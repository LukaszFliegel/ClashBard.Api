using ClashBard.Tow.Models.Interfaces;

namespace ClashBard.Tow.Models;

public abstract class TowOption<TTowType> : ITowValidatable where TTowType : Enum
{
    public abstract ICollection<ValidationError> Validate();
}

public class TowMandatoryOneOfTwoOption<TTowType> : TowOption<TTowType>, ITowValidatable where TTowType : Enum
{
    private readonly TowModel _model;
    private readonly TTowType _firstOption;
    private readonly TTowType _secondOption;

    public TowMandatoryOneOfTwoOption(TowModel model, TTowType firstOption, TTowType secondOption)
    {
        _model = model;
        _firstOption = firstOption;
        _secondOption = secondOption;
    }

    public override ICollection<ValidationError> Validate()
    {
        throw new NotImplementedException(); // goblin
    }
}