using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.DI.B1.ProductionOrders
{
    public enum ProductionOrderStatusType
    {
        Planned,
        Released,
        Closed,
        Cancelled
    }

    public static class ProductionOrderStatusClass
    {
        private const string Planned = "P";
        private const string Released = "R";
        private const string Closed = "L";
        private const string Cancelled = "C";

        public static string GetName(this ProductionOrderStatusType pProductionOrderStatusType)
        {
            var name = string.Empty;

            switch (pProductionOrderStatusType)
            {
                case ProductionOrderStatusType.Planned:
                    name = "Planejado";
                    break;
                case ProductionOrderStatusType.Released:
                    name = "Liberado";
                    break;
                case ProductionOrderStatusType.Closed:
                    name = "Fechado";
                    break;
                case ProductionOrderStatusType.Cancelled:
                    name = "Cancelado";
                    break;
                default:
                    break;
            }

            return name;
        }

        public static string ToStringEnum(this ProductionOrderStatusType pProductionOrderStatusType)
        {
            var name = string.Empty;

            switch (pProductionOrderStatusType)
            {
                case ProductionOrderStatusType.Planned:
                    name = Planned;
                    break;
                case ProductionOrderStatusType.Released:
                    name = Released;
                    break;
                case ProductionOrderStatusType.Closed:
                    name = Closed;
                    break;
                case ProductionOrderStatusType.Cancelled:
                    name = Cancelled;
                    break;
                default:
                    break;
            }
            return name;
        }

        public static ProductionOrderStatusType ToEnum(this string pProductionOrderStatusType)
        {
            switch (pProductionOrderStatusType)
            {
                case Planned:
                    return ProductionOrderStatusType.Planned;
                case Released:
                    return ProductionOrderStatusType.Released;
                case Closed:
                    return ProductionOrderStatusType.Closed;
                case Cancelled:
                default:
                    return ProductionOrderStatusType.Cancelled;
            }
        }
    }

    public enum ProductionOrderType
    {
        Standard,
        Special,
        Disassembly
    }

    public static class ProductionOrderClass
    {
        private const string Standard = "S";
        private const string Special = "P";
        private const string Disassembly = "D";

        public static string GetName(this ProductionOrderType pProductionOrderType)
        {
            var name = string.Empty;

            switch (pProductionOrderType)
            {
                case ProductionOrderType.Standard:
                    name = "Padrão";
                    break;
                case ProductionOrderType.Special:
                    name = "Especial";
                    break;
                case ProductionOrderType.Disassembly:
                    name = "Desmontagem";
                    break;
                default:
                    break;
            }

            return name;
        }

        public static string ToStringEnum(this ProductionOrderType pProductionOrderType)
        {
            var name = string.Empty;

            switch (pProductionOrderType)
            {
                case ProductionOrderType.Standard:
                    name = Standard;
                    break;
                case ProductionOrderType.Special:
                    name = Special;
                    break;
                case ProductionOrderType.Disassembly:
                    name = Disassembly;
                    break;
                default:
                    break;
            }

            return name;
        }

        public static ProductionOrderType ToEnum(this string pProductionOrderType)
        {
            switch (pProductionOrderType)
            {
                case Special:
                    return ProductionOrderType.Special;
                case Disassembly:
                    return ProductionOrderType.Disassembly;
                case Standard:
                default:
                    return ProductionOrderType.Standard;
            }
        }
    }
}
