using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppValidation.FileParser.Interface
{
    internal interface IDateValidator
    {
        bool IsValidLine(string line);
        bool IsValidPayment(string value);
        bool IsValidDate(string value);
        bool IsValidAccountNumber(string value);
        bool AreAllValuesPresent(string[] values);
    }
}
