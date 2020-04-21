using Microsoft.EntityFrameworkCore.Migrations;

namespace CAMSlive.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimecardCharts",
                columns: table => new
                {
                    ChartId = table.Column<string>(nullable: false),
                    ChartOptions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimecardCharts", x => x.ChartId);
                });

            migrationBuilder.InsertData(
                table: "TimecardCharts",
                columns: new[] { "ChartId", "ChartOptions" },
                values: new object[] { "chart1", "series: [44, 55, 13, 33],chart: { height: 300, type: 'donut', },dataLabels: { enabled: true },labels: ['one', 'two', 'three', 'four'],title: { text: 'Payroll Period Progress', align: 'left' },responsive: [{ breakpoint: 480, options: { chart: { width: 200 }, legend: { show: false } } }],legend: { position: 'right', offsetY: 0, height: 230, }" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimecardCharts");
        }
    }
}
