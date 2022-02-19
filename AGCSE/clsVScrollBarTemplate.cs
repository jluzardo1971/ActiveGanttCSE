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
using System.Windows.Threading;

namespace AGCSE
{

	public class clsVScrollBarTemplate
	{

		private enum E_BUTTON
		{
			BTN_NONE = 0,
			BTN_UP = 1,
			BTN_DOWN = 2,
			BTN_UPLCHANGE = 3,
			BTN_DOWNLCHANGE = 4,
			BTN_BUTTON = 5,
		}

		private ActiveGanttCSECtl mp_oControl;
		internal int mp_lSmallChange = 1;
		internal int mp_lLargeChange;
		internal int mp_lValue;
		internal int mp_lMin;
		internal int mp_lMax;
		private int ButtonX1;
		private int ButtonX2;
		private int ButtonY1;
		private int ButtonY2;
		private bool Visible;
		internal bool mp_bEnabled;
		internal int Height;
		internal int Width;
		internal int Top;
		internal int Left;
		private bool mp_bMouseDown;
		private int mp_iMouseYPosition;
		private E_BUTTON mp_iButton;
		private int mp_iTimerInterval;
		private E_SCROLLSTATE mp_yState;
		private int mp_lValueBuff;
        private DispatcherTimer mp_oTimer = new DispatcherTimer();
        private string mp_sStyleIndex;
        private clsStyle mp_oStyle;
        public clsButtonState ArrowButtons;
        public clsButtonState ThumbButton;

        internal event ValueChangedEventHandler ValueChanged;
        internal delegate void ValueChangedEventHandler(Object sender, System.EventArgs e, int Offset);



		public clsVScrollBarTemplate()
		{

		}

		internal void Initialize(ActiveGanttCSECtl oControl)
		{
			mp_oControl = oControl;
            ArrowButtons = new clsButtonState(oControl, "Arrow");
            ThumbButton = new clsButtonState(oControl, "Thumb");
			mp_lValueBuff = Value;
			Width = 17;
			mp_iButton = E_BUTTON.BTN_NONE;
			mp_iTimerInterval = 100;
			mp_lValueBuff = Value;
            mp_oTimer.Tick += new EventHandler(mp_oTimer_Tick);
            mp_sStyleIndex = "DS_SCROLLBAR";
            mp_oStyle = mp_oControl.Styles.FItem("DS_SCROLLBAR");
		}

		internal bool Enabled 
		{
			get 
			{
				return mp_bEnabled;
			}
			set 
			{
				mp_bEnabled = value;
			}
		}

		internal int Value 
		{
			get 
			{
				return mp_lValue;
			}
			set 
			{
				mp_lValue = value;
				if (mp_lValue < mp_lMin)
				{
					throw new Exception("value is less than mp_lMin.");
				}
			}
		}

		internal int Min 
		{
			get 
			{
				return mp_lMin;
			}
			set 
			{
				mp_lMin = value;
			}
		}

		internal int Max 
		{
			get 
			{
				return mp_lMax;
			}
			set 
			{
				mp_lMax = value;
				if (mp_lMax < mp_lMin)
				{
					throw new Exception("mp_lMax is less than mp_lMin.");
				}
			}
		}

		internal int SmallChange 
		{
			get 
			{
				return mp_lSmallChange;
			}
			set 
			{
				mp_lSmallChange = value;
			}
		}

		internal int LargeChange 
		{
			get 
			{
				return mp_lLargeChange;
			}
			set 
			{
				mp_lLargeChange = value;
			}
		}

		public int TimerInterval 
		{
			get 
			{
				return mp_iTimerInterval;
			}
			set 
			{
				mp_iTimerInterval = value;
			}
		}

		internal void Draw()
		{
            if (Visible == false)
                return;
            clsStyle oArrowButtonUpStyle = ArrowButtons.NormalStyle;
            clsStyle oArrowButtonDownStyle = ArrowButtons.NormalStyle;
            clsStyle oThumbButtonStyle = ThumbButton.NormalStyle;
            if ((mp_lMax - mp_lMin) == 0)
            {
                return;
            }
            mp_oControl.clsG.mp_DrawItem(Left, Top, Left + Width - 1, Top + Height - 1, "", "", false, null, 0, 0,
            mp_oStyle);
            CalculateV();
            if (Enabled == false)
            {
                oThumbButtonStyle = ThumbButton.DisabledStyle;
                oArrowButtonUpStyle = ArrowButtons.DisabledStyle;
                oArrowButtonDownStyle = ArrowButtons.DisabledStyle;
            }
            else if (mp_bMouseDown == true)
            {
                if (mp_iButton == E_BUTTON.BTN_UP)
                {
                    oThumbButtonStyle = ThumbButton.NormalStyle;
                    oArrowButtonUpStyle = ArrowButtons.PressedStyle;
                    oArrowButtonDownStyle = ArrowButtons.NormalStyle;
                }
                else if (mp_iButton == E_BUTTON.BTN_DOWN)
                {
                    oThumbButtonStyle = ThumbButton.NormalStyle;
                    oArrowButtonUpStyle = ArrowButtons.NormalStyle;
                    oArrowButtonDownStyle = ArrowButtons.PressedStyle;
                }
                else if (mp_iButton == E_BUTTON.BTN_BUTTON)
                {
                    oThumbButtonStyle = ThumbButton.PressedStyle;
                    oArrowButtonUpStyle = ArrowButtons.NormalStyle;
                    oArrowButtonDownStyle = ArrowButtons.NormalStyle;
                }
                else
                {
                    oThumbButtonStyle = ThumbButton.NormalStyle;
                    oArrowButtonUpStyle = ArrowButtons.NormalStyle;
                    oArrowButtonDownStyle = ArrowButtons.NormalStyle;
                }
            }
            else
            {
                oArrowButtonUpStyle = ArrowButtons.NormalStyle;
                oArrowButtonDownStyle = ArrowButtons.NormalStyle;
                oThumbButtonStyle = ThumbButton.NormalStyle;
            }
            mp_oControl.clsG.mp_DrawItem(Left, Top, Left + Width - 1, Top + 16, "", "", false, null, 0, 0,
            oArrowButtonUpStyle);
            mp_oControl.clsG.mp_DrawItem(Left, Top + Height - 17, Left + Width - 1, Top + Height - 1, "", "", false, null, 0, 0,
            oArrowButtonDownStyle);
            mp_oControl.clsG.mp_DrawItem(Left + ButtonX1 - 1, Top + ButtonY1, Left + ButtonX2 - 1, Top + ButtonY2 - 2, "", "", false, null, 0, 0,
            oThumbButtonStyle);

            if (oArrowButtonUpStyle.ScrollBarStyle.DropShadow == true)
            {
                mp_oControl.clsG.mp_DrawArrow(Left + oArrowButtonUpStyle.ScrollBarStyle.DropShadowUpX, Top + oArrowButtonUpStyle.ScrollBarStyle.DropShadowUpY, GRE_ARROWDIRECTION.AWD_UP, oArrowButtonUpStyle.ScrollBarStyle.ArrowSize, oArrowButtonUpStyle.ScrollBarStyle.DropShadowArrowColor);
            }
            mp_oControl.clsG.mp_DrawArrow(Left + oArrowButtonUpStyle.ScrollBarStyle.UpX, Top + oArrowButtonUpStyle.ScrollBarStyle.UpY, GRE_ARROWDIRECTION.AWD_UP, oArrowButtonUpStyle.ScrollBarStyle.ArrowSize, oArrowButtonUpStyle.ScrollBarStyle.ArrowColor);
            if (oArrowButtonDownStyle.ScrollBarStyle.DropShadow == true)
            {
                mp_oControl.clsG.mp_DrawArrow(Left + oArrowButtonDownStyle.ScrollBarStyle.DropShadowDownX, Top + Height - 17 + oArrowButtonDownStyle.ScrollBarStyle.DropShadowDownY, GRE_ARROWDIRECTION.AWD_DOWN, oArrowButtonDownStyle.ScrollBarStyle.ArrowSize, oArrowButtonDownStyle.ScrollBarStyle.DropShadowArrowColor);
            }
            mp_oControl.clsG.mp_DrawArrow(Left + oArrowButtonDownStyle.ScrollBarStyle.DownX, Top + Height - 17 + oArrowButtonDownStyle.ScrollBarStyle.DownY, GRE_ARROWDIRECTION.AWD_DOWN, oArrowButtonDownStyle.ScrollBarStyle.ArrowSize, oArrowButtonDownStyle.ScrollBarStyle.ArrowColor);
		}


		internal void OnMouseHover(int X, int Y)
		{
			mp_oControl.MouseKeyboardEvents.mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
		}

		internal void OnMouseDown(int X, int Y)
		{
			if (Enabled == false)
			{
				return;
			}
			if (Visible == false)
			{
				return;
			}
			mp_oControl.MouseKeyboardEvents.mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
			mp_bMouseDown = true;
            mp_oTimer.Interval = new TimeSpan(0, 0, 0, 0, mp_iTimerInterval);
            mp_oTimer.Start();
			ScrollBarClick(X, Y);
		}

		internal void OnMouseMove(int X, int Y)
		{
			if (Enabled == false)
			{
				return;
			}
			if (Visible == false)
			{
				return;
			}
			ConvertToRelativeCoords(ref X, ref Y);
			mp_oControl.MouseKeyboardEvents.mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
			if (mp_iButton == E_BUTTON.BTN_BUTTON)
			{
				int mp_iProjectedValue = mp_lValue + (InvCalculateV(Y) - InvCalculateV(mp_iMouseYPosition));
				if (mp_iProjectedValue >= mp_lMin & mp_iProjectedValue <= mp_lMax)
				{
					mp_iMouseYPosition = Y;
					mp_lValue = mp_iProjectedValue;
					mp_ValueChanged();
				}
				else if (mp_iProjectedValue < mp_lMin)
				{
					mp_iMouseYPosition = Y;
					mp_lValue = mp_lMin;
					mp_ValueChanged();
				}
				else if (mp_iProjectedValue > mp_lMax)
				{
					mp_iMouseYPosition = Y;
					mp_lValue = mp_lMax;
					mp_ValueChanged();
				}
			}
		}

		internal void OnMouseUp()
		{
			if (Enabled == false)
			{
				return;
			}
			if (Visible == false)
			{
				return;
			}
			mp_oControl.MouseKeyboardEvents.mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
			mp_bMouseDown = false;
            mp_oTimer.Stop();
			mp_iButton = E_BUTTON.BTN_NONE;
			mp_oControl.Redraw();
		}

		internal bool OverControl(int X, int Y)
		{
			if (X >= Left & X <= Left + Width & Y >= Top & Y <= Top + Height)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private void ConvertToRelativeCoords(ref int X, ref int Y)
		{
			X = X - Left;
			Y = Y - Top;
		}

		private bool ScrollBarClick(int X, int Y)
		{
			if (OverControl(X,Y) == false)
			{
				return false;
			}
			ConvertToRelativeCoords(ref X, ref Y);
			CalculateV();
			if (Y < 17)
			{
				mp_iButton = E_BUTTON.BTN_UP;
				SmallChangeUp();
				return true;
			}
			else if (Y > 17 & Y < ButtonY1)
			{
				mp_iButton = E_BUTTON.BTN_UPLCHANGE;
				LargeChangeUp();
				return true;
			}
			else if (Y >= ButtonY1 & Y <= ButtonY2)
			{
				mp_iButton = E_BUTTON.BTN_BUTTON;
				mp_iMouseYPosition = Y;
				return true;
			}
			else if (Y > ButtonY2 & Y < Height - 17)
			{
				mp_iButton = E_BUTTON.BTN_DOWNLCHANGE;
				LargeChangeDown();
				return true;
			}
			else if (Y > Height - 17 & Y < Height)
			{
				mp_iButton = E_BUTTON.BTN_DOWN;
				SmallChangeDown();
				return true;
			}
			else
			{
				return false;
			}
		}

		private void SmallChangeUp()
		{
			if ((mp_lValue - mp_lSmallChange) >= mp_lMin)
			{
				mp_lValue = mp_lValue - mp_lSmallChange;
			}
			else
			{
				mp_lValue = mp_lMin;
			}
			mp_ValueChanged();
		}

		private void SmallChangeDown()
		{
			if ((mp_lValue + mp_lSmallChange) <= mp_lMax)
			{
				mp_lValue = mp_lValue + mp_lSmallChange;
			}
			else
			{
				mp_lValue = mp_lMax;
			}
			mp_ValueChanged();
		}

		private void LargeChangeUp()
		{
			if ((mp_lValue - mp_lLargeChange) >= mp_lMin)
			{
				mp_lValue = mp_lValue - mp_lLargeChange;
			}
			else if ((mp_lValue - mp_lLargeChange) < mp_lMin)
			{
				mp_lValue = mp_lMin;
			}
			mp_ValueChanged();
		}

		private void LargeChangeDown()
		{
			if ((mp_lValue + mp_lLargeChange) <= mp_lMax)
			{
				mp_lValue = mp_lValue + mp_lLargeChange;
			}
			else if ((mp_lValue + mp_lLargeChange) > mp_lMax)
			{
				mp_lValue = mp_lMax;
			}
			mp_ValueChanged();
		}

		private void mp_ValueChanged()
		{
			System.EventArgs e = new System.EventArgs();
            if ((mp_lValue - mp_lValueBuff) != 0)
            {
                if (ValueChanged != null)
                {
                    ValueChanged(this, e, mp_lValue - mp_lValueBuff);
                }
            }
			mp_lValueBuff = mp_lValue;
		}

        private void mp_oTimer_Tick(object sender, EventArgs e)
		{
			switch (mp_iButton)
			{
				case E_BUTTON.BTN_UP:
					SmallChangeUp();
					break;
				case E_BUTTON.BTN_UPLCHANGE:
					LargeChangeUp();
					break;
				case E_BUTTON.BTN_DOWNLCHANGE:
					LargeChangeDown();
					break;
				case E_BUTTON.BTN_DOWN:
					SmallChangeDown();
					break;
			}
		}

		private void CalculateV()
		{
			int lHeight;
			int lItemLength = 0;
			lHeight = Height - (16 * 2) - 1;
			if (mp_lLargeChange > 0)
			{
				lItemLength = mp_oControl.MathLib.RoundDouble((double)lHeight / ((((double)mp_lMax - (double)mp_lMin) / (double)mp_lLargeChange) + 1));
			}
			if (lItemLength < 8)
			{
				lItemLength = 8;
			}
			lItemLength = lItemLength + 1;
			lHeight = lHeight - lItemLength;
			ButtonX1 = 1;
			ButtonX2 = ButtonX1 + Width - 1;
			ButtonY1 = mp_oControl.MathLib.RoundDouble(((((double)mp_lValue - (double)mp_lMin) / ((double)mp_lMax - (double)mp_lMin)) * (double)lHeight) + 17);
			ButtonY2 = ButtonY1 + lItemLength;
		}

		private int InvCalculateV(int Y)
		{
			int lHeight;
			int lItemLength = 0;
			int iReturnValue;
			lHeight = Height - (16 * 2) - 1;
			if (mp_lLargeChange > 0)
			{
				lItemLength = mp_oControl.MathLib.RoundDouble((double)lHeight / ((((double)mp_lMax - (double)mp_lMin) / (double)mp_lLargeChange) + 1));
			}
			if (lItemLength < 8)
			{
				lItemLength = 8;
			}
			lItemLength = lItemLength + 1;
			lHeight = lHeight - lItemLength;
			iReturnValue = mp_oControl.MathLib.RoundDouble(((((double)Y - 17) * ((double)mp_lMax - (double)mp_lMin)) / (double)lHeight) + (double)mp_lMin);
			return iReturnValue;
		}

		internal E_SCROLLSTATE State 
		{
			get 
			{
				return mp_yState;
			}
			set 
			{
				mp_yState = value;
				switch (mp_yState)
				{
					case E_SCROLLSTATE.SS_CANTDISPLAY:
						mp_yState = E_SCROLLSTATE.SS_HIDDEN;
						this.Visible = false;
						break;
					case E_SCROLLSTATE.SS_NOTNEEDED:
						if (mp_oControl.ScrollBarBehaviour == E_SCROLLBEHAVIOUR.SB_DISABLE)
						{
							mp_yState = E_SCROLLSTATE.SS_SHOWN;
							this.Enabled = false;
							this.Visible = true;
						}
						else
						{
							mp_yState = E_SCROLLSTATE.SS_HIDDEN;
							this.Visible = false;
						}
						break;
					case E_SCROLLSTATE.SS_NEEDED:
						mp_yState = E_SCROLLSTATE.SS_SHOWN;
						this.Enabled = true;
						this.Visible = true;
						break;
				}
			}
		}

        public string StyleIndex
        {
            get
            {
                if (mp_sStyleIndex == "DS_SCROLLBAR")
                {
                    return "";
                }
                else
                {
                    return mp_sStyleIndex;
                }
            }
            set
            {
                value = value.Trim();
                if (value.Length == 0)
                    value = "DS_SCROLLBAR";
                mp_sStyleIndex = value;
                mp_oStyle = mp_oControl.Styles.FItem(value);
            }
        }

        public clsStyle Style
        {
            get { return mp_oStyle; }
        }

        public string GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "ScrollBar");
            oXML.InitializeWriter();
            oXML.WriteProperty("StyleIndex", mp_sStyleIndex);
            oXML.WriteObject(ArrowButtons.GetXML());
            oXML.WriteObject(ThumbButton.GetXML());
            return oXML.GetXML();
        }

        public void SetXML(string sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "ScrollBar");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            oXML.ReadProperty("StyleIndex", ref mp_sStyleIndex);
            StyleIndex = mp_sStyleIndex;
            ArrowButtons.SetXML(oXML.ReadObject("ArrowButtonState"));
            ThumbButton.SetXML(oXML.ReadObject("ThumbButtonState"));
        }

	}

}
