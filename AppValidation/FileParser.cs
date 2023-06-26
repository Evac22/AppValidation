using System;
using System.IO;

namespace AppValidation
{
    internal class FileParser
    {
        //Компонент, отвечающий за разбор и чтение файлов,
        //включая валидацию и преобразование данных в структурированную форму.

        public static string[] ReadFileLines(string filePath)
        {
            try
            {
                return File.ReadAllLines(filePath);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла {filePath}: {ex.Message}");
            }

            return new string[0];// Если чтение файла не удалось, возвращаем пустой массив строк
        }

        public static void ProcessFile(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                int invalidLineCount = 0; // Счетчик недействительных строк

                foreach (string line in lines)
                {
                    ProcessLine(line, ref invalidLineCount);
                }

                Console.WriteLine($"Недействительных строк в файле {filePath}: {invalidLineCount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обработке файла {filePath}: {ex.Message}");
            }
        }


        public static void ProcessLine(string line, ref int invalidLineCount)
        {
            try
            {
                if (!line.Contains(","))
                {
                    invalidLineCount++;
                    return;
                }

                string[] values = line.Split(',');

                if (values.Length >= 2)
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
                    invalidLineCount++;
                    Console.WriteLine($"Ошибка при обработке строки: {line}");
                    Console.WriteLine("Недостаточно значений после разделения строки.");
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
