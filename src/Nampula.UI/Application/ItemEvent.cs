using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.UI {

    public class ItemEvent {

        //internal ItemEvent(ref SAPbouiCOM.ItemEvent pItemEvent) {

        //    this.ActionSuccess = pItemEvent.ActionSuccess;
        //    this.BeforeAction = pItemEvent.BeforeAction;
        //    this.CharPressed = pItemEvent.CharPressed;
        //    this.ColUID = pItemEvent.ColUID;
        //    this.EventType = (BoEventTypes)pItemEvent.EventType;
        //    this.FormMode = pItemEvent.FormMode;
        //    this.FormType = pItemEvent.FormType;
        //    this.FormTypeCount = pItemEvent.FormTypeCount;
        //    this.FormTypeEx = pItemEvent.FormTypeEx;
        //    this.FormUID = pItemEvent.FormUID;
        //    this.InnerEvent = pItemEvent.InnerEvent;
        //    this.ItemChanged = pItemEvent.ItemChanged;
        //    this.ItemUID = pItemEvent.ItemUID;
        //    this.Modifiers = (BoModifiersEnum)pItemEvent.Modifiers;
        //    this.PopUpIndicator = pItemEvent.PopUpIndicator;
        //    this.row = pItemEvent.Row;
        //}

        public bool ActionSuccess { get; set; }
        public bool BeforeAction { get; set; }
        public int CharPressed { get; set; }
        public string ColUID { get; set; }
        public  BoEventTypes EventType { get; set; }
        public int FormMode { get; set; }
        public int FormType { get; set; }
        public int FormTypeCount { get; set; }
        public string FormTypeEx { get; set; }
        public string FormUID { get; set; }
        public bool InnerEvent { get; set; }
        public bool ItemChanged { get; set; }
        public string ItemUID { get; set; }
        public BoModifiersEnum Modifiers { get; set; }
        public int PopUpIndicator { get; set; }
        public int row { get; set; }
        public string ObjectKey { get; set; }
        public string BusinessObjectType { get; set; }
        public SAPbouiCOM.DataTable SelectedObjects { get; set; }
    }
}
