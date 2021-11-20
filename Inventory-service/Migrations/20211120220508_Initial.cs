using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InventoryService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Exp = table.Column<long>(type: "bigint", nullable: false),
                    PositiveRating = table.Column<int>(type: "integer", nullable: false),
                    NegativeRating = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInventories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trinket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    UserInventoryId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trinket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trinket_UserInventories_UserInventoryId",
                        column: x => x.UserInventoryId,
                        principalTable: "UserInventories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trinket_UserInventoryId",
                table: "Trinket",
                column: "UserInventoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trinket");

            migrationBuilder.DropTable(
                name: "UserInventories");
        }
    }
}
