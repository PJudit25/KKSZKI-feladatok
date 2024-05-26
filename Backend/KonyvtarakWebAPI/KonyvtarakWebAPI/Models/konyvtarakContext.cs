using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KonyvtarakWebAPI.Models
{
    public partial class konyvtarakContext : DbContext
    {
        public konyvtarakContext()
        {
        }

        public konyvtarakContext(DbContextOptions<konyvtarakContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Konyvtarak> Konyvtaraks { get; set; } = null!;
        public virtual DbSet<Megyek> Megyeks { get; set; } = null!;
        public virtual DbSet<Telepulesek> Telepuleseks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("SERVER=localhost;PORT=3306;DATABASE=konyvtarak;USER=root;PASSWORD=;SSL MODE=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Konyvtarak>(entity =>
            {
                entity.ToTable("konyvtarak");

                entity.HasIndex(e => e.Irsz, "fk_konyvtarTelepules");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Cim)
                    .HasMaxLength(36)
                    .HasColumnName("cim");

                entity.Property(e => e.Irsz)
                    .HasMaxLength(4)
                    .HasColumnName("irsz");

                entity.Property(e => e.KonyvtarNev)
                    .HasMaxLength(200)
                    .HasColumnName("konyvtarNev");

                entity.HasOne(d => d.IrszNavigation)
                    .WithMany(p => p.Konyvtaraks)
                    .HasForeignKey(d => d.Irsz)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_konyvtarTelepules");
            });

            modelBuilder.Entity<Megyek>(entity =>
            {
                entity.ToTable("megyek");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.MegyeNev)
                    .HasMaxLength(22)
                    .HasColumnName("megyeNev");
            });

            modelBuilder.Entity<Telepulesek>(entity =>
            {
                entity.HasKey(e => e.Irsz)
                    .HasName("PRIMARY");

                entity.ToTable("telepulesek");

                entity.HasIndex(e => e.MegyeId, "fk_telepulesMegye");

                entity.Property(e => e.Irsz)
                    .HasMaxLength(4)
                    .HasColumnName("irsz");

                entity.Property(e => e.MegyeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("megyeId");

                entity.Property(e => e.TelepNev)
                    .HasMaxLength(19)
                    .HasColumnName("telepNev");

                entity.HasOne(d => d.Megye)
                    .WithMany(p => p.Telepuleseks)
                    .HasForeignKey(d => d.MegyeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_telepulesMegye");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
