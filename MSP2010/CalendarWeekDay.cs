using System;

namespace MSP2010
{
	public class CalendarWeekDay : clsItemBase
	{

		internal clsCollectionBase mp_oCollection;
		private E_DAYTYPE mp_yDayType;
		private bool mp_bDayWorking;
		private TimePeriod mp_oTimePeriod;
		private WorkingTimes mp_oWorkingTimes;

		public CalendarWeekDay()
		{
			mp_yDayType = E_DAYTYPE.DT_EXCEPTION;
			mp_bDayWorking = false;
			mp_oTimePeriod = new TimePeriod();
			mp_oWorkingTimes = new WorkingTimes();
		}

		public E_DAYTYPE yDayType
		{
			get
			{
				return mp_yDayType;
			}
			set
			{
				mp_yDayType = value;
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

		public TimePeriod oTimePeriod
		{
			get
			{
				return mp_oTimePeriod;
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
			if (mp_yDayType != E_DAYTYPE.DT_EXCEPTION)
			{
				bReturn = false;
			}
			if (mp_bDayWorking != false)
			{
				bReturn = false;
			}
			if (mp_oTimePeriod.IsNull() == false)
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
				return "<WeekDay/>";
			}
			clsXML oXML = new clsXML("WeekDay");
			oXML.InitializeWriter();
			oXML.SupportOptional = true;
			oXML.BoolsAreNumeric = true;
			oXML.WriteProperty("DayType", mp_yDayType);
			oXML.WriteProperty("DayWorking", mp_bDayWorking);
			if (mp_oTimePeriod.IsNull() == false)
			{
				oXML.WriteObject(mp_oTimePeriod.GetXML());
			}
			if (mp_oWorkingTimes.IsNull() == false)
			{
				oXML.WriteObject(mp_oWorkingTimes.GetXML());
			}
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML("WeekDay");
			oXML.SupportOptional = true;
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("DayType", ref mp_yDayType);
			oXML.ReadProperty("DayWorking", ref mp_bDayWorking);
			mp_oTimePeriod.SetXML(oXML.ReadObject("TimePeriod"));
			mp_oWorkingTimes.SetXML(oXML.ReadObject("WorkingTimes"));
		}

	}
}
