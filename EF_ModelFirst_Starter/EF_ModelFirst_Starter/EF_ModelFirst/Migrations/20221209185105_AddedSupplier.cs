using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFModelFirst.Migrations
{
    /// <inheritdoc />
    public partial class AddedSupplier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "OrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_SupplierId",
                table: "OrderDetails",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Suppliers_SupplierId",
                table: "OrderDetails",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Suppliers_SupplierId",
                table: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_SupplierId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "OrderDetails");
        }
    }
}
