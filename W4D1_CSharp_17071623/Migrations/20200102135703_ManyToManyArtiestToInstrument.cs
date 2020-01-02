using Microsoft.EntityFrameworkCore.Migrations;

namespace W4D1_CSharp_17071623.Migrations
{
    public partial class ManyToManyArtiestToInstrument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artiest_Instrument_InstrumentId",
                table: "Artiest");

            migrationBuilder.DropIndex(
                name: "IX_Artiest_InstrumentId",
                table: "Artiest");

            migrationBuilder.CreateTable(
                name: "ArtiestInstrument",
                columns: table => new
                {
                    ArtiestId = table.Column<int>(nullable: false),
                    InstrumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtiestInstrument", x => new { x.ArtiestId, x.InstrumentId });
                    table.ForeignKey(
                        name: "FK_ArtiestInstrument_Artiest_ArtiestId",
                        column: x => x.ArtiestId,
                        principalTable: "Artiest",
                        principalColumn: "ArtiestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtiestInstrument_Instrument_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instrument",
                        principalColumn: "InstrumentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtiestInstrument_InstrumentId",
                table: "ArtiestInstrument",
                column: "InstrumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtiestInstrument");

            migrationBuilder.CreateIndex(
                name: "IX_Artiest_InstrumentId",
                table: "Artiest",
                column: "InstrumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artiest_Instrument_InstrumentId",
                table: "Artiest",
                column: "InstrumentId",
                principalTable: "Instrument",
                principalColumn: "InstrumentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
