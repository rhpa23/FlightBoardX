using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FlightBoardX.Models;

namespace FlightBoardX.Util
{
    public class AirportDatabaseFile
    {
        /*

           Airport Tuple contains the following pieces of information:

           01.)Airport ICAO Code (4)
           02.)Airport IATA (3)
           03.)Airport Name (?)
           04.)City or Town or Suburb (?)
           05.)Country (?)
           06.)Latitude Degrees (2)
           07.)Latitude Minutes (2)
           08.)Latitude Seconds (2)
           09.)Latitude Direction (2)
           10.)Longitude Degrees (1)
           11.)Longitude Minutes (2)
           12.)Longitude Seconds (2)
           13.)Longitude Direction (1)
           14.)Altitude (?)

        */

        private static string fileName = "GlobalAirportDatabase.txt";

        public static Base FindAirportInfo(string code)
        {
            var airportInfo = File.ReadLines(fileName).First(line => Regex.IsMatch(line, "(^"+ code +".*$)"));
            Console.WriteLine(airportInfo);

            string[] infoArray = airportInfo.Split(':');

            var lat = double.Parse(infoArray[5] + CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator + infoArray[6] + infoArray[7]);
            var log = double.Parse(infoArray[9] + CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator + infoArray[10] + infoArray[11]);
            
            if ("S".Equals(infoArray[8])) lat = lat*-1;

            if ("U".Equals(infoArray[12])) log = log * -1;

            Base airportBase = new Base()
            {
                ICAO = infoArray[0],
                IATA = infoArray[1],
                AirportName = infoArray[2],
                City = infoArray[3],
                Country = infoArray[4],
                Latitude = lat,
                Longitude = log,
                Altitude = int.Parse(infoArray[13])
            };
            return airportBase;
        }
    }
}
