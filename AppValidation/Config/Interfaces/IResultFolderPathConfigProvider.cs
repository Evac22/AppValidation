using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppValidation.Config.Interfaces
{
    // Интерфейс для получения пути к результатам
    internal interface IResultFolderPathConfigProvider
    {
        string GetResultFolderPath();
    }
}
