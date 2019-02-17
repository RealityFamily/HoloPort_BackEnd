using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IpResolver.Migrations
{
    public partial class life : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LifeTime",
                table: "Clients",
                nullable: false,
                oldClrType: typeof(TimeSpan));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "LifeTime",
                table: "Clients",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
