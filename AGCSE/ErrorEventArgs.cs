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

    public class ErrorEventArgs : System.EventArgs
	{
		public int Number;
		public string Description;
		public string Source;
    
		internal ErrorEventArgs()
		{
			Clear();
		}
    
		internal void Clear()
		{
			Number = 0;
			Description = "";
			Source = "";
		}
	}
}
