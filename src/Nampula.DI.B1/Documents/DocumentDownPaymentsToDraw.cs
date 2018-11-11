using System;
using System.Collections.Generic;
using System.Data;

namespace Nampula.DI.B1.Documents
{
    public class DocumentDownPaymentsToDraw : TableAdapter
    {
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string DocEntry = "DocEntry";
            public static readonly string BaseAbs = "BaseAbs";
            public static readonly string ObjectType = "ObjectType";
            public static readonly string DrawnSum = "DrawnSum";
            public static readonly string ApplDrawn = "ApplDrawn";
            public static readonly string BaseDocNum = "BaseDocNum";
            public static readonly string BsDocDate = "BsDocDate";
            public static readonly string BsDueDate = "BsDueDate";
            public static readonly string BsCardName = "BsCardName";
            public static readonly string BsComments = "BsComments";
            public static readonly string Posted = "Posted";
        }
        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string DocEntry = "Número";
            public static readonly string BaseAbs = "BaseAbs";
            public static readonly string ObjectType = "Tipo de objeto";
            public static readonly string DrawnSum = "Valor a baixar";
            public static readonly string ApplDrawn = "Valor baixado";
            public static readonly string BaseDocNum = "Documento base";
            public static readonly string BsDocDate = "Data de lançamento base";
            public static readonly string BsDueDate = "Data de vencimento base";
            public static readonly string BsCardName = "Parceiro de negócio base";
            public static readonly string BsComments = "Observações base";
            public static readonly string Posted = "Postado";
        }

        readonly TableAdapterField _docEntry = new TableAdapterField(FieldsName.DocEntry, FieldsDescription.DocEntry, DbType.Int32, 11, null, true, false);
        readonly TableAdapterField _baseAbs = new TableAdapterField(FieldsName.BaseAbs, FieldsDescription.BaseAbs, DbType.Int32);
        readonly TableAdapterField _objectType = new TableAdapterField(FieldsName.ObjectType, FieldsDescription.ObjectType, DbType.Int32);
        readonly TableAdapterField _drawnSum = new TableAdapterField(FieldsName.DrawnSum, FieldsDescription.DrawnSum, DbType.Decimal);
        readonly TableAdapterField _applDrawn = new TableAdapterField(FieldsName.ApplDrawn, FieldsDescription.ApplDrawn, DbType.Decimal);
        readonly TableAdapterField _baseDocNum = new TableAdapterField(FieldsName.BaseDocNum, FieldsDescription.BaseDocNum, DbType.Int32);
        readonly TableAdapterField _bsDocDate = new TableAdapterField(FieldsName.BsDocDate, FieldsDescription.BsDocDate, DbType.DateTime);
        readonly TableAdapterField _bsDueDate = new TableAdapterField(FieldsName.BsDueDate, FieldsDescription.BsDueDate, DbType.DateTime);
        readonly TableAdapterField _bsCardName = new TableAdapterField(FieldsName.BsCardName, FieldsDescription.BsCardName, 100);
        readonly TableAdapterField _bsComments = new TableAdapterField(FieldsName.BsComments, FieldsDescription.BsComments, 254);
        readonly TableAdapterField _posted = new TableAdapterField(FieldsName.Posted, FieldsDescription.Posted, 1);

        public DocumentDownPaymentsToDraw()
        {
        }

        public DocumentDownPaymentsToDraw(string pCompanyDb, eDocumentObjectType pDocumentObjectType)
            : base(pCompanyDb, pDocumentObjectType.GetTableNameSufix() + "9")
        {
        }

        public DocumentDownPaymentsToDraw(DocumentDownPaymentsToDraw pDocumentDownPaymentsToDraw)
            : this()
        {
            CopyBy(pDocumentDownPaymentsToDraw);
        }

        public int DocEntry
        {
            get { return _docEntry.GetInt32(); }
            set { _docEntry.Value = value; }
        }

        public int BaseAbs
        {
            get { return _baseAbs.GetInt32(); }
            set { _baseAbs.Value = value; }
        }

        public eDocumentObjectType ObjectType
        {
            get { return _objectType.GetInt32().ToDocumentObjectTypeEnum(); }
            set { _objectType.Value = value.ToInt32(); }
        }

        public decimal DrawnSum
        {
            get { return _drawnSum.GetDecimal(); }
            set { _drawnSum.Value = value; }
        }

        public decimal ApplDrawn
        {
            get { return _applDrawn.GetDecimal(); }
            set { _applDrawn.Value = value; }
        }

        public int BaseDocNum
        {
            get { return _baseDocNum.GetInt32(); }
            set { _baseDocNum.Value = value; }
        }

        public DateTime BsDocDate
        {
            get { return _bsDocDate.GetDateTime(); }
            set { _bsDocDate.Value = value; }
        }

        public DateTime BsDueDate
        {
            get { return _bsDueDate.GetDateTime(); }
            set { _bsDueDate.Value = value; }
        }

        public string BsCardName
        {
            get { return _bsCardName.GetString(); }
            set { _bsCardName.Value = value; }
        }

        public string BsComments
        {
            get { return _bsComments.GetString(); }
            set { _bsComments.Value = value; }
        }

        public string Posted
        {
            get { return _posted.GetString(); }
            set { _posted.Value = value; }
        }

        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="docEntry">Código.</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public bool GetByKey(int docEntry)
        {
            DocEntry = docEntry;

            return GetByKey();
        }
        
        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de DocumentTaxExtension.</returns>
        public List<DocumentDownPaymentsToDraw> GetAll()
        {
            return FillCollection<DocumentDownPaymentsToDraw>(GetData().Rows);
        }
        
        public List<DocumentDownPaymentsToDraw> GetByDocEntry(int pDocEntry)
        {
            var tableQuery = new TableQuery(this);

            tableQuery.Where.Add(new QueryParam(_baseAbs, pDocEntry));

            return FillCollection<DocumentDownPaymentsToDraw>(tableQuery);
        }

        
    }
}
