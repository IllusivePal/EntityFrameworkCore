using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ScaffoldFromData
{
    public partial class SamuraiDataContext : DbContext
    {
        public virtual DbSet<Battle> Battles { get; set; }
        public virtual DbSet<Quotes> Quotes { get; set; }
        public virtual DbSet<SamuraiBattle> SamuraiBattle { get; set; }
        public virtual DbSet<Samurai> Samurais { get; set; }
        public virtual DbSet<SecretIdentity> SecretIdentity { get; set; }
        public virtual DbSet<TestingTable> TestingTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.UseSqlServer(@"Server=ZYLUN-PC-0396\SQL2014;Database=SamuraiData;user id=sa;password=systemadmin");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quotes>(entity =>
            {
                entity.HasIndex(e => e.SamuraiId)
                    .HasName("IX_Quotes_SamuraiId");

                entity.HasOne(d => d.Samurai)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.SamuraiId);
            });

            modelBuilder.Entity<SamuraiBattle>(entity =>
            {
                entity.HasKey(e => new { e.BattleId, e.SamuraiId })
                    .HasName("PK_SamuraiBattle");

                entity.HasIndex(e => e.SamuraiId)
                    .HasName("IX_SamuraiBattle_SamuraiId");

                entity.HasOne(d => d.Battle)
                    .WithMany(p => p.SamuraiBattle)
                    .HasForeignKey(d => d.BattleId);

                entity.HasOne(d => d.Samurai)
                    .WithMany(p => p.SamuraiBattle)
                    .HasForeignKey(d => d.SamuraiId);
            });

            modelBuilder.Entity<SecretIdentity>(entity =>
            {
                entity.HasIndex(e => e.SamuraiId)
                    .HasName("IX_SecretIdentity_SamuraiId")
                    .IsUnique();

                entity.HasOne(d => d.Samurai)
                    .WithOne(p => p.SecretIdentity)
                    .HasForeignKey<SecretIdentity>(d => d.SamuraiId);
            });

            modelBuilder.Entity<TestingTable>(entity =>
            {
                entity.Property(e => e.Names).HasColumnName("names");
            });
        }
    }
}