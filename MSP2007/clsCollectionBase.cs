using System;
using System.Collections;

namespace MSP2007
{
    internal class clsCollectionBase
    {
        private String m_sObjectName;
        internal ArrayList mp_aoCollection;
        private bool mp_bAddMode;
        private bool mp_bIgnoreKeyChecks;
        internal clsDictionary mp_oKeys;

        public clsCollectionBase(String sObjectName)
        {
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
            if (!Globals.g_StrIsNumeric(v_lIndex))
            {
                if (v_lIndex == "")
                {
                    Globals.g_ErrorReport(v_lErr1, "Invalid " + m_sObjectName + " object key, key cannot be an empty string", "ActiveGanttCSNCtl" + m_sObjectName + "s.Get m_oItem");
                    return null;
                }
                lIndex = m_lFindIndexByKey(v_lIndex);
                if (lIndex == -1)
                {
                    Globals.g_ErrorReport(v_lErr2, m_sObjectName + " object not found, invalid key (\"" + v_lIndex + "\")", "ActiveGanttCSNCtl" + m_sObjectName + "s.Get m_oItem");
                    return null;
                }
            }
            else
            {
                lIndex = System.Convert.ToInt32(v_lIndex);
                if (lIndex.ToString() != v_lIndex)
                {
                    Globals.g_ErrorReport(v_lErr3, m_sObjectName + " object not found, invalid v_lIndex", "ActiveGanttCSNCtl" + m_sObjectName + "s.Get m_oItem");
                    return null;
                }
                if (lIndex < 1 | lIndex > mp_aoCollection.Count)
                {
                    Globals.g_ErrorReport(v_lErr4, m_sObjectName + " object not found, v_lIndex out of bounds", "ActiveGanttCSNCtl" + m_sObjectName + "s.Get m_oItem");
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
            oItemBase = (clsItemBase)r_oObject;
            int lUpperBounds;
            if (mp_bAddMode == false)
            {
                Globals.g_ErrorReport(SYS_ERRORS.ERR_ADDMODE_G, "AddMode must be set to true before executing oCollection.m_Add", "cls" + m_sObjectName + "s");
            }
            if (Globals.g_StrIsNumeric(v_sKey))
            {
                Globals.g_ErrorReport(v_lErr1, "Invalid " + m_sObjectName + " object key, key cannot be numeric", "ActiveGanttCSNCtl.cls" + m_sObjectName + "s.Add");
                return;
            }
            if (v_sKey != "")
            {
                if (m_bIsKeyUnique(v_sKey) == false)
                {
                    Globals.g_ErrorReport(v_lErr2, "Key is not unique in " + m_sObjectName + "s collection", "ActiveGanttCSNCtl.cls" + m_sObjectName + "s.Add");
                    return;
                }
            }
            lUpperBounds = mp_aoCollection.Count + 1;
            oItemBase.Index = lUpperBounds;
            mp_aoCollection.Add(r_oObject);
            if (v_sKey != "")
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
            if (!Globals.g_StrIsNumeric(v_sIndex))
            {
                if (v_sIndex == "")
                {
                    Globals.g_ErrorReport(v_lErr1, "Invalid " + m_sObjectName + " object key, key cannot be an empty string", "ActiveGanttCSNCtl" + m_sObjectName + "s.Remove");
                    return;
                }
                lIndex = m_lFindIndexByKey(v_sIndex);
                if (lIndex == -1)
                {
                    Globals.g_ErrorReport(v_lErr2, m_sObjectName + " object not found, invalid key (\"" + v_sIndex + "\")", "ActiveGanttCSNCtl" + m_sObjectName + "s.Remove");
                    return;
                }
                lRemovedIndex = lIndex;
            }
            else
            {
                lIndex = System.Convert.ToInt32(v_sIndex);
                if (lIndex.ToString() != v_sIndex)
                {
                    Globals.g_ErrorReport(v_lErr3, m_sObjectName + " object not found, invalid v_sIndex", "ActiveGanttCSNCtl" + m_sObjectName + "s.Remove");
                    return;
                }
                if (lIndex < 1 | lIndex > mp_aoCollection.Count)
                {
                    Globals.g_ErrorReport(v_lErr4, m_sObjectName + " object not found, v_sIndex out of bounds", "ActiveGanttCSNCtl" + m_sObjectName + "s.Remove");
                    return;
                }
                clsItemBase oItemBase;
                oItemBase = (clsItemBase)mp_aoCollection[lIndex - 1];
                lRemovedIndex = lIndex;
            }
            mp_bIgnoreKeyChecks = true;
            mp_aoCollection.RemoveAt(lRemovedIndex - 1);
            mp_bIgnoreKeyChecks = false;
            m_ReconstKeys();
        }

        public void m_ReconstKeys()
        {
            int lIndex;
            int lCount;
            String sKey;
            mp_oKeys = null;
            mp_oKeys = new clsDictionary();
            lCount = mp_aoCollection.Count;
            for (lIndex = 1; lIndex <= lCount; lIndex++)
            {
                clsItemBase oItemBase;
                oItemBase = (clsItemBase)mp_aoCollection[lIndex - 1];
                sKey = oItemBase.mp_sKey;
                oItemBase.Index = lIndex;
                if (sKey != "")
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

        public Object m_oReturnArrayElement(int r_lIndex)
        {
            System.Diagnostics.Debug.Assert(r_lIndex >= 1 & r_lIndex <= mp_aoCollection.Count);
            return mp_aoCollection[r_lIndex - 1];
        }

        public void mp_SetKey(ref String sCurrentKey, String sNewKey, SYS_ERRORS ErrNumber)
        {
            if (m_bIgnoreKeyChecks == false)
            {
                if (Globals.g_StrIsNumeric(sNewKey) | (sNewKey != sCurrentKey & m_bIsKeyUnique(sNewKey) == false))
                {
                    Globals.g_ErrorReport(ErrNumber, "Numeric or duplicate " + m_sObjectName + " object key", "ActiveGanttCSNCtl" + m_sObjectName + ".Let Key");
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

    }
}
