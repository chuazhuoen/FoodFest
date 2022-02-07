using FoodFest.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodFest.Server.Configurations.Entities
{
    public class ReservationSeedConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Reservation> builder)
        {
            builder.HasData(
                new Reservation
                {
                    ID = 1,
                    RName = "esther",
                    People = "1",
                    ReserveDateTime = DateTime.Now
                },
                new Reservation
                {
                    ID = 2,
                    RName = "esther",
                    People = "2",
                    ReserveDateTime = DateTime.Now
                },
                new Reservation
                {
                    ID = 3,
                    RName = "esther",
                    People = "3",
                    ReserveDateTime = DateTime.Now
                }, 
                new Reservation
                {
                    ID = 4,
                    RName = "esther",
                    People = "4",
                    ReserveDateTime = DateTime.Now
                }, new Reservation
                {
                    ID = 5,
                    RName = "esther",
                    People = "5",
                    ReserveDateTime = DateTime.Now
                });
        }
    }
}
