using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppValidation
{
    internal class MetaLog
    {
        //Компонент, отвечающий за запись метаданных о работе приложения, таких как количество обработанных файлов, количество обработанных строк, количество ошибок и
        //невалидных файлов.

        public static void EndOfDay(string subfolderPath, int processedFileCount, int processedLineCount, int errorCount, List<string> invalidFiles)
        {
            // Создание пути к файлу meta.log
            string metaLogFilePath = Path.Combine(subfolderPath, "meta.log");

            // Создание содержимого файла meta.log
            StringBuilder contentBuilder = new StringBuilder();
            contentBuilder.AppendLine("End of Day Summary");
            contentBuilder.AppendLine($"Processed File Count: {processedFileCount}");
            contentBuilder.AppendLine($"Processed Line Count: {processedLineCount}");
            contentBuilder.AppendLine($"Error Count: {errorCount}");
            contentBuilder.AppendLine("Invalid Files:");

            foreach (string invalidFile in invalidFiles)
            {
                contentBuilder.AppendLine(invalidFile);
            }

            // Запись содержимого в файл meta.log
            File.WriteAllText(metaLogFilePath, contentBuilder.ToString());

            Console.WriteLine("Файл meta.log успешно создан.");
        }
    }
}
