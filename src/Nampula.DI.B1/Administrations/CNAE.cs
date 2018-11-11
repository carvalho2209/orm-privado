using System.Data;

namespace Nampula.DI.B1.Administrations
{
    /// <summary>
    /// Tabelas de Código CNAE's
    /// </summary>
    public class CNAE : TableAdapter
    {
        

        
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OCNA";
        }
        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string AbsId = "AbsId";
            public static readonly string CNAECode = "CNAECode";
            public static readonly string Descrip = "Descrip";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string AbsId = "N° Interno";
            public static readonly string CNAECode = "CNAE";
            public static readonly string Descrip = "Descrição";
        }
        

        

        TableAdapterField m_AbsId = new TableAdapterField(FieldsName.AbsId, FieldsDescription.AbsId, DbType.Int32, 11, 0, true, true);
        TableAdapterField m_CNAECode = new TableAdapterField(FieldsName.CNAECode, FieldsDescription.CNAECode, 9);
        TableAdapterField m_Descrip = new TableAdapterField(FieldsName.Descrip, FieldsDescription.Descrip, 200);

        

        

        

        public CNAE()
            : base(Definition.TableName)
        {
        }

        public CNAE(string pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        public CNAE(CNAE pCNAECode)
            : this()
        {
            this.CopyBy(pCNAECode);
        }

        

        

        public int AbsId
        {
            get { return m_AbsId.GetInt32(); }
            set { m_AbsId.Value = value; }
        }

        public string CNAECode
        {
            get { return m_CNAECode.GetString(); }
            set { m_CNAECode.Value = value; }
        }

        public string Descrip
        {
            get { return m_Descrip.GetString(); }
            set { m_Descrip.Value = value; }
        }

        

        public bool GetByKey(int pAbsId)
        {
            this.AbsId = pAbsId;
            return this.GetByKey();
        }
    }
}
