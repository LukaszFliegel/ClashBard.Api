using ClashBard.Api.Services;
using ClashBard.Tow.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<TowDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ClashBardConnection")));

builder.Services.AddSingleton<ICatalogService, DarkElvesCatalogService>();
builder.Services.AddScoped<IArmyBuilderService, DarkElvesArmyBuilderService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactDev", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("ReactDev");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
