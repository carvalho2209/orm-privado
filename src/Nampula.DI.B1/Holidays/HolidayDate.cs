using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI;
using System.Data;

namespace Nampula.DI.B1.Holidays
{
    public class HolidayDate : TableAdapter
    {
        

        
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "HLD1";
        }
        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string HldCode = "HldCode";
            public static readonly string StrDate = "StrDate";
            public static readonly string EndDate = "EndDate";
            public static readonly string Rmrks = "Rmrks";            
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string HldCode = "Descrição ID";
            public static readonly string StrDate = "Data de início";
            public static readonly string EndDate = "Data Final";
            public static readonly string Rmrks = "Observações";  
        }
        

        

        TableAdapterField m_HldCode = new TableAdapterField(FieldsName.HldCode, FieldsDescription.HldCode, DbType.String, 20, 0, true, false);
        TableAdapterField m_StrDate = new TableAdapterField(FieldsName.StrDate, FieldsDescription.StrDate, DbType.DateTime, 20, null, true, false);
        TableAdapterField m_EndDate = new TableAdapterField(FieldsName.EndDate, FieldsDescription.EndDate, DbType.DateTime, 20, null, true, false);
        TableAdapterField m_Rmrks = new TableAdapterField(FieldsName.Rmrks, FieldsDescription.Rmrks, 50);
                
        

        

        

        public HolidayDate()
            : base(Definition.TableName)
        {
        }

        public HolidayDate(String pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        public HolidayDate ( HolidayDate pItem )
            : this(pItem.DBName)
        {

            this.CopyBy(pItem);
        }

        

        

        public string HldCode
        {
            get { return m_HldCode.GetString(); }
            set { m_HldCode.Value = value; }
        }

        public DateTime StrDate
        {
            get { return m_StrDate.GetDateTime(); }
            set { m_StrDate.Value = value; }
        }

        public DateTime EndDate
        {
            get { return m_EndDate.GetDateTime(); }
            set { m_EndDate.Value = value; }
        }

        public String Rmrks
        {
            get { return m_Rmrks.GetString(); }
            set { m_Rmrks.Value = value; }
        }
        

        

        
        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="pID">Código.</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public bool GetByKey(string pID, DateTime pStrDate, DateTime pEndDate)
        {
            this.HldCode = pID;
            this.StrDate = pStrDate;
            this.EndDate = pEndDate;
            return GetByKey();
        }
        

        
        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de HolidayLine.</returns>
        public List<HolidayDate> GetAll ( )
        {
            return FillCollection<HolidayDate>( this.GetData( ).Rows );
        }
        

        
    }
}
