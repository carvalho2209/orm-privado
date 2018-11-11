using System;
using System.Data;

namespace Nampula.DI.B1.Itens
{

    /// <summary>
    /// Tabela de Código de Barras dos Itens
    /// </summary>
    public class BarCodeMasterData : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OBCD";
        }

        public struct FieldsName
        {
            public static readonly string BcdEntry = "BcdEntry";
            public static readonly string BcdCode = "BcdCode";
            public static readonly string BcdName = "BcdName";
            public static readonly string ItemCode = "ItemCode";
            public static readonly string UomEntry = "UomEntry";
        }

        public struct FieldsDescription
        {
            public static readonly string BcdEntry = "Nº";
            public static readonly string BcdCode = "Código de Barras";
            public static readonly string BcdName = "Nome do Código de Barras";
            public static readonly string ItemCode = "N° do Item";
            public static readonly string UomEntry = "Nº da Unidade de Medida";
        }

        readonly TableAdapterField m_BcdEntry = new TableAdapterField(FieldsName.BcdEntry, FieldsDescription.BcdEntry, DbType.Int32, 11, 0, true, true);
        readonly TableAdapterField m_BcdCode = new TableAdapterField(FieldsName.BcdCode, FieldsDescription.BcdCode, 16);
        readonly TableAdapterField m_BcdName = new TableAdapterField(FieldsName.BcdName, FieldsDescription.BcdName, 100);
        readonly TableAdapterField m_ItemCode = new TableAdapterField(FieldsName.ItemCode, FieldsDescription.ItemCode, 40);
        readonly TableAdapterField m_UomEntry = new TableAdapterField(FieldsName.UomEntry, FieldsDescription.UomEntry, DbType.Int32);

        public BarCodeMasterData()
            : base(Definition.TableName)
        {
        }

        public BarCodeMasterData(BarCodeMasterData pBarCodeMasterData)
            : this()
        {
            this.CopyBy(pBarCodeMasterData);
        }

        public int BcdEntry
        {
            get { return m_BcdEntry.GetInt32(); }
            set { m_BcdEntry.Value = value; }
        }

        public String BcdCode
        {
            get { return m_BcdCode.GetString(); }
            set { m_BcdCode.Value = value; }
        }

        public String BcdName
        {
            get { return m_BcdName.GetString(); }
            set { m_BcdName.Value = value; }
        }

        public String ItemCode
        {
            get { return m_ItemCode.GetString(); }
            set { m_ItemCode.Value = value; }
        }

        public Int32 UomEntry
        {
            get { return m_UomEntry.GetInt32(); }
            set { m_UomEntry.Value = value; }
        }


    }
}
