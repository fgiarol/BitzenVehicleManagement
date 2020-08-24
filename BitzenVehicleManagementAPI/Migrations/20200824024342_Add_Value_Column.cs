using Microsoft.EntityFrameworkCore.Migrations;

namespace BitzenVehicleManagementAPI.Migrations
{
    public partial class Add_Value_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "Fuelings",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Fuelings");
        }
    }
}
