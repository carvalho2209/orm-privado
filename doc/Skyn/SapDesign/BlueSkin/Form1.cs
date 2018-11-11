using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.Drawing.Helpers;
using DevExpress.XtraEditors;

namespace SkinTeste
{
    public partial class Form1 : XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Region = NativeMethods.CreateRoundRegion(new Rectangle(Point.Empty, Size), 15);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Region = NativeMethods.CreateRoundRegion(new Rectangle(Point.Empty, Size), 115);
        }
    }
}
