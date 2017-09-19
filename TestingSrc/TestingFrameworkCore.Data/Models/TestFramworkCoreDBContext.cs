using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestingFrameworkCore.Data.Models
{
    public partial class TestFramworkCoreDBContext : DbContext
    {
        public virtual DbSet<ProductMaster> ProductMaster { get; set; }
        public virtual DbSet<TransactionDetailMaster> TransactionDetailMaster { get; set; }
        public virtual DbSet<TransactionMaster> TransactionMaster { get; set; }
        public virtual DbSet<UserMaster> UserMaster { get; set; }
        public virtual DbSet<HistoryTableMaster> HistoryTableMaster { get; set; }
        public virtual DbSet<AuthIdentityMaster> AuthIdentityMaster { get; set; }
        public virtual DbSet<ProductAccountCodeIdentityMaster> ProductAccountCodeIdentityMaster { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=ZYLUN-PC-0396\SQL2014;Database=TestingDataDB;user id=sa;password=systemadmin;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AuthIdentityMaster>().ToTable("AuthIdentityUserMasters");
            modelBuilder.Entity<HistoryTableMaster>().ToTable("HistoryTableMaster");
            modelBuilder.Entity<ProductAccountCodeIdentityMaster>().ToTable("ProductAccountCodeIdentityMaster");

            modelBuilder.Entity<AuthIdentityMaster>(entity=> {
                entity.HasKey(e => new { e.Amt_AuthCode});
                
            });
            modelBuilder.Entity<HistoryTableMaster>(entity=> {
                entity.HasKey(e => new { e.Hmt_PmtProductCode, e.Hmt_UmtUserCode });
                
            });
            modelBuilder.Entity<ProductAccountCodeIdentityMaster>(entity=> {
                entity.HasKey(a => new { a.Pacmt_ProductCode });
            });
            modelBuilder.Entity<TransactionDetailMaster>().HasKey(a=> new { a.Tdmt_TransactionDetailCode});
            modelBuilder.Entity<TransactionMaster>().HasKey(a => new { a.Tmt_TransactionCode });

            modelBuilder.Entity<UserMaster>(entity =>
            {
                entity.HasKey(a => a.UmtUserCode);
                entity.HasOne(a => a.AuthIdentityMaster)
                    .WithOne(b => b.UserMaster)
                    .HasForeignKey<AuthIdentityMaster>(c => c.Amt_UmtUserCode)
                    .OnDelete(DeleteBehavior.Cascade);
                    
            });



            modelBuilder.Entity<ProductMaster>(entity =>
            {
                entity.HasKey(b => b.Pmt_ProductCode);
                entity.HasOne(a => a.ProductAccountCodeIdentityMaster)
                    .WithOne(b => b.ProductMaster)
                    .HasForeignKey<ProductAccountCodeIdentityMaster>(c => c.Pacmt_ProductCode)
                    .OnDelete(DeleteBehavior.Cascade);
                    

            });
          


        }
    }
}