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
	public class clsRows
	{
    
		private ActiveGanttCSECtl mp_oControl;
		private clsCollectionBase mp_oCollection;
		private int mp_lTopOffset;
		private int mp_lRealFirstVisibleRow;

        private int mp_lLoadIndex = 0;
        internal ArrayList mp_oTempCollection = null;
        internal clsDictionary mp_oTempDictionary = null;
        private ArrayList mp_oTempNodeList = null;
    
		internal clsRows(ActiveGanttCSECtl Value)
		{
			mp_oControl = Value;
			mp_oCollection = new clsCollectionBase(Value, "Row");
		}
    
		public int Count 
		{
			get { return mp_oCollection.m_lCount(); }
		}
    
		public clsRow Item(string Index)
		{
			return (clsRow)mp_oCollection.m_oItem(Index, SYS_ERRORS.ROWS_ITEM_1, SYS_ERRORS.ROWS_ITEM_2, SYS_ERRORS.ROWS_ITEM_3, SYS_ERRORS.ROWS_ITEM_4);
		}
    
		internal clsCollectionBase oCollection 
		{
			get { return mp_oCollection; }
		}
    
		public clsRow Add(string Key)
		{
			return Add(Key, "", false, true, "");
		}
    
		public clsRow Add(string Key, string Text)
		{
			return Add(Key, Text, false, true, "");
		}
    
		public clsRow Add(string Key, string Text, bool MergeCells)
		{
			return Add(Key, Text, MergeCells, true, "");
		}
    
		public clsRow Add(string Key, string Text, bool MergeCells, bool Container)
		{
			return Add(Key, Text, MergeCells, Container, "");
		}
    
		public clsRow Add(string Key, string Text, bool MergeCells, bool Container, string StyleIndex)
		{
			mp_oCollection.AddMode = true;
			clsRow oRow = new clsRow(mp_oControl);
			int lIndex = 0;
			oRow.Key = Key;
			oRow.Text = Text;
			oRow.MergeCells = MergeCells;
			oRow.Container = Container;
			oRow.StyleIndex = StyleIndex;
			mp_oCollection.m_Add(oRow, Key, SYS_ERRORS.ROWS_ADD_1, SYS_ERRORS.ROWS_ADD_2, true, SYS_ERRORS.ROWS_ADD_3);
			for (lIndex = 1; lIndex <= mp_oControl.Columns.Count; lIndex++) 
			{
				oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(mp_oControl.Rows.Count);
				oRow.Cells.Add();
			}
			mp_oControl.VerticalScrollBar.Update();
			return oRow;
		}
    
		public void Clear()
		{
			mp_oControl.Tasks.Clear();
			mp_oCollection.m_Clear();
			mp_oControl.SelectedRowIndex = 0;
			mp_oControl.VerticalScrollBar.Reset();
		}
    
		public void Remove(string Index)
		{
			string sRIndex = "";
			string sRKey = "";
			mp_oCollection.m_GetKeyAndIndex(Index, ref sRKey, ref sRIndex);
			mp_oControl.Tasks.oCollection.m_CollectionRemoveWhere("RowKey", sRKey, sRIndex);
			mp_oCollection.m_Remove(Index, SYS_ERRORS.ROWS_REMOVE_1, SYS_ERRORS.ROWS_REMOVE_2, SYS_ERRORS.ROWS_REMOVE_3, SYS_ERRORS.ROWS_REMOVE_4);
			mp_oControl.SelectedRowIndex = 0;
            mp_oControl.SelectedTaskIndex = 0;
			mp_oControl.VerticalScrollBar.Update();
		}
    
		public void MoveRow(int OriginRowIndex, int DestRowIndex)
		{
			if (OriginRowIndex < 1 | OriginRowIndex > Count) 
			{
				return;
			}
			if (DestRowIndex < 1 | DestRowIndex > Count) 
			{
				return;
			}
			if (DestRowIndex == OriginRowIndex) 
			{
				return;
			}
			mp_oCollection.m_lCopyAndMoveItems(OriginRowIndex, DestRowIndex);
		}
    
		public void SortRows(string PropertyName, bool Descending, E_SORTTYPE SortType)
		{
			SortRows(PropertyName, Descending, SortType, -1, -1);
		}
    
		public void SortRows(string PropertyName, bool Descending, E_SORTTYPE SortType, int StartIndex, int EndIndex)
		{
			if (StartIndex == -1) 
			{
				StartIndex = 1;
			}
			if (EndIndex == -1) 
			{
				EndIndex = Count;
			}
			if (Count == 0) 
			{
				return;
			}
			if (StartIndex < 1 | StartIndex > Count) 
			{
				return;
			}
			if (EndIndex < 1 | EndIndex > Count) 
			{
				return;
			}
			if (EndIndex == StartIndex) 
			{
				return;
			}
			mp_oCollection.m_Sort(PropertyName, Descending, SortType, StartIndex, EndIndex);
		}
    
		public void SortCells(int CellIndex, string PropertyName, bool Descending, E_SORTTYPE SortType)
		{
			SortCells(CellIndex, PropertyName, Descending, SortType, -1, -1);
		}
    
		public void SortCells(int CellIndex, string PropertyName, bool Descending, E_SORTTYPE SortType, int StartIndex, int EndIndex)
		{
			if (StartIndex == -1) 
			{
				StartIndex = 1;
			}
			if (EndIndex == -1) 
			{
				EndIndex = Count;
			}
			if (Count == 0) 
			{
				return;
			}
			if (StartIndex < 1 | StartIndex > Count) 
			{
				return;
			}
			if (EndIndex < 1 | EndIndex > Count) 
			{
				return;
			}
			if (EndIndex == StartIndex) 
			{
				return;
			}
			if (CellIndex < 1 | CellIndex > mp_oControl.Columns.Count) 
			{
				return;
			}
			mp_oCollection.m_SortCells(CellIndex, PropertyName, Descending, SortType, StartIndex, EndIndex);
		}
    
		internal void ClearCells()
		{
			int lIndex = 0;
			clsRow oRow = null;
			for (lIndex = 1; lIndex <= mp_oCollection.m_lCount(); lIndex++) 
			{
				oRow = (clsRow)mp_oCollection.m_oReturnArrayElement(lIndex);
				oRow.Cells.Clear();
			}
		}
    
		internal int Height()
		{
            int lBuffer = 0;
            int lIndex = 0;
            clsRow oRow = null;
            if (Count == 0)
            {
                return 0;
            }

            bool bChildrenHidden = false;
            int lCurrentDepth = 0;
            for (lIndex = 1; lIndex <= Count; lIndex++)
            {
                bool bHidden = false;
                oRow = (clsRow)mp_oCollection.m_oReturnArrayElement(lIndex);
                if (oRow.Node.Depth == 0)
                {
                    bHidden = false;
                }
                if (bChildrenHidden == true)
                {
                    bHidden = true;
                }
                if (oRow.Node.Depth < lCurrentDepth)
                {
                    lCurrentDepth = oRow.Node.Depth;
                    bHidden = false;
                    bChildrenHidden = false;
                }
                if (bHidden == false)
                {
                    lBuffer = lBuffer + oRow.Height + 1;
                }
                if (oRow.Node.Expanded == false & bChildrenHidden == false)
                {
                    lCurrentDepth = oRow.Node.Depth + 1;
                    bChildrenHidden = true;
                }
            }

            return lBuffer;
		}
    
		internal int CalculateHeight(int StartIndex, int EndIndex)
		{
			int lBuffer = 0;
			int lIndex = 0;
			clsRow oRow = null;
			if (StartIndex == 0) 
			{
				return 0;
			}
			for (lIndex = StartIndex; lIndex <= EndIndex; lIndex++) 
			{
				oRow = (clsRow)mp_oCollection.m_oReturnArrayElement(lIndex);
				lBuffer = lBuffer + oRow.Height;
			}
			return lBuffer;
		}
    
		internal int CalculateRows(int StartIndex, int Height)
		{
			int lBuffer = 0;
			int lIndex = 0;
			clsRow oRow = null;
			int lRows = 0;
			lRows = 1;
			if (StartIndex == 0) 
			{
				return lRows;
			}
			for (lIndex = StartIndex; lIndex <= Count; lIndex++) 
			{
				oRow = (clsRow)mp_oCollection.m_oReturnArrayElement(lIndex);
				lBuffer = lBuffer + oRow.Height;
				if (lBuffer > Height) 
				{
					break; // TODO: might not be correct. Was : Exit For
				}
				lRows = lRows + 1;
			}
			return lRows;
		}
    
		internal void PositionRows()
		{
			clsRow oRow = null;
			int lRowIndex = 0;
			int lBottomBuff = 0;
			clsClientArea oClientArea = null;
			oClientArea = mp_oControl.CurrentViewObject.ClientArea;
			if (Count == 0) 
			{
				oClientArea.f_LastVisibleRow = 0;
				mp_lTopOffset = mp_oControl.CurrentViewObject.ClientArea.Top;
				return;
			}
			else 
			{
				mp_lTopOffset = 0;
			}
			for (lRowIndex = (mp_lRealFirstVisibleRow - 1); lRowIndex >= 1; lRowIndex += -1) 
			{
				oRow = (clsRow)mp_oCollection.m_oReturnArrayElement(lRowIndex);
				if (lRowIndex == (mp_lRealFirstVisibleRow - 1)) 
				{
					oRow.f_lBottom = mp_oControl.CurrentViewObject.ClientArea.Top - 1;
				}
				else 
				{
					oRow.f_lBottom = lBottomBuff - 1;
				}
				oRow.f_lTop = oRow.Bottom - oRow.Height;
				lBottomBuff = oRow.Top;
				oRow.ClientAreaVisibility = E_CLIENTAREAVISIBILITY.VS_ABOVEVISIBLEAREA;
			}
			for (lRowIndex = mp_lRealFirstVisibleRow; lRowIndex <= Count; lRowIndex++) 
			{
				oRow = (clsRow)mp_oCollection.m_oReturnArrayElement(lRowIndex);
                if (mp_lTopOffset < mp_oControl.mt_TableBottom) 
				{
					if (lRowIndex == mp_lRealFirstVisibleRow) 
					{
						oRow.f_lTop = mp_oControl.CurrentViewObject.ClientArea.Top;
					}
					else 
					{
						oRow.f_lTop = lBottomBuff + 1;
					}
					oRow.f_lBottom = oRow.Top + oRow.Height;
					lBottomBuff = oRow.Bottom;
					mp_lTopOffset = oRow.Bottom;
					oClientArea.f_LastVisibleRow = lRowIndex;
					oRow.ClientAreaVisibility = E_CLIENTAREAVISIBILITY.VS_INSIDEVISIBLEAREA;
				}
				else 
				{
					break; // TODO: might not be correct. Was : Exit For
				}
			}
			for (lRowIndex = (oClientArea.LastVisibleRow + 1); lRowIndex <= Count; lRowIndex++) 
			{
				oRow = (clsRow)mp_oCollection.m_oReturnArrayElement(lRowIndex);
				oRow.f_lTop = lBottomBuff + 1;
				oRow.f_lBottom = oRow.Top + oRow.Height;
				lBottomBuff = oRow.Bottom;
				oRow.ClientAreaVisibility = E_CLIENTAREAVISIBILITY.VS_BELOWVISIBLEAREA;
			}
		}
    
		internal int TopOffset 
		{
			get { return mp_lTopOffset; }
			set { mp_lTopOffset = value; }
		}
    
		internal void InitializePosition()
		{
			mp_lRealFirstVisibleRow = RealFirstVisibleRow;
		}
    
		internal void NodesDrawBackground()
		{
            int lIndex = 0;
            clsNode oNode = null;
            clsRow oRow = null;
            clsCell oCell = null;
            if (Count == 0)
            {
                return;
            }
            for (lIndex = mp_lRealFirstVisibleRow; lIndex <= Count; lIndex++)
            {
                oRow = (clsRow)mp_oCollection.m_oReturnArrayElement(lIndex);
                oCell = (clsCell)oRow.Cells.oCollection.m_oReturnArrayElement(mp_oControl.TreeviewColumnIndex);
                oNode = oRow.Node;
                if (mp_oControl.Treeview.FullColumnSelect == true)
                {
                    mp_oControl.clsG.mp_DrawItem(oCell.Left, oCell.Top, oCell.Right - 1, oCell.Bottom, "", "", (oRow.Index == mp_oControl.SelectedRowIndex & mp_oControl.TreeviewColumnIndex == mp_oControl.SelectedCellIndex), oCell.Image, oCell.LeftTrim, oCell.RightTrim,
                    oNode.Style);
                }
                else
                {
                    mp_oControl.clsG.mp_DrawItem(oCell.Left, oCell.Top, oCell.Right - 1, oCell.Bottom, "", "", false, oCell.Image, oCell.LeftTrim, oCell.RightTrim,
                    oNode.Style);
                    if ((oRow.Index == mp_oControl.SelectedRowIndex & mp_oControl.TreeviewColumnIndex == mp_oControl.SelectedCellIndex & oNode.Style.SelectionRectangleStyle.Visible == true))
                    {
                        mp_oControl.clsG.mp_DrawSelectionRectangle(oNode.mt_TextLeft, oNode.Top, mp_oControl.Splitter.Left, oNode.Bottom - 1, oNode.Style);
                    }
                }
            }
		}
    
		internal void NodesDrawTreeLines()
		{
			int lIndex = 0;
			clsNode oNode = null;
			clsRow oRow = null;
			clsNode oRelative = null;
			if (Count == 0 | mp_oControl.Treeview.TreeLines == false) 
			{
				return;
			}
			for (lIndex = mp_lRealFirstVisibleRow; lIndex <= Count; lIndex++) 
			{
				oRow = (clsRow)mp_oCollection.m_oReturnArrayElement(lIndex);
				oNode = oRow.Node;
                if ((oRow.ClientAreaVisibility == E_CLIENTAREAVISIBILITY.VS_INSIDEVISIBLEAREA | oRow.ClientAreaVisibility == E_CLIENTAREAVISIBILITY.VS_BELOWVISIBLEAREA) & oNode.Hidden == false) 
				{
                    if (lIndex <= mp_oControl.CurrentViewObject.ClientArea.LastVisibleRow)
                    {
                        if (oNode.CheckBoxVisible == true)
                        {
                            mp_oControl.clsG.DrawLine(oNode.Left, oNode.YCenter, oNode.Left + 15, oNode.YCenter, GRE_LINETYPE.LT_NORMAL, mp_oControl.Treeview.TreeLineColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                        }
                        else if (oNode.ImageVisible == true)
                        {
                            mp_oControl.clsG.DrawLine(oNode.Left, oNode.YCenter, oNode.Left + 15, oNode.YCenter, GRE_LINETYPE.LT_NORMAL, mp_oControl.Treeview.TreeLineColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                        }
                        else if (oNode.ImageVisible == false & oNode.CheckBoxVisible == false)
                        {
                            mp_oControl.clsG.DrawLine(oNode.Left, oNode.YCenter, oNode.mt_TextLeft, oNode.YCenter, GRE_LINETYPE.LT_NORMAL, mp_oControl.Treeview.TreeLineColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                        }
                    }
					if (oNode.Index == 1) 
					{
                        //Dont Draw anything
					}
					else 
					{
                        oRelative = null;
						if (oNode.IsFirstSibling()) 
						{
							oRelative = oNode.Parent();
                            if (oRelative.Row.Index > mp_oControl.CurrentViewObject.ClientArea.LastVisibleRow)
                            {
                                oRelative = null;
                            }
                            else
                            {
                                mp_oControl.clsG.DrawLine(oNode.Left, oNode.YCenter, oNode.Left, oRelative.mt_TextBottom, GRE_LINETYPE.LT_NORMAL, mp_oControl.Treeview.TreeLineColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                            }
						}
                        else if (oNode.IsLastSibling()) 
						{
                            oRelative = oNode.FirstSibling();
                            if (oRelative.Row.Index > mp_oControl.CurrentViewObject.ClientArea.LastVisibleRow)
                            {
                                oRelative = null;
                            }
                            else
                            {
                                mp_oControl.clsG.DrawLine(oNode.Left, oNode.YCenter, oNode.Left, oRelative.YCenter, GRE_LINETYPE.LT_NORMAL, mp_oControl.Treeview.TreeLineColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                            }
						}
					}
				}
			}
		}
    
		internal void NodesDraw()
		{
			int lIndex = 0;
			clsNode oNode = null;
			clsRow oRow = null;
			if (Count == 0) 
			{
				return;
			}
			for (lIndex = mp_lRealFirstVisibleRow; lIndex <= Count; lIndex++) 
			{
				oRow = (clsRow)mp_oCollection.m_oReturnArrayElement(lIndex);
				oNode = oRow.Node;
                if (oRow.ClientAreaVisibility == E_CLIENTAREAVISIBILITY.VS_INSIDEVISIBLEAREA & oNode.Hidden == false) 
				{
                    mp_oControl.clsG.DrawAlignedText(oNode.mt_TextLeft, oNode.mt_TextTop, oNode.mt_TextRight, oNode.mt_TextBottom, oNode.Text, GRE_HORIZONTALALIGNMENT.HAL_LEFT, GRE_VERTICALALIGNMENT.VAL_CENTER, oNode.Style.ForeColor, oNode.Style.Font);
                    if (oNode.Text.Length > 0)
                    {
                        oNode.mp_lTextLeft = mp_oControl.clsG.mp_oTextFinalLayout.Left;
                        oNode.mp_lTextTop = mp_oControl.clsG.mp_oTextFinalLayout.Top;
                        oNode.mp_lTextRight = mp_oControl.clsG.mp_oTextFinalLayout.Left + mp_oControl.clsG.mp_oTextFinalLayout.Width - 1;
                        oNode.mp_lTextBottom = mp_oControl.clsG.mp_oTextFinalLayout.Top + mp_oControl.clsG.mp_oTextFinalLayout.Height - 1;
                    }
                    else
                    {
                        oNode.mp_lTextLeft = oNode.mt_TextLeft;
                        oNode.mp_lTextTop = oNode.mt_TextTop;
                        oNode.mp_lTextRight = oNode.mt_TextRight;
                        oNode.mp_lTextBottom = oNode.mt_TextBottom;
                    }
				}
			}
		}
    
		private void mp_DrawSign(bool bExpanded, int X, int Y, Color BorderColor, Color SignColor)
		{
			if (mp_oControl.Treeview.PlusMinusSigns == false) 
			{
				return;
			}
			Y = Y - 1;
			mp_oControl.clsG.DrawLine(X - 4, Y - 3, X + 4, Y + 4, GRE_LINETYPE.LT_FILLED, Colors.White, GRE_LINEDRAWSTYLE.LDS_SOLID);
			mp_oControl.clsG.DrawLine(X - 4, Y - 3, X + 4, Y + 5, GRE_LINETYPE.LT_BORDER, BorderColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
			mp_oControl.clsG.DrawLine(X - 2, Y + 1, X + 2, Y + 1, GRE_LINETYPE.LT_NORMAL, SignColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
			if (bExpanded == false) 
			{
				mp_oControl.clsG.DrawLine(X, Y - 1, X, Y + 3, GRE_LINETYPE.LT_NORMAL, SignColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
			}
		}
    
		internal int HiddenRows()
		{
            int lIndex = 0;
            clsRow oRow = null;
            int lReturn = 0;

            bool bChildrenHidden = false;
            int lCurrentDepth = 0;
            for (lIndex = 1; lIndex <= Count; lIndex++)
            {
                bool bHidden = false;
                oRow = (clsRow)mp_oCollection.m_oReturnArrayElement(lIndex);
                if (oRow.Node.Depth == 0)
                {
                    bHidden = false;
                }
                if (bChildrenHidden == true)
                {
                    bHidden = true;
                }
                if (oRow.Node.Depth < lCurrentDepth)
                {
                    lCurrentDepth = oRow.Node.Depth;
                    bHidden = false;
                    bChildrenHidden = false;
                }
                if (bHidden == true)
                {
                    lReturn = lReturn + 1;
                }
                if (oRow.Node.Expanded == false & bChildrenHidden == false)
                {
                    lCurrentDepth = oRow.Node.Depth + 1;
                    bChildrenHidden = true;
                }
            }

            return lReturn;
		}
    
		internal int RealFirstVisibleRow 
		{
			get 
			{
				return RealIndex(mp_oControl.VerticalScrollBar.Value);
			}
		}

        internal int RealIndex(int Index)
        {
            int lIndex = 0;
            clsRow oRow = null;
            clsNode oNode = null;
            int lCount = 0;
            for (lIndex = 1; lIndex <= Count; lIndex++)
            {
                oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(lIndex);
                oNode = oRow.Node;
                if (oNode.Hidden == false)
                {
                    lCount = lCount + 1;
                    if (lCount == Index)
                    {
                        return lIndex;
                    }
                }
            }
            return -1;
        }
    
		private void mp_DrawCheckBox(ref clsNode oNode)
		{
			if (mp_oControl.Treeview.CheckBoxes == false) 
			{
				return;
			}
			if (oNode.CheckBoxVisible == true) 
			{
				mp_oControl.clsG.DrawLine(oNode.CheckBoxLeft + 1, oNode.YCenter - 5, oNode.CheckBoxLeft + 11, oNode.YCenter + 5, GRE_LINETYPE.LT_FILLED, mp_oControl.Treeview.CheckBoxColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
				mp_oControl.clsG.DrawLine(oNode.CheckBoxLeft + 1, oNode.YCenter - 5, oNode.CheckBoxLeft + 11, oNode.YCenter + 5, GRE_LINETYPE.LT_BORDER, mp_oControl.Treeview.CheckBoxBorderColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
				if (oNode.Checked == true) 
				{
					mp_oControl.clsG.DrawLine(oNode.CheckBoxLeft + 3, oNode.YCenter, oNode.CheckBoxLeft + 3, oNode.YCenter + 2, GRE_LINETYPE.LT_NORMAL, mp_oControl.Treeview.CheckBoxMarkColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
					mp_oControl.clsG.DrawLine(oNode.CheckBoxLeft + 4, oNode.YCenter + 1, oNode.CheckBoxLeft + 4, oNode.YCenter + 3, GRE_LINETYPE.LT_NORMAL, mp_oControl.Treeview.CheckBoxMarkColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
					mp_oControl.clsG.DrawLine(oNode.CheckBoxLeft + 5, oNode.YCenter + 2, oNode.CheckBoxLeft + 5, oNode.YCenter + 4, GRE_LINETYPE.LT_NORMAL, mp_oControl.Treeview.CheckBoxMarkColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
					mp_oControl.clsG.DrawLine(oNode.CheckBoxLeft + 6, oNode.YCenter + 1, oNode.CheckBoxLeft + 6, oNode.YCenter + 3, GRE_LINETYPE.LT_NORMAL, mp_oControl.Treeview.CheckBoxMarkColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
					mp_oControl.clsG.DrawLine(oNode.CheckBoxLeft + 7, oNode.YCenter, oNode.CheckBoxLeft + 7, oNode.YCenter + 2, GRE_LINETYPE.LT_NORMAL, mp_oControl.Treeview.CheckBoxMarkColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
					mp_oControl.clsG.DrawLine(oNode.CheckBoxLeft + 8, oNode.YCenter - 1, oNode.CheckBoxLeft + 8, oNode.YCenter + 1, GRE_LINETYPE.LT_NORMAL, mp_oControl.Treeview.CheckBoxMarkColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
					mp_oControl.clsG.DrawLine(oNode.CheckBoxLeft + 9, oNode.YCenter - 2, oNode.CheckBoxLeft + 9, oNode.YCenter, GRE_LINETYPE.LT_NORMAL, mp_oControl.Treeview.CheckBoxMarkColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
				}
			}
		}
    
		private void mp_DrawImage(ref clsNode oNode)
		{
			Image oImage = null;
			int lImageWidth = 0;
			int lImageHeight = 0;
			if (mp_oControl.Treeview.Images == false) 
			{
				return;
			}
			if (oNode.ImageVisible == true) 
			{
				if (oNode.Expanded == true & oNode.Children() > 0 & (oNode.ExpandedImage != null)) 
				{
					oImage = oNode.ExpandedImage;
				}
				else if (oNode.Selected == true & (oNode.SelectedImage != null)) 
				{
					oImage = oNode.SelectedImage;
				}
				else if ((oNode.Image != null)) 
				{
					oImage = oNode.Image;
				}
				if ((oImage != null)) 
				{
					lImageWidth = (int)oImage.Width;
					lImageHeight = (int)oImage.Height;
					mp_oControl.clsG.PaintImage(oImage, oNode.ImageLeft, oNode.ImageTop, oNode.ImageRight, oNode.ImageBottom, 0, 0, true);
				}
			}
		}
    
		internal void Draw()
		{
			int lCellIndex = 0;
			int lRowIndex = 0;
			clsRow oRow = null;
			clsColumn oColumn = null;
			clsCell oCell = null;
            int lTableBottom = mp_oControl.mt_TableBottom;
            int lBottom;
			mp_oControl.clsG.ClipRegion(mp_oControl.mt_LeftMargin, mp_oControl.CurrentViewObject.ClientArea.Top, mp_oControl.Splitter.Left, mp_oControl.mt_TableBottom, false);
			mp_oControl.DrawEventArgs.Clear();
			mp_oControl.DrawEventArgs.CustomDraw = false;
			mp_oControl.DrawEventArgs.EventTarget = E_EVENTTARGET.EVT_GRID;
			mp_oControl.DrawEventArgs.ObjectIndex = 0;
			mp_oControl.DrawEventArgs.ParentObjectIndex = 0;
			//mp_oControl.DrawEventArgs.Graphics = mp_oControl.clsG.oGraphics;
			mp_oControl.FireDraw();
			if (mp_oControl.DrawEventArgs.CustomDraw == true) 
			{
				return;
			}
			if (Count == 0) 
			{
				return;
			}
			for (lRowIndex = mp_lRealFirstVisibleRow; lRowIndex <= mp_oControl.CurrentViewObject.ClientArea.LastVisibleRow; lRowIndex++) 
			{
				oRow = (clsRow)mp_oCollection.m_oReturnArrayElement(lRowIndex);
				if (oRow.Visible == true & oRow.Height > -1) 
				{
					if (oRow.MergeCells == true) 
					{
                        if (oRow.Bottom > lTableBottom)
                        {
                            lBottom = lTableBottom;
                        }
                        else
                        {
                            lBottom = oRow.Bottom;
                        }
                        mp_oControl.clsG.ClipRegion(oRow.Left, oRow.Top, oRow.Right, lBottom, true);
						mp_oControl.DrawEventArgs.Clear();
						mp_oControl.DrawEventArgs.CustomDraw = false;
						mp_oControl.DrawEventArgs.EventTarget = E_EVENTTARGET.EVT_ROW;
						mp_oControl.DrawEventArgs.ObjectIndex = lRowIndex;
						mp_oControl.DrawEventArgs.ParentObjectIndex = 0;
						//mp_oControl.DrawEventArgs.Graphics = mp_oControl.clsG.oGraphics;
						mp_oControl.FireDraw();
						if (mp_oControl.DrawEventArgs.CustomDraw == false) 
						{
                            mp_oControl.clsG.mp_DrawItem(oRow.Left, oRow.Top, oRow.Right, oRow.Bottom, "", oRow.Text, (lRowIndex == mp_oControl.SelectedRowIndex), oRow.Image, 0, 0, oRow.Style);
                            if (oRow.Text.Length > 0)
                            {
                                oRow.mp_lTextLeft = mp_oControl.clsG.mp_oTextFinalLayout.Left;
                                oRow.mp_lTextTop = mp_oControl.clsG.mp_oTextFinalLayout.Top;
                                oRow.mp_lTextRight = mp_oControl.clsG.mp_oTextFinalLayout.Left + mp_oControl.clsG.mp_oTextFinalLayout.Width - 1;
                                oRow.mp_lTextBottom = mp_oControl.clsG.mp_oTextFinalLayout.Top + mp_oControl.clsG.mp_oTextFinalLayout.Height - 1;
                            }
                            else
                            {
                                oRow.mp_lTextLeft = oRow.Left;
                                oRow.mp_lTextTop = oRow.Top;
                                oRow.mp_lTextRight = oRow.Right;
                                oRow.mp_lTextBottom = oRow.Bottom;
                            }
						}
					}
					else 
					{
						for (lCellIndex = 1; lCellIndex <= mp_oControl.Columns.Count; lCellIndex++) 
						{
                            if (lCellIndex != mp_oControl.TreeviewColumnIndex)
                            {
                                oCell = (clsCell)oRow.Cells.oCollection.m_oReturnArrayElement(lCellIndex);
                                oColumn = (clsColumn)mp_oControl.Columns.oCollection.m_oReturnArrayElement(lCellIndex);
                                if (oColumn.Visible == true)
                                {
                                    if (oCell.Bottom > lTableBottom)
                                    {
                                        lBottom = lTableBottom;
                                    }
                                    else
                                    {
                                        lBottom = oCell.Bottom;
                                    }
                                    mp_oControl.clsG.ClipRegion(oCell.LeftTrim, oCell.Top, oCell.RightTrim, lBottom, true);
                                    mp_oControl.DrawEventArgs.Clear();
                                    mp_oControl.DrawEventArgs.CustomDraw = false;
                                    mp_oControl.DrawEventArgs.EventTarget = E_EVENTTARGET.EVT_CELL;
                                    mp_oControl.DrawEventArgs.ObjectIndex = lCellIndex;
                                    mp_oControl.DrawEventArgs.ParentObjectIndex = lRowIndex;
                                    //mp_oControl.DrawEventArgs.Graphics = mp_oControl.clsG.oGraphics;
                                    mp_oControl.FireDraw();
                                    if (mp_oControl.DrawEventArgs.CustomDraw == false)
                                    {
                                        mp_oControl.clsG.mp_DrawItem(oCell.Left, oCell.Top, oCell.Right - 1, oCell.Bottom, "", oCell.Text, (lRowIndex == mp_oControl.SelectedRowIndex & lCellIndex == mp_oControl.SelectedCellIndex), oCell.Image, oCell.LeftTrim, oCell.RightTrim, oCell.Style);
                                        if (oCell.Text.Length > 0)
                                        {
                                            oCell.mp_lTextLeft = (int)mp_oControl.clsG.mp_oTextFinalLayout.Left;
                                            oCell.mp_lTextTop = (int)mp_oControl.clsG.mp_oTextFinalLayout.Top;
                                            oCell.mp_lTextRight = (int)mp_oControl.clsG.mp_oTextFinalLayout.Left + (int)mp_oControl.clsG.mp_oTextFinalLayout.Width - 1;
                                            oCell.mp_lTextBottom = (int)mp_oControl.clsG.mp_oTextFinalLayout.Top + (int)mp_oControl.clsG.mp_oTextFinalLayout.Height - 1;
                                        }
                                        else
                                        {
                                            oCell.mp_lTextLeft = oCell.Left;
                                            oCell.mp_lTextTop = oCell.Top;
                                            oCell.mp_lTextRight = oCell.Right;
                                            oCell.mp_lTextBottom = oCell.Bottom;
                                        }
                                    }
                                }
                            }
						}
					}
				}
			}
		}

        public string GetXML()
        {
            int lIndex = 0;
            clsRow oRow = null;
            clsXML oXML = new clsXML(mp_oControl, "Rows");
            oXML.InitializeWriter();
            for (lIndex = 1; lIndex <= Count; lIndex++)
            {
                oRow = (clsRow)mp_oCollection.m_oReturnArrayElement(lIndex);
                oXML.WriteObject(oRow.GetXML());
            }
            return oXML.GetXML();
        }


        public void SetXML(string sXML)
        {
            int lIndex = 0;
            clsXML oXML = new clsXML(mp_oControl, "Rows");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            mp_oCollection.m_Clear();
            for (lIndex = 1; lIndex <= oXML.ReadCollectionCount(); lIndex++)
            {
                clsRow oRow = new clsRow(mp_oControl);
                oRow.SetXML(oXML.ReadCollectionObject(lIndex));
                mp_oCollection.AddMode = true;
                mp_oCollection.m_Add(oRow, oRow.Key, SYS_ERRORS.ROWS_ADD_1, SYS_ERRORS.ROWS_ADD_2, true, SYS_ERRORS.ROWS_ADD_3);
                oRow = null;
            }
            mp_oControl.VerticalScrollBar.Update();
            mp_oControl.VerticalScrollBar.Value = 1;
        }

        public void BeginLoad(bool Preserve)
        {
            mp_oTempNodeList = new ArrayList();
            if (Preserve == false)
            {
                mp_lLoadIndex = 1;
                mp_oTempCollection = new ArrayList();
                mp_oTempDictionary = new clsDictionary();
                mp_oCollection.mp_aoCollection.Clear();
                mp_oCollection.mp_oKeys.Clear();
            }
            else
            {
                mp_oTempCollection = mp_oCollection.mp_aoCollection;
                mp_oCollection.mp_aoCollection = null;
                mp_oCollection.mp_aoCollection = new ArrayList();
                mp_oTempDictionary = mp_oCollection.mp_oKeys;
                mp_oCollection.mp_oKeys = null;
                mp_oCollection.mp_oKeys = new clsDictionary();
                mp_lLoadIndex = mp_oTempCollection.Count + 1;
            }
        }

        public clsRow Load(string sKey)
        {
            int lIndex = 0;
            clsRow oRow = new clsRow(mp_oControl);
            oRow.Key = sKey;
            for (lIndex = 1; lIndex <= mp_oControl.Columns.Count; lIndex++)
            {
                oRow.Cells.Add();
            }
            oRow.Index = mp_lLoadIndex;
            if (oRow.Node.Depth == 0)
            {
                oRow.Node.mp_oParent = null;
            }
            else
            {
                oRow.Node.mp_oParent = (clsNode)mp_oTempNodeList[oRow.Node.Depth - 1];
            }
            if (oRow.Node.Depth > (mp_oTempNodeList.Count - 1))
            {
                mp_oTempNodeList.Add(oRow.Node);
            }
            else
            {
                mp_oTempNodeList[oRow.Node.Depth] = oRow.Node;
            }
            mp_oTempCollection.Add(oRow);
            mp_oTempDictionary.Add(mp_lLoadIndex, sKey);
            mp_lLoadIndex = mp_lLoadIndex + 1;
            return oRow;
        }


        public void EndLoad()
        {
            mp_oCollection.mp_aoCollection = mp_oTempCollection;
            mp_oCollection.mp_oKeys = mp_oTempDictionary;
            mp_oControl.VerticalScrollBar.Update();
            mp_oTempCollection = null;
            mp_oTempDictionary = null;
            mp_oTempNodeList = null;
            UpdateTree();
        }

        public void UpdateTree()
        {
            int lIndex = 0;
            clsRow oRow;
            mp_oTempNodeList = new ArrayList();
            for (lIndex = 1; lIndex <= Count; lIndex++)
            {
                oRow = (clsRow)mp_oCollection.m_oReturnArrayElement(lIndex);
                if (oRow.Node.Depth == 0)
                {
                    oRow.Node.mp_oParent = null;
                }
                else
                {
                    oRow.Node.mp_oParent = (clsNode)mp_oTempNodeList[oRow.Node.Depth - 1];
                }
                if (oRow.Node.Depth > (mp_oTempNodeList.Count - 1))
                {
                    mp_oTempNodeList.Add(oRow.Node);
                }
                else
                {
                    mp_oTempNodeList[oRow.Node.Depth] = oRow.Node;
                }
            }
        }

        internal void NodesDrawElements()
        {
            int lIndex = 0;
            clsNode oNode = null;
            clsRow oRow = null;
            if (Count == 0)
            {
                return;
            }
            for (lIndex = mp_lRealFirstVisibleRow; lIndex <= Count; lIndex++)
            {
                oRow = (clsRow)mp_oCollection.m_oReturnArrayElement(lIndex);
                oNode = oRow.Node;
                if (oRow.ClientAreaVisibility == E_CLIENTAREAVISIBILITY.VS_INSIDEVISIBLEAREA & oNode.Hidden == false)
                {
                    if (oNode.Children() > 0)
                    {
                        mp_DrawSign(oNode.Expanded, oNode.Left, oNode.YCenter, mp_oControl.Treeview.PlusMinusBorderColor, mp_oControl.Treeview.PlusMinusSignColor);
                    }
                    mp_DrawCheckBox(ref oNode);
                    mp_DrawImage(ref oNode);
                }
            }
        }
    
	}
}
