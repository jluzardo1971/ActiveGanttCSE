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
	public class clsView : clsItemBase
	{
		private ActiveGanttCSECtl mp_oControl;
		private clsTimeLine mp_oTimeLine;
		private clsClientArea mp_oClientArea;
		private String mp_sTag;
        private E_INTERVAL mp_yScrollInterval;
        private E_INTERVAL mp_yInterval;
		private int mp_lFactor;

		public clsView(ActiveGanttCSECtl Value)
		{
            mp_oControl = Value;
            mp_yInterval = E_INTERVAL.IL_MINUTE;
            mp_lFactor = 1;
            mp_yScrollInterval = E_INTERVAL.IL_HOUR;
            mp_oTimeLine = new clsTimeLine(mp_oControl, this);
            mp_oClientArea = new clsClientArea(mp_oControl, mp_oTimeLine);
            mp_sTag = "";
		}

		~clsView()
		{	
		}

		public String Key 
		{
			get 
			{
				return mp_sKey;
			}
			set 
			{
				mp_oControl.Views.oCollection.mp_SetKey(ref mp_sKey, value, SYS_ERRORS.VIEWS_SET_KEY);
			}
		}

		public clsTimeLine TimeLine 
		{
			get 
			{
				return mp_oTimeLine;
			}
		}

		public clsClientArea ClientArea 
		{
			get 
			{
				return mp_oClientArea;
			}
		}

		public String Tag 
		{
			get 
			{
				return mp_sTag;
			}
			set 
			{
				mp_sTag = value;
			}
		}

        internal E_INTERVAL f_ScrollInterval
        {
            get
            {
                return mp_yScrollInterval;
            }
        }

        public E_INTERVAL Interval
        {
            get
            {
                return mp_yInterval;
            }
            set
            {
                mp_yInterval = value;
                if (mp_yInterval == E_INTERVAL.IL_YEAR)
                {
                    mp_yScrollInterval = E_INTERVAL.IL_YEAR;
                }
                else
                {
                    mp_yScrollInterval = mp_yInterval + 1;
                }
            }
        }

        public int Factor
        {
            get
            {
                return mp_lFactor;
            }
            set
            {
                mp_lFactor = value;
            }
        }

        public String GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "View");
            oXML.InitializeWriter();
            oXML.WriteProperty("Interval", mp_yInterval);
            oXML.WriteProperty("Factor", mp_lFactor);
            oXML.WriteProperty("Key", mp_sKey);
            oXML.WriteProperty("Tag", mp_sTag);
            oXML.WriteObject(mp_oClientArea.GetXML());
            oXML.WriteObject(mp_oTimeLine.GetXML());
            return oXML.GetXML();
        }

        public void SetXML(String sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "View");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            oXML.ReadProperty("Tag", ref mp_sTag);
            oXML.ReadProperty("Interval", ref mp_yInterval);
            oXML.ReadProperty("Factor", ref mp_lFactor);
            mp_oClientArea.SetXML(oXML.ReadObject("ClientArea"));
            mp_oTimeLine.SetXML(oXML.ReadObject("TimeLine"));
        }

	}
}
