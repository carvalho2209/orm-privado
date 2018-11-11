using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Drawing;

namespace Nampula.UI
{

    public class MenuItem
    {

        public event MenuEventHandler OnBeforeClick;
        public event MenuEventHandler OnAfterClick;

        internal MenuItem ( )
        {
            SubMenus = new List<MenuItem>( );
        }

        public MenuItem ( string pString )
            : this( )
        {
            this.Type = BoMenuType.mt_POPUP;
            this.UID = GetNexID( );
            this.String = pString;
            this.Enabled = true;
            //this.Position = oSubMenus.Count;

            Application.GetInstance( ).AddMenu( "511", this );

        }

        public MenuItem ( MenuItem pMenus, BoMenuType pType, string pString, Bitmap pImage )
            : this( )
        {
            this.Type = pType;
            this.UID = GetNexID( );
            this.String = pString;
            this.Enabled = true;
            //this.Position = oSubMenus.Count;

            if ( pImage != null )
            {
                string FileName = Path.Combine( Path.GetTempPath( ), this.UID + ".png" );
                pImage.Save( FileName );
                this.Image = FileName;
            }

            Application.GetInstance( ).AddMenu( pMenus.UID, this );

        }

        public MenuItem ( MenuItem pMenus, BoMenuType pType, string pString )
            : this( pMenus, pType, pString, null )
        {
        }

        public bool Checked { get; set; }
        public bool Enabled { get; set; }
        public string Image { get; set; }
        public string String { get; set; }
        public List<MenuItem> SubMenus { get; set; }
        public BoMenuType Type { get; set; }
        public string UID { get; set; }

        //private void AddToMenuCollection ( ) {
        //    Application.GetInstance( ).MenuCollection.Add( this );
        //}

        public static int menuCount;

        private string GetNexID ( )
        {
            menuCount++;
            return ( "mnuL" + Application.GetInstance( ).NameSpace + menuCount ).ToString( );
        }

        
        internal void DoOnClick ( MenuEventArgs e )
        {
            if ( e.BeforeAction && OnBeforeClick != null )
                OnBeforeClick( this, e );
            else if ( !e.BeforeAction && OnAfterClick != null )
                OnAfterClick( this, e );
        }
        

        
        /// <summary>
        /// Realiva um clique no item do menu
        /// </summary>
        public void Activate ( )
        {
            ApplicationSAP.GetInstance( ).SAPApp.ActivateMenuItem( this.UID );
        }
        
    }


}

