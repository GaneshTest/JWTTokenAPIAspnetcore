using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryPattern.Data.Migrations
{
    public partial class NotificationTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "notificationLogs",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    SenderUserId = table.Column<string>(nullable: false),
                    NotificationTitle = table.Column<string>(nullable: true),
                    NotificationText = table.Column<string>(nullable: false),
                    NotificationUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notificationLogs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_notificationLogs_AspNetUsers_SenderUserId",
                        column: x => x.SenderUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotificationLogUser",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    NotificationLogId = table.Column<string>(nullable: true),
                    ReceiverUserId = table.Column<string>(nullable: true),
                    IsRead = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationLogUser", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NotificationLogUser_notificationLogs_NotificationLogId",
                        column: x => x.NotificationLogId,
                        principalTable: "notificationLogs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotificationLogUser_AspNetUsers_ReceiverUserId",
                        column: x => x.ReceiverUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_notificationLogs_SenderUserId",
                table: "notificationLogs",
                column: "SenderUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationLogUser_NotificationLogId",
                table: "NotificationLogUser",
                column: "NotificationLogId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationLogUser_ReceiverUserId",
                table: "NotificationLogUser",
                column: "ReceiverUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationLogUser");

            migrationBuilder.DropTable(
                name: "notificationLogs");
        }
    }
}
