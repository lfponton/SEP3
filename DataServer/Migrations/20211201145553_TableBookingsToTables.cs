using Microsoft.EntityFrameworkCore.Migrations;

namespace DataServer.Migrations
{
    public partial class TableBookingsToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBooked",
                table: "Tables");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBooked",
                table: "Tables",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
