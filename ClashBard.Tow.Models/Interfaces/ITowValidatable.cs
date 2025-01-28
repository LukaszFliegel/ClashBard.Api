using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.Models.Interfaces;
public interface ITowValidatable
{
    public IEnumerable<ValidationError> Validate();
}

public class ValidationError
{
    public ValidationError(string validationErrorMessage, string owner)
    {
        ValidationErrorMessage = validationErrorMessage;
        Owner = owner;
    }

    public string ValidationErrorMessage { get; }
    public string Owner { get; }
}