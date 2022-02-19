using System;

namespace MSP2007
{
	public class OutlineCodeMasks
	{

		private clsCollectionBase mp_oCollection;

		public OutlineCodeMasks()
		{
			mp_oCollection = new clsCollectionBase("OutlineCodeMask");
		}

		public int Count
		{
			get
			{
				return mp_oCollection.m_lCount();
			}
		}

		public OutlineCodeMask Item(string Index)
		{
			return (OutlineCodeMask) mp_oCollection.m_oItem(Index, SYS_ERRORS.MP_ITEM_1, SYS_ERRORS.MP_ITEM_2, SYS_ERRORS.MP_ITEM_3, SYS_ERRORS.MP_ITEM_4);
		}

		public OutlineCodeMask Add()
		{
			mp_oCollection.AddMode = true;
			OutlineCodeMask oOutlineCodeMask = new OutlineCodeMask();
			oOutlineCodeMask.mp_oCollection = mp_oCollection;
			mp_oCollection.m_Add(oOutlineCodeMask, "", SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
			return oOutlineCodeMask;
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
				return "<Masks/>";
			}
			int lIndex;
			OutlineCodeMask oOutlineCodeMask;
			clsXML oXML = new clsXML("Masks");
			oXML.BoolsAreNumeric = true;
			oXML.InitializeWriter();
				for (lIndex = 1; lIndex <= Count; lIndex++)
			{
				oOutlineCodeMask = (OutlineCodeMask) mp_oCollection.m_oReturnArrayElement(lIndex);
				oXML.WriteObject(oOutlineCodeMask.GetXML());
			}
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			int lIndex;
			clsXML oXML = new clsXML("Masks");
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
				OutlineCodeMask oOutlineCodeMask = new OutlineCodeMask();
				oOutlineCodeMask.SetXML(oXML.ReadCollectionObject(lIndex));
				mp_oCollection.AddMode = true;
				string sKey = "";
				oOutlineCodeMask.mp_oCollection = mp_oCollection;
				mp_oCollection.m_Add(oOutlineCodeMask, sKey, SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
				oOutlineCodeMask = null;
			}
		}

	}
}
