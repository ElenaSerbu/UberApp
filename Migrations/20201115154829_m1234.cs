using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth.Migrations
{
    public partial class m1234 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "UserWatchlist",
                newName: "MarketOpen");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "UserWatchlist",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyRegion",
                table: "UserWatchlist",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MarketClose",
                table: "UserWatchlist",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TargetPrice",
                table: "UserWatchlist",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "UserWatchlist");

            migrationBuilder.DropColumn(
                name: "CompanyRegion",
                table: "UserWatchlist");

            migrationBuilder.DropColumn(
                name: "MarketClose",
                table: "UserWatchlist");

            migrationBuilder.DropColumn(
                name: "TargetPrice",
                table: "UserWatchlist");

            migrationBuilder.RenameColumn(
                name: "MarketOpen",
                table: "UserWatchlist",
                newName: "UserName");
        }
    }
}
