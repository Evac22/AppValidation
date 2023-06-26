using System;
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
                                FileParser.ProcessFile(filePath);
                            }
                            else
                            {
                                invalidFileCount++; // Увеличиваем счетчик недействительных файлов
                            }
                        }

                        Console.WriteLine($"Недействительных файлов: {invalidFileCount}");
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

    }
}
