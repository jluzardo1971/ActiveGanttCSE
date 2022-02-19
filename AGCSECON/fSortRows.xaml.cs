using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using AGCSE;

namespace AGCSECON
{
    public partial class fSortRows : Page
    {

        private bool mp_bDescending = false;

        public fSortRows()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            int i = 0;
            ActiveGanttCSECtl1.Columns.Add("", "C1", 125, "");
            for (i = 1; i <= 10; i++)
            {
                string si = null;
                si = i.ToString();
                while (si.Length < 2)
                {
                    si = "0" + si;
                }
                ActiveGanttCSECtl1.Rows.Add("K" + si, "K" + si, true, true, "");
            }
        }

        private void cmdSortRows_Click(object sender, RoutedEventArgs e)
        {
            mp_bDescending = !mp_bDescending;
            ActiveGanttCSECtl1.Rows.SortRows("Text", mp_bDescending, E_SORTTYPE.ES_STRING, -1, -1);
            ActiveGanttCSECtl1.Redraw();
        }

        private void cmdBack_Click(object sender, RoutedEventArgs e)
        {
            fMain oForm = new fMain();
            this.Content = oForm;
        }

    }
}
