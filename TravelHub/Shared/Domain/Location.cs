using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHub.Shared.Domain
{
    public class Location
    {
        public int LocationID { get; set; }
        [Required]
        [StringLength(100,MinimumLength =2,ErrorMessage ="Name does not meet requirements")]
        public String Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Address does not meet requirements")]
        public String Address { get; set; }
        [Required]
        [Range(1,5,ErrorMessage ="Safety must be between 1 - 5")]
        public int Safety { get; set; }
        [Required]
        public int? CityID { get; set; }
        public virtual City City { get; set; }
    }
}
