using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.Itens
{
    public class NCMCode : TableAdapter
    {
        

        
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "ONCM";
        }
        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string AbsEntry = "AbsEntry";
            public static readonly string NcmCode = "NcmCode";
            public static readonly string Descrip = "Descrip";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string AbsEntry = "AbsEntry";
            public static readonly string NcmCode = "NcmCode";
            public static readonly string Descrip = "Descrip";
        }
        

        

        TableAdapterField m_AbsEntry = new TableAdapterField(FieldsName.AbsEntry, FieldsDescription.AbsEntry, DbType.Int32, 11, 0, true, true);
        TableAdapterField m_NcmCode = new TableAdapterField(FieldsName.NcmCode, FieldsDescription.NcmCode, 10);
        TableAdapterField m_Descrip = new TableAdapterField(FieldsName.Descrip, FieldsDescription.Descrip, 200);

        

        

        

        public NCMCode()
            : base(Definition.TableName)
        {
        }

        public NCMCode(string pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        public NCMCode(NCMCode pNCMCode)
            : this()
        {
            this.CopyBy(pNCMCode);
        }

        

        

        public int AbsEntry
        {
            get { return m_AbsEntry.GetInt32(); }
            set { m_AbsEntry.Value = value; }
        }

        public string NcmCode
        {
            get { return m_NcmCode.GetString(); }
            set { m_NcmCode.Value = value; }
        }

        public string Descrip
        {
            get { return m_Descrip.GetString(); }
            set { m_Descrip.Value = value; }
        }

                
    }
}
