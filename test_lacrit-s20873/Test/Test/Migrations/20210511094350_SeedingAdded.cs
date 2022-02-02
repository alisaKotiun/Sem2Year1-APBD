using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Migrations
{
    public partial class SeedingAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Action",
                columns: new[] { "IdAction", "EndTime", "NeedSpecialEquipment", "StartTime" },
                values: new object[,]
                {
                    { 1, null, false, new DateTime(2021, 5, 11, 11, 43, 48, 650, DateTimeKind.Local).AddTicks(428) },
                    { 2, null, false, new DateTime(2021, 5, 11, 11, 43, 48, 660, DateTimeKind.Local).AddTicks(2520) }
                });

            migrationBuilder.InsertData(
                table: "FireTruck",
                columns: new[] { "IdFireTruck", "OperationalNumber", "SpecialEquipment" },
                values: new object[,]
                {
                    { 1, "123", true },
                    { 2, "124", false }
                });

            migrationBuilder.InsertData(
                table: "Firefighter",
                columns: new[] { "IdFirefighter", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Alisa", "Kotiun" },
                    { 2, "Ann", "Kotiun" }
                });

            migrationBuilder.InsertData(
                table: "FireTruck_Action",
                columns: new[] { "IdFireTruckAction", "AssignmentDate", "IdAction", "IdFireTruck" },
                values: new object[] { 1, new DateTime(2021, 5, 11, 11, 43, 48, 661, DateTimeKind.Local).AddTicks(62), 1, 1 });

            migrationBuilder.InsertData(
                table: "Firefighter_Action",
                columns: new[] { "IdAction", "IdFirefighter" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Action",
                keyColumn: "IdAction",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FireTruck",
                keyColumn: "IdFireTruck",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FireTruck_Action",
                keyColumn: "IdFireTruckAction",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Firefighter",
                keyColumn: "IdFirefighter",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Firefighter_Action",
                keyColumns: new[] { "IdAction", "IdFirefighter" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Action",
                keyColumn: "IdAction",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FireTruck",
                keyColumn: "IdFireTruck",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Firefighter",
                keyColumn: "IdFirefighter",
                keyValue: 1);
        }
    }
}
