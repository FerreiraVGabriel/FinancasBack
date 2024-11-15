using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Erros
{
    public record BaseError(string Detail, ErrorType ErrorType);

    public enum ErrorType
    {
        BusinessRule,
        Validation
    }
}
