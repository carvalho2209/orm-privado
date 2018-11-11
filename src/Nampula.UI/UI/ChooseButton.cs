using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace Nampula.UI
{

    /// <summary>
    /// Um botão de choose
    /// </summary>
    [ToolboxItem(true)]
    public class ChooseButton : Control
    {


        /// <summary>
        /// Construção Padrão
        /// </summary>
        public ChooseButton()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.ResizeRedraw | ControlStyles.UserPaint
                 | ControlStyles.UserMouse | ControlStyles.SupportsTransparentBackColor, true);

            Invalidate();

        }

        private bool Clicked { get; set; }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Clicked = true;
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            Clicked = false;
            Invalidate();
            base.OnMouseUp(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            PaintBut(e);
        }

        //If  this component is resized i update him
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate(true);
        }


        //The Core of this control...
        protected void PaintBut(PaintEventArgs e)
        {
            var bmp = new Bitmap(Clicked ? Properties.Resources.ChooseFromLstBtnPresses : Properties.Resources.ChooseFromLstBtn);

            var attr = new ImageAttributes();

            attr.SetColorKey(Color.Red, Color.Red);

            var dstRect = new Rectangle(
                (Width / 2) - (bmp.Width / 2),
                (Height / 2) - (bmp.Height / 2), bmp.Width, bmp.Height);

            e.Graphics.DrawImage(bmp, dstRect, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attr);

        }

    }

}
