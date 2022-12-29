using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHub.Shared.Domain
{
    public class Location
    {
        public int LocationID { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public int Safety { get; set; }
        public int CityID { get; set; }
        public virtual City City { get; set; }
    }
}
