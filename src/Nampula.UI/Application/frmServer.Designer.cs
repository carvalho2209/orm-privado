namespace Nampula.UI
{
    partial class frmServer
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
            this.cmdOk = new Nampula.UI.Button();
            this.cmdCancel = new Nampula.UI.Button();
            this.lblSrever = new Nampula.UI.StaticText();
            this.txtServer = new Nampula.UI.EditText();
            this.txtDBUser = new Nampula.UI.EditText();
            this.lblDBUser = new Nampula.UI.StaticText();
            this.txtDBPassword = new Nampula.UI.EditText();
            this.lblDBPassword = new Nampula.UI.StaticText();
            ((System.ComponentModel.ISupportInitialize)(this.txtServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBPassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(12, 107);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(75, 23);
            this.cmdOk.TabIndex = 1;
            this.cmdOk.Text = "Ok";
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(93, 107);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // lblSrever
            // 
            this.lblSrever.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblSrever.LinkedTo = this.txtServer;
            this.lblSrever.Location = new System.Drawing.Point(9, 14);
            this.lblSrever.Name = "lblSrever";
            this.lblSrever.Size = new System.Drawing.Size(105, 17);
            this.lblSrever.TabIndex = 3;
            this.lblSrever.Text = "Servidor";
            // 
            // txtServer
            // 
            this.txtServer.DataSourceInformation = null;
            this.txtServer.Location = new System.Drawing.Point(114, 14);
            this.txtServer.Name = "txtServer";
            this.txtServer.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.txtServer.Properties.Appearance.Options.UseFont = true;
            this.txtServer.Properties.Appearance.Options.UseTextOptions = true;
            this.txtServer.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtServer.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txtServer.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtServer.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtServer.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(156)))));
            this.txtServer.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtServer.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtServer.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txtServer.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtServer.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.txtServer.Properties.AutoHeight = false;
            this.txtServer.Properties.DisplayFormat.FormatString = "n0";
            this.txtServer.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtServer.Properties.EditFormat.FormatString = "n0";
            this.txtServer.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtServer.Size = new System.Drawing.Size(219, 17);
            this.txtServer.TabIndex = 4;
            // 
            // txtDBUser
            // 
            this.txtDBUser.DataSourceInformation = null;
            this.txtDBUser.Location = new System.Drawing.Point(114, 40);
            this.txtDBUser.Name = "txtDBUser";
            this.txtDBUser.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.txtDBUser.Properties.Appearance.Options.UseFont = true;
            this.txtDBUser.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDBUser.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtDBUser.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txtDBUser.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtDBUser.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtDBUser.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(156)))));
            this.txtDBUser.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtDBUser.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtDBUser.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txtDBUser.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtDBUser.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.txtDBUser.Properties.AutoHeight = false;
            this.txtDBUser.Properties.DisplayFormat.FormatString = "n0";
            this.txtDBUser.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDBUser.Properties.EditFormat.FormatString = "n0";
            this.txtDBUser.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDBUser.Size = new System.Drawing.Size(219, 17);
            this.txtDBUser.TabIndex = 6;
            // 
            // lblDBUser
            // 
            this.lblDBUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblDBUser.LinkedTo = this.txtDBUser;
            this.lblDBUser.Location = new System.Drawing.Point(9, 40);
            this.lblDBUser.Name = "lblDBUser";
            this.lblDBUser.Size = new System.Drawing.Size(105, 17);
            this.lblDBUser.TabIndex = 5;
            this.lblDBUser.Text = "Usuário do banco";
            // 
            // txtDBPassword
            // 
            this.txtDBPassword.DataSourceInformation = null;
            this.txtDBPassword.Location = new System.Drawing.Point(114, 63);
            this.txtDBPassword.Name = "txtDBPassword";
            this.txtDBPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.txtDBPassword.Properties.Appearance.Options.UseFont = true;
            this.txtDBPassword.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDBPassword.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtDBPassword.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txtDBPassword.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtDBPassword.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtDBPassword.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(156)))));
            this.txtDBPassword.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtDBPassword.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtDBPassword.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txtDBPassword.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtDBPassword.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.txtDBPassword.Properties.AutoHeight = false;
            this.txtDBPassword.Properties.DisplayFormat.FormatString = "n0";
            this.txtDBPassword.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDBPassword.Properties.EditFormat.FormatString = "n0";
            this.txtDBPassword.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDBPassword.Properties.PasswordChar = '*';
            this.txtDBPassword.Size = new System.Drawing.Size(219, 17);
            this.txtDBPassword.TabIndex = 8;
            // 
            // lblDBPassword
            // 
            this.lblDBPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblDBPassword.LinkedTo = this.txtDBPassword;
            this.lblDBPassword.Location = new System.Drawing.Point(9, 63);
            this.lblDBPassword.Name = "lblDBPassword";
            this.lblDBPassword.Size = new System.Drawing.Size(105, 17);
            this.lblDBPassword.TabIndex = 7;
            this.lblDBPassword.Text = "Senha do banco";
            // 
            // frmServer
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 7.85F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 167);
            this.Controls.Add(this.txtDBPassword);
            this.Controls.Add(this.lblDBPassword);
            this.Controls.Add(this.txtDBUser);
            this.Controls.Add(this.lblDBUser);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.lblSrever);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOk);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmServer";
            this.Text = "SQL Srever Loggin";
            ((System.ComponentModel.ISupportInitialize)(this.txtServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBPassword.Properties)).EndInit();
            this.ResumeLayout(false);

        }



        private Button cmdOk;
        private Button cmdCancel;
        private EditText txtServer;
        private StaticText lblSrever;
        private EditText txtDBPassword;
        private StaticText lblDBPassword;
        private EditText txtDBUser;
        private StaticText lblDBUser;
    }
}