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


    public class ToolTipEventArgs : System.EventArgs
	{
		public int InitialRowIndex;
		public int FinalRowIndex;
		public int TaskIndex;
		public int MilestoneIndex;
		public int PercentageIndex;
		public int RowIndex;
		public int CellIndex;
		public int ColumnIndex;
		public AGCSE.DateTime InitialStartDate;
        public AGCSE.DateTime InitialEndDate;
        public AGCSE.DateTime StartDate;
        public AGCSE.DateTime EndDate;
		public int XStart;
		public int XEnd;
		public E_OPERATION Operation;
		public E_EVENTTARGET EventTarget;
		public string TaskPosition;
		public string PredecessorPosition;
		public int X;
		public int Y;
		public bool CustomDraw;
        //[Description("A pointer to the Graphics object of the control.")]
		public Canvas Graphics;
		public E_TOOLTIPTYPE ToolTipType;
    
		internal ToolTipEventArgs()
		{
			Clear();
		}
    
		internal void Clear()
		{
			InitialRowIndex = 0;
			FinalRowIndex = 0;
			RowIndex = 0;
			TaskIndex = 0;
			MilestoneIndex = 0;
			PercentageIndex = 0;
			CellIndex = 0;
			ColumnIndex = 0;
            StartDate = new AGCSE.DateTime();
            EndDate = new AGCSE.DateTime();
            InitialStartDate = new AGCSE.DateTime();
            InitialEndDate = new AGCSE.DateTime();
			XStart = 0;
			XEnd = 0;
			X = 0;
			Y = 0;
			Operation = 0;
			EventTarget = 0;
			ToolTipType = 0;
		}
	}
}
