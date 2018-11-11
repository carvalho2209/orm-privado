using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Nampula.UI {

    public class Rectangle : System.Windows.Forms.Panel {

        public Rectangle () {

        }

        protected override void OnPaint ( System.Windows.Forms.PaintEventArgs e ) {

            e.Graphics.Clear ( SystemColors.Control );

            Pen p = new Pen ( Color.White, 1f );
            e.Graphics.DrawRectangle ( p, 0, 0, this.Width - 1, this.Height - 1 );
            base.OnPaint ( e );
        }

    }
}
