using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nampula.DI.B1.Equipaments
{

    /// <summary>
    /// Tabela de Cartão de Equipamentos do Cliente
    /// </summary>
    public class CustomerCardEquipament : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OINS";
        }

        public struct FieldsName
        {
            public static readonly string insID = "insID";
            public static readonly string customer = "customer";
            public static readonly string custmrName = "custmrName";
            public static readonly string contactCod = "contactCod";
            public static readonly string directCsmr = "directCsmr";
            public static readonly string drctCsmNam = "drctCsmNam";
            public static readonly string manufSN = "manufSN";
            public static readonly string internalSN = "internalSN";
            public static readonly string warranty = "warranty";
            public static readonly string wrrntyStrt = "wrrntyStrt";
            public static readonly string wrrntyEnd = "wrrntyEnd";
            public static readonly string responsVal = "responsVal";
            public static readonly string responsUnt = "responsUnt";
            public static readonly string itemCode = "itemCode";
            public static readonly string itemName = "itemName";
            public static readonly string itemGroup = "itemGroup";
            public static readonly string manufDate = "manufDate";
            public static readonly string delivery = "delivery";
            public static readonly string deliveryNo = "deliveryNo";
        }

        public struct FieldsDescription
        {
            public static readonly string insID = "Nº";
            public static readonly string customer = "Código do Cliente";
            public static readonly string custmrName = "Nome do Cliente";
            public static readonly string contactCod = "Pessoa de Contato";
            public static readonly string manufSN = "N° de Série do Fabricante";
            public static readonly string internalSN = "N° de Série";
            public static readonly string itemCode = "N° do Item";
            public static readonly string itemName = "Descrição do Item";            
        }

        TableAdapterField m_insID = new TableAdapterField(FieldsName.insID, FieldsDescription.insID, DbType.Int32, 11, 0, true, true);
        TableAdapterField m_customer = new TableAdapterField(FieldsName.customer, FieldsDescription.customer, 30);
        TableAdapterField m_custmrName = new TableAdapterField(FieldsName.custmrName, FieldsDescription.custmrName, 250);
        TableAdapterField m_contactCod = new TableAdapterField(FieldsName.contactCod, FieldsDescription.contactCod, DbType.Int16);
        TableAdapterField m_manufSN = new TableAdapterField(FieldsName.manufSN, FieldsDescription.manufSN, 32);
        TableAdapterField m_internalSN = new TableAdapterField(FieldsName.internalSN, FieldsDescription.internalSN, 32);
        TableAdapterField m_itemCode = new TableAdapterField(FieldsName.itemCode, FieldsDescription.itemCode, 40);
        TableAdapterField m_itemName = new TableAdapterField(FieldsName.itemName, FieldsDescription.itemName, 250);

        public CustomerCardEquipament()
            : base(Definition.TableName)
        {
        }

        public CustomerCardEquipament(string companyDb)
            : this()
        {
            DBName = companyDb;
        }

        public CustomerCardEquipament(CustomerCardEquipament pCustomerCardEquipament)
            : this()
        {
            this.CopyBy(pCustomerCardEquipament);
        }

        public int insID
        {
            get { return m_insID.GetInt32(); }
            set { m_insID.Value = value; }
        }

        public String customer
        {
            get { return m_customer.GetString(); }
            set { m_customer.Value = value; }
        }

        public String custmrName
        {
            get { return m_custmrName.GetString(); }
            set { m_custmrName.Value = value; }
        }

        public Int32 contactCod
        {
            get { return m_contactCod.GetInt32(); }
            set { m_contactCod.Value = value; }
        }

        public string manufSN
        {
            get { return m_manufSN.GetString(); }
            set { m_manufSN.Value = value; }
        }

        public String internalSN
        {
            get { return m_internalSN.GetString(); }
            set { m_internalSN.Value = value; }
        }

        public String ItemCode
        {
            get { return m_itemCode.GetString(); }
            set { m_itemCode.Value = value; }
        }

        public String itemName
        {
            get { return m_itemName.GetString(); }
            set { m_itemName.Value = value; }
        }

    }
}
