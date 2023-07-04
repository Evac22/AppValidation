using AppValidation.Config.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppValidation.Config
{
    // Реализация получения пути к папке
    internal class FolderPathConfigProvider : IFolderPathConfigProvider
    {
        private readonly IConfigReader _configReader;

        public FolderPathConfigProvider(IConfigReader configReader)
        {
            _configReader = configReader;
        }

        public string GetFolderPath()
        {
            return _configReader.GetValue("FolderPath");
        }
    }
   
    
}
