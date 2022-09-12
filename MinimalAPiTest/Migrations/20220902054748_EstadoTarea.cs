using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalAPiTest.Migrations
{
    public partial class EstadoTarea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cambio",
                table: "Categoria");

            migrationBuilder.DropColumn(
                name: "entero",
                table: "Categoria");

            migrationBuilder.AddColumn<int>(
                name: "EstadoTarea",
                table: "Tarea",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaID",
                keyValue: 1151,
                column: "FechaCreacion",
                value: new DateTime(2022, 9, 2, 2, 47, 48, 187, DateTimeKind.Local).AddTicks(3848));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaID",
                keyValue: 2252,
                column: "FechaCreacion",
                value: new DateTime(2022, 9, 2, 2, 47, 48, 187, DateTimeKind.Local).AddTicks(3858));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoTarea",
                table: "Tarea");

            migrationBuilder.AddColumn<string>(
                name: "cambio",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true);

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
                value: new DateTime(2022, 8, 31, 16, 54, 51, 765, DateTimeKind.Local).AddTicks(4544));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaID",
                keyValue: 2252,
                column: "FechaCreacion",
                value: new DateTime(2022, 8, 31, 16, 54, 51, 765, DateTimeKind.Local).AddTicks(4556));
        }
    }
}
