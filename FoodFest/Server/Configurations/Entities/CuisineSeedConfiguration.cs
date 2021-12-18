using FoodFest.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodFest.Server.Configurations.Entities
{
    public class CuisineSeedConfiguration : IEntityTypeConfiguration<Cuisine>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cuisine> builder)
        {
            builder.HasData(
                new Cuisine
                {
                    ID = 1,
                    Name = "Chinese",
                    Appetiser = "Peanuts",
                    MainCourse = "Fried Rice",
                    Dessert = "Watermelon"
                },
                new Cuisine
                {
                    ID = 2,
                    Name = "Korean",
                    Appetiser = "Tteokbokki",
                    MainCourse = "Kimchi Fried Rice",
                    Dessert = "Bingsu"
                },
                new Cuisine
                {
                    ID = 3,
                    Name = "Japanese",
                    Appetiser = "Sushi",
                    MainCourse = "Japanese Curry Udon",
                    Dessert = "Mochi"
                },
                new Cuisine
                {
                    ID = 4,
                    Name = "Western",
                    Appetiser = "Shepherd's Pie",
                    MainCourse = "Fish and Chips",
                    Dessert = "Sundae"
                });
        }
    }
}
