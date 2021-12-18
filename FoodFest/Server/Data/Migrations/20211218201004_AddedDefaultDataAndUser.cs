using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodFest.Server.Data.Migrations
{
    public partial class AddedDefaultDataAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cuisines",
                columns: new[] { "ID", "Appetiser", "Dessert", "MainCourse", "Name", "RestaurantID" },
                values: new object[,]
                {
                    { 1, "Peanuts", "Watermelon", "Fried Rice", "Chinese", null },
                    { 2, "Tteokbokki", "Bingsu", "Kimchi Fried Rice", "Korean", null },
                    { 3, "Sushi", "Mochi", "Japanese Curry Udon", "Japanese", null },
                    { 4, "Shepherd's Pie", "Sundae", "Fish and Chips", "Western", null }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ID", "CustomerID", "Description", "Ratings", "RestaurantID" },
                values: new object[,]
                {
                    { 1, null, "Excellent food, excellent customer service!", 5, null },
                    { 2, null, "Good food, good customer service!", 4, null },
                    { 3, null, "Not bad! Can improve!", 3, null },
                    { 4, null, "Food and customer service is not very good. ", 2, null },
                    { 5, null, "Never coming back again!!!!", 1, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}
