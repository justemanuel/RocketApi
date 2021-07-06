using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RocketApi.Web.Migrations
{
    public partial class Defaultvalueonstatuscreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Status",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 6, 21, 42, 14, 869, DateTimeKind.Utc).AddTicks(6571));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Status");
        }
    }
}
