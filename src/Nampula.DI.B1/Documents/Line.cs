using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Nampula.DI.B1.BatchNumbers;
using Nampula.DI.B1.TransactionLog;
using Nampula.DI.B1.Version;
using Nampula.Framework;
using Nampula.DI.B1.Helpers;
using Nampula.DI.B1.ProductTrees;

namespace Nampula.DI.B1.Documents
{
    /// <summary>
    /// Tabela de Documentos de Marketing - Linhas
    /// </summary>
    public class Line : TableAdapter
    {
        /// <summary>
        /// Nome dos Campos
        /// </summary>
        public struct FieldsName
        {
            public static readonly string DocEntry = "DocEntry";
            public static readonly string LineNum = "LineNum";
            public static readonly string DocDate = "DocDate";
            public static readonly string AcctCode = "AcctCode";
            public static readonly string ItemCode = "ItemCode";
            public static readonly string Dscription = "Dscription";
            public static readonly string UseBaseUn = "UseBaseUn";
            public static readonly string Usage = "Usage";
            public static readonly string WhsCode = "WhsCode";
            public static readonly string TaxCode = "TaxCode";
            public static readonly string CFOPCode = "CFOPCode";
            public static readonly string CSTCode = "CSTCode";
            public static readonly string CSTfCOFINS = "CSTfCOFINS";
            public static readonly string CSTfIPI = "CSTfIPI";
            public static readonly string CSTfPIS = "CSTfPIS";
            public static readonly string Quantity = "Quantity";
            public static readonly string PriceBefDi = "PriceBefDi";
            public static readonly string DiscPrcnt = "DiscPrcnt";
            public static readonly string LineTotal = "LineTotal";
            public static readonly string OcrCode = "OcrCode";
            public static readonly string Volume = "Volume";
            public static readonly string Weight1 = "Weight1";
            public static readonly string Height1 = "Height1";
            public static readonly string Width1 = "Width1";
            public static readonly string Length1 = "Length1";
            public static readonly string ObjType = "ObjType";
            public static readonly string BaseEntry = "BaseEntry";
            public static readonly string BaseLine = "BaseLine";
            public static readonly string BaseType = "BaseType";

            public static readonly string TrgetEntry = "TrgetEntry";
            public static readonly string TargetType = "TargetType";

            public static readonly string TaxOnly = "TaxOnly";
            public static readonly string LineStatus = "LineStatus";
            public static readonly string Hght1Unit = "Hght1Unit";
            public static readonly string Len1Unit = "Len1Unit";
            public static readonly string Wdth1Unit = "Wdth1Unit";
            public static readonly string VolUnit = "VolUnit";
            public static readonly string Project = "Project";
            public static readonly string OcrCode2 = "OcrCode2";
            public static readonly string OcrCode3 = "OcrCode3";
            public static readonly string OcrCode4 = "OcrCode4";
            public static readonly string OcrCode5 = "OcrCode5";
            public static readonly string Price = "Price";
            public static readonly string VendorNum = "VendorNum";
            public static readonly string OpenCreQty = "OpenCreQty";
            public static readonly string BackOrdr = "BackOrdr";
            public static readonly string Currency = "Currency";
            public static readonly string Rate = "Rate";
            public static readonly string unitMsr = "unitMsr";
            public static readonly string CodeBars = "CodeBars";
            public static readonly string SubCatNum = "SubCatNum";
            public static readonly string FreeTxt = "FreeTxt";
            public static readonly string UomCode = "UomCode";
            public static readonly string UomEntry = "UomEntry";
            public static readonly string PackQty = "PackQty";
            public static readonly string VisOrder = "VisOrder";
            public static readonly string NumPerMsr = "NumPerMsr";
            public static readonly string TreeType = "TreeType";

        }

        /// <summary>
        /// Descrição dos Campos
        /// </summary>
        public struct Description
        {

            public static readonly string DocEntry = "Código";
            public static readonly string LineNum = "Linha";
            public static readonly string DocDate = "Data Documento";
            public static readonly string AcctCode = "Conta Contábil";
            public static readonly string ItemCode = "Item";
            public static readonly string Dscription = "Descrição";
            public static readonly string UseBaseUn = "UseBaseUn";
            public static readonly string Usage = "Utilização";
            public static readonly string WhsCode = "Depósito";
            public static readonly string TaxCode = "Código do Imposto";
            public static readonly string CFOPCode = "CFOP";
            public static readonly string CSTCode = "CST para ICMS";
            public static readonly string CSTfCOFINS = "CST para COFINS";
            public static readonly string CSTfIPI = "CST para IPI";
            public static readonly string CSTfPIS = "CST para PIS";
            public static readonly string Quantity = "Quantidade";
            public static readonly string PriceBefDi = "Preço Unitário";
            public static readonly string DiscPrcnt = "% Desconto";
            public static readonly string LineTotal = "Total da Linha";
            public static readonly string OcrCode = "Centro de Custo 1";
            public static readonly string Volume = "Volume";
            public static readonly string Weight1 = "Peso";
            public static readonly string Height1 = "Altura";
            public static readonly string Width1 = "Largura";
            public static readonly string Length1 = "Comprimento";
            public static readonly string ObjType = "Tipo do Objeto";
            public static readonly string BaseEntry = "Documento Base";
            public static readonly string BaseLine = "Linha do Documento Base";
            public static readonly string BaseType = "Tipo do Documento Base";

            public static readonly string TrgetEntry = "N° do Destino";
            public static readonly string TargetType = "Tipo do Destino";

            public static readonly string TaxOnly = "Somente Imposto";
            public static readonly string LineStatus = "Status";
            public static readonly string Hght1Unit = "Unidade de Altura";
            public static readonly string Len1Unit = "Unidade de Comprimento";
            public static readonly string Wdth1Unit = "Unidade de Largura";
            public static readonly string VolUnit = "Unidade de Volume";
            public static readonly string OcrCode2 = "Centro de Custo 2";
            public static readonly string OcrCode3 = "Centro de Custo 3";
            public static readonly string OcrCode4 = "Centro de Custo 4";
            public static readonly string OcrCode5 = "Centro de Custo 5";
            public static readonly string Price = "Price";
            public static readonly string Project = "Projeto";
            public static readonly string VendorNum = "ID do Catalogo";
            public static readonly string OpenCreQty = "Quantidade em Aberto";
            public static readonly string BackOrdr = "Entrega Parcial";
            public static readonly string Currency = "Moeda";
            public static readonly string Rate = "Taxa";
            public static readonly string unitMsr = "Unidate de Medida";
            public static readonly string ItemType = "ItemType";
            public static readonly string CodeBars = "CodeBars";
            public static readonly string SubCatNum = "Catalogo do Fornecedor";
            public static readonly string FreeTxt = "Texto livre";
            public static readonly string UomCode = "Sigla da Unidade";
            public static readonly string UomEntry = "Id da Unidade";
            public static readonly string PackQty = "N° de embalagens";
            public static readonly string VisOrder = "Ordem de Visualização";
            public static readonly string NumPerMsr = "Itens por Unidade";
            public static readonly string TreeType = "TreeType";
        }

        readonly TableAdapterField m_DocEntry = new TableAdapterField(FieldsName.DocEntry, Description.DocEntry, DbType.Int32, 11, null, true, false);
        readonly TableAdapterField m_LineNum = new TableAdapterField(FieldsName.LineNum, Description.LineNum, DbType.Int32, 11, null, true, false);
        readonly TableAdapterField m_AcctCode = new TableAdapterField(FieldsName.AcctCode, Description.AcctCode, 15);
        readonly TableAdapterField m_DocDate = new TableAdapterField(FieldsName.DocDate, Description.DocDate, DbType.DateTime);
        readonly TableAdapterField m_ItemCode = new TableAdapterField(FieldsName.ItemCode, Description.ItemCode, 15);
        readonly TableAdapterField m_Dscription = new TableAdapterField(FieldsName.Dscription, Description.Dscription, 200);
        readonly TableAdapterField m_UseBaseUn = new TableAdapterField(FieldsName.UseBaseUn, Description.UseBaseUn, 1);
        readonly TableAdapterField m_TaxCode = new TableAdapterField(FieldsName.TaxCode, Description.TaxCode, 8);
        readonly TableAdapterField m_WhsCode = new TableAdapterField(FieldsName.WhsCode, Description.WhsCode, 8);
        readonly TableAdapterField m_Usage = new TableAdapterField(FieldsName.Usage, Description.Usage, DbType.Int32);
        readonly TableAdapterField m_CFOPCode = new TableAdapterField(FieldsName.CFOPCode, Description.CFOPCode, 6);
        readonly TableAdapterField m_CSTCode = new TableAdapterField(FieldsName.CSTCode, Description.CSTCode, 4);
        readonly TableAdapterField m_CSTfCOFINS = new TableAdapterField(FieldsName.CSTfCOFINS, Description.CSTfCOFINS, 4);
        readonly TableAdapterField m_CSTfIPI = new TableAdapterField(FieldsName.CSTfIPI, Description.CSTfIPI, 4);
        readonly TableAdapterField m_CSTfPIS = new TableAdapterField(FieldsName.CSTfPIS, Description.CSTfPIS, 4);
        readonly TableAdapterField m_Quantity = new TableAdapterField(FieldsName.Quantity, Description.Quantity, DbType.Decimal);
        readonly TableAdapterField m_OpenCreQty = new TableAdapterField(FieldsName.OpenCreQty, Description.OpenCreQty, DbType.Decimal);
        readonly TableAdapterField m_PriceBefDi = new TableAdapterField(FieldsName.PriceBefDi, Description.PriceBefDi, DbType.Decimal);
        readonly TableAdapterField m_DiscPrcnt = new TableAdapterField(FieldsName.DiscPrcnt, Description.DiscPrcnt, DbType.Decimal);
        readonly TableAdapterField m_LineTotal = new TableAdapterField(FieldsName.LineTotal, Description.LineTotal, DbType.Decimal);
        readonly TableAdapterField m_Volume = new TableAdapterField(FieldsName.Volume, Description.Volume, DbType.Decimal);
        readonly TableAdapterField m_Weight1 = new TableAdapterField(FieldsName.Weight1, Description.Weight1, DbType.Decimal);
        readonly TableAdapterField m_Height1 = new TableAdapterField(FieldsName.Height1, Description.Height1, DbType.Decimal);
        readonly TableAdapterField m_Width1 = new TableAdapterField(FieldsName.Width1, Description.Width1, DbType.Decimal);
        readonly TableAdapterField m_Length1 = new TableAdapterField(FieldsName.Length1, Description.Length1, DbType.Decimal);
        readonly TableAdapterField m_ObjType = new TableAdapterField(FieldsName.ObjType, Description.ObjType, DbType.Int32);
        readonly TableAdapterField m_BaseEntry = new TableAdapterField(FieldsName.BaseEntry, Description.BaseEntry, DbType.Int32);
        readonly TableAdapterField m_BaseType = new TableAdapterField(FieldsName.BaseType, Description.BaseType, DbType.Int32);
        readonly TableAdapterField m_BaseLine = new TableAdapterField(FieldsName.BaseLine, Description.BaseLine, DbType.Int32);

        readonly TableAdapterField m_TrgetEntry = new TableAdapterField(FieldsName.TrgetEntry, Description.TrgetEntry, DbType.Int32);
        readonly TableAdapterField m_TargetType = new TableAdapterField(FieldsName.TargetType, Description.TargetType, DbType.Int32);

        readonly TableAdapterField m_TaxOnly = new TableAdapterField(FieldsName.TaxOnly, Description.TaxOnly, 1);
        readonly TableAdapterField m_LineStatus = new TableAdapterField(FieldsName.LineStatus, Description.LineStatus, 1);

        readonly TableAdapterField m_Hght1Unit = new TableAdapterField(FieldsName.Hght1Unit, Description.Hght1Unit, DbType.Int32);
        readonly TableAdapterField m_Len1Unit = new TableAdapterField(FieldsName.Len1Unit, Description.Hght1Unit, DbType.Int32);
        readonly TableAdapterField m_Wdth1Unit = new TableAdapterField(FieldsName.Wdth1Unit, Description.Hght1Unit, DbType.Int32);
        readonly TableAdapterField m_Project = new TableAdapterField(FieldsName.Project, Description.Project, 20);
        readonly TableAdapterField m_OcrCode = new TableAdapterField(FieldsName.OcrCode, Description.OcrCode, 8);
        readonly TableAdapterField m_OcrCode2 = new TableAdapterField(FieldsName.OcrCode2, Description.OcrCode2, 8);
        readonly TableAdapterField m_OcrCode3 = new TableAdapterField(FieldsName.OcrCode3, Description.OcrCode3, 8);
        readonly TableAdapterField m_OcrCode4 = new TableAdapterField(FieldsName.OcrCode4, Description.OcrCode4, 8);
        readonly TableAdapterField m_OcrCode5 = new TableAdapterField(FieldsName.OcrCode5, Description.OcrCode5, 8);
        readonly TableAdapterField m_Price = new TableAdapterField(FieldsName.Price, Description.Price, DbType.Decimal);
        readonly TableAdapterField m_VendorNum = new TableAdapterField(FieldsName.VendorNum, Description.VendorNum, 17);
        readonly TableAdapterField m_BackOrdr = new TableAdapterField(FieldsName.BackOrdr, Description.BackOrdr, 1);
        readonly TableAdapterField m_Currency = new TableAdapterField(FieldsName.Currency, Description.Currency, 3);
        readonly TableAdapterField m_Rate = new TableAdapterField(FieldsName.Rate, Description.Rate, DbType.Decimal);
        readonly TableAdapterField m_unitMsr = new TableAdapterField(FieldsName.unitMsr, Description.unitMsr, 20);
        readonly TableAdapterField m_CodeBars = new TableAdapterField(FieldsName.CodeBars, Description.CodeBars, 200);
        readonly TableAdapterField m_SubCatNum = new TableAdapterField(FieldsName.SubCatNum, Description.SubCatNum, 200);
        readonly TableAdapterField m_FreeTxt = new TableAdapterField(FieldsName.FreeTxt, Description.FreeTxt, 100);
        readonly TableAdapterField m_PackQty = new TableAdapterField(FieldsName.PackQty, Description.PackQty, DbType.Decimal);
        readonly TableAdapterField m_VisOrder = new TableAdapterField(FieldsName.VisOrder, Description.VisOrder, DbType.Int32);
        readonly TableAdapterField m_NumPerMsr = new TableAdapterField(FieldsName.NumPerMsr, Description.NumPerMsr, DbType.Decimal);
        readonly TableAdapterField m_TreeType = new TableAdapterField(FieldsName.TreeType, FieldsName.TreeType, 2);

        public Line()
        {
            TaxAmounts = new List<DocumentTaxAmount>();
            BatchNumbes = new List<BatchNumber>();
            BatchNumberForDrafts = new List<BatchNumberBase>();
            WithholdingTaxes = new List<DocumentWithholdingTax>();
            SerialNumbers = new List<LineSerialNumber>();
            AdditionalExpenses = new List<DocumentLinesAdditionalExpenses>();

            AddUomEntryIfNeeded();
        }

        public Line(string pCompanyDb, eDocumentObjectType pObjectType)
            : base(pCompanyDb, pObjectType.GetTableNameSufix() + "1")
        {
            ObjType = pObjectType;
            TaxAmounts = new List<DocumentTaxAmount>();
            BatchNumbes = new List<BatchNumber>();
            WithholdingTaxes = new List<DocumentWithholdingTax>();
            SerialNumbers = new List<LineSerialNumber>();
            BatchNumberForDrafts = new List<BatchNumberBase>();
            AdditionalExpenses = new List<DocumentLinesAdditionalExpenses>();

            AddUomEntryIfNeeded();
        }

        public Line(Line pLine)
            : this()
        {
            CopyBy(pLine);

            pLine.BatchNumbes.ForEach(
                b => BatchNumbes.Add(new BatchNumber(b)));

            BatchNumberForDrafts.ForEach(
                b => BatchNumberForDrafts.Add(new BatchNumberBase(b)));

            pLine.WithholdingTaxes.ForEach(
                b => WithholdingTaxes.Add(new DocumentWithholdingTax(b)));

            pLine.SerialNumbers.ForEach(
                b => SerialNumbers.Add(new LineSerialNumber(b)));

            pLine.TaxAmounts.ForEach(
                b => TaxAmounts.Add(new DocumentTaxAmount(b)));

            pLine.AdditionalExpenses.ForEach(
                b => AdditionalExpenses.Add(new DocumentLinesAdditionalExpenses(b)));
        }

        private void AddUomEntryIfNeeded()
        {
            if (!SboVersion.EqualOrMoreThenSap9Pl4()) return;

            Collumns.Add(new TableAdapterField(FieldsName.UomEntry, Description.UomEntry, DbType.Int32));
            Collumns.Add(new TableAdapterField(FieldsName.UomCode, Description.UomCode, 10));
        }

        public Int32 DocEntry
        {
            get { return m_DocEntry.GetInt32(); }
            set { m_DocEntry.Value = value; }
        }

        public Int32 LineNum
        {
            get { return m_LineNum.GetInt32(); }
            set { m_LineNum.Value = value; }
        }

        public string AcctCode
        {
            get { return m_AcctCode.GetString(); }
            set { m_AcctCode.Value = value; }
        }

        /// <summary>
        /// Código do ítem
        /// </summary>
        public string ItemCode
        {
            get { return m_ItemCode.GetString(); }
            set { m_ItemCode.Value = value; }
        }

        /// <summary>
        /// Data do documento
        /// </summary>
        public DateTime DocDate
        {
            get { return m_DocDate.GetDateTime(); }
            set { m_DocDate.Value = value; }
        }

        public string Dscription
        {
            get { return m_Dscription.GetString(); }
            set { m_Dscription.Value = value; }
        }

        public Int32 Usage
        {
            get { return m_Usage.GetInt32(); }
            set { m_Usage.Value = value; }
        }

        public eYesNo UseBaseUn
        {
            get { return m_UseBaseUn.GetString().ToYesNoEnum(); }
            set { m_UseBaseUn.Value = value.ToYesNoString(); }
        }

        public string WhsCode
        {
            get { return m_WhsCode.GetString(); }
            set { m_WhsCode.Value = value; }
        }

        public string TaxCode
        {
            get { return m_TaxCode.GetString(); }
            set { m_TaxCode.Value = value; }
        }

        public string CFOPCode
        {
            get { return m_CFOPCode.GetString(); }
            set { m_CFOPCode.Value = value; }
        }

        public string CSTCode
        {
            get { return m_CSTCode.GetString(); }
            set { m_CSTCode.Value = value; }
        }

        public string CSTfCOFINS
        {
            get { return m_CSTfCOFINS.GetString(); }
            set { m_CSTfCOFINS.Value = value; }
        }

        public string CSTfIPI
        {
            get { return m_CSTfIPI.GetString(); }
            set { m_CSTfIPI.Value = value; }
        }

        public string CSTfPIS
        {
            get { return m_CSTfPIS.GetString(); }
            set { m_CSTfPIS.Value = value; }
        }

        public decimal Quantity
        {
            get { return m_Quantity.GetDecimal(); }
            set { m_Quantity.Value = value; }
        }

        public decimal OpenCreQty
        {
            get { return m_OpenCreQty.GetDecimal(); }
            set { m_OpenCreQty.Value = value; }
        }

        public decimal PriceBefDi
        {
            get { return m_PriceBefDi.GetDecimal(); }
            set { m_PriceBefDi.Value = value; }
        }

        public decimal DiscPrcnt
        {
            get { return m_DiscPrcnt.GetDecimal(); }
            set { m_DiscPrcnt.Value = value; }
        }

        public String Project
        {
            get { return m_Project.GetString(); }
            set { m_Project.Value = value; }
        }


        public decimal DiscSumTemp { get; set; }

        public decimal LineTotal
        {
            get { return m_LineTotal.GetDecimal(); }
            set { m_LineTotal.Value = value; }
        }

        public decimal Volume
        {
            get { return m_Volume.GetDecimal(); }
            set { m_Volume.Value = value; }
        }

        public decimal Weight1
        {
            get { return m_Weight1.GetDecimal(); }
            set { m_Weight1.Value = value; }
        }

        public decimal Height1
        {
            get { return m_Height1.GetDecimal(); }
            set { m_Height1.Value = value; }
        }

        public decimal Width1
        {
            get { return m_Width1.GetDecimal(); }
            set { m_Width1.Value = value; }
        }

        public decimal Length1
        {
            get { return m_Length1.GetDecimal(); }
            set { m_Length1.Value = value; }
        }

        public eDocumentObjectType ObjType
        {
            get { return m_ObjType.GetInt32().ToDocumentObjectTypeEnum(); }
            set { m_ObjType.Value = value.ToInt32(); }
        }

        public int BaseEntry
        {
            get { return m_BaseEntry.GetInt32(); }
            set { m_BaseEntry.Value = value.To<Int32>(); }
        }

        public int BaseLine
        {
            get { return m_BaseLine.GetInt32(); }
            set { m_BaseLine.Value = value.To<Int32>(); }
        }

        public eDocumentObjectType BaseType
        {
            get { return m_BaseType.GetInt32().ToDocumentObjectTypeEnum(); }
            set { m_BaseType.Value = value.ToInt32(); }
        }

        public int TrgetEntry
        {
            get { return m_TrgetEntry.GetInt32(); }
            set { m_TrgetEntry.Value = value.To<Int32>(); }
        }

        public eDocumentObjectType TargetType
        {
            get { return m_TargetType.GetInt32().ToDocumentObjectTypeEnum(); }
            set { m_TargetType.Value = value.ToInt32(); }
        }

        public eYesNo TaxOnly
        {
            get { return m_TaxOnly.GetString().ToYesNoEnum(); }
            set { m_TaxOnly.Value = value.ToYesNoString(); }
        }

        /// <summary>
        /// Entrega parcial
        /// </summary>
        public eYesNo BackOrdr
        {
            get { return m_BackOrdr.GetString().ToYesNoEnum(); }
            set { m_BackOrdr.Value = value.ToYesNoString(); }
        }

        public eDocStatus LineStatus
        {
            get { return m_LineStatus.GetString().ToDocStatusEnum(); }
            set { m_LineStatus.Value = value.ToDocStatusString(); }
        }

        public int Hght1Unit
        {
            get { return m_Hght1Unit.GetInt32(); }
            set { m_Hght1Unit.Value = value.To<Int32>(); }
        }

        public int Len1Unit
        {
            get { return m_Len1Unit.GetInt32(); }
            set { m_Len1Unit.Value = value.To<Int32>(); }
        }

        public int Wdth1Unit
        {
            get { return m_Wdth1Unit.GetInt32(); }
            set { m_Wdth1Unit.Value = value.To<Int32>(); }
        }

        public string OcrCode
        {
            get { return m_OcrCode.GetString(); }
            set { m_OcrCode.Value = value; }
        }

        public string OcrCode2
        {
            get { return m_OcrCode2.GetString(); }
            set { m_OcrCode2.Value = value; }
        }

        public string OcrCode3
        {
            get { return m_OcrCode3.GetString(); }
            set { m_OcrCode3.Value = value; }
        }

        public string OcrCode4
        {
            get { return m_OcrCode4.GetString(); }
            set { m_OcrCode4.Value = value; }
        }

        public string OcrCode5
        {
            get { return m_OcrCode5.GetString(); }
            set { m_OcrCode5.Value = value; }
        }

        public Decimal Price
        {
            get { return m_Price.GetDecimal(); }
            set { m_Price.Value = value; }
        }

        public string VendorNum
        {
            get { return m_VendorNum.GetString(); }
            set { m_VendorNum.Value = value; }
        }

        public string Currency
        {
            get { return m_Currency.GetString(); }
            set { m_Currency.Value = value; }
        }

        public decimal Rate
        {
            get { return m_Rate.GetDecimal(); }
            set { m_Rate.Value = value; }
        }

        public string unitMsr
        {
            get { return m_unitMsr.GetString(); }
            set { m_unitMsr.Value = value; }
        }

        public String CodeBars
        {
            get { return m_CodeBars.GetString(); }
            set { m_CodeBars.Value = value; }
        }

        public String SubCatNum
        {
            get { return m_SubCatNum.GetString(); }
            set { m_SubCatNum.Value = value; }
        }

        public String UomCode
        {
            get
            {
                var uomColumn = Collumns
                    .FirstOrDefault(c => c.Name == FieldsName.UomCode);

                return uomColumn == null ? string.Empty : uomColumn.GetString();
            }
            set
            {
                var uomColumn = Collumns
                    .FirstOrDefault(c => c.Name == FieldsName.UomCode);

                if (uomColumn != null)
                    uomColumn.Value = value;

            }
        }

        public const int ManualUomEntry = -1;
        public Int32 UomEntry
        {
            get
            {
                var uomColumn = Collumns
                    .FirstOrDefault(c => c.Name == FieldsName.UomEntry);

                return uomColumn == null ? ManualUomEntry : uomColumn.GetInt32();
            }
            set
            {
                var uomColumn = Collumns
                    .FirstOrDefault(c => c.Name == FieldsName.UomEntry);

                if (uomColumn != null)
                    uomColumn.Value = value;

            }
        }

        public Decimal PackQty
        {
            get { return m_PackQty.GetDecimal(); }
            set { m_PackQty.Value = value; }
        }

        /// <summary>
        /// Texto livre
        /// </summary>
        public String FreeTxt
        {
            get { return m_FreeTxt.GetString(); }
            set { m_FreeTxt.Value = value; }
        }

        public Int32 VisOrder
        {
            get { return m_VisOrder.GetInt32(); }
            set { m_VisOrder.Value = value; }
        }

        public Decimal NumPerMsr
        {
            get { return m_NumPerMsr.GetDecimal(); }
            set { m_NumPerMsr.Value = value; }
        }

        public string TreeType
        {
            get { return m_TreeType.GetString(); }
            set { m_TreeType.Value = value; }
        }

        public List<BatchNumber> BatchNumbes { get; set; }

        public List<BatchNumberBase> BatchNumberForDrafts { get; set; }

        public List<DocumentWithholdingTax> WithholdingTaxes { get; set; }

        public List<LineSerialNumber> SerialNumbers { get; set; }

        public List<DocumentTaxAmount> TaxAmounts { get; set; }

        public List<DocumentLinesAdditionalExpenses> AdditionalExpenses { get; set; }

        public bool GetByKey(Int32 pDocEntry, Int32 pLineNum)
        {
            DocEntry = pDocEntry;
            LineNum = pLineNum;

            return base.GetByKey();
        }

        public DataTable GetByDocEntry(Int32 pDocEntry, bool pResultData)
        {
            var tableQuery = new TableQuery(this);

            tableQuery.Where.Add(new QueryParam(m_DocEntry, pDocEntry));

            tableQuery.OrderBy.Add(new OrderBy(new QueryParam(m_LineNum)));

            return GetData(tableQuery);
        }

        public List<Line> GetByDocEntry(Int32 pDocEntry)
        {
            return FillCollection<Line>(GetByDocEntry(pDocEntry, true).Rows);
        }

        public List<Line> GetByBaseEntry(int pBaseEntry)
        {
            var tableQuery = new TableQuery(this);

            tableQuery.Where.Add(new QueryParam(m_BaseEntry, pBaseEntry));

            return FillCollection<Line>(tableQuery);
        }

        public bool Draft
        {
            get { return IsDraft(); }
        }

        private bool IsDraft(eDocumentObjectType pDocumentObjectType = eDocumentObjectType.oNone)
        {
            return pDocumentObjectType == eDocumentObjectType.oDrafts
                   || (TableName != null && TableName.Contains("DRF"));
        }
        private eDocumentObjectType GetObjType()
        {
            return IsDraft() ? eDocumentObjectType.oDrafts : ObjType;
        }

        public void FillBatches()
        {
            if (IsDraft())
            {
                FillBatchesForDraft();
                return;
            }

            BatchNumbes = new List<BatchNumber>();

            var batches = B1Helper.GetBatchNumbers(
                DBName, ItemCode, WhsCode, DocEntry, LineNum, ObjType);

            if (batches.IsEmpty() && BaseType != eDocumentObjectType.oNone)
            {
                batches = B1Helper.GetBatchNumbers(
                    DBName, ItemCode, WhsCode, BaseEntry, BaseLine, BaseType);
            }

            foreach (var batch in batches)
            {
                var newBath = new BatchNumber(DBName);

                if (!newBath.GetByKey(batch.ItemCode, batch.WhsCode, batch.BatchNum))
                    continue;

                newBath.Quantity = batch.Quantity;
                BatchNumbes.Add(newBath);
            }

        }

        private void FillBatchesForDraft()
        {
            BatchNumberForDrafts = new List<BatchNumberBase>();

            var serialBanchesForLine = new LineSerialAndBatch(DBName, eDocumentObjectType.oDrafts);
            var tableQuery = new TableQuery(serialBanchesForLine);

            tableQuery.Where.Add(
                new QueryParam(serialBanchesForLine.Collumns[LineSerialAndBatch.FieldsName.AbsEntry], DocEntry));

            tableQuery.Where.Add(
                new QueryParam(serialBanchesForLine.Collumns[LineSerialAndBatch.FieldsName.LineNum], LineNum));

            var baches = serialBanchesForLine.FillCollection<LineSerialAndBatch>(tableQuery);

            foreach (var lineSerialAndBatch in baches)
            {
                var newBatchForDraft = GetBatchObjectById(lineSerialAndBatch.ObjId);

                if (!newBatchForDraft.GetByKey(lineSerialAndBatch.ObjAbs))
                    continue;

                newBatchForDraft.Quantity = lineSerialAndBatch.Quantity;

                BatchNumberForDrafts.Add(newBatchForDraft);
            }
        }

        /// <summary>
        /// Obtem o objeto de lote dependendo da código de objeto
        /// </summary>
        /// <param name="objId"></param>
        /// <returns></returns>
        private BatchNumberBase GetBatchObjectById(int objId)
        {
            if (objId == BatchNumberMasterData.ObjectId)
                return new BatchNumberMasterData(DBName);

            if (objId == BatchNumberDraft.ObjectId)
                return new BatchNumberDraft(DBName);

            var message = string.Format("Não encontrado objeto de lote, onde o object id é [{0}]", objId);
            throw new Exception(message);

        }

        public void FillSerialNumbers()
        {
            SerialNumbers = new List<LineSerialNumber>();

            var item = B1Helper.GetItem(ItemCode, DBName);

            if (item.ManSerNum == eYesNo.No)
                return;

            var serialNumber = new TransactionLogService(DBName, DocEntry, ObjType.To<int>());
            var transLog = serialNumber.GetByLine(LineNum);

            if (transLog.Details.IsEmpty() && BaseType != eDocumentObjectType.oNone)
            {
                serialNumber = new TransactionLogService(DBName, BaseEntry, BaseType.To<int>());
                transLog = serialNumber.GetByLine(BaseLine);
            }

            foreach (var detail in transLog.Details)
            {
                SerialNumbers.Add(
                    new LineSerialNumber
                    {
                        SystemSerialNumber = detail.SysNumber
                    });
            }
        }
    }
}
