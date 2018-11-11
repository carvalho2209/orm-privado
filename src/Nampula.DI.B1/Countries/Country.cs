using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI;
using System.Data;

namespace Nampula.DI.B1.Countries {

    /// <summary>
    /// Tabela de Países
    /// </summary>
    public class Country : TableAdapter {

        /// <summary>
        /// Nome dos Campos
        /// </summary>
        public struct FieldsName {

            public static readonly  string Code = "Code";
            public static readonly  string Name = "Name";

        }

        /// <summary>
        /// Descrição dos Campos
        /// </summary>
        public struct Description {

            public static readonly  string Code = "Código";
            public static readonly  string Name = "Nome";

        }

        /// <summary>
        /// Definições da Tabela
        /// </summary>
        public struct Definition {
            public static readonly  string TableName = "OCRY";
        }

        TableAdapterField m_Code = new TableAdapterField ( FieldsName.Code, Description.Code, DbType.String, 3, null, true, false );
        TableAdapterField m_Name = new TableAdapterField ( FieldsName.Name, Description.Name, 100 );

        /// <summary>
        /// Paises
        /// </summary>
        /// <param name="pCompanyDb">Banco de Dados da Empresa do SAP</param>
        public Country ()
            : base ( Definition.TableName ) {
        }

        public Country ( string pCompanyDb )
            : this ( ) {

            this.DBName = pCompanyDb;
        }

        public Country ( Country pCountry )
            : this ( ) {

            this.CopyBy ( pCountry );
        }

        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }

        public string Code {
            get { return m_Code.GetString ( ); }
            set { m_Code.Value = value; }
        }

        public string Name {
            get { return m_Name.GetString ( ); }
            set { m_Name.Value = value; }
        }

        public bool GetByKey ( string Code ) {
            this.Code = Code;
            return this.GetByKey ( );
        }

        public List<Country> GetAll () {
            return FillCollection<Country> ( );
        }

    }

}
