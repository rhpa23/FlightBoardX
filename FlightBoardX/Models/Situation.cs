using FlightBoardX.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBoardX.Models
{
    public class Situation
    {
        public long Id { get; set; }
        public string CurrentLocation { get; set; }
        public decimal CompanyCash { get; set; }


        public Situation Get()
        {
            var data = new LocalDataBase();
            return data.SelectSituation();
        }

        public void Insert()
        {
            new LocalDataBase().InsertSituation(this);
        }

        public void Update()
        {
            new LocalDataBase().UpdateSituation(this);
        }

        //public void Delete()
        //{
        //    new LocalDataBase().UpdateSituation(this);
        //}

    }
}
