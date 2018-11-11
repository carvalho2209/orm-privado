using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.DI.B1.Itens
{
    public class ItemProperties : TableAdapter
    {
        public struct FieldsName
        {
            public const string ItmsTypCod = "ItmsTypCod";
            public const string ItmsGrpNam = "ItmsGrpNam";
            public const string UserSign = "UserSign";
        }

        public struct Description
        {
            public const string ItmsTypCod = "Código";
            public const string ItmsGrpNam = "Nome";
            public const string UserSign = "Usuário";
        }

        TableAdapterField m_ItmsTypCod = new TableAdapterField(FieldsName.ItmsTypCod, Description.ItmsTypCod, System.Data.DbType.Int32, 11, 0, true, false);
        TableAdapterField m_ItmsGrpNam = new TableAdapterField(FieldsName.ItmsGrpNam, Description.ItmsGrpNam, 50);
        TableAdapterField m_UserSign = new TableAdapterField(FieldsName.UserSign, Description.UserSign, System.Data.DbType.Int32);

        public ItemProperties()
            : base("OITG")
        {

        }

        public ItemProperties(string pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        public ItemProperties(ItemProperties pItemProperties)
            : this(pItemProperties.DBName)
        {

            this.CopyBy(pItemProperties);
        }

        
        public int ItmsTypCod
        {
            get { return m_ItmsTypCod.GetInt32(); }
            set { m_ItmsTypCod.Value = value; }
        }

        public string ItmsGrpNam
        {
            get { return m_ItmsGrpNam.GetString(); }
            set { m_ItmsGrpNam.Value = value; }
        }

        public int UserSign
        {
            get { return m_UserSign.GetInt32(); }
            set { m_UserSign.Value = value; }
        }
        

        public bool GetByKey(int pID)
        {
            this.ItmsTypCod = pID;
            return GetByKey();
        }

        public List<ItemProperties> GetAll()
        {
            return FillCollection<ItemProperties>(GetData().Rows);
        }

        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }
    }
}
