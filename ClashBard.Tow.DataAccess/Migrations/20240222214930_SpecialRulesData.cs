using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashBard.Tow.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SpecialRulesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TowModels_WarhammerFactions_FactionId",
                table: "TowModels");

            migrationBuilder.DropForeignKey(
                name: "FK_TowModelTowModelSpecialRule_TowModelSpecialRule_SpecialRulesId",
                table: "TowModelTowModelSpecialRule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WarhammerFactions",
                table: "WarhammerFactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TowModelSpecialRule",
                table: "TowModelSpecialRule");

            migrationBuilder.RenameTable(
                name: "WarhammerFactions",
                newName: "TowFactions");

            migrationBuilder.RenameTable(
                name: "TowModelSpecialRule",
                newName: "TowModelSpecialRules");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TowFactions",
                table: "TowFactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TowModelSpecialRules",
                table: "TowModelSpecialRules",
                column: "Id");

            migrationBuilder.InsertData(
                table: "TowModelSpecialRules",
                columns: new[] { "Id", "LongDescription", "Name", "ShortDescription" },
                values: new object[,]
                {
                    { 1, "From the beginning of round two onwards, roll a D6 during each of your Start of Turn sub-phases for each unit of Ambushers in your army that is held in reserve. On a roll of 1-3, the unit is delayed until your next turn at least. On a roll of 4+, the unit arrives, entering the battle as reinforcements during the Compulsory Moves sub-phase. The unit may be placed on any edge of the battlefield, chosen by its controlling player, but cannot be placed within 8\" of an enemy model. If any Ambushers are still held in reserve by the start of round five, they arrive automatically.", "Ambushers", "A unit with this special rule may be held in reserve rather than be deployed at the start of the game." },
                    { 2, "If a model with this special rule rolls a natural 6 when making a roll To Wound, the Armour Piercing characteristic of its weapon is improved by the amount shown in brackets after the name of this special rule (shown here as 'X'). For example, if a natural 6 is rolled when rolling To Wound with a weapon that has an AP of ' - ' and the Armour Bane (1) special rule, its AP counts as being -1 when making an Armour Save roll against that wound.", "Armour Bane (X)", "Some weapons are particularly well-suited to piercing armour, though they often require great skill." },
                    { 3, "The hide of some creatures forms natural armour and improves their armour value (and that of their rider). By how much armour value is improved varies from model to model, as shown in brackets after the name of this special rule (shown here as 'X'). Note that a model that wears no armour is considered to have an armour value of 7+ for the purposes of rules that improve armour value.", "Armoured Hide (X)", "Many creatures have gnarled, tough or scaly skin that offers the same protection as wrought armour." },
                    { 4, "A model with a Breath Weapon can use it once per round, during the Shooting phase of its turn. Place the flame template with its broad end over the intended target and its narrow end touching the model's base edge anywhere along its front arc. The template must lie entirely within the model's vision arc. Any model whose base lies underneath the template risks being hit. The Strength and any special rules of the breath weapon will be detailed in the creature's rules. Breath weapons cannot be used when making a Stand & Shoot charge reaction, or when the model is engaged in combat.", "Breath Weapon", "Some creatures or constructs belch clouds of flame or noxious choking fumes at their foes." },
                    { 5, "Friendly models whose troop type is chariot can draw a line of sight over or through models with this special rule and can move through friendly units of Chariot Runners that are in Skirmish formation. If the chariot's move would result in it ending up 'on top' of a Chariot Runner, simply nudge the Chariot Runner aside, by the smallest amount possible, to make space for the chariot. Whilst in Skirmish formation units of Chariot Runners can treat friendly chariots that are within 1\" of one or more of the unit's models as a part of the unit for the purposes of unit coherency.", "Chariot Runners", "Chariots are often accompanied by light troops that fight at their side, protecting their vulnerable flanks from the enemy." },
                    { 6, "A unit consisting of models with this special rule may adopt a Close Order formation.", "Close Order", "The mainstay of any army is its regiments of close order infantry and cavalry." },
                    { 7, "This special rule can only be used by units that consist entirely of models with this special rule. When a unit with this special rule is charged in its front arc by an enemy unit whose troop type is cavalry, chariot or monster, it may declare a 'Counter Charge' charge reaction: Counter Charge. The unit surges forward to meet the enemy charge. Measure the distance between the two units. If the distance is less than the Movement characteristic of the charging unit, the charged unit has not enough time to meet the enemy charge and must either Hold or Flee instead. Otherwise, pivot the unit about its centre so that it is facing directly towards the centre of the charging enemy unit. After pivoting, the unit moves D3+1\" directly towards the enemy unit. Both units are considered to have charged during this turn. Fleeing units and units already engaged in combat when charged cannot Counter Charge. A unit can only Counter Charge in response to one charge per turn, even if charged by multiple units. Once all charges have been declared, the inactive player can choose which charging unit to Counter Charge. The unit will then Hold against the other charging units.", "Counter Charge", "Particularly bold and brash warriors view offence as the best form of defence." },
                    { 8, "Weapons with this special rule cannot be used when making a Stand & Shoot charge reaction.", "Cumbersome", "Some missile weapons are too cumbersome to be raised and aimed at a charging foe." },
                    { 9, "A unit with this special rule can be fielded as a detachment.", "Detachment", "Large regiments may be accompanied by smaller detachments." },
                    { 10, "A model with this special rule that begins its movement within 1\" of a friendly unit whose troop type is infantry, that is not fleeing and that contains ten or more models, may replace its Movement characteristic with that of the unit.", "Dragged Along", "Great war engines may be dragged to battle by hordes of infantry." },
                    { 11, "Unless it is fleeing, a Drilled unit may perform a free redress the ranks manoeuvre immediately before moving. Once this manoeuvre is complete, the unit moves as normal. In addition, a Drilled unit can march whilst within 8\" of an enemy unit without first having to make a Leadership test. Note that any character that joins a Drilled unit is considered to be Drilled as well.", "Drilled", "Some regiments spend endless hours training to perform complex manoeuvres." },
                    { 12, "Ethereal creatures treat all terrain as open ground for the purposes of movement. They cannot end their movement inside impassable terrain, though they can pass through it. In addition, Ethereal creatures can only be wounded by Magical attacks. Characters that are not Ethereal cannot join units that are, and vice versa.", "Ethereal", "Lacking physical bodies, some beings are immune to mundane weapons." },
                    { 13, "Once per turn, when this unit is declared the target during the enemy Shooting phase, it may choose to Fall Back in Good Order and will flee directly away from the enemy unit shooting at it. Once this unit has completed its move, the enemy unit may continue with its shooting as declared.", "Evasive", "In the face of enemy fire, it is often wise to step back! Some warriors are particularly adept at this manoeuvre." },
                    { 14, "A model with this special rule has a modifier to its Attacks characteristic, as shown in brackets after the name of this special rule (shown here as '+X'). If this modifier is determined by the roll of a dice, roll when the model's combat is chosen during any Choose & Fight Combat sub-phase.", "Extra Attacks (+X)", "Through fury, extra limbs, or being armed to the teeth, this warrior can strike more blows." },
                    { 15, "If all of the models (including characters) within a unit arrayed in an Open Order formation have this special rule, the unit may perform its Quick Turn even if it marched.", "Fast Cavalry", "A highly trained unit of cavalry is able to perform complex manoeuvres, even at a full gallop." },
                    { 16, "Models with this special rule cause Fear: If a unit wishes to declare a charge against an enemy unit that both causes Fear and has a higher Unit Strength, it must first make a Leadership test. If this test is failed, the unit cannot charge. It does not move and is considered to have made a failed charge. If this test is passed, the unit can charge as normal. If a unit is engaged with an enemy unit that both causes Fear and has a higher Unit Strength when its combat is chosen during any Choose & Fight Combat sub-phase, it must make a Leadership test. If this test is failed, any models in the unit that direct their attacks against the Fear-causing enemy suffer a -1 modifier to their rolls To Hit. A unit only needs to make one Fear test per turn. Models that cause Fear are immune to Fear. A unit that does not cause Fear does not become immune to Fear when joined by a character that does.", "Fear", "Particularly large or disturbing creatures provoke terrible fear in the foe." },
                    { 17, "If this unit chooses to Flee (or Fire & Flee) as a charge reaction, it automatically rallies at the end of its move.", "Feigned Flight", "Some units are adept at escaping from the foe and regrouping, drawing the enemy into careless charges before vanishing into the distance." },
                    { 18, "A model with this special rule may make a supporting attacks. Certain weapons, such as thrusting or throwing spears, allow warriors not in the fighting rank to attack from behind their comrades.", "Fight in Extra Rank", "A model with this special rule may make a supporting attacks. Certain weapons, such as thrusting or throwing spears, allow warriors not in the fighting rank to attack from behind their comrades." },
                    { 19, "A unit with this special rule that is also armed with missile weapons may declare that it will 'Fire & Flee' as a charge reaction: Fire & Flee. The unit launches a volley of weapons fire before turning to flee from the enemy. If a unit with this special rule is armed with missile weapons and can draw a line of sight to the charging unit, it may declare that it will Fire & Flee. The unit will Stand & Shoot before turning tail and fleeing from the charge. However, due to the time spent shooting at the charging foe, when making its Flee roll the unit rolls two D6 and discards the lowest result. If both dice roll the same result, discard either. Note that, if the distance between this unit and the charging unit is less than the Movement characteristic of the charging unit, this unit must either Hold or Flee.", "Fire & Flee", "The boldest of warriors armed with missile weapons will face down a charging enemy with volleys of fire, before turning and fleeing at the last possible moment." },
                    { 20, "If this unit's first charge of the game is successful (i.e., if the unit makes contact with the charge target), the charge target becomes Disrupted until the end of the Combat phase of that turn.", "First Charge", "The thundering charge of heavily armed and armoured warriors, freshly arrived upon the battlefield and eager for the fray, is devastating to the cowering foe." },
                    { 21, "Any attack made or hits caused by a model with this special rule, or made using a weapon or spell with this special rule, is a 'Flaming' attack. In addition, a model with this special rule causes Fear in models whose troop type is war beasts or swarms. Unless otherwise stated, a model with this special rule makes Flaming attacks both when shooting and in combat (though any spells cast by the model are unaffected, as are any attacks made with magic weapons they might be wielding).", "Flaming Attacks", "Fire is a fearsome thing on the battlefield, but some creatures are more vulnerable to it than others." },
                    { 22, "A model with this special rule cannot make a Regeneration save against a wound caused by a Flaming attack.", "Flammable", "Some creatures are especially vulnerable to fire. Once flame has been set to their flesh, it will burn out of control." },
                    { 23, "A model with this special rule can Fly. Models that can Fly can choose either to move normally on the ground (using their Movement characteristic), or to move by flying. How many inches a model can Fly varies from model to model, and will be shown in brackets after the name of this special rule (shown here as 'X'). Models that choose to move by flying may move as normal (i.e., they may charge, march and manoeuvre as if moving on the ground), except that they are able to pass freely above other models, units and terrain features without any penalty, and they can march whilst within 8\" of an enemy unit without first having to make a Leadership test. They may end their movement in terrain, but will suffer its effects if they do. They cannot end their movement 'on top' of impassable terrain or another unit, or within 1\" of an enemy unit. Models that can Fly must begin and end all of their movement on the ground. A character with this special rule cannot join a unit without this special rule, and vice versa.", "Fly (X)", "Many creatures of the Warhammer world can fly, held aloft either by mighty pinions or by means of magic, soaring from one side of the battlefield to the other." },
                    { 24, "A Frenzied model has a +1 modifier to its Attacks characteristic. This modifier does not apply to the model's mount (in the case of a cavalry model), to the beasts that draw it (in the case of a chariot), or to its rider (in the case of a monster). In addition: If the majority of the models in a unit are Frenzied, the unit automatically passes any Fear, Panic or Terror tests it is required to make. If a unit that includes one or more Frenzied models is able to declare a charge during the Declare Charges & Charge Reactions sub-phase of its turn, it must do so. If the majority of the models in a unit are Frenzied, it cannot choose to Flee as a charge reaction, nor can it ever choose to make a Restraint test. Losing Frenzy: Unlike other special rules, Frenzy can be lost during a game. Any model that loses a round of combat will immediately lose this special rule.", "Frenzy", "For warriors gripped by a fighting frenzy, all rational thought is consumed by a hunger for violence." },
                    { 25, "During a turn in which it made a charge move of 3\" or more, a model with this special rule gains a +1 modifier to its Attacks characteristic.", "Furious Charge", "Some creatures charge with such fury, the very ground shakes beneath their feet." },
                    { 26, "A model with this special rule may re-roll any failed rolls To Hit made against a hated enemy during the first round of combat. Which enemies are hated varies from model to model and will be shown in brackets after the name of this special rule (shown here as 'X'). Some models hate 'all enemies', meaning they hate all enemy models equally.", "Hatred (X)", "Enmity is rife in the Warhammer world, but hatred is nurtured over thousands of years." },
                    { 27, "A unit with this special rule may increase the maximum Rank Bonus it can claim (as determined by its troop type) by one.", "Horde", "Some troops find strength in numbers, gathering in deep formations that crowd together tightly." },
                    { 28, "To represent its howdah and crew, a behemoth with this special rule has a split profile and follows both the Split Profile (Chariots) and Firing Platform. In all other respects, this model is a behemoth.", "Howdah", "A howdah is an armoured platform built atop a mighty behemoth. From here, a crew of warriors rain missiles upon the enemy." },
                    { 29, "If a model making a shooting attack has this special rule, it ignores any To Hit modifiers caused by partial or full cover.", "Ignores Cover", "Even dense cover offers no safe haven from a skilled marksman wielding a wellcrafted weapon." },
                    { 30, "If the majority of the models in a unit are Immune to Psychology, the unit automatically passes any Fear, Panic or Terror tests it is required to make. However, if the majority of the models in a unit have this special rule, the unit cannot choose to Flee as a charge reaction. Note that this special rule does not make a unit immune to any test made against Leadership not stated here.", "Immune to Psychology", "There are warriors so brave, or perhaps so jaded by the dangers of the world, that they heed no peril." },
                    { 31, "The number of Impact Hits caused varies from model to model, and will be shown in brackets after the name of this special rule (shown here as 'X'). Often, this is determined by the roll of a dice. Resolving Impact Hits: Impact Hits can only be made by a charging model that moved 3\" or more and that is in base contact with the enemy. Impact hits are attacks made in combat that always strike at Initiative 10 (regardless of modifiers), and that hit automatically using the unmodified Strength characteristic of the model.", "Impact Hits (X)", "The impact of a charge can itself cause severe casualties amongst the foe." },
                    { 32, "If during the Declare Charges & Charge Reactions sub-phase of its turn, a unit that includes one or more Impetuous models is able to declare a charge, roll a D6. On a roll of 1-3, the unit must declare a charge. On a roll of 4+, the unit may act as normal.", "Impetuous", "The eagerness of brash and brave warriors can lead them into foolish charges." },
                    { 33, "If a model with this special rule rolls a natural 6 when making a roll To Wound for an attack made in combat, it has struck a 'Killing Blow'. Enemy models whose troop type is infantry or cavalry are not permitted an armour or Regeneration save against a Killing Blow (Ward saves can be attempted as normal). If an enemy model whose troop type is infantry or cavalry suffers an unsaved wound from a Killing Blow, it loses all of its remaining Wounds. Note that if an attack wounds automatically, this special rule cannot be used.", "Killing Blow", "The most skilled of warriors can slay their enemies with a single deadly blow." },
                    { 34, "Enemy models never suffer To Hit modifiers for full or partial cover when shooting at models with this special rule. In addition, a model can draw a line of sight to a model with this special rule over or through other models, and vice versa.", "Large Target", "Monstrous creatures tower above the battlefield, visible to all for leagues around." },
                    { 35, "Models with this special rule cannot use the Inspiring Presence rule of the army's General nor the \"Hold your Ground\" rule of a Battle Standard. However, little is expected from Levies in battle. Therefore, units that do not have this special rule are not required to make a Panic test when a friendly unit of Levies Breaks and flees from combat.", "Levies", "Many regiments are made up of unwilling fighters, pressed into service." },
                    { 36, "A character with this special rule cannot be your General and cannot join a unit without this special rule. A unit with this special rule cannot be joined by a character without this special rule.", "Loner", "Some warriors do not mix well with others, preferring to keep their distance." },
                    { 37, "Any attack made or hit caused by a model with this special rule, or made using a weapon with this special rule, is a 'Magical' attack. Note that all spells are considered to have this special rule, as are any hits caused by magic items.", "Magical Attacks", "The Warhammer world is a deeply magical place. Consequently, magical weapons are quite commonplace." },
                    { 38, "The Casting roll of any enemy spell (including Bound spells) that targets a unit that includes one or more models with this special rule suffers a modifier, as shown in brackets after the name of this special rule (shown here as '-X'). Note that this special rule is not cumulative. If two or more models in a unit have this special rule, use the highest modifier.", "Magic Resistance (-X)", "Some creatures are naturally resistant to magic, whilst others bear charms or fetishes intended to ward off its effects." },
                    { 39, "Often, an army can include certain units drawn from another army list as mercenaries. Any such units included in your army gain this special rule. Mercenaries cannot use the Inspiring Presence rule of the army's General nor the \"Hold your Ground\" rule of a Battle Standard. Mercenaries cannot be joined by characters drawn from another army list.", "Mercenaries", "Mercenary bands roam the Warhammer world, looking for employment in the armies of foreign lands." },
                    { 40, "A monster with this special rule is accompanied by one or more models representing its handlers. During deployment, position these models anywhere that is adjacent to, and in base contact with, the monster. If the handlers are found to be blocking movement or line of sight, simply move them aside. In combat, each handler adds its attacks to those of the monster. If the monster suffers an unsaved wound, roll a D6. On a roll of 1-4 the monster loses a Wound, but on a roll of 5+ a handler model suffers the wound instead. If the monster is removed from play, so are its handlers.", "Monster Handlers", "Colossal beasts are goaded into battle by beastmasters hurrying at their heels." },
                    { 41, "If a model with this special rule rolls a natural 6 when making a roll To Wound for an attack made in combat, it has struck a 'Monster Slaying Blow'. Enemy models whose troop type is monster are not permitted an armour or Regeneration save against a Monster Slaying Blow (Ward saves can be attempted as normal). If an enemy model whose troop type is monster suffers an unsaved wound from a Monster Slaying Blow, it loses all of its remaining Wounds. Note that if an attack wounds automatically, this special rule cannot be used.", "Monster Slayer", "Legends tell of warriors so mighty they can slay terrible monsters with but a single blow!" },
                    { 42, "Units with this special rule may include models of the same type that are equipped differently to one another, and/or models of different types that fight together in a single unit. If necessary, the army list entry for such units will be accompanied by a brief explanation of the unit's composition. Different Weapons: The fighting rank of a Motley Crew may contain models that are armed with different weapons. In such cases, the controlling player must roll different batches of dice for the different models, making it clear to their opponent which model's attacks they represent and where they are being directed. These attacks are made in the Initiative order of the individual models, as usual. Different Armour: Models within a Motley Crew may have different armour values. In combat, use the armour value of the majority of the models in the fighting rank. Against enemy shooting, use the armour value of the majority of the models in the unit. Casualty Removal: Against enemy shooting, casualty removal should be divided as equally as possible between the different models within the unit. In combat, casualties should be removed from among the majority of the models that make up the fighting rank. In either case, available models are brought forward from rear ranks to fill any gaps, as chosen by the controlling player.", "Motley Crew", "Some regiments contain an assortment of differently armed and armoured warriors." },
                    { 43, "A weapon with this special rule can be used in the Shooting phase even if the model equipped with it marched this turn.", "Move & Shoot", "Weapons that are easy to use when moving at speed may lack power or range, but make up for it with their versatility." },
                    { 44, "A weapon with this special rule cannot be used in the Shooting phase if the model equipped with it moved for any reason during this turn (including rallying and reforming).", "Move or Shoot", "Artillery weapons sacrifice a speedy reload and manoeuvrability for range and power, making them impossible to fire on the move." },
                    { 45, "Models with this special rule do not suffer any modifiers to their Movement characteristic for moving through difficult or dangerous terrain. In addition, a model with this special rule may re-roll any rolls of 1 when making Dangerous Terrain tests.", "Move Through Cover", "A well-trained or naturally skilled warrior can traverse unhindered through the densest terrain." },
                    { 46, "A weapon with this special rule can either fire a single shot as normal, or it can be fired a number of times, as shown in brackets after the name of this special rule (shown here as 'X'). If multiple shots are fired, each roll To Hit suffers an additional -1 To Hit modifier. All models in a unit equipped with weapons with this special rule must fire either a single or Multiple Shots. Where the number of Multiple Shots is generated by a dice roll, roll separately for each model.", "Multiple Shots (X)", "Some weapons fire a fusillade of shots, sacrificing accuracy for sheer volume." },
                    { 47, "Each unsaved wound inflicted by an attack with this special rule is multiplied by the number shown in brackets after the name of this special rule (shown here as 'X'). For example, Multiple Wounds (2) would mean that each unsaved wound would cause the target to lose two Wounds. Where the number of Multiple Wounds is generated by a dice roll, roll separately for each unsaved wound. Note that excess wounds caused to a model will have no additional effect unless that model is a character, in which case this special rule counts for Overkill. Excess wounds do not 'spill over' onto other models in the unit.", "Multiple Wounds (X)", "The most powerful attacks strike with crushing force, causing massive damage to their victim." },
                    { 48, "A unit consisting of models with this special rule may adopt an Open Order formation.", "Open Order", "Many regiments adopt an open formation, increasing their manoeuvrability." },
                    { 49, "If a model with Poisoned Attacks rolls a natural 6 when making a roll To Hit, that hit will wound automatically. Unless otherwise stated, a model with this special rule may use it when making both shooting and combat attacks. Any spells cast by the model are unaffected, as are any attacks made with magic weapons. Note that if an attack needs a To Hit roll of 7+, or hits automatically, this special rule cannot be used.", "Poisoned Attacks", "Deadly toxins can turn an otherwise minor injury into a mortal wound." },
                    { 50, "A weapon with this special rule suffers a To Hit modifier of -2 for Moving and Shooting, rather than the usual -1.", "Ponderous", "Many weapons are too unwieldy to be used with any accuracy by a warrior on the move." },
                    { 51, "A weapon with this special rule does not suffer the usual -1 To Hit modifier for Moving and Shooting. In addition, a unit equipped with weapons with this special rule can use them to make a Stand & Shoot charge reaction regardless of how close the charging unit is.", "Quick Shot", "Weapons designed for speed can be brought to bear in less than a heartbeat." },
                    { 52, "During the Command sub-phase of their turn, if they are not engaged in combat, this character may nominate a single fleeing friendly unit that is within their Command range. The nominated unit immediately makes a Rally test. If this test is failed, the unit may attempt to rally again as normal during the Rally sub-phase.", "Rallying Cry", "Striking a heroic pose, a bold leader treats their loyal followers to a short but inspiring speech." },
                    { 53, "Models with this special rule do not have a normal Attacks characteristic. Instead, a dice roll is given (D3+1, for example). Each time a model with this special rule attacks in combat, roll the dice to determine the number of attacks it will make, then roll To Hit as normal. If a fighting rank contains more than one model with this special rule, roll separately for each, unless specified otherwise.", "Random Attacks", "Not all creatures fight with discipline; many flail about in careless abandon with unpredictable results." },
                    { 54, "Models with this special rule do not have a normal Movement characteristic. Instead, a dice roll is given (2D6, for example). Whenever a model with this special rule moves (for any reason), roll the dice to determine how far it must move. Models with this special rule move during the Compulsory Moves sub-phase. They cannot march or declare a charge. They can wheel to change direction, but cannot perform any other manoeuvres. If the model is able to make contact with an enemy unit during the Compulsory Moves sub-phase or whilst pursuing, it may do so and counts as having charged. The model aligns against the enemy unit and stops moving. A unit charged in this way must Hold. If every model in a unit has this special rule, roll once for the entire unit. If two or more models in a unit have different Random Movement characteristics, roll for each and use the lowest result for the entire unit.", "Random Movement", "Some creatures rush forward at one moment, only to falter clumsily in the next." },
                    { 55, "A model with this special rule can make a 'Regeneration' save. The armour value of a Regeneration save is shown in brackets after the name of this special rule (shown here as 'X+'). A Regeneration save can never be modified by the AP characteristic of a weapon and can be made in addition to an armour save and a Ward save. However, any wounds saved by a Regeneration save are still counted for the purposes of calculating the combat result. Note that models with this special rule are often vulnerable to the Flaming Attacks or Magical Attacks special rules.", "Regeneration (X+)", "Foul and unnatural creatures, such as Trolls, Daemons and the Undead, can regenerate all but the most grievous of wounds with ease." },
                    { 56, "A unit with this special rule can be accompanied by detachment.", "Regimental Unit", "Sometimes, large units are supported in battle by smaller detachments." },
                    { 57, "A model cannot use a shield alongside a weapon with this special rule during the Combat phase (a shield can still be used against wounds caused by shooting or magic during other phases of the game).", "Requires Two Hands", "Many weapons are unwieldy, requiring a firm two-handed grip in order to use effectively." },
                    { 58, "Unless it charged, marched or fled during the Movement phase of its turn, a unit with this special rule may make a Reserve move at the end of the Shooting phase of its turn, after all shooting has been resolved. A unit making a Reserve move moves as described in the Basic Movement rules. It may manoeuvre normally, but cannot march.", "Reserve Move", "Warriors that excel at hit and run warfare advance quickly, unleashing a deadly volley before withdrawing." },
                    { 59, "Units with this special rule may be deployed after all other units from both armies. They can be deployed anywhere on the battlefield that is more than 12\" away from an enemy model. If deployed in this way, Scouts cannot declare a charge during their first turn. If both armies contain Scouts, a roll-off should determine which player deploys Scouts first. The players then alternate deploying their scouting units one at a time, starting with the player who won the roll-off.", "Scouts", "Scouts are advance troops who sneak onto the battlefield in order to seize vital locations before the two armies clash." },
                    { 60, "Once per game, during a turn in which it was charged, a unit with this special rule that is arrayed in a Close Order formation, and that is equipped with and chooses to use shields, may Give Ground rather than Fall Back in Good Order.", "Shieldwall", "Presenting an impenetrable wall of shields to the foe, a regiment becomes almost unmovable." },
                    { 61, "A unit consisting of models with this special rule may adopt a Skirmish formation.", "Skirmishers", "Units of skirmishers move quickly and freely, harassing the enemy's flanks." },
                    { 62, "The number of Stomp Attacks caused varies from model to model, and will be shown in brackets after the name of this special rule (shown here as 'X'). Often, this is determined by the roll of a dice. Resolving Stomp Attacks: Stomp Attacks can only be made by a model that is in base contact with the enemy. Stomp Attacks are attacks made in combat that always strike at Initiative 1 (regardless of modifiers), and that hit automatically using the unmodified Strength characteristic of the model.", "Stomp Attacks (X)", "Some creatures are so massive that their sheer bulk is a threat all of its own." },
                    { 63, "During the Combat phase, a model with this special rule that is engaged in combat improves its Initiative characteristic to 10 (before any other modifiers are applied). If a model has both this rule and Strike Last, the two rules cancel one another out.", "Strike First", "Some warriors are gifted with supernatural speed and reactions, whilst others bear weapons enchanted to move like quicksilver through the air." },
                    { 64, "During the Combat phase, a model with this special rule that is engaged in combat reduces its Initiative characteristic to 1 (before any other modifiers are applied). If a model has both this rule and Strike First, the two rules cancel one another out.", "Strike Last", "Some warriors are incredibly slow and ponderous by nature, whilst others may be encumbered by massive weapons that slow them down." },
                    { 65, "The first time this unit is required to make a Break test it may choose not to and will automatically Falling Back in Good Order instead, even if the Unit Strength of the winning side is more than twice that of the losing side. A unit that is not Stubborn does not become Stubborn when joined by a character that is. A Stubborn character cannot use this special rule whilst part of a unit that is not Stubborn.", "Stubborn", "Elite troops will often fight on, refusing to flee from the enemy, regardless of casualties." },
                    { 66, "Unless it is engaged in combat, a unit with this special rule must make a 'Stupidity' test during the Start Of Turn sub-phase of its turn. To make a Stupidity test, test against the unit’s Leadership characteristic. If this test is failed, the unit becomes Stupid. A Stupid unit: Moves during the Compulsory Moves sub-phase. Must move straight ahead, without performing any manoeuvres. Cannot march or declare a charge. A unit or mount that does not have this special rule becomes subject to it when joined or ridden by a character that does (Stupidity is contagious).", "Stupidity", "Dull-witted creatures can often become hopelessly confused by the tumult of battle." },
                    { 67, "A unit with this special rule increases its maximum possible charge range by 3\" and, when it makes a Charge, Flee or Pursuit roll, may apply a +D6 modifier to the result.", "Swiftstride", "Mounted warriors, warbeasts and chariots, amongst others, are swift and deadly, crossing the battlefields of the Old World with unexpected speed." },
                    { 68, "Models with this special rule cause Terror. Models that cause Terror also cause Fear: When a unit that causes Terror declares a charge, the charge target must immediately make a Leadership test. If this test is failed, it must Flee. If this test is passed, it can declare its charge reaction normally. If the winning side of a combat includes one or more units that cause Terror, each unit that belongs to the losing side must apply a -1 modifier to its Leadership characteristic when making its Break test. Note that if a charged unit cannot choose to Flee, it does not make this Leadership test. Models with the Fear special rule Fear models that cause Terror. Models that cause Terror are immune to Terror. A unit that does not cause Terror does not become immune to Terror when joined by a character that does.", "Terror", "There are creatures so fierce that their mere appearance can cause the bravest to flee." },
                    { 69, "When this model is reduced to zero Wounds, the winner of a roll-off chooses one of its arcs (front, flank or rear) for it to fall into. Any units that are within the chosen arc and in base contact with this model suffer D6 hits, each using the Strength characteristic of this model, with an AP of -1. Once these hits are resolved, this model is removed from play.", "Timmm-berrr!", "When a behemoth falls in battle, it can cause utter devastation." },
                    { 70, "If a unit with this special rule loses a round of combat, it is not required to make a Break test. Instead, it will automatically Give Ground as it is pushed back by the enemy. Characters that are not Unbreakable cannot join units that are, and vice versa.", "Unbreakable", "Some warriors are so fearless that they will never run from the enemy." },
                    { 71, "If a unit with this special rule loses a round of combat, it loses one additional Wound for every combat result point by which it lost. These Wounds are lost after combat results have been calculated but before Break tests are made. If an Unstable unit contains any Unstable characters, allocate wounds to the unit until each model has been allocated one wound. Any remaining wounds are divided as equally as possible between the character(s) and the unit.", "Unstable", "Many evil creatures are not truly alive, but are driven instead by magic. Should the tide of battle turn, this magic can quickly fail." },
                    { 72, "After deployment, units with this special rule may make a Vanguard move. A unit making a Vanguard move moves as described in the Basic Movement rules. It may manoeuvre normally but cannot march. If both armies contain Vanguard units, a roll-off determines who moves first. The players then alternate moving their Vanguard units one at a time, starting with the player who won the roll-off.", "Vanguard", "An army's vanguard advances to occupy and engage the foe ahead of their comrades." },
                    { 73, "If the majority of the models in a unit have this special rule, the unit may re-roll any failed Leadership test. Note that a Break test is not a Leadership test.", "Veteran", "Veteran warriors have seen and done it all, and it takes a lot to unsettle them." },
                    { 74, "When a unit with this special rule makes a shooting attack, half of the models in each rank other than the front rank (or front two ranks if the unit is on a hill), rounding up, can shoot (in addition to the usual models that shoot from the front rank, or front two ranks if the unit is on a hill). A unit cannot Volley Fire if it has moved for any reason during this turn (including reforming), or when making a Stand & Shoot charge reaction. Note that models in rear ranks use the line of sight of the model at the front of their file.", "Volley Fire", "Bows and other weapons can loose their projectiles in a high-arcing volley. Even warriors who cannot see the foe can shoot in their general direction." },
                    { 75, "Unless it is fleeing, a Warband gains a positive (+) modifier to its Leadership characteristic equal to its current Rank Bonus, up to a maximum of Leadership 10. However, a Warband cannot use this modifier to its Leadership should it ever choose to make a Restraint test. In addition, if the majority of the models in a unit have this special rule, it may re-roll its Charge roll. Note that unless a character also has this special rule, their Leadership cannot be modified by this special rule. A Warband can use either its own modified Leadership, the modified Leadership of a Warband character, or the unmodified Leadership of a non-Warband character, whichever is the higher.", "Warband", "A warband is an unruly mob, keen for the fray but easily dismayed when things go poorly." },
                    { 76, "A model with this special rule cannot make a Regeneration save against a wound caused by a Magical attack. In addition, characters that are not Warp-spawned cannot join units that are, and vice versa.", "Warp-spawned", "Creatures of the supernatural feed upon magic to manifest as physical beings and, as such, are vulnerable to magical attacks." }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TowModels_TowFactions_FactionId",
                table: "TowModels",
                column: "FactionId",
                principalTable: "TowFactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TowModelTowModelSpecialRule_TowModelSpecialRules_SpecialRulesId",
                table: "TowModelTowModelSpecialRule",
                column: "SpecialRulesId",
                principalTable: "TowModelSpecialRules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TowModels_TowFactions_FactionId",
                table: "TowModels");

            migrationBuilder.DropForeignKey(
                name: "FK_TowModelTowModelSpecialRule_TowModelSpecialRules_SpecialRulesId",
                table: "TowModelTowModelSpecialRule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TowModelSpecialRules",
                table: "TowModelSpecialRules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TowFactions",
                table: "TowFactions");

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "TowModelSpecialRules",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.RenameTable(
                name: "TowModelSpecialRules",
                newName: "TowModelSpecialRule");

            migrationBuilder.RenameTable(
                name: "TowFactions",
                newName: "WarhammerFactions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TowModelSpecialRule",
                table: "TowModelSpecialRule",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WarhammerFactions",
                table: "WarhammerFactions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TowModels_WarhammerFactions_FactionId",
                table: "TowModels",
                column: "FactionId",
                principalTable: "WarhammerFactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TowModelTowModelSpecialRule_TowModelSpecialRule_SpecialRulesId",
                table: "TowModelTowModelSpecialRule",
                column: "SpecialRulesId",
                principalTable: "TowModelSpecialRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
