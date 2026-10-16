using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Krestel_Erich_Lab2.Migrations
{
    /// <inheritdoc />
    public partial class AddPublicator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Publisher_PublisherId",
                table: "Book");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropIndex(
                name: "IX_Book_PublisherId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "PublicatorID",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Publicator",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicator", x => x.ID);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Publicator_PublicatorID",
                table: "Book");

            migrationBuilder.DropTable(
                name: "Publicator");

            migrationBuilder.DropIndex(
                name: "IX_Book_PublicatorID",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "PublicatorID",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_PublisherId",
                table: "Book",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Publisher_PublisherId",
                table: "Book",
                column: "PublisherId",
                principalTable: "Publisher",
                principalColumn: "ID");
        }
    }
}
