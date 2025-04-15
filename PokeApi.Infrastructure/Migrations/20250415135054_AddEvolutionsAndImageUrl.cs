using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEvolutionsAndImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EvolvesFromId",
                table: "Pokemons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EvolvesToId",
                table: "Pokemons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Pokemons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_EvolvesFromId",
                table: "Pokemons",
                column: "EvolvesFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_EvolvesToId",
                table: "Pokemons",
                column: "EvolvesToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_Pokemons_EvolvesFromId",
                table: "Pokemons",
                column: "EvolvesFromId",
                principalTable: "Pokemons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_Pokemons_EvolvesToId",
                table: "Pokemons",
                column: "EvolvesToId",
                principalTable: "Pokemons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_Pokemons_EvolvesFromId",
                table: "Pokemons");

            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_Pokemons_EvolvesToId",
                table: "Pokemons");

            migrationBuilder.DropIndex(
                name: "IX_Pokemons_EvolvesFromId",
                table: "Pokemons");

            migrationBuilder.DropIndex(
                name: "IX_Pokemons_EvolvesToId",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "EvolvesFromId",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "EvolvesToId",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Pokemons");
        }
    }
}
