using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_AuctionProject.Migrations
{
    public partial class Sno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AddProducts",
                table: "AddProducts");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AddProducts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Sno",
                table: "AddProducts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddProducts",
                table: "AddProducts",
                column: "Sno");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AddProducts",
                table: "AddProducts");

            migrationBuilder.DropColumn(
                name: "Sno",
                table: "AddProducts");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AddProducts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddProducts",
                table: "AddProducts",
                column: "Email");
        }
    }
}
