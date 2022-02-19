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

    public class ScrollEventArgs : System.EventArgs
	{
		public E_SCROLLBAR ScrollBarType;
		public int Offset;
    
		internal ScrollEventArgs()
		{
			Clear();
		}
    
		internal void Clear()
		{
			ScrollBarType = 0;
			Offset = 0;
		}
	}
}
