using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shortify.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_URLs",
                table: "URLs");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "URLs");

            migrationBuilder.AlterColumn<string>(
                name: "Identifier",
                table: "URLs",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_URLs",
                table: "URLs",
                column: "Identifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_URLs",
                table: "URLs");

            migrationBuilder.AlterColumn<string>(
                name: "Identifier",
                table: "URLs",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "URLs",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_URLs",
                table: "URLs",
                column: "Id");
        }
    }
}
