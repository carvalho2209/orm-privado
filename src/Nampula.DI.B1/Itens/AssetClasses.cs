using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nampula.DI.B1.Itens
{

    /// <summary>
    /// Tabela de Classes do Ativo Fixo
    /// </summary>
    public class AssetClasses : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OACS";
        }

        public struct FieldsName
        {
            public static readonly string Code = "Code";
            public static readonly string Name = "Name";
            public static readonly string AssetType = "AssetType";
            public static readonly string LimitFrom = "LimitFrom";
            public static readonly string LimitTo = "LimitTo";
            public static readonly string CreateDate = "CreateDate";
            public static readonly string BPLId = "BPLId";
            public static readonly string AttrGrp = "AttrGrp";
            public static readonly string SnapshotId = "SnapshotId";
        }

        public struct FieldsDescription
        {
            public static readonly string Code = "Código";
            public static readonly string Name = "Descrição";
            public static readonly string AssetType = "AssetType";
            public static readonly string LimitFrom = "LimitFrom";
            public static readonly string LimitTo = "LimitTo";
            public static readonly string CreateDate = "Data de Criação";
            public static readonly string BPLId = "BPLId";
            public static readonly string AttrGrp = "AttrGrp";
            public static readonly string SnapshotId = "SnapshotId";
        }

        TableAdapterField m_Code = new TableAdapterField(FieldsName.Code, FieldsDescription.Code, 20);
        TableAdapterField m_Name = new TableAdapterField(FieldsName.Name, FieldsDescription.Name, 200);
        TableAdapterField m_AssetType = new TableAdapterField(FieldsName.AssetType, FieldsDescription.AssetType, 1);
        TableAdapterField m_LimitFrom = new TableAdapterField(FieldsName.LimitFrom, FieldsDescription.LimitFrom, DbType.Decimal, 19 , 6);
        TableAdapterField m_LimitTo = new TableAdapterField(FieldsName.LimitTo, FieldsDescription.LimitTo, DbType.Decimal, 19, 6);
        TableAdapterField m_CreateDate = new TableAdapterField(FieldsName.CreateDate, FieldsDescription.CreateDate, DbType.DateTime);
        TableAdapterField m_BPLId = new TableAdapterField(FieldsName.BPLId, FieldsDescription.BPLId, DbType.Int32);
        TableAdapterField m_AttrGrp = new TableAdapterField(FieldsName.AttrGrp, FieldsDescription.AttrGrp, DbType.Int32);
        TableAdapterField m_SnapshotId = new TableAdapterField(FieldsName.SnapshotId, FieldsDescription.SnapshotId, DbType.Int32);

        public AssetClasses()
            : base(Definition.TableName)
        {
        }

        /// <summary>
        /// Construtor padrão
        /// </summary>
        /// <param name="pCompanyDb">Nome do Banco</param>
        public AssetClasses(String pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        public AssetClasses(AssetClasses pAssetClasses)
            : this()
        {
            this.CopyBy(pAssetClasses);
        }

        public String Code
        {
            get { return m_Code.GetString(); }
            set { m_Code.Value = value; }
        }

        public String Name
        {
            get { return m_Name.GetString(); }
            set { m_Name.Value = value; }
        }

        public String AssetType
        {
            get { return m_AssetType.GetString(); }
            set { m_AssetType.Value = value; }
        }

        public Decimal LimitFrom
        {
            get { return m_LimitFrom.GetDecimal(); }
            set { m_LimitFrom.Value = value; }
        }

        public Decimal LimitTo
        {
            get { return m_LimitTo.GetDecimal(); }
            set { m_LimitTo.Value = value; }
        }

        public DateTime CreateDate
        {
            get { return m_CreateDate.GetDateTime(); }
            set { m_CreateDate.Value = value; }
        }

        public Int32 BPLId
        {
            get { return m_BPLId.GetInt32(); }
            set { m_BPLId.Value = value; }
        }

        public Int32 AttrGrp
        {
            get { return m_AttrGrp.GetInt32(); }
            set { m_AttrGrp.Value = value; }
        }

        public Int32 SnapshotId
        {
            get { return m_SnapshotId.GetInt32(); }
            set { m_SnapshotId.Value = value; }
        }

        /// <summary>
        /// Pega o objeto pela chave
        /// </summary>
        /// <param name="pCode">Código do Classe do Ativo</param>
        /// <returns></returns>
        public bool GetByKey(string pCode)
        {
            this.Code = pCode;
            return base.GetByKey();
        }

        /// <summary>
        /// Pega todos os registros da base
        /// </summary>
        /// <returns>Lista de Objetos</returns>
        public List<AssetClasses> GetAll()
        {
            return FillCollection<AssetClasses>();
        }

    }
}
