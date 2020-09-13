using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PublisherId = table.Column<long>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PublishedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BooksToAuthors",
                columns: table => new
                {
                    BookId = table.Column<long>(nullable: false),
                    AuthorId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksToAuthors", x => new { x.BookId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_BooksToAuthors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksToAuthors_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Author1" },
                    { 2L, "Author2" },
                    { 3L, "Author3" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Publisher1" },
                    { 2L, "Publisher2" },
                    { 3L, "Publisher3" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Description", "Name", "Price", "PublishedAt", "PublisherId" },
                values: new object[] { 1L, "Test test", "Book1", 17.15m, new DateTime(2020, 9, 10, 15, 13, 1, 819, DateTimeKind.Local).AddTicks(3443), 1L });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Description", "Name", "Price", "PublishedAt", "PublisherId" },
                values: new object[] { 2L, "Test test", "Book2", 17.15m, new DateTime(2020, 9, 10, 15, 13, 1, 820, DateTimeKind.Local).AddTicks(1078), 2L });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Description", "Name", "Price", "PublishedAt", "PublisherId" },
                values: new object[] { 3L, "Test test", "Book3", 17.15m, new DateTime(2020, 9, 10, 15, 13, 1, 820, DateTimeKind.Local).AddTicks(1085), 3L });

            migrationBuilder.InsertData(
                table: "BooksToAuthors",
                columns: new[] { "BookId", "AuthorId" },
                values: new object[] { 1L, 1L });

            migrationBuilder.InsertData(
                table: "BooksToAuthors",
                columns: new[] { "BookId", "AuthorId" },
                values: new object[] { 2L, 2L });

            migrationBuilder.InsertData(
                table: "BooksToAuthors",
                columns: new[] { "BookId", "AuthorId" },
                values: new object[] { 3L, 3L });

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksToAuthors_AuthorId",
                table: "BooksToAuthors",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BooksToAuthors");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
