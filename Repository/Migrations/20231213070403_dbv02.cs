using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class dbv02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_IdCategory",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Origin_IdOrigin",
                table: "Product");

            migrationBuilder.AlterColumn<string>(
                name: "IdOrigin",
                table: "Product",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "IdCategory",
                table: "Product",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDay",
                table: "Product",
                type: "datetime",
                nullable: false,
                defaultValue: DateTime.UtcNow);

            migrationBuilder.AddColumn<int>(
                name: "SoldQuantity",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_IdCategory",
                table: "Product",
                column: "IdCategory",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Origin_IdOrigin",
                table: "Product",
                column: "IdOrigin",
                principalTable: "Origin",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_IdCategory",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Origin_IdOrigin",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CreateDay",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SoldQuantity",
                table: "Product");

            migrationBuilder.AlterColumn<string>(
                name: "IdOrigin",
                table: "Product",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdCategory",
                table: "Product",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_IdCategory",
                table: "Product",
                column: "IdCategory",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Origin_IdOrigin",
                table: "Product",
                column: "IdOrigin",
                principalTable: "Origin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
