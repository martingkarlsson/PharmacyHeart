using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmacyOrderApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.Sql($"INSERT INTO [dbo].[Orders]" +
                $"([CustomerId],[Created],[Status],[TotalCost])" +
                $"VALUES(1,'2022-10-25 22:30:00.0000000',0,250)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Orders]" +
                $"([CustomerId],[Created],[Status],[TotalCost])" +
                $"VALUES(2,'2022-10-25 22:30:00.0000000',0,350)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
