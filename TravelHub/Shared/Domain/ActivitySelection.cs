using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHub.Shared.Domain
{
    public class ActivitySelection
    {
        public int AcsID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int? ItnID { get; set; }
        public virtual Itinerary Itinerary { get; set; }
        [Required]
        public int? AcID { get; set; } 
        public virtual Activity Activity { get; set; }
    }
}
