using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store_Example.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ProductFeatureAndProductFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductFeature_Products_ProductId",
                table: "ProductFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductFile_Products_ProductId",
                table: "ProductFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductFile",
                table: "ProductFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductFeature",
                table: "ProductFeature");

            migrationBuilder.RenameTable(
                name: "ProductFile",
                newName: "ProductFiles");

            migrationBuilder.RenameTable(
                name: "ProductFeature",
                newName: "ProductFeatures");

            migrationBuilder.RenameIndex(
                name: "IX_ProductFile_ProductId",
                table: "ProductFiles",
                newName: "IX_ProductFiles_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductFeature_ProductId",
                table: "ProductFeatures",
                newName: "IX_ProductFeatures_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductFiles",
                table: "ProductFiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductFeatures",
                table: "ProductFeatures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFeatures_Products_ProductId",
                table: "ProductFeatures",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFiles_Products_ProductId",
                table: "ProductFiles",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductFeatures_Products_ProductId",
                table: "ProductFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductFiles_Products_ProductId",
                table: "ProductFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductFiles",
                table: "ProductFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductFeatures",
                table: "ProductFeatures");

            migrationBuilder.RenameTable(
                name: "ProductFiles",
                newName: "ProductFile");

            migrationBuilder.RenameTable(
                name: "ProductFeatures",
                newName: "ProductFeature");

            migrationBuilder.RenameIndex(
                name: "IX_ProductFiles_ProductId",
                table: "ProductFile",
                newName: "IX_ProductFile_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductFeatures_ProductId",
                table: "ProductFeature",
                newName: "IX_ProductFeature_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductFile",
                table: "ProductFile",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductFeature",
                table: "ProductFeature",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFeature_Products_ProductId",
                table: "ProductFeature",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFile_Products_ProductId",
                table: "ProductFile",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
