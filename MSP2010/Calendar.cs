using System;

namespace MSP2010
{
	public class Calendar : clsItemBase
	{

		internal clsCollectionBase mp_oCollection;
		private int mp_lUID;
		private string mp_sName;
		private bool mp_bIsBaseCalendar;
		private bool mp_bIsBaselineCalendar;
		private int mp_lBaseCalendarUID;
		private CalendarWeekDays mp_oWeekDays;
		private CalendarExceptions mp_oExceptions;
		private CalendarWorkWeeks mp_oWorkWeeks;

		public Calendar()
		{
			mp_lUID = 0;
			mp_sName = "";
			mp_bIsBaseCalendar = false;
			mp_bIsBaselineCalendar = false;
			mp_lBaseCalendarUID = 0;
			mp_oWeekDays = new CalendarWeekDays();
			mp_oExceptions = new CalendarExceptions();
			mp_oWorkWeeks = new CalendarWorkWeeks();
		}

		public int lUID
		{
			get
			{
				return mp_lUID;
			}
			set
			{
				mp_lUID = value;
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

		public bool bIsBaseCalendar
		{
			get
			{
				return mp_bIsBaseCalendar;
			}
			set
			{
				mp_bIsBaseCalendar = value;
			}
		}

		public bool bIsBaselineCalendar
		{
			get
			{
				return mp_bIsBaselineCalendar;
			}
			set
			{
				mp_bIsBaselineCalendar = value;
			}
		}

		public int lBaseCalendarUID
		{
			get
			{
				return mp_lBaseCalendarUID;
			}
			set
			{
				mp_lBaseCalendarUID = value;
			}
		}

		public CalendarWeekDays oWeekDays
		{
			get
			{
				return mp_oWeekDays;
			}
		}

		public CalendarExceptions oExceptions
		{
			get
			{
				return mp_oExceptions;
			}
		}

		public CalendarWorkWeeks oWorkWeeks
		{
			get
			{
				return mp_oWorkWeeks;
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
			if (mp_lUID != 0)
			{
				bReturn = false;
			}
			if (mp_sName != "")
			{
				bReturn = false;
			}
			if (mp_bIsBaseCalendar != false)
			{
				bReturn = false;
			}
			if (mp_bIsBaselineCalendar != false)
			{
				bReturn = false;
			}
			if (mp_lBaseCalendarUID != 0)
			{
				bReturn = false;
			}
			if (mp_oWeekDays.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_oExceptions.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_oWorkWeeks.IsNull() == false)
			{
				bReturn = false;
			}
			return bReturn;
		}

		public string GetXML()
		{
			if (IsNull() == true)
			{
				return "<Calendar/>";
			}
			clsXML oXML = new clsXML("Calendar");
			oXML.InitializeWriter();
			oXML.SupportOptional = true;
			oXML.BoolsAreNumeric = true;
			oXML.WriteProperty("UID", mp_lUID);
			if (mp_sName != "")
			{
				oXML.WriteProperty("Name", mp_sName);
			}
			oXML.WriteProperty("IsBaseCalendar", mp_bIsBaseCalendar);
			oXML.WriteProperty("IsBaselineCalendar", mp_bIsBaselineCalendar);
			oXML.WriteProperty("BaseCalendarUID", mp_lBaseCalendarUID);
			if (mp_oWeekDays.IsNull() == false)
			{
				oXML.WriteObject(mp_oWeekDays.GetXML());
			}
			if (mp_oExceptions.IsNull() == false)
			{
				oXML.WriteObject(mp_oExceptions.GetXML());
			}
			if (mp_oWorkWeeks.IsNull() == false)
			{
				oXML.WriteObject(mp_oWorkWeeks.GetXML());
			}
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML("Calendar");
			oXML.SupportOptional = true;
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("UID", ref mp_lUID);
			oXML.ReadProperty("Name", ref mp_sName);
			if (mp_sName.Length > 512)
			{
				mp_sName = mp_sName.Substring(0, 512);
			}
			oXML.ReadProperty("IsBaseCalendar", ref mp_bIsBaseCalendar);
			oXML.ReadProperty("IsBaselineCalendar", ref mp_bIsBaselineCalendar);
			oXML.ReadProperty("BaseCalendarUID", ref mp_lBaseCalendarUID);
			mp_oWeekDays.SetXML(oXML.ReadObject("WeekDays"));
			mp_oExceptions.SetXML(oXML.ReadObject("Exceptions"));
			mp_oWorkWeeks.SetXML(oXML.ReadObject("WorkWeeks"));
		}

	}
}
