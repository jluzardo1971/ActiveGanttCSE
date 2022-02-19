using System;

namespace MSP2007
{
	public class CalendarException : clsItemBase
	{

		internal clsCollectionBase mp_oCollection;
		private bool mp_bEnteredByOccurrences;
		private TimePeriod mp_oTimePeriod;
		private int mp_lOccurrences;
		private string mp_sName;
		private E_TYPE_3 mp_yType;
		private int mp_lPeriod;
		private int mp_lDaysOfWeek;
		private E_MONTHITEM mp_yMonthItem;
		private E_MONTHPOSITION mp_yMonthPosition;
		private E_MONTH mp_yMonth;
		private int mp_lMonthDay;
		private bool mp_bDayWorking;
		private WorkingTimes mp_oWorkingTimes;

		public CalendarException()
		{
			mp_bEnteredByOccurrences = false;
			mp_oTimePeriod = new TimePeriod();
			mp_lOccurrences = 0;
			mp_sName = "";
			mp_yType = E_TYPE_3.T_3_DAILY;
			mp_lPeriod = 0;
			mp_lDaysOfWeek = 0;
			mp_yMonthItem = E_MONTHITEM.MI_DAY;
			mp_yMonthPosition = E_MONTHPOSITION.MP_FIRST_POSITION;
			mp_yMonth = E_MONTH.M_JANUARY;
			mp_lMonthDay = 0;
			mp_bDayWorking = false;
			mp_oWorkingTimes = new WorkingTimes();
		}

		public bool bEnteredByOccurrences
		{
			get
			{
				return mp_bEnteredByOccurrences;
			}
			set
			{
				mp_bEnteredByOccurrences = value;
			}
		}

		public TimePeriod oTimePeriod
		{
			get
			{
				return mp_oTimePeriod;
			}
		}

		public int lOccurrences
		{
			get
			{
				return mp_lOccurrences;
			}
			set
			{
				mp_lOccurrences = value;
			}
		}

		public string sName
		{
			get
			{
				return mp_sName;
			}
			set
			{
				if (value.Length > 512)
				{
					value = value.Substring(0, 512);
				}
				mp_sName = value;
			}
		}

		public E_TYPE_3 yType
		{
			get
			{
				return mp_yType;
			}
			set
			{
				mp_yType = value;
			}
		}

		public int lPeriod
		{
			get
			{
				return mp_lPeriod;
			}
			set
			{
				mp_lPeriod = value;
			}
		}

		public int lDaysOfWeek
		{
			get
			{
				return mp_lDaysOfWeek;
			}
			set
			{
				mp_lDaysOfWeek = value;
			}
		}

		public E_MONTHITEM yMonthItem
		{
			get
			{
				return mp_yMonthItem;
			}
			set
			{
				mp_yMonthItem = value;
			}
		}

		public E_MONTHPOSITION yMonthPosition
		{
			get
			{
				return mp_yMonthPosition;
			}
			set
			{
				mp_yMonthPosition = value;
			}
		}

		public E_MONTH yMonth
		{
			get
			{
				return mp_yMonth;
			}
			set
			{
				mp_yMonth = value;
			}
		}

		public int lMonthDay
		{
			get
			{
				return mp_lMonthDay;
			}
			set
			{
				mp_lMonthDay = value;
			}
		}

		public bool bDayWorking
		{
			get
			{
				return mp_bDayWorking;
			}
			set
			{
				mp_bDayWorking = value;
			}
		}

		public WorkingTimes oWorkingTimes
		{
			get
			{
				return mp_oWorkingTimes;
			}
		}
		public string Key
		{
			get { return mp_sKey; }
			set { mp_oCollection.mp_SetKey(ref mp_sKey, value, SYS_ERRORS.MP_SET_KEY); }
		}

		public bool IsNull()
		{
			bool bReturn = true;
			if (mp_bEnteredByOccurrences != false)
			{
				bReturn = false;
			}
			if (mp_oTimePeriod.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_lOccurrences != 0)
			{
				bReturn = false;
			}
			if (mp_sName != "")
			{
				bReturn = false;
			}
			if (mp_yType != E_TYPE_3.T_3_DAILY)
			{
				bReturn = false;
			}
			if (mp_lPeriod != 0)
			{
				bReturn = false;
			}
			if (mp_lDaysOfWeek != 0)
			{
				bReturn = false;
			}
			if (mp_yMonthItem != E_MONTHITEM.MI_DAY)
			{
				bReturn = false;
			}
			if (mp_yMonthPosition != E_MONTHPOSITION.MP_FIRST_POSITION)
			{
				bReturn = false;
			}
			if (mp_yMonth != E_MONTH.M_JANUARY)
			{
				bReturn = false;
			}
			if (mp_lMonthDay != 0)
			{
				bReturn = false;
			}
			if (mp_bDayWorking != false)
			{
				bReturn = false;
			}
			if (mp_oWorkingTimes.IsNull() == false)
			{
				bReturn = false;
			}
			return bReturn;
		}

		public string GetXML()
		{
			if (IsNull() == true)
			{
				return "<Exception/>";
			}
			clsXML oXML = new clsXML("Exception");
			oXML.InitializeWriter();
			oXML.SupportOptional = true;
			oXML.BoolsAreNumeric = true;
			oXML.WriteProperty("EnteredByOccurrences", mp_bEnteredByOccurrences);
			if (mp_oTimePeriod.IsNull() == false)
			{
				oXML.WriteObject(mp_oTimePeriod.GetXML());
			}
			oXML.WriteProperty("Occurrences", mp_lOccurrences);
			if (mp_sName != "")
			{
				oXML.WriteProperty("Name", mp_sName);
			}
			oXML.WriteProperty("Type", mp_yType);
			oXML.WriteProperty("Period", mp_lPeriod);
			oXML.WriteProperty("DaysOfWeek", mp_lDaysOfWeek);
			oXML.WriteProperty("MonthItem", mp_yMonthItem);
			oXML.WriteProperty("MonthPosition", mp_yMonthPosition);
			oXML.WriteProperty("Month", mp_yMonth);
			oXML.WriteProperty("MonthDay", mp_lMonthDay);
			oXML.WriteProperty("DayWorking", mp_bDayWorking);
			if (mp_oWorkingTimes.IsNull() == false)
			{
				oXML.WriteObject(mp_oWorkingTimes.GetXML());
			}
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML("Exception");
			oXML.SupportOptional = true;
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("EnteredByOccurrences", ref mp_bEnteredByOccurrences);
			mp_oTimePeriod.SetXML(oXML.ReadObject("TimePeriod"));
			oXML.ReadProperty("Occurrences", ref mp_lOccurrences);
			oXML.ReadProperty("Name", ref mp_sName);
			if (mp_sName.Length > 512)
			{
				mp_sName = mp_sName.Substring(0, 512);
			}
			oXML.ReadProperty("Type", ref mp_yType);
			oXML.ReadProperty("Period", ref mp_lPeriod);
			oXML.ReadProperty("DaysOfWeek", ref mp_lDaysOfWeek);
			oXML.ReadProperty("MonthItem", ref mp_yMonthItem);
			oXML.ReadProperty("MonthPosition", ref mp_yMonthPosition);
			oXML.ReadProperty("Month", ref mp_yMonth);
			oXML.ReadProperty("MonthDay", ref mp_lMonthDay);
			oXML.ReadProperty("DayWorking", ref mp_bDayWorking);
			mp_oWorkingTimes.SetXML(oXML.ReadObject("WorkingTimes"));
		}

	}
}
