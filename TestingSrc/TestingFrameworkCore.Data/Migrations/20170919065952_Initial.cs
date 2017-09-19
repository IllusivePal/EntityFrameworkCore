using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestingFrameworkCore.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductMaster",
                columns: table => new
                {
                    Pmt_ProductCode = table.Column<string>(nullable: false),
                    Pmt_ProductName = table.Column<string>(nullable: true),
                    Pmt_ProductPrice = table.Column<decimal>(nullable: true),
                    Pmt_ProductQuantity = table.Column<int>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    ludatetime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMaster", x => x.Pmt_ProductCode);
                });

            migrationBuilder.CreateTable(
                name: "UserMaster",
                columns: table => new
                {
                    UmtUserCode = table.Column<string>(nullable: false),
                    UmtEmail = table.Column<string>(nullable: true),
                    UmtFirstName = table.Column<string>(nullable: true),
                    UmtLastName = table.Column<string>(nullable: true),
                    UmtMiddleName = table.Column<string>(nullable: true),
                    UmtPassword = table.Column<string>(nullable: true),
                    UmtStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMaster", x => x.UmtUserCode);
                });

            migrationBuilder.CreateTable(
                name: "ProductAccountCodeIdentityMaster",
                columns: table => new
                {
                    Pacmt_ProductCode = table.Column<string>(nullable: false),
                    Pacmt_Account = table.Column<int>(nullable: false),
                    Pacmt_Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAccountCodeIdentityMaster", x => x.Pacmt_ProductCode);
                    table.ForeignKey(
                        name: "FK_ProductAccountCodeIdentityMaster_ProductMaster_Pacmt_ProductCode",
                        column: x => x.Pacmt_ProductCode,
                        principalTable: "ProductMaster",
                        principalColumn: "Pmt_ProductCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionDetailMaster",
                columns: table => new
                {
                    Tdmt_TransactionDetailCode = table.Column<string>(nullable: false),
                    ProductMasterPmt_ProductCode = table.Column<string>(nullable: true),
                    Tdmt_Date = table.Column<DateTime>(nullable: true),
                    Tdmt_Price = table.Column<decimal>(nullable: true),
                    Tdmt_ProductCode = table.Column<string>(nullable: true),
                    Tdmt_Quantity = table.Column<decimal>(nullable: true),
                    Tdmt_Status = table.Column<string>(nullable: true),
                    Tdmt_TotalPayment = table.Column<decimal>(nullable: true),
                    Tdmt_TransactionCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionDetailMaster", x => x.Tdmt_TransactionDetailCode);
                    table.ForeignKey(
                        name: "FK_TransactionDetailMaster_ProductMaster_ProductMasterPmt_ProductCode",
                        column: x => x.ProductMasterPmt_ProductCode,
                        principalTable: "ProductMaster",
                        principalColumn: "Pmt_ProductCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthIdentityMaster",
                columns: table => new
                {
                    Amt_AuthCode = table.Column<string>(nullable: false),
                    Amt_AuthName = table.Column<string>(nullable: true),
                    Amt_UmtUserCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthIdentityMaster", x => x.Amt_AuthCode);
                    table.ForeignKey(
                        name: "FK_AuthIdentityMaster_UserMaster_Amt_UmtUserCode",
                        column: x => x.Amt_UmtUserCode,
                        principalTable: "UserMaster",
                        principalColumn: "UmtUserCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryTableMaster",
                columns: table => new
                {
                    Hmt_PmtProductCode = table.Column<string>(nullable: false),
                    Hmt_UmtUserCode = table.Column<string>(nullable: false),
                    Hmt_Description = table.Column<string>(nullable: true),
                    ProductMasterPmt_ProductCode = table.Column<string>(nullable: true),
                    UserMasterUmtUserCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryTableMaster", x => new { x.Hmt_PmtProductCode, x.Hmt_UmtUserCode });
                    table.ForeignKey(
                        name: "FK_HistoryTableMaster_ProductMaster_ProductMasterPmt_ProductCode",
                        column: x => x.ProductMasterPmt_ProductCode,
                        principalTable: "ProductMaster",
                        principalColumn: "Pmt_ProductCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryTableMaster_UserMaster_UserMasterUmtUserCode",
                        column: x => x.UserMasterUmtUserCode,
                        principalTable: "UserMaster",
                        principalColumn: "UmtUserCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionMaster",
                columns: table => new
                {
                    Tmt_TransactionCode = table.Column<string>(nullable: false),
                    Tmt_TransactionDate = table.Column<DateTime>(nullable: true),
                    Tmt_TransactionStatus = table.Column<string>(nullable: true),
                    Tmt_UserCode = table.Column<string>(nullable: true),
                    UserMasterUmtUserCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionMaster", x => x.Tmt_TransactionCode);
                    table.ForeignKey(
                        name: "FK_TransactionMaster_UserMaster_UserMasterUmtUserCode",
                        column: x => x.UserMasterUmtUserCode,
                        principalTable: "UserMaster",
                        principalColumn: "UmtUserCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthIdentityMaster_Amt_UmtUserCode",
                table: "AuthIdentityMaster",
                column: "Amt_UmtUserCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistoryTableMaster_ProductMasterPmt_ProductCode",
                table: "HistoryTableMaster",
                column: "ProductMasterPmt_ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryTableMaster_UserMasterUmtUserCode",
                table: "HistoryTableMaster",
                column: "UserMasterUmtUserCode");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetailMaster_ProductMasterPmt_ProductCode",
                table: "TransactionDetailMaster",
                column: "ProductMasterPmt_ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionMaster_UserMasterUmtUserCode",
                table: "TransactionMaster",
                column: "UserMasterUmtUserCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthIdentityMaster");

            migrationBuilder.DropTable(
                name: "HistoryTableMaster");

            migrationBuilder.DropTable(
                name: "ProductAccountCodeIdentityMaster");

            migrationBuilder.DropTable(
                name: "TransactionDetailMaster");

            migrationBuilder.DropTable(
                name: "TransactionMaster");

            migrationBuilder.DropTable(
                name: "ProductMaster");

            migrationBuilder.DropTable(
                name: "UserMaster");
        }
    }
}
