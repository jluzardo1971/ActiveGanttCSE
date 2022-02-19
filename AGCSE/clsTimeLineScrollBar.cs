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
	public class clsTimeLineScrollBar
	{
		private ActiveGanttCSECtl mp_oControl;
		private AGCSE.DateTime mp_dtStartDate;
        private E_INTERVAL mp_yInterval;
		private int mp_lFactor;
		private bool mp_bVisible;

		public clsHScrollBarTemplate ScrollBar;

		public clsTimeLineScrollBar(ActiveGanttCSECtl Value)
		{
			mp_oControl = Value;
			ScrollBar = new clsHScrollBarTemplate();
			ScrollBar.Initialize(mp_oControl);
			ScrollBar.Min = 0;
            mp_dtStartDate = new AGCSE.DateTime();
            mp_dtStartDate.SetToCurrentDateTime();
            mp_yInterval = E_INTERVAL.IL_MINUTE;
            mp_lFactor = 1;
			ScrollBar.Enabled = false;
			mp_bVisible = false;
			ScrollBar.ValueChanged += new clsHScrollBarTemplate.ValueChangedEventHandler(this.oHScrollBar_ValueChanged);
		}

		~clsTimeLineScrollBar()
		{
			mp_oControl = null;
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

		public int Value 
		{
			get 
			{
				return ScrollBar.Value;
			}
			set 
			{
				if (value < 0)
				{
					value = 0;
				}
				if (value > ScrollBar.Max)
				{
					value = ScrollBar.Max;
				}
				ScrollBar.Value = value;
			}
		}

		public bool Enabled 
		{
			get 
			{
				return ScrollBar.Enabled;
			}
			set 
			{
				ScrollBar.Enabled = value;
			}
		}

        internal bool mf_Visible
        {
            get
            {
                return mp_bVisible;
            }
        }

		public bool Visible 
		{
			get 
			{
                if (ScrollBar.State != E_SCROLLSTATE.SS_SHOWN)
                {
                    return false;
                }
                else
                {
                    return mp_bVisible;
                }
			}
			set 
			{
				mp_bVisible = value;
			}
		}

		public int LargeChange 
		{
			get 
			{
				return ScrollBar.LargeChange;
			}
			set 
			{
				ScrollBar.LargeChange = value;
			}
		}

		public int Max 
		{
			get 
			{
				return ScrollBar.Max;
			}
			set 
			{
				ScrollBar.Max = value;
			}
		}

		public int SmallChange 
		{
			get 
			{
				return ScrollBar.SmallChange;
			}
			set 
			{
				ScrollBar.SmallChange = value;
			}
		}

		public DateTime StartDate 
		{
			get 
			{
				return mp_dtStartDate;
			}
			set 
			{
				mp_dtStartDate = value;
			}
		}

		internal E_SCROLLSTATE State 
		{
			get 
			{
				return ScrollBar.State;
			}
			set 
			{
				ScrollBar.State = value;
			}
		}

		internal int Width 
		{
			get 
			{
				return ScrollBar.Width;
			}
			set 
			{
				ScrollBar.Width = value;
			}
		}

		internal int Height 
		{
			get 
			{
				return ScrollBar.Height;
			}
			set 
			{
				ScrollBar.Height = value;
			}
		}

		internal int Left 
		{
			get 
			{
				return ScrollBar.Left;
			}
			set 
			{
				ScrollBar.Left = value;
			}
		}

		internal int Top 
		{
			get 
			{
				return ScrollBar.Top;
			}
			set 
			{
				ScrollBar.Top = value;
			}
		}

        public String GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "TimeLineScrollBar");
            oXML.InitializeWriter();
            oXML.WriteProperty("Enabled", ScrollBar.mp_bEnabled);
            oXML.WriteProperty("Interval", mp_yInterval);
            oXML.WriteProperty("Factor", mp_lFactor);
            oXML.WriteProperty("LargeChange", ScrollBar.mp_lLargeChange);
            oXML.WriteProperty("Max", ScrollBar.mp_lMax);
            oXML.WriteProperty("SmallChange", ScrollBar.mp_lSmallChange);
            oXML.WriteProperty("StartDate", mp_dtStartDate);
            oXML.WriteProperty("Value", ScrollBar.mp_lValue);
            oXML.WriteProperty("Visible", mp_bVisible);
            oXML.WriteObject(ScrollBar.GetXML());
            return oXML.GetXML();
        }

        public void SetXML(String sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "TimeLineScrollBar");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            oXML.ReadProperty("Enabled", ref ScrollBar.mp_bEnabled);
            oXML.ReadProperty("Interval", ref mp_yInterval);
            oXML.ReadProperty("Factor", ref mp_lFactor);
            oXML.ReadProperty("LargeChange", ref ScrollBar.mp_lLargeChange);
            oXML.ReadProperty("Max", ref ScrollBar.mp_lMax);
            oXML.ReadProperty("SmallChange", ref ScrollBar.mp_lSmallChange);
            oXML.ReadProperty("StartDate", ref mp_dtStartDate);
            oXML.ReadProperty("Value", ref ScrollBar.mp_lValue);
            oXML.ReadProperty("Visible", ref mp_bVisible);
            ScrollBar.SetXML(oXML.ReadObject("ScrollBar"));
        }

		private void oHScrollBar_ValueChanged(Object sender, System.EventArgs e, int Offset)
		{
			mp_oControl.TimeLineScrollBar_ValueChanged(Offset);
		}

		internal void Position()
		{
			Left = mp_oControl.Splitter.Right;
			Top = mp_oControl.clsG.Height - Height - mp_oControl.mt_BorderThickness;
			Width = mp_oControl.clsG.Width - mp_oControl.mt_BorderThickness - mp_oControl.Splitter.Right - mp_oControl.VerticalScrollBar.Width;
		}

	}
}
