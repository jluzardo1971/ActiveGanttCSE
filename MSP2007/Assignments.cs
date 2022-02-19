using System;

namespace MSP2007
{
	public class Assignments
	{

		private clsCollectionBase mp_oCollection;

		public Assignments()
		{
			mp_oCollection = new clsCollectionBase("Assignment");
		}

		public int Count
		{
			get
			{
				return mp_oCollection.m_lCount();
			}
		}

		public Assignment Item(string Index)
		{
			return (Assignment) mp_oCollection.m_oItem(Index, SYS_ERRORS.MP_ITEM_1, SYS_ERRORS.MP_ITEM_2, SYS_ERRORS.MP_ITEM_3, SYS_ERRORS.MP_ITEM_4);
		}

		public Assignment Add()
		{
			mp_oCollection.AddMode = true;
			Assignment oAssignment = new Assignment();
			oAssignment.mp_oCollection = mp_oCollection;
			mp_oCollection.m_Add(oAssignment, "", SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
			return oAssignment;
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
				return "<Assignments/>";
			}
			int lIndex;
			Assignment oAssignment;
			clsXML oXML = new clsXML("Assignments");
			oXML.BoolsAreNumeric = true;
			oXML.InitializeWriter();
				for (lIndex = 1; lIndex <= Count; lIndex++)
			{
				oAssignment = (Assignment) mp_oCollection.m_oReturnArrayElement(lIndex);
				oXML.WriteObject(oAssignment.GetXML());
			}
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			int lIndex;
			clsXML oXML = new clsXML("Assignments");
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
				Assignment oAssignment = new Assignment();
				oAssignment.SetXML(oXML.ReadCollectionObject(lIndex));
				mp_oCollection.AddMode = true;
				string sKey = "";
				sKey = "K" + oAssignment.lUID.ToString();
					oAssignment.mp_oCollection = mp_oCollection;
					oAssignment.Key = sKey;
				mp_oCollection.m_Add(oAssignment, sKey, SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
				oAssignment = null;
			}
		}

	}
}
