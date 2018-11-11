using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.UserTables
{
    public class UserFieldValuesDefinition : TableAdapter
    {
        

        
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "UFD1";
        }
        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string TableID = "TableID";
            public static readonly string FieldID = "FieldID";
            public static readonly string IndexID = "IndexID";
            public static readonly string FldValue = "FldValue";
            public static readonly string Descr = "Descr";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string TableID = "Tabela";
            public static readonly string FieldID = "Campo";
            public static readonly string IndexID = "Índice";
            public static readonly string FldValue = "Valor";
            public static readonly string Descr = "Descrição";
        }
        

        

        TableAdapterField m_TableID = new TableAdapterField(FieldsName.TableID, FieldsDescription.TableID, DbType.String, 20, null, true, false);
        TableAdapterField m_FieldID = new TableAdapterField(FieldsName.FieldID, FieldsDescription.FieldID, DbType.Int32, 6, null, true, false);
        TableAdapterField m_IndexID = new TableAdapterField(FieldsName.IndexID, FieldsDescription.IndexID, DbType.Int32, 6, null, true, false);
        TableAdapterField m_FldValue = new TableAdapterField(FieldsName.FldValue, FieldsDescription.FldValue, 254);
        TableAdapterField m_Descr = new TableAdapterField(FieldsName.Descr, FieldsDescription.Descr, 254);

        

        

        

        public UserFieldValuesDefinition(string pCompanyDb)
            : base(pCompanyDb, Definition.TableName)
        {
        }

        public UserFieldValuesDefinition()
            : base(Definition.TableName)
        {
        }

        

        

        public string TableID
        {
            get { return m_TableID.GetString(); }
            set { m_TableID.Value = value; }
        }

        public int FieldID
        {
            get { return m_FieldID.GetInt32(); }
            set { m_FieldID.Value = value; }
        }

        public int IndexID
        {
            get { return m_IndexID.GetInt32(); }
            set { m_IndexID.Value = value; }
        }

        public string FldValue
        {
            get { return m_FldValue.GetString(); }
            set { m_FldValue.Value = value; }
        }

        public string Descr
        {
            get { return m_Descr.GetString(); }
            set { m_Descr.Value = value; }
        }

        

        

        
        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="pTableID">Código da tabela.</param>
        /// <param name="pFieldID">Código do campo.</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public bool GetByKey(string pTableID, int pFieldID, int pIndexID)
        {
            this.TableID = pTableID;
            this.FieldID = pFieldID;
            this.IndexID = pIndexID;
            return GetByKey();
        }
        

        
        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="pTableID">Código da tabela.</param>
        /// <param name="pFieldID">Código do campo.</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public List<UserFieldValuesDefinition> GetByTableAndField(string pTableID, int pFieldID)
        {
            TableQuery query = new TableQuery(this);

            query.Where.Add(new QueryParam(m_TableID, pTableID));
            query.Where.Add(new QueryParam(m_FieldID, pFieldID));

            return FillCollection<UserFieldValuesDefinition>(this.GetData(query).Rows);
        }
        

        
        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de UserFieldValuesDefinition.</returns>
        public List<UserFieldValuesDefinition> GetAll()
        {
            return FillCollection<UserFieldValuesDefinition>(this.GetData().Rows);
        }
        

        
    }
}
