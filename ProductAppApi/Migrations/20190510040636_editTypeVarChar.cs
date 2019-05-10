using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductAppApi.Migrations
{
    public partial class editTypeVarChar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PName",
                table: "products",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)");

            migrationBuilder.AlterColumn<string>(
                name: "ImgUrl",
                table: "products",
                type: "nvarchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "products",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar",
                oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PName",
                table: "products",
                type: "nvarchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "ImgUrl",
                table: "products",
                type: "nvarchar",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "products",
                type: "nvarchar",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");
        }
    }
}
