using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestingFrameworkCore.Data.Migrations
{
    public partial class revertChangeColoumnnamr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ludatetime",
                table: "T_ProductMaster",
                newName: "ludatetimes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ludatetimes",
                table: "T_ProductMaster",
                newName: "ludatetime");
        }
    }
}
