using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCEFCore.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductFileId",
                table: "ProductTable",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTable_ProductFileId",
                table: "ProductTable",
                column: "ProductFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTable_Files_ProductFileId",
                table: "ProductTable",
                column: "ProductFileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTable_Files_ProductFileId",
                table: "ProductTable");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropIndex(
                name: "IX_ProductTable_ProductFileId",
                table: "ProductTable");

            migrationBuilder.DropColumn(
                name: "ProductFileId",
                table: "ProductTable");
        }
    }
}
