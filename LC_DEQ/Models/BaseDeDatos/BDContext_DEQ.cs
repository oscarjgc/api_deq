using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC_DEQ.Models.BaseDeDatos
{
    public class BDContext_DEQ : DbContext
    {// este es el contructor del context
        public BDContext_DEQ(DbContextOptions<BDContext_DEQ> options) : base(options) { AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); }
        //dbset esto representa la tabla o entidad del contexto (es donde podemos acceder a la tabla que queremos)
        public DbSet<Cliente> Clientes { get; set; } = default;
        public DbSet<EquipoAutonomo> EquipoAutonomo { get; set; } = default;
        public DbSet<Extintor> Extintor { get; set; } = default;
        public DbSet<Hidrante> Hidrante { get; set; } = default;
        public DbSet<TipoExtintor> TipoExtintor { get; set; } = default;
        public DbSet<Usuario> Usuario { get; set; } = default;
        public DbSet<CheckListEA> CLEA { get; set; } = default;
        public DbSet<CheckListExtintor> CLE { get; set; } = default;
        public DbSet<CheckListH> CLH { get; set; } = default;

        protected override void OnModelCreating(ModelBuilder modelBuilder) // mapeo para base de datos(entity framework)
        {
            #region Clientes 
            modelBuilder.HasSequence("SecuenciaClientes")
                .IncrementsBy(1)
                .StartsAt(1);
            modelBuilder.Entity<Cliente>(Entity =>
            {
                Entity.ToTable("Clientes");
                Entity.HasKey(x => x.IdCliente);
                Entity.Property(x => x.IdCliente)
                .HasColumnName("IdCliente")
                .HasColumnType("integer")
                .HasDefaultValueSql("nextval('\"SecuenciaClientes\"')")
                .ValueGeneratedOnAdd()
                .IsRequired();

                Entity.Property(x => x.Nombre)
                .HasColumnName("Nombre")
                .HasColumnType("character varying(100)")
                .IsRequired();

                Entity.Property(x => x.Status)
                .HasColumnName("Status")
                .HasColumnType("boolean")
                .IsRequired();

                Entity.Property(x => x.FechaHoraCaptura)
               .HasColumnName("FechaHoraCaptura")
               .HasColumnType("timestamp without time zone")
               .HasDefaultValueSql("CURRENT_TIMESTAMP")
               .IsRequired();


            }

                );
            #endregion

            #region Extintores 
            modelBuilder.HasSequence("SecuenciaExtintores")
                .IncrementsBy(1)
                .StartsAt(1);

            modelBuilder.Entity<Extintor>()
                .HasOne<Cliente>(c => c.Cliente)
                .WithMany(e => e.Extintors)
                .HasForeignKey(x => x.IdCliente);

            modelBuilder.Entity<Extintor>()
               .HasOne<TipoExtintor>(c => c.TipoExtintor)
               .WithMany(e => e.Extintors)
               .HasForeignKey(x => x.IdTipoExtintor);
            modelBuilder.Entity<Extintor>(Entity =>
            {
                Entity.ToTable("Extintores");
                Entity.HasKey(x => x.IdExtintor);
                Entity.Property(x => x.IdExtintor)
                .HasColumnName("IdExtintor")
                .HasColumnType("integer")
                .HasDefaultValueSql("nextval('\"SecuenciaExtintores\"')")
                .ValueGeneratedOnAdd()
                .IsRequired();

                Entity.Property(x => x.NumeroDeExtintor)
                .HasColumnName("NumeroDeExtintor")
                .HasColumnType("character varying(100)")
                .IsRequired();

                Entity.Property(x => x.IdCliente)
               .HasColumnName("IdCliente")
               .HasColumnType("integer")
               .IsRequired();

                Entity.Property(x => x.IdTipoExtintor)
               .HasColumnName("IdTipoExtintor")
               .HasColumnType("integer")
               .IsRequired();

                Entity.Property(x => x.Status)
                .HasColumnName("Status")
                .HasColumnType("boolean")
                .IsRequired();

                Entity.Property(x => x.FechaHoraCaptura)
               .HasColumnName("FechaHoraCaptura")
               .HasColumnType("timestamp without time zone")
               .HasDefaultValueSql("CURRENT_TIMESTAMP")
               .IsRequired();

                Entity.Property(x => x.FechaFabricacion)
              .HasColumnName("FechaFabricacion")
              .HasColumnType("timestamp without time zone");



            }

                );
            #endregion

            #region Hidrante 
            modelBuilder.HasSequence("SecuenciaHidrante")
                .IncrementsBy(1)
                .StartsAt(1);

            modelBuilder.Entity<Hidrante>()
                .HasOne<Cliente>(c => c.Cliente)
                .WithMany(e => e.Hidrantes)
                .HasForeignKey(x => x.IdCliente);


            modelBuilder.Entity<Hidrante>(Entity =>
            {
                Entity.ToTable("Hidrante");
                Entity.HasKey(x => x.IdHidrante);
                Entity.Property(x => x.IdHidrante)
                .HasColumnName("IdHidrante")
                .HasColumnType("integer")
                .HasDefaultValueSql("nextval('\"SecuenciaHidrante\"')")
                .ValueGeneratedOnAdd()
                .IsRequired();

                Entity.Property(x => x.NumeroHidrante)
                .HasColumnName("NumeroHidrante")
                .HasColumnType("character varying(100)")
                .IsRequired();

                Entity.Property(x => x.IdCliente)
               .HasColumnName("IdCliente")
               .HasColumnType("integer")
               .IsRequired();


                Entity.Property(x => x.Status)
                .HasColumnName("Status")
                .HasColumnType("boolean")
                .IsRequired();

                Entity.Property(x => x.FechaHoraCaptura)
               .HasColumnName("FechaHoraCaptura")
               .HasColumnType("timestamp without time zone")
               .HasDefaultValueSql("CURRENT_TIMESTAMP")
               .IsRequired();


            }

                );
            #endregion

            #region EquipoAutonomo 
            modelBuilder.HasSequence("SecuenciaEA")
                .IncrementsBy(1)
                .StartsAt(1);

            modelBuilder.Entity<EquipoAutonomo>()
                .HasOne<Cliente>(c => c.Cliente)
                .WithMany(e => e.EquiposAutonomos)
                .HasForeignKey(x => x.IdCliente);


            modelBuilder.Entity<EquipoAutonomo>(Entity =>
            {
                Entity.ToTable("EA");
                Entity.HasKey(x => x.IdAutonomo);
                Entity.Property(x => x.IdAutonomo)
                .HasColumnName("IdAutonomo")
                .HasColumnType("integer")
                .HasDefaultValueSql("nextval('\"SecuenciaEA\"')")
                .ValueGeneratedOnAdd()
                .IsRequired();

                Entity.Property(x => x.NumeroAutonomo)
                .HasColumnName("NumeroAutonomo")
                .HasColumnType("character varying(100)")
                .IsRequired();

                Entity.Property(x => x.IdCliente)
               .HasColumnName("IdCliente")
               .HasColumnType("integer")
               .IsRequired();


                Entity.Property(x => x.Status)
                .HasColumnName("Status")
                .HasColumnType("boolean")
                .IsRequired();

                Entity.Property(x => x.FechaHoraCaptura)
               .HasColumnName("FechaHoraCaptura")
               .HasColumnType("timestamp without time zone")
               .HasDefaultValueSql("CURRENT_TIMESTAMP")
               .IsRequired();


            }

                );
            #endregion

            #region TipoExtintor 
            modelBuilder.HasSequence("SecuenciaTipoExtintor")
                .IncrementsBy(1)
                .StartsAt(1);
            modelBuilder.Entity<TipoExtintor>(Entity =>
            {
                Entity.ToTable("TipoExtintores");
                Entity.HasKey(x => x.IdTipoExtintor);
                Entity.Property(x => x.IdTipoExtintor)
                .HasColumnName("IdTipoExtintor")
                .HasColumnType("integer")
                .HasDefaultValueSql("nextval('\"SecuenciaTipoExtintor\"')")
                .ValueGeneratedOnAdd()
                .IsRequired();

                Entity.Property(x => x.Descripcion)
                .HasColumnName("Descripcion")
                .HasColumnType("character varying(100)")
                .IsRequired();

                Entity.Property(x => x.Status)
                .HasColumnName("Status")
                .HasColumnType("boolean")
                .IsRequired();

                Entity.Property(x => x.FechaHoraCaptura)
               .HasColumnName("FechaHoraCaptura")
               .HasColumnType("timestamp without time zone")
               .HasDefaultValueSql("CURRENT_TIMESTAMP")
               .IsRequired();


            }

                );
            #endregion

            #region Usuario 
            modelBuilder.HasSequence("SecuenciaUsuario")
                .IncrementsBy(1)
                .StartsAt(1);
            modelBuilder.Entity<Usuario>(Entity =>
            {
                Entity.ToTable("Usuario");
                Entity.HasKey(x => x.IdUsuario);
                Entity.Property(x => x.IdUsuario)
                .HasColumnName("IdUsuario")
                .HasColumnType("integer")
                .HasDefaultValueSql("nextval('\"SecuenciaUsuario\"')")
                .ValueGeneratedOnAdd()
                .IsRequired();

                Entity.Property(x => x.UsuarioName)
                .HasColumnName("NombreUsuario")
                .HasColumnType("character varying(100)")
                .IsRequired();

                Entity.Property(x => x.Contrasenia)
               .HasColumnName("Contrasenia")
               .HasColumnType("text")
               .IsRequired();

                Entity.Property(x => x.Status)
                .HasColumnName("Status")
                .HasColumnType("boolean")
                .IsRequired();

                Entity.Property(x => x.FechaHoraCaptura)
               .HasColumnName("FechaHoraCaptura")
               .HasColumnType("timestamp without time zone")
               .HasDefaultValueSql("CURRENT_TIMESTAMP")
               .IsRequired();

                Entity.Property(x => x.IdPerfil)
              .HasColumnName("IdPerfil")
              .HasColumnType("integer")
              .HasDefaultValueSql("1")
              .IsRequired();


                Entity.Property(x => x.IdCliente)
             .HasColumnName("IdCliente")
             .HasColumnType("integer")
             .HasDefaultValueSql("1")
             .IsRequired();
            }

                );
            #endregion

            #region CheckListExtintor 
            modelBuilder.HasSequence("SecuenciaCLE") // secuencia
                .IncrementsBy(1)
                .StartsAt(1);

            modelBuilder.Entity<CheckListExtintor>() //relaciones
                .HasOne<Extintor>(c => c.Extintor)
                .WithMany(e => e.Extintores)
                .HasForeignKey(x => x.IdExtintor);

            modelBuilder.Entity<CheckListExtintor>()
                .HasOne<Usuario>(c => c.Usuario)
                .WithMany(e => e.ChekListExtintors)
                .HasForeignKey(x => x.IdUsuario);

            modelBuilder.Entity<CheckListExtintor>(Entity => // tabla
            {
                Entity.ToTable("CLE");
                Entity.HasKey(x => x.IdChekList);
                Entity.Property(x => x.IdChekList)
                .HasColumnName("IdCLE")
                .HasColumnType("integer")
                .HasDefaultValueSql("nextval('\"SecuenciaCLE\"')")
                .ValueGeneratedOnAdd()
                .IsRequired();

                Entity.Property(x => x.IdExtintor)
                .HasColumnName("IdExtintor")
                .HasColumnType("integer")
                .IsRequired();

                Entity.Property(x => x.Letrero)
               .HasColumnName("Letrero")
               .HasColumnType("boolean")
               .IsRequired();

                Entity.Property(x => x.NumeroExtintor)
                .HasColumnName("NumeroExtintor")
                .HasColumnType("boolean")
                .IsRequired();

                Entity.Property(x => x.Funda)
                .HasColumnName("Funda")
                .HasColumnType("boolean")
                .IsRequired();

                Entity.Property(x => x.Base)
                .HasColumnName("Base")
                .HasColumnType("character varying(100)")
                .IsRequired();

                Entity.Property(x => x.Seguro)
               .HasColumnName("Seguro")
               .HasColumnType("boolean")
               .IsRequired();

                Entity.Property(x => x.Obstrucciones)
              .HasColumnName("Obstrucciones")
              .HasColumnType("boolean")
              .IsRequired();

                Entity.Property(x => x.Manometro)
               .HasColumnName("Manometro")
               .HasColumnType("boolean");


                Entity.Property(x => x.Observaciones)
               .HasColumnName("Observaciones")
               .HasColumnType("text")
               .IsRequired();

                Entity.Property(x => x.IdUsuario)
                .HasColumnName("IdUsuario")
                .HasColumnType("integer")
                .IsRequired();

                Entity.Property(x => x.FechaHoraCaptura)
               .HasColumnName("FechaHoraCaptura")
               .HasColumnType("timestamp without time zone")
               .HasDefaultValueSql("CURRENT_TIMESTAMP")
               .IsRequired();

                Entity.Property(x => x.FechaServicio)
              .HasColumnName("FechaServicio")
              .HasColumnType("timestamp without time zone")
              .IsRequired();

                Entity.Property(x => x.TipoDeRevision)
                .HasColumnName("TipoDeRevsion")
                .HasColumnType("integer")
                .IsRequired();
            }

                );
            #endregion

            #region CheckListEA 
            modelBuilder.HasSequence("SecuenciaCLEA")
                .IncrementsBy(1)
                .StartsAt(1);

            modelBuilder.Entity<CheckListEA>()
                .HasOne<EquipoAutonomo>(c => c.EquipoAutonomo)
                .WithMany(e => e.CheckListEA)
                .HasForeignKey(x => x.IdAutonomo);

            modelBuilder.Entity<CheckListEA>()
                .HasOne<Usuario>(c => c.Usuario)
                .WithMany(e => e.ChekListEA)
                .HasForeignKey(x => x.IdUsuario);

            modelBuilder.Entity<CheckListEA>(Entity =>
            {
                Entity.ToTable("CLEA");
                Entity.HasKey(x => x.IdChecklistEA);
                Entity.Property(x => x.IdChecklistEA)
                .HasColumnName("IdCLEA")
                .HasColumnType("integer")
                .HasDefaultValueSql("nextval('\"SecuenciaCLEA\"')")
                .ValueGeneratedOnAdd()
                .IsRequired();

                Entity.Property(x => x.Presion)
                .HasColumnName("Presion")
                .HasColumnType("character varying(150)")
                .IsRequired();

                Entity.Property(x => x.Observaciones)
               .HasColumnName("Observaciones")
               .HasColumnType("text")
               .IsRequired();

                Entity.Property(x => x.IdUsuario)
                .HasColumnName("IdUsuario")
                .HasColumnType("integer")
                .IsRequired();

                Entity.Property(x => x.IdAutonomo)
                .HasColumnName("IdAutonomo")
                .HasColumnType("integer")
                .IsRequired();

                Entity.Property(x => x.Obstrucciones)
                .HasColumnName("Obstrucciones")
                .HasColumnType("boolean")
                .IsRequired();

                Entity.Property(x => x.FechaHoraCaptura)
               .HasColumnName("FechaHoraCaptura")
               .HasColumnType("timestamp without time zone")
               .HasDefaultValueSql("CURRENT_TIMESTAMP")
               .IsRequired();

            }

                );
            #endregion
            // estas son secuencias
            #region CheckListH 
            modelBuilder.HasSequence("SecuenciaCLH")
                .IncrementsBy(1)
                .StartsAt(1);
            // estas son relaciones
            modelBuilder.Entity<CheckListH>()
                .HasOne<Hidrante>(c => c.Hidrante)
                .WithMany(e => e.CheckListH)
                .HasForeignKey(x => x.IdHidrante);

            modelBuilder.Entity<CheckListH>()
                .HasOne<Usuario>(c => c.Usuario)
                .WithMany(e => e.ChekListH)
                .HasForeignKey(x => x.IdUsuario);
            // esta es la tabla
            modelBuilder.Entity<CheckListH>(Entity =>
            {
                //este es el nombre de la tabla
                Entity.ToTable("CLH");
                //esta es la llave primaria
                Entity.HasKey(x => x.IdChecklistH);
                //esta son las columnas de la tabla
                Entity.Property(x => x.IdChecklistH)
                .HasColumnName("IdCLH")
                .HasColumnType("integer")
                .HasDefaultValueSql("nextval('\"SecuenciaCLH\"')")
                .ValueGeneratedOnAdd()
                .IsRequired();

                Entity.Property(x => x.NumeroHidrante)
                .HasColumnName("NumeroHidrante")
                .HasColumnType("boolean")
                .IsRequired();

                Entity.Property(x => x.Boquilla)
               .HasColumnName("Boquilla")
               .HasColumnType("boolean")
               .IsRequired();

                Entity.Property(x => x.Observaciones)
               .HasColumnName("Observaciones")
               .HasColumnType("text")
               .IsRequired();

                Entity.Property(x => x.Funda)
               .HasColumnName("Funda")
               .HasColumnType("boolean")
               .IsRequired();

                Entity.Property(x => x.IdUsuario)
                .HasColumnName("IdUsuario")
                .HasColumnType("integer")
                .IsRequired();

                Entity.Property(x => x.IdHidrante)
                .HasColumnName("IdHidrante")
                .HasColumnType("integer")
                .IsRequired();

                Entity.Property(x => x.FechaHoraCaptura)
               .HasColumnName("FechaHoraCaptura")
               .HasColumnType("timestamp without time zone")
               .HasDefaultValueSql("CURRENT_TIMESTAMP")
               .IsRequired();

                Entity.Property(x => x.Obstrucciones)
                .HasColumnName("Obstrucciones")
                .HasColumnType("boolean")
                .IsRequired();

            }

                );
            #endregion
        }

    }
}
