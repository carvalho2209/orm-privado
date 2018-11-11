namespace Nampula.UI.Helpers.Extentions
{
    partial class DifferencesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.diffGrid = new Nampula.UI.DataGrid();
            this.diffView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.okButton = new Nampula.UI.Button();
            ((System.ComponentModel.ISupportInitialize)(this.diffGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diffView)).BeginInit();
            this.SuspendLayout();
            // 
            // diffGrid
            // 
            this.diffGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.diffGrid.DontSavePosition = false;
            this.diffGrid.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.diffGrid.Location = new System.Drawing.Point(6, 4);
            this.diffGrid.MainView = this.diffView;
            this.diffGrid.Name = "diffGrid";
            this.diffGrid.Size = new System.Drawing.Size(571, 297);
            this.diffGrid.TabIndex = 2;
            this.diffGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.diffView});
            // 
            // diffView
            // 
            this.diffView.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(231)))), ((int)(((byte)(156)))));
            this.diffView.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.diffView.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(231)))), ((int)(((byte)(156)))));
            this.diffView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.diffView.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(231)))), ((int)(((byte)(156)))));
            this.diffView.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.diffView.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(231)))), ((int)(((byte)(156)))));
            this.diffView.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.diffView.GridControl = this.diffGrid;
            this.diffView.GroupPanelText = "Arraste as colunas aqui para poder agrupa-las";
            this.diffView.Name = "diffView";
            this.diffView.OptionsBehavior.Editable = false;
            this.diffView.OptionsDetail.AllowZoomDetail = false;
            this.diffView.OptionsDetail.EnableMasterViewMode = false;
            this.diffView.OptionsDetail.ShowDetailTabs = false;
            this.diffView.OptionsDetail.SmartDetailExpand = false;
            this.diffView.OptionsView.ColumnAutoWidth = false;
            this.diffView.OptionsView.ShowFooter = true;
            this.diffView.OptionsView.ShowGroupPanel = false;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(6, 307);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 58;
            this.okButton.Text = "Fechar";
            // 
            // DifferencesForm
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 7.85F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 342);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.diffGrid);
            this.Name = "DifferencesForm";
            this.Text = "Diferenças";
            ((System.ComponentModel.ISupportInitialize)(this.diffGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diffView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nampula.UI.DataGrid diffGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView diffView;
        private Nampula.UI.Button okButton;
    }
}