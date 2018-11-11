using System;
using System.Data;

namespace Nampula.DI.B1.NotaFiscal
{

    /// <summary>
    /// Tabela de CST do SAP
    /// </summary>
    public class NotaFiscalCstCode : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OTSC";
        }

        public struct FieldsName
        {
            public static readonly string Id = "Id";
            public static readonly string Code = "Code";
            public static readonly string Situation = "Situation";
            public static readonly string Category = "Category";
            public static readonly string CodeOut = "CodeOut";
            public static readonly string OutDesc = "OutDesc";
        }

        public struct FieldsDescription
        {
            public static readonly string Id = "Nº";
            public static readonly string Code = "Code";
            public static readonly string Situation = "Situation";
            public static readonly string Category = "Category";
            public static readonly string CodeOut = "CodeOut";
            public static readonly string OutDesc = "OutDesc";
        }

        TableAdapterField m_Id = new TableAdapterField(FieldsName.Id, FieldsDescription.Id, DbType.Int32, 11, 0, true, true);
        TableAdapterField m_Code = new TableAdapterField(FieldsName.Code, FieldsDescription.Code, 20);
        TableAdapterField m_Situation = new TableAdapterField(FieldsName.Situation, FieldsDescription.Situation, 400);
        TableAdapterField m_Category = new TableAdapterField(FieldsName.Category, FieldsDescription.Category, DbType.Int32);
        TableAdapterField m_CodeOut = new TableAdapterField(FieldsName.CodeOut, FieldsDescription.CodeOut, 20);
        TableAdapterField m_OutDesc = new TableAdapterField(FieldsName.OutDesc, FieldsDescription.OutDesc, 400);

        public NotaFiscalCstCode()
            : base(Definition.TableName)
        {
        }

        public NotaFiscalCstCode(string pCompanyDb)
            : this()
        {
            DBName = pCompanyDb;
        }

        public NotaFiscalCstCode(NotaFiscalCstCode pNotaFiscalCstCode)
            : this()
        {
            CopyBy(pNotaFiscalCstCode);
        }

        public int Id
        {
            get { return m_Id.GetInt32(); }
            set { m_Id.Value = value; }
        }

        public String Code
        {
            get { return m_Code.GetString(); }
            set { m_Code.Value = value; }
        }

        public String Situation
        {
            get { return m_Situation.GetString(); }
            set { m_Situation.Value = value; }
        }

        public Int32 Category
        {
            get { return m_Category.GetInt32(); }
            set { m_Category.Value = value; }
        }

        public String CodeOut
        {
            get { return m_CodeOut.GetString(); }
            set { m_CodeOut.Value = value; }
        }

        public String OutDesc
        {
            get { return m_OutDesc.GetString(); }
            set { m_OutDesc.Value = value; }
        }


    }
}
