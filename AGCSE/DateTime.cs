using System;
using System.Collections.Generic;
using System.Text;

namespace AGCSE
{
    public class DateTime
    {

        private System.DateTime mp_dtDateTime;
        private int mp_lSecondFraction;

        public DateTime()
        {
            mp_dtDateTime = new System.DateTime(0);
            mp_lSecondFraction = 0;
        }

        public DateTime(int Year, int Month, int Day)
        {
            Initialize(Year, Month, Day, 0, 0, 0, 0, 0, 0);
        }

        public DateTime(int Year, int Month, int Day, int Hour, int Minute, int Second)
        {
            Initialize(Year, Month, Day, Hour, Minute, Second, 0, 0, 0);
        }

        public DateTime(int Year, int Month, int Day, int Hour, int Minute, int Second, int Millisecond, int Microsecond, int Nanosecond)
        {
            Initialize(Year, Month, Day, Hour, Minute, Second, Millisecond, Microsecond, Nanosecond);
        }

        public static AGCSE.DateTime Now
        {
            get
            {
                AGCSE.DateTime dtResult = new AGCSE.DateTime();
                dtResult.SetToCurrentDateTime();
                return dtResult;
            }
        }

        public void Initialize(int Year, int Month, int Day, int Hour, int Minute, int Second, int Millisecond, int Microsecond, int Nanosecond)
        {
            if (Year < 1)
            {
                mp_dtDateTime = new System.DateTime(0);
                mp_lSecondFraction = 0;
                return;
            }
            else if (Year > 9999)
            {
                mp_dtDateTime = new System.DateTime(0);
                mp_lSecondFraction = 0;
                return;
            }
            else if (Month < 1)
            {
                mp_dtDateTime = new System.DateTime(0);
                mp_lSecondFraction = 0;
                return;
            }
            else if (Month > 12)
            {
                mp_dtDateTime = new System.DateTime(0);
                mp_lSecondFraction = 0;
                return;
            }
            else if (Day < 1)
            {
                mp_dtDateTime = new System.DateTime(0);
                mp_lSecondFraction = 0;
                return;
            }
            else if (Day > 31)
            {
                mp_dtDateTime = new System.DateTime(0);
                mp_lSecondFraction = 0;
                return;
            }
            else if (Hour < 0)
            {
                mp_dtDateTime = new System.DateTime(0);
                mp_lSecondFraction = 0;
                return;
            }
            else if (Hour > 23)
            {
                mp_dtDateTime = new System.DateTime(0);
                mp_lSecondFraction = 0;
                return;
            }
            else if (Minute < 0)
            {
                mp_dtDateTime = new System.DateTime(0);
                mp_lSecondFraction = 0;
                return;
            }
            else if (Minute > 59)
            {
                mp_dtDateTime = new System.DateTime(0);
                mp_lSecondFraction = 0;
                return;
            }
            else if (Second < 0)
            {
                mp_dtDateTime = new System.DateTime(0);
                mp_lSecondFraction = 0;
                return;
            }
            else if (Second > 59)
            {
                mp_dtDateTime = new System.DateTime(0);
                mp_lSecondFraction = 0;
                return;
            }
            else if (Millisecond < 0)
            {
                mp_dtDateTime = new System.DateTime(0);
                mp_lSecondFraction = 0;
                return;
            }
            else if (Millisecond > 999)
            {
                mp_dtDateTime = new System.DateTime(0);
                mp_lSecondFraction = 0;
                return;
            }
            else if (Microsecond < 0)
            {
                mp_dtDateTime = new System.DateTime(0);
                mp_lSecondFraction = 0;
                return;
            }
            else if (Microsecond > 999)
            {
                mp_dtDateTime = new System.DateTime(0);
                mp_lSecondFraction = 0;
                return;
            }
            else if (Nanosecond < 0)
            {
                mp_dtDateTime = new System.DateTime(0);
                mp_lSecondFraction = 0;
                return;
            }
            else if (Nanosecond > 999)
            {
                mp_dtDateTime = new System.DateTime(0);
                mp_lSecondFraction = 0;
                return;
            }
            mp_dtDateTime = new System.DateTime(Year, Month, Day, Hour, Minute, Second, Millisecond);
            mp_lSecondFraction = (Millisecond * 1000000) + (Microsecond * 1000) + Nanosecond;
        }

        public void SetDateTime(int Year, int Month, int Day, int Hour, int Minute, int Second)
        {
            Initialize(Year, Month, Day, Hour, Minute, Second, 0, 0, 0);
        }

        public void SetDate(int Year, int Month, int Day)
        {
            Initialize(Year, Month, Day, 0, 0, 0, 0, 0, 0);
        }

        public void SetTime(int Hour, int Minute, int Second)
        {
            Initialize(1, 1, 1, Hour, Minute, Second, 0, 0, 0);
        }

        public void SetSecondFraction(int Millisecond, int Microsecond, int Nanosecond)
        {
            Initialize(1, 1, 1, 0, 0, 0, Millisecond, Microsecond, Nanosecond);
        }

        public int Nanosecond()
        {
            int lDateTime = mp_lSecondFraction;
            int lMillisecond = Millisecond();
            int lMicrosecond = Microsecond();
            lDateTime = lDateTime - (lMillisecond * 1000000);
            lDateTime = lDateTime - (lMicrosecond * 1000);
            return lDateTime;
        }

        public int Microsecond()
        {
            int lDateTime = mp_lSecondFraction;
            int lMillisecond = Millisecond();
            lDateTime = lDateTime - (lMillisecond * 1000000);
            return (int)System.Math.Floor((double)lDateTime / (double)1000);
        }

        public int Millisecond()
        {
            return (int)System.Math.Floor((double)mp_lSecondFraction / (double)1000000);
        }

        public int Second()
        {
            return mp_dtDateTime.Second;
        }

        public int Minute()
        {
            return mp_dtDateTime.Minute;
        }

        public int Hour()
        {
            return mp_dtDateTime.Hour;
        }

        public int Day()
        {
            return mp_dtDateTime.Day;
        }

        public int DayOfWeek()
        {
            return (int)mp_dtDateTime.DayOfWeek + 1;
        }

        public int DayOfYear()
        {
            return mp_dtDateTime.DayOfYear;
        }

        public int Week()
        {
            int lWeekDay = 0;
            int lDayOfYear = 0;
            lWeekDay = (int)mp_dtDateTime.DayOfWeek;
            lDayOfYear = mp_dtDateTime.DayOfYear;
            return (int)(System.Math.Floor((double)lDayOfYear - (double)lWeekDay) / 7) + 1;
        }

        public int Month()
        {
            return mp_dtDateTime.Month;
        }

        public int Quarter()
        {
            switch (mp_dtDateTime.Month)
            {
                case 1:
                case 2:
                case 3:
                    {
                        return 1;
                    }
                case 4:
                case 5:
                case 6:
                    {
                        return 2;
                    }
                case 7:
                case 8:
                case 9:
                    {
                        return 3;
                    }
                case 10:
                case 11:
                case 12:
                    {
                        return 4;
                    }

            }
            return -1;
        }

        public int Year()
        {
            return mp_dtDateTime.Year;
        }

        public void SetToCurrentDateTime()
        {
            mp_dtDateTime = System.DateTime.Now;
            mp_lSecondFraction = (mp_dtDateTime.Millisecond * 1000000);
        }

        public static bool operator ==(AGCSE.DateTime DateTime1, AGCSE.DateTime DateTime2)
        {
            if (((object)DateTime1 == null) & ((object)DateTime2 == null))
            {
                return true;
            }
            if (((object)DateTime1 == null) | ((object)DateTime2 == null))
            {
                return false;
            }
            if (((DateTime1.mp_dtDateTime == DateTime2.mp_dtDateTime) & (DateTime1.mp_lSecondFraction == DateTime2.mp_lSecondFraction)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null | (!object.ReferenceEquals(this.GetType(), obj.GetType())))
            {
                return false;
            }
            AGCSE.DateTime DateTime2 = (AGCSE.DateTime)obj;
            if (((mp_dtDateTime == DateTime2.mp_dtDateTime) & (mp_lSecondFraction == DateTime2.mp_lSecondFraction)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Equals(AGCSE.DateTime DateTime2)
        {
            if ((object)DateTime2 == null)
            {
                return false;
            }
            if (((mp_dtDateTime == DateTime2.mp_dtDateTime) & (mp_lSecondFraction == DateTime2.mp_lSecondFraction)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return mp_dtDateTime.GetHashCode() ^ mp_lSecondFraction;
        }

        public static bool operator !=(AGCSE.DateTime DateTime1, AGCSE.DateTime DateTime2)
        {
            if (((object)DateTime1 == null) & ((object)DateTime2 == null))
            {
                return false;
            }
            if (((object)DateTime1 == null) | ((object)DateTime2 == null))
            {
                return true;
            }
            if (((DateTime1.mp_dtDateTime == DateTime2.mp_dtDateTime) & (DateTime1.mp_lSecondFraction == DateTime2.mp_lSecondFraction)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool operator <=(AGCSE.DateTime DateTime1, AGCSE.DateTime DateTime2)
        {
            if (((DateTime1.mp_dtDateTime == DateTime2.mp_dtDateTime) & (DateTime1.mp_lSecondFraction == DateTime2.mp_lSecondFraction)))
            {
                return true;
            }
            if ((DateTime1.mp_dtDateTime < DateTime2.mp_dtDateTime))
            {
                return true;
            }
            if (((DateTime1.mp_dtDateTime == DateTime2.mp_dtDateTime) & (DateTime1.mp_lSecondFraction < DateTime2.mp_lSecondFraction)))
            {
                return true;
            }
            return false;
        }

        public static bool operator >=(AGCSE.DateTime DateTime1, AGCSE.DateTime DateTime2)
        {
            if (((DateTime1.mp_dtDateTime == DateTime2.mp_dtDateTime) & (DateTime1.mp_lSecondFraction == DateTime2.mp_lSecondFraction)))
            {
                return true;
            }
            if ((DateTime1.mp_dtDateTime > DateTime2.mp_dtDateTime))
            {
                return true;
            }
            if (((DateTime1.mp_dtDateTime == DateTime2.mp_dtDateTime) & (DateTime1.mp_lSecondFraction > DateTime2.mp_lSecondFraction)))
            {
                return true;
            }
            return false;
        }

        public static bool operator <(AGCSE.DateTime DateTime1, AGCSE.DateTime DateTime2)
        {
            if ((DateTime1.mp_dtDateTime < DateTime2.mp_dtDateTime))
            {
                return true;
            }
            if (((DateTime1.mp_dtDateTime == DateTime2.mp_dtDateTime) & (DateTime1.mp_lSecondFraction < DateTime2.mp_lSecondFraction)))
            {
                return true;
            }
            return false;
        }

        public static bool operator >(AGCSE.DateTime DateTime1, AGCSE.DateTime DateTime2)
        {
            if ((DateTime1.mp_dtDateTime > DateTime2.mp_dtDateTime))
            {
                return true;
            }
            if (((DateTime1.mp_dtDateTime == DateTime2.mp_dtDateTime) & (DateTime1.mp_lSecondFraction > DateTime2.mp_lSecondFraction)))
            {
                return true;
            }
            return false;
        }

        public void Clear()
        {
            mp_dtDateTime = new System.DateTime(0);
            mp_lSecondFraction = 0;
        }

        public System.DateTime DateTimePart
        {
            get { return mp_dtDateTime; }
            set
            {
                mp_dtDateTime = value;
                if ((mp_dtDateTime.Millisecond != 0))
                {
                    mp_lSecondFraction = (mp_dtDateTime.Millisecond * 1000000);
                }
            }
        }

        public int SecondFractionPart
        {
            get { return mp_lSecondFraction; }
            set
            {
                mp_lSecondFraction = value;
                mp_dtDateTime = new System.DateTime(mp_dtDateTime.Year, mp_dtDateTime.Month, mp_dtDateTime.Day, mp_dtDateTime.Hour, mp_dtDateTime.Minute, mp_dtDateTime.Second, Millisecond());
            }
        }

        public string ToString(string Format)
        {
            return ToString(Format, System.Globalization.CultureInfo.InvariantCulture);
        }

        public string ToString(string Format, System.IFormatProvider provider)
        {
            string sReturn = "";
            int i = 0;
            if (Format.Length == 0)
            {
                return mp_dtDateTime.ToString(Format);
            }
            for (i = 9; i >= 1; i += -1)
            {
                Format = GetSecondFractionFormat(i, false, Format);
            }
            for (i = 9; i >= 1; i += -1)
            {
                Format = GetSecondFractionFormat(i, true, Format);
            }
            if (IsNumeric(Format))
            {
                sReturn = Format;
            }
            else
            {
                sReturn = mp_dtDateTime.ToString(Format, provider);
            }
            return sReturn;
        }

        private string GetSecondFractionFormat(int lDigits, bool bCapital, string Format)
        {
            string sReturn = "";
            string sBuff = "";
            string sFormatSpec = "";
            if (bCapital == false)
            {
                while (sFormatSpec.Length < lDigits)
                {
                    sFormatSpec = sFormatSpec + "f";
                }
                if (Format.Contains(sFormatSpec) == false)
                {
                    return Format;
                }
                sBuff = mp_lSecondFraction.ToString();
                while (sBuff.Length < 9)
                {
                    sBuff = "0" + sBuff;
                }
                sBuff = sBuff.Substring(0, lDigits);
                sReturn = sBuff;
            }
            else
            {
                while (sFormatSpec.Length < lDigits)
                {
                    sFormatSpec = sFormatSpec + "F";
                }
                if (Format.Contains(sFormatSpec) == false)
                {
                    return Format;
                }
                sBuff = mp_lSecondFraction.ToString();
                while (sBuff.Length < 9)
                {
                    sBuff = "0" + sBuff;
                }
                sBuff = sBuff.Substring(0, lDigits);
                int i = System.Convert.ToInt32(sBuff);
                if (i > 0)
                {
                    sReturn = sBuff;
                }
                else
                {
                    sReturn = "";
                }
            }
            sReturn = Format.Replace(sFormatSpec, sReturn);
            return sReturn;
        }

        private bool IsNumeric(string Expression)
        {
            double dDummy = 0;
            return double.TryParse(Expression, out dDummy);
        }

    }
}
