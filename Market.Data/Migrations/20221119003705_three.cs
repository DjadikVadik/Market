using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Data.Migrations
{
    /// <inheritdoc />
    public partial class three : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IcomName",
                table: "Product",
                newName: "IconName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IconName",
                table: "Product",
                newName: "IcomName");
        }
    }
}
