using System;
using System.Text;
using System.Data;
using Nampula.Framework;
using System.Linq;

namespace Nampula.DI
{    
    public class Navigation : DataObject
    {
        public const int NoCurrent = -1;
        private readonly TableAdapter _tableObj;

        public event EventHandler OnLastRecord;
        public event EventHandler OnFirstRecord;

        public Navigation(TableAdapter pTableAdapter)
        {
            _tableObj = pTableAdapter;
        }

        public bool HasRows()
        {
            DataTable pData = ExecuteCommand(GetSelectCommand(eMoveCommand.Rows, 0));
            return (pData.Rows[0][0].To<Int32>() > 0);
        }

        public int MoveFirst()
        {
            if (!HasRows())
                return NoCurrent;

            var pData = ExecuteCommand(GetSelectCommand(eMoveCommand.MoveFirst, 0));

            return int.Parse(pData.Rows[0][0].ToString());
        }

        public int MoveLast()
        {
            if (!HasRows())
                return NoCurrent;

            DataTable pData = ExecuteCommand(GetSelectCommand(eMoveCommand.MoveLast, 0));
            return int.Parse(pData.Rows[0][0].ToString());
        }

        public int MoveNext(int pId)
        {
            if (!HasRows())
                return NoCurrent;

            var pData = ExecuteCommand(GetSelectCommand(eMoveCommand.MoveNext, pId));

            if (pData.Rows.Count > 0)
            {
                return int.Parse(pData.Rows[0][0].ToString());
            }

            if (OnLastRecord != null)
            {
                OnLastRecord(this, new EventArgs());
            }

            return MoveFirst();
        }

        public int MovePrevious(int id)
        {
            if (!HasRows()) 
                return NoCurrent;

            var pData = ExecuteCommand(GetSelectCommand(eMoveCommand.MovePrevious, id));

            if (pData.Rows.Count > 0)
            {
                return int.Parse(pData.Rows[0][0].ToString());
            }

            if (OnFirstRecord != null)
            {
                OnFirstRecord(this, new EventArgs());
            }

            return MoveLast();

            //return (int)pData.Rows[0][0];
        }

        public int MoveTo(int id)
        {
            if (!HasRows())
                return NoCurrent;

            var pData = ExecuteCommand(GetSelectCommand(eMoveCommand.MoveTo, id));
            return int.Parse(pData.Rows[0][0].ToString());
        }

        private string GetSelectCommand(eMoveCommand pCommand, int pId)
        {

            var query = new StringBuilder();
            String tableName = MakeFullTableName(_tableObj.DBName, _tableObj.TableName);
            string keyFieldName = _tableObj.KeyFields.First().Name;

            switch (pCommand)
            {
                case eMoveCommand.MoveFirst:

                    query.AppendLine(" Select ");
                    query.AppendLine("     min(" + SetQuote(keyFieldName) + ") ");
                    query.AppendLine(" From ");
                    query.AppendLine("     " + tableName + " ");

                    break;
                case eMoveCommand.MovePrevious:

                    query.AppendLine(" Select TOP 1 ");
                    query.AppendLine("     " + SetQuote(keyFieldName) + " ");
                    query.AppendLine(" From ");
                    query.AppendLine("     " + tableName + "");
                    query.AppendLine(" Where ");
                    query.AppendLine("     " + SetQuote(keyFieldName) + " < '" + pId + "'");
                    query.AppendLine(" Order By ");
                    query.AppendLine("     " + SetQuote(keyFieldName) + " DESC ");
                    //_Query.AppendLine(" Limit 1 ");

                    break;
                case eMoveCommand.MoveNext:

                    query.AppendLine(" Select TOP 1  ");
                    query.AppendLine("     " + SetQuote(keyFieldName) + " ");
                    query.AppendLine(" From ");
                    query.AppendLine("     " + tableName + " ");
                    query.AppendLine(" Where ");
                    query.AppendLine("     " + SetQuote(keyFieldName) + " > '" + pId + "'");
                    query.AppendLine(" Order By ");
                    query.AppendLine("     " + SetQuote(keyFieldName) + " ASC ");
                    //_Query.AppendLine(" Limit 1 ");

                    break;
                case eMoveCommand.MoveLast:

                    query.AppendLine(" Select ");
                    query.AppendLine("     Max(" + SetQuote(keyFieldName) + ") ");
                    query.AppendLine(" From ");
                    query.AppendLine("     " + tableName + " ");

                    break;
                case eMoveCommand.Rows:

                    query.AppendLine(" Select ");
                    query.AppendLine("     Count(" + SetQuote(keyFieldName) + ") ");
                    query.AppendLine(" From ");
                    query.AppendLine("     " + tableName + " ");

                    break;

                case eMoveCommand.MoveTo:

                    query.AppendLine(" Select ");
                    query.AppendLine("     " + SetQuote(keyFieldName) + " ");
                    query.AppendLine(" From ");
                    query.AppendLine("     " + tableName + " ");
                    query.AppendLine(" Where ");
                    query.AppendLine("     " + SetQuote(keyFieldName) + " = '" + pId + "'");
                    break;
            }

            return query.ToString();
        }

        private DataTable ExecuteCommand(String pQuery)
        {
            return Connection.SqlServerQuery(pQuery);
        }


        //private TableAdapter m_TableAdapter;
        //public TableAdapter TableAdapter
        //{
        //    get
        //    {
        //        return m_TableAdapter;
        //    }
        //    set
        //    {
        //        m_TableAdapter = value;
        //        _TableName = m_TableAdapter.FullTableName();
        //        _KeyFieldName = m_TableAdapter.KeyFields[0].Name;
        //    }
        //}
    }
}
