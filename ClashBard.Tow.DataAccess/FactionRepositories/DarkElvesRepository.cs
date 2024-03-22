//using ClashBard.Tow.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ClashBard.Tow.DataAccess.FactionRepositories;
//public class DarkElvesRepository
//{
//    private readonly TowDbContext _towDbContext;

//    public DarkElvesRepository(TowDbContext towDbContext)
//    {
//        _towDbContext = towDbContext;
//    }

//    public TowModel GetModelByName(string name)
//    {
//        var model = _towDbContext.TowModels.Where(p => p.Name.ToLower().Equals(name.ToLower())).Single();
//        return model;
//    }

//    public TowCharacter GetCharacterByName(string name)
//    {
//        var character = _towDbContext.TowModels.Where(p => p.Name.ToLower().Equals(name.ToLower()) && p.ModelSlotType == TowModelSlotType.Character).Single() as TowCharacter;
//        return character;
//    }
//}
