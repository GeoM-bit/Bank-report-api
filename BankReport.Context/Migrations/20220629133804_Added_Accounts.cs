using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankReport.Context.Migrations
{
    public partial class Added_Accounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccountType = table.Column<int>(type: "INTEGER", nullable: false),
                    Iban = table.Column<string>(type: "TEXT", nullable: true),
                    QwnerName = table.Column<string>(type: "TEXT", nullable: true),
                    Currency = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
