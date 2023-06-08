using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipesAPI.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Difficulty_DifficultyId",
                table: "Dish");

            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Ingridient_IngridientId",
                table: "Dish");

            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Tool_ToolId",
                table: "Dish");

            migrationBuilder.DropIndex(
                name: "IX_Dish_DifficultyId",
                table: "Dish");

            migrationBuilder.DropIndex(
                name: "IX_Dish_IngridientId",
                table: "Dish");

            migrationBuilder.DropIndex(
                name: "IX_Dish_ToolId",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "DifficultyId",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "IngridientId",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "ToolId",
                table: "Dish");

            migrationBuilder.CreateTable(
                name: "DifficultyDish",
                columns: table => new
                {
                    DifficultiesId = table.Column<int>(type: "int", nullable: false),
                    DishesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DifficultyDish", x => new { x.DifficultiesId, x.DishesId });
                    table.ForeignKey(
                        name: "FK_DifficultyDish_Difficulty_DifficultiesId",
                        column: x => x.DifficultiesId,
                        principalTable: "Difficulty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DifficultyDish_Dish_DishesId",
                        column: x => x.DishesId,
                        principalTable: "Dish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "DishTool",
                columns: table => new
                {
                    DishesId = table.Column<int>(type: "int", nullable: false),
                    ToolsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishTool", x => new { x.DishesId, x.ToolsId });
                    table.ForeignKey(
                        name: "FK_DishTool_Dish_DishesId",
                        column: x => x.DishesId,
                        principalTable: "Dish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishTool_Tool_ToolsId",
                        column: x => x.ToolsId,
                        principalTable: "Tool",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DifficultyDish_DishesId",
                table: "DifficultyDish",
                column: "DishesId");

            migrationBuilder.CreateIndex(
                name: "IX_DishIngridient_IngridientsId",
                table: "DishIngridient",
                column: "IngridientsId");

            migrationBuilder.CreateIndex(
                name: "IX_DishTool_ToolsId",
                table: "DishTool",
                column: "ToolsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DifficultyDish");

            migrationBuilder.DropTable(
                name: "DishIngridient");

            migrationBuilder.DropTable(
                name: "DishTool");

            migrationBuilder.AddColumn<int>(
                name: "DifficultyId",
                table: "Dish",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IngridientId",
                table: "Dish",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToolId",
                table: "Dish",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dish_DifficultyId",
                table: "Dish",
                column: "DifficultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Dish_IngridientId",
                table: "Dish",
                column: "IngridientId");

            migrationBuilder.CreateIndex(
                name: "IX_Dish_ToolId",
                table: "Dish",
                column: "ToolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Difficulty_DifficultyId",
                table: "Dish",
                column: "DifficultyId",
                principalTable: "Difficulty",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Ingridient_IngridientId",
                table: "Dish",
                column: "IngridientId",
                principalTable: "Ingridient",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Tool_ToolId",
                table: "Dish",
                column: "ToolId",
                principalTable: "Tool",
                principalColumn: "Id");
        }
    }
}
