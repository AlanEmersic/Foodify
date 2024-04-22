using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foodify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("4b60a9c6-c724-4d54-8faf-68c9e1d5c008"));

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("defccacf-1e21-4fac-8148-9d4060279f59"));

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "DiscountRate", "SubscriptionType" },
                values: new object[,]
                {
                    { new Guid("05811a33-3f04-4fd6-a3ec-fcfc6be127a2"), 10f, "Plus" },
                    { new Guid("180844bf-1f06-42f1-954b-5c45a882a77a"), 0f, "Free" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("05811a33-3f04-4fd6-a3ec-fcfc6be127a2"));

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("180844bf-1f06-42f1-954b-5c45a882a77a"));

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "DiscountRate", "SubscriptionType" },
                values: new object[,]
                {
                    { new Guid("4b60a9c6-c724-4d54-8faf-68c9e1d5c008"), 10f, "Plus" },
                    { new Guid("defccacf-1e21-4fac-8148-9d4060279f59"), 0f, "Free" }
                });
        }
    }
}