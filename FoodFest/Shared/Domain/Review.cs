using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodFest.Shared.Domain
{
    public class Review
    {
        public int ID { get; set; }
        [Required]
        [Range(1,5)]
        public int Ratings { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 2, ErrorMessage = "Description does not meet requirements")]

        public string Description { get; set; }
        public int RestId { get; set; }
        [Required]
        public string RestName { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual Customer Customer { get; set; }
    }
}