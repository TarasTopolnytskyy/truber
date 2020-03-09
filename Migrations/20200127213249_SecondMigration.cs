using Microsoft.EntityFrameworkCore.Migrations;

namespace Truber_Project.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalAmoutOfMiles",
                table: "Trubers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmoutOfMiles",
                table: "Trubers");
        }
    }
}
