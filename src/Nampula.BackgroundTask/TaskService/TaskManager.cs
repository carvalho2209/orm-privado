using System;
using System.Collections.Generic;
using System.Threading;
using log4net;
using Nampula.DI;

namespace Nampula.BackgroundTask.TaskService
{
    /// <summary>
    /// Classe para gerenciamento das tarefas a serem executadas
    /// </summary>
    public sealed class TaskManager
    {
        
        private static readonly TaskManager taskManager = new TaskManager();
        private static readonly ILog log = LogManager.GetLogger(typeof(TaskManager).Name);
        private static readonly Mutex mutex = new Mutex();
        private Timer timer;


        /// <summary>
        /// Construtor privado.
        /// </summary>
        private TaskManager()
        {
            //Seta valor padrão
            Period = 10;
            DueTime = 5;
        }

        /// <summary>
        /// Construtor privado estático.
        /// </summary>
        /// <remarks>
        /// Explicit static constructor to tell C# compiler not to mark type as beforefieldinit.
        /// </remarks>
        static TaskManager()
        {
            TaskEnqueues = new List<ITaskEnqueue>();
            
            log.Info("Construtor Iniciado");
        }

        /// <summary>
        /// Pega a instancia do gerenciador de tarefa
        /// </summary>
        public static TaskManager Instance
        {
            get { return taskManager; }
        }
        /// <summary>
        /// Infomase o serviço o timer está parado ou executando.
        /// </summary>
        public bool IsServiceRunning { get; private set; }

        /// <summary>
        /// Lista de enfilerador de tarefas
        /// </summary>
        public static List<ITaskEnqueue> TaskEnqueues { get; private set; }

        /// <summary>
        /// Tempo de atraso ao chamar rotina de CallBack
        /// </summary>
        public int DueTime { get; set; }
        /// <summary>
        /// Tempo de espera em segundos
        /// </summary>
        public int Period { get; set; }
        
        /// <summary>
        /// Adiciona um novo pesquisador de tarefas
        /// </summary>
        /// <param name="pTaskEnqueue">Novo origem enfileiramento de tarefas</param>
        public static void AddEnqueueTask(ITaskEnqueue pTaskEnqueue)
        {
            if (log.IsInfoEnabled)
                log.InfoFormat(
                    "Fila de tarefas {0}",
                    pTaskEnqueue.GetType().DeclaringType.Name);

            TaskEnqueues.Add(pTaskEnqueue);
        }
        
        /// <summary>
        /// Inicia o timer.
        /// </summary>
        public void Start()
        {
            if (!StartConnectionServer()) 
                return;

            timer = new Timer(
                Tick,
                null,
                TimeSpan.FromSeconds(DueTime),
                TimeSpan.FromSeconds(Period));

            this.IsServiceRunning = true;

            if (log.IsInfoEnabled)
                log.InfoFormat("tarefas iniciada: Period [{0}] seconds", Period);
        }
        

        
        /// <summary>
        /// Para o timer.
        /// </summary>
        public void Stop()
        {
            if (this.IsServiceRunning)
            {
                this.timer.Dispose();
                this.IsServiceRunning = false;
                if (log.IsInfoEnabled)
                    log.Info("tarefas parada");
            }
        }
        

        
        /// <summary>
        /// Método executado a cada tick do timer.
        /// </summary>
        /// <param name="data"></param>
        /// <remarks>This runs on a pooled thread</remarks>
        static void Tick(object data)
        {
            try
            {
                mutex.WaitOne();

                if (log.IsInfoEnabled)
                    log.InfoFormat("Verificando se existem novas tarefas.");

                foreach (var item in TaskEnqueues)
                {
                    foreach (var task in item.GetTasks())
                    {
                        if (log.IsInfoEnabled)
                            log.InfoFormat("Executando [{0}] - TaskID [{1}]", task, task.TaskID);

                        task.Execute();

                        if (log.IsInfoEnabled)
                            log.InfoFormat("Execução Finalizada [{0}] - TaskID [{1}]", task, task.TaskID);
                    }
                }

            }
            catch (Exception ex)
            {
                if (log.IsFatalEnabled)
                    log.Fatal("Ocorreu um erro fatal ao capturar novas tarefa", ex);
                TaskManager.Instance.Stop();
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
        

        
        /// <summary>
        /// Determina o servidor de banco de dados.
        /// </summary>
        private bool StartConnectionServer()
        {
            try
            {
                var conn = Connection.Instance;

                if (log.IsInfoEnabled)
                    log.InfoFormat(
                        "Tentativa de conexão em [{0}]",
                        conn.ConnectionParameter.Server);

                if (!string.IsNullOrEmpty(conn.ConnectionParameter.Server))
                    return conn.Connect();
            }
            catch (Exception ex)
            {
                if (log.IsFatalEnabled)
                    log.Fatal(ex.Message, ex);
            }

            return false;
        }
        

        
    }
}
