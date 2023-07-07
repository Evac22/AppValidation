using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppValidation.Configs.Interfaces
{
    // Интерфейс для получения имени подпапки
    internal interface ISubfolderNameConfigProvider
    {
        string GetSubfolderName();
    }
}
