using System;
using System.Configuration;
using System.IO;

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

                try
                {
                    if (Directory.Exists(folderPath))
                    {
                        string[] files = Directory.GetFiles(folderPath);

                        foreach (string filePath in files)
                        {
                            ProcessFile(filePath);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Папка не существует.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при получении списка файлов:");
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Путь к папке (A) не найден в файле конфигурации.");
            }

            Console.WriteLine("Завершение работы. Нажмите любую клавишу для выхода.");
            Console.ReadKey();

        }

        static void ProcessFile(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        ProcessLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обработке файла: {filePath}");
                Console.WriteLine(ex.Message);
                // Логирование ошибки, если требуется
            }
        }

        private static void ProcessLine(string line)
        {
            try
            {
               
                
                string[] values = line.Split(',');

                if(values.Length >= 2)
                {
                    string firstName = values[0].Trim();
                    string lastName = values[1].Trim();
                    // и т.д.

                    // Выполните необходимую обработку данных и сохраните результаты
                    // в соответствующем формате

                    // Пример: Вывод обработанных данных в консоль
                    Console.WriteLine($"Имя: {firstName}, Фамилия: {lastName}");
                }
                else
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обработке строки: {line}");
                Console.WriteLine(ex.Message);
                // Логирование ошибки, если требуется
            }
        }

        
    }
}
