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

    public List<TowUnit> Units { get; set; }

    public TowCharacter General { get; set; }
}
