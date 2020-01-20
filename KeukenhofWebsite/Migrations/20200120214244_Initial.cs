using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KeukenhofWebsite.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Action",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PagAction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Action", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zoekterm",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ZoektermString = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zoekterm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZoektermAction",
                columns: table => new
                {
                    ZoektermId = table.Column<int>(nullable: false),
                    ActionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZoektermAction", x => new { x.ZoektermId, x.ActionId });
                    table.ForeignKey(
                        name: "FK_ZoektermAction_Action_ActionId",
                        column: x => x.ActionId,
                        principalTable: "Action",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZoektermAction_Zoekterm_ZoektermId",
                        column: x => x.ZoektermId,
                        principalTable: "Zoekterm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZoektermAction_ActionId",
                table: "ZoektermAction",
                column: "ActionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZoektermAction");

            migrationBuilder.DropTable(
                name: "Action");

            migrationBuilder.DropTable(
                name: "Zoekterm");
        }
    }
}
