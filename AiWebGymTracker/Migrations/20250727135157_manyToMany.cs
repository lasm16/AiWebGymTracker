using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AiWebGymTracker.Migrations
{
    /// <inheritdoc />
    public partial class manyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_foods_dishes_DishId",
                table: "foods");

            migrationBuilder.DropIndex(
                name: "IX_foods_DishId",
                table: "foods");

            migrationBuilder.DropColumn(
                name: "DishId",
                table: "foods");

            migrationBuilder.AddColumn<int>(
                name: "NutritionId",
                table: "dishes",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "dishfood",
                columns: table => new
                {
                    DishesId = table.Column<int>(type: "integer", nullable: false),
                    FoodsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dishfood", x => new { x.DishesId, x.FoodsId });
                    table.ForeignKey(
                        name: "FK_dishfood_dishes_DishesId",
                        column: x => x.DishesId,
                        principalTable: "dishes",
                        principalColumn: "column",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dishfood_foods_FoodsId",
                        column: x => x.FoodsId,
                        principalTable: "foods",
                        principalColumn: "column",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nutritions",
                columns: table => new
                {
                    column = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    nutrition_type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nutritions", x => x.column);
                    table.ForeignKey(
                        name: "FK_nutritions_aspnetusers_user_id",
                        column: x => x.user_id,
                        principalTable: "aspnetusers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dishes_NutritionId",
                table: "dishes",
                column: "NutritionId");

            migrationBuilder.CreateIndex(
                name: "IX_dishfood_FoodsId",
                table: "dishfood",
                column: "FoodsId");

            migrationBuilder.CreateIndex(
                name: "IX_nutritions_user_id",
                table: "nutritions",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_dishes_nutritions_NutritionId",
                table: "dishes",
                column: "NutritionId",
                principalTable: "nutritions",
                principalColumn: "column");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dishes_nutritions_NutritionId",
                table: "dishes");

            migrationBuilder.DropTable(
                name: "dishfood");

            migrationBuilder.DropTable(
                name: "nutritions");

            migrationBuilder.DropIndex(
                name: "IX_dishes_NutritionId",
                table: "dishes");

            migrationBuilder.DropColumn(
                name: "NutritionId",
                table: "dishes");

            migrationBuilder.AddColumn<int>(
                name: "DishId",
                table: "foods",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_foods_DishId",
                table: "foods",
                column: "DishId");

            migrationBuilder.AddForeignKey(
                name: "FK_foods_dishes_DishId",
                table: "foods",
                column: "DishId",
                principalTable: "dishes",
                principalColumn: "column");
        }
    }
}
