using System;
using System.Collections.Generic;
using System.Text;

namespace MSP2007
{
    public class Time
    {
        private byte mp_yHour;
        private byte mp_yMinute;
        private byte mp_ySecond;

        public Time()
        {
            mp_yHour = 0;
            mp_yMinute = 0;
            mp_ySecond = 0;
        }

        public override string ToString()
        {
            return mp_yHour.ToString("00") + ":" + mp_yMinute.ToString("00") + ":" + mp_ySecond.ToString("00");
        }

        public void FromString(string sString)
        {
            mp_yHour = System.Convert.ToByte(sString.Substring(0, 2));
            mp_yMinute = System.Convert.ToByte(sString.Substring(3, 2));
            mp_ySecond = System.Convert.ToByte(sString.Substring(6, 2));
        }

        public byte Hour
        {
            get { return mp_yHour; }
            set { mp_yHour = value; }
        }

        public byte Minute
        {
            get { return mp_yMinute; }
            set { mp_yMinute = value; }
        }

        public byte Second
        {
            get { return mp_ySecond; }
            set { mp_ySecond = value; }
        }

        public System.DateTime ToDateTime()
        {
            System.DateTime dtReturn = new System.DateTime(0, 0, 0, mp_yHour, mp_yMinute, mp_ySecond);
            return dtReturn;
        }

        public void FromDateTime(System.DateTime dtDate)
        {
            mp_yHour = System.Convert.ToByte(dtDate.Hour);
            mp_yMinute = System.Convert.ToByte(dtDate.Minute);
            mp_ySecond = System.Convert.ToByte(dtDate.Second);
        }

        public bool IsNull()
        {
            bool bReturn = true;
            if (mp_yHour != 0)
            {
                bReturn = false;
            }
            if (mp_yMinute != 0)
            {
                bReturn = false;
            }
            if (mp_ySecond != 0)
            {
                bReturn = false;
            }
            return bReturn;
        }
    }
}
