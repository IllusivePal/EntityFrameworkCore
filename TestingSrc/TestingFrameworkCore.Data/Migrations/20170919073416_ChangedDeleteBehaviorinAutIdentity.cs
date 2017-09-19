using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestingFrameworkCore.Data.Migrations
{
    public partial class ChangedDeleteBehaviorinAutIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthIdentityUserMasters_UserMaster_Amt_UmtUserCode",
                table: "AuthIdentityUserMasters");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AuthIdentityUserMasters_UserMaster_Amt_UmtUserCode",
                table: "AuthIdentityUserMasters",
                column: "Amt_UmtUserCode",
                principalTable: "UserMaster",
                principalColumn: "UmtUserCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
