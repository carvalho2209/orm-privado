using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nampula.DI.B1.SalesTaxCode
{

    /// <summary>
    /// Tabela de campos de atributo do imposto
    /// </summary>
    public class TaxPerameterAttribute : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OTPA";
        }

        public struct FieldsName
        {
            public static readonly string AbsId = "AbsId";
            public static readonly string Code = "Code";
            public static readonly string Descr = "Descr";
        }

        public struct FieldsDescription
        {
            public static readonly string AbsId = "Nº";
            public static readonly string Code = "Código";
            public static readonly string Descr = "Descr";
        }

        TableAdapterField m_AbsId = new TableAdapterField(FieldsName.AbsId, FieldsDescription.AbsId, DbType.Int32, 11, 0, true, true);
        TableAdapterField m_Code = new TableAdapterField(FieldsName.Code, FieldsDescription.Code, 16);
        TableAdapterField m_Descr = new TableAdapterField(FieldsName.Descr, FieldsDescription.Descr, 16);

        public TaxPerameterAttribute()
            : base(Definition.TableName)
        {
        }

        public TaxPerameterAttribute(TaxPerameterAttribute pTaxPeramterAttribute)
            : this()
        {
            this.CopyBy(pTaxPeramterAttribute);
        }

        public int AbsId
        {
            get { return m_AbsId.GetInt32(); }
            set { m_AbsId.Value = value; }
        }

        public String Code
        {
            get { return m_Code.GetString(); }
            set { m_Code.Value = value; }
        }

        public String Descr
        {
            get { return m_Descr.GetString(); }
            set { m_Descr.Value = value; }
        }


    }
}
