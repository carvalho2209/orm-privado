using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.NotaFiscal
{
    /// <summary>
    /// Gerenciamento da Tabela Sequencia de Nota Fiscal "NFN1"
    /// </summary>
    public class NotaFiscalSequence : TableAdapter
    {
        
        /// <summary>
        /// Nome dos Campos
        /// </summary>
        public struct FieldsName
        {
            public static readonly string SeqCode = "SeqCode";
            public static readonly string SeqName = "SeqName";
            public static readonly string Model = "Model";
        }
        

        
        /// <summary>
        /// Descrição dos Campos
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string SeqCode = "Código";
            public static readonly string SeqName = "Nome";
            public static readonly string Model = "Modelo";
        }
        

        
        /// <summary>
        /// Definições da tabela
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "NFN1";
        }
        

        
        TableAdapterField m_SeqCode = new TableAdapterField( FieldsName.SeqCode, FieldsDescription.SeqCode, DbType.Int32, 11, null, true, false );
        TableAdapterField m_SeqName = new TableAdapterField( FieldsName.SeqName, FieldsDescription.SeqName, 100 );
        TableAdapterField m_Model = new TableAdapterField( FieldsName.Model, FieldsDescription.Model, 20 );
        

        
        public NotaFiscalSequence ( string pCompanyDb )
            : base( pCompanyDb, Definition.TableName )
        {
        }

        public NotaFiscalSequence ( )
            : base( Definition.TableName )
        {
        }
        

        public Int32 SeqCode
        {
            get { return m_SeqCode.GetInt32( ); }
            set { m_SeqCode.Value = value; }
        }

        public string SeqName
        {
            get { return m_SeqName.GetString( ); }
            set { m_SeqName.Value = value; }
        }

        public string Model
        {
            get { return m_Model.GetString( ); }
            set { m_Model.Value = value; }
        }

        public bool GetByKey ( int pSeqCode )
        {
            this.SeqCode = pSeqCode;
            return base.GetByKey( );
        }

        public List<NotaFiscalSequence> GetAll ( )
        {
            return FillCollection<NotaFiscalSequence>( );
        }

    }

}
