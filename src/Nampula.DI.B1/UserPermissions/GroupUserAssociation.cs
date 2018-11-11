using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nampula.DI.B1.UserPermissions
{
    public class GroupUserAssociation: TableAdapter
    {

        public struct FieldsName
        {
            public static readonly string UserId = "UserId";
            public static readonly string GroupId = "GroupId";
        }

        public struct Description
        {
            public static readonly string UserId = "User ID";
            public static readonly string GroupId = "Group ID";
        }

        public struct Definition
        {
            public static readonly string TableName = "USR7";
        }

        private TableAdapterField m_UserId = new TableAdapterField( FieldsName.UserId, Description.UserId,DbType.Int16 ,6, 0, true, false );
        private TableAdapterField m_GroupId = new TableAdapterField( FieldsName.GroupId, Description.GroupId, DbType.Int16);

        public GroupUserAssociation ( string pCompanyDb )
            : base( pCompanyDb, Definition.TableName )
        {
        }

        public GroupUserAssociation ( )
            : base( Definition.TableName )
        {
        }

        public short GroupId
        {
            get { return m_GroupId.GetInt16( ); }
            set { m_GroupId.Value = value; }
        }

        public short UserId
        {
            get { return m_UserId.GetInt16( ); }
            set { m_UserId.Value = value; }
        }

        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }

        /// <summary>
        /// Pega um grupo pelo código do Usuário
        /// </summary>
        /// <param name="pUserId">Código do Usuário</param>
        /// <returns>True se achou o grupo False se não achou o grupo com a permissão</returns>
        public bool GetByKey ( short pUserId )
        {
            UserId = pUserId;
            return GetByKey( );
        }

        /// <summary>
        /// Pega todos os grupos da tabela
        /// </summary>
        /// <returns></returns>
        public List<GroupUserAssociation> GetAll ( )
        {
            return FillCollection<GroupUserAssociation>( GetData( ).Rows );
        }

    }
}