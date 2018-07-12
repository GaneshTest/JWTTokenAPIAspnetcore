﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryPattern.Data.Migrations
{
    public partial class conte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "BlogUrl" },
                values: new object[] { 2, "http://facebook.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
