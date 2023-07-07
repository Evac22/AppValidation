using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppValidation.Configs.Interfaces
{
    // Интерфейс для получения пути к папке
    internal interface IFolderPathConfigProvider
    {
        string GetFolderPath();
    }
}
