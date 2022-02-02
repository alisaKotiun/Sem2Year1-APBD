using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Migrations
{
    public partial class SeedingTwoAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Action",
                keyColumn: "IdAction",
                keyValue: 1,
                columns: new[] { "NeedSpecialEquipment", "StartTime" },
                values: new object[] { true, new DateTime(2021, 5, 11, 11, 49, 17, 102, DateTimeKind.Local).AddTicks(5594) });

            migrationBuilder.UpdateData(
                table: "Action",
                keyColumn: "IdAction",
                keyValue: 2,
                column: "StartTime",
                value: new DateTime(2021, 5, 11, 11, 49, 17, 117, DateTimeKind.Local).AddTicks(3042));

            migrationBuilder.UpdateData(
                table: "FireTruck_Action",
                keyColumn: "IdFireTruckAction",
                keyValue: 1,
                column: "AssignmentDate",
                value: new DateTime(2021, 5, 11, 11, 49, 17, 118, DateTimeKind.Local).AddTicks(1248));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Action",
                keyColumn: "IdAction",
                keyValue: 1,
                columns: new[] { "NeedSpecialEquipment", "StartTime" },
                values: new object[] { false, new DateTime(2021, 5, 11, 11, 43, 48, 650, DateTimeKind.Local).AddTicks(428) });

            migrationBuilder.UpdateData(
                table: "Action",
                keyColumn: "IdAction",
                keyValue: 2,
                column: "StartTime",
                value: new DateTime(2021, 5, 11, 11, 43, 48, 660, DateTimeKind.Local).AddTicks(2520));

            migrationBuilder.UpdateData(
                table: "FireTruck_Action",
                keyColumn: "IdFireTruckAction",
                keyValue: 1,
                column: "AssignmentDate",
                value: new DateTime(2021, 5, 11, 11, 43, 48, 661, DateTimeKind.Local).AddTicks(62));
        }
    }
}
