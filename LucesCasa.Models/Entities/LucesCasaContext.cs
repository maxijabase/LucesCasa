using System;
using LucesCasa.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LucesCasa.Models.Entities
{
    public partial class LucesCasaContext : DbContext
    {
        public LucesCasaContext()
        {
        }

        public LucesCasaContext(DbContextOptions<LucesCasaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Luz> Luces { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(ServiceConfiguration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("logs");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .HasColumnName("descripcion");

                entity.Property(e => e.IdLog)
                    .HasMaxLength(255)
                    .HasColumnName("id_log");

                entity.Property(e => e.Responsable)
                    .HasMaxLength(255)
                    .HasColumnName("responsable");

                entity.Property(e => e.Timestamp).HasColumnName("timestamp");
            });

            modelBuilder.Entity<Luz>(entity =>
            {
                entity.ToTable("luces");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("alias");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("ip");

                entity.Property(e => e.Pin).HasColumnName("pin");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuarios");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(255)
                    .HasColumnName("apellido");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("nombre");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(255)
                    .HasColumnName("usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
