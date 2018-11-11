using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nampula.UI.Helpers.Extentions
{
    /// <summary>
    /// Extenções uteis para interface
    /// </summary>
    public static class UtilityUiExtentions
    {
        
        /// <summary>
        /// Exibe uma mensagem de confirmação na tela para o usuário fechar ou não a tela corrente
        /// </summary>
        /// <param name="owner">Formulário</param>
        public static void ConfirmAndClose(this Form owner)
        {
            var message = "Dados não gravados serão perdidos. Deseja continuar ?";
            if (owner.ConfirmQuertion(message))
                owner.Close();
        }

        /// <summary>
        /// Exibe uma mensagem de confirmação na tela para o usuário
        /// com opção de passagem de parametros
        /// </summary>
        /// <param name="owner">Formulário</param>
        /// <param name="message">Mesagem no estilo do String</param>
        /// <param name="param">Lista de Parametros do ofrma</param>
        /// <returns></returns>
        public static bool ConfirmQuertion(this Form owner, string message, params object[] param)
        {
            var messageText = string.Format(message, param);
            return owner.MessageBox(messageText, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }


        /// <summary>
        /// Exibe uma mensagem de sucesso na barra de status
        /// </summary>
        /// <param name="owner">Formulário</param>
        /// <param name="message">Mensagem no estilo string.Format</param>
        /// <param name="param">Parametros da mesangem</param>
        public static void SetTextBarSucess(this Form owner, string message, params object[] param)
        {
            SetTextOnStatusBar(owner, message, BoStatusBarMessageType.smt_Success, param);
        }

        /// <summary>
        /// Exibe uma mensagem de alerta na barra de status
        /// </summary>
        /// <param name="owner">Formulário</param>
        /// <param name="message">Mensagem no estilo string.Format</param>
        /// <param name="param">Parametros da mesangem</param>
        public static void SetTextBarWarning(this Form owner, string message, params object[] param)
        {
            SetTextOnStatusBar(owner, message, BoStatusBarMessageType.smt_Warning, param);
        }

        /// <summary>
        /// Exibe uma mensagem de erro na barra de status
        /// </summary>
        /// <param name="owner">Formulário</param>
        /// <param name="message">Mensagem no estilo string.Format</param>
        /// <param name="param">Parametros da mesangem</param>
        public static void SetTextBarError(this Form owner, string message, params object[] param)
        {
            SetTextOnStatusBar(owner, message, BoStatusBarMessageType.smt_Error, param);
        }


        internal static void SetTextOnStatusBar(this Form owner, string message, BoStatusBarMessageType messageType, params object[] param)
        {
            var messageTest = string.Format(message, param);
            owner.SetTextOnStatusBar(messageTest, BoMessageTime.bmt_Short, messageType);
        }
    }
}
