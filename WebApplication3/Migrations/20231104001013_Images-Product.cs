using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class ImagesProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_ProductImages_Id_ProductId_ImageId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "ProductImageId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductImageId",
                table: "Images");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ProductImages_ProductId_ImageId",
                table: "ProductImages",
                columns: new[] { "ProductId", "ImageId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_ProductImages_ProductId_ImageId",
                table: "ProductImages");

            migrationBuilder.AddColumn<int>(
                name: "ProductImageId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductImageId",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ProductImages_Id_ProductId_ImageId",
                table: "ProductImages",
                columns: new[] { "Id", "ProductId", "ImageId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");
        }
    }
}
