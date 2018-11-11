using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.UserCaches {

    public class UserCache : TableAdapter {
        

        
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition {
            public static readonly string TableName = "UserCache";
        }

        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName {
            public static readonly string ID = "ID";
            public static readonly string UserName = "UserName";
            public static readonly string Password = "Password";
            public static readonly string PasswordCompany = "PasswordCompany";
            public static readonly string CompanyDb = "CompanyDb";

        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription {
            public static readonly string ID = "Código";
            public static readonly string UserName = "Usuário";
            public static readonly string Password = "Senha";
            public static readonly string PasswordCompany = "Texto de Senha na empresa";
            public static readonly string CompanyDb = "Db da Empresa";
        }
        

        

        TableAdapterField m_ID = new TableAdapterField ( FieldsName.ID, FieldsDescription.ID, DbType.Int32, 11, 0, true, true );
        TableAdapterField m_UserName = new TableAdapterField ( FieldsName.UserName, FieldsDescription.UserName, 10 );
        TableAdapterField m_Password = new TableAdapterField ( FieldsName.Password, FieldsDescription.Password, 150 );
        TableAdapterField m_PasswordCompany = new TableAdapterField ( FieldsName.PasswordCompany, FieldsDescription.PasswordCompany, 150 );
        TableAdapterField m_CompanyDb = new TableAdapterField ( FieldsName.CompanyDb, FieldsDescription.CompanyDb, 150 );

        

        

        

        public UserCache ()
            : base ( "master", Definition.TableName ) {
        }

        public UserCache ( UserCache pUserCache )
            : this ( ) {
            this.CopyBy ( pUserCache );
        }

        

        

        public int ID {
            get { return m_ID.GetInt32 ( ); }
            set { m_ID.Value = value; }
        }

        public string UserName {
            get { return m_UserName.GetString ( ); }
            set { m_UserName.Value = value; }
        }

        public string Password {
            get { return m_Password.GetString ( ); }
            set { m_Password.Value = value; }
        }

        public string PasswordCompany {
            get { return m_PasswordCompany.GetString ( ); }
            set { m_PasswordCompany.Value = value; }
        }

        public string CompanyDb {
            get { return m_CompanyDb.GetString ( ); }
            set { m_CompanyDb.Value = value; }
        }

        

        

        
        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="pID">Código.</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public bool GetByKey ( int pID ) {
            this.ID = pID;
            return GetByKey ( );
        }
        

        
        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de UserCache.</returns>
        public List<UserCache> GetAll () {
            return FillCollection<UserCache> ( this.GetData ( ).Rows );
        }

        

        

        public bool GetByUserName ( string pCompanyDb, string pUserName ) {

            TableQuery myQuery = new TableQuery ( this );

            myQuery.Where.Add ( new QueryParam ( m_CompanyDb, pCompanyDb ) );
            myQuery.Where.Add ( new QueryParam ( m_UserName, pUserName ) );

            DataTable myData = GetData ( myQuery );

            if ( myData.Rows.Count > 0 )
                return GetByKey ( myData.Rows[0].Field<int> ( FieldsName.ID ) );
            else
                return false;

        }

    }

}
