using Microsoft.EntityFrameworkCore.Migrations;

namespace UberApp.Migrations
{
    public partial class m100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RatingScore",
                table: "Trip");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RatingScore",
                table: "Trip",
                nullable: false,
                defaultValue: 0);
        }
    }
}
