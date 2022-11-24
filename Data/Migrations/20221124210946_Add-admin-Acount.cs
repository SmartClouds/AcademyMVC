using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademyMVC.Data.Migrations
{
    public partial class AddadminAcount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Content_CategoryItem_categoryItemID",
                table: "Content");

            migrationBuilder.AlterColumn<int>(
                name: "categoryItemID",
                table: "Content",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Content_CategoryItem_categoryItemID",
                table: "Content",
                column: "categoryItemID",
                principalTable: "CategoryItem",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Content_CategoryItem_categoryItemID",
                table: "Content");

            migrationBuilder.AlterColumn<int>(
                name: "categoryItemID",
                table: "Content",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Content_CategoryItem_categoryItemID",
                table: "Content",
                column: "categoryItemID",
                principalTable: "CategoryItem",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
