using AppValidation.FileParser.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppValidation.FileParser
{
    internal class LineValidator : ILineValidator
    {
        public bool IsValidLine(string line)
        { 
            return line.Length > 5;
        }
    }
}
