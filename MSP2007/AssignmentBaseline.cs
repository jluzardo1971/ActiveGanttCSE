using System;

namespace MSP2007
{
	public class AssignmentBaseline : clsItemBase
	{

		internal clsCollectionBase mp_oCollection;
		private TimephasedData_C mp_oTimephasedData_C;
		private string mp_sNumber;
		private string mp_sStart;
		private string mp_sFinish;
		private Duration mp_oWork;
		private string mp_sCost;
		private float mp_fBCWS;
		private float mp_fBCWP;

		public AssignmentBaseline()
		{
			mp_oTimephasedData_C = new TimephasedData_C();
			mp_sNumber = "";
			mp_sStart = "";
			mp_sFinish = "";
			mp_oWork = new Duration();
			mp_sCost = "";
			mp_fBCWS = 0;
			mp_fBCWP = 0;
		}

		public TimephasedData_C oTimephasedData_C
		{
			get
			{
				return mp_oTimephasedData_C;
			}
		}

		public string sNumber
		{
			get
			{
				return mp_sNumber;
			}
			set
			{
				mp_sNumber = value;
			}
		}

		public string sStart
		{
			get
			{
				return mp_sStart;
			}
			set
			{
				mp_sStart = value;
			}
		}

		public string sFinish
		{
			get
			{
				return mp_sFinish;
			}
			set
			{
				mp_sFinish = value;
			}
		}

		public Duration oWork
		{
			get
			{
				return mp_oWork;
			}
		}

		public string sCost
		{
			get
			{
				return mp_sCost;
			}
			set
			{
				mp_sCost = value;
			}
		}

		public float fBCWS
		{
			get
			{
				return mp_fBCWS;
			}
			set
			{
				mp_fBCWS = value;
			}
		}

		public float fBCWP
		{
			get
			{
				return mp_fBCWP;
			}
			set
			{
				mp_fBCWP = value;
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
			if (mp_oTimephasedData_C.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_sNumber != "")
			{
				bReturn = false;
			}
			if (mp_sStart != "")
			{
				bReturn = false;
			}
			if (mp_sFinish != "")
			{
				bReturn = false;
			}
			if (mp_oWork.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_sCost != "")
			{
				bReturn = false;
			}
			if (mp_fBCWS != 0)
			{
				bReturn = false;
			}
			if (mp_fBCWP != 0)
			{
				bReturn = false;
			}
			return bReturn;
		}

		public string GetXML()
		{
			if (IsNull() == true)
			{
				return "<Baseline/>";
			}
			clsXML oXML = new clsXML("Baseline");
			oXML.InitializeWriter();
			oXML.SupportOptional = true;
			oXML.BoolsAreNumeric = true;
			if (mp_oTimephasedData_C.IsNull() == false)
			{
				mp_oTimephasedData_C.WriteObjectProtected(ref oXML);
			}
			oXML.WriteProperty("Number", mp_sNumber);
			if (mp_sStart != "")
			{
				oXML.WriteProperty("Start", mp_sStart);
			}
			if (mp_sFinish != "")
			{
				oXML.WriteProperty("Finish", mp_sFinish);
			}
			oXML.WriteProperty("Work", mp_oWork);
			if (mp_sCost != "")
			{
				oXML.WriteProperty("Cost", mp_sCost);
			}
			oXML.WriteProperty("BCWS", mp_fBCWS);
			oXML.WriteProperty("BCWP", mp_fBCWP);
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML("Baseline");
			oXML.SupportOptional = true;
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			mp_oTimephasedData_C.ReadObjectProtected(ref oXML);
			oXML.ReadProperty("Number", ref mp_sNumber);
			oXML.ReadProperty("Start", ref mp_sStart);
			oXML.ReadProperty("Finish", ref mp_sFinish);
			oXML.ReadProperty("Work", ref mp_oWork);
			oXML.ReadProperty("Cost", ref mp_sCost);
			oXML.ReadProperty("BCWS", ref mp_fBCWS);
			oXML.ReadProperty("BCWP", ref mp_fBCWP);
		}

	}
}
