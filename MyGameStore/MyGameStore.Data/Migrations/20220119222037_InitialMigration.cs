using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGameStore.Data.Migrations
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
                    { 1, null, "Port Lauriane", true, "Milton", "77", "Sam Mews", "2698" },
                    { 18, null, "Gusikowskiville", false, "Alfonso", "61", "Leannon Plains", "2816" },
                    { 17, null, "Einoshire", false, "Adela", "51", "Ullrich Burg", "1730" },
                    { 16, null, "New Germanburgh", false, "Easter", "85", "Crooks Mill", "2331" },
                    { 15, null, "New Kenyaberg", true, "Enid", "17", "Fletcher Street", "2443" },
                    { 14, null, "Lake Elnahaven", false, "Antonio", "96", "Orn Forest", "59" },
                    { 13, null, "Kylieland", false, "Kip", "13", "Hirthe Meadow", "1164" },
                    { 12, null, "North Zena", true, "Kathryne", "5", "Breitenberg Road", "336" },
                    { 11, null, "Pagacton", true, "Myrtie", "94", "Witting Lights", "2624" },
                    { 10, null, "Hamillshire", false, "Valentine", "97", "Ritchie Light", "701" },
                    { 9, null, "Reneeshire", true, "Ashtyn", "19", "Ward Vista", "1611" },
                    { 8, null, "North Robbieburgh", false, "Darlene", "84", "Kulas Roads", "228" },
                    { 7, null, "New Llewellyn", true, "Chyna", "82", "Gregory Fork", "442" },
                    { 6, null, "Port Milanstad", false, "Will", "84", "Mireille Park", "2309" },
                    { 5, null, "South Rickeyborough", false, "Jaylon", "7", "Kohler Junction", "1334" },
                    { 4, null, "South Raystad", true, "Tavares", "33", "Lowe Skyway", "610" },
                    { 3, null, "West Cortneymouth", true, "Tony", "49", "Dooley Drives", "2510" },
                    { 2, null, "New Amiya", false, "Raoul", "93", "Zemlak Harbor", "1468" },
                    { 19, null, "Beckerview", true, "Kiarra", "45", "Hauck Crossing", "2709" },
                    { 20, null, "Lake Colt", true, "Jovan", "96", "Amelie Hill", "2357" }
                });

            migrationBuilder.InsertData(
                schema: "Person",
                table: "tblPeople",
                columns: new[] { "Id", "EmailAddress", "FirstName", "Gender", "LastName", "StoreId" },
                values: new object[,]
                {
                    { 1, "bettye@kubreichel.us", "Lucinda", 1, "Gorczany", 2 },
                    { 2, "miguel@tremblay.ca", "Emily", 1, "Koelpin", 2 },
                    { 3, "izabella@bergnaum.biz", "Dustin", 1, "Krajcik", 2 },
                    { 4, "nicolas_kub@yundtbernier.com", "Keon", 1, "Blick", 2 },
                    { 5, "everett_wisozk@wisoky.name", "Major", 1, "Murphy", 2 },
                    { 6, "quentin.senger@abbott.com", "Elisa", 1, "Boehm", 2 },
                    { 7, "gudrun@abshire.name", "Karlee", 1, "Becker", 2 },
                    { 8, "darrick@bergealtenwerth.co.uk", "Faustino", 1, "Funk", 2 },
                    { 9, "johan_swift@crooks.name", "Dolores", 1, "Kirlin", 2 },
                    { 10, "felix_tillman@rippin.us", "Kyleigh", 1, "Gottlieb", 2 }
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
