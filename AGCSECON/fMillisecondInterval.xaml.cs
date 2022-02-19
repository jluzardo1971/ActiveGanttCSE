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
    public partial class fMillisecondInterval : Page
    {
        public fMillisecondInterval()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            clsView oView;
            oView = ActiveGanttCSECtl1.Views.Add(E_INTERVAL.IL_MILLISECOND, 5, E_TIERTYPE.ST_MINUTE, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_SECOND, "MSI");
            oView.TimeLine.TickMarkArea.Visible = false;
            oView.TimeLine.TierArea.MiddleTier.Visible = false;
            oView.TimeLine.TierArea.TierFormat.MinuteIntervalFormat = "MMM dd, yyyy hh:mm tt";
            oView.TimeLine.Position(new AGCSE.DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day, System.DateTime.Now.Hour, System.DateTime.Now.Minute, 58));

            ActiveGanttCSECtl1.CurrentView = "MSI";

            int i = 0;
            ActiveGanttCSECtl1.Columns.Add("", "C1", 125, "");
            for (i = 1; i <= 10; i++)
            {
                clsRow oRow;
                oRow = ActiveGanttCSECtl1.Rows.Add("K" + i.ToString(), "K" + i.ToString(), true, true, "");
            }
        }

        private void ActiveGanttCSECtl1_CompleteObjectMove(object sender, AGCSE.ObjectStateChangedEventArgs e)
        {
            if (e.EventTarget == E_EVENTTARGET.EVT_TASK)
            {
                clsTask oTask;
                string sText;
                oTask = ActiveGanttCSECtl1.Tasks.Item(e.Index.ToString());
                sText = ActiveGanttCSECtl1.MathLib.DateTimeDiff(E_INTERVAL.IL_MILLISECOND, oTask.StartDate, oTask.EndDate).ToString();
                oTask.Text = sText + "ms";
            }
        }

        private void ActiveGanttCSECtl1_CompleteObjectSize(object sender, AGCSE.ObjectStateChangedEventArgs e)
        {
            if (e.EventTarget == E_EVENTTARGET.EVT_TASK)
            {
                clsTask oTask;
                string sText;
                oTask = ActiveGanttCSECtl1.Tasks.Item(e.Index.ToString());
                sText = ActiveGanttCSECtl1.MathLib.DateTimeDiff(E_INTERVAL.IL_MILLISECOND, oTask.StartDate, oTask.EndDate).ToString();
                oTask.Text = sText + "ms";
            }
        }

        private void ActiveGanttCSECtl1_ObjectAdded(object sender, AGCSE.ObjectAddedEventArgs e)
        {
            if (e.EventTarget == E_EVENTTARGET.EVT_TASK)
            {
                clsTask oTask;
                string sText;
                oTask = ActiveGanttCSECtl1.Tasks.Item(e.TaskIndex.ToString());
                sText = ActiveGanttCSECtl1.MathLib.DateTimeDiff(E_INTERVAL.IL_MILLISECOND, oTask.StartDate, oTask.EndDate).ToString();
                oTask.Text = sText + "ms";
            }
        }

        private void cmdBack_Click(object sender, RoutedEventArgs e)
        {
            fMain oForm = new fMain();
            this.Content = oForm;
        }

    }
}
