using System;
using System.Text;

namespace Nampula.UI
{
    /// <summary>
    /// Componente combobox
    /// </summary>
    public class ComboBoxSimple : DevExpress.XtraEditors.ComboBoxEdit
    {
       /// <summary>
        /// Informações fonte de dados
        /// </summary>
        public string DataSourceInformation { get; set; }

        /// <summary>
        /// Construtor padrão
        /// </summary>
        public ComboBoxSimple()
        {
            InitializeComponent();

            VisualStyles.SetStyle(this);
        }
        
        private void InitializeComponent()
        {
            SuspendLayout();
            Font = new System.Drawing.Font("Tahoma", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Size = new System.Drawing.Size(121, 21);
            ResumeLayout(false);
        }        
    }
}
