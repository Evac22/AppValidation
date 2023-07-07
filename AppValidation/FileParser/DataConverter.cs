using AppValidation.FileParser.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppValidation.FileParser
{
    internal class DataConverter : IDataConverter
    {
        public Models ConvertModel(string[] values)
        {
            Models model = new Models();
            model.FirstName = values[0];
            model.LastName = values[1];
            model.Address = values[2];
            model.Payment = decimal.Parse(values[3]);
            model.Date  = DateTime.Parse(values[4]);
            model.AccountNumber = long.Parse(values[5]);
            model.Service = values[6];

            return model;
        }

        public string[] SplitLine(string line)
        {
            string[] values = line.Split(',');

            return values;
        }
    }
}
