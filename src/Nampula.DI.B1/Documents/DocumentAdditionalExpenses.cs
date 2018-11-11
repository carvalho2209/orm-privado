using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.Documents
{
    /// <summary>
    /// Depesas Adicionais
    /// </summary>
    public class DocumentAdditionalExpenses : TableAdapter
    {
        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string DocEntry = "DocEntry";
            public static readonly string LineNum = "LineNum";
            public static readonly string ExpnsCode = "ExpnsCode";
            public static readonly string TaxCode = "TaxCode";
            public static readonly string LineTotal = "LineTotal";
            public static readonly string ObjType = "ObjType";
            public static readonly string BaseAbsEnt = "BaseAbsEnt";
            public static readonly string BaseType = "BaseType";
            public static readonly string BaseRef = "BaseRef";
            public static readonly string BaseLnNum = "BaseLnNum";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string DocEntry = "Nº Documento";
            public static readonly string LineNum = "LineNum";
            public static readonly string ExpnsCode = "Nome da Despesa";
            public static readonly string TaxCode = "Código do Imposto";
            public static readonly string LineTotal = "Valor";
            public static readonly string ObjType = "Tipo de Documento";
            public static readonly string BaseAbsEnt = "Nº Doc. Base";
            public static readonly string BaseType = "Tipo do Doc. Base";
            public static readonly string BaseRef = "Referência do Doc Base";
            public static readonly string BaseLnNum = "BaseLnNum";
        }
        

        

        TableAdapterField m_DocEntry = new TableAdapterField(FieldsName.DocEntry, FieldsDescription.DocEntry, DbType.Int32, 11, 0, true, true);
        TableAdapterField m_LineNum = new TableAdapterField(FieldsName.LineNum, FieldsDescription.LineNum, DbType.Int32);
        TableAdapterField m_ExpnsCode = new TableAdapterField(FieldsName.ExpnsCode, FieldsDescription.ExpnsCode, DbType.Int32);
        TableAdapterField m_TaxCode = new TableAdapterField(FieldsName.TaxCode, FieldsDescription.TaxCode, 8);
        TableAdapterField m_LineTotal = new TableAdapterField(FieldsName.LineTotal, FieldsDescription.LineTotal, DbType.Decimal);
        TableAdapterField m_ObjType = new TableAdapterField(FieldsName.ObjType, FieldsDescription.ObjType, 20);
        TableAdapterField m_BaseAbsEnt = new TableAdapterField(FieldsName.BaseAbsEnt, FieldsDescription.BaseAbsEnt, DbType.Int32);
        TableAdapterField m_BaseType = new TableAdapterField(FieldsName.BaseType, FieldsDescription.BaseType, DbType.Int32);
        TableAdapterField m_BaseRef = new TableAdapterField(FieldsName.BaseRef, FieldsDescription.BaseRef, DbType.Int32);
        TableAdapterField m_BaseLnNum = new TableAdapterField(FieldsName.BaseLnNum, FieldsDescription.BaseLnNum, DbType.Int32);

        

        

        

        public DocumentAdditionalExpenses()
            : base()
        {
        }

        public DocumentAdditionalExpenses(string pCompanyDb, eDocumentObjectType pDocumentObjectType)
            : base(pCompanyDb, pDocumentObjectType.GetTableNameSufix() + "13")
        {
            this.ObjType = pDocumentObjectType;
        }

        public DocumentAdditionalExpenses(DocumentAdditionalExpenses pDocumentAdditionalExpenses)
            : this()
        {
            this.CopyBy(pDocumentAdditionalExpenses);
        }

        

        

        public int DocEntry
        {
            get { return m_DocEntry.GetInt32(); }
            set { m_DocEntry.Value = value; }
        }

        public int LineNum
        {
            get { return m_LineNum.GetInt32(); }
            set { m_LineNum.Value = value; }
        }

        public int ExpnsCode
        {
            get { return m_ExpnsCode.GetInt32(); }
            set { m_ExpnsCode.Value = value; }
        }

        public string TaxCode
        {
            get { return m_TaxCode.GetString(); }
            set { m_TaxCode.Value = value; }
        }

        public decimal LineTotal
        {
            get { return m_LineTotal.GetDecimal(); }
            set { m_LineTotal.Value = value; }
        }

        public eDocumentObjectType ObjType
        {
            get { return (eDocumentObjectType)m_ObjType.GetInt32(); }
            set { m_ObjType.Value = (int)value; }
        }

        public int BaseAbsEnt
        {
            get { return m_BaseAbsEnt.GetInt32(); }
            set { m_BaseAbsEnt.Value = value; }
        }

        public eDocumentObjectType BaseType
        {
            get { return (eDocumentObjectType)m_BaseType.GetInt32(); }
            set { m_BaseType.Value = (int)value; }
        }

        public int BaseRef
        {
            get { return m_BaseRef.GetInt32(); }
            set { m_BaseRef.Value = value; }
        }

        public int BaseLnNum
        {
            get { return m_BaseLnNum.GetInt32(); }
            set { m_BaseLnNum.Value = value; }
        }

        

        
        /// <summary>
        /// Pega a lista de despesas adicionais
        /// </summary>
        /// <param name="pDocEntry">Id do Documento</param>
        /// <returns>Uma lista de depesas adicionais</returns>
        public List<DocumentAdditionalExpenses> GetByDocEntry(Int32 pDocEntry)
        {

            //Tabela da Itens
            var query = new TableQuery(this);

            //DocEntry da Tabela de Itens
            query.Where.Add(
                new QueryParam(m_DocEntry, pDocEntry));

            //Ordernar pelo LineNum
            query.OrderBy.Add(new OrderBy(new QueryParam(m_ExpnsCode)));

            return this.FillCollection<DocumentAdditionalExpenses>(query);
        } 
        
    }

}
