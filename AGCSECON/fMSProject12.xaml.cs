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
using System.Windows.Navigation;
using AGCSECON.Web;
using System.ServiceModel.DomainServices.Client;
using AGCSE;

namespace AGCSECON
{
    public partial class fMSProject12 : Page
    {
        private MSP2007Context oServiceContext = new MSP2007Context();
        private InvokeOperation<string> invkGetXML;
        private InvokeOperation<string> invkGetFileList;
        private List<CON_File> mp_oFileList;

        private fLoad mp_fLoad;
        private const string mp_sFontName = "Tahoma";

        private MSP2007.MP12 oMP12;

        #region "Constructors"

        public fMSProject12()
        {
            InitializeComponent();
        }

        #endregion

        #region "Page Loaded"

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            invkGetFileList = oServiceContext.GetFileList();
            invkGetFileList.Completed += invkGetFileList_Completed;
            mp_fLoad = new fLoad();
            mp_fLoad.Closed += mp_fLoad_Closed;

            this.Title = "The Source Code Store - ActiveGantt Scheduler Control Version " + ActiveGanttCSECtl1.Version + " - Microsoft Project 2007 integration using XML Files and the MSP2007 Integration Library";
            InitializeAG();
            ActiveGanttCSECtl1.Redraw();
        }

        private void invkGetFileList_Completed(object sender, System.EventArgs e)
        {
            string sFileList = invkGetFileList.Value;
            if (sFileList.Length > 0)
            {
                string[] aFileList = null;
                int i = 0;
                aFileList = sFileList.Split(System.Convert.ToChar("|"));
                mp_oFileList = new List<CON_File>();
                for (i = 0; i <= aFileList.Length - 1; i++)
                {
                    CON_File oFile = new CON_File();
                    oFile.sDescription = aFileList[i];
                    oFile.sFileName = aFileList[i];
                    mp_oFileList.Add(oFile);
                }
            }
        }

        #endregion

        #region "ActiveGantt Event Handlers"

        private void ActiveGanttCSECtl1_CustomTierDraw(object sender, CustomTierDrawEventArgs e)
        {
            if (e.TierPosition == E_TIERPOSITION.SP_UPPER)
            {
                e.StyleIndex = "TimeLineTiers";
                if (System.Convert.ToInt32(ActiveGanttCSECtl1.CurrentView) <= 4)
                {
                    e.Text = e.StartDate.Year().ToString() + " Q" + e.StartDate.Quarter().ToString();
                }
                else
                {
                    e.Text = e.StartDate.ToString("MMMM, yyyy");
                }
            }
            else if (e.TierPosition == E_TIERPOSITION.SP_LOWER)
            {
                e.StyleIndex = "TimeLineTiers";
                if (System.Convert.ToInt32(ActiveGanttCSECtl1.CurrentView) <= 4)
                {
                    e.Text = e.StartDate.ToString("MMM");
                }
                else
                {
                    e.Text = e.StartDate.ToString("ddd");
                }
            }
        }

        #endregion

        #region "Functions"

        private void InitializeAG()
        {
            clsStyle oStyle = null;
            clsView oView = null;

            oStyle = ActiveGanttCSECtl1.Styles.Add("ScrollBar");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = Color.FromArgb(255, 122, 151, 193);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = Color.FromArgb(255, 139, 144, 150);

            oStyle = ActiveGanttCSECtl1.Styles.Add("ArrowButtons");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = Color.FromArgb(255, 122, 151, 193);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = Color.FromArgb(255, 150, 158, 168);

            oStyle = ActiveGanttCSECtl1.Styles.Add("ThumbButtonH");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
            oStyle.StartGradientColor = Color.FromArgb(255, 240, 240, 240);
            oStyle.EndGradientColor = Color.FromArgb(255, 165, 186, 207);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = Color.FromArgb(255, 138, 145, 153);

            oStyle = ActiveGanttCSECtl1.Styles.Add("ThumbButtonV");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_HORIZONTAL;
            oStyle.StartGradientColor = Color.FromArgb(255, 240, 240, 240);
            oStyle.EndGradientColor = Color.FromArgb(255, 165, 186, 207);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = Color.FromArgb(255, 138, 145, 153);

            oStyle = ActiveGanttCSECtl1.Styles.Add("TimeLineTiers");
            oStyle.Font = new Font(mp_sFontName, 7, E_FONTSIZEUNITS.FSU_POINTS);
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_TRANSPARENT;
            oStyle.CustomBorderStyle.Left = true;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Right = false;
            oStyle.CustomBorderStyle.Bottom = true;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.BorderColor = Color.FromArgb(255, 197, 206, 216);

            oStyle = ActiveGanttCSECtl1.Styles.Add("TimeLine");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.StartGradientColor = Color.FromArgb(255, 179, 206, 235);
            oStyle.EndGradientColor = Color.FromArgb(255, 161, 193, 232);
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
            oStyle.BackColor = Colors.White;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_NONE;

            oStyle = ActiveGanttCSECtl1.Styles.Add("ColumnStyle");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.StartGradientColor = Color.FromArgb(255, 179, 206, 235);
            oStyle.EndGradientColor = Color.FromArgb(255, 161, 193, 232);
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
            oStyle.BackColor = Colors.White;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.CustomBorderStyle.Left = false;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Right = true;
            oStyle.CustomBorderStyle.Bottom = true;
            oStyle.BorderColor = Color.FromArgb(255, 197, 206, 216);

            oStyle = ActiveGanttCSECtl1.Styles.Add("TaskStyle");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.StartGradientColor = Color.FromArgb(255, 240, 240, 240);
            oStyle.EndGradientColor = Color.FromArgb(255, 0, 0, 255);
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = Color.FromArgb(255, 148, 152, 179);
            oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT;
            oStyle.SelectionRectangleStyle.OffsetTop = 0;
            oStyle.SelectionRectangleStyle.OffsetLeft = 0;
            oStyle.SelectionRectangleStyle.OffsetRight = 0;
            oStyle.SelectionRectangleStyle.OffsetBottom = 0;
            oStyle.TextPlacement = E_TEXTPLACEMENT.SCP_EXTERIORPLACEMENT;
            oStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_RIGHT;
            oStyle.TextXMargin = 10;
            oStyle.OffsetTop = 5;
            oStyle.OffsetBottom = 10;
            oStyle.PredecessorStyle.LineColor = Colors.Black;
            oStyle.MilestoneStyle.ShapeIndex = GRE_FIGURETYPE.FT_DIAMOND;
            oStyle.MilestoneStyle.FillColor = Colors.Blue;
            oStyle.MilestoneStyle.BorderColor = Colors.Blue;
            oStyle.PredecessorStyle.XOffset = 4;
            oStyle.PredecessorStyle.YOffset = 4;

            oStyle = ActiveGanttCSECtl1.Styles.Add("SummaryStyle");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.StartGradientColor = Color.FromArgb(255, 0, 0, 0);
            oStyle.EndGradientColor = Color.FromArgb(255, 240, 240, 240);
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
            oStyle.BackColor = Colors.Black;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = Colors.Black;
            oStyle.FillMode = GRE_FILLMODE.FM_UPPERHALFFILLED;
            oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT;
            oStyle.OffsetTop = 5;
            oStyle.OffsetBottom = 10;
            oStyle.SelectionRectangleStyle.OffsetTop = 0;
            oStyle.SelectionRectangleStyle.OffsetLeft = 0;
            oStyle.SelectionRectangleStyle.OffsetRight = 0;
            oStyle.SelectionRectangleStyle.OffsetBottom = 0;
            oStyle.TextPlacement = E_TEXTPLACEMENT.SCP_EXTERIORPLACEMENT;
            oStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_RIGHT;
            oStyle.TextXMargin = 10;
            oStyle.PredecessorStyle.LineColor = Colors.Black;
            oStyle.TaskStyle.StartShapeIndex = GRE_FIGURETYPE.FT_PROJECTDOWN;
            oStyle.TaskStyle.EndShapeIndex = GRE_FIGURETYPE.FT_PROJECTDOWN;

            oStyle = ActiveGanttCSECtl1.Styles.Add("NodeStyle");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackColor = Colors.White;
            oStyle.BorderColor = Color.FromArgb(255, 197, 206, 216);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Left = false;

            oStyle = ActiveGanttCSECtl1.Styles.Add("CellStyleKeyColumn");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackColor = Colors.White;
            oStyle.BorderColor = Color.FromArgb(255, 197, 206, 216);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Left = false;
            oStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_RIGHT;
            oStyle.TextXMargin = 4;

            oStyle = ActiveGanttCSECtl1.Styles.Add("ClientAreaStyle");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackColor = Colors.White;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_NONE;

            ActiveGanttCSECtl1.AllowRowMove = true;
            ActiveGanttCSECtl1.AllowRowSize = true;
            ActiveGanttCSECtl1.AllowAdd = false;
            ActiveGanttCSECtl1.Style.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            ActiveGanttCSECtl1.Style.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            ActiveGanttCSECtl1.Style.BorderColor = Color.FromArgb(255, 122, 151, 193);
            ActiveGanttCSECtl1.Style.BorderWidth = 1;

            ActiveGanttCSECtl1.Splitter.Type = E_SPLITTERTYPE.SA_USERDEFINED;
            ActiveGanttCSECtl1.Splitter.Width = 4;
            ActiveGanttCSECtl1.Splitter.SetColor(1, Color.FromArgb(255, 197, 206, 216));
            ActiveGanttCSECtl1.Splitter.SetColor(2, Colors.White);
            ActiveGanttCSECtl1.Splitter.SetColor(3, Colors.White);
            ActiveGanttCSECtl1.Splitter.SetColor(4, Color.FromArgb(255, 197, 206, 216));
            ActiveGanttCSECtl1.Splitter.Position = 255;

            ActiveGanttCSECtl1.Treeview.Images = true;
            ActiveGanttCSECtl1.Treeview.CheckBoxes = true;
            ActiveGanttCSECtl1.Treeview.FullColumnSelect = true;
            ActiveGanttCSECtl1.Treeview.TreeLines = false;

            clsColumn oColumn;

            oColumn = ActiveGanttCSECtl1.Columns.Add("ID", "", 30, "");
            oColumn.StyleIndex = "ColumnStyle";
            oColumn.AllowTextEdit = true;

            oColumn = ActiveGanttCSECtl1.Columns.Add("Task Name", "", 300, "");
            oColumn.StyleIndex = "ColumnStyle";
            oColumn.AllowTextEdit = true;

            ActiveGanttCSECtl1.TreeviewColumnIndex = 2;
            ActiveGanttCSECtl1.Splitter.Position = 330;

            ActiveGanttCSECtl1.ScrollBarSeparator.Style.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            ActiveGanttCSECtl1.ScrollBarSeparator.Style.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            ActiveGanttCSECtl1.ScrollBarSeparator.Style.BackColor = Color.FromArgb(255, 164, 196, 237);

            ActiveGanttCSECtl1.VerticalScrollBar.ScrollBar.TimerInterval = 50;
            ActiveGanttCSECtl1.VerticalScrollBar.ScrollBar.StyleIndex = "ScrollBar";
            ActiveGanttCSECtl1.VerticalScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "ArrowButtons";
            ActiveGanttCSECtl1.VerticalScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "ArrowButtons";
            ActiveGanttCSECtl1.VerticalScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "ArrowButtons";
            ActiveGanttCSECtl1.VerticalScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "ThumbButtonV";
            ActiveGanttCSECtl1.VerticalScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "ThumbButtonV";
            ActiveGanttCSECtl1.VerticalScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "ThumbButtonV";

            ActiveGanttCSECtl1.HorizontalScrollBar.ScrollBar.StyleIndex = "ScrollBar";
            ActiveGanttCSECtl1.HorizontalScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "ArrowButtons";
            ActiveGanttCSECtl1.HorizontalScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "ArrowButtons";
            ActiveGanttCSECtl1.HorizontalScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "ArrowButtons";
            ActiveGanttCSECtl1.HorizontalScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "ThumbButtonH";
            ActiveGanttCSECtl1.HorizontalScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "ThumbButtonH";
            ActiveGanttCSECtl1.HorizontalScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "ThumbButtonH";

            oView = ActiveGanttCSECtl1.Views.Add(E_INTERVAL.IL_HOUR, 24, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM, "");
            oView.TimeLine.TierArea.UpperTier.Interval = E_INTERVAL.IL_QUARTER;
            oView.TimeLine.TierArea.UpperTier.Factor = 1;
            oView.TimeLine.TierArea.UpperTier.Height = 17;
            oView.TimeLine.TierArea.MiddleTier.Visible = false;
            oView.TimeLine.TierArea.LowerTier.Interval = E_INTERVAL.IL_MONTH;
            oView.TimeLine.TierArea.LowerTier.Factor = 1;
            oView.TimeLine.TierArea.LowerTier.Height = 17;
            oView.TimeLine.TickMarkArea.Visible = false;
            oView.TimeLine.TimeLineScrollBar.StartDate = AGCSE.DateTime.Now;
            oView.TimeLine.TimeLineScrollBar.Enabled = true;
            oView.TimeLine.TimeLineScrollBar.Visible = false;
            oView.TimeLine.TimeLineScrollBar.ScrollBar.StyleIndex = "ScrollBar";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "ArrowButtons";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "ArrowButtons";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "ArrowButtons";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "ThumbButtonH";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "ThumbButtonH";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "ThumbButtonH";
            oView.TimeLine.StyleIndex = "TimeLine";
            oView.ClientArea.DetectConflicts = false;
            oView.ClientArea.Grid.Color = Color.FromArgb(255, 197, 206, 216);

            oView = ActiveGanttCSECtl1.Views.Add(E_INTERVAL.IL_HOUR, 12, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM, "");
            oView.TimeLine.TierArea.UpperTier.Interval = E_INTERVAL.IL_QUARTER;
            oView.TimeLine.TierArea.UpperTier.Factor = 1;
            oView.TimeLine.TierArea.UpperTier.Height = 17;
            oView.TimeLine.TierArea.MiddleTier.Visible = false;
            oView.TimeLine.TierArea.LowerTier.Interval = E_INTERVAL.IL_MONTH;
            oView.TimeLine.TierArea.LowerTier.Factor = 1;
            oView.TimeLine.TierArea.LowerTier.Height = 17;
            oView.TimeLine.TickMarkArea.Visible = false;
            oView.TimeLine.TimeLineScrollBar.StartDate = AGCSE.DateTime.Now;
            oView.TimeLine.TimeLineScrollBar.Interval = E_INTERVAL.IL_HOUR;
            oView.TimeLine.TimeLineScrollBar.Factor = 1;
            oView.TimeLine.TimeLineScrollBar.SmallChange = 12;
            oView.TimeLine.TimeLineScrollBar.LargeChange = 240;
            oView.TimeLine.TimeLineScrollBar.Max = 2000;
            oView.TimeLine.TimeLineScrollBar.Value = 0;
            oView.TimeLine.TimeLineScrollBar.Enabled = true;
            oView.TimeLine.TimeLineScrollBar.Visible = true;
            oView.TimeLine.TimeLineScrollBar.ScrollBar.StyleIndex = "ScrollBar";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "ArrowButtons";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "ArrowButtons";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "ArrowButtons";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "ThumbButtonH";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "ThumbButtonH";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "ThumbButtonH";
            oView.TimeLine.StyleIndex = "TimeLine";
            oView.ClientArea.DetectConflicts = false;
            oView.ClientArea.Grid.Color = Color.FromArgb(255, 197, 206, 216);

            oView = ActiveGanttCSECtl1.Views.Add(E_INTERVAL.IL_HOUR, 6, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM, "");
            oView.TimeLine.TierArea.UpperTier.Interval = E_INTERVAL.IL_QUARTER;
            oView.TimeLine.TierArea.UpperTier.Factor = 1;
            oView.TimeLine.TierArea.UpperTier.Height = 17;
            oView.TimeLine.TierArea.MiddleTier.Visible = false;
            oView.TimeLine.TierArea.LowerTier.Interval = E_INTERVAL.IL_MONTH;
            oView.TimeLine.TierArea.LowerTier.Factor = 1;
            oView.TimeLine.TierArea.LowerTier.Height = 17;
            oView.TimeLine.TickMarkArea.Visible = false;
            oView.TimeLine.TimeLineScrollBar.StartDate = AGCSE.DateTime.Now;
            oView.TimeLine.TimeLineScrollBar.Interval = E_INTERVAL.IL_HOUR;
            oView.TimeLine.TimeLineScrollBar.Factor = 1;
            oView.TimeLine.TimeLineScrollBar.SmallChange = 6;
            oView.TimeLine.TimeLineScrollBar.LargeChange = 480;
            oView.TimeLine.TimeLineScrollBar.Max = 4000;
            oView.TimeLine.TimeLineScrollBar.Value = 0;
            oView.TimeLine.TimeLineScrollBar.Enabled = true;
            oView.TimeLine.TimeLineScrollBar.Visible = true;
            oView.TimeLine.TimeLineScrollBar.ScrollBar.StyleIndex = "ScrollBar";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "ArrowButtons";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "ArrowButtons";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "ArrowButtons";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "ThumbButtonH";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "ThumbButtonH";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "ThumbButtonH";
            oView.TimeLine.StyleIndex = "TimeLine";
            oView.ClientArea.DetectConflicts = false;
            oView.ClientArea.Grid.Color = Color.FromArgb(255, 197, 206, 216);

            oView = ActiveGanttCSECtl1.Views.Add(E_INTERVAL.IL_HOUR, 3, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM, "");
            oView.TimeLine.TierArea.UpperTier.Interval = E_INTERVAL.IL_QUARTER;
            oView.TimeLine.TierArea.UpperTier.Factor = 1;
            oView.TimeLine.TierArea.UpperTier.Height = 17;
            oView.TimeLine.TierArea.MiddleTier.Visible = false;
            oView.TimeLine.TierArea.LowerTier.Interval = E_INTERVAL.IL_MONTH;
            oView.TimeLine.TierArea.LowerTier.Factor = 1;
            oView.TimeLine.TierArea.LowerTier.Height = 17;
            oView.TimeLine.TickMarkArea.Visible = false;
            oView.TimeLine.TimeLineScrollBar.StartDate = AGCSE.DateTime.Now;
            oView.TimeLine.TimeLineScrollBar.Interval = E_INTERVAL.IL_HOUR;
            oView.TimeLine.TimeLineScrollBar.Factor = 1;
            oView.TimeLine.TimeLineScrollBar.SmallChange = 3;
            oView.TimeLine.TimeLineScrollBar.LargeChange = 960;
            oView.TimeLine.TimeLineScrollBar.Max = 8000;
            oView.TimeLine.TimeLineScrollBar.Value = 0;
            oView.TimeLine.TimeLineScrollBar.Enabled = true;
            oView.TimeLine.TimeLineScrollBar.Visible = true;
            oView.TimeLine.TimeLineScrollBar.ScrollBar.StyleIndex = "ScrollBar";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "ArrowButtons";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "ArrowButtons";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "ArrowButtons";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "ThumbButtonH";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "ThumbButtonH";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "ThumbButtonH";
            oView.TimeLine.StyleIndex = "TimeLine";
            oView.ClientArea.DetectConflicts = false;
            oView.ClientArea.Grid.Color = Color.FromArgb(255, 197, 206, 216);

            oView = ActiveGanttCSECtl1.Views.Add(E_INTERVAL.IL_HOUR, 1, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM, "");
            oView.TimeLine.TierArea.UpperTier.Interval = E_INTERVAL.IL_MONTH;
            oView.TimeLine.TierArea.UpperTier.Factor = 1;
            oView.TimeLine.TierArea.UpperTier.Height = 17;
            oView.TimeLine.TierArea.MiddleTier.Visible = false;
            oView.TimeLine.TierArea.LowerTier.Interval = E_INTERVAL.IL_DAY;
            oView.TimeLine.TierArea.LowerTier.Factor = 1;
            oView.TimeLine.TierArea.LowerTier.Height = 17;
            oView.TimeLine.TickMarkArea.Visible = false;
            oView.TimeLine.TimeLineScrollBar.StartDate = AGCSE.DateTime.Now;
            oView.TimeLine.TimeLineScrollBar.Interval = E_INTERVAL.IL_HOUR;
            oView.TimeLine.TimeLineScrollBar.Factor = 1;
            oView.TimeLine.TimeLineScrollBar.SmallChange = 48;
            oView.TimeLine.TimeLineScrollBar.LargeChange = 2880;
            oView.TimeLine.TimeLineScrollBar.Max = 24000;
            oView.TimeLine.TimeLineScrollBar.Value = 0;
            oView.TimeLine.TimeLineScrollBar.Enabled = true;
            oView.TimeLine.TimeLineScrollBar.Visible = true;
            oView.TimeLine.TimeLineScrollBar.ScrollBar.StyleIndex = "ScrollBar";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "ArrowButtons";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "ArrowButtons";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "ArrowButtons";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "ThumbButtonH";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "ThumbButtonH";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "ThumbButtonH";
            oView.TimeLine.StyleIndex = "TimeLine";
            oView.ClientArea.DetectConflicts = false;
            oView.ClientArea.Grid.Color = Color.FromArgb(255, 197, 206, 216);

            ActiveGanttCSECtl1.CurrentView = "5";

        }

        private void AGSetStartDate(AGCSE.DateTime dtStart)
        {
            int i = 0;
            for (i = 1; i <= ActiveGanttCSECtl1.Views.Count; i++)
            {
                ActiveGanttCSECtl1.Views.Item(i.ToString()).TimeLine.TimeLineScrollBar.StartDate = dtStart;
            }
        }

        private void MP12_To_AG()
        {
            clsTask oAGTask;
            clsRow oAGRow;
            MSP2007.Task oMPTask;
            AGCSE.DateTime dtStartDate = AGCSE.DateTime.Now;
            int i = 0;
            int j = 0;
            //// Load Project Tasks
            for (i = 1; i <= oMP12.oTasks.Count; i++)
            {
                oMPTask = oMP12.oTasks.Item(i.ToString());
                oAGRow = ActiveGanttCSECtl1.Rows.Add("K" + oMPTask.lUID.ToString());
                oAGRow.Cells.Item("1").Text = oMPTask.lUID.ToString();
                oAGRow.Cells.Item("1").StyleIndex = "CellStyleKeyColumn";
                oAGRow.Height = 20;
                oAGRow.ClientAreaStyleIndex = "ClientAreaStyle";
                oAGTask = ActiveGanttCSECtl1.Tasks.Add("", "K" + oMPTask.lUID.ToString(), Globals.FromDate(oMPTask.dtStart), Globals.FromDate(oMPTask.dtFinish), "", "", "");
                oAGTask.Key = "K" + oMPTask.lUID.ToString();
                oAGTask.AllowedMovement = E_MOVEMENTTYPE.MT_RESTRICTEDTOROW;
                oAGTask.AllowTextEdit = true;
                if (Globals.FromDate(oMPTask.dtStart) < dtStartDate)
                {
                    dtStartDate = Globals.FromDate(oMPTask.dtStart);
                }
                if (oAGTask.StartDate == oAGTask.EndDate)
                {
                    oAGTask.Text = oAGTask.StartDate.ToString("M/d");
                }
                oAGRow.Node.Depth = oMPTask.lOutlineLevel;
                oAGRow.Node.Text = oMPTask.sName;
                oAGRow.Node.AllowTextEdit = true;
                oAGRow.Node.StyleIndex = "NodeStyle";
                if (oMPTask.sNotes.Length > 0)
                {
                    oAGRow.Node.Image = GetImage("Note.png");
                    oAGRow.Node.ImageVisible = true;
                }
            }
            ActiveGanttCSECtl1.Rows.UpdateTree();
            //// Indent & set Predecessors
            for (i = 1; i <= oMP12.oTasks.Count; i++)
            {
                oMPTask = oMP12.oTasks.Item(i.ToString());
                oAGRow = ActiveGanttCSECtl1.Rows.Item(i.ToString());
                oAGTask = ActiveGanttCSECtl1.Tasks.Item(i.ToString());
                if (oAGRow.Node.Children() > 0)
                {
                    oAGTask.StyleIndex = "SummaryStyle";
                }
                else
                {
                    oAGTask.StyleIndex = "TaskStyle";
                }
                for (j = 1; j <= oMPTask.oPredecessorLink_C.Count; j++)
                {
                    MSP2007.TaskPredecessorLink oMPPredecessor;
                    oMPPredecessor = oMPTask.oPredecessorLink_C.Item(j.ToString());
                    ActiveGanttCSECtl1.Predecessors.Add("K" + oMPTask.lUID.ToString(), "K" + oMPPredecessor.lPredecessorUID.ToString(), GetAGPredecessorType(oMPPredecessor.yType), "", "TaskStyle");
                }
            }
            //Assignments
            for (i = 1; i <= oMP12.oAssignments.Count; i++)
            {
                MSP2007.Assignment oAssignment;
                oAssignment = oMP12.oAssignments.Item(i.ToString());
                oAGTask = ActiveGanttCSECtl1.Tasks.Item("K" + oAssignment.lTaskUID);
                if (oAGTask.StartDate != oAGTask.EndDate)
                {
                    if (oAssignment.lResourceUID > 0)
                    {
                        if (oAGTask.Text.Length == 0)
                        {
                            oAGTask.Text = oMP12.oResources.Item("K" + oAssignment.lResourceUID).sName;
                        }
                        else
                        {
                            oAGTask.Text = oAGTask.Text + ", " + oMP12.oResources.Item("K" + oAssignment.lResourceUID).sName;
                        }
                    }
                }
            }
            dtStartDate = ActiveGanttCSECtl1.MathLib.DateTimeAdd(E_INTERVAL.IL_DAY, -3, dtStartDate);
            AGSetStartDate(dtStartDate);
        }

        private AGCSE.E_CONSTRAINTTYPE GetAGPredecessorType(MSP2007.X_Globals.E_TYPE_5 MPPredecessorType)
        {
            switch (MPPredecessorType)
            {
                case MSP2007.X_Globals.E_TYPE_5.T_5_FF:
                    return AGCSE.E_CONSTRAINTTYPE.PCT_END_TO_END;
                case MSP2007.X_Globals.E_TYPE_5.T_5_FS:
                    return AGCSE.E_CONSTRAINTTYPE.PCT_END_TO_START;
                case MSP2007.X_Globals.E_TYPE_5.T_5_SF:
                    return AGCSE.E_CONSTRAINTTYPE.PCT_START_TO_END;
                case MSP2007.X_Globals.E_TYPE_5.T_5_SS:
                    return AGCSE.E_CONSTRAINTTYPE.PCT_START_TO_START;
            }
            return AGCSE.E_CONSTRAINTTYPE.PCT_END_TO_START;
        }

        private Image GetImage(string sImage)
        {
            dynamic oReturnImage = new Image();
            System.Uri oURI = new System.Uri("AGCSECON;component/Images/MSP/" + sImage, UriKind.Relative);
            System.Windows.Media.Imaging.BitmapImage oBitmap = new System.Windows.Media.Imaging.BitmapImage();
            System.Windows.Resources.StreamResourceInfo oSRI = Application.GetResourceStream(oURI);
            oBitmap.SetSource(oSRI.Stream);
            oReturnImage.Height = 16;
            oReturnImage.Width = 16;
            oReturnImage.Source = oBitmap;
            return oReturnImage;
        }

        #endregion

        #region "Toolbar Buttons"

        #region "cmdLoad"

        private void cmdLoadXML_Click(object sender, RoutedEventArgs e)
        {
            mp_fLoad.Title = "Load MS-Project 2007 XML file";
            mp_fLoad.mp_oFileList = mp_oFileList;
            mp_fLoad.Show();
        }

        private void mp_fLoad_Closed(object sender, System.EventArgs e)
        {
            if (mp_fLoad.DialogResult == true)
            {
                if (mp_fLoad.sFileName.Length > 0)
                {
                    invkGetXML = oServiceContext.GetXML(mp_fLoad.sFileName);
                    invkGetXML.Completed += invkGetXML_Completed;
                }
            }
        }

        private void invkGetXML_Completed(object sender, System.EventArgs e)
        {
            string sXML = invkGetXML.Value;
            sXML = Globals.g_RemoveXMLNameSpaces(sXML);
            this.Cursor = Cursors.Wait;
            ActiveGanttCSECtl1.Clear();
            oMP12 = new MSP2007.MP12();
            oMP12.SetXML(sXML);
            this.Cursor = Cursors.Wait;
            InitializeAG();
            MP12_To_AG();
            ActiveGanttCSECtl1.Redraw();
            ActiveGanttCSECtl1.VerticalScrollBar.LargeChange = ActiveGanttCSECtl1.CurrentViewObject.ClientArea.LastVisibleRow - ActiveGanttCSECtl1.CurrentViewObject.ClientArea.FirstVisibleRow;
            ActiveGanttCSECtl1.Redraw();
            this.Cursor = Cursors.Arrow;
        }

        #endregion

        private void cmdBack_Click(object sender, RoutedEventArgs e)
        {
            fMain oForm = new fMain();
            this.Content = oForm;
        }

        private void cmdZoomin_Click(object sender, RoutedEventArgs e)
        {
            if (System.Convert.ToInt32(ActiveGanttCSECtl1.CurrentView) < ActiveGanttCSECtl1.Views.Count)
            {
                ActiveGanttCSECtl1.CurrentView = System.Convert.ToString(System.Convert.ToInt32(ActiveGanttCSECtl1.CurrentView) + 1);
                ActiveGanttCSECtl1.Redraw();
            }
        }

        private void cmdZoomout_Click(object sender, RoutedEventArgs e)
        {
            if (System.Convert.ToInt32(ActiveGanttCSECtl1.CurrentView) > 1)
            {
                ActiveGanttCSECtl1.CurrentView = System.Convert.ToString(System.Convert.ToInt32(ActiveGanttCSECtl1.CurrentView) - 1);
                ActiveGanttCSECtl1.Redraw();
            }
        }

        #endregion



    }
}
