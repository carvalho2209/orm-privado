using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.DinamicInterfaces
{
    /// <summary>
    /// Dados da Tela do Usuário
    /// </summary>
    public class DinamicInterface : TableAdapter
    {
        

        
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "SDIS";
        }
        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string FormId = "FormId";
            public static readonly string ItemId = "ItemId";
            public static readonly string ColumnId = "ColumnId";
            public static readonly string Language = "Language";
            public static readonly string ItemString = "ItemString";
            public static readonly string IsBold = "IsBold";
            public static readonly string IsItalic = "IsItalic";
            public static readonly string UserSign = "UserSign";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string FormId = "Id do Formnulário";
            public static readonly string ItemId = "Id do Item";
            public static readonly string ColumnId = "Id da Coluna";
            public static readonly string Language = "Linguagem";
            public static readonly string ItemString = "Descrição";
            public static readonly string IsBold = "Negrito";
            public static readonly string IsItalic = "Italico";
            public static readonly string UserSign = "Usuário";
        }
        

        

        TableAdapterField m_FormId = new TableAdapterField(FieldsName.FormId, FieldsDescription.FormId, DbType.String, 20, 0, true, false);
        TableAdapterField m_ItemId = new TableAdapterField(FieldsName.ItemId, FieldsDescription.ItemId, DbType.String, 20, 0, true, false);
        TableAdapterField m_ColumnId = new TableAdapterField(FieldsName.ColumnId, FieldsDescription.ColumnId, DbType.String, 20, 0, true, false);
        TableAdapterField m_Language = new TableAdapterField(FieldsName.Language, FieldsDescription.Language, DbType.Int32);
        TableAdapterField m_ItemString = new TableAdapterField(FieldsName.ItemString, FieldsDescription.ItemString, 64);
        TableAdapterField m_IsBold = new TableAdapterField(FieldsName.IsBold, FieldsDescription.IsBold, 1);
        TableAdapterField m_IsItalic = new TableAdapterField(FieldsName.IsItalic, FieldsDescription.IsItalic, 1);
        TableAdapterField m_UserSign = new TableAdapterField(FieldsName.UserSign, FieldsDescription.UserSign, DbType.Int32);

        

        

        

        public DinamicInterface()
            : base(Definition.TableName)
        {
        }

        public DinamicInterface(DinamicInterface pDinamicInterface)
            : this()
        {
            this.CopyBy(pDinamicInterface);
        }

        public DinamicInterface(string pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        

        

        public string FormId
        {
            get { return m_FormId.GetString(); }
            set { m_FormId.Value = value; }
        }

        public string ItemId
        {
            get { return m_ItemId.GetString(); }
            set { m_ItemId.Value = value; }
        }

        public string ColumnId
        {
            get { return m_ColumnId.GetString(); }
            set { m_ColumnId.Value = value; }
        }

        public int Language
        {
            get { return m_Language.GetInt32(); }
            set { m_Language.Value = value; }
        }

        public string ItemString
        {
            get { return m_ItemString.GetString(); }
            set { m_ItemString.Value = value; }
        }

        public eYesNo IsBold
        {
            get { return m_IsBold.GetString().ToYesNoEnum(); }
            set { m_IsBold.Value = value.ToYesNoString(); }
        }

        public eYesNo IsItalic
        {
            get { return m_IsItalic.GetString().ToYesNoEnum(); }
            set { m_IsItalic.Value = value.ToYesNoString(); }
        }

        public int UserSign
        {
            get { return m_UserSign.GetInt32(); }
            set { m_UserSign.Value = value; }
        }


        public bool GetByKey(string pFormId, string pItemId, string pColumnId)
        {
            this.FormId = pFormId;
            this.ItemId = pItemId;
            this.ColumnId = pColumnId;
            return base.GetByKey();
        }

        

    }
}
