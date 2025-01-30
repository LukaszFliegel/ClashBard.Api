using ClashBard.Tow.Models;
using ClashBard.Tow.Models.SpecialRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.Models.Weapons;

public class AdditionalHandWeaponTowWeapon : TowWeapon
{   
    public AdditionalHandWeaponTowWeapon(TowObject owner) : base(owner, TowTypes.TowWeaponType.AdditionalHandWeapon, 0, TowWeaponStrength.S, 0)
    {
        AssignSpecialRule(new ExtraAttacksPlus1());
    }
}
