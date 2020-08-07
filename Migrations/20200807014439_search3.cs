using Microsoft.EntityFrameworkCore.Migrations;

namespace SearchFill.Migrations
{
    public partial class search3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "SportItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "SportItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
