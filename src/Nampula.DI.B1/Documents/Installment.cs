using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.Documents
{

    public class Installment : TableAdapter
    {

        public struct FieldsName
        {
            public static readonly string DocEntry = "DocEntry";
            public static readonly string InstlmntID = "InstlmntID";
            public static readonly string ObjType = "ObjType";
            public static readonly string DueDate = "DueDate";
            public static readonly string InstPrcnt = "InstPrcnt";
            public static readonly string InsTotal = "InsTotal";
            public static readonly string WTSum = "WTSum";
            public static readonly string Status = "Status";
            public static readonly string PaidToDate = "PaidToDate";
            public static readonly string TotalBlck = "TotalBlck";
            public static readonly string Paid = "Paid";
            public static readonly string DunDate = "DunDate";
            public static readonly string DunnLevel = "DunnLevel";
            public static readonly string DunWizBlck = "DunWizBlck";
            public static readonly string ExpAppl = "ExpAppl";
            public static readonly string ExpApplFC = "ExpApplFC";
            public static readonly string ExpApplSC = "ExpApplSC";
            public static readonly string ExpnsBlck = "ExpnsBlck";
            public static readonly string ExpnsBlckF = "ExpnsBlckF";
            public static readonly string ExpnsBlckS = "ExpnsBlckS";
            public static readonly string InsTotalFC = "InsTotalFC";
            public static readonly string InsTotalSy = "InsTotalSy";
            public static readonly string LogInstanc = "LogInstanc";
            public static readonly string LvlUpdDate = "LvlUpdDate";
            public static readonly string Ordered = "Ordered";
            public static readonly string PaidDpm = "PaidDpm";
            public static readonly string PaidDpmFc = "PaidDpmFc";
            public static readonly string PaidDpmSc = "PaidDpmSc";
            public static readonly string PaidFC = "PaidFC";
            public static readonly string PaidFrgn = "PaidFrgn";
            public static readonly string PaidSc = "PaidSc";
            public static readonly string PaidSys = "PaidSys";
            public static readonly string reserved = "reserved";
            public static readonly string TaxOnExApF = "TaxOnExApF";
            public static readonly string TaxOnExApS = "TaxOnExApS";
            public static readonly string TaxOnExBlF = "TaxOnExBlF";
            public static readonly string TaxOnExBlo = "TaxOnExBlo";
            public static readonly string TaxOnExBlS = "TaxOnExBlS";
            public static readonly string TaxOnExp = "TaxOnExp";
            public static readonly string TaxOnExpAp = "TaxOnExpAp";
            public static readonly string TaxOnExpFc = "TaxOnExpFc";
            public static readonly string TaxOnExpSc = "TaxOnExpSc";
            public static readonly string TotalBlckF = "TotalBlckF";
            public static readonly string TotalBlckS = "TotalBlckS";
            public static readonly string TotalExpFC = "TotalExpFC";
            public static readonly string TotalExpns = "TotalExpns";
            public static readonly string TotalExpSC = "TotalExpSC";
            public static readonly string VATBlck = "VATBlck";
            public static readonly string VATBlckFC = "VATBlckFC";
            public static readonly string VATBlckSC = "VATBlckSC";
            public static readonly string VatPaid = "VatPaid";
            public static readonly string VatPaidFC = "VatPaidFC";
            public static readonly string VatPaidSys = "VatPaidSys";
            public static readonly string VatSum = "VatSum";
            public static readonly string VatSumFC = "VatSumFC";
            public static readonly string VatSumSy = "VatSumSy";
            public static readonly string WTApplied = "WTApplied";
            public static readonly string WTAppliedF = "WTAppliedF";
            public static readonly string WTAppliedS = "WTAppliedS";
            public static readonly string WTBlocked = "WTBlocked";
            public static readonly string WTBlockedF = "WTBlockedF";
            public static readonly string WTBlockedS = "WTBlockedS";
            public static readonly string WTSumFC = "WTSumFC";
            public static readonly string WTSumSC = "WTSumSC";


        }

        public struct Description
        {
            public static readonly string DocEntry = "Nº do Docuemnto";
            public static readonly string InstlmntID = "Nº da Parcela";
            public static readonly string ObjType = "Tipo do Objeto";
            public static readonly string DueDate = "Data de Vencimento";
            public static readonly string InstPrcnt = "% do Documento";
            public static readonly string InsTotal = "Total da Parcela";
            public static readonly string WTSum = "Imposto Retido na Fonte";
            public static readonly string Status = "Status";
            public static readonly string PaidToDate = "Pago até a Data";
            public static readonly string TotalBlck = "Total Reservado";
            public static readonly string Paid = "Valor Pago";

            public static readonly string DunDate = "Última Data de Cobrança";
            public static readonly string DunnLevel = "Nível de Advertência";
            public static readonly string DunWizBlck = "Assistente do Bloco de Cobrança";
            public static readonly string ExpAppl = "Fretes Aplicados";
            public static readonly string ExpApplFC = "Fretes Aplicados (FC)";
            public static readonly string ExpApplSC = "Fretes Aplicados (SC)";
            public static readonly string ExpnsBlck = "Despesas de Frete Reservados";
            public static readonly string ExpnsBlckF = "Despesas de Frete Reservads (FC)";
            public static readonly string ExpnsBlckS = "Despesas de Frete Reservados (SC)";
            public static readonly string InsTotalFC = "Total de Parcela (FC)";
            public static readonly string InsTotalSy = "Total de Parcela (SC)";
            public static readonly string LogInstanc = "Log da Instância";
            public static readonly string LvlUpdDate = "Nível de Atualização da Data de Advertência";
            public static readonly string Ordered = "Pagamento Ordenado";
            public static readonly string PaidDpm = "Pago por Adiantamento";
            public static readonly string PaidDpmFc = "Pago por Adiantamento (FC)";
            public static readonly string PaidDpmSc = "Pago por Adiantamento (SC)";
            public static readonly string PaidFC = "Pago (FC)";
            public static readonly string PaidFrgn = "Pago (FC)";
            public static readonly string PaidSc = "Pago (SC)";
            public static readonly string PaidSys = "Pago (SC)";
            public static readonly string reserved = "Reservado";
            public static readonly string TaxOnExApF = "Imposto Aplicado em Despesas (FC)";
            public static readonly string TaxOnExApS = "Imposto Aplicado em Despesas (SC)";
            public static readonly string TaxOnExBlF = "Imposto Reservado ao Frete (FC)";
            public static readonly string TaxOnExBlo = "Imposto Reservado ao Valor do Frete";
            public static readonly string TaxOnExBlS = "Imposto Reservado ao Frete (SC)";
            public static readonly string TaxOnExp = "Imposto sobre Frete";
            public static readonly string TaxOnExpAp = "Imposto Aplicado em Despesas";
            public static readonly string TaxOnExpFc = "Imposto Aplicado em Despesas (FC)";
            public static readonly string TaxOnExpSc = "Imposto Aplicado em Despesas (SC)";
            public static readonly string TotalBlckF = "Valor Total Reservado";
            public static readonly string TotalBlckS = "Valor Total Reservado (SC)";
            public static readonly string TotalExpFC = "Total de Custos de Frete (FC)";
            public static readonly string TotalExpns = "Total de Custos de Frete";
            public static readonly string TotalExpSC = "Total de Custos de Frete (SC)";
            public static readonly string VATBlck = "Valor dos Impostos Reservados";
            public static readonly string VATBlckFC = "Valor dos Impostos Reservados (FC)";
            public static readonly string VATBlckSC = "Valor dos Impostos Reservados (SC)";
            public static readonly string VatPaid = "Imposto Pago até a Data";
            public static readonly string VatPaidFC = "Imposto Pago até a Data (FC)";
            public static readonly string VatPaidSys = "Imposto Pago até a Data (SC)";
            public static readonly string VatSum = "Total de Impostos";
            public static readonly string VatSumFC = "Total de Impostos (FC)";
            public static readonly string VatSumSy = "Total de Impostos (SC)";
            public static readonly string WTApplied = "Valor Imposto não Aplicado";
            public static readonly string WTAppliedF = "Valor Imposto não Aplicado (FC)";
            public static readonly string WTAppliedS = "Valor Imposto não Aplicado (SC)";
            public static readonly string WTBlocked = "Valor Imposto não reservado";
            public static readonly string WTBlockedF = "Valor Imposto não reservado (FC)";
            public static readonly string WTBlockedS = "Valor Imposto não reservado (SC)";
            public static readonly string WTSumFC = "Valor Imposto Isento";
            public static readonly string WTSumSC = "Valor Imposto Isento (SC)";

        }

        TableAdapterField m_DocEntry = new TableAdapterField(FieldsName.DocEntry, Description.DocEntry, DbType.Int32, 11, 0, true, false);
        TableAdapterField m_InstlmntID = new TableAdapterField(FieldsName.InstlmntID, Description.InstlmntID, DbType.Int32, 11, 0, true, false);
        TableAdapterField m_ObjType = new TableAdapterField(FieldsName.ObjType, Description.ObjType, DbType.Int32);
        TableAdapterField m_DueDate = new TableAdapterField(FieldsName.DueDate, Description.DueDate, DbType.DateTime);
        TableAdapterField m_InstPrcnt = new TableAdapterField(FieldsName.InstPrcnt, Description.InstPrcnt, DbType.Decimal);
        TableAdapterField m_InsTotal = new TableAdapterField(FieldsName.InsTotal, Description.InsTotal, DbType.Decimal);
        TableAdapterField m_WTSum = new TableAdapterField(FieldsName.WTSum, Description.WTSum, DbType.Decimal);
        TableAdapterField m_Status = new TableAdapterField(FieldsName.Status, Description.Status, 1);
        TableAdapterField m_PaidToDate = new TableAdapterField(FieldsName.PaidToDate, Description.PaidToDate, DbType.Decimal);
        TableAdapterField m_TotalBlck = new TableAdapterField(FieldsName.TotalBlck, Description.TotalBlck, DbType.Decimal);
        TableAdapterField m_Paid = new TableAdapterField(FieldsName.Paid, Description.Paid, DbType.Decimal);


        TableAdapterField m_DunDate = new TableAdapterField(FieldsName.DunDate, Description.DunDate, DbType.DateTime);
        TableAdapterField m_DunnLevel = new TableAdapterField(FieldsName.DunnLevel, Description.DunnLevel, DbType.Int32);
        TableAdapterField m_DunWizBlck = new TableAdapterField(FieldsName.DunWizBlck, Description.DunWizBlck, 1);
        TableAdapterField m_ExpAppl = new TableAdapterField(FieldsName.ExpAppl, Description.ExpAppl, DbType.Decimal);
        TableAdapterField m_ExpApplFC = new TableAdapterField(FieldsName.ExpApplFC, Description.ExpApplFC, DbType.Decimal);
        TableAdapterField m_ExpApplSC = new TableAdapterField(FieldsName.ExpApplSC, Description.ExpApplSC, DbType.Decimal);
        TableAdapterField m_ExpnsBlck = new TableAdapterField(FieldsName.ExpnsBlck, Description.ExpnsBlck, DbType.Decimal);
        TableAdapterField m_ExpnsBlckF = new TableAdapterField(FieldsName.ExpnsBlckF, Description.ExpnsBlckF, DbType.Decimal);
        TableAdapterField m_ExpnsBlckS = new TableAdapterField(FieldsName.ExpnsBlckS, Description.ExpnsBlckS, DbType.Decimal);
        TableAdapterField m_InsTotalFC = new TableAdapterField(FieldsName.InsTotalFC, Description.InsTotalFC, DbType.Decimal);
        TableAdapterField m_InsTotalSy = new TableAdapterField(FieldsName.InsTotalSy, Description.InsTotalSy, DbType.Decimal);
        TableAdapterField m_LogInstanc = new TableAdapterField(FieldsName.LogInstanc, Description.LogInstanc, 11);
        TableAdapterField m_LvlUpdDate = new TableAdapterField(FieldsName.LvlUpdDate, Description.LvlUpdDate, DbType.DateTime);
        TableAdapterField m_Ordered = new TableAdapterField(FieldsName.Ordered, Description.Ordered, 1);
        TableAdapterField m_PaidDpm = new TableAdapterField(FieldsName.PaidDpm, Description.PaidDpm, DbType.Decimal);
        TableAdapterField m_PaidDpmFc = new TableAdapterField(FieldsName.PaidDpmFc, Description.PaidDpmFc, DbType.Decimal);
        TableAdapterField m_PaidDpmSc = new TableAdapterField(FieldsName.PaidDpmSc, Description.PaidDpmSc, DbType.Decimal);
        TableAdapterField m_PaidFC = new TableAdapterField(FieldsName.PaidFC, Description.PaidFC, DbType.Decimal);
        TableAdapterField m_PaidFrgn = new TableAdapterField(FieldsName.PaidFrgn, Description.PaidFrgn, DbType.Decimal);
        TableAdapterField m_PaidSc = new TableAdapterField(FieldsName.PaidSc, Description.PaidSc, DbType.Decimal);
        TableAdapterField m_PaidSys = new TableAdapterField(FieldsName.PaidSys, Description.PaidSys, DbType.Decimal);
        TableAdapterField m_reserved = new TableAdapterField(FieldsName.reserved, Description.reserved, 1);
        TableAdapterField m_TaxOnExApF = new TableAdapterField(FieldsName.TaxOnExApF, Description.TaxOnExApF, DbType.Decimal);
        TableAdapterField m_TaxOnExApS = new TableAdapterField(FieldsName.TaxOnExApS, Description.TaxOnExApS, DbType.Decimal);
        TableAdapterField m_TaxOnExBlF = new TableAdapterField(FieldsName.TaxOnExBlF, Description.TaxOnExBlF, DbType.Decimal);
        TableAdapterField m_TaxOnExBlo = new TableAdapterField(FieldsName.TaxOnExBlo, Description.TaxOnExBlo, DbType.Decimal);
        TableAdapterField m_TaxOnExBlS = new TableAdapterField(FieldsName.TaxOnExBlS, Description.TaxOnExBlS, DbType.Decimal);
        TableAdapterField m_TaxOnExp = new TableAdapterField(FieldsName.TaxOnExp, Description.TaxOnExp, DbType.Decimal);
        TableAdapterField m_TaxOnExpAp = new TableAdapterField(FieldsName.TaxOnExpAp, Description.TaxOnExpAp, DbType.Decimal);
        TableAdapterField m_TaxOnExpFc = new TableAdapterField(FieldsName.TaxOnExpFc, Description.TaxOnExpFc, DbType.Decimal);
        TableAdapterField m_TaxOnExpSc = new TableAdapterField(FieldsName.TaxOnExpSc, Description.TaxOnExpSc, DbType.Decimal);
        TableAdapterField m_TotalBlckF = new TableAdapterField(FieldsName.TotalBlckF, Description.TotalBlckF, DbType.Decimal);
        TableAdapterField m_TotalBlckS = new TableAdapterField(FieldsName.TotalBlckS, Description.TotalBlckS, DbType.Decimal);
        TableAdapterField m_TotalExpFC = new TableAdapterField(FieldsName.TotalExpFC, Description.TotalExpFC, DbType.Decimal);
        TableAdapterField m_TotalExpns = new TableAdapterField(FieldsName.TotalExpns, Description.TotalExpns, DbType.Decimal);
        TableAdapterField m_TotalExpSC = new TableAdapterField(FieldsName.TotalExpSC, Description.TotalExpSC, DbType.Decimal);
        TableAdapterField m_VATBlck = new TableAdapterField(FieldsName.VATBlck, Description.VATBlck, DbType.Decimal);
        TableAdapterField m_VATBlckFC = new TableAdapterField(FieldsName.VATBlckFC, Description.VATBlckFC, DbType.Decimal);
        TableAdapterField m_VATBlckSC = new TableAdapterField(FieldsName.VATBlckSC, Description.VATBlckSC, DbType.Decimal);
        TableAdapterField m_VatPaid = new TableAdapterField(FieldsName.VatPaid, Description.VatPaid, DbType.Decimal);
        TableAdapterField m_VatPaidFC = new TableAdapterField(FieldsName.VatPaidFC, Description.VatPaidFC, DbType.Decimal);
        TableAdapterField m_VatPaidSys = new TableAdapterField(FieldsName.VatPaidSys, Description.VatPaidSys, DbType.Decimal);
        TableAdapterField m_VatSum = new TableAdapterField(FieldsName.VatSum, Description.VatSum, DbType.Decimal);
        TableAdapterField m_VatSumFC = new TableAdapterField(FieldsName.VatSumFC, Description.VatSumFC, DbType.Decimal);
        TableAdapterField m_VatSumSy = new TableAdapterField(FieldsName.VatSumSy, Description.VatSumSy, DbType.Decimal);
        TableAdapterField m_WTApplied = new TableAdapterField(FieldsName.WTApplied, Description.WTApplied, DbType.Decimal);
        TableAdapterField m_WTAppliedF = new TableAdapterField(FieldsName.WTAppliedF, Description.WTAppliedF, DbType.Decimal);
        TableAdapterField m_WTAppliedS = new TableAdapterField(FieldsName.WTAppliedS, Description.WTAppliedS, DbType.Decimal);
        TableAdapterField m_WTBlocked = new TableAdapterField(FieldsName.WTBlocked, Description.WTBlocked, DbType.Decimal);
        TableAdapterField m_WTBlockedF = new TableAdapterField(FieldsName.WTBlockedF, Description.WTBlockedF, DbType.Decimal);
        TableAdapterField m_WTBlockedS = new TableAdapterField(FieldsName.WTBlockedS, Description.WTBlockedS, DbType.Decimal);
        TableAdapterField m_WTSumFC = new TableAdapterField(FieldsName.WTSumFC, Description.WTSumFC, DbType.Decimal);
        TableAdapterField m_WTSumSC = new TableAdapterField(FieldsName.WTSumSC, Description.WTSumSC, DbType.Decimal);



        public Installment()
            : base()
        {
        }

        public Installment(string pCompanyDb, eDocumentObjectType pDocumentObjectType)
            : base(pCompanyDb, pDocumentObjectType.GetTableNameSufix() + "6")
        {
        }

        public int DocEntry
        {
            get { return m_DocEntry.GetInt32(); }
            set { m_DocEntry.Value = value; }
        }

        public int InstlmntID
        {
            get { return m_InstlmntID.GetInt32(); }
            set { m_InstlmntID.Value = value; }
        }

        public eDocumentObjectType ObjType
        {
            get { return m_ObjType.GetInt32().ToDocumentObjectTypeEnum(); }
            set { m_ObjType.Value = value.ToInt32(); }
        }

        public DateTime DueDate
        {
            get { return m_DueDate.GetDateTime(); }
            set { m_DueDate.Value = value; }
        }

        public decimal InstPrcnt
        {
            get { return m_InstPrcnt.GetDecimal(); }
            set { m_InstPrcnt.Value = value; }
        }

        public decimal InsTotal
        {
            get { return m_InsTotal.GetDecimal(); }
            set { m_InsTotal.Value = value; }
        }

        public decimal WTSum
        {
            get { return m_WTSum.GetDecimal(); }
            set { m_WTSum.Value = value; }
        }

        public eInstallmentStatus Status
        {
            get { return m_Status.GetString().ToEnum(); }
            set { m_Status.Value = value.ToEnumString(); }
        }

        public decimal PaidToDate
        {
            get { return m_PaidToDate.GetDecimal(); }
            set { m_PaidToDate.Value = value; }
        }

        public decimal TotalBlck
        {
            get { return m_TotalBlck.GetDecimal(); }
            set { m_TotalBlck.Value = value; }
        }

        public decimal Paid
        {
            get { return m_Paid.GetDecimal(); }
            set { m_Paid.Value = value; }
        }

        public DateTime DunDate
        {
            get { return m_DunDate.GetDateTime(); }
            set { m_DunDate.Value = value; }
        }

        public Int32 DunnLevel
        {
            get { return m_DunnLevel.GetInt32(); }
            set { m_DunnLevel.Value = value; }
        }

        public String DunWizBlck
        {
            get { return m_DunWizBlck.GetString(); }
            set { m_DunWizBlck.Value = value; }
        }

        public Decimal ExpAppl
        {
            get { return m_ExpAppl.GetDecimal(); }
            set { m_ExpAppl.Value = value; }
        }

        public Decimal ExpApplFC
        {
            get { return m_ExpApplFC.GetDecimal(); }
            set { m_ExpApplFC.Value = value; }
        }

        public Decimal ExpApplSC
        {
            get { return m_ExpApplSC.GetDecimal(); }
            set { m_ExpApplSC.Value = value; }
        }

        public Decimal ExpnsBlck
        {
            get { return m_ExpnsBlck.GetDecimal(); }
            set { m_ExpnsBlck.Value = value; }
        }

        public Decimal ExpnsBlckF
        {
            get { return m_ExpnsBlckF.GetDecimal(); }
            set { m_ExpnsBlckF.Value = value; }
        }

        public Decimal ExpnsBlckS
        {
            get { return m_ExpnsBlckS.GetDecimal(); }
            set { m_ExpnsBlckS.Value = value; }
        }

        public Decimal InsTotalFC
        {
            get { return m_InsTotalFC.GetDecimal(); }
            set { m_InsTotalFC.Value = value; }
        }

        public Decimal InsTotalSy
        {
            get { return m_InsTotalSy.GetDecimal(); }
            set { m_InsTotalSy.Value = value; }
        }

        public String LogInstanc
        {
            get { return m_LogInstanc.GetString(); }
            set { m_LogInstanc.Value = value; }
        }

        public DateTime LvlUpdDate
        {
            get { return m_LvlUpdDate.GetDateTime(); }
            set { m_LvlUpdDate.Value = value; }
        }

        public String Ordered
        {
            get { return m_Ordered.GetString(); }
            set { m_Ordered.Value = value; }
        }

        public Decimal PaidDpm
        {
            get { return m_PaidDpm.GetDecimal(); }
            set { m_PaidDpm.Value = value; }
        }

        public Decimal PaidDpmFc
        {
            get { return m_PaidDpmFc.GetDecimal(); }
            set { m_PaidDpmFc.Value = value; }
        }

        public Decimal PaidDpmSc
        {
            get { return m_PaidDpmSc.GetDecimal(); }
            set { m_PaidDpmSc.Value = value; }
        }

        public Decimal PaidFC
        {
            get { return m_PaidFC.GetDecimal(); }
            set { m_PaidFC.Value = value; }
        }

        public Decimal PaidFrgn
        {
            get { return m_PaidFrgn.GetDecimal(); }
            set { m_PaidFrgn.Value = value; }
        }

        public Decimal PaidSc
        {
            get { return m_PaidSc.GetDecimal(); }
            set { m_PaidSc.Value = value; }
        }

        public Decimal PaidSys
        {
            get { return m_PaidSys.GetDecimal(); }
            set { m_PaidSys.Value = value; }
        }

        public String reserved
        {
            get { return m_reserved.GetString(); }
            set { m_reserved.Value = value; }
        }

        public Decimal TaxOnExApF
        {
            get { return m_TaxOnExApF.GetDecimal(); }
            set { m_TaxOnExApF.Value = value; }
        }

        public Decimal TaxOnExApS
        {
            get { return m_TaxOnExApS.GetDecimal(); }
            set { m_TaxOnExApS.Value = value; }
        }

        public Decimal TaxOnExBlF
        {
            get { return m_TaxOnExBlF.GetDecimal(); }
            set { m_TaxOnExBlF.Value = value; }
        }

        public Decimal TaxOnExBlo
        {
            get { return m_TaxOnExBlo.GetDecimal(); }
            set { m_TaxOnExBlo.Value = value; }
        }

        public Decimal TaxOnExBlS
        {
            get { return m_TaxOnExBlS.GetDecimal(); }
            set { m_TaxOnExBlS.Value = value; }
        }


        public Decimal TaxOnExp
        {
            get { return m_TaxOnExp.GetDecimal(); }
            set { m_TaxOnExp.Value = value; }
        }

        public Decimal TaxOnExpAp
        {
            get { return m_TaxOnExpAp.GetDecimal(); }
            set { m_TaxOnExpAp.Value = value; }
        }

        public Decimal TaxOnExpFc
        {
            get { return m_TaxOnExpFc.GetDecimal(); }
            set { m_TaxOnExpFc.Value = value; }
        }

        public Decimal TaxOnExpSc
        {
            get { return m_TaxOnExpSc.GetDecimal(); }
            set { m_TaxOnExpSc.Value = value; }
        }

        public Decimal TotalBlckF
        {
            get { return m_TotalBlckF.GetDecimal(); }
            set { m_TotalBlckF.Value = value; }
        }

        public Decimal TotalBlckS
        {
            get { return m_TotalBlckS.GetDecimal(); }
            set { m_TotalBlckS.Value = value; }
        }

        public Decimal TotalExpFC
        {
            get { return m_TotalExpFC.GetDecimal(); }
            set { m_TotalExpFC.Value = value; }
        }

        public Decimal TotalExpns
        {
            get { return m_TotalExpns.GetDecimal(); }
            set { m_TotalExpns.Value = value; }
        }

        public Decimal TotalExpSC
        {
            get { return m_TotalExpSC.GetDecimal(); }
            set { m_TotalExpSC.Value = value; }
        }

        public Decimal VATBlck
        {
            get { return m_VATBlck.GetDecimal(); }
            set { m_VATBlck.Value = value; }
        }

        public Decimal VATBlckFC
        {
            get { return m_VATBlckFC.GetDecimal(); }
            set { m_VATBlckFC.Value = value; }
        }

        public Decimal VATBlckSC
        {
            get { return m_VATBlckSC.GetDecimal(); }
            set { m_VATBlckSC.Value = value; }
        }

        public Decimal VatPaid
        {
            get { return m_VatPaid.GetDecimal(); }
            set { m_VatPaid.Value = value; }
        }

        public Decimal VatPaidFC
        {
            get { return m_VatPaidFC.GetDecimal(); }
            set { m_VatPaidFC.Value = value; }
        }

        public Decimal VatPaidSys
        {
            get { return m_VatPaidSys.GetDecimal(); }
            set { m_VatPaidSys.Value = value; }
        }

        public Decimal VatSum
        {
            get { return m_VatSum.GetDecimal(); }
            set { m_VatSum.Value = value; }
        }

        public Decimal VatSumFC
        {
            get { return m_VatSumFC.GetDecimal(); }
            set { m_VatSumFC.Value = value; }
        }

        public Decimal VatSumSy
        {
            get { return m_VatSumSy.GetDecimal(); }
            set { m_VatSumSy.Value = value; }
        }

        public Decimal WTApplied
        {
            get { return m_WTApplied.GetDecimal(); }
            set { m_WTApplied.Value = value; }
        }

        public Decimal WTAppliedF
        {
            get { return m_WTAppliedF.GetDecimal(); }
            set { m_WTAppliedF.Value = value; }
        }

        public Decimal WTAppliedS
        {
            get { return m_WTAppliedS.GetDecimal(); }
            set { m_WTAppliedS.Value = value; }
        }

        public Decimal WTBlocked
        {
            get { return m_WTBlocked.GetDecimal(); }
            set { m_WTBlocked.Value = value; }
        }

        public Decimal WTBlockedF
        {
            get { return m_WTBlockedF.GetDecimal(); }
            set { m_WTBlockedF.Value = value; }
        }

        public Decimal WTBlockedS
        {
            get { return m_WTBlockedS.GetDecimal(); }
            set { m_WTBlockedS.Value = value; }
        }

        public Decimal WTSumFC
        {
            get { return m_WTSumFC.GetDecimal(); }
            set { m_WTSumFC.Value = value; }
        }

        public Decimal WTSumSC
        {
            get { return m_WTSumSC.GetDecimal(); }
            set { m_WTSumSC.Value = value; }
        }

        public bool GetByKey(int pDocEntry, int pInstlmntID)
        {
            this.DocEntry = pDocEntry;
            this.InstlmntID = pInstlmntID;
            return base.GetByKey();
        }

        public List<Installment> GetInstallments(int pDocEntry)
        {

            TableQuery myQuery = new TableQuery(this);

            myQuery.Where.Add(new QueryParam(m_DocEntry, pDocEntry));

            myQuery.OrderBy.Add(new OrderBy(new QueryParam(m_DocEntry), eOrder.eoASC));
            myQuery.OrderBy.Add(new OrderBy(new QueryParam(m_InstlmntID), eOrder.eoASC));

            return FillCollection<Installment>(myQuery);
        }


    }

}
