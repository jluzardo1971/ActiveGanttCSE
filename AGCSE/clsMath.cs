using System;
using System.Collections;
using System.Diagnostics;

namespace AGCSE
{
	public class clsMath
	{
		private ActiveGanttCSECtl mp_oControl;

		public clsMath(ActiveGanttCSECtl Value)
		{
			mp_oControl = Value;
		}

		~clsMath()
		{
		}

        public AGCSE.DateTime DateTimeAdd(E_INTERVAL Interval, int Number, AGCSE.DateTime dtDate)
        {
            AGCSE.DateTime dtReturn = new AGCSE.DateTime();
            System.DateTime dtBuff = new System.DateTime(0);
            int lBuff = 0;
            long lDay = 0;
            long lHour = 0;
            long lMinute = 0;
            long lSecond = 0;
            long lMillisecond = 0;
            long lMicrosecond = 0;
            long lNanosecond = 0;
            bool bNegative = false;

            if ((Number < 0))
            {
                bNegative = true;
                Number = System.Math.Abs(Number);
            }

            dtBuff = new System.DateTime(dtDate.Year(), dtDate.Month(), dtDate.Day(), dtDate.Hour(), dtDate.Minute(), dtDate.Second());
            switch (Interval)
            {
                case E_INTERVAL.IL_NANOSECOND:
                    lDay = Convert.ToInt64(System.Math.Floor(Convert.ToDouble(Number) / Convert.ToDouble(86400000000000L)));
                    Number = Convert.ToInt32(Convert.ToInt64(Number) - (lDay * Convert.ToInt64(86400000000000L)));
                    lHour = Convert.ToInt64(System.Math.Floor(Convert.ToDouble(Number) / Convert.ToDouble(3600000000000L)));
                    Number = Convert.ToInt32(Convert.ToInt64(Number) - (lHour * Convert.ToInt64(3600000000000L)));
                    lMinute = Convert.ToInt64(System.Math.Floor(Convert.ToDouble(Number) / Convert.ToDouble(60000000000L)));
                    Number = Convert.ToInt32(Convert.ToInt64(Number) - (lMinute * Convert.ToInt64(60000000000L)));
                    lSecond = Convert.ToInt64(System.Math.Floor(Convert.ToDouble(Number) / Convert.ToDouble(1000000000)));
                    Number = Convert.ToInt32(Convert.ToInt64(Number) - (lSecond * Convert.ToInt64(1000000000)));
                    lMillisecond = Convert.ToInt64(System.Math.Floor(Convert.ToDouble(Number) / Convert.ToDouble(1000000)));
                    Number = Convert.ToInt32(Convert.ToInt64(Number) - (lMillisecond * Convert.ToInt64(1000000)));
                    lMicrosecond = Convert.ToInt64(System.Math.Floor(Convert.ToDouble(Number) / Convert.ToDouble(1000)));
                    Number = Convert.ToInt32(Convert.ToInt64(Number) - (lMicrosecond * Convert.ToInt64(1000)));
                    lNanosecond = Convert.ToInt64(Number);
                    break;
                case E_INTERVAL.IL_MICROSECOND:
                    lDay = Convert.ToInt64(System.Math.Floor(Convert.ToDouble(Number) / Convert.ToDouble(86400000000L)));
                    Number = Convert.ToInt32(Convert.ToInt64(Number) - (lDay * Convert.ToInt64(86400000000L)));
                    lHour = Convert.ToInt64(System.Math.Floor(Convert.ToDouble(Number) / Convert.ToDouble(3600000000L)));
                    Number = Convert.ToInt32(Convert.ToInt64(Number) - (lHour * Convert.ToInt64(3600000000L)));
                    lMinute = Convert.ToInt64(System.Math.Floor(Convert.ToDouble(Number) / Convert.ToDouble(60000000)));
                    Number = Convert.ToInt32(Convert.ToInt64(Number) - (lMinute * Convert.ToInt64(60000000)));
                    lSecond = Convert.ToInt64(System.Math.Floor(Convert.ToDouble(Number) / Convert.ToDouble(1000000)));
                    Number = Convert.ToInt32(Convert.ToInt64(Number) - (lSecond * Convert.ToInt64(1000000)));
                    lMillisecond = Convert.ToInt64(System.Math.Floor(Convert.ToDouble(Number) / Convert.ToDouble(1000)));
                    Number = Convert.ToInt32(Convert.ToInt64(Number) - (lMillisecond * Convert.ToInt64(1000)));
                    lMicrosecond = Convert.ToInt64(Number);
                    break;
                case E_INTERVAL.IL_MILLISECOND:
                    lDay = Convert.ToInt64(System.Math.Floor(Convert.ToDouble(Number) / Convert.ToDouble(86400000)));
                    Number = Convert.ToInt32(Convert.ToInt64(Number) - (lDay * Convert.ToInt64(86400000)));
                    lHour = Convert.ToInt64(System.Math.Floor(Convert.ToDouble(Number) / Convert.ToDouble(3600000)));
                    Number = Convert.ToInt32(Convert.ToInt64(Number) - (lHour * Convert.ToInt64(3600000)));
                    lMinute = Convert.ToInt64(System.Math.Floor(Convert.ToDouble(Number) / Convert.ToDouble(60000)));
                    Number = Convert.ToInt32(Convert.ToInt64(Number) - (lMinute * Convert.ToInt64(60000)));
                    lSecond = Convert.ToInt64(System.Math.Floor(Convert.ToDouble(Number) / Convert.ToDouble(1000)));
                    Number = Convert.ToInt32(Convert.ToInt64(Number) - (lSecond * Convert.ToInt64(1000)));
                    lMillisecond = Convert.ToInt64(Number);
                    break;
                case E_INTERVAL.IL_SECOND:
                    if (bNegative == true)
                    {
                        Number = Number * (-1);
                    }
                    dtBuff = dtBuff.AddSeconds(Number);
                    lBuff = dtDate.SecondFractionPart;
                    break;
                case E_INTERVAL.IL_MINUTE:
                    if (bNegative == true)
                    {
                        Number = Number * (-1);
                    }
                    dtBuff = dtBuff.AddMinutes(Number);
                    lBuff = dtDate.SecondFractionPart;
                    break;
                case E_INTERVAL.IL_HOUR:
                    if (bNegative == true)
                    {
                        Number = Number * (-1);
                    }
                    dtBuff = dtBuff.AddHours(Number);
                    lBuff = dtDate.SecondFractionPart;
                    break;
                case E_INTERVAL.IL_DAY:
                    if (bNegative == true)
                    {
                        Number = Number * (-1);
                    }
                    dtBuff = dtBuff.AddDays(Number);
                    lBuff = dtDate.SecondFractionPart;
                    break;
                case E_INTERVAL.IL_WEEK:
                    if (bNegative == true)
                    {
                        Number = Number * (-1);
                    }
                    dtBuff = dtBuff.AddDays(Number * 7);
                    lBuff = dtDate.SecondFractionPart;
                    break;
                case E_INTERVAL.IL_MONTH:
                    if (bNegative == true)
                    {
                        Number = Number * (-1);
                    }
                    dtBuff = dtBuff.AddMonths(Number);
                    lBuff = dtDate.SecondFractionPart;
                    break;
                case E_INTERVAL.IL_QUARTER:
                    if (bNegative == true)
                    {
                        Number = Number * (-1);
                    }
                    dtBuff = dtBuff.AddMonths(Number * 3);
                    lBuff = dtDate.SecondFractionPart;
                    break;
                case E_INTERVAL.IL_YEAR:
                    if (bNegative == true)
                    {
                        Number = Number * (-1);
                    }
                    dtBuff = dtBuff.AddYears(Number);
                    lBuff = dtDate.SecondFractionPart;
                    break;
            }

            if (Interval == E_INTERVAL.IL_MILLISECOND | Interval == E_INTERVAL.IL_MICROSECOND | Interval == E_INTERVAL.IL_NANOSECOND)
            {
                if (bNegative == false)
                {
                    dtBuff = dtBuff.AddDays(lDay);
                    dtBuff = dtBuff.AddHours(lHour);
                    dtBuff = dtBuff.AddMinutes(lMinute);
                    dtBuff = dtBuff.AddSeconds(lSecond);
                }
                else
                {
                    dtBuff = dtBuff.AddDays(-lDay);
                    dtBuff = dtBuff.AddHours(-lHour);
                    dtBuff = dtBuff.AddMinutes(-lMinute);
                    dtBuff = dtBuff.AddSeconds(-lSecond);
                }
                if ((bNegative == false))
                {
                    lBuff = dtDate.SecondFractionPart + (Convert.ToInt32(lMillisecond) * 1000000) + (Convert.ToInt32(lMicrosecond) * 1000) + Convert.ToInt32(lNanosecond);
                    if ((lBuff > 99999999))
                    {
                        int lAdditionalSeconds = Convert.ToInt32(System.Math.Floor(Convert.ToDouble(lBuff) / Convert.ToDouble(1000000000)));
                        dtBuff = dtBuff.AddSeconds(Convert.ToDouble(lAdditionalSeconds));
                        lBuff = lBuff - (lAdditionalSeconds * 1000000000);
                    }
                }
                else
                {
                    lBuff = dtDate.SecondFractionPart - (Convert.ToInt32(lMillisecond) * 1000000) - (Convert.ToInt32(lMicrosecond) * 1000) - Convert.ToInt32(lNanosecond);
                    if ((lBuff < 0))
                    {
                        int lAdditionalSeconds = Convert.ToInt32(System.Math.Floor(Convert.ToDouble(-lBuff) / Convert.ToDouble(1000000000)) - 1);
                        dtBuff = dtBuff.AddSeconds(Convert.ToDouble(lAdditionalSeconds));
                        lBuff = lBuff + (lAdditionalSeconds * 1000000000 * (-1));
                    }
                }
            }

            dtReturn = new AGCSE.DateTime(dtBuff.Year, dtBuff.Month, dtBuff.Day, dtBuff.Hour, dtBuff.Minute, dtBuff.Second);
            dtReturn.SecondFractionPart = lBuff;

            return dtReturn;

        }

        public int DateTimeDiff(E_INTERVAL Interval, AGCSE.DateTime dtDate1, AGCSE.DateTime dtDate2)
        {
            int lSecondFractionSpan = 0;
            int lReturn = 0;
            long lReturn64 = 0;
            System.TimeSpan tsResult = new System.TimeSpan(0);
            int lYearDiff = 0;
            if (dtDate1 == dtDate2)
            {
                return 0;
            }
            if ((Interval == E_INTERVAL.IL_MILLISECOND) | (Interval == E_INTERVAL.IL_MICROSECOND) | (Interval == E_INTERVAL.IL_NANOSECOND))
            {
                if (dtDate1 < dtDate2)
                {
                    if (dtDate1.SecondFractionPart > 0)
                    {
                        lSecondFractionSpan = 1000000000 - dtDate1.SecondFractionPart + dtDate2.SecondFractionPart;
                        if (lSecondFractionSpan >= 1000000000)
                        {
                            lSecondFractionSpan = lSecondFractionSpan - 1000000000;
                        }
                    }
                    else
                    {
                        lSecondFractionSpan = dtDate2.SecondFractionPart;
                    }
                }
                else
                {
                    if (dtDate2.SecondFractionPart > 0)
                    {
                        lSecondFractionSpan = 1000000000 - dtDate2.SecondFractionPart + dtDate1.SecondFractionPart;
                        if (lSecondFractionSpan >= 1000000000)
                        {
                            lSecondFractionSpan = lSecondFractionSpan - 1000000000;
                        }
                    }
                    else
                    {
                        lSecondFractionSpan = dtDate1.SecondFractionPart;
                    }
                    lSecondFractionSpan = -lSecondFractionSpan;
                }
            }
            switch (Interval)
            {
                case E_INTERVAL.IL_NANOSECOND:
                    tsResult = dtDate2.DateTimePart.Subtract(dtDate1.DateTimePart);
                    lReturn = Convert.ToInt32(System.Math.Floor(tsResult.TotalSeconds));
                    lReturn64 = Convert.ToInt64(lReturn) * Convert.ToInt64(1000000000);
                    lReturn64 = Convert.ToInt64(lReturn64) + Convert.ToInt64(lSecondFractionSpan);
                    lReturn = Convert.ToInt32(lReturn64);
                    return lReturn;
                case E_INTERVAL.IL_MICROSECOND:
                    tsResult = dtDate2.DateTimePart.Subtract(dtDate1.DateTimePart);
                    lReturn = Convert.ToInt32(System.Math.Floor(tsResult.TotalSeconds));
                    lReturn64 = Convert.ToInt64(lReturn) * Convert.ToInt64(1000000000);
                    lReturn64 = Convert.ToInt64(lReturn64) + Convert.ToInt64(lSecondFractionSpan);
                    lReturn = Convert.ToInt32(System.Math.Floor(Convert.ToDouble(lReturn64) / Convert.ToDouble(1000)));
                    return lReturn;
                case E_INTERVAL.IL_MILLISECOND:
                    tsResult = dtDate2.DateTimePart.Subtract(dtDate1.DateTimePart);
                    lReturn = Convert.ToInt32(System.Math.Floor(tsResult.TotalSeconds));
                    lReturn64 = Convert.ToInt64(lReturn) * Convert.ToInt64(1000000000);
                    lReturn64 = Convert.ToInt64(lReturn64) + Convert.ToInt64(lSecondFractionSpan);
                    lReturn = Convert.ToInt32(System.Math.Floor(Convert.ToDouble(lReturn64) / Convert.ToDouble(1000000)));
                    return lReturn;
                case E_INTERVAL.IL_SECOND:
                    tsResult = dtDate2.DateTimePart.Subtract(dtDate1.DateTimePart);
                    lReturn = Convert.ToInt32(System.Math.Floor(tsResult.TotalSeconds));
                    return lReturn;
                case E_INTERVAL.IL_MINUTE:
                    tsResult = dtDate2.DateTimePart.Subtract(dtDate1.DateTimePart);
                    lReturn = Convert.ToInt32(System.Math.Floor(tsResult.TotalMinutes));
                    return lReturn;
                case E_INTERVAL.IL_HOUR:
                    tsResult = dtDate2.DateTimePart.Subtract(dtDate1.DateTimePart);
                    lReturn = Convert.ToInt32(System.Math.Floor(tsResult.TotalHours));
                    return lReturn;
                case E_INTERVAL.IL_DAY:
                    tsResult = dtDate2.DateTimePart.Subtract(dtDate1.DateTimePart);
                    lReturn = Convert.ToInt32(System.Math.Floor(tsResult.TotalDays));
                    return lReturn;
                case E_INTERVAL.IL_WEEK:
                    tsResult = dtDate2.DateTimePart.Subtract(dtDate1.DateTimePart);
                    lReturn = Convert.ToInt32(System.Math.Floor(tsResult.TotalDays / 7));
                    return lReturn;
                case E_INTERVAL.IL_MONTH:
                    lYearDiff = dtDate2.Year() - dtDate1.Year();
                    int lMonthDiff = dtDate2.Month() - dtDate1.Month();
                    lYearDiff = (lYearDiff * 12);
                    return lYearDiff + lMonthDiff;
                case E_INTERVAL.IL_YEAR:
                    lYearDiff = dtDate2.Year() - dtDate1.Year();
                    return lYearDiff;
            }
            return 0;
        }

		public int GetXCoordinateFromDate(AGCSE.DateTime dtCoordinate)
		{
			return (DateTimeDiff(mp_oControl.CurrentViewObject.Interval, mp_oControl.CurrentViewObject.TimeLine.StartDate, dtCoordinate) / mp_oControl.CurrentViewObject.Factor) + mp_oControl.CurrentViewObject.TimeLine.f_lStart;
		}

        public AGCSE.DateTime GetDateFromXCoordinate(int v_lXCoordinate)
		{
			return DateTimeAdd(mp_oControl.CurrentViewObject.Interval, (v_lXCoordinate - mp_oControl.CurrentViewObject.TimeLine.f_lStart) * mp_oControl.CurrentViewObject.Factor, mp_oControl.CurrentViewObject.TimeLine.StartDate);
		}

		public int GetRowIndexByPosition(int Y)
		{
			clsRow oRow;
			int lVisRowIndex;
			if ((mp_oControl.Rows.Count == 0))
			{
				return -1;
			}
			for (lVisRowIndex = mp_oControl.VerticalScrollBar.Value;lVisRowIndex <= mp_oControl.CurrentViewObject.ClientArea.LastVisibleRow;lVisRowIndex++)
			{
				oRow = (clsRow) mp_oControl.Rows.oCollection.m_oReturnArrayElement(lVisRowIndex);
				if (Y >= oRow.Top & Y <= oRow.Bottom & oRow.Visible == true)
				{
					return lVisRowIndex;
				}
			}
			return -1;
		}

		public int GetCellIndexByPosition(int X)
		{
			clsColumn oColumn;
			int lIndex;
			for (lIndex = 1;lIndex <= mp_oControl.Columns.Count;lIndex++)
			{
				oColumn = (clsColumn) mp_oControl.Columns.oCollection.m_oReturnArrayElement(lIndex);
				if (X > oColumn.Left & X < oColumn.Right)
				{
					return lIndex;
				}
			}
			return -1;
		}

		public int GetColumnIndexByPosition(int X, int Y)
		{
			clsColumn oColumn;
			int lIndex;
			for (lIndex = 1;lIndex <= mp_oControl.Columns.Count;lIndex++)
			{
				oColumn = (clsColumn) mp_oControl.Columns.oCollection.m_oReturnArrayElement(lIndex);
				if (X >= oColumn.Left & X <= oColumn.Right & Y >= oColumn.Top & Y <= oColumn.Bottom)
				{
					return lIndex;
				}
			}
			return -1;
		}

		public int GetTaskIndexByPosition(int X, int Y)
		{
			clsTask oTask;
			int lIndex;
			for (lIndex = mp_oControl.Tasks.Count;lIndex >= 1 ;lIndex--)
			{
				oTask = (clsTask) mp_oControl.Tasks.oCollection.m_oReturnArrayElement(lIndex);
				if (oTask.Visible == true & InCurrentLayer(oTask.LayerIndex))
				{
					if (X >= oTask.Left & X <= oTask.Right & Y >= oTask.Top & Y <= oTask.Bottom)
					{
						return lIndex;
					}
				}
			}
			return -1;
		}

        public int GetPredecessorIndexByPosition(int X, int Y)
        {
            clsPredecessor oPredecessor;
            int lIndex = 0;
            for (lIndex = mp_oControl.Predecessors.Count; lIndex >= 1; lIndex--)
            {
                oPredecessor = (clsPredecessor)mp_oControl.Predecessors.oCollection.m_oReturnArrayElement(lIndex);
                if (oPredecessor.Visible == true & oPredecessor.HitTest(X, Y) == true)
                {
                    return lIndex;
                }
            }
            return -1;
        }

		public int GetPercentageIndexByPosition(int X, int Y)
		{
			clsPercentage oPercentage;
			int lIndex;
			for (lIndex = mp_oControl.Percentages.Count;lIndex >= 1 ;lIndex--)
			{
				oPercentage = (clsPercentage) mp_oControl.Percentages.oCollection.m_oReturnArrayElement(lIndex);
				if (oPercentage.Visible == true)
				{
					if (X >= oPercentage.Left & X <= oPercentage.Right & Y >= oPercentage.Top & Y <= oPercentage.Bottom)
					{
						return lIndex;
					}
				}
			}
			return -1;
		}

		public int GetNodeIndexByCheckBoxPosition(int X, int Y)
		{
			int lIndex;
			clsNode oNode;
			clsRow oRow;
			int lReturn;
			if (mp_oControl.Treeview.CheckBoxes == false)
			{
				return -1;
			}
			lReturn = -1;
			for (lIndex = 1;lIndex <= mp_oControl.Rows.Count;lIndex++)
			{
				oRow = (clsRow) mp_oControl.Rows.oCollection.m_oReturnArrayElement(lIndex);
				oNode = oRow.Node;
                if (oRow.ClientAreaVisibility == E_CLIENTAREAVISIBILITY.VS_INSIDEVISIBLEAREA & X >= (oNode.CheckBoxLeft) & X <= (oNode.CheckBoxLeft + 13) & Y <= (oNode.YCenter + 6) & Y >= (oNode.YCenter - 7))
				{
					lReturn = oNode.Index;
				}
			}
			return lReturn;
		}

		public int GetNodeIndexBySignPosition(int X, int Y)
		{
			int lIndex;
			clsNode oNode;
			clsRow oRow;
			int lReturn;
			if (mp_oControl.Treeview.PlusMinusSigns == false)
			{
				return -1;
			}
			lReturn = -1;
			for (lIndex = 1;lIndex <= mp_oControl.Rows.Count;lIndex++)
			{
				oRow = (clsRow) mp_oControl.Rows.oCollection.m_oReturnArrayElement(lIndex);
				oNode = oRow.Node;
                if (oRow.ClientAreaVisibility == E_CLIENTAREAVISIBILITY.VS_INSIDEVISIBLEAREA & X >= (oNode.Left - 5) & X <= (oNode.Left + 5) & Y <= (oNode.YCenter + 5) & Y >= (oNode.YCenter - 5))
				{
					lReturn = oNode.Index;
				}
			}
			return lReturn;
		}

		internal bool InCurrentLayer(String sLayer)
		{
			if (mp_oControl.LayerEnableObjects == E_LAYEROBJECTENABLE.EC_INALLLAYERS)
			{
				return true;
			}
			else
			{
				int lLayerIndex;
				int lCurrentLayerIndex;
				lLayerIndex = mp_oControl.Layers.oCollection.m_lReturnIndex(sLayer, true);
				lCurrentLayerIndex = mp_oControl.Layers.oCollection.m_lReturnIndex(mp_oControl.CurrentLayer, true);
				if ((lLayerIndex != lCurrentLayerIndex))
				{
					return false;
				}
				else
				{
					return true;
				}
			}
		}

		public bool DetectConflict(AGCSE.DateTime StartDate, AGCSE.DateTime EndDate, string RowKey, int ExcludeIndex, string LayerIndex)
		{
			clsTask oTask;
			clsTimeBlock oTimeBlock;
			int lIndex = 0;
			int lLayerIndex = 0;
			int lRowIndex = 0;
			if (EndDate < StartDate) 
			{
				AGCSE.DateTime dtEndDate = StartDate;
				AGCSE.DateTime dtStartDate = EndDate;
				StartDate = dtStartDate;
				EndDate = dtEndDate;
			}
			lLayerIndex = mp_oControl.Layers.oCollection.m_lReturnIndex(LayerIndex, true);
			if ((lLayerIndex == -1)) 
			{
                mp_oControl.mp_ErrorReport(SYS_ERRORS.INVALID_LAYER_INDEX, "Invalid Layer Index", "ActiveGanttCSECtl.mp_bDetectConflict");
				return false;
			}
			//// Compare to other Task Objects
			for (lIndex = 1; lIndex <= mp_oControl.Tasks.Count; lIndex++) 
			{
				oTask = (clsTask) mp_oControl.Tasks.oCollection.m_oReturnArrayElement(lIndex);
				if (RowKey == oTask.RowKey & ExcludeIndex != lIndex) 
				{
					if ((mp_oControl.Layers.oCollection.m_lReturnIndex(oTask.LayerIndex, true) == lLayerIndex)) 
					{
						//// mp_aoTasks S------------------E
						//// interval S------------------E
						if ((StartDate == oTask.StartDate | EndDate == oTask.EndDate) & (StartDate != EndDate)) 
						{
							return true;
						}
						//// mp_aoTasks S------------------E
						//// interval S------------------E
						if (StartDate > oTask.StartDate & StartDate < oTask.EndDate) 
						{
							return true;
						}
						//// mp_aoTasks S------------------E
						//// interval S------------------E
						if (EndDate > oTask.StartDate & EndDate < oTask.EndDate) 
						{
							return true;
						}
						//// mp_aoTasks S------------------E
						//// interval S-------------------------E
						if (StartDate < oTask.StartDate & EndDate > oTask.EndDate) 
						{
							return true;
						}
						//// mp_aoTasks S--------------------------E
						//// interval S------------------E
						if (StartDate > oTask.StartDate & EndDate < oTask.EndDate) 
						{
							return true;
						}
					}
				}
			}
			//// Compare to TimeBlock Objects 
			for (lIndex = 1; lIndex <= mp_oControl.TimeBlocks.Count; lIndex++) 
			{
				oTimeBlock = (clsTimeBlock) mp_oControl.TimeBlocks.oCollection.m_oReturnArrayElement(lIndex);
				lRowIndex = mp_oControl.Rows.oCollection.m_lFindIndexByKey(RowKey);

                if (oTimeBlock.GenerateConflict == true)
				{
					//// mp_aoTimeBlocks S------------------E
					//// interval S------------------E
					if ((StartDate == oTimeBlock.StartDate | EndDate == oTimeBlock.EndDate) & (StartDate != EndDate)) 
					{
						return true;
					}
					//// mp_aoTimeBlocks S------------------E
					//// interval S------------------E
					if (StartDate > oTimeBlock.StartDate & StartDate < oTimeBlock.EndDate) 
					{
						return true;
					}
					//// mp_aoTimeBlocks S------------------E
					//// interval S------------------E
					if (EndDate > oTimeBlock.StartDate & EndDate < oTimeBlock.EndDate) 
					{
						return true;
					}
					//// mp_aoTimeBlocks S------------------E
					//// interval S-------------------------E
					if (StartDate < oTimeBlock.StartDate & EndDate > oTimeBlock.EndDate) 
					{
						return true;
					}
					//// mp_aoTimeBlocks S--------------------------E
					//// interval S------------------E
					if (StartDate > oTimeBlock.StartDate & EndDate < oTimeBlock.EndDate) 
					{
						return true;
					}
				}
			}
			//// Compare to Temporary TimeBlock Objects 
			for (lIndex = 1; lIndex <= mp_oControl.TempTimeBlocks().Count; lIndex++) 
			{
				oTimeBlock = (clsTimeBlock) mp_oControl.TempTimeBlocks().oCollection.m_oReturnArrayElement(lIndex);
				lRowIndex = mp_oControl.Rows.oCollection.m_lFindIndexByKey(RowKey);
                if (oTimeBlock.GenerateConflict == true)
				{
					//// mp_aoTimeBlocks S------------------E
					//// interval S------------------E
					if ((StartDate == oTimeBlock.StartDate | EndDate == oTimeBlock.EndDate) & (StartDate != EndDate)) 
					{
						return true;
					}
					//// mp_aoTimeBlocks S------------------E
					//// interval S------------------E
					if (StartDate > oTimeBlock.StartDate & StartDate < oTimeBlock.EndDate) 
					{
						return true;
					}
					//// mp_aoTimeBlocks S------------------E
					//// interval S------------------E
					if (EndDate > oTimeBlock.StartDate & EndDate < oTimeBlock.EndDate) 
					{
						return true;
					}
					//// mp_aoTimeBlocks S------------------E
					//// interval S-------------------------E
					if (StartDate < oTimeBlock.StartDate & EndDate > oTimeBlock.EndDate) 
					{
						return true;
					}
					//// mp_aoTimeBlocks S--------------------------E
					//// interval S------------------E
					if (StartDate > oTimeBlock.StartDate & EndDate < oTimeBlock.EndDate) 
					{
						return true;
					}
				}
			}
			return false;
		}

		internal float PercentageComplete(int X1, int X2, int X)
		{
			X2 = X2 - X1;
			X = X - X1;
			if (X == 0)
			{
				return 0;
			}
			else if (X == X2)
			{
				return 1;
			}
			else
			{
				return X / X2;
			}
		}

		// ---------------------------------------------------------------------------------------------------------------------
		// Round Methods
		// ---------------------------------------------------------------------------------------------------------------------


        private AGCSE.DateTime NewDateTime(int Year, int Month, int Day, int Hour, int Minute, int Second)
        {
            AGCSE.DateTime dtReturn;
            dtReturn = new AGCSE.DateTime(Year, Month, Day, Hour, Minute, Second);
            return dtReturn;
        }

        public AGCSE.DateTime RoundDate(E_INTERVAL Interval, int Number, AGCSE.DateTime dtDate)
        {
            int lBuffer = 0;
            int lBuffer2 = 0;

            if ((Interval == E_INTERVAL.IL_NANOSECOND))
            {
                lBuffer = dtDate.Nanosecond();
                lBuffer2 = Round(lBuffer, Number);
                return DateTimeAdd(E_INTERVAL.IL_NANOSECOND, lBuffer2 - lBuffer, dtDate);
            }
            else if ((Interval == E_INTERVAL.IL_MICROSECOND))
            {
                lBuffer = dtDate.Microsecond();
                lBuffer2 = Round(lBuffer, Number);
                return DateTimeAdd(E_INTERVAL.IL_MICROSECOND, lBuffer2 - lBuffer, dtDate);
            }
            else if ((Interval == E_INTERVAL.IL_MILLISECOND))
            {
                lBuffer = dtDate.Millisecond();
                lBuffer2 = Round(lBuffer, Number);
                return DateTimeAdd(E_INTERVAL.IL_MILLISECOND, lBuffer2 - lBuffer, dtDate);
            }
            else if ((Interval == E_INTERVAL.IL_SECOND))
            {
                lBuffer = dtDate.Second();
                lBuffer2 = Round(lBuffer, Number);
                dtDate.SecondFractionPart = 0;
                return DateTimeAdd(E_INTERVAL.IL_SECOND, lBuffer2 - lBuffer, dtDate);
            }
            else if ((Interval == E_INTERVAL.IL_MINUTE))
            {
                switch (Number)
                {
                    case 1:
                        dtDate = RoundDate(E_INTERVAL.IL_SECOND, 60, dtDate);
                        lBuffer = dtDate.Second();
                        lBuffer2 = Round(lBuffer, 60);
                        dtDate.SecondFractionPart = 0;
                        return DateTimeAdd(E_INTERVAL.IL_SECOND, lBuffer2 - lBuffer, dtDate);
                    default:
                        dtDate = RoundDate(E_INTERVAL.IL_MINUTE, 1, dtDate);
                        lBuffer = dtDate.Minute();
                        lBuffer2 = Round(lBuffer, Number);
                        dtDate.SecondFractionPart = 0;
                        return DateTimeAdd(E_INTERVAL.IL_MINUTE, lBuffer2 - lBuffer, dtDate);
                }
            }
            else if ((Interval == E_INTERVAL.IL_HOUR))
            {
                switch (Number)
                {
                    case 1:
                        dtDate = RoundDate(E_INTERVAL.IL_MINUTE, 1, dtDate);
                        lBuffer = dtDate.Minute();
                        lBuffer2 = Round(lBuffer, 60);
                        dtDate.SecondFractionPart = 0;
                        return DateTimeAdd(E_INTERVAL.IL_MINUTE, lBuffer2 - lBuffer, dtDate);
                    default:
                        dtDate = RoundDate(E_INTERVAL.IL_HOUR, 1, dtDate);
                        lBuffer = dtDate.Hour();
                        lBuffer2 = Round(lBuffer, Number);
                        dtDate.SecondFractionPart = 0;
                        return DateTimeAdd(E_INTERVAL.IL_HOUR, lBuffer2 - lBuffer, dtDate);
                }
            }
            else if ((Interval == E_INTERVAL.IL_DAY))
            {
                switch (Number)
                {
                    case 1:
                        dtDate = RoundDate(E_INTERVAL.IL_HOUR, 1, dtDate);
                        lBuffer = dtDate.Hour();
                        lBuffer2 = Round(lBuffer, 24);
                        dtDate.SecondFractionPart = 0;
                        return DateTimeAdd(E_INTERVAL.IL_HOUR, lBuffer2 - lBuffer, dtDate);
                    default:
                        dtDate = RoundDate(E_INTERVAL.IL_DAY, 1, dtDate);
                        lBuffer = dtDate.Day();
                        lBuffer2 = Round(lBuffer, Number);
                        dtDate.SecondFractionPart = 0;
                        return DateTimeAdd(E_INTERVAL.IL_DAY, lBuffer2 - lBuffer, dtDate);
                }
            }
            else if ((Interval == E_INTERVAL.IL_WEEK))
            {
                switch (Number)
                {
                    case 1:
                        dtDate = RoundDate(E_INTERVAL.IL_DAY, 1, dtDate);
                        lBuffer = dtDate.DayOfWeek();
                        if (lBuffer <= 3)
                        {
                            dtDate = DateTimeAdd(E_INTERVAL.IL_DAY, -(lBuffer - 1), dtDate);
                        }
                        else if (lBuffer >= 4)
                        {
                            dtDate = DateTimeAdd(E_INTERVAL.IL_DAY, 8 - lBuffer, dtDate);
                        }
                        dtDate.SecondFractionPart = 0;
                        return dtDate;
                    default:
                        dtDate = RoundDate(E_INTERVAL.IL_WEEK, 1, dtDate);
                        lBuffer = dtDate.Day();
                        lBuffer2 = Round(lBuffer, Number);
                        dtDate.SecondFractionPart = 0;
                        return DateTimeAdd(E_INTERVAL.IL_WEEK, lBuffer2 - lBuffer, dtDate);
                }
            }
            else if ((Interval == E_INTERVAL.IL_MONTH))
            {
                switch (Number)
                {
                    case 1:
                        AGCSE.DateTime dtNextMonth;
                        dtDate = RoundDate(E_INTERVAL.IL_DAY, 1, dtDate);
                        lBuffer = dtDate.Day();
                        dtDate.SecondFractionPart = 0;
                        if (lBuffer == 1)
                        {
                            return dtDate;
                        }
                        else if (lBuffer >= 15)
                        {
                            dtNextMonth = DateTimeAdd(E_INTERVAL.IL_MONTH, 1, dtDate);
                            return NewDateTime(dtNextMonth.Year(), dtNextMonth.Month(), 1, 0, 0, 0);
                        }
                        else
                        {
                            return NewDateTime(dtDate.Year(), dtDate.Month(), 1, 0, 0, 0);
                        }
                    default:
                        dtDate = RoundDate(E_INTERVAL.IL_MONTH, 1, dtDate);
                        lBuffer = dtDate.Month();
                        int i = Round(1, 3);
                        lBuffer2 = Round(lBuffer - 1, Number) + 1;
                        dtDate.SecondFractionPart = 0;
                        return DateTimeAdd(E_INTERVAL.IL_MONTH, lBuffer2 - lBuffer, dtDate);
                }
            }
            else if ((Interval == E_INTERVAL.IL_QUARTER))
            {
                dtDate = RoundDate(E_INTERVAL.IL_DAY, 1, dtDate);
                dtDate.SecondFractionPart = 0;
                return RoundDate(E_INTERVAL.IL_MONTH, 3, dtDate);
            }
            else if ((Interval == E_INTERVAL.IL_YEAR))
            {
                switch (Number)
                {
                    case 1:
                        dtDate = RoundDate(E_INTERVAL.IL_MONTH, 1, dtDate);
                        lBuffer = dtDate.Month();
                        lBuffer2 = Round(lBuffer, 11) + 1;
                        if (lBuffer2 == 1)
                        {
                            return NewDateTime(dtDate.Year(), 1, 1, 0, 0, 0);
                        }
                        else if (lBuffer2 == 12)
                        {
                            return NewDateTime(dtDate.Year() + 1, 1, 1, 0, 0, 0);
                        }
                        break;
                    default:
                        dtDate = RoundDate(E_INTERVAL.IL_YEAR, 1, dtDate);
                        lBuffer = dtDate.Year();
                        lBuffer2 = Round(lBuffer, Number);
                        dtDate.SecondFractionPart = 0;
                        return DateTimeAdd(E_INTERVAL.IL_YEAR, lBuffer2 - lBuffer, dtDate);
                }
            }
            return null;
        }

        public int RoundDouble(double dParam)
        {
            double dInt = 0;
            double dFract = 0;
            if ((dParam > 0))
            {
                dInt = System.Math.Floor(dParam);
                dFract = dParam - dInt;
                if ((dFract >= 0.5))
                {
                    return System.Convert.ToInt32(dInt) + 1;
                }
                else
                {
                    return System.Convert.ToInt32(dInt);
                }
            }
            else if ((dParam < 0))
            {
                dInt = System.Math.Ceiling(dParam);
                dFract = dParam - dInt;
                if ((dFract >= -0.5))
                {
                    return System.Convert.ToInt32(dInt);
                }
                else
                {
                    return System.Convert.ToInt32(dInt) - 1;
                }
            }
            return 0;
        }

        internal int Round(int v_lNumberToRound, int v_lRoundTo)
        {
            int lRoundToHalf = 0;
            int lMultiplier = 0;
            while (v_lNumberToRound > v_lRoundTo)
            {
                v_lNumberToRound = v_lNumberToRound - v_lRoundTo;
                lMultiplier = lMultiplier + 1;
            }
            lRoundToHalf = System.Math.Abs((int)System.Math.Floor(-((double)v_lRoundTo / (double)2)));
            if (v_lNumberToRound >= lRoundToHalf)
            {
                v_lNumberToRound = v_lRoundTo;
            }
            else
            {
                v_lNumberToRound = 0;
            }
            return (v_lRoundTo * lMultiplier) + v_lNumberToRound;
        }

		internal int lAbs(int Number)
		{
			return Math.Abs(Number);
		}


        internal bool mp_DateBlockVisible(AGCSE.DateTime dtIntStart, AGCSE.DateTime dtIntEnd, AGCSE.DateTime dtBaseDate, E_INTERVAL yInterval, int lFactor)
        {
            AGCSE.DateTime dtStart;
            AGCSE.DateTime dtEnd;
            if (lFactor > 0)
            {
                dtStart = dtBaseDate;
                dtEnd = DateTimeAdd(yInterval, lFactor, dtBaseDate);
            }
            else
            {
                dtStart = DateTimeAdd(yInterval, lFactor, dtBaseDate);
                dtEnd = dtBaseDate;
            }
            if (dtStart > dtIntStart & dtStart < dtIntEnd)
            {
                return true;
            }
            if (dtEnd > dtIntStart & dtEnd < dtIntEnd)
            {
                return true;
            }
            if (dtStart <= dtIntStart & dtEnd >= dtIntEnd)
            {
                return true;
            }
            return false;
        }

        internal void mp_GenerateTimeBlocks(ref ArrayList aTimeBlocks, AGCSE.DateTime dtIntStart, AGCSE.DateTime dtIntEnd)
        {
            int i = 0;
            clsTimeBlock oTimeBlock;
            for (i = 1; i <= mp_oControl.TimeBlocks.Count; i++)
            {
                oTimeBlock = (clsTimeBlock)mp_oControl.TimeBlocks.oCollection.m_oReturnArrayElement(i);
                if (mp_bIsValidTimeBlock(oTimeBlock) == true)
                {
                    if (oTimeBlock.TimeBlockType == E_TIMEBLOCKTYPE.TBT_SINGLE_OCURRENCE)
                    {
                        //If mp_DateBlockVisible(dtIntStart, dtIntEnd, oTimeBlock.StartDate, oTimeBlock.DurationInterval, oTimeBlock.DurationFactor) = True Then
                        mp_AddTimeBlock(ref aTimeBlocks, oTimeBlock.StartDate, oTimeBlock);
                        //End If
                    }
                    else if (oTimeBlock.TimeBlockType == E_TIMEBLOCKTYPE.TBT_RECURRING)
                    {
                        AGCSE.DateTime dtCurrent;
                        AGCSE.DateTime dtBase;
                        AGCSE.DateTime dtTimeLineStart;
                        AGCSE.DateTime dtTimeLineEnd;
                        switch (oTimeBlock.RecurringType)
                        {
                            case E_RECURRINGTYPE.RCT_DAY:
                                dtTimeLineStart = dtIntStart;
                                dtTimeLineEnd = dtIntEnd;
                                dtTimeLineStart = DateTimeAdd(E_INTERVAL.IL_DAY, -7, dtTimeLineStart);
                                dtTimeLineEnd = DateTimeAdd(E_INTERVAL.IL_DAY, 7, dtTimeLineEnd);
                                dtCurrent = new AGCSE.DateTime(dtTimeLineStart.Year(), dtTimeLineStart.Month(), dtTimeLineStart.Day(), 0, 0, 0);
                                while (dtCurrent < dtTimeLineEnd)
                                {
                                    dtBase = new AGCSE.DateTime(dtCurrent.Year(), dtCurrent.Month(), dtCurrent.Day(), oTimeBlock.BaseDate.Hour(), oTimeBlock.BaseDate.Minute(), oTimeBlock.BaseDate.Second());
                                    dtCurrent = DateTimeAdd(E_INTERVAL.IL_DAY, 1, dtCurrent);
                                    if (mp_DateBlockVisible(dtTimeLineStart, dtTimeLineEnd, dtBase, oTimeBlock.DurationInterval, oTimeBlock.DurationFactor))
                                    {
                                        mp_AddTimeBlock(ref aTimeBlocks, dtBase, oTimeBlock);
                                    }
                                }
                                break;
                            case E_RECURRINGTYPE.RCT_WEEK:
                                dtTimeLineStart = dtIntStart;
                                dtTimeLineEnd = dtIntEnd;
                                dtTimeLineStart = DateTimeAdd(E_INTERVAL.IL_DAY, -7, dtTimeLineStart);
                                dtTimeLineEnd = DateTimeAdd(E_INTERVAL.IL_DAY, 7, dtTimeLineEnd);
                                dtCurrent = new AGCSE.DateTime(dtTimeLineStart.Year(), dtTimeLineStart.Month(), dtTimeLineStart.Day(), 0, 0, 0);
                                while (dtCurrent < dtTimeLineEnd)
                                {
                                    dtBase = new AGCSE.DateTime(dtCurrent.Year(), dtCurrent.Month(), dtCurrent.Day(), oTimeBlock.BaseDate.Hour(), oTimeBlock.BaseDate.Minute(), oTimeBlock.BaseDate.Second());
                                    dtCurrent = DateTimeAdd(E_INTERVAL.IL_DAY, 1, dtCurrent);
                                    if (System.Convert.ToInt32(oTimeBlock.BaseWeekDay) == System.Convert.ToInt32(dtBase.DayOfWeek()))
                                    {
                                        if (mp_DateBlockVisible(dtTimeLineStart, dtTimeLineEnd, dtBase, oTimeBlock.DurationInterval, oTimeBlock.DurationFactor))
                                        {
                                            mp_AddTimeBlock(ref aTimeBlocks, dtBase, oTimeBlock);
                                        }
                                    }
                                }
                                break;
                            case E_RECURRINGTYPE.RCT_MONTH:
                                dtTimeLineStart = dtIntStart;
                                dtTimeLineEnd = dtIntEnd;
                                dtTimeLineStart = DateTimeAdd(E_INTERVAL.IL_MONTH, -1, dtTimeLineStart);
                                dtTimeLineEnd = DateTimeAdd(E_INTERVAL.IL_MONTH, 1, dtTimeLineEnd);
                                dtCurrent = new AGCSE.DateTime(dtTimeLineStart.Year(), dtTimeLineStart.Month(), dtTimeLineStart.Day(), 0, 0, 0);
                                while (dtCurrent < dtTimeLineEnd)
                                {
                                    if (oTimeBlock.BaseDate.Day() == dtCurrent.Day())
                                    {
                                        dtBase = new AGCSE.DateTime(dtCurrent.Year(), dtCurrent.Month(), dtCurrent.Day(), oTimeBlock.BaseDate.Hour(), oTimeBlock.BaseDate.Minute(), oTimeBlock.BaseDate.Second());
                                        dtCurrent = DateTimeAdd(E_INTERVAL.IL_DAY, 1, dtCurrent);
                                        if (mp_DateBlockVisible(dtTimeLineStart, dtTimeLineEnd, dtBase, oTimeBlock.DurationInterval, oTimeBlock.DurationFactor))
                                        {
                                            mp_AddTimeBlock(ref aTimeBlocks, dtBase, oTimeBlock);
                                        }
                                    }
                                    else
                                    {
                                        dtCurrent = DateTimeAdd(E_INTERVAL.IL_DAY, 1, dtCurrent);
                                    }
                                }
                                break;
                            case E_RECURRINGTYPE.RCT_YEAR:
                                dtTimeLineStart = dtIntStart;
                                dtTimeLineEnd = dtIntEnd;
                                dtTimeLineStart = DateTimeAdd(E_INTERVAL.IL_YEAR, -1, dtTimeLineStart);
                                dtTimeLineEnd = DateTimeAdd(E_INTERVAL.IL_YEAR, 1, dtTimeLineEnd);
                                dtCurrent = new AGCSE.DateTime(dtTimeLineStart.Year(), dtTimeLineStart.Month(), dtTimeLineStart.Day(), 0, 0, 0);
                                while (dtCurrent < dtTimeLineEnd)
                                {
                                    if (oTimeBlock.BaseDate.Month() == dtCurrent.Month())
                                    {
                                        if (oTimeBlock.BaseDate.Day() == dtCurrent.Day())
                                        {
                                            dtBase = new AGCSE.DateTime(dtCurrent.Year(), dtCurrent.Month(), dtCurrent.Day(), oTimeBlock.BaseDate.Hour(), oTimeBlock.BaseDate.Minute(), oTimeBlock.BaseDate.Second());
                                            dtCurrent = DateTimeAdd(E_INTERVAL.IL_DAY, 1, dtCurrent);
                                            if (mp_DateBlockVisible(dtTimeLineStart, dtTimeLineEnd, dtBase, oTimeBlock.DurationInterval, oTimeBlock.DurationFactor))
                                            {
                                                mp_AddTimeBlock(ref aTimeBlocks, dtBase, oTimeBlock);
                                            }
                                        }
                                        else
                                        {
                                            dtCurrent = DateTimeAdd(E_INTERVAL.IL_DAY, 1, dtCurrent);
                                        }
                                    }
                                    else
                                    {
                                        dtCurrent = DateTimeAdd(E_INTERVAL.IL_MONTH, 1, dtCurrent);
                                    }
                                }
                                break;
                        }
                    }
                }
            }
            if (aTimeBlocks.Count > 0)
            {
                mp_QuickSortTB(ref aTimeBlocks, 0, aTimeBlocks.Count - 1);
                mp_MergeTB(ref aTimeBlocks);
            }
        }

        private void mp_AddTimeBlock(ref ArrayList aTimeBlocks, AGCSE.DateTime dtBase, clsTimeBlock oTimeBlock)
        {
            S_TIMEBLOCK oTB;
            if (oTimeBlock.DurationFactor > 0)
            {
                oTB.dtStart = dtBase;
                oTB.dtEnd = DateTimeAdd(oTimeBlock.DurationInterval, oTimeBlock.DurationFactor, dtBase);
            }
            else
            {
                oTB.dtEnd = dtBase;
                oTB.dtStart = DateTimeAdd(oTimeBlock.DurationInterval, oTimeBlock.DurationFactor, dtBase);
            }
            aTimeBlocks.Add(oTB);
        }

        internal bool mp_bIsValidTimeBlock(clsTimeBlock oTimeBlock)
        {
            if (oTimeBlock.DurationFactor == 0)
            {
                return false;
            }
            if (oTimeBlock.NonWorking == true)
            {
                return true;
            }
            return false;
        }

        private void mp_MergeTB(ref ArrayList aTimeBlocks)
        {
            int i = 0;
            int lStart = 0;
            bool bFinished = false;
            while (bFinished == false)
            {
                for (i = lStart; i <= aTimeBlocks.Count - 2; i++)
                {
                    S_TIMEBLOCK oTB1;
                    S_TIMEBLOCK oTB2;
                    int lTB1 = 0;
                    int lTB2 = 0;
                    lTB1 = i;
                    lTB2 = i + 1;
                    oTB1 = (S_TIMEBLOCK)aTimeBlocks[lTB1];
                    oTB2 = (S_TIMEBLOCK)aTimeBlocks[lTB2];
                    if ((oTB2.dtStart > oTB1.dtStart) & (oTB2.dtEnd < oTB1.dtEnd))
                    {
                        //Case 1
                        //xxxxxxxxxxxxxxxxx           TB1
                        //   xxxxxxxxxxxx             TB2
                        aTimeBlocks.RemoveAt(lTB2);
                        bFinished = false;
                        if (i >= 1)
                            lStart = i - 1;
                        break; // TODO: might not be correct. Was : Exit For
                    }
                    else if ((oTB2.dtStart == oTB1.dtStart) & (oTB2.dtEnd == oTB1.dtEnd))
                    {
                        //Case 2
                        //xxxxxxxxxxxxxxxxx           TB1
                        //xxxxxxxxxxxxxxxxx           TB2
                        aTimeBlocks.RemoveAt(lTB2);
                        bFinished = false;
                        if (i >= 1)
                            lStart = i - 1;
                        break; // TODO: might not be correct. Was : Exit For
                    }
                    else if ((oTB2.dtStart == oTB1.dtStart) & (oTB2.dtEnd > oTB1.dtEnd))
                    {
                        //Case 3
                        //xxxxxxxxxxxx                TB1
                        //xxxxxxxxxxxxxxxxx           TB2
                        oTB1.dtEnd = oTB2.dtEnd;
                        aTimeBlocks[lTB1] = oTB1;
                        aTimeBlocks.RemoveAt(lTB2);
                        bFinished = false;
                        if (i >= 1)
                            lStart = i - 1;
                        break; // TODO: might not be correct. Was : Exit For
                    }
                    else if ((oTB2.dtStart == oTB1.dtStart) & (oTB2.dtEnd < oTB1.dtEnd))
                    {
                        //Case 4
                        //xxxxxxxxxxxxxxxxx           TB1
                        //xxxxxxxxxxx                 TB2
                        aTimeBlocks.RemoveAt(lTB2);
                        bFinished = false;
                        if (i >= 1)
                            lStart = i - 1;
                        break; // TODO: might not be correct. Was : Exit For
                    }
                    else if ((oTB2.dtStart > oTB1.dtStart) & (oTB2.dtStart < oTB1.dtEnd))
                    {
                        //Case 5
                        //xxxxxxxxxxxxxxxxx            TB1
                        //              xxxxxxxxxxxxxx TB2
                        oTB1.dtEnd = oTB2.dtEnd;
                        aTimeBlocks[lTB1] = oTB1;
                        aTimeBlocks.RemoveAt(lTB2);
                        bFinished = false;
                        if (i >= 1)
                            lStart = i - 1;
                        break; // TODO: might not be correct. Was : Exit For
                    }
                    else if ((oTB1.dtEnd == oTB2.dtStart))
                    {
                        //Case 6
                        //xxxxxxxxxxxxxx               TB1
                        //              xxxxxxxxxxxxxx TB2
                        oTB1.dtEnd = oTB2.dtEnd;
                        aTimeBlocks[lTB1] = oTB1;
                        aTimeBlocks.RemoveAt(lTB2);
                        bFinished = false;
                        if (i >= 1)
                            lStart = i - 1;
                        break; // TODO: might not be correct. Was : Exit For
                    }
                    bFinished = true;
                }
            }
        }

        internal int mp_CheckDuration(ref ArrayList aTimeBlocks, AGCSE.DateTime dtStartDate)
        {
            int i = 0;
            int lSeconds = 0;
            bool bInside = false;
            for (i = 0; i <= aTimeBlocks.Count - 2; i++)
            {
                S_TIMEBLOCK oTB1;
                S_TIMEBLOCK oTB2;
                oTB1 = (S_TIMEBLOCK)aTimeBlocks[i];
                oTB2 = (S_TIMEBLOCK)aTimeBlocks[i + 1];
                int lSecondDiff = 0;
                if (dtStartDate >= oTB1.dtEnd & dtStartDate < oTB2.dtStart)
                {
                    lSecondDiff = DateTimeDiff(E_INTERVAL.IL_SECOND, dtStartDate, oTB2.dtStart);
                    bInside = true;
                }
                else if (bInside == true)
                {
                    lSecondDiff = DateTimeDiff(E_INTERVAL.IL_SECOND, oTB1.dtEnd, oTB2.dtStart);
                }
                if (bInside == true & lSecondDiff <= 0)
                {
                    mp_oControl.mp_ErrorReport(SYS_ERRORS.CHECK_DURATION_ERROR, "Inconsistent State in Check Duration", "clsMath.mp_CheckDuration");
                    return -1;
                }
                lSeconds = lSeconds + lSecondDiff;
            }
            return lSeconds;
        }

        internal bool mp_GetStartDate(ref ArrayList aTimeBlocks, ref bool bStartDateVerified, ref AGCSE.DateTime dtStartDate)
        {
            if (bStartDateVerified == true)
            {
                return true;
            }
            int i = 0;
            for (i = 0; i <= aTimeBlocks.Count - 1; i++)
            {
                S_TIMEBLOCK oTB1;
                oTB1 = (S_TIMEBLOCK)aTimeBlocks[i];
                if (dtStartDate >= oTB1.dtStart & dtStartDate < oTB1.dtEnd)
                {
                    dtStartDate = oTB1.dtEnd;
                    bStartDateVerified = true;
                    return false;
                }
            }
            bStartDateVerified = true;
            return true;
        }

        internal void mp_GetEndDate(ref ArrayList aTimeBlocks, int lDurationInSeconds, ref AGCSE.DateTime dtStartDate, ref AGCSE.DateTime dtEndDate)
        {
            int i = 0;
            bool bInside = false;
            for (i = 0; i <= aTimeBlocks.Count - 2; i++)
            {
                S_TIMEBLOCK oTB1;
                S_TIMEBLOCK oTB2;
                oTB1 = (S_TIMEBLOCK)aTimeBlocks[i];
                oTB2 = (S_TIMEBLOCK)aTimeBlocks[i + 1];
                int lSecondDiff = 0;
                if (dtStartDate >= oTB1.dtEnd & dtStartDate < oTB2.dtStart & bInside == false)
                {
                    lSecondDiff = DateTimeDiff(E_INTERVAL.IL_SECOND, dtStartDate, oTB2.dtStart);
                    bInside = true;
                    if (lDurationInSeconds <= lSecondDiff)
                    {
                        dtEndDate = DateTimeAdd(E_INTERVAL.IL_SECOND, lDurationInSeconds, dtStartDate);
                        return;
                    }
                }
                else if (bInside == true)
                {
                    lSecondDiff = DateTimeDiff(E_INTERVAL.IL_SECOND, oTB1.dtEnd, oTB2.dtStart);
                }
                if (bInside == true)
                {
                    lDurationInSeconds = lDurationInSeconds - lSecondDiff;
                    if (lDurationInSeconds <= 0)
                    {
                        lDurationInSeconds = lDurationInSeconds + lSecondDiff;
                        dtEndDate = DateTimeAdd(E_INTERVAL.IL_SECOND, lDurationInSeconds, oTB1.dtEnd);
                        return;
                    }
                }
            }
        }

        internal void mp_ValidateStartDate(ref ArrayList aTimeBlocks, ref AGCSE.DateTime dtStartDate)
        {
            int i = 0;
            for (i = 0; i <= aTimeBlocks.Count - 1; i++)
            {
                S_TIMEBLOCK oTB1;
                oTB1 = (S_TIMEBLOCK)aTimeBlocks[i];
                if (dtStartDate >= oTB1.dtStart & dtStartDate < oTB1.dtEnd)
                {
                    dtStartDate = oTB1.dtEnd;
                    return;
                }
            }
        }

        internal void mp_ValidateEndDate(ref ArrayList aTimeBlocks, ref AGCSE.DateTime dtEndDate)
        {
            int i = 0;
            for (i = 0; i <= aTimeBlocks.Count - 1; i++)
            {
                S_TIMEBLOCK oTB1;
                oTB1 = (S_TIMEBLOCK)aTimeBlocks[i];
                if (dtEndDate >= oTB1.dtStart & dtEndDate < oTB1.dtEnd)
                {
                    dtEndDate = oTB1.dtStart;
                    return;
                }
            }
        }

        internal void mp_StandarizeInterval(ref AGCSE.DateTime dtIntStart, ref AGCSE.DateTime dtIntEnd)
        {
            if (dtIntStart < dtIntEnd)
            {
                return;
            }
            AGCSE.DateTime dtIntBuff;
            dtIntBuff = dtIntStart;
            dtIntStart = dtIntEnd;
            dtIntEnd = dtIntBuff;
        }

        public AGCSE.DateTime GetEndDate(ref AGCSE.DateTime StartDate, E_INTERVAL DurationInterval, int DurationFactor)
        {
            AGCSE.DateTime EndDate = new AGCSE.DateTime();
            AGCSE.DateTime dtIntStart;
            AGCSE.DateTime dtIntEnd;
            bool bFinished = false;
            bool bStartDateVerified = false;
            int lIntFactor = 2;
            ArrayList aTimeBlocks = null;
            int lDurationInSeconds = 0;
            int lCheckDuration = 0;
            int lPass = 0;
            int i = 0;
            clsTimeBlock oTimeBlock;
            int lSecondsInDay = 86400;
            int lSecondsInWeek = 604800;
            int lSecondsInMonth = 2419200;
            int lSecondsInYear = 31449600;
            int lEstimatedDuration = 0;
            if (!(DurationInterval == E_INTERVAL.IL_SECOND | DurationInterval == E_INTERVAL.IL_MINUTE | DurationInterval == E_INTERVAL.IL_HOUR | DurationInterval == E_INTERVAL.IL_DAY))
            {
                mp_oControl.mp_ErrorReport(SYS_ERRORS.INVALID_DURATION_INTERVAL, "Interval is invalid for a duration", "clsMath.GetEndDate");
                return EndDate;
            }
            lDurationInSeconds = mp_oControl.MathLib.mp_GetSeconds(DurationInterval, DurationFactor);
            lEstimatedDuration = lDurationInSeconds;
            for (i = 1; i <= mp_oControl.TimeBlocks.Count; i++)
            {
                oTimeBlock = (clsTimeBlock)mp_oControl.TimeBlocks.oCollection.m_oReturnArrayElement(i);
                if (mp_oControl.MathLib.mp_bIsValidTimeBlock(oTimeBlock))
                {
                    if (oTimeBlock.TimeBlockType == E_TIMEBLOCKTYPE.TBT_RECURRING)
                    {
                        switch (oTimeBlock.RecurringType)
                        {
                            case E_RECURRINGTYPE.RCT_DAY:
                                lSecondsInDay = lSecondsInDay - mp_oControl.MathLib.mp_GetSeconds(oTimeBlock.DurationInterval, oTimeBlock.DurationFactor);
                                break;
                            case E_RECURRINGTYPE.RCT_WEEK:
                                lSecondsInWeek = lSecondsInWeek - mp_oControl.MathLib.mp_GetSeconds(oTimeBlock.DurationInterval, oTimeBlock.DurationFactor);
                                break;
                            case E_RECURRINGTYPE.RCT_MONTH:
                                lSecondsInMonth = lSecondsInMonth - mp_oControl.MathLib.mp_GetSeconds(oTimeBlock.DurationInterval, oTimeBlock.DurationFactor);
                                break;
                            case E_RECURRINGTYPE.RCT_YEAR:
                                lSecondsInYear = lSecondsInYear - mp_oControl.MathLib.mp_GetSeconds(oTimeBlock.DurationInterval, oTimeBlock.DurationFactor);
                                break;
                        }
                    }
                }
            }
            if (lDurationInSeconds > 31449600)
            {
                lEstimatedDuration = lEstimatedDuration + System.Convert.ToInt32(System.Math.Ceiling((double)lDurationInSeconds / (double)lSecondsInYear) * 31449600);
            }
            if (lDurationInSeconds > 2419200)
            {
                lEstimatedDuration = lEstimatedDuration + System.Convert.ToInt32(System.Math.Ceiling((double)lDurationInSeconds / (double)lSecondsInMonth) * 2419200);
            }
            if (lDurationInSeconds > 604800)
            {
                lEstimatedDuration = lEstimatedDuration + System.Convert.ToInt32(System.Math.Ceiling((double)lDurationInSeconds / (double)lSecondsInWeek) * 604800);
            }
            if (lDurationInSeconds > 86400)
            {
                lEstimatedDuration = lEstimatedDuration + System.Convert.ToInt32(System.Math.Ceiling((double)lDurationInSeconds / (double)lSecondsInDay) * 86400);
            }
            while (bFinished == false)
            {
                lPass = lPass + 1;
                dtIntStart = StartDate;
                dtIntEnd = mp_oControl.MathLib.DateTimeAdd(E_INTERVAL.IL_SECOND, lEstimatedDuration * lIntFactor, StartDate);
                mp_oControl.MathLib.mp_StandarizeInterval(ref dtIntStart, ref dtIntEnd);
                if (mp_oControl.TimeBlocks.IntervalType == E_TBINTERVALTYPE.TBIT_AUTOMATIC)
                {
                    aTimeBlocks = new ArrayList();
                    mp_oControl.MathLib.mp_GenerateTimeBlocks(ref aTimeBlocks, dtIntStart, dtIntEnd);
                }
                else
                {
                    aTimeBlocks = mp_oControl.TimeBlocks.mp_aTimeBlocks;
                }
                if (aTimeBlocks.Count == 0)
                {
                    EndDate = mp_oControl.MathLib.DateTimeAdd(DurationInterval, DurationFactor, StartDate);
                    return EndDate;
                }
                else
                {
                    if (mp_oControl.MathLib.mp_GetStartDate(ref aTimeBlocks, ref bStartDateVerified, ref StartDate) == true)
                    {
                        lCheckDuration = mp_oControl.MathLib.mp_CheckDuration(ref aTimeBlocks, StartDate);
                        if (lCheckDuration < lDurationInSeconds)
                        {
                            if (lCheckDuration == 0)
                            {
                                lCheckDuration = lDurationInSeconds;
                            }
                            lIntFactor = System.Convert.ToInt32(System.Math.Ceiling((double)lDurationInSeconds / (double)lCheckDuration) * 2) + lIntFactor;
                        }
                        else
                        {
                            mp_oControl.MathLib.mp_GetEndDate(ref aTimeBlocks, lDurationInSeconds, ref StartDate, ref EndDate);
                            bFinished = true;
                        }
                    }
                }
            }
            return EndDate;
        }

        internal void mp_GetTimeBlocks(ref ArrayList aTimeBlocks, ref AGCSE.DateTime dtStartDate, ref AGCSE.DateTime dtEndDate)
        {
            if (mp_oControl.TimeBlocks.IntervalType == E_TBINTERVALTYPE.TBIT_AUTOMATIC)
            {
                aTimeBlocks = new ArrayList();
                mp_GenerateTimeBlocks(ref aTimeBlocks, dtStartDate, dtEndDate);
            }
            else
            {
                aTimeBlocks = mp_oControl.TimeBlocks.mp_aTimeBlocks;
            }
        }

        public int CalculateDuration(ref AGCSE.DateTime dtStartDate, ref AGCSE.DateTime dtEndDate, E_INTERVAL DurationInterval)
        {
            ArrayList aTimeBlocks = new ArrayList();
            int lDurationInSeconds = 0;
            int lReturn = 0;
            mp_StandarizeInterval(ref dtStartDate, ref dtEndDate);
            if (!(DurationInterval == E_INTERVAL.IL_SECOND | DurationInterval == E_INTERVAL.IL_MINUTE | DurationInterval == E_INTERVAL.IL_HOUR | DurationInterval == E_INTERVAL.IL_DAY))
            {
                mp_oControl.mp_ErrorReport(SYS_ERRORS.INVALID_DURATION_INTERVAL, "Interval is invalid for a duration", "clsMath.CalculateDuration");
                return -1;
            }
            mp_GetTimeBlocks(ref aTimeBlocks, ref dtStartDate, ref dtEndDate);
            if (aTimeBlocks.Count == 0)
            {
                return DateTimeDiff(DurationInterval, dtStartDate, dtEndDate);
            }
            else
            {
                mp_ValidateStartDate(ref aTimeBlocks, ref dtStartDate);
                mp_ValidateEndDate(ref aTimeBlocks, ref dtEndDate);
                lDurationInSeconds = mp_GetDuration(ref aTimeBlocks, dtStartDate, dtEndDate);
                switch (DurationInterval)
                {
                    case E_INTERVAL.IL_SECOND:
                        lReturn = lDurationInSeconds;
                        break;
                    case E_INTERVAL.IL_MINUTE:
                        lReturn = System.Convert.ToInt32(System.Math.Floor((double)lDurationInSeconds / 60));
                        break;
                    case E_INTERVAL.IL_HOUR:
                        lReturn = System.Convert.ToInt32(System.Math.Floor((double)lDurationInSeconds / 3600));
                        break;
                    case E_INTERVAL.IL_DAY:
                        lReturn = System.Convert.ToInt32(System.Math.Floor((double)lDurationInSeconds / 86400));
                        break;
                }
                return lReturn;
            }
        }

        private int mp_GetDuration(ref ArrayList aTimeBlocks, AGCSE.DateTime dtStartDate, AGCSE.DateTime dtEndDate)
        {
            int i = 0;
            bool bInside = false;
            int lReturn = 0;
            for (i = 0; i <= aTimeBlocks.Count - 2; i++)
            {
                S_TIMEBLOCK oTB1;
                S_TIMEBLOCK oTB2;
                oTB1 = (S_TIMEBLOCK)aTimeBlocks[i];
                oTB2 = (S_TIMEBLOCK)aTimeBlocks[i + 1];
                if (dtStartDate >= oTB1.dtEnd & dtStartDate <= oTB2.dtStart & dtEndDate >= oTB1.dtEnd & dtEndDate <= oTB2.dtStart)
                {
                    lReturn = DateTimeDiff(E_INTERVAL.IL_SECOND, dtStartDate, dtEndDate);
                }
                else if (dtStartDate >= oTB1.dtEnd & dtStartDate <= oTB2.dtStart)
                {
                    lReturn = lReturn + DateTimeDiff(E_INTERVAL.IL_SECOND, dtStartDate, oTB2.dtStart);
                    bInside = true;
                }
                else if (dtEndDate >= oTB1.dtEnd & dtEndDate <= oTB2.dtStart & bInside == true)
                {
                    lReturn = lReturn + DateTimeDiff(E_INTERVAL.IL_SECOND, oTB1.dtEnd, dtEndDate);
                    break; // TODO: might not be correct. Was : Exit For
                }
                else if (bInside == true)
                {
                    lReturn = lReturn + DateTimeDiff(E_INTERVAL.IL_SECOND, oTB1.dtEnd, oTB2.dtStart);
                }
            }
            return lReturn;
        }

        internal void mp_DumpTB(S_TIMEBLOCK oTB)
        {
            Debug.WriteLine("StartDate: " + oTB.dtStart.ToString("yyyy/MM/dd HH:mm:ss"));
            Debug.WriteLine("EndDate: " + oTB.dtEnd.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        internal void mp_DumpTimeBlocks(ref ArrayList aTimeBlocks, string sCaption)
        {
            Debug.WriteLine(sCaption + " *************************** Dumping TimeBlocks:");
            int i = 0;
            for (i = 0; i <= aTimeBlocks.Count - 1; i++)
            {
                S_TIMEBLOCK oTB;
                oTB = (S_TIMEBLOCK)aTimeBlocks[i];
                Debug.WriteLine(i.ToString() + ":");
                Debug.WriteLine("StartDate: " + oTB.dtStart.ToString("yyyy/MM/dd HH:mm:ss"));
                Debug.WriteLine("EndDate: " + oTB.dtEnd.ToString("yyyy/MM/dd HH:mm:ss"));
            }
        }

        internal int mp_GetSeconds(E_INTERVAL yInterval, int lFactor)
        {
            if (lFactor < 0)
            {
                lFactor = lFactor * -1;
            }
            switch (yInterval)
            {
                case E_INTERVAL.IL_SECOND:
                    return lFactor;
                case E_INTERVAL.IL_MINUTE:
                    return lFactor * 60;
                case E_INTERVAL.IL_HOUR:
                    return lFactor * 3600;
                case E_INTERVAL.IL_DAY:
                    return lFactor * 86400;
            }
            return -1;
        }

        internal void mp_QuickSortTB(ref ArrayList aTimeBlocks, int StartIndex, int EndIndex)
        {
            // StartIndex = subscript of beginning of array
            // EndIndex = subscript of end of array

            int MiddleIndex;
            if (StartIndex < EndIndex)
            {
                MiddleIndex = mp_QSPartitionTB(ref aTimeBlocks, StartIndex, EndIndex);
                mp_QuickSortTB(ref aTimeBlocks, StartIndex, MiddleIndex);   // sort first section
                mp_QuickSortTB(ref aTimeBlocks, MiddleIndex + 1, EndIndex);    // sort second section
            }
            return;
        }

        internal int mp_QSPartitionTB(ref ArrayList aTimeBlocks, int StartIndex, int EndIndex)
        {
            S_TIMEBLOCK oX = (S_TIMEBLOCK)aTimeBlocks[StartIndex];
            AGCSE.DateTime x = oX.dtStart;
            int i = StartIndex - 1;
            int j = EndIndex + 1;
            S_TIMEBLOCK temp;
            do
            {
                do
                {
                    j--;
                    oX = (S_TIMEBLOCK)aTimeBlocks[j];
                } while (x < oX.dtStart); //Change to > for descending

                do
                {
                    i++;
                    oX = (S_TIMEBLOCK)aTimeBlocks[i];
                } while (x > oX.dtStart); //Change to < for descending

                if (i < j)
                {
                    temp = (S_TIMEBLOCK)aTimeBlocks[i];
                    aTimeBlocks[i] = aTimeBlocks[j];
                    aTimeBlocks[j] = temp;
                }

            } while (i < j);
            return j;           // returns middle subscript  
        }

        internal string GetTierIndex(int Number)
        {
            string sNumber = null;
            int lLastDigit = 0;
            sNumber = System.Convert.ToString(Number);
            lLastDigit = System.Convert.ToInt32(sNumber.Substring(sNumber.Length - 1, 1));
            if (lLastDigit == 0)
            {
                return "10";
            }
            else
            {
                return lLastDigit.ToString();
            }
        }





	}
}
