using System;

namespace MSP2003
{
	public class OutlineCode : clsItemBase
	{

		internal clsCollectionBase mp_oCollection;
		private string mp_sFieldID;
		private string mp_sFieldName;
		private string mp_sAlias;
		private string mp_sPhoneticAlias;
		private OutlineCodeValues mp_oValues;
		private bool mp_bEnterprise;
		private int mp_lEnterpriseOutlineCodeAlias;
		private bool mp_bResourceSubstitutionEnabled;
		private bool mp_bLeafOnly;
		private bool mp_bAllLevelsRequired;
		private bool mp_bOnlyTableValuesAllowed;
		private OutlineCodeMasks mp_oMasks;

		public OutlineCode()
		{
			mp_sFieldID = "";
			mp_sFieldName = "";
			mp_sAlias = "";
			mp_sPhoneticAlias = "";
			mp_oValues = new OutlineCodeValues();
			mp_bEnterprise = false;
			mp_lEnterpriseOutlineCodeAlias = 0;
			mp_bResourceSubstitutionEnabled = false;
			mp_bLeafOnly = false;
			mp_bAllLevelsRequired = false;
			mp_bOnlyTableValuesAllowed = false;
			mp_oMasks = new OutlineCodeMasks();
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

		public string sFieldName
		{
			get
			{
				return mp_sFieldName;
			}
			set
			{
				mp_sFieldName = value;
			}
		}

		public string sAlias
		{
			get
			{
				return mp_sAlias;
			}
			set
			{
				mp_sAlias = value;
			}
		}

		public string sPhoneticAlias
		{
			get
			{
				return mp_sPhoneticAlias;
			}
			set
			{
				mp_sPhoneticAlias = value;
			}
		}

		public OutlineCodeValues oValues
		{
			get
			{
				return mp_oValues;
			}
		}

		public bool bEnterprise
		{
			get
			{
				return mp_bEnterprise;
			}
			set
			{
				mp_bEnterprise = value;
			}
		}

		public int lEnterpriseOutlineCodeAlias
		{
			get
			{
				return mp_lEnterpriseOutlineCodeAlias;
			}
			set
			{
				mp_lEnterpriseOutlineCodeAlias = value;
			}
		}

		public bool bResourceSubstitutionEnabled
		{
			get
			{
				return mp_bResourceSubstitutionEnabled;
			}
			set
			{
				mp_bResourceSubstitutionEnabled = value;
			}
		}

		public bool bLeafOnly
		{
			get
			{
				return mp_bLeafOnly;
			}
			set
			{
				mp_bLeafOnly = value;
			}
		}

		public bool bAllLevelsRequired
		{
			get
			{
				return mp_bAllLevelsRequired;
			}
			set
			{
				mp_bAllLevelsRequired = value;
			}
		}

		public bool bOnlyTableValuesAllowed
		{
			get
			{
				return mp_bOnlyTableValuesAllowed;
			}
			set
			{
				mp_bOnlyTableValuesAllowed = value;
			}
		}

		public OutlineCodeMasks oMasks
		{
			get
			{
				return mp_oMasks;
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
			if (mp_sFieldName != "")
			{
				bReturn = false;
			}
			if (mp_sAlias != "")
			{
				bReturn = false;
			}
			if (mp_sPhoneticAlias != "")
			{
				bReturn = false;
			}
			if (mp_oValues.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_bEnterprise != false)
			{
				bReturn = false;
			}
			if (mp_lEnterpriseOutlineCodeAlias != 0)
			{
				bReturn = false;
			}
			if (mp_bResourceSubstitutionEnabled != false)
			{
				bReturn = false;
			}
			if (mp_bLeafOnly != false)
			{
				bReturn = false;
			}
			if (mp_bAllLevelsRequired != false)
			{
				bReturn = false;
			}
			if (mp_bOnlyTableValuesAllowed != false)
			{
				bReturn = false;
			}
			if (mp_oMasks.IsNull() == false)
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
			if (mp_sFieldName != "")
			{
				oXML.WriteProperty("FieldName", mp_sFieldName);
			}
			if (mp_sAlias != "")
			{
				oXML.WriteProperty("Alias", mp_sAlias);
			}
			if (mp_sPhoneticAlias != "")
			{
				oXML.WriteProperty("PhoneticAlias", mp_sPhoneticAlias);
			}
			if (mp_oValues.IsNull() == false)
			{
				oXML.WriteObject(mp_oValues.GetXML());
			}
			oXML.WriteProperty("Enterprise", mp_bEnterprise);
			oXML.WriteProperty("EnterpriseOutlineCodeAlias", mp_lEnterpriseOutlineCodeAlias);
			oXML.WriteProperty("ResourceSubstitutionEnabled", mp_bResourceSubstitutionEnabled);
			oXML.WriteProperty("LeafOnly", mp_bLeafOnly);
			oXML.WriteProperty("AllLevelsRequired", mp_bAllLevelsRequired);
			oXML.WriteProperty("OnlyTableValuesAllowed", mp_bOnlyTableValuesAllowed);
			if (mp_oMasks.IsNull() == false)
			{
				oXML.WriteObject(mp_oMasks.GetXML());
			}
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML("OutlineCode");
			oXML.SupportOptional = true;
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("FieldID", ref mp_sFieldID);
			oXML.ReadProperty("FieldName", ref mp_sFieldName);
			oXML.ReadProperty("Alias", ref mp_sAlias);
			oXML.ReadProperty("PhoneticAlias", ref mp_sPhoneticAlias);
			mp_oValues.SetXML(oXML.ReadObject("Values"));
			oXML.ReadProperty("Enterprise", ref mp_bEnterprise);
			oXML.ReadProperty("EnterpriseOutlineCodeAlias", ref mp_lEnterpriseOutlineCodeAlias);
			oXML.ReadProperty("ResourceSubstitutionEnabled", ref mp_bResourceSubstitutionEnabled);
			oXML.ReadProperty("LeafOnly", ref mp_bLeafOnly);
			oXML.ReadProperty("AllLevelsRequired", ref mp_bAllLevelsRequired);
			oXML.ReadProperty("OnlyTableValuesAllowed", ref mp_bOnlyTableValuesAllowed);
			mp_oMasks.SetXML(oXML.ReadObject("Masks"));
		}

	}
}
