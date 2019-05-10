using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductAppApi.Migrations
{
    public partial class productEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "products",
                type: "float",
                nullable: false,
                oldClrType: typeof(float));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "products",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
