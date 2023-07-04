using AppValidation.Config.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppValidation.Config
{
    internal class SubfolderNameConfigProvider : ISubfolderNameConfigProvider
    {
        private readonly IConfigReader _configReader;

        public SubfolderNameConfigProvider(IConfigReader configReader)
        {
            _configReader = configReader;
        }

        public string GetSubfolderName()
        {
            return _configReader.GetValue("SubfolderName");
        }
    }
   
}
