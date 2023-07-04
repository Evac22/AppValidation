using AppValidation.Config.Interfaces;
using AppValidation.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using log4net;

namespace AppValidation.Config
{
    internal class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            //string folderPath = Config.GetFolderPathFromConfig();
            //int invalidFileCount = 0;
            //int processedFileCount = 0;
            //int processedLineCount = 0;
            //int errorCount = 0;
            //List<string> invalidFiles = new List<string>();

            //// Создание экземпляра DataAggregator
            //DataAggregator dataAggregator = new DataAggregator();

            //// Обработка файлов и агрегирование данных
            //Config.DisplayAllFiles(folderPath, dataAggregator);


            //// Обработка файлов и агрегирование данных
            //FileParser.ProcessFiles(folderPath, ref invalidFileCount, ref processedFileCount, ref processedLineCount, ref errorCount, invalidFiles, dataAggregator);

            //// Сохранение результатов
            //FileStorage.SaveResultsToFile(dataAggregator);

            //// Завершение дня и создание файла meta.log
            //string subfolderPath = Path.GetDirectoryName(folderPath);
            //MetaLog.EndOfDay(subfolderPath, processedFileCount, processedLineCount, errorCount, invalidFiles);

            //// Вывод агрегированных данных
            //DataAggregator.DisplayAggregatedData(dataAggregator);

            // Настройка log4net
            log4net.Config.XmlConfigurator.Configure();

            try
            {
                IConfigReader configReader = new ConfigurationManagerWrapper();
                IFolderPathConfigProvider folderPathConfigProvider = new FolderPathConfigProvider(configReader);
                IResultFolderPathConfigProvider resultFolderPathConfigProvider = new ResultFolderPathConfigProvider(configReader);
                ISubfolderNameConfigProvider subfolderNameConfigProvider = new SubfolderNameConfigProvider(configReader);

                // Создание экземпляра класса Config с передачей зависимостей
                Config config = new Config(folderPathConfigProvider, resultFolderPathConfigProvider, subfolderNameConfigProvider);

                // Использование методов класса Config
                string folderPath = config.GetFolderPathFromConfig();
                string resultFolderPath = config.GetResultFolderPathFromConfig();
                string subfolderName = config.GetSubfolderNameFromConfig();

                // Вывод результатов
                Console.WriteLine("Folder Path: " + folderPath);
                Console.WriteLine("Result Folder Path: " + resultFolderPath);
                Console.WriteLine("Subfolder Name: " + subfolderName);

                // Дополнительная логика...
            }
            catch (Exception ex)
            {
                log.Error("Произошла ошибка.", ex);
            }



            // Завершение работы. Нажмите любую клавишу для выхода.
            Console.WriteLine("Завершение работы. Нажмите любую клавишу для выхода.");
            Console.ReadKey();
        }


    }
}
