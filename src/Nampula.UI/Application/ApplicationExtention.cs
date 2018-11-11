using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI;
using Nampula.Framework;

namespace Nampula.UI
{

    /// <summary>
    /// Classe de utilidades para conversão entre aplicações
    /// </summary>
    public static class ApplicationExtention
    {

        
        /// <summary>
        /// Converte um objeto SAPBouiCOM.MenuItem para MenuItem
        /// </summary>
        /// <param name="pMenu">Um objeto SAP para o menu</param>
        /// <returns>Um objeto menu</returns>
        public static MenuItem ToMenu(this SAPbouiCOM.MenuItem pMenu)
        {
            MenuItem myMenu = new MenuItem();
            myMenu.Checked = pMenu.Checked;
            myMenu.Enabled = pMenu.Enabled;
            myMenu.Image = pMenu.Image;
            myMenu.String = pMenu.String;
            myMenu.Type = (BoMenuType)pMenu.Type.To<Int32>();
            myMenu.UID = pMenu.UID;
            return myMenu;
        }
        

        
        /// <summary>
        /// Converte um objeto SAPBouiCOM.Comany em Company
        /// </summary>
        /// <param name="pCompany">Um objeto SAPBouiCOM.Comany</param>
        /// <returns>um objeto company</returns>
        public static Company ToCompany(this SAPbouiCOM.Company pCompany)
        {
            Company myCompany = new Company();
            myCompany.CurrentPeriod = pCompany.CurrentPeriod;
            myCompany.DatabaseName = pCompany.DatabaseName;
            myCompany.InstallationId = pCompany.InstallationId;
            myCompany.Localization = pCompany.Localization;
            myCompany.Name = pCompany.Name;
            myCompany.ServerDate = pCompany.ServerDate;
            myCompany.ServerName = pCompany.ServerName;
            myCompany.ServerTime = pCompany.ServerTime;
            myCompany.SystemId = pCompany.SystemId;
            myCompany.UserName = pCompany.UserName;
            return myCompany;
        }
        

        
        /// <summary>
        /// Converte um objeto SAPBouiCOM.Desktop em Desktop
        /// </summary>
        /// <param name="pCompany">Um objeto SAPBouiCOM.Desktop</param>
        /// <returns>um objeto Desktop</returns>
        public static Desktop ToDesktop(this SAPbouiCOM.Desktop pCompany)
        {
            Desktop myDesktop = new Desktop();
            myDesktop.Height = pCompany.Height;
            myDesktop.Left = pCompany.Left;
            myDesktop.State = (BoFormStateEnum)pCompany.State.To<Int32>();
            myDesktop.Title = pCompany.Title;
            myDesktop.Top = pCompany.Top;
            myDesktop.WallPaper = pCompany.WallPaper;
            myDesktop.WallpaperDisplayType = (BoWallpaperDisplayTypes)pCompany.WallpaperDisplayType.To<Int32>();
            myDesktop.Width = pCompany.Width;
            return myDesktop;
        }
        

        
        /// <summary>
        /// Converte um objeto SAPBouiCOM.ItemEvent em Desktop
        /// </summary>
        /// <param name="pCompany">Um objeto SAPBouiCOM.ItemEvent</param>
        /// <returns>um objeto ItemEvent</returns>
        public static ItemEvent ToItemEvent(this SAPbouiCOM.ItemEvent pItemEvent)
        {
            ItemEvent myEvent = new ItemEvent();
            myEvent.ActionSuccess = pItemEvent.ActionSuccess;
            myEvent.BeforeAction = pItemEvent.BeforeAction;
            myEvent.CharPressed = pItemEvent.CharPressed;
            myEvent.ColUID = pItemEvent.ColUID;
            myEvent.EventType = pItemEvent.EventType.ToEventType();
            myEvent.FormMode = pItemEvent.FormMode;
            myEvent.FormType = pItemEvent.FormType;
            myEvent.FormTypeCount = pItemEvent.FormTypeCount;
            myEvent.FormTypeEx = pItemEvent.FormTypeEx;
            myEvent.FormUID = pItemEvent.FormUID;
            myEvent.InnerEvent = pItemEvent.InnerEvent;
            myEvent.ItemChanged = pItemEvent.ItemChanged;
            myEvent.ItemUID = pItemEvent.ItemUID;
            myEvent.Modifiers = pItemEvent.Modifiers.ToModifiersEnum();
            myEvent.PopUpIndicator = pItemEvent.PopUpIndicator;
            myEvent.row = pItemEvent.Row;

            if (pItemEvent.EventType == SAPbouiCOM.BoEventTypes.et_CHOOSE_FROM_LIST)
            {
                SAPbouiCOM.IChooseFromListEvent chooseFromListEvent = (SAPbouiCOM.IChooseFromListEvent)pItemEvent;
                myEvent.SelectedObjects = chooseFromListEvent.SelectedObjects;
            }

            return myEvent;
        }
        

        public static ItemEvent ToBusinessObjectInfo(this SAPbouiCOM.BusinessObjectInfo pBO)
        {
            ItemEvent myEvent = new ItemEvent();
            myEvent.ActionSuccess = pBO.ActionSuccess;
            myEvent.BeforeAction = pBO.BeforeAction;
            myEvent.EventType = pBO.EventType.ToEventType();
            myEvent.FormType = pBO.FormTypeEx.To<Int32>();
            myEvent.FormTypeEx = pBO.FormTypeEx;
            myEvent.FormUID = pBO.FormUID;
            myEvent.ObjectKey = pBO.ObjectKey;
            myEvent.BusinessObjectType = pBO.Type;
            myEvent.ItemUID = string.Empty;
            return myEvent;
        }

        public static BoEventTypes ToEventType(this SAPbouiCOM.BoEventTypes pEventType)
        {
            return (BoEventTypes)pEventType.To<Int16>();
        }

        public static BoModifiersEnum ToModifiersEnum(this SAPbouiCOM.BoModifiersEnum pModifiersEnum)
        {
            return (BoModifiersEnum)pModifiersEnum.To<Int16>();
        }

        //
        ///// <summary>
        ///// Converte um objeto SAPBouiCOM.ItemEvent em Desktop
        ///// </summary>
        ///// <param name="pCompany">Um objeto SAPBouiCOM.ItemEvent</param>
        ///// <returns>um objeto ItemEvent</returns>
        //public static SAPbouiCOM.ItemEvent ToItemEventB1 ( this ItemEvent pItemEvent , SAPbouiCOM.ItemEvent myEvent) {
        //    myEvent.ActionSuccess = pItemEvent.ActionSuccess;
        //    myEvent.BeforeAction = pItemEvent.BeforeAction;
        //    myEvent.CharPressed = pItemEvent.CharPressed;
        //    myEvent.ColUID = pItemEvent.ColUID;
        //    myEvent.EventType = (SAPbouiCOM.BoEventTypes)pItemEvent.EventType;
        //    myEvent.FormMode = pItemEvent.FormMode;
        //    myEvent.FormType = pItemEvent.FormType;
        //    myEvent.FormTypeCount = pItemEvent.FormTypeCount;
        //    myEvent.FormTypeEx = pItemEvent.FormTypeEx;
        //    myEvent.FormUID = pItemEvent.FormUID;
        //    myEvent.InnerEvent = pItemEvent.InnerEvent;
        //    myEvent.ItemChanged = pItemEvent.ItemChanged;
        //    myEvent.ItemUID = pItemEvent.ItemUID;
        //    myEvent.Modifiers = (SAPbouiCOM.BoModifiersEnum)pItemEvent.Modifiers;
        //    myEvent.PopUpIndicator = pItemEvent.PopUpIndicator;
        //    myEvent.row = pItemEvent.Row;
        //    return myDesktop;
        //}
        //


    }
}
