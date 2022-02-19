using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace AGCSE
{
	public class clsTierAppearance
	{
    
		private ActiveGanttCSECtl mp_oControl;
        public clsTierColors MicrosecondColors;
        public clsTierColors MillisecondColors;
        public clsTierColors SecondColors;
		public clsTierColors MinuteColors;
		public clsTierColors HourColors;
		public clsTierColors DayColors;
		public clsTierColors DayOfWeekColors;
		public clsTierColors DayOfYearColors;
		public clsTierColors WeekColors;
		public clsTierColors MonthColors;
		public clsTierColors QuarterColors;
		public clsTierColors YearColors;
    
		internal clsTierAppearance(ActiveGanttCSECtl Value)
		{
            Color Colors_DimGray = Color.FromArgb(255, 105, 105, 105);
            Color Colors_Silver = Color.FromArgb(255, 192, 192, 192);
            Color Colors_CornflowerBlue = Color.FromArgb(255, 100, 149, 237);
            Color Colors_MediumSlateBlue = Color.FromArgb(255, 123, 104, 238);
            Color Colors_SlateBlue = Color.FromArgb(255, 106, 90, 205);
            Color Colors_RoyalBlue = Color.FromArgb(255, 65, 105, 225);
            Color Colors_SteelBlue = Color.FromArgb(255, 70, 130, 180);
            Color Colors_CadetBlue = Color.FromArgb(255, 95, 158, 160);
            Color Colors_DodgerBlue = Color.FromArgb(255, 30, 144, 255);


            mp_oControl = Value;
            MicrosecondColors = new clsTierColors(mp_oControl, E_TIERTYPE.ST_MICROSECOND);
            MicrosecondColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black);
            MicrosecondColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black);
            MicrosecondColors.Add(Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black);
            MicrosecondColors.Add(Colors_Silver, Colors.Black, Colors_Silver, Colors.Black, Colors_Silver, Colors.Black);
            MicrosecondColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black);
            MicrosecondColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black);
            MicrosecondColors.Add(Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black);
            MicrosecondColors.Add(Colors_Silver, Colors.Black, Colors_Silver, Colors.Black, Colors_Silver, Colors.Black);
            MicrosecondColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black);
            MicrosecondColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black);
            MillisecondColors = new clsTierColors(mp_oControl, E_TIERTYPE.ST_MILLISECOND);
            MillisecondColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black);
            MillisecondColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black);
            MillisecondColors.Add(Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black);
            MillisecondColors.Add(Colors_Silver, Colors.Black, Colors_Silver, Colors.Black, Colors_Silver, Colors.Black);
            MillisecondColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black);
            MillisecondColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black);
            MillisecondColors.Add(Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black);
            MillisecondColors.Add(Colors_Silver, Colors.Black, Colors_Silver, Colors.Black, Colors_Silver, Colors.Black);
            MillisecondColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black);
            MillisecondColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black);
            SecondColors = new clsTierColors(mp_oControl, E_TIERTYPE.ST_SECOND);
            SecondColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black);
            SecondColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black);
            SecondColors.Add(Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black);
            SecondColors.Add(Colors_Silver, Colors.Black, Colors_Silver, Colors.Black, Colors_Silver, Colors.Black);
            SecondColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black);
            SecondColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black);
            SecondColors.Add(Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black);
            SecondColors.Add(Colors_Silver, Colors.Black, Colors_Silver, Colors.Black, Colors_Silver, Colors.Black);
            SecondColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black);
            SecondColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black);
            MinuteColors = new clsTierColors(mp_oControl, E_TIERTYPE.ST_MINUTE);
            MinuteColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black);
            MinuteColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black);
            MinuteColors.Add(Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black);
            MinuteColors.Add(Colors_Silver, Colors.Black, Colors_Silver, Colors.Black, Colors_Silver, Colors.Black);
            MinuteColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black);
            MinuteColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black);
            MinuteColors.Add(Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black);
            MinuteColors.Add(Colors_Silver, Colors.Black, Colors_Silver, Colors.Black, Colors_Silver, Colors.Black);
            MinuteColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black);
            MinuteColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black);
            HourColors = new clsTierColors(mp_oControl, E_TIERTYPE.ST_HOUR);
            HourColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black);
            HourColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black);
            HourColors.Add(Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black);
            HourColors.Add(Colors_Silver, Colors.Black, Colors_Silver, Colors.Black, Colors_Silver, Colors.Black);
            HourColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black);
            HourColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black);
            HourColors.Add(Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black);
            HourColors.Add(Colors_Silver, Colors.Black, Colors_Silver, Colors.Black, Colors_Silver, Colors.Black);
            HourColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black);
            HourColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black);
            DayColors = new clsTierColors(mp_oControl, E_TIERTYPE.ST_DAY);
            DayColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black);
            DayColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black);
            DayColors.Add(Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black);
            DayColors.Add(Colors_Silver, Colors.Black, Colors_Silver, Colors.Black, Colors_Silver, Colors.Black);
            DayColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black);
            DayColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black);
            DayColors.Add(Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black);
            DayColors.Add(Colors_Silver, Colors.Black, Colors_Silver, Colors.Black, Colors_Silver, Colors.Black);
            DayColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black);
            DayColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black);
            DayOfWeekColors = new clsTierColors(mp_oControl, E_TIERTYPE.ST_DAYOFWEEK);
            DayOfWeekColors.Add(Colors_CornflowerBlue, Colors.Black, Colors_CornflowerBlue, Colors.Black, Colors_CornflowerBlue, Colors.Black, "Sunday");
            DayOfWeekColors.Add(Colors_MediumSlateBlue, Colors.Black, Colors_MediumSlateBlue, Colors.Black, Colors_MediumSlateBlue, Colors.Black, "Monday");
            DayOfWeekColors.Add(Colors_SlateBlue, Colors.Black, Colors_SlateBlue, Colors.Black, Colors_SlateBlue, Colors.Black, "Tuesday");
            DayOfWeekColors.Add(Colors_RoyalBlue, Colors.Black, Colors_RoyalBlue, Colors.Black, Colors_RoyalBlue, Colors.Black, "Wednesday");
            DayOfWeekColors.Add(Colors_SteelBlue, Colors.Black, Colors_SteelBlue, Colors.Black, Colors_SteelBlue, Colors.Black, "Thursday");
            DayOfWeekColors.Add(Colors_CadetBlue, Colors.Black, Colors_CadetBlue, Colors.Black, Colors_CadetBlue, Colors.Black, "Friday");
            DayOfWeekColors.Add(Colors_DodgerBlue, Colors.Black, Colors_DodgerBlue, Colors.Black, Colors_DodgerBlue, Colors.Black, "Saturday");
            DayOfYearColors = new clsTierColors(mp_oControl, E_TIERTYPE.ST_DAYOFYEAR);
            DayOfYearColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black);
            DayOfYearColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black);
            DayOfYearColors.Add(Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black);
            DayOfYearColors.Add(Colors_Silver, Colors.Black, Colors_Silver, Colors.Black, Colors_Silver, Colors.Black);
            DayOfYearColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black);
            DayOfYearColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black);
            DayOfYearColors.Add(Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black);
            DayOfYearColors.Add(Colors_Silver, Colors.Black, Colors_Silver, Colors.Black, Colors_Silver, Colors.Black);
            DayOfYearColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black);
            DayOfYearColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black);
            WeekColors = new clsTierColors(mp_oControl, E_TIERTYPE.ST_WEEK);
            WeekColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black);
            WeekColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black);
            WeekColors.Add(Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black);
            WeekColors.Add(Colors_Silver, Colors.Black, Colors_Silver, Colors.Black, Colors_Silver, Colors.Black);
            WeekColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black);
            WeekColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black);
            WeekColors.Add(Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black);
            WeekColors.Add(Colors_Silver, Colors.Black, Colors_Silver, Colors.Black, Colors_Silver, Colors.Black);
            WeekColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black);
            WeekColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black);
            MonthColors = new clsTierColors(mp_oControl, E_TIERTYPE.ST_MONTH);
            MonthColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, "January");
            MonthColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, "February");
            MonthColors.Add(Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black, "March");
            MonthColors.Add(Colors_Silver, Colors.Black, Colors_Silver, Colors.Black, Colors_Silver, Colors.Black, "April");
            MonthColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, "May");
            MonthColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, "June");
            MonthColors.Add(Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black, "July");
            MonthColors.Add(Colors_Silver, Colors.Black, Colors_Silver, Colors.Black, Colors_Silver, Colors.Black, "August");
            MonthColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, "September");
            MonthColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, "October");
            MonthColors.Add(Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black, "November");
            MonthColors.Add(Colors_Silver, Colors.Black, Colors_Silver, Colors.Black, Colors_Silver, Colors.Black, "December");
            QuarterColors = new clsTierColors(mp_oControl, E_TIERTYPE.ST_QUARTER);
            QuarterColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black);
            QuarterColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black);
            QuarterColors.Add(Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black);
            QuarterColors.Add(Colors_Silver, Colors.Black, Colors_Silver, Colors.Black, Colors_Silver, Colors.Black);
            YearColors = new clsTierColors(mp_oControl, E_TIERTYPE.ST_YEAR);
            YearColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black);
            YearColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black);
            YearColors.Add(Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black);
            YearColors.Add(Colors_Silver, Colors.Black, Colors_Silver, Colors.Black, Colors_Silver, Colors.Black);
            YearColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black);
            YearColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black);
            YearColors.Add(Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black, Colors.DarkGray, Colors.Black);
            YearColors.Add(Colors_Silver, Colors.Black, Colors_Silver, Colors.Black, Colors_Silver, Colors.Black);
            YearColors.Add(Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black, Colors_DimGray, Colors.Black);
            YearColors.Add(Colors.Gray, Colors.Black, Colors.Gray, Colors.Black, Colors.Gray, Colors.Black);
		}

        public string GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "TierAppearance");
            oXML.InitializeWriter();
            oXML.WriteObject(DayColors.GetXML());
            oXML.WriteObject(DayOfWeekColors.GetXML());
            oXML.WriteObject(DayOfYearColors.GetXML());
            oXML.WriteObject(HourColors.GetXML());
            oXML.WriteObject(MinuteColors.GetXML());
            oXML.WriteObject(SecondColors.GetXML());
            oXML.WriteObject(MillisecondColors.GetXML());
            oXML.WriteObject(MicrosecondColors.GetXML());
            oXML.WriteObject(MonthColors.GetXML());
            oXML.WriteObject(QuarterColors.GetXML());
            oXML.WriteObject(WeekColors.GetXML());
            oXML.WriteObject(YearColors.GetXML());
            return oXML.GetXML();
        }


        public void SetXML(string sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "TierAppearance");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            DayColors.SetXML(oXML.ReadObject("DayColors"));
            DayOfWeekColors.SetXML(oXML.ReadObject("DayOfWeekColors"));
            DayOfYearColors.SetXML(oXML.ReadObject("DayOfYearColors"));
            HourColors.SetXML(oXML.ReadObject("HourColors"));
            MinuteColors.SetXML(oXML.ReadObject("MinuteColors"));
            SecondColors.SetXML(oXML.ReadObject("SecondColors"));
            MillisecondColors.SetXML(oXML.ReadObject("MillisecondColors"));
            MicrosecondColors.SetXML(oXML.ReadObject("MicrosecondColors"));
            MonthColors.SetXML(oXML.ReadObject("MonthColors"));
            QuarterColors.SetXML(oXML.ReadObject("QuarterColors"));
            WeekColors.SetXML(oXML.ReadObject("WeekColors"));
            YearColors.SetXML(oXML.ReadObject("YearColors"));
        }
    
	}
}
