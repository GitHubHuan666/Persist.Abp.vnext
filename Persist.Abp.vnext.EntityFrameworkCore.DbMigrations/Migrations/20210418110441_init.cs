using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persist.Abp.vnext.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    AuthorId = table.Column<string>(nullable: true),
                    AuthorName = table.Column<string>(maxLength: 20, nullable: false),
                    CategoryId = table.Column<string>(nullable: true),
                    CategoryName = table.Column<string>(maxLength: 10, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChapterText",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Content = table.Column<string>(type: "ntext", maxLength: 8000, nullable: false),
                    Memo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterText", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Volume",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    BookId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volume", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Volume_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chapter",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    VolumeId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 30, nullable: false),
                    ChapterTextId = table.Column<string>(nullable: true),
                    WordsNumber = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chapter_ChapterText_ChapterTextId",
                        column: x => x.ChapterTextId,
                        principalTable: "ChapterText",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chapter_Volume_VolumeId",
                        column: x => x.VolumeId,
                        principalTable: "Volume",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_ChapterTextId",
                table: "Chapter",
                column: "ChapterTextId");

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_VolumeId",
                table: "Chapter",
                column: "VolumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Volume_BookId",
                table: "Volume",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Chapter");

            migrationBuilder.DropTable(
                name: "ChapterText");

            migrationBuilder.DropTable(
                name: "Volume");

            migrationBuilder.DropTable(
                name: "Book");
        }
    }
}
