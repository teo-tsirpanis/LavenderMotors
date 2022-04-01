using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LavenderMotors.Database.Migrations
{
    public partial class pricecomputed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "LavenderMotors",
                table: "TransactionLines",
                type: "decimal(8,2)",
                precision: 8,
                scale: 2,
                nullable: false,
                computedColumnSql: "[Hours] * [PricePerHour]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                schema: "LavenderMotors",
                table: "TransactionLines");
        }
    }
}
