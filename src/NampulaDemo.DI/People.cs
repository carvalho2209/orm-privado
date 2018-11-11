using Nampula.DI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace NampulaDemo.DI
{

    /// <summary>
    /// Tabela de People
    /// </summary>
    public class People : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "People";
        }

        public struct FieldsName
        {
            public static readonly string Id = "Id";
            public static readonly string Name = "Name";
            public static readonly string Married = "Married";
            public static readonly string Gender = "Gender";
            public static readonly string BirthDate = "BirthDate";
        }

        public struct FieldsDescription
        {
            public static readonly string Id = "Nº";
            public static readonly string Name = "Nome";
            public static readonly string Married = "Casado(a)";
            public static readonly string Gender = "Sexo";
            public static readonly string BirthDate = "Nascimento";
        }

        TableAdapterField m_Id = new TableAdapterField(FieldsName.Id, FieldsDescription.Id, DbType.Int32, 11, 0, true, true);
        TableAdapterField m_Name = new TableAdapterField(FieldsName.Name, FieldsDescription.Name,  DbType.AnsiString, 8000, string.Empty, false, false);
        TableAdapterField m_Married = new TableAdapterField(FieldsName.Married, FieldsDescription.Married, DbType.Boolean);
        TableAdapterField m_Gender = new TableAdapterField(FieldsName.Gender, FieldsDescription.Gender, DbType.Int32);
        TableAdapterField m_BirthDate = new TableAdapterField(FieldsName.BirthDate, FieldsDescription.BirthDate, DbType.DateTime);

        public People()
            : base(Definition.TableName, true)
        {
        }

        public People(People pPeople)
            : this()
        {
            this.CopyBy(pPeople);
        }

        public int Id
        {
            get { return m_Id.GetInt32(); }
            set { m_Id.Value = value; }
        }

        public String Name
        {
            get { return m_Name.GetString(); }
            set { m_Name.Value = value; }
        }

        public Boolean Married
        {
            get { return m_Married.GetBoolean(); }
            set { m_Married.Value = value; }
        }

        public Int32 Gender
        {
            get { return m_Gender.GetInt32(); }
            set { m_Gender.Value = value; }
        }

        public DateTime BirthDate
        {
            get { return m_BirthDate.GetDateTime(); }
            set { m_BirthDate.Value = value; }
        }

    }
}
