using System;

namespace MSP2003
{
	public class ResourceAvailabilityPeriods
	{

		private clsCollectionBase mp_oCollection;

		public ResourceAvailabilityPeriods()
		{
			mp_oCollection = new clsCollectionBase("ResourceAvailabilityPeriod");
		}

		public int Count
		{
			get
			{
				return mp_oCollection.m_lCount();
			}
		}

		public ResourceAvailabilityPeriod Item(string Index)
		{
			return (ResourceAvailabilityPeriod) mp_oCollection.m_oItem(Index, SYS_ERRORS.MP_ITEM_1, SYS_ERRORS.MP_ITEM_2, SYS_ERRORS.MP_ITEM_3, SYS_ERRORS.MP_ITEM_4);
		}

		public ResourceAvailabilityPeriod Add()
		{
			mp_oCollection.AddMode = true;
			ResourceAvailabilityPeriod oResourceAvailabilityPeriod = new ResourceAvailabilityPeriod();
			oResourceAvailabilityPeriod.mp_oCollection = mp_oCollection;
			mp_oCollection.m_Add(oResourceAvailabilityPeriod, "", SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
			return oResourceAvailabilityPeriod;
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
				return "<AvailabilityPeriods/>";
			}
			int lIndex;
			ResourceAvailabilityPeriod oResourceAvailabilityPeriod;
			clsXML oXML = new clsXML("AvailabilityPeriods");
			oXML.BoolsAreNumeric = true;
			oXML.InitializeWriter();
				for (lIndex = 1; lIndex <= Count; lIndex++)
			{
				oResourceAvailabilityPeriod = (ResourceAvailabilityPeriod) mp_oCollection.m_oReturnArrayElement(lIndex);
				oXML.WriteObject(oResourceAvailabilityPeriod.GetXML());
			}
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			int lIndex;
			clsXML oXML = new clsXML("AvailabilityPeriods");
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
				ResourceAvailabilityPeriod oResourceAvailabilityPeriod = new ResourceAvailabilityPeriod();
				oResourceAvailabilityPeriod.SetXML(oXML.ReadCollectionObject(lIndex));
				mp_oCollection.AddMode = true;
				string sKey = "";
				oResourceAvailabilityPeriod.mp_oCollection = mp_oCollection;
				mp_oCollection.m_Add(oResourceAvailabilityPeriod, sKey, SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
				oResourceAvailabilityPeriod = null;
			}
		}

	}
}
