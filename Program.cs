using System;
using System.Windows.Forms;
using HookApp;

namespace WindowsFormsApplication1
{
    static class Program
    {

        [STAThread]
        private static void Main(string[] args)
        {
            KeyboardHook keyboardHook = new KeyboardHook();
            keyboardHook.Install();
            Application.Run(keyboardHook);
        }

    }
}
