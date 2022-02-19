using System;

namespace MSP2003
{
	public class Calendars
	{

		private clsCollectionBase mp_oCollection;

		public Calendars()
		{
			mp_oCollection = new clsCollectionBase("Calendar");
		}

		public int Count
		{
			get
			{
				return mp_oCollection.m_lCount();
			}
		}

		public Calendar Item(string Index)
		{
			return (Calendar) mp_oCollection.m_oItem(Index, SYS_ERRORS.MP_ITEM_1, SYS_ERRORS.MP_ITEM_2, SYS_ERRORS.MP_ITEM_3, SYS_ERRORS.MP_ITEM_4);
		}

		public Calendar Add()
		{
			mp_oCollection.AddMode = true;
			Calendar oCalendar = new Calendar();
			oCalendar.mp_oCollection = mp_oCollection;
			mp_oCollection.m_Add(oCalendar, "", SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
			return oCalendar;
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
				return "<Calendars/>";
			}
			int lIndex;
			Calendar oCalendar;
			clsXML oXML = new clsXML("Calendars");
			oXML.BoolsAreNumeric = true;
			oXML.InitializeWriter();
				for (lIndex = 1; lIndex <= Count; lIndex++)
			{
				oCalendar = (Calendar) mp_oCollection.m_oReturnArrayElement(lIndex);
				oXML.WriteObject(oCalendar.GetXML());
			}
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			int lIndex;
			clsXML oXML = new clsXML("Calendars");
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
				Calendar oCalendar = new Calendar();
				oCalendar.SetXML(oXML.ReadCollectionObject(lIndex));
				mp_oCollection.AddMode = true;
				string sKey = "";
				sKey = "K" + oCalendar.lUID.ToString();
					oCalendar.mp_oCollection = mp_oCollection;
					oCalendar.Key = sKey;
				mp_oCollection.m_Add(oCalendar, sKey, SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
				oCalendar = null;
			}
		}

	}
}
