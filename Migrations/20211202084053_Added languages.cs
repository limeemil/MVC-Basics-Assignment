using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Basics__Assignment.Migrations
{
    public partial class Addedlanguages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonLanguages",
                columns: table => new
                {
                    PersonSSN = table.Column<string>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonLanguages", x => new { x.LanguageId, x.PersonSSN });
                    table.ForeignKey(
                        name: "FK_PersonLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonLanguages_People_PersonSSN",
                        column: x => x.PersonSSN,
                        principalTable: "People",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Svenska" },
                    { 2, "Norsk" },
                    { 3, "English" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "SSN", "CityId", "First name", "Last name", "Phonenumber" },
                values: new object[] { "9876543210", 4, "Martin", "Nielsen", "1111111111" });

            migrationBuilder.InsertData(
                table: "PersonLanguages",
                columns: new[] { "LanguageId", "PersonSSN" },
                values: new object[,]
                {
                    { 1, "0123456789" },
                    { 2, "9876543210" },
                    { 3, "0123456789" },
                    { 3, "9876543210" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonLanguages_PersonSSN",
                table: "PersonLanguages",
                column: "PersonSSN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonLanguages");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "SSN",
                keyValue: "9876543210");
        }
    }
}
