using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.ProductTrees
{
    public class ProductTreeLine : TableAdapter
    {
        

        
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "ITT1";
        }
        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string Father = "Father";
            public static readonly string ChildNum = "ChildNum";
            public static readonly string Code = "Code";
            public static readonly string Quantity = "Quantity";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string Father = "Código pai";
            public static readonly string ChildNum = "Número da linha";
            public static readonly string Code = "Código do item";
            public static readonly string Quantity = "Quantidade";
        }
        

        

        TableAdapterField m_Father = new TableAdapterField(FieldsName.Father, FieldsDescription.Father, DbType.String, 20, 0, true, false);
        TableAdapterField m_ChildNum = new TableAdapterField(FieldsName.ChildNum, FieldsDescription.ChildNum, DbType.Int32, 11, 0, true, false);
        TableAdapterField m_Code = new TableAdapterField(FieldsName.Code, FieldsDescription.Code, 20);
        TableAdapterField m_Quantity = new TableAdapterField(FieldsName.Quantity, FieldsDescription.Quantity, DbType.Decimal);

        

        

        

        public ProductTreeLine()
            : base(Definition.TableName)
        {
        }

        public ProductTreeLine(string pCompanyDb)
            : this( )
        {
            DBName = pCompanyDb;
        }

        public ProductTreeLine(ProductTreeLine pProductTreeLine)
            : this()
        {
            this.CopyBy(pProductTreeLine);
        }

        

        

        public string Father
        {
            get { return m_Father.GetString(); }
            set { m_Father.Value = value; }
        }

        public int ChildNum
        {
            get { return m_ChildNum.GetInt32(); }
            set { m_ChildNum.Value = value; }
        }

        public string Code
        {
            get { return m_Code.GetString(); }
            set { m_Code.Value = value; }
        }

        public int Quantity
        {
            get { return m_Quantity.GetInt32(); }
            set { m_Quantity.Value = value; }
        }
        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }
        
        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="pFather">Código da estrutura de produtos.</param>
        /// <param name="pChildNum">Código da linha.</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public bool GetByKey(string pFather, int pChildNum)
        {
            this.Father = pFather;
            this.ChildNum = pChildNum;
            return GetByKey();
        }
        

        
        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de ProductTreeLine.</returns>
        public List<ProductTreeLine> GetAll()
        {
            return FillCollection<ProductTreeLine>(this.GetData().Rows);
        }
        

        
    }
}
