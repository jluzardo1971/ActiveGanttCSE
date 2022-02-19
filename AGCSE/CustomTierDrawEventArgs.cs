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

	using System;
	using System.ComponentModel;
	using System.Reflection;


    public class CustomTierDrawEventArgs : System.EventArgs
	{
		public string Text;
		public bool CustomDraw;
		public string StyleIndex;
		public E_TIERPOSITION TierPosition;
		public AGCSE.DateTime StartDate;
        public AGCSE.DateTime EndDate;
		public int Left;
		public int Top;
		public int Right;
		public int Bottom;
		public int LeftTrim;
		public int RightTrim;
        //public System.Drawing.Graphics Graphics;
        public E_INTERVAL Interval;
        public int Factor;
    
    
		internal CustomTierDrawEventArgs()
		{
			Clear();
		}
    
		internal void Clear()
		{
			Text = "";
			CustomDraw = false;
			StyleIndex = "";
			TierPosition = E_TIERPOSITION.SP_UPPER;
            StartDate = new AGCSE.DateTime();
            EndDate = new AGCSE.DateTime();
			Left = 0;
			Top = 0;
			Right = 0;
			Bottom = 0;
			LeftTrim = 0;
			RightTrim = 0;
			//Graphics = null;
            Interval = E_INTERVAL.IL_SECOND;
            Factor = 0;
		}
	}

}
