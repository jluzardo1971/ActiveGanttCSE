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
	public class clsPredecessor : clsItemBase
	{
    
		private ActiveGanttCSECtl mp_oControl;
		private bool mp_bVisible;
		private clsPredecessors mp_clsPredecessors;
        private String mp_sSuccessorKey;
        internal clsTask mp_oSuccessorTask;
        private String mp_sPredecessorKey;
        internal clsTask mp_oPredecessorTask;
		private string mp_sStyleIndex;
		private string mp_sTag;
		private E_CONSTRAINTTYPE mp_yPredecessorType;
		private clsStyle mp_oStyle;
        private E_INTERVAL mp_yLagInterval;
        private int mp_lLagFactor;
        private ArrayList mp_oRectangles;
        internal bool mp_bWarning;
        private string mp_sWarningStyleIndex;
        private clsStyle mp_oWarningStyle;
        private string mp_sSelectedStyleIndex;
        private clsStyle mp_oSelectedStyle;
    
		internal clsPredecessor(ActiveGanttCSECtl Value, clsPredecessors oPredecessors)
		{
			mp_oControl = Value;
			mp_bVisible = true;
			mp_clsPredecessors = oPredecessors;
			mp_sPredecessorKey = "";
            mp_sSuccessorKey = "";
			mp_sStyleIndex = "DS_PREDECESSOR";
			mp_oStyle = mp_oControl.Styles.FItem("DS_PREDECESSOR");
			mp_sTag = "";
            mp_yLagInterval = E_INTERVAL.IL_DAY;
            mp_lLagFactor = 0;
            mp_oRectangles = new ArrayList();
            mp_bWarning = false;
            mp_sWarningStyleIndex = "";
            mp_sSelectedStyleIndex = "";
		}
    
		public string Key 
		{
			get { return mp_sKey; }
			set { mp_clsPredecessors.oCollection.mp_SetKey(ref mp_sKey, value, SYS_ERRORS.PREDECESSORS_SET_KEY); }
		}
    
		public bool Visible 
		{
			get { return mp_bVisible; }
			set { mp_bVisible = value; }
		}
    
		public string PredecessorKey 
		{
			get { return mp_sPredecessorKey; }
			set 
			{
				mp_sPredecessorKey = value;
				mp_oPredecessorTask = mp_oControl.Tasks.Item(value);
			}
		}
    
		public clsTask PredecessorTask 
		{
			get { return mp_oPredecessorTask; }
		}
    
		public E_CONSTRAINTTYPE PredecessorType 
		{
			get { return mp_yPredecessorType; }
			set { mp_yPredecessorType = value; }
		}
    
		public string StyleIndex 
		{
			get 
			{
				if (mp_sStyleIndex == "DS_PREDECESSOR") 
				{
					return "";
				}
				else 
				{
					return mp_sStyleIndex;
				}
			}
			set 
			{
				if (value.Trim() == "") value = "DS_PREDECESSOR"; 
				mp_sStyleIndex = value;
				mp_oStyle = mp_oControl.Styles.FItem(value);
			}
		}
    
		public clsStyle Style 
		{
			get { return mp_oStyle; }
		}
    
		public string Tag 
		{
			get { return mp_sTag; }
			set { mp_sTag = value; }
		}

        public string SuccessorKey
        {
            get { return mp_sSuccessorKey; }
            set
            {
                mp_sSuccessorKey = value;
                mp_oSuccessorTask = mp_oControl.Tasks.Item(value);
            }
        }

        public clsTask SuccessorTask
        {
            get { return mp_oSuccessorTask; }
        }

        public E_INTERVAL LagInterval
        {
            get { return mp_yLagInterval; }
            set { mp_yLagInterval = value; }
        }

        public int LagFactor
        {
            get { return mp_lLagFactor; }
            set { mp_lLagFactor = value; }
        }

        internal void AddRectangle(S_Rectangle oRectangle)
        {
            mp_oRectangles.Add(oRectangle);
        }

        internal void ClearRectangles()
        {
            mp_oRectangles.Clear();
        }

        internal bool HitTest(int X, int Y)
        {
            int i = 0;
            for (i = 0; i <= mp_oRectangles.Count - 1; i++)
            {
                S_Rectangle oRectangle;
                oRectangle = (S_Rectangle)mp_oRectangles[i];
                if (oRectangle.mp_bInRect(X, Y) == true)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Warning
        {
            get { return mp_bWarning; }
        }

        public string WarningStyleIndex
        {
            get { return mp_sWarningStyleIndex; }
            set
            {
                value = value.Trim();
                mp_sWarningStyleIndex = value;
                if (value.Length > 0)
                {
                    mp_oWarningStyle = mp_oControl.Styles.FItem(value);
                }
                else
                {
                    mp_oWarningStyle = null;
                }
            }
        }

        public clsStyle WarningStyle
        {
            get
            {
                if (mp_sWarningStyleIndex.Length == 0)
                {
                    return mp_oStyle;
                }
                else
                {
                    return mp_oWarningStyle;
                }
            }
        }

        public string SelectedStyleIndex
        {
            get { return mp_sSelectedStyleIndex; }
            set
            {
                value = value.Trim();
                mp_sSelectedStyleIndex = value;
                if (value.Length > 0)
                {
                    mp_oSelectedStyle = mp_oControl.Styles.FItem(value);
                }
                else
                {
                    mp_oSelectedStyle = null;
                }
            }
        }

        public clsStyle SelectedStyle
        {
            get
            {
                if (mp_sSelectedStyleIndex.Length == 0)
                {
                    return mp_oStyle;
                }
                else
                {
                    return mp_oSelectedStyle;
                }
            }
        }

        public void Check(E_PREDECESSORMODE Mode)
        {
            AGCSE.DateTime dtPredecessor = new AGCSE.DateTime();
            AGCSE.DateTime dtSuccessor = new AGCSE.DateTime();
            int lDiff = 0;
            int lDuration = 0;
            mp_bWarning = false;
            switch (mp_yPredecessorType)
            {
                case E_CONSTRAINTTYPE.PCT_START_TO_START:
                    dtPredecessor = mp_oPredecessorTask.StartDate;
                    dtSuccessor = mp_oSuccessorTask.StartDate;
                    lDiff = mp_oControl.MathLib.DateTimeDiff(mp_yLagInterval, dtPredecessor, dtSuccessor);
                    if (lDiff != mp_lLagFactor & Mode == E_PREDECESSORMODE.PM_FORCE)
                    {
                        lDuration = mp_oControl.MathLib.DateTimeDiff(mp_oControl.CurrentViewObject.Interval, mp_oSuccessorTask.StartDate, mp_oSuccessorTask.EndDate);
                        mp_oSuccessorTask.StartDate = mp_oControl.MathLib.DateTimeAdd(mp_yLagInterval, mp_lLagFactor, mp_oPredecessorTask.StartDate);
                        mp_oSuccessorTask.EndDate = mp_oControl.MathLib.DateTimeAdd(mp_yLagInterval, lDuration, mp_oSuccessorTask.StartDate);
                    }
                    break;
                case E_CONSTRAINTTYPE.PCT_END_TO_END:
                    dtPredecessor = mp_oPredecessorTask.EndDate;
                    dtSuccessor = mp_oSuccessorTask.EndDate;
                    lDiff = mp_oControl.MathLib.DateTimeDiff(mp_yLagInterval, dtPredecessor, dtSuccessor);
                    if (lDiff != mp_lLagFactor & Mode == E_PREDECESSORMODE.PM_FORCE)
                    {
                        lDuration = mp_oControl.MathLib.DateTimeDiff(mp_oControl.CurrentViewObject.Interval, mp_oSuccessorTask.StartDate, mp_oSuccessorTask.EndDate);
                        mp_oSuccessorTask.EndDate = mp_oControl.MathLib.DateTimeAdd(mp_yLagInterval, mp_lLagFactor, mp_oPredecessorTask.EndDate);
                        mp_oSuccessorTask.StartDate = mp_oControl.MathLib.DateTimeAdd(mp_yLagInterval, -lDuration, mp_oSuccessorTask.EndDate);
                    }
                    break;
                case E_CONSTRAINTTYPE.PCT_START_TO_END:
                    dtPredecessor = mp_oPredecessorTask.StartDate;
                    dtSuccessor = mp_oSuccessorTask.EndDate;
                    lDiff = mp_oControl.MathLib.DateTimeDiff(mp_yLagInterval, dtPredecessor, dtSuccessor);
                    if (lDiff != mp_lLagFactor & Mode == E_PREDECESSORMODE.PM_FORCE)
                    {
                        lDuration = mp_oControl.MathLib.DateTimeDiff(mp_oControl.CurrentViewObject.Interval, mp_oSuccessorTask.StartDate, mp_oSuccessorTask.EndDate);
                        mp_oSuccessorTask.EndDate = mp_oControl.MathLib.DateTimeAdd(mp_yLagInterval, mp_lLagFactor, mp_oPredecessorTask.StartDate);
                        mp_oSuccessorTask.StartDate = mp_oControl.MathLib.DateTimeAdd(mp_yLagInterval, -lDuration, mp_oSuccessorTask.EndDate);
                    }
                    break;
                case E_CONSTRAINTTYPE.PCT_END_TO_START:
                    dtPredecessor = mp_oPredecessorTask.EndDate;
                    dtSuccessor = mp_oSuccessorTask.StartDate;
                    lDiff = mp_oControl.MathLib.DateTimeDiff(mp_yLagInterval, dtPredecessor, dtSuccessor);
                    if (lDiff != mp_lLagFactor & Mode == E_PREDECESSORMODE.PM_FORCE)
                    {
                        lDuration = mp_oControl.MathLib.DateTimeDiff(mp_oControl.CurrentViewObject.Interval, mp_oSuccessorTask.StartDate, mp_oSuccessorTask.EndDate);
                        mp_oSuccessorTask.StartDate = mp_oControl.MathLib.DateTimeAdd(mp_yLagInterval, mp_lLagFactor, mp_oPredecessorTask.EndDate);
                        mp_oSuccessorTask.EndDate = mp_oControl.MathLib.DateTimeAdd(mp_yLagInterval, lDuration, mp_oSuccessorTask.StartDate);
                    }
                    break;
            }
            if (lDiff != mp_lLagFactor & Mode == E_PREDECESSORMODE.PM_CREATEWARNINGFLAG)
            {
                mp_bWarning = true;
                mp_oSuccessorTask.mp_bWarning = true;
            }
            else if (lDiff != mp_lLagFactor & Mode == E_PREDECESSORMODE.PM_RAISEEVENT)
            {
                mp_oControl.PredecessorExceptionEventArgs.Clear();
                mp_oControl.PredecessorExceptionEventArgs.PredecessorIndex = this.Index;
                mp_oControl.PredecessorExceptionEventArgs.PredecessorType = this.PredecessorType;
                mp_oControl.FirePredecessorException();
            }
        }


        public string GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "Predecessor");
            oXML.InitializeWriter();
            oXML.WriteProperty("Key", mp_sKey);
            oXML.WriteProperty("SuccessorKey", mp_sSuccessorKey);
            oXML.WriteProperty("PredecessorKey", mp_sPredecessorKey);
            oXML.WriteProperty("PredecessorType", mp_yPredecessorType);
            oXML.WriteProperty("StyleIndex", mp_sStyleIndex);
            oXML.WriteProperty("Tag", mp_sTag);
            oXML.WriteProperty("Visible", mp_bVisible);
            oXML.WriteProperty("LagInterval", mp_yLagInterval);
            oXML.WriteProperty("LagFactor", mp_lLagFactor);
            oXML.WriteProperty("WarningStyleIndex", mp_sWarningStyleIndex);
            oXML.WriteProperty("SelectedStyleIndex", mp_sSelectedStyleIndex);
            return oXML.GetXML();
        }


        public void SetXML(string sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "Predecessor");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            oXML.ReadProperty("Key", ref mp_sKey);
            oXML.ReadProperty("SuccessorKey", ref mp_sSuccessorKey);
            mp_oSuccessorTask = mp_oControl.Tasks.Item(mp_sSuccessorKey);
            oXML.ReadProperty("PredecessorKey", ref mp_sPredecessorKey);
            mp_oPredecessorTask = mp_oControl.Tasks.Item(mp_sPredecessorKey);
            oXML.ReadProperty("PredecessorType", ref mp_yPredecessorType);
            oXML.ReadProperty("StyleIndex", ref mp_sStyleIndex);
            StyleIndex = mp_sStyleIndex;
            oXML.ReadProperty("Tag", ref mp_sTag);
            oXML.ReadProperty("Visible", ref mp_bVisible);
            oXML.ReadProperty("LagInterval", ref mp_yLagInterval);
            oXML.ReadProperty("LagFactor", ref mp_lLagFactor);
            oXML.ReadProperty("WarningStyleIndex", ref mp_sWarningStyleIndex);
            WarningStyleIndex = mp_sWarningStyleIndex;
            oXML.ReadProperty("SelectedStyleIndex", ref mp_sSelectedStyleIndex);
            SelectedStyleIndex = mp_sSelectedStyleIndex;
        }
    
	}
}
