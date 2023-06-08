using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipesAPI.Migrations
{
    public partial class m4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Ingridient");

            migrationBuilder.CreateTable(
                name: "DishIngridient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    IngridientId = table.Column<int>(type: "int", nullable: true),
                    DishId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishIngridient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DishIngridient_Dish_DishId",
                        column: x => x.DishId,
                        principalTable: "Dish",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DishIngridient_Ingridient_IngridientId",
                        column: x => x.IngridientId,
                        principalTable: "Ingridient",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DishIngridient_DishId",
                table: "DishIngridient",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_DishIngridient_IngridientId",
                table: "DishIngridient",
                column: "IngridientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishIngridient");

            migrationBuilder.AddColumn<int>(
                name: "DishId",
                table: "Ingridient",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Quantity",
                table: "Ingridient",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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
    }
}
