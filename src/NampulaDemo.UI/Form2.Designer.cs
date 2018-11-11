namespace NampulaDemo
{
    partial class FormGridDemo
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.button1 = new Nampula.UI.Button();
            this.dataGrid1 = new Nampula.UI.DataGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.staticText1 = new Nampula.UI.StaticText();
            this.editText1 = new Nampula.UI.EditText();
            this.editText2 = new Nampula.UI.EditText();
            this.editTextButton1 = new Nampula.UI.EditTextButton();
            this.editTextButtonChartOfAcc = new Nampula.UI.EditTextButton();
            this.editTextChartOfAcc = new Nampula.UI.EditText();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editText1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editText2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTextButton1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTextButtonChartOfAcc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTextChartOfAcc.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 460);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DontSavePosition = false;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.dataGrid1.Location = new System.Drawing.Point(8, 62);
            this.dataGrid1.MainView = this.gridView1;
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(816, 392);
            this.dataGrid1.TabIndex = 1;
            this.dataGrid1.UseEmbeddedNavigator = true;
            this.dataGrid1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(231)))), ((int)(((byte)(156)))));
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(231)))), ((int)(((byte)(156)))));
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(231)))), ((int)(((byte)(156)))));
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(231)))), ((int)(((byte)(156)))));
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.GridControl = this.dataGrid1;
            this.gridView1.GroupPanelText = "Arraste as colunas aqui para poder agrupa-las";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            // 
            // staticText1
            // 
            this.staticText1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.staticText1.LinkedTo = this.editText1;
            this.staticText1.Location = new System.Drawing.Point(8, 20);
            this.staticText1.Name = "staticText1";
            this.staticText1.Size = new System.Drawing.Size(100, 17);
            this.staticText1.TabIndex = 2;
            this.staticText1.Text = "staticText1";
            // 
            // editText1
            // 
            this.editText1.DataSourceInformation = null;
            this.editText1.Location = new System.Drawing.Point(108, 20);
            this.editText1.Name = "editText1";
            this.editText1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.editText1.Properties.Appearance.Options.UseFont = true;
            this.editText1.Properties.Appearance.Options.UseTextOptions = true;
            this.editText1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.editText1.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.editText1.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.editText1.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.editText1.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(156)))));
            this.editText1.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.editText1.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.editText1.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.editText1.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.editText1.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.editText1.Properties.AutoHeight = false;
            this.editText1.Properties.DisplayFormat.FormatString = "f0";
            this.editText1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.editText1.Properties.EditFormat.FormatString = "f0";
            this.editText1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.editText1.Size = new System.Drawing.Size(100, 17);
            this.editText1.TabIndex = 3;
            // 
            // editText2
            // 
            this.editText2.DataSourceInformation = null;
            this.editText2.Location = new System.Drawing.Point(305, 20);
            this.editText2.Name = "editText2";
            this.editText2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.editText2.Properties.Appearance.Options.UseFont = true;
            this.editText2.Properties.Appearance.Options.UseTextOptions = true;
            this.editText2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.editText2.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.editText2.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.editText2.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.editText2.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(156)))));
            this.editText2.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.editText2.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.editText2.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.editText2.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.editText2.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.editText2.Properties.AutoHeight = false;
            this.editText2.Properties.DisplayFormat.FormatString = "f0";
            this.editText2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.editText2.Properties.EditFormat.FormatString = "f0";
            this.editText2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.editText2.Size = new System.Drawing.Size(100, 17);
            this.editText2.TabIndex = 4;
            // 
            // editTextButton1
            // 
            this.editTextButton1.DataSourceInformation = null;
            this.editTextButton1.Location = new System.Drawing.Point(424, 19);
            this.editTextButton1.Name = "editTextButton1";
            this.editTextButton1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.editTextButton1.Properties.Appearance.Options.UseFont = true;
            this.editTextButton1.Properties.Appearance.Options.UseTextOptions = true;
            this.editTextButton1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.editTextButton1.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.editTextButton1.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.editTextButton1.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.editTextButton1.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.editTextButton1.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.editTextButton1.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(156)))));
            this.editTextButton1.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.editTextButton1.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.editTextButton1.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.editTextButton1.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.editTextButton1.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.editTextButton1.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.editTextButton1.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.editTextButton1.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.editTextButton1.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.editTextButton1.Properties.AutoHeight = false;
            this.editTextButton1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.editTextButton1.Properties.DisplayFormat.FormatString = "f0";
            this.editTextButton1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.editTextButton1.Properties.EditFormat.FormatString = "f0";
            this.editTextButton1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.editTextButton1.Size = new System.Drawing.Size(227, 17);
            this.editTextButton1.TabIndex = 5;
            // 
            // editTextButtonChartOfAcc
            // 
            this.editTextButtonChartOfAcc.DataSourceInformation = null;
            this.editTextButtonChartOfAcc.Location = new System.Drawing.Point(424, 39);
            this.editTextButtonChartOfAcc.Name = "editTextButtonChartOfAcc";
            this.editTextButtonChartOfAcc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.editTextButtonChartOfAcc.Properties.Appearance.Options.UseFont = true;
            this.editTextButtonChartOfAcc.Properties.Appearance.Options.UseTextOptions = true;
            this.editTextButtonChartOfAcc.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.editTextButtonChartOfAcc.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.editTextButtonChartOfAcc.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.editTextButtonChartOfAcc.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.editTextButtonChartOfAcc.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.editTextButtonChartOfAcc.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.editTextButtonChartOfAcc.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(156)))));
            this.editTextButtonChartOfAcc.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.editTextButtonChartOfAcc.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.editTextButtonChartOfAcc.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.editTextButtonChartOfAcc.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.editTextButtonChartOfAcc.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.editTextButtonChartOfAcc.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.editTextButtonChartOfAcc.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.editTextButtonChartOfAcc.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.editTextButtonChartOfAcc.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.editTextButtonChartOfAcc.Properties.AutoHeight = false;
            this.editTextButtonChartOfAcc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.editTextButtonChartOfAcc.Properties.DisplayFormat.FormatString = "f0";
            this.editTextButtonChartOfAcc.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.editTextButtonChartOfAcc.Properties.EditFormat.FormatString = "f0";
            this.editTextButtonChartOfAcc.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.editTextButtonChartOfAcc.Size = new System.Drawing.Size(227, 17);
            this.editTextButtonChartOfAcc.TabIndex = 7;
            // 
            // editTextChartOfAcc
            // 
            this.editTextChartOfAcc.DataSourceInformation = null;
            this.editTextChartOfAcc.Location = new System.Drawing.Point(305, 40);
            this.editTextChartOfAcc.Name = "editTextChartOfAcc";
            this.editTextChartOfAcc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.editTextChartOfAcc.Properties.Appearance.Options.UseFont = true;
            this.editTextChartOfAcc.Properties.Appearance.Options.UseTextOptions = true;
            this.editTextChartOfAcc.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.editTextChartOfAcc.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.editTextChartOfAcc.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.editTextChartOfAcc.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.editTextChartOfAcc.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(156)))));
            this.editTextChartOfAcc.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.editTextChartOfAcc.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.editTextChartOfAcc.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.editTextChartOfAcc.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.editTextChartOfAcc.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.editTextChartOfAcc.Properties.AutoHeight = false;
            this.editTextChartOfAcc.Properties.DisplayFormat.FormatString = "f0";
            this.editTextChartOfAcc.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.editTextChartOfAcc.Properties.EditFormat.FormatString = "f0";
            this.editTextChartOfAcc.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.editTextChartOfAcc.Size = new System.Drawing.Size(100, 17);
            this.editTextChartOfAcc.TabIndex = 6;
            // 
            // FormGridDemo
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 7.85F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 517);
            this.Controls.Add(this.editTextButtonChartOfAcc);
            this.Controls.Add(this.editTextChartOfAcc);
            this.Controls.Add(this.editTextButton1);
            this.Controls.Add(this.editText2);
            this.Controls.Add(this.editText1);
            this.Controls.Add(this.staticText1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.button1);
            this.Name = "FormGridDemo";
            this.Text = "FormGridDemo";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editText1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editText2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTextButton1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTextButtonChartOfAcc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTextChartOfAcc.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nampula.UI.Button button1;
        private Nampula.UI.DataGrid dataGrid1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private Nampula.UI.EditText editText1;
        private Nampula.UI.StaticText staticText1;
        private Nampula.UI.EditTextButton editTextButton1;
        private Nampula.UI.EditText editText2;
        private Nampula.UI.EditTextButton editTextButtonChartOfAcc;
        private Nampula.UI.EditText editTextChartOfAcc;
    }
}