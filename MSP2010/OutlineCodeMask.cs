using System;

namespace MSP2010
{
	public class OutlineCodeMask : clsItemBase
	{

		internal clsCollectionBase mp_oCollection;
		private int mp_lLevel;
		private E_TYPE_1 mp_yType;
		private int mp_lLength;
		private string mp_sSeparator;

		public OutlineCodeMask()
		{
			mp_lLevel = 0;
			mp_yType = E_TYPE_1.T_1_NUMBERS;
			mp_lLength = 0;
			mp_sSeparator = "";
		}

		public int lLevel
		{
			get
			{
				return mp_lLevel;
			}
			set
			{
				mp_lLevel = value;
			}
		}

		public E_TYPE_1 yType
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

		public int lLength
		{
			get
			{
				return mp_lLength;
			}
			set
			{
				mp_lLength = value;
			}
		}

		public string sSeparator
		{
			get
			{
				return mp_sSeparator;
			}
			set
			{
				mp_sSeparator = value;
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
			if (mp_lLevel != 0)
			{
				bReturn = false;
			}
			if (mp_yType != E_TYPE_1.T_1_NUMBERS)
			{
				bReturn = false;
			}
			if (mp_lLength != 0)
			{
				bReturn = false;
			}
			if (mp_sSeparator != "")
			{
				bReturn = false;
			}
			return bReturn;
		}

		public string GetXML()
		{
			if (IsNull() == true)
			{
				return "<Mask/>";
			}
			clsXML oXML = new clsXML("Mask");
			oXML.InitializeWriter();
			oXML.SupportOptional = true;
			oXML.BoolsAreNumeric = true;
			oXML.WriteProperty("Level", mp_lLevel);
			oXML.WriteProperty("Type", mp_yType);
			oXML.WriteProperty("Length", mp_lLength);
			if (mp_sSeparator != "")
			{
				oXML.WriteProperty("Separator", mp_sSeparator);
			}
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML("Mask");
			oXML.SupportOptional = true;
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("Level", ref mp_lLevel);
			oXML.ReadProperty("Type", ref mp_yType);
			oXML.ReadProperty("Length", ref mp_lLength);
			oXML.ReadProperty("Separator", ref mp_sSeparator);
		}

	}
}
