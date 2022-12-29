using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHub.Shared.Domain
{
    class Location
    {
        public int LocationID { get; set; }
        public String name { get; set; }
        public String address { get; set; }
        public int safety { get; set; }
        public int CityID { get; set; }
        public virtual City City { get; set; }
    }
}
