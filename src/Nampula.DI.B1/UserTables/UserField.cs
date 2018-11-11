using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.UserTables
{
    public class UserField : TableAdapter
    {
        

        
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "CUFD";
        }
        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string TableID = "TableID";
            public static readonly string FieldID = "FieldID";
            public static readonly string AliasID = "AliasID";
            public static readonly string Descr = "Descr";
            public static readonly string TypeID = "TypeID";
            public static readonly string EditType = "EditType";
            public static readonly string SizeID = "SizeID";
            public static readonly string EditSize = "EditSize";
            public static readonly string Dflt = "Dflt";
            public static readonly string NotNull = "NotNull";
            public static readonly string IndexID = "IndexID";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string TableID = "Tabela";
            public static readonly string FieldID = "Campo";
            public static readonly string AliasID = "Título";
            public static readonly string Descr = "Descrição";
            public static readonly string TypeID = "Tipo";
            public static readonly string EditType = "Tipo de Edição";
            public static readonly string SizeID = "Tamanho";
            public static readonly string EditSize = "Comprimento";
            public static readonly string Dflt = "Valor Padrão";
            public static readonly string NotNull = "Campo Obrigatório";
            public static readonly string IndexID = "Criar Índice";
        }
        

        

        TableAdapterField m_TableID = new TableAdapterField(FieldsName.TableID, FieldsDescription.TableID, DbType.String, 20, null, true, false);
        TableAdapterField m_FieldID = new TableAdapterField(FieldsName.FieldID, FieldsDescription.FieldID, DbType.Int32, 6, null, true, false);
        TableAdapterField m_AliasID = new TableAdapterField(FieldsName.AliasID, FieldsDescription.AliasID, 18);
        TableAdapterField m_Descr = new TableAdapterField(FieldsName.Descr, FieldsDescription.Descr, 30);
        TableAdapterField m_TypeID = new TableAdapterField(FieldsName.TypeID, FieldsDescription.TypeID, 1);
        TableAdapterField m_EditType = new TableAdapterField(FieldsName.EditType, FieldsDescription.EditType, 1);
        TableAdapterField m_SizeID = new TableAdapterField(FieldsName.SizeID, FieldsDescription.SizeID, DbType.Int32);
        TableAdapterField m_EditSize = new TableAdapterField(FieldsName.EditSize, FieldsDescription.EditSize, DbType.Int32);
        TableAdapterField m_Dflt = new TableAdapterField(FieldsName.Dflt, FieldsDescription.Dflt, 254);
        TableAdapterField m_NotNull = new TableAdapterField(FieldsName.NotNull, FieldsDescription.NotNull, 1);
        TableAdapterField m_IndexID = new TableAdapterField(FieldsName.IndexID, FieldsDescription.IndexID, 1);

        

        

        

        public UserField()
            : base(Definition.TableName)
        {
        }

        public UserField(string pCompanyDb)
            : base(pCompanyDb, Definition.TableName)
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

        public string AliasID
        {
            get { return m_AliasID.GetString(); }
            set { m_AliasID.Value = value; }
        }

        public string Descr
        {
            get { return m_Descr.GetString(); }
            set { m_Descr.Value = value; }
        }

        public string TypeID
        {
            get { return m_TypeID.GetString(); }
            set { m_TypeID.Value = value; }
        }

        public string EditType
        {
            get { return m_EditType.GetString(); }
            set { m_EditType.Value = value; }
        }

        public int SizeID
        {
            get { return m_SizeID.GetInt32(); }
            set { m_SizeID.Value = value; }
        }

        public int EditSize
        {
            get { return m_EditSize.GetInt32(); }
            set { m_EditSize.Value = value; }
        }

        public string Dflt
        {
            get { return m_Dflt.GetString(); }
            set { m_Dflt.Value = value; }
        }

        public string NotNull
        {
            get { return m_NotNull.GetString(); }
            set { m_NotNull.Value = value; }
        }

        public string IndexID
        {
            get { return m_IndexID.GetString(); }
            set { m_IndexID.Value = value; }
        }

        

        

        
        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="pTableID">Código da tabela.</param>
        /// <param name="pFieldID">Código do campo.</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public bool GetByKey(string pTableID, int pFieldID)
        {
            this.TableID = pTableID;
            this.FieldID = pFieldID;
            return GetByKey();
        }
        

        
        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="pTableID">Código da tabela.</param>
        /// <param name="pAliasID">Título do campo.</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public List<UserField> GetByTableAndAlias(string pTableID, string pAliasID)
        {
            TableQuery query = new TableQuery(this);

            query.Where.Add(new QueryParam(m_TableID, pTableID));
            query.Where.Add(new QueryParam(m_AliasID, pAliasID));

            return FillCollection<UserField>(this.GetData(query).Rows);
        }
        

        
        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de UserField.</returns>
        public List<UserField> GetAll()
        {
            return FillCollection<UserField>(this.GetData().Rows);
        }
        

        
    }
}
