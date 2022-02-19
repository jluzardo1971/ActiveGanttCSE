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

	public class clsPredecessorStyle
	{
    
		private ActiveGanttCSECtl mp_oControl;
		private int mp_lArrowSize;
		private GRE_LINEDRAWSTYLE mp_yLineStyle;
		private int mp_lLineWidth;
		private int mp_lXOffset;
		private int mp_lYOffset;
		private Color mp_clrLineColor;
    
		internal clsPredecessorStyle(ActiveGanttCSECtl Value)
		{
			mp_oControl = Value;
			mp_lArrowSize = 3;
			mp_yLineStyle = GRE_LINEDRAWSTYLE.LDS_SOLID;
			mp_lLineWidth = 1;
			mp_lXOffset = 10;
			mp_lYOffset = 10;
			mp_clrLineColor = Colors.Black;
		}
    
		public Color LineColor 
		{
			get { return mp_clrLineColor; }
			set { mp_clrLineColor = value; }
		}
    
		public int XOffset 
		{
			get { return mp_lXOffset; }
			set { mp_lXOffset = value; }
		}
    
		public int YOffset 
		{
			get { return mp_lYOffset; }
			set { mp_lYOffset = value; }
		}
    
		public int LineWidth 
		{
			get { return mp_lLineWidth; }
			set { mp_lLineWidth = value; }
		}
    
		public GRE_LINEDRAWSTYLE LineStyle 
		{
			get { return mp_yLineStyle; }
			set { mp_yLineStyle = value; }
		}

		public int ArrowSize 
		{
			get { return mp_lArrowSize; }
			set 
			{
				if ((value < 1)) 
				{
					value = 1;
				}
				mp_lArrowSize = value;
			}
		}

        public string GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "PredecessorStyle");
            oXML.InitializeWriter();
            oXML.WriteProperty("ArrowSize", mp_lArrowSize);
            oXML.WriteProperty("LineColor", mp_clrLineColor);
            oXML.WriteProperty("LineStyle", mp_yLineStyle);
            oXML.WriteProperty("LineWidth", mp_lLineWidth);
            oXML.WriteProperty("XOffset", mp_lXOffset);
            oXML.WriteProperty("YOffset", mp_lYOffset);
            return oXML.GetXML();
        }


        public void SetXML(string sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "PredecessorStyle");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            oXML.ReadProperty("ArrowSize", ref mp_lArrowSize);
            oXML.ReadProperty("LineColor", ref mp_clrLineColor);
            oXML.ReadProperty("LineStyle", ref mp_yLineStyle);
            oXML.ReadProperty("LineWidth", ref mp_lLineWidth);
            oXML.ReadProperty("XOffset", ref mp_lXOffset);
            oXML.ReadProperty("YOffset", ref mp_lYOffset);
        }
    
	}

}
