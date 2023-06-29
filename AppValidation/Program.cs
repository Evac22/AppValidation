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
                Config.DisplayAllFiles(folderPath);
            }

            Console.WriteLine("Завершение работы. Нажмите любую клавишу для выхода.");
            Console.ReadKey();

        }
    }
}
