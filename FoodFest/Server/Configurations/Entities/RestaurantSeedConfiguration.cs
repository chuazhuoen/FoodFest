using FoodFest.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodFest.Server.Configurations.Entities
{
    public class RestaurantSeedConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Restaurant> builder)
        {
            builder.HasData(
                new Restaurant
                {
                    ID = 1,
                    Name = "JiaHe Chinese Restaurant",
                    Number = "6694 8988",
                    Address = "1 Farrer Park Station Rd, #01-14/15/16 One Farrer Hotel Connexion, Singapore 217562",
                    PriceRange = "$$$"
                },
                new Restaurant
                {
                    ID = 2,
                    Name = "Seoul Garden Nex",
                    Number = "6555 1339",
                    Address = "23 Serangoon Central, #B1-34/35 NEX, Singapore 556083",
                    PriceRange = "$$$$"
                },
                new Restaurant
                {
                    ID = 3,
                    Name = "Ichiban Sushi (Hougang Mall)",
                    Number = "6386 7836",
                    Address = "90 Hougang Avenue 10 #02-23, Hougang Mall, 538766",
                    PriceRange = "$$$$"
                },
                new Restaurant
                {
                    ID = 4,
                    Name = "The Ranch Cafe",
                    Number = "6747 0788",
                    Address = "71 / 73 Lor 27 Geylang, Singapore 388191",
                    PriceRange = "$$"
                });
        }
    }
}
