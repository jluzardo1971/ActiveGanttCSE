using System;

namespace MSP2007
{
	public class OutlineCodeValue : clsItemBase
	{

		internal clsCollectionBase mp_oCollection;
		private int mp_lValueID;
		private string mp_sFieldGUID;
		private E_TYPE mp_yType;
		private int mp_lParentValueID;
		private string mp_sValue;
		private string mp_sDescription;

		public OutlineCodeValue()
		{
			mp_lValueID = 0;
			mp_sFieldGUID = "";
			mp_yType = E_TYPE.T_DATE;
			mp_lParentValueID = 0;
			mp_sValue = "";
			mp_sDescription = "";
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

		public string sFieldGUID
		{
			get
			{
				return mp_sFieldGUID;
			}
			set
			{
				mp_sFieldGUID = value;
			}
		}

		public E_TYPE yType
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

		public int lParentValueID
		{
			get
			{
				return mp_lParentValueID;
			}
			set
			{
				mp_lParentValueID = value;
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
		public string Key
		{
			get { return mp_sKey; }
			set { mp_oCollection.mp_SetKey(ref mp_sKey, value, SYS_ERRORS.MP_SET_KEY); }
		}

		public bool IsNull()
		{
			bool bReturn = true;
			if (mp_lValueID != 0)
			{
				bReturn = false;
			}
			if (mp_sFieldGUID != "")
			{
				bReturn = false;
			}
			if (mp_yType != E_TYPE.T_DATE)
			{
				bReturn = false;
			}
			if (mp_lParentValueID != 0)
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
			oXML.WriteProperty("ValueID", mp_lValueID);
			oXML.WriteProperty("FieldGUID", mp_sFieldGUID);
			oXML.WriteProperty("Type", mp_yType);
			oXML.WriteProperty("ParentValueID", mp_lParentValueID);
			if (mp_sValue != "")
			{
				oXML.WriteProperty("Value", mp_sValue);
			}
			if (mp_sDescription != "")
			{
				oXML.WriteProperty("Description", mp_sDescription);
			}
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML("Value");
			oXML.SupportOptional = true;
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("ValueID", ref mp_lValueID);
			oXML.ReadProperty("FieldGUID", ref mp_sFieldGUID);
			oXML.ReadProperty("Type", ref mp_yType);
			oXML.ReadProperty("ParentValueID", ref mp_lParentValueID);
			oXML.ReadProperty("Value", ref mp_sValue);
			oXML.ReadProperty("Description", ref mp_sDescription);
		}

	}
}
