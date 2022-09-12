using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalAPiTest.Migrations
{
    public partial class NuevaMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaID",
                keyValue: 1151,
                column: "FechaCreacion",
                value: new DateTime(2022, 8, 31, 4, 48, 14, 312, DateTimeKind.Local).AddTicks(6446));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaID",
                keyValue: 2252,
                column: "FechaCreacion",
                value: new DateTime(2022, 8, 31, 4, 48, 14, 312, DateTimeKind.Local).AddTicks(6459));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaID",
                keyValue: 1151,
                column: "FechaCreacion",
                value: new DateTime(2022, 8, 31, 4, 37, 43, 260, DateTimeKind.Local).AddTicks(6728));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaID",
                keyValue: 2252,
                column: "FechaCreacion",
                value: new DateTime(2022, 8, 31, 4, 37, 43, 260, DateTimeKind.Local).AddTicks(6741));
        }
    }
}
