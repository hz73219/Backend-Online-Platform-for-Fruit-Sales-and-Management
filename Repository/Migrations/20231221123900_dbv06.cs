using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class dbv06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Voucher_IdVoucher",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_IdVoucher",
                table: "Order");

            migrationBuilder.AlterColumn<string>(
                name: "IdVoucher",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FinishDay",
                table: "Order",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdVoucher",
                table: "Order",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FinishDay",
                table: "Order",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdVoucher",
                table: "Order",
                column: "IdVoucher");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Voucher_IdVoucher",
                table: "Order",
                column: "IdVoucher",
                principalTable: "Voucher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
