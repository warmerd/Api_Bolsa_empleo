using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Api_Bolsa_empleo.Entities
{
    public partial class empleoContext : DbContext
    {
        public empleoContext()
        {
        }

        public empleoContext(DbContextOptions<empleoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acceso> Accesos { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Ofertum> Oferta { get; set; }
        public virtual DbSet<Operacione> Operaciones { get; set; }
        public virtual DbSet<Permiso> Permisos { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=elite007.database.windows.net;Database=empleo;User Id =yeisonsiri; Password=Yanelis2020");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Acceso>(entity =>
            {
                entity.ToTable("Acceso");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(10)
                    .HasColumnName("nombre")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Ofertum>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Compania)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("compania");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdCategorias).HasColumnName("idCategorias");

                entity.Property(e => e.Logo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("logo");

                entity.Property(e => e.Posicion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("posicion");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ubicacion");

                entity.Property(e => e.Url)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("url");

                entity.HasOne(d => d.IdCategoriasNavigation)
                    .WithMany(p => p.Oferta)
                    .HasForeignKey(d => d.IdCategorias)
                    .HasConstraintName("FK_Oferta_Categorias");
            });

            modelBuilder.Entity<Operacione>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdAcceso).HasColumnName("idAcceso");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdAccesoNavigation)
                    .WithMany(p => p.Operaciones)
                    .HasForeignKey(d => d.IdAcceso)
                    .HasConstraintName("FK_Operaciones_Acceso");
            });

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.IdOperaciones).HasColumnName("idOperaciones");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.HasOne(d => d.IdOperacionesNavigation)
                    .WithMany(p => p.Permisos)
                    .HasForeignKey(d => d.IdOperaciones)
                    .HasConstraintName("FK_Permisos_Operaciones");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Permisos)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK_Permisos_Rol");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("Rol");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("USUARIO");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Clave)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("clave");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK_USUARIO_Rol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
