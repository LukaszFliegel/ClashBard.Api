using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;
using System.ComponentModel.DataAnnotations;

namespace ClashBard.Tow.Models;

public class TowUnit
{
    public readonly TowModel Model;
    private readonly int amount;
    private readonly TowFaction faction;
    private readonly bool standard;
    private readonly bool musician;
    private readonly bool champion;

    public TowUnit(TowModel model, int amount, TowFaction faction, bool standard, bool musician, bool champion)
    {
        this.Model = model;
        this.amount = amount;
        this.faction = faction;
        this.standard = standard;
        this.musician = musician;
        this.champion = champion;
    }

    public int GetAmount()
    {
        return amount;
    }

    public bool HasChampion()
    {
        return champion;
    }
}
