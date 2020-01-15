using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KeukenhofWebsite.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    ContentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tekst = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.ContentId);
                });

            migrationBuilder.CreateTable(
                name: "Park",
                columns: table => new
                {
                    Naam = table.Column<string>(nullable: false),
                    Openingsdag = table.Column<DateTime>(nullable: false),
                    Sluitingsdag = table.Column<DateTime>(nullable: false),
                    OpeningstijdenMaandag = table.Column<DateTime>(nullable: false),
                    OpeningstijdenDinsdag = table.Column<DateTime>(nullable: false),
                    OpeningstijdenWoensdag = table.Column<DateTime>(nullable: false),
                    OpeningstijdenDonderdag = table.Column<DateTime>(nullable: false),
                    OpeningstijdenVrijdag = table.Column<DateTime>(nullable: false),
                    OpeningstijdenZaterdag = table.Column<DateTime>(nullable: false),
                    OpeningstijdenZondag = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Park", x => x.Naam);
                });

            migrationBuilder.CreateTable(
                name: "QenA",
                columns: table => new
                {
                    AnswerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Question = table.Column<string>(nullable: true),
                    Answer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QenA", x => x.AnswerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropTable(
                name: "Park");

            migrationBuilder.DropTable(
                name: "QenA");
        }
    }
}
