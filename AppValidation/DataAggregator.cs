//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace AppValidation
//{
//    internal class DataAggregator
//    {
//        public  decimal TotalPayment { get; set; }
//        public Dictionary<string, List<Models>> CityPayers { get; set; }
//        public Dictionary<string, List<Models>> ServicePayers { get; set; }

//        public DataAggregator() 
//        {
//            TotalPayment = 0;
//            CityPayers = new Dictionary<string, List<Models>>();
//            ServicePayers = new Dictionary<string, List<Models>>();  
//        }

//        public void Aggregate(List<Models> models)
//        {
//            foreach (Models model in models)
//            {
//                TotalPayment += model.Payment;

//                if (!CityPayers.ContainsKey(model.Address))
//                    CityPayers[model.Address] = new List<Models>();

//                CityPayers[model.Address].Add(model);

//                if (!ServicePayers.ContainsKey(model.Service))
//                    ServicePayers[model.Service] = new List<Models>();

//                ServicePayers[model.Service].Add(model);

//            }
//        }

//        public static void DisplayAggregatedData(DataAggregator dataAggregator)
//        {
//            Console.WriteLine($"Total Payment: {dataAggregator.TotalPayment}");

//            Console.WriteLine("Payers by City:");
//            foreach (KeyValuePair<string, List<Models>> kvp in dataAggregator.CityPayers)
//            {
//                Console.WriteLine($"City: {kvp.Key}");
//                foreach (Models model in kvp.Value)
//                {
//                    Console.WriteLine($"Name: {model.FirstName} {model.LastName}, Payment: {model.Payment}");
//                }
//            }

//            Console.WriteLine("Payers by Service:");
//            foreach (KeyValuePair<string, List<Models>> kvp in dataAggregator.ServicePayers)
//            {
//                Console.WriteLine($"Service: {kvp.Key}");
//                foreach (Models model in kvp.Value)
//                {
//                    Console.WriteLine($"Name: {model.FirstName} {model.LastName}, Payment: {model.Payment}");
//                }
//            }
//        }

//    }
//}
