using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.BusinessPartners
{
    public class BusinessPartnerProperties : TableAdapter
    {
        

        
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OCQG";
        }
        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string GroupCode = "GroupCode";
            public static readonly string GroupName = "GroupName";
            public static readonly string UserSign = "UserSign";
            public static readonly string Filler = "Filler";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string GroupCode = "Código";
            public static readonly string GroupName = "Nome do grupo";
            public static readonly string UserSign = "Usuário ";
            public static readonly string Filler = "Filler";
        }
        

        

        TableAdapterField m_GroupCode = new TableAdapterField(FieldsName.GroupCode, FieldsDescription.GroupCode, DbType.Int32, 11, 0, true, true);
        TableAdapterField m_GroupName = new TableAdapterField(FieldsName.GroupName, FieldsDescription.GroupName, 50);
        TableAdapterField m_UserSign = new TableAdapterField(FieldsName.UserSign, FieldsDescription.UserSign, DbType.Int32);
        TableAdapterField m_Filler = new TableAdapterField(FieldsName.Filler, FieldsDescription.Filler, 10);
                
        

        

        

        public BusinessPartnerProperties()
            : base(Definition.TableName)
        {
        }

        public BusinessPartnerProperties(string pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        public BusinessPartnerProperties(BusinessPartnerProperties pBusinessPartnerProperties)
            : this(pBusinessPartnerProperties.DBName)
        {
            this.CopyBy(pBusinessPartnerProperties);
        }        

        

        

        public int GroupCode
        {
            get { return m_GroupCode.GetInt32(); }
            set { m_GroupCode.Value = value; }
        }

        public String GroupName
        {
            get { return m_GroupName.GetString(); }
            set { m_GroupName.Value = value; }
        }

        public Int32 UserSign
        {
            get { return m_UserSign.GetInt32(); }
            set { m_UserSign.Value = value; }
        }

        public String Filler
        {
            get { return m_Filler.GetString(); }
            set { m_Filler.Value = value; }
        }
        

        

        
        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="pID">Código.</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public bool GetByKey(int pGroupCode)
        {
            this.GroupCode = pGroupCode;
            return GetByKey();
        }
        

        
        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de BusinessPartnerProperties.</returns>
        public List<BusinessPartnerProperties> GetAll()
        {
            return FillCollection<BusinessPartnerProperties>(this.GetData().Rows);
        }
        

        
    }
}
