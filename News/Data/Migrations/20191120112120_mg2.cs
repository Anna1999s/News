using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace News.Data.Migrations
{
    public partial class mg2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "News",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NewsCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsViewModel",
                columns: table => new
                {
                    Title = table.Column<string>(nullable: true),
                    AddButtonTitle = table.Column<string>(nullable: true),
                    RedirectUrl = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NewsTitle = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsViewModel_NewsCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "NewsCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_News_CategoryId",
                table: "News",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsViewModel_CategoryId",
                table: "NewsViewModel",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsCategory_CategoryId",
                table: "News",
                column: "CategoryId",
                principalTable: "NewsCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsCategory_CategoryId",
                table: "News");

            migrationBuilder.DropTable(
                name: "NewsViewModel");

            migrationBuilder.DropTable(
                name: "NewsCategory");

            migrationBuilder.DropIndex(
                name: "IX_News_CategoryId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "News");
        }
    }
}
