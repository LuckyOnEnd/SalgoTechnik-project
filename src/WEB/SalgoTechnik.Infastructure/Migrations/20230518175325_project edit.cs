using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalgoTechnik.Infastructure.Migrations
{
    public partial class projectedit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DateConverted",
                table: "Projects",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateConverted",
                table: "Projects");
        }
    }
}
