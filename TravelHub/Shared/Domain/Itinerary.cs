using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHub.Shared.Domain
{
    public class Itinerary
    {
        public int ItineraryID { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Duration must be greater than 0")]
        public int Duration { get; set; }
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Budget must be greater than 0")]
        public float Budget { get; set; }
        public virtual Customer Customer { get; set; }
        [Required]
        public int? CustomerID { get; set; } 
    }
}
