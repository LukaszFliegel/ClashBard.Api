using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.ClassProducer.ConsoleApp.Models;
public class TowBuilderMagicItems
{
    public General[] general { get; set; }
    public KingdomOfBretonnia[] kingdomofbretonnia { get; set; }
    public KnightlyVirtues[] knightlyvirtues { get; set; }
    public EmpireOfMan[] empireofman { get; set; }
    public DwarfenMountainHolds[] dwarfenmountainholds { get; set; }
    public OrcAndGoblinTribes[] orcandgoblintribes { get; set; }
    public BeastmenBrayherds[] beastmenbrayherds { get; set; }
    public ForestSpites[] forestspites { get; set; }
    public TombKingsOfKhemri[] tombkingsofkhemri { get; set; }
    public WarriorsOfChaos[] warriorsofchaos { get; set; }
    public GiftsOfChaos[] giftsofchaos { get; set; }
    public ChaosMutations[] chaosmutations { get; set; }
    public WoodElfRealms[] woodelfrealms { get; set; }
    public HighElfRealms[] highelfrealms { get; set; }
    public ElvenHonours[] elvenhonours { get; set; }
    public ChaosDwarfs[] chaosdwarfs { get; set; }
    public Lizardman[] lizardmen { get; set; }
    public DisciplinesOldOnes[] disciplinesoldones { get; set; }
    public DarkElves[] darkelves { get; set; }
    public OgreKingdoms[] ogrekingdoms { get; set; }
    public BigNames[] bignames { get; set; }
    public Skaven[] skaven { get; set; }
    public VampireCounts[] vampirecounts { get; set; }
    public DaemonicGiftsCommon[] daemonicgiftscommon { get; set; }
    public DaemonicIconsCommon[] daemoniciconscommon { get; set; }
    public DaemonicGiftsKhorne[] daemonicgiftskhorne { get; set; }
    public DaemonicIconsKhorne[] daemoniciconskhorne { get; set; }
    public DaemonicGiftsNurgle[] daemonicgiftsnurgle { get; set; }
    public DaemonicIconsNurgle[] daemoniciconsnurgle { get; set; }
    public DaemonicGiftsSlaanesh[] daemonicgiftsslaanesh { get; set; }
    public DaemonicIconsSlaanesh[] daemoniciconsslaanesh { get; set; }
    public DaemonicGiftsTzeentch[] daemonicgiftstzeentch { get; set; }
    public DaemonicIconsTzeentch[] daemoniciconstzeentch { get; set; }
    public VampiricPowers[] vampiricpowers { get; set; }
    public ForbiddenPoisons[] forbiddenpoisons { get; set; }
    public GiftsOfKhaine[] giftsofkhaine { get; set; }
}

public class General
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public string name_pl { get; set; }
    public int points { get; set; }
    public string type { get; set; }
    public bool stackable { get; set; }
}

public class KingdomOfBretonnia
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public string name_pl { get; set; }
    public int points { get; set; }
    public string type { get; set; }
    public string armyComposition { get; set; }
    public bool stackable { get; set; }
}

public class KnightlyVirtues
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public int points { get; set; }
    public string type { get; set; }
}

public class EmpireOfMan
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public string name_pl { get; set; }
    public int points { get; set; }
    public string type { get; set; }
    public bool stackable { get; set; }
}

public class DwarfenMountainHolds
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public string name_pl { get; set; }
    public int points { get; set; }
    public string type { get; set; }
    public int maximum { get; set; }
    public int minimum { get; set; }
    public bool stackable { get; set; }
}

public class OrcAndGoblinTribes
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public int points { get; set; }
    public string type { get; set; }
    public bool stackable { get; set; }
}

public class BeastmenBrayherds
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public int points { get; set; }
    public string type { get; set; }
    public bool stackable { get; set; }
}

public class ForestSpites
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public bool nonExclusive { get; set; }
    public int points { get; set; }
    public string type { get; set; }
}

public class TombKingsOfKhemri
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public int points { get; set; }
    public string type { get; set; }
    public string armyComposition { get; set; }
    public bool stackable { get; set; }
    public int maximum { get; set; }
}

public class WarriorsOfChaos
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public int points { get; set; }
    public string type { get; set; }
    public bool stackable { get; set; }
}

public class GiftsOfChaos
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public int points { get; set; }
    public bool stackable { get; set; }
    public string type { get; set; }
}

public class ChaosMutations
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public bool nonExclusive { get; set; }
    public int points { get; set; }
    public string type { get; set; }
}

public class WoodElfRealms
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public int points { get; set; }
    public string type { get; set; }
    public int maximum { get; set; }
    public bool stackable { get; set; }
}

public class HighElfRealms
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public int points { get; set; }
    public string type { get; set; }
    public bool stackable { get; set; }
}

public class ElvenHonours
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public int points { get; set; }
    public string type { get; set; }
}

public class ChaosDwarfs
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public int points { get; set; }
    public string type { get; set; }
    public bool nonExclusive { get; set; }
    public bool stackable { get; set; }
}

public class Lizardman
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public int points { get; set; }
    public string type { get; set; }
    public bool stackable { get; set; }
}

public class DisciplinesOldOnes
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public int points { get; set; }
    public string type { get; set; }
}

public class DarkElves
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public int points { get; set; }
    public string type { get; set; }
    public bool stackable { get; set; }
}

public class OgreKingdoms
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public int points { get; set; }
    public string type { get; set; }
}

public class BigNames
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public int points { get; set; }
    public string type { get; set; }
}

public class Skaven
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public int points { get; set; }
    public string type { get; set; }
    public bool stackable { get; set; }
}

public class VampireCounts
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public int points { get; set; }
    public string type { get; set; }
    public bool stackable { get; set; }
}

public class DaemonicGiftsCommon
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public int points { get; set; }
    public string type { get; set; }
    public string namefr { get; set; }
    public bool stackable { get; set; }
}

public class DaemonicIconsCommon
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public int points { get; set; }
    public string type { get; set; }
}

public class DaemonicGiftsKhorne
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public int points { get; set; }
    public string type { get; set; }
    public bool stackable { get; set; }
}

public class DaemonicIconsKhorne
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public int points { get; set; }
    public string type { get; set; }
}

public class DaemonicGiftsNurgle
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public int points { get; set; }
    public string type { get; set; }
    public bool stackable { get; set; }
}

public class DaemonicIconsNurgle
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public int points { get; set; }
    public string type { get; set; }
}

public class DaemonicGiftsSlaanesh
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public int points { get; set; }
    public string type { get; set; }
    public bool stackable { get; set; }
}

public class DaemonicIconsSlaanesh
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public int points { get; set; }
    public string type { get; set; }
}

public class DaemonicGiftsTzeentch
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public int points { get; set; }
    public string type { get; set; }
    public bool stackable { get; set; }
}

public class DaemonicIconsTzeentch
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public int points { get; set; }
    public string type { get; set; }
    public bool stackable { get; set; }
}

public class VampiricPowers
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public bool nonExclusive { get; set; }
    public int points { get; set; }
    public string type { get; set; }
}

public class ForbiddenPoisons
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public int points { get; set; }
    public string type { get; set; }
}

public class GiftsOfKhaine
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public string name_it { get; set; }
    public int points { get; set; }
    public string type { get; set; }
}
