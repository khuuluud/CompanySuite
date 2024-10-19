﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinkDev.CompanyBase.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ImageColumnForEmpMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img",
                table: "Employees");
        }
    }
}
