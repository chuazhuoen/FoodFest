using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodFest.Shared.Domain
{
    public class TwoPeopleReservation
    {
        public int ID { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 2, ErrorMessage = "Name does not meet requirements")]
        public string Name { get; set; }
        [Required]
        public string RName { get; set; }
        public virtual Reservation Reservation { get; set; }
        public virtual TwoPeopleTable TwoPeopleTable { get; set; }

    }
}
