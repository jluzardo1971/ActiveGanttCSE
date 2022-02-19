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
	public class clsTimeBlocks
	{
    
		private ActiveGanttCSECtl mp_oControl;
		private clsCollectionBase mp_oCollection;
        internal ArrayList mp_aTimeBlocks;
        private AGCSE.DateTime mp_dtIntervalStart;
        private AGCSE.DateTime mp_dtIntervalEnd;
        private E_TBINTERVALTYPE mp_yIntervalType;
    
		internal clsTimeBlocks(ActiveGanttCSECtl Value)
		{
			mp_oControl = Value;
			mp_oCollection = new clsCollectionBase(Value, "TimeBlock");
            mp_dtIntervalStart = new AGCSE.DateTime();
            mp_dtIntervalEnd = new AGCSE.DateTime();
            mp_yIntervalType = E_TBINTERVALTYPE.TBIT_AUTOMATIC;
		}
    
		public int Count 
		{
			get { return mp_oCollection.m_lCount(); }
		}
    
		public clsTimeBlock Item(string Index)
		{
			return (clsTimeBlock)mp_oCollection.m_oItem(Index, SYS_ERRORS.TIMEBLOCKS_ITEM_1, SYS_ERRORS.TIMEBLOCKS_ITEM_2, SYS_ERRORS.TIMEBLOCKS_ITEM_3, SYS_ERRORS.TIMEBLOCKS_ITEM_4);
		}
    
		internal clsCollectionBase oCollection 
		{
			get { return mp_oCollection; }
		}
    
		public clsTimeBlock Add(string Key)
		{
			mp_oCollection.AddMode = true;
			clsTimeBlock oTimeBlock = new clsTimeBlock(mp_oControl);
			Key = mp_oControl.StrLib.StrTrim(Key);
			oTimeBlock.Key = Key;
			mp_oCollection.m_Add(oTimeBlock, Key, SYS_ERRORS.TIMEBLOCKS_ADD_1, SYS_ERRORS.TIMEBLOCKS_ADD_2, false, SYS_ERRORS.TIMEBLOCKS_ADD_3);
			return oTimeBlock;
		}
    
		public void Clear()
		{
			mp_oCollection.m_Clear();
		}
    
		public void Remove(string Index)
		{
			mp_oCollection.m_Remove(Index, SYS_ERRORS.TIMEBLOCKS_REMOVE_1, SYS_ERRORS.TIMEBLOCKS_REMOVE_2, SYS_ERRORS.TIMEBLOCKS_REMOVE_3, SYS_ERRORS.TIMEBLOCKS_REMOVE_4);
		}

        internal void CreateTemporaryTimeBlocks()
        {
            int lIndex = 0;
            mp_oControl.TempTimeBlocks().Clear();

            for (lIndex = 1; lIndex <= Count; lIndex++)
            {
                clsTimeBlock oTimeBlock = null;
                clsTimeBlock oTempTimeBlock = null;
                AGCSE.DateTime dtTimeLineStart = new AGCSE.DateTime();
                AGCSE.DateTime dtTimeLineEnd = new AGCSE.DateTime();
                AGCSE.DateTime dtCurrent = new AGCSE.DateTime();
                AGCSE.DateTime dtStartBuff = new AGCSE.DateTime();
                AGCSE.DateTime dtEndBuff = new AGCSE.DateTime();
                AGCSE.DateTime dtBase;
                AGCSE.DateTime dtStartDate = new AGCSE.DateTime();
                AGCSE.DateTime dtEndDate = new AGCSE.DateTime();
                oTimeBlock = (clsTimeBlock)mp_oCollection.m_oReturnArrayElement(lIndex);
                if (oTimeBlock.TimeBlockType == E_TIMEBLOCKTYPE.TBT_RECURRING)
                {
                    dtTimeLineStart = mp_oControl.CurrentViewObject.TimeLine.StartDate;
                    dtTimeLineEnd = mp_oControl.CurrentViewObject.TimeLine.EndDate;
                    switch (oTimeBlock.RecurringType)
                    {
                        case E_RECURRINGTYPE.RCT_DAY:
                            dtTimeLineStart = mp_oControl.MathLib.DateTimeAdd(E_INTERVAL.IL_DAY, -1, dtTimeLineStart);
                            dtCurrent = new AGCSE.DateTime(dtTimeLineStart.Year(), dtTimeLineStart.Month(), dtTimeLineStart.Day(), 0, 0, 0);
                            while (dtCurrent < dtTimeLineEnd)
                            {
                                dtBase = new AGCSE.DateTime(dtCurrent.Year(), dtCurrent.Month(), dtCurrent.Day(), oTimeBlock.BaseDate.Hour(), oTimeBlock.BaseDate.Minute(), oTimeBlock.BaseDate.Second());
                                dtCurrent = mp_oControl.MathLib.DateTimeAdd(E_INTERVAL.IL_DAY, 1, dtCurrent);
                                if (mp_oControl.MathLib.mp_DateBlockVisible(dtTimeLineStart, dtTimeLineEnd, dtBase, oTimeBlock.DurationInterval, oTimeBlock.DurationFactor))
                                {
                                    oTempTimeBlock = mp_oControl.TempTimeBlocks().Add("");
                                    oTempTimeBlock.BaseDate = dtBase;
                                    oTempTimeBlock.DurationInterval = oTimeBlock.DurationInterval;
                                    oTempTimeBlock.DurationFactor = oTimeBlock.DurationFactor;
                                    CopyTimeBlock(oTempTimeBlock, oTimeBlock);
                                }
                            }
                            break;
                        case E_RECURRINGTYPE.RCT_WEEK:
                            dtTimeLineStart = mp_oControl.MathLib.DateTimeAdd(E_INTERVAL.IL_DAY, -7, dtTimeLineStart);
                            dtCurrent = new AGCSE.DateTime(dtTimeLineStart.Year(), dtTimeLineStart.Month(), dtTimeLineStart.Day(), 0, 0, 0);
                            while (dtCurrent < dtTimeLineEnd)
                            {
                                dtBase = new AGCSE.DateTime(dtCurrent.Year(), dtCurrent.Month(), dtCurrent.Day(), oTimeBlock.BaseDate.Hour(), oTimeBlock.BaseDate.Minute(), oTimeBlock.BaseDate.Second());
                                dtCurrent = mp_oControl.MathLib.DateTimeAdd(E_INTERVAL.IL_DAY, 1, dtCurrent);
                                if (System.Convert.ToInt32(oTimeBlock.BaseWeekDay) == System.Convert.ToInt32(dtBase.DayOfWeek()))
                                {
                                    if (mp_oControl.MathLib.mp_DateBlockVisible(dtTimeLineStart, dtTimeLineEnd, dtBase, oTimeBlock.DurationInterval, oTimeBlock.DurationFactor))
                                    {
                                        oTempTimeBlock = mp_oControl.TempTimeBlocks().Add("");
                                        oTempTimeBlock.BaseDate = dtBase;
                                        oTempTimeBlock.DurationInterval = oTimeBlock.DurationInterval;
                                        oTempTimeBlock.DurationFactor = oTimeBlock.DurationFactor;
                                        CopyTimeBlock(oTempTimeBlock, oTimeBlock);
                                    }
                                }
                            }
                            break;
                        case E_RECURRINGTYPE.RCT_MONTH:
                            dtTimeLineStart = mp_oControl.MathLib.DateTimeAdd(E_INTERVAL.IL_MONTH, -1, dtTimeLineStart);
                            dtCurrent = new AGCSE.DateTime(dtTimeLineStart.Year(), dtTimeLineStart.Month(), dtTimeLineStart.Day(), 0, 0, 0);
                            while (dtCurrent < dtTimeLineEnd)
                            {
                                if (oTimeBlock.BaseDate.Day() == dtCurrent.Day())
                                {
                                    dtBase = new AGCSE.DateTime(dtCurrent.Year(), dtCurrent.Month(), dtCurrent.Day(), oTimeBlock.BaseDate.Hour(), oTimeBlock.BaseDate.Minute(), oTimeBlock.BaseDate.Second());
                                    dtCurrent = mp_oControl.MathLib.DateTimeAdd(E_INTERVAL.IL_DAY, 1, dtCurrent);
                                    if (mp_oControl.MathLib.mp_DateBlockVisible(dtTimeLineStart, dtTimeLineEnd, dtBase, oTimeBlock.DurationInterval, oTimeBlock.DurationFactor))
                                    {
                                        oTempTimeBlock = mp_oControl.TempTimeBlocks().Add("");
                                        oTempTimeBlock.BaseDate = dtBase;
                                        oTempTimeBlock.DurationInterval = oTimeBlock.DurationInterval;
                                        oTempTimeBlock.DurationFactor = oTimeBlock.DurationFactor;
                                        CopyTimeBlock(oTempTimeBlock, oTimeBlock);
                                    }
                                }
                                else
                                {
                                    dtCurrent = mp_oControl.MathLib.DateTimeAdd(E_INTERVAL.IL_DAY, 1, dtCurrent);
                                }
                            }
                            break;
                        case E_RECURRINGTYPE.RCT_YEAR:
                            dtTimeLineStart = mp_oControl.MathLib.DateTimeAdd(E_INTERVAL.IL_YEAR, -1, dtTimeLineStart);
                            dtCurrent = new AGCSE.DateTime(dtTimeLineStart.Year(), dtTimeLineStart.Month(), dtTimeLineStart.Day(), 0, 0, 0);
                            while (dtCurrent < dtTimeLineEnd)
                            {
                                if (oTimeBlock.BaseDate.Month() == dtCurrent.Month())
                                {
                                    if (oTimeBlock.BaseDate.Day() == dtCurrent.Day())
                                    {
                                        dtBase = new AGCSE.DateTime(dtCurrent.Year(), dtCurrent.Month(), dtCurrent.Day(), oTimeBlock.BaseDate.Hour(), oTimeBlock.BaseDate.Minute(), oTimeBlock.BaseDate.Second());
                                        dtCurrent = mp_oControl.MathLib.DateTimeAdd(E_INTERVAL.IL_DAY, 1, dtCurrent);
                                        if (mp_oControl.MathLib.mp_DateBlockVisible(dtTimeLineStart, dtTimeLineEnd, dtBase, oTimeBlock.DurationInterval, oTimeBlock.DurationFactor))
                                        {
                                            oTempTimeBlock = mp_oControl.TempTimeBlocks().Add("");
                                            oTempTimeBlock.BaseDate = dtBase;
                                            oTempTimeBlock.DurationInterval = oTimeBlock.DurationInterval;
                                            oTempTimeBlock.DurationFactor = oTimeBlock.DurationFactor;
                                            CopyTimeBlock(oTempTimeBlock, oTimeBlock);
                                        }
                                    }
                                    else
                                    {
                                        dtCurrent = mp_oControl.MathLib.DateTimeAdd(E_INTERVAL.IL_DAY, 1, dtCurrent);
                                    }
                                }
                                else
                                {
                                    dtCurrent = mp_oControl.MathLib.DateTimeAdd(E_INTERVAL.IL_MONTH, 1, dtCurrent);
                                }
                            }
                            break;
                    }
                }
            }
        }
    
		private void CopyTimeBlock(clsTimeBlock oDestination, clsTimeBlock oOriginal)
		{
			oDestination.TimeBlockType = E_TIMEBLOCKTYPE.TBT_SINGLE_OCURRENCE;
			oDestination.StyleIndex = oOriginal.StyleIndex;
			oDestination.GenerateConflict = oOriginal.GenerateConflict;
			oDestination.Tag = oOriginal.Tag;
            oDestination.NonWorking = oOriginal.NonWorking;
			oDestination.f_Visible = oOriginal.f_Visible;
		}
    
		internal void Draw()
		{
			DrawClass(this);
			DrawClass(mp_oControl.TempTimeBlocks());
		}
    
		internal void DrawClass(clsTimeBlocks oTimeBlocks)
		{
			int lIndex = 0;
			clsTimeBlock oTimeBlock = null;
			if (oTimeBlocks.Count == 0) 
			{
				return;
			}
			mp_oControl.clsG.ClipRegion(mp_oControl.Splitter.Right, mp_oControl.CurrentViewObject.ClientArea.Top, mp_oControl.mt_RightMargin, mp_oControl.CurrentViewObject.ClientArea.Bottom, true);
			for (lIndex = 1; lIndex <= oTimeBlocks.Count; lIndex++) 
			{
				oTimeBlock = (clsTimeBlock)oTimeBlocks.mp_oCollection.m_oReturnArrayElement(lIndex);
				if (oTimeBlock.Visible == true) 
				{
					mp_oControl.DrawEventArgs.Clear();
					mp_oControl.DrawEventArgs.CustomDraw = false;
					mp_oControl.DrawEventArgs.EventTarget = E_EVENTTARGET.EVT_TIMEBLOCK;
					mp_oControl.DrawEventArgs.ObjectIndex = lIndex;
					mp_oControl.DrawEventArgs.ParentObjectIndex = 0;
					//mp_oControl.DrawEventArgs.Graphics = mp_oControl.clsG.oGraphics;
					mp_oControl.FireDraw();
					if (mp_oControl.DrawEventArgs.CustomDraw == false) 
					{
                        if ((oTimeBlock.Right - oTimeBlock.Left) >= 1)
                        {
                            mp_oControl.clsG.mp_DrawItem(oTimeBlock.Left, oTimeBlock.Top, oTimeBlock.Right, oTimeBlock.Bottom, "", "", false, null, oTimeBlock.LeftTrim, oTimeBlock.RightTrim, oTimeBlock.Style);
                        }
					}
				}
			}
		}

        public AGCSE.DateTime IntervalStart
        {
            get { return mp_dtIntervalStart; }
            set { mp_dtIntervalStart = value; }
        }

        public AGCSE.DateTime IntervalEnd
        {
            get { return mp_dtIntervalEnd; }
            set { mp_dtIntervalEnd = value; }
        }

        public E_TBINTERVALTYPE IntervalType
        {
            get { return mp_yIntervalType; }
            set { mp_yIntervalType = value; }
        }

        public void CalculateInterval()
        {
            if (mp_yIntervalType == E_TBINTERVALTYPE.TBIT_AUTOMATIC)
            {
                return;
            }
            mp_aTimeBlocks = new ArrayList();
            mp_oControl.MathLib.mp_GenerateTimeBlocks(ref mp_aTimeBlocks, mp_dtIntervalStart, mp_dtIntervalEnd);
        }

        public string CP_GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "CP_TimeBlocks");
            oXML.InitializeWriter();
            oXML.WriteProperty("IntervalStart", mp_dtIntervalStart);
            oXML.WriteProperty("IntervalEnd", mp_dtIntervalEnd);
            oXML.WriteProperty("IntervalType", mp_yIntervalType);
            return oXML.GetXML();
        }

        public void CP_SetXML(string sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "CP_TimeBlocks");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            oXML.ReadProperty("IntervalStart", ref mp_dtIntervalStart);
            oXML.ReadProperty("IntervalEnd", ref mp_dtIntervalEnd);
            oXML.ReadProperty("IntervalType", ref mp_yIntervalType);
        }

        public string GetXML()
        {
            int lIndex = 0;
            clsTimeBlock oTimeBlock = null;
            clsXML oXML = new clsXML(mp_oControl, "TimeBlocks");
            oXML.InitializeWriter();
            for (lIndex = 1; lIndex <= Count; lIndex++)
            {
                oTimeBlock = (clsTimeBlock)mp_oCollection.m_oReturnArrayElement(lIndex);
                oXML.WriteObject(oTimeBlock.GetXML());
            }
            return oXML.GetXML();
        }

        public void SetXML(string sXML)
        {
            int lIndex = 0;
            clsXML oXML = new clsXML(mp_oControl, "TimeBlocks");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            mp_oCollection.m_Clear();
            for (lIndex = 1; lIndex <= oXML.ReadCollectionCount(); lIndex++)
            {
                clsTimeBlock oTimeBlock = new clsTimeBlock(mp_oControl);
                oTimeBlock.SetXML(oXML.ReadCollectionObject(lIndex));
                mp_oCollection.AddMode = true;
                mp_oCollection.m_Add(oTimeBlock, oTimeBlock.Key, SYS_ERRORS.TIMEBLOCKS_ADD_1, SYS_ERRORS.TIMEBLOCKS_ADD_2, false, SYS_ERRORS.TIMEBLOCKS_ADD_3);
            }
        }
    
	}
}
