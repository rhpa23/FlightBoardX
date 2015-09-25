using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightBoardX.Database;
using FlightBoardX.Enum;
using FlightBoardX.Error;
using FlightBoardX.Util;

namespace FlightBoardX.Models
{
    public class Base
    {
        public string ICAO { get; set; }

        public string IATA { get; set; }

        public string AirportName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        //public Countries Country { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Altitude { get; set; }

        public List<Base> GetAll()
        {
            var data = new LocalDataBase();
            var allBases =  data.SelectAllBase();

            var lstResult = new List<Base>();
            foreach (var myBase in allBases)
            {
                lstResult.Add(AirportDatabaseFile.FindAirportInfo(myBase.ICAO));
            }

            return lstResult;
        }

        public void Insert()
        {
            var myBase = AirportDatabaseFile.FindAirportInfo(ICAO);
            if (myBase != null)
            {
                new LocalDataBase().InsertBase(myBase);
            }
            else
            {
                throw new NotFoundException();
            }
        }


        public void Delete()
        {
            var myBase = AirportDatabaseFile.FindAirportInfo(ICAO);
            if (myBase != null)
            {
                new LocalDataBase().DeleteBase(myBase);
            }
            else
            {
                throw new NotFoundException();
            }
        }
    }
}
