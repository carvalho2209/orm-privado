using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.NotaFiscal {

    public class NotaFiscalNumbering : TableAdapter {

        public struct FieldsName {
            public static readonly string SeqCode ="SeqCode";
            public static readonly string ObjectCode ="ObjectCode";
        }

        public struct Description {
            public static readonly string SeqCode ="Código";
            public static readonly string ObjectCode ="Código do Objeto";
        }

        public struct Definition {
            public static readonly string TableName ="NFN3";
        }

        TableAdapterField m_SeqCode = new TableAdapterField (FieldsName.SeqCode, Description.SeqCode, DbType.Int32, 11, null, true, false );
        TableAdapterField m_ObjectCode = new TableAdapterField (FieldsName.ObjectCode, Description.ObjectCode, DbType.Int32, 11, null, true, false );

        public NotaFiscalNumbering ( string pCompanyDb )
            : base ( pCompanyDb, Definition.TableName ) {
        }

        public NotaFiscalNumbering ()
            : base ( Definition.TableName ) {
        }

        public Int32 SeqCode {
            get { return m_SeqCode.GetInt32 ( ); }
            set { m_SeqCode.Value = value; }
        }

        public Int32 ObjectCode {
            get { return m_ObjectCode.GetInt32 ( ); }
            set { m_ObjectCode.Value = value; }
        }

        public bool GetByKey ( int pSeqCode, int pObjectCode ) {
            this.SeqCode = pSeqCode;
            this.ObjectCode = pObjectCode;
            return base.GetByKey ( );
        }

    }

}
