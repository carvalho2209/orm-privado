using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.Framework;
using System.Data;

namespace Nampula.DI.B1.UserPermissions
{
    /// <summary>
    /// Classe para gerenciamento da tabela do SAP : USR3
    /// </summary>
    public class UserAuthorization : TableAdapter
    {
        

        
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "USR3";
        }
        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string UserLink = "UserLink";
            public static readonly string PermID = "PermID";
            public static readonly string Permission = "Permission";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string UserLink = "UserLink";
            public static readonly string PermID = "PermID";
            public static readonly string Permission = "Permission";
        }
        

        

        TableAdapterField m_UserLink = new TableAdapterField( FieldsName.UserLink, FieldsDescription.UserLink, DbType.Int32, 11, 0, true, false );
        TableAdapterField m_PermID = new TableAdapterField( FieldsName.PermID, FieldsDescription.PermID, DbType.String, 20, 0, true, false );
        TableAdapterField m_Permission = new TableAdapterField( FieldsName.Permission, FieldsDescription.Permission, 1 );

        

        

        

        public UserAuthorization ( )
            : base( Definition.TableName )
        {
        }

        public UserAuthorization ( string pCompanyDb )
            : this( )
        {
            DBName = pCompanyDb;
        }

        public UserAuthorization ( UserAuthorization pUserAuthorization )
            : this( )
        {
            this.CopyBy( pUserAuthorization );
        }

        

        

        public int UserLink
        {
            get { return m_UserLink.GetInt32( ); }
            set { m_UserLink.Value = value; }
        }

        public string PermID
        {
            get { return m_PermID.GetString( ); }
            set { m_PermID.Value = value; }
        }

        public PermissionType Permission
        {
            get { return m_Permission.GetString( ).ToPermEnum( ); }
            set { m_Permission.Value = value.ToPermString( ); }
        }

        

        

        
        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="pID">Código.</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public bool GetByKey ( int pUserLink, string pPermID )
        {
            this.UserLink = pUserLink;
            this.PermID = pPermID;
            return GetByKey( );
        }
        

        
        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de UserAuthorization.</returns>
        public List<UserAuthorization> GetAll ( )
        {
            return FillCollection<UserAuthorization>( this.GetData( ).Rows );
        }
        

        
    }
}
