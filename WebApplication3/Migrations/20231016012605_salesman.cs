using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class salesman : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Statuses_StatusID",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salesmen",
                table: "Salesmen");

            migrationBuilder.DropIndex(
                name: "IX_Salesmen_SalesmanId",
                table: "Salesmen");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Salesmen");

            migrationBuilder.RenameColumn(
                name: "StatusID",
                table: "Products",
                newName: "StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_StatusID",
                table: "Products",
                newName: "IX_Products_StatusId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Salesmen_SalesmanId_ProductId",
                table: "Salesmen",
                columns: new[] { "SalesmanId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salesmen",
                table: "Salesmen",
                column: "SalesmanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Statuses_StatusId",
                table: "Products",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Statuses_StatusId",
                table: "Products");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Salesmen_SalesmanId_ProductId",
                table: "Salesmen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salesmen",
                table: "Salesmen");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Products",
                newName: "StatusID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_StatusId",
                table: "Products",
                newName: "IX_Products_StatusID");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Salesmen",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salesmen",
                table: "Salesmen",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Salesmen_SalesmanId",
                table: "Salesmen",
                column: "SalesmanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Statuses_StatusID",
                table: "Products",
                column: "StatusID",
                principalTable: "Statuses",
                principalColumn: "Id");
        }
    }
}
