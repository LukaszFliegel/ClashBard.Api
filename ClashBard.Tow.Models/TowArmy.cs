using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.Models;
public class TowArmy
{
    public string Name { get; set; }
    public int Points { get; set; }
    public TowFaction Faction { get; set; }
    //public ICollection<TowModel> Models { get; set; }

    public List<TowCharacter> Characters { get; set; } = new List<TowCharacter>();

    public List<TowUnit> Units { get; set; } = new List<TowUnit>();

    public TowCharacter General { get; set; }

    public void Validate()
    {
        // check if lances are only in cavalry units/properly mounted characters

        // check if army has general

        // check for army compoistion rules (grand army/arcane journal)
    }
}
