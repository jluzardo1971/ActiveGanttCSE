using System;

namespace MSP2010
{
	public class ResourceRates
	{

		private clsCollectionBase mp_oCollection;

		public ResourceRates()
		{
			mp_oCollection = new clsCollectionBase("ResourceRate");
		}

		public int Count
		{
			get
			{
				return mp_oCollection.m_lCount();
			}
		}

		public ResourceRate Item(string Index)
		{
			return (ResourceRate) mp_oCollection.m_oItem(Index, SYS_ERRORS.MP_ITEM_1, SYS_ERRORS.MP_ITEM_2, SYS_ERRORS.MP_ITEM_3, SYS_ERRORS.MP_ITEM_4);
		}

		public ResourceRate Add()
		{
			mp_oCollection.AddMode = true;
			ResourceRate oResourceRate = new ResourceRate();
			oResourceRate.mp_oCollection = mp_oCollection;
			mp_oCollection.m_Add(oResourceRate, "", SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
			return oResourceRate;
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
				return "<Rates/>";
			}
			int lIndex;
			ResourceRate oResourceRate;
			clsXML oXML = new clsXML("Rates");
			oXML.BoolsAreNumeric = true;
			oXML.InitializeWriter();
				for (lIndex = 1; lIndex <= Count; lIndex++)
			{
				oResourceRate = (ResourceRate) mp_oCollection.m_oReturnArrayElement(lIndex);
				oXML.WriteObject(oResourceRate.GetXML());
			}
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			int lIndex;
			clsXML oXML = new clsXML("Rates");
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
				ResourceRate oResourceRate = new ResourceRate();
				oResourceRate.SetXML(oXML.ReadCollectionObject(lIndex));
				mp_oCollection.AddMode = true;
				string sKey = "";
				oResourceRate.mp_oCollection = mp_oCollection;
				mp_oCollection.m_Add(oResourceRate, sKey, SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
				oResourceRate = null;
			}
		}

	}
}
