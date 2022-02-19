using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;

namespace AGCSE
{

    public partial class ActiveGanttCSECtl : UserControl
    {

        public clsRows Rows;
        public clsTasks Tasks;
        public clsColumns Columns;
        public clsStyles Styles;
        public clsLayers Layers;
        public clsPercentages Percentages;
        public clsTimeBlocks TimeBlocks;
        public clsPredecessors Predecessors;
        public clsViews Views;
        public clsSplitter Splitter;
        public clsTreeview Treeview;
        public clsDrawing Drawing;
        public clsMath MathLib;
        public clsString StrLib;
        public clsVerticalScrollBar VerticalScrollBar;
        public clsHorizontalScrollBar HorizontalScrollBar;
        public clsTierAppearance TierAppearance;
        public clsTierFormat TierFormat;
        public clsScrollBarSeparator ScrollBarSeparator;

        internal WriteableBitmap mp_oBitmap;
        private clsTimeBlocks tmpTimeBlocks;
        internal clsMouseKeyboardEvents MouseKeyboardEvents;
        private clsView mp_oCurrentView;
        internal clsGraphics clsG;
        private Color mp_clrSelectionColor = Colors.Blue;
        private bool mp_bAllowAdd = true;
        private bool mp_bAllowEdit = true;
        private bool mp_bAllowSplitterMove = true;
        private bool mp_bAllowRowSize = true;
        private bool mp_bAllowRowMove = true;
        private bool mp_bAllowColumnSize = true;
        private bool mp_bAllowColumnMove = true;
        private bool mp_bAllowTimeLineScroll = true;
        private bool mp_bAllowPredecessorAdd = true;
        private bool mp_bDoubleBuffering = true;
        private bool mp_bPropertiesRead = false;
        private bool mp_bEnforcePredecessors = false;
        private AGCSE.DateTime mp_dtTimeLineStartBuffer;
        private AGCSE.DateTime mp_dtTimeLineEndBuffer;
        private int mp_lMinColumnWidth = 5;
        private int mp_lMinRowHeight = 5;
        private int mp_lSelectedTaskIndex = 0;
        private int mp_lSelectedColumnIndex = 0;
        private int mp_lSelectedRowIndex = 0;
        private int mp_lSelectedCellIndex = 0;
        private int mp_lSelectedPercentageIndex = 0;
        private int mp_lSelectedPredecessorIndex = 0;
        private int mp_lTreeviewColumnIndex = 0;
        private string mp_sCurrentLayer = "0";
        private string mp_sCurrentView = "";
        private E_ADDMODE mp_yAddMode = E_ADDMODE.AT_TASKADD;
        private E_INTERVAL mp_yAddDurationInterval = E_INTERVAL.IL_SECOND;
        private E_SCROLLBEHAVIOUR mp_yScrollBarBehaviour = E_SCROLLBEHAVIOUR.SB_HIDE;
        private E_TIMEBLOCKBEHAVIOUR mp_yTimeBlockBehaviour = E_TIMEBLOCKBEHAVIOUR.TBB_ROWEXTENTS;
        private E_LAYEROBJECTENABLE mp_yLayerEnableObjects = E_LAYEROBJECTENABLE.EC_INCURRENTLAYERONLY;
        private E_REPORTERRORS mp_yErrorReports = E_REPORTERRORS.RE_MSGBOX;
        private E_TIERAPPEARANCESCOPE mp_yTierAppearanceScope = E_TIERAPPEARANCESCOPE.TAS_CONTROL;
        private E_TIERFORMATSCOPE mp_yTierFormatScope = E_TIERFORMATSCOPE.TFS_CONTROL;
        private E_PREDECESSORMODE mp_yPredecessorMode = E_PREDECESSORMODE.PM_CREATEWARNINGFLAG;
        private string mp_sControlTag = "";
        private System.Globalization.CultureInfo mp_oCulture;
        private string mp_sStyleIndex;
        private clsStyle mp_oStyle;
        private Image mp_oImage;
        private string mp_sImageTag;
        internal clsTextBox mp_oTextBox;
        private System.Windows.Input.Key mp_oPredecessorAddModeKey = Key.F2;
        public ToolTipEventArgs ToolTipEventArgs = new ToolTipEventArgs();
        public ObjectAddedEventArgs ObjectAddedEventArgs = new ObjectAddedEventArgs();
        public CustomTierDrawEventArgs CustomTierDrawEventArgs = new CustomTierDrawEventArgs();
        public MouseEventArgs MouseEventArgs = new MouseEventArgs();
        public KeyEventArgs KeyEventArgs = new KeyEventArgs();
        public ScrollEventArgs ScrollEventArgs = new ScrollEventArgs();
        public DrawEventArgs DrawEventArgs = new DrawEventArgs();
        public PredecessorDrawEventArgs PredecessorDrawEventArgs = new PredecessorDrawEventArgs();
        public ObjectSelectedEventArgs ObjectSelectedEventArgs = new ObjectSelectedEventArgs();
        public ObjectStateChangedEventArgs ObjectStateChangedEventArgs = new ObjectStateChangedEventArgs();
        public ErrorEventArgs ErrorEventArgs = new ErrorEventArgs();
        public NodeEventArgs NodeEventArgs = new NodeEventArgs();
        public MouseWheelEventArgs MouseWheelEventArgs = new MouseWheelEventArgs();
        public TextEditEventArgs TextEditEventArgs = new TextEditEventArgs();
        public PredecessorExceptionEventArgs PredecessorExceptionEventArgs = new PredecessorExceptionEventArgs();

        
        internal Image mp_oCursor;

        internal string mp_sCursor;


        //Mouse Events
        public delegate void ControlClickEventHandler(object sender, MouseEventArgs e);
        public event ControlClickEventHandler ControlClick;
        public delegate void ControlDblClickEventHandler(object sender, MouseEventArgs e);
        public event ControlDblClickEventHandler ControlDblClick;
        public delegate void ControlMouseDownEventHandler(object sender, MouseEventArgs e);
        public event ControlMouseDownEventHandler ControlMouseDown;
        public delegate void ControlMouseMoveEventHandler(object sender, MouseEventArgs e);
        public event ControlMouseMoveEventHandler ControlMouseMove;
        public delegate void ControlMouseUpEventHandler(object sender, MouseEventArgs e);
        public event ControlMouseUpEventHandler ControlMouseUp;
        public delegate void ControlMouseHoverEventHandler(object sender, MouseEventArgs e);
        public event ControlMouseHoverEventHandler ControlMouseHover;
        public delegate void ControlMouseWheelEventHandler(object sender, MouseWheelEventArgs e);
        public event ControlMouseWheelEventHandler ControlMouseWheel;

        //Keyboard Events
        public delegate void ControlKeyDownEventHandler(object sender, KeyEventArgs e);
        public event ControlKeyDownEventHandler ControlKeyDown;
        public delegate void ControlKeyPressEventHandler(object sender, KeyEventArgs e);
        public event ControlKeyPressEventHandler ControlKeyPress;
        public delegate void ControlKeyUpEventHandler(object sender, KeyEventArgs e);
        public event ControlKeyUpEventHandler ControlKeyUp;

        // Scrolling
        public delegate void ControlScrollEventHandler(object sender, ScrollEventArgs e);
        public event ControlScrollEventHandler ControlScroll;

        //Draw
        public delegate void DrawEventHandler(object sender, DrawEventArgs e);
        public event DrawEventHandler Draw;
        public delegate void PredecessorDrawEventHandler(object sender, PredecessorDrawEventArgs e);
        public event PredecessorDrawEventHandler PredecessorDraw;
        public delegate void CustomTierDrawEventHandler(object sender, CustomTierDrawEventArgs e);
        public event CustomTierDrawEventHandler CustomTierDraw;
        public delegate void TierTextDrawEventHandler(object sender, CustomTierDrawEventArgs e);
        public event TierTextDrawEventHandler TierTextDraw;

        //Added/Selected
        public delegate void ObjectAddedEventHandler(object sender, ObjectAddedEventArgs e);
        public event ObjectAddedEventHandler ObjectAdded;
        public delegate void ObjectSelectedEventHandler(object sender, ObjectSelectedEventArgs e);
        public event ObjectSelectedEventHandler ObjectSelected;

        //Moving
        public delegate void BeginObjectMoveEventHandler(object sender, ObjectStateChangedEventArgs e);
        public event BeginObjectMoveEventHandler BeginObjectMove;
        public delegate void ObjectMoveEventHandler(object sender, ObjectStateChangedEventArgs e);
        public event ObjectMoveEventHandler ObjectMove;
        public delegate void EndObjectMoveEventHandler(object sender, ObjectStateChangedEventArgs e);
        public event EndObjectMoveEventHandler EndObjectMove;
        public delegate void CompleteObjectMoveEventHandler(object sender, ObjectStateChangedEventArgs e);
        public event CompleteObjectMoveEventHandler CompleteObjectMove;

        //Sizing
        public delegate void BeginObjectSizeEventHandler(object sender, ObjectStateChangedEventArgs e);
        public event BeginObjectSizeEventHandler BeginObjectSize;
        public delegate void ObjectSizeEventHandler(object sender, ObjectStateChangedEventArgs e);
        public event ObjectSizeEventHandler ObjectSize;
        public delegate void EndObjectSizeEventHandler(object sender, ObjectStateChangedEventArgs e);
        public event EndObjectSizeEventHandler EndObjectSize;
        public delegate void CompleteObjectSizeEventHandler(object sender, ObjectStateChangedEventArgs e);
        public event CompleteObjectSizeEventHandler CompleteObjectSize;

        //Errors
        public delegate void ActiveGanttErrorEventHandler(object sender, ErrorEventArgs e);
        public event ActiveGanttErrorEventHandler ActiveGanttError;
        public delegate void PredecessorExceptionEventHandler(object sender, PredecessorExceptionEventArgs e);
        public event PredecessorExceptionEventHandler PredecessorException;

        //Treeview
        public delegate void NodeCheckedEventHandler(object sender, NodeEventArgs e);
        public event NodeCheckedEventHandler NodeChecked;
        public delegate void NodeExpandedEventHandler(object sender, NodeEventArgs e);
        public event NodeExpandedEventHandler NodeExpanded;

        //Text Edit
        public delegate void BeginTextEditHandler(object sender, TextEditEventArgs e);
        public event BeginTextEditHandler BeginTextEdit;
        public delegate void EndTextEditHandler(object sender, TextEditEventArgs e);
        public event EndTextEditHandler EndTextEdit;

        //Other
        public delegate void TimeLineChangedEventHandler(object sender, System.EventArgs e);
        public event TimeLineChangedEventHandler TimeLineChanged;
        public delegate void ControlRedrawnEventHandler(object sender, System.EventArgs e);
        public event ControlRedrawnEventHandler ControlRedrawn;
        public delegate void ControlDrawEventHandler(object sender, System.EventArgs e);
        public event ControlDrawEventHandler ControlDraw;
        public delegate void ToolTipOnMouseHoverEventHandler(object sender, ToolTipEventArgs e);
        public event ToolTipOnMouseHoverEventHandler ToolTipOnMouseHover;
        public delegate void ToolTipOnMouseMoveEventHandler(object sender, ToolTipEventArgs e);
        public event ToolTipOnMouseMoveEventHandler ToolTipOnMouseMove;
        public delegate void OnMouseHoverToolTipDrawEventHandler(object sender, ToolTipEventArgs e);
        public event OnMouseHoverToolTipDrawEventHandler OnMouseHoverToolTipDraw;
        public delegate void OnMouseMoveToolTipDrawEventHandler(object sender, ToolTipEventArgs e);
        public event OnMouseMoveToolTipDrawEventHandler OnMouseMoveToolTipDraw;

        internal void FirePredecessorException()
        {
            if (PredecessorException != null)
            {
                PredecessorException(this, PredecessorExceptionEventArgs);
            }
        }

        internal void FireBeginTextEdit()
        {
            if (BeginTextEdit != null)
            {
                BeginTextEdit(this, TextEditEventArgs);
            }
        }

        internal void FireEndTextEdit()
        {
            if (EndTextEdit != null)
            {
                EndTextEdit(this, TextEditEventArgs);
            }
        }

        internal void FireControlClick()
        {
            if (ControlClick != null)
            {
                ControlClick(this, MouseEventArgs);
            }
        }

        internal void FireControlDblClick()
        {
            if (ControlDblClick != null)
            {
                ControlDblClick(this, MouseEventArgs);
            }
        }

        internal void FireControlMouseDown()
        {
            if (ControlMouseDown != null)
            {
                ControlMouseDown(this, MouseEventArgs);
            }
        }

        internal void FireControlMouseMove()
        {
            if (ControlMouseMove != null)
            {
                ControlMouseMove(this, MouseEventArgs);
            }
        }

        internal void FireControlMouseUp()
        {
            if (ControlMouseUp != null)
            {
                ControlMouseUp(this, MouseEventArgs);
            }
        }

        internal void FireControlMouseHover()
        {
            if (ControlMouseHover != null)
            {
                ControlMouseHover(this, MouseEventArgs);
            }
        }

        internal void FireControlKeyDown()
        {
            if (ControlKeyDown != null)
            {
                ControlKeyDown(this, KeyEventArgs);
            }
        }

        internal void FireControlKeyUp()
        {
            if (ControlKeyDown != null)
            {
                ControlKeyUp(this, KeyEventArgs);
            }
        }

        internal void FireControlKeyPress()
        {
            if (ControlKeyDown != null)
            {
                ControlKeyPress(this, KeyEventArgs);
            }
        }

        internal void FireControlMouseWheel()
        {
            if (ControlMouseWheel != null)
            {
                ControlMouseWheel(this, MouseWheelEventArgs);
            }
        }

        internal void FireDraw()
        {
            if (Draw != null)
            {
                Draw(this, DrawEventArgs);
            }
        }

        internal void FirePredecessorDraw()
        {
            if (PredecessorDraw != null)
            {
                PredecessorDraw(this, PredecessorDrawEventArgs);
            }
        }

        internal void FireCustomTierDraw()
        {
            if (CustomTierDraw != null)
            {
                CustomTierDraw(this, CustomTierDrawEventArgs);
            }
        }

        internal void FireTierTextDraw()
        {
            if (TierTextDraw != null)
            {
                TierTextDraw(this, CustomTierDrawEventArgs);
            }
        }

        internal void FireObjectAdded()
        {
            if (ObjectAdded != null)
            {
                ObjectAdded(this, ObjectAddedEventArgs);
            }
        }

        internal void FireObjectSelected()
        {
            if (ObjectSelected != null)
            {
                ObjectSelected(this, ObjectSelectedEventArgs);
            }
        }

        internal void FireBeginObjectMove()
        {
            if (BeginObjectMove != null)
            {
                BeginObjectMove(this, ObjectStateChangedEventArgs);
            }
        }

        internal void FireObjectMove()
        {
            if (ObjectMove != null)
            {
                ObjectMove(this, ObjectStateChangedEventArgs);
            }
        }

        internal void FireEndObjectMove()
        {
            if (EndObjectMove != null)
            {
                EndObjectMove(this, ObjectStateChangedEventArgs);
            }
        }

        internal void FireCompleteObjectMove()
        {
            if (CompleteObjectMove != null)
            {
                CompleteObjectMove(this, ObjectStateChangedEventArgs);
            }
        }

        internal void FireBeginObjectSize()
        {
            if (BeginObjectSize != null)
            {
                BeginObjectSize(this, ObjectStateChangedEventArgs);
            }
        }

        internal void FireObjectSize()
        {
            if (ObjectSize != null)
            {
                ObjectSize(this, ObjectStateChangedEventArgs);
            }
        }

        internal void FireEndObjectSize()
        {
            if (EndObjectSize != null)
            {
                EndObjectSize(this, ObjectStateChangedEventArgs);
            }
        }

        internal void FireCompleteObjectSize()
        {
            if (CompleteObjectSize != null)
            {
                CompleteObjectSize(this, ObjectStateChangedEventArgs);
            }
        }

        internal void FireActiveGanttError()
        {
            if (ActiveGanttError != null)
            {
                ActiveGanttError(this, ErrorEventArgs);
            }
        }

        internal void FireControlScroll()
        {
            if (ControlScroll != null)
            {
                ControlScroll(this, ScrollEventArgs);
            }
        }

        internal void FireNodeChecked()
        {
            if (NodeChecked != null)
            {
                NodeChecked(this, NodeEventArgs);
            }
        }

        internal void FireNodeExpanded()
        {
            if (NodeExpanded != null)
            {
                NodeExpanded(this, NodeEventArgs);
            }
        }

        internal void FireControlDraw()
        {
            if (ControlDraw != null)
            {
                ControlDraw(this, new System.EventArgs());
            }
        }

        internal void FireControlRedrawn()
        {
            if (ControlRedrawn != null)
            {
                ControlRedrawn(this, new System.EventArgs());
            }
        }

        internal void FireTimeLineChanged()
        {
            if (TimeLineChanged != null)
            {
                TimeLineChanged(this, new System.EventArgs());
            }
        }

        internal void FireToolTipOnMouseHover(E_EVENTTARGET EventTarget)
        {
            if (mp_oCurrentView.ClientArea.ToolTipsVisible == false)
            {
                return;
            }
            ToolTipEventArgs.ToolTipType = E_TOOLTIPTYPE.TPT_HOVER;
            ToolTipEventArgs.EventTarget = EventTarget;
            if (ToolTipOnMouseHover != null)
            {
                ToolTipOnMouseHover(this, ToolTipEventArgs);
            }
        }

        internal void FireToolTipOnMouseMove(E_OPERATION Operation)
        {
            if (mp_oCurrentView.ClientArea.ToolTipsVisible == false)
            {
                return;
            }
            ToolTipEventArgs.ToolTipType = E_TOOLTIPTYPE.TPT_MOVEMENT;
            ToolTipEventArgs.Operation = Operation;
            if (ToolTipOnMouseMove != null)
            {
                ToolTipOnMouseMove(this, ToolTipEventArgs);
            }
        }

        internal void FireOnMouseHoverToolTipDraw(E_EVENTTARGET EventTarget)
        {
            if (mp_oCurrentView.ClientArea.ToolTipsVisible == false)
            {
                return;
            }
            if (OnMouseHoverToolTipDraw != null)
            {
                OnMouseHoverToolTipDraw(this, ToolTipEventArgs);
            }
        }

        internal void FireOnMouseMoveToolTipDraw(E_OPERATION Operation)
        {
            if (mp_oCurrentView.ClientArea.ToolTipsVisible == false)
            {
                return;
            }
            if (OnMouseMoveToolTipDraw != null)
            {
                OnMouseMoveToolTipDraw(this, ToolTipEventArgs);
            }
        }



        public ActiveGanttCSECtl()
        {
            InitializeComponent();

            if (f_UserMode == true)
            {
                mp_oCursor = new Image();
                mp_oCursor.Width = 32;
                mp_oCursor.Height = 32;
                oCanvas.Children.Add(mp_oCursor);
            }


            if (mp_bPropertiesRead == false)
            {
                clsG = new clsGraphics(this);
                MathLib = new clsMath(this);
                StrLib = new clsString(this);
                Styles = new clsStyles(this);
                mp_sStyleIndex = "DS_CONTROL";
                mp_oStyle = Styles.FItem("DS_CONTROL");
                VerticalScrollBar = new clsVerticalScrollBar(this);
                HorizontalScrollBar = new clsHorizontalScrollBar(this);
                Rows = new clsRows(this);
                Tasks = new clsTasks(this);
                Columns = new clsColumns(this);
                Layers = new clsLayers(this);
                Percentages = new clsPercentages(this);
                TimeBlocks = new clsTimeBlocks(this);
                Predecessors = new clsPredecessors(this);
                tmpTimeBlocks = new clsTimeBlocks(this);
                Splitter = new clsSplitter(this);
                Views = new clsViews(this);
                Treeview = new clsTreeview(this);
                mp_oCurrentView = Views.FItem("0");
                MouseKeyboardEvents = new clsMouseKeyboardEvents(this);
                Drawing = new clsDrawing(this);
                mp_oCulture = (System.Globalization.CultureInfo)System.Globalization.CultureInfo.CurrentCulture.Clone();
                TierAppearance = new clsTierAppearance(this);
                TierFormat = new clsTierFormat(this);
                ScrollBarSeparator = new clsScrollBarSeparator(this);
                mp_oTextBox = new clsTextBox(this);

                mp_oImage = null;
                mp_sImageTag = "";
            }
            mp_bPropertiesRead = true;
        }

        private void oCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            this.Focus();
            Init();
        }

        private void Init()
        {
            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            if (clsG.NeedsRendering == true)
            {
                OnPaint();
            }
        }

        internal void OnPaint()
        {
            if (f_UserMode == false)
            {
                mp_DrawDesignMode();
            }
            else
            {
                //clsG.StartDrawing()
                //'mp_CHKPXPScrollButtons() 'Done
                //mp_CHKPXPLines() 'Done
                //'mp_CHKPXPButtons() 'Done
                //'mp_CHKPXPArrows() 'Done
                //'mp_CHKPXPFigures() 'Done
                //'mp_CHKPXPGradients() 'Done
                //'mp_CHKPXPText() 'Done
                //'mp_CHKPXPHatch() 'Done
                //clsG.TerminateDrawing()
                mp_Draw();
            }
            if (mp_oCurrentView.TimeLine.StartDate != mp_dtTimeLineStartBuffer | mp_oCurrentView.TimeLine.EndDate != mp_dtTimeLineEndBuffer)
            {
                mp_dtTimeLineStartBuffer = mp_oCurrentView.TimeLine.StartDate;
                mp_dtTimeLineEndBuffer = mp_oCurrentView.TimeLine.EndDate;
                FireTimeLineChanged();
            }
        }

        private void mp_Draw()
        {
            FireControlDraw();
            clsG.ResetFocusRectangle();
            clsG.StartDrawing();
            clsG.ClipRegion(0, 0, clsG.Width, clsG.Height, false);
            clsG.mp_DrawItem(0, 0, clsG.Width - 1, clsG.Height - 1, "", "", false, this.Image, 0, 0, this.Style);
            mp_oCurrentView.TimeLine.Calculate();
            mp_PositionScrollBars();
            Columns.Position();
            Rows.InitializePosition();
            Rows.PositionRows();
            Columns.Draw();
            Rows.Draw();
            Treeview.Draw();
            mp_oCurrentView.TimeLine.Draw();
            mp_oCurrentView.TimeLine.ProgressLine.Draw();
            TimeBlocks.CreateTemporaryTimeBlocks();
            TimeBlocks.Draw();
            mp_oCurrentView.ClientArea.Grid.Draw();
            mp_oCurrentView.ClientArea.Draw();
            Predecessors.Draw();
            Tasks.Draw();
            Percentages.Draw();
            mp_oCurrentView.TimeLine.ProgressLine.Draw();
            Splitter.Draw();
            clsG.ClipRegion(0, 0, clsG.Width, clsG.Height, false);
            if (VerticalScrollBar.State == E_SCROLLSTATE.SS_SHOWN)
            {
                clsG.mp_DrawItem(VerticalScrollBar.Left, VerticalScrollBar.Top + VerticalScrollBar.Height, VerticalScrollBar.Left + 16, VerticalScrollBar.Top + VerticalScrollBar.Height + 16, "", "", false, null, 0, 0, ScrollBarSeparator.Style);
                clsG.ClipRegion(0, 0, clsG.Width, clsG.Height, false);
            }
            else if (mp_oCurrentView.TimeLine.TimeLineScrollBar.State == E_SCROLLSTATE.SS_SHOWN)
            {
                clsG.mp_DrawItem(mp_oCurrentView.TimeLine.TimeLineScrollBar.Left + mp_oCurrentView.TimeLine.TimeLineScrollBar.Width, mp_oCurrentView.TimeLine.TimeLineScrollBar.Top, mp_oCurrentView.TimeLine.TimeLineScrollBar.Left + mp_oCurrentView.TimeLine.TimeLineScrollBar.Width + 16, mp_oCurrentView.TimeLine.TimeLineScrollBar.Top + 16, "", "", false, null, 0, 0, ScrollBarSeparator.Style);
                clsG.ClipRegion(0, 0, clsG.Width, clsG.Height, false);
            }
            mp_DrawDebugMetrics();
            if (VerticalScrollBar.State == E_SCROLLSTATE.SS_SHOWN)
            {
                VerticalScrollBar.ScrollBar.Draw();
            }
            if (HorizontalScrollBar.State == E_SCROLLSTATE.SS_SHOWN)
            {
                HorizontalScrollBar.ScrollBar.Draw();
            }
            if (mp_oCurrentView.TimeLine.TimeLineScrollBar.State == E_SCROLLSTATE.SS_SHOWN)
            {
                mp_oCurrentView.TimeLine.TimeLineScrollBar.ScrollBar.Draw();
            }
#if DemoVersion
            Font oFont = new Font("Arial", 12, E_FONTSIZEUNITS.FSU_POINTS, FontWeights.Bold);
		System.Random rnd = null;
		rnd = new System.Random((int)System.DateTime.Now.Ticks);
		Color oColor = new Color();
		oColor = Color.FromArgb(255, System.Convert.ToByte(rnd.Next(0, 255)), System.Convert.ToByte(rnd.Next(0, 255)), System.Convert.ToByte(rnd.Next(0, 255)));
		clsG.DrawAlignedText(20, 20, clsG.Width - 20, clsG.Height - 20, "ActiveGanttCSE Scheduler Component" + "\r\n" + "Trial Version: " + "1.0.0.0" + "\r\n" + "For evaluation purposes only" + "\r\n" + "Purchase the full version through: " + "\r\n" + "http://www.sourcecodestore.com", GRE_HORIZONTALALIGNMENT.HAL_RIGHT, GRE_VERTICALALIGNMENT.VAL_BOTTOM, oColor, oFont, true
		);
#endif
            clsG.TerminateDrawing();
            FireControlRedrawn();
        }

        private void mp_DrawDesignMode()
        {
            Border oBorder;
            TextBlock oTextBlock;
            if (oCanvas.Children.Count == 1)
            {
                oBorder = new Border();
                oBorder.BorderThickness = new Thickness(2, 2, 2, 2);
                oBorder.BorderBrush = new SolidColorBrush(Colors.Blue);
                oBorder.Width = oCanvas.ActualWidth;
                oBorder.Height = oCanvas.ActualHeight;
                oTextBlock = new TextBlock();
                oTextBlock.Text = "ActiveGanttCSE Silverlight Control" + "\r\n" + "Version: " + Version;
                oTextBlock.FontFamily = new FontFamily("Verdana");
                oTextBlock.FontSize = 14;
                oTextBlock.Foreground = new SolidColorBrush(Color.FromArgb(255, 70, 70, 70));
                oTextBlock.TextAlignment = TextAlignment.Center;
                oTextBlock.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                oBorder.Child = oTextBlock;
                oCanvas.Children.Add(oBorder);
            }
            else
            {
                oBorder = (System.Windows.Controls.Border)oCanvas.Children[1];
                oBorder.Width = oCanvas.ActualWidth;
                oBorder.Height = oCanvas.ActualHeight;
            }
        }


        private void mp_DrawDebugMetrics()
        {
        }

        //Friend Function f_HDC() As Graphics
        //    Return mp_oGraphics
        //End Function

        internal int f_Width()
        {
            return (int)this.Width;
        }

        internal int f_Height()
        {
            return (int)this.Height;
        }

        internal int mp_lStrWidth(string sString, Font r_oFont)
        {
            //Return MathLib.RoundDouble(mp_oGraphics.MeasureString(sString, r_oFont).Width)
            TextBlock oTextBlock = new TextBlock();
            oTextBlock.Text = sString;
            oTextBlock.FontFamily = new FontFamily(r_oFont.FamilyName);
            oTextBlock.FontSize = r_oFont.Size;
            oTextBlock.FontWeight = r_oFont.FontWeight;
            oTextBlock.Measure(new System.Windows.Size(1000, 1000));
            return (int)oTextBlock.ActualWidth;
        }

        internal int mp_lStrHeight(string sString, Font r_oFont)
        {
            TextBlock oTextBlock = new TextBlock();
            oTextBlock.Text = sString;
            oTextBlock.FontFamily = new FontFamily(r_oFont.FamilyName);
            oTextBlock.FontSize = r_oFont.Size;
            oTextBlock.FontWeight = r_oFont.FontWeight;
            oTextBlock.Measure(new System.Windows.Size(1000, 1000));
            return (int)oTextBlock.ActualHeight;
        }

        //'Friend Function GetGraphicsObject() As Graphics
        //'    Return Me.CreateGraphics()
        //'End Function

        //Friend Sub ReleaseGraphicsObject()
        //    Me.ReleaseGraphicsObject()
        //End Sub

        internal clsTimeBlocks TempTimeBlocks()
        {
            return tmpTimeBlocks;
        }

        internal bool f_UserMode
        {
            get { return !System.ComponentModel.DesignerProperties.GetIsInDesignMode(this); }
        }

        internal int mt_BorderThickness
        {
            get
            {
                switch (mp_oStyle.Appearance)
                {
                    case E_STYLEAPPEARANCE.SA_RAISED:
                        return 2;
                    case E_STYLEAPPEARANCE.SA_SUNKEN:
                        return 2;
                    case E_STYLEAPPEARANCE.SA_FLAT:
                        if (mp_oStyle.BorderStyle == GRE_BORDERSTYLE.SBR_NONE)
                        {
                            return 0;
                        }
                        else
                        {
                            return mp_oStyle.BorderWidth;
                        }
                    case E_STYLEAPPEARANCE.SA_CELL:
                        if (mp_oStyle.BorderStyle == GRE_BORDERSTYLE.SBR_NONE)
                        {
                            return 0;
                        }
                        else
                        {
                            return mp_oStyle.BorderWidth;
                        }
                    case E_STYLEAPPEARANCE.SA_GRAPHICAL:
                        return 0;
                }
                return 0;
            }
        }

        internal int mt_TableBottom
        {
            get
            {
                if (HorizontalScrollBar.State == E_SCROLLSTATE.SS_SHOWN)
                {
                    return clsG.Height - mt_BorderThickness - 1 - HorizontalScrollBar.Height;
                }
                else
                {
                    return clsG.Height - mt_BorderThickness - 1;
                }
            }
        }

        internal int mt_TopMargin
        {
            get { return mt_BorderThickness; }
        }

        internal int mt_LeftMargin
        {
            get { return mt_BorderThickness; }
        }

        internal int mt_RightMargin
        {
            get
            {
                if (VerticalScrollBar.State == E_SCROLLSTATE.SS_SHOWN)
                {
                    return clsG.Width - mt_BorderThickness - 1 - VerticalScrollBar.Width;
                }
                else
                {
                    return clsG.Width - mt_BorderThickness - 1;
                }
            }
        }

        internal int mt_BottomMargin
        {
            get { return clsG.Height - mt_BorderThickness - 1; }
        }

        private void oCanvas_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (f_UserMode == false)
            {
                return;
            }
            System.Diagnostics.Debug.WriteLine(e.Key + " " + e.Key.ToString());
            MouseKeyboardEvents.KeyDown(e.Key);
        }

        private void oCanvas_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (f_UserMode == false)
            {
                return;
            }
            MouseKeyboardEvents.KeyUp(e.Key);
            System.Diagnostics.Debug.WriteLine("KeyUp");
        }

        private void oCanvas_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (f_UserMode == false)
            {
                return;
            }
            MouseKeyboardEvents.OnMouseLeave();
        }

        private void oCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (f_UserMode == false)
            {
                return;
            }
            MouseKeyboardEvents.OnMouseDown((int)e.GetPosition(oCanvas).X, (int)e.GetPosition(oCanvas).Y, E_MOUSEBUTTONS.BTN_LEFT);
            e.Handled = true;
        }

        private void oCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (f_UserMode == false)
            {
                return;
            }
            MouseKeyboardEvents.OnMouseDown((int)e.GetPosition(oCanvas).X, (int)e.GetPosition(oCanvas).Y, E_MOUSEBUTTONS.BTN_RIGHT);
            e.Handled = true;
        }

        private void oCanvas_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (f_UserMode == false)
            {
                return;
            }
            mp_oCursor.SetValue(Canvas.LeftProperty, e.GetPosition(oCanvas).X - 16);
            mp_oCursor.SetValue(Canvas.TopProperty, e.GetPosition(oCanvas).Y - 16);

            MouseKeyboardEvents.OnMouseMoveGeneral((int)e.GetPosition(oImage).X, (int)e.GetPosition(oImage).Y);
        }

        private void oCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (f_UserMode == false)
            {
                return;
            }
            MouseKeyboardEvents.OnMouseUp((int)e.GetPosition(oCanvas).X, (int)e.GetPosition(oCanvas).Y);
            Redraw();
            e.Handled = true;
        }

        private void oCanvas_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (f_UserMode == false)
            {
                return;
            }
            MouseKeyboardEvents.OnMouseUp((int)e.GetPosition(oCanvas).X, (int)e.GetPosition(oCanvas).Y);
            Redraw();
            e.Handled = true;
        }

        private void oCanvas_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            MouseWheelEventArgs.Clear();
            MouseWheelEventArgs.Delta = e.Delta;
            MouseWheelEventArgs.X = (int)e.GetPosition(oCanvas).X;
            MouseWheelEventArgs.Y = (int)e.GetPosition(oCanvas).Y;
            //MouseWheelEventArgs.Button = DirectCast(e., E_MOUSEBUTTONS)
            FireControlMouseWheel();
        }


        public void Redraw()
        {
            clsG.NeedsRendering = true;
        }



        internal void VerticalScrollBar_ValueChanged(int Offset)
        {
            Redraw();
            ScrollEventArgs.Clear();
            ScrollEventArgs.ScrollBarType = E_SCROLLBAR.SCR_VERTICAL;
            ScrollEventArgs.Offset = Offset;
            FireControlScroll();
        }

        internal void HorizontalScrollBar_ValueChanged(int Offset)
        {
            Redraw();
            ScrollEventArgs.Clear();
            ScrollEventArgs.ScrollBarType = E_SCROLLBAR.SCR_HORIZONTAL1;
            ScrollEventArgs.Offset = Offset;
            FireControlScroll();
        }

        internal void TimeLineScrollBar_ValueChanged(int Offset)
        {
            Redraw();
            ScrollEventArgs.Clear();
            ScrollEventArgs.ScrollBarType = E_SCROLLBAR.SCR_HORIZONTAL2;
            ScrollEventArgs.Offset = Offset;
            FireControlScroll();
        }

        internal void mp_PositionScrollBars()
        {
            if (f_UserMode == false)
            {
                return;
            }

            if (clsG.Height <= mp_oCurrentView.ClientArea.Top)
            {
                VerticalScrollBar.State = E_SCROLLSTATE.SS_CANTDISPLAY;
                HorizontalScrollBar.State = E_SCROLLSTATE.SS_CANTDISPLAY;
                mp_oCurrentView.TimeLine.TimeLineScrollBar.State = E_SCROLLSTATE.SS_CANTDISPLAY;
                return;
            }

            //// Determine need for HorizontalScrollBar
            int lWidth = 0;
            lWidth = Columns.Width;
            if (lWidth > Splitter.Right)
            {
                HorizontalScrollBar.State = E_SCROLLSTATE.SS_NEEDED;
            }
            else
            {
                HorizontalScrollBar.State = E_SCROLLSTATE.SS_NOTNEEDED;
            }
            if (Splitter.Right < 5)
            {
                HorizontalScrollBar.State = E_SCROLLSTATE.SS_CANTDISPLAY;
            }

            //// Determine need for mp_oCurrentView.TimeLine.TimeLineScrollBar
            if (Splitter.Right < clsG.Width - (18 + mt_BorderThickness))
            {
                if (mp_oCurrentView.TimeLine.TimeLineScrollBar.Enabled == true)
                {
                    if (mp_oCurrentView.TimeLine.TimeLineScrollBar.mf_Visible == true)
                    {
                        mp_oCurrentView.TimeLine.TimeLineScrollBar.State = E_SCROLLSTATE.SS_NEEDED;
                    }
                    else
                    {
                        mp_oCurrentView.TimeLine.TimeLineScrollBar.State = E_SCROLLSTATE.SS_NOTNEEDED;
                    }
                }
                else
                {
                    mp_oCurrentView.TimeLine.TimeLineScrollBar.State = E_SCROLLSTATE.SS_NOTNEEDED;
                }
            }
            else
            {
                mp_oCurrentView.TimeLine.TimeLineScrollBar.State = E_SCROLLSTATE.SS_CANTDISPLAY;
            }

            //// Determine need for VerticalScrollBar
            if (((Rows.Height() + mp_oCurrentView.ClientArea.Top + HorizontalScrollBar.Height + mt_BorderThickness) > clsG.Height) | (Rows.RealFirstVisibleRow > 1))
            {
                if (mp_oCurrentView.TimeLine.TimeLineScrollBar.State == E_SCROLLSTATE.SS_CANTDISPLAY)
                {
                    VerticalScrollBar.State = E_SCROLLSTATE.SS_CANTDISPLAY;
                }
                else
                {
                    VerticalScrollBar.State = E_SCROLLSTATE.SS_NEEDED;
                }
            }
            else
            {
                VerticalScrollBar.State = E_SCROLLSTATE.SS_NOTNEEDED;
            }

            if (VerticalScrollBar.mf_Visible == false)
            {
                VerticalScrollBar.State = E_SCROLLSTATE.SS_CANTDISPLAY;
            }
            if (HorizontalScrollBar.mf_Visible == false)
            {
                HorizontalScrollBar.State = E_SCROLLSTATE.SS_CANTDISPLAY;
            }
            if (mp_oCurrentView.TimeLine.TimeLineScrollBar.mf_Visible == false)
            {
                mp_oCurrentView.TimeLine.TimeLineScrollBar.State = E_SCROLLSTATE.SS_CANTDISPLAY;
            }

            if (VerticalScrollBar.State == E_SCROLLSTATE.SS_SHOWN)
            {
                VerticalScrollBar.Position();
            }
            if (HorizontalScrollBar.State == E_SCROLLSTATE.SS_SHOWN)
            {
                HorizontalScrollBar.Position();
            }
            if (mp_oCurrentView.TimeLine.TimeLineScrollBar.State == E_SCROLLSTATE.SS_SHOWN)
            {
                mp_oCurrentView.TimeLine.TimeLineScrollBar.Position();
            }
        }

        //Public Sub WriteXML(ByVal url As String)
        //    Dim oXML As New clsXML(Me, "ActiveGanttCtl")
        //    mp_WriteXML(oXML)
        //    oXML.WriteXML(url)
        //End Sub

        //Public Sub ReadXML(ByVal url As String)
        //    Dim oXML As New clsXML(Me, "ActiveGanttCtl")
        //    oXML.ReadXML(url)
        //    mp_ReadXML(oXML)
        //End Sub

        public void SetXML(string sXML)
        {
            clsXML oXML = new clsXML(this, "ActiveGanttCtl");
            oXML.SetXML(sXML);
            mp_ReadXML(ref oXML);
        }

        public string GetXML()
        {
            clsXML oXML = new clsXML(this, "ActiveGanttCtl");
            mp_WriteXML(ref oXML);
            return oXML.GetXML();
        }

        private void mp_WriteXML(ref clsXML oXML)
        {
            oXML.InitializeWriter();
            oXML.WriteProperty("Version", "AGCSE");
            oXML.WriteProperty("ControlTag", mp_sControlTag);
            oXML.WriteProperty("AddMode", mp_yAddMode);
            oXML.WriteProperty("AddDurationInterval", mp_yAddDurationInterval);
            oXML.WriteProperty("AllowAdd", mp_bAllowAdd);
            oXML.WriteProperty("AllowColumnMove", mp_bAllowColumnMove);
            oXML.WriteProperty("AllowColumnSize", mp_bAllowColumnSize);
            oXML.WriteProperty("AllowEdit", mp_bAllowEdit);
            oXML.WriteProperty("AllowPredecessorAdd", mp_bAllowPredecessorAdd);
            oXML.WriteProperty("AllowRowMove", mp_bAllowRowMove);
            oXML.WriteProperty("AllowRowSize", mp_bAllowRowSize);
            oXML.WriteProperty("AllowSplitterMove", mp_bAllowSplitterMove);
            oXML.WriteProperty("AllowTimeLineScroll", mp_bAllowTimeLineScroll);
            oXML.WriteProperty("EnforcePredecessors", mp_bEnforcePredecessors);
            oXML.WriteProperty("CurrentLayer", mp_sCurrentLayer);
            oXML.WriteProperty("CurrentView", mp_sCurrentView);
            oXML.WriteProperty("DoubleBuffering", mp_bDoubleBuffering);
            oXML.WriteProperty("ErrorReports", mp_yErrorReports);
            oXML.WriteProperty("LayerEnableObjects", mp_yLayerEnableObjects);
            oXML.WriteProperty("MinColumnWidth", mp_lMinColumnWidth);
            oXML.WriteProperty("MinRowHeight", mp_lMinRowHeight);
            oXML.WriteProperty("ScrollBarBehaviour", mp_yScrollBarBehaviour);
            oXML.WriteProperty("SelectedCellIndex", mp_lSelectedCellIndex);
            oXML.WriteProperty("SelectedColumnIndex", mp_lSelectedColumnIndex);
            oXML.WriteProperty("SelectedPercentageIndex", mp_lSelectedPercentageIndex);
            oXML.WriteProperty("SelectedPredecessorIndex", mp_lSelectedPredecessorIndex);
            oXML.WriteProperty("SelectedRowIndex", mp_lSelectedRowIndex);
            oXML.WriteProperty("SelectedTaskIndex", mp_lSelectedTaskIndex);
            oXML.WriteProperty("TreeviewColumnIndex", mp_lTreeviewColumnIndex);
            oXML.WriteProperty("TimeBlockBehaviour", mp_yTimeBlockBehaviour);
            oXML.WriteProperty("TierAppearanceScope", mp_yTierAppearanceScope);
            oXML.WriteProperty("TierFormatScope", mp_yTierFormatScope);
            oXML.WriteProperty("PredecessorMode", mp_yPredecessorMode);
            oXML.WriteProperty("StyleIndex", mp_sStyleIndex);
            oXML.WriteProperty("Image", mp_oImage);
            oXML.WriteProperty("ImageTag", mp_sImageTag);
            oXML.WriteObject(Styles.GetXML());
            oXML.WriteObject(Rows.GetXML());
            oXML.WriteObject(Columns.GetXML());
            oXML.WriteObject(Layers.GetXML());
            oXML.WriteObject(Tasks.GetXML());
            oXML.WriteObject(Predecessors.GetXML());
            oXML.WriteObject(Views.GetXML());
            oXML.WriteObject(TimeBlocks.GetXML());
            oXML.WriteObject(TimeBlocks.CP_GetXML());
            oXML.WriteObject(Percentages.GetXML());
            oXML.WriteObject(Splitter.GetXML());
            oXML.WriteObject(Treeview.GetXML());
            oXML.WriteObject(TierAppearance.GetXML());
            oXML.WriteObject(TierFormat.GetXML());
            oXML.WriteObject(ScrollBarSeparator.GetXML());
            oXML.WriteObject(VerticalScrollBar.GetXML());
            oXML.WriteObject(HorizontalScrollBar.GetXML());
        }

        private void mp_ReadXML(ref clsXML oXML)
        {
            string sVersion = "";
            Clear();
            oXML.InitializeReader();
            oXML.ReadProperty("Version", ref sVersion);
            oXML.ReadProperty("ControlTag", ref mp_sControlTag);
            oXML.ReadProperty("AddMode", ref mp_yAddMode);
            oXML.ReadProperty("AddDurationInterval", ref mp_yAddDurationInterval);
            oXML.ReadProperty("AllowAdd", ref mp_bAllowAdd);
            oXML.ReadProperty("AllowColumnMove", ref mp_bAllowColumnMove);
            oXML.ReadProperty("AllowColumnSize", ref mp_bAllowColumnSize);
            oXML.ReadProperty("AllowEdit", ref mp_bAllowEdit);
            oXML.ReadProperty("AllowPredecessorAdd", ref mp_bAllowPredecessorAdd);
            oXML.ReadProperty("AllowRowMove", ref mp_bAllowRowMove);
            oXML.ReadProperty("AllowRowSize", ref mp_bAllowRowSize);
            oXML.ReadProperty("AllowSplitterMove", ref mp_bAllowSplitterMove);
            oXML.ReadProperty("AllowTimeLineScroll", ref mp_bAllowTimeLineScroll);
            oXML.ReadProperty("EnforcePredecessors", ref mp_bEnforcePredecessors);
            oXML.ReadProperty("CurrentLayer", ref mp_sCurrentLayer);
            oXML.ReadProperty("CurrentView", ref mp_sCurrentView);
            oXML.ReadProperty("DoubleBuffering", ref mp_bDoubleBuffering);
            oXML.ReadProperty("ErrorReports", ref mp_yErrorReports);
            oXML.ReadProperty("LayerEnableObjects", ref mp_yLayerEnableObjects);
            oXML.ReadProperty("MinColumnWidth", ref mp_lMinColumnWidth);
            oXML.ReadProperty("MinRowHeight", ref mp_lMinRowHeight);
            oXML.ReadProperty("ScrollBarBehaviour", ref mp_yScrollBarBehaviour);
            oXML.ReadProperty("SelectedCellIndex", ref mp_lSelectedCellIndex);
            oXML.ReadProperty("SelectedColumnIndex", ref mp_lSelectedColumnIndex);
            oXML.ReadProperty("SelectedPercentageIndex", ref mp_lSelectedPercentageIndex);
            oXML.ReadProperty("SelectedPredecessorIndex", ref mp_lSelectedPredecessorIndex);
            oXML.ReadProperty("SelectedRowIndex", ref mp_lSelectedRowIndex);
            oXML.ReadProperty("SelectedTaskIndex", ref mp_lSelectedTaskIndex);
            oXML.ReadProperty("TreeviewColumnIndex", ref mp_lTreeviewColumnIndex);
            oXML.ReadProperty("TimeBlockBehaviour", ref mp_yTimeBlockBehaviour);
            oXML.ReadProperty("TierAppearanceScope", ref mp_yTierAppearanceScope);
            oXML.ReadProperty("TierFormatScope", ref mp_yTierFormatScope);
            oXML.ReadProperty("PredecessorMode", ref mp_yPredecessorMode);
            oXML.ReadProperty("StyleIndex", ref mp_sStyleIndex);
            oXML.ReadProperty("Image", ref mp_oImage);
            oXML.ReadProperty("ImageTag", ref mp_sImageTag);
            Styles.SetXML(oXML.ReadObject("Styles"));
            Rows.SetXML(oXML.ReadObject("Rows"));
            Columns.SetXML(oXML.ReadObject("Columns"));
            Layers.SetXML(oXML.ReadObject("Layers"));
            Tasks.SetXML(oXML.ReadObject("Tasks"));
            Predecessors.SetXML(oXML.ReadObject("Predecessors"));
            Views.SetXML(oXML.ReadObject("Views"));
            TimeBlocks.SetXML(oXML.ReadObject("TimeBlocks"));
            TimeBlocks.CP_SetXML(oXML.ReadObject("CP_TimeBlocks"));
            Percentages.SetXML(oXML.ReadObject("Percentages"));
            Splitter.SetXML(oXML.ReadObject("Splitter"));
            Treeview.SetXML(oXML.ReadObject("Treeview"));
            TierAppearance.SetXML(oXML.ReadObject("TierAppearance"));
            TierFormat.SetXML(oXML.ReadObject("TierFormat"));
            ScrollBarSeparator.SetXML(oXML.ReadObject("ScrollBarSeparator"));
            VerticalScrollBar.SetXML(oXML.ReadObject("VerticalScrollBar"));
            HorizontalScrollBar.SetXML(oXML.ReadObject("HorizontalScrollBar"));
            StyleIndex = mp_sStyleIndex;
            Rows.UpdateTree();
            CurrentView = mp_sCurrentView;
            mp_oCurrentView.TimeLine.Position(mp_oCurrentView.TimeLine.StartDate);
        }


        internal void mp_ErrorReport(SYS_ERRORS ErrNumber, string ErrDescription, string ErrSource)
        {
            if (mp_yErrorReports == E_REPORTERRORS.RE_MSGBOX)
            {
                MessageBox.Show(ErrNumber + ": " + ErrDescription, ErrSource, MessageBoxButton.OK);
            }
            else if (mp_yErrorReports == E_REPORTERRORS.RE_HIDE)
            {
            }
            else if (mp_yErrorReports == E_REPORTERRORS.RE_RAISE)
            {
                AGError ex = new AGError(ErrNumber.ToString() + ": " + ErrDescription + " - " + ErrSource);
                ex.ErrNumber = (int)ErrNumber;
                ex.ErrDescription = ErrDescription;
                ex.ErrSource = ErrSource;
                throw ex;
            }
            else if (mp_yErrorReports == E_REPORTERRORS.RE_RAISEEVENT)
            {
                ErrorEventArgs.Clear();
                ErrorEventArgs.Number = (int)ErrNumber;
                ErrorEventArgs.Description = ErrDescription;
                ErrorEventArgs.Source = ErrSource;
                FireActiveGanttError();
            }
        }

        public Canvas ControlCanvas
        {
            get { return oCanvas; }
        }

        public E_REPORTERRORS ErrorReports
        {
            get { return mp_yErrorReports; }
            set { mp_yErrorReports = value; }
        }

        public Color SelectionColor
        {
            get { return mp_clrSelectionColor; }
            set { mp_clrSelectionColor = value; }
        }

        public System.Windows.Input.Key PredecessorAddModeKey
        {
            get { return mp_oPredecessorAddModeKey; }
            set { mp_oPredecessorAddModeKey = value; }
        }

        public string CurrentLayer
        {
            get { return mp_sCurrentLayer; }
            set { mp_sCurrentLayer = value; }
        }

        public string CurrentView
        {
            get { return mp_sCurrentView; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = "0";
                }
                mp_oCurrentView = Views.FItem(value);
                mp_sCurrentView = value;
            }
        }

        public clsView CurrentViewObject
        {
            get { return mp_oCurrentView; }
        }

        public E_SCROLLBEHAVIOUR ScrollBarBehaviour
        {
            get { return mp_yScrollBarBehaviour; }
            set { mp_yScrollBarBehaviour = value; }
        }

        public E_TIERAPPEARANCESCOPE TierAppearanceScope
        {
            get { return mp_yTierAppearanceScope; }
            set { mp_yTierAppearanceScope = value; }
        }

        public E_TIERFORMATSCOPE TierFormatScope
        {
            get { return mp_yTierFormatScope; }
            set { mp_yTierFormatScope = value; }
        }

        public E_TIMEBLOCKBEHAVIOUR TimeBlockBehaviour
        {
            get { return mp_yTimeBlockBehaviour; }
            set { mp_yTimeBlockBehaviour = value; }
        }

        public int SelectedTaskIndex
        {
            get { return mp_lSelectedTaskIndex; }
            set
            {
                if (value <= 0)
                {
                    value = 0;
                }
                else if (value > Tasks.Count)
                {
                    value = Tasks.Count;
                }
                mp_lSelectedTaskIndex = value;
            }
        }

        public int SelectedColumnIndex
        {
            get { return mp_lSelectedColumnIndex; }
            set
            {
                if (value <= 0)
                {
                    value = 0;
                }
                else if (value > Columns.Count)
                {
                    value = Columns.Count;
                }
                mp_lSelectedColumnIndex = value;
            }
        }

        public int SelectedRowIndex
        {
            get { return mp_lSelectedRowIndex; }
            set
            {
                if (value <= 0)
                {
                    value = 0;
                }
                else if (value > Rows.Count)
                {
                    value = Rows.Count;
                }
                mp_lSelectedRowIndex = value;
            }
        }

        public int SelectedCellIndex
        {
            get { return mp_lSelectedCellIndex; }
            set
            {
                if (value <= 0)
                {
                    value = 0;
                }
                else if (value > Columns.Count)
                {
                    value = Columns.Count;
                }
                mp_lSelectedCellIndex = value;
            }
        }

        public int SelectedPercentageIndex
        {
            get { return mp_lSelectedPercentageIndex; }
            set
            {
                if (value <= 0)
                {
                    value = 0;
                }
                else if (value > Percentages.Count)
                {
                    value = Percentages.Count;
                }
                mp_lSelectedPercentageIndex = value;
            }
        }

        public int SelectedPredecessorIndex
        {
            get { return mp_lSelectedPredecessorIndex; }
            set
            {
                if (value <= 0)
                {
                    value = 0;
                }
                else if (value > Percentages.Count)
                {
                    value = Percentages.Count;
                }
                mp_lSelectedPredecessorIndex = value;
            }
        }

        public int TreeviewColumnIndex
        {
            get
            {
                if (Columns.Count == 0)
                {
                    return 0;
                }
                else if (mp_lTreeviewColumnIndex > Columns.Count)
                {
                    return 0;
                }
                else if (mp_lTreeviewColumnIndex < 0)
                {
                    return 0;
                }
                else
                {
                    return mp_lTreeviewColumnIndex;
                }
            }
            set
            {
                if (value <= 0)
                {
                    value = 0;
                }
                else if (value > Columns.Count)
                {
                    value = Columns.Count;
                }
                mp_lTreeviewColumnIndex = value;
            }
        }

        public string StyleIndex
        {
            get
            {
                if (mp_sStyleIndex == "DS_CONTROL")
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
                if (value.Length == 0)
                    value = "DS_CONTROL";
                mp_sStyleIndex = value;
                mp_oStyle = Styles.FItem(value);
            }
        }

        public new clsStyle Style
        {
            get { return mp_oStyle; }
        }

        public Image Image
        {
            get { return mp_oImage; }
            set { mp_oImage = value; }
        }

        public string ImageTag
        {
            get { return mp_sImageTag; }
            set { mp_sImageTag = value; }
        }

        public System.Globalization.CultureInfo Culture
        {
            get { return mp_oCulture; }
            set { mp_oCulture = value; }
        }

        public void ClearSelections()
        {
            mp_oTextBox.Terminate();
            mp_lSelectedTaskIndex = 0;
            mp_lSelectedColumnIndex = 0;
            mp_lSelectedRowIndex = 0;
            mp_lSelectedCellIndex = 0;
            mp_lSelectedPercentageIndex = 0;
            mp_lSelectedPredecessorIndex = 0;
        }

        public void Clear()
        {
            mp_oTextBox.Terminate();
            Tasks.Clear();
            Rows.Clear();
            Styles.Clear();
            Layers.Clear();
            Columns.Clear();
            TimeBlocks.Clear();
            Views.Clear();
        }

        public void CheckPredecessors()
        {
            int i = 0;
            clsTask oTask;
            for (i = 1; i <= Tasks.Count; i++)
            {
                oTask = (clsTask)Tasks.oCollection.m_oReturnArrayElement(i);
                oTask.mp_bWarning = false;
            }
            if (Predecessors.Count == 0)
            {
                return;
            }
            clsPredecessor oPredecessor;
            for (i = 1; i <= Predecessors.Count; i++)
            {
                oPredecessor = (clsPredecessor)Predecessors.oCollection.m_oReturnArrayElement(i);
                oPredecessor.Check(mp_yPredecessorMode);
            }
        }

        public bool EnforcePredecessors
        {
            get { return mp_bEnforcePredecessors; }
            set { mp_bEnforcePredecessors = value; }
        }

        public E_PREDECESSORMODE PredecessorMode
        {
            get { return mp_yPredecessorMode; }
            set { mp_yPredecessorMode = value; }
        }


        public void ForceEndTextEdit()
        {
            mp_oTextBox.Terminate();
        }
        public string ModuleCompletePath
        {
            get { return System.Reflection.Assembly.GetExecutingAssembly().Location; }
        }

        public string Version
        {
            get
            {
                System.Reflection.Assembly ai = System.Reflection.Assembly.GetExecutingAssembly();
                System.Reflection.AssemblyName oAssemblyName = new System.Reflection.AssemblyName(ai.FullName);
                return oAssemblyName.Version.ToString();
            }
        }

        public void AboutBox()
        {
            //Dim oForm As New fAbout()
            //oForm.ShowDialog(Me)
        }

        //Public Sub SaveToImage(ByVal Path As String, ByVal Format As Imaging.ImageFormat)
        //    Dim oBitmap As Bitmap
        //    oBitmap = New Bitmap(clsG.Width, clsG.Height)
        //    mp_oGraphics = Graphics.FromImage(oBitmap)
        //    mp_Draw()
        //    oBitmap.Save(Path, Format)
        //End Sub

        public bool AllowSplitterMove
        {
            get { return mp_bAllowSplitterMove; }
            set { mp_bAllowSplitterMove = value; }
        }

        public bool AllowPredecessorAdd
        {
            get { return mp_bAllowPredecessorAdd; }
            set { mp_bAllowPredecessorAdd = value; }
        }

        public bool AllowAdd
        {
            get { return mp_bAllowAdd; }
            set { mp_bAllowAdd = value; }
        }

        public bool AllowEdit
        {
            get { return mp_bAllowEdit; }
            set { mp_bAllowEdit = value; }
        }

        public bool AllowColumnSize
        {
            get { return mp_bAllowColumnSize; }
            set { mp_bAllowColumnSize = value; }
        }

        public bool AllowRowSize
        {
            get { return mp_bAllowRowSize; }
            set { mp_bAllowRowSize = value; }
        }

        public bool AllowRowMove
        {
            get { return mp_bAllowRowMove; }
            set { mp_bAllowRowMove = value; }
        }

        public bool AllowColumnMove
        {
            get { return mp_bAllowColumnMove; }
            set { mp_bAllowColumnMove = value; }
        }

        public bool AllowTimeLineScroll
        {
            get { return mp_bAllowTimeLineScroll; }
            set { mp_bAllowTimeLineScroll = value; }
        }

        public E_ADDMODE AddMode
        {
            get { return mp_yAddMode; }
            set { mp_yAddMode = value; }
        }

        public E_INTERVAL AddDurationInterval
        {
            get { return mp_yAddDurationInterval; }
            set
            {
                if (!(value == E_INTERVAL.IL_SECOND | value == E_INTERVAL.IL_MINUTE | value == E_INTERVAL.IL_HOUR | value == E_INTERVAL.IL_DAY))
                {
                    mp_ErrorReport(SYS_ERRORS.INVALID_DURATION_INTERVAL, "Interval is invalid for a duration", "ActiveGanttCSECtl.Set_AddDurationInterval");
                    return;
                }
                mp_yAddDurationInterval = value;
            }
        }

        public E_LAYEROBJECTENABLE LayerEnableObjects
        {
            get { return mp_yLayerEnableObjects; }
            set { mp_yLayerEnableObjects = value; }
        }

        public bool DoubleBuffering
        {
            get { return mp_bDoubleBuffering; }
            set { mp_bDoubleBuffering = value; }
        }

        public int MinRowHeight
        {
            get { return mp_lMinRowHeight; }
            set { mp_lMinRowHeight = value; }
        }

        public int MinColumnWidth
        {
            get { return mp_lMinColumnWidth; }
            set { mp_lMinColumnWidth = value; }
        }

        public string ControlTag
        {
            get { return mp_sControlTag; }
            set { mp_sControlTag = value; }
        }

        //Friend Function ShowAbout() As Boolean
        //    'Dim oKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("Licenses\BF5980F3-B7A2-4fcf-9E12-575D378FDFA7")
        //    'If Not oKey Is Nothing Then
        //    '    Dim sDefault As String = CType(oKey.GetValue(""), String)
        //    '    If Not sDefault Is Nothing Then
        //    '        If String.Compare("15EFB0FA-E747-46ed-993F-D76EFF641B02", sDefault, False) = 0 Then
        //    '            Return False
        //    '        End If
        //    '    End If
        //    'End If
        //    'Return True
        //End Function

        //Private Sub oImage_MouseLeftButtonDown(sender As Object, e As System.Windows.Input.MouseButtonEventArgs) Handles oImage.MouseLeftButtonDown
        //    Redraw()
        //End Sub

        private void mp_CHKPXPStart(Color clrBackground)
        {
            clsG.Clear(clrBackground);
        }

        private void mp_CHKPXPScrollButtons()
        {
            mp_CHKPXPStart(Colors.Red);
            clsG.DrawScrollButton(20, 20, 17, 17, E_SCROLLBUTTON.SB_UP, E_SCROLLBUTTONSTATE.BS_NORMAL);
            clsG.DrawScrollButton(40, 20, 17, 17, E_SCROLLBUTTON.SB_UP, E_SCROLLBUTTONSTATE.BS_PUSHED);
            clsG.DrawScrollButton(60, 20, 17, 17, E_SCROLLBUTTON.SB_UP, E_SCROLLBUTTONSTATE.BS_INACTIVE);

            clsG.DrawScrollButton(20, 40, 17, 17, E_SCROLLBUTTON.SB_DOWN, E_SCROLLBUTTONSTATE.BS_NORMAL);
            clsG.DrawScrollButton(40, 40, 17, 17, E_SCROLLBUTTON.SB_DOWN, E_SCROLLBUTTONSTATE.BS_PUSHED);
            clsG.DrawScrollButton(60, 40, 17, 17, E_SCROLLBUTTON.SB_DOWN, E_SCROLLBUTTONSTATE.BS_INACTIVE);

            clsG.DrawScrollButton(20, 60, 17, 17, E_SCROLLBUTTON.SB_LEFT, E_SCROLLBUTTONSTATE.BS_NORMAL);
            clsG.DrawScrollButton(40, 60, 17, 17, E_SCROLLBUTTON.SB_LEFT, E_SCROLLBUTTONSTATE.BS_PUSHED);
            clsG.DrawScrollButton(60, 60, 17, 17, E_SCROLLBUTTON.SB_LEFT, E_SCROLLBUTTONSTATE.BS_INACTIVE);

            clsG.DrawScrollButton(20, 80, 17, 17, E_SCROLLBUTTON.SB_RIGHT, E_SCROLLBUTTONSTATE.BS_NORMAL);
            clsG.DrawScrollButton(40, 80, 17, 17, E_SCROLLBUTTON.SB_RIGHT, E_SCROLLBUTTONSTATE.BS_PUSHED);
            clsG.DrawScrollButton(60, 80, 17, 17, E_SCROLLBUTTON.SB_RIGHT, E_SCROLLBUTTONSTATE.BS_INACTIVE);
        }

        private void mp_CHKPXPLines()
        {
            mp_CHKPXPStart(Colors.White);
            clsG.DrawLine(20, 10, 60, 10, GRE_LINETYPE.LT_NORMAL, Colors.Black, GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.DrawLine(30, 20, 30, 70, GRE_LINETYPE.LT_NORMAL, Colors.Black, GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.DrawLine(40, 40, 60, 60, GRE_LINETYPE.LT_BORDER, Colors.Black, GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.DrawLine(70, 70, 90, 90, GRE_LINETYPE.LT_FILLED, Colors.Black, GRE_LINEDRAWSTYLE.LDS_SOLID);

            clsG.DrawLine(40, 100, 90, 150, GRE_LINETYPE.LT_FILLED, Colors.Green, GRE_LINEDRAWSTYLE.LDS_SOLID);

            clsG.DrawLine(100, 100, 150, 150, GRE_LINETYPE.LT_FILLED, Colors.Green, GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.DrawLine(100, 100, 150, 150, GRE_LINETYPE.LT_BORDER, Colors.Red, GRE_LINEDRAWSTYLE.LDS_SOLID);

            clsG.DrawLine(150, 100, 200, 150, GRE_LINETYPE.LT_FILLED, Colors.Green, GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.DrawLine(150, 100, 200, 150, GRE_LINETYPE.LT_BORDER, Colors.Red, GRE_LINEDRAWSTYLE.LDS_SOLID);

            clsG.DrawLine(200, 100, 250, 150, GRE_LINETYPE.LT_FILLED, Colors.Green, GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.DrawLine(200, 100, 250, 150, GRE_LINETYPE.LT_BORDER, Colors.Red, GRE_LINEDRAWSTYLE.LDS_SOLID);

            clsG.DrawLine(200, 150, 250, 200, GRE_LINETYPE.LT_FILLED, Colors.Green, GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.DrawLine(200, 150, 250, 200, GRE_LINETYPE.LT_BORDER, Colors.Red, GRE_LINEDRAWSTYLE.LDS_SOLID);

            ////Clip
            clsG.ClipRegion(200, 10, 250, 60, false);

            clsG.DrawLine(190, 0, 260, 70, GRE_LINETYPE.LT_FILLED, Colors.Black, GRE_LINEDRAWSTYLE.LDS_SOLID);

            clsG.DrawLine(200, 10, 250, 60, GRE_LINETYPE.LT_FILLED, Colors.Green, GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.DrawLine(200, 10, 250, 60, GRE_LINETYPE.LT_BORDER, Colors.Red, GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.ClearClipRegion();

            clsG.DrawLine(100, 160, 150, 210, GRE_LINETYPE.LT_FILLED, Colors.Green, GRE_LINEDRAWSTYLE.LDS_SOLID);
        }

        private void mp_CHKPXPButtons()
        {
            mp_CHKPXPStart(Colors.Red);
            clsG.DrawButton(new Rect(20, 20, 100, 50), E_SCROLLBUTTONSTATE.BS_NORMAL);
            //clsG.mp_DrawItem(50, 50, 100, 100, "", "", False, Nothing, 100, 100, Styles.FItem("DS_TICKMARKAREA"))
        }

        private void mp_CHKPXPArrows()
        {
            mp_CHKPXPStart(Colors.White);
            clsG.mp_DrawArrow(100, 120, GRE_ARROWDIRECTION.AWD_RIGHT, 20, Colors.Black);
            clsG.mp_DrawArrow(50, 120, GRE_ARROWDIRECTION.AWD_LEFT, 20, Colors.Black);
            clsG.mp_DrawArrow(100, 150, GRE_ARROWDIRECTION.AWD_UP, 20, Colors.Black);
            clsG.mp_DrawArrow(50, 170, GRE_ARROWDIRECTION.AWD_DOWN, 20, Colors.Black);
        }

        private void mp_CHKPXPFigures()
        {
            mp_CHKPXPStart(Colors.White);
            clsG.DrawFigure(200, 20, 20, 20, GRE_FIGURETYPE.FT_ARROWDOWN, Colors.Blue, Colors.Black, GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.DrawFigure(230, 20, 20, 20, GRE_FIGURETYPE.FT_ARROWUP, Colors.Blue, Colors.Black, GRE_LINEDRAWSTYLE.LDS_SOLID);

            clsG.DrawFigure(200, 60, 20, 20, GRE_FIGURETYPE.FT_CIRCLEARROWDOWN, Colors.Blue, Colors.Black, GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.DrawFigure(230, 60, 20, 20, GRE_FIGURETYPE.FT_CIRCLEARROWUP, Colors.Blue, Colors.Black, GRE_LINEDRAWSTYLE.LDS_SOLID);

            clsG.DrawFigure(200, 100, 20, 20, GRE_FIGURETYPE.FT_CIRCLETRIANGLEDOWN, Colors.Blue, Colors.Black, GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.DrawFigure(230, 100, 20, 20, GRE_FIGURETYPE.FT_CIRCLETRIANGLEUP, Colors.Blue, Colors.Black, GRE_LINEDRAWSTYLE.LDS_SOLID);

            clsG.DrawFigure(200, 140, 20, 20, GRE_FIGURETYPE.FT_PROJECTDOWN, Colors.Blue, Colors.Black, GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.DrawFigure(230, 140, 20, 20, GRE_FIGURETYPE.FT_PROJECTUP, Colors.Blue, Colors.Black, GRE_LINEDRAWSTYLE.LDS_SOLID);

            clsG.DrawFigure(200, 180, 20, 20, GRE_FIGURETYPE.FT_SMALLPROJECTDOWN, Colors.Blue, Colors.Black, GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.DrawFigure(230, 180, 20, 20, GRE_FIGURETYPE.FT_SMALLPROJECTUP, Colors.Blue, Colors.Black, GRE_LINEDRAWSTYLE.LDS_SOLID);

            clsG.DrawFigure(200, 220, 20, 20, GRE_FIGURETYPE.FT_TRIANGLEDOWN, Colors.Blue, Colors.Black, GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.DrawFigure(230, 220, 20, 20, GRE_FIGURETYPE.FT_TRIANGLEUP, Colors.Blue, Colors.Black, GRE_LINEDRAWSTYLE.LDS_SOLID);

            clsG.DrawFigure(200, 260, 20, 20, GRE_FIGURETYPE.FT_TRIANGLELEFT, Colors.Blue, Colors.Black, GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.DrawFigure(230, 260, 20, 20, GRE_FIGURETYPE.FT_TRIANGLERIGHT, Colors.Blue, Colors.Black, GRE_LINEDRAWSTYLE.LDS_SOLID);

            clsG.DrawFigure(200, 300, 20, 20, GRE_FIGURETYPE.FT_SQUARE, Colors.Blue, Colors.Black, GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.DrawFigure(230, 300, 20, 20, GRE_FIGURETYPE.FT_CIRCLE, Colors.Blue, Colors.Black, GRE_LINEDRAWSTYLE.LDS_SOLID);

            clsG.DrawFigure(200, 340, 20, 20, GRE_FIGURETYPE.FT_DIAMOND, Colors.Blue, Colors.Black, GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.DrawFigure(230, 340, 20, 20, GRE_FIGURETYPE.FT_RECTANGLE, Colors.Blue, Colors.Black, GRE_LINEDRAWSTYLE.LDS_SOLID);

            clsG.DrawFigure(200, 380, 20, 20, GRE_FIGURETYPE.FT_NONE, Colors.Blue, Colors.Black, GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.DrawFigure(230, 380, 20, 20, GRE_FIGURETYPE.FT_NONE, Colors.Blue, Colors.Black, GRE_LINEDRAWSTYLE.LDS_SOLID);
        }

        private void mp_CHKPXPGradients()
        {
            mp_CHKPXPStart(Colors.White);
            clsG.GradientFill(20, 250, 120, 320, Colors.Black, Colors.Blue, GRE_GRADIENTFILLMODE.GDT_HORIZONTAL);
            clsG.GradientFill(20, 340, 120, 400, Colors.Black, Colors.Blue, GRE_GRADIENTFILLMODE.GDT_VERTICAL);
        }

        private void mp_CHKPXPText()
        {
            mp_CHKPXPStart(Colors.Red);
            clsTextFlags oFlags = new clsTextFlags(this);
            oFlags.HorizontalAlignment = GRE_HORIZONTALALIGNMENT.HAL_RIGHT;
            oFlags.VerticalAlignment = GRE_VERTICALALIGNMENT.VAL_BOTTOM;

            //'clsG.DrawTextEx(300, 100, 400, 400, "M Hello World", oFlags, Colors.Black, New Font("Arial", 10), True)
            clsG.DrawLine(200, 100, 400, 300, GRE_LINETYPE.LT_BORDER, Colors.Black, GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.DrawTextEx(200, 100, 400, 300, "M Hello World", oFlags, Colors.Black, new Font("Arial",  13, E_FONTSIZEUNITS.FSU_POINTS), true);

        }

        private void mp_CHKPXPHatch()
        {
            System.Random rnd = null;
            rnd = new Random();
            Color oColor = new Color();
            oColor.A = 255;
            oColor.R = (byte)rnd.Next(1, 255);
            oColor.G = (byte)rnd.Next(1, 255);
            oColor.B = (byte)rnd.Next(1, 255);

            mp_CHKPXPStart(oColor);
            clsG.HatchFill(600, 400, 756, 556, Colors.Black, Colors.White, GRE_HATCHSTYLE.HS_VERTICAL);
            int i = 0;
            int j = 0;
            j = 0;
            for (i = 0; i <= 9; i++)
            {
                clsG.HatchFill(0, j * 30, 100, (j * 30) + 20, Colors.Black, Colors.White, (GRE_HATCHSTYLE)i);
                j = j + 1;
            }
            j = 0;
            for (i = 10; i <= 19; i++)
            {
                clsG.HatchFill(120, j * 30, 220, (j * 30) + 20, Colors.Black, Colors.White, (GRE_HATCHSTYLE)i);
                j = j + 1;
            }

            j = 0;
            for (i = 20; i <= 29; i++)
            {
                clsG.HatchFill(240, j * 30, 340, (j * 30) + 20, Colors.Black, Colors.White, (GRE_HATCHSTYLE)i);
                j = j + 1;
            }
            j = 0;
            for (i = 30; i <= 39; i++)
            {
                clsG.HatchFill(360, j * 30, 460, (j * 30) + 20, Colors.Black, Colors.White, (GRE_HATCHSTYLE)i);
                j = j + 1;
            }
            j = 0;
            for (i = 40; i <= 49; i++)
            {
                clsG.HatchFill(480, j * 30, 580, (j * 30) + 20, Colors.Black, Colors.White, (GRE_HATCHSTYLE)i);
                j = j + 1;
            }
            j = 0;
            for (i = 50; i <= 52; i++)
            {
                clsG.HatchFill(600, j * 30, 700, (j * 30) + 20, Colors.Black, Colors.White, (GRE_HATCHSTYLE)i);
                j = j + 1;
            }
        }

    }



    public class AGError : Exception
    {
        private string mp_sErrDescription;
        private int mp_lErrNumber;
        private string mp_sErrSource;

        public AGError() : base() { }
        public AGError(string s) : base(s) { }
        public AGError(string s, Exception ex) : base(s, ex) { }

        public string ErrDescription
        {
            get
            {
                return mp_sErrDescription;
            }
            set
            {
                mp_sErrDescription = value;
            }
        }

        public int ErrNumber
        {
            get
            {
                return mp_lErrNumber;
            }
            set
            {
                mp_lErrNumber = value;
            }
        }

        public string ErrSource
        {
            get
            {
                return mp_sErrSource;
            }
            set
            {
                mp_sErrSource = value;
            }
        }
    }





}
