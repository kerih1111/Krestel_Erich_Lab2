using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Krestel_Erich_Lab2.Migrations
{
    /// <inheritdoc />
    public partial class PublisherChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Publicator_PublicatorID",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_PublicatorID",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "PublicatorID",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "PublisherID",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_PublisherID",
                table: "Book",
                column: "PublisherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Publicator_PublisherID",
                table: "Book",
                column: "PublisherID",
                principalTable: "Publicator",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Publicator_PublisherID",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_PublisherID",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "PublisherID",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "PublicatorID",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Book_PublicatorID",
                table: "Book",
                column: "PublicatorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Publicator_PublicatorID",
                table: "Book",
                column: "PublicatorID",
                principalTable: "Publicator",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
