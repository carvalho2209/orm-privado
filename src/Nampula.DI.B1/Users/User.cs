using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI;
using System.Data;


namespace Nampula.DI.B1.Users
{
    public class User : TableAdapter
    {
        public static readonly int GroupDepeted = 99;
        public static readonly int GroupRegular = 0;

        public struct FieldsName
        {
            public static readonly string USER_CODE = "USER_CODE";
            public static readonly string INTERNAL_K = "INTERNAL_K";
            public static readonly string U_NAME = "U_NAME";
            public static readonly string SUPERUSER = "SUPERUSER";
            public static readonly string Locked = "Locked";
            public static readonly string Department = "Department";
            public static readonly string Password = "Password";
            public static readonly string GROUPS = "GROUPS";
            public static readonly string UserId = "UserId";
        }

        public struct Description
        {
            public static readonly string USER_CODE = "Código";
            public static readonly string INTERNAL_K = "Chave Interna";
            public static readonly string U_NAME = "Nome";
            public static readonly string SUPERUSER = "Super Usuário";
            public static readonly string Locked = "Bloqueado";
            public static readonly string Department = "Departamento";
            public static readonly string Password = "Senha";
            public static readonly string GROUPS = "Grupo";
            public static readonly string UserId = "User Signature";
        }

        public struct Definition
        {
            public static readonly string TableName = "OUSR";
        }

        private TableAdapterField m_USER_CODE = new TableAdapterField( FieldsName.USER_CODE, Description.USER_CODE, DbType.String, 10, null, true, false );
        private TableAdapterField m_INTERNAL_K = new TableAdapterField( FieldsName.INTERNAL_K, Description.INTERNAL_K, DbType.Int32 );
        private TableAdapterField m_U_NAME = new TableAdapterField( FieldsName.U_NAME, Description.U_NAME, 100 );
        private TableAdapterField m_SUPERUSER = new TableAdapterField( FieldsName.SUPERUSER, Description.SUPERUSER, 1 );
        private TableAdapterField m_Locked = new TableAdapterField( FieldsName.Locked, Description.Locked, 1 );
        private TableAdapterField m_Department = new TableAdapterField( FieldsName.Department, Description.Department, DbType.Int16 );
        private TableAdapterField m_Password = new TableAdapterField( FieldsName.Password, Description.Password, 200 );
        TableAdapterField m_GROUPS = new TableAdapterField(FieldsName.GROUPS, Description.GROUPS, DbType.Int16);
        private TableAdapterField m_UserId = new TableAdapterField( FieldsName.UserId, Description.UserId, DbType.Int16 );

        public User ( string pCompanyDb )
            : base( pCompanyDb, Definition.TableName )
        {
        }

        public User ( )
            : base( Definition.TableName )
        {
        }

        public int InternalK
        {
            get { return m_INTERNAL_K.GetInt32( ); }
            set { m_INTERNAL_K.Value = value; }
        }

        public string USER_CODE
        {
            get { return m_USER_CODE.GetString( ); }
            set { m_USER_CODE.Value = value; }
        }

        public string U_NAME
        {
            get { return m_U_NAME.GetString( ); }
            set { m_U_NAME.Value = value; }
        }

        public eYesNo SUPERUSER
        {
            get { return m_SUPERUSER.GetString( ).ToYesNoEnum( ); }
            set { m_SUPERUSER.Value = value.ToYesNoString( ); }
        }

        public eYesNo Locked
        {
            get { return m_Locked.GetString( ).ToYesNoEnum( ); }
            set { m_Locked.Value = value.ToYesNoString( ); }
        }

        public short Department
        {
            get { return m_Department.GetInt16( ); }
            set { m_Department.Value = value; }
        }

        public string Password
        {
            get { return m_Password.GetString( ); }
            set { m_Password.Value = value; }
        }

        public Int16 GROUPS
        {
            get { return m_GROUPS.GetInt16(); }
            set { m_GROUPS.Value = value; }
        }
        
        public short UserId
        {
            get { return m_UserId.GetInt16( ); }
            set { m_UserId.Value = value; }
        }

        
        /// <summary>
        /// Pega um usuário pelo código do usuário
        /// </summary>
        /// <param name="USER_CODE">Código do usuário</param>
        /// <returns>True se achou o usuário False se não achou o usuário</returns>
        public bool GetByKey ( string USER_CODE )
        {
            this.USER_CODE = USER_CODE;
            return base.GetByKey( );
        } 
        

        
        /// <summary>
        /// Pega um usuário pelo código interno
        /// </summary>
        /// <param name="USER_CODE">Código do usuário</param>
        /// <returns>True se achou o usuário False se não achou o usuário</returns>
        public bool GetByKey ( Int32 pInternalK )
        {
            var query = new TableQuery( this );

            query.Where.Add(
                new QueryParam( m_INTERNAL_K, pInternalK ) );

            var data = GetData( query );

            if ( data.Rows.Count != 0 )
                return GetByKey( data.Rows[0].Field<string>( FieldsName.USER_CODE ) );
            else
                return false;

        } 
        

        /// <summary>
        /// Pega todos os usuários de acordo com um filtro
        /// </summary>
        /// <param name="pDepartment">Departamento</param>
        /// <param name="pUser">Usuário</param>
        /// <returns>Uma lista de usuários</returns>
        public List<User> GetUsers ( int pDepartment, string pUser )
        {

            TableQuery myTableUser = new TableQuery(this);//Uma tabela

            //== Departamento
            myTableUser.Where.Add(new QueryParam(m_Department, pDepartment));

            //== Usuario
            if (!String.IsNullOrEmpty(pUser))
                myTableUser.Where.Add(
                    new QueryParam(m_USER_CODE, eCondition.ecLike, pUser));

            return FillCollection<User>(myTableUser);
        }

        /// <summary>
        /// Pega todos os usuário da tabela
        /// </summary>
        /// <returns></returns>
        public List<User> GetAll ( )
        {
            return FillCollection<User>( GetData( ).Rows );
        }

    }
}
