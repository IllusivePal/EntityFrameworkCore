using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestingFrameworkCore.Data.Migrations
{
    public partial class RenamedIdentityUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthIdentityMaster_UserMaster_Amt_UmtUserCode",
                table: "AuthIdentityMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthIdentityMaster",
                table: "AuthIdentityMaster");

            migrationBuilder.RenameTable(
                name: "AuthIdentityMaster",
                newName: "AuthIdentityUserMasters");

            migrationBuilder.RenameIndex(
                name: "IX_AuthIdentityMaster_Amt_UmtUserCode",
                table: "AuthIdentityUserMasters",
                newName: "IX_AuthIdentityUserMasters_Amt_UmtUserCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthIdentityUserMasters",
                table: "AuthIdentityUserMasters",
                column: "Amt_AuthCode");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthIdentityUserMasters_UserMaster_Amt_UmtUserCode",
                table: "AuthIdentityUserMasters",
                column: "Amt_UmtUserCode",
                principalTable: "UserMaster",
                principalColumn: "UmtUserCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthIdentityUserMasters_UserMaster_Amt_UmtUserCode",
                table: "AuthIdentityUserMasters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthIdentityUserMasters",
                table: "AuthIdentityUserMasters");

            migrationBuilder.RenameTable(
                name: "AuthIdentityUserMasters",
                newName: "AuthIdentityMaster");

            migrationBuilder.RenameIndex(
                name: "IX_AuthIdentityUserMasters_Amt_UmtUserCode",
                table: "AuthIdentityMaster",
                newName: "IX_AuthIdentityMaster_Amt_UmtUserCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthIdentityMaster",
                table: "AuthIdentityMaster",
                column: "Amt_AuthCode");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthIdentityMaster_UserMaster_Amt_UmtUserCode",
                table: "AuthIdentityMaster",
                column: "Amt_UmtUserCode",
                principalTable: "UserMaster",
                principalColumn: "UmtUserCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
