using FoodFest.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodFest.Server.Configurations.Entities
{
    public class ReviewSeedConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Review> builder)
        {
            builder.HasData(
                new Review
                {
                    ID = 1,
                    Ratings =  5, 
                    Description = "Excellent food, excellent customer service!"
                },
                new Review
                {
                    ID = 2,
                    Ratings = 4,
                    Description = "Good food, good customer service!"
                },
                new Review
                {
                    ID = 3,
                    Ratings = 3,
                    Description = "Not bad! Can improve!"
                },
                new Review
                 {
                     ID = 4,
                     Ratings = 2,
                     Description = "Food and customer service is not very good. "
                 },
                new Review
                  {
                      ID = 5,
                      Ratings = 1,
                      Description = "Never coming back again!!!!"
                  });

                    ;
        }
    }
}
