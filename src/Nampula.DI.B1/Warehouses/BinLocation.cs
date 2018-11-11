using System;
using System.Data;

namespace Nampula.DI.B1.Warehouses
{
    /// <summary>
    /// Tabela de Posições do Estoque
    /// </summary>
    public class BinLocation : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OBIN";
        }
		
		public struct FieldsName
        {
            public static readonly string AbsEntry = "AbsEntry";
            public static readonly string BinCode = "BinCode";
            public static readonly string Descr = "Descr";
            public static readonly string WhsCode = "WhsCode";
            public static readonly string Disabled = "Disabled";
            public static readonly string Deleted = "Deleted";            
		}
		
		public struct FieldsDescription
        {
            public static readonly string AbsEntry = "Nº";
            public static readonly string BinCode = "Código da Posição";
            public static readonly string Descr = "Descrição";
            public static readonly string WhsCode = "Depósito";
            public static readonly string Disabled = "Desabilitado";
            public static readonly string Deleted = "Deletado";
		}

        readonly TableAdapterField _absEntry = new TableAdapterField(FieldsName.AbsEntry, FieldsDescription.AbsEntry, DbType.Int32, 11, 0, true, true);
        readonly TableAdapterField _binCode = new TableAdapterField(FieldsName.BinCode, FieldsDescription.BinCode, 256);
        readonly TableAdapterField _descr = new TableAdapterField(FieldsName.Descr, FieldsDescription.Descr, 100);
        readonly TableAdapterField _whsCode = new TableAdapterField(FieldsName.WhsCode, FieldsDescription.WhsCode, 40);
        readonly TableAdapterField _disabled = new TableAdapterField(FieldsName.Disabled, FieldsDescription.Disabled, 1);
        readonly TableAdapterField _deleted = new TableAdapterField(FieldsName.Deleted, FieldsDescription.Deleted, 1);        

        public BinLocation()
            : base(Definition.TableName)
        {            
        }

        public BinLocation(string companyDb)
            : this()
        {
            DBName = companyDb;
        }

		public BinLocation(BinLocation pBinLocation)
            : this()
        {
            CopyBy(pBinLocation);
        }
        
        public int AbsEntry
        {
            get { return _absEntry.GetInt32(); }
            set { _absEntry.Value = value; }
        }

        public String BinCode
        {
            get { return _binCode.GetString(); }
            set { _binCode.Value = value; }
        }

        public String Descr
        {
            get { return _descr.GetString(); }
            set { _descr.Value = value; }
        }

        public String WhsCode
        {
            get { return _whsCode.GetString(); }
            set { _whsCode.Value = value; }
        }

        public String Disabled
        {
            get { return _disabled.GetString(); }
            set { _disabled.Value = value; }
        }

        public String Deleted
        {
            get { return _deleted.GetString(); }
            set { _deleted.Value = value; }
        }


    }
}
