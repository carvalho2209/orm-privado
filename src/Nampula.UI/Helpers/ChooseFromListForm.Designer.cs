namespace Nampula.UI.Helpers
{
    partial class ChooseFromListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.grdResult = new Nampula.UI.DataGrid();
            this.ViewResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtSearch = new Nampula.UI.EditText();
            this.lblSerach = new Nampula.UI.StaticText();
            this.cmdOk = new Nampula.UI.Button();
            this.cmdCancel = new Nampula.UI.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdResult
            // 
            this.grdResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdResult.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.grdResult.Location = new System.Drawing.Point(8, 41);
            this.grdResult.MainView = this.ViewResult;
            this.grdResult.Name = "grdResult";
            this.grdResult.Size = new System.Drawing.Size(646, 333);
            this.grdResult.TabIndex = 10;
            this.grdResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ViewResult});
            this.grdResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdResult_KeyDown);
            // 
            // ViewResult
            // 
            this.ViewResult.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(231)))), ((int)(((byte)(156)))));
            this.ViewResult.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.ViewResult.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(231)))), ((int)(((byte)(156)))));
            this.ViewResult.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.ViewResult.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(231)))), ((int)(((byte)(156)))));
            this.ViewResult.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.ViewResult.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(231)))), ((int)(((byte)(156)))));
            this.ViewResult.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.ViewResult.GridControl = this.grdResult;
            this.ViewResult.GroupPanelText = "Arraste as colunas aqui para poder agrupa-las";
            this.ViewResult.Name = "ViewResult";
            this.ViewResult.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.ViewResult.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.ViewResult.OptionsBehavior.AllowIncrementalSearch = true;
            this.ViewResult.OptionsBehavior.Editable = false;
            this.ViewResult.OptionsNavigation.AutoFocusNewRow = true;
            this.ViewResult.OptionsNavigation.UseTabKey = false;
            this.ViewResult.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ViewResult.OptionsView.ColumnAutoWidth = false;
            this.ViewResult.OptionsView.ShowGroupPanel = false;
            this.ViewResult.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.ViewResult_FocusedColumnChanged);
            this.ViewResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdResult_KeyDown);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(121, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.txtSearch.Properties.Appearance.Options.UseFont = true;
            this.txtSearch.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSearch.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtSearch.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txtSearch.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtSearch.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtSearch.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(156)))));
            this.txtSearch.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtSearch.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtSearch.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txtSearch.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtSearch.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.txtSearch.Properties.AutoHeight = false;
            this.txtSearch.Properties.DisplayFormat.FormatString = "n0";
            this.txtSearch.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSearch.Properties.EditFormat.FormatString = "n0";
            this.txtSearch.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSearch.Size = new System.Drawing.Size(268, 17);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.EditValueChanged += new System.EventHandler(this.txtSearch_EditValueChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // lblSerach
            // 
            this.lblSerach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblSerach.LinkedTo = this.txtSearch;
            this.lblSerach.Location = new System.Drawing.Point(7, 12);
            this.lblSerach.Name = "lblSerach";
            this.lblSerach.Size = new System.Drawing.Size(114, 17);
            this.lblSerach.TabIndex = 8;
            this.lblSerach.Text = "Procurar";
            // 
            // cmdOk
            // 
            this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdOk.Location = new System.Drawing.Point(8, 383);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(75, 22);
            this.cmdOk.TabIndex = 11;
            this.cmdOk.Text = "Selecionar";
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdCancel.Location = new System.Drawing.Point(89, 383);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 22);
            this.cmdCancel.TabIndex = 12;
            this.cmdCancel.Text = "Cancelar";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // ChooseFromListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 412);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.grdResult);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSerach);
            this.Name = "ChooseFromListForm";
            this.Text = "ChooseFromListForm";
            this.Load += new System.EventHandler(this.FormChooseFromList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        

        private DataGrid grdResult;
        protected DevExpress.XtraGrid.Views.Grid.GridView ViewResult;
        private EditText txtSearch;
        private StaticText lblSerach;
        private Button cmdCancel;
        private Button cmdOk;

    }
}