using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.Territories {
    public class Territory : TableAdapter {
        

        public new static readonly string TableName = "OTER";

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName {
            public static readonly string ID = "territryID";
            public static readonly string Description = "descript";
            public static readonly string Parent = "parent";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription {
            public static readonly string ID = "Território";
            public static readonly string Description = "Descrição";
            public static readonly string Parent = "Pai";
        }
        

        

        TableAdapterField m_ID = new TableAdapterField ( FieldsName.ID, FieldsDescription.ID, DbType.Int32, 11, 0, true, true );
        TableAdapterField m_Description = new TableAdapterField ( FieldsName.Description, FieldsDescription.Description, 200 );
        TableAdapterField m_Parent = new TableAdapterField ( FieldsName.Parent, FieldsDescription.Parent, DbType.Int32 );

        

        

        

        public Territory ()
            : base ( TableName ) {
        }

        public Territory ( Territory pTerritory )
            : this ( ) {
            this.CopyBy ( pTerritory );
        }

        public Territory ( string pCompanyDb )
            : this ( ) {
            this.DBName = pCompanyDb;
        }

        

        

        public int ID {
            get { return m_ID.GetInt32 ( ); }
            set { m_ID.Value = value; }
        }

        public string Description {
            get { return m_Description.GetString ( ); }
            set { m_Description.Value = value; }
        }

        public int Parent {
            get { return m_Parent.GetInt32 ( ); }
            set { m_Parent.Value = value; }
        }

        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }

        
        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="pID">Código.</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public bool GetByKey ( int pID ) {
            this.ID = pID;
            return GetByKey ( );
        }
        

        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de Territory.</returns>
        public List<Territory> GetAll () {
            return FillCollection<Territory> ( );
        }
        

        
    }
}
