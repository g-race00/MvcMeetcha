using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcMeetcha.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupType",
                columns: table => new
                {
                    GroupTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupTypeName = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupType", x => x.GroupTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    GroupDescription = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    GroupTypeId = table.Column<int>(nullable: false),
                    GroupImageName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_Group_GroupType_GroupTypeId",
                        column: x => x.GroupTypeId,
                        principalTable: "GroupType",
                        principalColumn: "GroupTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GroupType",
                columns: new[] { "GroupTypeId", "GroupTypeName" },
                values: new object[,]
                {
                    { 1, "Arts" },
                    { 20, "Social" },
                    { 19, "Sci-Fi & Games" },
                    { 18, "Photography" },
                    { 17, "Pets" },
                    { 16, "Outdoors & Adventure" },
                    { 15, "Music" },
                    { 14, "Movements" },
                    { 13, "Learning" },
                    { 12, "Language & Culture" },
                    { 11, "Hobbies & Crafts" },
                    { 10, "Health & Wellness" },
                    { 9, "Food & Drinks" },
                    { 8, "Film" },
                    { 7, "Fashion & Beauty" },
                    { 6, "Family" },
                    { 5, "Dance" },
                    { 4, "Career & Business" },
                    { 3, "Book Clubs" },
                    { 2, "Beliefs" },
                    { 21, "Sports & Fitness" },
                    { 22, "Writing" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Group_GroupTypeId",
                table: "Group",
                column: "GroupTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "GroupType");
        }
    }
}
