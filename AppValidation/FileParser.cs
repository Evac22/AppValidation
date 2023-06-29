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
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла {filePath}: {ex.Message}");
            }

            return new string[0];// Если чтение файла не удалось, возвращаем пустой массив строк
        }

        public static void ProcessFile(string filePath, ref int invalidFileCount)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                int invalidLineCount = 0; // Counter for invalid lines

                Console.WriteLine($"File: {filePath}");

                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    ProcessLine(line, ref invalidLineCount);
                }

                Console.WriteLine($"Invalid lines in file {filePath}: {invalidLineCount}");
                invalidFileCount += invalidLineCount;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing file {filePath}: {ex.Message}");
                invalidFileCount++;
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

                if (values.Length >= 7)
                {
                    string firstName = values[0].Trim();
                    string lastName = values[1].Trim();
                    string address = values[2].Trim() + ", " + values[3].Trim() + ", " + values[4].Trim();
                    decimal payment;
                    DateTime date;
                    long accountNumber;
                    string service = values[6].Trim();

                    // Проверка типов данных для поля 'Payment'
                    if (!decimal.TryParse(values[5].Trim(), out payment))
                    {
                        invalidLineCount++;
                        Console.WriteLine($"Error processing line: {line}");
                        Console.WriteLine("Invalid data type for 'Payment' field.");
                        return;
                    }

                    // Проверка типов данных для поля 'Date'
                    if (!DateTime.TryParse(values[6].Trim(), out date))
                    {
                        invalidLineCount++;
                        Console.WriteLine($"Error processing line: {line}");
                        Console.WriteLine("Invalid data type for 'Date' field.");
                        return;
                    }

                    // Проверка типов данных для поля 'Account Number'
                    if (!long.TryParse(values[7].Trim(), out accountNumber))
                    {
                        invalidLineCount++;
                        Console.WriteLine($"Error processing line: {line}");
                        Console.WriteLine("Invalid data type for 'Account Number' field.");
                        return;
                    }

                    // Проверка наличия всех значений
                    if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                    {
                        invalidLineCount++;
                        Console.WriteLine($"Error processing line: {line}");
                        Console.WriteLine("Missing values for one or more fields.");
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


                    // Выполните необходимую обработку данных и сохраните результаты
                    // в соответствующем формате

                    // Вывод обработанных данных в консоль
                    Console.WriteLine($"First Name: {model.FirstName}, Last Name: {model.LastName}, Address: {model.Address}, Payment: {model.Payment}, Date: {model.Date}, Account Number: {model.AccountNumber}, Service: {model.Service}");
                }
                else
                {
                    invalidLineCount++;
                    Console.WriteLine($"Error processing line: {line}");
                    Console.WriteLine("Insufficient values after line splitting.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing line: {line}");
                Console.WriteLine(ex.Message);
                // Логирование ошибки, если требуется
            }
        }

    }

}
