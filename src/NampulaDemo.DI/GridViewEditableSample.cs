using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Nampula.DI;

namespace NampulaDemo.DI
{

    /// <summary>
    /// Tabela de Exemplo para os testes no GridView Editable
    /// </summary>
    public class SampleGri : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "SampleGri";
        }

        public struct FieldsName
        {
            public static readonly string Id = "Id";
            public static readonly string Campo1 = "Campo1";
            public static readonly string Campo2 = "Campo2";
            public static readonly string Campo3 = "Campo3";
        }

        public struct FieldsDescription
        {
            public static readonly string Id = "Nº";
            public static readonly string Campo1 = "Campo1";
            public static readonly string Campo2 = "Campo2";
            public static readonly string Campo3 = "Campo3";
        }

        TableAdapterField m_Id = new TableAdapterField(FieldsName.Id, FieldsDescription.Id, DbType.Int32, 11, 0, true, true);
        TableAdapterField m_Campo1 = new TableAdapterField(FieldsName.Campo1, FieldsDescription.Campo1, 100);
        TableAdapterField m_Campo2 = new TableAdapterField(FieldsName.Campo2, FieldsDescription.Campo2, 200);
        TableAdapterField m_Campo3 = new TableAdapterField(FieldsName.Campo3, FieldsDescription.Campo3, 200);


        public SampleGri()
            : base(Definition.TableName)
        {
            Samples = new List<SampleGri>();
        }

        public SampleGri(SampleGri pSampleGri)
            : this()
        {
            this.CopyBy(pSampleGri);
        }

        public int Id
        {
            get { return m_Id.GetInt32(); }
            set { m_Id.Value = value; }
        }

        public String Campo1
        {
            get { return m_Campo1.GetString(); }
            set { m_Campo1.Value = value; }
        }

        public String Campo2
        {
            get { return m_Campo2.GetString(); }
            set { m_Campo2.Value = value; }
        }

        public String Campo3
        {
            get { return m_Campo3.GetString(); }
            set { m_Campo3.Value = value; }
        }


        public List<SampleGri> Samples { get; set; }
    }
}
