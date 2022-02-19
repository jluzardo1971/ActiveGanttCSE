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


    public class ObjectStateChangedEventArgs : System.EventArgs
	{
		public E_EVENTTARGET EventTarget;
		public int Index;
		public bool Cancel;
		public int DestinationIndex;
		public int InitialRowIndex;
		public int FinalRowIndex;
		public int InitialColumnIndex;
		public int FinalColumnIndex;
        public AGCSE.DateTime StartDate;
        public AGCSE.DateTime EndDate;
    
		internal ObjectStateChangedEventArgs()
		{
			Clear();
		}
    
		internal void Clear()
		{
            EventTarget = 0;
            Index = 0;
            StartDate = new AGCSE.DateTime();
            EndDate = new AGCSE.DateTime();
            Cancel = false;
		}
	}
}
