using Nampula.DI;
namespace Nampula.UI {
    partial class FormChooseFromList<TT> {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.cmdOk = new Nampula.UI.Button( );
            this.cmdCancelar = new Nampula.UI.Button( );
            this.lblSerach = new Nampula.UI.StaticText( );
            this.txtSearch = new Nampula.UI.EditText( );
            this.grdResult = new Nampula.UI.DataGrid( );
            this.ViewResult = new DevExpress.XtraGrid.Views.Grid.GridView( );
            ( (System.ComponentModel.ISupportInitialize)( this.txtSearch.Properties ) ).BeginInit( );
            ( (System.ComponentModel.ISupportInitialize)( this.grdResult ) ).BeginInit( );
            ( (System.ComponentModel.ISupportInitialize)( this.ViewResult ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // pnClient
            // 
            this.Controls.Add( this.grdResult );
            this.Controls.Add( this.txtSearch );
            this.Controls.Add( this.lblSerach );
            this.Controls.Add( this.cmdCancelar );
            this.Controls.Add( this.cmdOk );
            this.Size = new System.Drawing.Size( 637, 405 );
            // 
            // cmdOk
            // 
            this.cmdOk.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.cmdOk.Appearance.ForeColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 40 ) ) ) ), ( (int)( ( (byte)( 40 ) ) ) ), ( (int)( ( (byte)( 40 ) ) ) ) );
            this.cmdOk.Appearance.Options.UseForeColor = true;
            this.cmdOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdOk.Location = new System.Drawing.Point( 9, 372 );
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size( 75, 23 );
            this.cmdOk.TabIndex = 0;
            this.cmdOk.Text = "Selecionar";
            this.cmdOk.Click += new System.EventHandler( this.CmdOkClick );
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.cmdCancelar.Appearance.ForeColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 40 ) ) ) ), ( (int)( ( (byte)( 40 ) ) ) ), ( (int)( ( (byte)( 40 ) ) ) ) );
            this.cmdCancelar.Appearance.Options.UseForeColor = true;
            this.cmdCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancelar.Location = new System.Drawing.Point( 90, 372 );
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size( 75, 23 );
            this.cmdCancelar.TabIndex = 1;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.Click += new System.EventHandler( this.CmdCancelarClick );
            // 
            // lblSerach
            // 
            this.lblSerach.ForeColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 40 ) ) ) ), ( (int)( ( (byte)( 40 ) ) ) ), ( (int)( ( (byte)( 40 ) ) ) ) );
            this.lblSerach.LinkedTo = this.txtSearch;
            this.lblSerach.Location = new System.Drawing.Point( 7, 6 );
            this.lblSerach.Name = "lblSerach";
            this.lblSerach.Size = new System.Drawing.Size( 114, 17 );
            this.lblSerach.TabIndex = 2;
            this.lblSerach.Text = "Procurar";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point( 121, 6 );
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Appearance.Font = new System.Drawing.Font( "Tahoma", 7.25F );
            this.txtSearch.Properties.Appearance.Options.UseFont = true;
            this.txtSearch.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSearch.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtSearch.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 235 ) ) ) ), ( (int)( ( (byte)( 222 ) ) ) ) );
            this.txtSearch.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtSearch.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtSearch.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.txtSearch.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtSearch.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.txtSearch.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtSearch.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.txtSearch.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtSearch.Properties.AutoHeight = false;
            this.txtSearch.Properties.DisplayFormat.FormatString = "n0";
            this.txtSearch.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSearch.Properties.EditFormat.FormatString = "n0";
            this.txtSearch.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSearch.Size = new System.Drawing.Size( 268, 17 );
            this.txtSearch.TabIndex = 3;
            this.txtSearch.EditValueChanged += new System.EventHandler( this.TxtSearchEditValueChanged );
            // 
            // grdResult
            // 
            this.grdResult.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.grdResult.Location = new System.Drawing.Point( 8, 33 );
            this.grdResult.MainView = this.ViewResult;
            this.grdResult.Name = "grdResult";
            this.grdResult.Size = new System.Drawing.Size( 621, 333 );
            this.grdResult.TabIndex = 4;
            this.grdResult.ViewCollection.AddRange( new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ViewResult} );
            this.grdResult.DoubleClick += new System.EventHandler( this.GrdResultDoubleClick );
            this.grdResult.KeyDown += new System.Windows.Forms.KeyEventHandler( this.GrdResultKeyDown );
            // 
            // ViewResult
            // 
            this.ViewResult.GridControl = this.grdResult;
            this.ViewResult.GroupPanelText = "Arraste as colunas aqui para poder agrupa-las";
            this.ViewResult.Name = "ViewResult";
            this.ViewResult.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.ViewResult.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.ViewResult.OptionsBehavior.AllowIncrementalSearch = true;
            this.ViewResult.OptionsBehavior.Editable = false;
            this.ViewResult.OptionsNavigation.AutoFocusNewRow = true;
            this.ViewResult.OptionsNavigation.UseTabKey = false;
            this.ViewResult.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ViewResult.OptionsView.ColumnAutoWidth = false;
            // 
            // FormChooseFromList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 645, 430 );
            this.Name = "FormChooseFromList";
            this.Text = "FormChooseFromList";
            this.Load += new System.EventHandler( this.FormChooseFromListLoad );
            ( (System.ComponentModel.ISupportInitialize)( this.txtSearch.Properties ) ).EndInit( );
            ( (System.ComponentModel.ISupportInitialize)( this.grdResult ) ).EndInit( );
            ( (System.ComponentModel.ISupportInitialize)( this.ViewResult ) ).EndInit( );
            this.ResumeLayout( false );

        }

        

        private Button cmdOk;
        private Button cmdCancelar;
        private EditText txtSearch;
        private StaticText lblSerach;
        private DataGrid grdResult;
        protected DevExpress.XtraGrid.Views.Grid.GridView ViewResult;
    }
}