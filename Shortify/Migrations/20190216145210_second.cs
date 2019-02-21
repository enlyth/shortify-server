using Microsoft.EntityFrameworkCore.Migrations;

namespace Shortify.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "shortURL",
                table: "URLs",
                newName: "ShortURL");

            migrationBuilder.RenameColumn(
                name: "longURL",
                table: "URLs",
                newName: "LongURL");

            migrationBuilder.RenameColumn(
                name: "identifier",
                table: "URLs",
                newName: "Identifier");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "URLs",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "URLs",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShortURL",
                table: "URLs",
                newName: "shortURL");

            migrationBuilder.RenameColumn(
                name: "LongURL",
                table: "URLs",
                newName: "longURL");

            migrationBuilder.RenameColumn(
                name: "Identifier",
                table: "URLs",
                newName: "identifier");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "URLs",
                newName: "created");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "URLs",
                newName: "id");
        }
    }
}
