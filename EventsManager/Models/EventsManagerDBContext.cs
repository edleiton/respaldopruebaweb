using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EventsManager.Models
{
    public partial class EventsManagerDBContext : DbContext
    {
        public EventsManagerDBContext()
        {
        }

        public EventsManagerDBContext(DbContextOptions<EventsManagerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Calificacion> Calificacion { get; set; }
        public virtual DbSet<Canton> Canton { get; set; }
        public virtual DbSet<Contacto> Contacto { get; set; }
        public virtual DbSet<Distrito> Distrito { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<Institucion> Institucion { get; set; }
        public virtual DbSet<NivelAcademico> NivelAcademico { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<Tema> Tema { get; set; }
        public virtual DbSet<TipoEvento> TipoEvento { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Ubicacion> Ubicacion { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EventsManagerDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calificacion>(entity =>
            {
                entity.HasKey(e => e.Idcalifiacion);

                entity.Property(e => e.Idcalifiacion).HasColumnName("IDCalifiacion");

                entity.Property(e => e.Calificacion1).HasColumnName("Calificacion");

                entity.Property(e => e.Comentario)
                    .HasMaxLength(1500)
                    .IsUnicode(false);

                entity.Property(e => e.Idevento).HasColumnName("IDEvento");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.HasOne(d => d.IdeventoNavigation)
                    .WithMany(p => p.CalificacionNavigation)
                    .HasForeignKey(d => d.Idevento)
                    .HasConstraintName("FK_Calificacion_Evento");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Calificacion)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("FK_Calificacion_Usuario");
            });

            modelBuilder.Entity<Canton>(entity =>
            {
                entity.HasKey(e => e.Idcanton);

                entity.Property(e => e.Idcanton).HasColumnName("IDCanton");

                entity.Property(e => e.Idprovicia).HasColumnName("IDProvicia");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.HasKey(e => e.Idcontacto);

                entity.Property(e => e.Idcontacto).HasColumnName("IDContacto");

                entity.Property(e => e.Identificador)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Contacto)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("FK_Contacto_Usuario");
            });

            modelBuilder.Entity<Distrito>(entity =>
            {
                entity.HasKey(e => e.Iddistrito);

                entity.Property(e => e.Iddistrito).HasColumnName("IDdistrito");

                entity.Property(e => e.Idcanton).HasColumnName("IDCanton");

                entity.Property(e => e.Idprovicia).HasColumnName("IDProvicia");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.Idevento);

                entity.Property(e => e.Idevento).HasColumnName("IDEvento");

                entity.Property(e => e.FechaFinal).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.Idexpositor).HasColumnName("IDExpositor");

                entity.Property(e => e.Idtema).HasColumnName("IDTema");

                entity.Property(e => e.IdtipoEvento).HasColumnName("IDTipoEvento");

                entity.Property(e => e.Idubicacion).HasColumnName("IDUbicacion");

                entity.HasOne(d => d.IdexpositorNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.Idexpositor)
                    .HasConstraintName("FK_Evento_Usuario");

                entity.HasOne(d => d.IdtemaNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.Idtema)
                    .HasConstraintName("FK_Evento_Tema");

                entity.HasOne(d => d.IdtipoEventoNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.IdtipoEvento)
                    .HasConstraintName("FK_Evento_TipoEvento");

                entity.HasOne(d => d.IdubicacionNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.Idubicacion)
                    .HasConstraintName("FK_Evento_Ubica");
            });

            modelBuilder.Entity<Institucion>(entity =>
            {
                entity.HasKey(e => e.Idinstitucion);

                entity.Property(e => e.Idinstitucion).HasColumnName("IDInstitucion");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NivelAcademico>(entity =>
            {
                entity.HasKey(e => e.Idnivel);

                entity.Property(e => e.Idnivel).HasColumnName("IDNivel");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.HasKey(e => e.Idprovincia);

                entity.Property(e => e.Idprovincia).HasColumnName("IDProvincia");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.Idreserva);

                entity.Property(e => e.Idreserva).HasColumnName("IDReserva");

                entity.Property(e => e.Idevento).HasColumnName("IDEvento");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.Property(e => e.Reserva1).HasColumnName("Reserva");

                entity.HasOne(d => d.IdeventoNavigation)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.Idevento)
                    .HasConstraintName("FK_Reserva_Evento");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("FK_Reserva_Usuario");
            });

            modelBuilder.Entity<Tema>(entity =>
            {
                entity.HasKey(e => e.Idtema);

                entity.Property(e => e.Idtema).HasColumnName("IDTema");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Idtipo).HasColumnName("IDTipo");

                entity.HasOne(d => d.IdtipoNavigation)
                    .WithMany(p => p.Tema)
                    .HasForeignKey(d => d.Idtipo)
                    .HasConstraintName("FK_Tema_TipoEvento");
            });

            modelBuilder.Entity<TipoEvento>(entity =>
            {
                entity.HasKey(e => e.IdtipoEvento);

                entity.Property(e => e.IdtipoEvento).HasColumnName("IDTipoEvento");

                entity.Property(e => e.Descripcion).HasMaxLength(50);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.Idtipo);

                entity.Property(e => e.Idtipo).HasColumnName("IDTipo");

                entity.Property(e => e.Descripcion).HasMaxLength(50);
            });

            modelBuilder.Entity<Ubicacion>(entity =>
            {
                entity.HasKey(e => e.Idubicacion);

                entity.Property(e => e.Idubicacion).HasColumnName("IDUbicacion");

                entity.Property(e => e.Idcanton).HasColumnName("IDCanton");

                entity.Property(e => e.Iddistrito).HasColumnName("IDDistrito");

                entity.Property(e => e.Idevento).HasColumnName("IDEvento");

                entity.Property(e => e.Idprovincia).HasColumnName("IDProvincia");

                entity.Property(e => e.Lugar)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdcantonNavigation)
                    .WithMany(p => p.Ubicacion)
                    .HasForeignKey(d => d.Idcanton)
                    .HasConstraintName("FK_Ubica_Canton");

                entity.HasOne(d => d.IddistritoNavigation)
                    .WithMany(p => p.Ubicacion)
                    .HasForeignKey(d => d.Iddistrito)
                    .HasConstraintName("FK_Ubica_Distrito");

                entity.HasOne(d => d.IdprovinciaNavigation)
                    .WithMany(p => p.Ubicacion)
                    .HasForeignKey(d => d.Idprovincia)
                    .HasConstraintName("FK_Ubica_provincia");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario);

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.Property(e => e.Apellido1)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido2)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Clave)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso).HasColumnType("date");

                entity.Property(e => e.Idinstitucion).HasColumnName("IDInstitucion");

                entity.Property(e => e.Idnivel).HasColumnName("IDNivel");

                entity.Property(e => e.Idtipo).HasColumnName("IDTipo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario1)
                    .HasColumnName("Usuario")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdinstitucionNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.Idinstitucion)
                    .HasConstraintName("FK_Usuario_Institucion");

                entity.HasOne(d => d.IdnivelNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.Idnivel)
                    .HasConstraintName("FK_Usuario_NivelAC");

                entity.HasOne(d => d.IdtipoNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.Idtipo)
                    .HasConstraintName("FK_Usuario_TipoUsuario");
            });
        }
    }
}
