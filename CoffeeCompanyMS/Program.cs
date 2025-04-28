using CoffeeCompanyMS.UI;
using CoffeeCompanyMS.UI.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeCompanyMS
{
    internal static class Program
    {
        public static Login loginForm;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            loginForm = new Login();
            Application.Run(loginForm);
        }
    }
}
