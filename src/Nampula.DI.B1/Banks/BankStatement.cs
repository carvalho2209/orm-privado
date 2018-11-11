using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nampula.DI.B1.Banks
{

    /// <summary>
    /// Tabela de BankStatement
    /// </summary>
    public class BankStatement : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OBNK";
        }

        public struct FieldsName
        {
            public static readonly string IdNumber = "IdNumber";
            public static readonly string AcctCode = "AcctCode";
            public static readonly string Sequence = "Sequence";
            public static readonly string AcctName = "AcctName";
            public static readonly string Ref = "Ref";
            public static readonly string DueDate = "DueDate";
            public static readonly string Memo = "Memo";
            public static readonly string DebAmount = "DebAmount";
            public static readonly string DebAmntCur = "DebAmntCur";
            public static readonly string CredAmnt = "CredAmnt";
            public static readonly string CredAmntCu = "CredAmntCu";
            public static readonly string Memo2 = "Memo2";
            public static readonly string ExternCode = "ExternCode";
            public static readonly string BSLineDate = "BSLineDate";
            public static readonly string BSValuDate = "BSValuDate";
            public static readonly string LnDocDate = "LnDocDate";
            public static readonly string PmnPstDate = "PmnPstDate";
            public static readonly string InOpCode = "InOpCode";
            public static readonly string PmnValDate = "PmnValDate";
            public static readonly string BankMatch = "BankMatch";
            public static readonly string DocNum = "DocNum";
        }

        public struct FieldsDescription
        {
            public static readonly string IdNumber = "Nº";
            public static readonly string AcctCode = "Código Conta";
            public static readonly string Sequence = "Sequência";
            public static readonly string AcctName = "Nome da conta";
            public static readonly string Ref = "Referência";
            public static readonly string DueDate = "Vencimento";
            public static readonly string Memo = "Detalhe";
            public static readonly string DebAmount = "Valor de Débito";
            public static readonly string DebAmntCur = "Valor de Débito-Moeda ";
            public static readonly string CredAmnt = "Valor de Crédito";
            public static readonly string CredAmntCu = "Valor de Crédito-Moeda";
            public static readonly string Memo2 = "Detalhe 2";
            public static readonly string ExternCode = "Código Externo";
            public static readonly string BSLineDate = "Data linha";
            public static readonly string BSValuDate = "Data vencimento extrato";
            public static readonly string LnDocDate = "Data do Documento";
            public static readonly string PmnPstDate = "Data do Lançamento";
            public static readonly string InOpCode = "Código de Operação Interno";
            public static readonly string PmnValDate = "Vencimento";
            public static readonly string BankMatch = "N° da Reconciliação";
            public static readonly string DocNum = "N° do Documento";
        }

        readonly TableAdapterField m_IdNumber = new TableAdapterField(FieldsName.IdNumber, FieldsDescription.IdNumber, DbType.Int32);
        readonly TableAdapterField m_AcctCode = new TableAdapterField(FieldsName.AcctCode, FieldsDescription.AcctCode, DbType.String, 15, "", true, false);
        readonly TableAdapterField m_Sequence = new TableAdapterField(FieldsName.Sequence, FieldsDescription.Sequence, DbType.Int32, 11, 0, true, false);
        readonly TableAdapterField m_AcctName = new TableAdapterField(FieldsName.AcctName, FieldsDescription.AcctName, 100);
        readonly TableAdapterField m_Ref = new TableAdapterField(FieldsName.Ref, FieldsDescription.Ref, 27);
        readonly TableAdapterField m_DueDate = new TableAdapterField(FieldsName.DueDate, FieldsDescription.DueDate, DbType.DateTime);
        readonly TableAdapterField m_Memo = new TableAdapterField(FieldsName.Memo, FieldsDescription.Memo, 254);
        readonly TableAdapterField m_DebAmount = new TableAdapterField(FieldsName.DebAmount, FieldsDescription.DebAmount, DbType.Decimal, 19, 6);
        readonly TableAdapterField m_DebAmntCur = new TableAdapterField(FieldsName.DebAmntCur, FieldsDescription.DebAmntCur, 3);
        readonly TableAdapterField m_CredAmnt = new TableAdapterField(FieldsName.CredAmnt, FieldsDescription.CredAmnt, DbType.Decimal, 19, 6);
        readonly TableAdapterField m_CredAmntCu = new TableAdapterField(FieldsName.CredAmntCu, FieldsDescription.CredAmntCu, 3);
        readonly TableAdapterField m_Memo2 = new TableAdapterField(FieldsName.Memo2, FieldsDescription.Memo2, 254);
        readonly TableAdapterField m_ExternCode = new TableAdapterField(FieldsName.ExternCode, FieldsDescription.ExternCode, 30);
        readonly TableAdapterField m_BSLineDate = new TableAdapterField(FieldsName.BSLineDate, FieldsDescription.BSLineDate, DbType.DateTime);
        readonly TableAdapterField m_BSValuDate = new TableAdapterField(FieldsName.BSValuDate, FieldsDescription.BSValuDate, DbType.DateTime);
        readonly TableAdapterField m_LnDocDate = new TableAdapterField(FieldsName.LnDocDate, FieldsDescription.LnDocDate, DbType.DateTime);
        readonly TableAdapterField m_PmnPstDate = new TableAdapterField(FieldsName.PmnPstDate, FieldsDescription.PmnPstDate, DbType.DateTime);
        readonly TableAdapterField m_InOpCode = new TableAdapterField(FieldsName.InOpCode, FieldsDescription.InOpCode, DbType.Int32);
        readonly TableAdapterField m_PmnValDate = new TableAdapterField(FieldsName.PmnValDate, FieldsDescription.PmnValDate, DbType.DateTime);
        readonly TableAdapterField m_BankMatch = new TableAdapterField(FieldsName.BankMatch, FieldsDescription.BankMatch, DbType.Int32);
        readonly TableAdapterField m_DocNum = new TableAdapterField(FieldsName.DocNum, FieldsDescription.DocNum, 54);

        public BankStatement()
            : base(Definition.TableName)
        {
        }

        public BankStatement(string companyDb)
            : base(companyDb, Definition.TableName)
        {
        }

        public BankStatement(BankStatement pBankStatement)
            : this()
        {
            this.CopyBy(pBankStatement);
        }

        public Int32 IdNumber
        {
            get { return m_IdNumber.GetInt32(); }
            set { m_IdNumber.Value = value; }
        }

        public String AcctCode
        {
            get { return m_AcctCode.GetString(); }
            set { m_AcctCode.Value = value; }
        }

        public Int32 Sequence
        {
            get { return m_Sequence.GetInt32(); }
            set { m_Sequence.Value = value; }
        }

        public String AcctName
        {
            get { return m_AcctName.GetString(); }
            set { m_AcctName.Value = value; }
        }

        public String Ref
        {
            get { return m_Ref.GetString(); }
            set { m_Ref.Value = value; }
        }

        public DateTime DueDate
        {
            get { return m_DueDate.GetDateTime(); }
            set { m_DueDate.Value = value; }
        }

        public String Memo
        {
            get { return m_Memo.GetString(); }
            set { m_Memo.Value = value; }
        }

        public Decimal DebAmount
        {
            get { return m_DebAmount.GetDecimal(); }
            set { m_DebAmount.Value = value; }
        }

        public String DebAmntCur
        {
            get { return m_DebAmntCur.GetString(); }
            set { m_DebAmntCur.Value = value; }
        }

        public Decimal CredAmnt
        {
            get { return m_CredAmnt.GetDecimal(); }
            set { m_CredAmnt.Value = value; }
        }

        public String CredAmntCu
        {
            get { return m_CredAmntCu.GetString(); }
            set { m_CredAmntCu.Value = value; }
        }

        public String Memo2
        {
            get { return m_Memo2.GetString(); }
            set { m_Memo2.Value = value; }
        }

        public String ExternCode
        {
            get { return m_ExternCode.GetString(); }
            set { m_ExternCode.Value = value; }
        }

        public DateTime BSLineDate
        {
            get { return m_BSLineDate.GetDateTime(); }
            set { m_BSLineDate.Value = value; }
        }

        public DateTime BSValuDate
        {
            get { return m_BSValuDate.GetDateTime(); }
            set { m_BSValuDate.Value = value; }
        }

        public DateTime LnDocDate
        {
            get { return m_LnDocDate.GetDateTime(); }
            set { m_LnDocDate.Value = value; }
        }

        public DateTime PmnPstDate
        {
            get { return m_PmnPstDate.GetDateTime(); }
            set { m_PmnPstDate.Value = value; }
        }

        public Int32 InOpCode
        {
            get { return m_InOpCode.GetInt32(); }
            set { m_InOpCode.Value = value; }
        }

        public Int32 BankMatch
        {
            get { return m_BankMatch.GetInt32(); }
            set { m_BankMatch.Value = value; }
        }

        public DateTime PmnValDate
        {
            get { return m_PmnValDate.GetDateTime(); }
            set { m_PmnValDate.Value = value; }
        }

        public String DocNum
        {
            get { return m_DocNum.GetString(); }
            set { m_DocNum.Value = value; }
        }


        public bool GetByKey(string acctCode, int sequence)
        {
            this.AcctCode = acctCode;
            this.Sequence = sequence;
            return GetByKey();
        }


    }
}
