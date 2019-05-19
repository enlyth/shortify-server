using Microsoft.EntityFrameworkCore.Migrations;

namespace Shortify.Migrations
{
    public partial class TimesAccessed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TimesAccessed",
                table: "URLs",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimesAccessed",
                table: "URLs");
        }
    }
}
