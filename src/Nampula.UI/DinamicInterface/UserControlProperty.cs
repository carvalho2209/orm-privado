using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI;
using System.Data;

namespace Nampula.UI.DinamicInterface
{
    /// <summary>
    /// Tabela para armazenamento das configurações do software
    /// </summary>
    internal class UserControlProperty : TableAdapter
    {
        

        
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "UserControlProperty";
        }
        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string Id = "Id";
            public static readonly string Form = "Form";
            public static readonly string Control = "Control";
            public static readonly string Column = "Column";
            public static readonly string ColOrder = "ColOrder";
            public static readonly string Caption = "Caption";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string Id = "Código";
            public static readonly string Form = "Formulário";
            public static readonly string Control = "Controle";
            public static readonly string Column = "Coluna";
            public static readonly string ColOrder = "Orderm da Coluna";
            public static readonly string Caption = "Caption";
        }
        

        

        TableAdapterField m_Id = new TableAdapterField(FieldsName.Id, FieldsDescription.Id, DbType.Int32, 11, 0, true, true);
        TableAdapterField m_Form = new TableAdapterField(FieldsName.Form, FieldsDescription.Form, 200 );
        TableAdapterField m_Control = new TableAdapterField(FieldsName.Control, FieldsDescription.Control, 200);
        TableAdapterField m_Column = new TableAdapterField(FieldsName.Column, FieldsDescription.Column, 200);
        TableAdapterField m_ColOrder = new TableAdapterField(FieldsName.ColOrder, FieldsDescription.ColOrder, DbType.Int32);
        TableAdapterField m_Caption = new TableAdapterField(FieldsName.Caption, FieldsDescription.Caption, 200);

        

        

        

        public UserControlProperty()
            : base(Definition.TableName)
        {
        }

        public UserControlProperty(UserControlProperty pUserControlProperty)
            : this()
        {
            this.CopyBy(pUserControlProperty);
        }

        

        

        public int Id
        {
            get { return m_Id.GetInt32(); }
            set { m_Id.Value = value; }
        }

        public string Form
        {
            get { return m_Form.GetString(); }
            set { m_Form.Value = value; }
        }

        public string Control
        {
            get { return m_Control.GetString(); }
            set { m_Control.Value = value; }
        }

        public string Column
        {
            get { return m_Column.GetString(); }
            set { m_Column.Value = value; }
        }

        public int ColOrder
        {
            get { return m_ColOrder.GetInt32(); }
            set { m_ColOrder.Value = value; }
        }

        public string Caption
        {
            get { return m_Caption.GetString(); }
            set { m_Caption.Value = value; }
        }
        
        
    }
}
