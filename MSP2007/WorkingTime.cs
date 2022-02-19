using System;

namespace MSP2007
{
	public class WorkingTime : clsItemBase
	{

		internal clsCollectionBase mp_oCollection;
		private Time mp_oFromTime;
		private Time mp_oToTime;

		public WorkingTime()
		{
			mp_oFromTime = new Time();
			mp_oToTime = new Time();
		}

		public Time oFromTime
		{
			get
			{
				return mp_oFromTime;
			}
		}

		public Time oToTime
		{
			get
			{
				return mp_oToTime;
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
			if (mp_oFromTime.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_oToTime.IsNull() == false)
			{
				bReturn = false;
			}
			return bReturn;
		}

		public string GetXML()
		{
			if (IsNull() == true)
			{
				return "<WorkingTime/>";
			}
			clsXML oXML = new clsXML("WorkingTime");
			oXML.InitializeWriter();
			oXML.SupportOptional = true;
			oXML.BoolsAreNumeric = true;
			if (mp_oFromTime.IsNull() == false)
			{
				oXML.WriteProperty("FromTime", mp_oFromTime);
			}
			if (mp_oToTime.IsNull() == false)
			{
				oXML.WriteProperty("ToTime", mp_oToTime);
			}
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML("WorkingTime");
			oXML.SupportOptional = true;
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("FromTime", ref mp_oFromTime);
			oXML.ReadProperty("ToTime", ref mp_oToTime);
		}

	}
}
