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
                name: "Admin",
                columns: table => new
                {
                    AdminId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Pagina",
                columns: table => new
                {
                    PaginaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagina", x => x.PaginaId);
                });

            migrationBuilder.CreateTable(
                name: "Park",
                columns: table => new
                {
                    Naam = table.Column<string>(nullable: false),
                    Openingsdag = table.Column<DateTime>(nullable: false),
                    Sluitingsdag = table.Column<DateTime>(nullable: false),
                    OpeningstijdMaandag = table.Column<DateTime>(nullable: false),
                    SluitingstijdMaandag = table.Column<DateTime>(nullable: false),
                    OpeningstijdDinsdag = table.Column<DateTime>(nullable: false),
                    SluitingstijdDinsdag = table.Column<DateTime>(nullable: false),
                    OpeningstijdWoensdag = table.Column<DateTime>(nullable: false),
                    SluitingstijdWoensdag = table.Column<DateTime>(nullable: false),
                    OpeningstijdDonderdag = table.Column<DateTime>(nullable: false),
                    SluitingstijdDonderdag = table.Column<DateTime>(nullable: false),
                    OpeningstijdVrijdag = table.Column<DateTime>(nullable: false),
                    SluitingstijdVrijdag = table.Column<DateTime>(nullable: false),
                    OpeningstijdZaterdag = table.Column<DateTime>(nullable: false),
                    SluitingstijdZaterdag = table.Column<DateTime>(nullable: false),
                    OpeningstijdZondag = table.Column<DateTime>(nullable: false),
                    SluitingstijdZondag = table.Column<DateTime>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    ContentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(nullable: false),
                    Tekst = table.Column<string>(nullable: true),
                    PaginaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.ContentId);
                    table.ForeignKey(
                        name: "FK_Content_Pagina_PaginaId",
                        column: x => x.PaginaId,
                        principalTable: "Pagina",
                        principalColumn: "PaginaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Content_PaginaId",
                table: "Content",
                column: "PaginaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropTable(
                name: "Park");

            migrationBuilder.DropTable(
                name: "QenA");

            migrationBuilder.DropTable(
                name: "Pagina");
        }
    }
}
