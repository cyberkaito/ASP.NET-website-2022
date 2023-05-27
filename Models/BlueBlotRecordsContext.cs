using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlueBlotRecords.Models
{
    public partial class BlueBlotRecordsContext : DbContext
    {
        public BlueBlotRecordsContext()
        {
        }

        public BlueBlotRecordsContext(DbContextOptions<BlueBlotRecordsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Band> Bands { get; set; } = null!;
        public virtual DbSet<BandArea> BandAreas { get; set; } = null!;
        public virtual DbSet<BandSubscriber> BandSubscribers { get; set; } = null!;
        public virtual DbSet<BasketItem> BasketItems { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<SubGenre> SubGenres { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Band>(entity =>
            {
                entity.HasKey(e => e.IdBand)
                    .HasName("PK_Band");

                entity.HasIndex(e => e.Mail, "UQ_Mail")
                    .IsUnique();

                entity.HasIndex(e => e.NumberPhone, "UQ_Number_Phone")
                    .IsUnique();

                entity.Property(e => e.IdBand).HasColumnName("ID_Band");

                entity.Property(e => e.Bio).IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FormedIn)
                    .HasColumnType("date")
                    .HasColumnName("Formed_In");

                entity.Property(e => e.Mail)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.MembersBand)
                    .IsUnicode(false)
                    .HasColumnName("Members_Band");

                entity.Property(e => e.NameBand)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("Name_Band");

                entity.Property(e => e.NumberPhone)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("Number_Phone");

                entity.Property(e => e.PasswordBand)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("Password_Band");
            });

            modelBuilder.Entity<BandArea>(entity =>
            {
                entity.HasKey(e => e.IdBandArea);

                entity.ToTable("Band_Area");

                entity.Property(e => e.IdBandArea).HasColumnName("ID_Band_Area");

                entity.Property(e => e.IdBand).HasColumnName("ID_Band");

                entity.Property(e => e.IdGenre).HasColumnName("ID_Genre");

                entity.Property(e => e.IdSubgenre).HasColumnName("ID_Subgenre");

                entity.HasOne(d => d.IdBandNavigation)
                    .WithMany(p => p.BandAreas)
                    .HasForeignKey(d => d.IdBand)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Band_ID");

                entity.HasOne(d => d.IdGenreNavigation)
                    .WithMany(p => p.BandAreas)
                    .HasForeignKey(d => d.IdGenre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Genre_ID");

                entity.HasOne(d => d.IdSubgenreNavigation)
                    .WithMany(p => p.BandAreas)
                    .HasForeignKey(d => d.IdSubgenre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subgenre_ID");
            });

            modelBuilder.Entity<BandSubscriber>(entity =>
            {
                entity.HasKey(e => e.IdSub)
                    .HasName("PK_Sub");

                entity.ToTable("Band_Subscribers");

                entity.HasIndex(e => e.Mail, "UQ_Mail_Sub")
                    .IsUnique();

                entity.Property(e => e.IdSub).HasColumnName("ID_Sub");

                entity.Property(e => e.IdBand).HasColumnName("ID_Band");

                entity.Property(e => e.Mail)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBandNavigation)
                    .WithMany(p => p.BandSubscribers)
                    .HasForeignKey(d => d.IdBand)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_Band_Sub");
            });

            modelBuilder.Entity<BasketItem>(entity =>
            {
                entity.HasKey(e => e.IdBasketItem);

                entity.ToTable("Basket_Item");

                entity.Property(e => e.IdBasketItem).HasColumnName("ID_Basket_Item");

                entity.Property(e => e.IdBand).HasColumnName("ID_Band");

                entity.Property(e => e.IdService).HasColumnName("ID_Service");

                entity.HasOne(d => d.IdBandNavigation)
                    .WithMany(p => p.BasketItems)
                    .HasForeignKey(d => d.IdBand)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_Band_Basket");

                entity.HasOne(d => d.IdServiceNavigation)
                    .WithMany(p => p.BasketItems)
                    .HasForeignKey(d => d.IdService)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_Service");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.IdGenre)
                    .HasName("PK_Genre");

                entity.HasIndex(e => e.NameGenre, "UQ_Name_Genre")
                    .IsUnique();

                entity.Property(e => e.IdGenre).HasColumnName("ID_Genre");

                entity.Property(e => e.NameGenre)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("Name_Genre");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("PK_ID_Order");

                entity.Property(e => e.IdOrder).HasColumnName("ID_Order");

                entity.Property(e => e.DateExpired)
                    .HasColumnType("date")
                    .HasColumnName("Date_Expired");

                entity.Property(e => e.FormationDate)
                    .HasColumnType("date")
                    .HasColumnName("Formation_Date");

                entity.Property(e => e.IdBasketItem).HasColumnName("ID_Basket_Item");

                entity.HasOne(d => d.IdBasketItemNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdBasketItem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_Basket");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.IdService)
                    .HasName("PK_Service");

                entity.HasIndex(e => e.Name, "UQ_Name")
                    .IsUnique();

                entity.Property(e => e.IdService).HasColumnName("ID_Service");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(38, 1)");
            });

            modelBuilder.Entity<SubGenre>(entity =>
            {
                entity.HasKey(e => e.IdSubgenre)
                    .HasName("PK_Subgenre");

                entity.HasIndex(e => e.NameSubgenre, "UQ_Name_Subgenre")
                    .IsUnique();

                entity.Property(e => e.IdSubgenre).HasColumnName("ID_Subgenre");

                entity.Property(e => e.NameSubgenre)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("Name_Subgenre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
