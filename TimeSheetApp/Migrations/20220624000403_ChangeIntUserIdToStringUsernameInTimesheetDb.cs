using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheetApp.Migrations
{
    public partial class ChangeIntUserIdToStringUsernameInTimesheetDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClockInClockOut_TimeSheet_UserId",
                table: "ClockInClockOut");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TimeSheet");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ClockInClockOut",
                newName: "SheetId");

            migrationBuilder.RenameIndex(
                name: "IX_ClockInClockOut_UserId",
                table: "ClockInClockOut",
                newName: "IX_ClockInClockOut_SheetId");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "TimeSheet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClockInClockOut_TimeSheet_SheetId",
                table: "ClockInClockOut",
                column: "SheetId",
                principalTable: "TimeSheet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClockInClockOut_TimeSheet_SheetId",
                table: "ClockInClockOut");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "TimeSheet");

            migrationBuilder.RenameColumn(
                name: "SheetId",
                table: "ClockInClockOut",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ClockInClockOut_SheetId",
                table: "ClockInClockOut",
                newName: "IX_ClockInClockOut_UserId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TimeSheet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ClockInClockOut_TimeSheet_UserId",
                table: "ClockInClockOut",
                column: "UserId",
                principalTable: "TimeSheet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
