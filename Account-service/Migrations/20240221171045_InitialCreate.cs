using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace account_service.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    accountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    balance = table.Column<double>(type: "float", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accountType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.accountId);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "accountId", "accountType", "balance", "createdAt", "currency", "customerId" },
                values: new object[,]
                {
                    { "A1", "CURRENT_ACCOUNT", 12.0, new DateTime(2024, 2, 21, 17, 10, 44, 556, DateTimeKind.Utc).AddTicks(4165), "DHs", 1L },
                    { "A2", "SAVING_ACCOUNT", 14.0, new DateTime(2024, 2, 21, 17, 10, 44, 556, DateTimeKind.Utc).AddTicks(4247), "Dollar", 2L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
