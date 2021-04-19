using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketDataContribution.DataAccess.Migrations
{
    public partial class InitialFxCurrencySeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FxCurrencyPair",
                columns: new[] { "FxCurrencyPairId", "FxCurrencyPairName", "LastUpdated", "LastUpdatedBy" },
                values: new object[,]
                {
                    { 1, "EUR/USD", new DateTime(2021, 4, 19, 7, 14, 23, 107, DateTimeKind.Local).AddTicks(8407), "System" },
                    { 2, "USD/EUR", new DateTime(2021, 4, 19, 7, 14, 23, 107, DateTimeKind.Local).AddTicks(8988), "System" },
                    { 3, "GBP/USD", new DateTime(2021, 4, 19, 7, 14, 23, 107, DateTimeKind.Local).AddTicks(9004), "System" },
                    { 4, "USD/GBP", new DateTime(2021, 4, 19, 7, 14, 23, 107, DateTimeKind.Local).AddTicks(9008), "System" }
                });

            migrationBuilder.UpdateData(
                table: "MarketDataType",
                keyColumn: "MarketDataTypeId",
                keyValue: 3,
                columns: new[] { "LastUpdated", "LastUpdatedBy" },
                values: new object[] { new DateTime(2021, 4, 19, 7, 14, 23, 103, DateTimeKind.Local).AddTicks(2698), "System" });

            migrationBuilder.UpdateData(
                table: "MarketDataType",
                keyColumn: "MarketDataTypeId",
                keyValue: 4,
                columns: new[] { "LastUpdated", "LastUpdatedBy" },
                values: new object[] { new DateTime(2021, 4, 19, 7, 14, 23, 106, DateTimeKind.Local).AddTicks(2768), "System" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FxCurrencyPair",
                keyColumn: "FxCurrencyPairId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FxCurrencyPair",
                keyColumn: "FxCurrencyPairId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FxCurrencyPair",
                keyColumn: "FxCurrencyPairId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FxCurrencyPair",
                keyColumn: "FxCurrencyPairId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "MarketDataType",
                keyColumn: "MarketDataTypeId",
                keyValue: 3,
                columns: new[] { "LastUpdated", "LastUpdatedBy" },
                values: new object[] { new DateTime(2021, 4, 19, 7, 8, 18, 445, DateTimeKind.Local).AddTicks(6482), "Test" });

            migrationBuilder.UpdateData(
                table: "MarketDataType",
                keyColumn: "MarketDataTypeId",
                keyValue: 4,
                columns: new[] { "LastUpdated", "LastUpdatedBy" },
                values: new object[] { new DateTime(2021, 4, 19, 7, 8, 18, 448, DateTimeKind.Local).AddTicks(5253), "Test" });
        }
    }
}
