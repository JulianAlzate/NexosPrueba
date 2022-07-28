using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace DataBase.Model 
{
    public partial class NexosContext : DbContext
    {
        public NexosContext() : base()
        {
        }
        public NexosContext(DbContextOptions<NexosContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<NexosContext>();
            var connectionString = configuration.GetConnectionString("NexoConnection");
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }   
    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(e => e.IdAutor);

                entity.ToTable("Autor");

                entity.Property(e => e.IdAutor).HasColumnName("idAutor");

                entity.Property(e => e.CiudadProcedencia)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("ciudadProcedencia");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasColumnName("correo");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fechaNacimiento");

                entity.Property(e => e.NombreAutor)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("nombreAutor");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.IdLibro);

                entity.ToTable("Libro");

                entity.Property(e => e.IdLibro).HasColumnName("idLibro");

                entity.Property(e => e.Anio).HasColumnName("anio");

                entity.Property(e => e.Genero)
                    .HasMaxLength(200)
                    .HasColumnName("genero");

                entity.Property(e => e.IdAutor).HasColumnName("idAutor");

                entity.Property(e => e.NumeroPaginas).HasColumnName("numeroPaginas");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(400)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.Autor)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.IdAutor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Libro__idAutor__30F848ED");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public virtual DbSet<Autor> Autors { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }

    }
}
