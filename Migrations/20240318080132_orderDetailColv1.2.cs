using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trasua_web_mvc.Migrations
{
    /// <inheritdoc />
    public partial class orderDetailColv12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail");
        }
    }
}
