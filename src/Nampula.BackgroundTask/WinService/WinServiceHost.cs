using System;
using System.ServiceProcess;
using log4net;
using Nampula.BackgroundTask.TaskService;

namespace Nampula.BackgroundTask.WinService
{
    public partial class WinServiceHost : ServiceBase
    {

        private static readonly ILog Log = LogManager.GetLogger(typeof(WinServiceHost).Name);

        public WinServiceHost()
        {

        }

        public WinServiceHost(string pServiceName)
        {
            InitializeComponent();
            ServiceName = pServiceName;
            AutoLog = true;
        }

        /// <summary>
        /// Especifica a ação a ser tomada quando o serviço inicia.
        /// </summary>
        /// <param name="args">Dados passados pelo comando de início.</param>
        protected override void OnStart(string[] args)
        {
            try
            {
                ExitCode = 1;

                Log.Info("Iniciando serviço...");

                TaskManager.Instance.Start();

                base.OnStart(args);

                Log.Info("Serviço iniciado");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex.Message, ex);
            }
        }

        /// <summary>
        /// Especifica a ação a ser tomada quando o serviço é parado.
        /// </summary>
        protected override void OnStop()
        {
            Log.Info("Parando serviço...");

            // Para as tarefas
            TaskManager.Instance.Stop();

            ExitCode = 0;
            base.OnStop();

            Log.Info("Serviço parado...");
        }
    }
}
