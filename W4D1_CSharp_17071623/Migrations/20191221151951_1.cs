using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace W4D1_CSharp_17071623.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instrument",
                columns: table => new
                {
                    InstrumentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InstrumentNaam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrument", x => x.InstrumentId);
                });

            migrationBuilder.CreateTable(
                name: "Popgroep",
                columns: table => new
                {
                    PopgroepId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PopgroepNaam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Popgroep", x => x.PopgroepId);
                });

            migrationBuilder.CreateTable(
                name: "Artiest",
                columns: table => new
                {
                    ArtiestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArtiestNaam = table.Column<string>(nullable: true),
                    InstrumentId = table.Column<int>(nullable: false),
                    PopgroepId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artiest", x => x.ArtiestId);
                    table.ForeignKey(
                        name: "FK_Artiest_Instrument_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instrument",
                        principalColumn: "InstrumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Artiest_Popgroep_PopgroepId",
                        column: x => x.PopgroepId,
                        principalTable: "Popgroep",
                        principalColumn: "PopgroepId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artiest_InstrumentId",
                table: "Artiest",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Artiest_PopgroepId",
                table: "Artiest",
                column: "PopgroepId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artiest");

            migrationBuilder.DropTable(
                name: "Instrument");

            migrationBuilder.DropTable(
                name: "Popgroep");
        }
    }
}
