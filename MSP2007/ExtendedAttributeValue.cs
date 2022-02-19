using System;

namespace MSP2007
{
	public class ExtendedAttributeValue : clsItemBase
	{

		internal clsCollectionBase mp_oCollection;
		private int mp_lID;
		private string mp_sValue;
		private string mp_sDescription;
		private string mp_sPhonetic;

		public ExtendedAttributeValue()
		{
			mp_lID = 0;
			mp_sValue = "";
			mp_sDescription = "";
			mp_sPhonetic = "";
		}

		public int lID
		{
			get
			{
				return mp_lID;
			}
			set
			{
				mp_lID = value;
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

		public string sDescription
		{
			get
			{
				return mp_sDescription;
			}
			set
			{
				mp_sDescription = value;
			}
		}

		public string sPhonetic
		{
			get
			{
				return mp_sPhonetic;
			}
			set
			{
				mp_sPhonetic = value;
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
			if (mp_lID != 0)
			{
				bReturn = false;
			}
			if (mp_sValue != "")
			{
				bReturn = false;
			}
			if (mp_sDescription != "")
			{
				bReturn = false;
			}
			if (mp_sPhonetic != "")
			{
				bReturn = false;
			}
			return bReturn;
		}

		public string GetXML()
		{
			if (IsNull() == true)
			{
				return "<Value/>";
			}
			clsXML oXML = new clsXML("Value");
			oXML.InitializeWriter();
			oXML.SupportOptional = true;
			oXML.BoolsAreNumeric = true;
			oXML.WriteProperty("ID", mp_lID);
			if (mp_sValue != "")
			{
				oXML.WriteProperty("Value", mp_sValue);
			}
			if (mp_sDescription != "")
			{
				oXML.WriteProperty("Description", mp_sDescription);
			}
			if (mp_sPhonetic != "")
			{
				oXML.WriteProperty("Phonetic", mp_sPhonetic);
			}
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML("Value");
			oXML.SupportOptional = true;
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("ID", ref mp_lID);
			oXML.ReadProperty("Value", ref mp_sValue);
			oXML.ReadProperty("Description", ref mp_sDescription);
			oXML.ReadProperty("Phonetic", ref mp_sPhonetic);
		}

	}
}
