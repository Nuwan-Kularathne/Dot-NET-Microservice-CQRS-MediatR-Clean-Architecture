using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TyreManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TyreProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    QuantityInStock = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TyreProducts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TyreProducts",
                columns: new[] { "Id", "DateCreated", "DateModified", "Name", "QuantityInStock", "UnitPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michelin Pilot Sport", 5000, 100.0 },
                    { 2, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kumho E31", 10000, 200.0 },
                    { 3, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bridgestone Turanza Serenity", 15000, 300.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TyreProducts");
        }
    }
}
