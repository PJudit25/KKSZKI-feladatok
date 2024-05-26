using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Webshop.Models
{
    public partial class adatbazis2Context : DbContext
    {
        public adatbazis2Context()
        {
        }

        public adatbazis2Context(DbContextOptions<adatbazis2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Szamlafej> Szamlafejs { get; set; } = null!;
        public virtual DbSet<Szamlatetel> Szamlatetels { get; set; } = null!;
        public virtual DbSet<Termekek> Termekeks { get; set; } = null!;
        public virtual DbSet<Vevok> Vevoks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("SERVER=localhost;PORT=3306;DATABASE=adatbazis2;USER=root;PASSWORD=;SSL MODE=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Szamlafej>(entity =>
            {
                entity.ToTable("szamlafej");

                entity.HasIndex(e => e.Vevoid, "vevoid");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Kelt)
                    .HasColumnType("date")
                    .HasColumnName("kelt");

                entity.Property(e => e.Szamlaszam)
                    .HasColumnType("text")
                    .HasColumnName("szamlaszam");

                entity.Property(e => e.Teljesites)
                    .HasColumnType("date")
                    .HasColumnName("teljesites");

                entity.Property(e => e.Vevoid)
                    .HasColumnType("int(11)")
                    .HasColumnName("vevoid");

                entity.HasOne(d => d.Vevo)
                    .WithMany(p => p.Szamlafejs)
                    .HasForeignKey(d => d.Vevoid)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("szamlafej_ibfk_1");
            });

            modelBuilder.Entity<Szamlatetel>(entity =>
            {
                entity.ToTable("szamlatetel");

                entity.HasIndex(e => e.Szamlafejid, "szamlafejid");

                entity.HasIndex(e => e.Termekid, "termekid");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Afaszazalek)
                    .HasColumnType("int(11)")
                    .HasColumnName("afaszazalek");

                entity.Property(e => e.Bruttoegysegar).HasColumnName("bruttoegysegar");

                entity.Property(e => e.Mennyiseg)
                    .HasColumnType("int(11)")
                    .HasColumnName("mennyiseg");

                entity.Property(e => e.Mennyisegiegyseg)
                    .HasColumnType("text")
                    .HasColumnName("mennyisegiegyseg");

                entity.Property(e => e.Szamlafejid)
                    .HasColumnType("int(11)")
                    .HasColumnName("szamlafejid");

                entity.Property(e => e.Termekid)
                    .HasColumnType("int(11)")
                    .HasColumnName("termekid");

                entity.HasOne(d => d.Szamlafej)
                    .WithMany(p => p.Szamlatetels)
                    .HasForeignKey(d => d.Szamlafejid)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("szamlatetel_ibfk_1");

                entity.HasOne(d => d.Termek)
                    .WithMany(p => p.Szamlatetels)
                    .HasForeignKey(d => d.Termekid)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("szamlatetel_ibfk_2");
            });

            modelBuilder.Entity<Termekek>(entity =>
            {
                entity.ToTable("termekek");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Ar).HasColumnName("ar");

                entity.Property(e => e.Megnevezes)
                    .HasColumnType("text")
                    .HasColumnName("megnevezes");
            });

            modelBuilder.Entity<Vevok>(entity =>
            {
                entity.ToTable("vevok");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Iranyitoszam)
                    .HasColumnType("text")
                    .HasColumnName("iranyitoszam");

                entity.Property(e => e.Nev)
                    .HasColumnType("text")
                    .HasColumnName("nev");

                entity.Property(e => e.Telepules)
                    .HasColumnType("text")
                    .HasColumnName("telepules");

                entity.Property(e => e.Utcahazszam)
                    .HasColumnType("text")
                    .HasColumnName("utcahazszam");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
