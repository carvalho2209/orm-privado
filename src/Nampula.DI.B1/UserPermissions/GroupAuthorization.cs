using System.Collections.Generic;
using System.Data;

namespace Nampula.DI.B1.UserPermissions
{
    public class GroupAuthorization: TableAdapter
    {

        public struct FieldsName
        {
            public static readonly string GroupLink = "GroupLink";
            public static readonly string PermId = "PermId";
            public static readonly string Permission = "Permission";
        }

        public struct Description
        {
            public static readonly string GroupLink = "Group Link";
            public static readonly string PermId = "Authorization ID";
            public static readonly string Permission = "Authorization";
        }

        public struct Definition
        {
            public static readonly string TableName = "UGR1";
        }

        private TableAdapterField m_GroupLink = new TableAdapterField( FieldsName.GroupLink, Description.GroupLink, DbType.Int16 ,6 , 0, true, false );
        private TableAdapterField m_PermId = new TableAdapterField( FieldsName.PermId, Description.PermId,DbType.String, 20 , 0, true, false );
        TableAdapterField m_Permission = new TableAdapterField(FieldsName.Permission, Description.Permission, 1);

        public GroupAuthorization ( string pCompanyDb )
            : base( pCompanyDb, Definition.TableName )
        {
        }

        public GroupAuthorization ( )
            : base( Definition.TableName )
        {
        }

        public short GroupLink
        {
            get { return m_GroupLink.GetInt16( ); }
            set { m_GroupLink.Value = value; }
        }

        public string PermId
        {
            get { return m_PermId.GetString( ); }
            set { m_PermId.Value = value; }
        }

        public PermissionType Permission
        {
            get { return m_Permission.GetString( ).ToPermEnum( ); }
            set { m_Permission.Value = value.ToPermString( ); }
        }

        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }

        /// <summary>
        /// Pega um grupo pelo código do grupo
        /// </summary>
        /// <param name="groupLink">Código do Grupo</param>
        /// <param name="pPermId">Código da Permissão</param>
        /// <returns>True se achou o grupo False se não achou o grupo com a permissão</returns>
        public bool GetByKey ( short groupLink, string pPermId )
        {
            GroupLink = groupLink;
            PermId = pPermId;
            return GetByKey( );
        }

        /// <summary>
        /// Pega todos os grupos da tabela
        /// </summary>
        /// <returns></returns>
        public List<GroupAuthorization> GetAll ( )
        {
            return FillCollection<GroupAuthorization>( GetData( ).Rows );
        }

    }
}

