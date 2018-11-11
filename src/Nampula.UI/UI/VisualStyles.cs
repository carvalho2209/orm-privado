using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace Nampula.UI
{

    public class VisualStyles
    {
        public static readonly Color focusedEditorColor = Color.FromArgb(255, 243, 156);
        public static readonly Color disabledEditorColor = Color.FromArgb(217, 229, 242);
        public static readonly Color selectedRow = Color.FromArgb(252, 221, 130);
        public static readonly Color staticLineColor = Color.FromArgb(213, 218, 223);

        static private int GetDefaultHeight()
        {
            return 17;
        }

        static internal void SetStyle(EditText pEditText)
        {
            pEditText.Properties.AutoHeight = false;
            pEditText.Font = GetFont();
            //pEditText.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;

            pEditText.Properties.AppearanceFocused.Reset();
            pEditText.Properties.AppearanceFocused.BackColor = focusedEditorColor;
            pEditText.Properties.AppearanceFocused.Options.UseBackColor = true;
            pEditText.Properties.AppearanceFocused.Options.UseForeColor = true;

            pEditText.Size = new Size(pEditText.Width, GetDefaultHeight());

            pEditText.Properties.AppearanceDisabled.Reset();
            pEditText.Properties.AppearanceDisabled.BackColor = disabledEditorColor;
            pEditText.Properties.AppearanceDisabled.Options.UseBackColor = true;
            pEditText.Properties.AppearanceDisabled.Options.UseForeColor = true;

            pEditText.Properties.AppearanceReadOnly.Reset();
            pEditText.Properties.AppearanceReadOnly.BackColor = disabledEditorColor;
            pEditText.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            pEditText.Properties.AppearanceReadOnly.Options.UseForeColor = true;
        }

        static internal void SetStyle(EditTextButton pEditText)
        {
            pEditText.Properties.AutoHeight = false;
            pEditText.Font = GetFont();

            pEditText.Properties.AppearanceFocused.BackColor = focusedEditorColor;
            pEditText.Properties.AppearanceFocused.Options.UseBackColor = true;
            pEditText.Properties.AppearanceFocused.Options.UseForeColor = true;

            pEditText.Size = new Size(pEditText.Width, GetDefaultHeight());

            pEditText.Properties.AppearanceDisabled.BackColor = disabledEditorColor;
            pEditText.Properties.AppearanceDisabled.Options.UseBackColor = true;
            pEditText.Properties.AppearanceDisabled.Options.UseForeColor = true;

            pEditText.Properties.AppearanceReadOnly.BackColor = disabledEditorColor;
            pEditText.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            pEditText.Properties.AppearanceReadOnly.Options.UseForeColor = true;
        }

        static internal void SetStyle(ComboBox pComboBox)
        {
            
            pComboBox.Properties.AutoHeight = false;
            pComboBox.Font = GetFont();

            pComboBox.Properties.AppearanceFocused.BackColor = focusedEditorColor;
            pComboBox.Properties.AppearanceFocused.Options.UseBackColor = true;
            pComboBox.Properties.AppearanceFocused.Options.UseForeColor = true;

            pComboBox.Size = new Size(pComboBox.Width, GetDefaultHeight());

            pComboBox.Properties.AppearanceDisabled.BackColor = disabledEditorColor;
            pComboBox.Properties.AppearanceDisabled.Options.UseBackColor = true;
            pComboBox.Properties.AppearanceDisabled.Options.UseForeColor = true;

            pComboBox.Properties.AppearanceReadOnly.BackColor = disabledEditorColor;
            pComboBox.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            pComboBox.Properties.AppearanceReadOnly.Options.UseForeColor = true;

            pComboBox.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        }

        static internal Font GetFont()
        {
            return new System.Drawing.Font("Tahoma", 7.25F);
        }

        internal static void SetStyle(DataGrid pDataGrid)
        {
            pDataGrid.Font = GetFont();
            //pEditText.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;

            var mainView = pDataGrid.MainView as GridView;

            if(mainView == null)
                return;

            mainView.Appearance.FocusedCell.BackColor = focusedEditorColor;

            mainView.Appearance.FocusedCell.Options.UseBackColor = true;
            mainView.Appearance.FocusedCell.Options.UseForeColor = true;

            //mainView.Appearance..AppearanceDisabled.BackColor = disabledEditorColor;
            //pEditText.Properties.AppearanceDisabled.Options.UseBackColor = true;
            //pEditText.Properties.AppearanceDisabled.Options.UseForeColor = true;
        }

        internal static void SetStyle(DataGridTreeView dataGridTreeView)
        {
        }

        internal static void SetStyle(ImageBox imageBox)
        {
        }

        internal static void SetStyle(BaseEdit baseEdit)
        {

            if (baseEdit == null)
                return;

            baseEdit.Properties.AutoHeight = false;
            baseEdit.Font = GetFont();
            //pEditText.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;

            baseEdit.Properties.AppearanceFocused.Reset();
            baseEdit.Properties.AppearanceFocused.BackColor = focusedEditorColor;
            baseEdit.Properties.AppearanceFocused.Options.UseBackColor = true;
            baseEdit.Properties.AppearanceFocused.Options.UseForeColor = true;

            baseEdit.Size = new Size(baseEdit.Width, GetDefaultHeight());

            baseEdit.Properties.AppearanceDisabled.Reset();
            baseEdit.Properties.AppearanceDisabled.BackColor = disabledEditorColor;
            baseEdit.Properties.AppearanceDisabled.Options.UseBackColor = true;
            baseEdit.Properties.AppearanceDisabled.Options.UseForeColor = true;

            baseEdit.Properties.AppearanceReadOnly.Reset();
            baseEdit.Properties.AppearanceReadOnly.BackColor = disabledEditorColor;
            baseEdit.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            baseEdit.Properties.AppearanceReadOnly.Options.UseForeColor = true;
        }

        
    }
}
