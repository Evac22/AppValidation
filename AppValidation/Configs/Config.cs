using AppValidation.Configs.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppValidation.Configs
{
    // Класс, который использует провайдеры конфигурационных значений для получения нужных значений
    internal class Config
    {
        private readonly IFolderPathConfigProvider _folderPathConfigProvider;
        private readonly IResultFolderPathConfigProvider _resultFolderPathConfigProvider;
        private readonly ISubfolderNameConfigProvider _subfolderNameConfigProvider;

        private readonly string _filePath;

        public Config(string filePath)
        {
            _filePath = filePath;
        }

        public string ReadFileContent()
        {
            try
            {
                // Проверка наличия файла
                if (File.Exists(_filePath))
                {
                    // Чтение содержимого файла
                    string content = File.ReadAllText(_filePath);
                    return content;
                }
                else
                {
                    throw new FileNotFoundException("Файл не найден.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при чтении файла.", ex);
            }
        }

        public Config(
             IFolderPathConfigProvider folderPathConfigProvider,
             IResultFolderPathConfigProvider resultFolderPathConfigProvider,
             ISubfolderNameConfigProvider subfolderNameConfigProvider)
        {
            _folderPathConfigProvider = folderPathConfigProvider;
            _resultFolderPathConfigProvider = resultFolderPathConfigProvider;
            _subfolderNameConfigProvider = subfolderNameConfigProvider;
        }

        // Получение пути к папке из конфигурации
        public string GetFolderPathFromConfig()
        {
            try
            {
                string folderPath = _folderPathConfigProvider.GetFolderPath();
                if (!string.IsNullOrEmpty(folderPath))
                {
                    return folderPath;
                }
                else
                {
                    throw new ConfigurationErrorsException("Путь к папке (A) не найден в файле конфигурации.");
                }

            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException("Ошибка чтения файла конфигурации.", ex);
            }
        }

        // Получение пути к результатам из конфигурации
        public string GetResultFolderPathFromConfig()
        {
            try
            {
                string resultFolderPath = _resultFolderPathConfigProvider.GetResultFolderPath();
                if (!string.IsNullOrEmpty(resultFolderPath))
                {
                    return resultFolderPath;
                }
                else
                {
                    throw new ConfigurationErrorsException("Путь к папке B не найден в файле конфигурации.");
                }
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException("Ошибка чтения файла конфигурации.", ex);
            }
        }

        // Получение имени подпапки из конфигурации
        public string GetSubfolderNameFromConfig()
        {
            try
            {
                string subfolderName = _subfolderNameConfigProvider.GetSubfolderName();
                if (!string.IsNullOrEmpty(subfolderName))
                {
                    return subfolderName;
                }
                else
                {
                    throw new ConfigurationErrorsException("Имя подпапки не найдено в файле конфигурации.");
                }
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException("Ошибка чтения файла конфигурации.", ex);
            }
        }
    }
}
