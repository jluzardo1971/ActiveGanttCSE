using System;

namespace MSP2010
{
	public class TimephasedData : clsItemBase
	{

		internal clsCollectionBase mp_oCollection;
		private E_TYPE_7 mp_yType;
		private int mp_lUID;
		private System.DateTime mp_dtStart;
		private System.DateTime mp_dtFinish;
		private E_UNIT mp_yUnit;
		private string mp_sValue;

		public TimephasedData()
		{
			mp_yType = E_TYPE_7.T_7_ASSIGNMENT_REMAINING_WORK;
			mp_lUID = 0;
			mp_dtStart = new System.DateTime(0);
			mp_dtFinish = new System.DateTime(0);
			mp_yUnit = E_UNIT.U_M;
			mp_sValue = "";
		}

		public E_TYPE_7 yType
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

		public System.DateTime dtStart
		{
			get
			{
				return mp_dtStart;
			}
			set
			{
				mp_dtStart = value;
			}
		}

		public System.DateTime dtFinish
		{
			get
			{
				return mp_dtFinish;
			}
			set
			{
				mp_dtFinish = value;
			}
		}

		public E_UNIT yUnit
		{
			get
			{
				return mp_yUnit;
			}
			set
			{
				mp_yUnit = value;
			}
		}

		public string sValue
		{
			get
			{
				return mp_sValue;
			}
			set
			{
				mp_sValue = value;
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
			if (mp_yType != E_TYPE_7.T_7_ASSIGNMENT_REMAINING_WORK)
			{
				bReturn = false;
			}
			if (mp_lUID != 0)
			{
				bReturn = false;
			}
			if (mp_dtStart.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_dtFinish.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_yUnit != E_UNIT.U_M)
			{
				bReturn = false;
			}
			if (mp_sValue != "")
			{
				bReturn = false;
			}
			return bReturn;
		}

		public string GetXML()
		{
			if (IsNull() == true)
			{
				return "<TimephasedData/>";
			}
			clsXML oXML = new clsXML("TimephasedData");
			oXML.InitializeWriter();
			oXML.SupportOptional = true;
			oXML.BoolsAreNumeric = true;
			oXML.WriteProperty("Type", mp_yType);
			oXML.WriteProperty("UID", mp_lUID);
			if (mp_dtStart.Ticks != 0)
			{
				oXML.WriteProperty("Start", mp_dtStart);
			}
			if (mp_dtFinish.Ticks != 0)
			{
				oXML.WriteProperty("Finish", mp_dtFinish);
			}
			oXML.WriteProperty("Unit", mp_yUnit);
			if (mp_sValue != "")
			{
				oXML.WriteProperty("Value", mp_sValue);
			}
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML("TimephasedData");
			oXML.SupportOptional = true;
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("Type", ref mp_yType);
			oXML.ReadProperty("UID", ref mp_lUID);
			oXML.ReadProperty("Start", ref mp_dtStart);
			oXML.ReadProperty("Finish", ref mp_dtFinish);
			oXML.ReadProperty("Unit", ref mp_yUnit);
			oXML.ReadProperty("Value", ref mp_sValue);
		}

	}
}
