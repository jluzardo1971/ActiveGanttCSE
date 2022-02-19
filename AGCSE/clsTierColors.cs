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

namespace AGCSE
{
	public class clsTierColors
	{

		private ActiveGanttCSECtl mp_oControl;
		private clsCollectionBase mp_oCollection;
		private E_TIERTYPE mp_yTierType;

		public clsTierColors(ActiveGanttCSECtl Value, E_TIERTYPE yTierType)
		{
			mp_oControl = Value;
			mp_oCollection = new clsCollectionBase(Value, "TierColor");
			mp_yTierType = yTierType;
		}

		~clsTierColors()
		{
			mp_oCollection = null;
			mp_oControl = null;
		}

		public int Count 
		{
			get 
			{
				return mp_oCollection.m_lCount();
			}
		}

		public clsTierColor Item(String Index)
		{
			return (clsTierColor) mp_oCollection.m_oItem(Index, SYS_ERRORS.TIERCOLORS_ITEM_1, SYS_ERRORS.TIERCOLORS_ITEM_2, SYS_ERRORS.TIERCOLORS_ITEM_3, SYS_ERRORS.TIERCOLORS_ITEM_4);
		}

		internal clsCollectionBase oCollection 
		{
			get 
			{
				return mp_oCollection;
			}
		}

        internal clsTierColor Add(Color BackColor, Color ForeColor, Color StartGradientColor, Color EndGradientColor, Color HatchBackColor, Color HatchForeColor, String Key)
		{
			mp_oCollection.AddMode = true;
			clsTierColor oTierColor = new clsTierColor(mp_oControl, this);
			oTierColor.BackColor = BackColor;
			oTierColor.ForeColor = ForeColor;
            oTierColor.StartGradientColor = StartGradientColor;
            oTierColor.EndGradientColor = EndGradientColor;
            oTierColor.HatchBackColor = HatchBackColor;
            oTierColor.HatchForeColor = HatchForeColor;
			oTierColor.Key = Key;
			mp_oCollection.m_Add(oTierColor, Key, SYS_ERRORS.TIERCOLORS_ADD_1, SYS_ERRORS.TIERCOLORS_ADD_2, false, SYS_ERRORS.TIERCOLORS_ADD_3);
			return oTierColor;
		}


        internal void Add(Color BackColor, Color ForeColor, Color StartGradientColor, Color EndGradientColor, Color HatchBackColor, Color HatchForeColor)
        {
            Add(BackColor, ForeColor, StartGradientColor, EndGradientColor, HatchBackColor, HatchForeColor, "");
        }

		private String mp_CollectionName()
		{
            if (mp_yTierType == E_TIERTYPE.ST_MICROSECOND)
            {
                return "MicrosecondColors";
            }
            else if (mp_yTierType == E_TIERTYPE.ST_MILLISECOND)
            {
                return "MillisecondColors";
            }
            else if (mp_yTierType == E_TIERTYPE.ST_SECOND)
            {
                return "SecondColors";
            }
            else if (mp_yTierType == E_TIERTYPE.ST_MINUTE)
			{
				return "MinuteColors";
			}
			else if (mp_yTierType == E_TIERTYPE.ST_HOUR)
			{
				return "HourColors";
			}
			else if (mp_yTierType == E_TIERTYPE.ST_DAY)
			{
				return "DayColors";
			}
			else if (mp_yTierType == E_TIERTYPE.ST_DAYOFWEEK)
			{
				return "DayOfWeekColors";
			}
			else if (mp_yTierType == E_TIERTYPE.ST_DAYOFYEAR)
			{
				return "DayOfYearColors";
			}
			else if (mp_yTierType == E_TIERTYPE.ST_WEEK)
			{
				return "WeekColors";
			}
			else if (mp_yTierType == E_TIERTYPE.ST_MONTH)
			{
				return "MonthColors";
			}
			else if (mp_yTierType == E_TIERTYPE.ST_QUARTER)
			{
				return "QuarterColors";
			}
			else if (mp_yTierType == E_TIERTYPE.ST_YEAR)
			{
				return "YearColors";
			}
			return "";
		}

        public String GetXML()
        {
            int lIndex;
            clsTierColor oTierColor;
            clsXML oXML = new clsXML(mp_oControl, mp_CollectionName());
            oXML.InitializeWriter();
            for (lIndex = 1; lIndex <= Count; lIndex++)
            {
                oTierColor = (clsTierColor)mp_oCollection.m_oReturnArrayElement(lIndex);
                oXML.WriteObject(oTierColor.GetXML());
            }
            return oXML.GetXML();
        }

        public void SetXML(String sXML)
        {
            int lIndex;
            clsXML oXML = new clsXML(mp_oControl, mp_CollectionName());
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            mp_oCollection.m_Clear();
            for (lIndex = 1; lIndex <= oXML.ReadCollectionCount(); lIndex++)
            {
                clsTierColor oTierColor = new clsTierColor(mp_oControl, this);
                oTierColor.SetXML(oXML.ReadCollectionObject(lIndex));
                mp_oCollection.AddMode = true;
                mp_oCollection.m_Add(oTierColor, oTierColor.Key, SYS_ERRORS.TIERCOLORS_ADD_1, SYS_ERRORS.TIERCOLORS_ADD_2, false, SYS_ERRORS.TIERCOLORS_ADD_3);
                oTierColor = null;
            }
        }



	}
}
