using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebvillWebAPI.Models
{
    public partial class webvillContext : DbContext
    {
        public webvillContext()
        {
        }

        public webvillContext(DbContextOptions<webvillContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kategoriak> Kategoriaks { get; set; } = null!;
        public virtual DbSet<Rendelesek> Rendeleseks { get; set; } = null!;
        public virtual DbSet<Termekek> Termekeks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("SERVER=localhost;PORT=3306;DATABASE=webvill;USER=root;PASSWORD=;SSL MODE=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategoriak>(entity =>
            {
                entity.HasKey(e => e.Kazon)
                    .HasName("PRIMARY");

                entity.ToTable("kategoriak");

                entity.Property(e => e.Kazon)
                    .HasColumnType("int(11)")
                    .HasColumnName("kazon");

                entity.Property(e => e.Knev)
                    .HasColumnType("text")
                    .HasColumnName("knev");
            });

            modelBuilder.Entity<Rendelesek>(entity =>
            {
                entity.HasKey(e => e.Razon)
                    .HasName("PRIMARY");

                entity.ToTable("rendelesek");

                entity.HasIndex(e => e.Tazon, "tazon");

                entity.Property(e => e.Razon)
                    .HasColumnType("int(11)")
                    .HasColumnName("razon");

                entity.Property(e => e.Db)
                    .HasColumnType("int(11)")
                    .HasColumnName("db");

                entity.Property(e => e.Rdatum)
                    .HasColumnType("date")
                    .HasColumnName("rdatum");

                entity.Property(e => e.Tazon)
                    .HasColumnType("int(11)")
                    .HasColumnName("tazon");

                entity.HasOne(d => d.TazonNavigation)
                    .WithMany(p => p.Rendeleseks)
                    .HasForeignKey(d => d.Tazon)
                    .HasConstraintName("rendelesek_ibfk_1");
            });

            modelBuilder.Entity<Termekek>(entity =>
            {
                entity.HasKey(e => e.Tazon)
                    .HasName("PRIMARY");

                entity.ToTable("termekek");

                entity.HasIndex(e => e.Kazon, "kazon");

                entity.Property(e => e.Tazon)
                    .HasColumnType("int(11)")
                    .HasColumnName("tazon");

                entity.Property(e => e.Ar)
                    .HasColumnType("int(11)")
                    .HasColumnName("ar");

                entity.Property(e => e.Elettartam)
                    .HasColumnType("int(11)")
                    .HasColumnName("elettartam");

                entity.Property(e => e.Fesz)
                    .HasColumnType("text")
                    .HasColumnName("fesz");

                entity.Property(e => e.Foglalat)
                    .HasColumnType("text")
                    .HasColumnName("foglalat");

                entity.Property(e => e.Kazon)
                    .HasColumnType("int(11)")
                    .HasColumnName("kazon");

                entity.Property(e => e.Telj).HasColumnName("telj");

                entity.Property(e => e.Tnev)
                    .HasColumnType("text")
                    .HasColumnName("tnev");

                entity.HasOne(d => d.KazonNavigation)
                    .WithMany(p => p.Termekeks)
                    .HasForeignKey(d => d.Kazon)
                    .HasConstraintName("termekek_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
