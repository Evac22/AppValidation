using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppValidation.FileParser.Interface
{
    internal interface IDataConverter
    {
        string[] SplitLine(string line);
        Models ConvertModel(string[] values);
    }
}
