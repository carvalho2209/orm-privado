namespace NampulaDemo
{
    partial class PaymentForm
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
            this.paymentGrid = new Nampula.UI.DataGrid();
            this.paymentView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.staticText3 = new Nampula.UI.StaticText();
            this.txtDoc = new Nampula.UI.EditText();
            this.button1 = new Nampula.UI.Button();
            ((System.ComponentModel.ISupportInitialize)(this.paymentGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDoc.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // paymentGrid
            // 
            this.paymentGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paymentGrid.DontSavePosition = false;
            this.paymentGrid.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.paymentGrid.Location = new System.Drawing.Point(12, 62);
            this.paymentGrid.MainView = this.paymentView;
            this.paymentGrid.Name = "paymentGrid";
            this.paymentGrid.Size = new System.Drawing.Size(640, 355);
            this.paymentGrid.TabIndex = 0;
            this.paymentGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.paymentView});
            // 
            // paymentView
            // 
            this.paymentView.GridControl = this.paymentGrid;
            this.paymentView.Name = "paymentView";
            this.paymentView.OptionsView.ColumnAutoWidth = false;
            // 
            // staticText3
            // 
            this.staticText3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.staticText3.LinkedTo = this.txtDoc;
            this.staticText3.Location = new System.Drawing.Point(155, 12);
            this.staticText3.Name = "staticText3";
            this.staticText3.Size = new System.Drawing.Size(116, 17);
            this.staticText3.TabIndex = 90;
            this.staticText3.Text = "DocEntry:";
            // 
            // txtDoc
            // 
            this.txtDoc.DataSourceInformation = null;
            this.txtDoc.Location = new System.Drawing.Point(271, 12);
            this.txtDoc.Name = "txtDoc";
            this.txtDoc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.txtDoc.Properties.Appearance.Options.UseFont = true;
            this.txtDoc.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDoc.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtDoc.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(235)))), ((int)(((byte)(222)))));
            this.txtDoc.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtDoc.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtDoc.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.txtDoc.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtDoc.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.txtDoc.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtDoc.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.txtDoc.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtDoc.Properties.AutoHeight = false;
            this.txtDoc.Properties.DisplayFormat.FormatString = "n0";
            this.txtDoc.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDoc.Properties.EditFormat.FormatString = "n0";
            this.txtDoc.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDoc.Size = new System.Drawing.Size(100, 17);
            this.txtDoc.TabIndex = 91;
            this.txtDoc.EditValueChanged += new System.EventHandler(this.txtDoc_EditValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 92;
            this.button1.Text = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PaymentForm
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 7.85F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 429);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtDoc);
            this.Controls.Add(this.staticText3);
            this.Controls.Add(this.paymentGrid);
            this.Name = "PaymentForm";
            this.Text = "Incoming Payment";
            ((System.ComponentModel.ISupportInitialize)(this.paymentGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDoc.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nampula.UI.DataGrid paymentGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView paymentView;
        private Nampula.UI.StaticText staticText3;
        private Nampula.UI.EditText txtDoc;
        private Nampula.UI.Button button1;
    }
}