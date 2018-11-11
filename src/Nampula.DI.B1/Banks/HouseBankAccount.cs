using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.Banks
{

    public class HouseBankAccount : TableAdapter
    {
        public struct Definition
        {
            public static readonly string TableName = "DSC1";
        }

        public struct FieldsName
        {
            public static readonly string BankCode = "BankCode";
            public static readonly string Account = "Account";
            public static readonly string AccountChk = "AccountChk";
            public static readonly string GLAccount = "GLAccount";
            public static readonly string AcctName = "AcctName";
            public static readonly string Branch = "Branch";
            public static readonly string BranchChk = "BranchChk";
            public static readonly string Country = "Country";
        }

        public struct Description
        {
            public static readonly string BankCode = "Código do Banco";
            public static readonly string Account = "Nº da Conta";
            public static readonly string GLAccount = "Conta Contábil";
            public static readonly string AcctName = "Nome da Conta";
            public static readonly string AccountChk = "Conta bancária dig.";
            public static readonly string Branch = "Agência";
            public static readonly string BranchChk = "Agência Dig.";
            public static readonly string Country = "País";
        }

        TableAdapterField m_BankCode = new TableAdapterField(FieldsName.BankCode, Description.BankCode, DbType.String, 10, null, true, false);
        TableAdapterField m_Account = new TableAdapterField(FieldsName.Account, Description.Account, DbType.String, 50, null, true, false);
        TableAdapterField m_AccountChk = new DI.TableAdapterField(FieldsName.AccountChk, Description.AccountChk, 1);
        TableAdapterField m_GLAccount = new TableAdapterField(FieldsName.GLAccount, Description.GLAccount, 15);
        TableAdapterField m_AcctName = new TableAdapterField(FieldsName.AcctName, Description.AcctName, 15);
        TableAdapterField m_Branch = new TableAdapterField(FieldsName.Branch, Description.Branch, 15);
        TableAdapterField m_BranchChk = new DI.TableAdapterField(FieldsName.BranchChk, Description.BranchChk, 5);
        TableAdapterField m_Country = new TableAdapterField(FieldsName.Country, Description.Country, 3);

        public HouseBankAccount()
            : base(Definition.TableName)
        {
        }

        public HouseBankAccount(string pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        public string BankCode
        {
            get { return m_BankCode.GetString(); }
            set { m_BankCode.Value = value; }
        }

        public string Account
        {
            get { return m_Account.GetString(); }
            set { m_Account.Value = value; }
        }

        public string AccountChk
        {
            get { return m_AccountChk.GetString(); }
            set { m_AccountChk.Value = value; }
        }

        public string GLAccount
        {
            get { return m_GLAccount.GetString(); }
            set { m_GLAccount.Value = value; }
        }

        public string AcctName
        {
            get { return m_AcctName.GetString(); }
            set { m_AcctName.Value = value; }
        }

        public string Branch
        {
            get { return m_Branch.GetString(); }
            set { m_Branch.Value = value; }
        }

        public string BranchChk
        {
            get { return m_BranchChk.GetString(); }
            set { m_BranchChk.Value = value; }
        }

        public string Country
        {
            get { return m_Country.GetString(); }
            set { m_Country.Value = value; }
        }

        public bool GetByKey(string pBankCode, string pAccount)
        {

            this.BankCode = pBankCode;
            this.Account = pAccount;
            return base.GetByKey();
        }

        public List<HouseBankAccount> GetByBankCode(string pBankCode)
        {

            TableQuery myQuery = new TableQuery(this);

            myQuery.Where.Add(new QueryParam(m_BankCode, pBankCode));

            return FillCollection<HouseBankAccount>(myQuery);

        }
    }

}

