using System;

namespace MSP2010
{
	public class ResourceExtendedAttribute_C
	{

		private clsCollectionBase mp_oCollection;

		public ResourceExtendedAttribute_C()
		{
			mp_oCollection = new clsCollectionBase("ResourceExtendedAttribute");
		}

		public int Count
		{
			get
			{
				return mp_oCollection.m_lCount();
			}
		}

		public ResourceExtendedAttribute Item(string Index)
		{
			return (ResourceExtendedAttribute) mp_oCollection.m_oItem(Index, SYS_ERRORS.MP_ITEM_1, SYS_ERRORS.MP_ITEM_2, SYS_ERRORS.MP_ITEM_3, SYS_ERRORS.MP_ITEM_4);
		}

		public ResourceExtendedAttribute Add()
		{
			mp_oCollection.AddMode = true;
			ResourceExtendedAttribute oResourceExtendedAttribute = new ResourceExtendedAttribute();
			oResourceExtendedAttribute.mp_oCollection = mp_oCollection;
			mp_oCollection.m_Add(oResourceExtendedAttribute, "", SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
			return oResourceExtendedAttribute;
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

		internal void ReadObjectProtected(ref clsXML oXML)
		{
			int lIndex;
			for (lIndex = 1; lIndex <= oXML.ReadCollectionCount(); lIndex++)
			{
				if (oXML.GetCollectionObjectName(lIndex) == "ExtendedAttribute")
				{
					ResourceExtendedAttribute oResourceExtendedAttribute = new ResourceExtendedAttribute();
					oResourceExtendedAttribute.SetXML(oXML.ReadCollectionObject(lIndex));
					mp_oCollection.AddMode = true;
					string sKey = "";
					oResourceExtendedAttribute.mp_oCollection = mp_oCollection;
					mp_oCollection.m_Add(oResourceExtendedAttribute, sKey, SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
					oResourceExtendedAttribute = null;
				}
			}
		}

		internal void WriteObjectProtected(ref clsXML oXML)
		{
			int lIndex;
			ResourceExtendedAttribute oResourceExtendedAttribute;
			for (lIndex = 1; lIndex <= Count; lIndex++)
			{
				oResourceExtendedAttribute = (ResourceExtendedAttribute) mp_oCollection.m_oReturnArrayElement(lIndex);
				oXML.WriteObject(oResourceExtendedAttribute.GetXML());
			}
		}

	}
}
