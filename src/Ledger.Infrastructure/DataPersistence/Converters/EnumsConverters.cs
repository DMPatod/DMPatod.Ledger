using Ledger.Domain.Products.Enums;
using Ledger.Domain.Tickets.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ledger.Infrastructure.DataPersistence.Converters
{
    internal class EnumsConverters
    {
        public static readonly ValueConverter<Currency, string> CurrencyConverter = new(
            v => v.ToString(),
            v => (Currency)Enum.Parse(typeof(Currency), v));

        public static readonly ValueConverter<Direction, string> DirectionConverter = new(
            v => v.ToString(),
            v => (Direction)Enum.Parse(typeof(Direction), v));

        public static readonly ValueConverter<MesureUnit, string> MesureUnitConverter = new(
            v => v.ToString(),
            v => (MesureUnit)Enum.Parse(typeof(MesureUnit), v));
    }
}
