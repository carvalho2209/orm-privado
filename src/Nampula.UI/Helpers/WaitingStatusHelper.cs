using System;
using System.Threading;
using System.Windows.Forms;

namespace Nampula.UI.Helpers
{
    /// <summary>
    /// Exibir formulário de processamento demorado
    /// </summary>
    public static class WaitingStatusHelper
    {
        /// <summary>
        /// Exibe uma mensagem de aguarde enquanto uma determinada ação é processada
        /// </summary>
        /// <param name="waintiAction">CallBack da Ação</param>
        /// <param name="progressMessage">Mensagem para ser exibido na tela</param>
        public static void WaintigFor(Action waintiAction, string progressMessage = null)
        {
            using (var form = new WaitingStatusForm())
            {
                if (!string.IsNullOrWhiteSpace(progressMessage))
                    form.SetMessage(progressMessage);

                var savedCursor = Cursor.Current;

                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    System.Windows.Forms.Application.DoEvents();

                    var thread = new Thread(waintiAction.Invoke);
                    thread.Start();

                    var waintUntilFor = DateTime.Now.AddSeconds(2);

                    while (thread.IsAlive)
                    {
                        Thread.Sleep(500);

                        if (form.Visible)
                            continue;

                        if(DateTime.Now < waintUntilFor)
                            continue;

                        form.Show();
                        form.Refresh();

                        System.Windows.Forms.Application.DoEvents();

                        thread.Join();
                    }

                    form.Close();

                }
                finally
                {
                    Cursor.Current = savedCursor;
                    form.Close();
                }
            }
        }
    }
}
