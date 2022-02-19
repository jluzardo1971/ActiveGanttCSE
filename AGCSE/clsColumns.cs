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
	public class clsColumns
	{
		private ActiveGanttCSECtl mp_oControl;
		private clsCollectionBase mp_oCollection;

		public clsColumns(ActiveGanttCSECtl Value)
		{
			mp_oControl = Value;
			mp_oCollection = new clsCollectionBase(Value, "Column");		
		}

		~clsColumns()
		{
		}

		public int Count 
		{
			get 
			{
				return mp_oCollection.m_lCount();
			}
		}

		public clsColumn Item(String Index)
		{
			return (clsColumn) mp_oCollection.m_oItem(Index, SYS_ERRORS.COLUMNS_ITEM_1, SYS_ERRORS.COLUMNS_ITEM_2, SYS_ERRORS.COLUMNS_ITEM_3, SYS_ERRORS.COLUMNS_ITEM_4);
		}

		internal clsCollectionBase oCollection 
		{
			get 
			{
				return mp_oCollection;
			}
		}

		public clsColumn Add(String Text, String Key, int Width, String StyleIndex)
		{
			mp_oCollection.AddMode = true;
			clsColumn oColumn = new clsColumn(mp_oControl);
			Text = mp_oControl.StrLib.StrTrim(Text);
			oColumn.Text= Text;
			oColumn.Width = Width;
			oColumn.StyleIndex = StyleIndex;
			mp_oCollection.m_Add(oColumn, "", SYS_ERRORS.COLUMNS_ADD_1, SYS_ERRORS.COLUMNS_ADD_2, false, SYS_ERRORS.COLUMNS_ADD_3);
			int lIndex;
			clsRow oRow;
			for (lIndex = 1;lIndex <= mp_oControl.Rows.Count;lIndex++) 
			{
				oRow = (clsRow) mp_oControl.Rows.oCollection.m_oReturnArrayElement(lIndex);
				oRow.Cells.Add();
			}
			mp_oControl.Splitter.f_AdjustPosition();
			return oColumn;
		}

		public void Clear()
		{
			mp_oControl.Rows.ClearCells();
			mp_oCollection.m_Clear();
			mp_oControl.SelectedColumnIndex = 0;
			mp_oControl.SelectedCellIndex = 0;
			mp_oControl.Splitter.f_AdjustPosition();
		}

		public void Remove(String Index)
		{
			int lIndex;
			clsRow oRow;
			for (lIndex = 1;lIndex <= mp_oControl.Rows.Count;lIndex++) 
			{
				oRow = (clsRow) mp_oControl.Rows.oCollection.m_oReturnArrayElement(lIndex);
				oRow.Cells.Remove(Index);
			}
			mp_oCollection.m_Remove(Index, SYS_ERRORS.COLUMNS_REMOVE_1, SYS_ERRORS.COLUMNS_REMOVE_2, SYS_ERRORS.COLUMNS_REMOVE_3, SYS_ERRORS.COLUMNS_REMOVE_4);
			mp_oControl.SelectedColumnIndex = 0;
			mp_oControl.SelectedCellIndex = 0;
			mp_oControl.Splitter.f_AdjustPosition();
		}

		public void MoveColumn(int OriginColumnIndex, int DestColumnIndex)
		{
            clsColumn oColumn;
            clsRow oRow;
            int lIndex = 0;
            if (OriginColumnIndex < 1 | OriginColumnIndex > Count)
            {
                return;
            }
            if (DestColumnIndex < 1 | DestColumnIndex > Count)
            {
                return;
            }
            if (DestColumnIndex == OriginColumnIndex)
            {
                return;
            }
            if (mp_oControl.TreeviewColumnIndex > 0)
            {
                for (lIndex = 1; lIndex <= mp_oControl.Columns.Count; lIndex++)
                {
                    oColumn = (clsColumn)mp_oControl.Columns.oCollection.m_oReturnArrayElement(lIndex);
                    if (lIndex == mp_oControl.TreeviewColumnIndex)
                    {
                        oColumn.mp_bTreeViewColumnIndex = true;
                    }
                    else
                    {
                        oColumn.mp_bTreeViewColumnIndex = false;
                    }
                }
            }
            mp_oCollection.m_lCopyAndMoveItems(OriginColumnIndex, DestColumnIndex);
            for (lIndex = 1; lIndex <= mp_oControl.Rows.Count; lIndex++)
            {
                oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(lIndex);
                oRow.Cells.oCollection.m_lCopyAndMoveItems(OriginColumnIndex, DestColumnIndex);
            }
            if (mp_oControl.TreeviewColumnIndex > 0)
            {
                for (lIndex = 1; lIndex <= mp_oControl.Columns.Count; lIndex++)
                {
                    oColumn = (clsColumn)mp_oControl.Columns.oCollection.m_oReturnArrayElement(lIndex);
                    if (oColumn.mp_bTreeViewColumnIndex == true)
                    {
                        mp_oControl.TreeviewColumnIndex = lIndex;
                    }
                }
            }
		}

		internal int Width 
		{
			get 
			{
				int lIndex;
				int lResult = 0;
				for (lIndex = 1;lIndex <= Count;lIndex++) 
				{
					clsColumn oColumn;
					oColumn = (clsColumn) mp_oCollection.m_oReturnArrayElement(lIndex);
					lResult = lResult + oColumn.Width;
				}
				return lResult;
			}
		}

		internal void Position()
		{
			int lIndex;
			clsColumn oColumn;
			int lLeft;
			lLeft = -mp_oControl.HorizontalScrollBar.Value + mp_oControl.mt_LeftMargin;
			for (lIndex = 1;lIndex <= Count;lIndex++) 
			{
				oColumn = (clsColumn) mp_oCollection.m_oReturnArrayElement(lIndex);
				oColumn.f_lLeft = lLeft;
				oColumn.f_lRight = lLeft + oColumn.Width;
				if (oColumn.Right < mp_oControl.mt_LeftMargin)
				{
					oColumn.f_bVisible = false;
				}
				else if (oColumn.Left > mp_oControl.Splitter.Left)
				{
					oColumn.f_bVisible = false;
				}
				else
				{
					oColumn.f_bVisible = true;
				}
				if (oColumn.Right > oColumn.Left)
				{
					oColumn.f_bVisible = true;
				}
				else
				{
					oColumn.f_bVisible = false;
				}
				lLeft = lLeft + oColumn.Width;
			}
		}

		internal void Draw()
		{
			clsColumn oColumn;
			int lIndex;
			if (Count == 0)
			{
				return;
			}
			if ((mp_oControl.CurrentViewObject.TimeLine.Height == 0))
			{
				return;
			}
			for (lIndex = 1;lIndex <= Count;lIndex++) 
			{
				oColumn = (clsColumn) mp_oCollection.m_oReturnArrayElement(lIndex);
				if (oColumn.Visible == true)
				{
					mp_oControl.clsG.ClipRegion(oColumn.LeftTrim, oColumn.Top, oColumn.RightTrim, oColumn.Bottom, true);
                    mp_oControl.DrawEventArgs.Clear();
                    mp_oControl.DrawEventArgs.CustomDraw = false;
                    mp_oControl.DrawEventArgs.EventTarget = E_EVENTTARGET.EVT_COLUMN;
                    mp_oControl.DrawEventArgs.ObjectIndex = lIndex;
                    mp_oControl.DrawEventArgs.ParentObjectIndex = 0;
                    //mp_oControl.DrawEventArgs.Graphics = mp_oControl.clsG.oGraphics;
                    mp_oControl.FireDraw();
                    if (mp_oControl.DrawEventArgs.CustomDraw == false)
					{
                        mp_oControl.clsG.mp_DrawItem(oColumn.Left, oColumn.Top, oColumn.Right - 1, oColumn.Bottom, "", oColumn.Text, (lIndex == mp_oControl.SelectedColumnIndex), oColumn.Image, oColumn.LeftTrim, oColumn.RightTrim, oColumn.Style);
                        if (oColumn.Text.Length > 0)
                        {
                            oColumn.mp_lTextLeft = mp_oControl.clsG.mp_oTextFinalLayout.Left;
                            oColumn.mp_lTextTop = mp_oControl.clsG.mp_oTextFinalLayout.Top;
                            oColumn.mp_lTextRight = mp_oControl.clsG.mp_oTextFinalLayout.Left + mp_oControl.clsG.mp_oTextFinalLayout.Width - 1;
                            oColumn.mp_lTextBottom = mp_oControl.clsG.mp_oTextFinalLayout.Top + mp_oControl.clsG.mp_oTextFinalLayout.Height - 1;
                        }
                        else
                        {
                            oColumn.mp_lTextLeft = oColumn.Left;
                            oColumn.mp_lTextTop = oColumn.Top;
                            oColumn.mp_lTextRight = oColumn.Right;
                            oColumn.mp_lTextBottom = oColumn.Bottom;
                        }
					}
				}
			}
		}

        public String GetXML()
        {
            int lIndex;
            clsColumn oColumn;
            clsXML oXML = new clsXML(mp_oControl, "Columns");
            oXML.InitializeWriter();
            for (lIndex = 1; lIndex <= Count; lIndex++)
            {
                oColumn = (clsColumn)mp_oCollection.m_oReturnArrayElement(lIndex);
                oXML.WriteObject(oColumn.GetXML());
            }
            return oXML.GetXML();
        }

        public void SetXML(String sXML)
        {
            int lIndex;
            clsXML oXML = new clsXML(mp_oControl, "Columns");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            mp_oCollection.m_Clear();
            for (lIndex = 1; lIndex <= oXML.ReadCollectionCount(); lIndex++)
            {
                clsColumn oColumn = new clsColumn(mp_oControl);
                oColumn.SetXML(oXML.ReadCollectionObject(lIndex));
                mp_oCollection.AddMode = true;
                mp_oCollection.m_Add(oColumn, oColumn.Key, SYS_ERRORS.COLUMNS_ADD_1, SYS_ERRORS.COLUMNS_ADD_2, false, SYS_ERRORS.COLUMNS_ADD_3);
                oColumn = null;
            }
        }

	}
}
