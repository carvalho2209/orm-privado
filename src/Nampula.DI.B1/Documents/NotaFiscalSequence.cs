using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nampula.DI.B1.Documents
{

    /// <summary>
    /// Tabela de NotaFiscalSequence
    /// </summary>
    public class NotaFiscalSequence : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "NFN1";
        }

        public struct FieldsName
        {
            public static readonly string ObjectCode = "ObjectCode";
            public static readonly string SeqCode = "SeqCode";
            public static readonly string SeqName = "SeqName";
            public static readonly string SeriesStr = "SeqName";
            public static readonly string BPLId = "BPLId";
            public static readonly string SubStr = "SubStr";
            public static readonly string InitialNum = "InitialNum";
            public static readonly string NextNum = "NextNum";
            public static readonly string LastNum = "LastNum";
            public static readonly string Model = "Model";
            public static readonly string Locked = "Locked";
            public static readonly string EnvTypeNFe = "EnvTypeNFe";
            public static readonly string IsDigital = "IsDigital";
            public static readonly string DocSubType = "DocSubType";
        }

        public struct FieldsDescription
        {
            public static readonly string ObjectCode = "Documento";
            public static readonly string SeqCode = "Cód sequência";
            public static readonly string SeqName = "Sequência";
            public static readonly string SeriesStr = "Série";
            public static readonly string BPLId = "Filial";
            public static readonly string SubStr = "Sub Série";
            public static readonly string InitialNum = "Primeiro";
            public static readonly string NextNum = "Seguinte";
            public static readonly string LastNum = "Último";
            public static readonly string Model = "Modelo";
            public static readonly string Locked = "Bloqueado";
            public static readonly string EnvTypeNFe = "NFe do tipo de ambiente";
            public static readonly string IsDigital = "Série digital";
            public static readonly string DocSubType = "Tipo sub doc";
        }

        TableAdapterField m_ObjectCode = new TableAdapterField(FieldsName.ObjectCode, FieldsDescription.ObjectCode, DbType.String, 20, "", true, false);
        TableAdapterField m_SeqCode = new TableAdapterField(FieldsName.SeqCode, FieldsDescription.SeqCode, DbType.Int32, 11, 0, true, false);
        TableAdapterField m_SeqName = new TableAdapterField(FieldsName.SeqName, FieldsDescription.SeqName, 8);
        TableAdapterField m_InitialNum = new TableAdapterField(FieldsName.InitialNum, FieldsDescription.InitialNum, DbType.Int32);
        TableAdapterField m_NextNum = new TableAdapterField(FieldsName.NextNum, FieldsDescription.NextNum, DbType.Int32);
        TableAdapterField m_LastNum = new TableAdapterField(FieldsName.LastNum, FieldsDescription.LastNum, DbType.Int32);
        TableAdapterField m_Model = new TableAdapterField(FieldsName.Model, FieldsDescription.Model, 6);
        TableAdapterField m_Locked = new TableAdapterField(FieldsName.Locked, FieldsDescription.Locked, 1);
        TableAdapterField m_EnvTypeNFe = new TableAdapterField(FieldsName.EnvTypeNFe, FieldsDescription.EnvTypeNFe, DbType.Int32);
        TableAdapterField m_IsDigital = new TableAdapterField(FieldsName.IsDigital, FieldsDescription.IsDigital, 1);
        TableAdapterField m_DocSubType = new TableAdapterField(FieldsName.DocSubType, FieldsDescription.DocSubType, 2);
       
        public NotaFiscalSequence()
            : base(Definition.TableName)
        {

        }

        public NotaFiscalSequence(string companyDb)
            : base(companyDb, Definition.TableName)
        {
 
        }
        public NotaFiscalSequence(NotaFiscalSequence pNotaFiscalSequence)
            : this()
        {
            this.CopyBy(pNotaFiscalSequence);
        }

        public String ObjectCode
        {
            get { return m_ObjectCode.GetString(); }
            set { m_ObjectCode.Value = value; }
        }


        public Int32 SeqCode
        {
            get { return m_SeqCode.GetInt32(); }
            set { m_SeqCode.Value = value; }
        }

        public String SeqName
        {
            get { return m_SeqName.GetString(); }
            set { m_SeqName.Value = value; }
        }

        public Int32 InitialNum
        {
            get { return m_InitialNum.GetInt32(); }
            set { m_InitialNum.Value = value; }
        }

        public Int32 NextNum
        {
            get { return m_NextNum.GetInt32(); }
            set { m_NextNum.Value = value; }
        }

        public Int32 LastNum
        {
            get { return m_LastNum.GetInt32(); }
            set { m_LastNum.Value = value; }
        }

        public String Model
        {
            get { return m_Model.GetString(); }
            set { m_Model.Value = value; }
        }

        public String Locked
        {
            get { return m_Locked.GetString(); }
            set { m_Locked.Value = value; }
        }

        public String EnvTypeNFe
        {
            get { return m_EnvTypeNFe.GetString(); }
            set { m_EnvTypeNFe.Value = value; }
        }

        public String IsDigital
        {
            get { return m_IsDigital.GetString(); }
            set { m_IsDigital.Value = value; }
        }

        public String DocSubType
        {
            get { return m_DocSubType.GetString(); }
            set { m_DocSubType.Value = value; }
        }

        public bool GetByKey(string objectCode, int seqCode, string docSubType)
        {
            this.ObjectCode = objectCode;
            this.SeqCode = seqCode;
            this.DocSubType = DocSubType;
            return GetByKey();
        }
    }
}
