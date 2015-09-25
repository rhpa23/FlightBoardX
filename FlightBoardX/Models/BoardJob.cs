using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBoardX.Models
{
    public class BoardJob
    {
        // Plane			To		From	Dist	EOBT		POB		CRG		Profit

        public string Plane { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public long Dist { get; set; }
        public long Eobt { get; set; }
        public long Pob { get; set; }
        public long Cargo { get; set; }
        public long Profit { get; set; }
    }
}
