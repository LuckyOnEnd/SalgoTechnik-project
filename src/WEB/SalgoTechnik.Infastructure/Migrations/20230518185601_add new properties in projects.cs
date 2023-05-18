using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalgoTechnik.Infastructure.Migrations
{
    public partial class addnewpropertiesinprojects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LegalRelationship",
                table: "Projects",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProjectLanguage",
                table: "Projects",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProjectLocation",
                table: "Projects",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProjectType",
                table: "Projects",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LegalRelationship",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectLanguage",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectLocation",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectType",
                table: "Projects");
        }
    }
}
