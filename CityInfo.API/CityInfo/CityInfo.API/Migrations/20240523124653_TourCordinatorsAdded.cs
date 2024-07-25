using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityInfo.API.Migrations
{
    public partial class TourCordinatorsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TourCoordinators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourCoordinators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourCoordinators_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TourCoordinators",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[,]
                {
                    { 1, 4, "John Doe" },
                    { 2, 5, "Jane Smith" },
                    { 3, 6, "Robert Johnson" },
                    { 4, 7, "Mary Davis" },
                    { 5, 8, "James Brown" },
                    { 6, 8, "Patricia Garcia" },
                    { 7, 10, "Michael Miller" },
                    { 8, 11, "Linda Martinez" },
                    { 9, 12, "William Rodriguez" },
                    { 10, 13, "Elizabeth Taylor" },
                    { 11, 11, "David Anderson" },
                    { 12, 12, "Jennifer Thomas" },
                    { 13, 13, "Richard Jackson" },
                    { 14, 5, "Susan White" },
                    { 15, 6, "Joseph Harris" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourCoordinators_CityId",
                table: "TourCoordinators",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourCoordinators");
        }
    }
}
