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
	public class clsTickMarkArea
	{
    
		private ActiveGanttCSECtl mp_oControl;
		private int mp_lHeight;
		private int mp_lBigTickMarkHeight;
		private int mp_lMediumTickMarkHeight;
		private int mp_lSmallTickMarkHeight;
		private bool mp_bVisible;
		private int mp_lTextOffset;
		public clsTickMarks TickMarks;
		private clsTimeLine mp_oTimeLine;
		private string mp_sStyleIndex;
		private clsStyle mp_oStyle;
    
		internal clsTickMarkArea(ActiveGanttCSECtl Value, clsTimeLine oTimeLine, bool bInit)
		{
			mp_oControl = Value;
			mp_oTimeLine = oTimeLine;
			mp_sStyleIndex = "DS_TICKMARKAREA";
			mp_oStyle = mp_oControl.Styles.FItem("DS_TICKMARKAREA");
			mp_lHeight = 23;
			mp_lBigTickMarkHeight = 12;
			mp_lMediumTickMarkHeight = 9;
			mp_lSmallTickMarkHeight = 7;
			mp_bVisible = true;
			mp_lTextOffset = 11;
			TickMarks = new clsTickMarks(mp_oControl);
		}
    
		public int Height 
		{
			get { return mp_lHeight; }
			set { mp_lHeight = value; }
		}
    
		public int BigTickMarkHeight 
		{
			get { return mp_lBigTickMarkHeight; }
			set { mp_lBigTickMarkHeight = value; }
		}
    
		public int MediumTickMarkHeight 
		{
			get { return mp_lMediumTickMarkHeight; }
			set { mp_lMediumTickMarkHeight = value; }
		}
    
		public int SmallTickMarkHeight 
		{
			get { return mp_lSmallTickMarkHeight; }
			set { mp_lSmallTickMarkHeight = value; }
		}
    
		public bool Visible 
		{
			get { return mp_bVisible; }
			set { mp_bVisible = value; }
		}
    
		public string StyleIndex 
		{
			get 
			{
				if (mp_sStyleIndex == "DS_TICKMARKAREA") 
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
                if (value.Length == 0) { value = "DS_TICKMARKAREA"; }
				mp_sStyleIndex = value;
				mp_oStyle = mp_oControl.Styles.FItem(value);
			}
		}

        public clsStyle Style
        {
            get { return mp_oStyle; }
        }
    
		public int TextOffset 
		{
			get { return mp_lTextOffset; }
			set { mp_lTextOffset = value; }
		}


        internal void Draw()
        {
            AGCSE.DateTime dtBuff = new AGCSE.DateTime();
            clsTickMark oTickMark = null;
            int lIndex = 0;
            if (Visible == false)
            {
                return;
            }
            mp_oControl.clsG.mp_DrawItem(mp_oTimeLine.f_lStart, mp_oTimeLine.Bottom - Height, mp_oTimeLine.f_lEnd, mp_oTimeLine.Bottom, "", "", false, null, mp_oTimeLine.f_lStart, mp_oTimeLine.f_lEnd, mp_oStyle);
            mp_oControl.clsG.ClipRegion(mp_oTimeLine.f_lStart, mp_oTimeLine.Bottom - Height, mp_oTimeLine.f_lEnd, mp_oTimeLine.Bottom, false);
            for (lIndex = 1; lIndex <= TickMarks.Count; lIndex++)
            {
                E_INTERVAL yInterval;
                int lFactor = 0;
                oTickMark = TickMarks.Item(lIndex.ToString());
                yInterval = oTickMark.Interval;
                lFactor = oTickMark.Factor;
                if (mp_oControl.MathLib.GetXCoordinateFromDate(mp_oControl.MathLib.DateTimeAdd(yInterval, lFactor, mp_oTimeLine.StartDate)) - mp_oControl.MathLib.GetXCoordinateFromDate(mp_oTimeLine.StartDate) < 5)
                {
                    break; // TODO: might not be correct. Was : Exit For
                }
                dtBuff = mp_oControl.MathLib.RoundDate(yInterval, lFactor, mp_oTimeLine.StartDate);
                if (mp_oControl.MathLib.GetXCoordinateFromDate(dtBuff) >= mp_oTimeLine.f_lStart)
                {
                    PaintTickMark(mp_oControl.MathLib.GetXCoordinateFromDate(dtBuff), oTickMark.TickMarkType);
                    if (oTickMark.DisplayText == true)
                    {
                        PaintText(mp_oControl.MathLib.GetXCoordinateFromDate(dtBuff), oTickMark.TextFormat);
                    }
                }
                while (dtBuff < mp_oTimeLine.EndDate)
                {
                    dtBuff = mp_oControl.MathLib.DateTimeAdd(yInterval, lFactor, dtBuff);
                    PaintTickMark(mp_oControl.MathLib.GetXCoordinateFromDate(dtBuff), oTickMark.TickMarkType);
                    if (oTickMark.DisplayText == true)
                    {
                        PaintText(mp_oControl.MathLib.GetXCoordinateFromDate(dtBuff), oTickMark.TextFormat);
                    }
                }
            }
            mp_oControl.clsG.ClearClipRegion();
        }
    
		private void PaintTickMark(int fXCoordinate, E_TICKMARKTYPES TickMarkType)
		{
			int lTickMarkHeight = 0;
			switch (TickMarkType) 
			{
				case E_TICKMARKTYPES.TLT_BIG:
					lTickMarkHeight = mp_lBigTickMarkHeight;
					break;
				case E_TICKMARKTYPES.TLT_MEDIUM:
					lTickMarkHeight = mp_lMediumTickMarkHeight;
					break;
				case E_TICKMARKTYPES.TLT_SMALL:
					lTickMarkHeight = mp_lSmallTickMarkHeight;
					break;
			}
			mp_oControl.clsG.DrawLine(fXCoordinate, mp_oTimeLine.Bottom - lTickMarkHeight, fXCoordinate, mp_oTimeLine.Bottom, GRE_LINETYPE.LT_NORMAL, mp_oStyle.BorderColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
		}
    
		private void PaintText(int fXCoordinate, string sFormat)
		{
			string sDateBuff = null;
			int lLeft = 0;
			int lTop = 0;
			int lRight = 0;
			int lBottom = 0;
			int lStringWidth = 0;
			int lStringHeight = 0;
			sDateBuff = mp_oControl.MathLib.GetDateFromXCoordinate(fXCoordinate).ToString(sFormat);
			lStringWidth = mp_oControl.mp_lStrWidth(sDateBuff, mp_oStyle.Font);
			lStringHeight = mp_oControl.mp_lStrHeight(sDateBuff, mp_oStyle.Font);
			lLeft = fXCoordinate - (lStringWidth / 2) - 10;
			lTop = mp_oTimeLine.Bottom - mp_lTextOffset - lStringHeight;
			lRight = fXCoordinate + (lStringWidth / 2) + 10;
			lBottom = lTop + lStringHeight;
			mp_oControl.clsG.DrawAlignedText(lLeft, lTop, lRight, lBottom, sDateBuff, GRE_HORIZONTALALIGNMENT.HAL_CENTER, GRE_VERTICALALIGNMENT.VAL_CENTER, mp_oStyle.ForeColor, mp_oStyle.Font);
		}

        public string GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "TickMarkArea");
            oXML.InitializeWriter();
            oXML.WriteProperty("BigTickMarkHeight", mp_lBigTickMarkHeight);
            oXML.WriteProperty("Height", mp_lHeight);
            oXML.WriteProperty("MediumTickMarkHeight", mp_lMediumTickMarkHeight);
            oXML.WriteProperty("SmallTickMarkHeight", mp_lSmallTickMarkHeight);
            oXML.WriteProperty("StyleIndex", mp_sStyleIndex);
            oXML.WriteProperty("TextOffset", mp_lTextOffset);
            oXML.WriteProperty("Visible", mp_bVisible);
            oXML.WriteObject(TickMarks.GetXML());
            return oXML.GetXML();
        }


        public void SetXML(string sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "TickMarkArea");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            oXML.ReadProperty("BigTickMarkHeight", ref mp_lBigTickMarkHeight);
            oXML.ReadProperty("Height", ref mp_lHeight);
            oXML.ReadProperty("MediumTickMarkHeight", ref mp_lMediumTickMarkHeight);
            oXML.ReadProperty("SmallTickMarkHeight", ref mp_lSmallTickMarkHeight);
            oXML.ReadProperty("StyleIndex", ref mp_sStyleIndex);
            StyleIndex = mp_sStyleIndex;
            oXML.ReadProperty("TextOffset", ref mp_lTextOffset);
            oXML.ReadProperty("Visible", ref mp_bVisible);
            TickMarks.SetXML(oXML.ReadObject("TickMarks"));
        }
    
	}
}
