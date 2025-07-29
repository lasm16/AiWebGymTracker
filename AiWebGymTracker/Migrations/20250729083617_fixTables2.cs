using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AiWebGymTracker.Migrations
{
    /// <inheritdoc />
    public partial class fixTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "column",
                table: "trainings",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "column",
                table: "foods",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "column",
                table: "exercise",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "column",
                table: "dishes",
                newName: "id");

            migrationBuilder.CreateTable(
                name: "nutritions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    dish_id = table.Column<int>(type: "integer", nullable: false),
                    nutrition_type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nutritions", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nutritions");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "trainings",
                newName: "column");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "foods",
                newName: "column");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "exercise",
                newName: "column");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "dishes",
                newName: "column");
        }
    }
}
