using System;
using Nampula.UI;

namespace NampulaDemo
{
    /// <summary>
    /// Representa a tela de parceiro de negócios
    /// </summary>
    public class BusinessPartnerForm : FormSystem
    {

        /// <summary>
        /// Construtor padrãp
        /// </summary>
        public BusinessPartnerForm ( )
            : base( 134 ) { }

        ///// <summary>
        ///// Método para caputra de evento FORM_LOAD do SAP
        ///// </summary>
        ///// <param name="pEvent">Argumentos do Evento</param>
        ///// <param name="bubleevent">Propagar execução do evento</param>
        //[FormSystemEventAttribute( EventType = BoEventTypes.et_FORM_LOAD )]
        //public void LoadForm ( ItemEvent pEvent, bool bubleevent )
        //{
        //    CreateItem( );
        //}

        [FormSystemEventAttribute( EventType = BoEventTypes.et_FORM_DATA_ADD, BeforeAction = true )]
        public void Teste ( ItemEvent pEvent, bool bubleevent )
        {
            bubleevent = false;
            throw new Exception("Algum erro");
            //Application.GetInstance( ).SetTextOnStatusBar( "Teste" + pEvent.ItemUID );
        }

        //[FormSystemEventAttribute( EventType = BoEventTypes.et_FORM_CLOSE )]
        //public void AfterTeste ( ItemEvent pEvent, bool bubleevent )
        //{
        //    //throw new Exception( );
        //    Application.GetInstance( ).SetTextOnStatusBar( "Fechou a tela " + this.Type.ToString( ) );
        //}

        //#region FormDataUpdate
        ///// <summary>
        ///// Método para caputra de evento FormDataUpda do SAP
        ///// </summary>
        ///// <param name="pEvent">Argumentos do Evento</param>
        ///// <param name="bubleevent">Propagar execução do evento</param>
        //[FormSystemEventAttribute( EventType = BoEventTypes.et_FORM_DATA_UPDATE )]
        //public void FormDataUpdate ( ItemEvent pEvent, bool bubleevent )
        //{
        //    Application.GetInstance( ).SetTextOnStatusBar( "Fechou a tela " + this.Type.ToString( ) );
        //}
        //#endregion
        ////[FormSystemEventAttribute( EventType = BoEventTypes.et_CLICK, ItemID = "1" )]
        ////public void CickOk ( ItemEvent pEvent, bool bubleevent )
        ////{            
        ////    Application.GetInstance( ).SetTextOnStatusBar( ) );
        ////}

        //[FormSystemEventAttribute(
        //    EventType = BoEventTypes.et_CLICK,
        //    ItemID = "C",
        //    BeforeAction = false )]
        //public void Ok_SAP ( ItemEvent pEvent, bool bubleevent )
        //{
        //    SAPbouiCOM.EditText myText = (SAPbouiCOM.EditText)GetItem( "5" ).Specific;
        //    Application.GetInstance( ).MessageBox( string.Format( "Cliquei no OK {0}", myText.Value ) );
        //}

        //public void CreateItem ( )
        //{
        //    SAPbouiCOM.Item myRelatedCalls = GetItem( "2" );
        //    SAPbouiCOM.Item myItem = AddItem( "C", SAPbouiCOM.BoFormItemTypes.it_BUTTON );
        //    SAPbouiCOM.Button myButton = (SAPbouiCOM.Button)myItem.Specific;
        //    myItem.Top = myRelatedCalls.Top;
        //    myItem.Left = myRelatedCalls.Left + myRelatedCalls.Width + 5;
        //    myButton.Caption = "Teste";

        //    FormBind.DataSources.UserDataSources.Add( "FolderDS", SAPbouiCOM.BoDataType.dt_SHORT_TEXT, 1 );
        //    SAPbouiCOM.Item mySystemItem = GetItem( "9" );
        //    SAPbouiCOM.Folder mySystemFolder = mySystemItem.Specific as SAPbouiCOM.Folder;

        //    myItem = AddItem( "F1", SAPbouiCOM.BoFormItemTypes.it_FOLDER );
        //    SAPbouiCOM.Folder myFolder = myItem.Specific as SAPbouiCOM.Folder;

        //    myItem.Left = mySystemItem.Left + mySystemItem.Width;
        //    //myFolder.DataBind.SetBound( true, "", "FolderDS" );

        //    myFolder.GroupWith( "3" );
        //    //myFolder.GroupWith( "9" );
        //    //myFolder.DataBind.Bind (mySystemFolder.DataBind.DataBound

        //}

        //[FormSystemEventAttribute(
        //    EventType = BoEventTypes.et_CLICK,
        //    ItemID = "F1",
        //    BeforeAction = false )]
        //public void FolderClick ( ItemEvent pEvent, bool bubleevent )
        //{
        //    FormBind.PaneLevel = 30;
        //}

    }
}
