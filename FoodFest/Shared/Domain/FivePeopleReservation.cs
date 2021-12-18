using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodFest.Shared.Domain
{
    public class FivePeopleReservation
    {
        public int ID { get; set; }
        public virtual Reservation Reservation { get; set; }
        public virtual FivePeopleTable FivePeopleTable { get; set; }

    }
}
