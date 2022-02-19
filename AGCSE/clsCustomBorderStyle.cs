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
	public class clsCustomBorderStyle
	{
    
		private ActiveGanttCSECtl mp_oControl;
		private bool mp_bTop;
		private bool mp_bBottom;
		private bool mp_bLeft;
		private bool mp_bRight;
    
		internal clsCustomBorderStyle(ActiveGanttCSECtl Value)
		{
			mp_oControl = Value;
			mp_bTop = true;
			mp_bBottom = true;
			mp_bLeft = true;
			mp_bRight = true;
		}
    
		public bool Left 
		{
			get { return mp_bLeft; }
			set { mp_bLeft = value; }
		}
    
		public bool Top 
		{
			get { return mp_bTop; }
			set { mp_bTop = value; }
		}
    
		public bool Right 
		{
			get { return mp_bRight; }
			set { mp_bRight = value; }
		}
    
		public bool Bottom 
		{
			get { return mp_bBottom; }
			set { mp_bBottom = value; }
		}

        public string GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "CustomBorderStyle");
            oXML.InitializeWriter();
            oXML.WriteProperty("Bottom", mp_bBottom);
            oXML.WriteProperty("Left", mp_bLeft);
            oXML.WriteProperty("Right", mp_bRight);
            oXML.WriteProperty("Top", mp_bTop);
            return oXML.GetXML();
        }


        public void SetXML(string sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "CustomBorderStyle");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            oXML.ReadProperty("Bottom", ref mp_bBottom);
            oXML.ReadProperty("Left", ref mp_bLeft);
            oXML.ReadProperty("Right", ref mp_bRight);
            oXML.ReadProperty("Top", ref mp_bTop);
        }
    
	}
}
