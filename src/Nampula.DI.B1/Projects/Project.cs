using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI;
using System.Data;

namespace Nampula.DI.B1.Projects
{

    /// <summary>
    /// Tabela para gerenciamento de projetos
    /// </summary>
    public class ProjectCode : TableAdapter
    {

        public struct Definition
        {
            public static readonly string TableName = "OPRJ";
        }

        /// <summary>
        /// Nome dos Campos
        /// </summary>
        public struct FieldsName
        {
            public static readonly string PrjCode = "PrjCode";
            public static readonly string PrjName = "PrjName";
            public static readonly string Locked = "Locked";
        }

        /// <summary>
        /// Descriçaõ dos campos
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string PrjCode = "Cód. Projeto";
            public static readonly string PrjName = "Nome projeto";
            public static readonly string Locked = "Bloqueado";
        }


        private TableAdapterField m_PrjCode = new TableAdapterField(FieldsName.PrjCode, FieldsDescription.PrjCode, DbType.String, 8, null, true, false);
        private TableAdapterField m_PrjName = new TableAdapterField(FieldsName.PrjName, FieldsDescription.PrjName, 50);
        private TableAdapterField m_Locked = new TableAdapterField(FieldsName.Locked, FieldsDescription.Locked, 1);

        public ProjectCode()
            : base(Definition.TableName)
        {
        }

        public ProjectCode(string pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        public ProjectCode(ProjectCode pProjectCode)
            : this()
        {
            this.CopyBy(pProjectCode);
        }
        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }

        //public override bool Create()
        //{
        //    return false;
        //}

        public string PrjCode
        {
            get { return m_PrjCode.GetString(); }
            private set { m_PrjCode.Value = value; }
        }

        public string PrjName
        {
            get { return m_PrjName.GetString(); }
            private set { m_PrjName.Value = value; }
        }

        public string Locked
        {
            get { return m_Locked.GetString(); }
            private set { m_PrjName.Value = value; }
        }

        public bool GetByKey(string PrjCode)
        {
            this.PrjCode = PrjCode;
            return this.GetByKey();
        }


        public List<ProjectCode> GetAll()
        {
            return FillCollection<ProjectCode>();
        }
    }
}
