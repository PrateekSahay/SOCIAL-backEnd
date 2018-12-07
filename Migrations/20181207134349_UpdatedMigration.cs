using Microsoft.EntityFrameworkCore.Migrations;

namespace backEnd.Migrations
{
    public partial class UpdatedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "topicId", "topicName" },
                values: new object[] { 3, "Topic-3" });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "topicId", "topicName" },
                values: new object[] { 4, "Topic-4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "topicId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "topicId",
                keyValue: 4);
        }
    }
}
