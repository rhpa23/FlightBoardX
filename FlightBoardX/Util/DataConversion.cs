using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBoardX.Util
{
    public class DataConversion
    {
        public static double ConvertMetersToMiles(double meters)
        {
            return (meters / 1852);
        }
    }
}
