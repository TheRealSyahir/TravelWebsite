using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHub.Shared.Domain
{
    public class Itinerary
    {
        public int ItnID { get; set; }
        public int Duration { get; set; }
        public float Budget { get; set; }
        public virtual Customer Customer { get; set; }
        public int CustID { get; set; } 
    }
}
