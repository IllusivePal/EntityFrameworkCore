using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestingFrameworkCore.Data.Migrations
{
    public partial class AddHistoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.CreateTable(
                name: "HistoryTable",
                columns: table => new
                {
                    UmtUserCode = table.Column<string>(nullable: false),
                    PmtProductCode = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryTable", x => new { x.UmtUserCode, x.PmtProductCode });
                    table.ForeignKey(
                        name: "FK_HistoryTable_T_ProductMaster_PmtProductCode",
                        column: x => x.PmtProductCode,
                        principalTable: "T_ProductMaster",
                        principalColumn: "Pmt_ProductCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryTable_T_UserMaster_UmtUserCode",
                        column: x => x.UmtUserCode,
                        principalTable: "T_UserMaster",
                        principalColumn: "Umt_UserCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoryTable_PmtProductCode",
                table: "HistoryTable",
                column: "PmtProductCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoryTable");

            
        }
    }
}
