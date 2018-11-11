using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.BusinessPlaces
{

    /// <summary>
    /// Tabela de Lista de IE do ST por Empresa
    /// </summary>
    public class BusinessPlaceTaxId : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "BPL1";
        }

        public struct FieldsName
        {
            public static readonly string BPLId = "BPLId";
            public static readonly string DstState = "DstState";
            public static readonly string IENumber = "IENumber";
        }

        public struct FieldsDescription
        {
            public static readonly string BPLId = "Id da Filial";
            public static readonly string DstState = "Estado de Destino";
            public static readonly string IENumber = "Número do I.E.";
        }

        TableAdapterField m_BPLId = new TableAdapterField(FieldsName.BPLId, FieldsDescription.BPLId, DbType.Int32, 11, 0, true, false);
        TableAdapterField m_DstState = new TableAdapterField(FieldsName.DstState, FieldsDescription.DstState, DbType.String, 3, 0, true, false);
        TableAdapterField m_IENumber = new TableAdapterField(FieldsName.IENumber, FieldsDescription.IENumber, 32);

        public BusinessPlaceTaxId(string pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        public BusinessPlaceTaxId()
            : base(Definition.TableName)
        {
        }

        public BusinessPlaceTaxId(BusinessPlaceTaxId pBusinessPlaceTaxId)
            : this()
        {
            this.CopyBy(pBusinessPlaceTaxId);
        }

        public Int32 BPLId
        {
            get { return m_BPLId.GetInt32(); }
            set { m_BPLId.Value = value; }
        }

        public String DstState
        {
            get { return m_DstState.GetString(); }
            set { m_DstState.Value = value; }
        }

        public String IENumber
        {
            get { return m_IENumber.GetString(); }
            set { m_IENumber.Value = value; }
        }


    }
}
