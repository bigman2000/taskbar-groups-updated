using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace client.Classes
{
    public static class WindowHelper
    {
        private const int DWMWA_WINDOW_CORNER_PREFERENCE = 33;
        private const int DWMWCP_ROUND = 2;
        private const int SW_RESTORE = 9;

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("dwmapi.dll", PreserveSig = true)]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

        [DllImport("kernel32.dll")]
        private static extern uint GetCurrentThreadId();

        public static void EnableRoundedCorners(IntPtr handle)
        {
            try
            {
                int preference = DWMWCP_ROUND;
                DwmSetWindowAttribute(handle, DWMWA_WINDOW_CORNER_PREFERENCE, ref preference, sizeof(int));
            }
            catch
            {
                // Ignored on older Windows versions that do not support DWMWA_WINDOW_CORNER_PREFERENCE
            }
        }

        public static bool ActivateProcessWindow(ICollection<int> processIds)
        {
            if (processIds == null || processIds.Count == 0)
                return false;

            IntPtr targetHwnd = IntPtr.Zero;
            HashSet<int> pidSet = new HashSet<int>(processIds);

            EnumWindows((hWnd, lParam) =>
            {
                if (!IsWindowVisible(hWnd))
                    return true;

                GetWindowThreadProcessId(hWnd, out uint pid);
                if (pidSet.Contains((int)pid))
                {
                    targetHwnd = hWnd;
                    return false;
                }
                return true;
            }, IntPtr.Zero);

            if (targetHwnd == IntPtr.Zero)
                return false;

            if (IsIconic(targetHwnd))
            {
                ShowWindow(targetHwnd, SW_RESTORE);
            }

            IntPtr fgHwnd = GetForegroundWindow();
            uint fgThread = fgHwnd != IntPtr.Zero ? GetWindowThreadProcessId(fgHwnd, out _) : 0;
            uint curThread = GetCurrentThreadId();

            if (fgThread != 0 && fgThread != curThread)
            {
                AttachThreadInput(curThread, fgThread, true);
                SetForegroundWindow(targetHwnd);
                AttachThreadInput(curThread, fgThread, false);
            }
            else
            {
                SetForegroundWindow(targetHwnd);
            }

            return true;
        }

        public static bool CloseProcessWindows(ICollection<int> processIds)
        {
            if (processIds == null || processIds.Count == 0)
                return false;

            bool anyClosed = false;
            foreach (int pid in processIds)
            {
                try
                {
                    using (Process proc = Process.GetProcessById(pid))
                    {
                        if (proc.CloseMainWindow())
                        {
                            anyClosed = true;
                        }
                    }
                }
                catch
                {
                    // Process may have exited or have no main window
                }
            }

            return anyClosed;
        }
    }
}

