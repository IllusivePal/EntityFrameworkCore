using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestingFrameworkCore.Data.Migrations
{
    public partial class ChangeStatusName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pmt_Status",
                table: "T_ProductMaster",
                newName: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "T_ProductMaster",
                newName: "Pmt_Status");
        }
    }
}
