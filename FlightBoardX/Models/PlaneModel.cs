using FlightBoardX.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBoardX.Models
{
    public class PlaneModel
    {
        public long id { get; set; }

        public string Name { get; set; }

        public decimal FuelConsumption { get; set; }

        public decimal Cost { get; set; }


        public List<PlaneModel> GetAll()
        {
            var data = new LocalDataBase();
            var allPlanes = data.SelectAllModels();

            var lstResult = new List<PlaneModel>();
            foreach (var model in allPlanes)
            {
                lstResult.Add(model);
            }

            return lstResult;
        }

        public void Insert()
        {
            new LocalDataBase().InsertModel(this);
        }


        public void Delete()
        {
            new LocalDataBase().DeleteModel(this);
        }
    }
}
