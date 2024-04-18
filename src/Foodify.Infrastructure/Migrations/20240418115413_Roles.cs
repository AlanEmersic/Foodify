using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foodify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("1e5c95a5-49a8-4627-9491-136e52fa8e05"));

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("63e4283d-b887-49a3-b78d-b7e922b8b267"));

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "DiscountRate", "SubscriptionType" },
                values: new object[,]
                {
                    { new Guid("4b60a9c6-c724-4d54-8faf-68c9e1d5c008"), 10f, "Plus" },
                    { new Guid("defccacf-1e21-4fac-8148-9d4060279f59"), 0f, "Free" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("4b60a9c6-c724-4d54-8faf-68c9e1d5c008"));

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("defccacf-1e21-4fac-8148-9d4060279f59"));

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "DiscountRate", "SubscriptionType" },
                values: new object[,]
                {
                    { new Guid("1e5c95a5-49a8-4627-9491-136e52fa8e05"), 10f, "Plus" },
                    { new Guid("63e4283d-b887-49a3-b78d-b7e922b8b267"), 0f, "Free" }
                });
        }
    }
}