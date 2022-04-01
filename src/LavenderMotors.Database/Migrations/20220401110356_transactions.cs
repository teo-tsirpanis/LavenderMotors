using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LavenderMotors.Database.Migrations
{
    public partial class transactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                schema: "LavenderMotors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Cars_CarId",
                        column: x => x.CarId,
                        principalSchema: "LavenderMotors",
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "LavenderMotors",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Employees_ManagerId",
                        column: x => x.ManagerId,
                        principalSchema: "LavenderMotors",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionLines",
                schema: "LavenderMotors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EngineerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Hours = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    PricePerHour = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionLines_Employees_EngineerId",
                        column: x => x.EngineerId,
                        principalSchema: "LavenderMotors",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionLines_ServiceTasks_ServiceTaskId",
                        column: x => x.ServiceTaskId,
                        principalSchema: "LavenderMotors",
                        principalTable: "ServiceTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionLines_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalSchema: "LavenderMotors",
                        principalTable: "Transactions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLines_EngineerId",
                schema: "LavenderMotors",
                table: "TransactionLines",
                column: "EngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLines_ServiceTaskId",
                schema: "LavenderMotors",
                table: "TransactionLines",
                column: "ServiceTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLines_TransactionId",
                schema: "LavenderMotors",
                table: "TransactionLines",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CarId",
                schema: "LavenderMotors",
                table: "Transactions",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CustomerId",
                schema: "LavenderMotors",
                table: "Transactions",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ManagerId",
                schema: "LavenderMotors",
                table: "Transactions",
                column: "ManagerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionLines",
                schema: "LavenderMotors");

            migrationBuilder.DropTable(
                name: "Transactions",
                schema: "LavenderMotors");
        }
    }
}
