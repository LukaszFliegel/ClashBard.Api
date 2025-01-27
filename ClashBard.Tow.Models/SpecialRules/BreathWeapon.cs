using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class BreathWeapon : TowSpecialRule
{
    private static string ShortDescription = "Some creatures or constructs belch clouds of flame or noxious choking fumes at their foes.";
    private static string LongDescription = "A model with a Breath Weapon can use it once per round, during the Shooting phase of its turn. Place the flame template with its broad end over the intended target and its narrow end touching the model's base edge anywhere along its front arc. The template must lie entirely within the model's vision arc. Any model whose base lies underneath the template risks being hit. The Strength and any special rules of the breath weapon will be detailed in the creature's rules. Breath weapons cannot be used when making a Stand & Shoot charge reaction, or when the model is engaged in combat.";

    public BreathWeapon()
        : base(TowSpecialRuleType.BreathWeapon,
            ShortDescription,
            LongDescription,
            printShortDescription: false)
    {

    }
}
