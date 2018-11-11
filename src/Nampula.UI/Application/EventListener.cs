using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Nampula.UI
{

    public class MenuEventsListing : Stack<MenuEvent>
    {

        public delegate void OnAfterLoadEventHandler ( MenuEvent pEvent );
        public event OnAfterLoadEventHandler OnReceiveEvent;

        Thread myThread;

        public MenuEventsListing ( )
        {
            myThread = new Thread( DoListing );
            System.Windows.Forms.Application.ApplicationExit += new EventHandler( Application_ApplicationExit );
            myThread.SetApartmentState( ApartmentState.STA );
            myThread.Start( );
        }

        void Application_ApplicationExit ( object sender, EventArgs e )
        {
            myThread.Abort( );
        }

        //[MTAThread]t
        public void DoListing ( )
        {

            do
            {
                Thread.Sleep( 100 );

                System.Windows.Forms.Application.DoEvents( );

                if ( this.Count > 0 & OnReceiveEvent != null )
                {
                    OnReceiveEvent( this.Pop( ) );
                }

            } while ( true );
        }

        ~MenuEventsListing ( )
        {
        }


    }

    //public class ItemEventsListing : Stack<ItemEvent>
    //{

    //    public delegate void OnAfterLoadEventHandler ( ItemEvent pEvent );
    //    public event OnAfterLoadEventHandler OnReceiveEvent;

    //    Thread myThread;

    //    //public ItemEventsListing () {
    //    //    myThread = new Thread ( DoListing );
    //    //    myThread.ApartmentState = ApartmentState.STA;
    //    //    myThread.Start ( );
    //    //}

    //    //[STAThread]
    //    //public void DoListing () {

    //    //    do {
    //    //        //Thread.Sleep(1);

    //    //        System.Windows.Forms.Application.DoEvents ( );

    //    //        if ( this.Count > 0 & OnReceiveEvent != null ) {
    //    //            OnReceiveEvent ( this.Pop ( ) );
    //    //        }

    //    //    } while ( true );
    //    //}

    //    ~ItemEventsListing ( )
    //    {
    //        //myThread.Suspend();
    //    }


    //}
}
