﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalabatG02.Repository.Data.Migrations
{
    public partial class updateColumnAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShippingAddress_LName",
                table: "Orders",
                newName: "ShippingAddress_LastName");

            migrationBuilder.RenameColumn(
                name: "ShippingAddress_FName",
                table: "Orders",
                newName: "ShippingAddress_FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShippingAddress_LastName",
                table: "Orders",
                newName: "ShippingAddress_LName");

            migrationBuilder.RenameColumn(
                name: "ShippingAddress_FirstName",
                table: "Orders",
                newName: "ShippingAddress_FName");
        }
    }
}
