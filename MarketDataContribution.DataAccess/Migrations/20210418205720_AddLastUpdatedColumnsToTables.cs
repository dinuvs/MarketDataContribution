using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketDataContribution.DataAccess.Migrations
{
    public partial class AddLastUpdatedColumnsToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "MarketDataType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                table: "MarketDataType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "MarketData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                table: "MarketData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "FxCurrencyPair",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                table: "FxCurrencyPair",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "MarketDataType");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "MarketDataType");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "MarketData");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "MarketData");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "FxCurrencyPair");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "FxCurrencyPair");
        }
    }
}
