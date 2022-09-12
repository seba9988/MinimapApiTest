using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalAPiTest.Migrations
{
    public partial class campoTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "test",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "test",
                table: "Categoria");

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
    }
}
