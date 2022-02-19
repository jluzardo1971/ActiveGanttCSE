using System;

namespace MSP2010
{
	public class WeekDay_C
	{

		private clsCollectionBase mp_oCollection;

		public WeekDay_C()
		{
			mp_oCollection = new clsCollectionBase("WeekDay");
		}

		public int Count
		{
			get
			{
				return mp_oCollection.m_lCount();
			}
		}

		public WeekDay Item(string Index)
		{
			return (WeekDay) mp_oCollection.m_oItem(Index, SYS_ERRORS.MP_ITEM_1, SYS_ERRORS.MP_ITEM_2, SYS_ERRORS.MP_ITEM_3, SYS_ERRORS.MP_ITEM_4);
		}

		public WeekDay Add()
		{
			mp_oCollection.AddMode = true;
			WeekDay oWeekDay = new WeekDay();
			oWeekDay.mp_oCollection = mp_oCollection;
			mp_oCollection.m_Add(oWeekDay, "", SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
			return oWeekDay;
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
				if (oXML.GetCollectionObjectName(lIndex) == "WeekDay")
				{
					WeekDay oWeekDay = new WeekDay();
					oWeekDay.SetXML(oXML.ReadCollectionObject(lIndex));
					mp_oCollection.AddMode = true;
					string sKey = "";
					oWeekDay.mp_oCollection = mp_oCollection;
					mp_oCollection.m_Add(oWeekDay, sKey, SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
					oWeekDay = null;
				}
			}
		}

		internal void WriteObjectProtected(ref clsXML oXML)
		{
			int lIndex;
			WeekDay oWeekDay;
			for (lIndex = 1; lIndex <= Count; lIndex++)
			{
				oWeekDay = (WeekDay) mp_oCollection.m_oReturnArrayElement(lIndex);
				oXML.WriteObject(oWeekDay.GetXML());
			}
		}

	}
}
