using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHub.Shared.Domain
{
    public class Activity
    {
        
        public int ActivityID { get; set; }
        [Required]
        [StringLength(100,MinimumLength =2,ErrorMessage ="Name does not meet requirements")]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        [Range(1,10,ErrorMessage ="Rating must be between 1 - 10")]
        public int Rating { get; set; }
        [Required]
        public int? StaffID { get; set; }
        public virtual Staff Staff { get; set; }
        [Required]
        public int? LocationID { get; set; }
        public virtual Location Location { get; set; }
    }
}
