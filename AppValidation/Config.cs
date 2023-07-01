using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace AppValidation
{
    internal class Config
    {
        // Класс, который загружает конфигурационные данные, включая путь к папке (A), из конфигурационного файла
        public static string GetFolderPathFromConfig()
        {
            try
            {
                // Получение значения "FolderPath" из файла конфигурации
                string folderPath = ConfigurationManager.AppSettings["FolderPath"];

                // Проверка, что значение не пустое или null
                if (!string.IsNullOrEmpty(folderPath))
                {
                    return folderPath;
                }
                else
                {
                    // Обработка случая, когда значение "FolderPath" отсутствует или пустое
                    // Возможно, вы захотите выбросить исключение или вернуть дефолтное значение
                    // в зависимости от ваших требований
                    Console.WriteLine("Путь к папке (A) не найден в файле конфигурации.");
                }
            }
            catch (ConfigurationErrorsException ex)
            {
                // Обработка ошибки при чтении конфигурации
                Console.WriteLine("Ошибка чтения файла конфигурации: " + ex.Message);

            }
            return null; // Возвращаем null в случае ошибки или отсутствия значения
        }

        public static void DisplayAllFiles(string folderPath)
        {
            DataAggregator dataAggregator = new DataAggregator();

            try
            {
                if (Directory.Exists(folderPath))
                {
                    string[] files = Directory.GetFiles(folderPath);

                    Console.WriteLine("Список файлов:");
                    int invalidFileCount = 0; // Счетчик недействительных файлов

                    foreach (string filePath in files)
                    {
                        string extension = Path.GetExtension(filePath);

                        if (string.Equals(extension, ".txt", StringComparison.OrdinalIgnoreCase)
                            || string.Equals(extension, ".csv", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine(filePath);
                            FileParser.ProcessFile(filePath, ref invalidFileCount, dataAggregator);
                        }
                        else
                        {
                            invalidFileCount++; // Увеличиваем счетчик недействительных файлов
                        }
                    }

                    Console.WriteLine($"Недействительных файлов: {invalidFileCount}");

                    // Вывод агрегированных данных
                    Console.WriteLine($"Total Payment: {dataAggregator.TotalPayment}");

                    Console.WriteLine("Payers by City:");
                    foreach (KeyValuePair<string, List<Models>> kvp in dataAggregator.CityPayers)
                    {
                        Console.WriteLine($"City: {kvp.Key}");
                        foreach (Models model in kvp.Value)
                        {
                            Console.WriteLine($"Name: {model.FirstName} {model.LastName}, Payment: {model.Payment}");
                        }
                    }

                    Console.WriteLine("Payers by Service:");
                    foreach (KeyValuePair<string, List<Models>> kvp in dataAggregator.ServicePayers)
                    {
                        Console.WriteLine($"Service: {kvp.Key}");
                        foreach (Models model in kvp.Value)
                        {
                            Console.WriteLine($"Name: {model.FirstName} {model.LastName}, Payment: {model.Payment}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Папка не существует.");
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при получении списка файлов:");
                Console.WriteLine(ex.Message);
            }
        }

    }
}
