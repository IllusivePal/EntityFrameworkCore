using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestingFrameworkCore.Data.Migrations
{
    public partial class ChangeProductModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_ProductMaster",
                columns: table => new
                {
                    Pmt_ProductCode = table.Column<string>(type: "char(8)", nullable: false),
                    Pmt_ProductName = table.Column<string>(type: "char(20)", nullable: true),
                    Pmt_ProductPrice = table.Column<decimal>(type: "decimal", nullable: true),
                    Pmt_ProductQuantity = table.Column<int>(nullable: true),
                    Pmt_Status = table.Column<string>(type: "char(1)", nullable: true),
                    ludatetime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ProductMaster", x => x.Pmt_ProductCode);
                });

            migrationBuilder.CreateTable(
                name: "T_UserMaster",
                columns: table => new
                {
                    Umt_UserCode = table.Column<string>(type: "char(8)", nullable: false),
                    Umt_Email = table.Column<string>(type: "char(20)", nullable: true),
                    Umt_FirstName = table.Column<string>(type: "char(20)", nullable: true),
                    Umt_LastName = table.Column<string>(type: "char(20)", nullable: true),
                    Umt_MiddleName = table.Column<string>(type: "char(20)", nullable: true),
                    Umt_Password = table.Column<string>(type: "char(20)", nullable: true),
                    Umt_Status = table.Column<string>(type: "char(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_UserMaster", x => x.Umt_UserCode);
                });

            migrationBuilder.CreateTable(
                name: "T_TransactionDetailMaster",
                columns: table => new
                {
                    Tdmt_TransactionDetailCode = table.Column<string>(type: "char(8)", nullable: false),
                    Tdmt_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Tdmt_Price = table.Column<decimal>(type: "decimal", nullable: true),
                    Tdmt_ProductCode = table.Column<string>(type: "char(8)", nullable: true),
                    Tdmt_Quantity = table.Column<decimal>(type: "decimal", nullable: true),
                    Tdmt_Status = table.Column<string>(type: "char(1)", nullable: true),
                    Tdmt_TotalPayment = table.Column<decimal>(type: "decimal", nullable: true),
                    Tdmt_TransactionCode = table.Column<string>(type: "char(8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_TransactionDetailMaster", x => x.Tdmt_TransactionDetailCode);
                    table.ForeignKey(
                        name: "FK_T_TransactionDetailMaster_T_TransactionMaster",
                        column: x => x.Tdmt_ProductCode,
                        principalTable: "T_ProductMaster",
                        principalColumn: "Pmt_ProductCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_TransactionMaster",
                columns: table => new
                {
                    Tmt_TransactionCode = table.Column<string>(type: "char(8)", nullable: false),
                    Tmt_TransactionDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Tmt_TransactionStatus = table.Column<string>(type: "char(1)", nullable: true),
                    Tmt_UserCode = table.Column<string>(type: "char(8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_TransactionMaster", x => x.Tmt_TransactionCode);
                    table.ForeignKey(
                        name: "FK_T_TransactionMaster_T_UserMaster_Tmt_UserCode",
                        column: x => x.Tmt_UserCode,
                        principalTable: "T_UserMaster",
                        principalColumn: "Umt_UserCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_TransactionDetailMaster_Tdmt_ProductCode",
                table: "T_TransactionDetailMaster",
                column: "Tdmt_ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_T_TransactionMaster_Tmt_UserCode",
                table: "T_TransactionMaster",
                column: "Tmt_UserCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_TransactionDetailMaster");

            migrationBuilder.DropTable(
                name: "T_TransactionMaster");

            migrationBuilder.DropTable(
                name: "T_ProductMaster");

            migrationBuilder.DropTable(
                name: "T_UserMaster");
        }
    }
}
