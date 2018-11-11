using System;

namespace Nampula.DI.B1.Administrations
{

    /// <summary>
    /// Tabela de description
    /// </summary>
    public class Currency : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OCRN";
        }

        public struct FieldsName
        {
            
            public static readonly string CurrCode = "CurrCode";
            public static readonly string CurrName = "CurrName";
            public static readonly string ChkName = "ChkName";
        }

        public struct FieldsDescription
        {
            
            public static readonly string CurrCode = "Código da moeda";
            public static readonly string CurrName = "Nome da moeda";
            public static readonly string ChkName = "Abr. moeda";
        }

        readonly TableAdapterField m_CurrCode = new TableAdapterField(FieldsName.CurrCode, FieldsDescription.CurrCode, 20);
        readonly TableAdapterField m_CurrName = new TableAdapterField(FieldsName.CurrName, FieldsDescription.CurrName, 20);
        readonly TableAdapterField m_ChkName = new TableAdapterField(FieldsName.ChkName, FieldsDescription.ChkName, 20);

        public Currency()
            : base(Definition.TableName)
        {            
        }

        public Currency(string companyDb)
            : this()
        {
            DBName = companyDb;
        }
        
        public String CurrName
        {
            get { return m_CurrName.GetString(); }
            set { m_CurrName.Value = value; }
        }

        public String CurrCode
        {
            get { return m_CurrCode.GetString(); }
            set { m_CurrCode.Value = value; }
        }

        public String ChkName
        {
            get { return m_ChkName.GetString(); }
            set { m_ChkName.Value = value; }
        }

    }
}

