using System;

namespace MSP2003
{
	public class ResourceExtendedAttribute : clsItemBase
	{

		internal clsCollectionBase mp_oCollection;
		private int mp_lUID;
		private string mp_sFieldID;
		private string mp_sValue;
		private int mp_lValueID;
		private E_DURATIONFORMAT mp_yDurationFormat;

		public ResourceExtendedAttribute()
		{
			mp_lUID = 0;
			mp_sFieldID = "";
			mp_sValue = "";
			mp_lValueID = 0;
			mp_yDurationFormat = E_DURATIONFORMAT.DF_M;
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

		public string sFieldID
		{
			get
			{
				return mp_sFieldID;
			}
			set
			{
				mp_sFieldID = value;
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

		public int lValueID
		{
			get
			{
				return mp_lValueID;
			}
			set
			{
				mp_lValueID = value;
			}
		}

		public E_DURATIONFORMAT yDurationFormat
		{
			get
			{
				return mp_yDurationFormat;
			}
			set
			{
				mp_yDurationFormat = value;
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
			if (mp_sFieldID != "")
			{
				bReturn = false;
			}
			if (mp_sValue != "")
			{
				bReturn = false;
			}
			if (mp_lValueID != 0)
			{
				bReturn = false;
			}
			if (mp_yDurationFormat != E_DURATIONFORMAT.DF_M)
			{
				bReturn = false;
			}
			return bReturn;
		}

		public string GetXML()
		{
			if (IsNull() == true)
			{
				return "<ExtendedAttribute/>";
			}
			clsXML oXML = new clsXML("ExtendedAttribute");
			oXML.InitializeWriter();
			oXML.SupportOptional = true;
			oXML.BoolsAreNumeric = true;
			oXML.WriteProperty("UID", mp_lUID);
			if (mp_sFieldID != "")
			{
				oXML.WriteProperty("FieldID", mp_sFieldID);
			}
			if (mp_sValue != "")
			{
				oXML.WriteProperty("Value", mp_sValue);
			}
			oXML.WriteProperty("ValueID", mp_lValueID);
			oXML.WriteProperty("DurationFormat", mp_yDurationFormat);
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML("ExtendedAttribute");
			oXML.SupportOptional = true;
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("UID", ref mp_lUID);
			oXML.ReadProperty("FieldID", ref mp_sFieldID);
			oXML.ReadProperty("Value", ref mp_sValue);
			oXML.ReadProperty("ValueID", ref mp_lValueID);
			oXML.ReadProperty("DurationFormat", ref mp_yDurationFormat);
		}

	}
}
