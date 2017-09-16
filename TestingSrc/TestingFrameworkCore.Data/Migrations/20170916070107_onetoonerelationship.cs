using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestingFrameworkCore.Data.Migrations
{
    public partial class onetoonerelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthIdentity_T_ProductMaster_PmtProductCode",
                table: "AuthIdentity");

            migrationBuilder.RenameColumn(
                name: "PmtProductCode",
                table: "AuthIdentity",
                newName: "UmtUserCode");

            migrationBuilder.RenameIndex(
                name: "IX_AuthIdentity_PmtProductCode",
                table: "AuthIdentity",
                newName: "IX_AuthIdentity_UmtUserCode");

            migrationBuilder.AddForeignKey(
                name: "FK_T_TransactionMaster_T_UserMaster",
                table: "AuthIdentity",
                column: "UmtUserCode",
                principalTable: "T_UserMaster",
                principalColumn: "Umt_UserCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_TransactionMaster_T_UserMaster",
                table: "AuthIdentity");

            migrationBuilder.RenameColumn(
                name: "UmtUserCode",
                table: "AuthIdentity",
                newName: "PmtProductCode");

            migrationBuilder.RenameIndex(
                name: "IX_AuthIdentity_UmtUserCode",
                table: "AuthIdentity",
                newName: "IX_AuthIdentity_PmtProductCode");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthIdentity_T_ProductMaster_PmtProductCode",
                table: "AuthIdentity",
                column: "PmtProductCode",
                principalTable: "T_ProductMaster",
                principalColumn: "Pmt_ProductCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
