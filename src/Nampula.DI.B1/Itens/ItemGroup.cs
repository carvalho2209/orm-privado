using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI;
using System.Data;

namespace Nampula.DI.B1.Itens
{
    /// <summary>
    /// Gerencia o grupo de items do SAP
    /// </summary>
    public class ItemGroup : TableAdapter
    {
        
        /// <summary>
        /// Definições da Tabela
        /// </summary>
        public struct Definition
        {
            public const string TableName = "OITB";
        }

        /// <summary>
        /// Nome dos Campos
        /// </summary>
        public struct FieldsName
        {
            public const string ItmsGrpCod = "ItmsGrpCod";
            public const string ItmsGrpNam = "ItmsGrpNam";
        }

        /// <summary>
        /// Descrição dos Campos
        /// </summary>
        public struct Description
        {
            public const string ItmsGrpCod = "Código";
            public const string ItmsGrpNam = "Nome";
        }

        
        TableAdapterField m_ItmsGrpCod = new TableAdapterField( FieldsName.ItmsGrpCod, Description.ItmsGrpCod, DbType.Int32, 11, 0, true, true );
        TableAdapterField m_ItmsGrpNam = new TableAdapterField( FieldsName.ItmsGrpNam, Description.ItmsGrpNam, 20 );
         
        

        
        /// <summary>
        /// Construtor padrão
        /// </summary>
        public ItemGroup ( )
            : base( Definition.TableName )
        {
        }

        /// <summary>
        /// Constutor a classe
        /// </summary>
        /// <param name="pCompanyDb">Banco de dados da Empresa</param>
        public ItemGroup ( String pCompanyDb )
            : this( )
        {
            this.DBName = pCompanyDb;
        }

        /// <summary>
        /// Clona o objeto
        /// </summary>
        /// <param name="pItemGroup">Objeto de Origem</param>
        public ItemGroup ( ItemGroup pItemGroup )
            : this( pItemGroup.DBName )
        {

            this.CopyBy( pItemGroup );
        } 
        

        
        public Int32 ItmsGrpCod
        {
            get { return m_ItmsGrpCod.GetInt32( ); }
            set { m_ItmsGrpCod.Value = value; }
        }

        public string ItmsGrpNam
        {
            get { return m_ItmsGrpNam.GetString( ); }
            set { m_ItmsGrpNam.Value = value; }
        } 
        

        
        
        /// <summary>
        /// Pega todos os registros do banco
        /// </summary>
        /// <returns>List de ItemGroup</returns>
        public List<ItemGroup> GetAll ( )
        {
            return FillCollection<ItemGroup>( );
        } 
        

        
        /// <summary>
        /// Pega o registro na tabela pelo ID
        /// </summary>
        /// <param name="pItmsGrpCod">Código do Grupo</param>
        /// <returns>True se encontrar</returns>
        public bool GetByKey ( int pItmsGrpCod )
        {
            this.ItmsGrpCod = pItmsGrpCod;
            return GetByKey( );
        }  
        
        

    }
}
