using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.PaymentTerms
{
    public class PaymentTermsLine : TableAdapter
    {
        

        
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "CTG1";
        }
        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string CTGCode = "CTGCode";
            public static readonly string IntsNo = "IntsNo";
            public static readonly string InstMonth = "InstMonth";
            public static readonly string InstDays = "InstDays";
            public static readonly string InstPrcnt = "InstPrcnt";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string CTGCode = "CTGCode";
            public static readonly string IntsNo = "IntsNo";
            public static readonly string InstMonth = "InstMonth";
            public static readonly string InstDays = "InstDays";
            public static readonly string InstPrcnt = "InstPrcnt";
        }
        

        

        TableAdapterField m_CTGCode = new TableAdapterField(FieldsName.CTGCode, FieldsDescription.CTGCode, DbType.Int32, 11, 0, true, false);
        TableAdapterField m_IntsNo = new TableAdapterField(FieldsName.IntsNo, FieldsDescription.IntsNo, DbType.Int32, 11, 0, true, false);
        TableAdapterField m_InstMonth = new TableAdapterField(FieldsName.InstMonth, FieldsDescription.InstMonth, DbType.Int32);
        TableAdapterField m_InstDays = new TableAdapterField(FieldsName.InstDays, FieldsDescription.InstDays, DbType.Int32);
        TableAdapterField m_InstPrcnt = new TableAdapterField(FieldsName.InstPrcnt, FieldsDescription.InstPrcnt, DbType.Decimal, 19, 6);

        

        

        

        public PaymentTermsLine()
            : base(Definition.TableName)
        {
        }

        public PaymentTermsLine(string pCompanyDb)
            : base(pCompanyDb, Definition.TableName)
        {
        }

        public PaymentTermsLine(PaymentTermsLine pPaymentTermsLine)
            : this()
        {
            this.CopyBy(pPaymentTermsLine);
        }

        

        

        /// <summary>
        /// Chave 1
        /// </summary>
        public int CTGCode
        {
            get { return m_CTGCode.GetInt32(); }
            set { m_CTGCode.Value = value; }
        }

        /// <summary>
        /// Chave 2
        /// </summary>
        public Int32 IntsNo
        {
            get { return m_IntsNo.GetInt32(); }
            set { m_IntsNo.Value = value; }
        }

        /// <summary>
        /// Meses
        /// </summary>
        public Int32 InstMonth
        {
            get { return m_InstMonth.GetInt32(); }
            set { m_InstMonth.Value = value; }
        }


        /// <summary>
        /// Dias
        /// </summary>
        public Int32 InstDays
        {
            get { return m_InstDays.GetInt32(); }
            set { m_InstDays.Value = value; }
        }

        /// <summary>
        /// Percentual parcelamento
        /// </summary>
        public Decimal InstPrcnt
        {
            get { return m_InstPrcnt.GetDecimal(); }
            set { m_InstPrcnt.Value = value; }
        }

        public bool GetByKey(int pCTGCode, int pIntsNo)
        {
            this.CTGCode = pCTGCode;
            this.IntsNo = pIntsNo;
            return base.GetByKey();
        }
        


    }
}
