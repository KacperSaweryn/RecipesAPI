using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipesAPI.Migrations
{
    public partial class m5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "DishIngridient");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DishIngridient");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DishIngridient",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DishIngridient",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
