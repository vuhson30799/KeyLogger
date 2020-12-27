using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Reflection;
using System.ComponentModel;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace HookApp
{
    public partial class KeyboardHook : Form
    {
        public KeyboardHook()
        {
            InitializeComponent();
            pureInfo = "";
            history = new Dictionary<string, string>();
        }

        #region Win32 API Functions and Constants

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
        KeyboardHookDelegate lpfn, IntPtr hMod, int dwThreadId);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
        IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private const int WH_KEYBOARD_LL = 13;

        private const int WM_KEYDOWN = 0x0100;
        #endregion

        private string currentWindow;
        private string pureInfo;
        private Dictionary<String, String> history;
        
        private KeyboardHookDelegate _hookProc;
        private IntPtr _hookHandle = IntPtr.Zero;
        public delegate IntPtr KeyboardHookDelegate(int nCode, IntPtr wParam, IntPtr lParam);

        [StructLayout(LayoutKind.Sequential)]
        public struct KeyboardHookStruct
        {
            public int VirtualKeyCode;
            public int ScanCode;
            public int Flags;
            public int Time;
            public int ExtraInfo;
        }

        ~KeyboardHook()
        {
            Uninstall();
        }

        public void Install()
        {
            _hookProc = KeyboardHookProc;
            _hookHandle = SetupHook(_hookProc);
            currentWindow = GetActiveWindowsTXT();
            textBoxWindowName.Text = currentWindow;
            this.TopMost = true;

            if (_hookHandle == IntPtr.Zero)
                throw new Win32Exception(Marshal.GetLastWin32Error());
            
        }

        public void Uninstall()
        {
            UnhookWindowsHookEx(_hookHandle);
        }

        private string GetActiveWindowsTXT()
        {
            try
            {
                int chars = 256;
                StringBuilder buff = new StringBuilder(chars);
                IntPtr handle = GetForegroundWindow();
                string RET = "";
                if (handle != null)
                {
                    if (GetWindowText(handle, buff, chars) > 0)
                    {
                        RET = buff.ToString();
                    }
                }

                return RET;
            }
            catch
            {
                return "No Windows Active";
            }
        }

        private IntPtr SetupHook(KeyboardHookDelegate hookProc)
        {
            IntPtr hInstance = Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]);

            return SetWindowsHookEx(WH_KEYBOARD_LL, hookProc, hInstance, 0);
        }

        private IntPtr KeyboardHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                KeyboardHookStruct kbStruct = (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));

                if (wParam == (IntPtr)WM_KEYDOWN)
                {
                    if (currentWindow.CompareTo(GetActiveWindowsTXT()) != 0)
                    {
                        resetCurrentState();
                    }
                    Keys k = (Keys)kbStruct.VirtualKeyCode;

                    if (k != Keys.LWin)
                    {
                        pureInfo = pureInfo.Insert(pureInfo.Length, k.ToString());
                        textBoxKeyInfo.AppendText("Key has been clicked: " + k.ToString() + "\n");
                        return (IntPtr)0;
                    }
                }
            }

            return CallNextHookEx(_hookHandle, nCode, wParam, lParam);
        }

        private void resetCurrentState()
        {
            logHistory();
            textBoxHistory.AppendText("[" + currentWindow + "]\r\n");
            if (pureInfo.Length != 0)
            {
                textBoxHistory.AppendText(pureInfo + "\r\n");
            }
            else
            {
                textBoxHistory.AppendText(pureInfo + "Keys have not been clicked yet on this window.\r\n");
            }
            textBoxHistory.AppendText("\t***===========***\r\n");
            currentWindow = GetActiveWindowsTXT();
            textBoxWindowName.Text = currentWindow;

            textBoxKeyInfo.Clear();
            pureInfo = "";
        }

        private void logHistory()
        {
            string previousValue;
            if (history.TryGetValue(currentWindow,out previousValue))
            {
                string addedValue = previousValue + pureInfo;
                history.Remove(currentWindow);
                history.Add(currentWindow, addedValue);
            } else
            {
                history.Add(currentWindow, pureInfo);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            logHistory();
            saveHistoryToLogFile();
            Application.Exit();
        }

        private void saveHistoryToLogFile()
        {

            FileStream fileStream = new FileStream("D:\\log.txt", FileMode.Append, FileAccess.Write, FileShare.Read);
            
            using (StreamWriter streamWriter = new StreamWriter(fileStream))
            {
                streamWriter.WriteLine(System.DateTime.Now);
                foreach (var window in history)
                {
                    string title = window.Key;
                    string content = window.Value;
                    streamWriter.WriteLine("[ " + title + " ]");
                    if (!string.IsNullOrEmpty(content))
                    {
                        streamWriter.WriteLine(content);
                    }
                    streamWriter.WriteLine();
                    streamWriter.WriteLine("****------------------****");
                }
            }
        }
    }
}