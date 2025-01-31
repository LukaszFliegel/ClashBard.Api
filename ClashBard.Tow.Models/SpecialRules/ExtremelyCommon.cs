//using ClashBard.Tow.Models;
//using ClashBard.Tow.Models.SpecialRules.Interfaces;
//using ClashBard.Tow.Models.TowTypes;

//namespace ClashBard.Tow.Models.SpecialRules;

//public class ExtremelyCommon : TowSpecialRule, IExtremelyCommon
//{
//    private static string ShortDescription = "A unit with this special rule may be held in reserve rather than be deployed at the start of the game.";
//    private static string LongDescription = "From the beginning of round two onwards, roll a D6 during each of your Start of Turn sub-phases for each unit of Ambushers in your army that is held in reserve. On a roll of 1-3, the unit is delayed until your next turn at least. On a roll of 4+, the unit arrives, entering the battle as reinforcements during the Compulsory Moves sub-phase. The unit may be placed on any edge of the battlefield, chosen by its controlling player, but cannot be placed within 8\" of an enemy model. If any Ambushers are still held in reserve by the start of round five, they arrive automatically.";

//    public ExtremelyCommon(int numberOfOccurences)
//        : base(TowSpecialRuleType.ExtremelyCommon,
//            ShortDescription,
//            LongDescription)
//    {
//        NumberOfOccurences = numberOfOccurences;
//    }

//    // used to define it is the same object when comparing extremelly common items (used in magic item GetHashCode())
//    //public Guid Id { get; private set; }

//    public int NumberOfOccurences { get; private set; }
//}
