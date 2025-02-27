using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LCDEQ.Migrations
{
    /// <inheritdoc />
    public partial class _270220251 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Usuario",
                type: "integer",
                nullable: false,
                defaultValueSql: "1");

            migrationBuilder.AddColumn<int>(
                name: "IdPerfil",
                table: "Usuario",
                type: "integer",
                nullable: false,
                defaultValueSql: "1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "IdPerfil",
                table: "Usuario");

        }
    }
}
