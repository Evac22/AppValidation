using AppValidation.Config.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppValidation.Config
{
    // Реализация получения пути к результатам
    internal class ResultFolderPathConfigProvider : IResultFolderPathConfigProvider
    {
        private readonly IConfigReader _configReader;

        public ResultFolderPathConfigProvider(IConfigReader configReader)
        {
            _configReader = configReader;
        }

        public string GetResultFolderPath()
        {
            return _configReader.GetValue("ResultFolderPath");
        }
    }
}
