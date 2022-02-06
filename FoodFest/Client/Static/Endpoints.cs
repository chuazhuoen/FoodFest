using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodFest.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string ReservationsEndpoint = $"{Prefix}/reservations";
        public static readonly string RestaurantsEndpoint = $"{Prefix}/restaurants";
        public static readonly string ReviewsEndpoint = $"{Prefix}/reviews";
        public static readonly string CuisinesEndpoint = $"{Prefix}/cuisines";
    }
}
