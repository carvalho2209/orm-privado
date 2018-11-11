namespace Nampula.UI.Helpers.Extentions
{
    partial class ChangeLogForm
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
            this.logView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.logGrid = new Nampula.UI.DataGrid();
            this.OkButton = new Nampula.UI.Button();
            this.ViewDiffButton = new Nampula.UI.Button();
            ((System.ComponentModel.ISupportInitialize)(this.logView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // logView
            // 
            this.logView.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(231)))), ((int)(((byte)(156)))));
            this.logView.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.logView.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(231)))), ((int)(((byte)(156)))));
            this.logView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.logView.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(231)))), ((int)(((byte)(156)))));
            this.logView.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.logView.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(231)))), ((int)(((byte)(156)))));
            this.logView.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.logView.GridControl = this.logGrid;
            this.logView.GroupPanelText = "Arraste as colunas aqui para poder agrupa-las";
            this.logView.Name = "logView";
            this.logView.OptionsView.ColumnAutoWidth = false;
            this.logView.OptionsView.ShowFooter = true;
            this.logView.OptionsView.ShowGroupPanel = false;
            // 
            // logGrid
            // 
            this.logGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logGrid.DontSavePosition = false;
            this.logGrid.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.logGrid.Location = new System.Drawing.Point(6, 7);
            this.logGrid.MainView = this.logView;
            this.logGrid.Name = "logGrid";
            this.logGrid.Size = new System.Drawing.Size(621, 269);
            this.logGrid.TabIndex = 1;
            this.logGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.logView});
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.OkButton.Location = new System.Drawing.Point(7, 282);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 57;
            this.OkButton.Text = "Fechar";
            // 
            // ViewDiffButton
            // 
            this.ViewDiffButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ViewDiffButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ViewDiffButton.Location = new System.Drawing.Point(532, 282);
            this.ViewDiffButton.Name = "ViewDiffButton";
            this.ViewDiffButton.Size = new System.Drawing.Size(98, 23);
            this.ViewDiffButton.TabIndex = 58;
            this.ViewDiffButton.Text = "Exibir Diferenças";
            // 
            // ChangeLogForm
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 7.85F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 317);
            this.Controls.Add(this.ViewDiffButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.logGrid);
            this.Name = "ChangeLogForm";
            this.Text = "Log de Modificações";
            ((System.ComponentModel.ISupportInitialize)(this.logView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nampula.UI.DataGrid logGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView logView;
        private Nampula.UI.Button OkButton;
        private Nampula.UI.Button ViewDiffButton;


    }
}