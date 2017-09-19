using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TestingFrameworkCore.Data.Models;

namespace TestingFrameworkCore.Data.Migrations
{
    [DbContext(typeof(TestFramworkCoreDBContext))]
    [Migration("20170919071835_RenamedIdentityUserTable")]
    partial class RenamedIdentityUserTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestingFrameworkCore.Data.Models.AuthIdentityMaster", b =>
                {
                    b.Property<string>("Amt_AuthCode")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Amt_AuthName");

                    b.Property<string>("Amt_UmtUserCode");

                    b.HasKey("Amt_AuthCode");

                    b.HasIndex("Amt_UmtUserCode")
                        .IsUnique();

                    b.ToTable("AuthIdentityUserMasters");
                });

            modelBuilder.Entity("TestingFrameworkCore.Data.Models.HistoryTableMaster", b =>
                {
                    b.Property<string>("Hmt_PmtProductCode");

                    b.Property<string>("Hmt_UmtUserCode");

                    b.Property<string>("Hmt_Description");

                    b.Property<string>("ProductMasterPmt_ProductCode");

                    b.Property<string>("UserMasterUmtUserCode");

                    b.HasKey("Hmt_PmtProductCode", "Hmt_UmtUserCode");

                    b.HasIndex("ProductMasterPmt_ProductCode");

                    b.HasIndex("UserMasterUmtUserCode");

                    b.ToTable("HistoryTableMaster");
                });

            modelBuilder.Entity("TestingFrameworkCore.Data.Models.ProductAccountCodeIdentityMaster", b =>
                {
                    b.Property<string>("Pacmt_ProductCode");

                    b.Property<int>("Pacmt_Account");

                    b.Property<string>("Pacmt_Description");

                    b.HasKey("Pacmt_ProductCode");

                    b.ToTable("ProductAccountCodeIdentityMaster");
                });

            modelBuilder.Entity("TestingFrameworkCore.Data.Models.ProductMaster", b =>
                {
                    b.Property<string>("Pmt_ProductCode")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Pmt_ProductName");

                    b.Property<decimal?>("Pmt_ProductPrice");

                    b.Property<int?>("Pmt_ProductQuantity");

                    b.Property<string>("Status");

                    b.Property<DateTime>("ludatetime");

                    b.HasKey("Pmt_ProductCode");

                    b.ToTable("ProductMaster");
                });

            modelBuilder.Entity("TestingFrameworkCore.Data.Models.TransactionDetailMaster", b =>
                {
                    b.Property<string>("Tdmt_TransactionDetailCode")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ProductMasterPmt_ProductCode");

                    b.Property<DateTime?>("Tdmt_Date");

                    b.Property<decimal?>("Tdmt_Price");

                    b.Property<string>("Tdmt_ProductCode");

                    b.Property<decimal?>("Tdmt_Quantity");

                    b.Property<string>("Tdmt_Status");

                    b.Property<decimal?>("Tdmt_TotalPayment");

                    b.Property<string>("Tdmt_TransactionCode");

                    b.HasKey("Tdmt_TransactionDetailCode");

                    b.HasIndex("ProductMasterPmt_ProductCode");

                    b.ToTable("TransactionDetailMaster");
                });

            modelBuilder.Entity("TestingFrameworkCore.Data.Models.TransactionMaster", b =>
                {
                    b.Property<string>("Tmt_TransactionCode")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Tmt_TransactionDate");

                    b.Property<string>("Tmt_TransactionStatus");

                    b.Property<string>("Tmt_UserCode");

                    b.Property<string>("UserMasterUmtUserCode");

                    b.HasKey("Tmt_TransactionCode");

                    b.HasIndex("UserMasterUmtUserCode");

                    b.ToTable("TransactionMaster");
                });

            modelBuilder.Entity("TestingFrameworkCore.Data.Models.UserMaster", b =>
                {
                    b.Property<string>("UmtUserCode")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UmtEmail");

                    b.Property<string>("UmtFirstName");

                    b.Property<string>("UmtMiddleName");

                    b.Property<string>("UmtPassword");

                    b.Property<string>("UmtStatus");

                    b.Property<string>("Umt_Gender");

                    b.Property<string>("Umt_UserLastName");

                    b.HasKey("UmtUserCode");

                    b.ToTable("UserMaster");
                });

            modelBuilder.Entity("TestingFrameworkCore.Data.Models.AuthIdentityMaster", b =>
                {
                    b.HasOne("TestingFrameworkCore.Data.Models.UserMaster", "UserMaster")
                        .WithOne("AuthIdentityMaster")
                        .HasForeignKey("TestingFrameworkCore.Data.Models.AuthIdentityMaster", "Amt_UmtUserCode")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestingFrameworkCore.Data.Models.HistoryTableMaster", b =>
                {
                    b.HasOne("TestingFrameworkCore.Data.Models.ProductMaster", "ProductMaster")
                        .WithMany("HistoryTableMaster")
                        .HasForeignKey("ProductMasterPmt_ProductCode");

                    b.HasOne("TestingFrameworkCore.Data.Models.UserMaster", "UserMaster")
                        .WithMany("HistoryTables")
                        .HasForeignKey("UserMasterUmtUserCode");
                });

            modelBuilder.Entity("TestingFrameworkCore.Data.Models.ProductAccountCodeIdentityMaster", b =>
                {
                    b.HasOne("TestingFrameworkCore.Data.Models.ProductMaster", "ProductMaster")
                        .WithOne("ProductAccountCodeIdentityMaster")
                        .HasForeignKey("TestingFrameworkCore.Data.Models.ProductAccountCodeIdentityMaster", "Pacmt_ProductCode")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestingFrameworkCore.Data.Models.TransactionDetailMaster", b =>
                {
                    b.HasOne("TestingFrameworkCore.Data.Models.ProductMaster", "ProductMaster")
                        .WithMany("TransactionDetailMaster")
                        .HasForeignKey("ProductMasterPmt_ProductCode");
                });

            modelBuilder.Entity("TestingFrameworkCore.Data.Models.TransactionMaster", b =>
                {
                    b.HasOne("TestingFrameworkCore.Data.Models.UserMaster", "UserMaster")
                        .WithMany("TTransactionMaster")
                        .HasForeignKey("UserMasterUmtUserCode");
                });
        }
    }
}
