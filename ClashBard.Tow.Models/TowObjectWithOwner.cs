namespace ClashBard.Tow.Models;

public abstract class TowObjectWithOwner: TowObject
{
    public TowObject Owner { get; protected set; }

    public TowObjectWithOwner(TowObject owner)
    {
        Owner = owner;
    }
}
