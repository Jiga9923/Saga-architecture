using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking_Micro.Migrations
{
    public partial class BookingDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingData",
                columns: table => new
                {
                    BookingId = table.Column<Guid>(nullable: false),
                    FlightDetails = table.Column<string>(nullable: true),
                    CardDetails = table.Column<string>(nullable: true),
                    CustomerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingData", x => x.BookingId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingData");
        }
    }
}
