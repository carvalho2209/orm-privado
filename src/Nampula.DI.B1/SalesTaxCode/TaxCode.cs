using System;
using System.Data;

namespace Nampula.DI.B1.SalesTaxCode
{
    /// <summary>
    /// Código de Imposto
    /// </summary>
    public class TaxCode : TableAdapter
    {

        public struct FieldsName
        {
            public static readonly string Code = "Code";
            public static readonly string Name = "Name";
            public static readonly string Rate = "Rate";
            public static readonly string ValidForAr = "ValidForAR";
            public static readonly string ValidForAp = "ValidForAP";
            public static readonly string Lock = "Lock";
            public static readonly string CfopIn = "CfopIn";
            public static readonly string CfopOut = "CfopOut";
        }

        public struct FieldsDescription
        {
            public static readonly string Code = "Código";
            public static readonly string Name = "Descrição";
            public static readonly string Rate = "Aliquota";
            public static readonly string ValidForAr = "Venda";
            public static readonly string ValidForAp = "Compra";
            public static readonly string Lock = "Bloqueado";
            public static readonly string CfopIn = "CFOP Entrada";
            public static readonly string CfopOut = "CFOP Saída";
        }

        public struct Definition
        {
            public static readonly string TableName = "OSTC";
        }

        private readonly TableAdapterField _code = new TableAdapterField(FieldsName.Code, FieldsDescription.Code, DbType.String, 15, "", true, false);
        private readonly TableAdapterField _name = new TableAdapterField(FieldsName.Name, FieldsDescription.Name, 50);
        private readonly TableAdapterField _rate = new TableAdapterField(FieldsName.Rate, FieldsDescription.Rate, DbType.Decimal);
        private readonly TableAdapterField _validForAr = new TableAdapterField(FieldsName.ValidForAp, FieldsDescription.ValidForAp, 1);
        private readonly TableAdapterField _validForAp = new TableAdapterField(FieldsName.ValidForAr, FieldsDescription.ValidForAr, 1);
        private readonly TableAdapterField _lock = new TableAdapterField(FieldsName.Lock, FieldsDescription.Lock, 1);
        TableAdapterField _cfopIn = new TableAdapterField(FieldsName.CfopIn, FieldsDescription.CfopIn, 6);
        TableAdapterField _cfopOut = new TableAdapterField(FieldsName.CfopOut, FieldsDescription.CfopOut, 6);

        public TaxCode(string pCompanyDb)
            : base(pCompanyDb, Definition.TableName)
        {
        }

        public TaxCode()
            : base(Definition.TableName)
        {
        }

        public string Code
        {
            get { return _code.GetString(); }
            private set { _code.Value = value; }
        }

        public string Name
        {
            get { return _name.GetString(); }
            private set { _name.Value = value; }
        }

        public decimal Rate
        {
            get { return _rate.GetDecimal(); }
            private set { _rate.Value = value; }
        }

        public eYesNo ValidForAr
        {
            get { return _validForAr.GetString().ToYesNoEnum(); }
            private set { _validForAr.Value = value.ToYesNoString(); }
        }

        public eYesNo ValidForAp
        {
            get { return _validForAp.GetString().ToYesNoEnum(); }
            private set { _validForAp.Value = value.ToYesNoString(); }
        }

        public eYesNo Lock
        {
            get { return _lock.GetString().ToYesNoEnum(); }
            private set { _lock.Value = value.ToYesNoString(); }
        }

        public String CfopIn
        {
            get { return _cfopIn.GetString(); }
            set { _cfopIn.Value = value; }
        }

        public String CfopOut
        {
            get { return _cfopOut.GetString(); }
            set { _cfopOut.Value = value; }
        }


    }
}