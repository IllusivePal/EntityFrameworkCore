using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TestingFrameworkCore.Data.Models;

namespace TestingFrameworkCore.Data.Migrations
{
    [DbContext(typeof(TestFramworkCoreDBContext))]
    partial class TestFramworkCoreDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestingFrameworkCore.Data.Models.AuthIdentity", b =>
                {
                    b.Property<string>("AuthCode")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthName");

                    b.Property<string>("UmtUserCode");

                    b.HasKey("AuthCode");

                    b.HasIndex("UmtUserCode")
                        .IsUnique();

                    b.ToTable("AuthIdentity");
                });

            modelBuilder.Entity("TestingFrameworkCore.Data.Models.HistoryTable", b =>
                {
                    b.Property<string>("UmtUserCode");

                    b.Property<string>("PmtProductCode");

                    b.Property<string>("Description");

                    b.HasKey("UmtUserCode", "PmtProductCode");

                    b.HasIndex("PmtProductCode");

                    b.ToTable("HistoryTable");
                });

            modelBuilder.Entity("TestingFrameworkCore.Data.Models.ProductMaster", b =>
                {
                    b.Property<string>("PmtProductCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Pmt_ProductCode")
                        .HasColumnType("char(8)");

                    b.Property<string>("PmtProductName")
                        .HasColumnName("Pmt_ProductName")
                        .HasColumnType("char(20)");

                    b.Property<decimal?>("PmtProductPrice")
                        .HasColumnName("Pmt_ProductPrice")
                        .HasColumnType("decimal");

                    b.Property<int?>("PmtProductQuantity")
                        .HasColumnName("Pmt_ProductQuantity");

                    b.Property<string>("Status")
                        .HasColumnName("Status")
                        .HasColumnType("char(1)");

                    b.Property<DateTime>("ludatetime")
                        .HasColumnName("ludatetimes")
                        .HasColumnType("datetime");

                    b.HasKey("PmtProductCode")
                        .HasName("PK_T_ProductMaster");

                    b.ToTable("T_ProductMaster");
                });

            modelBuilder.Entity("TestingFrameworkCore.Data.Models.TransactionDetailMaster", b =>
                {
                    b.Property<string>("TdmtTransactionDetailCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Tdmt_TransactionDetailCode")
                        .HasColumnType("char(8)");

                    b.Property<DateTime?>("TdmtDate")
                        .HasColumnName("Tdmt_Date")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("TdmtPrice")
                        .HasColumnName("Tdmt_Price")
                        .HasColumnType("decimal");

                    b.Property<string>("TdmtProductCode")
                        .HasColumnName("Tdmt_ProductCode")
                        .HasColumnType("char(8)");

                    b.Property<decimal?>("TdmtQuantity")
                        .HasColumnName("Tdmt_Quantity")
                        .HasColumnType("decimal");

                    b.Property<string>("TdmtStatus")
                        .HasColumnName("Tdmt_Status")
                        .HasColumnType("char(1)");

                    b.Property<decimal?>("TdmtTotalPayment")
                        .HasColumnName("Tdmt_TotalPayment")
                        .HasColumnType("decimal");

                    b.Property<string>("TdmtTransactionCode")
                        .HasColumnName("Tdmt_TransactionCode")
                        .HasColumnType("char(8)");

                    b.HasKey("TdmtTransactionDetailCode")
                        .HasName("PK_T_TransactionDetailMaster");

                    b.HasIndex("TdmtProductCode");

                    b.ToTable("T_TransactionDetailMaster");
                });

            modelBuilder.Entity("TestingFrameworkCore.Data.Models.TransactionMaster", b =>
                {
                    b.Property<string>("TmtTransactionCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Tmt_TransactionCode")
                        .HasColumnType("char(8)");

                    b.Property<DateTime?>("TmtTransactionDate")
                        .HasColumnName("Tmt_TransactionDate")
                        .HasColumnType("datetime");

                    b.Property<string>("TmtTransactionStatus")
                        .HasColumnName("Tmt_TransactionStatus")
                        .HasColumnType("char(1)");

                    b.Property<string>("TmtUserCode")
                        .HasColumnName("Tmt_UserCode")
                        .HasColumnType("char(8)");

                    b.HasKey("TmtTransactionCode")
                        .HasName("PK_T_TransactionMaster");

                    b.HasIndex("TmtUserCode");

                    b.ToTable("T_TransactionMaster");
                });

            modelBuilder.Entity("TestingFrameworkCore.Data.Models.UserMaster", b =>
                {
                    b.Property<string>("UmtUserCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Umt_UserCode")
                        .HasColumnType("char(8)");

                    b.Property<string>("UmtEmail")
                        .HasColumnName("Umt_Email")
                        .HasColumnType("char(20)");

                    b.Property<string>("UmtFirstName")
                        .HasColumnName("Umt_FirstName")
                        .HasColumnType("char(20)");

                    b.Property<string>("UmtLastName")
                        .HasColumnName("Umt_LastName")
                        .HasColumnType("char(20)");

                    b.Property<string>("UmtMiddleName")
                        .HasColumnName("Umt_MiddleName")
                        .HasColumnType("char(20)");

                    b.Property<string>("UmtPassword")
                        .HasColumnName("Umt_Password")
                        .HasColumnType("char(20)");

                    b.Property<string>("UmtStatus")
                        .HasColumnName("Umt_Status")
                        .HasColumnType("char(1)");

                    b.HasKey("UmtUserCode")
                        .HasName("PK_T_UserMaster");

                    b.ToTable("T_UserMaster");
                });

            modelBuilder.Entity("TestingFrameworkCore.Data.Models.AuthIdentity", b =>
                {
                    b.HasOne("TestingFrameworkCore.Data.Models.UserMaster", "UserMaster")
                        .WithOne("AuthIdentity")
                        .HasForeignKey("TestingFrameworkCore.Data.Models.AuthIdentity", "UmtUserCode")
                        .HasConstraintName("FK_T_TransactionMaster_T_UserMaster");
                });

            modelBuilder.Entity("TestingFrameworkCore.Data.Models.HistoryTable", b =>
                {
                    b.HasOne("TestingFrameworkCore.Data.Models.ProductMaster", "ProductMaster")
                        .WithMany("HistoryTables")
                        .HasForeignKey("PmtProductCode")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestingFrameworkCore.Data.Models.UserMaster", "UserMaster")
                        .WithMany("HistoryTables")
                        .HasForeignKey("UmtUserCode")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestingFrameworkCore.Data.Models.TransactionDetailMaster", b =>
                {
                    b.HasOne("TestingFrameworkCore.Data.Models.ProductMaster", "TdmtProductCodeNavigation")
                        .WithMany("TTransactionDetailMaster")
                        .HasForeignKey("TdmtProductCode")
                        .HasConstraintName("FK_T_TransactionDetailMaster_T_TransactionMaster")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestingFrameworkCore.Data.Models.TransactionMaster", b =>
                {
                    b.HasOne("TestingFrameworkCore.Data.Models.UserMaster", "TmtUserCodeNavigation")
                        .WithMany("TTransactionMaster")
                        .HasForeignKey("TmtUserCode");
                });
        }
    }
}
