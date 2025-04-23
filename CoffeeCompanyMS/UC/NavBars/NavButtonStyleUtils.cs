using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeCompanyMS.UC.NavBars
{
    internal class NavButtonStyleUtils
    {
        private static void ResetButtonStyle(Button button)
        {
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Color.Black;
        }

        public static void ResetButtonsStyle(Button[] buttons)
        {
            foreach (Button button in buttons)
            {
                ResetButtonStyle(button);
            }
        }

        public static void SetChosenButtonStyle(Button button)
        {
            button.FlatAppearance.BorderSize = 5;
            button.FlatAppearance.BorderColor = Color.Navy;
        }
    }
}
