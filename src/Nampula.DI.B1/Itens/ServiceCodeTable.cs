using System;
using System.Data;

namespace Nampula.DI.B1.Itens
{

    /// <summary>
    /// Tabela de Código de Serviço
    /// </summary>
    public class ServiceCodeTable : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OSCD";
        }

        public struct FieldsName
        {
            public static readonly string AbsEntry = "AbsEntry";
            public static readonly string County = "County";
            public static readonly string ServiceCD = "ServiceCD";
            public static readonly string Descrip = "Descrip";
            public static readonly string Incomimg = "Incomimg";
        }

        public struct FieldsDescription
        {
            public static readonly string AbsEntry = "Nº";
            public static readonly string County = "County";
            public static readonly string ServiceCD = "ServiceCD";
            public static readonly string Descrip = "Descrip";
            public static readonly string Incomimg = "Incomimg";
        }

        readonly TableAdapterField m_AbsEntry = new TableAdapterField(FieldsName.AbsEntry, FieldsDescription.AbsEntry, DbType.Int32, 11, 0, true, true);
        readonly TableAdapterField m_County = new TableAdapterField(FieldsName.County, FieldsDescription.County, DbType.Int32);
        readonly TableAdapterField m_ServiceCD = new TableAdapterField(FieldsName.ServiceCD, FieldsDescription.ServiceCD, 15);
        readonly TableAdapterField m_Descrip = new TableAdapterField(FieldsName.Descrip, FieldsDescription.Descrip, 70);
        readonly TableAdapterField m_Incomimg = new TableAdapterField(FieldsName.Incomimg, FieldsDescription.Incomimg, 1);
        
        public ServiceCodeTable()
            : base(Definition.TableName)
        {
        }

        public ServiceCodeTable(ServiceCodeTable pServiceCodeTable)
            : this()
        {
            CopyBy(pServiceCodeTable);
        }

        public int AbsEntry
        {
            get { return m_AbsEntry.GetInt32(); }
            set { m_AbsEntry.Value = value; }
        }

        public Int32 County
        {
            get { return m_County.GetInt32(); }
            set { m_County.Value = value; }
        }

        public String ServiceCD
        {
            get { return m_ServiceCD.GetString(); }
            set { m_ServiceCD.Value = value; }
        }

        public String Descrip
        {
            get { return m_Descrip.GetString(); }
            set { m_Descrip.Value = value; }
        }

        /// <summary>
        /// Yes e No
        /// </summary>
        public String Incoming
        {
            get { return m_Incomimg.GetString(); }
            set { m_Incomimg.Value = value; }
        }


    }
}
