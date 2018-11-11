using System.Data;

namespace Nampula.DI.Test.QueryTests
{
    class FakeTableForQuery : TableAdapter
    {
        TableAdapterField _id = new TableAdapterField("Id", "Id", DbType.Int32, 11, null, true, false);
        TableAdapterField _description = new TableAdapterField("Description", "Descrição", 200);

        public FakeTableForQuery()
            : base("FakeTableForQuery")
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
