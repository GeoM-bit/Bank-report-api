using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankReport.Context.Migrations
{
    public partial class Added_Transaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    CategoryTransaction = table.Column<int>(type: "INTEGER", nullable: false),
                    TransactionDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    AccountIdId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_AccountIdId",
                        column: x => x.AccountIdId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountIdId",
                table: "Transactions",
                column: "AccountIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
