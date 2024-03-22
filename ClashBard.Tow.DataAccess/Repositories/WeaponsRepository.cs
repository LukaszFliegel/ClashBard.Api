//using ClashBard.Tow.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ClashBard.Tow.DataAccess.Repositories;
//public class WeaponsRepository
//{
//    private readonly TowDbContext _towDbContext;

//    public WeaponsRepository(TowDbContext towDbContext)
//    {
//        _towDbContext = towDbContext;
//    }

//    public TowWeapon GetWeaponByName(string name)
//    {
//        var weapon = _towDbContext.TowWeapons.Where(p => p.Name.ToLower().Equals(name.ToLower())).Single();
//        return weapon;
//    }
//}
