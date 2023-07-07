using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppValidation.FileParser.Interface
{
    internal interface IAccountNumberValidator
    {
        bool IsValidAccountNumber(string value);
    }
}
