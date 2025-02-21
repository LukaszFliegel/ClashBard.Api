using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.DarkElves.ArcaneItems;

public class TomeOfFurionTowArcaneItem : TowArcaneItem
{
    private const int points = 15;

    public TomeOfFurionTowArcaneItem(TowObject owner) : base(owner, TowDarkElvesMagicItemType.TomeOfFurion, points)
    {
        AssignSpecialRule(new PlusOneSpell());
    }
}
