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


    public class MouseEventArgs : System.EventArgs
	{
		public int X;
		public int Y;
		public E_EVENTTARGET EventTarget;
		public E_OPERATION Operation;
		public E_MOUSEBUTTONS Button;
		public bool Cancel;
    
		internal MouseEventArgs()
		{
			Clear();
		}
    
		internal void Clear()
		{
			X = 0;
			Y = 0;
			EventTarget = 0;
			Operation = 0;
			Button = 0;
			Cancel = false;
		}
	}
}
