using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheetApp.Migrations
{
    public partial class AddClockInClockOutToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClockInClockOutTime_TimeSheet_UserId",
                table: "ClockInClockOutTime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClockInClockOutTime",
                table: "ClockInClockOutTime");

            migrationBuilder.RenameTable(
                name: "ClockInClockOutTime",
                newName: "ClockInClockOut");

            migrationBuilder.RenameIndex(
                name: "IX_ClockInClockOutTime_UserId",
                table: "ClockInClockOut",
                newName: "IX_ClockInClockOut_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClockInClockOut",
                table: "ClockInClockOut",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClockInClockOut_TimeSheet_UserId",
                table: "ClockInClockOut",
                column: "UserId",
                principalTable: "TimeSheet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClockInClockOut_TimeSheet_UserId",
                table: "ClockInClockOut");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClockInClockOut",
                table: "ClockInClockOut");

            migrationBuilder.RenameTable(
                name: "ClockInClockOut",
                newName: "ClockInClockOutTime");

            migrationBuilder.RenameIndex(
                name: "IX_ClockInClockOut_UserId",
                table: "ClockInClockOutTime",
                newName: "IX_ClockInClockOutTime_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClockInClockOutTime",
                table: "ClockInClockOutTime",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClockInClockOutTime_TimeSheet_UserId",
                table: "ClockInClockOutTime",
                column: "UserId",
                principalTable: "TimeSheet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
