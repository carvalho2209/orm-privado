using System;
using System.Threading;
using System.Windows.Forms;

namespace Nampula.UI.Helpers
{
    /// <summary>
    /// Formulário que exibe uma mensagem de espera
    /// </summary>
    public partial class WaitingStatusForm : Nampula.UI.Form
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public WaitingStatusForm()
        {
            InitializeComponent();
        }        

        /// <summary>
        /// Atribui uma mensagem para ser exibido na tela de progresso
        /// </summary>
        /// <param name="message">Uma string com a mensagem</param>
        public void SetMessage(string message)
        {
            statusLabel.Text = message;
            statusLabel.Invalidate(true);
        }
    }
}
