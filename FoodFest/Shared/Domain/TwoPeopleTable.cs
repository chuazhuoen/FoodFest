using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodFest.Shared.Domain
{
    public class TwoPeopleTable
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
