﻿using ClashBard.Tow.Models.TowTypes;
using System.ComponentModel.DataAnnotations;

namespace ClashBard.Tow.Models;

public class TowWeapon
{
    //[Key]
    //public int Id { get; set; }

    public required TowWeaponType WeaponType { get; set; }
    //public required string Name { get; set; }

    public int Range { get; set; } = 0;

    public TowWeaponStrength Strength { get; set; }

    public int ArmorPiercing { get; set; }

    //public virtual ICollection<int>? SpecialRuleId { get; set; }
    public virtual ICollection<TowSpecialRule>? SpecialRules { get; set; }

    //public required TowModel OwnerModel { get; set; }

    //public void AssigneToOwner()
    //{
    //    if(OwnerModel == null)
    //    {
    //        throw new Exception($"Owner model of {Name} weapon not set");
    //    }

    //    OwnerModel.Weapons.Add(this);
    //}

    //public void UnassigneFromOwner()
    //{
    //    if (OwnerModel == null)
    //    {
    //        throw new Exception($"Owner model of {Name} weapon not set");
    //    }

    //    OwnerModel.Weapons.Remove(this);
    //}
}

public enum TowWeaponStrength
{
    S = 1,
    Splus1,
    Splus2,
    Splus3,
    Three,
    Four,
}