using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExpenseTrackerApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a8f53a53-8211-4db9-aa57-b9b1768d12da"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a9c7504b-6f1c-4ac5-b9da-7ee1e7feef65"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bec59df6-193c-4fd1-b5cc-ad2ca5adada4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e5eb8240-3080-4cdc-830e-f773fac48548"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8d2003ec-b650-4609-b987-8a8da342f1fa"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "PasswordHash", "UpdatedAt" },
                values: new object[] { new Guid("8d2003ec-b650-4609-b987-8a8da342f1fa"), new DateTime(2024, 12, 23, 8, 39, 33, 372, DateTimeKind.Utc).AddTicks(2574), "tavanvinh172@gmail.com", "Vinh", "$2a$11$CaL.cJ7iJzDDW05Y6z8kf.j5RX2M6PrXoh2la.8n4SL2LxeBxob26", new DateTime(2024, 12, 23, 8, 39, 33, 372, DateTimeKind.Utc).AddTicks(2578) });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "IconUrl", "Name", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("a8f53a53-8211-4db9-aa57-b9b1768d12da"), new DateTime(2024, 12, 23, 8, 39, 33, 372, DateTimeKind.Utc).AddTicks(3293), null, "Housing", new DateTime(2024, 12, 23, 8, 39, 33, 372, DateTimeKind.Utc).AddTicks(3294), new Guid("8d2003ec-b650-4609-b987-8a8da342f1fa") },
                    { new Guid("a9c7504b-6f1c-4ac5-b9da-7ee1e7feef65"), new DateTime(2024, 12, 23, 8, 39, 33, 372, DateTimeKind.Utc).AddTicks(3299), null, "Transportation", new DateTime(2024, 12, 23, 8, 39, 33, 372, DateTimeKind.Utc).AddTicks(3300), new Guid("8d2003ec-b650-4609-b987-8a8da342f1fa") },
                    { new Guid("bec59df6-193c-4fd1-b5cc-ad2ca5adada4"), new DateTime(2024, 12, 23, 8, 39, 33, 372, DateTimeKind.Utc).AddTicks(3283), null, "Food & Dining", new DateTime(2024, 12, 23, 8, 39, 33, 372, DateTimeKind.Utc).AddTicks(3284), new Guid("8d2003ec-b650-4609-b987-8a8da342f1fa") },
                    { new Guid("e5eb8240-3080-4cdc-830e-f773fac48548"), new DateTime(2024, 12, 23, 8, 39, 33, 372, DateTimeKind.Utc).AddTicks(3304), null, "Health & Wellness", new DateTime(2024, 12, 23, 8, 39, 33, 372, DateTimeKind.Utc).AddTicks(3305), new Guid("8d2003ec-b650-4609-b987-8a8da342f1fa") }
                });
        }
    }
}
