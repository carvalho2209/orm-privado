using System.Drawing;

namespace Nampula.UI
{
    /// <summary>
    /// Componente que mostra texto estático lincado um textBox
    /// </summary>
    public class StaticText : System.Windows.Forms.Label
    {
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            if (LinkedTo != null)
            {
                var p = new Pen(VisualStyles.staticLineColor, 1f);
                e.Graphics.DrawLine(p, 0, Height - 1, Width - 1, Height - 1);
                SetSize();
            }
            base.OnPaint(e);
        }

        private System.Windows.Forms.Control m_LinkedTo;
        /// <summary>
        /// 
        /// </summary>
        public System.Windows.Forms.Control LinkedTo
        {
            get { return m_LinkedTo; }
            set
            {
                m_LinkedTo = value;
                SetSize();
            }
        }

        //private bool m_AutoSize;
        /// <summary>
        /// Auto redimencionar o controle
        /// </summary>
        public new bool AutoSize
        {
            get { return base.AutoSize; }
// ReSharper disable ValueParameterNotUsed
            set { base.AutoSize = false; }
// ReSharper restore ValueParameterNotUsed
        }

        private void SetSize()
        {
            if (m_LinkedTo == null) return;

            AutoSize = false;
            Width = m_LinkedTo.Left - Left;
            Top = m_LinkedTo.Top;
            Height = m_LinkedTo.Height;
        }

    }
}
