using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.SalesTaxCode
{
    /// <summary>
    /// Tipos de Impostos
    /// </summary>
    public class TaxAuthoritiesType : TableAdapter
    {
        

        
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OSTT";
        }
        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string AbsId = "AbsId";
            public static readonly string Name = "Name";
            public static readonly string NfTaxId = "NfTaxId";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string AbsId = "Código";
            public static readonly string Name = "Nome";
            public static readonly string NfTaxId = "Categoria";
        }
        

        

        TableAdapterField m_Id = new TableAdapterField(FieldsName.AbsId, FieldsDescription.AbsId, DbType.Int32, 11, 0, true, true);
        TableAdapterField m_Name = new TableAdapterField(FieldsName.Name, FieldsDescription.Name, 40);
        TableAdapterField m_NfTaxId = new TableAdapterField(FieldsName.NfTaxId, FieldsDescription.NfTaxId, DbType.Int32);

        

        

        

        public TaxAuthoritiesType()
            : base(Definition.TableName)
        {
        }

        public TaxAuthoritiesType(string pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        public TaxAuthoritiesType(TaxAuthoritiesType pTaxAuthoritiesType)
            : this()
        {
            this.CopyBy(pTaxAuthoritiesType);
        }

        

        

        public int Id
        {
            get { return m_Id.GetInt32(); }
            set { m_Id.Value = value; }
        }

        public String Name
        {
            get { return m_Name.GetString(); }
            set { m_Name.Value = value; }
        }

        public Int32 NfTaxId
        {
            get { return m_NfTaxId.GetInt32(); }
            set { m_NfTaxId.Value = value; }
        }
        

    }
}
