using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cookie_stand_api.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CookieStands",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Minimum_Customers_PerHour = table.Column<int>(type: "int", nullable: false),
                    Maximum_Customers_PerHour = table.Column<int>(type: "int", nullable: false),
                    Average_Cookies_PerSale = table.Column<double>(type: "float", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookieStands", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HourlySales",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    CookieStandID = table.Column<int>(type: "int", nullable: false),
                    HourlySale = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourlySales", x => new { x.ID, x.CookieStandID });
                    table.ForeignKey(
                        name: "FK_HourlySales_CookieStands_CookieStandID",
                        column: x => x.CookieStandID,
                        principalTable: "CookieStands",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HourlySales_CookieStandID",
                table: "HourlySales",
                column: "CookieStandID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HourlySales");

            migrationBuilder.DropTable(
                name: "CookieStands");
        }
    }
}
