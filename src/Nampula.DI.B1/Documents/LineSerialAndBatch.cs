using System;
using System.Data;

namespace Nampula.DI.B1.Documents
{

    /// <summary>
    /// Tabela de Linhas dos Lotes dos Drafts
    /// </summary>
    public class LineSerialAndBatch : TableAdapter
    {
        public struct FieldsName
        {
            public static readonly string AbsEntry = "AbsEntry";
            public static readonly string LineNum = "LineNum";
            public static readonly string SnBIndex = "SnBIndex";
            public static readonly string ItemCode = "ItemCode";
            public static readonly string WhsCode = "WhsCode";
            public static readonly string ObjId = "ObjId";
            public static readonly string ObjAbs = "ObjAbs";
            public static readonly string DrfWObjAbs = "DrfWObjAbs";
            public static readonly string Quantity = "Quantity";
            public static readonly string SubLineNum = "SubLineNum";
            public static readonly string ObjType = "ObjType";
        }

        public struct FieldsDescription
        {
            public static readonly string AbsEntry = "Nº do Documento";
            public static readonly string LineNum = "N° da Linha";
            public static readonly string SnBIndex = "SnBIndex";
            public static readonly string ItemCode = "ItemCode";
            public static readonly string WhsCode = "WhsCode";
            public static readonly string ObjId = "ObjId";
            /// <summary>
            /// Id do ODBN
            /// </summary>
            public static readonly string ObjAbs = "ObjAbs";
            public static readonly string DrfWObjAbs = "DrfWObjAbs";
            public static readonly string Quantity = "Quantity";
            public static readonly string SubLineNum = "SubLineNum";
            public static readonly string ObjType = "ObjType";
        }

        readonly TableAdapterField _absEntry = new TableAdapterField(FieldsName.AbsEntry, FieldsDescription.AbsEntry, DbType.Int32, 11, 0, true, true);
        readonly TableAdapterField _lineNum = new TableAdapterField(FieldsName.LineNum, FieldsDescription.LineNum, DbType.Int32);
        readonly TableAdapterField _snBIndex = new TableAdapterField(FieldsName.SnBIndex, FieldsDescription.SnBIndex, DbType.Int32);
        readonly TableAdapterField _itemCode = new TableAdapterField(FieldsName.ItemCode, FieldsDescription.ItemCode, 100);
        readonly TableAdapterField _whsCode = new TableAdapterField(FieldsName.WhsCode, FieldsDescription.WhsCode, 100);
        readonly TableAdapterField _objId = new TableAdapterField(FieldsName.ObjId, FieldsDescription.ObjId, DbType.Int32);
        readonly TableAdapterField _objAbs = new TableAdapterField(FieldsName.ObjAbs, FieldsDescription.ObjAbs, DbType.Int32);
        readonly TableAdapterField _drfWObjAbs = new TableAdapterField(FieldsName.DrfWObjAbs, FieldsDescription.DrfWObjAbs, DbType.Int32);
        readonly TableAdapterField _quantity = new TableAdapterField(FieldsName.Quantity, FieldsDescription.Quantity, DbType.Decimal);
        readonly TableAdapterField _subLineNum = new TableAdapterField(FieldsName.SubLineNum, FieldsDescription.SubLineNum, DbType.Int32);
        readonly TableAdapterField _objType = new TableAdapterField(FieldsName.ObjType, FieldsDescription.ObjType, 100);

        public LineSerialAndBatch()
        {
        }

        public LineSerialAndBatch(string companyDb, eDocumentObjectType documentObjectType)
            : base(companyDb, documentObjectType.GetTableNameSufix() + "16")
        {
        }

        public LineSerialAndBatch(LineSerialAndBatch pLineSerialAndBatch)
            : this()
        {
            CopyBy(pLineSerialAndBatch);
        }

        public int AbsEntry
        {
            get { return _absEntry.GetInt32(); }
            set { _absEntry.Value = value; }
        }

        public Int32 LineNum
        {
            get { return _lineNum.GetInt32(); }
            set { _lineNum.Value = value; }
        }

        public Int32 SnBIndex
        {
            get { return _snBIndex.GetInt32(); }
            set { _snBIndex.Value = value; }
        }

        public String ItemCode
        {
            get { return _itemCode.GetString(); }
            set { _itemCode.Value = value; }
        }

        public String WhsCode
        {
            get { return _whsCode.GetString(); }
            set { _whsCode.Value = value; }
        }

        public Int32 ObjId
        {
            get { return _objId.GetInt32(); }
            set { _objId.Value = value; }
        }

        public Int32 ObjAbs
        {
            get { return _objAbs.GetInt32(); }
            set { _objAbs.Value = value; }
        }

        public Int32 DrfWObjAbs
        {
            get { return _drfWObjAbs.GetInt32(); }
            set { _drfWObjAbs.Value = value; }
        }

        public Decimal Quantity
        {
            get { return _quantity.GetDecimal(); }
            set { _quantity.Value = value; }
        }

        public Int32 SubLineNum
        {
            get { return _subLineNum.GetInt32(); }
            set { _subLineNum.Value = value; }
        }

        public String ObjType
        {
            get { return _objType.GetString(); }
            set { _objType.Value = value; }
        }

    }
}
