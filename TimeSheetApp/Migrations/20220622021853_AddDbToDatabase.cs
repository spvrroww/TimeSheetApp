using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheetApp.Migrations
{
    public partial class AddDbToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimeSheet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ElapsedTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSheet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClockInClockOutTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClockInTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClockOutTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClockInClockOutTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClockInClockOutTime_TimeSheet_UserId",
                        column: x => x.UserId,
                        principalTable: "TimeSheet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClockInClockOutTime_UserId",
                table: "ClockInClockOutTime",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClockInClockOutTime");

            migrationBuilder.DropTable(
                name: "TimeSheet");
        }
    }
}
