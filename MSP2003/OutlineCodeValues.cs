using System;

namespace MSP2003
{
	public class OutlineCodeValues
	{

		private clsCollectionBase mp_oCollection;

		public OutlineCodeValues()
		{
			mp_oCollection = new clsCollectionBase("OutlineCodeValue");
		}

		public int Count
		{
			get
			{
				return mp_oCollection.m_lCount();
			}
		}

		public OutlineCodeValue Item(string Index)
		{
			return (OutlineCodeValue) mp_oCollection.m_oItem(Index, SYS_ERRORS.MP_ITEM_1, SYS_ERRORS.MP_ITEM_2, SYS_ERRORS.MP_ITEM_3, SYS_ERRORS.MP_ITEM_4);
		}

		public OutlineCodeValue Add()
		{
			mp_oCollection.AddMode = true;
			OutlineCodeValue oOutlineCodeValue = new OutlineCodeValue();
			oOutlineCodeValue.mp_oCollection = mp_oCollection;
			mp_oCollection.m_Add(oOutlineCodeValue, "", SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
			return oOutlineCodeValue;
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
				return "<Values/>";
			}
			int lIndex;
			OutlineCodeValue oOutlineCodeValue;
			clsXML oXML = new clsXML("Values");
			oXML.BoolsAreNumeric = true;
			oXML.InitializeWriter();
				for (lIndex = 1; lIndex <= Count; lIndex++)
			{
				oOutlineCodeValue = (OutlineCodeValue) mp_oCollection.m_oReturnArrayElement(lIndex);
				oXML.WriteObject(oOutlineCodeValue.GetXML());
			}
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			int lIndex;
			clsXML oXML = new clsXML("Values");
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
				OutlineCodeValue oOutlineCodeValue = new OutlineCodeValue();
				oOutlineCodeValue.SetXML(oXML.ReadCollectionObject(lIndex));
				mp_oCollection.AddMode = true;
				string sKey = "";
				oOutlineCodeValue.mp_oCollection = mp_oCollection;
				mp_oCollection.m_Add(oOutlineCodeValue, sKey, SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
				oOutlineCodeValue = null;
			}
		}

	}
}
