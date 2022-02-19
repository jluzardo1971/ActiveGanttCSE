using System;

namespace MSP2010
{
	public class CalendarExceptions
	{

		private clsCollectionBase mp_oCollection;

		public CalendarExceptions()
		{
			mp_oCollection = new clsCollectionBase("CalendarException");
		}

		public int Count
		{
			get
			{
				return mp_oCollection.m_lCount();
			}
		}

		public CalendarException Item(string Index)
		{
			return (CalendarException) mp_oCollection.m_oItem(Index, SYS_ERRORS.MP_ITEM_1, SYS_ERRORS.MP_ITEM_2, SYS_ERRORS.MP_ITEM_3, SYS_ERRORS.MP_ITEM_4);
		}

		public CalendarException Add()
		{
			mp_oCollection.AddMode = true;
			CalendarException oCalendarException = new CalendarException();
			oCalendarException.mp_oCollection = mp_oCollection;
			mp_oCollection.m_Add(oCalendarException, "", SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
			return oCalendarException;
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
				return "<Exceptions/>";
			}
			int lIndex;
			CalendarException oCalendarException;
			clsXML oXML = new clsXML("Exceptions");
			oXML.BoolsAreNumeric = true;
			oXML.InitializeWriter();
				for (lIndex = 1; lIndex <= Count; lIndex++)
			{
				oCalendarException = (CalendarException) mp_oCollection.m_oReturnArrayElement(lIndex);
				oXML.WriteObject(oCalendarException.GetXML());
			}
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			int lIndex;
			clsXML oXML = new clsXML("Exceptions");
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
				CalendarException oCalendarException = new CalendarException();
				oCalendarException.SetXML(oXML.ReadCollectionObject(lIndex));
				mp_oCollection.AddMode = true;
				string sKey = "";
				oCalendarException.mp_oCollection = mp_oCollection;
				mp_oCollection.m_Add(oCalendarException, sKey, SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
				oCalendarException = null;
			}
		}

	}
}
