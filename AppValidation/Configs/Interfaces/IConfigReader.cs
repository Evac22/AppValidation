using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppValidation.Configs.Interfaces
{
    // Интерфейс для чтения конфигурационных значений
    internal interface IConfigReader
    {
        string GetValue(string key);
    }
}
