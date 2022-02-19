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
using AGCSE;
using System.ServiceModel.DomainServices.Client;
using AGCSECON.Web;

namespace AGCSECON
{
    public partial class fWBSProject : Page
    {

        private AGCSE.DateTime mp_dtStartDate;
        private AGCSE.DateTime mp_dtEndDate;
        private const string mp_sFontName = "Tahoma";
        internal E_DATASOURCETYPE mp_yDataSourceType;
        private Border mp_oToolTip;
        private StackPanel mp_oStackPanel;
        private Grid mp_oTitleGrid;
        private TextBlock mp_oToolTipTitle;
        private TextBlock mp_oToolTipText;
        private Line mp_oToolTipLine;
        private Image mp_oToolTipImage;
        private bool mp_bBluePercentagesVisible = true;
        private bool mp_bGreenPercentagesVisible = true;
        private bool mp_bRedPercentagesVisible = true;
        private fWBSPProperties mp_fWBSPProperties;

        private InvokeOperation<string> invkGetFileList;
        private InvokeOperation invkSetXML;
        ActiveGanttXMLContext oServiceContext = new ActiveGanttXMLContext();
        private List<CON_File> mp_oFileList;
        private fSave mp_fSave;

        #region "Constructors"

        public fWBSProject()
        {
            InitializeComponent();
            mp_fWBSPProperties = new fWBSPProperties(this);
        }

        #endregion

        #region "Page Loaded"

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            InitToolTip();

            invkGetFileList = oServiceContext.GetFileList();
            invkGetFileList.Completed += invkGetFileList_Completed;

            mp_dtStartDate = new AGCSE.DateTime();
            mp_dtEndDate = new AGCSE.DateTime();

            AGCSE.DateTime dtStartDate = new AGCSE.DateTime();

            clsStyle oStyle = null;
            clsView oView = null;

            oStyle = ActiveGanttCSECtl1.Styles.Add("ControlStyle");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.BorderColor = Color.FromArgb(255, 100, 145, 204);
            oStyle.BackColor = Color.FromArgb(255, 240, 240, 240);

            oStyle = ActiveGanttCSECtl1.Styles.Add("ScrollBar");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = Colors.White;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = Color.FromArgb(255, 150, 150, 150);

            oStyle = ActiveGanttCSECtl1.Styles.Add("ArrowButtons");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = Colors.White;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = Color.FromArgb(255, 150, 150, 150);

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

            oStyle = ActiveGanttCSECtl1.Styles.Add("ThumbButtonHP");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
            oStyle.StartGradientColor = Color.FromArgb(255, 165, 186, 207);
            oStyle.EndGradientColor = Color.FromArgb(255, 240, 240, 240);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = Color.FromArgb(255, 138, 145, 153);

            oStyle = ActiveGanttCSECtl1.Styles.Add("ThumbButtonVP");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_HORIZONTAL;
            oStyle.StartGradientColor = Color.FromArgb(255, 165, 186, 207);
            oStyle.EndGradientColor = Color.FromArgb(255, 240, 240, 240);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = Color.FromArgb(255, 138, 145, 153);

            oStyle = ActiveGanttCSECtl1.Styles.Add("ColumnStyle");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.StartGradientColor = Color.FromArgb(255, 179, 206, 235);
            oStyle.EndGradientColor = Color.FromArgb(255, 161, 193, 232);
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
            oStyle.CustomBorderStyle.Left = false;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Right = true;
            oStyle.CustomBorderStyle.Bottom = true;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.BorderColor = Color.FromArgb(255, 100, 145, 204);

            oStyle = ActiveGanttCSECtl1.Styles.Add("ScrollBarSeparatorStyle");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = Colors.White;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = Color.FromArgb(255, 150, 150, 150);

            oStyle = ActiveGanttCSECtl1.Styles.Add("TimeLineTiers");
            oStyle.Font = new Font(mp_sFontName, 7, E_FONTSIZEUNITS.FSU_POINTS, System.Windows.FontWeights.Normal);
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

            oStyle = ActiveGanttCSECtl1.Styles.Add("NodeRegular");
            oStyle.Font = new Font(mp_sFontName, 8, E_FONTSIZEUNITS.FSU_POINTS, System.Windows.FontWeights.Normal);
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = Colors.White;
            oStyle.BorderColor = Color.FromArgb(255, 192, 192, 192);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Left = false;

            oStyle = ActiveGanttCSECtl1.Styles.Add("NodeRegularChecked");
            oStyle.Font = new Font(mp_sFontName, 8, E_FONTSIZEUNITS.FSU_POINTS, System.Windows.FontWeights.Normal);
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = Color.FromArgb(255, 176, 196, 222);
            oStyle.BorderColor = Color.FromArgb(255, 192, 192, 192);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Left = false;

            oStyle = ActiveGanttCSECtl1.Styles.Add("NodeBold");
            oStyle.Font = new Font(mp_sFontName, 8, E_FONTSIZEUNITS.FSU_POINTS, System.Windows.FontWeights.Bold);
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = Colors.White;
            oStyle.BorderColor = Color.FromArgb(255, 192, 192, 192);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Left = false;

            oStyle = ActiveGanttCSECtl1.Styles.Add("NodeBoldChecked");
            oStyle.Font = new Font(mp_sFontName, 8, E_FONTSIZEUNITS.FSU_POINTS, System.Windows.FontWeights.Bold);
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = Color.FromArgb(255, 176, 196, 222);
            oStyle.BorderColor = Color.FromArgb(255, 192, 192, 192);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Left = false;

            oStyle = ActiveGanttCSECtl1.Styles.Add("ClientAreaChecked");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = Color.FromArgb(255, 176, 196, 222);

            oStyle = ActiveGanttCSECtl1.Styles.Add("NormalTask");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT;
            oStyle.BackColor = Color.FromArgb(255, 100, 145, 204);
            oStyle.BorderColor = Colors.Blue;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.SelectionRectangleStyle.OffsetTop = 0;
            oStyle.SelectionRectangleStyle.OffsetLeft = 0;
            oStyle.SelectionRectangleStyle.OffsetRight = 0;
            oStyle.SelectionRectangleStyle.OffsetBottom = 0;
            oStyle.OffsetTop = 5;
            oStyle.OffsetBottom = 10;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.StartGradientColor = Colors.White;
            oStyle.EndGradientColor = Color.FromArgb(255, 100, 145, 204);
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
            oStyle.PredecessorStyle.LineColor = Color.FromArgb(255, 100, 145, 204);
            oStyle.MilestoneStyle.ShapeIndex = GRE_FIGURETYPE.FT_DIAMOND;

            oStyle = ActiveGanttCSECtl1.Styles.Add("NormalTaskWarning");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT;
            oStyle.BackColor = Color.FromArgb(255, 100, 145, 204);
            oStyle.BorderColor = Colors.Red;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.SelectionRectangleStyle.OffsetTop = 0;
            oStyle.SelectionRectangleStyle.OffsetLeft = 0;
            oStyle.SelectionRectangleStyle.OffsetRight = 0;
            oStyle.SelectionRectangleStyle.OffsetBottom = 0;
            oStyle.OffsetTop = 5;
            oStyle.OffsetBottom = 10;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.StartGradientColor = Colors.White;
            oStyle.EndGradientColor = Color.FromArgb(255, 100, 145, 204);
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
            oStyle.PredecessorStyle.LineColor = Colors.Red;
            oStyle.MilestoneStyle.ShapeIndex = GRE_FIGURETYPE.FT_DIAMOND;

            oStyle = ActiveGanttCSECtl1.Styles.Add("SelectedPredecessor");
            oStyle.PredecessorStyle.LineColor = Colors.Green;

            oStyle = ActiveGanttCSECtl1.Styles.Add("GreenSummary");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT;
            oStyle.BackColor = Colors.Green;
            oStyle.BorderColor = Colors.Green;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.SelectionRectangleStyle.OffsetTop = 0;
            oStyle.SelectionRectangleStyle.OffsetLeft = 0;
            oStyle.SelectionRectangleStyle.OffsetRight = 0;
            oStyle.SelectionRectangleStyle.OffsetBottom = 0;
            oStyle.OffsetTop = 5;
            oStyle.OffsetBottom = 10;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.StartGradientColor = Colors.White;
            oStyle.EndGradientColor = Colors.Green;
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
            oStyle.MilestoneStyle.ShapeIndex = GRE_FIGURETYPE.FT_DIAMOND;
            oStyle.SelectionRectangleStyle.Visible = false;
            oStyle.TaskStyle.EndFillColor = Colors.Green;
            oStyle.TaskStyle.EndBorderColor = Colors.Green;
            oStyle.TaskStyle.StartFillColor = Colors.Green;
            oStyle.TaskStyle.StartBorderColor = Colors.Green;
            oStyle.TaskStyle.StartShapeIndex = GRE_FIGURETYPE.FT_PROJECTDOWN;
            oStyle.TaskStyle.EndShapeIndex = GRE_FIGURETYPE.FT_PROJECTDOWN;
            oStyle.FillMode = GRE_FILLMODE.FM_UPPERHALFFILLED;

            oStyle = ActiveGanttCSECtl1.Styles.Add("RedSummary");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT;
            oStyle.BackColor = Colors.Red;
            oStyle.BorderColor = Colors.Red;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.OffsetTop = 5;
            oStyle.OffsetBottom = 10;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.StartGradientColor = Colors.White;
            oStyle.EndGradientColor = Colors.Red;
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
            oStyle.MilestoneStyle.ShapeIndex = GRE_FIGURETYPE.FT_DIAMOND;
            oStyle.SelectionRectangleStyle.Visible = false;
            oStyle.TaskStyle.EndFillColor = Colors.Red;
            oStyle.TaskStyle.EndBorderColor = Colors.Red;
            oStyle.TaskStyle.StartFillColor = Colors.Red;
            oStyle.TaskStyle.StartBorderColor = Colors.Red;
            oStyle.TaskStyle.StartShapeIndex = GRE_FIGURETYPE.FT_PROJECTDOWN;
            oStyle.TaskStyle.EndShapeIndex = GRE_FIGURETYPE.FT_PROJECTDOWN;
            oStyle.FillMode = GRE_FILLMODE.FM_UPPERHALFFILLED;

            oStyle = ActiveGanttCSECtl1.Styles.Add("BluePercentages");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT;
            oStyle.BackColor = Colors.Blue;
            oStyle.BorderColor = Colors.Blue;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.SelectionRectangleStyle.OffsetTop = 0;
            oStyle.SelectionRectangleStyle.OffsetLeft = 0;
            oStyle.SelectionRectangleStyle.OffsetRight = 0;
            oStyle.SelectionRectangleStyle.OffsetBottom = 0;
            oStyle.OffsetTop = 8;
            oStyle.OffsetBottom = 4;
            oStyle.SelectionRectangleStyle.Visible = true;
            oStyle.TextVisible = false;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;

            oStyle = ActiveGanttCSECtl1.Styles.Add("GreenPercentages");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT;
            oStyle.BackColor = Colors.Green;
            oStyle.BorderColor = Colors.Green;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.SelectionRectangleStyle.OffsetTop = 0;
            oStyle.SelectionRectangleStyle.OffsetLeft = 0;
            oStyle.SelectionRectangleStyle.OffsetRight = 0;
            oStyle.SelectionRectangleStyle.OffsetBottom = 0;
            oStyle.OffsetTop = 5;
            oStyle.OffsetBottom = 5;
            oStyle.SelectionRectangleStyle.Visible = false;
            oStyle.TextVisible = false;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;

            oStyle = ActiveGanttCSECtl1.Styles.Add("RedPercentages");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT;
            oStyle.BackColor = Colors.Red;
            oStyle.BorderColor = Colors.Red;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.SelectionRectangleStyle.OffsetTop = 0;
            oStyle.SelectionRectangleStyle.OffsetLeft = 0;
            oStyle.SelectionRectangleStyle.OffsetRight = 0;
            oStyle.SelectionRectangleStyle.OffsetBottom = 0;
            oStyle.OffsetTop = 5;
            oStyle.OffsetBottom = 5;
            oStyle.SelectionRectangleStyle.Visible = false;
            oStyle.TextVisible = false;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;

            oStyle = ActiveGanttCSECtl1.Styles.Add("InvisiblePercentages");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT;
            oStyle.BackColor = Colors.White;
            oStyle.BorderColor = Colors.White;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.SelectionRectangleStyle.OffsetTop = 0;
            oStyle.SelectionRectangleStyle.OffsetLeft = 0;
            oStyle.SelectionRectangleStyle.OffsetRight = 0;
            oStyle.SelectionRectangleStyle.OffsetBottom = 0;
            oStyle.OffsetTop = 5;
            oStyle.OffsetBottom = 5;
            oStyle.SelectionRectangleStyle.Visible = false;
            oStyle.TextVisible = false;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;

            oStyle = ActiveGanttCSECtl1.Styles.Add("ClientAreaStyle");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackColor = Colors.White;
            oStyle.BorderColor = Color.FromArgb(255, 197, 206, 216);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Left = false;
            oStyle.CustomBorderStyle.Right = false;

            oStyle = ActiveGanttCSECtl1.Styles.Add("CellStyleKeyColumn");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackColor = Colors.White;
            oStyle.BorderColor = Color.FromArgb(255, 192, 192, 192);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Left = false;
            oStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_RIGHT;
            oStyle.TextXMargin = 4;

            oStyle = ActiveGanttCSECtl1.Styles.Add("CellStyle");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackColor = Colors.White;
            oStyle.BorderColor = Color.FromArgb(255, 192, 192, 192);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Left = false;

            oStyle = ActiveGanttCSECtl1.Styles.Add("CellStyleKeyColumnChecked");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackColor = Color.FromArgb(255, 176, 196, 222);
            oStyle.BorderColor = Color.FromArgb(255, 192, 192, 192);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Left = false;
            oStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_RIGHT;
            oStyle.TextXMargin = 4;

            oStyle = ActiveGanttCSECtl1.Styles.Add("CellStyleChecked");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackColor = Color.FromArgb(255, 176, 196, 222);
            oStyle.BorderColor = Color.FromArgb(255, 192, 192, 192);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Left = false;

            ActiveGanttCSECtl1.ControlTag = "WBSProject";
            ActiveGanttCSECtl1.StyleIndex = "ControlStyle";
            ActiveGanttCSECtl1.ScrollBarSeparator.StyleIndex = "ScrollBarSeparatorStyle";
            ActiveGanttCSECtl1.AllowRowMove = true;
            ActiveGanttCSECtl1.AllowRowSize = true;
            ActiveGanttCSECtl1.AddMode = E_ADDMODE.AT_BOTH;

            clsColumn oColumn;

            oColumn = ActiveGanttCSECtl1.Columns.Add("ID", "", 30, "");
            oColumn.StyleIndex = "ColumnStyle";
            oColumn.AllowTextEdit = true;

            oColumn = ActiveGanttCSECtl1.Columns.Add("Task Name", "", 300, "");
            oColumn.StyleIndex = "ColumnStyle";
            oColumn.AllowTextEdit = true;

            oColumn = ActiveGanttCSECtl1.Columns.Add("StartDate", "", 125, "");
            oColumn.StyleIndex = "ColumnStyle";
            oColumn.AllowTextEdit = true;

            oColumn = ActiveGanttCSECtl1.Columns.Add("EndDate", "", 125, "");
            oColumn.StyleIndex = "ColumnStyle";
            oColumn.AllowTextEdit = true;

            ActiveGanttCSECtl1.TreeviewColumnIndex = 2;

            ActiveGanttCSECtl1.Treeview.Images = true;
            ActiveGanttCSECtl1.Treeview.CheckBoxes = true;
            ActiveGanttCSECtl1.Treeview.FullColumnSelect = true;
            ActiveGanttCSECtl1.Treeview.PlusMinusBorderColor = Color.FromArgb(255, 100, 145, 204);
            ActiveGanttCSECtl1.Treeview.PlusMinusSignColor = Color.FromArgb(255, 100, 145, 204);
            ActiveGanttCSECtl1.Treeview.CheckBoxBorderColor = Color.FromArgb(255, 100, 145, 204);
            ActiveGanttCSECtl1.Treeview.TreeLineColor = Color.FromArgb(255, 100, 145, 204);

            ActiveGanttCSECtl1.Splitter.Type = E_SPLITTERTYPE.SA_USERDEFINED;
            ActiveGanttCSECtl1.Splitter.Width = 1;
            ActiveGanttCSECtl1.Splitter.SetColor(1, Color.FromArgb(255, 100, 145, 204));
            ActiveGanttCSECtl1.Splitter.Position = 255;

            ActiveGanttCSECtl1.VerticalScrollBar.ScrollBar.TimerInterval = 50;
            ActiveGanttCSECtl1.VerticalScrollBar.ScrollBar.StyleIndex = "ScrollBar";
            ActiveGanttCSECtl1.VerticalScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "ArrowButtons";
            ActiveGanttCSECtl1.VerticalScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "ArrowButtons";
            ActiveGanttCSECtl1.VerticalScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "ArrowButtons";
            ActiveGanttCSECtl1.VerticalScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "ThumbButtonV";
            ActiveGanttCSECtl1.VerticalScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "ThumbButtonVP";
            ActiveGanttCSECtl1.VerticalScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "ThumbButtonV";

            ActiveGanttCSECtl1.HorizontalScrollBar.ScrollBar.StyleIndex = "ScrollBar";
            ActiveGanttCSECtl1.HorizontalScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "ArrowButtons";
            ActiveGanttCSECtl1.HorizontalScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "ArrowButtons";
            ActiveGanttCSECtl1.HorizontalScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "ArrowButtons";
            ActiveGanttCSECtl1.HorizontalScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "ThumbButtonH";
            ActiveGanttCSECtl1.HorizontalScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "ThumbButtonHP";
            ActiveGanttCSECtl1.HorizontalScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "ThumbButtonH";

            if (mp_yDataSourceType == E_DATASOURCETYPE.DST_ACCESS)
            {
                //Access_LoadTasks();
            }
            else if (mp_yDataSourceType == E_DATASOURCETYPE.DST_XML)
            {
                //XML_LoadTasks();
            }
            else if (mp_yDataSourceType == E_DATASOURCETYPE.DST_NONE)
            {
                NoDataSource_LoadTasks();
            }
            ActiveGanttCSECtl1.Rows.UpdateTree();

            //// Start one month before the first task:
            dtStartDate = ActiveGanttCSECtl1.MathLib.DateTimeAdd(E_INTERVAL.IL_MONTH, -1, mp_dtStartDate);

            oView = ActiveGanttCSECtl1.Views.Add(E_INTERVAL.IL_HOUR, 24, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM, "");
            oView.TimeLine.TierArea.UpperTier.Interval = E_INTERVAL.IL_QUARTER;
            oView.TimeLine.TierArea.UpperTier.Factor = 1;
            oView.TimeLine.TierArea.UpperTier.Height = 17;
            oView.TimeLine.TierArea.MiddleTier.Visible = false;
            oView.TimeLine.TierArea.LowerTier.Interval = E_INTERVAL.IL_MONTH;
            oView.TimeLine.TierArea.LowerTier.Factor = 1;
            oView.TimeLine.TierArea.LowerTier.Height = 17;
            oView.TimeLine.TickMarkArea.Visible = false;
            oView.TimeLine.TimeLineScrollBar.StartDate = dtStartDate;
            oView.TimeLine.TimeLineScrollBar.Enabled = true;
            oView.TimeLine.TimeLineScrollBar.Visible = false;
            oView.TimeLine.TimeLineScrollBar.ScrollBar.StyleIndex = "ScrollBar";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "ArrowButtons";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "ArrowButtons";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "ArrowButtons";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "ThumbButtonH";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "ThumbButtonHP";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "ThumbButtonH";
            oView.TimeLine.StyleIndex = "TimeLine";
            oView.ClientArea.DetectConflicts = false;

            oView = ActiveGanttCSECtl1.Views.Add(E_INTERVAL.IL_HOUR, 12, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM, "");
            oView.TimeLine.TierArea.UpperTier.Interval = E_INTERVAL.IL_QUARTER;
            oView.TimeLine.TierArea.UpperTier.Factor = 1;
            oView.TimeLine.TierArea.UpperTier.Height = 17;
            oView.TimeLine.TierArea.MiddleTier.Visible = false;
            oView.TimeLine.TierArea.LowerTier.Interval = E_INTERVAL.IL_MONTH;
            oView.TimeLine.TierArea.LowerTier.Factor = 1;
            oView.TimeLine.TierArea.LowerTier.Height = 17;
            oView.TimeLine.TickMarkArea.Visible = false;
            oView.TimeLine.TimeLineScrollBar.StartDate = dtStartDate;
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
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "ThumbButtonHP";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "ThumbButtonH";
            oView.TimeLine.StyleIndex = "TimeLine";
            oView.ClientArea.DetectConflicts = false;

            oView = ActiveGanttCSECtl1.Views.Add(E_INTERVAL.IL_HOUR, 6, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM, "");
            oView.TimeLine.TierArea.UpperTier.Interval = E_INTERVAL.IL_QUARTER;
            oView.TimeLine.TierArea.UpperTier.Factor = 1;
            oView.TimeLine.TierArea.UpperTier.Height = 17;
            oView.TimeLine.TierArea.MiddleTier.Visible = false;
            oView.TimeLine.TierArea.LowerTier.Interval = E_INTERVAL.IL_MONTH;
            oView.TimeLine.TierArea.LowerTier.Factor = 1;
            oView.TimeLine.TierArea.LowerTier.Height = 17;
            oView.TimeLine.TickMarkArea.Visible = false;
            oView.TimeLine.TimeLineScrollBar.StartDate = dtStartDate;
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
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "ThumbButtonHP";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "ThumbButtonH";
            oView.TimeLine.StyleIndex = "TimeLine";
            oView.ClientArea.DetectConflicts = false;

            ActiveGanttCSECtl1.CurrentView = "2";


            ActiveGanttCSECtl1.Redraw();

        }

        private void InitToolTip()
        {
            mp_oToolTip = new Border();
            mp_oToolTip.BorderThickness = new Thickness(1);
            mp_oToolTip.BorderBrush = new SolidColorBrush(Colors.Black);
            mp_oToolTip.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 224));
            mp_oToolTip.Width = 275;
            mp_oToolTip.Visibility = System.Windows.Visibility.Collapsed;
            mp_oStackPanel = new StackPanel();

            mp_oTitleGrid = new Grid();
            ColumnDefinition oColumn0 = new ColumnDefinition();
            ColumnDefinition oColumn1 = new ColumnDefinition();
            oColumn0.Width = new GridLength(20);
            mp_oTitleGrid.ColumnDefinitions.Add(oColumn0);
            oColumn1.Width = new GridLength(255);
            mp_oTitleGrid.ColumnDefinitions.Add(oColumn1);
            RowDefinition oRow1 = new RowDefinition();
            oRow1.Height = GridLength.Auto;
            mp_oTitleGrid.RowDefinitions.Add(oRow1);

            mp_oToolTipImage = new Image();
            mp_oToolTipImage.Width = 16;
            mp_oToolTipImage.Height = 16;
            mp_oToolTipImage.VerticalAlignment = System.Windows.VerticalAlignment.Top;

            mp_oTitleGrid.Children.Add(mp_oToolTipImage);
            Grid.SetRow(mp_oToolTipImage, 0);
            Grid.SetColumn(mp_oToolTipImage, 0);


            mp_oToolTipTitle = new TextBlock();
            mp_oToolTipTitle.TextWrapping = TextWrapping.Wrap;
            mp_oToolTipTitle.TextAlignment = TextAlignment.Center;

            mp_oTitleGrid.Children.Add(mp_oToolTipTitle);
            Grid.SetRow(mp_oToolTipTitle, 0);
            Grid.SetColumn(mp_oToolTipTitle, 1);

            mp_oStackPanel.Children.Add(mp_oTitleGrid);

            mp_oToolTipLine = new Line();
            mp_oToolTipLine.Stroke = new SolidColorBrush(Colors.Black);
            mp_oToolTipLine.X1 = 0;
            mp_oToolTipLine.Y1 = 0;
            mp_oToolTipLine.X2 = 275;
            mp_oToolTipLine.Y2 = 0;

            mp_oStackPanel.Children.Add(mp_oToolTipLine);

            mp_oToolTipText = new TextBlock();

            mp_oStackPanel.Children.Add(mp_oToolTipText);

            mp_oToolTip.Child = mp_oStackPanel;
            ActiveGanttCSECtl1.ControlCanvas.Children.Add(mp_oToolTip);
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

        private void ActiveGanttCSECtl1_CustomTierDraw(object sender, AGCSE.CustomTierDrawEventArgs e)
        {
            if (e.TierPosition == E_TIERPOSITION.SP_LOWER)
            {
                e.StyleIndex = "TimeLineTiers";
                ActiveGanttCSECtl1.CustomTierDrawEventArgs.Text = e.StartDate.ToString("MMM");
            }
            else if (e.TierPosition == E_TIERPOSITION.SP_UPPER)
            {
                e.StyleIndex = "TimeLineTiers";
                ActiveGanttCSECtl1.CustomTierDrawEventArgs.Text = e.StartDate.Year().ToString() + " Q" + e.StartDate.Quarter().ToString();
            }
        }

        private void ActiveGanttCSECtl1_NodeChecked(object sender, AGCSE.NodeEventArgs e)
        {
            clsRow oRow;
            oRow = ActiveGanttCSECtl1.Rows.Item(e.Index.ToString());
            if (oRow.Node.Checked == true)
            {
                oRow.ClientAreaStyleIndex = "ClientAreaChecked";
                oRow.Cells.Item("1").StyleIndex = "CellStyleKeyColumnChecked";
                oRow.Cells.Item("3").StyleIndex = "CellStyleChecked";
                oRow.Cells.Item("4").StyleIndex = "CellStyleChecked";
                if (oRow.Node.StyleIndex == "NodeBold")
                {
                    oRow.Node.StyleIndex = "NodeBoldChecked";
                }
                else
                {
                    oRow.Node.StyleIndex = "NodeRegularChecked";
                }
            }
            else
            {
                oRow.ClientAreaStyleIndex = "ClientAreaStyle";
                oRow.Cells.Item("1").StyleIndex = "CellStyleKeyColumn";
                oRow.Cells.Item("3").StyleIndex = "CellStyle";
                oRow.Cells.Item("4").StyleIndex = "CellStyle";
                if (oRow.Node.StyleIndex == "NodeBoldChecked")
                {
                    oRow.Node.StyleIndex = "NodeBold";
                }
                else
                {
                    oRow.Node.StyleIndex = "NodeRegular";
                }
            }
        }

        private void ActiveGanttCSECtl1_ControlMouseDown(object sender, AGCSE.MouseEventArgs e)
        {

        }

        private void ActiveGanttCSECtl1_ObjectAdded(object sender, AGCSE.ObjectAddedEventArgs e)
        {
            switch (e.EventTarget)
            {
                case E_EVENTTARGET.EVT_TASK:
                case E_EVENTTARGET.EVT_MILESTONE:
                    clsTask oTask = null;
                    oTask = GetTaskByRowKey(ActiveGanttCSECtl1.Tasks.Item(e.TaskIndex.ToString()).RowKey);
                    oTask.StartDate = ActiveGanttCSECtl1.Tasks.Item(e.TaskIndex.ToString()).StartDate;
                    oTask.EndDate = ActiveGanttCSECtl1.Tasks.Item(e.TaskIndex.ToString()).EndDate;
                    UpdateTask(oTask.Index);
                    ActiveGanttCSECtl1.Tasks.Remove(e.TaskIndex.ToString());
                    break;
                case E_EVENTTARGET.EVT_PREDECESSOR:
                    ActiveGanttCSECtl1.Predecessors.Item(e.PredecessorObjectIndex.ToString()).StyleIndex = "NormalTask";
                    ActiveGanttCSECtl1.Predecessors.Item(e.PredecessorObjectIndex.ToString()).WarningStyleIndex = "NormalTaskWarning";
                    ActiveGanttCSECtl1.Predecessors.Item(e.PredecessorObjectIndex.ToString()).SelectedStyleIndex = "SelectedPredecessor";
                    InsertPredecessor(e.PredecessorTaskKey, e.TaskKey, e.PredecessorType);
                    break;
            }
        }

        private void ActiveGanttCSECtl1_CompleteObjectMove(object sender, AGCSE.ObjectStateChangedEventArgs e)
        {
            switch (e.EventTarget)
            {
                case E_EVENTTARGET.EVT_TASK:
                    UpdateTask(e.Index);
                    break;
            }
        }

        private void ActiveGanttCSECtl1_CompleteObjectSize(object sender, AGCSE.ObjectStateChangedEventArgs e)
        {
            switch (e.EventTarget)
            {
                case E_EVENTTARGET.EVT_TASK:
                    UpdateTask(e.Index);
                    break;
                case E_EVENTTARGET.EVT_PERCENTAGE:
                    int lTaskIndex = 0;
                    lTaskIndex = ActiveGanttCSECtl1.Tasks.Item(ActiveGanttCSECtl1.Percentages.Item(e.Index.ToString()).TaskKey).Index;
                    UpdateTask(lTaskIndex);
                    break;
            }
        }

        private void ActiveGanttCSECtl1_ToolTipOnMouseHover(object sender, AGCSE.ToolTipEventArgs e)
        {
            if (e.EventTarget == E_EVENTTARGET.EVT_TASK | e.EventTarget == E_EVENTTARGET.EVT_SELECTEDTASK | e.EventTarget == E_EVENTTARGET.EVT_PERCENTAGE | e.EventTarget == E_EVENTTARGET.EVT_SELECTEDPERCENTAGE)
            {
                mp_oToolTip.Visibility = System.Windows.Visibility.Visible;
                clsRow oRow = null;
                clsTask oTask = null;
                clsPercentage oPercentage;
                float fPercentage = 0;
                oRow = ActiveGanttCSECtl1.Rows.Item(ActiveGanttCSECtl1.MathLib.GetRowIndexByPosition(System.Convert.ToInt32(e.Y)).ToString());
                oTask = ActiveGanttCSECtl1.Tasks.Item(ActiveGanttCSECtl1.MathLib.GetTaskIndexByPosition(System.Convert.ToInt32(e.X), System.Convert.ToInt32(e.Y)).ToString());
                oPercentage = GetPercentageByTaskKey(oTask.Key);
                if ((oPercentage != null))
                {
                    fPercentage = oPercentage.Percent * 100;
                }
                mp_oToolTipTitle.Text = oRow.Text;
                mp_oToolTipImage.Source = oRow.Node.Image.Source;
                mp_oToolTipText.Text = "Duration: " + ActiveGanttCSECtl1.MathLib.DateTimeDiff(E_INTERVAL.IL_DAY, oTask.StartDate, oTask.EndDate) + " days" + "\r\n" + "From: " + oTask.StartDate.ToString("ddd MMM d, yyyy") + " To " + oTask.EndDate.ToString("ddd MMM d, yyyy") + "\r\n" + "Percent Completed: " + fPercentage.ToString("00.00") + "%";
                return;
            }
            mp_oToolTip.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void ActiveGanttCSECtl1_ToolTipOnMouseMove(object sender, AGCSE.ToolTipEventArgs e)
        {
            if (e.Operation == E_OPERATION.EO_PERCENTAGESIZING | e.Operation == E_OPERATION.EO_TASKMOVEMENT | e.Operation == E_OPERATION.EO_TASKSTRETCHLEFT | e.Operation == E_OPERATION.EO_TASKSTRETCHRIGHT)
            {
                mp_oToolTip.Visibility = System.Windows.Visibility.Visible;
                clsRow oRow = null;
                clsTask oTask = null;
                clsPercentage oPercentage;
                float fPercentage = 0;
                oRow = ActiveGanttCSECtl1.Rows.Item(ActiveGanttCSECtl1.MathLib.GetRowIndexByPosition(e.Y).ToString());
                if (ActiveGanttCSECtl1.MathLib.GetTaskIndexByPosition(e.X, e.Y) >= 1)
                {
                    oTask = ActiveGanttCSECtl1.Tasks.Item(ActiveGanttCSECtl1.MathLib.GetTaskIndexByPosition(e.X, e.Y).ToString());
                }
                if (oTask == null)
                {
                    oTask = ActiveGanttCSECtl1.Tasks.Item(e.TaskIndex.ToString());
                }
                oPercentage = GetPercentageByTaskKey(oTask.Key);
                if (e.Operation == E_OPERATION.EO_PERCENTAGESIZING)
                {
                    fPercentage = (e.X - e.XStart) / (e.XEnd - e.XStart) * 100;
                }
                else
                {
                    if ((oPercentage != null))
                    {
                        fPercentage = oPercentage.Percent * 100;
                    }
                }
                mp_oToolTipTitle.Text = oRow.Text;
                mp_oToolTipImage.Source = oRow.Node.Image.Source;
                mp_oToolTipText.Text = "Duration: " + ActiveGanttCSECtl1.MathLib.DateTimeDiff(E_INTERVAL.IL_DAY, e.StartDate, e.EndDate) + " days" + "\r\n" + "From: " + e.StartDate.ToString("ddd MMM d, yyyy") + " To " + e.EndDate.ToString("ddd MMM d, yyyy") + "\r\n" + "Percent Completed: " + fPercentage.ToString("00.00") + "%";
                return;
            }
            mp_oToolTip.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void ActiveGanttCSECtl1_ControlMouseWheel(object sender, AGCSE.MouseWheelEventArgs e)
        {
            if ((e.Delta == 0) | (ActiveGanttCSECtl1.VerticalScrollBar.Visible == false))
            {
                return;
            }
            int lDelta = System.Convert.ToInt32(-(e.Delta / 100));
            int lInitialValue = ActiveGanttCSECtl1.VerticalScrollBar.Value;
            if ((ActiveGanttCSECtl1.VerticalScrollBar.Value + lDelta < 1))
            {
                ActiveGanttCSECtl1.VerticalScrollBar.Value = 1;
            }
            else if ((((ActiveGanttCSECtl1.VerticalScrollBar.Value + lDelta) > ActiveGanttCSECtl1.VerticalScrollBar.Max)))
            {
                ActiveGanttCSECtl1.VerticalScrollBar.Value = ActiveGanttCSECtl1.VerticalScrollBar.Max;
            }
            else
            {
                ActiveGanttCSECtl1.VerticalScrollBar.Value = ActiveGanttCSECtl1.VerticalScrollBar.Value + lDelta;
            }
            ActiveGanttCSECtl1.Redraw();
        }

        private void ActiveGanttCSECtl1_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            mp_oToolTip.SetValue(Canvas.LeftProperty, e.GetPosition(ActiveGanttCSECtl1.ControlCanvas).X + 32);
            mp_oToolTip.SetValue(Canvas.TopProperty, e.GetPosition(ActiveGanttCSECtl1.ControlCanvas).Y + 32);
        }

        #endregion

        #region "Page Properties"

        internal E_DATASOURCETYPE DataSource
        {
            get { return mp_yDataSourceType; }
            set { mp_yDataSourceType = value; }
        }

        #endregion

        #region "Functions"

        private void UpdateTask(int Index)
        {
            AGCSE.clsPercentage oPercentage = GetPercentageByTaskKey(ActiveGanttCSECtl1.Tasks.Item(Index.ToString()).Key);
            clsTask oTask;
            oTask = ActiveGanttCSECtl1.Tasks.Item(Index.ToString());
            SetTaskGridColumns(oTask);
            string sRowKey = oTask.RowKey;
            AGCSE.DateTime dtStartDate = oTask.StartDate;
            AGCSE.DateTime dtEndDate = oTask.EndDate;
            clsNode oNode = ActiveGanttCSECtl1.Rows.Item(sRowKey).Node;
            if (mp_yDataSourceType == E_DATASOURCETYPE.DST_ACCESS)
            {
            }
            //Using oConn As New OleDbConnection(g_DST_ACCESS_GetConnectionString())
            //    Dim oCmd As OleDbCommand = Nothing
            //    Dim sSQL As String = "UPDATE tb_GuysStThomas SET " & _
            //    "StartDate = " & g_DST_ACCESS_ConvertDate(dtStartDate) & _
            //    ", EndDate = " & g_DST_ACCESS_ConvertDate(dtEndDate) & _
            //    ", PercentCompleted = " & oPercentage.Percent & _
            //    " WHERE ID = " & sRowKey.Replace("K", "")
            //    oConn.Open()
            //    oCmd = New OleDbCommand(sSQL, oConn)
            //    oCmd.ExecuteNonQuery()
            //    oConn.Close()
            //End Using
            else if (mp_yDataSourceType == E_DATASOURCETYPE.DST_XML)
            {
                //Dim oDataRow As DataRow = Nothing
                //oDataRow = mp_otb_GuysStThomas.Tables(1).Rows.Find(sRowKey.Replace("K", ""))
                //oDataRow("StartDate") = dtStartDate
                //oDataRow("EndDate") = dtEndDate
                //oDataRow("PercentCompleted") = oPercentage.Percent
                //mp_otb_GuysStThomas.WriteXml(g_GetAppLocation() & "\HPM_XML\tb_GuysStThomas.xml")
            }
            UpdateSummary(ref oNode);
        }

        private void InsertPredecessor(string PredecessorKey, string SuccessorKey, E_CONSTRAINTTYPE PredecessorType)
        {
            if (mp_yDataSourceType == E_DATASOURCETYPE.DST_ACCESS)
            {
            }
            //Using oConn As New OleDbConnection(g_DST_ACCESS_GetConnectionString())
            //    Dim oCmd As OleDbCommand = Nothing
            //    PredecessorKey = PredecessorKey.Replace("T", "")
            //    SuccessorKey = SuccessorKey.Replace("T", "")
            //    Dim sSQL As String = "INSERT INTO tb_GuysStThomas_Predecessors (lPredecessorID, lSuccessorID, yType) VALUES (" & PredecessorKey.Replace("T", "") & "," & SuccessorKey.Replace("T", "") & "," & PredecessorType & ")"
            //    oConn.Open()
            //    oCmd = New OleDbCommand(sSQL, oConn)
            //    oCmd.ExecuteNonQuery()
            //    oConn.Close()
            //End Using
            else if (mp_yDataSourceType == E_DATASOURCETYPE.DST_XML)
            {
                //Dim oDataRow As DataRow = Nothing
                //Dim oLastRow As DataRow = Nothing
                //oLastRow = mp_otb_GuysStThomas_Predecessors.Tables(1).Rows(mp_otb_GuysStThomas_Predecessors.Tables(1).Rows.Count - 1)
                //oDataRow = mp_otb_GuysStThomas_Predecessors.Tables(1).NewRow()
                //oDataRow("lID") = DirectCast(oLastRow.Item("ID"), System.Int32) + 1
                //oDataRow("lPredecessorID") = PredecessorKey.Replace("T", "")
                //oDataRow("lSuccessorID") = SuccessorKey.Replace("T", "")
                //oDataRow("yType") = PredecessorType
                //mp_otb_GuysStThomas_Predecessors.Tables(1).Rows.Add(oDataRow)
                //mp_otb_GuysStThomas_Predecessors.WriteXml(g_GetAppLocation() & "\HPM_XML\tb_GuysStThomas_Predecessors.xml")
            }
        }

        private void UpdateSummary(ref clsNode oNode)
        {
            //Dim oConn As OleDbConnection = Nothing
            //Dim oCmd As OleDbCommand = Nothing
            clsNode oParentNode = null;
            clsTask oSummaryTask = null;
            clsPercentage oSummaryPercentage = null;
            if (mp_yDataSourceType == E_DATASOURCETYPE.DST_ACCESS)
            {
                //oConn = New OleDbConnection(g_DST_ACCESS_GetConnectionString())
                //oConn.Open()
            }
            oParentNode = oNode.Parent();
            while ((oParentNode != null))
            {
                oSummaryTask = GetTaskByRowKey(oParentNode.Row.Key);
                oSummaryPercentage = GetPercentageByTaskKey(oSummaryTask.Key);
                if ((oSummaryTask != null))
                {
                    clsTask oChildTask = null;
                    clsPercentage oChildPercentage = null;
                    clsNode oChildNode = null;
                    AGCSE.DateTime dtSumStartDate = new AGCSE.DateTime();
                    AGCSE.DateTime dtSumEndDate = new AGCSE.DateTime();
                    int lPercentagesCount = 0;
                    float fPercentagesSum = 0;
                    float fPercentageAvg = 0;
                    oChildNode = oParentNode.Child();
                    while ((oChildNode != null))
                    {
                        oChildTask = GetTaskByRowKey(oChildNode.Row.Key);
                        oChildPercentage = GetPercentageByTaskKey(oChildTask.Key);
                        lPercentagesCount = lPercentagesCount + 1;
                        fPercentagesSum = fPercentagesSum + oChildPercentage.Percent;
                        if ((oChildTask != null))
                        {
                            if (dtSumStartDate.DateTimePart.Ticks == 0)
                            {
                                dtSumStartDate = oChildTask.StartDate;
                            }
                            else
                            {
                                if (oChildTask.StartDate < dtSumStartDate)
                                {
                                    dtSumStartDate = oChildTask.StartDate;
                                }
                            }
                            if (dtSumEndDate.DateTimePart.Ticks == 0)
                            {
                                dtSumEndDate = oChildTask.EndDate;
                            }
                            else
                            {
                                if (oChildTask.EndDate > dtSumEndDate)
                                {
                                    dtSumEndDate = oChildTask.EndDate;
                                }
                            }
                        }
                        oChildNode = oChildNode.NextSibling();
                    }
                    fPercentageAvg = fPercentagesSum / lPercentagesCount;
                    oSummaryTask.StartDate = dtSumStartDate;
                    oSummaryTask.EndDate = dtSumEndDate;
                    SetTaskGridColumns(oSummaryTask);
                    oSummaryPercentage.Percent = fPercentageAvg;
                    if (mp_yDataSourceType == E_DATASOURCETYPE.DST_ACCESS)
                    {
                    }
                    //sSQL = "UPDATE tb_GuysStThomas SET " & _
                    //"StartDate = " & g_DST_ACCESS_ConvertDate(dtSumStartDate) & _
                    //", EndDate = " & g_DST_ACCESS_ConvertDate(dtSumEndDate) & _
                    //", PercentCompleted = " & oSummaryPercentage.Percent & _
                    //" WHERE ID = " & oSummaryTask.RowKey.Replace("K", "")
                    //oCmd = New OleDbCommand(sSQL, oConn)
                    //oCmd.ExecuteNonQuery()
                    else if (mp_yDataSourceType == E_DATASOURCETYPE.DST_XML)
                    {
                        //Dim oDataRow As DataRow = Nothing
                        //oDataRow = mp_otb_GuysStThomas.Tables(1).Rows.Find(oSummaryTask.RowKey.Replace("K", ""))
                        //oDataRow("StartDate") = dtSumStartDate
                        //oDataRow("EndDate") = dtSumEndDate
                        //oDataRow("PercentCompleted") = oSummaryPercentage.Percent
                        //mp_otb_GuysStThomas.WriteXml(g_GetAppLocation() & "\HPM_XML\tb_GuysStThomas.xml")
                    }
                }
                oParentNode = oParentNode.Parent();
            }

            if (mp_yDataSourceType == E_DATASOURCETYPE.DST_ACCESS)
            {
                //oConn.Close()
            }

        }

        private clsTask GetTaskByRowKey(string sRowKey)
        {
            int i = 0;
            clsTask oTask = null;
            for (i = 1; i <= ActiveGanttCSECtl1.Tasks.Count; i++)
            {
                oTask = ActiveGanttCSECtl1.Tasks.Item(i.ToString());
                if (oTask.RowKey == sRowKey)
                {
                    return oTask;
                }
            }
            return null;
        }

        private clsPercentage GetPercentageByTaskKey(string sTaskKey)
        {
            int i = 0;
            clsPercentage oPercentage;
            for (i = 1; i <= ActiveGanttCSECtl1.Percentages.Count; i++)
            {
                oPercentage = ActiveGanttCSECtl1.Percentages.Item(i.ToString());
                if (oPercentage.TaskKey == sTaskKey)
                {
                    return oPercentage;
                }
            }
            return null;
        }

        private Image GetImage(string sImage)
        {
            Image oReturnImage = new Image();
            System.Uri oURI = new System.Uri("AGCSECON;component/Images/WBS/" + sImage, UriKind.Relative);
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

        #region "cmdSave"

        private void cmdSaveXML_Click(object sender, RoutedEventArgs e)
        {
            mp_fSave = new fSave();
            mp_fSave.Closed += mp_fSave_Closed;
            mp_fSave.sSuggestedFileName = "AGCSE_WBSP";
            mp_fSave.Title = "Save XML File";
            mp_fSave.mp_oFileList = mp_oFileList;
            mp_fSave.Show();
        }

        private void mp_fSave_Closed(object sender, System.EventArgs e)
        {
            if (mp_fSave.DialogResult == true)
            {
                string sXML = "";
                sXML = ActiveGanttCSECtl1.GetXML();
                if (sXML.Length > 0)
                {
                    invkSetXML = oServiceContext.SetXML(sXML, mp_fSave.sFileName);
                    cmdSaveXML.IsEnabled = false;
                    invkSetXML.Completed += invkSetXML_Completed;
                }
            }
        }

        private void invkSetXML_Completed(object sender, System.EventArgs e)
        {
            invkGetFileList = oServiceContext.GetFileList();
            invkGetFileList.Completed += invkGetFileList_Completed;
            cmdSaveXML.IsEnabled = true;
        }

        #endregion

        private void cmdLoadXML_Click(object sender, RoutedEventArgs e)
        {
            fLoadXML oForm = new fLoadXML();
            this.Content = oForm;
        }

        private void cmdBack_Click(object sender, RoutedEventArgs e)
        {
            fMain oForm = new fMain();
            this.Content = oForm;
        }

        private void cmdZoomin_Click(object sender, RoutedEventArgs e)
        {
            if (System.Convert.ToInt32(ActiveGanttCSECtl1.CurrentView) < 3)
            {
                ActiveGanttCSECtl1.CurrentView = (System.Convert.ToInt32(ActiveGanttCSECtl1.CurrentView) + 1).ToString();
                ActiveGanttCSECtl1.Redraw();
            }
        }

        private void cmdZoomout_Click(object sender, RoutedEventArgs e)
        {
            if (System.Convert.ToInt32(ActiveGanttCSECtl1.CurrentView) > 1)
            {
                ActiveGanttCSECtl1.CurrentView = (System.Convert.ToInt32(ActiveGanttCSECtl1.CurrentView) - 1).ToString();
                ActiveGanttCSECtl1.Redraw();
            }
        }

        private void cmdBluePercentages_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            clsPercentage oPercentage;
            mp_bBluePercentagesVisible = !mp_bBluePercentagesVisible;
            for (i = 1; i <= ActiveGanttCSECtl1.Percentages.Count; i++)
            {
                oPercentage = ActiveGanttCSECtl1.Percentages.Item(i.ToString());
                if (oPercentage.StyleIndex == "BluePercentages")
                {
                    oPercentage.Visible = mp_bBluePercentagesVisible;
                }
            }
            ActiveGanttCSECtl1.Redraw();
        }

        private void cmdGreenPercentages_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            clsPercentage oPercentage;
            mp_bGreenPercentagesVisible = !mp_bGreenPercentagesVisible;
            for (i = 1; i <= ActiveGanttCSECtl1.Percentages.Count; i++)
            {
                oPercentage = ActiveGanttCSECtl1.Percentages.Item(i.ToString());
                if (oPercentage.StyleIndex == "GreenPercentages")
                {
                    oPercentage.Visible = mp_bGreenPercentagesVisible;
                }
            }
            ActiveGanttCSECtl1.Redraw();
        }

        private void cmdRedPercentages_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            clsPercentage oPercentage;
            mp_bRedPercentagesVisible = !mp_bRedPercentagesVisible;
            for (i = 1; i <= ActiveGanttCSECtl1.Percentages.Count; i++)
            {
                oPercentage = ActiveGanttCSECtl1.Percentages.Item(i.ToString());
                if (oPercentage.StyleIndex == "RedPercentages")
                {
                    oPercentage.Visible = mp_bRedPercentagesVisible;
                }
            }
            ActiveGanttCSECtl1.Redraw();
        }

        private void cmdProperties_Click(object sender, RoutedEventArgs e)
        {
            mp_fWBSPProperties.Show();
        }

        private void cmdCheck_Click(object sender, RoutedEventArgs e)
        {
            ActiveGanttCSECtl1.CheckPredecessors();
            ActiveGanttCSECtl1.Redraw();
        }

        private void cmdHelp_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Browser.HtmlPage.Window.Navigate(new Uri("http://www.sourcecodestore.com/Article.aspx?ID=17"), "_blank");
        }

        #endregion

        #region "Load Data"

        public void NoDataSource_LoadTasks()
        {
            AddRow_Task(1, 0, "A", "Capital Plan", new AGCSE.DateTime(2007, 3, 8, 12, 0, 0), new AGCSE.DateTime(2007, 10, 19, 0, 0, 0), 0.4F, false, true);
            AddRow_Task(2, 0, "F", "Strategic Projects", new AGCSE.DateTime(2006, 11, 1, 12, 0, 0), new AGCSE.DateTime(2007, 9, 14, 0, 0, 0), 0.75F, true, true);
            AddRow_Task(3, 1, "F", "Infrastructure Work Team", new AGCSE.DateTime(2007, 2, 1, 12, 0, 0), new AGCSE.DateTime(2007, 9, 5, 0, 0, 0), 0.77F, true, true);
            AddRow_Task(4, 2, "A", "Guys Tower Façade Feasability", new AGCSE.DateTime(2007, 2, 1, 12, 0, 0), new AGCSE.DateTime(2007, 8, 1, 0, 0, 0), 0.6F, false, true);
            AddRow_Task(5, 2, "A", "East Wing Cladding (inc Ward Refurbisments)", new AGCSE.DateTime(2007, 4, 21, 0, 0, 0), new AGCSE.DateTime(2007, 9, 5, 0, 0, 0), 0.94F, false, true);
            AddRow_Task(6, 1, "F", "Modernisation Workstream", new AGCSE.DateTime(2007, 1, 22, 0, 0, 0), new AGCSE.DateTime(2007, 3, 27, 12, 0, 0), 0.72F, true, true);
            AddRow_Task(7, 2, "A", "A&E Reconfiguration", new AGCSE.DateTime(2007, 1, 22, 0, 0, 0), new AGCSE.DateTime(2007, 3, 27, 12, 0, 0), 0.69F, false, true);
            AddRow_Task(8, 2, "A", "St. Thomas Main Theatres Study", new AGCSE.DateTime(2007, 1, 28, 0, 0, 0), new AGCSE.DateTime(2007, 3, 18, 12, 0, 0), 0.75F, false, true);
            AddRow_Task(9, 1, "F", "Ambulatory Workstream", new AGCSE.DateTime(2007, 3, 9, 12, 0, 0), new AGCSE.DateTime(2007, 6, 5, 12, 0, 0), 0.73F, true, true);
            AddRow_Task(10, 2, "A", "PET Feasability", new AGCSE.DateTime(2007, 3, 9, 12, 0, 0), new AGCSE.DateTime(2007, 6, 5, 12, 0, 0), 0.73F, false, true);
            AddRow_Task(11, 1, "F", "Cancer Workstream", new AGCSE.DateTime(2006, 11, 1, 12, 0, 0), new AGCSE.DateTime(2007, 9, 14, 0, 0, 0), 0.78F, true, true);
            AddRow_Task(12, 2, "A", "Redevelopment of Guys Site Incorporating Cancer Feasability", new AGCSE.DateTime(2007, 1, 11, 0, 0, 0), new AGCSE.DateTime(2007, 8, 11, 12, 0, 0), 0.74F, false, true);
            AddRow_Task(13, 2, "A", "Radiotherapy and Chemotherapy Center", new AGCSE.DateTime(2006, 11, 1, 12, 0, 0), new AGCSE.DateTime(2007, 3, 30, 12, 0, 0), 0.94F, false, true);
            AddRow_Task(14, 2, "A", "Decant Facilities", new AGCSE.DateTime(2007, 5, 24, 12, 0, 0), new AGCSE.DateTime(2007, 9, 14, 0, 0, 0), 0.65F, false, true);
            AddRow_Task(15, 0, "F", "Capital Projects", new AGCSE.DateTime(2006, 9, 1, 12, 0, 0), new AGCSE.DateTime(2007, 12, 12, 0, 0, 0), 0.87F, true, true);
            AddRow_Task(16, 1, "A", "4th Floor Block & Refurbishment", new AGCSE.DateTime(2006, 9, 1, 12, 0, 0), new AGCSE.DateTime(2007, 2, 1, 0, 0, 0), 0.93F, false, true);
            AddRow_Task(17, 1, "A", "Bio Medical Research Center & CRF", new AGCSE.DateTime(2007, 3, 2, 0, 0, 0), new AGCSE.DateTime(2007, 7, 4, 0, 0, 0), 0.91F, false, true);
            AddRow_Task(18, 1, "A", "Blundell Ward Relocation Florence + Aston Key", new AGCSE.DateTime(2007, 8, 7, 12, 0, 0), new AGCSE.DateTime(2007, 11, 12, 12, 0, 0), 0.62F, false, true);
            AddRow_Task(19, 1, "A", "Bostock Ward Replacement of Water Treatment Plant", new AGCSE.DateTime(2007, 3, 7, 0, 0, 0), new AGCSE.DateTime(2007, 6, 23, 12, 0, 0), 0.84F, false, true);
            AddRow_Task(20, 1, "A", "Centralisation Health Record Storage", new AGCSE.DateTime(2007, 6, 22, 0, 0, 0), new AGCSE.DateTime(2007, 11, 12, 0, 0, 0), 0.78F, false, true);
            AddRow_Task(21, 1, "A", "ENT & Audiology Suite Phase II", new AGCSE.DateTime(2006, 12, 31, 12, 0, 0), new AGCSE.DateTime(2007, 3, 10, 0, 0, 0), 0.75F, false, true);
            AddRow_Task(22, 1, "A", "GLI Structural Monitoring & Repair", new AGCSE.DateTime(2007, 2, 12, 12, 0, 0), new AGCSE.DateTime(2007, 5, 9, 12, 0, 0), 0.91F, false, true);
            AddRow_Task(23, 1, "A", "Pathology Labs (Phase 1A)", new AGCSE.DateTime(2007, 4, 2, 0, 0, 0), new AGCSE.DateTime(2007, 10, 23, 0, 0, 0), 0.95F, false, true);
            AddRow_Task(24, 1, "A", "Pathology Labs (Phase 2)", new AGCSE.DateTime(2007, 1, 15, 0, 0, 0), new AGCSE.DateTime(2007, 7, 29, 12, 0, 0), 0.92F, false, true);
            AddRow_Task(25, 1, "A", "Pathology: NW5 - CSR Haematology & CSR Labs", new AGCSE.DateTime(2007, 4, 9, 0, 0, 0), new AGCSE.DateTime(2007, 9, 5, 0, 0, 0), 0.88F, false, true);
            AddRow_Task(26, 1, "A", "Pathology: Haematology Day Care Center Transfer (NW4 to GT4)", new AGCSE.DateTime(2006, 10, 19, 0, 0, 0), new AGCSE.DateTime(2007, 1, 12, 0, 0, 0), 0.85F, false, true);
            AddRow_Task(27, 1, "A", "HDR", new AGCSE.DateTime(2007, 6, 1, 0, 0, 0), new AGCSE.DateTime(2007, 9, 3, 0, 0, 0), 0.85F, false, true);
            AddRow_Task(28, 1, "A", "Kidney Treatment Center", new AGCSE.DateTime(2007, 6, 25, 0, 0, 0), new AGCSE.DateTime(2007, 11, 18, 0, 0, 0), 0.76F, false, true);
            AddRow_Task(29, 1, "A", "Maternity Expansion Business Case", new AGCSE.DateTime(2006, 11, 9, 12, 0, 0), new AGCSE.DateTime(2007, 4, 6, 0, 0, 0), 0.93F, false, true);
            AddRow_Task(30, 1, "A", "New Laminar Flow Theatre at Guy's", new AGCSE.DateTime(2007, 4, 25, 12, 0, 0), new AGCSE.DateTime(2007, 11, 29, 12, 0, 0), 0.89F, false, true);
            AddRow_Task(31, 1, "A", "North Wing Basement Entance - Phase 2", new AGCSE.DateTime(2007, 9, 7, 0, 0, 0), new AGCSE.DateTime(2007, 11, 30, 0, 0, 0), 0.88F, false, true);
            AddRow_Task(32, 1, "A", "Paediatric Neurosciences Feasibility", new AGCSE.DateTime(2006, 11, 29, 0, 0, 0), new AGCSE.DateTime(2007, 2, 10, 0, 0, 0), 0.9F, false, true);
            AddRow_Task(33, 1, "A", "Fluroscopy (Imaging 2) at St. Thomas", new AGCSE.DateTime(2007, 1, 24, 0, 0, 0), new AGCSE.DateTime(2007, 6, 8, 12, 0, 0), 0.94F, false, true);
            AddRow_Task(34, 1, "A", "Interventional Radiology Suite (Imaging 3) at GT3 Phase 1", new AGCSE.DateTime(2007, 6, 17, 0, 0, 0), new AGCSE.DateTime(2007, 12, 12, 0, 0, 0), 0.91F, false, true);
            AddRow_Task(35, 1, "A", "Interventional Radiology Suite (Imaging 3) at GT3 Phase 2", new AGCSE.DateTime(2007, 8, 12, 0, 0, 0), new AGCSE.DateTime(2007, 12, 1, 12, 0, 0), 0.92F, false, true);
            AddRow_Task(36, 1, "A", "Imaging: Radiology Environment & Waiting Areas (Imaging 2) Phases 1 & 2", new AGCSE.DateTime(2006, 11, 27, 12, 0, 0), new AGCSE.DateTime(2007, 1, 25, 12, 0, 0), 1.0F, false, true);
            AddRow_Task(37, 1, "A", "Imaging: Radiology Environment & Waiting Areas (Imaging 2) Phase 3", new AGCSE.DateTime(2006, 12, 21, 0, 0, 0), new AGCSE.DateTime(2007, 1, 9, 0, 0, 0), 1.0F, false, true);
            AddRow_Task(38, 1, "A", "Relocation of Pharmacy Manufacturing & QC Laboratories", new AGCSE.DateTime(2007, 6, 7, 12, 0, 0), new AGCSE.DateTime(2007, 8, 20, 12, 0, 0), 0.93F, false, true);
            AddRow_Task(39, 1, "A", "Samaritan Ward - Bone marrow transplant beds", new AGCSE.DateTime(2007, 6, 1, 0, 0, 0), new AGCSE.DateTime(2007, 8, 18, 0, 0, 0), 0.94F, false, true);
            AddRow_Task(40, 1, "A", "Sexual Health Relocation", new AGCSE.DateTime(2007, 1, 10, 12, 0, 0), new AGCSE.DateTime(2007, 4, 12, 12, 0, 0), 1.0F, false, true);
            AddRow_Task(41, 1, "A", "St. Thomas HV Upgrade", new AGCSE.DateTime(2007, 5, 2, 12, 0, 0), new AGCSE.DateTime(2007, 6, 20, 12, 0, 0), 0.52F, false, true);
            AddRow_Task(42, 1, "A", "Ultrasound (Imaging 2) at Guy's", new AGCSE.DateTime(2007, 6, 5, 12, 0, 0), new AGCSE.DateTime(2007, 6, 22, 12, 0, 0), 1.0F, false, true);
            AddRow_Task(43, 1, "F", "New Schemes Approved in Year", new AGCSE.DateTime(2006, 11, 15, 12, 0, 0), new AGCSE.DateTime(2007, 9, 4, 12, 0, 0), 0.78F, true, true);
            AddRow_Task(44, 2, "A", "Modular Theatres", new AGCSE.DateTime(2006, 11, 15, 12, 0, 0), new AGCSE.DateTime(2007, 1, 1, 12, 0, 0), 0.84F, false, true);
            AddRow_Task(45, 2, "A", "ECH - Theatre Ventilation", new AGCSE.DateTime(2006, 12, 24, 0, 0, 0), new AGCSE.DateTime(2007, 9, 4, 12, 0, 0), 0.77F, false, true);
            AddRow_Task(46, 2, "A", "Modular Pharmacy Aseptic Unit", new AGCSE.DateTime(2006, 12, 22, 12, 0, 0), new AGCSE.DateTime(2007, 1, 28, 12, 0, 0), 0.82F, false, true);
            AddRow_Task(47, 2, "A", "Acute Stroke Unit Bid", new AGCSE.DateTime(2007, 4, 11, 0, 0, 0), new AGCSE.DateTime(2007, 7, 20, 0, 0, 0), 0.74F, false, true);
            AddRow_Task(48, 2, "A", "Chemo Centralisation", new AGCSE.DateTime(2006, 12, 26, 0, 0, 0), new AGCSE.DateTime(2007, 3, 30, 0, 0, 0), 0.9F, false, true);
            AddRow_Task(49, 2, "A", "Feasability of MRI at Guy's", new AGCSE.DateTime(2007, 5, 12, 0, 0, 0), new AGCSE.DateTime(2007, 7, 25, 0, 0, 0), 0.59F, false, true);
            AddRow_Task(50, 0, "F", "Engineering", new AGCSE.DateTime(2006, 10, 17, 0, 0, 0), new AGCSE.DateTime(2007, 9, 15, 12, 0, 0), 0.7F, true, true);
            AddRow_Task(51, 1, "A", "Borough Wing Theatre Ductwork and Heater Batteries", new AGCSE.DateTime(2007, 5, 2, 0, 0, 0), new AGCSE.DateTime(2007, 6, 20, 0, 0, 0), 0.85F, false, true);
            AddRow_Task(52, 1, "A", "Combined Heat and Power System at Guy's", new AGCSE.DateTime(2007, 1, 20, 12, 0, 0), new AGCSE.DateTime(2007, 4, 15, 12, 0, 0), 0.88F, false, true);
            AddRow_Task(53, 1, "A", "Combined Heat and Power System at St. Thomas", new AGCSE.DateTime(2007, 3, 10, 12, 0, 0), new AGCSE.DateTime(2007, 9, 15, 12, 0, 0), 0.74F, false, true);
            AddRow_Task(54, 1, "A", "Electrical Power Monitoring", new AGCSE.DateTime(2006, 11, 20, 0, 0, 0), new AGCSE.DateTime(2007, 8, 22, 12, 0, 0), 0.88F, false, true);
            AddRow_Task(55, 1, "A", "Guy's Lifts 101-105 (Guys Tower)", new AGCSE.DateTime(2006, 12, 6, 0, 0, 0), new AGCSE.DateTime(2007, 3, 3, 0, 0, 0), 0.88F, false, true);
            AddRow_Task(56, 1, "A", "Guy's Lifts 110-114 (Guys Tower)", new AGCSE.DateTime(2007, 5, 15, 12, 0, 0), new AGCSE.DateTime(2007, 7, 1, 12, 0, 0), 0.5F, false, true);
            AddRow_Task(57, 1, "A", "Motor Control Panel Refurbishment", new AGCSE.DateTime(2007, 1, 9, 0, 0, 0), new AGCSE.DateTime(2007, 6, 13, 0, 0, 0), 0.7F, false, true);
            AddRow_Task(58, 1, "A", "North Wing / Lambeth Wing Air Supply Plants", new AGCSE.DateTime(2007, 1, 13, 0, 0, 0), new AGCSE.DateTime(2007, 4, 19, 0, 0, 0), 0.21F, false, true);
            AddRow_Task(59, 1, "A", "North Wing Chiller Replacement", new AGCSE.DateTime(2007, 1, 9, 0, 0, 0), new AGCSE.DateTime(2007, 6, 16, 0, 0, 0), 0.5F, false, true);
            AddRow_Task(60, 1, "A", "North Wing Replacement Generator", new AGCSE.DateTime(2006, 12, 10, 12, 0, 0), new AGCSE.DateTime(2007, 6, 11, 0, 0, 0), 0.76F, false, true);
            AddRow_Task(61, 1, "A", "NW/LW Riser Refurbishment", new AGCSE.DateTime(2007, 1, 20, 12, 0, 0), new AGCSE.DateTime(2007, 3, 17, 12, 0, 0), 0.5F, false, true);
            AddRow_Task(62, 1, "A", "Satchwell BMS Upgrade", new AGCSE.DateTime(2006, 12, 16, 12, 0, 0), new AGCSE.DateTime(2007, 7, 18, 12, 0, 0), 0.91F, false, true);
            AddRow_Task(63, 1, "A", "St. Thomas Increase Standby Capacity - Phase 2", new AGCSE.DateTime(2007, 1, 2, 0, 0, 0), new AGCSE.DateTime(2007, 6, 18, 0, 0, 0), 0.8F, false, true);
            AddRow_Task(64, 1, "A", "Substation 3 HV Works (St. Thomas)", new AGCSE.DateTime(2007, 2, 27, 0, 0, 0), new AGCSE.DateTime(2007, 8, 10, 12, 0, 0), 0.78F, false, true);
            AddRow_Task(65, 1, "A", "TB Electrical Distribution", new AGCSE.DateTime(2006, 10, 17, 0, 0, 0), new AGCSE.DateTime(2007, 6, 29, 12, 0, 0), 0.73F, false, true);
            AddRow_Task(66, 1, "A", "Tower Wing Dental Theatre Air Handling Unit", new AGCSE.DateTime(2006, 12, 30, 12, 0, 0), new AGCSE.DateTime(2007, 3, 24, 12, 0, 0), 0.75F, false, true);
            AddRow_Task(67, 1, "A", "Tower Wing Recovery Air Handling Unit", new AGCSE.DateTime(2007, 3, 2, 0, 0, 0), new AGCSE.DateTime(2007, 8, 8, 0, 0, 0), 0.7F, false, true);
            AddRow_Task(68, 1, "A", "Water Booster Pumps - Phase 1 & 2", new AGCSE.DateTime(2007, 1, 8, 12, 0, 0), new AGCSE.DateTime(2007, 6, 14, 12, 0, 0), 0.64F, false, true);
            AddRow_Task(69, 1, "A", "Water Softner - Boiler House", new AGCSE.DateTime(2007, 2, 12, 12, 0, 0), new AGCSE.DateTime(2007, 7, 30, 12, 0, 0), 0.66F, false, true);
            AddRow_Task(70, 1, "A", "Energy Efficiency", new AGCSE.DateTime(2007, 3, 31, 12, 0, 0), new AGCSE.DateTime(2007, 9, 4, 12, 0, 0), 0.72F, false, true);
            AddRow_Task(71, 0, "F", "PEAT Plan", new AGCSE.DateTime(2006, 11, 5, 0, 0, 0), new AGCSE.DateTime(2008, 1, 21, 0, 0, 0), 0.82F, true, true);
            AddRow_Task(72, 1, "A", "Hilliers Ward Refurb St. Thomas", new AGCSE.DateTime(2007, 3, 28, 0, 0, 0), new AGCSE.DateTime(2007, 5, 23, 12, 0, 0), 0.79F, false, true);
            AddRow_Task(73, 1, "A", "William Gull Ward St. Thomas", new AGCSE.DateTime(2007, 3, 20, 0, 0, 0), new AGCSE.DateTime(2007, 8, 23, 0, 0, 0), 0.77F, false, true);
            AddRow_Task(74, 1, "A", "Henry Ward Day Room", new AGCSE.DateTime(2007, 4, 29, 0, 0, 0), new AGCSE.DateTime(2007, 6, 1, 0, 0, 0), 0.8F, false, true);
            AddRow_Task(75, 1, "A", "Sarah Swift Ward", new AGCSE.DateTime(2006, 11, 5, 0, 0, 0), new AGCSE.DateTime(2007, 2, 3, 0, 0, 0), 0.78F, false, true);
            AddRow_Task(76, 1, "A", "Victoria Ward", new AGCSE.DateTime(2007, 5, 10, 12, 0, 0), new AGCSE.DateTime(2007, 7, 14, 12, 0, 0), 0.91F, false, true);
            AddRow_Task(77, 1, "A", "Appointment Center Staff Toilets", new AGCSE.DateTime(2007, 1, 16, 0, 0, 0), new AGCSE.DateTime(2007, 4, 7, 12, 0, 0), 0.77F, false, true);
            AddRow_Task(78, 1, "A", "Page Ward", new AGCSE.DateTime(2007, 5, 19, 12, 0, 0), new AGCSE.DateTime(2007, 7, 16, 12, 0, 0), 0.74F, false, true);
            AddRow_Task(79, 1, "A", "Nightingdale Ward - Side Rooms", new AGCSE.DateTime(2007, 2, 18, 0, 0, 0), new AGCSE.DateTime(2007, 4, 28, 0, 0, 0), 0.77F, false, true);
            AddRow_Task(80, 1, "A", "Luke Ward - Side Rooms", new AGCSE.DateTime(2007, 11, 14, 12, 0, 0), new AGCSE.DateTime(2007, 12, 31, 12, 0, 0), 0.8F, false, true);
            AddRow_Task(81, 1, "A", "Therapies Department - Disabled Toilets", new AGCSE.DateTime(2007, 7, 31, 12, 0, 0), new AGCSE.DateTime(2007, 9, 26, 12, 0, 0), 0.81F, false, true);
            AddRow_Task(82, 1, "A", "Northumberland Ward Side Rooms", new AGCSE.DateTime(2007, 4, 18, 0, 0, 0), new AGCSE.DateTime(2007, 6, 6, 0, 0, 0), 0.83F, false, true);
            AddRow_Task(83, 1, "A", "General Outpatients", new AGCSE.DateTime(2007, 10, 17, 0, 0, 0), new AGCSE.DateTime(2008, 1, 21, 0, 0, 0), 0.86F, false, true);
            AddRow_Task(84, 1, "A", "Rheumatology Clinic", new AGCSE.DateTime(2007, 5, 3, 0, 0, 0), new AGCSE.DateTime(2007, 5, 28, 0, 0, 0), 0.84F, false, true);
            AddRow_Task(85, 1, "A", "Diabetes Clinic", new AGCSE.DateTime(2007, 1, 8, 12, 0, 0), new AGCSE.DateTime(2007, 3, 18, 12, 0, 0), 0.86F, false, true);
            AddRow_Task(86, 1, "A", "ENT Clinic", new AGCSE.DateTime(2007, 4, 14, 12, 0, 0), new AGCSE.DateTime(2007, 10, 28, 12, 0, 0), 0.91F, false, true);
            AddRow_Task(87, 0, "F", "Buildings Improvement Programs", new AGCSE.DateTime(2006, 10, 18, 12, 0, 0), new AGCSE.DateTime(2007, 10, 28, 0, 0, 0), 0.75F, true, true);
            AddRow_Task(88, 1, "F", "Environmental Improvement Plan", new AGCSE.DateTime(2006, 10, 18, 12, 0, 0), new AGCSE.DateTime(2007, 10, 28, 0, 0, 0), 0.75F, false, false);
            AddRow_Task(89, 2, "A", "Ward Improvementrs", new AGCSE.DateTime(2006, 10, 18, 12, 0, 0), new AGCSE.DateTime(2007, 10, 15, 12, 0, 0), 0.61F, false, true);
            AddRow_Task(90, 2, "A", "Outpatient / Clinics", new AGCSE.DateTime(2006, 12, 29, 0, 0, 0), new AGCSE.DateTime(2007, 8, 11, 0, 0, 0), 0.74F, false, true);
            AddRow_Task(91, 2, "A", "Circulation Areas", new AGCSE.DateTime(2007, 4, 14, 12, 0, 0), new AGCSE.DateTime(2007, 10, 28, 0, 0, 0), 0.74F, false, true);
            AddRow_Task(92, 2, "A", "St. Thomas Main Entrance", new AGCSE.DateTime(2007, 2, 28, 0, 0, 0), new AGCSE.DateTime(2007, 6, 8, 0, 0, 0), 0.76F, false, true);
            AddRow_Task(93, 2, "A", "St. Thomas Retail Mall", new AGCSE.DateTime(2007, 1, 1, 0, 0, 0), new AGCSE.DateTime(2007, 2, 6, 0, 0, 0), 0.81F, false, true);
            AddRow_Task(94, 2, "A", "Guys Main Entrance Revolving Door", new AGCSE.DateTime(2007, 3, 28, 12, 0, 0), new AGCSE.DateTime(2007, 4, 25, 12, 0, 0), 0.83F, false, true);

            AddPredecessor(16, 17, E_CONSTRAINTTYPE.PCT_END_TO_START, 696, E_INTERVAL.IL_HOUR);     //End-To-Start with lag (down)
            AddPredecessor(13, 5, E_CONSTRAINTTYPE.PCT_END_TO_START, 516, E_INTERVAL.IL_HOUR);      //End-To-Start with lag (up)
            AddPredecessor(21, 22, E_CONSTRAINTTYPE.PCT_END_TO_START, -612, E_INTERVAL.IL_HOUR);    //End-To-Start with lead (down)
            AddPredecessor(24, 19, E_CONSTRAINTTYPE.PCT_END_TO_START, -3468, E_INTERVAL.IL_HOUR);   //End-To-Start with lead (up)

            AddPredecessor(18, 20, E_CONSTRAINTTYPE.PCT_START_TO_END, 2316, E_INTERVAL.IL_HOUR);    //Start-To-End with lag (down)
            AddPredecessor(29, 26, E_CONSTRAINTTYPE.PCT_START_TO_END, 1524, E_INTERVAL.IL_HOUR);    //Start-To-End with lag (up)
            AddPredecessor(27, 32, E_CONSTRAINTTYPE.PCT_START_TO_END, -2664, E_INTERVAL.IL_HOUR);   //Start-To-End with lead (down)
            AddPredecessor(38, 36, E_CONSTRAINTTYPE.PCT_START_TO_END, -3192, E_INTERVAL.IL_HOUR);   //Start-To-End with lead (up)

            AddPredecessor(12, 14, E_CONSTRAINTTYPE.PCT_START_TO_START, 3204, E_INTERVAL.IL_HOUR);  //Start-To-Start with lag (down)
            AddPredecessor(48, 47, E_CONSTRAINTTYPE.PCT_START_TO_START, 2544, E_INTERVAL.IL_HOUR);  //Start-To-Start with lag (up)
            AddPredecessor(52, 55, E_CONSTRAINTTYPE.PCT_START_TO_START, -1092, E_INTERVAL.IL_HOUR); //Start-To-Start with lead (down)
            AddPredecessor(56, 53, E_CONSTRAINTTYPE.PCT_START_TO_START, -1584, E_INTERVAL.IL_HOUR); //Start-To-Start with lead (up)

            AddPredecessor(40, 41, E_CONSTRAINTTYPE.PCT_END_TO_END, 1656, E_INTERVAL.IL_HOUR);      //End-To-End with lag (down)
            AddPredecessor(58, 57, E_CONSTRAINTTYPE.PCT_END_TO_END, 1320, E_INTERVAL.IL_HOUR);      //End-To-End with lag (up)
            AddPredecessor(62, 63, E_CONSTRAINTTYPE.PCT_END_TO_END, -732, E_INTERVAL.IL_HOUR);      //End-To-End with lead (down)
            AddPredecessor(67, 65, E_CONSTRAINTTYPE.PCT_END_TO_END, -948, E_INTERVAL.IL_HOUR);      //End-To-End with lead (up)

        }

        public void AddPredecessor(int lPredecessorID, int lSuccessorID, E_CONSTRAINTTYPE yType, int lLagFactor, E_INTERVAL yLagInterval)
        {
            clsPredecessor oPredecessor;
            oPredecessor = ActiveGanttCSECtl1.Predecessors.Add("T" + lSuccessorID.ToString(), "T" + lPredecessorID.ToString(), yType, "", "NormalTask");
            oPredecessor.WarningStyleIndex = "NormalTaskWarning";
            oPredecessor.SelectedStyleIndex = "SelectedPredecessor";
            oPredecessor.LagFactor = lLagFactor;
            oPredecessor.LagInterval = yLagInterval;
        }

        public void AddRow_Task(int lID, int lDepth, string sTaskType, string sDescription, AGCSE.DateTime dtStartDate, AGCSE.DateTime dtEndDate, float fPercentCompleted, bool bSummary, bool bHasTasks)
        {
            clsRow oRow = null;
            clsTask oTask = null;
            oRow = ActiveGanttCSECtl1.Rows.Add("K" + lID.ToString(), sDescription);
            oRow.Cells.Item("1").Text = lID.ToString();
            oRow.Cells.Item("1").StyleIndex = "CellStyleKeyColumn";
            oRow.Node.StyleIndex = "CellStyle";
            oRow.Cells.Item("3").StyleIndex = "CellStyle";
            oRow.Cells.Item("4").StyleIndex = "CellStyle";
            oRow.Height = 20;
            oRow.ClientAreaStyleIndex = "ClientAreaStyle";
            oRow.Node.AllowTextEdit = true;
            if (sTaskType == "F")
            {
                if (lDepth == 0)
                {
                    oRow.Node.Image = GetImage("folderclosed.png");
                    oRow.Node.ExpandedImage = GetImage("folderopen.png");
                    oRow.Node.StyleIndex = "NodeBold";
                }
                else
                {
                    oRow.Node.Image = GetImage("modules.png");
                    oRow.Node.StyleIndex = "NodeRegular";
                }
            }
            else if (sTaskType == "A")
            {
                oRow.Node.StyleIndex = "NodeRegular";
                oRow.Node.Image = GetImage("task.png");
                oRow.Node.CheckBoxVisible = true;
            }
            oRow.Node.Depth = lDepth;
            oRow.Node.ImageVisible = true;
            oRow.Node.AllowTextEdit = true;
            if ((mp_dtStartDate.DateTimePart.Ticks == 0))
            {
                mp_dtStartDate = dtStartDate;
            }
            else
            {
                if ((dtStartDate < mp_dtStartDate))
                {
                    mp_dtStartDate = dtStartDate;
                }
            }
            if ((mp_dtEndDate.DateTimePart.Ticks == 0))
            {
                mp_dtEndDate = dtEndDate;
            }
            else
            {
                if ((dtEndDate > mp_dtEndDate))
                {
                    mp_dtEndDate = dtEndDate;
                }
            }
            oTask = ActiveGanttCSECtl1.Tasks.Add("", "K" + lID, dtStartDate, dtEndDate, "T" + lID.ToString(), "", "");
            SetTaskGridColumns(oTask);
            if (bSummary == true)
            {
                //// Prevent user from moving/sizing summary tasks
                oTask.AllowedMovement = E_MOVEMENTTYPE.MT_MOVEMENTDISABLED;
                oTask.AllowStretchLeft = false;
                oTask.AllowStretchRight = false;
                //// Prevent user from adding tasks in these Rows
                oRow.Container = false;
                //// Apply Summary Style 
                if (oRow.Node.Depth == 0)
                {
                    oTask.StyleIndex = "RedSummary";
                    ActiveGanttCSECtl1.Percentages.Add("T" + lID.ToString(), "RedPercentages", fPercentCompleted, "");
                }
                else if (oRow.Node.Depth == 1)
                {
                    oTask.StyleIndex = "GreenSummary";
                    ActiveGanttCSECtl1.Percentages.Add("T" + lID.ToString(), "GreenPercentages", fPercentCompleted, "");
                }
                ActiveGanttCSECtl1.Percentages.Item(ActiveGanttCSECtl1.Percentages.Count.ToString()).AllowSize = false;
            }
            else
            {
                oTask.AllowedMovement = E_MOVEMENTTYPE.MT_RESTRICTEDTOROW;
                oTask.StyleIndex = "NormalTask";
                oTask.WarningStyleIndex = "NormalTaskWarning";
                if (bHasTasks == false)
                {
                    oTask.Visible = false;
                    //// Prevent user from adding tasks in these rows
                    oRow.Container = false;
                    ActiveGanttCSECtl1.Percentages.Add("T" + lID.ToString(), "InvisiblePercentages", fPercentCompleted, "");
                    ActiveGanttCSECtl1.Percentages.Item(ActiveGanttCSECtl1.Percentages.Count.ToString()).AllowSize = false;
                }
                else
                {
                    ActiveGanttCSECtl1.Percentages.Add("T" + lID.ToString(), "BluePercentages", fPercentCompleted, "");
                }
            }
        }

        private void SetTaskGridColumns(clsTask oTask)
        {
            oTask.Row.Cells.Item("3").Text = oTask.StartDate.ToString("MM/dd/yyyy");
            oTask.Row.Cells.Item("4").Text = oTask.EndDate.ToString("MM/dd/yyyy");
        }

        #endregion

    }
}
