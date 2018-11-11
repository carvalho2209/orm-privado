using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace NampulaDemo
{
    public class TesteClassFormShowModal
    {
        public bool Dummy ( )
        {

            // create the login dialog
            var myDialog = new FormGridDemo( );

            // How we show it depends on where we are. We might be in the main thread, or in a background thread
            // (There may be better ways of doing this??)
            if ( SynchronizationContext.Current == null )
            {
                // We are in the main thread. Just display the dialog
                DialogResult result = myDialog.ShowDialog( );
                return result == DialogResult.OK;
            }
            else
            {
                // Get the window handle of the main window of the calling process
                IntPtr windowHandle = Process.GetCurrentProcess( ).MainWindowHandle;

                if ( windowHandle == IntPtr.Zero )
                {
                    // No window displayed yet
                    DialogResult result = myDialog.ShowDialog( );
                    return result == DialogResult.OK;
                }
                else
                {
                    // Parent window exists on separate thread
                    // We want the dialog box to appear in front of the main window in the calling program
                    // We would like to be able to do 'myDialog.ShowDialog(windowHandleWrapper)', but that means doing something on the UI thread
                    object resultState = null;
                    SynchronizationContext.Current.Send(
                        new SendOrPostCallback( delegate( object state ) { resultState = myDialog.ShowDialog( ); } ), resultState );

                    if ( resultState is DialogResult )
                    {
                        var result = (DialogResult)resultState;
                        return result == DialogResult.OK;
                    }
                    else
                        return false;

                }
            }
        }
    }

}
