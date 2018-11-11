using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Nampula.UI
{
    public class WinAPI
    {
        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        static extern IntPtr GetWindow(IntPtr hwnd, GetWindowFlag wFlag);

        [DllImport("user32", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32", SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetWindowTextLength(IntPtr hWnd);

        enum GetWindowFlag : uint
        {
            GW_HWNDFIRST = 0,
            GW_HWNDLAST = 1,
            GW_HWNDNEXT = 2,
            GW_HWNDPREV = 3,
            GW_OWNER = 4,
            GW_CHILD = 5,
            GW_ENABLEDPOPUP = 6
        }

        /// <summary>
        /// Pega o handle de uma janela do windows
        /// </summary>
        /// <param name="pSapWindowName">Nome a Janela</param>
        /// <returns>Um handle da janela</returns>
        public static IntPtr GetParentWindowHandlerByName(string pSapWindowName, string pMenuSapFormName)
        {
            var hwnd = FindWindow(default(string), pSapWindowName);

            if (hwnd == IntPtr.Zero)
                return hwnd;

            var handleJanelaFilhaSap = GetWindow(hwnd, GetWindowFlag.GW_CHILD);

            foreach (var i in Enumerable.Range(1, 20))
            {
                handleJanelaFilhaSap = GetWindow(handleJanelaFilhaSap, GetWindowFlag.GW_HWNDNEXT);

                if (TemFilhoComONomeDaJanela(handleJanelaFilhaSap, pMenuSapFormName))
                    return handleJanelaFilhaSap;
            }

            return IntPtr.Zero;
        }

        private static bool TemFilhoComONomeDaJanela(IntPtr handleJanelaFilhaSap, string pMenuFormName)
        {
            var filhoDoMdi = GetWindow(handleJanelaFilhaSap, GetWindowFlag.GW_CHILD);

            foreach (var i in Enumerable.Range(1, 20))
            {
                if (filhoDoMdi == IntPtr.Zero)
                    break;

                if (pMenuFormName == GetText(filhoDoMdi))
                    return true;

                filhoDoMdi = GetWindow(filhoDoMdi, GetWindowFlag.GW_HWNDNEXT);
            }

            return false;
        }

        public static string GetText(IntPtr hWnd)
        {
            int length = GetWindowTextLength(hWnd);
            var sb = new StringBuilder(length + 1);
            GetWindowText(hWnd, sb, sb.Capacity);
            return sb.ToString();
        }
    }
}
