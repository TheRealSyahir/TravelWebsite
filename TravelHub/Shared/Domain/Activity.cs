using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHub.Shared.Domain
{
    public class Activity
    {
        public int ActivityID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public float Price { get; set; }
        public int Rating { get; set; }
        public int StaffID { get; set; }
        public virtual Staff Staff { get; set; }
        public int LocationID { get; set; }
        public virtual Location Location { get; set; }
    }
}
