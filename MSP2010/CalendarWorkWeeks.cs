using System;

namespace MSP2010
{
	public class CalendarWorkWeeks
	{

		private clsCollectionBase mp_oCollection;

		public CalendarWorkWeeks()
		{
			mp_oCollection = new clsCollectionBase("CalendarWorkWeek");
		}

		public int Count
		{
			get
			{
				return mp_oCollection.m_lCount();
			}
		}

		public CalendarWorkWeek Item(string Index)
		{
			return (CalendarWorkWeek) mp_oCollection.m_oItem(Index, SYS_ERRORS.MP_ITEM_1, SYS_ERRORS.MP_ITEM_2, SYS_ERRORS.MP_ITEM_3, SYS_ERRORS.MP_ITEM_4);
		}

		public CalendarWorkWeek Add()
		{
			mp_oCollection.AddMode = true;
			CalendarWorkWeek oCalendarWorkWeek = new CalendarWorkWeek();
			oCalendarWorkWeek.mp_oCollection = mp_oCollection;
			mp_oCollection.m_Add(oCalendarWorkWeek, "", SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
			return oCalendarWorkWeek;
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
				return "<WorkWeeks/>";
			}
			int lIndex;
			CalendarWorkWeek oCalendarWorkWeek;
			clsXML oXML = new clsXML("WorkWeeks");
			oXML.BoolsAreNumeric = true;
			oXML.InitializeWriter();
				for (lIndex = 1; lIndex <= Count; lIndex++)
			{
				oCalendarWorkWeek = (CalendarWorkWeek) mp_oCollection.m_oReturnArrayElement(lIndex);
				oXML.WriteObject(oCalendarWorkWeek.GetXML());
			}
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			int lIndex;
			clsXML oXML = new clsXML("WorkWeeks");
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
				CalendarWorkWeek oCalendarWorkWeek = new CalendarWorkWeek();
				oCalendarWorkWeek.SetXML(oXML.ReadCollectionObject(lIndex));
				mp_oCollection.AddMode = true;
				string sKey = "";
				oCalendarWorkWeek.mp_oCollection = mp_oCollection;
				mp_oCollection.m_Add(oCalendarWorkWeek, sKey, SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
				oCalendarWorkWeek = null;
			}
		}

	}
}
