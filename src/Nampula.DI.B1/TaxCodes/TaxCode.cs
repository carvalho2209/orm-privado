using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.TaxCodes
{

    public class TaxCode : TableAdapter
    {

        public struct FieldsName
        {
            public static readonly string Code = "Code";
            public static readonly string Name = "Name";
            public static readonly string Rate = "Rate";
            public static readonly string ValidForAR = "ValidForAR";
            public static readonly string ValidForAP = "ValidForAP";
            public static readonly string Lock = "Lock";
        }

        public struct Description
        {
            public static readonly string Code = "Código";
            public static readonly string Name = "Descrição";
            public static readonly string Rate = "Aliquota";
            public static readonly string ValidForAR = "Venda";
            public static readonly string ValidForAP = "Compra";
            public static readonly string Lock = "Bloqueado";
        }

        public struct Definition
        {
            public static readonly string TableName = "OSTC";
        }

        private TableAdapterField m_Code = new TableAdapterField(FieldsName.Code, Description.Code, DbType.String, 15, "", true, false);
        private TableAdapterField m_Name = new TableAdapterField(FieldsName.Name, Description.Name, 50);
        private TableAdapterField m_Rate = new TableAdapterField(FieldsName.Rate, Description.Rate, DbType.Decimal);
        private TableAdapterField m_ValidForAR = new TableAdapterField(FieldsName.ValidForAP, Description.ValidForAP, 1);
        private TableAdapterField m_ValidForAP = new TableAdapterField(FieldsName.ValidForAR, Description.ValidForAR, 1);
        private TableAdapterField m_Lock = new TableAdapterField(FieldsName.Lock, Description.Lock, 1);

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
            get { return m_Code.GetString(); }
            private set { m_Code.Value = value; }
        }

        public string Name
        {
            get { return m_Name.GetString(); }
            private set { m_Name.Value = value; }
        }

        public decimal Rate
        {
            get { return m_Rate.GetDecimal(); }
            private set { m_Rate.Value = value; }
        }

        public eYesNo ValidForAR
        {
            get { return m_ValidForAR.GetString().ToYesNoEnum(); }
            private set { m_ValidForAR.Value = value.ToYesNoString(); }
        }

        public eYesNo ValidForAP
        {
            get { return m_ValidForAP.GetString().ToYesNoEnum(); }
            private set { m_ValidForAP.Value = value.ToYesNoString(); }
        }

        public eYesNo Lock
        {
            get { return m_Lock.GetString().ToYesNoEnum(); }
            private set { m_Lock.Value = value.ToYesNoString(); }
        }

        public bool GetByKey(string Code)
        {
            this.Code = Code;
            return base.GetByKey();
        }

    }
}