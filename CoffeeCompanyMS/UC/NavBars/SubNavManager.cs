using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeCompanyMS.Navigations
{
    public static class SubNavManager
    {
        private static Panel _subNavPanel;
        private static Panel _pagePanel;

        private static UserControl currentSubNav;
        private static UserControl currentPage;

        public static void Initialize(Panel subNavPanel, Panel pagePanel)
        {
            _subNavPanel = subNavPanel;
            _pagePanel = pagePanel;
        }

        public static void ShowSubNav(UserControl subNav)
        {
            if (currentSubNav != null)
                _subNavPanel.Controls.Remove(currentSubNav);

            currentSubNav = subNav;
            subNav.Dock = DockStyle.Fill;
            _subNavPanel.Controls.Add(subNav);
        }

        public static void ShowPage(UserControl page)
        {
            if (currentPage != null)
                _pagePanel.Controls.Remove(currentPage);

            currentPage = page;
            page.Dock = DockStyle.Fill;
            _pagePanel.Controls.Add(page);
        }
    }

}
