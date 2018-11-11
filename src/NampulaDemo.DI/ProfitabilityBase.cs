using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI;

namespace Iris.DI.Settings
{
    /// <summary>
    /// Tabela de Dominio para o Objeto ProfitabilityBaseType
    /// </summary>
    public class ProfitabilityBase : TableAdapterDomain<ProfitabilityBaseType>
    {
        #region Fields

        #region Definition
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "ProfitabilityBase";
        }
        #endregion
        #endregion

        #region Construtor

        public ProfitabilityBase()
            : base(Definition.TableName)
        {
            this.OnBeforeLoadValues += new TableAdapterEventHandler(ProfitabilityBase_OnBeforeLoadValues);
        }

        /// <summary>
        /// Evento disparado depois de criado a tabela
        /// </summary>
        /// <param name="Sender">Objeto que disparou</param>
        /// <param name="e">Propriedades di evento</param>
        void ProfitabilityBase_OnBeforeLoadValues(object Sender, TableAdapterEventArgs e)
        {
            InicialValues = new List<TableAdapter> {
                new ProfitabilityBase() { ID = ProfitabilityBaseType.None, Description = "Não Definido" },
                new ProfitabilityBase() { ID = ProfitabilityBaseType.LastPurchasePrice, Description = "Último preço de compra"},
                new ProfitabilityBase() { ID = ProfitabilityBaseType.PriceCost, Description = "Preço de Custo do Item" }};
        }

        public ProfitabilityBase(ProfitabilityBase pProfitabilityBase)
            : this()
        {
            this.CopyBy(pProfitabilityBase);
        }
        

        #endregion

        #region Metodos

        #region GetAll
        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de ProfitabilityBase.</returns>
        public List<ProfitabilityBase> GetAll()
        {
            return FillCollection<ProfitabilityBase>(GetAllOrder());
        }
        #endregion

        #endregion
    }
}
