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
    public partial class fFastLoading : Page
    {
        public fFastLoading()
        {
            InitializeComponent();
        }

        private void cmdBack_Click(object sender, RoutedEventArgs e)
        {
            fMain oForm = new fMain();
            this.Content = oForm;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            int i = 0;
            ActiveGanttCSECtl1.Columns.Add("Tasks", "", 200, "");
            ActiveGanttCSECtl1.TreeviewColumnIndex = 1;
            ActiveGanttCSECtl1.Rows.BeginLoad(false);
            ActiveGanttCSECtl1.Tasks.BeginLoad(false);
            int lCurrentDepth = 0;
            for (i = 0; i <= 5000; i++)
            {
                clsRow oRow;
                clsTask oTask;
                oRow = ActiveGanttCSECtl1.Rows.Load("K" + i.ToString());
                oTask = ActiveGanttCSECtl1.Tasks.Load("K" + i.ToString(), "K" + i.ToString());
                oRow.Text = "Task K" + i.ToString();
                oRow.MergeCells = true;
                oRow.Node.Depth = lCurrentDepth;
                oTask.Text = "K" + i.ToString();
                oTask.StartDate = ActiveGanttCSECtl1.MathLib.DateTimeAdd(E_INTERVAL.IL_HOUR, Globals.GetRnd(0, 5), AGCSE.DateTime.Now);
                oTask.EndDate = ActiveGanttCSECtl1.MathLib.DateTimeAdd(E_INTERVAL.IL_HOUR, Globals.GetRnd(2, 7), oTask.StartDate);
                lCurrentDepth = lCurrentDepth + Globals.GetRnd(-1, 2);
                if (lCurrentDepth < 0)
                {
                    lCurrentDepth = 0;
                }
            }
            ActiveGanttCSECtl1.Tasks.EndLoad();
            ActiveGanttCSECtl1.Rows.EndLoad();
            ActiveGanttCSECtl1.Rows.BeginLoad(true);
            ActiveGanttCSECtl1.Tasks.BeginLoad(true);
            for (i = 5001; i <= 10000; i++)
            {
                clsRow oRow;
                clsTask oTask;
                oRow = ActiveGanttCSECtl1.Rows.Load("KL" + i.ToString());
                oTask = ActiveGanttCSECtl1.Tasks.Load("KL" + i.ToString(), "KL" + i.ToString());
                oRow.Text = "Task KL" + i.ToString();
                oRow.MergeCells = true;
                oTask.Text = "KL" + i.ToString();
                oTask.StartDate = ActiveGanttCSECtl1.MathLib.DateTimeAdd(E_INTERVAL.IL_HOUR, Globals.GetRnd(0, 5), AGCSE.DateTime.Now);
                oTask.EndDate = ActiveGanttCSECtl1.MathLib.DateTimeAdd(E_INTERVAL.IL_HOUR, Globals.GetRnd(2, 7), oTask.StartDate);
            }
            ActiveGanttCSECtl1.Tasks.EndLoad();
            ActiveGanttCSECtl1.Rows.EndLoad();
            ActiveGanttCSECtl1.Redraw();


        }

    }
}
