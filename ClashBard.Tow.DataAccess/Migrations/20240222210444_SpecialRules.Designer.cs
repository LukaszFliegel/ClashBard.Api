﻿// <auto-generated />
using ClashBard.Tow.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClashBard.Tow.DataAccess.Migrations
{
    [DbContext(typeof(TowDbContext))]
    [Migration("20240222210444_SpecialRules")]
    partial class SpecialRules
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClashBard.Tow.Models.TowFaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WarhammerFactions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Empire of Man"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Orc & Goblin Tribes"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Dwarfen Mountain Holds"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Warriors of Chaos"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Kingdom of Bretonnia"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Beastmen Brayherds"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Wood Elf Realms"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Tomb Kings of Khemri"
                        },
                        new
                        {
                            Id = 9,
                            Name = "High Elf Realms"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Dark Elves"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Skaven"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Vampire Counts"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Daemons of Chaos"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Ogre Kingdoms"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Lizardmen"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Chaos Dwarfs"
                        });
                });

            modelBuilder.Entity("ClashBard.Tow.Models.TowModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Attacks")
                        .HasColumnType("int");

                    b.Property<int>("BallisticSkill")
                        .HasColumnType("int");

                    b.Property<int>("FactionId")
                        .HasColumnType("int");

                    b.Property<int>("Initiative")
                        .HasColumnType("int");

                    b.Property<int>("Leadership")
                        .HasColumnType("int");

                    b.Property<int>("Movement")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.Property<int>("Toughness")
                        .HasColumnType("int");

                    b.Property<int>("WeaponSkill")
                        .HasColumnType("int");

                    b.Property<int>("Wounds")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FactionId");

                    b.ToTable("TowModels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Attacks = 4,
                            BallisticSkill = 7,
                            FactionId = 10,
                            Initiative = 6,
                            Leadership = 10,
                            Movement = 5,
                            Name = "Dark Elf Dreadlord",
                            Strength = 4,
                            Toughness = 3,
                            WeaponSkill = 7,
                            Wounds = 3
                        },
                        new
                        {
                            Id = 2,
                            Attacks = 3,
                            BallisticSkill = 6,
                            FactionId = 10,
                            Initiative = 5,
                            Leadership = 9,
                            Movement = 5,
                            Name = "Dark Elf Master",
                            Strength = 4,
                            Toughness = 3,
                            WeaponSkill = 6,
                            Wounds = 2
                        },
                        new
                        {
                            Id = 3,
                            Attacks = 2,
                            BallisticSkill = 4,
                            FactionId = 10,
                            Initiative = 5,
                            Leadership = 8,
                            Movement = 5,
                            Name = "Supreme Sorceress",
                            Strength = 3,
                            Toughness = 3,
                            WeaponSkill = 4,
                            Wounds = 3
                        },
                        new
                        {
                            Id = 4,
                            Attacks = 1,
                            BallisticSkill = 4,
                            FactionId = 10,
                            Initiative = 4,
                            Leadership = 8,
                            Movement = 5,
                            Name = "Sorceress",
                            Strength = 3,
                            Toughness = 3,
                            WeaponSkill = 4,
                            Wounds = 2
                        },
                        new
                        {
                            Id = 5,
                            Attacks = 3,
                            BallisticSkill = 7,
                            FactionId = 10,
                            Initiative = 5,
                            Leadership = 9,
                            Movement = 5,
                            Name = "High Beastmaster",
                            Strength = 4,
                            Toughness = 3,
                            WeaponSkill = 7,
                            Wounds = 3
                        },
                        new
                        {
                            Id = 6,
                            Attacks = 3,
                            BallisticSkill = 6,
                            FactionId = 10,
                            Initiative = 7,
                            Leadership = 8,
                            Movement = 5,
                            Name = "Death Hag",
                            Strength = 4,
                            Toughness = 3,
                            WeaponSkill = 6,
                            Wounds = 2
                        },
                        new
                        {
                            Id = 7,
                            Attacks = 3,
                            BallisticSkill = 7,
                            FactionId = 10,
                            Initiative = 7,
                            Leadership = 8,
                            Movement = 5,
                            Name = "Khainite Assassin",
                            Strength = 4,
                            Toughness = 3,
                            WeaponSkill = 8,
                            Wounds = 2
                        },
                        new
                        {
                            Id = 8,
                            Attacks = 1,
                            BallisticSkill = 4,
                            FactionId = 10,
                            Initiative = 4,
                            Leadership = 8,
                            Movement = 5,
                            Name = "Dark Elf Warrior",
                            Strength = 3,
                            Toughness = 3,
                            WeaponSkill = 4,
                            Wounds = 1
                        },
                        new
                        {
                            Id = 9,
                            Attacks = 1,
                            BallisticSkill = 4,
                            FactionId = 10,
                            Initiative = 4,
                            Leadership = 8,
                            Movement = 5,
                            Name = "Repeater Crossbowman",
                            Strength = 3,
                            Toughness = 3,
                            WeaponSkill = 4,
                            Wounds = 1
                        },
                        new
                        {
                            Id = 10,
                            Attacks = 1,
                            BallisticSkill = 0,
                            FactionId = 10,
                            Initiative = 2,
                            Leadership = 6,
                            Movement = 5,
                            Name = "Black Guard of Naggarond",
                            Strength = 4,
                            Toughness = 3,
                            WeaponSkill = 3,
                            Wounds = 2
                        },
                        new
                        {
                            Id = 11,
                            Attacks = 0,
                            BallisticSkill = 0,
                            FactionId = 10,
                            Initiative = 0,
                            Leadership = 0,
                            Movement = 2,
                            Name = "Scourgerunner Chariot",
                            Strength = 0,
                            Toughness = 6,
                            WeaponSkill = 0,
                            Wounds = 2
                        },
                        new
                        {
                            Id = 12,
                            Attacks = 1,
                            BallisticSkill = 4,
                            FactionId = 10,
                            Initiative = 4,
                            Leadership = 8,
                            Movement = 5,
                            Name = "Beastmaster Crew",
                            Strength = 3,
                            Toughness = 3,
                            WeaponSkill = 4,
                            Wounds = 1
                        },
                        new
                        {
                            Id = 13,
                            Attacks = 1,
                            BallisticSkill = 0,
                            FactionId = 10,
                            Initiative = 4,
                            Leadership = 0,
                            Movement = 9,
                            Name = "Dark Steed",
                            Strength = 3,
                            Toughness = 3,
                            WeaponSkill = 3,
                            Wounds = 1
                        },
                        new
                        {
                            Id = 14,
                            Attacks = 0,
                            BallisticSkill = 0,
                            FactionId = 10,
                            Initiative = 0,
                            Leadership = 0,
                            Movement = 2,
                            Name = "Cold One Chariot",
                            Strength = 0,
                            Toughness = 5,
                            WeaponSkill = 0,
                            Wounds = 4
                        },
                        new
                        {
                            Id = 15,
                            Attacks = 1,
                            BallisticSkill = 4,
                            FactionId = 10,
                            Initiative = 5,
                            Leadership = 9,
                            Movement = 5,
                            Name = "Knight Charioteer",
                            Strength = 4,
                            Toughness = 3,
                            WeaponSkill = 5,
                            Wounds = 1
                        },
                        new
                        {
                            Id = 16,
                            Attacks = 2,
                            BallisticSkill = 0,
                            FactionId = 10,
                            Initiative = 2,
                            Leadership = 0,
                            Movement = 7,
                            Name = "Cold One",
                            Strength = 4,
                            Toughness = 3,
                            WeaponSkill = 3,
                            Wounds = 1
                        },
                        new
                        {
                            Id = 17,
                            Attacks = 5,
                            BallisticSkill = 0,
                            FactionId = 10,
                            Initiative = 3,
                            Leadership = 7,
                            Movement = 6,
                            Name = "Black Dragon",
                            Strength = 7,
                            Toughness = 3,
                            WeaponSkill = 6,
                            Wounds = 6
                        },
                        new
                        {
                            Id = 18,
                            Attacks = 5,
                            BallisticSkill = 0,
                            FactionId = 10,
                            Initiative = 3,
                            Leadership = 7,
                            Movement = 6,
                            Name = "Manticore",
                            Strength = 5,
                            Toughness = 1,
                            WeaponSkill = 5,
                            Wounds = 4
                        },
                        new
                        {
                            Id = 19,
                            Attacks = 2,
                            BallisticSkill = 0,
                            FactionId = 10,
                            Initiative = 3,
                            Leadership = 6,
                            Movement = 6,
                            Name = "War Hydra",
                            Strength = 5,
                            Toughness = 5,
                            WeaponSkill = 4,
                            Wounds = 5
                        },
                        new
                        {
                            Id = 20,
                            Attacks = 1,
                            BallisticSkill = 4,
                            FactionId = 10,
                            Initiative = 4,
                            Leadership = 8,
                            Movement = 6,
                            Name = "Beastmaster Handlers",
                            Strength = 3,
                            Toughness = 3,
                            WeaponSkill = 4,
                            Wounds = 2
                        },
                        new
                        {
                            Id = 21,
                            Attacks = 3,
                            BallisticSkill = 5,
                            FactionId = 10,
                            Initiative = 5,
                            Leadership = 7,
                            Movement = 7,
                            Name = "Bloodwrack Medusa",
                            Strength = 4,
                            Toughness = 4,
                            WeaponSkill = 5,
                            Wounds = 4
                        },
                        new
                        {
                            Id = 22,
                            Attacks = 5,
                            BallisticSkill = 0,
                            FactionId = 10,
                            Initiative = 3,
                            Leadership = 6,
                            Movement = 6,
                            Name = "Kharibdyss",
                            Strength = 7,
                            Toughness = 5,
                            WeaponSkill = 5,
                            Wounds = 5
                        },
                        new
                        {
                            Id = 23,
                            Attacks = 0,
                            BallisticSkill = 0,
                            FactionId = 10,
                            Initiative = 0,
                            Leadership = 0,
                            Movement = 0,
                            Name = "Repeater Bolt Thrower",
                            Strength = 0,
                            Toughness = 6,
                            WeaponSkill = 0,
                            Wounds = 2
                        },
                        new
                        {
                            Id = 24,
                            Attacks = 2,
                            BallisticSkill = 4,
                            FactionId = 10,
                            Initiative = 4,
                            Leadership = 8,
                            Movement = 5,
                            Name = "Dark Elf Crew",
                            Strength = 3,
                            Toughness = 3,
                            WeaponSkill = 4,
                            Wounds = 2
                        });
                });

            modelBuilder.Entity("ClashBard.Tow.Models.TowModelSpecialRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LongDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TowModelSpecialRule");
                });

            modelBuilder.Entity("TowModelTowModelSpecialRule", b =>
                {
                    b.Property<int>("SpecialRulesId")
                        .HasColumnType("int");

                    b.Property<int>("TowModelId")
                        .HasColumnType("int");

                    b.HasKey("SpecialRulesId", "TowModelId");

                    b.HasIndex("TowModelId");

                    b.ToTable("TowModelTowModelSpecialRule");
                });

            modelBuilder.Entity("ClashBard.Tow.Models.TowModel", b =>
                {
                    b.HasOne("ClashBard.Tow.Models.TowFaction", "Faction")
                        .WithMany()
                        .HasForeignKey("FactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faction");
                });

            modelBuilder.Entity("TowModelTowModelSpecialRule", b =>
                {
                    b.HasOne("ClashBard.Tow.Models.TowModelSpecialRule", null)
                        .WithMany()
                        .HasForeignKey("SpecialRulesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClashBard.Tow.Models.TowModel", null)
                        .WithMany()
                        .HasForeignKey("TowModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}