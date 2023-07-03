using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

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
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла {filePath}: {ex.Message}");
            }

            return new string[0];// Если чтение файла не удалось, возвращаем пустой массив строк
        }

        public static void ProcessFile(string filePath, ref int invalidFileCount, ref int processedLineCount, ref int errorCount, List<string> invalidFiles, DataAggregator dataAggregator)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                int invalidLineCount = 0; // Счетчик некорректных строк

                Console.WriteLine($"Файл: {filePath}");

                List<Models> models = new List<Models>();

                foreach (string line in lines)
                {
                    ProcessLine(line, ref invalidLineCount, ref models);
                    processedLineCount++;
                }

                

                // Добавление моделей в агрегатор данных
                dataAggregator.Aggregate(models);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обработке файла {filePath}: {ex.Message}");
                invalidFileCount++;
                errorCount++;
                invalidFiles.Add(filePath);
            }
        }


        public static void ProcessFiles(string folderPath, ref int invalidFileCount, ref int processedFileCount, ref int processedLineCount, ref int errorCount, List<string> invalidFiles, DataAggregator dataAggregator)
        {
            try
            {
                string[] filePaths = Directory.GetFiles(folderPath, "*.txt", SearchOption.AllDirectories);

                foreach (string filePath in filePaths)
                {
                    ProcessFile(filePath, ref invalidFileCount, ref processedLineCount, ref errorCount, invalidFiles, dataAggregator);
                    processedFileCount++;
                }

                Console.WriteLine("Обработка файлов завершена.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обработке файлов: {ex.Message}");
            }
        }

        public static void ProcessLine(string line, ref int invalidLineCount, ref List<Models> models)
        {
            try
            {
                if (!line.Contains(","))
                {
                    invalidLineCount++;
                    return;
                }

                string[] values = line.Split(',');

                if (values.Length >= 8)
                {
                    string firstName = values[0].Trim();
                    string lastName = values[1].Trim();
                    string address = values[2].Trim() + ", " + values[3].Trim() + ", " + values[4].Trim();
                    decimal payment;
                    DateTime date;
                    long accountNumber;
                    string service = values[7].Trim();

                    // Проверка типов данных для поля 'Payment'
                    if (!decimal.TryParse(values[5].Trim(), out payment))
                    {
                        invalidLineCount++;
                        Console.WriteLine($"Ошибка при обработке строки: {line}");
                        Console.WriteLine("Недопустимый тип данных для поля 'Payment'.");
                        return;
                    }

                    // Проверка типов данных для поля 'Date'
                    if (!DateTime.TryParse(values[6].Trim(), out date))
                    {
                        invalidLineCount++;
                        Console.WriteLine($"Ошибка при обработке строки: {line}");
                        Console.WriteLine("Недопустимый тип данных для поля 'Date'.");
                        return;
                    }

                    // Проверка типов данных для поля 'Account Number'
                    if (!long.TryParse(values[7].Trim(), out accountNumber))
                    {
                        invalidLineCount++;
                        Console.WriteLine($"Ошибка при обработке строки: {line}");
                        Console.WriteLine("Недопустимый тип данных для поля 'Account Number'.");
                        return;
                    }

                    // Проверка наличия всех значений
                    if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                    {
                        invalidLineCount++;
                        Console.WriteLine($"Ошибка при обработке строки: {line}");
                        Console.WriteLine("Отсутствуют значения для одного или нескольких полей.");
                        return;
                    }

                    // Создание экземпляра Models и заполнение его значениями
                    Models model = new Models()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Address = address,
                        Payment = payment,
                        Date = date,
                        AccountNumber = accountNumber,
                        Service = service
                    };

                    // Добавление модели в список моделей
                    models.Add(model);

                    // Вывод обработанных данных в консоль
                    Console.WriteLine($"First Name: {model.FirstName}, Last Name: {model.LastName}, Address: {model.Address}, Payment: {model.Payment}, Date: {model.Date}, Account Number: {model.AccountNumber}, Service: {model.Service}");
                }
                else
                {
                    invalidLineCount++;
                    Console.WriteLine($"Ошибка при обработке строки: {line}");
                    Console.WriteLine("Недостаточное количество значений после разделения строки.");
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