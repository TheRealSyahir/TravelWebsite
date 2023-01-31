using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHub.Shared.Domain
{
    public class City
    {
        public int CityID { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name does not meet requirements")]
        public String Name { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Safety must be between 1 - 5")]
        public int Safety { get; set; }
        [Required]
        public String Transport { get; set; }
        [Required]
        [StringLength(100,MinimumLength =2,ErrorMessage ="Country name does not meet requirements")]
        public String Countryname { get; set; }

    }
}
