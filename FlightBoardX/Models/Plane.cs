using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightBoardX.Enum;
using FlightBoardX.Database;
using FlightBoardX.Error;
using FlightBoardX.Util;

namespace FlightBoardX.Models
{
    public class Plane
    {
        public string Companny { get; set; }

        public String Country { get; set; }

        public PlaneModel Model { get; set; }

        public string ModelName
        {
            get { return this.Model.Name; } 
        }


        public List<Plane> GetAll()
        {
            var data = new LocalDataBase();
            var allPlanes = data.SelectAllPlanes();

            var lstResult = new List<Plane>();
            foreach (var myPlane in allPlanes)
            {
                lstResult.Add(myPlane);
            }

            return lstResult;
        }

        public List<Plane> GetPlanesByCountry()
        {
            var data = new LocalDataBase();
            var allPlanes = data.SelectlPlanesByCountry(Country);

            var lstResult = new List<Plane>();
            foreach (var myPlane in allPlanes)
            {
                lstResult.Add(myPlane);
            }

            return lstResult;
        }

        public void Insert()
        {
            new LocalDataBase().InsertPlane(this);
        }


        public void Delete()
        {
            new LocalDataBase().DeletePlane(this);
        }
    }
}
