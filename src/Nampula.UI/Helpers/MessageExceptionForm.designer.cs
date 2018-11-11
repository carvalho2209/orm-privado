namespace Nampula.UI.Helpers
{
    partial class MessageExceptionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageExceptionForm));
            this.okButton = new Nampula.UI.Button();
            this.stackExceptionEditMemo = new Nampula.UI.EditMemo();
            this.messageExceptionStatic = new Nampula.UI.StaticText();
            this.detailExceptionStatic = new Nampula.UI.StaticText();
            this.messageSpplitContainer = new Nampula.UI.SpliContainer();
            this.button1 = new Nampula.UI.Button();
            ((System.ComponentModel.ISupportInitialize)(this.stackExceptionEditMemo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageSpplitContainer)).BeginInit();
            this.messageSpplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.okButton.Location = new System.Drawing.Point(9, 137);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "Ok";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // stackExceptionEditMemo
            // 
            this.stackExceptionEditMemo.DataSourceInformation = null;
            this.stackExceptionEditMemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stackExceptionEditMemo.Location = new System.Drawing.Point(0, 21);
            this.stackExceptionEditMemo.Name = "stackExceptionEditMemo";
            this.stackExceptionEditMemo.Properties.ReadOnly = true;
            this.stackExceptionEditMemo.Size = new System.Drawing.Size(0, 0);
            this.stackExceptionEditMemo.TabIndex = 1;
            this.stackExceptionEditMemo.UseOptimizedRendering = true;
            // 
            // messageExceptionStatic
            // 
            this.messageExceptionStatic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageExceptionStatic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.messageExceptionStatic.LinkedTo = null;
            this.messageExceptionStatic.Location = new System.Drawing.Point(0, 0);
            this.messageExceptionStatic.Name = "messageExceptionStatic";
            this.messageExceptionStatic.Size = new System.Drawing.Size(526, 113);
            this.messageExceptionStatic.TabIndex = 2;
            this.messageExceptionStatic.Text = "#";
            // 
            // detailExceptionStatic
            // 
            this.detailExceptionStatic.Dock = System.Windows.Forms.DockStyle.Top;
            this.detailExceptionStatic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.detailExceptionStatic.LinkedTo = null;
            this.detailExceptionStatic.Location = new System.Drawing.Point(0, 0);
            this.detailExceptionStatic.Name = "detailExceptionStatic";
            this.detailExceptionStatic.Padding = new System.Windows.Forms.Padding(3);
            this.detailExceptionStatic.Size = new System.Drawing.Size(0, 21);
            this.detailExceptionStatic.TabIndex = 3;
            this.detailExceptionStatic.Text = "Detalhes da Exceção";
            // 
            // messageSpplitContainer
            // 
            this.messageSpplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageSpplitContainer.Collapsed = true;
            this.messageSpplitContainer.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
            this.messageSpplitContainer.Horizontal = false;
            this.messageSpplitContainer.Location = new System.Drawing.Point(9, 12);
            this.messageSpplitContainer.Name = "messageSpplitContainer";
            this.messageSpplitContainer.Panel1.Controls.Add(this.messageExceptionStatic);
            this.messageSpplitContainer.Panel1.Text = "Panel1";
            this.messageSpplitContainer.Panel2.Controls.Add(this.stackExceptionEditMemo);
            this.messageSpplitContainer.Panel2.Controls.Add(this.detailExceptionStatic);
            this.messageSpplitContainer.Panel2.Text = "Panel2";
            this.messageSpplitContainer.Size = new System.Drawing.Size(526, 119);
            this.messageSpplitContainer.SplitterPosition = 101;
            this.messageSpplitContainer.TabIndex = 4;
            this.messageSpplitContainer.Text = "spliContainer1";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(460, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Copiar";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MessageExceptionForm
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 7.85F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 172);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.messageSpplitContainer);
            this.Controls.Add(this.okButton);
            this.Name = "MessageExceptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mensagem do Sistema";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.stackExceptionEditMemo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageSpplitContainer)).EndInit();
            this.messageSpplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Nampula.UI.Button okButton;
        private Nampula.UI.StaticText detailExceptionStatic;
        private Nampula.UI.StaticText messageExceptionStatic;
        private Nampula.UI.EditMemo stackExceptionEditMemo;
        private Nampula.UI.SpliContainer messageSpplitContainer;
        private Nampula.UI.Button button1;
    }
}