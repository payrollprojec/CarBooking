using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarBooking.Data.Migrations
{
    public partial class cbandstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarBooking",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(nullable: false),
                    CarId = table.Column<string>(nullable: true),
                    CarId1 = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBooking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarBooking_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarBooking_Car_CarId1",
                        column: x => x.CarId1,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarBooking_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarBooking_ApplicationUserId",
                table: "CarBooking",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CarBooking_CarId1",
                table: "CarBooking",
                column: "CarId1");

            migrationBuilder.CreateIndex(
                name: "IX_CarBooking_StatusId",
                table: "CarBooking",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarBooking");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
