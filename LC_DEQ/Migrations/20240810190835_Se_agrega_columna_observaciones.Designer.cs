﻿// <auto-generated />
using System;
using LC_DEQ.Models.BaseDeDatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LCDEQ.Migrations
{
    [DbContext(typeof(BDContext_DEQ))]
    [Migration("20240810190835_Se_agrega_columna_observaciones")]
    partial class Seagregacolumnaobservaciones
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.HasSequence("SecuenciaCLE");

            modelBuilder.HasSequence("SecuenciaCLEA");

            modelBuilder.HasSequence("SecuenciaCLH");

            modelBuilder.HasSequence("SecuenciaClientes");

            modelBuilder.HasSequence("SecuenciaEA");

            modelBuilder.HasSequence("SecuenciaExtintores");

            modelBuilder.HasSequence("SecuenciaHidrante");

            modelBuilder.HasSequence("SecuenciaTipoExtintor");

            modelBuilder.HasSequence("SecuenciaUsuario");

            modelBuilder.Entity("LC_DEQ.Models.BaseDeDatos.CheckListEA", b =>
                {
                    b.Property<int>("IdChecklistEA")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("IdCLEA")
                        .HasDefaultValueSql("nextval('\"SecuenciaCLEA\"')");

                    b.Property<DateTime>("FechaHoraCaptura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("FechaHoraCaptura")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("IdAutonomo")
                        .HasColumnType("integer")
                        .HasColumnName("IdAutonomo");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("integer")
                        .HasColumnName("IdUsuario");

                    b.Property<string>("Observaciones")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Observaciones");

                    b.Property<bool>("Obstrucciones")
                        .HasColumnType("boolean")
                        .HasColumnName("Obstrucciones");

                    b.Property<string>("Presion")
                        .IsRequired()
                        .HasColumnType("character varying(150)")
                        .HasColumnName("Presion");

                    b.HasKey("IdChecklistEA");

                    b.HasIndex("IdAutonomo");

                    b.HasIndex("IdUsuario");

                    b.ToTable("CLEA", (string)null);
                });

            modelBuilder.Entity("LC_DEQ.Models.BaseDeDatos.CheckListExtintor", b =>
                {
                    b.Property<int>("IdChekList")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("IdCLE")
                        .HasDefaultValueSql("nextval('\"SecuenciaCLE\"')");

                    b.Property<string>("Base")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasColumnName("Base");

                    b.Property<DateTime>("FechaHoraCaptura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("FechaHoraCaptura")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime>("FechaServicio")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("FechaServicio");

                    b.Property<bool>("Funda")
                        .HasColumnType("boolean")
                        .HasColumnName("Funda");

                    b.Property<int>("IdExtintor")
                        .HasColumnType("integer")
                        .HasColumnName("IdExtintor");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("integer")
                        .HasColumnName("IdUsuario");

                    b.Property<bool>("Letrero")
                        .HasColumnType("boolean")
                        .HasColumnName("Letrero");

                    b.Property<bool?>("Manometro")
                        .HasColumnType("boolean")
                        .HasColumnName("Manometro");

                    b.Property<bool>("NumeroExtintor")
                        .HasColumnType("boolean")
                        .HasColumnName("NumeroExtintor");

                    b.Property<string>("Observaciones")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Observaciones");

                    b.Property<bool>("Obstrucciones")
                        .HasColumnType("boolean")
                        .HasColumnName("Obstrucciones");

                    b.Property<bool>("Seguro")
                        .HasColumnType("boolean")
                        .HasColumnName("Seguro");

                    b.Property<int>("TipoDeRevision")
                        .HasColumnType("integer")
                        .HasColumnName("TipoDeRevsion");

                    b.HasKey("IdChekList");

                    b.HasIndex("IdExtintor");

                    b.HasIndex("IdUsuario");

                    b.ToTable("CLE", (string)null);
                });

            modelBuilder.Entity("LC_DEQ.Models.BaseDeDatos.CheckListH", b =>
                {
                    b.Property<int>("IdChecklistH")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("IdCLH")
                        .HasDefaultValueSql("nextval('\"SecuenciaCLH\"')");

                    b.Property<bool>("Boquilla")
                        .HasColumnType("boolean")
                        .HasColumnName("Boquilla");

                    b.Property<DateTime>("FechaHoraCaptura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("FechaHoraCaptura")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<bool>("Funda")
                        .HasColumnType("boolean")
                        .HasColumnName("Funda");

                    b.Property<int>("IdHidrante")
                        .HasColumnType("integer")
                        .HasColumnName("IdHidrante");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("integer")
                        .HasColumnName("IdUsuario");

                    b.Property<bool>("NumeroHidrante")
                        .HasColumnType("boolean")
                        .HasColumnName("NumeroHidrante");

                    b.Property<string>("Observaciones")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Observaciones");

                    b.Property<bool>("Obstrucciones")
                        .HasColumnType("boolean")
                        .HasColumnName("Obstrucciones");

                    b.HasKey("IdChecklistH");

                    b.HasIndex("IdHidrante");

                    b.HasIndex("IdUsuario");

                    b.ToTable("CLH", (string)null);
                });

            modelBuilder.Entity("LC_DEQ.Models.BaseDeDatos.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("IdCliente")
                        .HasDefaultValueSql("nextval('\"SecuenciaClientes\"')");

                    b.Property<DateTime>("FechaHoraCaptura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("FechaHoraCaptura")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasColumnName("Nombre");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnName("Status");

                    b.HasKey("IdCliente");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("LC_DEQ.Models.BaseDeDatos.EquipoAutonomo", b =>
                {
                    b.Property<int>("IdAutonomo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("IdAutonomo")
                        .HasDefaultValueSql("nextval('\"SecuenciaEA\"')");

                    b.Property<DateTime>("FechaHoraCaptura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("FechaHoraCaptura")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("IdCliente")
                        .HasColumnType("integer")
                        .HasColumnName("IdCliente");

                    b.Property<string>("NumeroAutonomo")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasColumnName("NumeroAutonomo");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnName("Status");

                    b.HasKey("IdAutonomo");

                    b.HasIndex("IdCliente");

                    b.ToTable("EA", (string)null);
                });

            modelBuilder.Entity("LC_DEQ.Models.BaseDeDatos.Extintor", b =>
                {
                    b.Property<int>("IdExtintor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("IdExtintor")
                        .HasDefaultValueSql("nextval('\"SecuenciaExtintores\"')");

                    b.Property<DateTime?>("FechaFabricacion")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("FechaFabricacion");

                    b.Property<DateTime>("FechaHoraCaptura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("FechaHoraCaptura")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("IdCliente")
                        .HasColumnType("integer")
                        .HasColumnName("IdCliente");

                    b.Property<int>("IdTipoExtintor")
                        .HasColumnType("integer")
                        .HasColumnName("IdTipoExtintor");

                    b.Property<string>("NumeroDeExtintor")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasColumnName("NumeroDeExtintor");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnName("Status");

                    b.HasKey("IdExtintor");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdTipoExtintor");

                    b.ToTable("Extintores", (string)null);
                });

            modelBuilder.Entity("LC_DEQ.Models.BaseDeDatos.Hidrante", b =>
                {
                    b.Property<int>("IdHidrante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("IdHidrante")
                        .HasDefaultValueSql("nextval('\"SecuenciaHidrante\"')");

                    b.Property<DateTime>("FechaHoraCaptura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("FechaHoraCaptura")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("IdCliente")
                        .HasColumnType("integer")
                        .HasColumnName("IdCliente");

                    b.Property<string>("NumeroHidrante")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasColumnName("NumeroHidrante");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnName("Status");

                    b.HasKey("IdHidrante");

                    b.HasIndex("IdCliente");

                    b.ToTable("Hidrante", (string)null);
                });

            modelBuilder.Entity("LC_DEQ.Models.BaseDeDatos.TipoExtintor", b =>
                {
                    b.Property<int>("IdTipoExtintor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("IdTipoExtintor")
                        .HasDefaultValueSql("nextval('\"SecuenciaTipoExtintor\"')");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasColumnName("Descripcion");

                    b.Property<DateTime>("FechaHoraCaptura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("FechaHoraCaptura")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnName("Status");

                    b.HasKey("IdTipoExtintor");

                    b.ToTable("TipoExtintores", (string)null);
                });

            modelBuilder.Entity("LC_DEQ.Models.BaseDeDatos.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("IdUsuario")
                        .HasDefaultValueSql("nextval('\"SecuenciaUsuario\"')");

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Contrasenia");

                    b.Property<DateTime>("FechaHoraCaptura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("FechaHoraCaptura")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnName("Status");

                    b.Property<string>("UsuarioName")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasColumnName("NombreUsuario");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("LC_DEQ.Models.BaseDeDatos.CheckListEA", b =>
                {
                    b.HasOne("LC_DEQ.Models.BaseDeDatos.EquipoAutonomo", "EquipoAutonomo")
                        .WithMany("CheckListEA")
                        .HasForeignKey("IdAutonomo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LC_DEQ.Models.BaseDeDatos.Usuario", "Usuario")
                        .WithMany("ChekListEA")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EquipoAutonomo");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("LC_DEQ.Models.BaseDeDatos.CheckListExtintor", b =>
                {
                    b.HasOne("LC_DEQ.Models.BaseDeDatos.Extintor", "Extintor")
                        .WithMany("Extintores")
                        .HasForeignKey("IdExtintor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LC_DEQ.Models.BaseDeDatos.Usuario", "Usuario")
                        .WithMany("ChekListExtintors")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Extintor");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("LC_DEQ.Models.BaseDeDatos.CheckListH", b =>
                {
                    b.HasOne("LC_DEQ.Models.BaseDeDatos.Hidrante", "Hidrante")
                        .WithMany("CheckListH")
                        .HasForeignKey("IdHidrante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LC_DEQ.Models.BaseDeDatos.Usuario", "Usuario")
                        .WithMany("ChekListH")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hidrante");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("LC_DEQ.Models.BaseDeDatos.EquipoAutonomo", b =>
                {
                    b.HasOne("LC_DEQ.Models.BaseDeDatos.Cliente", "Cliente")
                        .WithMany("EquiposAutonomos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("LC_DEQ.Models.BaseDeDatos.Extintor", b =>
                {
                    b.HasOne("LC_DEQ.Models.BaseDeDatos.Cliente", "Cliente")
                        .WithMany("Extintors")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LC_DEQ.Models.BaseDeDatos.TipoExtintor", "TipoExtintor")
                        .WithMany("Extintors")
                        .HasForeignKey("IdTipoExtintor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("TipoExtintor");
                });

            modelBuilder.Entity("LC_DEQ.Models.BaseDeDatos.Hidrante", b =>
                {
                    b.HasOne("LC_DEQ.Models.BaseDeDatos.Cliente", "Cliente")
                        .WithMany("Hidrantes")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("LC_DEQ.Models.BaseDeDatos.Cliente", b =>
                {
                    b.Navigation("EquiposAutonomos");

                    b.Navigation("Extintors");

                    b.Navigation("Hidrantes");
                });

            modelBuilder.Entity("LC_DEQ.Models.BaseDeDatos.EquipoAutonomo", b =>
                {
                    b.Navigation("CheckListEA");
                });

            modelBuilder.Entity("LC_DEQ.Models.BaseDeDatos.Extintor", b =>
                {
                    b.Navigation("Extintores");
                });

            modelBuilder.Entity("LC_DEQ.Models.BaseDeDatos.Hidrante", b =>
                {
                    b.Navigation("CheckListH");
                });

            modelBuilder.Entity("LC_DEQ.Models.BaseDeDatos.TipoExtintor", b =>
                {
                    b.Navigation("Extintors");
                });

            modelBuilder.Entity("LC_DEQ.Models.BaseDeDatos.Usuario", b =>
                {
                    b.Navigation("ChekListEA");

                    b.Navigation("ChekListExtintors");

                    b.Navigation("ChekListH");
                });
#pragma warning restore 612, 618
        }
    }
}
