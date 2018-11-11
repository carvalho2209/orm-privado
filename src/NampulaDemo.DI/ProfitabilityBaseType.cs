using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iris.DI.Settings {
    /// <summary>
    /// Origem do Preço para calculo de lucratividade
    /// </summary>
    public enum ProfitabilityBaseType {
        None,
        LastPurchasePrice,
        PriceCost
    }
}
