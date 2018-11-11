using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Nampula.UI
{
    public class WinAPI
    {

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, IntPtr windowTitle);

        // For Windows Mobile, replace user32.dll with coredll.dll
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        // Find window by Caption only. Note you must pass IntPtr.Zero as the first parameter.

        //[DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        //static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        // You can also call FindWindow(default(string), lpWindowName) or FindWindow((string)null, lpWindowName)

        // Find window by Caption, and wait 1/2 a second and then try again.
        public IntPtr FindWindow(string windowName)
        {
            //IntPtr hWnd = FindWindow((string)null, windowName);
            //Process[] processes = Process.GetProcessesByName(windowName);
            IntPtr hWnd = GetHandleToHorizontalScrollBar(windowName);
            return hWnd;
        }

        private IntPtr GetHandleToHorizontalScrollBar(string pName)
        {
            // Locals
            IntPtr childHandle;
            string appDomainHexedHash;

            // Get the hexadecimal value of AppDomain hash code.
            // This value is dynamically appended to the window class name of the child window
            // for .NET Windows Forms.  This name is viewable via the Spy++ tool.
            appDomainHexedHash = AppDomain.CurrentDomain.GetHashCode().ToString("x");

            // Find window handle
            childHandle = FindWindowEx(
                IntPtr.Zero,    // Parent handle
                IntPtr.Zero,    // Child window after which to seek
                pName, // Class name to seek (viewable in the Spy++ tool)
                IntPtr.Zero);    // Window title to seek

            // Return handle
            return childHandle;
        }

        //// THE FOLLOWING METHOD REFERENCES THE SetForegroundWindow API
        //public static bool BringWindowToTop(string windowName, bool wait)
        //{
        //    int hWnd = FindWindow(windowName, wait);
        //    if (hWnd != 0)
        //    {
        //        return SetForegroundWindow((IntPtr)hWnd);
        //    }
        //    return false;
        //}

        [DllImport("user32", EntryPoint = "GetWindowLongA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int GetWindowLW(int hwnd, int nIndex);

        static int level;
        static int iFound;

        public static int FindWindowLike(ref int[] hWndArray, int hWndStart, string WindowText, string Classname, object ID, int lLevels)
        {

            string lpString = new string('\0', 0x100);
            if (level == 0)
            {
                iFound = 0;
                hWndArray = new int[1];
                if (hWndStart == 0)
                {
                    hWndStart = GetDesktopWindow();
                }
            }
            level++;
            for (int i = GetWindow(hWndStart, 5); i != 0; i = GetWindow(i, 2))
            {
                int windowLW;
                object obj2;
                System.Windows.Forms.Application.DoEvents();

                if (level <= lLevels)
                {
                    windowLW = FindWindowLike(ref hWndArray, i, WindowText, Classname, RuntimeHelpers.GetObjectValue(ID), lLevels);
                }

                lpString = Strings.Space(0xff);
                windowLW = GetWindowText(i, ref lpString, 0xff);
                lpString = Strings.Left(lpString, windowLW);                
                string lpClassName = Strings.Space(0xff);
                
                windowLW = GetClassName(i, ref lpClassName, 0xff);
                lpClassName = Strings.Left(lpClassName, windowLW);

                if (GetParent(i) != 0)
                {
                    windowLW = GetWindowLW(i, -12);
                    obj2 = Conversions.ToLong("&H" + Conversion.Hex(windowLW));
                }
                else
                {
                    obj2 = null;
                }
                if (LikeOperator.LikeString(lpString, WindowText, CompareMethod.Binary) & LikeOperator.LikeString(lpClassName, Classname, CompareMethod.Binary))
                {
                    if (ID == null)
                    {
                        iFound++;
                        hWndArray = (int[])Utils.CopyArray((Array)hWndArray, new int[iFound + 1]);
                        hWndArray[iFound] = i;
                    }
                    else if ((obj2 != null) && (Conversions.ToLong(obj2) == Conversions.ToLong(ID)))
                    {
                        iFound++;
                        hWndArray = (int[])Utils.CopyArray((Array)hWndArray, new int[iFound + 1]);
                        hWndArray[iFound] = i;
                    }
                }
            }
            level--;
            return iFound;

        }

        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int GetDesktopWindow();

        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int GetParent(int hwnd);

        [DllImport("user32", EntryPoint = "GetClassNameA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int GetClassName(int hwnd, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpClassName, int nMaxCount);

        [DllImport("user32", EntryPoint = "GetWindowTextA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int GetWindowText(int hwnd, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpString, int cch);

        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int GetWindow(int hwnd, int wCmd);

        private static int mlSAPWnd = 0;

        public static int GetSAPHandle(string pSAPWindowName)
        {
            int[] numArray = {0};

            if ((mlSAPWnd == 0) && (FindWindowLike(ref numArray, 0, pSAPWindowName, "TMFrameClass", null, 1) != 0))
            {
                return numArray[1];
            }
            return mlSAPWnd;
        }


        public static int GetSAPMDIChild(string pSAPWindowName)
        {
            int num2 = 0 ;
            int hwnd = GetSAPHandle(pSAPWindowName);
            string lpClassName = Strings.Space(0x100);

            if (hwnd == 0)
            {
                int num5 = 0;
                return num5;
            }

            int window = GetWindow(hwnd, 5);

            while ((num2 == 0) & (window != 0))
            {
                window = GetWindow(window, 2);
                int num3 = GetClassName(window, ref lpClassName, 0x100);
                if (window != 0)
                {
                    num3 = GetClassName(window, ref lpClassName, 0x100);
                    if (Strings.Left(lpClassName, Strings.InStr(lpClassName, "\0", CompareMethod.Binary) - 1) == "TMMDIClientClass")
                    {
                        num2 = 1;
                    }
                }
            }
            
            return window;

        }


        public class WindowWrapper : IWin32Window
        {

            private IntPtr _hwnd;
            //private static WindowWrapper m_Hanle;

            public WindowWrapper(IntPtr handle)
            {
                _hwnd = handle;
            }

            public System.IntPtr Handle
            {
                get { return _hwnd; }
            }

            //public static WindowWrapper GetWindowTop()
            //{
            //    m_Hanle = new WindowWrapper(LibWrap.GetForegroundWindow());
            //    return m_Hanle;
            //}

        }

        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);               


    }
}
