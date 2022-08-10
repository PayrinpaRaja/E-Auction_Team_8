using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_AuctionProject.Migrations
{
    public partial class approval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Approval",
                table: "ApplyBids",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approval",
                table: "ApplyBids");
        }
    }
}
