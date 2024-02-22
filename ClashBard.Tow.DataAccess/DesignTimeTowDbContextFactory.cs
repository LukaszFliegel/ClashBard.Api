using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace ClashBard.Tow.DataAccess;
public class DesignTimeTowDbContextFactory : IDesignTimeDbContextFactory<TowDbContext>
{
    public TowDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TowDbContext>();
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ClashBard");

        return new TowDbContext(optionsBuilder.Options);
    }
}
