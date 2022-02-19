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

	public class clsClientArea
	{

		private ActiveGanttCSECtl mp_oControl;
		private clsTimeLine mp_oTimeLine;
		private bool mp_bDetectConflicts;
		private int mp_lMilestoneSelectionOffset;
        private int mp_lPredecessorSelectionOffset;
		private int mp_lLastVisibleRow;
		public clsGrid Grid;
		private string mp_sToolTipFormat;
		private bool mp_bToolTipsVisible;

		internal clsClientArea(ActiveGanttCSECtl Value, clsTimeLine oTimeLine)
		{
			mp_oControl = Value;
			mp_oTimeLine = oTimeLine;
			mp_bDetectConflicts = true;
			mp_lMilestoneSelectionOffset = 5;
			mp_lLastVisibleRow = 0;
			Grid = new clsGrid(mp_oControl, mp_oTimeLine);
			mp_sToolTipFormat = "ddddd";
			mp_bToolTipsVisible = true;
            mp_lPredecessorSelectionOffset = 2;
		}

		public bool DetectConflicts 
		{
			get { return mp_bDetectConflicts; }
			set { mp_bDetectConflicts = value; }
		}

		public int MilestoneSelectionOffset 
		{
			get { return mp_lMilestoneSelectionOffset; }
			set { mp_lMilestoneSelectionOffset = value; }
		}

		public int FirstVisibleRow 
		{
			get { return mp_oControl.VerticalScrollBar.Value; }
			set { mp_oControl.VerticalScrollBar.Value = value; }
		}

		public int LastVisibleRow 
		{
			get { return mp_lLastVisibleRow; }
		}

		internal int f_LastVisibleRow 
		{
			set { mp_lLastVisibleRow = value; }
		}

		public string ToolTipFormat 
		{
			get { return mp_sToolTipFormat; }
			set { mp_sToolTipFormat = value; }
		}

		public bool ToolTipsVisible 
		{
			get { return mp_bToolTipsVisible; }
			set { mp_bToolTipsVisible = value; }
		}

		public int Top 
		{
			get 
			{
				if ((mp_oTimeLine.Height == 0)) 
				{
					return mp_oControl.mt_BorderThickness;
				}
				else 
				{
					return mp_oTimeLine.Bottom + 1;
				}
			}
		}

		public int Bottom 
		{
			get 
			{
				if (mp_oTimeLine.TimeLineScrollBar.State == E_SCROLLSTATE.SS_SHOWN) 
				{
					return mp_oControl.clsG.Height - mp_oControl.mt_BorderThickness - 1 - mp_oTimeLine.TimeLineScrollBar.Height;
				}
				else 
				{
					return mp_oControl.clsG.Height - mp_oControl.mt_BorderThickness - 1;
				}
			}
		}

		public int Left 
		{
			get { return mp_oTimeLine.f_lStart; }
		}

		public int Right 
		{
			get { return mp_oTimeLine.f_lEnd; }
		}

		public int Width 
		{
			get { return Right - Left; }
		}

		public int Height 
		{
			get { return Bottom - Top; }
		}

        public int PredecessorSelectionOffset
        {
            get { return mp_lPredecessorSelectionOffset; }
            set { mp_lPredecessorSelectionOffset = value; }
        }

		internal void Draw()
		{
			int lRowIndex = 0;
			clsRow oRow = null;
			if (mp_oControl.Rows.Count == 0) 
			{
				return;
			}
			mp_oControl.clsG.ClipRegion(mp_oControl.Splitter.Right, mp_oControl.CurrentViewObject.ClientArea.Top, mp_oControl.mt_RightMargin, mp_oControl.CurrentViewObject.ClientArea.Bottom, true);
			for (lRowIndex = mp_oControl.VerticalScrollBar.Value; lRowIndex <= mp_lLastVisibleRow; lRowIndex++) 
			{
				oRow = (clsRow) mp_oControl.Rows.oCollection.m_oReturnArrayElement(lRowIndex);
                mp_oControl.clsG.mp_DrawItem(mp_oControl.Splitter.Right, oRow.Top, mp_oControl.mt_RightMargin, oRow.Bottom, "", "", false, null, 0, 0, oRow.ClientAreaStyle);
			}
		}

        public string GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "ClientArea");
            oXML.InitializeWriter();
            oXML.WriteProperty("DetectConflicts", mp_bDetectConflicts);
            oXML.WriteProperty("MilestoneSelectionOffset", mp_lMilestoneSelectionOffset);
            oXML.WriteProperty("ToolTipFormat", mp_sToolTipFormat);
            oXML.WriteProperty("ToolTipsVisible", mp_bToolTipsVisible);
            oXML.WriteProperty("PredecessorSelectionOffset", mp_lPredecessorSelectionOffset);
            oXML.WriteObject(Grid.GetXML());
            return oXML.GetXML();
        }

        public void SetXML(string sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "ClientArea");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            oXML.ReadProperty("DetectConflicts", ref mp_bDetectConflicts);
            oXML.ReadProperty("MilestoneSelectionOffset", ref mp_lMilestoneSelectionOffset);
            oXML.ReadProperty("ToolTipFormat", ref mp_sToolTipFormat);
            oXML.ReadProperty("ToolTipsVisible", ref mp_bToolTipsVisible);
            oXML.ReadProperty("PredecessorSelectionOffset", ref mp_lPredecessorSelectionOffset);
            Grid.SetXML(oXML.ReadObject("Grid"));
        }

	}

}
