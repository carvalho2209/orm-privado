using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI;
using System.Data;
using Nampula.DI.B1;
using Nampula.Framework;

namespace Nampula.DI.B1.Holidays
{
    public class Holiday : TableAdapter
    {
        

        
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OHLD";
        }
        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string HldCode = "HldCode";
            public static readonly string WndFrm = "WndFrm";
            public static readonly string WndTo = "WndTo";
            public static readonly string isCurYear = "isCurYear";
            public static readonly string ignrWnd = "ignrWnd";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string HldCode = "Código";
            public static readonly string WndFrm = "Final Semana Inicial";
            public static readonly string WndTo = "Final de Semana Final";
            public static readonly string isCurYear = "Válido por apenas um ano";
            public static readonly string ignrWnd = "Ignoar fins de semana para pagamento";
        }
        

        

        TableAdapterField m_HldCode = new TableAdapterField(FieldsName.HldCode, FieldsDescription.HldCode, DbType.String, 20, null, true, false);
        TableAdapterField m_WndFrm = new TableAdapterField(FieldsName.WndFrm, FieldsDescription.WndFrm, 1);
        TableAdapterField m_WndTo = new TableAdapterField(FieldsName.WndTo, FieldsDescription.WndTo, 1);
        TableAdapterField m_IsCurYear = new TableAdapterField(FieldsName.isCurYear, FieldsDescription.isCurYear, 1 );
        TableAdapterField m_ignrWnd = new TableAdapterField(FieldsName.ignrWnd, FieldsDescription.ignrWnd, 1);

        

        

        

        public Holiday()
            : base(Definition.TableName)
        {
        }

        public Holiday(String pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        public Holiday(Holiday pItem)
            : this(pItem.DBName)
        {

            this.CopyBy(pItem);
        }

        

        

        public string HldCode
        {
            get { return m_HldCode.GetString(); }
            set { m_HldCode.Value = value; }
        }

        public WeekDayType WndFrm
        {
            get { return (WeekDayType)m_WndFrm.GetInt32( ); }
            set { m_WndFrm.Value = value.To<Int32>(); }
        }

        public WeekDayType WndTo
        {
            get { return (WeekDayType)m_WndTo.GetInt32(); }
            set { m_WndTo.Value = value.To<Int32>(); }
        }

        public eYesNo isCurYear
        {
            get { return m_IsCurYear.GetString().ToYesNoEnum(); }
            set { m_IsCurYear.Value = value.ToYesNoString(); }
        }

        public eYesNo ignrWnd
        {
            get { return m_ignrWnd.GetString().ToYesNoEnum(); }
            set { m_ignrWnd.Value = value.ToYesNoString(); }
        }
        

        

        
        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="pID">Código.</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public bool GetByKey(string pID)
        {
            this.HldCode = pID;
            return GetByKey();
        }
        

        
        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de Holiday.</returns>
        public List<Holiday> GetAll()
        {
            return FillCollection<Holiday>(this.GetData().Rows);
        }
        

        
    }
}
