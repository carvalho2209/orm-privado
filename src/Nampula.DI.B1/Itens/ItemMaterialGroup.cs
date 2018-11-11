using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.Itens
{

    /// <summary>
    /// Tabela de Grupo de materiais do item
    /// </summary>
    public class ItemMaterialGroup : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OMGP";
        }

        public struct FieldsName
        {
            public static readonly string AbsEntry = "AbsEntry";
            public static readonly string MatGrp = "MatGrp";
            public static readonly string Descrip = "Descrip";
            public static readonly string LogInstanc = "LogInstanc";
            public static readonly string UserSign2 = "UserSign2";
            public static readonly string UpdateDate = "UpdateDate";
        }

        public struct FieldsDescription
        {
            public static readonly string AbsEntry = "Nº";
            public static readonly string MatGrp = "MatGrp";
            public static readonly string Descrip = "Descrição";
            public static readonly string LogInstanc = "Log";
            public static readonly string UserSign2 = "Usuário";
            public static readonly string UpdateDate = "Atualização";
        }

        TableAdapterField m_AbsEntry = new TableAdapterField(FieldsName.AbsEntry, FieldsDescription.AbsEntry, DbType.Int32, 11, 0, true, true);
        TableAdapterField m_MatGrp = new TableAdapterField(FieldsName.MatGrp, FieldsDescription.MatGrp, 3);
        TableAdapterField m_Descrip = new TableAdapterField(FieldsName.Descrip, FieldsDescription.Descrip, 70);
        TableAdapterField m_LogInstanc = new TableAdapterField(FieldsName.LogInstanc, FieldsDescription.LogInstanc, DbType.Int32);
        TableAdapterField m_UserSign2 = new TableAdapterField(FieldsName.UserSign2, FieldsDescription.UserSign2, DbType.Int32);
        TableAdapterField m_UpdateDate = new TableAdapterField(FieldsName.UpdateDate, FieldsDescription.UpdateDate, DbType.DateTime);

        public ItemMaterialGroup()
            : base(Definition.TableName)
        {
        }

        public ItemMaterialGroup(string pCompanyDb)
            : base(Definition.TableName)
        {
            this.DBName = pCompanyDb;
        }

        public ItemMaterialGroup(ItemMaterialGroup pItemMaterialGroup)
            : this()
        {
            this.CopyBy(pItemMaterialGroup);
        }

        public Int32 AbsEntry
        {
            get { return m_AbsEntry.GetInt32(); }
            set { m_AbsEntry.Value = value; }
        }

        public Int32 MatGrp
        {
            get { return m_MatGrp.GetInt32(); }
            set { m_MatGrp.Value = value; }
        }

        public String Descrip
        {
            get { return m_Descrip.GetString(); }
            set { m_Descrip.Value = value; }
        }

        public Int32 LogInstanc
        {
            get { return m_LogInstanc.GetInt32(); }
            set { m_LogInstanc.Value = value; }
        }

        public Int32 UserSign2
        {
            get { return m_UserSign2.GetInt32(); }
            set { m_UserSign2.Value = value; }
        }

        public DateTime UpdateDate
        {
            get { return m_UpdateDate.GetDateTime(); }
            set { m_UpdateDate.Value = value; }
        }

        /// <summary>
        /// Pega todos os registros do banco
        /// </summary>
        /// <returns>List de ItemMaterialGroup</returns>
        public List<ItemMaterialGroup> GetAll()
        {
            return FillCollection<ItemMaterialGroup>();
        } 
    }
}
