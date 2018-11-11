using System.Collections.Generic;
using System.Data;

namespace Nampula.DI.B1.UserPermissions
{
    public class AuthorizationGroup: TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OUGR";
        }

        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string GroupId = "GroupId";
            public static readonly string GroupName = "GroupName";
            public static readonly string GroupDec = "GroupDec";
            public static readonly string Allowences = "Allowences";
            public static readonly string TPLId = "TPLId";
        }

        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string GroupId = "Authorization Group ID";
            public static readonly string GroupName = "Group Name";
            public static readonly string GroupDec = "Group Description";
            public static readonly string Allowences = "Allowances";
            public static readonly string TPLId = "Template ID";
        }

        TableAdapterField m_GroupId = new TableAdapterField(FieldsName.GroupId, FieldsDescription.GroupId, DbType.String, 20, 0, true, false);
        TableAdapterField m_GroupName = new TableAdapterField(FieldsName.GroupName, FieldsDescription.GroupName, 155);
        TableAdapterField m_GroupDec = new TableAdapterField(FieldsName.GroupDec, FieldsDescription.GroupDec, 155);
        TableAdapterField m_Allowences = new TableAdapterField(FieldsName.Allowences, FieldsDescription.Allowences, 16);
        TableAdapterField m_TPLId = new TableAdapterField(FieldsName.TPLId, FieldsDescription.TPLId, DbType.Int16);

        public AuthorizationGroup ( string pCompanyDb )
            : base( pCompanyDb, Definition.TableName )
        {
        }

        public AuthorizationGroup ( )
            : base( Definition.TableName )
        {
        }

        public string GroupId
        {
            get { return m_GroupId.GetString(); }
            set { m_GroupId.Value = value; }
        }

        public string GroupName
        {
            get { return m_GroupName.GetString(); }
            set { m_GroupName.Value = value; }
        }

        public string GroupDec
        {
            get { return m_GroupDec.GetString(); }
            set { m_GroupDec.Value = value; }
        }

        public string Allowences
        {
            get { return m_Allowences.GetString(); }
            set { m_Allowences.Value = value; }
        }

        public int TPLId
        {
            get { return m_TPLId.GetInt32(); }
            set { m_TPLId.Value = value; }
        }

        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }


        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="pGroupId">Código do Grupo</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public bool GetByKey(string pGroupId)
        {
            GroupId = pGroupId;
            return GetByKey();
        }

        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de UserAutorizationTree.</returns>
        public List<AuthorizationGroup> GetAll()
        {
            return FillCollection<AuthorizationGroup>(GetData().Rows);
        }
    }
}

