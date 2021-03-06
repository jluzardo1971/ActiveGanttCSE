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

    public class ObjectSelectedEventArgs : System.EventArgs
	{
		public E_EVENTTARGET EventTarget;
		public int ObjectIndex;
		public int ParentObjectIndex;
    
		internal ObjectSelectedEventArgs()
		{
			Clear();
		}
    
		internal void Clear()
		{
			EventTarget = 0;
			ObjectIndex = 0;
			ParentObjectIndex = 0;
		}
	}
}
