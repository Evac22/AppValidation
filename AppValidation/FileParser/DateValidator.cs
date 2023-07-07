using AppValidation.FileParser.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppValidation.FileParser
{
    internal class DateValidator : IDateValidator
    {
        public bool AreAllValuesPresent(string[] values)
        {
            // Проверяем, что все значения в массиве не являются пустыми или нулевыми
            return values.All(value => !string.IsNullOrEmpty(value));
        }

        public bool IsValidAccountNumber(string value)
        {
            // Реализуйте логику валидации номера счета
            // Возвращайте true, если номер счета валиден, иначе false
            // Например:
            // return MyAccountNumberValidationLogic.Validate(value);

            // В данном случае, так как логика валидации неизвестна,
            // просто возвращаем true
            return true;
        }

        public bool IsValidDate(string value)
        {
            // Реализуйте логику валидации даты
            // Возвращайте true, если дата валидна, иначе false
            // Например:
            // return MyDateValidationLogic.Validate(value);

            // В данном случае, так как логика валидации неизвестна,
            // просто возвращаем true
            return true;
        }

        public bool IsValidLine(string line)
        {
            // Реализуйте логику валидации строки
            // Возвращайте true, если строка валидна, иначе false
            // Например:
            // return MyLineValidationLogic.Validate(line);

            // В данном случае, так как логика валидации неизвестна,
            // просто возвращаем true
            return true;
        }

        public bool IsValidPayment(string value)
        {
            // Реализуйте логику валидации платежа
            // Возвращайте true, если платеж валиден, иначе false
            // Например:
            // return MyPaymentValidationLogic.Validate(value);

            // В данном случае, так как логика валидации неизвестна,
            // просто возвращаем true
            return true;
        }
    }
}
