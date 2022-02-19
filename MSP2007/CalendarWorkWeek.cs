using System;

namespace MSP2007
{
	public class CalendarWorkWeek : clsItemBase
	{

		internal clsCollectionBase mp_oCollection;
		private TimePeriod mp_oTimePeriod;
		private string mp_sName;
		private WeekDay_C mp_oWeekDay_C;

		public CalendarWorkWeek()
		{
			mp_oTimePeriod = new TimePeriod();
			mp_sName = "";
			mp_oWeekDay_C = new WeekDay_C();
		}

		public TimePeriod oTimePeriod
		{
			get
			{
				return mp_oTimePeriod;
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

		public WeekDay_C oWeekDay_C
		{
			get
			{
				return mp_oWeekDay_C;
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
			if (mp_oTimePeriod.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_sName != "")
			{
				bReturn = false;
			}
			if (mp_oWeekDay_C.IsNull() == false)
			{
				bReturn = false;
			}
			return bReturn;
		}

		public string GetXML()
		{
			if (IsNull() == true)
			{
				return "<WorkWeek/>";
			}
			clsXML oXML = new clsXML("WorkWeek");
			oXML.InitializeWriter();
			oXML.SupportOptional = true;
			oXML.BoolsAreNumeric = true;
			if (mp_oTimePeriod.IsNull() == false)
			{
				oXML.WriteObject(mp_oTimePeriod.GetXML());
			}
			if (mp_sName != "")
			{
				oXML.WriteProperty("Name", mp_sName);
			}
			if (mp_oWeekDay_C.IsNull() == false)
			{
				mp_oWeekDay_C.WriteObjectProtected(ref oXML);
			}
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML("WorkWeek");
			oXML.SupportOptional = true;
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			mp_oTimePeriod.SetXML(oXML.ReadObject("TimePeriod"));
			oXML.ReadProperty("Name", ref mp_sName);
			if (mp_sName.Length > 512)
			{
				mp_sName = mp_sName.Substring(0, 512);
			}
			mp_oWeekDay_C.ReadObjectProtected(ref oXML);
		}

	}
}
