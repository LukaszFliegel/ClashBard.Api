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
    private readonly int _firstOptionCost;
    private readonly TTowType _secondOption;
    private readonly int _secondOptionCost;
    private TTowType _selectedOption;

    public TowMandatoryOneOfTwoOption(TowModel model, TTowType firstOption, int firstOptionCost, TTowType secondOption, int secondOptionCost)
    {
        _model = model;
        _firstOption = firstOption;
        _firstOptionCost = firstOptionCost;
        _secondOption = secondOption;
        _secondOptionCost = secondOptionCost;
        
        _selectedOption = _firstOption;
    }

    public void UseFirstOption()
    {
        _selectedOption = _firstOption;
    }

    public void UseSecondOption()
    {
        _selectedOption = _secondOption;
    }

    public override ICollection<ValidationError> Validate()
    {
        throw new NotImplementedException(); // goblin
    }

    public TTowType GetSelectedOption()
    {
        return _selectedOption;
    }

    public int GetSelectedOptionCost()
    {
        if(_selectedOption.Equals(_firstOption))
        {
            return _firstOptionCost;
        }
        else
        {
            return _secondOptionCost;
        }
    }
}

public class TowOptionalOneOfTwoOption<TTowType> : TowOption<TTowType>, ITowValidatable where TTowType : Enum
{
    private readonly TowModel _model;
    private readonly TTowType _firstOption;
    private readonly int _firstOptionCost;
    private readonly TTowType _secondOption;
    private readonly int _secondOptionCost;
    private TTowType? _selectedOption;

    public TowOptionalOneOfTwoOption(TowModel model, TTowType firstOption, int firstOptionCost, TTowType secondOption, int secondOptionCost)
    {
        _model = model;
        _firstOption = firstOption;
        _firstOptionCost = firstOptionCost;
        _secondOption = secondOption;
        _secondOptionCost = secondOptionCost;
    }

    public void UseFirstOption()
    {
        _selectedOption = _firstOption;
    }

    public void UseSecondOption()
    {
        _selectedOption = _secondOption;
    }

    public override ICollection<ValidationError> Validate()
    {
        // nothing to validate
        return new List<ValidationError>();
    }

    public TTowType? GetSelectedOption()
    {
        return _selectedOption;
    }

    public int? GetSelectedOptionCost()
    {
        if(_selectedOption == null)
        {
            return null;
        }

        if (_selectedOption.Equals(_firstOption))
        {
            return _firstOptionCost;
        }
        else
        {
            return _secondOptionCost;
        }
    }
}