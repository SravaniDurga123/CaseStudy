using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CouponManagementDBEntity.Models
{
    public partial class CouponManagementContext : DbContext
    {
        public CouponManagementContext()
        {
        }

        public CouponManagementContext(DbContextOptions<CouponManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CouponDetails> CouponDetails { get; set; }
        public virtual DbSet<UserDetails> UserDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-KJSLJO5\SQLEXPRESS;Database=CouponManagement;
User Id=sa; Password=sravani;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CouponDetails>(entity =>
            {
                entity.HasKey(e => e.Couponid)
                    .HasName("PK__CouponDe__A2AE896C6298C2A4");

                entity.Property(e => e.Couponid)
                    .HasColumnName("couponid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Couponno)
                    .IsRequired()
                    .HasColumnName("couponno")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CouponDetails)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK__CouponDet__useri__173876EA");
            });

            modelBuilder.Entity<UserDetails>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK__UserDeta__CBA1B2578EF50044");

                entity.HasIndex(e => e.Emailid)
                    .HasName("UQ__UserDeta__8734520B6BDD9315")
                    .IsUnique();

                entity.HasIndex(e => e.Mobile)
                    .HasName("UQ__UserDeta__A32E2E1CA1572FB5")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("UQ__UserDeta__F3DBC57237B603B7")
                    .IsUnique();

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Emailid)
                    .IsRequired()
                    .HasColumnName("emailid")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasColumnName("mobile")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Registeredtime)
                    .HasColumnName("registeredtime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
