using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodFest.Shared.Domain
{
    public class Cuisine
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Appetiser { get; set; }
        public string MainCourse { get; set; }
        public string Dessert { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
