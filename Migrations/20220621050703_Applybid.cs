using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_AuctionProject.Migrations
{
    public partial class Applybid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplyBids",
                columns: table => new
                {
                    BidNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerName = table.Column<int>(type: "int", nullable: false),
                    B_Product = table.Column<int>(type: "int", nullable: false),
                    B_Details = table.Column<int>(type: "int", nullable: false),
                    Owner = table.Column<int>(type: "int", nullable: false),
                    BidAmount = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplyBids", x => x.BidNo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplyBids");
        }
    }
}
