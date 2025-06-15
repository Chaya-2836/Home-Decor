using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Orderid",
                table: "productOrdereds",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productOrdereds_Orderid",
                table: "productOrdereds",
                column: "Orderid");

            migrationBuilder.AddForeignKey(
                name: "FK_productOrdereds_orders_Orderid",
                table: "productOrdereds",
                column: "Orderid",
                principalTable: "orders",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productOrdereds_orders_Orderid",
                table: "productOrdereds");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropIndex(
                name: "IX_productOrdereds_Orderid",
                table: "productOrdereds");

            migrationBuilder.DropColumn(
                name: "Orderid",
                table: "productOrdereds");
        }
    }
}
