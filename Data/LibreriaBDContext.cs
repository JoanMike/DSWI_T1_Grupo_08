using System;
using System.Collections.Generic;
using DSWI_T1_Grupo_08.Models;
using Microsoft.EntityFrameworkCore;

namespace DSWI_T1_Grupo_08.Data;

public partial class LibreriaBDContext : DbContext
{
    public LibreriaBDContext()
    {
    }

    public LibreriaBDContext(DbContextOptions<LibreriaBDContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autore> Autores { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autore>(entity =>
        {
            entity.HasKey(e => e.AutorId).HasName("PK__Autores__F58AE90962397997");

            entity.Property(e => e.AutorId).HasColumnName("AutorID");
            entity.Property(e => e.Nacionalidad).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.LibroId).HasName("PK__Libros__35A1EC8DEC6D0126");

            entity.Property(e => e.LibroId).HasColumnName("LibroID");
            entity.Property(e => e.AutorId).HasColumnName("AutorID");
            entity.Property(e => e.Genero).HasMaxLength(50);
            entity.Property(e => e.Isbn)
                .HasMaxLength(20)
                .HasColumnName("ISBN");
            entity.Property(e => e.Titulo).HasMaxLength(100);

            entity.HasOne(d => d.Autor).WithMany(p => p.Libros)
                .HasForeignKey(d => d.AutorId)
                .HasConstraintName("FK__Libros__AutorID__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
