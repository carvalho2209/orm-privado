using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using log4net;

namespace Nampula.BackgroundTask.TaskService
{
    internal class TaskQueue : IDisposable
    {
        #region Variáveis

        EventWaitHandle wait = new AutoResetEvent( false );

        Queue<ITask> taskQueue = new Queue<ITask>( );
        readonly object syncLock = new object( );
        private static readonly ILog log = LogManager.GetLogger( typeof( TaskQueue ).Name );

        #endregion

        #region Construtores

        public TaskQueue ( )
        {
            Thread t = new Thread( this.Work );
            t.Start( );
            if ( log.IsDebugEnabled )
                log.Debug( "Construtor iniciado" );
        }

        #endregion

        #region Métodos

        #region EnqueueTask
        /// <summary>
        /// Adiciona tarefas na fila.
        /// </summary>
        /// <param name="pTask">Uma tarefa.</param>
        public void EnqueueTask ( ITask pTask )
        {
            if ( log.IsDebugEnabled )
                log.DebugFormat( "Enfileiramento de tarefa : {0}", pTask.TaskID );

            lock ( syncLock )
                taskQueue.Enqueue( pTask );

            wait.Set( );
        }
        #endregion

        #region Work
        /// <summary>
        /// Executa as tarefas.
        /// </summary>
        private void Work ( )
        {
            var count = 0;
            while ( true )
            {
                lock ( syncLock )
                {
                    if ( taskQueue.Count > 0 )
                    {
                        var task = taskQueue.Dequeue( );

                        if ( log.IsDebugEnabled )
                            log.DebugFormat( "Executar Tarefa [{0}] - TaskID [{1}]", task.ToString( ), task.TaskID );

                        task.Execute( );
                    }

                    count = taskQueue.Count;
                }

                if ( count == 0 )
                    wait.WaitOne( );
            }
        }
        #endregion

        #region TaskCount
        /// <summary>
        /// Retorna a quantidade de tarefas na fila.
        /// </summary>
        /// <returns></returns>
        public int TaskCount ( )
        {
            var count = 0;

            lock ( syncLock )
                count = taskQueue.Count;

            return count;
        }
        #endregion

        #region Dispose
        /// <summary>
        /// Libera os recursos do objeto.
        /// </summary>
        public void Dispose ( )
        {
            if ( log.IsInfoEnabled )
                log.InfoFormat( "Liberando recursos" );

            wait.Close( );
            taskQueue.Clear( );
        }
        #endregion

        #endregion
    }
}
