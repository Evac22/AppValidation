using AppValidation.FileParser.Interface;
using System;
using System.Collections.Generic;

namespace AppValidation.FileParser
{
    internal class DataProcessor
    {
        private readonly IFileReader fileReader;
        private readonly ILineValidator lineValidator;
        private readonly IPaymentValidator paymentValidator;
        private readonly IDateValidator dateValidator;
        private readonly IAccountNumberValidator accountNumberValidator;
        private readonly IDataConverter dataConverter;
        private readonly IDataAggregator dataAggregator;

        public DataProcessor(
            IFileReader fileReader,
            ILineValidator lineValidator,
            IPaymentValidator paymentValidator,
            IDateValidator dateValidator,
            IAccountNumberValidator accountNumberValidator,
            IDataConverter dataConverter,
            IDataAggregator dataAggregator)
        {
            this.fileReader = fileReader;
            this.lineValidator = lineValidator;
            this.paymentValidator = paymentValidator;
            this.dateValidator = dateValidator;
            this.accountNumberValidator = accountNumberValidator;
            this.dataConverter = dataConverter;
            this.dataAggregator = dataAggregator;
        }

        public void ProcessData(string filePath)
        {
            string[] lines = fileReader.ReadFileLines(filePath);
            List<Models> validModels = new List<Models>();

            foreach (string line in lines)
            {
                if (lineValidator.IsValidLine(line))
                {
                    string[] values = dataConverter.SplitLine(line);

                    if (dateValidator.AreAllValuesPresent(values) &&
                        dateValidator.IsValidPayment(values[0]) &&
                        dateValidator.IsValidDate(values[1]) &&
                        dateValidator.IsValidAccountNumber(values[2]))
                    {
                        Models model = dataConverter.ConvertModel(values);
                        validModels.Add(model);
                    }
                }
            }

            dataAggregator.Aggregate(validModels);
        }
    }
}
