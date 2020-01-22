using Microsoft.EntityFrameworkCore.Migrations;

namespace KeukenhofWebsite.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "pagTitle",
                table: "Action",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pagTitle",
                table: "Action");
        }
    }
}
