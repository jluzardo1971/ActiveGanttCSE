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
	public class clsVerticalScrollBar
	{
		private ActiveGanttCSECtl mp_oControl;
		private bool mp_bVisible;
		public clsVScrollBarTemplate ScrollBar;

		public clsVerticalScrollBar(ActiveGanttCSECtl Value)
		{
			mp_oControl = Value;
			mp_bVisible = true;
			ScrollBar = new clsVScrollBarTemplate();
			ScrollBar.Initialize(mp_oControl);
			ScrollBar.LargeChange = 1;
			ScrollBar.SmallChange = 1;
			ScrollBar.Min = 1;
			ScrollBar.Max = 1;
			ScrollBar.Value = 1;
			this.ScrollBar.ValueChanged += new clsVScrollBarTemplate.ValueChangedEventHandler(this.oVScrollBar_ValueChanged);
		}

		public int Min 
		{
			get 
			{
				if (mp_oControl.Rows.Count == 0)
				{
					return 0;
				}
				else
				{
					return ScrollBar.Min;
				}
			}
		}

		public int Max 
		{
			get 
			{
				if (mp_oControl.Rows.Count == 0)
				{
					return 0;
				}
				else
				{
                    ScrollBar.Max = mp_oControl.Rows.Count - mp_oControl.Rows.HiddenRows();
                    return mp_oControl.Rows.Count - mp_oControl.Rows.HiddenRows();
				}
			}
		}

		public int Value 
		{
			get 
			{
				if (mp_oControl.Rows.Count == 0)
				{
					return 0;
				}
				else
				{
					return ScrollBar.Value;
				}
			}
			set 
			{
				if (mp_oControl.Rows.Count > 0)
				{
					if (value < 1)
					{
						value = 1;
					}
					if (value > mp_oControl.Rows.Count)
					{
						value = mp_oControl.Rows.Count;
					}
					ScrollBar.Value = value;
				}
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
            int lHiddenRows = mp_oControl.Rows.HiddenRows();
            if (mp_oControl.Rows.Count > 0)
            {
                if (ScrollBar.Value > (mp_oControl.Rows.Count - lHiddenRows))
                {
                    ScrollBar.Value = (mp_oControl.Rows.Count - lHiddenRows);
                }
                ScrollBar.Max = mp_oControl.Rows.Count - lHiddenRows;
            }
            else
            {
                Reset();
            }
		}

		internal void Reset()
		{
			ScrollBar.Min = 1;
			ScrollBar.Max = 1;
			ScrollBar.Value = 1;
		}

		internal void Position()
		{
			Left = mp_oControl.clsG.Width - Width - mp_oControl.mt_BorderThickness;
			Top = mp_oControl.mt_TopMargin;
			Height = mp_oControl.clsG.Height - (mp_oControl.mt_BorderThickness * 2) - mp_oControl.HorizontalScrollBar.Height;
			SmallChange = 1;
		}

		private void oVScrollBar_ValueChanged(Object sender, System.EventArgs e, int Offset)
		{
			mp_oControl.VerticalScrollBar_ValueChanged(Offset);
		}

        public string GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "VerticalScrollBar");
            oXML.InitializeWriter();
            oXML.WriteObject(ScrollBar.GetXML());
            return oXML.GetXML();
        }

        public void SetXML(string sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "VerticalScrollBar");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            ScrollBar.SetXML(oXML.ReadObject("ScrollBar"));
        }


	}
}
