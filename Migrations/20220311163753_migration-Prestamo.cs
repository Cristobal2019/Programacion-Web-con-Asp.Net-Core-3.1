using Microsoft.EntityFrameworkCore.Migrations;

namespace CristobalCruz.Migrations
{
    public partial class migrationPrestamo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prestamo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    Monto = table.Column<int>(nullable: false),
                    Interes = table.Column<int>(nullable: false),
                    Cuota = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prestamo");
        }
    }
}
