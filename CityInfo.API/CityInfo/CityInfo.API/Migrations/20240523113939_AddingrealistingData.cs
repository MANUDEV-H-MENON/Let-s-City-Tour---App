using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityInfo.API.Migrations
{
    public partial class AddingrealistingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 4, "The Big Apple", "New York" },
                    { 5, "One of the busiest cities in the world", "Tokyo" },
                    { 6, "The City of Light", "Paris" },
                    { 7, "The capital of England", "London" },
                    { 8, "The largest city in Australia", "Sydney" },
                    { 9, "Home of the famous Christ the Redeemer statue", "Rio de Janeiro" },
                    { 10, "Known for its harbour and Table Mountain", "Cape Town" },
                    { 11, "The capital of Russia", "Moscow" },
                    { 12, "The capital of China", "Beijing" },
                    { 13, "The largest city in Africa", "Cairo" }
                });

            migrationBuilder.InsertData(
                table: "PointOfInterests",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[,]
                {
                    { 5, 4, "A colossal neoclassical sculpture on Liberty Island", "Statue of Liberty" },
                    { 6, 5, "A communications and observation tower in the Shiba-koen district", "Tokyo Tower" },
                    { 7, 6, "A wrought-iron lattice tower on the Champ de Mars", "Eiffel Tower" },
                    { 8, 7, "A giant Ferris wheel on the South Bank of the River Thames", "London Eye" },
                    { 9, 8, "A multi-venue performing arts centre at Sydney Harbour", "Sydney Opera House" },
                    { 10, 9, "An Art Deco statue of Jesus Christ in Rio de Janeiro", "Christ the Redeemer" },
                    { 11, 10, "A flat-topped mountain forming a prominent landmark overlooking the city of Cape Town", "Table Mountain" },
                    { 12, 11, "A city square in Moscow", "Red Square" },
                    { 13, 12, "A series of fortifications that were built across the historical northern borders of China", "Great Wall of China" },
                    { 14, 13, "The oldest of the Seven Wonders of the Ancient World, and the only one to remain largely intact", "Pyramids of Giza" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Cultural CApital of Kerala", "Thrissur" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "Tech CApital of Kerala", "Kochi" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, "OOriginal CApital of Kerala", "Trivandrum" });

            migrationBuilder.InsertData(
                table: "PointOfInterests",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Beach It is", "snehatheeram" },
                    { 2, 2, "It's a Tourist spot", "Fort kochi" },
                    { 3, 2, "It's a backwaters spot", "Kumbalangi" },
                    { 4, 3, "Beach It is", "Kovalam" }
                });
        }
    }
}
