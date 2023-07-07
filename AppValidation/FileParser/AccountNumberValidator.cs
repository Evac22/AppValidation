using AppValidation.FileParser.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppValidation.FileParser
{
    internal class AccountNumberValidator : IAccountNumberValidator
    {
        public bool IsValidAccountNumber(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            // Проверка, что значение является числом
            if (!long.TryParse(value, out long accountNumber))
            {
                return false;
            }

            // Дополнительная логика валидации номера счета
            // Например, проверка длины, формата и т.д.

            // Возвращаем результат валидации
            return true;
        }
    }

}
