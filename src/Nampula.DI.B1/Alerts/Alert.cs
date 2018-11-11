using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nampula.DI.B1.Alerts
{

    /// <summary>
    /// Tabela de Alerta
    /// </summary>
    public class Alert : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OALR";
        }

        public struct FieldsName
        {
            public static readonly string Code = "Code";
            public static readonly string Type = "Type";
            public static readonly string Priority = "Priority";
            public static readonly string TCode = "TCode";
            public static readonly string Subject = "Subject";
            public static readonly string UserText = "UserText";
            public static readonly string DataCols = "DataCols";
            public static readonly string DataParams = "DataParams";
            public static readonly string MsgData = "MsgData";
            public static readonly string UserSign = "UserSign";
            public static readonly string Attachment = "Attachment";
            public static readonly string AtcEntry = "AtcEntry";
        }

        public struct FieldsDescription
        {
            public static readonly string Code = "Nº";
            public static readonly string Type = "Tipo";
            public static readonly string Priority = "Prioridade";
            public static readonly string TCode = "Template do Alerta";
            public static readonly string Subject = "Assunto";
            public static readonly string UserText = "Mensagem";
            public static readonly string DataCols = "Colunas";
            public static readonly string DataParams = "Parametros";
            public static readonly string MsgData = "Dados da Mensagem";
            public static readonly string UserSign = "Usuário";
            public static readonly string Attachment = "Anexo";
            public static readonly string AtcEntry = "Nº do Anexo";
        }

        TableAdapterField m_Code = new TableAdapterField(FieldsName.Code, FieldsDescription.Code, DbType.Int32, 11, 0, true, true);
        TableAdapterField m_Type = new TableAdapterField(FieldsName.Type, FieldsDescription.Type, 1);
        TableAdapterField m_Priority = new TableAdapterField(FieldsName.Priority, FieldsDescription.Priority, DbType.Int16);
        TableAdapterField m_TCode = new TableAdapterField(FieldsName.TCode, FieldsDescription.TCode, DbType.Int16);
        TableAdapterField m_Subject = new TableAdapterField(FieldsName.Subject, FieldsDescription.Subject, 50);
        TableAdapterField m_UserText = new TableAdapterField(FieldsName.UserText, FieldsDescription.UserText, 64000);
        TableAdapterField m_DataCols = new TableAdapterField(FieldsName.DataCols, FieldsDescription.DataCols, DbType.Int32);
        TableAdapterField m_DataParams = new TableAdapterField(FieldsName.DataParams, FieldsDescription.DataParams, 4000);
        TableAdapterField m_MsgData = new TableAdapterField(FieldsName.MsgData, FieldsDescription.MsgData, 4000);
        TableAdapterField m_UserSign = new TableAdapterField(FieldsName.UserSign, FieldsDescription.UserSign, DbType.Int16);
        TableAdapterField m_Attachment = new TableAdapterField(FieldsName.Attachment, FieldsDescription.Attachment, 4000);
        TableAdapterField m_AtcEntry = new TableAdapterField(FieldsName.AtcEntry, FieldsDescription.AtcEntry, DbType.Int32);

        public Alert()
            : base(Definition.TableName)
        {
        }

        public Alert(string pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        public Alert(Alert pAlert)
            : this()
        {
            this.CopyBy(pAlert);
        }

        public int Code
        {
            get { return m_Code.GetInt32(); }
            set { m_Code.Value = value; }
        }

        public String Type
        {
            get { return m_Type.GetString(); }
            set { m_Type.Value = value; }
        }

        public Int16 Priority
        {
            get { return m_Priority.GetInt16(); }
            set { m_Priority.Value = value; }
        }

        public Int32 TCode
        {
            get { return m_TCode.GetInt32(); }
            set { m_TCode.Value = value; }
        }

        public String Subject
        {
            get { return m_Subject.GetString(); }
            set { m_Subject.Value = value; }
        }

        public String UserText
        {
            get { return m_UserText.GetString(); }
            set { m_UserText.Value = value; }
        }

        public Int32 DataCols
        {
            get { return m_DataCols.GetInt32(); }
            set { m_DataCols.Value = value; }
        }

        public String DataParams
        {
            get { return m_DataParams.GetString(); }
            set { m_DataParams.Value = value; }
        }

        public String MsgData
        {
            get { return m_MsgData.GetString(); }
            set { m_MsgData.Value = value; }
        }

        public Int16 UserSign
        {
            get { return m_UserSign.GetInt16(); }
            set { m_UserSign.Value = value; }
        }

        public String Attachment
        {
            get { return m_Attachment.GetString(); }
            set { m_Attachment.Value = value; }
        }

        public Int32 AtcEntry
        {
            get { return m_AtcEntry.GetInt32(); }
            set { m_AtcEntry.Value = value; }
        }
        

    }
}
