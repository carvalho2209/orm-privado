using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Nampula.Framework;

namespace Nampula.DI
{
    /// <summary>
    /// Controle de Transações
    /// </summary>
    public class TransManager : IDisposable
    {
        readonly DbProviderFactory _provider = DbProviderFactories.GetFactory("System.Data.SqlClient");

        [ThreadStatic]
        private static object _lockObject;
        private static Object LockObject
        {
            get { return _lockObject ?? (_lockObject = new object()); }
        }

        [ThreadStatic]
        private static Dictionary<string, TransManager> _managers;
        private static Dictionary<string, TransManager> Managers
        {
            get { return _managers ?? (_managers = new Dictionary<string, TransManager>()); }
        }

        private readonly IDbConnection _connection;
        private int _referenceCount;
        private readonly string _name;
        private readonly bool _withTransaction;

        internal IDbTransaction Transaction { get; set; }
        private bool _inTransaction;

        /// <summary>
        /// Get new manager
        /// </summary>
        /// <returns></returns>
        public static TransManager GetTrans(string conectionName = "default", bool withTransaction = true)
        {
            lock (LockObject)
            {
                TransManager mgr;

                if (!Managers.TryGetValue(conectionName, out mgr))
                {
                    mgr = new TransManager(conectionName, withTransaction);
                    Managers.Add(conectionName, mgr);
                }

                mgr.AddRef();

                return mgr;
            }
        }

        private TransManager(string connectionName, bool withTransaction)
        {
            _name = connectionName;
            _withTransaction = withTransaction;

            _connection = _provider.CreateConnection();

            if (_connection == null)
                throw new Exception("Não foi possível instanciar uma nova conexão : {0}".Fmt(_provider));

            _connection.ConnectionString = DI.Connection.Instance.GetConnString();
            _connection.Open();

            if (withTransaction)
                Transaction = _connection.BeginTransaction(IsolationLevel.ReadCommitted);

            _inTransaction = true;
        }

        /// <summary>
        /// Conexão com o banco de dados
        /// </summary>
        public IDbConnection Connection
        {
            get { return _connection; }
        }

        private void AddRef()
        {
            _referenceCount += 1;
        }

        private void DeRef()
        {
            lock (LockObject)
            {
                _referenceCount -= 1;

                if (_referenceCount != 0)
                    return;

                if (_inTransaction)
                    RollBack();

                _connection.Dispose();

                Managers.Remove(_name);
            }
        }

        /// <summary>
        /// Commit trans
        /// </summary>
        public void Complete()
        {
            lock (LockObject)
            {
                if (_referenceCount > 1)
                    return;

                if (_withTransaction)
                    Transaction.Commit();

                _inTransaction = false;
            }

        }

        /// <summary>
        /// Commit trans
        /// </summary>
        public void RollBack()
        {
            if (_withTransaction)
                Transaction.Rollback();
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                DeRef();
            }
        }

        ~TransManager()
        {
            Dispose(false);
        }

        #endregion

    }
}
