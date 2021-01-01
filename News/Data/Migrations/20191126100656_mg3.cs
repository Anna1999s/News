using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace News.Data.Migrations
{
    public partial class mg3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsViewModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddButtonTitle = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    NewsTitle = table.Column<string>(nullable: false),
                    RedirectUrl = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
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
                name: "IX_NewsViewModel_CategoryId",
                table: "NewsViewModel",
                column: "CategoryId");
        }
    }
}
