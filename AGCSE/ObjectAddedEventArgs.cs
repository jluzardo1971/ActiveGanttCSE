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


    public class ObjectAddedEventArgs : System.EventArgs
	{
		public int TaskIndex;
		public int PredecessorObjectIndex;
		public int PredecessorTaskIndex;
		public E_CONSTRAINTTYPE PredecessorType;
		public string TaskKey;
		public string PredecessorTaskKey;
		public E_EVENTTARGET EventTarget;
    
		internal ObjectAddedEventArgs()
		{
			Clear();
		}
    
		internal void Clear()
		{
			TaskIndex = 0;
			PredecessorObjectIndex = 0;
			PredecessorTaskIndex = 0;
			PredecessorType = 0;
			TaskKey = "";
			PredecessorTaskKey = "";
			EventTarget = 0;
		}
	}
}
