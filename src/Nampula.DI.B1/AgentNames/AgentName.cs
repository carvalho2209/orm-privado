using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI;

using System.Data;

namespace Nampula.DI.B1.AgentNames
{
    public class AgentName : TableAdapter
    {
        public struct FieldsName
        {
            public static readonly string AgentCode = "AgentCode";
            public static readonly string AgentName = "AgentName";
            public static readonly string Memo = "Memo";
            public static readonly string Locked = "Locked";
        }

        public struct Description
        {
            public static readonly string AgentCode = "Código";
            public static readonly string AgentName = "Nome";
            public static readonly string Memo = "Descrição";
            public static readonly string Locked = "Bloqueado";
        }

        TableAdapterField m_AgentCode = new TableAdapterField(FieldsName.AgentCode, Description.AgentCode, DbType.String, 32, 0, true, false);
        TableAdapterField m_AgentName = new TableAdapterField(FieldsName.AgentName, Description.AgentName, DbType.String, 50, 0, true, false);
        TableAdapterField m_Memo = new TableAdapterField(FieldsName.Memo, Description.Memo, 50);
        TableAdapterField m_Locked = new TableAdapterField(FieldsName.Locked, Description.Locked, 1);

        public AgentName()
            : base("OAGP")
        {

        }

        public AgentName(string pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        public AgentName(AgentName pAgentName)
            : this()
        {
            this.CopyBy(pAgentName);
        }

        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }

        public string AgentCode
        {
            get { return m_AgentCode.GetString(); }
            set { m_AgentCode.Value = value; }
        }
        public string AgentNome
        {
            get { return m_AgentName.GetString(); }
            set { m_AgentName.Value = value; }
        }
        public string Memo
        {
            get { return m_Memo.GetString(); }
            set { m_Memo.Value = value; }
        }
        public eYesNo Locked
        {
            get { return m_Locked.GetString().ToYesNoEnum(); }
            set { m_Locked.Value = value.ToYesNoString(); }
        }

        public List<AgentName> GetAll()
        {
            return FillCollection<AgentName>();
        }
    }
}