using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.MeasuresUnits
{
    /// <summary>
    /// Classe para controlde da tabela de unidades de medida de comprimento
    /// </summary>
    public class WeightUnit : TableAdapter
    {
        

        
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OWGT";
        }
        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string UnitCode = "UnitCode";
            public static readonly string UnitDisply = "UnitDisply";
            public static readonly string UnitName = "UnitName";
            public static readonly string WightInMG = "WightInMG";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string UnitCode = "Código";
            public static readonly string UnitDisply = "Símbolo";
            public static readonly string UnitName = "Unidade";
            public static readonly string WightInMG = "Peso em mg";
        }
        

        
        TableAdapterField m_UnitCode = new TableAdapterField( FieldsName.UnitCode, FieldsDescription.UnitCode, DbType.Int16, 11, null, true, false );
        TableAdapterField m_UnitDisply = new TableAdapterField( FieldsName.UnitDisply, FieldsDescription.UnitDisply, 2 );
        TableAdapterField m_UnitName = new TableAdapterField( FieldsName.UnitName, FieldsDescription.UnitName, 20 );
        TableAdapterField m_WightInMG = new TableAdapterField( FieldsName.WightInMG, FieldsDescription.WightInMG, DbType.Decimal );
        

        

        

        public WeightUnit ( )
            : base( Definition.TableName )
        {
        }

        public WeightUnit ( string pCompanyDb )
            : this( )
        {
            this.DBName = pCompanyDb;
        }

        public WeightUnit ( WeightUnit pLengthMeasures )
            : this( )
        {
            this.CopyBy( pLengthMeasures );
        }

        

        

        public int UnitCode
        {
            get { return m_UnitCode.GetInt32( ); }
            set { m_UnitCode.Value = value; }
        }

        public string UnitDisply
        {
            get { return m_UnitDisply.GetString( ); }
            set { m_UnitDisply.Value = value; }
        }

        public string UnitName
        {
            get { return m_UnitName.GetString( ); }
            set { m_UnitName.Value = value; }
        }


        public decimal WightInMG
        {
            get { return m_WightInMG.GetDecimal( ); }
            set { m_WightInMG.Value = value; }
        }

        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }

        
        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="pID">Código.</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public bool GetByKey ( int pUnitCode )
        {
            this.UnitCode = pUnitCode;
            return GetByKey( );
        }
        

        
        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de LengthMeasures.</returns>
        public List<WeightUnit> GetAll ( )
        {
            return FillCollection<WeightUnit>( );
        }
        

        
    }
}
