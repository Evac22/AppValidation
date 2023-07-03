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
            int invalidFileCount = 0;
            int processedFileCount = 0;
            int processedLineCount = 0;
            int errorCount = 0;
            List<string> invalidFiles = new List<string>();

            // Создание экземпляра DataAggregator
            DataAggregator dataAggregator = new DataAggregator();

            // Обработка файлов и агрегирование данных
            Config.DisplayAllFiles(folderPath, dataAggregator);


            // Обработка файлов и агрегирование данных
            FileParser.ProcessFiles(folderPath, ref invalidFileCount, ref processedFileCount, ref processedLineCount, ref errorCount, invalidFiles, dataAggregator);

            // Сохранение результатов
            FileStorage.SaveResultsToFile(dataAggregator);

            // Завершение дня и создание файла meta.log
            string subfolderPath = Path.GetDirectoryName(folderPath);
            MetaLog.EndOfDay(subfolderPath, processedFileCount, processedLineCount, errorCount, invalidFiles);

            // Вывод агрегированных данных
            DataAggregator.DisplayAggregatedData(dataAggregator);

            // Завершение работы. Нажмите любую клавишу для выхода.
            Console.WriteLine("Завершение работы. Нажмите любую клавишу для выхода.");
            Console.ReadKey();
        }


    }
}
