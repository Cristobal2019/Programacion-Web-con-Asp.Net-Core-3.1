using Microsoft.EntityFrameworkCore.Migrations;

namespace CristobalCruz.Migrations
{
    public partial class migrationDecimalCampo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Monto",
                table: "Prestamo",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Monto",
                table: "Prestamo",
                type: "float",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
