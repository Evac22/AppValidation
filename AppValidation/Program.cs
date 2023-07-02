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

            // Создание экземпляра DataAggregator
            DataAggregator dataAggregator = new DataAggregator();

            // Обработка файлов и агрегирование данных
            Config.DisplayAllFiles(folderPath, dataAggregator);

            // Вывод агрегированных данных
            DataAggregator.DisplayAggregatedData(dataAggregator);

            // Завершение работы. Нажмите любую клавишу для выхода.
            Console.WriteLine("Завершение работы. Нажмите любую клавишу для выхода.");
            Console.ReadKey();
        }
    }
}
