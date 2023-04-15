using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WpfApp15.Classess;

namespace WpfApp15
{
    public partial class EfModel : DbContext
    {
        private static EfModel Instance;
        public static EfModel Init()
        {
            if (Instance == null)
                Instance = new EfModel();
            return Instance;
        }
        public EfModel()
        {
        }

        public EfModel(DbContextOptions<EfModel> options)
            : base(options)
        {
        }

        public virtual DbSet<Doljnosti> Doljnostis { get; set; } = null!;
        public virtual DbSet<DopUslov> DopUslovs { get; set; } = null!;
        public virtual DbSet<Smena> Smenas { get; set; } = null!;
        public virtual DbSet<Sotrudniki> Sotrudnikis { get; set; } = null!;
        public virtual DbSet<Stavka> Stavkas { get; set; } = null!;
        public virtual DbSet<TypeUslov> TypeUslovs { get; set; } = null!;
        public virtual DbSet<Zona> Zonas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=cfif31.ru;port=3306;user id=ISPr22-43_NekrasovAI;password=ISPr22-43_NekrasovAI;database=ISPr22-43_NekrasovAI_BDDop;character set=utf8", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Doljnosti>(entity =>
            {
                entity.HasKey(e => e.IdDoljnosti)
                    .HasName("PRIMARY");

                entity.ToTable("Doljnosti");

                entity.Property(e => e.Doljns).HasMaxLength(60);
            });

            modelBuilder.Entity<DopUslov>(entity =>
            {
                entity.HasKey(e => e.IdDopUslov)
                    .HasName("PRIMARY");

                entity.ToTable("DopUslov");

                entity.HasIndex(e => e.Type, "Type_idx");

                entity.Property(e => e.Summa).HasPrecision(10, 2);

                entity.Property(e => e.Uslov).HasMaxLength(45);

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.DopUslovs)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Type");
            });

            modelBuilder.Entity<Smena>(entity =>
            {
                entity.HasKey(e => e.IdSmena)
                    .HasName("PRIMARY");

                entity.ToTable("Smena");

                entity.Property(e => e.Time).HasMaxLength(45);

                entity.Property(e => e.Type).HasMaxLength(45);
            });

            modelBuilder.Entity<Sotrudniki>(entity =>
            {
                entity.HasKey(e => e.IdSotrudniki)
                    .HasName("PRIMARY");

                entity.ToTable("Sotrudniki");

                entity.HasIndex(e => e.Doljn, "Doljn_idx");

                entity.HasIndex(e => e.Smena, "Smena_idx");

                entity.HasIndex(e => e.TipStavki, "TipStav_idx");

                entity.HasIndex(e => e.Zona, "Zona_idx");

                entity.Property(e => e.FirstName).HasMaxLength(60);

                entity.Property(e => e.Patronimyc).HasMaxLength(60);

                entity.Property(e => e.SecondName).HasMaxLength(60);

                entity.Property(e => e.Stavka).HasPrecision(10, 2);

                entity.HasOne(d => d.DoljnNavigation)
                    .WithMany(p => p.Sotrudnikis)
                    .HasForeignKey(d => d.Doljn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Doljn");

                entity.HasOne(d => d.SmenaNavigation)
                    .WithMany(p => p.Sotrudnikis)
                    .HasForeignKey(d => d.Smena)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Smena");

                entity.HasOne(d => d.TipStavkiNavigation)
                    .WithMany(p => p.Sotrudnikis)
                    .HasForeignKey(d => d.TipStavki)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TipStav");

                entity.HasOne(d => d.ZonaNavigation)
                    .WithMany(p => p.Sotrudnikis)
                    .HasForeignKey(d => d.Zona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zona");
            });

            modelBuilder.Entity<Stavka>(entity =>
            {
                entity.HasKey(e => e.IdStavka)
                    .HasName("PRIMARY");

                entity.ToTable("Stavka");

                entity.Property(e => e.Type).HasMaxLength(45);
            });

            modelBuilder.Entity<TypeUslov>(entity =>
            {
                entity.HasKey(e => e.IdTypeUslov)
                    .HasName("PRIMARY");

                entity.ToTable("TypeUslov");

                entity.Property(e => e.Type).HasMaxLength(45);
            });

            modelBuilder.Entity<Zona>(entity =>
            {
                entity.HasKey(e => e.IdZona)
                    .HasName("PRIMARY");

                entity.ToTable("Zona");

                entity.Property(e => e.Zona1)
                    .HasMaxLength(45)
                    .HasColumnName("Zona");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
