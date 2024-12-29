using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExpenseTrackerApi.Migrations
{
    /// <inheritdoc />
    public partial class MigrateDecimalToFloat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("194c5e46-a93a-4e2f-a494-44b52f756dcc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3b0655c9-b8e2-48f0-b2fc-6e12e2764335"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("48f80e69-2492-4b7d-af2d-c20df5bfb023"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c38bc430-25e2-4f75-93ec-641a2e1b824c"));

            migrationBuilder.AlterColumn<float>(
                name: "Amount",
                table: "Finances",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<float>(
                name: "Amount",
                table: "Budgets",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8d2003ec-b650-4609-b987-8a8da342f1fa"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 23, 8, 39, 33, 372, DateTimeKind.Utc).AddTicks(2574), new DateTime(2024, 12, 23, 8, 39, 33, 372, DateTimeKind.Utc).AddTicks(2578) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Finances",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Budgets",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "IconUrl", "Name", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("194c5e46-a93a-4e2f-a494-44b52f756dcc"), new DateTime(2024, 12, 16, 3, 11, 57, 493, DateTimeKind.Utc).AddTicks(1065), null, "Food & Dining", new DateTime(2024, 12, 16, 3, 11, 57, 493, DateTimeKind.Utc).AddTicks(1065), new Guid("8d2003ec-b650-4609-b987-8a8da342f1fa") },
                    { new Guid("3b0655c9-b8e2-48f0-b2fc-6e12e2764335"), new DateTime(2024, 12, 16, 3, 11, 57, 493, DateTimeKind.Utc).AddTicks(1070), null, "Transportation", new DateTime(2024, 12, 16, 3, 11, 57, 493, DateTimeKind.Utc).AddTicks(1071), new Guid("8d2003ec-b650-4609-b987-8a8da342f1fa") },
                    { new Guid("48f80e69-2492-4b7d-af2d-c20df5bfb023"), new DateTime(2024, 12, 16, 3, 11, 57, 493, DateTimeKind.Utc).AddTicks(1068), null, "Housing", new DateTime(2024, 12, 16, 3, 11, 57, 493, DateTimeKind.Utc).AddTicks(1069), new Guid("8d2003ec-b650-4609-b987-8a8da342f1fa") },
                    { new Guid("c38bc430-25e2-4f75-93ec-641a2e1b824c"), new DateTime(2024, 12, 16, 3, 11, 57, 493, DateTimeKind.Utc).AddTicks(1072), null, "Health & Wellness", new DateTime(2024, 12, 16, 3, 11, 57, 493, DateTimeKind.Utc).AddTicks(1073), new Guid("8d2003ec-b650-4609-b987-8a8da342f1fa") }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8d2003ec-b650-4609-b987-8a8da342f1fa"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 16, 3, 11, 57, 493, DateTimeKind.Utc).AddTicks(862), new DateTime(2024, 12, 16, 3, 11, 57, 493, DateTimeKind.Utc).AddTicks(865) });
        }
    }
}
