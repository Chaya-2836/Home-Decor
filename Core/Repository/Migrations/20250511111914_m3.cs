using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentForCategories_Department_DepartmentId",
                table: "DepartmentForCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_productOrdereds_Products_ProductSKU",
                table: "productOrdereds");

            migrationBuilder.DropForeignKey(
                name: "FK_productOrdereds_orders_Orderid",
                table: "productOrdereds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productOrdereds",
                table: "productOrdereds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.RenameTable(
                name: "productOrdereds",
                newName: "ProductOrdereds");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.RenameIndex(
                name: "IX_productOrdereds_ProductSKU",
                table: "ProductOrdereds",
                newName: "IX_ProductOrdereds_ProductSKU");

            migrationBuilder.RenameIndex(
                name: "IX_productOrdereds_Orderid",
                table: "ProductOrdereds",
                newName: "IX_ProductOrdereds_Orderid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductOrdereds",
                table: "ProductOrdereds",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentForCategories_Departments_DepartmentId",
                table: "DepartmentForCategories",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrdereds_Orders_Orderid",
                table: "ProductOrdereds",
                column: "Orderid",
                principalTable: "Orders",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrdereds_Products_ProductSKU",
                table: "ProductOrdereds",
                column: "ProductSKU",
                principalTable: "Products",
                principalColumn: "SKU",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentForCategories_Departments_DepartmentId",
                table: "DepartmentForCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrdereds_Orders_Orderid",
                table: "ProductOrdereds");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrdereds_Products_ProductSKU",
                table: "ProductOrdereds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductOrdereds",
                table: "ProductOrdereds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.RenameTable(
                name: "ProductOrdereds",
                newName: "productOrdereds");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "orders");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOrdereds_ProductSKU",
                table: "productOrdereds",
                newName: "IX_productOrdereds_ProductSKU");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOrdereds_Orderid",
                table: "productOrdereds",
                newName: "IX_productOrdereds_Orderid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productOrdereds",
                table: "productOrdereds",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentForCategories_Department_DepartmentId",
                table: "DepartmentForCategories",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_productOrdereds_Products_ProductSKU",
                table: "productOrdereds",
                column: "ProductSKU",
                principalTable: "Products",
                principalColumn: "SKU",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productOrdereds_orders_Orderid",
                table: "productOrdereds",
                column: "Orderid",
                principalTable: "orders",
                principalColumn: "id");
        }
    }
}
