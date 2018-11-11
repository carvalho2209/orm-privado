namespace Nampula.UI.DinamicInterface
{
    partial class frmSettingDescription
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
            this.cmdRestore = new Nampula.UI.Button();
            this.lblDesc = new Nampula.UI.StaticText();
            this.txtDesc = new Nampula.UI.EditText();
            this.lblNewDesc = new Nampula.UI.StaticText();
            this.txtNewDesc = new Nampula.UI.EditText();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewDesc.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOk
            // 
            this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdOk.Location = new System.Drawing.Point(11, 208);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(75, 25);
            this.cmdOk.TabIndex = 0;
            this.cmdOk.Text = "Ok";
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdCancel.Location = new System.Drawing.Point(92, 208);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 25);
            this.cmdCancel.TabIndex = 0;
            this.cmdCancel.Text = "Cancelar";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdRestore
            // 
            this.cmdRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRestore.Location = new System.Drawing.Point(347, 208);
            this.cmdRestore.Name = "cmdRestore";
            this.cmdRestore.Size = new System.Drawing.Size(121, 25);
            this.cmdRestore.TabIndex = 0;
            this.cmdRestore.Text = "Restaurar Padrão";
            this.cmdRestore.Click += new System.EventHandler(this.cmdRestore_Click);
            // 
            // lblDesc
            // 
            this.lblDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblDesc.LinkedTo = this.txtDesc;
            this.lblDesc.Location = new System.Drawing.Point(9, 16);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(131, 17);
            this.lblDesc.TabIndex = 1;
            this.lblDesc.Text = "Descrição Original";
            // 
            // txtDesc
            // 
            this.txtDesc.Enabled = false;
            this.txtDesc.Location = new System.Drawing.Point(140, 16);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.txtDesc.Properties.Appearance.Options.UseFont = true;
            this.txtDesc.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDesc.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtDesc.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(235)))), ((int)(((byte)(222)))));
            this.txtDesc.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtDesc.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtDesc.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.txtDesc.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtDesc.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.txtDesc.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtDesc.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.txtDesc.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtDesc.Properties.AutoHeight = false;
            this.txtDesc.Properties.DisplayFormat.FormatString = "n0";
            this.txtDesc.Properties.EditFormat.FormatString = "n0";
            this.txtDesc.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDesc.Size = new System.Drawing.Size(310, 17);
            this.txtDesc.TabIndex = 2;
            // 
            // lblNewDesc
            // 
            this.lblNewDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblNewDesc.LinkedTo = this.txtNewDesc;
            this.lblNewDesc.Location = new System.Drawing.Point(9, 41);
            this.lblNewDesc.Name = "lblNewDesc";
            this.lblNewDesc.Size = new System.Drawing.Size(131, 17);
            this.lblNewDesc.TabIndex = 1;
            this.lblNewDesc.Text = "Nova Descrição";
            // 
            // txtNewDesc
            // 
            this.txtNewDesc.Location = new System.Drawing.Point(140, 41);
            this.txtNewDesc.Name = "txtNewDesc";
            this.txtNewDesc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.txtNewDesc.Properties.Appearance.Options.UseFont = true;
            this.txtNewDesc.Properties.Appearance.Options.UseTextOptions = true;
            this.txtNewDesc.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtNewDesc.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(235)))), ((int)(((byte)(222)))));
            this.txtNewDesc.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtNewDesc.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtNewDesc.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.txtNewDesc.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtNewDesc.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.txtNewDesc.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtNewDesc.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.txtNewDesc.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtNewDesc.Properties.AutoHeight = false;
            this.txtNewDesc.Properties.DisplayFormat.FormatString = "n0";
            this.txtNewDesc.Properties.EditFormat.FormatString = "n0";
            this.txtNewDesc.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtNewDesc.Size = new System.Drawing.Size(310, 17);
            this.txtNewDesc.TabIndex = 2;
            // 
            // frmSettingDescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 245);
            this.Controls.Add(this.txtNewDesc);
            this.Controls.Add(this.lblNewDesc);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.cmdRestore);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOk);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettingDescription";
            this.Text = "Modificar Descrição";
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewDesc.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        

        private Nampula.UI.EditText txtDesc;
        private Nampula.UI.StaticText lblDesc;
        private Nampula.UI.Button cmdRestore;
        private Nampula.UI.Button cmdCancel;
        private Nampula.UI.Button cmdOk;
        private Nampula.UI.EditText txtNewDesc;
        private Nampula.UI.StaticText lblNewDesc;
    }
}