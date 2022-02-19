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
	public class clsTask : clsItemBase
	{
		private ActiveGanttCSECtl mp_oControl;
		private bool mp_bAllowStretchLeft;
		private bool mp_bAllowStretchRight;
		private AGCSE.DateTime mp_dtEndDate;
		private AGCSE.DateTime mp_dtStartDate;
		private string mp_sText;
		private string mp_sLayerIndex;
		private Image mp_oImage;
		private string mp_sRowKey;
		private string mp_sStyleIndex;
		private clsStyle mp_oStyle;
		private string mp_sTag;
		private E_MOVEMENTTYPE mp_yAllowedMovement;
		private bool mp_bVisible;
		internal clsRow mp_oRow;
		private clsLayer mp_oLayer;
		private bool mp_bIncomingPredecessors;
		private bool mp_bOutgoingPredecessors;
        private string mp_sImageTag;
        internal double mp_lTextLeft;
        internal double mp_lTextTop;
        internal double mp_lTextRight;
        internal double mp_lTextBottom;
        private bool mp_bAllowTextEdit;
        internal bool mp_bWarning;
        private string mp_sWarningStyleIndex;
        private clsStyle mp_oWarningStyle;
        private E_TASKTYPE mp_yTaskType;
        private E_INTERVAL mp_yDurationInterval;
        private int mp_lDurationFactor;

		public clsTask(ActiveGanttCSECtl Value)
		{
			mp_oControl = Value;
			mp_bIncomingPredecessors = true;
			mp_bOutgoingPredecessors = true;
			mp_bAllowStretchLeft = true;
			mp_bAllowStretchRight = true;
			mp_dtEndDate = new AGCSE.DateTime();
            mp_dtEndDate.SetToCurrentDateTime();
			mp_dtStartDate = new AGCSE.DateTime();
            mp_dtStartDate.SetToCurrentDateTime();
			mp_sText = "";
			mp_sLayerIndex = "0";
			mp_oLayer = mp_oControl.Layers.FItem("0");
			mp_oImage = null;
			mp_sRowKey = "";
			mp_sStyleIndex = "DS_TASK";
			mp_oStyle = mp_oControl.Styles.FItem("DS_TASK");
			mp_sTag = "";
			mp_yAllowedMovement = E_MOVEMENTTYPE.MT_UNRESTRICTED;
			mp_bVisible = true;
            mp_sImageTag = "";
            mp_bAllowTextEdit = false;
            mp_bWarning = false;
            mp_sWarningStyleIndex = "";
            mp_yTaskType = E_TASKTYPE.TT_START_END;
            mp_yDurationInterval = E_INTERVAL.IL_HOUR;
            mp_lDurationFactor = 0;
		}

        public bool AllowTextEdit
        {
            get { return mp_bAllowTextEdit; }
            set { mp_bAllowTextEdit = value; }
        }

		public string Key 
		{
			get { return mp_sKey; }
			set { mp_oControl.Tasks.oCollection.mp_SetKey(ref mp_sKey, value, SYS_ERRORS.TASKS_SET_KEY); }
		}

		public bool IncomingPredecessors 
		{
			get { return mp_bIncomingPredecessors; }
			set { mp_bIncomingPredecessors = value; }
		}

		public bool OutgoingPredecessors 
		{
			get { return mp_bOutgoingPredecessors; }
			set { mp_bOutgoingPredecessors = value; }
		}

		public bool AllowStretchLeft 
		{
			get { return mp_bAllowStretchLeft; }
			set { mp_bAllowStretchLeft = value; }
		}

		public bool AllowStretchRight 
		{
			get { return mp_bAllowStretchRight; }
			set { mp_bAllowStretchRight = value; }
		}

		public string Text 
		{
			get { return mp_sText; }
			set { mp_sText = value; }
		}

		public string LayerIndex 
		{
			get { return mp_sLayerIndex; }
			set 
			{
				if (value.Trim() == "") 
				{
					value = "0";
				}
				mp_sLayerIndex = value;
				mp_oLayer = mp_oControl.Layers.FItem(value);
			}
		}

		public clsLayer Layer 
		{
			get { return mp_oLayer; }
		}

		public Image Image 
		{
			get { return mp_oImage; }
			set { mp_oImage = value; }
		}

		public string RowKey 
		{
			get { return mp_sRowKey; }
			set 
			{
				if (mp_oControl.Rows.oCollection.m_bDoesKeyExist(value) == false) 
				{
                    mp_oControl.mp_ErrorReport(SYS_ERRORS.INVALID_ROW_KEY, "Invalid Row Key (\"" + value + "\")", "ActiveGanttCSECtl.clsTask.Let RowKey");
					return;
				}
				mp_sRowKey = value;
				mp_oRow = mp_oControl.Rows.Item(mp_sRowKey);
			}
		}

		public clsRow Row 
		{
			get { return mp_oRow; }
		}

		public string StyleIndex 
		{
			get 
			{
				if (mp_sStyleIndex == "DS_TASK") 
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
				value = value.Trim();
                if (value.Length == 0) { value = "DS_TASK"; }
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

		public E_MOVEMENTTYPE AllowedMovement 
		{
			get { return mp_yAllowedMovement; }
			set { mp_yAllowedMovement = value; }
		}

		public int LeftTrim 
		{
			get 
			{
				if (Left < mp_oControl.Splitter.Right) 
				{
					return mp_oControl.Splitter.Right;
				}
				else 
				{
					return Left;
				}
			}
		}

		public int RightTrim 
		{
			get 
			{
				if (Right > mp_oControl.mt_RightMargin) 
				{
					return mp_oControl.mt_RightMargin;
				}
				else 
				{
					return Right;
				}
			}
		}

		internal bool f_bLeftVisible 
		{
			get 
			{
				if (LeftTrim == Left) 
				{
					return true;
				}
				else 
				{
					return false;
				}
			}
		}

		internal bool f_bRightVisible 
		{
			get 
			{
				if (RightTrim == Right) 
				{
					return true;
				}
				else 
				{
					return false;
				}
			}
		}

        public AGCSE.DateTime StartDate
        {
            get { return mp_dtStartDate; }
            set
            {
                mp_dtStartDate = value;
                if (mp_yTaskType == E_TASKTYPE.TT_DURATION & mp_lDurationFactor != 0)
                {
                    mp_GetDuration();
                }
            }
        }

        public int Left
        {
            get
            {
                if (mp_dtStartDate == mp_dtEndDate)
                {
                    return mp_oControl.MathLib.GetXCoordinateFromDate(StartDate) - mp_oControl.CurrentViewObject.ClientArea.MilestoneSelectionOffset;
                }
                else
                {
                    return mp_oControl.MathLib.GetXCoordinateFromDate(StartDate);
                }
            }
        }

        public int Right
        {
            get
            {
                if (mp_dtStartDate == mp_dtEndDate)
                {
                    return mp_oControl.MathLib.GetXCoordinateFromDate(EndDate) + mp_oControl.CurrentViewObject.ClientArea.MilestoneSelectionOffset;
                }
                else
                {
                    return mp_oControl.MathLib.GetXCoordinateFromDate(EndDate);
                }
            }
        }

        public AGCSE.DateTime EndDate
        {
            get { return mp_dtEndDate; }
            set
            {
                if (mp_yTaskType == E_TASKTYPE.TT_START_END)
                {
                    mp_dtEndDate = value;
                }
            }
        }

		public int Top 
		{
			get 
			{
				if ((mp_oRow.Height <= -1)) 
				{
					return mp_oRow.Top;
				}
				if (mp_oStyle.Placement == E_PLACEMENT.PLC_ROWEXTENTSPLACEMENT | mp_oStyle.Appearance == E_STYLEAPPEARANCE.SA_CELL) 
				{
					return mp_oRow.Top;
				}
				if (mp_oStyle.Placement == E_PLACEMENT.PLC_OFFSETPLACEMENT) 
				{
					return mp_oRow.Top + mp_oStyle.OffsetTop;
				}
				return 0;
			}
		}

		public int Bottom 
		{
			get 
			{
				if ((mp_oRow.Height <= -1)) 
				{
					return mp_oRow.Top;
				}
				if (mp_oStyle.Placement == E_PLACEMENT.PLC_ROWEXTENTSPLACEMENT | mp_oStyle.Appearance == E_STYLEAPPEARANCE.SA_CELL) 
				{
					return mp_oRow.Bottom - 1;
				}
				if (mp_oStyle.Placement == E_PLACEMENT.PLC_OFFSETPLACEMENT) 
				{
					return mp_oRow.Top + mp_oStyle.OffsetTop + mp_oStyle.OffsetBottom;
				}
				return 0;
			}
		}


		public bool Visible 
		{
			get 
			{
				if (mp_oLayer.Visible == false) 
				{
					return false;
				}
				if ((mp_oRow.Height <= -1)) 
				{
					return false;
				}
				if (mp_oRow.Visible == false) 
				{
					return false;
				}
				return mp_bVisible;
			}
			set { mp_bVisible = value; }
		}

        internal bool InsideVisibleTimeLineArea
        {
            get
            {
                if (StartDate > mp_oControl.CurrentViewObject.TimeLine.EndDate)
                {
                    return false;
                }
                if (EndDate < mp_oControl.CurrentViewObject.TimeLine.StartDate)
                {
                    return false;
                }
                return true;
            }
        }

        internal E_CLIENTAREAVISIBILITY ClientAreaVisiblity
        {
            get
            {
                if (StartDate > mp_oControl.CurrentViewObject.TimeLine.EndDate)
                {
                    return E_CLIENTAREAVISIBILITY.VS_RIGHTOFVISIBLEAREA;
                }
                if (EndDate < mp_oControl.CurrentViewObject.TimeLine.StartDate)
                {
                    return E_CLIENTAREAVISIBILITY.VS_LEFTOFVISIBLEAREA;
                }
                return E_CLIENTAREAVISIBILITY.VS_INSIDEVISIBLEAREA;
            }
        }

		public E_OBJECTTYPE Type 
		{
			get 
			{
                if (mp_yTaskType == E_TASKTYPE.TT_DURATION & mp_lDurationFactor == 0)
                {
                    return E_OBJECTTYPE.OT_MILESTONE;
                }
				if (StartDate == EndDate) 
				{
					return E_OBJECTTYPE.OT_MILESTONE;
				}
				else 
				{
					return E_OBJECTTYPE.OT_TASK;
				}
			}
		}

		public bool InConflict()
		{
			return mp_oControl.MathLib.DetectConflict(StartDate, EndDate, mp_sRowKey, Index, mp_sLayerIndex);
		}

        public string ImageTag
        {
            get { return mp_sImageTag; }
            set { mp_sImageTag = value; }
        }

        public bool Warning
        {
            get
            {
                if (mp_oControl.Predecessors.Count == 0)
                {
                    return false;
                }
                else
                {
                    return mp_bWarning;
                }
            }
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

        public E_TASKTYPE TaskType
        {
            get { return mp_yTaskType; }
            set
            {
                mp_yTaskType = value;
                if (mp_yTaskType == E_TASKTYPE.TT_DURATION)
                {
                    mp_GetDuration();
                }
            }
        }

        public E_INTERVAL DurationInterval
        {
            get { return mp_yDurationInterval; }
            set
            {
                if (!(value == E_INTERVAL.IL_SECOND | value == E_INTERVAL.IL_MINUTE | value == E_INTERVAL.IL_HOUR | value == E_INTERVAL.IL_DAY))
                {
                    mp_oControl.mp_ErrorReport(SYS_ERRORS.INVALID_DURATION_INTERVAL, "Interval is invalid for a duration", "clsTask.Set_DurationInterval");
                    return;
                }
                mp_yDurationInterval = value;
                if (mp_yTaskType == E_TASKTYPE.TT_DURATION)
                {
                    mp_GetDuration();
                }
            }
        }

        public int DurationFactor
        {
            get { return mp_lDurationFactor; }
            set
            {
                if (value < 0)
                {
                    value = value * -1;
                }
                mp_lDurationFactor = value;
                if (mp_yTaskType == E_TASKTYPE.TT_DURATION)
                {
                    mp_GetDuration();
                }
            }
        }

        private void mp_GetDuration()
        {
            mp_dtEndDate = mp_oControl.MathLib.GetEndDate(ref mp_dtStartDate, mp_yDurationInterval, mp_lDurationFactor);
        }

        public string GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "Task");
            oXML.InitializeWriter();
            oXML.WriteProperty("AllowedMovement", mp_yAllowedMovement);
            oXML.WriteProperty("AllowStretchLeft", mp_bAllowStretchLeft);
            oXML.WriteProperty("AllowStretchRight", mp_bAllowStretchRight);
            oXML.WriteProperty("EndDate", mp_dtEndDate);
            oXML.WriteProperty("Image", mp_oImage);
            oXML.WriteProperty("IncomingPredecessors", mp_bIncomingPredecessors);
            oXML.WriteProperty("Key", mp_sKey);
            oXML.WriteProperty("LayerIndex", mp_sLayerIndex);
            oXML.WriteProperty("OutgoingPredecessors", mp_bOutgoingPredecessors);
            oXML.WriteProperty("RowKey", mp_sRowKey);
            oXML.WriteProperty("StartDate", mp_dtStartDate);
            oXML.WriteProperty("StyleIndex", mp_sStyleIndex);
            oXML.WriteProperty("Tag", mp_sTag);
            oXML.WriteProperty("Text", mp_sText);
            oXML.WriteProperty("Visible", mp_bVisible);
            oXML.WriteProperty("ImageTag", mp_sImageTag);
            oXML.WriteProperty("AllowTextEdit", mp_bAllowTextEdit);
            oXML.WriteProperty("WarningStyleIndex", mp_sWarningStyleIndex);
            oXML.WriteProperty("TaskType", mp_yTaskType);
            oXML.WriteProperty("DurationInterval", mp_yDurationInterval);
            oXML.WriteProperty("DurationFactor", mp_lDurationFactor);
            return oXML.GetXML();
        }


        public void SetXML(string sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "Task");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            oXML.ReadProperty("AllowedMovement", ref mp_yAllowedMovement);
            oXML.ReadProperty("AllowStretchLeft", ref mp_bAllowStretchLeft);
            oXML.ReadProperty("AllowStretchRight", ref mp_bAllowStretchRight);
            oXML.ReadProperty("EndDate", ref mp_dtEndDate);
            oXML.ReadProperty("Image", ref mp_oImage);
            oXML.ReadProperty("IncomingPredecessors", ref mp_bIncomingPredecessors);
            oXML.ReadProperty("Key", ref mp_sKey);
            oXML.ReadProperty("LayerIndex", ref mp_sLayerIndex);
            mp_oLayer = mp_oControl.Layers.FItem(mp_sLayerIndex);
            oXML.ReadProperty("OutgoingPredecessors", ref mp_bOutgoingPredecessors);
            oXML.ReadProperty("RowKey", ref mp_sRowKey);
            mp_oRow = mp_oControl.Rows.Item(mp_sRowKey);
            oXML.ReadProperty("StartDate", ref mp_dtStartDate);
            oXML.ReadProperty("StyleIndex", ref mp_sStyleIndex);
            StyleIndex = mp_sStyleIndex;
            oXML.ReadProperty("Tag", ref mp_sTag);
            oXML.ReadProperty("Text", ref mp_sText);
            oXML.ReadProperty("Visible", ref mp_bVisible);
            oXML.ReadProperty("ImageTag", ref mp_sImageTag);
            oXML.ReadProperty("AllowTextEdit", ref mp_bAllowTextEdit);
            oXML.ReadProperty("WarningStyleIndex", ref mp_sWarningStyleIndex);
            WarningStyleIndex = mp_sWarningStyleIndex;
            oXML.ReadProperty("TaskType", ref mp_yTaskType);
            oXML.ReadProperty("DurationInterval", ref mp_yDurationInterval);
            oXML.ReadProperty("DurationFactor", ref mp_lDurationFactor);
        }


	}
}
