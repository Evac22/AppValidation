using AppValidation.Configs.Interfaces;
using AppValidation.Configs;
using AppValidation.FileParser;
using AppValidation.FileParser.Interface;
using System;

namespace AppValidation
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            // Инициализация логирования
            log4net.Config.XmlConfigurator.Configure();

            try
            {
                // Создание экземпляров классов, реализующих интерфейсы в папке Config
                IConfigReader configReader = new ConfigurationManagerWrapper();
                IFolderPathConfigProvider folderPathConfigProvider = new FolderPathConfigProvider(configReader);
                IResultFolderPathConfigProvider resultFolderPathConfigProvider = new ResultFolderPathConfigProvider(configReader);
                ISubfolderNameConfigProvider subfolderNameConfigProvider = new SubfolderNameConfigProvider(configReader);

                
                // Создание экземпляра класса Config с передачей зависимостей
                Config config = new Config(folderPathConfigProvider, resultFolderPathConfigProvider, subfolderNameConfigProvider);

                // Чтение содержимого файла
                string fileContent = config.ReadFileContent();
                Console.WriteLine("File Content: " + fileContent);

               

                // Использование методов класса Config
                string folderPath = config.GetFolderPathFromConfig();
                string resultFolderPath = config.GetResultFolderPathFromConfig();
                string subfolderName = config.GetSubfolderNameFromConfig();



                // Вывод результатов
                Console.WriteLine("Folder Path: " + folderPath);
                Console.WriteLine("Result Folder Path: " + resultFolderPath);
                Console.WriteLine("Subfolder Name: " + subfolderName);

                // Создание экземпляра класса DataProcessor с внедрением зависимостей
                IFileReader fileReader = new FileReader();
                ILineValidator lineValidator = new LineValidator();
                IPaymentValidator paymentValidator = new PaymentValidator();
                IDateValidator dateValidator = new DateValidator();
                IAccountNumberValidator accountNumberValidator = new AccountNumberValidator();
                IDataConverter dataConverter = new DataConverter();
                IDataAggregator dataAggregator = new DataAggregator();

                DataProcessor dataProcessor = new DataProcessor(
                    fileReader,
                    lineValidator,
                    paymentValidator,
                    dateValidator,
                    accountNumberValidator,
                    dataConverter,
                    dataAggregator);

                // Обработка данных
                dataProcessor.ProcessData(folderPath);

                // Дополнительная логика...

                // Завершение работы. Нажмите любую клавишу для выхода.
                Console.WriteLine("Завершение работы. Нажмите любую клавишу для выхода.");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                log.Error("Произошла ошибка.", ex);
            }
        }
    }
}
