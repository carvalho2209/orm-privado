using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nampula.DI.Test.LogsTestes
{
    class FakeTableWithLogWithThreFields : TableAdapter
    {
        TableAdapterField _id = new TableAdapterField("Id", "Id", DbType.Int32, 11, null, true, true);
        TableAdapterField _description = new TableAdapterField("Description", "Descrição", 200);
        TableAdapterField _dateAdd = new TableAdapterField("DateAdd", "Data de Adição", DbType.DateTime);

        public FakeTableWithLogWithThreFields()
            : base("FakeTableWithLogWithThreFields", autoLog: true)
        {
        }

        public int Id
        {
            get { return _id.GetInt32(); }
            set { _id.Value = value; }
        }

        public string Description
        {
            get { return _description.GetString(); }
            set { _description.Value = value; }
        }

        public DateTime DateAdd
        {
            get { return _dateAdd.GetDateTime(); }
            set { _dateAdd.Value = value; }
        }

    }
}
