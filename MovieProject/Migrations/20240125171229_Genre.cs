using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieProject.Migrations
{
    /// <inheritdoc />
    public partial class Genre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GenreModelId",
                table: "Movies",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreModelId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreModelId);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreModelId", "Name" },
                values: new object[,]
                {
                    { "A", "Action" },
                    { "C", "Comedy" },
                    { "D", "Drama" },
                    { "H", "Horror" },
                    { "M", "Musical" },
                    { "R", "RomCom" },
                    { "S", "SciFi" }
                });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieModelId",
                keyValue: 1,
                column: "GenreModelId",
                value: "D");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieModelId",
                keyValue: 2,
                column: "GenreModelId",
                value: "A");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieModelId",
                keyValue: 3,
                column: "GenreModelId",
                value: "D");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreModelId",
                table: "Movies",
                column: "GenreModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_GenreModelId",
                table: "Movies",
                column: "GenreModelId",
                principalTable: "Genres",
                principalColumn: "GenreModelId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_GenreModelId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GenreModelId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "GenreModelId",
                table: "Movies");
        }
    }
}
