using Nampula.DI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace NampulaDemo.DI
{

    /// <summary>
    /// Tabela de PeopleAddress
    /// </summary>
    public class PeopleAddress : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "PeopleAddress";
        }

        public struct FieldsName
        {
            public static readonly string Id = "Id";
            public static readonly string PeopleId = "PeopleId";
            public static readonly string Address = "Address";
        }

        public struct FieldsDescription
        {
            public static readonly string Id = "Nº";
            public static readonly string PeopleId = "Cód. Pessoa";
            public static readonly string Address = "Endereço";
        }

        TableAdapterField m_Id = new TableAdapterField(FieldsName.Id, FieldsDescription.Id, DbType.Int32, 11, 0, true, true);
        TableAdapterField m_PeopleId = new TableAdapterField(FieldsName.PeopleId, FieldsDescription.PeopleId, DbType.Int32);
        TableAdapterField m_Address = new TableAdapterField(FieldsName.Address, FieldsDescription.Address, 200);

        public PeopleAddress()
            : base(Definition.TableName)
        {
        }

        public PeopleAddress(PeopleAddress pPeopleAddress)
            : this()
        {
            this.CopyBy(pPeopleAddress);
        }

        public int Id
        {
            get { return m_Id.GetInt32(); }
            set { m_Id.Value = value; }
        }

        public Int32 PeopleId
        {
            get { return m_PeopleId.GetInt32(); }
            set { m_PeopleId.Value = value; }
        }

        public String Address
        {
            get { return m_Address.GetString(); }
            set { m_Address.Value = value; }
        }

    }
}
