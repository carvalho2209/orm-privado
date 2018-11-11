using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Nampula.Framework;

namespace Nampula.DI.B1.Documents
{
    /// <summary>
    /// Despesa adicional da linha
    /// </summary>
    public class LineFreightRow : TableAdapter
    {
        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string DocEntry = "DocEntry";
            public static readonly string LineNum = "LineNum";
            public static readonly string GroupNum = "GroupNum";
            public static readonly string ExpnsCode = "ExpnsCode";
            public static readonly string LineTotal = "LineTotal";
            public static readonly string ObjType = "ObjType";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string DocEntry = "N° do Documento";
            public static readonly string LineNum = "N° da Linha";
            public static readonly string GroupNum = "Grupo";
            public static readonly string ExpnsCode = "Despesa Adicional";
            public static readonly string LineTotal = "Total";
            public static readonly string ObjType = "Tipo de Documento";
        }
        

        

        TableAdapterField m_DocEntry = new TableAdapterField(FieldsName.DocEntry, FieldsDescription.DocEntry, DbType.Int32, 11, 0, true, false);
        TableAdapterField m_LineNum = new TableAdapterField(FieldsName.LineNum, FieldsDescription.LineNum, DbType.Int32, 11, 0, true, false);
        TableAdapterField m_GroupNum = new TableAdapterField(FieldsName.GroupNum, FieldsDescription.GroupNum, DbType.Int32, 11, 0, true, false);
        TableAdapterField m_ExpnsCode = new TableAdapterField(FieldsName.ExpnsCode, FieldsDescription.ExpnsCode, DbType.Int32);
        TableAdapterField m_LineTotal = new TableAdapterField(FieldsName.LineTotal, FieldsDescription.LineTotal, DbType.Decimal);
        TableAdapterField m_ObjType = new TableAdapterField(FieldsName.ObjType, FieldsDescription.ObjType, DbType.Int32);

        

        

        

        public LineFreightRow()
            : base()
        {
        }

        public LineFreightRow(string pCompanyDb, eDocumentObjectType pDocumentObjectType)
            : base(pCompanyDb, pDocumentObjectType.GetTableNameSufix() + "2")
        {
            this.ObjType = pDocumentObjectType;
        }

        public LineFreightRow(LineFreightRow pLineFreightRow)
            : this()
        {
            this.CopyBy(pLineFreightRow);
        }

        

        

        public int DocEntry
        {
            get { return m_DocEntry.GetInt32(); }
            set { m_DocEntry.Value = value; }
        }

        public int LineNum
        {
            get { return m_LineNum.GetInt32(); }
            set { m_LineNum.Value = value; }
        }

        public int GroupNum
        {
            get { return m_GroupNum.GetInt32(); }
            set { m_GroupNum.Value = value; }
        }

        public int ExpnsCode
        {
            get { return m_ExpnsCode.GetInt32(); }
            set { m_ExpnsCode.Value = value; }
        }

        public decimal LineTotal
        {
            get { return m_LineTotal.GetInt32(); }
            set { m_LineTotal.Value = value; }
        }

        public eDocumentObjectType ObjType
        {
            get { return (eDocumentObjectType)m_ObjType.GetInt32(); }
            set { m_ObjType.Value = value.To<int>(); }
        }

        

    }
}
