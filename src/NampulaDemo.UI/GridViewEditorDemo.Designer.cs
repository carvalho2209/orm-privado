namespace NampulaDemo
{
    partial class GridViewEditorDemo
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
            this.dataGrid1 = new Nampula.UI.DataGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.button1 = new Nampula.UI.Button();
            this.dataGrid2 = new Nampula.UI.DataGrid();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.spliContainer1 = new Nampula.UI.SpliContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spliContainer1)).BeginInit();
            this.spliContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.dataGrid1.Location = new System.Drawing.Point(0, 0);
            this.dataGrid1.MainView = this.gridView1;
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(655, 198);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.dataGrid1;
            this.gridView1.Name = "gridView1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 400);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Close";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.dataGrid2.Location = new System.Drawing.Point(0, 0);
            this.dataGrid2.MainView = this.gridView2;
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(655, 178);
            this.dataGrid2.TabIndex = 2;
            this.dataGrid2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.dataGrid2;
            this.gridView2.Name = "gridView2";
            // 
            // spliContainer1
            // 
            this.spliContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spliContainer1.Horizontal = false;
            this.spliContainer1.Location = new System.Drawing.Point(12, 12);
            this.spliContainer1.Name = "spliContainer1";
            this.spliContainer1.Panel1.Controls.Add(this.dataGrid1);
            this.spliContainer1.Panel1.Text = "Panel1";
            this.spliContainer1.Panel2.Controls.Add(this.dataGrid2);
            this.spliContainer1.Panel2.Text = "Panel2";
            this.spliContainer1.Size = new System.Drawing.Size(655, 382);
            this.spliContainer1.SplitterPosition = 198;
            this.spliContainer1.TabIndex = 3;
            this.spliContainer1.Text = "spliContainer1";
            // 
            // GridViewEditorDemo
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 7.85F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 435);
            this.Controls.Add(this.spliContainer1);
            this.Controls.Add(this.button1);
            this.Name = "GridViewEditorDemo";
            this.Text = "GridViewEditorDemo";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spliContainer1)).EndInit();
            this.spliContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Nampula.UI.DataGrid dataGrid1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private Nampula.UI.Button button1;
        private Nampula.UI.DataGrid dataGrid2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private Nampula.UI.SpliContainer spliContainer1;
    }
}