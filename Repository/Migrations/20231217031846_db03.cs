using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class db03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsComplete",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "Order",
                newName: "Status");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDay",
                table: "Order",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDay",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Order",
                newName: "IsDelete");

            migrationBuilder.AddColumn<bool>(
                name: "IsComplete",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
