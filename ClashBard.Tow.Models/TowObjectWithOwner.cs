namespace ClashBard.Tow.Models;

public abstract class TowObjectWithOwner: TowObject
{
    protected TowObject Owner;

    public TowObjectWithOwner(TowObject owner)
    {
        Owner = owner;
    }
}
