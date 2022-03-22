using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CristobalCruz.Migrations
{
    public partial class migrationFechaCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Recibo",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Customer",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Customer");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Recibo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });
        }
    }
}
