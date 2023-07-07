using AppValidation.FileParser.Interface;
using System;
using System.Collections.Generic;


namespace AppValidation.FileParser
{
    internal class DataAggregator : IDataAggregator
    {
      
        
           

       void IDataAggregator.Aggregate(List<Models> models)
       {
            
            foreach (var model in models)
            {
                Console.WriteLine($"Aggregating Model: {model.FirstName} {model.LastName}");
                
            }
       }
    }

}
