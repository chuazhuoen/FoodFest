using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodFest.Server.Data.Migrations
{
    public partial class AddedDefaultDataAndUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ID", "CustomerID", "DateCreated", "People", "ReserveDateTime", "RestaurantID" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 12, 19, 4, 13, 35, 725, DateTimeKind.Local).AddTicks(2082), null },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 12, 19, 4, 13, 35, 726, DateTimeKind.Local).AddTicks(4359), null },
                    { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2021, 12, 19, 4, 13, 35, 726, DateTimeKind.Local).AddTicks(4385), null },
                    { 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2021, 12, 19, 4, 13, 35, 726, DateTimeKind.Local).AddTicks(4388), null },
                    { 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2021, 12, 19, 4, 13, 35, 726, DateTimeKind.Local).AddTicks(4389), null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}
