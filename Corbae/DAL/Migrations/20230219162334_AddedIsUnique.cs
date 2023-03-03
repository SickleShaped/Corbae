using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Corbae.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_CartId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Users_UserId",
                table: "OrderProducts");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "OrderProducts",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProducts_UserId",
                table: "OrderProducts",
                newName: "IX_OrderProducts_UserID");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "Carts",
                newName: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserID",
                table: "Users",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductID",
                table: "Products",
                column: "ProductID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderID",
                table: "Orders",
                column: "OrderID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderProductID",
                table: "OrderProducts",
                column: "OrderProductID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CartID",
                table: "Carts",
                column: "CartID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_CartProductID",
                table: "CartProducts",
                column: "CartProductID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_CartID",
                table: "Carts",
                column: "CartID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Users_UserID",
                table: "OrderProducts",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_CartID",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Users_UserID",
                table: "OrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderProducts_OrderProductID",
                table: "OrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_CartID",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_CartProducts_CartProductID",
                table: "CartProducts");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "OrderProducts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProducts_UserID",
                table: "OrderProducts",
                newName: "IX_OrderProducts_UserId");

            migrationBuilder.RenameColumn(
                name: "CartID",
                table: "Carts",
                newName: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_CartId",
                table: "Carts",
                column: "CartId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Users_UserId",
                table: "OrderProducts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
