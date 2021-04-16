using Microsoft.EntityFrameworkCore.Migrations;

namespace NKUST109_2.Data.Migrations
{
    public partial class CreateVolumeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "volumeDatas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    TotalVolume = table.Column<int>(type: "int", nullable: false),
                    AverangeDailyVolume = table.Column<int>(type: "int", nullable: false),
                    AvgHolidayVolume = table.Column<int>(type: "int", nullable: false),
                    AvgBuyTicketWithCardOnPlatform = table.Column<float>(type: "real", nullable: false),
                    AvgBuyTicketWithCardOnTrain = table.Column<float>(type: "real", nullable: false),
                    AvgBuyTicketFromTicketMachine = table.Column<float>(type: "real", nullable: false),
                    AvgRebuyTicket = table.Column<float>(type: "real", nullable: false),
                    AvgBuyGroupTicket = table.Column<float>(type: "real", nullable: false),
                    AvgBuyTicketByManual = table.Column<float>(type: "real", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_volumeDatas", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "volumeDatas");
        }
    }
}
