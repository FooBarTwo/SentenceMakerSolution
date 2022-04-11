using Microsoft.EntityFrameworkCore.Migrations;

namespace SentenceManagement.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sentences",
                columns: table => new
                {
                    SentenceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sentences", x => x.SentenceId);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    WordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfWord = table.Column<int>(nullable: false),
                    Descrip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.WordId);
                });

            migrationBuilder.InsertData(
                table: "Sentences",
                columns: new[] { "SentenceId", "Content" },
                values: new object[,]
                {
                    { 1, "Hello World!" },
                    { 2, "Goodbye cruel World." },
                    { 3, "Whatever you say is only you're opinion." },
                    { 4, "When the blueberry sings and the mocking bird hums." },
                    { 5, "When comes and the sun chaseth the darkness away." }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "WordId", "Descrip", "TypeOfWord" },
                values: new object[,]
                {
                    { 1, "Box", 0 },
                    { 2, "Car", 0 },
                    { 3, "Case", 0 },
                    { 4, "Ride", 1 },
                    { 5, "Sit", 1 },
                    { 6, "Sing", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sentences");

            migrationBuilder.DropTable(
                name: "Words");
        }
    }
}
