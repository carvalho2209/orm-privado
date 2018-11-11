using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1 {

    public class LicenseServer : TableAdapter {
        

        
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition {
            public static readonly string TableName = "SLIC";
        }
        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName {
            public static readonly string LSRV = "LSRV";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription {
            public static readonly string LSRV = "Servidor de Licença";
        }
        

        

        TableAdapterField m_LSRV = new TableAdapterField ( FieldsName.LSRV, FieldsDescription.LSRV, DbType.String, 100, 0, true, false );

        

        

        

        public LicenseServer ()
            : base ( "SBO-COMMON", Definition.TableName ) {
        }

        public LicenseServer ( LicenseServer pLicenseServer )
            : this ( ) {
            this.CopyBy ( pLicenseServer );
        }

        

        

        public string LSRV {
            get { return m_LSRV.GetString ( ); }
            set { m_LSRV.Value = value; }
        }

        

        

        
        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="pID">Código.</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public string GetByLienseServer (  ) {
            return GetAll()[0].LSRV;
        }
        

        
        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de LicenseServer.</returns>
        public List<LicenseServer> GetAll () {
            return FillCollection<LicenseServer> ( this.GetData ( ).Rows );
        }
        

        
    }    
}
