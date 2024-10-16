using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ledger.Infrastructure.DataPersistence.Migrations
{
    /// <inheritdoc />
    public partial class AddEnumsConvertersOnTicketsAndProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Direction
            migrationBuilder.AddColumn<int>(
                name: "DirectionTemp",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql("UPDATE Tickets SET DirectionTemp = 0 WHERE Direction = 0");
            migrationBuilder.Sql("UPDATE Tickets SET DirectionTemp = 1 WHERE Direction = 1");

            migrationBuilder.AlterColumn<string>(
                name: "Direction",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            // Currency
            migrationBuilder.AddColumn<int>(
                name: "CurrencyTemp",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql("UPDATE Tickets SET CurrencyTemp = 0 WHERE Currency = 0");
            migrationBuilder.Sql("UPDATE Tickets SET CurrencyTemp = 1 WHERE Currency = 1");
            migrationBuilder.Sql("UPDATE Tickets SET CurrencyTemp = 2 WHERE Currency = 2");

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            // MesureUnit
            migrationBuilder.AddColumn<int>(
                name: "MesureUnitTemp",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql("UPDATE Products SET MesureUnitTemp = 0 WHERE MesureUnit = 0");
            migrationBuilder.Sql("UPDATE Products SET MesureUnitTemp = 1 WHERE MesureUnit = 1");
            migrationBuilder.Sql("UPDATE Products SET MesureUnitTemp = 2 WHERE MesureUnit = 2");
            migrationBuilder.Sql("UPDATE Products SET MesureUnitTemp = 3 WHERE MesureUnit = 3");

            migrationBuilder.AlterColumn<string>(
                name: "MesureUnit",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.Sql("UPDATE Tickets SET Direction = 'Income' WHERE DirectionTemp = 0");
            migrationBuilder.Sql("UPDATE Tickets SET Direction = 'Outcome' WHERE DirectionTemp = 1");

            migrationBuilder.DropColumn(
                name: "DirectionTemp",
                table: "Tickets");

            migrationBuilder.Sql("UPDATE Tickets SET Currency = 'USD' WHERE CurrencyTemp = 0");
            migrationBuilder.Sql("UPDATE Tickets SET Currency = 'BRL' WHERE CurrencyTemp = 1");
            migrationBuilder.Sql("UPDATE Tickets SET Currency = 'NZD' WHERE CurrencyTemp = 2");

            migrationBuilder.DropColumn(
                name: "CurrencyTemp",
                table: "Tickets");

            migrationBuilder.Sql("UPDATE Products SET MesureUnit = 'Kilogram' WHERE MesureUnitTemp = 0");
            migrationBuilder.Sql("UPDATE Products SET MesureUnit = 'Unit' WHERE MesureUnitTemp = 1");
            migrationBuilder.Sql("UPDATE Products SET MesureUnit = 'Liter' WHERE MesureUnitTemp = 2");
            migrationBuilder.Sql("UPDATE Products SET MesureUnit = 'Meter' WHERE MesureUnitTemp = 3");

            migrationBuilder.DropColumn(
                name: "MesureUnitTemp",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Direction
            migrationBuilder.AddColumn<int>(
                name: "DirectionTemp",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql("UPDATE Tickets SET DirectionTemp = 0 WHERE Direction = 'Income'");
            migrationBuilder.Sql("UPDATE Tickets SET DirectionTemp = 1 WHERE Direction = 'Outcome'");

            migrationBuilder.AlterColumn<int>(
                name: "Direction",
                table: "Tickets",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.Sql("UPDATE Tickets SET Direction = 0 WHERE DirectionTemp = 0");
            migrationBuilder.Sql("UPDATE Tickets SET Direction = 1 WHERE DirectionTemp = 1");

            migrationBuilder.DropColumn(
                name: "DirectionTemp",
                table: "Tickets");

            // Currency
            migrationBuilder.AddColumn<int>(
                name: "CurrencyTemp",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql("UPDATE Tickets SET CurrencyTemp = 0 WHERE Currency = 'USD'");
            migrationBuilder.Sql("UPDATE Tickets SET CurrencyTemp = 1 WHERE Currency = 'BRL'");
            migrationBuilder.Sql("UPDATE Tickets SET CurrencyTemp = 2 WHERE Currency = 'NZD'");

            migrationBuilder.AlterColumn<int>(
                name: "Currency",
                table: "Tickets",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.Sql("UPDATE Tickets SET Currency = 0 WHERE CurrencyTemp = 0");
            migrationBuilder.Sql("UPDATE Tickets SET Currency = 1 WHERE CurrencyTemp = 1");
            migrationBuilder.Sql("UPDATE Tickets SET Currency = 2 WHERE CurrencyTemp = 2");

            migrationBuilder.DropColumn(
                name: "CurrencyTemp",
                table: "Tickets");

            // MesureUnit
            migrationBuilder.AddColumn<int>(
                name: "MesureUnitTemp",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql("UPDATE Products SET MesureUnitTemp = 0 WHERE MesureUnit = 'Kilogram'");
            migrationBuilder.Sql("UPDATE Products SET MesureUnitTemp = 1 WHERE MesureUnit = 'Unit'");
            migrationBuilder.Sql("UPDATE Products SET MesureUnitTemp = 2 WHERE MesureUnit = 'Liter'");
            migrationBuilder.Sql("UPDATE Products SET MesureUnitTemp = 3 WHERE MesureUnit = 'Meter'");

            migrationBuilder.AlterColumn<int>(
                name: "MesureUnit",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.Sql("UPDATE Products SET MesureUnit = 0 WHERE MesureUnitTemp = 0");
            migrationBuilder.Sql("UPDATE Products SET MesureUnit = 1 WHERE MesureUnitTemp = 1");
            migrationBuilder.Sql("UPDATE Products SET MesureUnit = 2 WHERE MesureUnitTemp = 2");
            migrationBuilder.Sql("UPDATE Products SET MesureUnit = 3 WHERE MesureUnitTemp = 3");

            migrationBuilder.DropColumn(
                name: "MesureUnitTemp",
                table: "Products");
        }
    }
}
