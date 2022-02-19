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
    public partial class fRCT_DAY : Page
    {
        public fRCT_DAY()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            clsView oView;
            oView = ActiveGanttCSECtl1.Views.Add(E_INTERVAL.IL_MINUTE, 10, E_TIERTYPE.ST_MONTH, E_TIERTYPE.ST_DAYOFWEEK, E_TIERTYPE.ST_DAYOFWEEK, "View1");
            oView.TimeLine.TierArea.MiddleTier.Visible = false;
            oView.TimeLine.TickMarkArea.Visible = false;

            ActiveGanttCSECtl1.CurrentView = "View1";

            int i = 0;
            for (i = 1; i <= 50; i++)
            {
                ActiveGanttCSECtl1.Rows.Add("K" + i.ToString());
            }

            clsTimeBlock oTimeBlock;

            oTimeBlock = ActiveGanttCSECtl1.TimeBlocks.Add("TB_OutOfOfficeHours");
            oTimeBlock.NonWorking = true;
            oTimeBlock.BaseDate = new AGCSE.DateTime(2000, 1, 1, 18, 0, 0);
            oTimeBlock.DurationInterval = E_INTERVAL.IL_HOUR;
            oTimeBlock.DurationFactor = 13;
            oTimeBlock.TimeBlockType = E_TIMEBLOCKTYPE.TBT_RECURRING;
            oTimeBlock.RecurringType = E_RECURRINGTYPE.RCT_DAY;

            oTimeBlock = ActiveGanttCSECtl1.TimeBlocks.Add("TB_LunchBreak");
            oTimeBlock.NonWorking = true;
            oTimeBlock.BaseDate = new AGCSE.DateTime(2000, 1, 1, 12, 0, 0);
            oTimeBlock.DurationInterval = E_INTERVAL.IL_MINUTE;
            oTimeBlock.DurationFactor = 90;
            oTimeBlock.TimeBlockType = E_TIMEBLOCKTYPE.TBT_RECURRING;
            oTimeBlock.RecurringType = E_RECURRINGTYPE.RCT_DAY;

        }

        private void cmdBack_Click(object sender, RoutedEventArgs e)
        {
            fMain oForm = new fMain();
            this.Content = oForm;
        }



    }
}
