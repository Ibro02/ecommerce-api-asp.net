using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class productImages3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImagesProducts_Images_ImageId",
                table: "ProductImagesProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImagesProducts_Products_ProductId",
                table: "ProductImagesProducts");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ProductImagesProducts_Id_ProductId_ImageId",
                table: "ProductImagesProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImagesProducts",
                table: "ProductImagesProducts");

            migrationBuilder.RenameTable(
                name: "ProductImagesProducts",
                newName: "ProductImages");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImagesProducts_ProductId",
                table: "ProductImages",
                newName: "IX_ProductImages_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImagesProducts_ImageId",
                table: "ProductImages",
                newName: "IX_ProductImages_ImageId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ProductImages_Id_ProductId_ImageId",
                table: "ProductImages",
                columns: new[] { "Id", "ProductId", "ImageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Images_ImageId",
                table: "ProductImages",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Images_ImageId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ProductImages_Id_ProductId_ImageId",
                table: "ProductImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages");

            migrationBuilder.RenameTable(
                name: "ProductImages",
                newName: "ProductImagesProducts");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImagesProducts",
                newName: "IX_ProductImagesProducts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImages_ImageId",
                table: "ProductImagesProducts",
                newName: "IX_ProductImagesProducts_ImageId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ProductImagesProducts_Id_ProductId_ImageId",
                table: "ProductImagesProducts",
                columns: new[] { "Id", "ProductId", "ImageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImagesProducts",
                table: "ProductImagesProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImagesProducts_Images_ImageId",
                table: "ProductImagesProducts",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImagesProducts_Products_ProductId",
                table: "ProductImagesProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
