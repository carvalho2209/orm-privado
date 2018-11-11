using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.UI
{

    public class Desktop
    {

        public Desktop ( )
        {
        }

        public Desktop ( int pWidth, int pHeight )
            : base( )
        {
            this.Width = pWidth;
            this.Height = pHeight;
        }

        public int Height { get; set; }
        public int Left { get; set; }
        public BoFormStateEnum State { get; set; }
        public string Title { get; set; }
        public int Top { get; set; }
        public string WallPaper { get; set; }
        public BoWallpaperDisplayTypes WallpaperDisplayType { get; set; }
        public int Width { get; set; }

    }

}
