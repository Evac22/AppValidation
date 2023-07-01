using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AppValidation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string folderPath = Config.GetFolderPathFromConfig();

            if (folderPath != null)
            {
                Config.DisplayAllFiles(folderPath);
                string[] filePaths = Directory.GetFiles(folderPath, "*.txt");

                DataAggregator dataAggregator = new DataAggregator();
                int invalidFileCount = 0; // Объявление и инициализация переменной invalidFileCount

                foreach (string filePath in filePaths)
                {
                    FileParser.ProcessFile(filePath, ref invalidFileCount, dataAggregator);
                }

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

            Console.WriteLine("Завершение работы. Нажмите любую клавишу для выхода.");
            Console.ReadKey();
        }
    }
}
