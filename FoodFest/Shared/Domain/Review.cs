﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodFest.Shared.Domain
{
    public class Review
    {
        public int ID { get; set; }
        public string Ratings { get; set; }
        public string Description { get; set; }
        public int RestId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual Customer Customer { get; set; }
    }
}