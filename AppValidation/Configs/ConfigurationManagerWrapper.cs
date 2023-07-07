using AppValidation.Configs.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppValidation.Configs
{
    // Реализация чтения конфигурационных значений с использованием ConfigurationManager
    internal class ConfigurationManagerWrapper : IConfigReader
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ConfigurationManagerWrapper));

        public string GetValue(string key)
        {
            try
            {
                string value = ConfigurationManager.AppSettings[key];
                if (!string.IsNullOrEmpty(value))
                {
                    return value;
                }
                else
                {
                    string errorMessage = $"Значение для ключа '{key}' не найдено в файле конфигурации.";
                    log.Error(errorMessage);
                    throw new ConfigurationErrorsException($"Значение для ключа '{key}' не найдено в файле конфигурации.");
                }
            }
            catch (ConfigurationErrorsException ex)
            {
                string errorMessage = "Ошибка чтения файла конфигурации.";
                log.Error(errorMessage, ex);
                throw new ConfigurationErrorsException("Ошибка чтения файла конфигурации.", ex);
            }
        }

    }
    
}
