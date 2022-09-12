using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalAPiTest.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaID",
                keyValue: 1151,
                column: "FechaCreacion",
                value: new DateTime(2022, 8, 31, 4, 33, 49, 367, DateTimeKind.Local).AddTicks(587));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaID",
                keyValue: 2252,
                column: "FechaCreacion",
                value: new DateTime(2022, 8, 31, 4, 33, 49, 367, DateTimeKind.Local).AddTicks(598));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaID",
                keyValue: 1151,
                column: "FechaCreacion",
                value: new DateTime(2022, 8, 31, 4, 18, 2, 208, DateTimeKind.Local).AddTicks(2247));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaID",
                keyValue: 2252,
                column: "FechaCreacion",
                value: new DateTime(2022, 8, 31, 4, 18, 2, 208, DateTimeKind.Local).AddTicks(2259));
        }
    }
}
