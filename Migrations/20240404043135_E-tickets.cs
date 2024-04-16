using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_ticket.Migrations
{
    public partial class Etickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movies_CartId",
                table: "movies",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_movies_carts_CartId",
                table: "movies",
                column: "CartId",
                principalTable: "carts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_carts_CartId",
                table: "movies");

            migrationBuilder.DropTable(
                name: "carts");

            migrationBuilder.DropIndex(
                name: "IX_movies_CartId",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "movies");
        }
    }
}
