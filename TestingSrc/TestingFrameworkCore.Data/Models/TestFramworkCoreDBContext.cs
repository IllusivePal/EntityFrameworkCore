using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestingFrameworkCore.Data.Models
{
    public partial class TestFramworkCoreDBContext : DbContext
    {
        public virtual DbSet<ProductMaster> TProductMaster { get; set; }
        public virtual DbSet<TransactionDetailMaster> TTransactionDetailMaster { get; set; }
        public virtual DbSet<TransactionMaster> TTransactionMaster { get; set; }
        public virtual DbSet<UserMaster> TUserMaster { get; set; }
        public virtual DbSet<HistoryTable> HistoryTable { get; set; }
        public virtual DbSet<AuthIdentity> AuthIdentity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=ZYLUN-PC-0396\SQL2014;Database=TestingDataDB;user id=sa;password=systemadmin;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HistoryTable>().HasKey(s => new { s.UmtUserCode,s.PmtProductCode});
            modelBuilder.Entity<AuthIdentity>().HasKey(e => new { e.AuthCode });
          
            modelBuilder.Entity<ProductMaster>(entity =>
            {
                entity.HasKey(e => e.PmtProductCode)
                    .HasName("PK_T_ProductMaster");

                entity.ToTable("T_ProductMaster");

                entity.Property(e => e.PmtProductCode)
                    .HasColumnName("Pmt_ProductCode")
                    .HasColumnType("char(8)");

                entity.Property(e => e.PmtProductName)
                    .HasColumnName("Pmt_ProductName")
                    .HasColumnType("char(20)");

                entity.Property(e => e.PmtProductPrice)
                    .HasColumnName("Pmt_ProductPrice")
                    .HasColumnType("decimal");

                entity.Property(e => e.PmtProductQuantity).HasColumnName("Pmt_ProductQuantity");

                entity.Property(e=>e.ludatetime).HasColumnName("ludatetimes").HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasColumnName("Status")
                    .HasColumnType("char(1)");
            });

            modelBuilder.Entity<TransactionDetailMaster>(entity =>
            {
                entity.HasKey(e => e.TdmtTransactionDetailCode)
                    .HasName("PK_T_TransactionDetailMaster");

                entity.ToTable("T_TransactionDetailMaster");

                entity.Property(e => e.TdmtTransactionDetailCode)
                    .HasColumnName("Tdmt_TransactionDetailCode")
                    .HasColumnType("char(8)");

                entity.Property(e => e.TdmtDate)
                    .HasColumnName("Tdmt_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TdmtPrice)
                    .HasColumnName("Tdmt_Price")
                    .HasColumnType("decimal");

                entity.Property(e => e.TdmtProductCode)
                    .HasColumnName("Tdmt_ProductCode")
                    .HasColumnType("char(8)");

                entity.Property(e => e.TdmtQuantity)
                    .HasColumnName("Tdmt_Quantity")
                    .HasColumnType("decimal");

                entity.Property(e => e.TdmtStatus)
                    .HasColumnName("Tdmt_Status")
                    .HasColumnType("char(1)");

                entity.Property(e => e.TdmtTotalPayment)
                    .HasColumnName("Tdmt_TotalPayment")
                    .HasColumnType("decimal");

                entity.Property(e => e.TdmtTransactionCode)
                    .HasColumnName("Tdmt_TransactionCode")
                    .HasColumnType("char(8)");

                entity.HasOne(d => d.TdmtProductCodeNavigation)
                    .WithMany(p => p.TTransactionDetailMaster)
                    .HasForeignKey(d => d.TdmtProductCode)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_T_TransactionDetailMaster_T_TransactionMaster");
            });

            modelBuilder.Entity<TransactionMaster>(entity =>
            {
                entity.HasKey(e => e.TmtTransactionCode)
                    .HasName("PK_T_TransactionMaster");

                entity.ToTable("T_TransactionMaster");

                entity.Property(e => e.TmtTransactionCode)
                    .HasColumnName("Tmt_TransactionCode")
                    .HasColumnType("char(8)");

                entity.Property(e => e.TmtTransactionDate)
                    .HasColumnName("Tmt_TransactionDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TmtTransactionStatus)
                    .HasColumnName("Tmt_TransactionStatus")
                    .HasColumnType("char(1)");

                entity.Property(e => e.TmtUserCode)
                    .HasColumnName("Tmt_UserCode")
                    .HasColumnType("char(8)");

                entity.HasOne(d => d.TmtUserCodeNavigation)
                    .WithMany(p => p.TTransactionMaster)
                    .HasForeignKey(d => d.TmtUserCode)
                    .HasConstraintName("FK_T_TransactionMaster_T_UserMaster");

            });

            modelBuilder.Entity<UserMaster>(entity =>
            {
                entity.HasKey(e => e.UmtUserCode)
                    .HasName("PK_T_UserMaster");

                entity.ToTable("T_UserMaster");

                entity.Property(e => e.UmtUserCode)
                    .HasColumnName("Umt_UserCode")
                    .HasColumnType("char(8)");

                entity.Property(e => e.UmtEmail)
                    .HasColumnName("Umt_Email")
                    .HasColumnType("char(20)");

                entity.Property(e => e.UmtFirstName)
                    .HasColumnName("Umt_FirstName")
                    .HasColumnType("char(20)");

                entity.Property(e => e.UmtLastName)
                    .HasColumnName("Umt_LastName")
                    .HasColumnType("char(20)");

                entity.Property(e => e.UmtMiddleName)
                    .HasColumnName("Umt_MiddleName")
                    .HasColumnType("char(20)");

                entity.Property(e => e.UmtPassword)
                    .HasColumnName("Umt_Password")
                    .HasColumnType("char(20)");

                entity.Property(e => e.UmtStatus)
                    .HasColumnName("Umt_Status")
                    .HasColumnType("char(1)");

                entity.HasOne(e => e.AuthIdentity)
                      .WithOne(i => i.UserMaster)
                      .HasForeignKey<AuthIdentity>(b => b.UmtUserCode)
                      .HasConstraintName("FK_T_TransactionMaster_T_UserMaster");
            });
        }
    }
}