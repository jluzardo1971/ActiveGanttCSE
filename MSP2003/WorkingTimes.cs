using System;

namespace MSP2003
{
	public class WorkingTimes
	{

		private clsCollectionBase mp_oCollection;

		public WorkingTimes()
		{
			mp_oCollection = new clsCollectionBase("WorkingTime");
		}

		public int Count
		{
			get
			{
				return mp_oCollection.m_lCount();
			}
		}

		public WorkingTime Item(string Index)
		{
			return (WorkingTime) mp_oCollection.m_oItem(Index, SYS_ERRORS.MP_ITEM_1, SYS_ERRORS.MP_ITEM_2, SYS_ERRORS.MP_ITEM_3, SYS_ERRORS.MP_ITEM_4);
		}

		public WorkingTime Add()
		{
			mp_oCollection.AddMode = true;
			WorkingTime oWorkingTime = new WorkingTime();
			oWorkingTime.mp_oCollection = mp_oCollection;
			mp_oCollection.m_Add(oWorkingTime, "", SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
			return oWorkingTime;
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
				return "<WorkingTimes/>";
			}
			int lIndex;
			WorkingTime oWorkingTime;
			clsXML oXML = new clsXML("WorkingTimes");
			oXML.BoolsAreNumeric = true;
			oXML.InitializeWriter();
				for (lIndex = 1; lIndex <= Count; lIndex++)
			{
				oWorkingTime = (WorkingTime) mp_oCollection.m_oReturnArrayElement(lIndex);
				oXML.WriteObject(oWorkingTime.GetXML());
			}
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			int lIndex;
			clsXML oXML = new clsXML("WorkingTimes");
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
				WorkingTime oWorkingTime = new WorkingTime();
				oWorkingTime.SetXML(oXML.ReadCollectionObject(lIndex));
				mp_oCollection.AddMode = true;
				string sKey = "";
				oWorkingTime.mp_oCollection = mp_oCollection;
				mp_oCollection.m_Add(oWorkingTime, sKey, SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
				oWorkingTime = null;
			}
		}

	}
}
