using System;
using System.Drawing;
using System.Windows.Forms;

namespace Views
{
    class Program
    {
        [STAThread]
        static void Main ()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TelaInicial());
        }
    }
} 