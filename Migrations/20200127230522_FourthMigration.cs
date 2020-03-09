using Microsoft.EntityFrameworkCore.Migrations;

namespace Truber_Project.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trubers_Drivers_DriverId",
                table: "Trubers");

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "Trubers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Trubers_Drivers_DriverId",
                table: "Trubers",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "DriverId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trubers_Drivers_DriverId",
                table: "Trubers");

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "Trubers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trubers_Drivers_DriverId",
                table: "Trubers",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "DriverId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
