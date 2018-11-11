using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nampula.DI.B1.Banks
{

    /// <summary>
    /// Tabela de BankStatementHeader
    /// </summary>
    public class BankStatementHeader : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "BankStatementHeader";
        }

        public struct FieldsName
        {
            public static readonly string IdNumber = "IdNumber";
            public static readonly string ActKey = "ActKey";
            public static readonly string BSNum = "BSNum";
            public static readonly string BSDate = "BSDate";
            public static readonly string Status = "Status";
            public static readonly string Imported = "Imported";
            public static readonly string StrtBlncF = "StrtBlncF";
            public static readonly string EndBlncF = "EndBlncF";
            public static readonly string Currency = "Currency";
            public static readonly string StrtBlncL = "StrtBlncL";
            public static readonly string EndBlncL = "EndBlncL";
            public static readonly string FileCRC = "FileCRC";
            public static readonly string StmtGuid = "StmtGuid";
            public static readonly string BSFileNum = "BSFileNum";
            public static readonly string PeriodAbs = "PeriodAbs";

        }

        public struct FieldsDescription
        {
            public static readonly string IdNumber = "Nº";
            public static readonly string ActKey = "Chave conta";
            public static readonly string BSNum = "Nº";
            public static readonly string BSDate = "Data Extrato";
            public static readonly string Status = "Status";
            public static readonly string Imported = "Importado";
            public static readonly string StrtBlncF = "Saldo inicial (FC)";
            public static readonly string EndBlncF = "Saldo final (FC)";
            public static readonly string Currency = "Moeda";
            public static readonly string StrtBlncL = "Saldo inicial (LC)";
            public static readonly string EndBlncL = "Saldo final (LC)";
            public static readonly string FileCRC = "FileCRC";
            public static readonly string StmtGuid = "StmtGuid";
            public static readonly string BSFileNum = "Nº Extrato bancário";
            public static readonly string PeriodAbs = "Nº Período";
        }

        TableAdapterField m_IdNumber = new TableAdapterField(FieldsName.IdNumber, FieldsDescription.IdNumber, DbType.Int32, 11, 0, true, true);
        TableAdapterField m_ActKey = new TableAdapterField(FieldsName.ActKey, FieldsDescription.ActKey, DbType.Int32);
        TableAdapterField m_BSNum = new TableAdapterField(FieldsName.BSNum, FieldsDescription.BSNum, DbType.Int32);
        TableAdapterField m_BSDate = new TableAdapterField(FieldsName.BSDate, FieldsDescription.BSDate, DbType.DateTime);
        TableAdapterField m_Status = new TableAdapterField(FieldsName.Status, FieldsDescription.Status, 1);
        TableAdapterField m_Imported = new TableAdapterField(FieldsName.Imported, FieldsDescription.Imported, 1);
        TableAdapterField m_StrtBlncF = new TableAdapterField(FieldsName.StrtBlncF, FieldsDescription.StrtBlncF, DbType.Decimal, 19, 6);
        TableAdapterField m_EndBlncF = new TableAdapterField(FieldsName.EndBlncF, FieldsDescription.EndBlncF, DbType.Decimal, 19, 6);
        TableAdapterField m_Currency = new TableAdapterField(FieldsName.Currency, FieldsDescription.Currency, 3);
        TableAdapterField m_StrtBlncL = new TableAdapterField(FieldsName.StrtBlncL, FieldsDescription.StrtBlncL, DbType.Decimal, 19, 6);
        TableAdapterField m_EndBlncL = new TableAdapterField(FieldsName.EndBlncL, FieldsDescription.EndBlncL, DbType.Decimal, 19, 6);
        TableAdapterField m_FileCRC = new TableAdapterField(FieldsName.FileCRC, FieldsDescription.FileCRC, 32);
        TableAdapterField m_StmtGuid = new TableAdapterField(FieldsName.StmtGuid, FieldsDescription.StmtGuid, 32);
        TableAdapterField m_BSFileNum = new TableAdapterField(FieldsName.BSFileNum, FieldsDescription.BSFileNum, 50);
        TableAdapterField m_PeriodAbs = new TableAdapterField(FieldsName.PeriodAbs, FieldsDescription.PeriodAbs, DbType.Int32);

        public BankStatementHeader()
            : base(Definition.TableName)
        {
        }

        public BankStatementHeader(string companyDb)
            : base(companyDb,Definition.TableName)
        {
        }

        public BankStatementHeader(BankStatementHeader pBankStatementHeader)
            : this()
        {
            this.CopyBy(pBankStatementHeader);
        }

        public int IdNumber
        {
            get { return m_IdNumber.GetInt32(); }
            set { m_IdNumber.Value = value; }
        }

        public Int32 ActKey
        {
            get { return m_ActKey.GetInt32(); }
            set { m_ActKey.Value = value; }
        }

        public Int32 BSNum
        {
            get { return m_BSNum.GetInt32(); }
            set { m_BSNum.Value = value; }
        }

        public DateTime BSDate
        {
            get { return m_BSDate.GetDateTime(); }
            set { m_BSDate.Value = value; }
        }

        public String Status
        {
            get { return m_Status.GetString(); }
            set { m_Status.Value = value; }
        }

        public String Imported
        {
            get { return m_Imported.GetString(); }
            set { m_Imported.Value = value; }
        }

        public Decimal StrtBlncF
        {
            get { return m_StrtBlncF.GetDecimal(); }
            set { m_StrtBlncF.Value = value; }
        }

        public Decimal EndBlncF
        {
            get { return m_EndBlncF.GetDecimal(); }
            set { m_EndBlncF.Value = value; }
        }

        public String Currency
        {
            get { return m_Currency.GetString(); }
            set { m_Currency.Value = value; }
        }

        public Decimal StrtBlncL
        {
            get { return m_StrtBlncL.GetDecimal(); }
            set { m_StrtBlncL.Value = value; }
        }

        public Decimal EndBlncL
        {
            get { return m_EndBlncL.GetDecimal(); }
            set { m_EndBlncL.Value = value; }
        }

        public String FileCRC
        {
            get { return m_FileCRC.GetString(); }
            set { m_FileCRC.Value = value; }
        }

        public String StmtGuid
        {
            get { return m_StmtGuid.GetString(); }
            set { m_StmtGuid.Value = value; }
        }

        public String BSFileNum
        {
            get { return m_BSFileNum.GetString(); }
            set { m_BSFileNum.Value = value; }
        }

        public Int32 PeriodAbs
        {
            get { return m_PeriodAbs.GetInt32(); }
            set { m_PeriodAbs.Value = value; }
        }




    }
}
