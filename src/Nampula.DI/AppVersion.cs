using System;
using System.Text;
using System.Data;

namespace Nampula.DI
{
    /// <summary>
    /// Tabela de Gerenciamento da Versão do Banco de Dados
    /// </summary>
    public class AppVersion : TableAdapter
    {
        /// <summary>
        /// Nome dos Campos
        /// </summary>
        public struct FieldsName
        {
            public static readonly string ID = "ID";
            public static readonly string Version = "Version";
            public static readonly string AssemblyName = "AssemblyName";
            public static readonly string UserName = "UserName";
            public static readonly string CreateDate = "CreateDate";
        }

        /// <summary>
        /// Descrição dos Campos
        /// </summary>
        public struct Description
        {
            public static readonly string ID = "Código";
            public static readonly string Version = "Versão";
            public static readonly string AssemblyName = "AssemblyName";
            public static readonly string UserName = "UserName";
            public static readonly string CreateDate = "Data de Criação";
        }

        readonly TableAdapterField m_ID = new TableAdapterField(FieldsName.ID, Description.ID, DbType.Int32, 11, null, true, true);
        readonly TableAdapterField m_Version = new TableAdapterField(FieldsName.Version, Description.Version, 20);
        readonly TableAdapterField m_AssemblyName = new TableAdapterField(FieldsName.AssemblyName, Description.AssemblyName, 100);
        readonly TableAdapterField m_UserName = new TableAdapterField(FieldsName.UserName, Description.UserName, 20);
        readonly TableAdapterField m_CreateDate = new TableAdapterField(FieldsName.CreateDate, Description.CreateDate, DbType.Date);

        /// <summary>
        /// Construtor padrão
        /// </summary>
        public AppVersion()
            : base("AppVersion")
        {
        }

        public int ID
        {
            get { return m_ID.GetInt32(); }
            set { m_ID.Value = value; }
        }

        public string AssemblyName
        {
            get { return m_AssemblyName.GetString(); }
            set { m_AssemblyName.Value = value; }
        }

        public string Version
        {
            get { return m_Version.GetString(); }
            set { m_Version.Value = value; }
        }

        public string UserName
        {
            get { return m_UserName.GetString(); }
            set { m_UserName.Value = value; }
        }

        public DateTime CreateDate
        {
            get { return m_CreateDate.GetDateTime(); }
            set { m_CreateDate.Value = value; }
        }

        public bool GetByKey(int pID)
        {
            ID = pID;
            return base.GetByKey();
        }

        internal bool GetLastVersion(string pAssemblyName)
        {
            var strongBuider = new StringBuilder();

            strongBuider.AppendFormat(
                " Select Max(ID) From {0} Where AssemblyName = '{1}' ", FullTableName(), pAssemblyName);

            return GetByKey(Connection.SqlExecuteScalar<Int32>(strongBuider.ToString()));

        }
    }

}
