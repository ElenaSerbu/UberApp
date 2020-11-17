using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth.Migrations
{
    public partial class stopre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TargetPrice",
                table: "UserWatchlist",
                newName: "StockPrice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StockPrice",
                table: "UserWatchlist",
                newName: "TargetPrice");
        }
    }
}
