using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcMeetcha.Migrations
{
    public partial class AddMeetupModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeetupType",
                columns: table => new
                {
                    MeetupTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetupTypeName = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetupType", x => x.MeetupTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Meetup",
                columns: table => new
                {
                    MeetupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetupName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    MeetupDescription = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    MeetupDate = table.Column<DateTime>(nullable: false),
                    MeetupTime = table.Column<DateTime>(nullable: false),
                    MeetupTypeId = table.Column<int>(nullable: false),
                    MeetupVenue = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    MeetupFee = table.Column<decimal>(nullable: false),
                    MeetupImageName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetup", x => x.MeetupId);
                    table.ForeignKey(
                        name: "FK_Meetup_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meetup_MeetupType_MeetupTypeId",
                        column: x => x.MeetupTypeId,
                        principalTable: "MeetupType",
                        principalColumn: "MeetupTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MeetupType",
                columns: new[] { "MeetupTypeId", "MeetupTypeName" },
                values: new object[,]
                {
                    { 1, "Event" },
                    { 2, "Workshop" },
                    { 3, "Seminar" },
                    { 4, "Conference" },
                    { 5, "Programme" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meetup_GroupId",
                table: "Meetup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetup_MeetupTypeId",
                table: "Meetup",
                column: "MeetupTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meetup");

            migrationBuilder.DropTable(
                name: "MeetupType");
        }
    }
}
