using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.LengthMeasures
{
    /// <summary>
    /// Classe para controlde da tabela de unidades de medida.
    /// </summary>
    public class LengthMeasure : TableAdapter
    {
        #region Fields

        #region Definition
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OLGT";
        }
        #endregion

        #region FieldsName
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string UnitCode = "UnitCode";
            public static readonly string UnitDisply = "UnitDisply";
            public static readonly string UnitName = "UnitName";
            public static readonly string VolDisply = "VolDisply";
            public static readonly string SizeInMM = "SizeInMM";
        }
        #endregion

        #region FieldsDescription
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string UnitCode = "Código";
            public static readonly string UnitDisply = "Símbolo";
            public static readonly string UnitName = "Unidade";
            public static readonly string VolDisply = "Símbolo de Volume";
            public static readonly string SizeInMM = "Tamanho em mm";
        }
        #endregion

        #region TableAdapterFields
        TableAdapterField m_UnitCode = new TableAdapterField(FieldsName.UnitCode, FieldsDescription.UnitCode, DbType.Int16, 11, null, true, false);
        TableAdapterField m_UnitDisply = new TableAdapterField(FieldsName.UnitDisply, FieldsDescription.UnitDisply, 2);
        TableAdapterField m_UnitName = new TableAdapterField(FieldsName.UnitName, FieldsDescription.UnitName, 20);
        TableAdapterField m_VolDisply = new TableAdapterField(FieldsName.VolDisply, FieldsDescription.VolDisply, 3);
        TableAdapterField m_SizeInMM = new TableAdapterField(FieldsName.SizeInMM, FieldsDescription.SizeInMM, DbType.Decimal);
        #endregion

        #endregion

        #region Construtor

        public LengthMeasure()
            : base(Definition.TableName)
        {
        }

        public LengthMeasure(string pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        public LengthMeasure(LengthMeasure pLengthMeasures)
            : this()
        {
            this.CopyBy(pLengthMeasures);
        }

        #endregion

        #region Propriedades

        public int UnitCode
        {
            get { return m_UnitCode.GetInt32(); }
            set { m_UnitCode.Value = value; }
        }

        public string UnitDisply
        {
            get { return m_UnitDisply.GetString(); }
            set { m_UnitDisply.Value = value; }
        }

        public string UnitName
        {
            get { return m_UnitName.GetString(); }
            set { m_UnitName.Value = value; }
        }

        public string VolDisply
        {
            get { return m_VolDisply.GetString(); }
            set { m_VolDisply.Value = value; }
        }

        public decimal SizeInMM
        {
            get { return m_SizeInMM.GetDecimal(); }
            set { m_SizeInMM.Value = value; }
        }

        #endregion

        #region Metodos

        public override bool Add() { return false; }

        public override bool Update() { return false; }

        public override bool Remove() { return false; }

        #region GetByKey
        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="pID">Código.</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public bool GetByKey(int pUnitCode)
        {
            this.UnitCode = pUnitCode;
            return GetByKey();
        }
        #endregion

        #region GetAll
        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de LengthMeasures.</returns>
        public List<LengthMeasure> GetAll()
        {
            return FillCollection<LengthMeasure>();
        }
        #endregion

        #endregion
    }
}
