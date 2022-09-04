﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace FluentValidationApp.Web.Migrations
{
    public partial class Add_Enum_Gender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "gender",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "gender",
                table: "Customers");
        }
    }
}
