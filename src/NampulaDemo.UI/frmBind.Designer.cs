namespace NampulaDemo
{
    partial class frmBind
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBind));
            this.buttonOK = new Nampula.UI.Button();
            this.txtId = new Nampula.UI.EditText();
            this.staticText1 = new Nampula.UI.StaticText();
            this.staticText2 = new Nampula.UI.StaticText();
            this.txtName = new Nampula.UI.EditText();
            this.comboBox1 = new Nampula.UI.ComboBox();
            this.checkBox1 = new Nampula.UI.CheckBox();
            this.staticText3 = new Nampula.UI.StaticText();
            this.editDateTime1 = new Nampula.UI.EditDateTime();
            this.staticText4 = new Nampula.UI.StaticText();
            this.dataGrid1 = new Nampula.UI.DataGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.buttonLog = new Nampula.UI.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonPrev = new Nampula.UI.Button();
            this.buttonNext = new Nampula.UI.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editDateTime1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editDateTime1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.Location = new System.Drawing.Point(15, 238);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            // 
            // txtId
            // 
            this.txtId.DataSourceInformation = null;
            this.txtId.Location = new System.Drawing.Point(78, 39);
            this.txtId.Name = "txtId";
            this.txtId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.txtId.Properties.Appearance.Options.UseFont = true;
            this.txtId.Properties.Appearance.Options.UseTextOptions = true;
            this.txtId.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtId.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txtId.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtId.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtId.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.txtId.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtId.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(156)))));
            this.txtId.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtId.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtId.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.txtId.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtId.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txtId.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtId.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.txtId.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.txtId.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtId.Properties.AutoHeight = false;
            this.txtId.Properties.DisplayFormat.FormatString = "f0";
            this.txtId.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtId.Properties.EditFormat.FormatString = "f0";
            this.txtId.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtId.Size = new System.Drawing.Size(100, 17);
            this.txtId.TabIndex = 1;
            // 
            // staticText1
            // 
            this.staticText1.LinkedTo = this.txtId;
            this.staticText1.Location = new System.Drawing.Point(10, 39);
            this.staticText1.Name = "staticText1";
            this.staticText1.Size = new System.Drawing.Size(68, 17);
            this.staticText1.TabIndex = 3;
            this.staticText1.Text = "Código";
            // 
            // staticText2
            // 
            this.staticText2.LinkedTo = this.txtName;
            this.staticText2.Location = new System.Drawing.Point(10, 57);
            this.staticText2.Name = "staticText2";
            this.staticText2.Size = new System.Drawing.Size(68, 17);
            this.staticText2.TabIndex = 5;
            this.staticText2.Text = "Nome";
            // 
            // txtName
            // 
            this.txtName.DataSourceInformation = null;
            this.txtName.Location = new System.Drawing.Point(78, 57);
            this.txtName.Name = "txtName";
            this.txtName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.txtName.Properties.Appearance.Options.UseFont = true;
            this.txtName.Properties.Appearance.Options.UseTextOptions = true;
            this.txtName.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtName.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txtName.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtName.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtName.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(156)))));
            this.txtName.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtName.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtName.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txtName.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtName.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.txtName.Properties.AutoHeight = false;
            this.txtName.Properties.DisplayFormat.FormatString = "f0";
            this.txtName.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtName.Properties.EditFormat.FormatString = "f0";
            this.txtName.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtName.Size = new System.Drawing.Size(215, 17);
            this.txtName.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.DataSourceInformation = null;
            this.comboBox1.Location = new System.Drawing.Point(78, 75);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.comboBox1.Properties.Appearance.Options.UseFont = true;
            this.comboBox1.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.comboBox1.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.comboBox1.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.comboBox1.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(156)))));
            this.comboBox1.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.comboBox1.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.comboBox1.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.comboBox1.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.comboBox1.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.comboBox1.Properties.AutoHeight = false;
            this.comboBox1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBox1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBox1.ShowTextCombo = Nampula.UI.eShowTextCombo.eName;
            this.comboBox1.Size = new System.Drawing.Size(100, 17);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.ValueAlign = Nampula.UI.eValueAlign.eLeft;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.DataSourceInformation = null;
            this.checkBox1.Location = new System.Drawing.Point(367, 38);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(76, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Casado(a)";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // staticText3
            // 
            this.staticText3.LinkedTo = this.comboBox1;
            this.staticText3.Location = new System.Drawing.Point(10, 75);
            this.staticText3.Name = "staticText3";
            this.staticText3.Size = new System.Drawing.Size(68, 17);
            this.staticText3.TabIndex = 8;
            this.staticText3.Text = "Sexo";
            // 
            // editDateTime1
            // 
            this.editDateTime1.DataSourceInformation = null;
            this.editDateTime1.EditValue = null;
            this.editDateTime1.Location = new System.Drawing.Point(78, 93);
            this.editDateTime1.Name = "editDateTime1";
            this.editDateTime1.Properties.Appearance.Options.UseTextOptions = true;
            this.editDateTime1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.editDateTime1.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.editDateTime1.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.editDateTime1.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.editDateTime1.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.editDateTime1.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.editDateTime1.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.editDateTime1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.editDateTime1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.editDateTime1.Properties.Mask.EditMask = "([012]?[1-9]|[123]0|31)/(0?[1-9]|1[012])/([123][0-9])?[0-9][0-9]";
            this.editDateTime1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.editDateTime1.Properties.Mask.ShowPlaceHolders = false;
            this.editDateTime1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.editDateTime1.Size = new System.Drawing.Size(100, 20);
            this.editDateTime1.TabIndex = 9;
            // 
            // staticText4
            // 
            this.staticText4.LinkedTo = this.editDateTime1;
            this.staticText4.Location = new System.Drawing.Point(10, 93);
            this.staticText4.Name = "staticText4";
            this.staticText4.Size = new System.Drawing.Size(68, 20);
            this.staticText4.TabIndex = 10;
            this.staticText4.Text = "Data Nasc.";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DontSavePosition = false;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.dataGrid1.Location = new System.Drawing.Point(12, 119);
            this.dataGrid1.MainView = this.gridView1;
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(433, 113);
            this.dataGrid1.TabIndex = 11;
            this.dataGrid1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.dataGrid1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // buttonLog
            // 
            this.buttonLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLog.Location = new System.Drawing.Point(369, 238);
            this.buttonLog.Name = "buttonLog";
            this.buttonLog.Size = new System.Drawing.Size(75, 23);
            this.buttonLog.TabIndex = 12;
            this.buttonLog.Text = "Log";
            this.buttonLog.Click += new System.EventHandler(this.buttonLog_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonNext);
            this.panel1.Controls.Add(this.buttonPrev);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(457, 32);
            this.panel1.TabIndex = 14;
            // 
            // buttonPrev
            // 
            this.buttonPrev.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonPrev.Image = ((System.Drawing.Image)(resources.GetObject("buttonPrev.Image")));
            this.buttonPrev.Location = new System.Drawing.Point(0, 0);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(33, 32);
            this.buttonPrev.TabIndex = 1;
            this.buttonPrev.Click += new System.EventHandler(this.toolStripButtonPrev_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonNext.Image = ((System.Drawing.Image)(resources.GetObject("buttonNext.Image")));
            this.buttonNext.Location = new System.Drawing.Point(33, 0);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(33, 32);
            this.buttonNext.TabIndex = 2;
            this.buttonNext.Click += new System.EventHandler(this.toolStripButtonNext_Click);
            // 
            // frmBind
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 7.85F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 270);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonLog);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.staticText4);
            this.Controls.Add(this.editDateTime1);
            this.Controls.Add(this.staticText3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.staticText2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.staticText1);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.buttonOK);
            this.Name = "frmBind";
            this.Text = "Teste bindind";
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editDateTime1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editDateTime1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Nampula.UI.Button buttonOK;
        private Nampula.UI.EditText txtId;
        private Nampula.UI.StaticText staticText1;
        private Nampula.UI.StaticText staticText2;
        private Nampula.UI.EditText txtName;
        private Nampula.UI.ComboBox comboBox1;
        private Nampula.UI.CheckBox checkBox1;
        private Nampula.UI.StaticText staticText3;
        private Nampula.UI.EditDateTime editDateTime1;
        private Nampula.UI.StaticText staticText4;
        private Nampula.UI.DataGrid dataGrid1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private Nampula.UI.Button buttonLog;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private Nampula.UI.Button buttonNext;
        private Nampula.UI.Button buttonPrev;
    }
}