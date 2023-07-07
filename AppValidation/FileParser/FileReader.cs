using AppValidation.FileParser.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AppValidation.FileParser
{
    internal class FileReader : IFileReader       
    {
        public string[] ReadFileLines(string filePath)
        {
            try
            {
                return File.ReadAllLines(filePath);
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Ошибка при чтении файла {filePath}: {ex.Message}");
            }

            return new string[0];
        }
    }
}
