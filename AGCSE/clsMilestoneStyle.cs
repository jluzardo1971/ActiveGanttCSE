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

	public class clsMilestoneStyle
	{
		private ActiveGanttCSECtl mp_oControl;
		private Color mp_clrBorderColor;
		private Color mp_clrFillColor;
		private GRE_FIGURETYPE mp_yShapeIndex;
        private Image mp_oImage;
        private string mp_sImageTag;

		public clsMilestoneStyle(ActiveGanttCSECtl Value)
		{
			mp_oControl = Value;
			mp_clrBorderColor = Colors.Black;
			mp_clrFillColor = Colors.Black;
			mp_yShapeIndex = GRE_FIGURETYPE.FT_NONE;
            mp_oImage = null;
            mp_sImageTag = "";
		}

		~clsMilestoneStyle()
		{
			mp_oControl = null;
		}

		public Color BorderColor 
		{
			get 
			{
				return mp_clrBorderColor;
			}
			set 
			{
				mp_clrBorderColor = value;
			}
		}

		public Color FillColor 
		{
			get 
			{
				return mp_clrFillColor;
			}
			set 
			{
				mp_clrFillColor = value;
			}
		}

		public GRE_FIGURETYPE ShapeIndex 
		{
			get 
			{
				return mp_yShapeIndex;
			}
			set 
			{
				mp_yShapeIndex = value;
			}
		}

        public Image Image
        {
            get { return mp_oImage; }
            set { mp_oImage = value; }
        }

        public string ImageTag
        {
            get { return mp_sImageTag; }
            set { mp_sImageTag = value; }
        }

        public String GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "MilestoneStyle");
            oXML.InitializeWriter();
            oXML.WriteProperty("BorderColor", mp_clrBorderColor);
            oXML.WriteProperty("FillColor", mp_clrFillColor);
            oXML.WriteProperty("ShapeIndex", mp_yShapeIndex);
            oXML.WriteProperty("Image", mp_oImage);
            oXML.WriteProperty("ImageTag", mp_sImageTag);
            return oXML.GetXML();
        }

        public void SetXML(String sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "MilestoneStyle");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            oXML.ReadProperty("BorderColor", ref mp_clrBorderColor);
            oXML.ReadProperty("FillColor", ref mp_clrFillColor);
            oXML.ReadProperty("ShapeIndex", ref mp_yShapeIndex);
            oXML.ReadProperty("Image", ref mp_oImage);
            oXML.ReadProperty("ImageTag", ref mp_sImageTag);
        }

	}
}
