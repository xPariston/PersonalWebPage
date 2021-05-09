using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebPage.Server.Console.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockInfos",
                columns: table => new
                {
                    StockInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastRefreshed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstValueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockInfos", x => x.StockInfoId);
                });

            migrationBuilder.CreateTable(
                name: "StockPerformance",
                columns: table => new
                {
                    StockPerformanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    close = table.Column<double>(type: "float", nullable: false),
                    StockInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockPerformance", x => x.StockPerformanceId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockInfos");

            migrationBuilder.DropTable(
                name: "StockPerformance");
        }
    }
}
