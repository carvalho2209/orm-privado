using Nampula.DI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Nampula.UI
{

    /// <summary>
    /// Uma implementação de aplicação
    /// </summary>
    public interface IApplication
    {

        /// <summary>
        /// Inicia uma conexão com a instancia do SAP
        /// </summary>
        /// <param name="pNameSpace">Aplicação</param>
        /// <returns>True if connected</returns>
        bool StartApplication(string pNameSpace);

        DialogResult MessageBox(string Text, MessageBoxButtons buttons, MessageBoxIcon icon);
        DialogResult MessageBox(string Text, MessageBoxIcon icon);
        DialogResult MessageBox(string Text);

        /// <summary>
        /// Lista de Addon Identifiers, para ser gerado sem licença
        /// </summary>
        List<string> AddonIdentifiers { get; set; }
        Company Company { get; set; }
        Desktop Desktop { get; set; }
        List<Form> Forms { get; }
        BoLanguages Language { get; set; }
        List<MenuItem> Menus { get; set; }
        bool CheckHostedEnvironment { get; set; }
        /// <summary>
        /// Identifica se o SAP está rodando sobre o CCC
        /// </summary>
        bool IsHostedEnvironment { get; set; }
        
        event ApplicationEventHandler AppEvent;
        event ApplicationEventHandler FormDataEvent;
        event ApplicationEventHandler ItemEvent;
        event ApplicationEventHandler MenuEvent;
        event ApplicationEventHandler PrintEvent;
        event ApplicationEventHandler ProgressBarEvent;
        event ApplicationEventHandler ReportDataEvent;
        event ApplicationEventHandler RightClickEvent;
        event ApplicationEventHandler StatusBarEvent;
        event ApplicationEventHandler OnStartConnection;
        event ApplicationEventHandler OnStartCreateMenu;
        event ApplicationEventHandler OnShutDown;
        event ApplicationEventHandler OnChangeCompany;

        FormMain MainForm();

        IntPtr GetMdiWindowHandle();

        void StatusBar(string Text, BoMessageTime Seconds, BoStatusBarMessageType Type);

        void PerformLinkedButton(object sender, LinkedButtonEventArgs Event);

        void AddMenu(string pFatherMenu, MenuItem pMenuItem);

        MenuItem GetMenu(string pMenuID);

        ConnectionParameter GetParam();
    }

}
