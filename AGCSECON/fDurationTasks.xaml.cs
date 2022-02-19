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
using System.Diagnostics;

namespace AGCSECON
{
    public partial class fDurationTasks : Page
    {
        public fDurationTasks()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            ActiveGanttCSECtl1.AddMode = E_ADDMODE.AT_DURATION_BOTH;
            ActiveGanttCSECtl1.AddDurationInterval = E_INTERVAL.IL_HOUR;

            clsView oView;
            oView = ActiveGanttCSECtl1.Views.Add(E_INTERVAL.IL_MINUTE, 10, E_TIERTYPE.ST_MONTH, E_TIERTYPE.ST_DAYOFWEEK, E_TIERTYPE.ST_DAYOFWEEK, "View1");
            oView.TimeLine.TierArea.MiddleTier.Visible = false;
            oView.TimeLine.TickMarkArea.Visible = false;

            ActiveGanttCSECtl1.CurrentView = "View1";

            int i = 0;
            for (i = 0; i <= 110; i++)
            {
                ActiveGanttCSECtl1.Rows.Add("K" + i.ToString());
            }

            clsTimeBlock oTimeBlock;

            //Note: non-working overlapping TimeBlock objects are combined for duration calculation purposes.


            // TimeBlock starts at 6:00pm and ends on 7:00am next day (13 Hours)
            // This TimeBlock is repeated every day.
            oTimeBlock = ActiveGanttCSECtl1.TimeBlocks.Add("TB_OutOfOfficeHours");
            oTimeBlock.NonWorking = true;
            oTimeBlock.BaseDate = new AGCSE.DateTime(2000, 1, 1, 18, 0, 0);
            oTimeBlock.DurationInterval = E_INTERVAL.IL_HOUR;
            oTimeBlock.DurationFactor = 13;
            oTimeBlock.TimeBlockType = E_TIMEBLOCKTYPE.TBT_RECURRING;
            oTimeBlock.RecurringType = E_RECURRINGTYPE.RCT_DAY;

            // TimeBlock starts at 12:00pm (noon) and ends at 1:30pm (90 Minutes)
            // This TimeBlock is repeated every day. 
            oTimeBlock = ActiveGanttCSECtl1.TimeBlocks.Add("TB_LunchBreak");
            oTimeBlock.NonWorking = true;
            oTimeBlock.BaseDate = new AGCSE.DateTime(2000, 1, 1, 12, 0, 0);
            oTimeBlock.DurationInterval = E_INTERVAL.IL_MINUTE;
            oTimeBlock.DurationFactor = 90;
            oTimeBlock.TimeBlockType = E_TIMEBLOCKTYPE.TBT_RECURRING;
            oTimeBlock.RecurringType = E_RECURRINGTYPE.RCT_DAY;

            // Timeblock starts at 12:00am Saturday and ends on 12:00am Monday (48 Hours)
            // This TimeBlock is repeated every week.
            oTimeBlock = ActiveGanttCSECtl1.TimeBlocks.Add("TB_Weekend");
            oTimeBlock.NonWorking = true;
            oTimeBlock.BaseDate = new AGCSE.DateTime(2000, 1, 1, 0, 0, 0);
            oTimeBlock.DurationInterval = E_INTERVAL.IL_HOUR;
            oTimeBlock.DurationFactor = 48;
            oTimeBlock.TimeBlockType = E_TIMEBLOCKTYPE.TBT_RECURRING;
            oTimeBlock.RecurringType = E_RECURRINGTYPE.RCT_WEEK;
            oTimeBlock.BaseWeekDay = E_WEEKDAY.WD_SATURDAY;

            // Arbitrary holiday that starts at 12:00am January 8th and ends on 12:00am January 9th (24 hours)
            // This TimeBlock is repeated every year.
            oTimeBlock = ActiveGanttCSECtl1.TimeBlocks.Add("TB_Jan8");
            oTimeBlock.NonWorking = true;
            oTimeBlock.BaseDate = new AGCSE.DateTime(2000, 1, 8, 0, 0, 0);
            oTimeBlock.DurationInterval = E_INTERVAL.IL_HOUR;
            oTimeBlock.DurationFactor = 24;
            oTimeBlock.TimeBlockType = E_TIMEBLOCKTYPE.TBT_RECURRING;
            oTimeBlock.RecurringType = E_RECURRINGTYPE.RCT_YEAR;

            ActiveGanttCSECtl1.TimeBlocks.IntervalStart = new AGCSE.DateTime(2012, 1, 1);
            ActiveGanttCSECtl1.TimeBlocks.IntervalEnd = new AGCSE.DateTime(2023, 6, 1);
            ActiveGanttCSECtl1.TimeBlocks.IntervalType = E_TBINTERVALTYPE.TBIT_MANUAL;
            ActiveGanttCSECtl1.TimeBlocks.CalculateInterval();


            clsTask oTask;
            for (i = 0; i <= 100; i++)
            {
                oTask = ActiveGanttCSECtl1.Tasks.DAdd("K" + i.ToString(), new AGCSE.DateTime(2013, 1, 1), E_INTERVAL.IL_HOUR, i, i.ToString(), "", "", "0");

                AGCSE.DateTime dtStartDate;
                AGCSE.DateTime dtEndDate;

                dtStartDate = oTask.StartDate;
                dtEndDate = oTask.EndDate;

                int lDuration = 0;
                lDuration = ActiveGanttCSECtl1.MathLib.CalculateDuration(ref dtStartDate, ref dtEndDate, oTask.DurationInterval);
                if (lDuration != oTask.DurationFactor)
                {
                    Debug.WriteLine("Error: " + i.ToString());
                    Debug.WriteLine("  Task Duration Factor: " + oTask.DurationFactor.ToString());
                    Debug.WriteLine("  Calculated Duration: " + lDuration.ToString());
                    Debug.WriteLine("  Task:");
                    Debug.WriteLine("    " + oTask.StartDate.ToString("yyyy/MM/dd HH:mm:ss"));
                    Debug.WriteLine("    " + oTask.EndDate.ToString("yyyy/MM/dd HH:mm:ss"));
                    Debug.WriteLine("  Calculated:");
                    Debug.WriteLine("    " + dtStartDate.ToString("yyyy/MM/dd HH:mm:ss"));
                    Debug.WriteLine("    " + dtEndDate.ToString("yyyy/MM/dd HH:mm:ss"));
                }

            }

            ActiveGanttCSECtl1.CurrentViewObject.TimeLine.Position(new AGCSE.DateTime(2013, 1, 1));
        }

        private void cmdBack_Click(object sender, RoutedEventArgs e)
        {
            fMain oForm = new fMain();
            this.Content = oForm;
        }

    }
}
