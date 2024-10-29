using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LCDEQ.Migrations
{
    /// <inheritdoc />
    public partial class secreabasededatosymodelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "SecuenciaCLE");

            migrationBuilder.CreateSequence(
                name: "SecuenciaCLEA");

            migrationBuilder.CreateSequence(
                name: "SecuenciaCLH");

            migrationBuilder.CreateSequence(
                name: "SecuenciaClientes");

            migrationBuilder.CreateSequence(
                name: "SecuenciaEA");

            migrationBuilder.CreateSequence(
                name: "SecuenciaExtintores");

            migrationBuilder.CreateSequence(
                name: "SecuenciaHidrante");

            migrationBuilder.CreateSequence(
                name: "SecuenciaTipoExtintor");

            migrationBuilder.CreateSequence(
                name: "SecuenciaUsuario");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"SecuenciaClientes\"')"),
                    Nombre = table.Column<string>(type: "character varying(100)", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    FechaHoraCaptura = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "TipoExtintores",
                columns: table => new
                {
                    IdTipoExtintor = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"SecuenciaTipoExtintor\"')"),
                    Descripcion = table.Column<string>(type: "character varying(100)", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    FechaHoraCaptura = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoExtintores", x => x.IdTipoExtintor);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"SecuenciaUsuario\"')"),
                    NombreUsuario = table.Column<string>(type: "character varying(100)", nullable: false),
                    Contrasenia = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    FechaHoraCaptura = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "EA",
                columns: table => new
                {
                    IdAutonomo = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"SecuenciaEA\"')"),
                    NumeroAutonomo = table.Column<string>(type: "character varying(100)", nullable: false),
                    IdCliente = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    FechaHoraCaptura = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EA", x => x.IdAutonomo);
                    table.ForeignKey(
                        name: "FK_EA_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hidrante",
                columns: table => new
                {
                    IdHidrante = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"SecuenciaHidrante\"')"),
                    NumeroHidrante = table.Column<string>(type: "character varying(100)", nullable: false),
                    IdCliente = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    FechaHoraCaptura = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hidrante", x => x.IdHidrante);
                    table.ForeignKey(
                        name: "FK_Hidrante_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Extintores",
                columns: table => new
                {
                    IdExtintor = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"SecuenciaExtintores\"')"),
                    NumeroDeExtintor = table.Column<string>(type: "character varying(100)", nullable: false),
                    IdCliente = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    FechaHoraCaptura = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    IdTipoExtintor = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extintores", x => x.IdExtintor);
                    table.ForeignKey(
                        name: "FK_Extintores_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Extintores_TipoExtintores_IdTipoExtintor",
                        column: x => x.IdTipoExtintor,
                        principalTable: "TipoExtintores",
                        principalColumn: "IdTipoExtintor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CLEA",
                columns: table => new
                {
                    IdCLEA = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"SecuenciaCLEA\"')"),
                    Presion = table.Column<string>(type: "character varying(150)", nullable: false),
                    Observaciones = table.Column<string>(type: "text", nullable: false),
                    FechaHoraCaptura = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    IdUsuario = table.Column<int>(type: "integer", nullable: false),
                    IdAutonomo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLEA", x => x.IdCLEA);
                    table.ForeignKey(
                        name: "FK_CLEA_EA_IdAutonomo",
                        column: x => x.IdAutonomo,
                        principalTable: "EA",
                        principalColumn: "IdAutonomo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CLEA_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CLH",
                columns: table => new
                {
                    IdCLH = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"SecuenciaCLH\"')"),
                    NumeroHidrante = table.Column<bool>(type: "boolean", nullable: false),
                    Boquilla = table.Column<bool>(type: "boolean", nullable: false),
                    Funda = table.Column<bool>(type: "boolean", nullable: false),
                    FechaHoraCaptura = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    IdUsuario = table.Column<int>(type: "integer", nullable: false),
                    IdHidrante = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLH", x => x.IdCLH);
                    table.ForeignKey(
                        name: "FK_CLH_Hidrante_IdHidrante",
                        column: x => x.IdHidrante,
                        principalTable: "Hidrante",
                        principalColumn: "IdHidrante",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CLH_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CLE",
                columns: table => new
                {
                    IdCLE = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"SecuenciaCLE\"')"),
                    IdExtintor = table.Column<int>(type: "integer", nullable: false),
                    Letrero = table.Column<bool>(type: "boolean", nullable: false),
                    NumeroExtintor = table.Column<bool>(type: "boolean", nullable: false),
                    Funda = table.Column<bool>(type: "boolean", nullable: false),
                    Base = table.Column<string>(type: "character varying(100)", nullable: false),
                    Seguro = table.Column<bool>(type: "boolean", nullable: false),
                    Manometro = table.Column<bool>(type: "boolean", nullable: true),
                    Observaciones = table.Column<string>(type: "text", nullable: false),
                    FechaHoraCaptura = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    IdUsuario = table.Column<int>(type: "integer", nullable: false),
                    TipoDeRevsion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLE", x => x.IdCLE);
                    table.ForeignKey(
                        name: "FK_CLE_Extintores_IdExtintor",
                        column: x => x.IdExtintor,
                        principalTable: "Extintores",
                        principalColumn: "IdExtintor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CLE_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CLE_IdExtintor",
                table: "CLE",
                column: "IdExtintor");

            migrationBuilder.CreateIndex(
                name: "IX_CLE_IdUsuario",
                table: "CLE",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_CLEA_IdAutonomo",
                table: "CLEA",
                column: "IdAutonomo");

            migrationBuilder.CreateIndex(
                name: "IX_CLEA_IdUsuario",
                table: "CLEA",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_CLH_IdHidrante",
                table: "CLH",
                column: "IdHidrante");

            migrationBuilder.CreateIndex(
                name: "IX_CLH_IdUsuario",
                table: "CLH",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_EA_IdCliente",
                table: "EA",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Extintores_IdCliente",
                table: "Extintores",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Extintores_IdTipoExtintor",
                table: "Extintores",
                column: "IdTipoExtintor");

            migrationBuilder.CreateIndex(
                name: "IX_Hidrante_IdCliente",
                table: "Hidrante",
                column: "IdCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CLE");

            migrationBuilder.DropTable(
                name: "CLEA");

            migrationBuilder.DropTable(
                name: "CLH");

            migrationBuilder.DropTable(
                name: "Extintores");

            migrationBuilder.DropTable(
                name: "EA");

            migrationBuilder.DropTable(
                name: "Hidrante");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "TipoExtintores");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropSequence(
                name: "SecuenciaCLE");

            migrationBuilder.DropSequence(
                name: "SecuenciaCLEA");

            migrationBuilder.DropSequence(
                name: "SecuenciaCLH");

            migrationBuilder.DropSequence(
                name: "SecuenciaClientes");

            migrationBuilder.DropSequence(
                name: "SecuenciaEA");

            migrationBuilder.DropSequence(
                name: "SecuenciaExtintores");

            migrationBuilder.DropSequence(
                name: "SecuenciaHidrante");

            migrationBuilder.DropSequence(
                name: "SecuenciaTipoExtintor");

            migrationBuilder.DropSequence(
                name: "SecuenciaUsuario");
        }
    }
}
