using System;

namespace MSP2007
{
	public class TaskExtendedAttribute_C
	{

		private clsCollectionBase mp_oCollection;

		public TaskExtendedAttribute_C()
		{
			mp_oCollection = new clsCollectionBase("TaskExtendedAttribute");
		}

		public int Count
		{
			get
			{
				return mp_oCollection.m_lCount();
			}
		}

		public TaskExtendedAttribute Item(string Index)
		{
			return (TaskExtendedAttribute) mp_oCollection.m_oItem(Index, SYS_ERRORS.MP_ITEM_1, SYS_ERRORS.MP_ITEM_2, SYS_ERRORS.MP_ITEM_3, SYS_ERRORS.MP_ITEM_4);
		}

		public TaskExtendedAttribute Add()
		{
			mp_oCollection.AddMode = true;
			TaskExtendedAttribute oTaskExtendedAttribute = new TaskExtendedAttribute();
			oTaskExtendedAttribute.mp_oCollection = mp_oCollection;
			mp_oCollection.m_Add(oTaskExtendedAttribute, "", SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
			return oTaskExtendedAttribute;
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
					TaskExtendedAttribute oTaskExtendedAttribute = new TaskExtendedAttribute();
					oTaskExtendedAttribute.SetXML(oXML.ReadCollectionObject(lIndex));
					mp_oCollection.AddMode = true;
					string sKey = "";
					oTaskExtendedAttribute.mp_oCollection = mp_oCollection;
					mp_oCollection.m_Add(oTaskExtendedAttribute, sKey, SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
					oTaskExtendedAttribute = null;
				}
			}
		}

		internal void WriteObjectProtected(ref clsXML oXML)
		{
			int lIndex;
			TaskExtendedAttribute oTaskExtendedAttribute;
			for (lIndex = 1; lIndex <= Count; lIndex++)
			{
				oTaskExtendedAttribute = (TaskExtendedAttribute) mp_oCollection.m_oReturnArrayElement(lIndex);
				oXML.WriteObject(oTaskExtendedAttribute.GetXML());
			}
		}

	}
}
