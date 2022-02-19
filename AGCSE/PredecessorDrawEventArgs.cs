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

    public class PredecessorDrawEventArgs : System.EventArgs
	{
		public bool CustomDraw;
        //[Description("A pointer to the Graphics object of the control.")]
        //public Graphics Graphics;
		public int PredecessorIndex;
		public int TaskIndex;
		public E_CONSTRAINTTYPE PredecessorType;
    
		internal PredecessorDrawEventArgs()
		{
			Clear();
		}
    
		internal void Clear()
		{
			CustomDraw = false;
			//Graphics = null;
			PredecessorIndex = 0;
			TaskIndex = 0;
			PredecessorType = 0;
		}
	}

}
