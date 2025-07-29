using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AiWebGymTracker.Migrations
{
    /// <inheritdoc />
    public partial class entities_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dishes_nutritions_NutritionId",
                table: "dishes");

            migrationBuilder.DropTable(
                name: "foods");

            migrationBuilder.DropTable(
                name: "nutritions");

            migrationBuilder.DropTable(
                name: "trainings");

            migrationBuilder.DropIndex(
                name: "IX_dishes_NutritionId",
                table: "dishes");

            migrationBuilder.DropColumn(
                name: "NutritionId",
                table: "dishes");

            migrationBuilder.RenameColumn(
                name: "column",
                table: "dishes",
                newName: "id");

            migrationBuilder.CreateTable(
                name: "food",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    calories = table.Column<double>(type: "double precision", nullable: false),
                    protein = table.Column<double>(type: "double precision", nullable: false),
                    fat = table.Column<double>(type: "double precision", nullable: false),
                    carbohydrates = table.Column<double>(type: "double precision", nullable: false),
                    food_category = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: false),
                    DishId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_food", x => x.id);
                    table.ForeignKey(
                        name: "FK_food_dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "dishes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_food_DishId",
                table: "food",
                column: "DishId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "food");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "dishes",
                newName: "column");

            migrationBuilder.AddColumn<int>(
                name: "NutritionId",
                table: "dishes",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "foods",
                columns: table => new
                {
                    column = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    calories = table.Column<double>(type: "double precision", nullable: false),
                    carbohydrates = table.Column<double>(type: "double precision", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    DishId = table.Column<int>(type: "integer", nullable: true),
                    fat = table.Column<double>(type: "double precision", nullable: false),
                    food_category = table.Column<int>(type: "integer", nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    protein = table.Column<double>(type: "double precision", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_foods", x => x.column);
                    table.ForeignKey(
                        name: "FK_foods_dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "dishes",
                        principalColumn: "column");
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

            migrationBuilder.CreateTable(
                name: "trainings",
                columns: table => new
                {
                    column = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    coach_id = table.Column<int>(type: "integer", nullable: false),
                    trainee_id = table.Column<int>(type: "integer", nullable: false),
                    end_training = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    start_training = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainings", x => x.column);
                    table.ForeignKey(
                        name: "FK_trainings_aspnetusers_coach_id",
                        column: x => x.coach_id,
                        principalTable: "aspnetusers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trainings_aspnetusers_trainee_id",
                        column: x => x.trainee_id,
                        principalTable: "aspnetusers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dishes_NutritionId",
                table: "dishes",
                column: "NutritionId");

            migrationBuilder.CreateIndex(
                name: "IX_foods_DishId",
                table: "foods",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_nutritions_user_id",
                table: "nutritions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_trainings_coach_id",
                table: "trainings",
                column: "coach_id");

            migrationBuilder.CreateIndex(
                name: "IX_trainings_trainee_id",
                table: "trainings",
                column: "trainee_id");

            migrationBuilder.AddForeignKey(
                name: "FK_dishes_nutritions_NutritionId",
                table: "dishes",
                column: "NutritionId",
                principalTable: "nutritions",
                principalColumn: "column");
        }
    }
}
