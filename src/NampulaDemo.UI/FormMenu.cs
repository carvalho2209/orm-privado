using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.UI;
using System.Threading;

namespace TaxOne.Logon
{
    public class FormMenu : FormSystem
    {
        #region UniqueIDType
        /// <summary>
        /// IDs relacionado a customização do iris
        /// </summary>
        public struct UniqueID
        {
            public const string cmdOption = "opt";
            public const string lblCompany = "cmp";
        }
        #endregion

        #region Construtores
        /// <summary>
        /// Construtor padrão
        /// </summary>
        public FormMenu ( )
            : base( 169, 0 )
        {
            InitializeItems( );            
            //EntitySelection.Instace.OnChangeCurrentCompany += new EventHandler( Instace_OnChangeCurrentCompany );
        }
        #endregion

        void Instace_OnChangeCurrentCompany ( object sender, EventArgs e )
        {
            var itmcompany = GetItem( UniqueID.lblCompany );
            var txtcompany = itmcompany.Specific as SAPbouiCOM.StaticText;

            //txtcompany.Caption = EntitySelection.Instace.Entity.NomeFantasia;
        }

        #region FormLoad
        /// <summary>
        /// Método para caputra de evento FORM_LOAD do SAP
        /// </summary>
        /// <param name="pEvent">Argumentos do Evento</param>
        /// <param name="bubleevent">Propagar execução do evento</param>
        [FormSystemEventAttribute( EventType = BoEventTypes.et_FORM_LOAD )]
        public void FormLoad ( ItemEvent pEvent, bool bubleevent )
        {
            InitializeItems( );
        }
        #endregion

        #region InitiaizeItems
        /// <summary>
        /// Carrega todos os itens na tela
        /// </summary>
        private void InitializeItems ( )
        {
            SAPbouiCOM.Item itmOption = null;
            try
            {
                itmOption = GetItem( UniqueID.cmdOption );
            }
            catch { }

            if ( itmOption == null )
            {
                AddItem( UniqueID.cmdOption, SAPbouiCOM.BoFormItemTypes.it_BUTTON );
                itmOption = GetItem( UniqueID.cmdOption );
            }

            SAPbouiCOM.Button cmdOption = itmOption.Specific as SAPbouiCOM.Button;

            itmOption.Top = 5;
            itmOption.Width = 20;
            itmOption.Left = this.FormBind.Width - itmOption.Width - 10;
            cmdOption.Caption = "...";

            SAPbouiCOM.Item itmCompany = null;
            try
            {
                itmCompany = GetItem( UniqueID.lblCompany );
            }
            catch { }

            if ( itmCompany == null )
            {
                AddItem( UniqueID.lblCompany, SAPbouiCOM.BoFormItemTypes.it_STATIC );
                itmCompany = GetItem( UniqueID.lblCompany );
            }

            var txtCompany = itmCompany.Specific as SAPbouiCOM.StaticText;
            txtCompany.Caption = "Não Selecionado";
            itmCompany.Left = 5;
            itmCompany.Top = 0;
            itmCompany.Width = this.FormBind.Width - 35;
            itmCompany.Height = 20;

        }
        #endregion

        #region FormLoad
        /// <summary>
        /// Método para caputra de evento FORM_LOAD do SAP
        /// </summary>
        /// <param name="pEvent">Argumentos do Evento</param>
        /// <param name="bubleevent">Propagar execução do evento</param>
        [FormSystemEventAttribute( ItemID = UniqueID.cmdOption, EventType = BoEventTypes.et_CLICK )]
        public void cmdOption_Click ( ItemEvent pEvent, bool bubleevent )
        {
            try
            {
                var form = new FormChooseCompany( );
                form.ShowSystemModel( );
            }
            catch ( Exception ex )
            {
                ShowMessageError( ex );
            }
        }
        #endregion

        //#region ShowOption
        ///// <summary>
        ///// Carrega a tela de opções do sistema
        ///// </summary>
        //private void ShowOption ( )
        //{

        //}
        //#endregion

        //#region ShowOptionThread
        ///// <summary>
        ///// Exibir o formulário de opções (Método usado para ser chamado de uma nova Tread)
        ///// </summary>
        ///// <param name="pTest">Um Objeto</param>
        //private void ShowOptionThread ( object pTest )
        //{
        //    var form = new frmChooseCompany();
        //    form.Show( );
        //    do
        //    {
        //        Thread.Sleep( 100 );
        //        System.Windows.Forms.Application.DoEvents( );
        //    } while ( form.Visible );
            
        //    if ( form.DialogResult == System.Windows.Forms.DialogResult.OK )
        //    {
        //        //EntitySelection.Instace.SetCompany( form.EntityID );
        //    }
        //}
        //#endregion
    }
}
