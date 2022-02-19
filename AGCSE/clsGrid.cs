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

	public class clsGrid
	{
		private ActiveGanttCSECtl mp_oControl;
		private bool mp_bHorizontalLines;
		private bool mp_bVerticalLines;
		private bool mp_bSnapToGrid;
		private bool mp_bSnapToGridOnSelection;
		private Color mp_clrColor;
        private E_INTERVAL mp_yInterval;
		private int mp_lFactor;
		private clsTimeLine mp_oTimeLine;

		public clsGrid(ActiveGanttCSECtl Value, clsTimeLine oTimeLine)
		{
			mp_oControl = Value;
			mp_oTimeLine = oTimeLine;
			mp_bHorizontalLines = true;
			mp_bVerticalLines = false;
			mp_bSnapToGrid = false;
			mp_bSnapToGridOnSelection = true;
			mp_clrColor = Color.FromArgb(255, 192, 192, 192);
            mp_yInterval = E_INTERVAL.IL_MINUTE;
            mp_lFactor = 15;

		}

		~clsGrid()
		{

		}

		public bool HorizontalLines 
		{
			get 
			{
				return mp_bHorizontalLines;
			}
			set 
			{
				mp_bHorizontalLines = value;
			}
		}

		public bool VerticalLines 
		{
			get 
			{
				return mp_bVerticalLines;
			}
			set 
			{
				mp_bVerticalLines = value;
			}
		}

		public bool SnapToGrid 
		{
			get 
			{
				return mp_bSnapToGrid;
			}
			set 
			{
				mp_bSnapToGrid = value;
			}
		}

		public bool SnapToGridOnSelection 
		{
			get 
			{
				return mp_bSnapToGridOnSelection;
			}
			set 
			{
				mp_bSnapToGridOnSelection = value;
			}
		}

		public Color Color 
		{
			get 
			{
				return mp_clrColor;
			}
			set 
			{
				mp_clrColor = value;
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

        internal void Draw()
        {
            AGCSE.DateTime dtBuff;
            if (mp_bVerticalLines == false)
            {
                return;
            }
            if (mp_oControl.MathLib.GetXCoordinateFromDate(mp_oControl.MathLib.DateTimeAdd(mp_yInterval, mp_lFactor, mp_oTimeLine.StartDate)) - mp_oControl.MathLib.GetXCoordinateFromDate(mp_oTimeLine.StartDate) < 5)
            {
                return;
            }
            mp_oControl.clsG.ClipRegion(mp_oTimeLine.f_lStart, mp_oControl.CurrentViewObject.ClientArea.Top, mp_oTimeLine.f_lEnd, mp_oControl.CurrentViewObject.ClientArea.Bottom, true);
            dtBuff = mp_oControl.MathLib.RoundDate(mp_yInterval, mp_lFactor, mp_oTimeLine.StartDate);
            if (mp_oControl.MathLib.GetXCoordinateFromDate(dtBuff) >= mp_oTimeLine.f_lStart)
            {
                mp_PaintVerticalGridLine(mp_oControl.MathLib.GetXCoordinateFromDate(dtBuff), GRE_LINEDRAWSTYLE.LDS_SOLID);
            }
            while (dtBuff < mp_oTimeLine.EndDate)
            {
                dtBuff = mp_oControl.MathLib.DateTimeAdd(mp_yInterval, mp_lFactor, dtBuff);
                mp_PaintVerticalGridLine(mp_oControl.MathLib.GetXCoordinateFromDate(dtBuff), GRE_LINEDRAWSTYLE.LDS_SOLID);
            }
        }

		private void mp_PaintVerticalGridLine(int fXCoordinate, GRE_LINEDRAWSTYLE v_lDrawStyle)
		{
			mp_oControl.clsG.DrawLine(fXCoordinate, mp_oControl.CurrentViewObject.ClientArea.Top, fXCoordinate, mp_oControl.Rows.TopOffset, GRE_LINETYPE.LT_NORMAL, mp_clrColor, v_lDrawStyle, 1, true);
		}

        public String GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "Grid");
            oXML.InitializeWriter();
            oXML.WriteProperty("Color", mp_clrColor);
            oXML.WriteProperty("HorizontalLines", mp_bHorizontalLines);
            oXML.WriteProperty("Interval", mp_yInterval);
            oXML.WriteProperty("Factor", mp_lFactor);
            oXML.WriteProperty("SnapToGrid", mp_bSnapToGrid);
            oXML.WriteProperty("SnapToGridOnSelection", mp_bSnapToGridOnSelection);
            oXML.WriteProperty("VerticalLines", mp_bVerticalLines);
            return oXML.GetXML();
        }

        public void SetXML(String sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "Grid");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            oXML.ReadProperty("HorizontalLines", ref mp_bHorizontalLines);
            oXML.ReadProperty("VerticalLines", ref mp_bVerticalLines);
            oXML.ReadProperty("SnapToGrid", ref mp_bSnapToGrid);
            oXML.ReadProperty("SnapToGridOnSelection", ref mp_bSnapToGridOnSelection);
            oXML.ReadProperty("Color", ref mp_clrColor);
            oXML.ReadProperty("Interval", ref mp_yInterval);
            oXML.ReadProperty("Factor", ref mp_lFactor);
        }

	}
}
