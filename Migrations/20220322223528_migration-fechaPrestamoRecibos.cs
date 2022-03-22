using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CristobalCruz.Migrations
{
    public partial class migrationfechaPrestamoRecibos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Recibo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Prestamo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Recibo");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Prestamo");
        }
    }
}
