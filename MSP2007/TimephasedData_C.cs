using System;

namespace MSP2007
{
	public class TimephasedData_C
	{

		private clsCollectionBase mp_oCollection;

		public TimephasedData_C()
		{
			mp_oCollection = new clsCollectionBase("TimephasedData");
		}

		public int Count
		{
			get
			{
				return mp_oCollection.m_lCount();
			}
		}

		public TimephasedData Item(string Index)
		{
			return (TimephasedData) mp_oCollection.m_oItem(Index, SYS_ERRORS.MP_ITEM_1, SYS_ERRORS.MP_ITEM_2, SYS_ERRORS.MP_ITEM_3, SYS_ERRORS.MP_ITEM_4);
		}

		public TimephasedData Add()
		{
			mp_oCollection.AddMode = true;
			TimephasedData oTimephasedData = new TimephasedData();
			oTimephasedData.mp_oCollection = mp_oCollection;
			mp_oCollection.m_Add(oTimephasedData, "", SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
			return oTimephasedData;
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
				if (oXML.GetCollectionObjectName(lIndex) == "TimephasedData")
				{
					TimephasedData oTimephasedData = new TimephasedData();
					oTimephasedData.SetXML(oXML.ReadCollectionObject(lIndex));
					mp_oCollection.AddMode = true;
					string sKey = "";
					oTimephasedData.mp_oCollection = mp_oCollection;
					mp_oCollection.m_Add(oTimephasedData, sKey, SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
					oTimephasedData = null;
				}
			}
		}

		internal void WriteObjectProtected(ref clsXML oXML)
		{
			int lIndex;
			TimephasedData oTimephasedData;
			for (lIndex = 1; lIndex <= Count; lIndex++)
			{
				oTimephasedData = (TimephasedData) mp_oCollection.m_oReturnArrayElement(lIndex);
				oXML.WriteObject(oTimephasedData.GetXML());
			}
		}

	}
}
