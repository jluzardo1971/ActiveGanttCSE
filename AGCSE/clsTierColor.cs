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
	public class clsTierColor : clsItemBase
	{
		private ActiveGanttCSECtl mp_oControl;
		private clsTierColors mp_clsTierColors;
		private Color mp_clrBackColor;
		private Color mp_clrForeColor;
        private Color mp_clrStartGradientColor;
        private Color mp_clrEndGradientColor;
        private Color mp_clrHatchBackColor;
        private Color mp_clrHatchForeColor;

		public clsTierColor(ActiveGanttCSECtl Value, clsTierColors oTierColors)
		{
			mp_oControl = Value;
			mp_clsTierColors = oTierColors;
		}

		~clsTierColor()
		{
			mp_oControl = null;
		}

		public String Key 
		{
			get 
			{
				return mp_sKey;
			}
			set 
			{
				mp_clsTierColors.oCollection.mp_SetKey(ref mp_sKey, value, SYS_ERRORS.TIERCOLORS_SET_KEY);
			}
		}

		public Color ForeColor 
		{
			get 
			{
				return mp_clrForeColor;
			}
			set 
			{
				mp_clrForeColor = value;
			}
		}

		public Color BackColor 
		{
			get 
			{
				return mp_clrBackColor;
			}
			set 
			{
				mp_clrBackColor = value;
			}
		}

        public Color StartGradientColor
        {
            get { return mp_clrStartGradientColor; }
            set { mp_clrStartGradientColor = value; }
        }

        public Color EndGradientColor
        {
            get { return mp_clrEndGradientColor; }
            set { mp_clrEndGradientColor = value; }
        }

        public Color HatchBackColor
        {
            get { return mp_clrHatchBackColor; }
            set { mp_clrHatchBackColor = value; }
        }

        public Color HatchForeColor
        {
            get { return mp_clrHatchForeColor; }
            set { mp_clrHatchForeColor = value; }
        }

        public String GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "TierColor");
            oXML.InitializeWriter();
            oXML.WriteProperty("BackColor", mp_clrBackColor);
            oXML.WriteProperty("ForeColor", mp_clrForeColor);
            oXML.WriteProperty("StartGradientColor", mp_clrStartGradientColor);
            oXML.WriteProperty("EndGradientColor", mp_clrEndGradientColor);
            oXML.WriteProperty("HatchBackColor", mp_clrHatchBackColor);
            oXML.WriteProperty("HatchForeColor", mp_clrHatchForeColor);
            oXML.WriteProperty("Key", mp_sKey);
            return oXML.GetXML();
        }

        public void SetXML(String sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "TierColor");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            oXML.ReadProperty("BackColor", ref mp_clrBackColor);
            oXML.ReadProperty("ForeColor", ref mp_clrForeColor);
            oXML.ReadProperty("StartGradientColor", ref mp_clrStartGradientColor);
            oXML.ReadProperty("EndGradientColor", ref mp_clrEndGradientColor);
            oXML.ReadProperty("HatchBackColor", ref mp_clrHatchBackColor);
            oXML.ReadProperty("HatchForeColor", ref mp_clrHatchForeColor);
            oXML.ReadProperty("Key", ref mp_sKey);
        }

	}
}
