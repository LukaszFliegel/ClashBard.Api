using ClashBard.Tow.Models;
using Microsoft.EntityFrameworkCore;

namespace ClashBard.Tow.DataAccess;

public class TowDbContext: DbContext
{
    public TowDbContext(DbContextOptions<TowDbContext> options)
        : base(options)
    {
    }

    //public DbSet<TowModel> TowModels { get; set; }

    //public DbSet<TowModelAdditional> TowModelAdditionals { get; set; }

    //public DbSet<TowFaction> TowFactions { get; set; }

    //public DbSet<TowSpecialRule> TowModelSpecialRules { get; set; }

    //public DbSet<TowWeapon> TowWeapons { get; set; }

    //public DbSet<TowArmor> TowArmors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Database=ClashBard")
                .EnableSensitiveDataLogging();
        }

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //var darkEvlesFaction = new TowFaction { Id = 10, Name = "Dark Elves" };

        //var towFactionList = new List<TowFaction>
        //{
        //    new TowFaction { Id = 1, Name = "Empire of Man" },
        //    new TowFaction { Id = 2, Name = "Orc & Goblin Tribes" },
        //    new TowFaction { Id = 3, Name = "Dwarfen Mountain Holds" },
        //    new TowFaction { Id = 4, Name = "Warriors of Chaos" },
        //    new TowFaction { Id = 5, Name = "Kingdom of Bretonnia" },
        //    new TowFaction { Id = 6, Name = "Beastmen Brayherds" },
        //    new TowFaction { Id = 7, Name = "Wood Elf Realms" },
        //    new TowFaction { Id = 8, Name = "Tomb Kings of Khemri" },
        //    new TowFaction { Id = 9, Name = "High Elf Realms" },
        //    darkEvlesFaction,
        //    new TowFaction { Id = 11, Name = "Skaven" },
        //    new TowFaction { Id = 12, Name = "Vampire Counts" },
        //    new TowFaction { Id = 13, Name = "Daemons of Chaos" },
        //    new TowFaction { Id = 14, Name = "Ogre Kingdoms" },
        //    new TowFaction { Id = 15, Name = "Lizardmen" },
        //    new TowFaction { Id = 16, Name = "Chaos Dwarfs" }
        //};

        //modelBuilder.Entity<TowFaction>().HasData(towFactionList);

        //var specialRules = SpecialRulesSeed.SeedSpecialRules(modelBuilder);

        //WeaponsSeed.SeedWeapons(modelBuilder, specialRules);
        //ArmorSeed.SeedArmors(modelBuilder, specialRules, towFactionList);

        //DarkElvesSeed.SeedDarkElves(modelBuilder, darkEvlesFaction);

    }    
}
