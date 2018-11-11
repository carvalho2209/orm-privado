using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.ProfitCenters
{
    public class ProfitCenter : TableAdapter
    {
        

        
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OPRC";
        }
        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string PrcCode = "PrcCode";
            public static readonly string PrcName = "PrcName";
            public static readonly string GrpCode = "GrpCode";
            public static readonly string DimCode = "DimCode";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string PrcCode = "Centro de Lucro";
            public static readonly string PrcName = "Nome";
            public static readonly string GrpCode = "Cód.de Ordenação";
            public static readonly string DimCode = "Dimensão";
        }
        

        

        TableAdapterField m_PrcCode = new TableAdapterField(FieldsName.PrcCode, FieldsDescription.PrcCode, DbType.String, 8, 0, true, false);
        TableAdapterField m_PrcName = new TableAdapterField(FieldsName.PrcName, FieldsDescription.PrcName, 30);
        TableAdapterField m_GrpCode = new TableAdapterField(FieldsName.GrpCode, FieldsDescription.GrpCode, 8);
        TableAdapterField m_DimCode = new TableAdapterField(FieldsName.DimCode, FieldsDescription.DimCode, DbType.Int16);

        

        

        

        public ProfitCenter()
            : base(Definition.TableName)
        {
        }

        public ProfitCenter(ProfitCenter pProfitCenter)
            : this()
        {
            this.CopyBy(pProfitCenter);
        }

        

        

        public string PrcCode
        {
            get { return m_PrcCode.GetString(); }
            set { m_PrcCode.Value = value; }
        }

        public string PrcName
        {
            get { return m_PrcName.GetString(); }
            set { m_PrcName.Value = value; }
        }

        public string GrpCode
        {
            get { return m_GrpCode.GetString(); }
            set { m_GrpCode.Value = value; }
        }

        public short DimCode
        {
            get { return m_DimCode.GetInt16(); }
            set { m_DimCode.Value = value; }
        }
        

    }
}
