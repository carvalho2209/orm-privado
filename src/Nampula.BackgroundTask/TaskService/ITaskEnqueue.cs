using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.BackgroundTask.TaskService
{
    /// <summary>
    /// Interface para recuperar novas tasrefas que precisem ser executadas
    /// </summary>
    public interface ITaskEnqueue
    {
        /// <summary>
        /// Pega uma lista de tarefas.
        /// </summary>
        /// <returns></returns>
        List<ITask> GetTasks ( );
    }
}
