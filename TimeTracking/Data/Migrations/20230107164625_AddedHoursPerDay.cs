using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTracking.Data.Migrations
{
    public partial class AddedHoursPerDay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "HoursPerday",
                table: "TimeSheetRow",
                type: "json",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoursPerday",
                table: "TimeSheetRow");
        }
    }
}
