using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalAPiTest.Migrations
{
    public partial class enteroYCambio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "test",
                table: "Categoria",
                newName: "cambio");

            migrationBuilder.AddColumn<int>(
                name: "entero",
                table: "Categoria",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaID",
                keyValue: 1151,
                column: "FechaCreacion",
                value: new DateTime(2022, 8, 31, 16, 51, 9, 543, DateTimeKind.Local).AddTicks(6079));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaID",
                keyValue: 2252,
                column: "FechaCreacion",
                value: new DateTime(2022, 8, 31, 16, 51, 9, 543, DateTimeKind.Local).AddTicks(6106));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "entero",
                table: "Categoria");

            migrationBuilder.RenameColumn(
                name: "cambio",
                table: "Categoria",
                newName: "test");

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
    }
}
