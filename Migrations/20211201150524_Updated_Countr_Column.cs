using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Basics__Assignment.Migrations
{
    public partial class Updated_Countr_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Cities",
                newName: "Country");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                newName: "IX_Cities_Country");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_Country",
                table: "Cities",
                column: "Country",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_Country",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Cities",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_Country",
                table: "Cities",
                newName: "IX_Cities_CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
