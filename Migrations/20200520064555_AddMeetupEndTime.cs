using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcMeetcha.Migrations
{
    public partial class AddMeetupEndTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeetupTime",
                table: "Meetup");

            migrationBuilder.AddColumn<DateTime>(
                name: "MeetupEndTime",
                table: "Meetup",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "MeetupStartTime",
                table: "Meetup",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeetupEndTime",
                table: "Meetup");

            migrationBuilder.DropColumn(
                name: "MeetupStartTime",
                table: "Meetup");

            migrationBuilder.AddColumn<DateTime>(
                name: "MeetupTime",
                table: "Meetup",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
