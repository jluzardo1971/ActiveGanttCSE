using System;

namespace MSP2003
{
	public class TimePeriods
	{

		private clsCollectionBase mp_oCollection;

		public TimePeriods()
		{
			mp_oCollection = new clsCollectionBase("TimePeriod");
		}

		public int Count
		{
			get
			{
				return mp_oCollection.m_lCount();
			}
		}

		public TimePeriod Item(string Index)
		{
			return (TimePeriod) mp_oCollection.m_oItem(Index, SYS_ERRORS.MP_ITEM_1, SYS_ERRORS.MP_ITEM_2, SYS_ERRORS.MP_ITEM_3, SYS_ERRORS.MP_ITEM_4);
		}

		public TimePeriod Add()
		{
			mp_oCollection.AddMode = true;
			TimePeriod oTimePeriod = new TimePeriod();
			oTimePeriod.mp_oCollection = mp_oCollection;
			mp_oCollection.m_Add(oTimePeriod, "", SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
			return oTimePeriod;
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
				return "<TimePeriods/>";
			}
			int lIndex;
			TimePeriod oTimePeriod;
			clsXML oXML = new clsXML("TimePeriods");
			oXML.BoolsAreNumeric = true;
			oXML.InitializeWriter();
				for (lIndex = 1; lIndex <= Count; lIndex++)
			{
				oTimePeriod = (TimePeriod) mp_oCollection.m_oReturnArrayElement(lIndex);
				oXML.WriteObject(oTimePeriod.GetXML());
			}
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			int lIndex;
			clsXML oXML = new clsXML("TimePeriods");
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
				TimePeriod oTimePeriod = new TimePeriod();
				oTimePeriod.SetXML(oXML.ReadCollectionObject(lIndex));
				mp_oCollection.AddMode = true;
				string sKey = "";
				oTimePeriod.mp_oCollection = mp_oCollection;
				mp_oCollection.m_Add(oTimePeriod, sKey, SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
				oTimePeriod = null;
			}
		}

	}
}
