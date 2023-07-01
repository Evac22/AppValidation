using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppValidation
{
    internal class DataAggregator
    {
        public  decimal TotalPayment { get; set; }
        public Dictionary<string, List<Models>> CityPayers { get; set; }
        public Dictionary<string, List<Models>> ServicePayers { get; set; }

        public DataAggregator() 
        {
            TotalPayment = 0;
            CityPayers = new Dictionary<string, List<Models>>();
            ServicePayers = new Dictionary<string, List<Models>>();  
        }

        public void Aggregate(List<Models> models)
        {
            foreach (Models model in models)
            {
                TotalPayment += model.Payment;

                if (!CityPayers.ContainsKey(model.Address))
                    CityPayers[model.Address] = new List<Models>();

                CityPayers[model.Address].Add(model);

                if (!ServicePayers.ContainsKey(model.Service))
                    ServicePayers[model.Service] = new List<Models>();

                ServicePayers[model.Service].Add(model);

            }
        }
    }
}
