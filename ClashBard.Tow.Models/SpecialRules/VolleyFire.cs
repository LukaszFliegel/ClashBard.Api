using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class VolleyFire : TowSpecialRule
{
    private static new string ShortDescription = "Bows and other weapons can loose their projectiles in a high-arcing volley. Even warriors who cannot see the foe can shoot in their general direction.";
    private static new string LongDescription = "When a unit with this special rule makes a shooting attack, half of the models in each rank other than the front rank (or front two ranks if the unit is on a hill), rounding up, can shoot (in addition to the usual models that shoot from the front rank, or front two ranks if the unit is on a hill). A unit cannot Volley Fire if it has moved for any reason during this turn (including reforming), or when making a Stand & Shoot charge reaction. Note that models in rear ranks use the line of sight of the model at the front of their file.";

    public VolleyFire()
        : base(TowSpecialRuleType.VolleyFire,
            ShortDescription,
            LongDescription)
    {

    }
}
