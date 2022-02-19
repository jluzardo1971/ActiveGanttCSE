using System;

namespace MSP2010
{
	public class Tasks
	{

		private clsCollectionBase mp_oCollection;

		public Tasks()
		{
			mp_oCollection = new clsCollectionBase("Task");
		}

		public int Count
		{
			get
			{
				return mp_oCollection.m_lCount();
			}
		}

		public Task Item(string Index)
		{
			return (Task) mp_oCollection.m_oItem(Index, SYS_ERRORS.MP_ITEM_1, SYS_ERRORS.MP_ITEM_2, SYS_ERRORS.MP_ITEM_3, SYS_ERRORS.MP_ITEM_4);
		}

		public Task Add()
		{
			mp_oCollection.AddMode = true;
			Task oTask = new Task();
			oTask.mp_oCollection = mp_oCollection;
			mp_oCollection.m_Add(oTask, "", SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
			return oTask;
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
				return "<Tasks/>";
			}
			int lIndex;
			Task oTask;
			clsXML oXML = new clsXML("Tasks");
			oXML.BoolsAreNumeric = true;
			oXML.InitializeWriter();
				for (lIndex = 1; lIndex <= Count; lIndex++)
			{
				oTask = (Task) mp_oCollection.m_oReturnArrayElement(lIndex);
				oXML.WriteObject(oTask.GetXML());
			}
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			int lIndex;
			clsXML oXML = new clsXML("Tasks");
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
				Task oTask = new Task();
				oTask.SetXML(oXML.ReadCollectionObject(lIndex));
				mp_oCollection.AddMode = true;
				string sKey = "";
				sKey = "K" + oTask.lUID.ToString();
					oTask.mp_oCollection = mp_oCollection;
					oTask.Key = sKey;
				mp_oCollection.m_Add(oTask, sKey, SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
				oTask = null;
			}
		}

	}
}
