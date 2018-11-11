using System.Data;

namespace Nampula.DI.Test.LogsTestes
{
    class FakeTableWithLog : TableAdapter
    {
        TableAdapterField _id = new TableAdapterField("Id", "Id", DbType.Int32, 11, null, true, true);
        TableAdapterField _description = new TableAdapterField("Description", "Descrição", 200);

        public FakeTableWithLog()
            : base("Fake", autoLog: true)
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
    }
}
