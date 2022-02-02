using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodFest.Shared.Domain
{
    public class Reservation
    {
        public int ID { get; set; }
        public string People { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ReserveDateTime { get; set; }
        public int? RestaurantId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Restaurant Restaurant{ get; set; }
    }
}
