using System;
using System.Data;

namespace Nampula.DI.B1.Alerts
{

    /// <summary>
    /// Tabela de Recebimento de Alertas
    /// </summary>
    public class ReceivedAlert : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OAIB";
        }

        public struct FieldsName
        {
            public static readonly string AlertCode = "AlertCode";
            public static readonly string UserSign = "UserSign";
            public static readonly string Opened = "Opened";
            public static readonly string RecDate = "RecDate";
            public static readonly string RecTime = "RecTime";
            public static readonly string WasRead = "WasRead";
            public static readonly string Deleted = "Deleted";
        }

        public struct FieldsDescription
        {
            public static readonly string AlertCode = "Nº";
            public static readonly string UserSign = "Usuário";
            public static readonly string Opened = "Aberto";
            public static readonly string RecDate = "Data";
            public static readonly string RecTime = "Hora";
            public static readonly string WasRead = "Lido?";
            public static readonly string Deleted = "Excluído?";
        }

        TableAdapterField m_AlertCode = new TableAdapterField(FieldsName.AlertCode, FieldsDescription.AlertCode, DbType.Int32, 11, 0, true, false);
        TableAdapterField m_UserSign = new TableAdapterField(FieldsName.UserSign, FieldsDescription.UserSign, DbType.Int32, 11, 0, true, false);
        TableAdapterField m_Opened = new TableAdapterField(FieldsName.Opened, FieldsDescription.Opened, 1);
        TableAdapterField m_RecDate = new TableAdapterField(FieldsName.RecDate, FieldsDescription.RecDate, DbType.Date);
        TableAdapterField m_RecTime = new TableAdapterField(FieldsName.RecTime, FieldsDescription.RecTime, DbType.Int16);
        TableAdapterField m_WasRead = new TableAdapterField(FieldsName.WasRead, FieldsDescription.WasRead, 1);
        TableAdapterField m_Deleted = new TableAdapterField(FieldsName.Deleted, FieldsDescription.Deleted, 1);

        public ReceivedAlert()
            : base(Definition.TableName)
        {
        }

        public ReceivedAlert(string pCompanyDb)
            : this()
        {
            DBName = pCompanyDb;
        }

        public ReceivedAlert(ReceivedAlert pReceivedAlert)
            : this()
        {
            CopyBy(pReceivedAlert);
        }

        public int AlertCode
        {
            get { return m_AlertCode.GetInt32(); }
            set { m_AlertCode.Value = value; }
        }

        public Int32 UserSign
        {
            get { return m_UserSign.GetInt32(); }
            set { m_UserSign.Value = value; }
        }

        public string Opened
        {
            get { return m_Opened.GetString(); }
            set { m_Opened.Value = value; }
        }

        public DateTime RecDate
        {
            get { return m_RecDate.GetDateTime(); }
            set { m_RecDate.Value = value; }
        }

        public DateTime RecTime
        {
            get { return m_RecTime.GetDateTime(); }
            set { m_RecTime.Value = value; }
        }

        public String WasRead
        {
            get { return m_WasRead.GetString(); }
            set { m_WasRead.Value = value; }
        }

        public String Deleted
        {
            get { return m_Deleted.GetString(); }
            set { m_Deleted.Value = value; }
        }

    }
}
