using Microsoft.EntityFrameworkCore.Migrations;

namespace Inverntory_Managment_System.Migrations
{
    public partial class EditingHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EditingHistorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    OldName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldAmount = table.Column<double>(type: "float", nullable: false),
                    OldDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldPrice = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditingHistorys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EditingHistorys_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EditingHistorys_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EditingHistorys_ProductId",
                table: "EditingHistorys",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_EditingHistorys_UserId",
                table: "EditingHistorys",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EditingHistorys");
        }
    }
}
