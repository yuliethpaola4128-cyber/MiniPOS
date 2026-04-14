using System;
using System.Windows.Forms;
using MiniPOS.Forms;
namespace MiniPOS
{
    

    namespace MiniPOS
    {
        internal static class Program
        {
            [STAThread]
            static void Main()
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new frmLogin());
            }
        }
    }
}