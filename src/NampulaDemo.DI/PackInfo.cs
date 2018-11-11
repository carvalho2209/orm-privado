using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI;
using Nampula.DI.B1.UserTables;
using System.Data;

namespace NampulaDemo.DI
{
    public class PackInfo : TableNoObject
    {
        #region Fields

        #region Definition
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "MMBTBV";
        }
        #endregion

        #region FieldsName
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public new struct FieldsName
        {
            public static readonly string VolumeID = "mmbvol";
            public static readonly string TableName = "mmbnomtb";
            public static readonly string DocEntry = "mmbdcent";
        }
        #endregion

        #region FieldsDescription
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public new struct FieldsDescription
        {
            public static readonly string VolumeID = "Código do Volume";
            public static readonly string TableName = "Tablea do SAP";
            public static readonly string DocEntry = "Nº do Documento";
        }
        #endregion

        #region TableAdapterFields

        TableAdapterField m_VolumeID = new TableAdapterField(FieldsName.VolumeID, FieldsDescription.VolumeID, 10);
        TableAdapterField m_TableName = new TableAdapterField(FieldsName.TableName, FieldsDescription.TableName, 10);
        TableAdapterField m_DocEntry = new TableAdapterField(FieldsName.DocEntry, FieldsDescription.DocEntry, DbType.Int32);

        #endregion

        #endregion

        #region Construtor

        public PackInfo()
            : base(Definition.TableName)
        {
        }

        public PackInfo(string pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        public PackInfo(PackInfo pPackInfo)
            : this()
        {
            this.CopyBy(pPackInfo);
        }

        #endregion

        #region Propriedades

        public string VolumeID
        {
            get { return m_VolumeID.GetString(); }
            set { m_VolumeID.Value = value; }
        }

        public string TableName
        {
            get { return m_TableName.GetString(); }
            set { m_TableName.Value = value; }
        }

        public Int32 DocEntry
        {
            get { return m_DocEntry.GetInt32(); }
            set { m_DocEntry.Value = value; }
        }

        #endregion

        #region Metodos

        #region GetAll
        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de PackInfo.</returns>
        public List<PackInfo> GetAll()
        {
            return FillCollection<PackInfo>(this.GetData().Rows);
        }
        #endregion

        public List<PackInfo> GetByDocEntry(Int32 pDocEntry)
        {
            TableQuery myQuery = new TableQuery(this);

            myQuery.Where.Add(new QueryParam(m_DocEntry, pDocEntry));

            return FillCollection<PackInfo>(myQuery);
        }



        #endregion
    }
}
