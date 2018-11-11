using System;
using System.Collections.Generic;
using System.Data;
using Nampula.DI.B1.Documents;
using Nampula.Framework;

namespace Nampula.DI.B1.BatchNumbers
{

    public class BatchNumber : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OIBT";
        }
        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string ItemCode = "ItemCode";
            public static readonly string BatchNum = "BatchNum";
            public static readonly string WhsCode = "WhsCode";
            public static readonly string ExpDate = "ExpDate";
            public static readonly string PrdDate = "PrdDate";
            public static readonly string InDate = "InDate";
            public static readonly string Quantity = "Quantity";
            public static readonly string BaseType = "BaseType";
            public static readonly string BaseEntry = "BaseEntry";
            public static readonly string BaseNum = "BaseNum";
            public static readonly string BaseLinNum = "BaseLinNum";
            public static readonly string Status = "Status";
            public static readonly string Direction = "Direction";
            public static readonly string IsCommited = "IsCommited";
            public static readonly string OnOrder = "OnOrder";
            public static readonly string Consig = "Consig";
            public static readonly string IntrSerial = "IntrSerial";
            public static readonly string SuppSerial = "SuppSerial";           
            public static readonly string Notes = "Notes";
            public static readonly string SysNumber = "SysNumber";
            public static readonly string Located = "Located";
            
        }
        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string ItemCode = "Código do Item";
            public static readonly string BatchNum = "Nº do Lote";
            public static readonly string WhsCode = "Deposito";
            public static readonly string ExpDate = "Date de Validade";
            public static readonly string PrdDate = "Data de Fábricação";
            public static readonly string InDate = "Data de Entrada";
            public static readonly string Quantity = "Quantidade";
            public static readonly string BaseType = "Doc. de Origem";
            public static readonly string BaseEntry = "Nº Int. do Documento";
            public static readonly string BaseNum = "Nº do Documento";
            public static readonly string BaseLinNum = "Linha do Documento";
            public static readonly string Status = "Status";
            public static readonly string Direction = "Direção";
            public static readonly string IsCommited = "IsCommited";
            public static readonly string OnOrder = "OnOrder";
            public static readonly string Consig = "Consig";

            public static readonly string IntrSerial = "Atríbuto do Lote 1";
            public static readonly string SuppSerial = "Atríbuto do Lote 2";            
            public static readonly string Notes = "Detalhes";
            public static readonly string SysNumber = "Nº do Sistema";
            public static readonly string Located = "Localização";
        }
        
        TableAdapterField m_ItemCode = new TableAdapterField(FieldsName.ItemCode, FieldsDescription.ItemCode, DbType.String, 20, 0, true, false);
        TableAdapterField m_BatchNum = new TableAdapterField(FieldsName.BatchNum, FieldsDescription.BatchNum, DbType.String, 32, 0, true, false);
        TableAdapterField m_WhsCode = new TableAdapterField(FieldsName.WhsCode, FieldsDescription.WhsCode, DbType.String, 8, 0, true, false);
        TableAdapterField m_ExpDate = new TableAdapterField(FieldsName.ExpDate, FieldsDescription.ExpDate, DbType.DateTime);
        TableAdapterField m_PrdDate = new TableAdapterField(FieldsName.PrdDate, FieldsDescription.PrdDate, DbType.DateTime);
        TableAdapterField m_InDate = new TableAdapterField(FieldsName.InDate, FieldsDescription.InDate, DbType.DateTime);
        TableAdapterField m_Quantity = new TableAdapterField(FieldsName.Quantity, FieldsDescription.Quantity, DbType.Decimal);
        TableAdapterField m_BaseType = new TableAdapterField(FieldsName.BaseType, FieldsDescription.BaseType, DbType.Int32);
        TableAdapterField m_BaseEntry = new TableAdapterField(FieldsName.BaseEntry, FieldsDescription.BaseEntry, DbType.Int32);
        TableAdapterField m_BaseNum = new TableAdapterField(FieldsName.BaseNum, FieldsDescription.BaseNum, DbType.Int32);
        TableAdapterField m_BaseLinNum = new TableAdapterField(FieldsName.BaseLinNum, FieldsDescription.BaseLinNum, DbType.Int32);
        TableAdapterField m_Status = new TableAdapterField(FieldsName.Status, FieldsDescription.Status, DbType.Int32);
        TableAdapterField m_Direction = new TableAdapterField(FieldsName.Direction, FieldsDescription.Direction, DbType.Int32);
        TableAdapterField m_IsCommited = new TableAdapterField(FieldsName.IsCommited, FieldsDescription.IsCommited, DbType.Decimal);
        TableAdapterField m_OnOrder = new TableAdapterField(FieldsName.OnOrder, FieldsDescription.OnOrder, DbType.Decimal);
        TableAdapterField m_Consig = new TableAdapterField(FieldsName.Consig, FieldsDescription.Consig, DbType.Decimal);

        TableAdapterField m_IntrSerial = new TableAdapterField(FieldsName.IntrSerial, FieldsDescription.IntrSerial, 32);
        TableAdapterField m_SuppSerial = new TableAdapterField(FieldsName.SuppSerial, FieldsDescription.SuppSerial, 32);
        TableAdapterField m_Notes = new TableAdapterField(FieldsName.Notes, FieldsDescription.Notes, 1000);
        //TableAdapterField m_SysNumber = new TableAdapterField(FieldsName.SysNumber, FieldsDescription.SysNumber, DbType.Int32);
        TableAdapterField m_Located = new TableAdapterField(FieldsName.Located, FieldsDescription.Located, 100);

        public BatchNumber()
            : base(Definition.TableName)
        {
            //if (IsSap2007)
            //    Collumns.Remove(m_SysNumber);
        }

        public BatchNumber(string pCompanyDb)
            : this()
        {
            DBName = pCompanyDb;
        }

        public BatchNumber(BatchNumber pBatchNumberForItem)
            : this()
        {
            CopyBy(pBatchNumberForItem);
        }

        public string ItemCode
        {
            get { return m_ItemCode.GetString(); }
            set { m_ItemCode.Value = value; }
        }

        public string BatchNum
        {
            get { return m_BatchNum.GetString(); }
            set { m_BatchNum.Value = value; }
        }

        public string WhsCode
        {
            get { return m_WhsCode.GetString(); }
            set { m_WhsCode.Value = value; }
        }

        public DateTime ExpDate
        {
            get { return m_ExpDate.GetDateTime(); }
            set { m_ExpDate.Value = value; }
        }

        public DateTime PrdDate
        {
            get { return m_PrdDate.GetDateTime(); }
            set { m_PrdDate.Value = value; }
        }

        public DateTime InDate
        {
            get { return m_InDate.GetDateTime(); }
            set { m_InDate.Value = value; }
        }

        public decimal Quantity
        {
            get { return m_Quantity.GetDecimal(); }
            set { m_Quantity.Value = value; }
        }

        public eDocumentObjectType BaseType
        {
            get { return m_BaseType.GetInt32().ToDocumentObjectTypeEnum(); }
            set { m_BaseType.Value = value.ToInt32(); }
        }

        public int BaseEntry
        {
            get { return m_BaseEntry.GetInt32(); }
            set { m_BaseEntry.Value = value; }
        }

        public int BaseNum
        {
            get { return m_BaseNum.GetInt32(); }
            set { m_BaseNum.Value = value; }
        }

        public int BaseLinNum
        {
            get { return m_BaseLinNum.GetInt32(); }
            set { m_BaseLinNum.Value = value; }
        }

        public BatchNumberStatusType Status
        {
            get { return (BatchNumberStatusType)m_Status.GetInt32(); }
            set { m_Status.Value = value.To<Int32>(); }
        }

        public BatchNumberDirectionType Direction
        {
            get { return (BatchNumberDirectionType)m_Direction.GetInt32(); }
            set { m_Direction.Value = value.To<Int32>(); }
        }

        public decimal IsCommited
        {
            get { return m_IsCommited.GetDecimal(); }
            set { m_IsCommited.Value = value; }
        }

        public decimal OnOrder
        {
            get { return m_OnOrder.GetDecimal(); }
            set { m_OnOrder.Value = value; }
        }

        public decimal Consig
        {
            get { return m_Consig.GetDecimal(); }
            set { m_Consig.Value = value; }
        }

        public String IntrSerial
        {
            get { return m_IntrSerial.GetString(); }
            set { m_IntrSerial.Value = value; }
        }

        public String SuppSerial
        {
            get { return m_SuppSerial.GetString(); }
            set { m_SuppSerial.Value = value; }
        }

        public String Notes
        {
            get { return m_Notes.GetString(); }
            set { m_Notes.Value = value; }
        }

        //public Int32 SysNumber
        //{
        //    get { return m_SysNumber.GetInt32(); }
        //    set { m_SysNumber.Value = value; }
        //}

        public String Located
        {
            get { return m_Located.GetString(); }
            set { m_Located.Value = value; }
        }

        //public static bool IsSap2007 { get; set; }

        public bool GetByKey(string pItemCode, string pWhsCode, string pBatchNumber)
        {
            ItemCode = pItemCode;
            WhsCode = pWhsCode;
            BatchNum = pBatchNumber;
            return GetByKey();
        }

        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de BatchNumberForItem.</returns>
        public List<BatchNumber> GetAll()
        {
            return FillCollection<BatchNumber>();
        }

        /// <summary>
        /// Pegar todos os lotes que forem do item e do deposito informado ordenado por data de validade onde a quantidade for maior que zero
        /// </summary>
        /// <param name="pWhsCode">Código do Deposito</param>
        /// <param name="pItemCode">Código do Item</param>
        /// <param name="pQuantidadeGraterThan">Somente com quantidade Maior que</param>
        /// <returns>Lista de Lotes</returns>
        public List<BatchNumber> GetByItem(string pWhsCode, string pItemCode, decimal pQuantidadeGraterThan)
        {

            var myQuery = new TableQuery(this);

            myQuery.Where.Add(new QueryParam(m_WhsCode, pWhsCode));
            myQuery.Where.Add(new QueryParam(m_ItemCode, pItemCode));
            myQuery.Where.Add(new QueryParam(m_Quantity, eCondition.ecGraterThan, pQuantidadeGraterThan));

            myQuery.OrderBy.Add(
                new OrderBy(
                    new QueryParam(m_ExpDate)));

            return FillCollection<BatchNumber>(myQuery);
        }


    }
}
