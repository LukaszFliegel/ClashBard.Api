using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.Models.Interfaces;
public interface ITowValidatable
{
    public ICollection<ValidationError> Validate();
}

public class ValidationError
{
    public ValidationError(string validationErrorMessage)
    {
        ValidationErrorMessage = validationErrorMessage;
    }

    public string ValidationErrorMessage { get; }
}