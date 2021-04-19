using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketDataContribution.DataAccess.Migrations
{
    public partial class AddMarketDataTypeSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MarketDataType",
                columns: new[] { "MarketDataTypeId", "LastUpdated", "LastUpdatedBy", "MarketTypeName" },
                values: new object[] { 3, new DateTime(2021, 4, 19, 7, 8, 18, 445, DateTimeKind.Local).AddTicks(6482), "Test", "FxQuote" });

            migrationBuilder.InsertData(
                table: "MarketDataType",
                columns: new[] { "MarketDataTypeId", "LastUpdated", "LastUpdatedBy", "MarketTypeName" },
                values: new object[] { 4, new DateTime(2021, 4, 19, 7, 8, 18, 448, DateTimeKind.Local).AddTicks(5253), "Test", "Legal auditing" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MarketDataType",
                keyColumn: "MarketDataTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MarketDataType",
                keyColumn: "MarketDataTypeId",
                keyValue: 4);
        }
    }
}
