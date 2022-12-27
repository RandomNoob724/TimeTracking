using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTracking.Data.Migrations
{
    public partial class AddedTimesheetmodel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimeSheet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    WeekNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSheet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeSheetRow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    TimeSheetId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSheetRow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSheetRow_TimeSheet_TimeSheetId",
                        column: x => x.TimeSheetId,
                        principalTable: "TimeSheet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheetRow_TimeSheetId",
                table: "TimeSheetRow",
                column: "TimeSheetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeSheetRow");

            migrationBuilder.DropTable(
                name: "TimeSheet");
        }
    }
}
