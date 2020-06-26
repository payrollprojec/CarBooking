using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarBooking.Data.Migrations
{
    public partial class renametable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarBooking");

            migrationBuilder.CreateTable(
                name: "CarBookingz",
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
                    table.PrimaryKey("PK_CarBookingz", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarBookingz_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarBookingz_Car_CarId1",
                        column: x => x.CarId1,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarBookingz_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarBookingz_ApplicationUserId",
                table: "CarBookingz",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CarBookingz_CarId1",
                table: "CarBookingz",
                column: "CarId1");

            migrationBuilder.CreateIndex(
                name: "IX_CarBookingz_StatusId",
                table: "CarBookingz",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarBookingz");

            migrationBuilder.CreateTable(
                name: "CarBooking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CarId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarId1 = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
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
    }
}
