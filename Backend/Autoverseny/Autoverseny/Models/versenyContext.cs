using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Autoverseny.Models
{
    public partial class versenyContext : DbContext
    {
        public versenyContext()
        {
        }

        public versenyContext(DbContextOptions<versenyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Csapat> Csapats { get; set; } = null!;
        public virtual DbSet<Korido> Koridos { get; set; } = null!;
        public virtual DbSet<Palya> Palyas { get; set; } = null!;
        public virtual DbSet<Versenyzo> Versenyzos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("SERVER=localhost;PORT=3306;DATABASE=verseny;USER=root;PASSWORD=;SSL MODE=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Csapat>(entity =>
            {
                entity.ToTable("csapat");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Alapitva)
                    .HasColumnType("year(4)")
                    .HasColumnName("alapitva");

                entity.Property(e => e.Nev)
                    .HasColumnType("text")
                    .HasColumnName("nev");
            });

            modelBuilder.Entity<Korido>(entity =>
            {
                entity.ToTable("korido");

                entity.HasIndex(e => e.Palyaid, "palyaid");

                entity.HasIndex(e => e.Versenyzoid, "versenyzoid");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Kor)
                    .HasColumnType("int(2)")
                    .HasColumnName("kor");

                entity.Property(e => e.Korido1)
                    .HasColumnType("time")
                    .HasColumnName("korido");

                entity.Property(e => e.Palyaid)
                    .HasColumnType("int(11)")
                    .HasColumnName("palyaid");

                entity.Property(e => e.Versenyzoid)
                    .HasColumnType("int(11)")
                    .HasColumnName("versenyzoid");

                entity.HasOne(d => d.Palya)
                    .WithMany(p => p.Koridos)
                    .HasForeignKey(d => d.Palyaid)
                    .HasConstraintName("korido_ibfk_2");

                entity.HasOne(d => d.Versenyzo)
                    .WithMany(p => p.Koridos)
                    .HasForeignKey(d => d.Versenyzoid)
                    .HasConstraintName("korido_ibfk_1");
            });

            modelBuilder.Entity<Palya>(entity =>
            {
                entity.ToTable("palya");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Hossz).HasColumnName("hossz");

                entity.Property(e => e.Nev)
                    .HasColumnType("text")
                    .HasColumnName("nev");

                entity.Property(e => e.Orszag)
                    .HasColumnType("text")
                    .HasColumnName("orszag");
            });

            modelBuilder.Entity<Versenyzo>(entity =>
            {
                entity.ToTable("versenyzo");

                entity.HasIndex(e => e.Csapatid, "csapatid");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Csapatid)
                    .HasColumnType("int(11)")
                    .HasColumnName("csapatid");

                entity.Property(e => e.Eletkor)
                    .HasColumnType("int(2)")
                    .HasColumnName("eletkor");

                entity.Property(e => e.Nev)
                    .HasColumnType("text")
                    .HasColumnName("nev");

                entity.HasOne(d => d.Csapat)
                    .WithMany(p => p.Versenyzos)
                    .HasForeignKey(d => d.Csapatid)
                    .HasConstraintName("versenyzo_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
