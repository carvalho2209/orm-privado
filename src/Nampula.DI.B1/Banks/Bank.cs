using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI;
using System.Data;


namespace Nampula.DI.B1.Banks
{
    /// <summary>
    /// Gerencia a tabela de bancos do SAP
    /// </summary>
    public class Bank : TableAdapter
    {
        
        /// <summary>
        /// Definições da Tabela
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "ODSC";
        } 
        

        
        /// <summary>
        /// Nome dos Campos
        /// </summary>
        public struct FieldsName
        {
            public static readonly string AbsEntry = "AbsEntry";
            public static readonly string BankCode = "BankCode";
            public static readonly string BankName = "BankName";
        } 
        

        
        /// <summary>
        /// Descrição dos Campos
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string AbsEntry = "Id";
            public static readonly string BankCode = "Código";
            public static readonly string BankName = "Nome";
        } 
        

        
        TableAdapterField m_AbsEntry = new TableAdapterField(FieldsName.AbsEntry, FieldsDescription.AbsEntry, DbType.Int32, 11, 0, true, true);
        TableAdapterField m_BankCode = new TableAdapterField(FieldsName.BankCode, FieldsDescription.BankCode, 30);
        TableAdapterField m_BankName = new TableAdapterField(FieldsName.BankName, FieldsDescription.BankName, 32); 
        

        
        public Bank()
            : base(Definition.TableName)
        {
        }

        public Bank(string pdbName)
            : this()
        {
            this.DBName = pdbName;
        } 
        

        
        public int AbsEntry
        {
            get { return m_AbsEntry.GetInt32(); }
            set { m_AbsEntry.Value = value; }
        }

        public string BankCode
        {
            get { return m_BankCode.GetString(); }
            set { m_BankCode.Value = value; }
        }

        public string BankName
        {
            get { return m_BankName.GetString(); }
            set { m_BankName.Value = value; }
        } 
        

        public List<Bank> GetByBankCode(string pBankCode)
        {
            TableQuery myTableQuery = new TableQuery(this);
            myTableQuery.Where.Add(new QueryParam(this.m_BankCode, pBankCode));

            return FillCollection<Bank>(myTableQuery);
        }

        public bool GetByBankCode(string pBankCode, bool First)
        {
            TableQuery myTableQuery = new TableQuery(this);

            myTableQuery.Where.Add(new QueryParam(this.m_BankCode, pBankCode));

            var data = this.GetData(myTableQuery);

            if (data.Rows.Count > 0)
                FillFields(data.Rows[0]);

            return data.Rows.Count > 0;
        }

        public List<Bank> GetByHouseBankAccounts()
        {

            var myQueryBank = new TableQuery(this, true, "T0");

            HouseBankAccount myHouse = new HouseBankAccount(this.DBName);
            TableQuery myQueryHouse = new TableQuery(myHouse, true, "T1");

            QueryParam myBankCodeHouse = new QueryParam(m_BankCode);
            myBankCodeHouse.AliasTableName = myQueryHouse.Alias;

            QueryParam myBankCode = new QueryParam(m_BankCode);
            myBankCode.AliasTableName = myQueryBank.Alias;

            myBankCodeHouse.Value1Column = myBankCode;

            myQueryBank.Joins.Add(new Join(myQueryHouse, new WhereCollection(myBankCodeHouse)));

            return FillCollection<Bank>(myQueryBank);
        }

        public bool GetByKey(int pAbsEntry)
        {
            this.AbsEntry = pAbsEntry;
            return GetByKey();
        }

        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }

        public List<Bank> GetAll()
        {
            return FillCollection<Bank>(new TableQuery(this));
        }
    }
}
