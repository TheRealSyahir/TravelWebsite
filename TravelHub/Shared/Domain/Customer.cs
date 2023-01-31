using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHub.Shared.Domain
{
    public class Customer
    {
        public int CustomerID { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name does not meet requirements")]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Address does not meet requirements")]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(6|8|9)\d{7}", ErrorMessage = "Number is not a valid")]
        public int Number { get; set; }
    }
}
