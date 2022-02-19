using System;

namespace MSP2007
{
	public class ExtendedAttributes
	{

		private clsCollectionBase mp_oCollection;

		public ExtendedAttributes()
		{
			mp_oCollection = new clsCollectionBase("ExtendedAttribute");
		}

		public int Count
		{
			get
			{
				return mp_oCollection.m_lCount();
			}
		}

		public ExtendedAttribute Item(string Index)
		{
			return (ExtendedAttribute) mp_oCollection.m_oItem(Index, SYS_ERRORS.MP_ITEM_1, SYS_ERRORS.MP_ITEM_2, SYS_ERRORS.MP_ITEM_3, SYS_ERRORS.MP_ITEM_4);
		}

		public ExtendedAttribute Add()
		{
			mp_oCollection.AddMode = true;
			ExtendedAttribute oExtendedAttribute = new ExtendedAttribute();
			oExtendedAttribute.mp_oCollection = mp_oCollection;
			mp_oCollection.m_Add(oExtendedAttribute, "", SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
			return oExtendedAttribute;
		}

		public void Clear()
		{
			mp_oCollection.m_Clear();
		}

		public void Remove(string Index)
		{
			mp_oCollection.m_Remove(Index, SYS_ERRORS.MP_REMOVE_1, SYS_ERRORS.MP_REMOVE_2, SYS_ERRORS.MP_REMOVE_3, SYS_ERRORS.MP_REMOVE_4);
		}

	public bool IsNull()
	{
		bool bReturn = true;
		if (Count > 0)
		{
			bReturn = false;
		}
		return bReturn;
	}

		public string GetXML()
		{
			if (IsNull() == true)
			{
				return "<ExtendedAttributes/>";
			}
			int lIndex;
			ExtendedAttribute oExtendedAttribute;
			clsXML oXML = new clsXML("ExtendedAttributes");
			oXML.BoolsAreNumeric = true;
			oXML.InitializeWriter();
				for (lIndex = 1; lIndex <= Count; lIndex++)
			{
				oExtendedAttribute = (ExtendedAttribute) mp_oCollection.m_oReturnArrayElement(lIndex);
				oXML.WriteObject(oExtendedAttribute.GetXML());
			}
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			int lIndex;
			clsXML oXML = new clsXML("ExtendedAttributes");
			oXML.SupportOptional = true;
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			mp_oCollection.m_Clear();
			if (oXML.ReadCollectionCount() == 0)
			{
				return;
			}
			for (lIndex = 1; lIndex <= oXML.ReadCollectionCount(); lIndex++)
			{
				ExtendedAttribute oExtendedAttribute = new ExtendedAttribute();
				oExtendedAttribute.SetXML(oXML.ReadCollectionObject(lIndex));
				mp_oCollection.AddMode = true;
				string sKey = "";
				oExtendedAttribute.mp_oCollection = mp_oCollection;
				mp_oCollection.m_Add(oExtendedAttribute, sKey, SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
				oExtendedAttribute = null;
			}
		}

	}
}
