namespace Nampula.UI
{

    partial class frmMessageBox
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
            this.lblMessage = new System.Windows.Forms.Label();
            this.cmdCancel = new Nampula.UI.Button();
            this.cmdOk = new Nampula.UI.Button();
            this.cmdAbort = new Nampula.UI.Button();
            this.cmdRetry = new Nampula.UI.Button();
            this.cmdYes = new Nampula.UI.Button();
            this.cmdNo = new Nampula.UI.Button();
            this.cmdIgnore = new Nampula.UI.Button();
            this.icoImage = new Nampula.UI.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.icoImage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(8, 9);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(392, 91);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "#";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(87, 117);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.Visible = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(6, 117);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(75, 23);
            this.cmdOk.TabIndex = 4;
            this.cmdOk.Text = "Ok";
            this.cmdOk.Visible = false;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // cmdAbort
            // 
            this.cmdAbort.Location = new System.Drawing.Point(168, 117);
            this.cmdAbort.Name = "cmdAbort";
            this.cmdAbort.Size = new System.Drawing.Size(75, 23);
            this.cmdAbort.TabIndex = 6;
            this.cmdAbort.Text = "Abortar";
            this.cmdAbort.Visible = false;
            this.cmdAbort.Click += new System.EventHandler(this.cmdAbort_Click);
            // 
            // cmdRetry
            // 
            this.cmdRetry.Location = new System.Drawing.Point(249, 117);
            this.cmdRetry.Name = "cmdRetry";
            this.cmdRetry.Size = new System.Drawing.Size(75, 23);
            this.cmdRetry.TabIndex = 7;
            this.cmdRetry.Text = "Repetir";
            this.cmdRetry.Visible = false;
            this.cmdRetry.Click += new System.EventHandler(this.cmdRetry_Click);
            // 
            // cmdYes
            // 
            this.cmdYes.Location = new System.Drawing.Point(330, 117);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(75, 23);
            this.cmdYes.TabIndex = 8;
            this.cmdYes.Text = "Sim";
            this.cmdYes.Visible = false;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // cmdNo
            // 
            this.cmdNo.Location = new System.Drawing.Point(411, 117);
            this.cmdNo.Name = "cmdNo";
            this.cmdNo.Size = new System.Drawing.Size(75, 23);
            this.cmdNo.TabIndex = 9;
            this.cmdNo.Text = "Não";
            this.cmdNo.Visible = false;
            this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
            // 
            // cmdIgnore
            // 
            this.cmdIgnore.Location = new System.Drawing.Point(406, 86);
            this.cmdIgnore.Name = "cmdIgnore";
            this.cmdIgnore.Size = new System.Drawing.Size(75, 23);
            this.cmdIgnore.TabIndex = 10;
            this.cmdIgnore.Text = "Ignorar";
            this.cmdIgnore.Visible = false;
            // 
            // icoImage
            // 
            this.icoImage.Location = new System.Drawing.Point(417, 15);
            this.icoImage.Name = "icoImage";
            this.icoImage.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.icoImage.Properties.Appearance.Options.UseBackColor = true;
            this.icoImage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.icoImage.Properties.InitialImage = null;
            this.icoImage.Properties.ReadOnly = true;
            this.icoImage.Size = new System.Drawing.Size(25, 26);
            this.icoImage.TabIndex = 11;
            // 
            // frmMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 145);
            this.Controls.Add(this.icoImage);
            this.Controls.Add(this.cmdIgnore);
            this.Controls.Add(this.cmdNo);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.cmdRetry);
            this.Controls.Add(this.cmdAbort);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.lblMessage);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMessageBox";
            ((System.ComponentModel.ISupportInitialize)(this.icoImage.Properties)).EndInit();
            this.ResumeLayout(false);

        }



        private Button cmdCancel;
        private Button cmdOk;
        private System.Windows.Forms.Label lblMessage;
        private Button cmdRetry;
        private Button cmdAbort;
        private Button cmdYes;
        private Button cmdNo;
        private Button cmdIgnore;
        private PictureBox icoImage;


    }
}