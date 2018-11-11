namespace Nampula.UI
{
    partial class frmSplash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSplash));
            this.cmdOk = new Nampula.UI.Button();
            this.cmdEnd = new Nampula.UI.Button();
            this.cmdCompany = new Nampula.UI.Button();
            this.lblUserName = new Nampula.UI.StaticText();
            this.txtUserName = new Nampula.UI.EditText();
            this.lblPassword = new Nampula.UI.StaticText();
            this.txtPassword = new Nampula.UI.EditText();
            this.pictureBox1 = new Nampula.UI.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(9, 292);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(75, 23);
            this.cmdOk.TabIndex = 2;
            this.cmdOk.Text = "Ok";
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // cmdEnd
            // 
            this.cmdEnd.Location = new System.Drawing.Point(90, 292);
            this.cmdEnd.Name = "cmdEnd";
            this.cmdEnd.Size = new System.Drawing.Size(75, 23);
            this.cmdEnd.TabIndex = 3;
            this.cmdEnd.Text = "Encerrar";
            this.cmdEnd.Click += new System.EventHandler(this.cmdEnd_Click);
            // 
            // cmdCompany
            // 
            this.cmdCompany.Location = new System.Drawing.Point(357, 292);
            this.cmdCompany.Name = "cmdCompany";
            this.cmdCompany.Size = new System.Drawing.Size(105, 23);
            this.cmdCompany.TabIndex = 4;
            this.cmdCompany.Text = "Modificar Empresa";
            this.cmdCompany.Click += new System.EventHandler(this.cmdCompany_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblUserName.LinkedTo = this.txtUserName;
            this.lblUserName.Location = new System.Drawing.Point(22, 178);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(126, 17);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "Código do Usuário";
            // 
            // txtUserName
            // 
            this.txtUserName.DataSourceInformation = null;
            this.txtUserName.Location = new System.Drawing.Point(148, 178);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.txtUserName.Properties.Appearance.Options.UseFont = true;
            this.txtUserName.Properties.Appearance.Options.UseTextOptions = true;
            this.txtUserName.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtUserName.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txtUserName.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtUserName.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtUserName.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(156)))));
            this.txtUserName.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtUserName.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtUserName.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txtUserName.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtUserName.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.txtUserName.Properties.AutoHeight = false;
            this.txtUserName.Properties.DisplayFormat.FormatString = "n0";
            this.txtUserName.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtUserName.Properties.EditFormat.FormatString = "n0";
            this.txtUserName.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtUserName.Size = new System.Drawing.Size(102, 17);
            this.txtUserName.TabIndex = 0;
            // 
            // lblPassword
            // 
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblPassword.LinkedTo = this.txtPassword;
            this.lblPassword.Location = new System.Drawing.Point(22, 204);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(126, 17);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Senha";
            // 
            // txtPassword
            // 
            this.txtPassword.DataSourceInformation = null;
            this.txtPassword.Location = new System.Drawing.Point(148, 204);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPassword.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtPassword.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txtPassword.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtPassword.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtPassword.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(156)))));
            this.txtPassword.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtPassword.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtPassword.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txtPassword.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtPassword.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.txtPassword.Properties.AutoHeight = false;
            this.txtPassword.Properties.DisplayFormat.FormatString = "n0";
            this.txtPassword.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPassword.Properties.EditFormat.FormatString = "n0";
            this.txtPassword.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(102, 17);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.EditValue = ((object)(resources.GetObject("pictureBox1.EditValue")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureBox1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureBox1.Size = new System.Drawing.Size(476, 345);
            this.pictureBox1.TabIndex = 5;
            // 
            // frmSplash
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 7.85F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 345);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.cmdCompany);
            this.Controls.Add(this.cmdEnd);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSplash";
            this.Text = "SAP Business One";
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1.Properties)).EndInit();
            this.ResumeLayout(false);

        }



        private Button cmdCompany;
        private Button cmdEnd;
        private Button cmdOk;
        private StaticText lblPassword;
        private StaticText lblUserName;
        private EditText txtPassword;
        private EditText txtUserName;
        private PictureBox pictureBox1;
    }
}