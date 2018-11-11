using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI;
using Nampula.Framework;

namespace Nampula.UI
{

    public class FormLinkedButtonHelper
    {
        private SAPbouiCOM.Form SboForm { get; set; }

        private static readonly string strFormName = "FrmAnchror";
        private static readonly string strTextItem = "my1";
        private static readonly string strLindkedtem = "my2";

        internal FormLinkedButtonHelper(SAPbouiCOM.Application pApplication)
        {
            try
            {
                SboForm = pApplication.Forms.Item(strFormName);
            }
            catch (Exception)
            {
                SboForm = null;
            }

            if (SboForm == null)
            {
                SboForm = pApplication.Forms.Add(strFormName, SAPbouiCOM.BoFormTypes.ft_Floating, 0);
            }

            SAPbouiCOM.Item textItm = null;

            try
            {
                textItm = SboForm.Items.Item(strTextItem);
            }
            catch (Exception)
            {
                textItm = null;
            }

            if (textItm == null)
            {

                textItm = SboForm.Items.Add(strTextItem, SAPbouiCOM.BoFormItemTypes.it_EDIT);

                var linkedItem = SboForm.Items.Add(strLindkedtem, SAPbouiCOM.BoFormItemTypes.it_LINKED_BUTTON);
                //var editText = (SAPbouiCOM.EditText)textItm.Specific;
                //var linkedButton = (SAPbouiCOM.LinkedButton)linkedItem.Specific;

                linkedItem.LinkTo = textItm.UniqueID;
                textItm.LinkTo = linkedItem.UniqueID;

            }

        }

        internal void PerformLinked(object sender, LinkedButtonEventArgs Event)
        {
            try
            {
                var linkedButtonItem = SboForm.Items.Item(strLindkedtem);
                var editTextItem = SboForm.Items.Item(strTextItem);
                var editText = editTextItem.Specific as SAPbouiCOM.EditText;
                var linkedButton = linkedButtonItem.Specific as SAPbouiCOM.LinkedButton;

                linkedButton.LinkedObject = (SAPbouiCOM.BoLinkedObject)Event.LinkedObjectType.To<Int32>();
                editText.Value = Event.Values[0].ToString();

                linkedButtonItem.Click();
            }
            catch (Exception excetion)
            {
                Application.GetInstance().SetTextOnStatusBar(excetion.Message, BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Error);
            }

        }

    }

}
