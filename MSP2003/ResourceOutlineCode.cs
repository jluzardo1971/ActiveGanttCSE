using System;

namespace MSP2003
{
	public class ResourceOutlineCode : clsItemBase
	{

		internal clsCollectionBase mp_oCollection;
		private int mp_lUID;
		private string mp_sFieldID;
		private int mp_lValueID;

		public ResourceOutlineCode()
		{
			mp_lUID = 0;
			mp_sFieldID = "";
			mp_lValueID = 0;
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
			if (mp_lValueID != 0)
			{
				bReturn = false;
			}
			return bReturn;
		}

		public string GetXML()
		{
			if (IsNull() == true)
			{
				return "<OutlineCode/>";
			}
			clsXML oXML = new clsXML("OutlineCode");
			oXML.InitializeWriter();
			oXML.SupportOptional = true;
			oXML.BoolsAreNumeric = true;
			oXML.WriteProperty("UID", mp_lUID);
			if (mp_sFieldID != "")
			{
				oXML.WriteProperty("FieldID", mp_sFieldID);
			}
			oXML.WriteProperty("ValueID", mp_lValueID);
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML("OutlineCode");
			oXML.SupportOptional = true;
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("UID", ref mp_lUID);
			oXML.ReadProperty("FieldID", ref mp_sFieldID);
			oXML.ReadProperty("ValueID", ref mp_lValueID);
		}

	}
}
