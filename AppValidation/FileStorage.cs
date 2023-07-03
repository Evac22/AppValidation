using System;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;

namespace AppValidation
{
    internal class FileStorage
    {
        //Компонент, отвечающий за сохранение
        //результатов обработки файлов в папке (B).

        public static void SaveResultsToFile(DataAggregator dataAggregator)
        {
            // Получение пути к папке результатов и имени подпапки из файла конфигурации
            string resultFolderPath = Config.GetResultFolderPathFromConfig();
            string subfolderName = Config.GetSubfolderNameFromConfig();

            // Создание пути к папке текущей даты
            string currentDateFolderPath = Path.Combine(resultFolderPath, subfolderName, DateTime.Now.ToString("yyyy-MM-dd"));

            // Создание папки текущей даты, если она не существует
            Directory.CreateDirectory(currentDateFolderPath);

            // Генерация имени нового файла в формате "outputN.json", где N - номер файла для текущего дня
            int fileNumber = 1;
            string[] existingFiles = Directory.GetFiles(currentDateFolderPath, "output*.json");
            if (existingFiles.Length > 0)
            {
                string lastFilePath = existingFiles[existingFiles.Length - 1];
                string lastFileName = Path.GetFileNameWithoutExtension(lastFilePath);
                if (int.TryParse(lastFileName.Replace("output", ""), out int lastFileNumber))
                {
                    fileNumber = lastFileNumber + 1;
                }
            }
            string newFileName = $"output{fileNumber}.json";
            string newFilePath = Path.Combine(currentDateFolderPath, newFileName);

            // Сохранение результатов в JSON-файл
            string json = JsonConvert.SerializeObject(dataAggregator, Formatting.Indented);
            File.WriteAllText(newFilePath, json);
        }

        private static string GetResultFolderPathFromConfig()
        {
            // Реализация метода чтения пути к папке результатов из файла конфигурации

            try
            {
                string resultFolderPath = ConfigurationManager.AppSettings["ResultFolderPath"];

                if (!string.IsNullOrEmpty(resultFolderPath))
                {
                    return resultFolderPath;
                }
                else
                {
                    Console.WriteLine("Путь к папке результатов не найден в файле конфигурации.");
                }
            }
            catch (ConfigurationErrorsException ex)
            {
                Console.WriteLine("Ошибка чтения файла конфигурации: " + ex.Message);
            }

            return null;
        }

        private static string GetSubfolderNameFromConfig()
        {
            // Реализация метода чтения имени подпапки из файла конфигурации

            // Реализация метода чтения имени подпапки из файла конфигурации

            try
            {
                string subfolderName = ConfigurationManager.AppSettings["SubfolderName"];

                if (!string.IsNullOrEmpty(subfolderName))
                {
                    return subfolderName;
                }
                else
                {
                    Console.WriteLine("Имя подпапки не найдено в файле конфигурации.");
                }
            }
            catch (ConfigurationErrorsException ex)
            {
                Console.WriteLine("Ошибка чтения файла конфигурации: " + ex.Message);
            }

            return null;
        }
    }
}
