using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nampula.DI.B1.Documents
{
    public class DocumentReferenceInformation : TableAdapter
    {

        public struct FieldsName
        {
            public static readonly string DocEntry = "DocEntry";
            public static readonly string ObjType = "ObjectType";
            public static readonly string LogInstanc = "LogInstanc";
            public static readonly string RefType = "RefType";
            public static readonly string LineNum = "LineNum";
            public static readonly string RefDocEntr = "RefDocEntr";
            public static readonly string RefDocNum = "RefDocNum";
            public static readonly string RefObjType = "RefObjType";
            public static readonly string AccessKey = "AccessKey";
            public static readonly string IssueDate = "IssueDate";
            public static readonly string IssuerCNPJ = "IssuerCNPJ";
            public static readonly string IssuerCode = "IssuerCode";
            public static readonly string Model = "Model";
            public static readonly string Series = "Series";
            public static readonly string Number = "Number";
            public static readonly string RefAccKey = "RefAccKey";
        }

        public struct FieldsDescription
        {
            public static readonly string DocEntry = "Internal Number";
            public static readonly string ObjType = "Object Type";
            public static readonly string LogInstanc = "Log Instance";
            public static readonly string RefType = "Reference Types";
            public static readonly string LineNum = "Line Number";
            public static readonly string RefDocEntr = "Referenced Internal Number";
            public static readonly string RefDocNum = "Referenced Document Number";
            public static readonly string RefObjType = "Referenced Object Type";
            public static readonly string AccessKey = "Access Key";
            public static readonly string IssueDate = "Date of Issue";
            public static readonly string IssuerCNPJ = "Issuer CNPJ";
            public static readonly string IssuerCode = "Fiscal Document Issuer UF Code";
            public static readonly string Model = "Fiscal Document Model";
            public static readonly string Series = "Fiscal Document Series";
            public static readonly string Number = "Fiscal Document Number";
            public static readonly string RefAccKey = "Referenced CT-e Access Key";
        }

        TableAdapterField m_DocEntry = new TableAdapterField(FieldsName.DocEntry, FieldsDescription.DocEntry, DbType.Int32);
        TableAdapterField m_ObjType = new TableAdapterField(FieldsName.ObjType, FieldsDescription.ObjType, DbType.Int32);
        TableAdapterField m_LogInstanc = new TableAdapterField(FieldsName.LogInstanc, FieldsDescription.LogInstanc, DbType.Int32);
        TableAdapterField m_RefType = new TableAdapterField(FieldsName.RefType, FieldsDescription.RefType, 1);
        TableAdapterField m_LineNum = new TableAdapterField(FieldsName.LineNum, FieldsDescription.LineNum, DbType.Int32);
        TableAdapterField m_RefDocEntr = new TableAdapterField(FieldsName.RefDocEntr, FieldsDescription.RefDocEntr, DbType.Int32);
        TableAdapterField m_RefDocNum = new TableAdapterField(FieldsName.RefDocNum, FieldsDescription.RefDocNum, DbType.Int32);
        TableAdapterField m_RefObjType = new TableAdapterField(FieldsName.RefObjType, FieldsDescription.RefObjType, 20);
        TableAdapterField m_AccessKey = new TableAdapterField(FieldsName.AccessKey, FieldsDescription.AccessKey, 100);
        TableAdapterField m_IssueDate = new TableAdapterField(FieldsName.IssueDate, FieldsDescription.IssueDate, DbType.DateTime);
        TableAdapterField m_IssuerCNPJ = new TableAdapterField(FieldsName.IssuerCNPJ, FieldsDescription.IssuerCNPJ, 100);
        TableAdapterField m_IssuerCode = new TableAdapterField(FieldsName.IssuerCode, FieldsDescription.IssuerCode, 10);
        TableAdapterField m_Model = new TableAdapterField(FieldsName.Model, FieldsDescription.Model, 6);
        TableAdapterField m_Series = new TableAdapterField(FieldsName.Series, FieldsDescription.Series, 3);
        TableAdapterField m_Number = new TableAdapterField(FieldsName.Number, FieldsDescription.Number, DbType.Int32);
        TableAdapterField m_RefAccKey = new TableAdapterField(FieldsName.RefAccKey, FieldsDescription.RefAccKey, 100);


        public DocumentReferenceInformation()
            : base()
        {
        }

        public DocumentReferenceInformation(string pCompanyDb, eDocumentObjectType pDocumentObjectType)
            : base(pCompanyDb, pDocumentObjectType.GetTableNameSufix() + "21")
        {
            this.ObjType = pDocumentObjectType;
        }

        /// <summary>
        /// Pega a lista de despesas adicionais
        /// </summary>
        /// <param name="pDocEntry">Id do Documento</param>
        /// <returns>Uma lista de depesas adicionais</returns>
        public List<DocumentReferenceInformation> GetByDocEntry(Int32 pDocEntry)
        {
            //Tabela da Itens
            var query = new TableQuery(this);

            //DocEntry da Tabela de Itens
            query.Where.Add(
                new QueryParam(m_DocEntry, pDocEntry));

            //Ordernar pelo LineNum
            //query.OrderBy.Add(new OrderBy(new QueryParam(m_ExpnsCode)));

            return this.FillCollection<DocumentReferenceInformation>(query);
        } 


        public Int32 DocEntry
        {
            get { return m_DocEntry.GetInt32(); }
            set { m_DocEntry.Value = value; }
        }

        public eDocumentObjectType ObjType
        {
            get { return m_ObjType.GetInt32().ToDocumentObjectTypeEnum(); }
            set { m_ObjType.Value = value.ToInt32(); }
        }

        public Int32 LogInstanc
        {
            get { return m_LogInstanc.GetInt32(); }
            set { m_LogInstanc.Value = value; }
        }


        public eRefType RefType
        {
            get { return m_RefType.GetString().ToRefTypeEnum(); }
            set { m_RefType.Value = value; }
        }

        public Int32 LineNum
        {
            get { return m_LineNum.GetInt32(); }
            set { m_LineNum.Value = value; }
        }

        public Int32 RefDocEntr
        {
            get { return m_RefDocEntr.GetInt32(); }
            set { m_RefDocEntr.Value = value; }
        }

        public Int32 RefDocNum
        {
            get { return m_RefDocNum.GetInt32(); }
            set { m_RefDocNum.Value = value; }
        }

        public eDocumentObjectType RefObjType
        {
            get { return m_RefObjType.GetInt32().ToDocumentObjectTypeEnum(); }
            set { m_RefObjType.Value = value.ToInt32(); }
        }

        public String AccessKey
        {
            get { return m_AccessKey.GetString(); }
            set { m_AccessKey.Value = value; }
        }

        public DateTime IssueDate
        {
            get { return m_IssueDate.GetDateTime(); }
            set { m_IssueDate.Value = value; }
        }

        public String IssuerCNPJ
        {
            get { return m_IssuerCNPJ.GetString(); }
            set { m_IssuerCNPJ.Value = value; }
        }

        public String IssuerCode
        {
            get { return m_IssuerCode.GetString(); }
            set { m_IssuerCode.Value = value; }
        }

        public String Model
        {
            get { return m_Model.GetString(); }
            set { m_Model.Value = value; }
        }

        public String Series
        {
            get { return m_Series.GetString(); }
            set { m_Series.Value = value; }
        }

        public Int32 Number
        {
            get { return m_Number.GetInt32(); }
            set { m_Number.Value = value; }
        }

        public String RefAccKey
        {
            get { return m_RefAccKey.GetString(); }
            set { m_RefAccKey.Value = value; }
        }

    }
}
