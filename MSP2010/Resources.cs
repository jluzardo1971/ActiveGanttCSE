using System;

namespace MSP2010
{
	public class Resources
	{

		private clsCollectionBase mp_oCollection;

		public Resources()
		{
			mp_oCollection = new clsCollectionBase("Resource");
		}

		public int Count
		{
			get
			{
				return mp_oCollection.m_lCount();
			}
		}

		public Resource Item(string Index)
		{
			return (Resource) mp_oCollection.m_oItem(Index, SYS_ERRORS.MP_ITEM_1, SYS_ERRORS.MP_ITEM_2, SYS_ERRORS.MP_ITEM_3, SYS_ERRORS.MP_ITEM_4);
		}

		public Resource Add()
		{
			mp_oCollection.AddMode = true;
			Resource oResource = new Resource();
			oResource.mp_oCollection = mp_oCollection;
			mp_oCollection.m_Add(oResource, "", SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
			return oResource;
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
				return "<Resources/>";
			}
			int lIndex;
			Resource oResource;
			clsXML oXML = new clsXML("Resources");
			oXML.BoolsAreNumeric = true;
			oXML.InitializeWriter();
				for (lIndex = 1; lIndex <= Count; lIndex++)
			{
				oResource = (Resource) mp_oCollection.m_oReturnArrayElement(lIndex);
				oXML.WriteObject(oResource.GetXML());
			}
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			int lIndex;
			clsXML oXML = new clsXML("Resources");
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
				Resource oResource = new Resource();
				oResource.SetXML(oXML.ReadCollectionObject(lIndex));
				mp_oCollection.AddMode = true;
				string sKey = "";
				sKey = "K" + oResource.lUID.ToString();
					oResource.mp_oCollection = mp_oCollection;
					oResource.Key = sKey;
				mp_oCollection.m_Add(oResource, sKey, SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
				oResource = null;
			}
		}

	}
}
