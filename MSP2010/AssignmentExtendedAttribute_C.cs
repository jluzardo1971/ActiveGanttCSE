using System;

namespace MSP2010
{
	public class AssignmentExtendedAttribute_C
	{

		private clsCollectionBase mp_oCollection;

		public AssignmentExtendedAttribute_C()
		{
			mp_oCollection = new clsCollectionBase("AssignmentExtendedAttribute");
		}

		public int Count
		{
			get
			{
				return mp_oCollection.m_lCount();
			}
		}

		public AssignmentExtendedAttribute Item(string Index)
		{
			return (AssignmentExtendedAttribute) mp_oCollection.m_oItem(Index, SYS_ERRORS.MP_ITEM_1, SYS_ERRORS.MP_ITEM_2, SYS_ERRORS.MP_ITEM_3, SYS_ERRORS.MP_ITEM_4);
		}

		public AssignmentExtendedAttribute Add()
		{
			mp_oCollection.AddMode = true;
			AssignmentExtendedAttribute oAssignmentExtendedAttribute = new AssignmentExtendedAttribute();
			oAssignmentExtendedAttribute.mp_oCollection = mp_oCollection;
			mp_oCollection.m_Add(oAssignmentExtendedAttribute, "", SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
			return oAssignmentExtendedAttribute;
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
					AssignmentExtendedAttribute oAssignmentExtendedAttribute = new AssignmentExtendedAttribute();
					oAssignmentExtendedAttribute.SetXML(oXML.ReadCollectionObject(lIndex));
					mp_oCollection.AddMode = true;
					string sKey = "";
					oAssignmentExtendedAttribute.mp_oCollection = mp_oCollection;
					mp_oCollection.m_Add(oAssignmentExtendedAttribute, sKey, SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
					oAssignmentExtendedAttribute = null;
				}
			}
		}

		internal void WriteObjectProtected(ref clsXML oXML)
		{
			int lIndex;
			AssignmentExtendedAttribute oAssignmentExtendedAttribute;
			for (lIndex = 1; lIndex <= Count; lIndex++)
			{
				oAssignmentExtendedAttribute = (AssignmentExtendedAttribute) mp_oCollection.m_oReturnArrayElement(lIndex);
				oXML.WriteObject(oAssignmentExtendedAttribute.GetXML());
			}
		}

	}
}
