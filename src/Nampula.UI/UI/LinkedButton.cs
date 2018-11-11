using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Nampula.UI
{

    [ToolboxItem(true)]
    public class LinkedButton : Control
    {


        public LinkedButton()
        {

            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.ResizeRedraw | ControlStyles.UserPaint
                 | ControlStyles.UserMouse | ControlStyles.SupportsTransparentBackColor, true);

            this.LinkedObjectType = BoLinkedObject.lf_None;

            this.Invalidate();

        }

        private bool Clicked { get; set; }

        protected override void OnClick(EventArgs e)
        {

            if (this.LinkedObjectType == BoLinkedObject.lf_None)
            {
                base.OnClick(e);
                return;
            }

            if (this.LinkedTo == null)
            {
                Application.GetInstance().SetTextOnStatusBar("Não há EditText Lincado !", BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Error);
                return;
            }

            var myNewLinkedEventArgs = new LinkedButtonEventArgs();

            myNewLinkedEventArgs.LinkedObjectType = LinkedObjectType;
            myNewLinkedEventArgs.Values = new List<object>() { LinkedTo.EditValue };

            Application.GetInstance().PeformLinkedButton(this, myNewLinkedEventArgs);

        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Clicked = true;
            this.Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            Clicked = false;
            this.Invalidate();
            base.OnMouseUp(e);
        }

        //i overide the default paint
        //and do my special routine...
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            this.PaintBut(e);
        }

        //If  this component is resized i update him
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate(true);
        }

        //The Core of this control...
        protected void PaintBut(PaintEventArgs e)
        {

            Bitmap bmp = new Bitmap(this.Clicked ? Nampula.UI.Properties.Resources.LinkBtnPressed : Nampula.UI.Properties.Resources.LinkBtn);

            ImageAttributes attr = new ImageAttributes();

            attr.SetColorKey(Color.Red, Color.Red);

            System.Drawing.Rectangle dstRect = new System.Drawing.Rectangle(
                (this.Width / 2) - (bmp.Width / 2),
                (this.Height / 2) - (bmp.Height / 2), bmp.Width, bmp.Height);

            e.Graphics.DrawImage(bmp, dstRect, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attr);

        }

        EditText m_LinkedTo;
        public EditText LinkedTo
        {
            get { return m_LinkedTo; }
            set
            {
                m_LinkedTo = value;
                SetSize();
            }
        }

        private void SetSize()
        {
            try
            {

                if (LinkedTo != null)
                {
                    this.AutoSize = false;
                    this.Width = 20;
                    this.Top = LinkedTo.Top;
                    this.Height = LinkedTo.Height - 3;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [DefaultValue(BoLinkedObject.lf_None)]
        public BoLinkedObject LinkedObjectType { get; set; }

    }

}
