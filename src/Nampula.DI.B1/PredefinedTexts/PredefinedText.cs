using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nampula.DI.B1.PredefinedTexts
{

    /// <summary>
    /// Tabela de Textos Predefinidos
    /// </summary>
    public class PredefinedText : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OPDT";
        }

        public struct FieldsName
        {
            public static readonly string AbsEntry = "AbsEntry";
            public static readonly string TextCode = "TextCode";
            public static readonly string Text = "Text";
        }

        public struct FieldsDescription
        {
            public static readonly string AbsEntry = "Nº";
            public static readonly string TextCode = "Código do Texto";
            public static readonly string Text = "Texto";
        }

        TableAdapterField m_AbsEntry = new TableAdapterField(FieldsName.AbsEntry, FieldsDescription.AbsEntry, DbType.Int32, 11, 0, true, true);
        TableAdapterField m_TextCode = new TableAdapterField(FieldsName.TextCode, FieldsDescription.TextCode, 20);
        TableAdapterField m_Text = new TableAdapterField(FieldsName.Text, FieldsDescription.Text, 4000);

        public PredefinedText()
            : base(Definition.TableName)
        {
        }

        public PredefinedText(string companyDb)
            : this()
        {
            this.DBName = companyDb;
        }

        public PredefinedText(PredefinedText pPredefinedText)
            : this()
        {
            this.CopyBy(pPredefinedText);
        }

        public int AbsEntry
        {
            get { return m_AbsEntry.GetInt32(); }
            set { m_AbsEntry.Value = value; }
        }

        public String TextCode
        {
            get { return m_TextCode.GetString(); }
            set { m_TextCode.Value = value; }
        }

        public String Text
        {
            get { return m_Text.GetString(); }
            set { m_Text.Value = value; }
        }


    }
}
