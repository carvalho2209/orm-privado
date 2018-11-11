using System;
using System.Data;

namespace Nampula.DI.Logs
{
    /// <summary>
    /// Registro de Alterações
    /// </summary>
    public class LogDifferences : TableAdapter
    {
        /// <summary>
        /// Nome dos campos do registro de alterações
        /// </summary>
        public struct FieldsName
        {
            public static readonly string Instance = "Instance";
            public static readonly string MachineName = "MachineName";
            public static readonly string Date = "Date";
            public static readonly string UserName = "UserName";
            public static readonly string FieldName = "FieldName";
            public static readonly string FieldDescription = "FieldDescription";
            public static readonly string OldValue = "OldValue";
            public static readonly string NewValue = "NewValue";
        }

        /// <summary>
        /// Descrição dos campos do registro de alterações
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string Instance = "Instância";
            public static readonly string MachineName = "Maquina";
            public static readonly string Date = "Data";
            public static readonly string UserName = "Usuário";
            public static readonly string FieldName = "Campo";
            public static readonly string FieldDescription = "Campo";
            public static readonly string OldValue = "Valor Antigo";
            public static readonly string NewValue = "Novo Valor";
        }

        readonly TableAdapterField m_Instance = new TableAdapterField(FieldsName.Instance, FieldsDescription.Instance, DbType.Int32);
        readonly TableAdapterField m_MachineName = new TableAdapterField(FieldsName.MachineName, FieldsDescription.MachineName, 200);
        readonly TableAdapterField m_Date = new TableAdapterField(FieldsName.Date, FieldsDescription.Date, DbType.DateTime);
        readonly TableAdapterField m_UserName = new TableAdapterField(FieldsName.UserName, FieldsDescription.UserName, 200);
        readonly TableAdapterField m_FieldDescription = new TableAdapterField(FieldsName.FieldDescription, FieldsDescription.FieldDescription, 200);
        readonly TableAdapterField m_FieldName = new TableAdapterField(FieldsName.FieldName, FieldsDescription.FieldName, 200);
        readonly TableAdapterField m_OldValue = new TableAdapterField(FieldsName.OldValue, FieldsDescription.OldValue, 200);
        readonly TableAdapterField m_NewValue = new TableAdapterField(FieldsName.NewValue, FieldsDescription.NewValue, 200);

        /// <summary>
        /// Instancia do Registro
        /// </summary>
        public Int32 Instance
        {
            get { return m_Instance.GetInt32(); }
            set { m_Instance.Value = value; }
        }

        /// <summary>
        /// Data de Alteração
        /// </summary>
        public DateTime Date
        {
            get { return m_Date.GetDateTime(); }
            set { m_Date.Value = value; }
        }

        /// <summary>
        /// Nome da Máquina
        /// </summary>
        public String MachineName
        {
            get { return m_MachineName.GetString(); }
            set { m_MachineName.Value = value; }
        }

        /// <summary>
        /// Nome do Campo
        /// </summary>
        public String FieldName
        {
            get { return m_FieldName.GetString(); }
            set { m_FieldName.Value = value; }
        }

        /// <summary>
        /// Descrição do Campo
        /// </summary>
        public String FieldDescription
        {
            get { return m_FieldDescription.GetString(); }
            set { m_FieldDescription.Value = value; }
        }


        /// <summary>
        /// Valor Antigo
        /// </summary>
        public String OldValue
        {
            get { return m_OldValue.GetString(); }
            set { m_OldValue.Value = value; }
        }

        /// <summary>
        /// Novo valor
        /// </summary>
        public String NewValue
        {
            get { return m_NewValue.GetString(); }
            set { m_NewValue.Value = value; }
        }

        /// <summary>
        /// Nome do Usuário
        /// </summary>
        public String UserName
        {
            get { return m_UserName.GetString(); }
            set { m_UserName.Value = value; }
        }
    }
}
