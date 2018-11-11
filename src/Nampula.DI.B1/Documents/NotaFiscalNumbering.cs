using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nampula.DI.B1.Documents
{
    public class NotaFiscalNumbering: TableAdapter
    {
        public struct Definition
        {
            public static readonly string TableName = "ONFN";
        }

        public struct FieldsName
        {
            public static readonly string ObjectCode = "ObjectCode";
            public static readonly string AutoKey = "AutoKey";
            public static readonly string DfltSeq = "DfltSeq";
            public static readonly string UpdCounter = "UpdCounter";
            public static readonly string UserSign = "UserSign";
            public static readonly string DocSubType = "DocSubType";
        }

        public struct FieldsDescription
        {
            public static readonly string ObjectCode = "Documento";
            public static readonly string AutoKey = "Chave auto";
            public static readonly string DfltSeq = "Dflt Seq";
            public static readonly string UpdCounter = "Contador atualização";
            public static readonly string UserSign = "User";
            public static readonly string DocSubType = "Sub tipo documento";
        }

        TableAdapterField m_ObjectCode = new TableAdapterField(FieldsName.ObjectCode, FieldsDescription.ObjectCode, System.Data.DbType.String, 20, "", true, false);
        TableAdapterField m_AutoKey = new TableAdapterField(FieldsName.AutoKey, FieldsDescription.AutoKey, DbType.Int32);
        TableAdapterField m_DfltSeq = new TableAdapterField(FieldsName.DfltSeq, FieldsDescription.DfltSeq, DbType.Int32);
        TableAdapterField m_UpdCounter = new TableAdapterField(FieldsName.UpdCounter, FieldsDescription.UpdCounter, DbType.Int32);
        TableAdapterField m_UserSign = new TableAdapterField(FieldsName.UserSign, FieldsDescription.UserSign, DbType.Int32);
        TableAdapterField m_DocSubType = new TableAdapterField(FieldsName.DocSubType, FieldsDescription.DocSubType, DbType.String, 2, "", true, false);

        public NotaFiscalNumbering()
            : base(Definition.TableName)
        {
 
        }

        public NotaFiscalNumbering(string companyDb)
            : base(companyDb, Definition.TableName)
        {

        }

        public String ObjectCode
        {
            get { return m_ObjectCode.GetString(); }
            set { m_ObjectCode.Value = value; }
        }

        public Int32 AutoKey
        {
            get { return m_AutoKey.GetInt32(); }
            set { m_AutoKey.Value = value; }
        }

        public Int32 DfltSeq
        {
            get { return m_DfltSeq.GetInt32(); }
            set { m_DfltSeq.Value = value; }
        }

        public Int32 UpdCounter
        {
            get { return m_UpdCounter.GetInt32(); }
            set { m_UpdCounter.Value = value; }
        }

        public Int32 UserSign
        {
            get { return m_UserSign.GetInt32(); }
            set { m_UserSign.Value = value; }
        }

        public String DocSubType
        {
            get { return m_DocSubType.GetString(); }
            set { m_DocSubType.Value = value; }
        }

        public bool GetByKey(string objectCode, string docSubType)
        {
            this.ObjectCode = objectCode;
            this.DocSubType = docSubType;
            return GetByKey();
        }
        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }
    }
}
