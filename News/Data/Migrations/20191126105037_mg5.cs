using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace News.Data.Migrations
{
    public partial class mg5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NewsViewModelId",
                table: "NewsCategory",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NewsViewModel",
                columns: table => new
                {
                    Title = table.Column<string>(nullable: true),
                    AddButtonTitle = table.Column<string>(nullable: true),
                    RedirectUrl = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NewsTitle = table.Column<string>(nullable: true),
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
                name: "IX_NewsCategory_NewsViewModelId",
                table: "NewsCategory",
                column: "NewsViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsViewModel_CategoryId",
                table: "NewsViewModel",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsCategory_NewsViewModel_NewsViewModelId",
                table: "NewsCategory",
                column: "NewsViewModelId",
                principalTable: "NewsViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsCategory_NewsViewModel_NewsViewModelId",
                table: "NewsCategory");

            migrationBuilder.DropTable(
                name: "NewsViewModel");

            migrationBuilder.DropIndex(
                name: "IX_NewsCategory_NewsViewModelId",
                table: "NewsCategory");

            migrationBuilder.DropColumn(
                name: "NewsViewModelId",
                table: "NewsCategory");
        }
    }
}
