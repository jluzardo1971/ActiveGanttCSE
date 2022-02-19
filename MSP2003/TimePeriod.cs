using System;

namespace MSP2003
{
	public class TimePeriod : clsItemBase
	{

		internal clsCollectionBase mp_oCollection;
		private System.DateTime mp_dtFromDate;
		private System.DateTime mp_dtToDate;

		public TimePeriod()
		{
			mp_dtFromDate = new System.DateTime(0);
			mp_dtToDate = new System.DateTime(0);
		}

		public System.DateTime dtFromDate
		{
			get
			{
				return mp_dtFromDate;
			}
			set
			{
				mp_dtFromDate = value;
			}
		}

		public System.DateTime dtToDate
		{
			get
			{
				return mp_dtToDate;
			}
			set
			{
				mp_dtToDate = value;
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
			if (mp_dtFromDate.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_dtToDate.Ticks != 0)
			{
				bReturn = false;
			}
			return bReturn;
		}

		public string GetXML()
		{
			if (IsNull() == true)
			{
				return "<TimePeriod/>";
			}
			clsXML oXML = new clsXML("TimePeriod");
			oXML.InitializeWriter();
			oXML.SupportOptional = true;
			oXML.BoolsAreNumeric = true;
			if (mp_dtFromDate.Ticks != 0)
			{
				oXML.WriteProperty("FromDate", mp_dtFromDate);
			}
			if (mp_dtToDate.Ticks != 0)
			{
				oXML.WriteProperty("ToDate", mp_dtToDate);
			}
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML("TimePeriod");
			oXML.SupportOptional = true;
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("FromDate", ref mp_dtFromDate);
			oXML.ReadProperty("ToDate", ref mp_dtToDate);
		}

	}
}
