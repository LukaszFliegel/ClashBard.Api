using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.StaticData.Repositories;
using ClashBard.Tow.StaticData.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.StaticData.FactionRepositories;

public class DarkElvesRepository : IFactionRepository
{
    private List<TowModel> Models = new List<TowModel>();
    private List<TowCharacter> Characters = new List<TowCharacter>();
    private List<TowModelMount> Mounts = new List<TowModelMount>();
    private readonly IFactionsListRepository _factionsRepository;

    public DarkElvesRepository(IFactionsListRepository factionsRepository)
    {        
        _factionsRepository = factionsRepository;

        SeedData();
    }

    public TowModel GetModelByType(Enum modelType)
    {
        var model = Models.Single(m => m.ModelType == modelType);
        return model;
    }

    public TowCharacter GetCharacterByType(Enum characterType)
    {
        var character = Characters.Single(c => c.ModelType == characterType);
        return character;
    }

    private void SeedData()
    {
        //var darkElvesFaction = _factionsRepository.GetByType(TowFactionType.DarkElvesName);

        //var reaperBoltThrowerCrew = new TowModelAdditional { Id = 1, Name = "Dark Elf Crew", Movement = 5, WeaponSkill = 4, BallisticSkill = 4, Strength = 3, Toughness = 3, Wounds = 2, Initiative = 4, Attacks = 2, Leadership = 8, Faction = darkElvesFaction };
        //var CauldronOfBloodCrew = new TowModelAdditional { Id = 2, Name = "Which Elf Crew", Movement = null, WeaponSkill = 4, BallisticSkill = 4, Strength = 3, Toughness = null, Wounds = null, Initiative = 5, Attacks = 1, Leadership = 9, Faction = darkElvesFaction };
        //var beasmasterHandlers = new TowModelAdditional { Id = 3, Name = "Beastmaster Handlers", Movement = 6, WeaponSkill = 4, BallisticSkill = 4, Strength = 3, Toughness = 3, Wounds = 2, Initiative = 4, Attacks = 1, Leadership = 8, Faction = darkElvesFaction };

        //var tempMounts = new List<TowModelMount>
        //{
        //    new TowModelMount { Id = 1, Name = "Dark Steed", Movement = 9, WeaponSkill = 3, Strength = 3, ToughnessAdded = 0, WoundsAdded = 0, Initiative = 4, Attacks = 1, PointsCostAdded = 14, ModelTroopType = TowModelTroopType.LightCavalry, Faction = darkElvesFaction },
        //    new TowModelMount { Id = 2, Name = "Cold One", Movement = 7, WeaponSkill = 3, Strength = 4, ToughnessAdded = 1, WoundsAdded = 0, Initiative = 2, Attacks = 2, PointsCostAdded = 18, ModelTroopType = TowModelTroopType.HeavyCavalry, Faction = darkElvesFaction },
        //    new TowModelMount { Id = 3, Name = "Dark Pegasus", Movement = 8, WeaponSkill = 3, Strength = 4, ToughnessAdded = 0, WoundsAdded = 1, Initiative = 4, Attacks = 3, PointsCostAdded = 35, ModelTroopType = TowModelTroopType.MonstrousCavalry, Faction = darkElvesFaction },
        //    new TowModelMount { Id = 4, Name = "Manticore", Movement = 6, WeaponSkill = 5, Strength = 5, ToughnessAdded = 1, WoundsAdded = 4, Initiative = 3, Attacks = 5, PointsCostAdded = 130, ModelTroopType = TowModelTroopType.MonstrousCreature, Faction = darkElvesFaction },
        //    new TowModelMount { Id = 5, Name = "Black Dragon", Movement = 6, WeaponSkill = 6, Strength = 7, ToughnessAdded = 3, WoundsAdded = 6, Initiative = 4, Attacks = 6, PointsCostAdded = 280, ModelTroopType = TowModelTroopType.Behemoth, Faction = darkElvesFaction },
        //    new TowModelMount
        //    {
        //        Id = 6,
        //        Name = "Cauldron Of Blood",
        //        Movement = 2,
        //        WeaponSkill = null,
        //        Strength = 5,
        //        Toughness = 5,
        //        Wounds = 5,
        //        Initiative = null,
        //        Attacks = null,
        //        PointsCostAdded = 150,
        //        ModelTroopType = TowModelTroopType.HeavyChariot,
        //        Faction = darkElvesFaction,
        //        Crew = new List<TowModelAdditional> { CauldronOfBloodCrew, CauldronOfBloodCrew }
        //    }
        //};

        //Mounts.AddRange(tempMounts);

        //var tempModels = new List<TowModel>
        //{            

        //    new TowModel { ModelType = TowDarkElfModelType.DarkElfWarriors, ModelSlotType = TowModelSlotType.Core, ModelTroopType = TowModelTroopType.Infantry, Movement = 5, WeaponSkill = 4, BallisticSkill = 4, Strength = 3, Toughness = 3, Wounds = 1, Initiative = 4, Attacks = 1, Leadership = 8, Faction = darkElvesFaction,
        //        Crew = null },
        //    new TowModel { Id = 9, Name = "Repeater Crossbowman", ModelSlotType = TowModelSlotType.Core, ModelTroopType = TowModelTroopType.Infantry, Movement = 5, WeaponSkill = 4, BallisticSkill = 4, Strength = 3, Toughness = 3, Wounds = 1, Initiative = 4, Attacks = 1, Leadership = 8, Faction = darkElvesFaction },
        //    new TowModel { Id = 25, Name = "Dark Riders", ModelSlotType = TowModelSlotType.Core, ModelTroopType = TowModelTroopType.LightCavalry, Movement = 5, WeaponSkill = 4, BallisticSkill = 4, Strength = 3, Toughness = 3, Wounds = 1, Initiative = 4, Attacks = 1, Leadership = 8, Faction = darkElvesFaction },
        //    new TowModel { Id = 26, Name = "Black Ark Corsairs", ModelSlotType = TowModelSlotType.Core, ModelTroopType = TowModelTroopType.Infantry, Movement = 5, WeaponSkill = 4, BallisticSkill = 4, Strength = 3, Toughness = 3, Wounds = 1, Initiative = 4, Attacks = 1, Leadership = 8, Faction = darkElvesFaction },

        //    new TowModel { Id = 10, Name = "Black Guard of Naggarond", ModelSlotType = TowModelSlotType.Special, ModelTroopType = TowModelTroopType.Infantry, Movement = 5, WeaponSkill = 3, BallisticSkill = 0, Strength = 4, Toughness = 3, Wounds = 2, Initiative = 2, Attacks = 1, Leadership = 6, Faction = darkElvesFaction },
        //    new TowModel { Id = 11, Name = "Scourgerunner Chariot", ModelSlotType = TowModelSlotType.Special, ModelTroopType = TowModelTroopType.LightChariot, Movement = 2, WeaponSkill = 0, BallisticSkill = 0, Strength = 0, Toughness = 6, Wounds = 2, Initiative = 0, Attacks = 0, Leadership = 0, Faction = darkElvesFaction },
        //    //new TowModel { Id = 12, Name = "Beastmaster Crew", ModelSlotType = TowModelSlotType.Core, Movement = 5, WeaponSkill = 4, BallisticSkill = 4, Strength = 3, Toughness = 3, Wounds = 1, Initiative = 4, Attacks = 1, Leadership = 8, Faction = darkEvlesFaction },
        //    //new TowModel { Id = 13, Name = "Dark Steed", ModelSlotType = TowModelSlotType.Core, Movement = 9, WeaponSkill = 3, BallisticSkill = 0, Strength = 3, Toughness = 3, Wounds = 1, Initiative = 4, Attacks = 1, Leadership = 0, Faction = darkEvlesFaction },
        //    new TowModel { Id = 14, Name = "Cold One Chariot", ModelSlotType = TowModelSlotType.Special, ModelTroopType = TowModelTroopType.HeavyChariot, Movement = 2, WeaponSkill = 0, BallisticSkill = 0, Strength = 0, Toughness = 5, Wounds = 4, Initiative = 0, Attacks = 0, Leadership = 0, Faction = darkElvesFaction },

        //    new TowModel { Id = 24, Name = "Dark Elf Shades", ModelSlotType = TowModelSlotType.Special, ModelTroopType = TowModelTroopType.Infantry, Movement = 5, WeaponSkill = 5, BallisticSkill = 5, Strength = 3, Toughness = 3, Wounds = 1, Initiative = 5, Attacks = 1, Leadership = 8, Faction = darkElvesFaction },
        //    //new TowModel { Id = 15, Name = "Knight Charioteer", ModelSlotType = TowModelSlotType.Core, Movement = 5, WeaponSkill = 5, BallisticSkill = 4, Strength = 4, Toughness = 3, Wounds = 1, Initiative = 5, Attacks = 1, Leadership = 9, Faction = darkEvlesFaction },
        //    //new TowModel { Id = 16, Name = "Cold One", ModelSlotType = TowModelSlotType.Core, Movement = 7, WeaponSkill = 3, BallisticSkill = 0, Strength = 4, Toughness = 3, Wounds = 1, Initiative = 2, Attacks = 2, Leadership = 0, Faction = darkEvlesFaction },
        //    //new TowModel { Id = 17, Name = "Black Dragon", ModelSlotType = TowModelSlotType.Core, Movement = 6, WeaponSkill = 6, BallisticSkill = 0, Strength = 7, Toughness = 3, Wounds = 6, Initiative = 3, Attacks = 5, Leadership = 7, Faction = darkEvlesFaction },
        //    //new TowModel { Id = 18, Name = "Manticore", ModelSlotType = TowModelSlotType.Core, Movement = 6, WeaponSkill = 5, BallisticSkill = 0, Strength = 5, Toughness = 1, Wounds = 4, Initiative = 3, Attacks = 5, Leadership = 7, Faction = darkEvlesFaction },

        //    new TowModel { Id = 19, Name = "War Hydra", ModelSlotType = TowModelSlotType.Rare, ModelTroopType = TowModelTroopType.Behemoth, Movement = 6, WeaponSkill = 4, BallisticSkill = 0, Strength = 5, Toughness = 5, Wounds = 5, Initiative = 3, Attacks = 2, Leadership = 6, Faction = darkElvesFaction, Crew = new List<TowModelAdditional> { beasmasterHandlers, beasmasterHandlers } },
        //    //new TowModel { Id = 20, Name = "Beastmaster Handlers", ModelSlotType = TowModelSlotType.Core, Movement = 6, WeaponSkill = 4, BallisticSkill = 4, Strength = 3, Toughness = 3, Wounds = 2, Initiative = 4, Attacks = 1, Leadership = 8, Faction = darkEvlesFaction },
        //    new TowModel { Id = 21, Name = "Bloodwrack Medusa", ModelSlotType = TowModelSlotType.Rare, ModelTroopType = TowModelTroopType.MonstrousCreature, Movement = 7, WeaponSkill = 5, BallisticSkill = 5, Strength = 4, Toughness = 4, Wounds = 4, Initiative = 5, Attacks = 3, Leadership = 7, Faction = darkElvesFaction },
        //    new TowModel { Id = 22, Name = "Kharibdyss", ModelSlotType = TowModelSlotType.Rare, ModelTroopType = TowModelTroopType.Behemoth, Movement = 6, WeaponSkill = 5, BallisticSkill = 0, Strength = 7, Toughness = 5, Wounds = 5, Initiative = 3, Attacks = 5, Leadership = 6, Faction = darkElvesFaction },
        //    new TowModel { Id = 23, Name = "Reaper Bolt Thrower", ModelSlotType = TowModelSlotType.Rare, ModelTroopType = TowModelTroopType.WarMachine, Movement = 0, WeaponSkill = 0, BallisticSkill = 0, Strength = 0, Toughness = 6, Wounds = 2, Initiative = 0, Attacks = 0, Leadership = 0, Faction = darkElvesFaction, Crew = new List<TowModelAdditional>() { reaperBoltThrowerCrew } }
        //};

        //Models.AddRange(tempModels);

        //var tempCharacters = new List<TowCharacter>
        //{
        //    new TowCharacter { Id = 1, Name = "Dark Elf Dreadlord", ModelSlotType = TowModelSlotType.Character, ModelTroopType = TowModelTroopType.Infantry, Movement = 5, WeaponSkill = 7, BallisticSkill = 7, Strength = 4, Toughness = 3, Wounds = 3, Initiative = 6, Attacks = 4, Leadership = 10, Faction = darkElvesFaction },
        //    new TowCharacter { Id = 2, Name = "Dark Elf Master", ModelSlotType = TowModelSlotType.Character, ModelTroopType = TowModelTroopType.Infantry, Movement = 5, WeaponSkill = 6, BallisticSkill = 6, Strength = 4, Toughness = 3, Wounds = 2, Initiative = 5, Attacks = 3, Leadership = 9, Faction = darkElvesFaction },
        //    new TowCharacter { Id = 3, Name = "Supreme Sorceress", ModelSlotType = TowModelSlotType.Character, ModelTroopType = TowModelTroopType.Infantry, Movement = 5, WeaponSkill = 4, BallisticSkill = 4, Strength = 3, Toughness = 3, Wounds = 3, Initiative = 5, Attacks = 2, Leadership = 8, Faction = darkElvesFaction },
        //    new TowCharacter { Id = 4, Name = "Sorceress", ModelSlotType = TowModelSlotType.Character, ModelTroopType = TowModelTroopType.Infantry, Movement = 5, WeaponSkill = 4, BallisticSkill = 4, Strength = 3, Toughness = 3, Wounds = 2, Initiative = 4, Attacks = 1, Leadership = 8, Faction = darkElvesFaction },
        //    new TowCharacter { Id = 5, Name = "High Beastmaster", ModelSlotType = TowModelSlotType.Character, ModelTroopType = TowModelTroopType.Infantry, Movement = 5, WeaponSkill = 7, BallisticSkill = 7, Strength = 4, Toughness = 3, Wounds = 3, Initiative = 5, Attacks = 3, Leadership = 9, Faction = darkElvesFaction },
        //    new TowCharacter { Id = 6, Name = "Death Hag", ModelSlotType = TowModelSlotType.Character, ModelTroopType = TowModelTroopType.Infantry, Movement = 5, WeaponSkill = 6, BallisticSkill = 6, Strength = 4, Toughness = 3, Wounds = 2, Initiative = 7, Attacks = 3, Leadership = 8, Faction = darkElvesFaction },
        //    new TowCharacter { Id = 7, Name = "Khainite Assassin", ModelSlotType = TowModelSlotType.Character, ModelTroopType = TowModelTroopType.Infantry, Movement = 5, WeaponSkill = 8, BallisticSkill = 7, Strength = 4, Toughness = 3, Wounds = 2, Initiative = 7, Attacks = 3, Leadership = 8, Faction = darkElvesFaction },
        //};

        //Characters.AddRange(tempCharacters);
    }    
}
