using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheetApp.Migrations
{
    public partial class AddChangesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "TimeSheet");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TimeSheet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "ClockInClockOut",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TimeSheet");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "ClockInClockOut");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "TimeSheet",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
