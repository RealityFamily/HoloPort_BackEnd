using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IpResolver.Migrations
{
    public partial class time : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "LifeTime",
                table: "Clients",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LifeTime",
                table: "Clients");
        }
    }
}
