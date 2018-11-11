using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nampula.DI.B1.Banks
{
    
    /// <summary>
    /// Tabela de InternalBankOperation
    /// </summary>
    public class InternalBankOperation : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OBTC";
        }

        public struct FieldsName
        {
            public static readonly string AbsEntry = "AbsEntry";
            public static readonly string InOpCode = "InOpCode";
            public static readonly string PstTrans = "PstTrans";
            public static readonly string UpdateDate = "UpdateDate";
            public static readonly string Descript = "Descript";
            public static readonly string UserSign = "UserSign";
            public static readonly string ActFee = "ActFee";
        }

        public struct FieldsDescription
        {
            public static readonly string AbsEntry = "Nº";
            public static readonly string InOpCode = "Código";
            public static readonly string PstTrans = "PstTrans";
            public static readonly string UpdateDate = "UpdateDate";
            public static readonly string Descript = "Descript";
            public static readonly string UserSign = "UserSign";
            public static readonly string ActFee = "Conta da taxa";
        }

        TableAdapterField m_AbsEntry = new TableAdapterField(FieldsName.AbsEntry, FieldsDescription.AbsEntry, DbType.Int32, 11, 0, true, false);
        TableAdapterField m_InOpCode = new TableAdapterField(FieldsName.InOpCode, FieldsDescription.InOpCode, 15);
        TableAdapterField m_PstTrans = new TableAdapterField(FieldsName.PstTrans, FieldsDescription.PstTrans, 1);
        TableAdapterField m_UpdateDate = new TableAdapterField(FieldsName.UpdateDate, FieldsDescription.UpdateDate, DbType.DateTime);
        TableAdapterField m_Descript = new TableAdapterField(FieldsName.Descript, FieldsDescription.Descript, 40);
        TableAdapterField m_UserSign = new TableAdapterField(FieldsName.UserSign, FieldsDescription.UserSign, DbType.Int32);
        TableAdapterField m_ActFee = new TableAdapterField(FieldsName.ActFee, FieldsDescription.ActFee, 15);


        public InternalBankOperation()
            : base(Definition.TableName)
        {
        }

        public InternalBankOperation(string companyDb)
            : base(companyDb, Definition.TableName)
        {
        }

        public InternalBankOperation(InternalBankOperation pInternalBankOperation)
            : this()
        {
            this.CopyBy(pInternalBankOperation);
        }

        public Int32 AbsEntry
        {
            get { return m_AbsEntry.GetInt32(); }
            set { m_AbsEntry.Value = value; }
        }

        public String InOpCode
        {
            get { return m_InOpCode.GetString(); }
            set { m_InOpCode.Value = value; }
        }

        public String PstTrans
        {
            get { return m_PstTrans.GetString(); }
            set { m_PstTrans.Value = value; }
        }

        public DateTime UpdateDate
        {
            get { return m_UpdateDate.GetDateTime(); }
            set { m_UpdateDate.Value = value; }
        }

        public String Descript
        {
            get { return m_Descript.GetString(); }
            set { m_Descript.Value = value; }
        }

        public Int32 UserSign
        {
            get { return m_UserSign.GetInt32(); }
            set { m_UserSign.Value = value; }
        }

        public String ActFee
        {
            get { return m_ActFee.GetString(); }
            set { m_ActFee.Value = value; }
        }


        public bool GetByKey(int absEntry)
        {
            this.AbsEntry = absEntry;
            return GetByKey();
        }

    }
}
