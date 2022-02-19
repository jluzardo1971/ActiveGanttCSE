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

	public class clsTimeBlock : clsItemBase
	{
    
		private ActiveGanttCSECtl mp_oControl;
		private string mp_sStyleIndex;
		private string mp_sTag;
		private bool mp_bGenerateConflict;
		private bool mp_bVisible;
		private clsStyle mp_oStyle;
		private E_TIMEBLOCKTYPE mp_yTimeBlockType;
		private E_RECURRINGTYPE mp_yRecurringType;
        private E_WEEKDAY mp_yBaseWeekDay;
        private AGCSE.DateTime mp_dtBaseDate;
        private E_INTERVAL mp_yDurationInterval;
        private int mp_lDurationFactor;
        private bool mp_bNonWorking;
    
		internal clsTimeBlock(ActiveGanttCSECtl Value)
		{
			mp_oControl = Value;
			mp_sStyleIndex = "DS_TIMEBLOCK";
			mp_oStyle = mp_oControl.Styles.FItem("DS_TIMEBLOCK");
			mp_sTag = "";
			mp_bGenerateConflict = false;
			mp_yTimeBlockType = E_TIMEBLOCKTYPE.TBT_SINGLE_OCURRENCE;
            mp_yRecurringType = E_RECURRINGTYPE.RCT_DAY;
			mp_bVisible = true;
            mp_yBaseWeekDay = E_WEEKDAY.WD_SUNDAY;
            mp_dtBaseDate = new AGCSE.DateTime();
            mp_dtBaseDate.SetToCurrentDateTime();
            mp_yDurationInterval = E_INTERVAL.IL_HOUR;
            mp_lDurationFactor = 1;
            mp_bNonWorking = false;
		}
    
		public string Key 
		{
			get { return mp_sKey; }
			set { mp_oControl.TimeBlocks.oCollection.mp_SetKey(ref mp_sKey, value, SYS_ERRORS.TIMEBLOCKS_SET_KEY); }
		}
    
		public E_TIMEBLOCKTYPE TimeBlockType 
		{
			get { return mp_yTimeBlockType; }
			set { mp_yTimeBlockType = value; }
		}
    
		public E_RECURRINGTYPE RecurringType 
		{
			get { return mp_yRecurringType; }
			set { mp_yRecurringType = value; }
		}

        public AGCSE.DateTime EndDate
        {
            get
            {
                if (mp_lDurationFactor > 0)
                {
                    return mp_oControl.MathLib.DateTimeAdd(mp_yDurationInterval, mp_lDurationFactor, mp_dtBaseDate);
                }
                else
                {
                    return mp_dtBaseDate;
                }
            }
        }

        public AGCSE.DateTime StartDate
        {
            get
            {
                if (mp_lDurationFactor > 0)
                {
                    return mp_dtBaseDate;
                }
                else
                {
                    return mp_oControl.MathLib.DateTimeAdd(mp_yDurationInterval, mp_lDurationFactor, mp_dtBaseDate);
                }
            }
        }
    
		public string StyleIndex 
		{
			get 
			{
				if (mp_sStyleIndex == "DS_TIMEBLOCK") 
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
				if (value.Trim() == "") value = "DS_TIMEBLOCK"; 
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
    
		public bool GenerateConflict 
		{
			get { return mp_bGenerateConflict; }
			set { mp_bGenerateConflict = value; }
		}
    
		public int LeftTrim 
		{
			get 
			{
				if (mp_yTimeBlockType == E_TIMEBLOCKTYPE.TBT_SINGLE_OCURRENCE) 
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
				else 
				{
					return 0;
				}
			}
		}
    
		public int RightTrim 
		{
			get 
			{
				if (mp_yTimeBlockType == E_TIMEBLOCKTYPE.TBT_SINGLE_OCURRENCE) 
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
				else 
				{
					return 0;
				}
			}
		}

        public int Left
        {
            get
            {
                if (mp_yTimeBlockType == E_TIMEBLOCKTYPE.TBT_SINGLE_OCURRENCE)
                {
                    return mp_oControl.MathLib.GetXCoordinateFromDate(StartDate);
                }
                else
                {
                    return 0;
                }
            }
        }

        public int Top
        {
            get { return mp_oControl.CurrentViewObject.ClientArea.Top; }
        }

        public int Right
        {
            get
            {
                if (mp_yTimeBlockType == E_TIMEBLOCKTYPE.TBT_SINGLE_OCURRENCE)
                {
                    return mp_oControl.MathLib.GetXCoordinateFromDate(EndDate);
                }
                else
                {
                    return 0;
                }
            }
        }

        public int Bottom
        {
            get
            {
                if (mp_oControl.TimeBlockBehaviour == E_TIMEBLOCKBEHAVIOUR.TBB_CONTROLEXTENTS)
                {
                    return mp_oControl.mt_BottomMargin;
                }
                else if (mp_oControl.Rows.Count > 0)
                {
                    return mp_oControl.Rows.Item(mp_oControl.CurrentViewObject.ClientArea.LastVisibleRow.ToString()).Bottom;
                }
                else
                {
                    return mp_oControl.CurrentViewObject.ClientArea.Top;
                }
            }
        }
    
		internal bool f_Visible 
		{
			get { return mp_bVisible; }
			set { mp_bVisible = value; }
		}

        public bool Visible
        {
            get
            {
                if (mp_oControl.Rows.Count == 0)
                {
                    return false;
                }
                if (mp_yTimeBlockType == E_TIMEBLOCKTYPE.TBT_RECURRING)
                {
                    return false;
                }
                AGCSE.DateTime dtStartDate;
                AGCSE.DateTime dtEndDate;
                dtStartDate = StartDate;
                dtEndDate = EndDate;
                if ((((dtStartDate >= mp_oControl.CurrentViewObject.TimeLine.StartDate & dtStartDate <= mp_oControl.CurrentViewObject.TimeLine.EndDate) | (dtEndDate >= mp_oControl.CurrentViewObject.TimeLine.StartDate & dtEndDate <= mp_oControl.CurrentViewObject.TimeLine.EndDate)) | (dtStartDate < mp_oControl.CurrentViewObject.TimeLine.StartDate & dtEndDate > mp_oControl.CurrentViewObject.TimeLine.EndDate)))
                {
                    return mp_bVisible;
                }
                else
                {
                    return false;
                }
            }
            set { mp_bVisible = value; }
        }

        public AGCSE.DateTime BaseDate
        {
            get { return mp_dtBaseDate; }
            set { mp_dtBaseDate = value; }
        }

        public E_WEEKDAY BaseWeekDay
        {
            get { return mp_yBaseWeekDay; }
            set { mp_yBaseWeekDay = value; }
        }

        public E_INTERVAL DurationInterval
        {
            get { return mp_yDurationInterval; }
            set { mp_yDurationInterval = value; }
        }

        public int DurationFactor
        {
            get { return mp_lDurationFactor; }
            set { mp_lDurationFactor = value; }
        }

        public bool NonWorking
        {
            get { return mp_bNonWorking; }
            set { mp_bNonWorking = value; }
        }

        public string GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "TimeBlock");
            oXML.InitializeWriter();
            oXML.WriteProperty("GenerateConflict", mp_bGenerateConflict);
            oXML.WriteProperty("Key", mp_sKey);
            oXML.WriteProperty("RecurringType", mp_yRecurringType);
            oXML.WriteProperty("StyleIndex", mp_sStyleIndex);
            oXML.WriteProperty("Tag", mp_sTag);
            oXML.WriteProperty("TimeBlockType", mp_yTimeBlockType);
            oXML.WriteProperty("Visible", mp_bVisible);
            oXML.WriteProperty("BaseDate", mp_dtBaseDate);
            oXML.WriteProperty("BaseWeekDay", mp_yBaseWeekDay);
            oXML.WriteProperty("DurationInterval", mp_yDurationInterval);
            oXML.WriteProperty("DurationFactor", mp_lDurationFactor);
            oXML.WriteProperty("NonWorking", mp_bNonWorking);
            return oXML.GetXML();
        }


        public void SetXML(string sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "TimeBlock");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            oXML.ReadProperty("GenerateConflict", ref mp_bGenerateConflict);
            oXML.ReadProperty("Key", ref mp_sKey);
            oXML.ReadProperty("RecurringType", ref mp_yRecurringType);
            oXML.ReadProperty("StyleIndex", ref mp_sStyleIndex);
            StyleIndex = mp_sStyleIndex;
            oXML.ReadProperty("Tag", ref mp_sTag);
            oXML.ReadProperty("TimeBlockType", ref mp_yTimeBlockType);
            oXML.ReadProperty("Visible", ref mp_bVisible);
            oXML.ReadProperty("BaseDate", ref mp_dtBaseDate);
            oXML.ReadProperty("BaseWeekDay", ref mp_yBaseWeekDay);
            oXML.ReadProperty("DurationInterval", ref mp_yDurationInterval);
            oXML.ReadProperty("DurationFactor", ref mp_lDurationFactor);
            oXML.ReadProperty("NonWorking", ref mp_bNonWorking);
        }
    
	}


}
