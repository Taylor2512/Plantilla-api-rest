using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFRASTRUCTURE.Migrations
{
    public partial class _35 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "tbl_usuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_usuario",
                table: "tbl_usuario",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "tbl_ImagenesPersona",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RouteFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ImagenesPersona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_ImagenesPersona_tbl_usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "tbl_usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_producto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameProduct = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_producto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ImagenesProducto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_procuto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RouteFile = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ImagenesProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_ImagenesProducto_tbl_producto_Id_procuto",
                        column: x => x.Id_procuto,
                        principalTable: "tbl_producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ImagenesPersona_IdUsuario",
                table: "tbl_ImagenesPersona",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ImagenesProducto_Id_procuto",
                table: "tbl_ImagenesProducto",
                column: "Id_procuto");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_tbl_usuario_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "tbl_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_tbl_usuario_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "tbl_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_tbl_usuario_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "tbl_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_tbl_usuario_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "tbl_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_tbl_usuario_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_tbl_usuario_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_tbl_usuario_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_tbl_usuario_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "tbl_ImagenesPersona");

            migrationBuilder.DropTable(
                name: "tbl_ImagenesProducto");

            migrationBuilder.DropTable(
                name: "tbl_producto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_usuario",
                table: "tbl_usuario");

            migrationBuilder.RenameTable(
                name: "tbl_usuario",
                newName: "AspNetUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
