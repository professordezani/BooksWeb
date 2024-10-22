using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksWeb.Migrations
{
    /// <inheritdoc />
    public partial class composekey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BooksReaders",
                table: "BooksReaders");

            migrationBuilder.DropIndex(
                name: "IX_BooksReaders_BookId",
                table: "BooksReaders");

            migrationBuilder.DropColumn(
                name: "BookReaderId",
                table: "BooksReaders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BooksReaders",
                table: "BooksReaders",
                columns: new[] { "BookId", "ReaderId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BooksReaders",
                table: "BooksReaders");

            migrationBuilder.AddColumn<int>(
                name: "BookReaderId",
                table: "BooksReaders",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BooksReaders",
                table: "BooksReaders",
                column: "BookReaderId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksReaders_BookId",
                table: "BooksReaders",
                column: "BookId");
        }
    }
}
