using Microsoft.EntityFrameworkCore.Migrations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;

#nullable disable

namespace Ledger.Infrastructure.DataPersistence.Migrations
{
    /// <inheritdoc />
    public partial class ProductAvgTrigger : Migration
    {
        private static readonly string TriggerSQL =
@"CREATE TRIGGER ProductAverageValueTrigger
ON Orders
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
	BEGIN TRY
		UPDATE Products
		SET AverageValue = (
			SELECT AVG(o.Value)
			FROM Orders o
			WHERE o.ProductId = Products.Id
			)
		WHERE Products.Id IN (
			SELECT i.ProductId
			FROM Inserted i
		);
	END TRY
	BEGIN CATCH
		INSERT INTO Ledger.dbo.Log (Msg)
		VALUES (ERROR_MESSAGE());
	END CATCH
END";

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AverageValue",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.Sql(TriggerSQL);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS ProductAverageValueTrigger");

            migrationBuilder.DropColumn(
                name: "AverageValue",
                table: "Products");
        }
    }
}
