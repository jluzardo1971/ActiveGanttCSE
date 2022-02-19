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


	public class clsHorizontalScrollBar
	{
		private ActiveGanttCSECtl mp_oControl;
		private bool mp_bVisible;
		public clsHScrollBarTemplate ScrollBar;

		public clsHorizontalScrollBar(ActiveGanttCSECtl Value)
		{
			mp_oControl = Value;
			mp_bVisible = true;
			ScrollBar = new clsHScrollBarTemplate();
			ScrollBar.Initialize(mp_oControl);
			ScrollBar.LargeChange = 1;
			ScrollBar.SmallChange = 1;
			ScrollBar.Min = 0;
			ScrollBar.Max = 0;
			ScrollBar.Value = 0;
			this.ScrollBar.ValueChanged += new clsHScrollBarTemplate.ValueChangedEventHandler(this.oHScrollBar_ValueChanged);
		}

		public int Min 
		{
			get 
			{
				return 0;
			}
		}

		public int Max 
		{
			get 
			{
				return ScrollBar.Max;
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
				ScrollBar.Value = value;
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

		internal void Update()
		{

		}

		internal void Reset()
		{
			ScrollBar.Min = 0;
			ScrollBar.Max = 0;
			ScrollBar.Value = 0;
		}

		internal void Position()
		{
			Left = mp_oControl.mt_BorderThickness;
			Top = mp_oControl.clsG.Height - Height - mp_oControl.mt_BorderThickness;
			if (mp_oControl.Splitter.Left > 0)
			{
				Width = mp_oControl.Splitter.Left;
			}
			ScrollBar.Max = mp_oControl.Columns.Width - mp_oControl.Splitter.Position;
		}

		private void oHScrollBar_ValueChanged(Object sender, System.EventArgs e, int Offset)
		{
			mp_oControl.HorizontalScrollBar_ValueChanged(Offset);
		}

        public string GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "HorizontalScrollBar");
            oXML.InitializeWriter();
            oXML.WriteObject(ScrollBar.GetXML());
            return oXML.GetXML();
        }

        public void SetXML(string sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "HorizontalScrollBar");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            ScrollBar.SetXML(oXML.ReadObject("ScrollBar"));
        }


	}
}
