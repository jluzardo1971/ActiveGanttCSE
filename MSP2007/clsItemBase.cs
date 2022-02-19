using System;

namespace MSP2007
{
    public abstract class clsItemBase
    {
        public String mp_sKey;
        public int mp_lIndex;

        public clsItemBase()
        {
            mp_sKey = "";
            mp_lIndex = 0;
        }

        public int Index
        {
            get
            {
                return mp_lIndex;
            }
            set
            {
                mp_lIndex = value;
            }
        }
    }
}
