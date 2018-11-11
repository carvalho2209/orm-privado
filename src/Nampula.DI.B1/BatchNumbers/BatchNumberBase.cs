using System;
using Nampula.DI.B1.Documents;
using System.Data;
using Nampula.Framework;

namespace Nampula.DI.B1.BatchNumbers
{
    public class BatchNumberBase : TableAdapter
    {
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string ItemCode = "ItemCode";
            public static readonly string SysNumber = "SysNumber";
            public static readonly string DistNumber = "DistNumber";
            public static readonly string MnfSerial = "MnfSerial";
            public static readonly string LotNumber = "LotNumber";
            public static readonly string ExpDate = "ExpDate";
            public static readonly string MnfDate = "MnfDate";
            public static readonly string InDate = "InDate";
            public static readonly string GrntStart = "GrntStart";
            public static readonly string GrntExp = "GrntExp";
            public static readonly string CreateDate = "CreateDate";
            public static readonly string Location = "Location";
            public static readonly string Status = "Status";
            public static readonly string Notes = "Notes";
            public static readonly string AbsEntry = "AbsEntry";
            public static readonly string ObjType = "ObjType";
            public static readonly string ItemName = "ItemName";
            public static readonly string UpdateDate = "UpdateDate";
            public static readonly string CostTotal = "CostTotal";
            public static readonly string Quantity = "Quantity";
            public static readonly string QuantOut = "QuantOut";
            public static readonly string PriceDiff = "PriceDiff";
            public static readonly string Balance = "Balance";
            public static readonly string TrackingNt = "TrackingNt";
            public static readonly string TrackiNtLn = "TrackiNtLn";
        }

        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string ItemCode = "N° do Item";
            public static readonly string SysNumber = "N° do Sistema";
            public static readonly string DistNumber = "DistNumber";
            public static readonly string MnfSerial = "MnfSerial";
            public static readonly string LotNumber = "LotNumber";
            public static readonly string ExpDate = "ExpDate";
            public static readonly string MnfDate = "MnfDate";
            public static readonly string InDate = "InDate";
            public static readonly string GrntStart = "GrntStart";
            public static readonly string GrntExp = "GrntExp";
            public static readonly string CreateDate = "CreateDate";
            public static readonly string Location = "Location";
            public static readonly string Status = "Status";
            public static readonly string Notes = "Notes";
            public static readonly string AbsEntry = "AbsEntry";
            public static readonly string ObjType = "ObjType";
            public static readonly string ItemName = "ItemName";
            public static readonly string UpdateDate = "UpdateDate";
            public static readonly string CostTotal = "CostTotal";
            public static readonly string Quantity = "Quantity";
            public static readonly string QuantOut = "QuantOut";
            public static readonly string PriceDiff = "PriceDiff";
            public static readonly string Balance = "Balance";
            public static readonly string TrackingNt = "TrackingNt";
            public static readonly string TrackiNtLn = "TrackiNtLn";
        }

        readonly TableAdapterField _absEntry = new TableAdapterField(FieldsName.AbsEntry, FieldsDescription.AbsEntry, DbType.Int32, 20, 0, true, false);
        readonly TableAdapterField _itemCode = new TableAdapterField(FieldsName.ItemCode, FieldsDescription.ItemCode, 20);
        readonly TableAdapterField _sysNumber = new TableAdapterField(FieldsName.SysNumber, FieldsDescription.SysNumber, DbType.Int32);
        readonly TableAdapterField _distNumber = new TableAdapterField(FieldsName.DistNumber, FieldsDescription.DistNumber, 100);
        readonly TableAdapterField _mnfSerial = new TableAdapterField(FieldsName.MnfSerial, FieldsDescription.MnfSerial, 100);
        readonly TableAdapterField _lotNumber = new TableAdapterField(FieldsName.LotNumber, FieldsDescription.LotNumber, 100);
        readonly TableAdapterField _expDate = new TableAdapterField(FieldsName.ExpDate, FieldsDescription.ExpDate, DbType.DateTime);
        readonly TableAdapterField _mnfDate = new TableAdapterField(FieldsName.MnfDate, FieldsDescription.MnfDate, DbType.DateTime);
        readonly TableAdapterField _inDate = new TableAdapterField(FieldsName.InDate, FieldsDescription.InDate, DbType.DateTime);
        readonly TableAdapterField _grntStart = new TableAdapterField(FieldsName.GrntStart, FieldsDescription.GrntStart, DbType.DateTime);
        readonly TableAdapterField _grntExp = new TableAdapterField(FieldsName.GrntExp, FieldsDescription.GrntExp, DbType.DateTime);
        readonly TableAdapterField _createDate = new TableAdapterField(FieldsName.CreateDate, FieldsDescription.CreateDate, DbType.DateTime);
        readonly TableAdapterField _location = new TableAdapterField(FieldsName.Location, FieldsDescription.Location, 100);
        readonly TableAdapterField _status = new TableAdapterField(FieldsName.Status, FieldsDescription.Status, 1);
        readonly TableAdapterField _notes = new TableAdapterField(FieldsName.Notes, FieldsDescription.Notes, 1000);
        readonly TableAdapterField _objType = new TableAdapterField(FieldsName.ObjType, FieldsDescription.ObjType, DbType.Int32);
        readonly TableAdapterField _itemName = new TableAdapterField(FieldsName.ItemName, FieldsDescription.ItemName, 200);
        readonly TableAdapterField _updateDate = new TableAdapterField(FieldsName.UpdateDate, FieldsDescription.UpdateDate, DbType.DateTime);
        readonly TableAdapterField _costTotal = new TableAdapterField(FieldsName.CostTotal, FieldsDescription.CostTotal, DbType.Decimal);
        readonly TableAdapterField _quantity = new TableAdapterField(FieldsName.Quantity, FieldsDescription.Quantity, DbType.Decimal);
        readonly TableAdapterField _quantOut = new TableAdapterField(FieldsName.QuantOut, FieldsDescription.QuantOut, DbType.Decimal);
        readonly TableAdapterField _priceDiff = new TableAdapterField(FieldsName.PriceDiff, FieldsDescription.PriceDiff, DbType.Decimal);
        readonly TableAdapterField _balance = new TableAdapterField(FieldsName.Balance, FieldsDescription.Balance, DbType.Decimal);
        readonly TableAdapterField _trackingNt = new TableAdapterField(FieldsName.TrackingNt, FieldsDescription.TrackingNt, DbType.Int32);
        readonly TableAdapterField _trackiNtLn = new TableAdapterField(FieldsName.TrackiNtLn, FieldsDescription.TrackiNtLn, DbType.Int32);

        public BatchNumberBase() { }

        public BatchNumberBase(BatchNumberBase batchNumberBase)
        {
            CopyBy(batchNumberBase);
        }

        public string ItemCode
        {
            get { return _itemCode.GetString(); }
            set { _itemCode.Value = value; }
        }

        public Int32 SysNumber
        {
            get { return _sysNumber.GetInt32(); }
            set { _sysNumber.Value = value; }
        }

        public String DistNumber
        {
            get { return _distNumber.GetString(); }
            set { _distNumber.Value = value; }
        }

        public String MnfSerial
        {
            get { return _mnfSerial.GetString(); }
            set { _mnfSerial.Value = value; }
        }

        public String LotNumber
        {
            get { return _lotNumber.GetString(); }
            set { _lotNumber.Value = value; }
        }

        public DateTime ExpDate
        {
            get { return _expDate.GetDateTime(); }
            set { _expDate.Value = value; }
        }

        public DateTime MnfDate
        {
            get { return _mnfDate.GetDateTime(); }
            set { _mnfDate.Value = value; }
        }

        public DateTime InDate
        {
            get { return _inDate.GetDateTime(); }
            set { _inDate.Value = value; }
        }

        public DateTime GrntStart
        {
            get { return _grntStart.GetDateTime(); }
            set { _grntStart.Value = value; }
        }

        public DateTime GrntExp
        {
            get { return _grntExp.GetDateTime(); }
            set { _grntExp.Value = value; }
        }

        public DateTime CreateDate
        {
            get { return _createDate.GetDateTime(); }
            set { _createDate.Value = value; }
        }

        public String Location
        {
            get { return _location.GetString(); }
            set { _location.Value = value; }
        }

        public String Status
        {
            get { return _status.GetString(); }
            set { _status.Value = value; }
        }

        public String Notes
        {
            get { return _notes.GetString(); }
            set { _notes.Value = value; }
        }

        public Int32 AbsEntry
        {
            get { return _absEntry.GetInt32(); }
            set { _absEntry.Value = value; }
        }

        public eDocumentObjectType ObjType
        {
            get { return (eDocumentObjectType)_objType.GetInt32(); }
            set { _objType.Value = value.To<int>(); }
        }

        public String ItemName
        {
            get { return _itemName.GetString(); }
            set { _itemName.Value = value; }
        }

        public DateTime UpdateDate
        {
            get { return _updateDate.GetDateTime(); }
            set { _updateDate.Value = value; }
        }

        public Decimal CostTotal
        {
            get { return _costTotal.GetDecimal(); }
            set { _costTotal.Value = value; }
        }

        public Decimal QuantOut
        {
            get { return _quantOut.GetDecimal(); }
            set { _quantOut.Value = value; }
        }

        public Decimal PriceDiff
        {
            get { return _priceDiff.GetDecimal(); }
            set { _priceDiff.Value = value; }
        }

        public Decimal Balance
        {
            get { return _balance.GetDecimal(); }
            set { _balance.Value = value; }
        }

        public Int32 TrackingNt
        {
            get { return _trackingNt.GetInt32(); }
            set { _trackingNt.Value = value; }
        }

        public Int32 TrackiNtLn
        {
            get { return _trackiNtLn.GetInt32(); }
            set { _trackiNtLn.Value = value; }
        }

        public decimal Quantity
        {
            get { return _quantity.GetDecimal(); }
            set { _quantity.Value = value; }
        }

        public bool GetByKey(int absEntry)
        {
            AbsEntry = absEntry;

            return GetByKey();
        }

    }
}
