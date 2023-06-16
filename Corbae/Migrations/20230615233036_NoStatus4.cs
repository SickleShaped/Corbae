using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Corbae.Migrations
{
    /// <inheritdoc />
    public partial class NoStatus4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Users_UserDBUserID",
                table: "OrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderProducts_UserDBUserID",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "UserDBUserID",
                table: "OrderProducts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserDBUserID",
                table: "OrderProducts",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_UserDBUserID",
                table: "OrderProducts",
                column: "UserDBUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Users_UserDBUserID",
                table: "OrderProducts",
                column: "UserDBUserID",
                principalTable: "Users",
                principalColumn: "UserID");
        }
    }
}
