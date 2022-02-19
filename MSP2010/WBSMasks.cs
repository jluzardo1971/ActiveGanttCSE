using System;

namespace MSP2010
{
	public class WBSMasks
	{

		private clsCollectionBase mp_oCollection;

		public WBSMasks()
		{
			mp_oCollection = new clsCollectionBase("WBSMask");
		}

		public int Count
		{
			get
			{
				return mp_oCollection.m_lCount();
			}
		}

		public WBSMask Item(string Index)
		{
			return (WBSMask) mp_oCollection.m_oItem(Index, SYS_ERRORS.MP_ITEM_1, SYS_ERRORS.MP_ITEM_2, SYS_ERRORS.MP_ITEM_3, SYS_ERRORS.MP_ITEM_4);
		}

		public WBSMask Add()
		{
			mp_oCollection.AddMode = true;
			WBSMask oWBSMask = new WBSMask();
			oWBSMask.mp_oCollection = mp_oCollection;
			mp_oCollection.m_Add(oWBSMask, "", SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
			return oWBSMask;
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
				return "<WBSMasks/>";
			}
			int lIndex;
			WBSMask oWBSMask;
			clsXML oXML = new clsXML("WBSMasks");
			oXML.BoolsAreNumeric = true;
			oXML.InitializeWriter();
				for (lIndex = 1; lIndex <= Count; lIndex++)
			{
				oWBSMask = (WBSMask) mp_oCollection.m_oReturnArrayElement(lIndex);
				oXML.WriteObject(oWBSMask.GetXML());
			}
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			int lIndex;
			clsXML oXML = new clsXML("WBSMasks");
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
				WBSMask oWBSMask = new WBSMask();
				oWBSMask.SetXML(oXML.ReadCollectionObject(lIndex));
				mp_oCollection.AddMode = true;
				string sKey = "";
				oWBSMask.mp_oCollection = mp_oCollection;
				mp_oCollection.m_Add(oWBSMask, sKey, SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
				oWBSMask = null;
			}
		}

	}
}
