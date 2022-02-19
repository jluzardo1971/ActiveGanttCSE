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

    public class DrawEventArgs : System.EventArgs
	{
		public E_EVENTTARGET EventTarget;
		public bool CustomDraw;
		public int ObjectIndex;
		public int ParentObjectIndex;
        //[Description("A pointer to the Graphics object of the control.")]
        //public System.Drawing.Graphics Graphics;
    
		internal DrawEventArgs()
		{
			Clear();
		}
    
		internal void Clear()
		{
			EventTarget = 0;
			CustomDraw = false;
			ObjectIndex = 0;
			ParentObjectIndex = 0;
			//Graphics = null;
		}
	}


}
