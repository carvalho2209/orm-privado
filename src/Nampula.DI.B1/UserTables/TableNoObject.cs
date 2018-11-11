using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.UserTables
{

    /// <summary>
    /// Gerenciamento de tabelas que não possuem um objeto a mesma
    /// </summary>
    public abstract class TableNoObject : TableAdapter
    {

        /// <summary>
        /// Campos das Tabelas
        /// </summary>
        public struct FieldsName
        {
            public static readonly string Code = "Code";
            public static readonly string Name = "Name";
        }

        /// <summary>
        /// Descrição dos campos da tabela padrão
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string Code = "Code";
            public static readonly string Name = "Name";
        }

        TableAdapterField m_Code = new TableAdapterField(FieldsName.Code, FieldsDescription.Code, DbType.String, 20, null, true, false);
        TableAdapterField m_Name = new TableAdapterField(FieldsName.Name, FieldsDescription.Name, 100);

        public TableNoObject(string pTableName) :
            base(string.Format("{0}{1}", Common.TableUserPrefix, pTableName))
        {
            SetFields();
        }

        private void SetFields()
        {

            List<string> columnName = new List<string>() { FieldsName.Code, FieldsName.Name };

            var myColumns = from column in this.Collumns
                            where !columnName.Exists(p => p == column.Name)
                            select column;

            foreach (var item in myColumns)
            {
                item.Name = Common.TableUserFieldPrefix + item.Name;
            }
        }

        public override void Create() {}

        public override void Add()
        {

            if (string.IsNullOrEmpty(this.Code))
            {
                this.Code = GetNextCode();
            }

            if (string.IsNullOrEmpty(this.Name))
            {
                this.Name = this.Code;
            }

            base.Add();
        }

        public string Code
        {
            get { return m_Code.GetString(); }
            set { m_Code.Value = value; }
        }

        public string Name
        {
            get { return m_Name.GetString(); }
            set { m_Name.Value = value; }
        }

        public bool GetByKey(string pCode)
        {
            this.Code = pCode;
            return base.GetByKey();
        }

        public string GetNextCode()
        {
            string sqlQuery = "Select coalesce(max(convert(int,{0})),0)+1 as code From {1} ";
            return Connection.SqlExecuteScalar<String>(
                string.Format(
                sqlQuery, FieldsName.Code, FullTableName()));
        }

    }
}
