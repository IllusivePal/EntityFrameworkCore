using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestingFrameworkCore.Data.Migrations
{
    public partial class addAuthIdentityClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthIdentity",
                columns: table => new
                {
                    AuthCode = table.Column<string>(nullable: false),
                    AuthName = table.Column<string>(nullable: true),
                    PmtProductCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthIdentity", x => x.AuthCode);
                    table.ForeignKey(
                        name: "FK_AuthIdentity_T_ProductMaster_PmtProductCode",
                        column: x => x.PmtProductCode,
                        principalTable: "T_ProductMaster",
                        principalColumn: "Pmt_ProductCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthIdentity_PmtProductCode",
                table: "AuthIdentity",
                column: "PmtProductCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthIdentity");
        }
    }
}
