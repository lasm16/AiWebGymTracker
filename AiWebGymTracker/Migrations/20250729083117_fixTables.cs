using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AiWebGymTracker.Migrations
{
    /// <inheritdoc />
    public partial class fixTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dishes_nutritions_NutritionId",
                table: "dishes");

            migrationBuilder.DropTable(
                name: "nutritions");

            migrationBuilder.DropIndex(
                name: "IX_dishes_NutritionId",
                table: "dishes");

            migrationBuilder.DropColumn(
                name: "NutritionId",
                table: "dishes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NutritionId",
                table: "dishes",
                type: "integer",
                nullable: true);

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
    }
}
