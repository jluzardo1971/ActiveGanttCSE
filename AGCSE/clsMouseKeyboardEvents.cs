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

    internal class clsMouseKeyboardEvents
    {

        private enum E_OPERATIONMODIFIER
        {
            OPM_NONE = 0,
            OPM_PREDECESSORMODE = 1
        }

        private struct S_TIMELINEMOVEMENT
        {
            public int lX;
            public void Clear()
            {
                lX = 0;
            }
        }

        private struct S_COLUMNMOVEMENT
        {
            public int lColumnIndex;
            public int lDestinationColumnIndex;
            public void Clear()
            {
                lColumnIndex = 0;
                lDestinationColumnIndex = 0;
            }
        }

        private struct S_COLUMNSIZING
        {
            public int lColumnIndex;
            public void Clear()
            {
                lColumnIndex = 0;
            }
        }

        private struct S_COLUMNSELECTION
        {
            public int lColumnIndex;
            public void Clear()
            {
                lColumnIndex = 0;
            }
        }

        private struct S_ROWMOVEMENT
        {
            public int lRowIndex;
            public int lDestinationRowIndex;
            public void Clear()
            {
                lRowIndex = 0;
                lDestinationRowIndex = 0;
            }
        }

        private struct S_ROWSIZING
        {
            public int lRowIndex;
            public void Clear()
            {
                lRowIndex = 0;
            }
        }

        private struct S_ROWSELECTION
        {
            public int lRowIndex;
            public int lCellIndex;
            public void Clear()
            {
                lRowIndex = 0;
                lCellIndex = 0;
            }
        }

        private struct S_TASKMOVEMENT
        {
            public int lInitialRowIndex;
            public string sInitialRowKey;
            public int lFinalRowIndex;
            public AGCSE.DateTime dtInitialStartDate;
            public AGCSE.DateTime dtInitialEndDate;
            public int lDeltaLeft;
            public int lDeltaRight;
            public int lDurationFactor;
            public void Clear()
            {
                lInitialRowIndex = 0;
                sInitialRowKey = "";
                lFinalRowIndex = 0;
                dtInitialStartDate = new AGCSE.DateTime();
                dtInitialEndDate = new AGCSE.DateTime();
                lDeltaLeft = 0;
                lDeltaRight = 0;
                lDurationFactor = 0;
            }
        }

        private struct S_TASKSTRETCHLEFT
        {
            public AGCSE.DateTime dtInitialStartDate;
            public AGCSE.DateTime dtInitialEndDate;
            public AGCSE.DateTime dtFinalStartDate;
            public int lRowIndex;
            public void Clear()
            {
                dtInitialStartDate = new AGCSE.DateTime();
                dtInitialEndDate = new AGCSE.DateTime();
                dtFinalStartDate = new AGCSE.DateTime();
                lRowIndex = 0;
            }
        }

        private struct S_TASKSTRETCHRIGHT
        {
            public AGCSE.DateTime dtInitialStartDate;
            public AGCSE.DateTime dtInitialEndDate;
            public AGCSE.DateTime dtFinalEndDate;
            public int lRowIndex;
            public void Clear()
            {
                dtInitialStartDate = new AGCSE.DateTime();
                dtInitialEndDate = new AGCSE.DateTime();
                dtFinalEndDate = new AGCSE.DateTime();
                lRowIndex = 0;
            }
        }

        private struct S_TASKSELECTION
        {
            public int lTaskIndex;
            public void Clear()
            {
                lTaskIndex = 0;
            }
        }

        private struct S_TASKADDITION
        {
            public bool bCancel;
            public bool bInConflict;
            public AGCSE.DateTime dtStartDate;
            public AGCSE.DateTime dtEndDate;
            public int lRowIndex;
            public void Clear()
            {
                bCancel = false;
                bInConflict = false;
                dtStartDate = new AGCSE.DateTime();
                dtEndDate = new AGCSE.DateTime();
                lRowIndex = 0;
            }
        }

        private struct S_PERCENTAGESELECTION
        {
            public int lPercentageIndex;
            public void Clear()
            {
                lPercentageIndex = 0;
            }
        }

        private struct S_PERCENTAGESIZING
        {
            public int lX;
            public int lTaskStart;
            public int lTaskEnd;
            public int lTaskIndex;
            public bool bMouseMove;
            public void Clear()
            {
                lX = 0;
                lTaskStart = 0;
                lTaskEnd = 0;
                lTaskIndex = 0;
                bMouseMove = true;
            }
        }

        private struct S_PREDECESSORSELECTION
        {
            public int lPredecessorIndex;
            public void Clear()
            {
                lPredecessorIndex = 0;
            }
        }

        private struct S_PREDECESSORADDITION
        {
            public int lXStart;
            public int lYStart;
            public int lTaskIndex;
            public string sTaskPosition;
            public int lPredecessorIndex;
            public string sPredecessorKey;
            public string sPredecessorPosition;
            public bool bCancel;
            public bool bCantAccept;
            public void Clear()
            {
                lXStart = 0;
                lYStart = 0;
                lTaskIndex = 0;
                sTaskPosition = "";
                lPredecessorIndex = 0;
                sPredecessorKey = "";
                sPredecessorPosition = "";
                bCancel = false;
                bCantAccept = false;
            }
        }



        internal E_OPERATION mp_yOperation = E_OPERATION.EO_NONE;
        private E_OPERATIONMODIFIER mp_yOperationModifier = E_OPERATIONMODIFIER.OPM_NONE;
        private ActiveGanttCSECtl mp_oControl;
        private S_TIMELINEMOVEMENT s_tmlnMVT;
        private S_COLUMNMOVEMENT s_clmnMVT;
        private S_COLUMNSIZING s_clmnSZ;
        private S_COLUMNSELECTION s_clmnSEL;
        private S_ROWMOVEMENT s_rowMVT;
        private S_ROWSIZING s_rowSZ;
        private S_ROWSELECTION s_rowSEL;
        private S_TASKMOVEMENT s_tskMVT;
        private S_TASKSTRETCHLEFT s_tskSTL;
        private S_TASKSTRETCHRIGHT s_tskSTR;
        private S_TASKSELECTION s_tskSEL;
        private S_TASKADDITION s_tskADD;
        private S_PERCENTAGESELECTION s_perSEL;
        private S_PERCENTAGESIZING s_perSZ;
        private S_PREDECESSORADDITION s_preADD;
        private S_PREDECESSORSELECTION s_preSEL;

        internal clsMouseKeyboardEvents(ActiveGanttCSECtl Value)
        {
            mp_oControl = Value;
        }

        internal void KeyDown(System.Windows.Input.Key KeyCode)
        {
            mp_oControl.KeyEventArgs.Clear();
            mp_oControl.KeyEventArgs.KeyCode = KeyCode;
            mp_oControl.KeyEventArgs.Cancel = false;
            mp_oControl.FireControlKeyDown();
            if (mp_oControl.KeyEventArgs.Cancel == true)
            {
                return;
            }
            if (KeyCode == mp_oControl.PredecessorAddModeKey)
            {
                mp_yOperationModifier = E_OPERATIONMODIFIER.OPM_PREDECESSORMODE;
            }
        }

        internal void KeyUp(System.Windows.Input.Key KeyCode)
        {
            mp_oControl.KeyEventArgs.Clear();
            mp_oControl.KeyEventArgs.KeyCode = KeyCode;
            mp_oControl.KeyEventArgs.Cancel = false;
            mp_oControl.FireControlKeyUp();
            mp_yOperationModifier = E_OPERATIONMODIFIER.OPM_NONE;
        }

        internal void KeyPress(char Key)
        {
            mp_oControl.KeyEventArgs.Clear();
            mp_oControl.KeyEventArgs.CharacterCode = Key;
            mp_oControl.KeyEventArgs.Cancel = false;
            mp_oControl.FireControlKeyDown();
            if (mp_oControl.KeyEventArgs.Cancel == true)
            {
                return;
            }
        }

        internal void OnMouseClick()
        {
            mp_oControl.FireControlClick();
            if (mp_oControl.MouseEventArgs.Cancel == true)
            {
                return;
            }
        }

        internal void OnMouseDblClick()
        {
            mp_oControl.FireControlDblClick();
            if (mp_oControl.MouseEventArgs.Cancel == true)
            {
                return;
            }
        }

        internal void OnMouseMoveGeneral(int X, int Y)
        {
            if (mp_yOperation == E_OPERATION.EO_NONE)
            {
                OnMouseHover(X, Y);
            }
            else
            {
                OnMouseMove(X, Y);
            }
        }

        internal void OnMouseHover(int X, int Y)
        {
            E_EVENTTARGET yEventTarget = E_EVENTTARGET.EVT_NONE;
            yEventTarget = CursorPosition(X, Y);
            mp_oControl.MouseEventArgs.Clear();
            mp_oControl.MouseEventArgs.X = X;
            mp_oControl.MouseEventArgs.Y = Y;
            mp_oControl.MouseEventArgs.EventTarget = yEventTarget;
            mp_oControl.MouseEventArgs.Cancel = false;
            mp_oControl.FireControlMouseHover();
            if (mp_oControl.MouseEventArgs.Cancel == true)
            {
                return;
            }
            mp_oControl.ToolTipEventArgs.Clear();
            mp_oControl.ToolTipEventArgs.X = X;
            mp_oControl.ToolTipEventArgs.Y = Y;
            mp_oControl.FireToolTipOnMouseHover(yEventTarget);
            switch (yEventTarget)
            {
                case E_EVENTTARGET.EVT_VSCROLLBAR:
                    mp_oControl.VerticalScrollBar.ScrollBar.OnMouseHover(X, Y);
                    break;
                case E_EVENTTARGET.EVT_HSCROLLBAR:
                    mp_oControl.HorizontalScrollBar.ScrollBar.OnMouseHover(X, Y);
                    break;
                case E_EVENTTARGET.EVT_TIMELINESCROLLBAR:
                    mp_oControl.CurrentViewObject.TimeLine.TimeLineScrollBar.ScrollBar.OnMouseHover(X, Y);
                    break;
                case E_EVENTTARGET.EVT_TREEVIEW:
                    mp_oControl.Treeview.OnMouseHover(X, Y);
                    break;
                case E_EVENTTARGET.EVT_SPLITTER:
                    mp_EO_SPLITTERMOVEMENT(E_MOUSEKEYBOARDEVENTS.MouseHover, X, Y);
                    break;
                case E_EVENTTARGET.EVT_TIMELINE:
                    mp_EO_TIMELINEMOVEMENT(E_MOUSEKEYBOARDEVENTS.MouseHover, X, Y);
                    break;
                case E_EVENTTARGET.EVT_SELECTEDCOLUMN:
                    if (mp_bCursorEditTextColumn(X, Y) == true)
                    {
                        return;
                    }
                    switch (mp_yColumnArea(X, Y))
                    {
                        case E_AREA.EA_RIGHT:
                            mp_EO_COLUMNSIZING(E_MOUSEKEYBOARDEVENTS.MouseHover, X, Y);
                            break;
                        case E_AREA.EA_CENTER:
                            mp_EO_COLUMNMOVEMENT(E_MOUSEKEYBOARDEVENTS.MouseHover, X, Y);
                            break;
                    }
                    break;
                case E_EVENTTARGET.EVT_COLUMN:
                    mp_EO_COLUMNSELECTION(E_MOUSEKEYBOARDEVENTS.MouseHover, X, Y);
                    break;
                case E_EVENTTARGET.EVT_SELECTEDROW:
                    if (mp_bCursorEditTextRow(X, Y) == true)
                    {
                        return;
                    }
                    switch (mp_yRowArea(X, Y))
                    {
                        case E_AREA.EA_BOTTOM:
                            mp_EO_ROWSIZING(E_MOUSEKEYBOARDEVENTS.MouseHover, X, Y);
                            break;
                        case E_AREA.EA_CENTER:
                            mp_EO_ROWMOVEMENT(E_MOUSEKEYBOARDEVENTS.MouseHover, X, Y);
                            break;
                    }
                    break;
                case E_EVENTTARGET.EVT_ROW:
                    mp_EO_ROWSELECTION(E_MOUSEKEYBOARDEVENTS.MouseHover, X, Y);
                    break;
                case E_EVENTTARGET.EVT_SELECTEDPERCENTAGE:
                    mp_EO_PERCENTAGESIZING(E_MOUSEKEYBOARDEVENTS.MouseHover, X, Y);
                    break;
                case E_EVENTTARGET.EVT_PERCENTAGE:
                    mp_EO_PERCENTAGESELECTION(E_MOUSEKEYBOARDEVENTS.MouseHover, X, Y);
                    break;
                case E_EVENTTARGET.EVT_SELECTEDTASK:
                    if (mp_yOperationModifier == E_OPERATIONMODIFIER.OPM_PREDECESSORMODE)
                    {
                        mp_EO_PREDECESSORADDITION(E_MOUSEKEYBOARDEVENTS.MouseHover, X, Y);
                    }
                    else
                    {
                        if (mp_bCursorEditTextTask(X, Y) == true)
                        {
                            return;
                        }
                        switch (mp_yTaskArea(X, Y))
                        {
                            case E_AREA.EA_CENTER:
                                mp_EO_TASKMOVEMENT(E_MOUSEKEYBOARDEVENTS.MouseHover, X, Y);
                                break;
                            case E_AREA.EA_LEFT:
                                mp_EO_TASKSTRETCHLEFT(E_MOUSEKEYBOARDEVENTS.MouseHover, X, Y);
                                break;
                            case E_AREA.EA_RIGHT:
                                mp_EO_TASKSTRETCHRIGHT(E_MOUSEKEYBOARDEVENTS.MouseHover, X, Y);
                                break;
                            case E_AREA.EA_NONE:
                                break;
                        }
                    }

                    break;
                case E_EVENTTARGET.EVT_TASK:
                    mp_EO_TASKSELECTION(E_MOUSEKEYBOARDEVENTS.MouseHover, X, Y);
                    break;
                case E_EVENTTARGET.EVT_SELECTEDPREDECESSOR:
                    //
                    break;
                case E_EVENTTARGET.EVT_PREDECESSOR:
                    mp_EO_PREDECESSORSELECTION(E_MOUSEKEYBOARDEVENTS.MouseHover, X, Y);
                    break;
                case E_EVENTTARGET.EVT_CLIENTAREA:
                    if (mp_bCursorEditTextTask(X, Y) == true)
                    {
                        return;
                    }
                    mp_EO_TASKADDITION(E_MOUSEKEYBOARDEVENTS.MouseHover, X, Y);
                    break;
                case E_EVENTTARGET.EVT_NONE:
                    mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
                    break;
                //Moving over empty space
            }
            System.Diagnostics.Debug.Assert(mp_yOperation == E_OPERATION.EO_NONE);
        }

        internal void OnMouseDown(int X, int Y, E_MOUSEBUTTONS Button)
        {
            mp_oControl.mp_oTextBox.Terminate();
            E_EVENTTARGET EventTarget = E_EVENTTARGET.EVT_NONE;
            EventTarget = CursorPosition(X, Y);
            mp_oControl.MouseEventArgs.Clear();
            mp_oControl.MouseEventArgs.X = X;
            mp_oControl.MouseEventArgs.Y = Y;
            mp_oControl.MouseEventArgs.EventTarget = EventTarget;
            mp_oControl.MouseEventArgs.Button = (E_MOUSEBUTTONS)Button;
            mp_oControl.MouseEventArgs.Cancel = false;
            mp_oControl.FireControlMouseDown();
            if (mp_oControl.MouseEventArgs.Cancel == true)
            {
                return;
            }
            switch (CursorPosition(X, Y))
            {
                case E_EVENTTARGET.EVT_VSCROLLBAR:
                    mp_oControl.VerticalScrollBar.ScrollBar.OnMouseDown(X, Y);
                    mp_yOperation = E_OPERATION.EO_VERTICALSCROLLBAR;
                    break;
                case E_EVENTTARGET.EVT_HSCROLLBAR:
                    mp_oControl.HorizontalScrollBar.ScrollBar.OnMouseDown(X, Y);
                    mp_yOperation = E_OPERATION.EO_HORIZONTALSCROLLBAR;
                    break;
                case E_EVENTTARGET.EVT_TIMELINESCROLLBAR:
                    mp_oControl.CurrentViewObject.TimeLine.TimeLineScrollBar.ScrollBar.OnMouseDown(X, Y);
                    mp_yOperation = E_OPERATION.EO_TIMELINESCROLLBAR;
                    break;
                case E_EVENTTARGET.EVT_TREEVIEW:
                    mp_oControl.Treeview.OnMouseDown(X, Y);
                    mp_yOperation = E_OPERATION.EO_TREEVIEW;
                    break;
                case E_EVENTTARGET.EVT_SPLITTER:
                    mp_EO_SPLITTERMOVEMENT(E_MOUSEKEYBOARDEVENTS.MouseDown, X, Y);
                    mp_yOperation = E_OPERATION.EO_SPLITTERMOVEMENT;
                    break;
                case E_EVENTTARGET.EVT_TIMELINE:
                    mp_EO_TIMELINEMOVEMENT(E_MOUSEKEYBOARDEVENTS.MouseDown, X, Y);
                    mp_yOperation = E_OPERATION.EO_TIMELINEMOVEMENT;
                    break;
                case E_EVENTTARGET.EVT_SELECTEDCOLUMN:
                    if (mp_bShowEditTextColumn(X, Y) == true)
                    {
                        return;
                    }
                    switch (mp_yColumnArea(X, Y))
                    {
                        case E_AREA.EA_RIGHT:
                            mp_EO_COLUMNSIZING(E_MOUSEKEYBOARDEVENTS.MouseDown, X, Y);
                            mp_yOperation = E_OPERATION.EO_COLUMNSIZING;
                            break;
                        case E_AREA.EA_CENTER:
                            mp_EO_COLUMNMOVEMENT(E_MOUSEKEYBOARDEVENTS.MouseDown, X, Y);
                            mp_yOperation = E_OPERATION.EO_COLUMNMOVEMENT;
                            break;
                    }
                    break;
                case E_EVENTTARGET.EVT_COLUMN:
                    mp_EO_COLUMNSELECTION(E_MOUSEKEYBOARDEVENTS.MouseDown, X, Y);
                    mp_yOperation = E_OPERATION.EO_COLUMNSELECTION;
                    break;
                case E_EVENTTARGET.EVT_SELECTEDROW:
                    if (mp_bShowEditTextRow(X, Y) == true)
                    {
                        return;
                    }
                    switch (mp_yRowArea(X, Y))
                    {
                        case E_AREA.EA_BOTTOM:
                            mp_EO_ROWSIZING(E_MOUSEKEYBOARDEVENTS.MouseDown, X, Y);
                            mp_yOperation = E_OPERATION.EO_ROWSIZING;
                            break;
                        case E_AREA.EA_CENTER:
                            mp_EO_ROWMOVEMENT(E_MOUSEKEYBOARDEVENTS.MouseDown, X, Y);
                            mp_yOperation = E_OPERATION.EO_ROWMOVEMENT;
                            break;
                    }
                    break;
                case E_EVENTTARGET.EVT_ROW:
                    mp_EO_ROWSELECTION(E_MOUSEKEYBOARDEVENTS.MouseDown, X, Y);
                    mp_yOperation = E_OPERATION.EO_ROWSELECTION;
                    break;
                case E_EVENTTARGET.EVT_SELECTEDPERCENTAGE:
                    mp_EO_PERCENTAGESIZING(E_MOUSEKEYBOARDEVENTS.MouseDown, X, Y);
                    mp_yOperation = E_OPERATION.EO_PERCENTAGESIZING;
                    break;
                case E_EVENTTARGET.EVT_PERCENTAGE:
                    mp_EO_PERCENTAGESELECTION(E_MOUSEKEYBOARDEVENTS.MouseDown, X, Y);
                    mp_yOperation = E_OPERATION.EO_PERCENTAGESELECTION;
                    break;
                case E_EVENTTARGET.EVT_SELECTEDTASK:
                    if (mp_yOperationModifier == E_OPERATIONMODIFIER.OPM_PREDECESSORMODE)
                    {
                        mp_EO_PREDECESSORADDITION(E_MOUSEKEYBOARDEVENTS.MouseDown, X, Y);
                        mp_yOperation = E_OPERATION.EO_PREDECESSORADDITION;
                    }
                    else
                    {
                        if (mp_bShowEditTextTask(X, Y) == true)
                        {
                            return;
                        }
                        switch (mp_yTaskArea(X, Y))
                        {
                            case E_AREA.EA_CENTER:
                                mp_EO_TASKMOVEMENT(E_MOUSEKEYBOARDEVENTS.MouseDown, X, Y);
                                mp_yOperation = E_OPERATION.EO_TASKMOVEMENT;
                                break;
                            case E_AREA.EA_LEFT:
                                mp_EO_TASKSTRETCHLEFT(E_MOUSEKEYBOARDEVENTS.MouseDown, X, Y);
                                mp_yOperation = E_OPERATION.EO_TASKSTRETCHLEFT;
                                break;
                            case E_AREA.EA_RIGHT:
                                mp_EO_TASKSTRETCHRIGHT(E_MOUSEKEYBOARDEVENTS.MouseDown, X, Y);
                                mp_yOperation = E_OPERATION.EO_TASKSTRETCHRIGHT;
                                break;
                            case E_AREA.EA_NONE:
                                mp_yOperation = E_OPERATION.EO_NONE;
                                break;
                        }
                    }

                    break;
                case E_EVENTTARGET.EVT_TASK:
                    mp_EO_TASKSELECTION(E_MOUSEKEYBOARDEVENTS.MouseDown, X, Y);
                    mp_yOperation = E_OPERATION.EO_TASKSELECTION;
                    break;
                case E_EVENTTARGET.EVT_SELECTEDPREDECESSOR:
                    //
                    break;
                case E_EVENTTARGET.EVT_PREDECESSOR:
                    mp_EO_PREDECESSORSELECTION(E_MOUSEKEYBOARDEVENTS.MouseDown, X, Y);
                    mp_yOperation = E_OPERATION.EO_PREDECESSORSELECTION;
                    break;
                case E_EVENTTARGET.EVT_CLIENTAREA:
                    if (mp_bShowEditTextTask(X, Y) == true)
                    {
                        return;
                    }
				    mp_EO_TASKADDITION(E_MOUSEKEYBOARDEVENTS.MouseDown, X, Y);
				    switch (mp_oControl.AddMode) {
					    case E_ADDMODE.AT_TASKADD:
					    case E_ADDMODE.AT_DURATION_TASKADD:
						    mp_yOperation = E_OPERATION.EO_TASKADDITION;
						    break;
					    case E_ADDMODE.AT_MILESTONEADD:
					    case E_ADDMODE.AT_DURATION_MILESTONEADD:
						    mp_yOperation = E_OPERATION.EO_MILESTONEADDITION;
						    break;
					    case E_ADDMODE.AT_BOTH:
					    case E_ADDMODE.AT_DURATION_BOTH:
						    mp_yOperation = E_OPERATION.EO_TASKADDITION;
						    break;
				    }
				    break;
            }
        }

        internal void OnMouseMove(int X, int Y)
        {
            E_OPERATION yOperation = mp_yOperation;
            mp_oControl.MouseEventArgs.X = X;
            mp_oControl.MouseEventArgs.Y = Y;
            mp_oControl.MouseEventArgs.Operation = mp_yOperation;
            mp_oControl.FireControlMouseMove();
            if (mp_oControl.MouseEventArgs.Cancel == true)
            {
                mp_yOperation = E_OPERATION.EO_NONE;
                return;
            }
            switch (mp_yOperation)
            {
                case E_OPERATION.EO_VERTICALSCROLLBAR:
                    mp_oControl.VerticalScrollBar.ScrollBar.OnMouseMove(X, Y);
                    break;
                case E_OPERATION.EO_HORIZONTALSCROLLBAR:
                    mp_oControl.HorizontalScrollBar.ScrollBar.OnMouseMove(X, Y);
                    break;
                case E_OPERATION.EO_TIMELINESCROLLBAR:
                    mp_oControl.CurrentViewObject.TimeLine.TimeLineScrollBar.ScrollBar.OnMouseMove(X, Y);
                    break;
                case E_OPERATION.EO_TREEVIEW:
                    mp_oControl.Treeview.OnMouseMove(X, Y);
                    break;
                case E_OPERATION.EO_SPLITTERMOVEMENT:
                    mp_EO_SPLITTERMOVEMENT(E_MOUSEKEYBOARDEVENTS.MouseMove, X, Y);
                    break;
                case E_OPERATION.EO_TIMELINEMOVEMENT:
                    mp_EO_TIMELINEMOVEMENT(E_MOUSEKEYBOARDEVENTS.MouseMove, X, Y);
                    break;
                case E_OPERATION.EO_COLUMNMOVEMENT:
                    mp_EO_COLUMNMOVEMENT(E_MOUSEKEYBOARDEVENTS.MouseMove, X, Y);
                    break;
                case E_OPERATION.EO_COLUMNSIZING:
                    mp_EO_COLUMNSIZING(E_MOUSEKEYBOARDEVENTS.MouseMove, X, Y);
                    break;
                case E_OPERATION.EO_COLUMNSELECTION:
                    mp_EO_COLUMNSELECTION(E_MOUSEKEYBOARDEVENTS.MouseMove, X, Y);
                    break;
                case E_OPERATION.EO_ROWMOVEMENT:
                    mp_EO_ROWMOVEMENT(E_MOUSEKEYBOARDEVENTS.MouseMove, X, Y);
                    break;
                case E_OPERATION.EO_ROWSIZING:
                    mp_EO_ROWSIZING(E_MOUSEKEYBOARDEVENTS.MouseMove, X, Y);
                    break;
                case E_OPERATION.EO_ROWSELECTION:
                    mp_EO_ROWSELECTION(E_MOUSEKEYBOARDEVENTS.MouseMove, X, Y);
                    break;
                case E_OPERATION.EO_PERCENTAGESIZING:
                    mp_EO_PERCENTAGESIZING(E_MOUSEKEYBOARDEVENTS.MouseMove, X, Y);
                    break;
                case E_OPERATION.EO_PERCENTAGESELECTION:
                    mp_EO_PERCENTAGESELECTION(E_MOUSEKEYBOARDEVENTS.MouseMove, X, Y);
                    break;
                case E_OPERATION.EO_PREDECESSORADDITION:
                    mp_EO_PREDECESSORADDITION(E_MOUSEKEYBOARDEVENTS.MouseMove, X, Y);
                    break;
                case E_OPERATION.EO_TASKMOVEMENT:
                    mp_EO_TASKMOVEMENT(E_MOUSEKEYBOARDEVENTS.MouseMove, X, Y);
                    break;
                case E_OPERATION.EO_TASKSTRETCHLEFT:
                    mp_EO_TASKSTRETCHLEFT(E_MOUSEKEYBOARDEVENTS.MouseMove, X, Y);
                    break;
                case E_OPERATION.EO_TASKSTRETCHRIGHT:
                    mp_EO_TASKSTRETCHRIGHT(E_MOUSEKEYBOARDEVENTS.MouseMove, X, Y);
                    break;
                case E_OPERATION.EO_TASKSELECTION:
                    mp_EO_TASKSELECTION(E_MOUSEKEYBOARDEVENTS.MouseMove, X, Y);
                    break;
                case E_OPERATION.EO_TASKADDITION:
                    mp_EO_TASKADDITION(E_MOUSEKEYBOARDEVENTS.MouseMove, X, Y);
                    break;
            }
            System.Diagnostics.Debug.Assert(yOperation == mp_yOperation);
        }

        internal void OnMouseUp(int X, int Y)
        {
            mp_oControl.MouseEventArgs.X = X;
            mp_oControl.MouseEventArgs.Y = Y;
            mp_oControl.FireControlMouseUp();
            if (mp_oControl.MouseEventArgs.Cancel == true)
            {
                mp_yOperation = E_OPERATION.EO_NONE;
                return;
            }
            switch (mp_yOperation)
            {
                case E_OPERATION.EO_VERTICALSCROLLBAR:
                    mp_oControl.VerticalScrollBar.ScrollBar.OnMouseUp();
                    break;
                case E_OPERATION.EO_HORIZONTALSCROLLBAR:
                    mp_oControl.HorizontalScrollBar.ScrollBar.OnMouseUp();
                    break;
                case E_OPERATION.EO_TIMELINESCROLLBAR:
                    mp_oControl.CurrentViewObject.TimeLine.TimeLineScrollBar.ScrollBar.OnMouseUp();
                    break;
                case E_OPERATION.EO_TREEVIEW:
                    mp_oControl.Treeview.OnMouseUp(X, Y);
                    break;
                case E_OPERATION.EO_SPLITTERMOVEMENT:
                    mp_EO_SPLITTERMOVEMENT(E_MOUSEKEYBOARDEVENTS.MouseUp, X, Y);
                    break;
                case E_OPERATION.EO_TIMELINEMOVEMENT:
                    mp_EO_TIMELINEMOVEMENT(E_MOUSEKEYBOARDEVENTS.MouseUp, X, Y);
                    break;
                case E_OPERATION.EO_COLUMNMOVEMENT:
                    mp_EO_COLUMNMOVEMENT(E_MOUSEKEYBOARDEVENTS.MouseUp, X, Y);
                    break;
                case E_OPERATION.EO_COLUMNSIZING:
                    mp_EO_COLUMNSIZING(E_MOUSEKEYBOARDEVENTS.MouseUp, X, Y);
                    break;
                case E_OPERATION.EO_COLUMNSELECTION:
                    mp_EO_COLUMNSELECTION(E_MOUSEKEYBOARDEVENTS.MouseUp, X, Y);
                    break;
                case E_OPERATION.EO_ROWMOVEMENT:
                    mp_EO_ROWMOVEMENT(E_MOUSEKEYBOARDEVENTS.MouseUp, X, Y);
                    break;
                case E_OPERATION.EO_ROWSIZING:
                    mp_EO_ROWSIZING(E_MOUSEKEYBOARDEVENTS.MouseUp, X, Y);
                    break;
                case E_OPERATION.EO_ROWSELECTION:
                    mp_EO_ROWSELECTION(E_MOUSEKEYBOARDEVENTS.MouseUp, X, Y);
                    break;
                case E_OPERATION.EO_PERCENTAGESELECTION:
                    mp_EO_PERCENTAGESELECTION(E_MOUSEKEYBOARDEVENTS.MouseUp, X, Y);
                    break;
                case E_OPERATION.EO_PERCENTAGESIZING:
                    mp_EO_PERCENTAGESIZING(E_MOUSEKEYBOARDEVENTS.MouseUp, X, Y);
                    break;
                case E_OPERATION.EO_PREDECESSORADDITION:
                    mp_EO_PREDECESSORADDITION(E_MOUSEKEYBOARDEVENTS.MouseUp, X, Y);
                    break;
                case E_OPERATION.EO_TASKMOVEMENT:
                    mp_EO_TASKMOVEMENT(E_MOUSEKEYBOARDEVENTS.MouseUp, X, Y);
                    break;
                case E_OPERATION.EO_TASKSTRETCHLEFT:
                    mp_EO_TASKSTRETCHLEFT(E_MOUSEKEYBOARDEVENTS.MouseUp, X, Y);
                    break;
                case E_OPERATION.EO_TASKSTRETCHRIGHT:
                    mp_EO_TASKSTRETCHRIGHT(E_MOUSEKEYBOARDEVENTS.MouseUp, X, Y);
                    break;
                case E_OPERATION.EO_TASKSELECTION:
                    mp_EO_TASKSELECTION(E_MOUSEKEYBOARDEVENTS.MouseUp, X, Y);
                    break;
                case E_OPERATION.EO_TASKADDITION:
                    mp_EO_TASKADDITION(E_MOUSEKEYBOARDEVENTS.MouseUp, X, Y);
                    break;
                case E_OPERATION.EO_PREDECESSORSELECTION:
                    mp_EO_PREDECESSORSELECTION(E_MOUSEKEYBOARDEVENTS.MouseUp, X, Y);
                    break;
            }
            mp_yOperation = E_OPERATION.EO_NONE;
        }

        private E_EVENTTARGET CursorPosition(int X, int Y)
        {
            if (mp_oControl.VerticalScrollBar.ScrollBar.OverControl(X, Y) == true)
            {
                return E_EVENTTARGET.EVT_VSCROLLBAR;
            }
            else if (mp_oControl.HorizontalScrollBar.ScrollBar.OverControl(X, Y) == true)
            {
                return E_EVENTTARGET.EVT_HSCROLLBAR;
            }
            else if (mp_oControl.CurrentViewObject.TimeLine.TimeLineScrollBar.ScrollBar.OverControl(X, Y) == true)
            {
                return E_EVENTTARGET.EVT_TIMELINESCROLLBAR;
            }
            else if (mp_oControl.Treeview.OverControl(X, Y) == true)
            {
                return E_EVENTTARGET.EVT_TREEVIEW;
            }
            else if (mp_bOverSplitter(X, Y) == true)
            {
                return E_EVENTTARGET.EVT_SPLITTER;
            }
            else if (mp_bOverEmptySpace(Y) == true)
            {
                return E_EVENTTARGET.EVT_NONE;
            }
            else if (mp_bOverTimeLine(X, Y) == true)
            {
                return E_EVENTTARGET.EVT_TIMELINE;
            }
            else if (mp_bOverSelectedColumn(X, Y) == true)
            {
                return E_EVENTTARGET.EVT_SELECTEDCOLUMN;
            }
            else if (mp_bOverColumn(X, Y) == true)
            {
                return E_EVENTTARGET.EVT_COLUMN;
            }
            else if (mp_bOverSelectedRow(X, Y) == true)
            {
                return E_EVENTTARGET.EVT_SELECTEDROW;
            }
            else if (mp_bOverRow(X, Y) == true)
            {
                return E_EVENTTARGET.EVT_ROW;
            }
            else if (mp_bOverSelectedPercentage(X, Y) == true & mp_yOperationModifier != E_OPERATIONMODIFIER.OPM_PREDECESSORMODE)
            {
                return E_EVENTTARGET.EVT_SELECTEDPERCENTAGE;
            }
            else if (mp_bOverPercentage(X, Y) == true & mp_yOperationModifier != E_OPERATIONMODIFIER.OPM_PREDECESSORMODE)
            {
                return E_EVENTTARGET.EVT_PERCENTAGE;
            }
            else if (mp_bOverSelectedTask(X, Y) == true)
            {
                return E_EVENTTARGET.EVT_SELECTEDTASK;
            }
            else if (mp_bOverTask(X, Y) == true)
            {
                return E_EVENTTARGET.EVT_TASK;
            }
            else if (mp_bOverSelectedPredecessor(X, Y) == true)
            {
                return E_EVENTTARGET.EVT_SELECTEDPREDECESSOR;
            }
            else if (mp_bOverPredecessor(X, Y) == true)
            {
                return E_EVENTTARGET.EVT_PREDECESSOR;
            }
            else if (mp_bOverClientArea(X, Y) == true)
            {
                return E_EVENTTARGET.EVT_CLIENTAREA;
            }
            else
            {
                return E_EVENTTARGET.EVT_NONE;
            }
        }

        private void mp_EO_SPLITTERMOVEMENT(E_MOUSEKEYBOARDEVENTS yMouseKeyBoardEvent, int X, int Y)
        {
            if (mp_oControl.AllowSplitterMove == false)
            {
                return;
            }
            switch (yMouseKeyBoardEvent)
            {
                case E_MOUSEKEYBOARDEVENTS.MouseHover:
                    mp_SetCursor(E_CURSORTYPE.CT_MOVESPLITTER);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDown:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseMove:
                    mp_oControl.clsG.EraseReversibleFrames();
                    mp_DrawMovingReversibleFrame(X, 0, X + 2, 0, E_FOCUSTYPE.FCT_VERTICALSPLITTER);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseUp:
                    int lWidth = 0;
                    if (X > (mp_oControl.clsG.Width - 10))
                    {
                        X = mp_oControl.clsG.Width - 10;
                    }

                    if (X < 10)
                    {
                        X = 10;
                    }
                    lWidth = mp_oControl.Columns.Width;
                    if (X > lWidth)
                    {
                        X = lWidth;
                        mp_oControl.Splitter.Position = X;
                        mp_oControl.HorizontalScrollBar.Value = 0;
                    }
                    else if (X > (lWidth - mp_oControl.HorizontalScrollBar.Value))
                    {
                        X = (lWidth - mp_oControl.HorizontalScrollBar.Value);
                        mp_oControl.Splitter.Position = X;
                    }
                    else
                    {
                        mp_oControl.Splitter.Position = X;
                    }

                    mp_oControl.clsG.EraseReversibleFrames();
                    mp_oControl.Redraw();
                    mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDblClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseWheel:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyDown:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyUp:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyPress:
                    break;
            }
        }

        private void mp_EO_TIMELINEMOVEMENT(E_MOUSEKEYBOARDEVENTS yMouseKeyBoardEvent, int X, int Y)
        {
            if (mp_oControl.AllowTimeLineScroll == false)
            {
                return;
            }
            if (mp_oControl.CurrentViewObject.TimeLine.TimeLineScrollBar.Enabled == true)
            {
                return;
            }
            switch (yMouseKeyBoardEvent)
            {
                case E_MOUSEKEYBOARDEVENTS.MouseHover:
                    mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDown:
                    mp_SetCursor(E_CURSORTYPE.CT_SCROLLTIMELINE);
                    s_tmlnMVT.lX = X;
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseMove:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseUp:
                    mp_oControl.CurrentViewObject.TimeLine.f_StartDate = mp_oControl.MathLib.DateTimeAdd(mp_oControl.CurrentViewObject.Interval, (s_tmlnMVT.lX - X) * mp_oControl.CurrentViewObject.Factor, mp_oControl.CurrentViewObject.TimeLine.StartDate);
                    mp_oControl.Redraw();
                    mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDblClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseWheel:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyDown:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyUp:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyPress:
                    break;
            }
        }

        private void mp_EO_COLUMNMOVEMENT(E_MOUSEKEYBOARDEVENTS yMouseKeyBoardEvent, int X, int Y)
        {
            clsColumn oColumn = null;
            clsColumn oDestinationColumn = null;
            clsRow oRow = null;
            int lIndex = 0;
            if (mp_oControl.AllowColumnMove == false)
            {
                return;
            }
            oColumn = (clsColumn)mp_oControl.Columns.oCollection.m_oReturnArrayElement(mp_oControl.SelectedColumnIndex);
            if (oColumn.AllowMove == false)
            {
                return;
            }
            switch (yMouseKeyBoardEvent)
            {
                case E_MOUSEKEYBOARDEVENTS.MouseHover:
                    mp_SetCursor(E_CURSORTYPE.CT_MOVECOLUMN);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDown:
                    s_clmnMVT.lColumnIndex = mp_oControl.MathLib.GetColumnIndexByPosition(X, Y);
                    System.Diagnostics.Debug.Assert(s_clmnMVT.lColumnIndex >= 1);
                    mp_oControl.ObjectStateChangedEventArgs.Clear();
                    mp_oControl.ObjectStateChangedEventArgs.EventTarget = E_EVENTTARGET.EVT_COLUMN;
                    mp_oControl.ObjectStateChangedEventArgs.Index = s_clmnMVT.lColumnIndex;
                    mp_oControl.ObjectStateChangedEventArgs.Cancel = false;
                    mp_oControl.FireBeginObjectMove();
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseMove:
                    if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                    {
                        mp_oControl.clsG.EraseReversibleFrames();
                        mp_DynamicColumnMove(X);
                        s_clmnMVT.lDestinationColumnIndex = mp_oControl.MathLib.GetColumnIndexByPosition(X, Y);
                        if (s_clmnMVT.lDestinationColumnIndex >= 1)
                        {
                            mp_oControl.clsG.EraseReversibleFrames();
                            mp_oControl.ObjectStateChangedEventArgs.DestinationIndex = s_clmnMVT.lDestinationColumnIndex;
                            mp_oControl.FireObjectMove();
                            if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                            {
                                oDestinationColumn = (clsColumn)mp_oControl.Columns.oCollection.m_oReturnArrayElement(s_clmnMVT.lDestinationColumnIndex);
                                mp_DrawMovingReversibleFrame(oDestinationColumn.LeftTrim, oDestinationColumn.Top, oDestinationColumn.RightTrim, oDestinationColumn.Bottom, E_FOCUSTYPE.FCT_NORMAL);
                            }
                        }
                    }

                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseUp:
                    if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                    {
                        mp_oControl.clsG.EraseReversibleFrames();
                        mp_oControl.FireEndObjectMove();
                        if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                        {
                            s_clmnMVT.lDestinationColumnIndex = mp_oControl.MathLib.GetColumnIndexByPosition(X, Y);
                            if (s_clmnMVT.lDestinationColumnIndex >= 1 & (s_clmnMVT.lColumnIndex != s_clmnMVT.lDestinationColumnIndex))
                            {
                                mp_oControl.FireCompleteObjectMove();
                                if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                                {
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
                                    mp_oControl.SelectedColumnIndex = mp_oControl.Columns.oCollection.m_lCopyAndMoveItems(s_clmnMVT.lColumnIndex, s_clmnMVT.lDestinationColumnIndex);
                                    for (lIndex = 1; lIndex <= mp_oControl.Rows.Count; lIndex++)
                                    {
                                        oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(lIndex);
                                        oRow.Cells.oCollection.m_lCopyAndMoveItems(s_clmnMVT.lColumnIndex, s_clmnMVT.lDestinationColumnIndex);
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
                            }
                        }
                    }

                    mp_oControl.Redraw();
                    mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDblClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseWheel:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyDown:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyUp:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyPress:
                    break;
            }
        }

        private void mp_EO_COLUMNSIZING(E_MOUSEKEYBOARDEVENTS yMouseKeyBoardEvent, int X, int Y)
        {
            clsColumn oColumn = null;
            if (mp_oControl.AllowColumnSize == false)
            {
                return;
            }
            oColumn = (clsColumn)mp_oControl.Columns.oCollection.m_oReturnArrayElement(mp_oControl.SelectedColumnIndex);
            if (oColumn.AllowSize == false)
            {
                return;
            }
            switch (yMouseKeyBoardEvent)
            {
                case E_MOUSEKEYBOARDEVENTS.MouseHover:
                    mp_SetCursor(E_CURSORTYPE.CT_COLUMNWIDTH);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDown:
                    s_clmnSZ.lColumnIndex = mp_oControl.MathLib.GetColumnIndexByPosition(X, Y);
                    System.Diagnostics.Debug.Assert(s_clmnSZ.lColumnIndex >= 1);
                    mp_oControl.ObjectStateChangedEventArgs.Clear();
                    mp_oControl.ObjectStateChangedEventArgs.EventTarget = E_EVENTTARGET.EVT_COLUMN;
                    mp_oControl.ObjectStateChangedEventArgs.Index = s_clmnSZ.lColumnIndex;
                    mp_oControl.ObjectStateChangedEventArgs.Cancel = false;
                    mp_oControl.FireBeginObjectSize();
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseMove:
                    if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                    {
                        mp_oControl.clsG.EraseReversibleFrames();
                        mp_oControl.FireObjectSize();
                        if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                        {
                            mp_DrawMovingReversibleFrame(X, 0, X + 2, mp_oControl.clsG.Height, E_FOCUSTYPE.FCT_NORMAL);
                        }
                    }

                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseUp:
                    if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                    {
                        mp_oControl.clsG.EraseReversibleFrames();
                        mp_oControl.FireEndObjectSize();
                        if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                        {
                            if (X < mp_oControl.mt_BorderThickness)
                            {
                                X = mp_oControl.mt_BorderThickness;
                            }
                            if (X > mp_oControl.Splitter.Position)
                            {
                                mp_oControl.Splitter.Position = X;
                            }
                            oColumn = (clsColumn)mp_oControl.Columns.oCollection.m_oReturnArrayElement(s_clmnSZ.lColumnIndex);
                            oColumn.Width = oColumn.Width + (X - oColumn.Right);
                            if (oColumn.Width < mp_oControl.MinColumnWidth)
                            {
                                oColumn.Width = mp_oControl.MinColumnWidth;
                            }
                            if (mp_oControl.Splitter.Position > mp_oControl.Columns.Width)
                            {
                                mp_oControl.Splitter.Position = mp_oControl.Columns.Width;
                                mp_oControl.HorizontalScrollBar.Value = 0;
                            }
                            mp_oControl.FireCompleteObjectSize();
                        }
                    }

                    mp_oControl.Redraw();
                    mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDblClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseWheel:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyDown:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyUp:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyPress:
                    break;
            }
        }

        private void mp_EO_COLUMNSELECTION(E_MOUSEKEYBOARDEVENTS yMouseKeyBoardEvent, int X, int Y)
        {
            switch (yMouseKeyBoardEvent)
            {
                case E_MOUSEKEYBOARDEVENTS.MouseHover:
                    mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDown:
                    s_clmnSEL.lColumnIndex = mp_oControl.MathLib.GetColumnIndexByPosition(X, Y);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseMove:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseUp:
                    mp_oControl.SelectedColumnIndex = s_clmnSEL.lColumnIndex;
                    mp_oControl.ObjectSelectedEventArgs.Clear();
                    mp_oControl.ObjectSelectedEventArgs.EventTarget = E_EVENTTARGET.EVT_COLUMN;
                    mp_oControl.ObjectSelectedEventArgs.ObjectIndex = mp_oControl.SelectedColumnIndex;
                    mp_oControl.FireObjectSelected();
                    mp_oControl.Redraw();
                    mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDblClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseWheel:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyDown:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyUp:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyPress:
                    break;
            }
        }

        private void mp_EO_ROWMOVEMENT(E_MOUSEKEYBOARDEVENTS yMouseKeyBoardEvent, int X, int Y)
        {
            clsRow oRow = null;
            clsRow oDestinationRow = null;
            if (mp_oControl.AllowRowMove == false)
            {
                return;
            }
            oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(mp_oControl.SelectedRowIndex);
            if (oRow.AllowMove == false)
            {
                return;
            }
            switch (yMouseKeyBoardEvent)
            {
                case E_MOUSEKEYBOARDEVENTS.MouseHover:
                    mp_SetCursor(E_CURSORTYPE.CT_MOVEROW);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDown:
                    s_rowMVT.lRowIndex = mp_oControl.MathLib.GetRowIndexByPosition(Y);
                    System.Diagnostics.Debug.Assert(s_rowMVT.lRowIndex >= 1);
                    mp_oControl.ObjectStateChangedEventArgs.Clear();
                    mp_oControl.ObjectStateChangedEventArgs.EventTarget = E_EVENTTARGET.EVT_ROW;
                    mp_oControl.ObjectStateChangedEventArgs.Index = s_rowMVT.lRowIndex;
                    mp_oControl.ObjectStateChangedEventArgs.InitialRowIndex = s_rowMVT.lRowIndex;
                    mp_oControl.ObjectStateChangedEventArgs.Cancel = false;
                    mp_oControl.FireBeginObjectMove();
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseMove:
                    if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                    {
                        mp_oControl.clsG.EraseReversibleFrames();
                        mp_DynamicRowMove(Y);
                        s_rowMVT.lDestinationRowIndex = mp_oControl.MathLib.GetRowIndexByPosition(Y);
                        if (s_rowMVT.lDestinationRowIndex >= 1)
                        {
                            mp_oControl.clsG.EraseReversibleFrames();
                            mp_oControl.ObjectStateChangedEventArgs.DestinationIndex = s_rowMVT.lDestinationRowIndex;
                            mp_oControl.ObjectStateChangedEventArgs.FinalRowIndex = s_rowMVT.lDestinationRowIndex;
                            mp_oControl.FireObjectMove();
                            if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                            {
                                oDestinationRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(s_rowMVT.lDestinationRowIndex);
                                mp_DrawMovingReversibleFrame(oDestinationRow.Left, oDestinationRow.Top, oDestinationRow.Right, oDestinationRow.Bottom, E_FOCUSTYPE.FCT_NORMAL);
                            }
                        }
                    }

                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseUp:
                    if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                    {
                        mp_oControl.clsG.EraseReversibleFrames();
                        mp_oControl.FireEndObjectMove();
                        if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                        {
                            s_rowMVT.lDestinationRowIndex = mp_oControl.MathLib.GetRowIndexByPosition(Y);
                            if (s_rowMVT.lDestinationRowIndex >= 1 & (s_rowMVT.lRowIndex != s_rowMVT.lDestinationRowIndex))
                            {
                                mp_oControl.SelectedRowIndex = mp_oControl.Rows.oCollection.m_lCopyAndMoveItems(s_rowMVT.lRowIndex, s_rowMVT.lDestinationRowIndex);
                                mp_oControl.FireCompleteObjectMove();
                            }
                        }
                    }

                    mp_oControl.Redraw();
                    mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDblClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseWheel:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyDown:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyUp:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyPress:
                    break;
            }
        }

        private void mp_EO_ROWSIZING(E_MOUSEKEYBOARDEVENTS yMouseKeyBoardEvent, int X, int Y)
        {
            clsRow oRow = null;
            if (mp_oControl.AllowRowSize == false)
            {
                return;
            }
            oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(mp_oControl.SelectedRowIndex);
            if (oRow.AllowSize == false)
            {
                return;
            }
            switch (yMouseKeyBoardEvent)
            {
                case E_MOUSEKEYBOARDEVENTS.MouseHover:
                    mp_SetCursor(E_CURSORTYPE.CT_ROWHEIGHT);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDown:
                    s_rowSZ.lRowIndex = mp_oControl.MathLib.GetRowIndexByPosition(Y);
                    System.Diagnostics.Debug.Assert(s_rowSZ.lRowIndex >= 1);
                    mp_oControl.ObjectStateChangedEventArgs.Clear();
                    mp_oControl.ObjectStateChangedEventArgs.EventTarget = E_EVENTTARGET.EVT_ROW;
                    mp_oControl.ObjectStateChangedEventArgs.Index = s_rowSZ.lRowIndex;
                    mp_oControl.ObjectStateChangedEventArgs.Cancel = false;
                    mp_oControl.FireBeginObjectSize();
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseMove:
                    if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                    {
                        mp_oControl.clsG.EraseReversibleFrames();
                        mp_oControl.FireBeginObjectSize();
                        if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                        {
                            mp_DrawMovingReversibleFrame(0, Y, mp_oControl.clsG.Width, Y + 2, E_FOCUSTYPE.FCT_NORMAL);
                        }
                    }

                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseUp:
                    if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                    {
                        mp_oControl.clsG.EraseReversibleFrames();
                        mp_oControl.FireEndObjectSize();
                        if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                        {
                            oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(s_rowSZ.lRowIndex);
                            oRow.Height = oRow.Height + (Y - oRow.Bottom);
                            if (oRow.Height < mp_oControl.MinRowHeight)
                            {
                                oRow.Height = mp_oControl.MinRowHeight;
                            }
                            mp_oControl.FireCompleteObjectSize();
                        }
                    }

                    mp_oControl.Redraw();
                    mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDblClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseWheel:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyDown:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyUp:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyPress:
                    break;
            }
        }

        private void mp_EO_ROWSELECTION(E_MOUSEKEYBOARDEVENTS yMouseKeyBoardEvent, int X, int Y)
        {
            clsRow oRow = null;
            switch (yMouseKeyBoardEvent)
            {
                case E_MOUSEKEYBOARDEVENTS.MouseHover:
                    mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDown:
                    s_rowSEL.lRowIndex = mp_oControl.MathLib.GetRowIndexByPosition(Y);
                    s_rowSEL.lCellIndex = mp_oControl.MathLib.GetCellIndexByPosition(X);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseMove:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseUp:
                    mp_oControl.SelectedRowIndex = s_rowSEL.lRowIndex;
                    mp_oControl.SelectedCellIndex = s_rowSEL.lCellIndex;
                    oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(mp_oControl.SelectedRowIndex);
                    if (oRow.MergeCells == true)
                    {
                        mp_oControl.ObjectSelectedEventArgs.Clear();
                        mp_oControl.ObjectSelectedEventArgs.EventTarget = E_EVENTTARGET.EVT_ROW;
                        mp_oControl.ObjectSelectedEventArgs.ObjectIndex = mp_oControl.SelectedRowIndex;
                        mp_oControl.FireObjectSelected();
                    }
                    else
                    {
                        mp_oControl.ObjectSelectedEventArgs.Clear();
                        mp_oControl.ObjectSelectedEventArgs.EventTarget = E_EVENTTARGET.EVT_CELL;
                        mp_oControl.ObjectSelectedEventArgs.ObjectIndex = mp_oControl.SelectedCellIndex;
                        mp_oControl.ObjectSelectedEventArgs.ParentObjectIndex = mp_oControl.SelectedRowIndex;
                        mp_oControl.FireObjectSelected();
                    }

                    mp_oControl.Redraw();
                    mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDblClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseWheel:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyDown:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyUp:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyPress:
                    break;
            }
        }

        private void mp_EO_TASKMOVEMENT(E_MOUSEKEYBOARDEVENTS yMouseKeyBoardEvent, int X, int Y)
        {
            clsTask oTask = null;
            clsRow oRow = null;
            if (mp_oControl.AllowEdit == false)
            {
                return;
            }
            oTask = (clsTask)mp_oControl.Tasks.oCollection.m_oReturnArrayElement(mp_oControl.SelectedTaskIndex);
            if (oTask.AllowedMovement == E_MOVEMENTTYPE.MT_MOVEMENTDISABLED)
            {
                return;
            }
            switch (yMouseKeyBoardEvent)
            {
                case E_MOUSEKEYBOARDEVENTS.MouseHover:
                    mp_SetCursor(E_CURSORTYPE.CT_MOVETASK);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDown:
                    s_tskMVT.Clear();
                    s_tskMVT.lInitialRowIndex = mp_oControl.MathLib.GetRowIndexByPosition(Y);
                    X = mp_fSnapX(X);
                    mp_oControl.ObjectStateChangedEventArgs.Clear();
                    mp_oControl.ObjectStateChangedEventArgs.EventTarget = E_EVENTTARGET.EVT_TASK;
                    mp_oControl.ObjectStateChangedEventArgs.Index = mp_oControl.SelectedTaskIndex;
                    mp_oControl.ObjectStateChangedEventArgs.InitialRowIndex = s_tskMVT.lInitialRowIndex;
                    mp_oControl.ObjectStateChangedEventArgs.StartDate = oTask.StartDate;
                    mp_oControl.ObjectStateChangedEventArgs.EndDate = oTask.EndDate;
                    mp_oControl.ObjectStateChangedEventArgs.Cancel = false;
                    mp_oControl.FireBeginObjectMove();
                    if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                    {
                        s_tskMVT.lDeltaLeft = X - mp_oControl.MathLib.GetXCoordinateFromDate(oTask.StartDate);
                        s_tskMVT.lDeltaRight = mp_oControl.MathLib.GetXCoordinateFromDate(oTask.EndDate) - X;
                        s_tskMVT.dtInitialStartDate = oTask.StartDate;
                        s_tskMVT.dtInitialEndDate = oTask.EndDate;
                        s_tskMVT.sInitialRowKey = oTask.RowKey;
                        s_tskMVT.lDurationFactor = oTask.DurationFactor;
                    }

                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseMove:
                    if (oTask.TaskType == E_TASKTYPE.TT_START_END)
                    {
                        if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                        {
                            X = mp_fSnapX(X);
                            s_tskMVT.lFinalRowIndex = mp_oControl.MathLib.GetRowIndexByPosition(Y);
                            mp_oControl.clsG.EraseReversibleFrames();
                            mp_oControl.ObjectStateChangedEventArgs.FinalRowIndex = s_tskMVT.lFinalRowIndex;
                            mp_oControl.ObjectStateChangedEventArgs.StartDate = mp_oControl.MathLib.GetDateFromXCoordinate(X - s_tskMVT.lDeltaLeft);
                            mp_oControl.ObjectStateChangedEventArgs.EndDate = mp_oControl.MathLib.GetDateFromXCoordinate(X + s_tskMVT.lDeltaRight);
                            mp_oControl.FireObjectMove();
                            mp_DynamicRowMove(Y);
                            if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false & (s_tskMVT.lFinalRowIndex >= 1 & s_tskMVT.lFinalRowIndex <= mp_oControl.Rows.Count))
                            {
                                if (X < 0 | X > mp_oControl.clsG.Width | Y < 0 | Y > mp_oControl.clsG.Height)
                                {
                                    mp_SetCursor(E_CURSORTYPE.CT_NODROP);
                                    mp_oControl.clsG.DrawReversibleFrameEx();
                                }
                                oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(s_tskMVT.lFinalRowIndex);
                                if ((s_tskMVT.lInitialRowIndex != s_tskMVT.lFinalRowIndex & oTask.AllowedMovement == E_MOVEMENTTYPE.MT_RESTRICTEDTOROW) | (oRow.Container == false) | (mp_oControl.MathLib.DetectConflict(mp_oControl.MathLib.GetDateFromXCoordinate(mp_fSnapX(X - s_tskMVT.lDeltaLeft)), mp_oControl.MathLib.GetDateFromXCoordinate(mp_fSnapX(X + s_tskMVT.lDeltaRight)), oRow.Key, mp_oControl.SelectedTaskIndex, oTask.LayerIndex) == true & mp_oControl.CurrentViewObject.ClientArea.DetectConflicts == true))
                                {
                                    mp_SetCursor(E_CURSORTYPE.CT_NODROP);
                                    mp_oControl.clsG.DrawReversibleFrameEx();
                                    return;
                                }
                                mp_SetCursor(E_CURSORTYPE.CT_MOVETASK);
                                mp_DynamicTimeLineMove(X);
                                mp_oControl.ToolTipEventArgs.Clear();
                                mp_oControl.ToolTipEventArgs.TaskIndex = mp_oControl.SelectedTaskIndex;
                                mp_oControl.ToolTipEventArgs.InitialRowIndex = s_tskMVT.lInitialRowIndex;
                                mp_oControl.ToolTipEventArgs.FinalRowIndex = s_tskMVT.lFinalRowIndex;
                                mp_oControl.ToolTipEventArgs.InitialStartDate = s_tskMVT.dtInitialStartDate;
                                mp_oControl.ToolTipEventArgs.InitialEndDate = s_tskMVT.dtInitialEndDate;
                                mp_oControl.ToolTipEventArgs.StartDate = mp_oControl.MathLib.GetDateFromXCoordinate(X - s_tskMVT.lDeltaLeft);
                                mp_oControl.ToolTipEventArgs.EndDate = mp_oControl.MathLib.GetDateFromXCoordinate(X + s_tskMVT.lDeltaRight);
                                mp_oControl.ToolTipEventArgs.X = X;
                                mp_oControl.ToolTipEventArgs.Y = Y;
                                mp_oControl.FireToolTipOnMouseMove(mp_yOperation);
                                mp_DrawMovingReversibleFrame(X - s_tskMVT.lDeltaLeft, oRow.Top, X + s_tskMVT.lDeltaRight, oRow.Bottom, E_FOCUSTYPE.FCT_KEEPLEFTRIGHTBOUNDS);
                            }
                        }
                    }
                    else if (oTask.TaskType == E_TASKTYPE.TT_DURATION)
                    {
                        if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                        {
                            AGCSE.DateTime dtStartDate;
                            AGCSE.DateTime dtEndDate;
                            X = mp_fSnapX(X);
                            s_tskMVT.lFinalRowIndex = mp_oControl.MathLib.GetRowIndexByPosition(Y);
                            mp_oControl.clsG.EraseReversibleFrames();
                            mp_oControl.ObjectStateChangedEventArgs.FinalRowIndex = s_tskMVT.lFinalRowIndex;
                            dtStartDate = mp_oControl.MathLib.GetDateFromXCoordinate(X - s_tskMVT.lDeltaLeft);
                            dtEndDate = mp_oControl.MathLib.GetEndDate(ref dtStartDate, oTask.DurationInterval, oTask.DurationFactor);
                            mp_oControl.ObjectStateChangedEventArgs.StartDate = dtStartDate;
                            mp_oControl.ObjectStateChangedEventArgs.EndDate = dtEndDate;
                            mp_oControl.FireObjectMove();
                            mp_DynamicRowMove(Y);
                            if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false & (s_tskMVT.lFinalRowIndex >= 1 & s_tskMVT.lFinalRowIndex <= mp_oControl.Rows.Count))
                            {
                                if (X < 0 | X > mp_oControl.clsG.Width | Y < 0 | Y > mp_oControl.clsG.Height)
                                {
                                    mp_SetCursor(E_CURSORTYPE.CT_NODROP);
                                    mp_oControl.clsG.DrawReversibleFrameEx();
                                }
                                oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(s_tskMVT.lFinalRowIndex);
                                if ((s_tskMVT.lInitialRowIndex != s_tskMVT.lFinalRowIndex & oTask.AllowedMovement == E_MOVEMENTTYPE.MT_RESTRICTEDTOROW) | (oRow.Container == false) | (mp_oControl.MathLib.DetectConflict(mp_oControl.MathLib.GetDateFromXCoordinate(mp_fSnapX(X - s_tskMVT.lDeltaLeft)), mp_oControl.MathLib.GetDateFromXCoordinate(mp_fSnapX(X + s_tskMVT.lDeltaRight)), oRow.Key, mp_oControl.SelectedTaskIndex, oTask.LayerIndex) == true & mp_oControl.CurrentViewObject.ClientArea.DetectConflicts == true))
                                {
                                    mp_SetCursor(E_CURSORTYPE.CT_NODROP);
                                    mp_oControl.clsG.DrawReversibleFrameEx();
                                    return;
                                }
                                mp_SetCursor(E_CURSORTYPE.CT_MOVETASK);
                                mp_DynamicTimeLineMove(X);
                                mp_oControl.ToolTipEventArgs.Clear();
                                mp_oControl.ToolTipEventArgs.TaskIndex = mp_oControl.SelectedTaskIndex;
                                mp_oControl.ToolTipEventArgs.InitialRowIndex = s_tskMVT.lInitialRowIndex;
                                mp_oControl.ToolTipEventArgs.FinalRowIndex = s_tskMVT.lFinalRowIndex;
                                mp_oControl.ToolTipEventArgs.InitialStartDate = s_tskMVT.dtInitialStartDate;
                                mp_oControl.ToolTipEventArgs.InitialEndDate = s_tskMVT.dtInitialEndDate;
                                mp_oControl.ToolTipEventArgs.StartDate = dtStartDate;
                                mp_oControl.ToolTipEventArgs.EndDate = dtEndDate;
                                mp_oControl.ToolTipEventArgs.X = X;
                                mp_oControl.ToolTipEventArgs.Y = Y;
                                mp_oControl.FireToolTipOnMouseMove(mp_yOperation);
                                mp_DrawMovingReversibleFrame(mp_oControl.MathLib.GetXCoordinateFromDate(dtStartDate), oRow.Top, mp_oControl.MathLib.GetXCoordinateFromDate(dtEndDate), oRow.Bottom, E_FOCUSTYPE.FCT_KEEPLEFTRIGHTBOUNDS);
                            }
                        }
                    }
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseUp:
                    if (oTask.TaskType == E_TASKTYPE.TT_START_END)
                    {
                        if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false & (s_tskMVT.lFinalRowIndex >= 1 & s_tskMVT.lFinalRowIndex <= mp_oControl.Rows.Count))
                        {
                            oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(s_tskMVT.lFinalRowIndex);
                            mp_oControl.clsG.EraseReversibleFrames();
                            if ((s_tskMVT.lInitialRowIndex != s_tskMVT.lFinalRowIndex & oTask.AllowedMovement == E_MOVEMENTTYPE.MT_RESTRICTEDTOROW) | (oRow.Container == false) | (mp_oControl.MathLib.DetectConflict(mp_oControl.MathLib.GetDateFromXCoordinate(mp_fSnapX(X - s_tskMVT.lDeltaLeft)), mp_oControl.MathLib.GetDateFromXCoordinate(mp_fSnapX(X + s_tskMVT.lDeltaRight)), oRow.Key, mp_oControl.SelectedTaskIndex, oTask.LayerIndex) == true & mp_oControl.CurrentViewObject.ClientArea.DetectConflicts == true))
                            {
                            }
                            else
                            {
                                X = mp_fSnapX(X);
                                mp_oControl.FireEndObjectMove();
                                if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                                {
                                    oTask.StartDate = mp_oControl.MathLib.GetDateFromXCoordinate(X - s_tskMVT.lDeltaLeft);
                                    oTask.EndDate = mp_oControl.MathLib.GetDateFromXCoordinate(X + s_tskMVT.lDeltaRight);
                                    if (mp_oControl.CurrentViewObject.ClientArea.Grid.SnapToGrid == true)
                                    {
                                        oTask.StartDate = mp_oControl.MathLib.RoundDate(mp_oControl.CurrentViewObject.ClientArea.Grid.Interval, mp_oControl.CurrentViewObject.ClientArea.Grid.Factor, oTask.StartDate);
                                        oTask.EndDate = mp_oControl.MathLib.RoundDate(mp_oControl.CurrentViewObject.ClientArea.Grid.Interval, mp_oControl.CurrentViewObject.ClientArea.Grid.Factor, oTask.EndDate);
                                    }
                                    oTask.RowKey = oRow.Key;
                                    if (oTask.StartDate != s_tskMVT.dtInitialStartDate | oTask.EndDate != s_tskMVT.dtInitialEndDate | oTask.RowKey != s_tskMVT.sInitialRowKey)
                                    {
                                        mp_oControl.FireCompleteObjectMove();
                                        if (mp_oControl.ObjectStateChangedEventArgs.Cancel == true)
                                        {
                                            ////Account for Duration
                                            oTask.StartDate = s_tskMVT.dtInitialStartDate;
                                            oTask.EndDate = s_tskMVT.dtInitialEndDate;
                                            oTask.RowKey = s_tskMVT.sInitialRowKey;
                                        }
                                    }
                                }
                            }
                        }
                        if (mp_oControl.EnforcePredecessors == true)
                        {
                            mp_oControl.CheckPredecessors();
                        }
                        mp_oControl.Redraw();
                        mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
                    }
                    else if (oTask.TaskType == E_TASKTYPE.TT_DURATION)
                    {
                        if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false & (s_tskMVT.lFinalRowIndex >= 1 & s_tskMVT.lFinalRowIndex <= mp_oControl.Rows.Count))
                        {
                            AGCSE.DateTime dtStartDate;
                            AGCSE.DateTime dtEndDate;
                            int lDuration = 0;
                            oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(s_tskMVT.lFinalRowIndex);
                            mp_oControl.clsG.EraseReversibleFrames();
                            if ((s_tskMVT.lInitialRowIndex != s_tskMVT.lFinalRowIndex & oTask.AllowedMovement == E_MOVEMENTTYPE.MT_RESTRICTEDTOROW) | (oRow.Container == false) | (mp_oControl.MathLib.DetectConflict(mp_oControl.MathLib.GetDateFromXCoordinate(mp_fSnapX(X - s_tskMVT.lDeltaLeft)), mp_oControl.MathLib.GetDateFromXCoordinate(mp_fSnapX(X + s_tskMVT.lDeltaRight)), oRow.Key, mp_oControl.SelectedTaskIndex, oTask.LayerIndex) == true & mp_oControl.CurrentViewObject.ClientArea.DetectConflicts == true))
                            {
                            }
                            else
                            {
                                X = mp_fSnapX(X);
                                mp_oControl.FireEndObjectMove();
                                if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                                {
                                    dtStartDate = mp_oControl.MathLib.GetDateFromXCoordinate(X - s_tskMVT.lDeltaLeft);
                                    dtEndDate = mp_oControl.MathLib.GetEndDate(ref dtStartDate, oTask.DurationInterval, oTask.DurationFactor);
                                    if (mp_oControl.CurrentViewObject.ClientArea.Grid.SnapToGrid == true)
                                    {
                                        dtStartDate = mp_oControl.MathLib.RoundDate(mp_oControl.CurrentViewObject.ClientArea.Grid.Interval, mp_oControl.CurrentViewObject.ClientArea.Grid.Factor, dtStartDate);
                                    }
                                    lDuration = mp_oControl.MathLib.CalculateDuration(ref dtStartDate, ref dtEndDate, oTask.DurationInterval);
                                    if (lDuration != s_tskMVT.lDurationFactor)
                                    {
                                        mp_oControl.mp_ErrorReport(SYS_ERRORS.ERR_DURATION_INCONSISTENT, "Inconsistent duration", "clsMouseKeyboardEvents.mp_EO_TASKMOVEMENT");
                                    }
                                    oTask.StartDate = dtStartDate;
                                    oTask.RowKey = oRow.Key;
                                    if (oTask.StartDate != s_tskMVT.dtInitialStartDate | oTask.EndDate != s_tskMVT.dtInitialEndDate | oTask.RowKey != s_tskMVT.sInitialRowKey)
                                    {
                                        mp_oControl.FireCompleteObjectMove();
                                        if (mp_oControl.ObjectStateChangedEventArgs.Cancel == true)
                                        {
                                            oTask.StartDate = s_tskMVT.dtInitialStartDate;
                                            oTask.RowKey = s_tskMVT.sInitialRowKey;
                                        }
                                    }
                                }
                            }
                        }
                        if (mp_oControl.EnforcePredecessors == true)
                        {
                            mp_oControl.CheckPredecessors();
                        }
                        mp_oControl.Redraw();
                        mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
                    }

                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDblClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseWheel:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyDown:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyUp:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyPress:
                    break;
            }
        }

        private void mp_EO_TASKSTRETCHLEFT(E_MOUSEKEYBOARDEVENTS yMouseKeyBoardEvent, int X, int Y)
        {
            clsTask oTask = null;
            clsRow oRow = null;
            if (mp_oControl.AllowEdit == false)
            {
                return;
            }
            oTask = (clsTask)mp_oControl.Tasks.oCollection.m_oReturnArrayElement(mp_oControl.SelectedTaskIndex);
            if (oTask.AllowStretchLeft == false | oTask.TaskType == E_TASKTYPE.TT_DURATION)
            {
                return;
            }
            switch (yMouseKeyBoardEvent)
            {
                case E_MOUSEKEYBOARDEVENTS.MouseHover:
                    mp_SetCursor(E_CURSORTYPE.CT_SIZETASK);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDown:
                    mp_oControl.ObjectStateChangedEventArgs.Cancel = false;
                    s_tskSTL.lRowIndex = mp_oControl.MathLib.GetRowIndexByPosition(Y);
                    X = mp_fSnapX(X);
                    mp_oControl.ObjectStateChangedEventArgs.Clear();
                    mp_oControl.ObjectStateChangedEventArgs.EventTarget = E_EVENTTARGET.EVT_TASK;
                    mp_oControl.ObjectStateChangedEventArgs.Index = mp_oControl.SelectedTaskIndex;
                    mp_oControl.ObjectStateChangedEventArgs.Cancel = false;
                    mp_oControl.FireBeginObjectSize();
                    if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                    {
                        s_tskSTL.dtInitialStartDate = oTask.StartDate;
                        s_tskSTL.dtInitialEndDate = oTask.EndDate;
                    }

                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseMove:
                    if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                    {
                        X = mp_fSnapX(X);
                        mp_oControl.clsG.EraseReversibleFrames();
                        oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(s_tskSTL.lRowIndex);
                        s_tskSTL.dtFinalStartDate = mp_oControl.MathLib.GetDateFromXCoordinate(X);
                        mp_oControl.FireObjectSize();
                        if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                        {
                            if (mp_oControl.MathLib.DetectConflict(mp_oControl.MathLib.GetDateFromXCoordinate(X), oTask.EndDate, oRow.Key, mp_oControl.SelectedTaskIndex, oTask.LayerIndex) == true & mp_oControl.CurrentViewObject.ClientArea.DetectConflicts == true)
                            {
                                mp_SetCursor(E_CURSORTYPE.CT_NODROP);
                            }
                            else
                            {
                                mp_SetCursor(E_CURSORTYPE.CT_SIZETASK);
                            }
                            mp_DynamicTimeLineMove(X);
                            mp_oControl.ToolTipEventArgs.Clear();
                            mp_oControl.ToolTipEventArgs.TaskIndex = mp_oControl.SelectedTaskIndex;
                            mp_oControl.ToolTipEventArgs.RowIndex = s_tskSTL.lRowIndex;
                            mp_oControl.ToolTipEventArgs.InitialStartDate = s_tskSTL.dtInitialStartDate;
                            mp_oControl.ToolTipEventArgs.InitialEndDate = s_tskSTL.dtInitialEndDate;
                            mp_oControl.ToolTipEventArgs.StartDate = s_tskSTL.dtFinalStartDate;
                            mp_oControl.ToolTipEventArgs.EndDate = s_tskSTL.dtInitialEndDate;
                            mp_oControl.ToolTipEventArgs.X = X;
                            mp_oControl.ToolTipEventArgs.Y = Y;
                            mp_oControl.FireToolTipOnMouseMove(mp_yOperation);
                            mp_DrawMovingReversibleFrame(X, oRow.Top, mp_oControl.MathLib.GetXCoordinateFromDate(oTask.EndDate), oRow.Bottom, E_FOCUSTYPE.FCT_KEEPLEFTRIGHTBOUNDS);
                        }
                    }

                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseUp:
                    if (s_tskSTL.dtFinalStartDate >= s_tskSTL.dtInitialEndDate)
                    {
                        mp_oControl.ObjectStateChangedEventArgs.Cancel = true;
                    }

                    if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                    {
                        mp_oControl.clsG.EraseReversibleFrames();
                        if (s_tskSTL.dtFinalStartDate < mp_oControl.CurrentViewObject.TimeLine.StartDate)
                        {
                            s_tskSTL.dtFinalStartDate = mp_oControl.CurrentViewObject.TimeLine.StartDate;
                        }
                        mp_oControl.FireEndObjectSize();
                        if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                        {
                            oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(s_tskSTL.lRowIndex);
                            if (mp_oControl.MathLib.DetectConflict(mp_oControl.MathLib.GetDateFromXCoordinate(X), oTask.EndDate, oRow.Key, mp_oControl.SelectedTaskIndex, oTask.LayerIndex) == true & mp_oControl.CurrentViewObject.ClientArea.DetectConflicts == true)
                            {
                            }
                            else
                            {
                                oTask.StartDate = s_tskSTL.dtFinalStartDate;
                                if (mp_oControl.CurrentViewObject.ClientArea.Grid.SnapToGrid == true)
                                {
                                    oTask.StartDate = mp_oControl.MathLib.RoundDate(mp_oControl.CurrentViewObject.ClientArea.Grid.Interval, mp_oControl.CurrentViewObject.ClientArea.Grid.Factor, oTask.StartDate);
                                    oTask.EndDate = mp_oControl.MathLib.RoundDate(mp_oControl.CurrentViewObject.ClientArea.Grid.Interval, mp_oControl.CurrentViewObject.ClientArea.Grid.Factor, oTask.EndDate);
                                }
                                if (oTask.StartDate != s_tskSTL.dtInitialStartDate)
                                {
                                    mp_oControl.FireCompleteObjectSize();
                                    if (mp_oControl.ObjectStateChangedEventArgs.Cancel == true)
                                    {
                                        oTask.StartDate = s_tskSTL.dtInitialStartDate;
                                    }
                                }
                            }
                        }
                    }
                    if (mp_oControl.EnforcePredecessors == true)
                    {
                        mp_oControl.CheckPredecessors();
                    }
                    mp_oControl.Redraw();
                    mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDblClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseWheel:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyDown:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyUp:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyPress:
                    break;
            }
        }

        private void mp_EO_TASKSTRETCHRIGHT(E_MOUSEKEYBOARDEVENTS yMouseKeyBoardEvent, int X, int Y)
        {
            clsTask oTask = null;
            clsRow oRow = null;
            if (mp_oControl.AllowEdit == false)
            {
                return;
            }
            oTask = (clsTask)mp_oControl.Tasks.oCollection.m_oReturnArrayElement(mp_oControl.SelectedTaskIndex);
            if (oTask.AllowStretchRight == false)
            {
                return;
            }
            switch (yMouseKeyBoardEvent)
            {
                case E_MOUSEKEYBOARDEVENTS.MouseHover:
                    mp_SetCursor(E_CURSORTYPE.CT_SIZETASK);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDown:
                    s_tskSTR.lRowIndex = mp_oControl.MathLib.GetRowIndexByPosition(Y);
                    X = mp_fSnapX(X);
                    mp_oControl.ObjectStateChangedEventArgs.Clear();
                    mp_oControl.ObjectStateChangedEventArgs.EventTarget = E_EVENTTARGET.EVT_TASK;
                    mp_oControl.ObjectStateChangedEventArgs.Index = mp_oControl.SelectedTaskIndex;
                    mp_oControl.ObjectStateChangedEventArgs.Cancel = false;
                    mp_oControl.FireBeginObjectSize();
                    if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                    {
                        s_tskSTR.dtInitialStartDate = oTask.StartDate;
                        s_tskSTR.dtInitialEndDate = oTask.EndDate;
                    }

                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseMove:
                    if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                    {
                        X = mp_fSnapX(X);
                        mp_oControl.clsG.EraseReversibleFrames();
                        oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(s_tskSTR.lRowIndex);
                        s_tskSTR.dtFinalEndDate = mp_oControl.MathLib.GetDateFromXCoordinate(X);
                        mp_oControl.FireObjectSize();
                        if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                        {
                            if (mp_oControl.MathLib.DetectConflict(oTask.StartDate, mp_oControl.MathLib.GetDateFromXCoordinate(X), oRow.Key, mp_oControl.SelectedTaskIndex, oTask.LayerIndex) == true & mp_oControl.CurrentViewObject.ClientArea.DetectConflicts == true)
                            {
                                mp_SetCursor(E_CURSORTYPE.CT_NODROP);
                            }
                            else
                            {
                                mp_SetCursor(E_CURSORTYPE.CT_SIZETASK);
                            }
                            mp_DynamicTimeLineMove(X);
                            mp_oControl.ToolTipEventArgs.Clear();
                            mp_oControl.ToolTipEventArgs.TaskIndex = mp_oControl.SelectedTaskIndex;
                            mp_oControl.ToolTipEventArgs.RowIndex = s_tskSTR.lRowIndex;
                            mp_oControl.ToolTipEventArgs.InitialStartDate = s_tskSTR.dtInitialStartDate;
                            mp_oControl.ToolTipEventArgs.InitialEndDate = s_tskSTR.dtInitialEndDate;
                            mp_oControl.ToolTipEventArgs.StartDate = s_tskSTR.dtInitialStartDate;
                            mp_oControl.ToolTipEventArgs.EndDate = s_tskSTR.dtFinalEndDate;
                            mp_oControl.ToolTipEventArgs.X = X;
                            mp_oControl.ToolTipEventArgs.Y = Y;
                            mp_oControl.FireToolTipOnMouseMove(mp_yOperation);
                            mp_DrawMovingReversibleFrame(mp_oControl.MathLib.GetXCoordinateFromDate(oTask.StartDate), oRow.Top, X, oRow.Bottom, E_FOCUSTYPE.FCT_KEEPLEFTRIGHTBOUNDS);
                        }
                    }

                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseUp:
                    if (s_tskSTR.dtFinalEndDate <= s_tskSTR.dtInitialStartDate)
                    {
                        mp_oControl.ObjectStateChangedEventArgs.Cancel = true;
                    }

                    if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                    {
                        mp_oControl.clsG.EraseReversibleFrames();
                        if (s_tskSTR.dtFinalEndDate > mp_oControl.CurrentViewObject.TimeLine.EndDate)
                        {
                            s_tskSTR.dtFinalEndDate = mp_oControl.CurrentViewObject.TimeLine.EndDate;
                        }
                        mp_oControl.FireEndObjectSize();
                        if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                        {
                            oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(s_tskSTR.lRowIndex);
                            if (mp_oControl.MathLib.DetectConflict(oTask.StartDate, mp_oControl.MathLib.GetDateFromXCoordinate(X), oRow.Key, mp_oControl.SelectedTaskIndex, oTask.LayerIndex) == true & mp_oControl.CurrentViewObject.ClientArea.DetectConflicts == true)
                            {
                            }
                            else
                            {
                                if (oTask.TaskType == E_TASKTYPE.TT_START_END)
                                {
                                    oTask.EndDate = s_tskSTR.dtFinalEndDate;
                                    if (mp_oControl.CurrentViewObject.ClientArea.Grid.SnapToGrid == true)
                                    {
                                        oTask.StartDate = mp_oControl.MathLib.RoundDate(mp_oControl.CurrentViewObject.ClientArea.Grid.Interval, mp_oControl.CurrentViewObject.ClientArea.Grid.Factor, oTask.StartDate);
                                        oTask.EndDate = mp_oControl.MathLib.RoundDate(mp_oControl.CurrentViewObject.ClientArea.Grid.Interval, mp_oControl.CurrentViewObject.ClientArea.Grid.Factor, oTask.EndDate);
                                    }
                                }
                                else if (oTask.TaskType == E_TASKTYPE.TT_DURATION)
                                {
                                    oTask.DurationFactor = mp_oControl.MathLib.CalculateDuration(ref s_tskSTR.dtInitialStartDate, ref s_tskSTR.dtFinalEndDate, oTask.DurationInterval);
                                }
                                if (oTask.EndDate != s_tskSTR.dtInitialEndDate)
                                {
                                    mp_oControl.FireCompleteObjectSize();
                                    if (mp_oControl.ObjectStateChangedEventArgs.Cancel == true)
                                    {
                                        oTask.EndDate = s_tskSTR.dtInitialEndDate;
                                    }
                                }
                            }
                        }
                    }
                    if (mp_oControl.EnforcePredecessors == true)
                    {
                        mp_oControl.CheckPredecessors();
                    }
                    mp_oControl.Redraw();
                    mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDblClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseWheel:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyDown:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyUp:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyPress:
                    break;
            }
        }

        private void mp_EO_TASKSELECTION(E_MOUSEKEYBOARDEVENTS yMouseKeyBoardEvent, int X, int Y)
        {
            clsTask oTask = null;
            switch (yMouseKeyBoardEvent)
            {
                case E_MOUSEKEYBOARDEVENTS.MouseHover:
                    //ToolTipText(E_OPERATION.EO_TASKSELECTION, mp_oControl.MathLib.GetTaskIndexByPosition(X, Y), X, Y, Nothing, Nothing, "")
                    mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDown:
                    s_tskSEL.lTaskIndex = mp_oControl.MathLib.GetTaskIndexByPosition(X, Y);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseMove:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseUp:
                    mp_oControl.SelectedTaskIndex = s_tskSEL.lTaskIndex;
                    oTask = (clsTask)mp_oControl.Tasks.oCollection.m_oReturnArrayElement(mp_oControl.SelectedTaskIndex);
                    if (mp_oControl.CurrentViewObject.ClientArea.Grid.SnapToGrid == true & mp_oControl.CurrentViewObject.ClientArea.Grid.SnapToGridOnSelection == true)
                    {
                        oTask = (clsTask)mp_oControl.Tasks.oCollection.m_oReturnArrayElement(mp_oControl.SelectedTaskIndex);
                        oTask.StartDate = mp_oControl.MathLib.RoundDate(mp_oControl.CurrentViewObject.ClientArea.Grid.Interval, mp_oControl.CurrentViewObject.ClientArea.Grid.Factor, oTask.StartDate);
                        oTask.EndDate = mp_oControl.MathLib.RoundDate(mp_oControl.CurrentViewObject.ClientArea.Grid.Interval, mp_oControl.CurrentViewObject.ClientArea.Grid.Factor, oTask.EndDate);
                    }

                    mp_oControl.ObjectSelectedEventArgs.Clear();
                    mp_oControl.ObjectSelectedEventArgs.EventTarget = E_EVENTTARGET.EVT_TASK;
                    mp_oControl.ObjectSelectedEventArgs.ObjectIndex = mp_oControl.SelectedTaskIndex;
                    mp_oControl.FireObjectSelected();
                    mp_oControl.Redraw();
                    mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDblClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseWheel:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyDown:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyUp:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyPress:
                    break;
            }
        }

        private void mp_EO_TASKADDITION(E_MOUSEKEYBOARDEVENTS yMouseKeyBoardEvent, int X, int Y)
        {
            clsRow oRow = null;
            if (mp_oControl.AllowAdd == false)
            {
                mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
                return;
            }
            s_tskADD.lRowIndex = mp_oControl.MathLib.GetRowIndexByPosition(Y);
            if (s_tskADD.lRowIndex <= 0)
            {
                return;
            }
            oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(s_tskADD.lRowIndex);
            if (oRow.Container == false)
            {
                return;
            }
            switch (yMouseKeyBoardEvent)
            {
                case E_MOUSEKEYBOARDEVENTS.MouseHover:
                    mp_SetCursor(E_CURSORTYPE.CT_CLIENTAREA);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDown:
                    s_tskADD.bCancel = false;
                    X = mp_fSnapX(X);
                    if ((oRow.Container == false) | (mp_oControl.MathLib.DetectConflict(mp_oControl.MathLib.GetDateFromXCoordinate(X), mp_oControl.MathLib.GetDateFromXCoordinate(X), oRow.Key, 0, mp_oControl.CurrentLayer) == true & mp_oControl.CurrentViewObject.ClientArea.DetectConflicts == true))
                    {
                        s_tskADD.bCancel = true;
                    }
                    else
                    {
                        s_tskADD.dtStartDate = mp_oControl.MathLib.GetDateFromXCoordinate(X);
                    }

                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseMove:
                    if (s_tskADD.bCancel == false)
                    {
                        X = mp_fSnapX(X);
                        mp_oControl.clsG.EraseReversibleFrames();
                        if ((mp_oControl.MathLib.DetectConflict(s_tskADD.dtStartDate, mp_oControl.MathLib.GetDateFromXCoordinate(X), oRow.Key, 0, mp_oControl.CurrentLayer) == true | oRow.Container == false) & mp_oControl.CurrentViewObject.ClientArea.DetectConflicts == true)
                        {
                            mp_SetCursor(E_CURSORTYPE.CT_NODROP);
                            s_tskADD.bInConflict = true;
                        }
                        else
                        {
                            s_tskADD.bInConflict = false;
                            mp_SetCursor(E_CURSORTYPE.CT_CLIENTAREA);
                            s_tskADD.dtEndDate = mp_oControl.MathLib.GetDateFromXCoordinate(X);
                            mp_DynamicTimeLineMove(X);
                            mp_oControl.ToolTipEventArgs.Clear();
                            mp_oControl.ToolTipEventArgs.RowIndex = s_tskADD.lRowIndex;
                            mp_oControl.ToolTipEventArgs.StartDate = s_tskADD.dtStartDate;
                            mp_oControl.ToolTipEventArgs.EndDate = s_tskADD.dtEndDate;
                            mp_oControl.ToolTipEventArgs.X = X;
                            mp_oControl.ToolTipEventArgs.Y = Y;
                            mp_oControl.FireToolTipOnMouseMove(mp_yOperation);
                            mp_DrawMovingReversibleFrame(mp_oControl.MathLib.GetXCoordinateFromDate(s_tskADD.dtStartDate), oRow.Top, X, oRow.Bottom, E_FOCUSTYPE.FCT_ADD);
                        }
                    }

                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseUp:
                    mp_oControl.clsG.EraseReversibleFrames();
                    if (s_tskADD.bCancel == false & s_tskADD.bInConflict == false)
                    {
                        X = mp_fSnapX(X);
                        s_tskADD.dtEndDate = mp_oControl.MathLib.GetDateFromXCoordinate(X);
                        if (s_tskADD.dtEndDate == s_tskADD.dtStartDate)
                        {
                            if (mp_oControl.AddMode == E_ADDMODE.AT_BOTH | mp_oControl.AddMode == E_ADDMODE.AT_MILESTONEADD)
                            {
                                mp_oControl.Tasks.Add("", oRow.Key, s_tskADD.dtEndDate, s_tskADD.dtStartDate, "", "DS_TASK", mp_oControl.CurrentLayer);
                            }
                            else if (mp_oControl.AddMode == E_ADDMODE.AT_DURATION_BOTH | mp_oControl.AddMode == E_ADDMODE.AT_DURATION_MILESTONEADD)
                            {
                                AGCSE.DateTime dtStartDate = s_tskADD.dtStartDate;
                                AGCSE.DateTime dtTLStartDate = mp_oControl.CurrentViewObject.TimeLine.StartDate;
                                AGCSE.DateTime dtTLEndDate = mp_oControl.CurrentViewObject.TimeLine.EndDate;
                                ArrayList aTimeBlocks = new ArrayList();
                                mp_oControl.MathLib.mp_GetTimeBlocks(ref aTimeBlocks, ref dtTLStartDate, ref dtTLEndDate);
                                mp_oControl.MathLib.mp_ValidateStartDate(ref aTimeBlocks, ref dtStartDate);
                                mp_oControl.Tasks.DAdd(oRow.Key, dtStartDate, mp_oControl.AddDurationInterval, 0, "", "", "DS_TASK", mp_oControl.CurrentLayer);
                            }
                            mp_oControl.SelectedTaskIndex = mp_oControl.Tasks.Count;
                            mp_oControl.ObjectAddedEventArgs.Clear();
                            mp_oControl.ObjectAddedEventArgs.TaskIndex = mp_oControl.Tasks.Count;
                            mp_oControl.ObjectAddedEventArgs.EventTarget = E_EVENTTARGET.EVT_MILESTONE;
                            mp_oControl.FireObjectAdded();
                        }
                        else
                        {
                            if (mp_oControl.AddMode == E_ADDMODE.AT_BOTH | mp_oControl.AddMode == E_ADDMODE.AT_TASKADD)
                            {
                                if (s_tskADD.dtEndDate < s_tskADD.dtStartDate)
                                {
                                    mp_oControl.Tasks.Add("", oRow.Key, s_tskADD.dtEndDate, s_tskADD.dtStartDate, "", "DS_TASK", mp_oControl.CurrentLayer);
                                }
                                else
                                {
                                    mp_oControl.Tasks.Add("", oRow.Key, s_tskADD.dtStartDate, s_tskADD.dtEndDate, "", "DS_TASK", mp_oControl.CurrentLayer);
                                }
                                mp_oControl.SelectedTaskIndex = mp_oControl.Tasks.Count;
                                mp_oControl.ObjectAddedEventArgs.Clear();
                                mp_oControl.ObjectAddedEventArgs.TaskIndex = mp_oControl.Tasks.Count;
                                mp_oControl.ObjectAddedEventArgs.EventTarget = E_EVENTTARGET.EVT_TASK;
                                mp_oControl.FireObjectAdded();
                            }
                            else if (mp_oControl.AddMode == E_ADDMODE.AT_DURATION_BOTH | mp_oControl.AddMode == E_ADDMODE.AT_DURATION_TASKADD)
                            {
                                int lDuration = 0;
                                AGCSE.DateTime dtStartDate;
                                AGCSE.DateTime dtEndDate;
                                if (s_tskADD.dtEndDate > s_tskADD.dtStartDate)
                                {
                                    dtStartDate = s_tskADD.dtStartDate;
                                    dtEndDate = s_tskADD.dtEndDate;
                                }
                                else
                                {
                                    dtStartDate = s_tskADD.dtEndDate;
                                    dtEndDate = s_tskADD.dtStartDate;
                                }
                                lDuration = mp_oControl.MathLib.CalculateDuration(ref dtStartDate, ref dtEndDate, mp_oControl.AddDurationInterval);
                                mp_oControl.Tasks.DAdd(oRow.Key, dtStartDate, mp_oControl.AddDurationInterval, lDuration, "", "", "DS_TASK", mp_oControl.CurrentLayer);
                                mp_oControl.SelectedTaskIndex = mp_oControl.Tasks.Count;
                                mp_oControl.ObjectAddedEventArgs.Clear();
                                mp_oControl.ObjectAddedEventArgs.TaskIndex = mp_oControl.Tasks.Count;
                                mp_oControl.ObjectAddedEventArgs.EventTarget = E_EVENTTARGET.EVT_TASK;
                                mp_oControl.FireObjectAdded();
                            }
                        }
                    }
                    mp_oControl.Redraw();
                    mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDblClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseWheel:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyDown:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyUp:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyPress:
                    break;
            }
        }

        private void mp_EO_PERCENTAGESELECTION(E_MOUSEKEYBOARDEVENTS yMouseKeyBoardEvent, int X, int Y)
        {
            clsPercentage oPercentage = null;
            switch (yMouseKeyBoardEvent)
            {
                case E_MOUSEKEYBOARDEVENTS.MouseHover:
                    mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDown:
                    s_perSEL.lPercentageIndex = mp_oControl.MathLib.GetPercentageIndexByPosition(X, Y);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseMove:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseUp:
                    mp_oControl.SelectedPercentageIndex = s_perSEL.lPercentageIndex;
                    oPercentage = (clsPercentage)mp_oControl.Percentages.oCollection.m_oReturnArrayElement(mp_oControl.SelectedPercentageIndex);
                    mp_oControl.ObjectSelectedEventArgs.Clear();
                    mp_oControl.ObjectSelectedEventArgs.EventTarget = E_EVENTTARGET.EVT_PERCENTAGE;
                    mp_oControl.ObjectSelectedEventArgs.ObjectIndex = mp_oControl.SelectedTaskIndex;
                    mp_oControl.FireObjectSelected();
                    mp_oControl.Redraw();
                    mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDblClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseWheel:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyDown:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyUp:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyPress:
                    break;
            }
        }

        private void mp_EO_PERCENTAGESIZING(E_MOUSEKEYBOARDEVENTS yMouseKeyBoardEvent, int X, int Y)
        {
            clsPercentage oPercentage = null;
            clsTask oTask = null;
            if (mp_oControl.AllowEdit == false)
            {
                return;
            }
            oPercentage = (clsPercentage)mp_oControl.Percentages.Item(mp_oControl.SelectedPercentageIndex.ToString());
            if (oPercentage.AllowSize == false)
            {
                return;
            }
            switch (yMouseKeyBoardEvent)
            {
                case E_MOUSEKEYBOARDEVENTS.MouseHover:
                    mp_SetCursor(E_CURSORTYPE.CT_PERCENTAGE);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDown:
                    s_perSZ.bMouseMove = false;
                    oTask = (clsTask)mp_oControl.Tasks.Item(oPercentage.TaskKey);
                    mp_oControl.ObjectStateChangedEventArgs.Clear();
                    mp_oControl.ObjectStateChangedEventArgs.EventTarget = E_EVENTTARGET.EVT_PERCENTAGE;
                    mp_oControl.ObjectStateChangedEventArgs.Index = mp_oControl.SelectedPercentageIndex;
                    mp_oControl.ObjectStateChangedEventArgs.Cancel = false;
                    if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                    {
                        s_perSZ.lTaskIndex = oTask.Index;
                    }

                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseMove:
                    s_perSZ.bMouseMove = true;
                    if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                    {
                        mp_oControl.clsG.EraseReversibleFrames();
                        oTask = (clsTask)mp_oControl.Tasks.Item(oPercentage.TaskKey);
                        mp_oControl.FireObjectSize();
                        if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                        {
                            mp_DynamicTimeLineMove(X);
                            s_perSZ.lTaskStart = mp_oControl.MathLib.GetXCoordinateFromDate(oTask.StartDate);
                            s_perSZ.lTaskEnd = mp_oControl.MathLib.GetXCoordinateFromDate(oTask.EndDate);
                            if (X < s_perSZ.lTaskStart)
                            {
                                X = s_perSZ.lTaskStart;
                            }
                            if (X > s_perSZ.lTaskEnd)
                            {
                                X = s_perSZ.lTaskEnd;
                            }
                            float fPercent = 0;
                            fPercent = mp_oControl.MathLib.PercentageComplete(s_perSZ.lTaskStart, s_perSZ.lTaskEnd, X);
                            fPercent = mp_oControl.MathLib.RoundDouble(fPercent * 100);
                            mp_oControl.ToolTipEventArgs.Clear();
                            mp_oControl.ToolTipEventArgs.PercentageIndex = mp_oControl.SelectedPercentageIndex;
                            mp_oControl.ToolTipEventArgs.XStart = s_perSZ.lTaskStart;
                            mp_oControl.ToolTipEventArgs.XEnd = s_perSZ.lTaskEnd;
                            mp_oControl.ToolTipEventArgs.TaskIndex = oTask.Index;
                            mp_oControl.ToolTipEventArgs.RowIndex = mp_oControl.Rows.Item(oTask.RowKey).Index;
                            mp_oControl.ToolTipEventArgs.StartDate = oTask.StartDate;
                            mp_oControl.ToolTipEventArgs.EndDate = oTask.EndDate;
                            mp_oControl.ToolTipEventArgs.X = X;
                            mp_oControl.ToolTipEventArgs.Y = Y;
                            mp_oControl.FireToolTipOnMouseMove(mp_yOperation);
                            mp_DrawMovingReversibleFrame(s_perSZ.lTaskStart, oPercentage.Top, X, oPercentage.Bottom, E_FOCUSTYPE.FCT_KEEPLEFTRIGHTBOUNDS);
                            s_perSZ.lX = X;
                        }
                    }

                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseUp:
                    if (s_perSZ.bMouseMove == false)
                    {
                        return;
                    }

                    if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                    {
                        mp_oControl.clsG.EraseReversibleFrames();
                        mp_oControl.FireEndObjectSize();
                        if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false)
                        {
                            s_perSZ.lTaskEnd = s_perSZ.lTaskEnd - s_perSZ.lTaskStart;
                            s_perSZ.lX = s_perSZ.lX - s_perSZ.lTaskStart;
                            if (s_perSZ.lX == 0)
                            {
                                oPercentage.Percent = 0;
                            }
                            else if (s_perSZ.lX == s_perSZ.lTaskEnd)
                            {
                                oPercentage.Percent = 1;
                            }
                            else
                            {
                                oPercentage.Percent = (System.Single)s_perSZ.lX / (System.Single)s_perSZ.lTaskEnd;
                            }
                            mp_oControl.FireCompleteObjectSize();
                        }
                    }

                    mp_oControl.Redraw();
                    mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDblClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseWheel:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyDown:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyUp:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyPress:
                    break;
            }
        }

        private void mp_EO_PREDECESSORSELECTION(E_MOUSEKEYBOARDEVENTS yMouseKeyBoardEvent, int X, int Y)
        {
            switch (yMouseKeyBoardEvent)
            {
                case E_MOUSEKEYBOARDEVENTS.MouseHover:
                    mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDown:
                    s_preSEL.lPredecessorIndex = mp_oControl.MathLib.GetPredecessorIndexByPosition(X, Y);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseMove:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseUp:
                    mp_oControl.SelectedPredecessorIndex = s_preSEL.lPredecessorIndex;
                    mp_oControl.ObjectSelectedEventArgs.Clear();
                    mp_oControl.ObjectSelectedEventArgs.EventTarget = E_EVENTTARGET.EVT_PREDECESSOR;
                    mp_oControl.ObjectSelectedEventArgs.ObjectIndex = mp_oControl.SelectedPredecessorIndex;
                    mp_oControl.FireObjectSelected();
                    mp_oControl.Redraw();
                    mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDblClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseWheel:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyDown:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyUp:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyPress:
                    break;
            }
        }

        private void mp_EO_PREDECESSORADDITION(E_MOUSEKEYBOARDEVENTS yMouseKeyBoardEvent, int X, int Y)
        {
            clsTask oTask = null;
            clsTask oPredecessor = null;
            if (mp_oControl.AllowPredecessorAdd == false)
            {
                return;
            }
            switch (yMouseKeyBoardEvent)
            {
                case E_MOUSEKEYBOARDEVENTS.MouseHover:
                    mp_SetCursor(E_CURSORTYPE.CT_PREDECESSOR);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDown:
                    s_preADD.bCancel = false;
                    s_preADD.lXStart = X;
                    s_preADD.lYStart = Y;
                    s_preADD.lPredecessorIndex = mp_oControl.MathLib.GetTaskIndexByPosition(X, Y);
                    oPredecessor = mp_oControl.Tasks.Item(s_preADD.lPredecessorIndex.ToString());
                    if ((oPredecessor.Key.Length == 0 | oPredecessor.OutgoingPredecessors == false))
                    {
                        s_preADD.bCancel = true;
                        return;
                    }

                    s_preADD.sPredecessorKey = oPredecessor.Key;
                    if ((X <= oPredecessor.Left + ((oPredecessor.Right - oPredecessor.Left) / 2)))
                    {
                        s_preADD.sPredecessorPosition = "S";
                    }
                    else
                    {
                        s_preADD.sPredecessorPosition = "E";
                    }

                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseMove:
                    if (s_preADD.bCancel == false)
                    {
                        mp_oControl.clsG.EraseReversibleFrames();
                        mp_oControl.clsG.EraseReversibleLines();
                        //mp_DynamicRowMove(Y)
                        //mp_DynamicTimeLineMove(X)
                        mp_oControl.clsG.DrawReversibleLine(s_preADD.lXStart, s_preADD.lYStart, X, Y);
                        s_preADD.lTaskIndex = mp_oControl.MathLib.GetTaskIndexByPosition(X, Y);
                        if (s_preADD.lTaskIndex > 0)
                        {
                            oTask = (clsTask)mp_oControl.Tasks.Item(s_preADD.lTaskIndex.ToString());
                            if (oTask.IncomingPredecessors == false)
                            {
                                mp_SetCursor(E_CURSORTYPE.CT_NODROP);
                                s_preADD.bCantAccept = true;
                            }
                            else
                            {
                                s_preADD.bCantAccept = false;
                                mp_SetCursor(E_CURSORTYPE.CT_PREDECESSOR);
                                if ((X <= oTask.Left + ((oTask.Right - oTask.Left) / 2)))
                                {
                                    s_preADD.sTaskPosition = "S";
                                }
                                else
                                {
                                    s_preADD.sTaskPosition = "E";
                                }
                                mp_oControl.ToolTipEventArgs.Clear();
                                mp_oControl.ToolTipEventArgs.PredecessorPosition = s_preADD.sPredecessorPosition;
                                mp_oControl.ToolTipEventArgs.TaskPosition = s_preADD.sTaskPosition;
                                mp_oControl.clsG.EraseReversibleLines();
                                mp_oControl.FireToolTipOnMouseMove(mp_yOperation);
                                mp_oControl.clsG.DrawReversibleLine(s_preADD.lXStart, s_preADD.lYStart, X, Y);
                                mp_DrawMovingReversibleFrame(oTask.Left, oTask.Top, oTask.Right, oTask.Bottom, E_FOCUSTYPE.FCT_KEEPLEFTRIGHTBOUNDS);
                            }
                        }
                    }

                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseUp:
                    string sType = null;
                    E_CONSTRAINTTYPE mp_yType = 0;
                    mp_oControl.clsG.EraseReversibleFrames();
                    mp_oControl.clsG.EraseReversibleLines();
                    if (s_preADD.bCancel == false & s_preADD.bCantAccept == false)
                    {
                        if (s_preADD.lTaskIndex > 0)
                        {
                            oTask = (clsTask)mp_oControl.Tasks.Item(s_preADD.lTaskIndex.ToString());
                            if ((X <= oTask.Left + ((oTask.Right - oTask.Left) / 2)))
                            {
                                s_preADD.sTaskPosition = "S";
                            }
                            else
                            {
                                s_preADD.sTaskPosition = "E";
                            }
                            sType = s_preADD.sPredecessorPosition + s_preADD.sTaskPosition;
                            if (sType == "EE")
                            {
                                mp_yType = E_CONSTRAINTTYPE.PCT_END_TO_END;
                                mp_oControl.Predecessors.Add(oTask.Key, s_preADD.sPredecessorKey, E_CONSTRAINTTYPE.PCT_END_TO_END, "", "DS_PREDECESSOR");
                            }
                            else if (sType == "SS")
                            {
                                mp_yType = E_CONSTRAINTTYPE.PCT_START_TO_START;
                                mp_oControl.Predecessors.Add(oTask.Key, s_preADD.sPredecessorKey, E_CONSTRAINTTYPE.PCT_START_TO_START, "", "DS_PREDECESSOR");
                            }
                            else if (sType == "ES")
                            {
                                mp_yType = E_CONSTRAINTTYPE.PCT_END_TO_START;
                                mp_oControl.Predecessors.Add(oTask.Key, s_preADD.sPredecessorKey, E_CONSTRAINTTYPE.PCT_END_TO_START, "", "DS_PREDECESSOR");
                            }
                            else if (sType == "SE")
                            {
                                mp_yType = E_CONSTRAINTTYPE.PCT_START_TO_END;
                                mp_oControl.Predecessors.Add(oTask.Key, s_preADD.sPredecessorKey, E_CONSTRAINTTYPE.PCT_START_TO_END, "", "DS_PREDECESSOR");
                            }
                            if (mp_oControl.EnforcePredecessors == true)
                            {
                                mp_oControl.CheckPredecessors();
                            }
                            oPredecessor = mp_oControl.Tasks.Item(s_preADD.sPredecessorKey);
                            mp_oControl.ObjectAddedEventArgs.Clear();
                            mp_oControl.ObjectAddedEventArgs.TaskIndex = oTask.Index;
                            mp_oControl.ObjectAddedEventArgs.TaskKey = oTask.Key;
                            mp_oControl.ObjectAddedEventArgs.PredecessorTaskIndex = oPredecessor.Index;
                            mp_oControl.ObjectAddedEventArgs.PredecessorTaskKey = oPredecessor.Key;
                            mp_oControl.ObjectAddedEventArgs.PredecessorObjectIndex = mp_oControl.Predecessors.Count;
                            mp_oControl.ObjectAddedEventArgs.PredecessorType = mp_yType;
                            mp_oControl.ObjectAddedEventArgs.EventTarget = E_EVENTTARGET.EVT_PREDECESSOR;
                            mp_oControl.FireObjectAdded();
                        }
                    }

                    mp_oControl.Redraw();
                    mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseDblClick:
                    break;
                case E_MOUSEKEYBOARDEVENTS.MouseWheel:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyDown:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyUp:
                    break;
                case E_MOUSEKEYBOARDEVENTS.KeyPress:
                    break;
            }
        }

        private bool mp_bOverSplitter(int X, int Y)
        {
            if (mp_oControl.Splitter.Width == 0)
            {
                return false;
            }
            if (X >= (mp_oControl.Splitter.Right - mp_oControl.Splitter.Width) & X <= mp_oControl.Splitter.Right & Y < mp_oControl.clsG.Height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool mp_bOverEmptySpace(int Y)
        {
            if (Y > mp_oControl.Rows.TopOffset)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool mp_bOverTimeLine(int X, int Y)
        {
            if (X >= mp_oControl.CurrentViewObject.TimeLine.f_lStart & X <= mp_oControl.CurrentViewObject.TimeLine.f_lEnd & Y <= mp_oControl.CurrentViewObject.TimeLine.Bottom & Y >= mp_oControl.mt_TopMargin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool mp_bOverSelectedColumn(int X, int Y)
        {
            clsColumn oColumn = null;
            if (mp_oControl.SelectedColumnIndex == 0 | mp_oControl.Columns.Count == 0)
            {
                return false;
            }
            oColumn = (clsColumn)mp_oControl.Columns.oCollection.m_oReturnArrayElement(mp_oControl.SelectedColumnIndex);
            if (X >= oColumn.Left & X <= oColumn.Right & Y >= oColumn.Top & Y <= oColumn.Bottom)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool mp_bOverColumn(int X, int Y)
        {
            clsColumn oColumn = null;
            int lIndex = 0;
            if (!(X <= mp_oControl.Splitter.Left & Y <= mp_oControl.CurrentViewObject.TimeLine.Bottom))
            {
                return false;
            }
            for (lIndex = 1; lIndex <= mp_oControl.Columns.Count; lIndex++)
            {
                oColumn = (clsColumn)mp_oControl.Columns.oCollection.m_oReturnArrayElement(lIndex);
                if (oColumn.Visible == true)
                {
                    if (X >= oColumn.Left & X <= oColumn.Right & Y >= oColumn.Top & Y <= oColumn.Bottom)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        internal bool mp_bOverSelectedRow(int X, int Y)
        {
            clsRow oRow = null;
            if (mp_oControl.SelectedRowIndex == 0 | mp_oControl.Rows.Count == 0)
            {
                return false;
            }
            oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(mp_oControl.SelectedRowIndex);
            if (oRow.MergeCells == true)
            {
                if (X >= oRow.Left & X <= oRow.Right & Y >= oRow.Top & Y <= oRow.Bottom)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (X >= oRow.Left & X <= oRow.Right & Y >= oRow.Top & Y <= oRow.Bottom)
                {
                    if (mp_oControl.SelectedCellIndex == mp_oControl.MathLib.GetCellIndexByPosition(X))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        internal bool mp_bOverRow(int X, int Y)
        {
            clsRow oRow = null;
            int lIndex = 0;
            if (!(X <= mp_oControl.CurrentViewObject.TimeLine.f_lStart & Y > mp_oControl.CurrentViewObject.TimeLine.Bottom))
            {
                return false;
            }
            for (lIndex = 1; lIndex <= mp_oControl.Rows.Count; lIndex++)
            {
                oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(lIndex);
                if (oRow.Visible == true)
                {
                    if (X >= oRow.Left & X <= oRow.Right & Y >= oRow.Top & Y <= oRow.Bottom)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool mp_bOverSelectedTask(int X, int Y)
        {
            clsTask oSelectedTask = null;
            if (X < mp_oControl.CurrentViewObject.TimeLine.f_lStart)
            {
                return false;
            }
            if (X > mp_oControl.CurrentViewObject.TimeLine.f_lEnd)
            {
                return false;
            }
            if (mp_oControl.SelectedTaskIndex == 0)
            {
                return false;
            }
            oSelectedTask = (clsTask)mp_oControl.Tasks.oCollection.m_oReturnArrayElement(mp_oControl.SelectedTaskIndex);
            if (X >= oSelectedTask.Left & X <= oSelectedTask.Right & Y >= oSelectedTask.Top & Y <= oSelectedTask.Bottom & mp_oControl.MathLib.InCurrentLayer(oSelectedTask.LayerIndex))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool mp_bOverSelectedPredecessor(int X, int Y)
        {
            clsPredecessor oSelectedPredecessor = null;
            if (X < mp_oControl.CurrentViewObject.TimeLine.f_lStart)
            {
                return false;
            }
            if (X > mp_oControl.CurrentViewObject.TimeLine.f_lEnd)
            {
                return false;
            }
            if (mp_oControl.SelectedPredecessorIndex == 0)
            {
                return false;
            }
            oSelectedPredecessor = (clsPredecessor)mp_oControl.Predecessors.oCollection.m_oReturnArrayElement(mp_oControl.SelectedPredecessorIndex);
            if (oSelectedPredecessor.HitTest(X, Y) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool mp_bOverSelectedPercentage(int X, int Y)
        {
            clsPercentage oSelectedPercentage = null;
            if (X < mp_oControl.CurrentViewObject.TimeLine.f_lStart)
            {
                return false;
            }
            if (X > mp_oControl.CurrentViewObject.TimeLine.f_lEnd)
            {
                return false;
            }
            if (mp_oControl.SelectedPercentageIndex == 0)
            {
                return false;
            }
            oSelectedPercentage = (clsPercentage)mp_oControl.Percentages.oCollection.m_oReturnArrayElement(mp_oControl.SelectedPercentageIndex);
            if (X >= oSelectedPercentage.Left & X <= oSelectedPercentage.RightSel & Y >= oSelectedPercentage.Top & Y <= oSelectedPercentage.Bottom)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private E_AREA mp_yTaskArea(int X, int Y)
        {
            clsTask oSelectedTask = null;
            oSelectedTask = (clsTask)mp_oControl.Tasks.oCollection.m_oReturnArrayElement(mp_oControl.SelectedTaskIndex);
            if (X >= oSelectedTask.Left & X <= oSelectedTask.Right & Y >= oSelectedTask.Top & Y <= oSelectedTask.Bottom & mp_oControl.MathLib.InCurrentLayer(oSelectedTask.LayerIndex))
            {
                if (X >= oSelectedTask.Left & X <= oSelectedTask.Left + 2)
                {
                    if (oSelectedTask.f_bLeftVisible == true)
                    {
                        return E_AREA.EA_LEFT;
                    }
                    else
                    {
                        return E_AREA.EA_CENTER;
                    }
                }
                if (X >= oSelectedTask.Right - 2 & X <= oSelectedTask.Right)
                {
                    if (oSelectedTask.f_bRightVisible == true)
                    {
                        return E_AREA.EA_RIGHT;
                    }
                    else
                    {
                        return E_AREA.EA_CENTER;
                    }
                }
                return E_AREA.EA_CENTER;
            }
            return E_AREA.EA_NONE;
        }

        internal E_AREA mp_yRowArea(int X, int Y)
        {
            clsRow oSelectedRow = null;
            oSelectedRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(mp_oControl.SelectedRowIndex);
            if (Y >= oSelectedRow.Bottom & Y <= oSelectedRow.Bottom + 3)
            {
                return E_AREA.EA_BOTTOM;
            }
            else
            {
                return E_AREA.EA_CENTER;
            }
        }

        private E_AREA mp_yColumnArea(int X, int Y)
        {
            clsColumn oSelectedColumn = null;
            oSelectedColumn = (clsColumn)mp_oControl.Columns.oCollection.m_oReturnArrayElement(mp_oControl.SelectedColumnIndex);
            if (X >= (oSelectedColumn.Right - 3) & X <= oSelectedColumn.Right)
            {
                return E_AREA.EA_RIGHT;
            }
            else
            {
                return E_AREA.EA_CENTER;
            }
        }

        private void mp_DynamicColumnMove(int v_X)
        {
            if (v_X < mp_oControl.mt_LeftMargin)
            {
                if (mp_oControl.HorizontalScrollBar.Value > 20)
                {
                    mp_oControl.HorizontalScrollBar.Value = mp_oControl.HorizontalScrollBar.Value - 20;
                }
                else
                {
                    mp_oControl.HorizontalScrollBar.Value = 0;
                }
                mp_oControl.Redraw();
                return;
            }
            if (v_X > mp_oControl.Splitter.Left)
            {
                if (mp_oControl.HorizontalScrollBar.Value < (mp_oControl.HorizontalScrollBar.Max - 20))
                {
                    mp_oControl.HorizontalScrollBar.Value = mp_oControl.HorizontalScrollBar.Value + 20;
                }
                else
                {
                    mp_oControl.HorizontalScrollBar.Value = mp_oControl.HorizontalScrollBar.Max;
                }
                mp_oControl.Redraw();
                return;
            }
        }

        internal void mp_DynamicRowMove(int v_Y)
        {
            if (v_Y < mp_oControl.CurrentViewObject.TimeLine.Bottom)
            {
                if (mp_oControl.CurrentViewObject.ClientArea.FirstVisibleRow > 1)
                {
                    mp_oControl.CurrentViewObject.ClientArea.FirstVisibleRow = mp_oControl.CurrentViewObject.ClientArea.FirstVisibleRow - 1;
                    mp_oControl.VerticalScrollBar.Value = mp_oControl.VerticalScrollBar.Value - 1;
                    mp_oControl.Redraw();
                    return;
                }
            }
            if (v_Y > mp_oControl.CurrentViewObject.ClientArea.Bottom)
            {
                if (mp_oControl.VerticalScrollBar.Value < mp_oControl.VerticalScrollBar.Max)
                {
                    mp_oControl.CurrentViewObject.ClientArea.FirstVisibleRow = mp_oControl.CurrentViewObject.ClientArea.FirstVisibleRow + 1;
                    mp_oControl.VerticalScrollBar.Value = mp_oControl.VerticalScrollBar.Value + 1;
                    mp_oControl.Redraw();
                }
            }
        }

        private void mp_DynamicTimeLineMove(int v_X)
        {
            if (v_X > mp_oControl.CurrentViewObject.TimeLine.f_lEnd)
            {
                if (mp_oControl.CurrentViewObject.TimeLine.TimeLineScrollBar.Enabled == false)
                {
                    mp_oControl.CurrentViewObject.TimeLine.f_StartDate = mp_oControl.MathLib.DateTimeAdd(mp_oControl.CurrentViewObject.f_ScrollInterval, mp_oControl.CurrentViewObject.Factor, mp_oControl.CurrentViewObject.TimeLine.StartDate);
                }
                else
                {
                    if (mp_oControl.CurrentViewObject.TimeLine.TimeLineScrollBar.Value < mp_oControl.CurrentViewObject.TimeLine.TimeLineScrollBar.Max)
                    {
                        mp_oControl.CurrentViewObject.TimeLine.TimeLineScrollBar.Value = mp_oControl.CurrentViewObject.TimeLine.TimeLineScrollBar.Value + 1;
                    }
                }
                mp_oControl.Redraw();
            }
            if (v_X < mp_oControl.CurrentViewObject.TimeLine.f_lStart)
            {
                if (mp_oControl.CurrentViewObject.TimeLine.TimeLineScrollBar.Enabled == false)
                {
                    mp_oControl.CurrentViewObject.TimeLine.f_StartDate = mp_oControl.MathLib.DateTimeAdd(mp_oControl.CurrentViewObject.f_ScrollInterval, -mp_oControl.CurrentViewObject.Factor, mp_oControl.CurrentViewObject.TimeLine.StartDate);
                }
                else
                {
                    if (mp_oControl.CurrentViewObject.TimeLine.TimeLineScrollBar.Value > 0)
                    {
                        mp_oControl.CurrentViewObject.TimeLine.TimeLineScrollBar.Value = mp_oControl.CurrentViewObject.TimeLine.TimeLineScrollBar.Value - 1;
                    }
                }
                mp_oControl.Redraw();
            }
        }

        private bool mp_bOverTask(int X, int Y)
        {
            clsTask oTask = null;
            int lIndex = 0;
            for (lIndex = mp_oControl.Tasks.Count; lIndex >= 1; lIndex += -1)
            {
                oTask = (clsTask)mp_oControl.Tasks.oCollection.m_oReturnArrayElement(lIndex);
                if (oTask.Visible == true & mp_oControl.MathLib.InCurrentLayer(oTask.LayerIndex))
                {
                    if (X >= oTask.Left & X <= oTask.Right & Y >= oTask.Top & Y <= oTask.Bottom)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool mp_bOverPredecessor(int X, int Y)
        {
            clsPredecessor oPredecessor = null;
            int lIndex = 0;
            for (lIndex = mp_oControl.Predecessors.Count; lIndex >= 1; lIndex += -1)
            {
                oPredecessor = (clsPredecessor)mp_oControl.Predecessors.oCollection.m_oReturnArrayElement(lIndex);
                if (oPredecessor.Visible == true)
                {
                    if (oPredecessor.HitTest(X, Y) == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool mp_bOverPercentage(int X, int Y)
        {
            clsPercentage oPercentage = null;
            int lIndex = 0;
            for (lIndex = mp_oControl.Percentages.Count; lIndex >= 1; lIndex += -1)
            {
                oPercentage = (clsPercentage)mp_oControl.Percentages.oCollection.m_oReturnArrayElement(lIndex);
                if (oPercentage.Visible == true)
                {
                    if (X >= oPercentage.Left & X <= oPercentage.RightSel & Y >= oPercentage.Top & Y <= oPercentage.Bottom)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool mp_bOverClientArea(int X, int Y)
        {
            if (X >= mp_oControl.CurrentViewObject.TimeLine.f_lStart & X <= mp_oControl.CurrentViewObject.TimeLine.f_lEnd & Y >= mp_oControl.CurrentViewObject.ClientArea.Top)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private int mp_fSnapX(int X)
        {
            AGCSE.DateTime dtDate = new AGCSE.DateTime();
            if (mp_oControl.CurrentViewObject.ClientArea.Grid.SnapToGrid == false)
            {
                return X;
            }
            dtDate = mp_oControl.MathLib.GetDateFromXCoordinate(X);
            dtDate = mp_oControl.MathLib.RoundDate(mp_oControl.CurrentViewObject.ClientArea.Grid.Interval, mp_oControl.CurrentViewObject.ClientArea.Grid.Factor, dtDate);
            return mp_oControl.MathLib.GetXCoordinateFromDate(dtDate);
        }

        internal void mp_DrawMovingReversibleFrame(int v_X1, int v_Y1, int v_X2, int v_Y2, E_FOCUSTYPE v_yFocusType)
        {
            mp_oControl.clsG.f_FocusLeft = v_X1;
            mp_oControl.clsG.f_FocusTop = v_Y1;
            mp_oControl.clsG.f_FocusRight = v_X2;
            mp_oControl.clsG.f_FocusBottom = v_Y2;
            switch (v_yFocusType)
            {
                case E_FOCUSTYPE.FCT_NORMAL:
                    break;
                case E_FOCUSTYPE.FCT_KEEPLEFTRIGHTBOUNDS:
                    if (mp_oControl.clsG.f_FocusLeft < mp_oControl.CurrentViewObject.TimeLine.f_lStart)
                    {
                        mp_oControl.clsG.f_FocusLeft = mp_oControl.CurrentViewObject.TimeLine.f_lStart;
                    }

                    if (mp_oControl.clsG.f_FocusRight > mp_oControl.CurrentViewObject.TimeLine.f_lEnd)
                    {
                        mp_oControl.clsG.f_FocusRight = mp_oControl.CurrentViewObject.TimeLine.f_lEnd;
                    }

                    break;
                case E_FOCUSTYPE.FCT_ADD:
                    if (mp_oControl.clsG.f_FocusLeft < mp_oControl.CurrentViewObject.TimeLine.f_lStart)
                    {
                        mp_oControl.clsG.f_FocusLeft = mp_oControl.CurrentViewObject.TimeLine.f_lStart;
                    }

                    if (mp_oControl.clsG.f_FocusRight < mp_oControl.clsG.f_FocusLeft)
                    {
                        mp_oControl.clsG.f_FocusRight = mp_oControl.clsG.f_FocusLeft;
                        mp_oControl.clsG.f_FocusLeft = v_X2;
                    }


                    break;
                case E_FOCUSTYPE.FCT_VERTICALSPLITTER:
                    if (mp_oControl.clsG.f_FocusLeft >= mp_oControl.Splitter.Right)
                    {
                        mp_oControl.clsG.f_FocusBottom = mp_oControl.CurrentViewObject.ClientArea.Bottom;
                    }
                    else
                    {
                        mp_oControl.clsG.f_FocusBottom = mp_oControl.mt_TableBottom;
                    }

                    break;
            }
            mp_oControl.clsG.DrawReversibleFrameEx();
        }

        public void OnMouseLeave()
        {
            //mp_oToolTip.Visible = false;
        }

        internal bool mp_bCursorEditTextColumn(int X, int Y)
        {
            clsColumn oColumn;
            oColumn = mp_oControl.Columns.Item(mp_oControl.SelectedColumnIndex.ToString());
            if (oColumn.AllowTextEdit == true)
            {
                if (X >= oColumn.mp_lTextLeft & X <= oColumn.mp_lTextRight)
                {
                    if (Y >= oColumn.mp_lTextTop & Y <= oColumn.mp_lTextBottom)
                    {
                        mp_SetCursor(E_CURSORTYPE.CT_IBEAM);
                        return true;
                    }
                }
            }
            mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
            return false;
        }

        internal bool mp_bShowEditTextColumn(int X, int Y)
        {
            clsColumn oColumn;
            oColumn = mp_oControl.Columns.Item(mp_oControl.SelectedColumnIndex.ToString());
            if (oColumn.AllowTextEdit == true)
            {
                if (X >= oColumn.mp_lTextLeft & X <= oColumn.mp_lTextRight)
                {
                    if (Y >= oColumn.mp_lTextTop & Y <= oColumn.mp_lTextBottom)
                    {
                        mp_oControl.mp_oTextBox.Initialize(mp_oControl.SelectedColumnIndex, 0, E_TEXTOBJECTTYPE.TOT_COLUMN, X, Y);
                        return true;
                    }
                }
            }
            return false;
        }

        internal bool mp_bCursorEditTextRow(int X, int Y)
        {
            clsRow oRow;
            oRow = mp_oControl.Rows.Item(mp_oControl.SelectedRowIndex.ToString());
            if (oRow.MergeCells == true)
            {
                if (oRow.AllowTextEdit == true)
                {
                    if (X >= oRow.mp_lTextLeft & X <= oRow.mp_lTextRight)
                    {
                        if (Y >= oRow.mp_lTextTop & Y <= oRow.mp_lTextBottom)
                        {
                            mp_SetCursor(E_CURSORTYPE.CT_IBEAM);
                            return true;
                        }
                    }
                }
            }
            else
            {
                clsCell oCell;
                int lCellIndex = 0;
                clsColumn oColumn;
                for (lCellIndex = 1; lCellIndex <= mp_oControl.Columns.Count; lCellIndex++)
                {
                    oColumn = mp_oControl.Columns.Item(lCellIndex.ToString());
                    if (oColumn.Visible == true)
                    {
                        oCell = oRow.Cells.Item(lCellIndex.ToString());
                        if (oCell.AllowTextEdit == true)
                        {
                            if (X >= oCell.mp_lTextLeft & X <= oCell.mp_lTextRight)
                            {
                                if (Y >= oCell.mp_lTextTop & Y <= oCell.mp_lTextBottom)
                                {
                                    mp_SetCursor(E_CURSORTYPE.CT_IBEAM);
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
            return false;
        }

        internal bool mp_bShowEditTextRow(int X, int Y)
        {
            clsRow oRow;
            oRow = mp_oControl.Rows.Item(mp_oControl.SelectedRowIndex.ToString());
            if (oRow.MergeCells == true)
            {
                if (oRow.AllowTextEdit == true)
                {
                    if (X >= oRow.mp_lTextLeft & X <= oRow.mp_lTextRight)
                    {
                        if (Y >= oRow.mp_lTextTop & Y <= oRow.mp_lTextBottom)
                        {
                            mp_oControl.mp_oTextBox.Initialize(mp_oControl.SelectedRowIndex, 0, E_TEXTOBJECTTYPE.TOT_ROW, X, Y);
                            return true;
                        }
                    }
                }
            }
            else
            {
                clsCell oCell;
                int lCellIndex = 0;
                clsColumn oColumn;
                for (lCellIndex = 1; lCellIndex <= mp_oControl.Columns.Count; lCellIndex++)
                {
                    oColumn = mp_oControl.Columns.Item(lCellIndex.ToString());
                    if (oColumn.Visible == true)
                    {
                        oCell = oRow.Cells.Item(lCellIndex.ToString());
                        if (oCell.AllowTextEdit == true)
                        {
                            if (X >= oCell.mp_lTextLeft & X <= oCell.mp_lTextRight)
                            {
                                if (Y >= oCell.mp_lTextTop & Y <= oCell.mp_lTextBottom)
                                {
                                    mp_oControl.mp_oTextBox.Initialize(mp_oControl.SelectedRowIndex, lCellIndex, E_TEXTOBJECTTYPE.TOT_CELL, X, Y);
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        internal bool mp_bCursorEditTextTask(int X, int Y)
        {
            clsTask oTask;
            if (mp_oControl.SelectedTaskIndex <= 0)
            {
                mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
                return false;
            }
            oTask = mp_oControl.Tasks.Item(mp_oControl.SelectedTaskIndex.ToString());
            if (oTask.AllowTextEdit == true)
            {
                if (X >= oTask.mp_lTextLeft & X <= oTask.mp_lTextRight)
                {
                    if (Y >= oTask.mp_lTextTop & Y <= oTask.mp_lTextBottom)
                    {
                        mp_SetCursor(E_CURSORTYPE.CT_IBEAM);
                        return true;
                    }
                }
            }
            mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
            return false;
        }

        internal bool mp_bShowEditTextTask(int X, int Y)
        {
            clsTask oTask;
            if (mp_oControl.SelectedTaskIndex <= 0)
            {
                return false;
            }
            oTask = mp_oControl.Tasks.Item(mp_oControl.SelectedTaskIndex.ToString());
            if (oTask.AllowTextEdit == true)
            {
                if (X >= oTask.mp_lTextLeft & X <= oTask.mp_lTextRight)
                {
                    if (Y >= oTask.mp_lTextTop & Y <= oTask.mp_lTextBottom)
                    {
                        mp_oControl.mp_oTextBox.Initialize(mp_oControl.SelectedTaskIndex, 0, E_TEXTOBJECTTYPE.TOT_TASK, X, Y);
                        return true;
                    }
                }
            }
            return false;
        }


        internal void mp_SetCursor(E_CURSORTYPE v_iCursorType)
        {
            switch (v_iCursorType)
            {
                case E_CURSORTYPE.CT_NORMAL:
                    mp_CustomCursor("");
                    mp_oControl.oCanvas.Cursor = System.Windows.Input.Cursors.Arrow;
                    break;
                case E_CURSORTYPE.CT_SIZETASK:
                    mp_CustomCursor("");
                    mp_oControl.oCanvas.Cursor = System.Windows.Input.Cursors.SizeWE;
                    break;
                case E_CURSORTYPE.CT_MOVETASK:
                    mp_CustomCursor("SIZE_ALL.PNG");
                    break;
                case E_CURSORTYPE.CT_MOVEMILESTONE:
                    mp_CustomCursor("SIZE_ALL.PNG");
                    break;
                case E_CURSORTYPE.CT_CLIENTAREA:
                    mp_CustomCursor("CROSS.PNG");
                    break;
                case E_CURSORTYPE.CT_MOVESPLITTER:
                    mp_CustomCursor("");
                    mp_oControl.oCanvas.Cursor = System.Windows.Input.Cursors.SizeWE;
                    break;
                case E_CURSORTYPE.CT_IBEAM:
                    mp_CustomCursor("");
                    mp_oControl.oCanvas.Cursor = System.Windows.Input.Cursors.IBeam;
                    break;
                case E_CURSORTYPE.CT_ROWHEIGHT:
                    mp_CustomCursor("HO_SPLIT.PNG");
                    break;
                case E_CURSORTYPE.CT_COLUMNWIDTH:
                    mp_CustomCursor("VE_SPLIT.PNG");
                    break;
                case E_CURSORTYPE.CT_MOVEROW:
                    mp_CustomCursor("DRAGMOVE.PNG");
                    break;
                case E_CURSORTYPE.CT_MOVECOLUMN:
                    mp_CustomCursor("DRAGMOVE.PNG");
                    break;
                case E_CURSORTYPE.CT_SCROLLTIMELINE:
                    mp_CustomCursor("C_WAIT05.PNG");
                    break;
                case E_CURSORTYPE.CT_PERCENTAGE:
                    mp_CustomCursor("PERCENTAGE.PNG");
                    break;
                case E_CURSORTYPE.CT_PREDECESSOR:
                    mp_CustomCursor("PREDECESSOR.PNG");
                    break;
                case E_CURSORTYPE.CT_NODROP:
                    mp_CustomCursor("NO_DROP.PNG");
                    break;
            }
        }


        private void mp_CustomCursor(string sImage)
        {
            if (sImage.Length == 0)
            {
                mp_oControl.mp_oCursor.Source = null;
                mp_oControl.mp_sCursor = "";
            }
            else
            {
                if ((sImage != mp_oControl.mp_sCursor) | (string.IsNullOrEmpty(mp_oControl.mp_sCursor)))
                {
                    mp_oControl.mp_sCursor = sImage;
                    mp_oControl.oCanvas.Cursor = System.Windows.Input.Cursors.None;
                    System.Uri oURI = new System.Uri("AGCSE;component/" + sImage, UriKind.Relative);
                    System.Windows.Media.Imaging.BitmapImage oBitmap = new System.Windows.Media.Imaging.BitmapImage();
                    System.Windows.Resources.StreamResourceInfo oSRI = Application.GetResourceStream(oURI);
                    oBitmap.SetSource(oSRI.Stream);
                    mp_oControl.mp_oCursor.Source = oBitmap;
                }
            }
        }


    }

}
