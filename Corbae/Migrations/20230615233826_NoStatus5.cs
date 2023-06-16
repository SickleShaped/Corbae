using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Corbae.Migrations
{
    /// <inheritdoc />
    public partial class NoStatus5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Orders_ProductID",
                table: "OrderProducts");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderID",
                table: "OrderProducts",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Orders_OrderID",
                table: "OrderProducts",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Orders_OrderID",
                table: "OrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderProducts_OrderID",
                table: "OrderProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Orders_ProductID",
                table: "OrderProducts",
                column: "ProductID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
