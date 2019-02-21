using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shortify.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "URLs",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    longURL = table.Column<string>(nullable: true),
                    shortURL = table.Column<string>(nullable: true),
                    identifier = table.Column<string>(nullable: true),
                    created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_URLs", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "URLs");
        }
    }
}
