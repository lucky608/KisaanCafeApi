﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KisaanCafeWebAPI.Migrations
{
    public partial class AddWeightColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "ProductDetails",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "ProductDetails");
        }
    }
}
