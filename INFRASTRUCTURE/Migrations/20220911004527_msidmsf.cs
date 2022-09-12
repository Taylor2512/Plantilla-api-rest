using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFRASTRUCTURE.Migrations
{
    public partial class msidmsf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_ImagenesProducto_tbl_producto_Id_procuto",
                table: "tbl_ImagenesProducto");

            migrationBuilder.AlterColumn<string>(
                name: "RouteFile",
                table: "tbl_ImagenesProducto",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id_procuto",
                table: "tbl_ImagenesProducto",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_ImagenesProducto_tbl_producto_Id_procuto",
                table: "tbl_ImagenesProducto",
                column: "Id_procuto",
                principalTable: "tbl_producto",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_ImagenesProducto_tbl_producto_Id_procuto",
                table: "tbl_ImagenesProducto");

            migrationBuilder.AlterColumn<string>(
                name: "RouteFile",
                table: "tbl_ImagenesProducto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id_procuto",
                table: "tbl_ImagenesProducto",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_ImagenesProducto_tbl_producto_Id_procuto",
                table: "tbl_ImagenesProducto",
                column: "Id_procuto",
                principalTable: "tbl_producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
