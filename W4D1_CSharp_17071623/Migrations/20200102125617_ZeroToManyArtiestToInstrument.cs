using Microsoft.EntityFrameworkCore.Migrations;

namespace W4D1_CSharp_17071623.Migrations
{
    public partial class ZeroToManyArtiestToInstrument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artiest_Instrument_InstrumentId",
                table: "Artiest");

            migrationBuilder.AlterColumn<int>(
                name: "InstrumentId",
                table: "Artiest",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Artiest_Instrument_InstrumentId",
                table: "Artiest",
                column: "InstrumentId",
                principalTable: "Instrument",
                principalColumn: "InstrumentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artiest_Instrument_InstrumentId",
                table: "Artiest");

            migrationBuilder.AlterColumn<int>(
                name: "InstrumentId",
                table: "Artiest",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Artiest_Instrument_InstrumentId",
                table: "Artiest",
                column: "InstrumentId",
                principalTable: "Instrument",
                principalColumn: "InstrumentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
