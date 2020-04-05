using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Abac.Web.Api.Infrastructure.Entities
{
    public partial class AbacDbContext : DbContext
    {
        public AbacDbContext()
        {
        }

        public AbacDbContext(DbContextOptions<AbacDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Colonist> Colonist { get; set; }
        public virtual DbSet<ColonistPlanet> ColonistPlanet { get; set; }
        public virtual DbSet<ColonistType> ColonistType { get; set; }
        public virtual DbSet<Planet> Planet { get; set; }
        public virtual DbSet<RoleType> RoleType { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Colonist>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Colonist)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Colonist_ColonistType");
            });

            modelBuilder.Entity<ColonistPlanet>(entity =>
            {
                entity.HasOne(d => d.Colonist)
                    .WithMany(p => p.ColonistPlanet)
                    .HasForeignKey(d => d.ColonistId)
                    .HasConstraintName("FK_ColonistPlanet_Colonist");

                entity.HasOne(d => d.Planet)
                    .WithMany(p => p.ColonistPlanet)
                    .HasForeignKey(d => d.PlanetId)
                    .HasConstraintName("FK_ColonistPlanet_Planet");
            });

            modelBuilder.Entity<ColonistType>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<Planet>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.ImageLink).HasMaxLength(300);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<RoleType>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.Token).HasMaxLength(200);

                entity.Property(e => e.TokenExpirationDate).HasColumnType("datetime");

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_UserRole_RoleType");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserRole_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
