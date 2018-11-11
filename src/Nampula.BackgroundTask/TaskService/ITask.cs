using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.BackgroundTask.TaskService
{
    /// <summary>
    /// Classe para tratamento das tarefas
    /// </summary>
    public interface ITask
    {
        /// <summary>
        /// ID exclusido de uma tarefa
        /// </summary>
        object TaskID { get; }
        /// <summary>
        /// Método que chama a execução da tarefa
        /// </summary>
        void Execute();
    }
}
