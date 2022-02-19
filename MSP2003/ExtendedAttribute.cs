using System;

namespace MSP2003
{
	public class ExtendedAttribute : clsItemBase
	{

		internal clsCollectionBase mp_oCollection;
		private string mp_sFieldID;
		private string mp_sFieldName;
		private string mp_sAlias;
		private string mp_sPhoneticAlias;
		private E_ROLLUPTYPE mp_yRollupType;
		private E_CALCULATIONTYPE mp_yCalculationType;
		private string mp_sFormula;
		private bool mp_bRestrictValues;
		private E_VALUELISTSORTORDER mp_yValuelistSortOrder;
		private bool mp_bAppendNewValues;
		private string mp_sDefault;
		private ExtendedAttributeValueList mp_oValueList;

		public ExtendedAttribute()
		{
			mp_sFieldID = "";
			mp_sFieldName = "";
			mp_sAlias = "";
			mp_sPhoneticAlias = "";
			mp_yRollupType = E_ROLLUPTYPE.RT_MAXIMUM_OR_FOR_FLAG_FIELDS;
			mp_yCalculationType = E_CALCULATIONTYPE.CT_NONE;
			mp_sFormula = "";
			mp_bRestrictValues = false;
			mp_yValuelistSortOrder = E_VALUELISTSORTORDER.VSO_DESCENDING;
			mp_bAppendNewValues = false;
			mp_sDefault = "";
			mp_oValueList = new ExtendedAttributeValueList();
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
				if (value.Length > 50)
				{
					value = value.Substring(0, 50);
				}
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
				if (value.Length > 50)
				{
					value = value.Substring(0, 50);
				}
				mp_sPhoneticAlias = value;
			}
		}

		public E_ROLLUPTYPE yRollupType
		{
			get
			{
				return mp_yRollupType;
			}
			set
			{
				mp_yRollupType = value;
			}
		}

		public E_CALCULATIONTYPE yCalculationType
		{
			get
			{
				return mp_yCalculationType;
			}
			set
			{
				mp_yCalculationType = value;
			}
		}

		public string sFormula
		{
			get
			{
				return mp_sFormula;
			}
			set
			{
				mp_sFormula = value;
			}
		}

		public bool bRestrictValues
		{
			get
			{
				return mp_bRestrictValues;
			}
			set
			{
				mp_bRestrictValues = value;
			}
		}

		public E_VALUELISTSORTORDER yValuelistSortOrder
		{
			get
			{
				return mp_yValuelistSortOrder;
			}
			set
			{
				mp_yValuelistSortOrder = value;
			}
		}

		public bool bAppendNewValues
		{
			get
			{
				return mp_bAppendNewValues;
			}
			set
			{
				mp_bAppendNewValues = value;
			}
		}

		public string sDefault
		{
			get
			{
				return mp_sDefault;
			}
			set
			{
				mp_sDefault = value;
			}
		}

		public ExtendedAttributeValueList oValueList
		{
			get
			{
				return mp_oValueList;
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
			if (mp_yRollupType != E_ROLLUPTYPE.RT_MAXIMUM_OR_FOR_FLAG_FIELDS)
			{
				bReturn = false;
			}
			if (mp_yCalculationType != E_CALCULATIONTYPE.CT_NONE)
			{
				bReturn = false;
			}
			if (mp_sFormula != "")
			{
				bReturn = false;
			}
			if (mp_bRestrictValues != false)
			{
				bReturn = false;
			}
			if (mp_yValuelistSortOrder != E_VALUELISTSORTORDER.VSO_DESCENDING)
			{
				bReturn = false;
			}
			if (mp_bAppendNewValues != false)
			{
				bReturn = false;
			}
			if (mp_sDefault != "")
			{
				bReturn = false;
			}
			if (mp_oValueList.IsNull() == false)
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
			oXML.WriteProperty("RollupType", mp_yRollupType);
			oXML.WriteProperty("CalculationType", mp_yCalculationType);
			if (mp_sFormula != "")
			{
				oXML.WriteProperty("Formula", mp_sFormula);
			}
			oXML.WriteProperty("RestrictValues", mp_bRestrictValues);
			oXML.WriteProperty("ValuelistSortOrder", mp_yValuelistSortOrder);
			oXML.WriteProperty("AppendNewValues", mp_bAppendNewValues);
			if (mp_sDefault != "")
			{
				oXML.WriteProperty("Default", mp_sDefault);
			}
			if (mp_oValueList.IsNull() == false)
			{
				oXML.WriteObject(mp_oValueList.GetXML());
			}
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML("ExtendedAttribute");
			oXML.SupportOptional = true;
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("FieldID", ref mp_sFieldID);
			oXML.ReadProperty("FieldName", ref mp_sFieldName);
			oXML.ReadProperty("Alias", ref mp_sAlias);
			if (mp_sAlias.Length > 50)
			{
				mp_sAlias = mp_sAlias.Substring(0, 50);
			}
			oXML.ReadProperty("PhoneticAlias", ref mp_sPhoneticAlias);
			if (mp_sPhoneticAlias.Length > 50)
			{
				mp_sPhoneticAlias = mp_sPhoneticAlias.Substring(0, 50);
			}
			oXML.ReadProperty("RollupType", ref mp_yRollupType);
			oXML.ReadProperty("CalculationType", ref mp_yCalculationType);
			oXML.ReadProperty("Formula", ref mp_sFormula);
			oXML.ReadProperty("RestrictValues", ref mp_bRestrictValues);
			oXML.ReadProperty("ValuelistSortOrder", ref mp_yValuelistSortOrder);
			oXML.ReadProperty("AppendNewValues", ref mp_bAppendNewValues);
			oXML.ReadProperty("Default", ref mp_sDefault);
			mp_oValueList.SetXML(oXML.ReadObject("ValueList"));
		}

	}
}
