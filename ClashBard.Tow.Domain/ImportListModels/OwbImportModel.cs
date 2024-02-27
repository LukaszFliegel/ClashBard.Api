using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.Domain.ImportListModels;

public class OwbImportModel
{
    public string name { get; set; }
    public string description { get; set; }
    public string game { get; set; }
    public int points { get; set; }
    public string army { get; set; }
    public Character[] characters { get; set; }
    public Core[] core { get; set; }
    public Special[] special { get; set; }
    public Rare[] rare { get; set; }
    public object[] mercenaries { get; set; }
    public object[] allies { get; set; }
    public string id { get; set; }
    public string armyComposition { get; set; }
}

public class Character
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public string id { get; set; }
    public int points { get; set; }
    public int minimum { get; set; }
    public int maximum { get; set; }
    public bool regimentalUnit { get; set; }
    public bool detachment { get; set; }
    public object[] command { get; set; }
    public Equipment[] equipment { get; set; }
    public Armor[] armor { get; set; }
    public Option[] options { get; set; }
    public Mount[] mounts { get; set; }
    public Item[] items { get; set; }
    public string[] lores { get; set; }
    public Specialrules specialRules { get; set; }
    public Notes notes { get; set; }
    public int strength { get; set; }
    public string activeLore { get; set; }
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



public class Armor
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public int points { get; set; }
    public bool perModel { get; set; }
    public bool active { get; set; }
    public int id { get; set; }
}

public class Option
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public int points { get; set; }
    public bool perModel { get; set; }
    public bool stackable { get; set; }
    public int minimum { get; set; }
    public int maximum { get; set; }
    public int id { get; set; }
    public bool active { get; set; }
}


public class Mount
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public int points { get; set; }
    public bool active { get; set; }
    public int id { get; set; }
}

public class Item
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public string[] types { get; set; }
    public Selected[] selected { get; set; }
    public bool mutuallyExclusive { get; set; }
    public int maxPoints { get; set; }
}

public class Selected
{
    public string name_de { get; set; }
    public string name_en { get; set; }
    public int points { get; set; }
    public string type { get; set; }
    public string id { get; set; }
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
    public bool regimentalUnit { get; set; }
    public bool detachment { get; set; }
    public Command[] command { get; set; }
    public Equipment[] equipment { get; set; }
    public Armor[] armor { get; set; }
    public Option[] options { get; set; }
    public object[] mounts { get; set; }
    public object[] items { get; set; }
    public object[] lores { get; set; }
    public Specialrules specialRules { get; set; }
    public Notes notes { get; set; }
    public int strength { get; set; }
    public Magic magic { get; set; }
}

public class Magic
{
    public object[] items { get; set; }

    public string[] types { get; set; }
    public int maxPoints { get; set; }
}

public class Command
{
    public string name_en { get; set; }
    public string name_de { get; set; }
    public string name_es { get; set; }
    public string name_fr { get; set; }
    public int points { get; set; }
    public Magic magic { get; set; }
    public int id { get; set; }
    public bool active { get; set; }
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
    public int id { get; set; }
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
    public Command[] command { get; set; }
    public Equipment[] equipment { get; set; }
    public Armor[] armor { get; set; }
    public Option[] options { get; set; }
    public object[] mounts { get; set; }
    public object[] items { get; set; }
    public object[] lores { get; set; }
    public Specialrules specialRules { get; set; }
    public Notes notes { get; set; }
    public int strength { get; set; }
    public Magic magic { get; set; }
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
    public bool regimentalUnit { get; set; }
    public bool detachment { get; set; }
    public Command[] command { get; set; }
    public Equipment[] equipment { get; set; }
    public Armor[] armor { get; set; }
    public object[] options { get; set; }
    public object[] mounts { get; set; }
    public object[] items { get; set; }
    public object[] lores { get; set; }
    public Specialrules specialRules { get; set; }
    public Notes notes { get; set; }
    public int strength { get; set; }
    public Magic magic { get; set; }
}
