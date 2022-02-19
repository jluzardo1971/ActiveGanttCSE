using System;
using System.Collections.Generic;
using System.Text;

namespace MSP2007
{
    public class Duration
    {
        private int mp_lYear;
        private int mp_lMonth;
        private int mp_lDay;
        private int mp_lHour;
        private int mp_lMinute;
        private int mp_lSecond;

        public Duration()
        {
            mp_lYear = 0;
            mp_lMonth = 0;
            mp_lDay = 0;
            mp_lHour = 0;
            mp_lMinute = 0;
            mp_lSecond = 0;
        }

        public bool IsNull()
        {
            bool bReturn = true;
            if (mp_lYear != 0)
            {
                bReturn = false;
            }
            if (mp_lMonth != 0)
            {
                bReturn = false;
            }
            if (mp_lDay != 0)
            {
                bReturn = false;
            }
            if (mp_lHour != 0)
            {
                bReturn = false;
            }
            if (mp_lMinute != 0)
            {
                bReturn = false;
            }
            if (mp_lSecond != 0)
            {
                bReturn = false;
            }

            return bReturn;
        }

        public override string ToString()
        {
            string sReturn = "P";
            if (mp_lYear != 0)
            {
                sReturn = sReturn + mp_lYear.ToString() + "Y";
            }
            if (mp_lMonth != 0)
            {
                sReturn = sReturn + mp_lMonth.ToString() + "M";
            }
            if (mp_lDay != 0)
            {
                sReturn = sReturn + mp_lDay.ToString() + "D";
            }
            sReturn = sReturn + "T";
            sReturn = sReturn + mp_lHour.ToString() + "H";
            sReturn = sReturn + mp_lMinute.ToString() + "M";
            sReturn = sReturn + mp_lSecond.ToString() + "S";
            return sReturn;
        }

        public void FromString(string sString)
        {
            string sTime = null;
            string sDate = null;
            string sBuff = null;
            if (sString.StartsWith("P") == false | sString.Length == 0)
            {
                return;
            }
            if (sString.IndexOf("T") > -1)
            {
                sTime = sString.Substring(sString.IndexOf("T") + 1, sString.Length - sString.IndexOf("T") - 1);
                sDate = sString.Replace("T" + sTime, "");
            }
            else
            {
                sTime = "";
                sDate = sString;
            }
            sDate = sDate.Substring(1, sDate.Length - 1);
            if (sTime.Length > 0)
            {
                if (sTime.IndexOf("H") > -1)
                {
                    sBuff = sTime.Substring(0, sTime.IndexOf("H"));
                    sTime = sTime.Replace(sBuff + "H", "");
                    mp_lHour = System.Convert.ToInt16(sBuff);
                }
                if (sTime.IndexOf("M") > -1)
                {
                    sBuff = sTime.Substring(0, sTime.IndexOf("M"));
                    sTime = sTime.Replace(sBuff + "M", "");
                    mp_lMinute = System.Convert.ToInt16(sBuff);
                }
                if (sTime.IndexOf("S") > -1)
                {
                    sBuff = sTime.Substring(0, sTime.IndexOf("S"));
                    sTime = sTime.Replace(sBuff + "S", "");
                    mp_lSecond = System.Convert.ToInt16(sBuff);
                }
            }
            if (sDate.Length > 0)
            {
                if (sDate.IndexOf("Y") > -1)
                {
                    sBuff = sDate.Substring(0, sDate.IndexOf("Y"));
                    sDate = sDate.Replace(sBuff + "Y", "");
                    mp_lYear = System.Convert.ToInt16(sBuff);
                }
                if (sDate.IndexOf("M") > -1)
                {
                    sBuff = sDate.Substring(0, sDate.IndexOf("M"));
                    sDate = sDate.Replace(sBuff + "M", "");
                    mp_lMonth = System.Convert.ToInt16(sBuff);
                }
                if (sDate.IndexOf("D") > -1)
                {
                    sBuff = sDate.Substring(0, sDate.IndexOf("D"));
                    sDate = sDate.Replace(sBuff + "D", "");
                    mp_lDay = System.Convert.ToInt16(sBuff);
                }
            }
        }

        public int Year
        {
            get { return mp_lYear; }
            set { mp_lYear = value; }
        }

        public int Month
        {
            get { return mp_lMonth; }
            set { mp_lMonth = value; }
        }

        public int Day
        {
            get { return mp_lDay; }
            set { mp_lDay = value; }
        }

        public int Hour
        {
            get { return mp_lHour; }
            set { mp_lHour = value; }
        }

        public int Minute
        {
            get { return mp_lMinute; }
            set { mp_lMinute = value; }
        }

        public int Second
        {
            get { return mp_lSecond; }
            set { mp_lSecond = value; }
        }

    }
}
