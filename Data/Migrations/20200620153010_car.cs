using Microsoft.EntityFrameworkCore.Migrations;

namespace CarBooking.Data.Migrations
{
    public partial class car : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manufacturer = table.Column<string>(nullable: true),
                    CarModel = table.Column<string>(nullable: true),
                    DailyRate = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ImgUrl = table.Column<string>(nullable: true),
                    NoOfSeats = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");
        }
    }
}
