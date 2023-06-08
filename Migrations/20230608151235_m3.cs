using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipesAPI.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishIngridient");

            migrationBuilder.AddColumn<int>(
                name: "DishId",
                table: "Ingridient",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingridient_DishId",
                table: "Ingridient",
                column: "DishId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingridient_Dish_DishId",
                table: "Ingridient",
                column: "DishId",
                principalTable: "Dish",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingridient_Dish_DishId",
                table: "Ingridient");

            migrationBuilder.DropIndex(
                name: "IX_Ingridient_DishId",
                table: "Ingridient");

            migrationBuilder.DropColumn(
                name: "DishId",
                table: "Ingridient");

            migrationBuilder.CreateTable(
                name: "DishIngridient",
                columns: table => new
                {
                    DishesId = table.Column<int>(type: "int", nullable: false),
                    IngridientsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishIngridient", x => new { x.DishesId, x.IngridientsId });
                    table.ForeignKey(
                        name: "FK_DishIngridient_Dish_DishesId",
                        column: x => x.DishesId,
                        principalTable: "Dish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishIngridient_Ingridient_IngridientsId",
                        column: x => x.IngridientsId,
                        principalTable: "Ingridient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DishIngridient_IngridientsId",
                table: "DishIngridient",
                column: "IngridientsId");
        }
    }
}
