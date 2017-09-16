using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestingFrameworkCore.Data.Migrations
{
    public partial class AddSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    UserCode = table.Column<string>(nullable: false),
                    ProductCode = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ProductPmtProductCode = table.Column<string>(nullable: true),
                    UserUmtUserCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => new { x.UserCode, x.ProductCode });
                    table.ForeignKey(
                        name: "FK_History_T_ProductMaster_ProductPmtProductCode",
                        column: x => x.ProductPmtProductCode,
                        principalTable: "T_ProductMaster",
                        principalColumn: "Pmt_ProductCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_History_T_UserMaster_UserUmtUserCode",
                        column: x => x.UserUmtUserCode,
                        principalTable: "T_UserMaster",
                        principalColumn: "Umt_UserCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_History_ProductPmtProductCode",
                table: "History",
                column: "ProductPmtProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_History_UserUmtUserCode",
                table: "History",
                column: "UserUmtUserCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "History");
        }
    }
}
