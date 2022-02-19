using System;

namespace MSP2007
{
	public class ResourceAvailabilityPeriod : clsItemBase
	{

		internal clsCollectionBase mp_oCollection;
		private System.DateTime mp_dtAvailableFrom;
		private System.DateTime mp_dtAvailableTo;
		private float mp_fAvailableUnits;

		public ResourceAvailabilityPeriod()
		{
			mp_dtAvailableFrom = new System.DateTime(0);
			mp_dtAvailableTo = new System.DateTime(0);
			mp_fAvailableUnits = 0;
		}

		public System.DateTime dtAvailableFrom
		{
			get
			{
				return mp_dtAvailableFrom;
			}
			set
			{
				mp_dtAvailableFrom = value;
			}
		}

		public System.DateTime dtAvailableTo
		{
			get
			{
				return mp_dtAvailableTo;
			}
			set
			{
				mp_dtAvailableTo = value;
			}
		}

		public float fAvailableUnits
		{
			get
			{
				return mp_fAvailableUnits;
			}
			set
			{
				mp_fAvailableUnits = value;
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
			if (mp_dtAvailableFrom.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_dtAvailableTo.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_fAvailableUnits != 0)
			{
				bReturn = false;
			}
			return bReturn;
		}

		public string GetXML()
		{
			if (IsNull() == true)
			{
				return "<AvailabilityPeriod/>";
			}
			clsXML oXML = new clsXML("AvailabilityPeriod");
			oXML.InitializeWriter();
			oXML.SupportOptional = true;
			oXML.BoolsAreNumeric = true;
			if (mp_dtAvailableFrom.Ticks != 0)
			{
				oXML.WriteProperty("AvailableFrom", mp_dtAvailableFrom);
			}
			if (mp_dtAvailableTo.Ticks != 0)
			{
				oXML.WriteProperty("AvailableTo", mp_dtAvailableTo);
			}
			oXML.WriteProperty("AvailableUnits", mp_fAvailableUnits);
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML("AvailabilityPeriod");
			oXML.SupportOptional = true;
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("AvailableFrom", ref mp_dtAvailableFrom);
			oXML.ReadProperty("AvailableTo", ref mp_dtAvailableTo);
			oXML.ReadProperty("AvailableUnits", ref mp_fAvailableUnits);
		}

	}
}
