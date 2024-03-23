using ClashBard.Tow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.Models.Weapons;

public class HandWeaponTowWeapon : TowWeapon
{   
    public HandWeaponTowWeapon() : base(TowTypes.TowWeaponType.HandWeapon, 0, TowWeaponStrength.S, 0)
    {
            
    }
}
