using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections;

namespace AGCSE
{
	internal class clsCollectionBase
	{
		private ActiveGanttCSECtl mp_oControl;
		private String m_sObjectName;
		internal ArrayList mp_aoCollection;
		private bool mp_bAddMode;
		private bool mp_bDescending;
		private bool mp_bIgnoreKeyChecks;
		private bool mp_bSortCells;
		private int mp_lCellIndex;
		internal clsDictionary mp_oKeys;
		private String mp_sPropertyName;
		private E_SORTTYPE mp_ySortType;

		public clsCollectionBase(ActiveGanttCSECtl Value, String sObjectName)
		{
			mp_oControl = Value;
			mp_aoCollection = new ArrayList();
			mp_oKeys = new clsDictionary();
			m_sObjectName = sObjectName;
		}

		~clsCollectionBase()
		{
		}

		public Object m_oItem(String v_lIndex, SYS_ERRORS v_lErr1, SYS_ERRORS v_lErr2, SYS_ERRORS v_lErr3, SYS_ERRORS v_lErr4)
		{
			int lIndex;
			if ( !mp_oControl.StrLib.StrIsNumeric(v_lIndex) )
			{
				if ( v_lIndex == "" )
				{
                    mp_oControl.mp_ErrorReport(v_lErr1, "Invalid " + m_sObjectName + " object key, key cannot be an empty string", "ActiveGanttCSECtl" + m_sObjectName + "s.Get m_oItem");
					return null;
				}
				lIndex = m_lFindIndexByKey(v_lIndex);
				if ( lIndex == -1 )
				{
                    mp_oControl.mp_ErrorReport(v_lErr2, m_sObjectName + " object not found, invalid key (\"" + v_lIndex + "\")", "ActiveGanttCSECtl" + m_sObjectName + "s.Get m_oItem");
					return null;
				}
			}
			else
			{
				lIndex = mp_oControl.StrLib.StrCLng(v_lIndex);
				if ( mp_oControl.StrLib.StrCStr(lIndex) != v_lIndex )
				{
                    mp_oControl.mp_ErrorReport(v_lErr3, m_sObjectName + " object not found, invalid v_lIndex", "ActiveGanttCSECtl" + m_sObjectName + "s.Get m_oItem");
					return null;
				}
				if ( lIndex < 1 | lIndex > mp_aoCollection.Count )
				{
                    mp_oControl.mp_ErrorReport(v_lErr4, m_sObjectName + " object not found, v_lIndex out of bounds", "ActiveGanttCSECtl" + m_sObjectName + "s.Get m_oItem");
					return null;
				}
			}
			return mp_aoCollection[lIndex - 1];
		}


		public bool m_bIgnoreKeyChecks 
		{
			get 
			{
				return mp_bIgnoreKeyChecks;
			}
			set 
			{
				mp_bIgnoreKeyChecks = value;
			}
		}

		public void m_Add(object r_oObject, String v_sKey, SYS_ERRORS v_lErr1, SYS_ERRORS v_lErr2, bool v_bKeyRequired, SYS_ERRORS v_lKeyError)
		{
			clsItemBase oItemBase;
			oItemBase = (clsItemBase) r_oObject;
			int lUpperBounds;
			if (mp_bAddMode == false)
			{
                mp_oControl.mp_ErrorReport(SYS_ERRORS.ERR_ADDMODE_G, "AddMode must be set to true before executing oCollection.m_Add", "cls" + m_sObjectName + "s");
			}
			if (mp_oControl.StrLib.StrIsNumeric(v_sKey) )
			{
				mp_oControl.mp_ErrorReport(v_lErr1, "Invalid " + m_sObjectName + " object key, key cannot be numeric", "ActiveGanttCSECtl.cls" + m_sObjectName + "s.Add");
				return;
			}
			if (v_sKey != "" )
			{
				if (m_bIsKeyUnique(v_sKey) == false )
				{
                    mp_oControl.mp_ErrorReport(v_lErr2, "Key is not unique in " + m_sObjectName + "s collection", "ActiveGanttCSECtl.cls" + m_sObjectName + "s.Add");
					return;
				}
			}
			lUpperBounds = mp_aoCollection.Count + 1;
			oItemBase.Index = lUpperBounds;
			mp_aoCollection.Add(r_oObject);
			if ( v_sKey != "" )
			{
				mp_oKeys.Add(lUpperBounds, v_sKey);
			}
			mp_bAddMode = false;
		}

		public int m_lCount()
		{
			return mp_aoCollection.Count;
		}

		public void m_Clear()
		{
			mp_aoCollection.Clear();
			m_ReconstKeys();
		}

		public void m_Remove(String v_sIndex, SYS_ERRORS v_lErr1, SYS_ERRORS v_lErr2, SYS_ERRORS v_lErr3, SYS_ERRORS v_lErr4)
		{
			int lIndex;
			int lRemovedIndex;
			if ( !mp_oControl.StrLib.StrIsNumeric(v_sIndex) )
			{
				if ( v_sIndex == "" )
				{
                    mp_oControl.mp_ErrorReport(v_lErr1, "Invalid " + m_sObjectName + " object key, key cannot be an empty string", "ActiveGanttCSECtl" + m_sObjectName + "s.Remove");
					return;
				}
				lIndex = m_lFindIndexByKey(v_sIndex);
				if ( lIndex == -1 )
				{
                    mp_oControl.mp_ErrorReport(v_lErr2, m_sObjectName + " object not found, invalid key (\"" + v_sIndex + "\")", "ActiveGanttCSECtl" + m_sObjectName + "s.Remove");
					return;
				}
				lRemovedIndex = lIndex;
			}
			else
			{
				lIndex = mp_oControl.StrLib.StrCLng(v_sIndex);
				if ( mp_oControl.StrLib.StrCStr(lIndex) != v_sIndex )
				{
                    mp_oControl.mp_ErrorReport(v_lErr3, m_sObjectName + " object not found, invalid v_sIndex", "ActiveGanttCSECtl" + m_sObjectName + "s.Remove");
					return;
				}
				if ( lIndex < 1 | lIndex > mp_aoCollection.Count )
				{
                    mp_oControl.mp_ErrorReport(v_lErr4, m_sObjectName + " object not found, v_sIndex out of bounds", "ActiveGanttCSECtl" + m_sObjectName + "s.Remove");
					return;
				}
				clsItemBase oItemBase;
				oItemBase = (clsItemBase) mp_aoCollection[lIndex - 1];
				lRemovedIndex = lIndex;
			}
			mp_bIgnoreKeyChecks = true;
			mp_aoCollection.RemoveAt(lRemovedIndex - 1);
			mp_bIgnoreKeyChecks = false;
			m_ReconstKeys();
		}

		public int m_lCopyAndMoveItems(int v_lOriginIndex, int v_lDestinationIndex)
		{
			Object Buffer;
			int lIndex;
			mp_bIgnoreKeyChecks = true;
			v_lOriginIndex = v_lOriginIndex - 1;
			v_lDestinationIndex = v_lDestinationIndex - 1;
			Buffer = mp_aoCollection[v_lOriginIndex];
			if ( v_lOriginIndex > v_lDestinationIndex )
			{
				for (lIndex = v_lOriginIndex;lIndex >= v_lDestinationIndex + 1;lIndex--) 
				{
					mp_aoCollection[lIndex] = mp_aoCollection[lIndex - 1];
				}
			}
			else
			{
				for (lIndex = v_lOriginIndex;lIndex <= v_lDestinationIndex - 1;lIndex++) 
				{
					mp_aoCollection[lIndex] = mp_aoCollection[lIndex + 1];
				}
			}
			mp_aoCollection[v_lDestinationIndex] = Buffer;
			mp_bIgnoreKeyChecks = false;
			m_ReconstKeys();
			return lIndex;
		}

		public void m_ReconstKeys()
		{
			int lIndex;
			int lCount;
			String sKey;
			mp_oKeys = null;
			mp_oKeys = new clsDictionary();
			lCount = mp_aoCollection.Count;
			for (lIndex = 1;lIndex <= lCount;lIndex++) 
			{
				clsItemBase oItemBase;
				oItemBase = (clsItemBase) mp_aoCollection[lIndex - 1];
				sKey = oItemBase.mp_sKey;
				oItemBase.Index = lIndex;
				if ( sKey != "" )
				{
					mp_oKeys.Add(lIndex, sKey);
				}
			}
		}

		public int m_lFindIndexByKey(String v_sKey)
		{
			if (mp_oKeys.Contains(v_sKey) == true)
			{
				return mp_oKeys[v_sKey];
			}
			else
			{
				return -1;
			}
		}

		public bool m_bIsKeyUnique(String v_sKey)
		{
			return !mp_oKeys.Contains(v_sKey);
		}

		public bool m_bDoesKeyExist(String v_sKey)
		{
			return mp_oKeys.Contains(v_sKey);
		}

		public Object m_oReturnArrayElement(int r_lIndex)
		{
			System.Diagnostics.Debug.Assert(r_lIndex >= 1 & r_lIndex <= mp_aoCollection.Count); 
			return mp_aoCollection[r_lIndex - 1];
		}

		public void m_Sort(String sPropertyName, bool bDescending, E_SORTTYPE SortType, int StartIndex, int EndIndex)
		{
			ArrayList aTempArray = new ArrayList();
			int lIndex;
			for (lIndex = 1; lIndex <= EndIndex; lIndex++)
			{
				aTempArray.Add(null);
			}
			mp_sPropertyName = sPropertyName;
			mp_bDescending = bDescending;
			mp_ySortType = SortType;
			mp_bSortCells = false;
			mp_Sort(mp_aoCollection, aTempArray, StartIndex - 1, EndIndex - 1);
			m_ReconstKeys();
		}

		public void m_SortCells(int CellIndex, String sPropertyName, bool bDescending, E_SORTTYPE SortType, int StartIndex, int EndIndex)
		{
			ArrayList aTempArray = new ArrayList();
			int lIndex;
			for (lIndex = 1; lIndex <= EndIndex; lIndex++)
			{
				aTempArray.Add(null);
			}
			mp_sPropertyName = sPropertyName;
			mp_bDescending = bDescending;
			mp_ySortType = SortType;
			mp_bSortCells = true;
			mp_lCellIndex = CellIndex;
			mp_Sort(mp_aoCollection, aTempArray, StartIndex - 1, EndIndex - 1);
			m_ReconstKeys();
		}

		private void mp_Sort(ArrayList r_aSortArray, ArrayList r_aTempArray, int first, int last)
		{
			int lArrayMBound;
			int lArrayLBound;
			int lArrayUBound;
			if ( first == -1 )
			{
				lArrayLBound = 0;
			}
			else
			{
				lArrayLBound = first;
			}
			if ( last == -1 )
			{
				lArrayUBound = r_aSortArray.Count;
			}
			else
			{
				lArrayUBound = last;
			}
			if ( lArrayUBound > lArrayLBound )
			{
				lArrayMBound = (lArrayUBound + lArrayLBound) / 2;
				mp_Sort(r_aSortArray, r_aTempArray, lArrayLBound, lArrayMBound);
				mp_Sort(r_aSortArray, r_aTempArray, lArrayMBound + 1, lArrayUBound);
				mp_Merge(r_aSortArray, r_aTempArray, lArrayLBound, lArrayMBound + 1, lArrayUBound);
			}
		}

        private void mp_Merge(ArrayList r_aSortArray, ArrayList r_aTempArray, int first, int mid, int last)
        {
            int i;
            int iLow;
            int nNumElements;
            int iTempPos;
            iLow = mid - 1;
            iTempPos = first;
            nNumElements = last - first + 1;
            while (first <= iLow & mid <= last)
            {
                if (mp_bDescending == false)
                {
                    if (mp_bCompareTypes((clsItemBase)r_aSortArray[first], (clsItemBase)r_aSortArray[mid]) == true)
                    {
                        r_aTempArray[iTempPos] = r_aSortArray[first];
                        iTempPos = iTempPos + 1;
                        first = first + 1;
                    }
                    else
                    {
                        r_aTempArray[iTempPos] = r_aSortArray[mid];
                        iTempPos = iTempPos + 1;
                        mid = mid + 1;
                    }
                }
                else
                {
                    if (mp_bCompareTypes((clsItemBase)r_aSortArray[first], (clsItemBase)r_aSortArray[mid]) == false)
                    {
                        r_aTempArray[iTempPos] = r_aSortArray[first];
                        iTempPos = iTempPos + 1;
                        first = first + 1;
                    }
                    else
                    {
                        r_aTempArray[iTempPos] = r_aSortArray[mid];
                        iTempPos = iTempPos + 1;
                        mid = mid + 1;
                    }
                }
            }
            while (first <= iLow)
            {
                r_aTempArray[iTempPos] = r_aSortArray[first];
                first = first + 1;
                iTempPos = iTempPos + 1;
            }
            while (mid <= last)
            {
                r_aTempArray[iTempPos] = r_aSortArray[mid];
                mid = mid + 1;
                iTempPos = iTempPos + 1;
            }
            for (i = 0; i <= nNumElements - 1; i++)
            {
                r_aSortArray[last] = r_aTempArray[last];
                last = last - 1;
            }
        }

        private bool mp_bCompareTypes(clsItemBase oItemBase1, clsItemBase oItemBase2)
        {
            System.Type t1 = oItemBase1.GetType();
            System.Type t2 = oItemBase1.GetType();
            System.Reflection.PropertyInfo pi1;
            System.Reflection.PropertyInfo pi2;
            clsCell oCell1 = null;
            clsCell oCell2 = null;
            object oObject1 = null;
            object oObject2 = null;



            if (mp_bSortCells == false)
            {
                pi1 = t1.GetProperty(mp_sPropertyName);
                pi2 = t2.GetProperty(mp_sPropertyName);
                oObject1 = oItemBase1;
                oObject2 = oItemBase2;
            }
            else
            {

                System.Reflection.MethodInfo mth1;
                System.Reflection.MethodInfo mth2;
                mth1 = t1.GetMethod("Cell");
                mth2 = t2.GetMethod("Cell");
                oCell1 = (clsCell)mth1.Invoke(oItemBase1, new object[] { mp_lCellIndex });
                oCell2 = (clsCell)mth2.Invoke(oItemBase2, new object[] { mp_lCellIndex });

                pi1 = oCell1.GetType().GetProperty(mp_sPropertyName);
                pi2 = oCell2.GetType().GetProperty(mp_sPropertyName);

                oObject1 = oCell1;
                oObject2 = oCell2;
            }

            switch (mp_ySortType)
            {
                case E_SORTTYPE.ES_NUMERIC:
                    int lValue1;
                    int lValue2;
                    lValue1 = (int)pi1.GetValue(oObject1, null);
                    lValue2 = (int)pi2.GetValue(oObject2, null);
                    if (lValue1 >= lValue2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case E_SORTTYPE.ES_STRING:
                    String sValue1;
                    String sValue2;
                    sValue1 = (String)pi1.GetValue(oObject1, null);
                    sValue2 = (String)pi2.GetValue(oObject2, null);
                    if (sValue2.CompareTo(sValue1) <= 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case E_SORTTYPE.ES_DATE:
                    DateTime dtValue1;
                    DateTime dtValue2;
                    dtValue1 = (DateTime)pi1.GetValue(oObject1, null);
                    dtValue2 = (DateTime)pi2.GetValue(oObject2, null);
                    if (dtValue1 >= dtValue2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return false;
            }
        }

		public int m_lReturnIndex(String v_sIndex, bool bIncludeDefault)
		{
			int lIndex = 0;
			int lReturn = 0;

			if ((mp_oControl.StrLib.StrIsNumeric(v_sIndex)))
			{
				lIndex = mp_oControl.StrLib.StrCLng(v_sIndex);
				if ( (bIncludeDefault == true) )
				{
					if ((lIndex >= 0 & lIndex <= m_lCount()) )
					{
						lReturn = lIndex;
					}
					else
					{
						lReturn = -1;
					}
				}
				else
				{
					if ( (lIndex >= 1 & lIndex <= m_lCount()) )
					{
						lReturn = lIndex;
					}
					else
					{
						lReturn = -1;
					}
				}
			}
			else
			{
				lReturn = m_lFindIndexByKey(v_sIndex);
			}

			return lReturn;
		}

		public Object m_oReturnArrayElementKey(String v_sKey)
		{
			int lIndex;
			if ( mp_oControl.StrLib.StrIsNumeric(v_sKey) )
			{
				return mp_aoCollection[mp_oControl.StrLib.StrCLng(v_sKey)-1];
			}
			else
			{
				lIndex = m_lFindIndexByKey(v_sKey);
				if ( lIndex != -1 )
				{
					return mp_aoCollection[lIndex - 1];
				}
				else
				{
                    mp_oControl.mp_ErrorReport(SYS_ERRORS.ERR_RETARRELEMKEY_G, "Key not found", "ActiveGanttCSECtl" + m_sObjectName + "s.m_oReturnArrayElementKey");
					return null;
				}
			}
		}

		public void mp_SetKey(ref String sCurrentKey, String sNewKey, SYS_ERRORS ErrNumber)
		{
			if (m_bIgnoreKeyChecks == false)
			{
				if (mp_oControl.StrLib.StrIsNumeric(sNewKey) | (sNewKey != sCurrentKey & m_bIsKeyUnique(sNewKey) == false))
				{
					mp_oControl.mp_ErrorReport(ErrNumber, "Numeric or duplicate " + m_sObjectName + " object key", "ActiveGanttCSECtl" + m_sObjectName + ".Let Key");
					return;
				}
			}
			sCurrentKey = sNewKey;
			if (mp_bAddMode == false)
			{
				m_ReconstKeys();
			}
		}

		public bool AddMode 
		{
			get 
			{
				return mp_bAddMode;
			}
			set 
			{
				mp_bAddMode = value;
			}
		}

		public void m_GetKeyAndIndex(String sIndex, ref String sKey, ref String sReturnIndex)
		{
			clsItemBase oObject;
			oObject = (clsItemBase) m_oItem(sIndex, SYS_ERRORS.GETINDEXANDKEY_ITEM1, SYS_ERRORS.GETINDEXANDKEY_ITEM2, SYS_ERRORS.GETINDEXANDKEY_ITEM3, SYS_ERRORS.GETINDEXANDKEY_ITEM4);
			if (oObject.mp_sKey != "")
			{
				sKey = oObject.mp_sKey;
			}
			else
			{
				sKey = mp_oControl.StrLib.StrCStr(oObject.Index);
			}
			sReturnIndex = mp_oControl.StrLib.StrCStr(oObject.Index);
		}

		public void m_CollectionRemoveWhere(String sPropertyName, String sKey, String sIndex)
		{
			int lIndex;
			Object oObject;
			String sPropertyValue;
			for (lIndex = m_lCount();lIndex >= 1 ;lIndex--) 
			{
				oObject = m_oReturnArrayElement(lIndex);
				sPropertyValue = CallByName(oObject, sPropertyName);
				if (sPropertyValue == sKey | sPropertyValue == sIndex)
				{
					m_Remove(lIndex.ToString(), SYS_ERRORS.ERR_COLLREMWHERE_1_G, SYS_ERRORS.ERR_COLLREMWHERE_2_G, SYS_ERRORS.ERR_COLLREMWHERE_3_G, SYS_ERRORS.ERR_COLLREMWHERE_4_G);
				}
			}
		}

		public void m_CollectionRemoveWhereNot(String sPropertyName, String sValue)
		{
			int lIndex;
			Object oObject;
			String sPropertyValue;
			String sIndex;
			for (lIndex = m_lCount();lIndex >= 1 ;lIndex--) 
			{
				oObject = m_oReturnArrayElement(lIndex);
				sPropertyValue = CallByName(oObject, sPropertyName);
				if (sPropertyValue != sValue)
				{
					sIndex = mp_oControl.StrLib.StrCStr(lIndex);
					m_Remove(sIndex, SYS_ERRORS.ERR_COLLREMWHERENOT_1_G, SYS_ERRORS.ERR_COLLREMWHERENOT_2_G, SYS_ERRORS.ERR_COLLREMWHERENOT_3_G, SYS_ERRORS.ERR_COLLREMWHERENOT_4_G);
				}
			}
		}

		public void m_CollectionChange(String sPropertyName, String sKey, String sIndex, String sNewValue)
		{
			int lIndex;
			Object oObject;
			String sPropertyValue;
			for (lIndex = 1;lIndex <= m_lCount();lIndex++) 
			{
				oObject = m_oReturnArrayElement(lIndex);
				sPropertyValue = CallByName(oObject, sPropertyName);
				if (sPropertyValue == sKey | sPropertyValue == sIndex)
				{
					CallByName(oObject, sPropertyName, sNewValue);
				}
			}
		}

		public void m_CollectionChangeAll(String sPropertyName, String sNewValue)
		{
			int lIndex;
			Object oObject;
			for (lIndex = 1;lIndex <= m_lCount();lIndex++) 
			{
				oObject = m_oReturnArrayElement(lIndex);
				CallByName(oObject, sPropertyName, sNewValue);
			}
		}

        public string CallByName(object oObject, string sPropertyName)
        {
            System.Type oObjectType = oObject.GetType();
            System.Reflection.PropertyInfo oPropertyInfo = null;
            oPropertyInfo = oObjectType.GetProperty(sPropertyName);
            return (System.String)oPropertyInfo.GetValue(oObject, null);
        }

        public void CallByName(object oObject, string sPropertyName, string sNewValue)
        {
            System.Type oObjectType = oObject.GetType();
            System.Reflection.PropertyInfo oPropertyInfo = null;
            oPropertyInfo = oObjectType.GetProperty(sPropertyName);
            oPropertyInfo.SetValue(oObject, sNewValue, null);
        }

	}
}
