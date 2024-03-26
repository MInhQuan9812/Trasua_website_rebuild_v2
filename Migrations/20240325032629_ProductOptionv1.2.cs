using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trasua_web_mvc.Migrations
{
    /// <inheritdoc />
    public partial class ProductOptionv12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "OptionValue",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "OptionValue");
        }
    }
}
