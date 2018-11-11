namespace Nampula.UI
{
    partial class frmSelectCompany
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



        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grdCompany = new Nampula.UI.DataGrid();
            this.ViewCompany = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblCompany = new Nampula.UI.StaticText();
            this.lblUserName = new Nampula.UI.StaticText();
            this.txtUserName = new Nampula.UI.EditText();
            this.txtPassword = new Nampula.UI.EditText();
            this.lblPassword = new Nampula.UI.StaticText();
            this.lblServer = new Nampula.UI.StaticText();
            this.cboServerType = new Nampula.UI.ComboBox();
            this.txtServerName = new Nampula.UI.EditText();
            this.cmdServer = new Nampula.UI.Button();
            this.cmdUpdate = new Nampula.UI.Button();
            this.cmdOk = new Nampula.UI.Button();
            this.cmdCancelar = new Nampula.UI.Button();

            ((System.ComponentModel.ISupportInitialize)(this.grdCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboServerType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnClient
            // 
            Controls.Add(this.cmdCancelar);
            Controls.Add(this.cmdOk);
            Controls.Add(this.cmdUpdate);
            Controls.Add(this.cmdServer);
            Controls.Add(this.txtServerName);
            Controls.Add(this.cboServerType);
            Controls.Add(this.lblServer);
            Controls.Add(this.lblPassword);
            Controls.Add(this.txtPassword);
            Controls.Add(this.txtUserName);
            Controls.Add(this.lblUserName);
            Controls.Add(this.lblCompany);
            Controls.Add(this.grdCompany);
            Size = new System.Drawing.Size(479, 259);
            // 
            // grdCompany
            // 
            this.grdCompany.Location = new System.Drawing.Point(8, 87);
            this.grdCompany.MainView = this.ViewCompany;
            this.grdCompany.Name = "grdCompany";
            this.grdCompany.Size = new System.Drawing.Size(377, 131);
            this.grdCompany.TabIndex = 1;
            this.grdCompany.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ViewCompany});
            // 
            // ViewCompany
            // 
            this.ViewCompany.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.ViewCompany.GridControl = this.grdCompany;
            this.ViewCompany.GroupPanelText = "Arraste as colunas aqui para poder agrupa-las";
            this.ViewCompany.Name = "ViewCompany";
            this.ViewCompany.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ViewCompany.OptionsView.ShowGroupPanel = false;
            // 
            // lblCompany
            // 
            this.lblCompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblCompany.LinkedTo = null;
            this.lblCompany.Location = new System.Drawing.Point(8, 71);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(137, 13);
            this.lblCompany.TabIndex = 2;
            this.lblCompany.Text = "Empresas no servidor atual";
            // 
            // lblUserName
            // 
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblUserName.LinkedTo = this.txtUserName;
            this.lblUserName.Location = new System.Drawing.Point(7, 10);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(91, 17);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "Código Usuário";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(98, 10);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.txtUserName.Properties.Appearance.Options.UseFont = true;
            this.txtUserName.Properties.Appearance.Options.UseTextOptions = true;
            this.txtUserName.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtUserName.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.txtUserName.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtUserName.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.txtUserName.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtUserName.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.txtUserName.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtUserName.Properties.AutoHeight = false;
            this.txtUserName.Properties.DisplayFormat.FormatString = "n0";
            this.txtUserName.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtUserName.Properties.EditFormat.FormatString = "n0";
            this.txtUserName.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtUserName.Size = new System.Drawing.Size(97, 17);
            this.txtUserName.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(287, 10);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPassword.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtPassword.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.txtPassword.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtPassword.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.txtPassword.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtPassword.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.txtPassword.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtPassword.Properties.AutoHeight = false;
            this.txtPassword.Properties.DisplayFormat.FormatString = "n0";
            this.txtPassword.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPassword.Properties.EditFormat.FormatString = "n0";
            this.txtPassword.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(98, 17);
            this.txtPassword.TabIndex = 5;
            // 
            // lblPassword
            // 
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblPassword.LinkedTo = this.txtPassword;
            this.lblPassword.Location = new System.Drawing.Point(201, 10);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(86, 17);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Senha";
            // 
            // lblServer
            // 
            this.lblServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblServer.LinkedTo = this.cboServerType;
            this.lblServer.Location = new System.Drawing.Point(7, 39);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(91, 17);
            this.lblServer.TabIndex = 7;
            this.lblServer.Text = "Servidor Atual";
            // 
            // cboServerType
            // 
            this.cboServerType.Location = new System.Drawing.Point(98, 39);
            this.cboServerType.Name = "cboServerType";
            this.cboServerType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.cboServerType.Properties.Appearance.Options.UseFont = true;
            this.cboServerType.Properties.AutoHeight = false;
            this.cboServerType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboServerType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboServerType.ShowTextCombo = eShowTextCombo.eName;
            this.cboServerType.Size = new System.Drawing.Size(97, 17);
            this.cboServerType.TabIndex = 8;
            this.cboServerType.ValueAlign = eValueAlign.eLeft;
            // 
            // txtServerName
            // 
            this.txtServerName.Enabled = false;
            this.txtServerName.Location = new System.Drawing.Point(198, 39);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.txtServerName.Properties.Appearance.Options.UseFont = true;
            this.txtServerName.Properties.Appearance.Options.UseTextOptions = true;
            this.txtServerName.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtServerName.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.txtServerName.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtServerName.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.txtServerName.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtServerName.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.txtServerName.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtServerName.Properties.AutoHeight = false;
            this.txtServerName.Properties.DisplayFormat.FormatString = "n0";
            this.txtServerName.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtServerName.Properties.EditFormat.FormatString = "n0";
            this.txtServerName.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtServerName.Size = new System.Drawing.Size(187, 17);
            this.txtServerName.TabIndex = 9;
            // 
            // cmdServer
            // 
            this.cmdServer.Location = new System.Drawing.Point(392, 39);
            this.cmdServer.Name = "cmdServer";
            this.cmdServer.Size = new System.Drawing.Size(81, 23);
            this.cmdServer.TabIndex = 10;
            this.cmdServer.Text = "Servidor";
            this.cmdServer.Click += new System.EventHandler(this.cmdServer_Click);
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Location = new System.Drawing.Point(392, 85);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(81, 23);
            this.cmdUpdate.TabIndex = 11;
            this.cmdUpdate.Text = "Atualizar";
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(4, 228);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(75, 23);
            this.cmdOk.TabIndex = 12;
            this.cmdOk.Text = "Ok";
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Location = new System.Drawing.Point(85, 228);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(75, 23);
            this.cmdCancelar.TabIndex = 13;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // frmSelectCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 284);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectCompany";
            this.Text = "Selecionar Empresa";
            ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboServerType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerName.Properties)).EndInit();
            this.ResumeLayout(false);

        }



        private DataGrid grdCompany;
        private DevExpress.XtraGrid.Views.Grid.GridView ViewCompany;
        private StaticText lblCompany;
        private StaticText lblPassword;
        private EditText txtPassword;
        private EditText txtUserName;
        private StaticText lblUserName;
        private EditText txtServerName;
        private ComboBox cboServerType;
        private StaticText lblServer;
        private Button cmdUpdate;
        private Button cmdServer;
        private Button cmdCancelar;
        private Button cmdOk;
    }
}