using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IW7PP.Migrations
{
    /// <inheritdoc />
    public partial class ModificateColumnProstesisIdToAllowNulls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientesProtesicos_Prostheses_ProtesisId",
                table: "ClientesProtesicos");

            migrationBuilder.AlterColumn<int>(
                name: "ProtesisId",
                table: "ClientesProtesicos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            

            migrationBuilder.AddForeignKey(
                name: "FK_ClientesProtesicos_Prostheses_ProtesisId",
                table: "ClientesProtesicos",
                column: "ProtesisId",
                principalTable: "Prostheses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientesProtesicos_Prostheses_ProtesisId",
                table: "ClientesProtesicos");

            
            migrationBuilder.AlterColumn<int>(
                name: "ProtesisId",
                table: "ClientesProtesicos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientesProtesicos_Prostheses_ProtesisId",
                table: "ClientesProtesicos",
                column: "ProtesisId",
                principalTable: "Prostheses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
