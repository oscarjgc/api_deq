using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LCDEQ.Migrations
{
    /// <inheritdoc />
    public partial class seagregancolumnasdeobstruccionesatabladecheklist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /**migrationBuilder.AddColumn<DateTime>(
                name: "FechaFabricacion",
                table: "Extintores",
                type: "timestamp without time zone",
                nullable: true);**/

            migrationBuilder.AddColumn<bool>(
                name: "Obstrucciones",
                table: "CLH",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Obstrucciones",
                table: "CLEA",
                type: "boolean",
                nullable: false,
                defaultValue: false);

           /** migrationBuilder.AddColumn<DateTime>(
                name: "FechaServicio",
                table: "CLE",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)); **/

           /** migrationBuilder.AddColumn<bool>(
                name: "Obstrucciones",
                table: "CLE",
                type: "boolean",
                nullable: false,
                defaultValue: false); **/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          /**  migrationBuilder.DropColumn(
                name: "FechaFabricacion",
                table: "Extintores"); **/

            migrationBuilder.DropColumn(
                name: "Obstrucciones",
                table: "CLH");

            migrationBuilder.DropColumn(
                name: "Obstrucciones",
                table: "CLEA");

          /**  migrationBuilder.DropColumn(
                name: "FechaServicio",
                table: "CLE"); **/

          /**  migrationBuilder.DropColumn(
                name: "Obstrucciones",
                table: "CLE"); **/
        }
    }
}
