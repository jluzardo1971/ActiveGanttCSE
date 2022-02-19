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
    public partial class fRCT_MONTH : Page
    {
        public fRCT_MONTH()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            clsView oView;
            oView = ActiveGanttCSECtl1.Views.Add(E_INTERVAL.IL_HOUR, 1, E_TIERTYPE.ST_MONTH, E_TIERTYPE.ST_DAYOFWEEK, E_TIERTYPE.ST_DAYOFWEEK, "View1");
            oView.TimeLine.TierArea.MiddleTier.Visible = false;
            oView.TimeLine.TickMarkArea.Visible = false;
            ActiveGanttCSECtl1.TierFormatScope = E_TIERFORMATSCOPE.TFS_CONTROL;
            ActiveGanttCSECtl1.TierFormat.DayOfWeekIntervalFormat = "dd";

            ActiveGanttCSECtl1.CurrentView = "View1";

            int i = 0;
            for (i = 1; i <= 50; i++)
            {
                ActiveGanttCSECtl1.Rows.Add("K" + i.ToString());
            }

            clsTimeBlock oTimeBlock;
            AGCSE.DateTime dtDate;
            dtDate = new AGCSE.DateTime(2000, 1, 1, 0, 0, 0);

            oTimeBlock = ActiveGanttCSECtl1.TimeBlocks.Add("TimeBlock1");
            oTimeBlock.BaseDate = dtDate;
            oTimeBlock.DurationInterval = E_INTERVAL.IL_HOUR;
            oTimeBlock.DurationFactor = -48;
            oTimeBlock.TimeBlockType = E_TIMEBLOCKTYPE.TBT_RECURRING;
            oTimeBlock.RecurringType = E_RECURRINGTYPE.RCT_MONTH;

        }

        private void cmdBack_Click(object sender, RoutedEventArgs e)
        {
            fMain oForm = new fMain();
            this.Content = oForm;
        }



    }
}
