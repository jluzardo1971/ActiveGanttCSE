using System;

namespace MSP2010
{
	public class TaskOutlineCode : clsItemBase
	{

		internal clsCollectionBase mp_oCollection;
		private string mp_sFieldID;
		private int mp_lValueID;
		private int mp_lValueGUID;

		public TaskOutlineCode()
		{
			mp_sFieldID = "";
			mp_lValueID = 0;
			mp_lValueGUID = 0;
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

		public int lValueGUID
		{
			get
			{
				return mp_lValueGUID;
			}
			set
			{
				mp_lValueGUID = value;
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
			if (mp_sFieldID != "")
			{
				bReturn = false;
			}
			if (mp_lValueID != 0)
			{
				bReturn = false;
			}
			if (mp_lValueGUID != 0)
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
			if (mp_sFieldID != "")
			{
				oXML.WriteProperty("FieldID", mp_sFieldID);
			}
			oXML.WriteProperty("ValueID", mp_lValueID);
			oXML.WriteProperty("ValueGUID", mp_lValueGUID);
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML("OutlineCode");
			oXML.SupportOptional = true;
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("FieldID", ref mp_sFieldID);
			oXML.ReadProperty("ValueID", ref mp_lValueID);
			oXML.ReadProperty("ValueGUID", ref mp_lValueGUID);
		}

	}
}
