using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.ProductTrees
{
    public class ProductTree : TableAdapter
    {
        

        
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OITT";
        }
        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string Code = "Code";
            public static readonly string TreeType = "TreeType";
            public static readonly string Qauntity = "Qauntity";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string Code = "Código";
            public static readonly string TreeType = "Tipo";
            public static readonly string Qauntity = "Quantidade";
        }
        

        

        TableAdapterField m_Code = new TableAdapterField(FieldsName.Code, FieldsDescription.Code, DbType.String, 20, 0, true, true);
        TableAdapterField m_TreeType = new TableAdapterField(FieldsName.TreeType, FieldsDescription.TreeType, 1);
        TableAdapterField m_Qauntity = new TableAdapterField(FieldsName.Qauntity, FieldsDescription.Qauntity, DbType.Decimal);

        

        

        

        public ProductTree()
            : base(Definition.TableName)
        {
            Lines = new List<ProductTreeLine>();
            OnAfterSelect += new TableAdapterEventHandler(ProductTree_OnAfterSelect);
        }

        public ProductTree(string pCompanyDb)
            : this( )
        {
            DBName = pCompanyDb;
        }

        public ProductTree(ProductTree pProductTree)
            : this()
        {
            this.CopyBy(pProductTree);
        }

        

        

        private void ProductTree_OnAfterSelect(object Sender, TableAdapterEventArgs e)
        {
            var line = new ProductTreeLine(DBName);
            TableQuery query = new TableQuery(line);

            query.Where.Add(
                new QueryParam(
                    line.Collumns[ProductTreeLine.FieldsName.Father],
                    this.Code));

            Lines = line.FillCollection<ProductTreeLine>(query);
        }

        

        

        public string Code
        {
            get { return m_Code.GetString(); }
            set { m_Code.Value = value; }
        }

        public ItemTreeType TreeType
        {
            get { return m_TreeType.GetString().ToEnum(); }
            set { m_TreeType.Value = value.ToStringEnum(); }
        }

        public int Quantity
        {
            get { return m_Qauntity.GetInt32(); }
            set { m_Qauntity.Value = value; }
        }

        public List<ProductTreeLine> Lines { get; set; }

        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }
        
        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="pCode">Código.</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public bool GetByKey(string pCode)
        {
            this.Code = pCode;
            return GetByKey();
        }
        

        
        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de ProductTree.</returns>
        public List<ProductTree> GetAll()
        {
            return FillCollection<ProductTree>(this.GetData().Rows);
        }
        

        
    }
}
