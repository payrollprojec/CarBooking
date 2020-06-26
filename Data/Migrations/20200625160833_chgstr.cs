using Microsoft.EntityFrameworkCore.Migrations;

namespace CarBooking.Data.Migrations
{
    public partial class chgstr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarBookingz_Car_CarId1",
                table: "CarBookingz");

            migrationBuilder.DropIndex(
                name: "IX_CarBookingz_CarId1",
                table: "CarBookingz");

            migrationBuilder.DropColumn(
                name: "CarId1",
                table: "CarBookingz");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "CarBookingz",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarBookingz_CarId",
                table: "CarBookingz",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarBookingz_Car_CarId",
                table: "CarBookingz",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarBookingz_Car_CarId",
                table: "CarBookingz");

            migrationBuilder.DropIndex(
                name: "IX_CarBookingz_CarId",
                table: "CarBookingz");

            migrationBuilder.AlterColumn<string>(
                name: "CarId",
                table: "CarBookingz",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CarId1",
                table: "CarBookingz",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CarBookingz_CarId1",
                table: "CarBookingz",
                column: "CarId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CarBookingz_Car_CarId1",
                table: "CarBookingz",
                column: "CarId1",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
