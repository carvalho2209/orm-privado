using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.Itens
{

    public class ItemWareHouse : TableAdapter
    {

        
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OITW";
        }
        

        public struct FieldsName
        {
            public static readonly string ItemCode = "ItemCode";
            public static readonly string WhsCode = "WhsCode";
            public static readonly string OnHand = "OnHand";
            public static readonly string IsCommited = "IsCommited";
            public static readonly string OnOrder = "OnOrder";
            public static readonly string Available = "Available";
            public static readonly string AvgPrice = "AvgPrice";
        }

        public struct Description
        {
            public static readonly string ItemCode = "Código do Item";
            public static readonly string WhsCode = "Depósito";
            public static readonly string OnHand = "Em Estoque";
            public static readonly string IsCommited = "Saída Precista";
            public static readonly string OnOrder = "Entrada Prevista";
            public static readonly string Available = "Quantidade Disponível";
            public static readonly string AvgPrice = "Preço de Custo";
        }

        TableAdapterField m_ItemCode = new TableAdapterField(FieldsName.ItemCode, Description.ItemCode, DbType.String, 15, null, true, false);
        TableAdapterField m_WhsCode = new TableAdapterField(FieldsName.WhsCode, Description.WhsCode, DbType.String, 8, null, true, false);
        TableAdapterField m_OnHand = new TableAdapterField(FieldsName.OnHand, Description.OnHand, DbType.Decimal);
        TableAdapterField m_IsCommited = new TableAdapterField(FieldsName.IsCommited, Description.IsCommited, DbType.Decimal);
        TableAdapterField m_OnOrder = new TableAdapterField(FieldsName.OnOrder, Description.OnOrder, DbType.Decimal);
        TableAdapterField m_AvgPrice = new TableAdapterField(FieldsName.AvgPrice, Description.AvgPrice, DbType.Decimal, 19, 6);

        public ItemWareHouse()
            : base(Definition.TableName)
        {
        }

        public ItemWareHouse(string pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        public string ItemCode
        {
            get { return m_ItemCode.GetString(); }
            set { m_ItemCode.Value = value; }
        }

        public string WhsCode
        {
            get { return m_WhsCode.GetString(); }
            set { m_WhsCode.Value = value; }
        }

        public decimal OnHand
        {
            get { return m_OnHand.GetDecimal(); }
            set { m_OnHand.Value = value; }
        }

        public decimal IsCommited
        {
            get { return m_IsCommited.GetDecimal(); }
            set { m_IsCommited.Value = value; }
        }

        public decimal OnOrder
        {
            get { return m_OnOrder.GetDecimal(); }
            set { m_OnOrder.Value = value; }
        }

        public Decimal AvgPrice
        {
            get { return m_AvgPrice.GetDecimal(); }
            set { m_AvgPrice.Value = value; }
        }

        
        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="pID">Código.</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public bool GetByKey(string pItemCode, string pWhsCode)
        {
            this.ItemCode = pItemCode;
            this.WhsCode = pWhsCode;
            return GetByKey();
        }
        

        
        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de ItemWareHouse.</returns>
        public List<ItemWareHouse> GetAll()
        {
            return FillCollection<ItemWareHouse>(this.GetData().Rows);
        }
        


    }

}
