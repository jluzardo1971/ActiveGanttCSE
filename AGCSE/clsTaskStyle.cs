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

	public class clsTaskStyle
	{
    
		private ActiveGanttCSECtl mp_oControl;
		private Color mp_clrEndBorderColor;
		private Color mp_clrEndFillColor;
		private Color mp_clrStartBorderColor;
		private Color mp_clrStartFillColor;
    
		private GRE_FIGURETYPE mp_yEndShapeIndex;
		private GRE_FIGURETYPE mp_yStartShapeIndex;
    
		private Image mp_oStartImage;
		private Image mp_oMiddleImage;
		private Image mp_oEndImage;

        private string mp_sStartImageTag;
        private string mp_sMiddleImageTag;
        private string mp_sEndImageTag;
    
		internal clsTaskStyle(ActiveGanttCSECtl Value)
		{
			mp_oControl = Value;
			mp_clrEndBorderColor = Colors.Black;
			mp_clrEndFillColor = Colors.Black;
			mp_clrStartBorderColor = Colors.Black;
			mp_clrStartFillColor = Colors.Black;
			mp_oEndImage = null;
			mp_oMiddleImage = null;
			mp_oStartImage = null;
			mp_yEndShapeIndex = GRE_FIGURETYPE.FT_NONE;
			mp_yStartShapeIndex = GRE_FIGURETYPE.FT_NONE;
            mp_sStartImageTag = "";
            mp_sMiddleImageTag = "";
            mp_sEndImageTag = "";
		}
    
		public Color EndBorderColor 
		{
			get { return mp_clrEndBorderColor; }
			set { mp_clrEndBorderColor = value; }
		}
    
		public Color EndFillColor 
		{
			get { return mp_clrEndFillColor; }
			set { mp_clrEndFillColor = value; }
		}
    
		public Color StartBorderColor 
		{
			get { return mp_clrStartBorderColor; }
			set { mp_clrStartBorderColor = value; }
		}
    
		public Color StartFillColor 
		{
			get { return mp_clrStartFillColor; }
			set { mp_clrStartFillColor = value; }
		}
    
		public Image StartImage 
		{
			get { return mp_oStartImage; }
			set { mp_oStartImage = value; }
		}
    
		public Image MiddleImage 
		{
			get { return mp_oMiddleImage; }
			set { mp_oMiddleImage = value; }
		}
    
		public Image EndImage 
		{
			get { return mp_oEndImage; }
			set { mp_oEndImage = value; }
		}
    
		public GRE_FIGURETYPE StartShapeIndex 
		{
			get { return mp_yStartShapeIndex; }
			set { mp_yStartShapeIndex = value; }
		}
    
		public GRE_FIGURETYPE EndShapeIndex 
		{
			get { return mp_yEndShapeIndex; }
			set { mp_yEndShapeIndex = value; }
		}

        public string StartImageTag
        {
            get { return mp_sStartImageTag; }
            set { mp_sStartImageTag = value; }
        }

        public string MiddleImageTag
        {
            get { return mp_sMiddleImageTag; }
            set { mp_sMiddleImageTag = value; }
        }

        public string EndImageTag
        {
            get { return mp_sEndImageTag; }
            set { mp_sEndImageTag = value; }
        }

        public string GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "TaskStyle");
            oXML.InitializeWriter();
            oXML.WriteProperty("EndBorderColor", mp_clrEndBorderColor);
            oXML.WriteProperty("EndFillColor", mp_clrEndFillColor);
            oXML.WriteProperty("EndImage", mp_oEndImage);
            oXML.WriteProperty("EndShapeIndex", mp_yEndShapeIndex);
            oXML.WriteProperty("MiddleImage", mp_oMiddleImage);
            oXML.WriteProperty("StartBorderColor", mp_clrStartBorderColor);
            oXML.WriteProperty("StartFillColor", mp_clrStartFillColor);
            oXML.WriteProperty("StartImage", mp_oStartImage);
            oXML.WriteProperty("StartShapeIndex", mp_yStartShapeIndex);
            oXML.WriteProperty("StartImageTag", mp_sStartImageTag);
            oXML.WriteProperty("MiddleImageTag", mp_sMiddleImageTag);
            oXML.WriteProperty("EndImageTag", mp_sEndImageTag);
            return oXML.GetXML();
        }


        public void SetXML(string sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "TaskStyle");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            oXML.ReadProperty("EndBorderColor", ref mp_clrEndBorderColor);
            oXML.ReadProperty("EndFillColor", ref mp_clrEndFillColor);
            oXML.ReadProperty("EndImage", ref mp_oEndImage);
            oXML.ReadProperty("EndShapeIndex", ref mp_yEndShapeIndex);
            oXML.ReadProperty("MiddleImage", ref mp_oMiddleImage);
            oXML.ReadProperty("StartBorderColor", ref mp_clrStartBorderColor);
            oXML.ReadProperty("StartFillColor", ref mp_clrStartFillColor);
            oXML.ReadProperty("StartImage", ref mp_oStartImage);
            oXML.ReadProperty("StartShapeIndex", ref mp_yStartShapeIndex);
            oXML.ReadProperty("StartImageTag", ref mp_sStartImageTag);
            oXML.ReadProperty("MiddleImageTag", ref mp_sMiddleImageTag);
            oXML.ReadProperty("EndImageTag", ref mp_sEndImageTag);
        }
    
	}
}
