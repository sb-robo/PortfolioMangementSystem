using Microsoft.EntityFrameworkCore.Migrations;

namespace DailyMutualFundNavMS.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyNavPriceDetails",
                columns: table => new
                {
                    MutualFundId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MutualFundName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Nav = table.Column<int>(type: "int", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyNavPriceDetails", x => x.MutualFundId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyNavPriceDetails");
        }
    }
}
