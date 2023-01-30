using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHub.Shared.Domain
{
    public class ActivitySelection
    {
        public int ActivitySelectionID { get; set; }
        public DateTime Date { get; set; }
        public int ItineraryID { get; set; }
        public virtual Itinerary Itinerary { get; set; }
        public int ActivityID { get; set; } 
        public virtual Activity Activity { get; set; }
    }
}
