using System;
using System.Data;


namespace Nampula.DI.B1.CenterCosts
{
    /// <summary>
    /// Tabela para gerenciamento de centro de lucro
    /// </summary>
    public class CenterCostsCode : TableAdapter
    {

        
        /// <summary>
        /// Definições da Tabela
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OOCR";
        } 
        

        
        /// <summary>
        /// Nome dos Campos
        /// </summary>
        public struct FieldsName
        {
            public static readonly string OcrCode = "OcrCode";
            public static readonly string OcrName = "OcrName";
            public static readonly string Locked = "Locked";
            public static readonly string DimCode = "DimCode";
            public static readonly string Active = "Active";
        } 
        

        
        /// <summary>
        /// Descrição dos Campos
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string OcrCode = "Código";
            public static readonly string OcrName = "Descrição";
            public static readonly string Locked = "Bloqueado";
            public static readonly string DimCode = "Dimensão";
            public static readonly string Active = "Active";
        } 
        

        
        private TableAdapterField m_OcrCode = new TableAdapterField( FieldsName.OcrCode, FieldsDescription.OcrName, DbType.String, 8, "", true, false );
        private TableAdapterField m_OcrName = new TableAdapterField( FieldsName.OcrName, FieldsDescription.OcrName, 30 );
        private TableAdapterField m_Locked = new TableAdapterField( FieldsName.Locked, FieldsDescription.Locked, 1 );
        private TableAdapterField m_DimCode = new TableAdapterField( FieldsName.DimCode, FieldsDescription.DimCode, DbType.Int16 ); 
        private TableAdapterField m_Active = new TableAdapterField(FieldsName.Active, FieldsDescription.Active, 1);


        public CenterCostsCode ( )
            : base( Definition.TableName )
        {
        }

        public CenterCostsCode ( string pCompanyDb )
            : this( )
        {
            this.DBName = pCompanyDb;
        }

        public CenterCostsCode ( CenterCostsCode pCenterCostsCode )
            : this( )
        {
            this.CopyBy( pCenterCostsCode );
        }

        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }

        
        public string OcrCode
        {
            get { return m_OcrCode.GetString( ); }
            set { m_OcrCode.Value = value; }
        }

        public string OcrName
        {
            get { return m_OcrName.GetString( ); }
            set { m_OcrName.Value = value; }
        }

        public string Locked
        {
            get { return m_Locked.GetString( ); }
            set { m_Locked.Value = value; }
        }

        public Int16 DimCode
        {
            get { return m_DimCode.GetInt16( ); }
            set { m_DimCode.Value = value; }
        }

        public string Active
        {
            get { return m_Active.GetString(); }
            set { m_Active.Value = value; }
        }

        /// <summary>
        /// Pega registro na tabela pela sua chave
        /// </summary>
        /// <param name="OcrCode">Código do Registro</param>
        /// <returns>True se encontrar false se não encotrar</returns>
        public bool GetByKey ( string OcrCode )
        {
            this.OcrCode = OcrCode;
            return this.GetByKey( );
        } 
        

    }
}
