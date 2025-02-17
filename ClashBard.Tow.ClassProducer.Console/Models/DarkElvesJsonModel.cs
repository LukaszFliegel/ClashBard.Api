using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.ClassProducer.ConsoleApp.Models;

public class DarkElvesJsonModel
{
    public Character[] characters { get; set; }
    public Core[] core { get; set; }
    public Special[] special { get; set; }
    public Rare[] rare { get; set; }
    public object[] mercenaries { get; set; }
    public object[] allies { get; set; }
}

public class Character
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public string id { get; set; }
    public int points { get; set; }
    public Command[] command { get; set; }
    public Equipment[] equipment { get; set; }
    public Armor[] armor { get; set; }
    public Option[] options { get; set; }
    public Mount[] mounts { get; set; }
    public Item[] items { get; set; }
    public string[] lores { get; set; }
    public Specialrules specialRules { get; set; }
    public Notes notes { get; set; }
}

public class Specialrules
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
}

public class Notes
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
}

public class Command
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_fr { get; set; }
    public string name_es { get; set; }
    public int points { get; set; }
    public Magic magic { get; set; }
}

public class Magic
{
    public string[] types { get; set; }
    public int maxPoints { get; set; }
}

public class Equipment
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public int points { get; set; }
    public bool perModel { get; set; }
    public bool active { get; set; }
}

public class Armor
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public int points { get; set; }
    public bool perModel { get; set; }
    public bool active { get; set; }
}

public class Option
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public int points { get; set; }
    public bool perModel { get; set; }
    public int minimum { get; set; }
    public int maximum { get; set; }
}

public class Mount
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public int points { get; set; }
    public bool active { get; set; }
    public Option1[] options { get; set; }
}

public class Option1
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public int points { get; set; }
}

public class Item
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public string[] types { get; set; }
    public object[] selected { get; set; }
    public int maxPoints { get; set; }
}

public class Core
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public string id { get; set; }
    public int points { get; set; }
    public int minimum { get; set; }
    public int maximum { get; set; }
    public Command1[] command { get; set; }
    public Equipment1[] equipment { get; set; }
    public Armor1[] armor { get; set; }
    public Option2[] options { get; set; }
    public object[] mounts { get; set; }
    public object[] items { get; set; }
    public object[] lores { get; set; }
    public Specialrules1 specialRules { get; set; }
    public Notes1 notes { get; set; }
}

public class Specialrules1
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
}

public class Notes1
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
}

public class Command1
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public int points { get; set; }
    public Magic1 magic { get; set; }
}

public class Magic1
{
    public string[] types { get; set; }
    public int maxPoints { get; set; }
}

public class Equipment1
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public int points { get; set; }
    public bool perModel { get; set; }
    public bool active { get; set; }
}

public class Armor1
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public int points { get; set; }
    public bool perModel { get; set; }
    public bool active { get; set; }
}

public class Option2
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public int points { get; set; }
    public bool perModel { get; set; }
    public int minimum { get; set; }
    public int maximum { get; set; }
}

public class Special
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public string id { get; set; }
    public int points { get; set; }
    public int minimum { get; set; }
    public int maximum { get; set; }
    public Command2[] command { get; set; }
    public Equipment2[] equipment { get; set; }
    public Armor2[] armor { get; set; }
    public Option3[] options { get; set; }
    public object[] mounts { get; set; }
    public object[] items { get; set; }
    public object[] lores { get; set; }
    public Specialrules2 specialRules { get; set; }
    public Notes2 notes { get; set; }
}

public class Specialrules2
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
}

public class Notes2
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
}

public class Command2
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public int points { get; set; }
    public Magic2 magic { get; set; }
}

public class Magic2
{
    public string[] types { get; set; }
    public int maxPoints { get; set; }
}

public class Equipment2
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public int points { get; set; }
    public bool perModel { get; set; }
    public bool active { get; set; }
}

public class Armor2
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public int points { get; set; }
    public bool perModel { get; set; }
    public bool active { get; set; }
}

public class Option3
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public int points { get; set; }
    public bool perModel { get; set; }
    public int minimum { get; set; }
    public int maximum { get; set; }
}

public class Rare
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public string id { get; set; }
    public int points { get; set; }
    public int minimum { get; set; }
    public int maximum { get; set; }
    public Command3[] command { get; set; }
    public Equipment3[] equipment { get; set; }
    public Armor3[] armor { get; set; }
    public object[] options { get; set; }
    public object[] mounts { get; set; }
    public object[] items { get; set; }
    public object[] lores { get; set; }
    public Specialrules3 specialRules { get; set; }
    public Notes3 notes { get; set; }
}

public class Specialrules3
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
}

public class Notes3
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
}

public class Command3
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public int points { get; set; }
    public Magic3 magic { get; set; }
}

public class Magic3
{
    public string[] types { get; set; }
    public int maxPoints { get; set; }
}

public class Equipment3
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public int points { get; set; }
    public bool perModel { get; set; }
    public bool active { get; set; }
}

public class Armor3
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public int points { get; set; }
    public bool perModel { get; set; }
    public bool active { get; set; }
}

