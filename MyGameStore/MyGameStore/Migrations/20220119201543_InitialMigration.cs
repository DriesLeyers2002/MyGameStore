using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGameStore.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Person");

            migrationBuilder.EnsureSchema(
                name: "Store");

            migrationBuilder.CreateTable(
                name: "tblStores",
                schema: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Addition = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Zipcode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Place = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    IsFranchiseStore = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblPeople",
                schema: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPeople", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblPeople_tblStores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "Store",
                        principalTable: "tblStores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Store",
                table: "tblStores",
                columns: new[] { "Id", "Addition", "Place", "IsFranchiseStore", "Name", "Number", "Street", "Zipcode" },
                values: new object[,]
                {
                    { 1, null, "Haleighshire", true, "Kadin", "64", "Frami Harbor", "1434" },
                    { 18, null, "West Denis", false, "Rhea", "98", "Celestino Pass", "2533" },
                    { 17, null, "North Melissa", false, "Geraldine", "55", "Sheldon Courts", "2853" },
                    { 16, null, "New Lourdes", true, "Norma", "34", "Tad Circle", "997" },
                    { 15, null, "West Rigobertomouth", true, "Billie", "85", "Lemke Trail", "1816" },
                    { 14, null, "Batzview", true, "Monserrat", "60", "Isaiah Dale", "742" },
                    { 13, null, "Eudorashire", true, "German", "17", "Ernser Fork", "2239" },
                    { 12, null, "Zolaborough", true, "Vincenza", "62", "Carter Stream", "766" },
                    { 11, null, "Williamsonland", true, "Edgar", "99", "Ahmad Glen", "535" },
                    { 10, null, "West Price", false, "Valentin", "12", "Alena Meadows", "116" },
                    { 9, null, "Stammbury", true, "Kristina", "26", "Cleo Burg", "183" },
                    { 8, null, "East Monroehaven", true, "Morris", "38", "Barbara Ridge", "1125" },
                    { 7, null, "Milofort", true, "Alisha", "6", "Schulist Cove", "797" },
                    { 6, null, "New Blancaside", true, "Sophia", "17", "Terry Mountains", "1352" },
                    { 5, null, "Jadeburgh", true, "Jamey", "9", "Katarina Mill", "1458" },
                    { 4, null, "New Laurenville", true, "Zoila", "72", "Fahey Falls", "2507" },
                    { 3, null, "Frederikville", true, "Kenny", "10", "Hessel Walks", "2944" },
                    { 2, null, "Gregshire", true, "Creola", "3", "Nikolaus Pike", "1007" },
                    { 19, null, "Predovicshire", true, "Amber", "90", "Collins Corners", "853" },
                    { 20, null, "Ebertburgh", false, "Elwyn", "99", "Mueller Row", "248" }
                });

            migrationBuilder.InsertData(
                schema: "Person",
                table: "tblPeople",
                columns: new[] { "Id", "EmailAddress", "FirstName", "Gender", "LastName", "StoreId" },
                values: new object[,]
                {
                    { 1, "liam_farrell@erdmananderson.info", "Sadie", 1, "Ruecker", 2 },
                    { 2, "myrtis@wunsch.ca", "Magnus", 1, "Ziemann", 2 },
                    { 3, "abe@kozey.ca", "Felicity", 1, "Wilderman", 2 },
                    { 4, "reinhold.lang@binskuphal.us", "Raul", 1, "McGlynn", 2 },
                    { 5, "elijah@hyatt.ca", "Dominic", 1, "Hirthe", 2 },
                    { 6, "lauriane.hegmann@strosinritchie.ca", "Tate", 1, "Rath", 2 },
                    { 7, "amya@stroman.co.uk", "Genoveva", 1, "Harvey", 2 },
                    { 8, "cordell.rempel@willmshessel.com", "Trinity", 1, "Ryan", 2 },
                    { 9, "hillard@homenick.us", "Kenna", 1, "Kreiger", 2 },
                    { 10, "hubert.wisoky@jakubowski.name", "Andrew", 1, "Prosacco", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblPeople_StoreId",
                schema: "Person",
                table: "tblPeople",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblPeople",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "tblStores",
                schema: "Store");
        }
    }
}
