using Microsoft.EntityFrameworkCore.Migrations;

namespace To_Do_Lists.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListOfItemsTable",
                columns: table => new
                {
                    ListOfItemsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfItemsTable", x => x.ListOfItemsId);
                });

            migrationBuilder.CreateTable(
                name: "ItemsTable",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ListOfItemsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsTable", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_ItemsTable_ListOfItemsTable_ListOfItemsId",
                        column: x => x.ListOfItemsId,
                        principalTable: "ListOfItemsTable",
                        principalColumn: "ListOfItemsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemsTable_ListOfItemsId",
                table: "ItemsTable",
                column: "ListOfItemsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemsTable");

            migrationBuilder.DropTable(
                name: "ListOfItemsTable");
        }
    }
}
