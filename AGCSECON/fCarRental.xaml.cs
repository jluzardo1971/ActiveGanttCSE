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
using System.Windows.Controls.Primitives;
using System.ServiceModel.DomainServices.Client;
using AGCSECON.Web;

namespace AGCSECON
{
    public partial class fCarRental : Page
    {

        public enum HPE_ADDMODE
        {
            AM_RESERVATION = 0,
            AM_RENTAL = 1,
            AM_MAINTENANCE = 2
        }

        private HPE_ADDMODE mp_yAddMode = HPE_ADDMODE.AM_RENTAL;
        private string mp_sAddModeStyleIndex;
        private int mp_lZoom;
        private string mp_sEditRowKey;

        private string mp_sEditTaskKey;
        private const string mp_sFontName = "Tahoma";

        internal E_DATASOURCETYPE mp_yDataSourceType;
        internal List<AG_CR_Row> mp_o_AG_CR_Rows;

        internal List<AG_CR_Rental> mp_o_AG_CR_Rentals;
        internal List<AG_CR_Car_Type> mp_o_AG_CR_Car_Types;
        internal List<AG_CR_US_State> mp_o_AG_CR_US_States;
        internal List<AG_CR_ACRISS_Code> mp_o_AG_CR_ACRISS_Codes;
        internal List<AG_CR_ACRISS_Code> mp_o_AG_CR_ACRISS_Codes_1;
        internal List<AG_CR_ACRISS_Code> mp_o_AG_CR_ACRISS_Codes_2;
        internal List<AG_CR_ACRISS_Code> mp_o_AG_CR_ACRISS_Codes_3;
        internal List<AG_CR_ACRISS_Code> mp_o_AG_CR_ACRISS_Codes_4;
        internal List<AG_CR_Tax_Surcharge_Option> mp_o_AG_CR_Taxes_Surcharges_Options;

        private fCarRentalBranch mp_fCarRentalBranch;
        private fCarRentalReservation mp_fCarRentalReservation;
        private fCarRentalVehicle mp_fCarRentalVehicle;
        private fYesNoMsgBox mp_fYesNoMsgBox;

        private Point mp_oCursorPosition;
        private Popup mp_oTaskPopUp;
        private StackPanel mp_oTaskStackPanel;
        private TextBlock mp_mnuEditTask;
        private TextBlock mp_mnuDeleteTask;

        private TextBlock mp_mnuConvertToRental;
        private Popup mp_oRowPopUp;
        private StackPanel mp_oRowStackPanel;
        private TextBlock mp_mnuEditRow;
        private TextBlock mp_mnuDeleteRow;

        private InvokeOperation<string> invkGetFileList;
        private InvokeOperation invkSetXML;
        ActiveGanttXMLContext oServiceContext = new ActiveGanttXMLContext();
        private List<CON_File> mp_oFileList;
        private fSave mp_fSave;

        #region "Constructors"

        public fCarRental()
        {
            InitializeComponent();
            mp_o_AG_CR_Rows = new List<AG_CR_Row>();
            mp_o_AG_CR_Rentals = new List<AG_CR_Rental>();
            mp_o_AG_CR_Car_Types = new List<AG_CR_Car_Type>();
            mp_o_AG_CR_US_States = new List<AG_CR_US_State>();
            mp_o_AG_CR_ACRISS_Codes = new List<AG_CR_ACRISS_Code>();
            mp_o_AG_CR_ACRISS_Codes_1 = new List<AG_CR_ACRISS_Code>();
            mp_o_AG_CR_ACRISS_Codes_2 = new List<AG_CR_ACRISS_Code>();
            mp_o_AG_CR_ACRISS_Codes_3 = new List<AG_CR_ACRISS_Code>();
            mp_o_AG_CR_ACRISS_Codes_4 = new List<AG_CR_ACRISS_Code>();
            mp_o_AG_CR_Taxes_Surcharges_Options = new List<AG_CR_Tax_Surcharge_Option>();
            mp_fCarRentalBranch = new fCarRentalBranch(this);
            mp_fCarRentalReservation = new fCarRentalReservation(this);
            mp_fCarRentalVehicle = new fCarRentalVehicle(this);
            mp_fYesNoMsgBox = new fYesNoMsgBox();
            mp_fYesNoMsgBox.Closed += YesNoMsgBox_Closed;
        }

        #endregion

        #region "Page Loaded"

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            InitRowContextMenu();
            InitTaskContextMenu();

            invkGetFileList = oServiceContext.GetFileList();
            invkGetFileList.Completed += invkGetFileList_Completed;

            if (mp_yDataSourceType == E_DATASOURCETYPE.DST_XML)
            {
                //Globals.g_VerifyWriteAccess("CR_XML");
                //XML_Load_Car_Types();
                //XML_Load_US_States();
                //XML_Load_ACRISS_Codes();
                //XML_Load_Taxes_Surcharges_Options();
            }
            else if (mp_yDataSourceType == E_DATASOURCETYPE.DST_NONE)
            {
                NoDataSource_Load_Car_Types();
                NoDataSource_Load_US_States();
                NoDataSource_Load_ACRISS_Codes(mp_o_AG_CR_ACRISS_Codes, 0);
                NoDataSource_Load_ACRISS_Codes(mp_o_AG_CR_ACRISS_Codes_1, 1);
                NoDataSource_Load_ACRISS_Codes(mp_o_AG_CR_ACRISS_Codes_2, 2);
                NoDataSource_Load_ACRISS_Codes(mp_o_AG_CR_ACRISS_Codes_3, 3);
                NoDataSource_Load_ACRISS_Codes(mp_o_AG_CR_ACRISS_Codes_4, 4);
                NoDataSource_Load_Taxes_Surcharges_Options();
            }


            clsStyle oStyle = null;
            clsView oView = null;
            clsTimeBlock oTimeBlock = null;

            oStyle = ActiveGanttCSECtl1.Styles.Add("ScrollBar");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = Colors.White;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = Color.FromArgb(255, 150, 158, 168);

            oStyle = ActiveGanttCSECtl1.Styles.Add("ArrowButtons");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = Colors.White;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = Color.FromArgb(255, 150, 158, 168);

            oStyle = ActiveGanttCSECtl1.Styles.Add("ThumbButton");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = Colors.White;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = Color.FromArgb(255, 138, 145, 153);

            oStyle = ActiveGanttCSECtl1.Styles.Add("SplitterStyle");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
            oStyle.StartGradientColor = Color.FromArgb(255, 109, 122, 136);
            oStyle.EndGradientColor = Color.FromArgb(255, 220, 220, 220);

            oStyle = ActiveGanttCSECtl1.Styles.Add("Columns");
            oStyle.Font = new Font(mp_sFontName, 8, E_FONTSIZEUNITS.FSU_POINTS, System.Windows.FontWeights.Bold);
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
            oStyle.StartGradientColor = Color.FromArgb(255, 148, 164, 189);
            oStyle.EndGradientColor = Color.FromArgb(255, 178, 199, 228);
            oStyle.ForeColor = Colors.White;
            oStyle.BorderColor = Colors.Black;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.CustomBorderStyle.Left = false;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.TextAlignmentVertical = GRE_VERTICALALIGNMENT.VAL_BOTTOM;

            oStyle = ActiveGanttCSECtl1.Styles.Add("TimeLine");
            oStyle.Font = new Font(mp_sFontName, 7, E_FONTSIZEUNITS.FSU_POINTS, System.Windows.FontWeights.Normal);
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
            oStyle.StartGradientColor = Color.FromArgb(255, 148, 164, 189);
            oStyle.EndGradientColor = Color.FromArgb(255, 178, 199, 228);
            oStyle.ForeColor = Colors.White;
            oStyle.BorderColor = Colors.Black;
            oStyle.CustomBorderStyle.Left = true;
            oStyle.CustomBorderStyle.Top = true;
            oStyle.CustomBorderStyle.Right = false;
            oStyle.CustomBorderStyle.Bottom = true;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;

            oStyle = ActiveGanttCSECtl1.Styles.Add("TimeLineVA");
            oStyle.Font = new Font(mp_sFontName, 7, E_FONTSIZEUNITS.FSU_POINTS, System.Windows.FontWeights.Normal);
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
            oStyle.StartGradientColor = Color.FromArgb(255, 148, 164, 189);
            oStyle.EndGradientColor = Color.FromArgb(255, 178, 199, 228);
            oStyle.ForeColor = Colors.White;
            oStyle.BorderColor = Colors.Black;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.DrawTextInVisibleArea = true;

            oStyle = ActiveGanttCSECtl1.Styles.Add("Branch");
            oStyle.Font = new Font(mp_sFontName, 9, E_FONTSIZEUNITS.FSU_POINTS, System.Windows.FontWeights.Normal);
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
            oStyle.StartGradientColor = Color.FromArgb(255, 109, 122, 136);
            oStyle.EndGradientColor = Color.FromArgb(255, 179, 199, 229);
            oStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_LEFT;
            oStyle.TextAlignmentVertical = GRE_VERTICALALIGNMENT.VAL_TOP;
            oStyle.TextXMargin = 5;
            oStyle.TextYMargin = 5;
            oStyle.ForeColor = Colors.White;
            oStyle.BorderColor = Colors.Black;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.ImageAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_RIGHT;
            oStyle.ImageAlignmentVertical = GRE_VERTICALALIGNMENT.VAL_BOTTOM;
            oStyle.ImageXMargin = 5;
            oStyle.ImageYMargin = 5;
            oStyle.UseMask = false;

            oStyle = ActiveGanttCSECtl1.Styles.Add("BranchCA");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
            oStyle.StartGradientColor = Color.FromArgb(255, 109, 122, 136);
            oStyle.EndGradientColor = Color.FromArgb(255, 179, 199, 229);
            oStyle.ForeColor = Colors.White;

            oStyle = ActiveGanttCSECtl1.Styles.Add("Weekend");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_HORIZONTAL;
            oStyle.StartGradientColor = Color.FromArgb(255, 133, 143, 154);
            oStyle.EndGradientColor = Color.FromArgb(255, 172, 183, 194);

            oStyle = ActiveGanttCSECtl1.Styles.Add("Reservation");
            oStyle.Font = new Font(mp_sFontName, 7, E_FONTSIZEUNITS.FSU_POINTS, System.Windows.FontWeights.Normal);
            oStyle.ForeColor = Colors.White;
            oStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_LEFT;
            oStyle.TextAlignmentVertical = GRE_VERTICALALIGNMENT.VAL_TOP;
            oStyle.TextXMargin = 5;
            oStyle.SelectionRectangleStyle.OffsetTop = 0;
            oStyle.SelectionRectangleStyle.OffsetBottom = 0;
            oStyle.SelectionRectangleStyle.OffsetLeft = 0;
            oStyle.SelectionRectangleStyle.OffsetRight = 0;
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_HORIZONTAL;
            oStyle.StartGradientColor = Color.FromArgb(255, 109, 122, 136);
            oStyle.EndGradientColor = Color.FromArgb(255, 179, 199, 229);

            oStyle = ActiveGanttCSECtl1.Styles.Add("Rental");
            oStyle.Font = new Font(mp_sFontName, 7, E_FONTSIZEUNITS.FSU_POINTS, System.Windows.FontWeights.Normal);
            oStyle.ForeColor = Colors.White;
            oStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_LEFT;
            oStyle.TextAlignmentVertical = GRE_VERTICALALIGNMENT.VAL_TOP;
            oStyle.TextXMargin = 5;
            oStyle.SelectionRectangleStyle.OffsetTop = 0;
            oStyle.SelectionRectangleStyle.OffsetBottom = 0;
            oStyle.SelectionRectangleStyle.OffsetLeft = 0;
            oStyle.SelectionRectangleStyle.OffsetRight = 0;
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_HORIZONTAL;
            oStyle.StartGradientColor = Color.FromArgb(255, 162, 78, 50);
            oStyle.EndGradientColor = Color.FromArgb(255, 215, 92, 54);

            oStyle = ActiveGanttCSECtl1.Styles.Add("Maintenance");
            oStyle.Font = new Font(mp_sFontName, 7, E_FONTSIZEUNITS.FSU_POINTS, System.Windows.FontWeights.Normal);
            oStyle.ForeColor = Colors.White;
            oStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_LEFT;
            oStyle.TextAlignmentVertical = GRE_VERTICALALIGNMENT.VAL_TOP;
            oStyle.TextXMargin = 5;
            oStyle.SelectionRectangleStyle.OffsetTop = 0;
            oStyle.SelectionRectangleStyle.OffsetBottom = 0;
            oStyle.SelectionRectangleStyle.OffsetLeft = 0;
            oStyle.SelectionRectangleStyle.OffsetRight = 0;
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_HORIZONTAL;
            oStyle.StartGradientColor = Color.FromArgb(255, 255, 77, 1);
            oStyle.EndGradientColor = Color.FromArgb(255, 244, 172, 43);

            ActiveGanttCSECtl1.ControlTag = "CarRental";
            ActiveGanttCSECtl1.Columns.Add("", "", 45, "Columns");
            ActiveGanttCSECtl1.Columns.Add("", "", 95, "Columns");
            ActiveGanttCSECtl1.Columns.Add("", "", 250, "Columns");

            ActiveGanttCSECtl1.Splitter.Position = 340;
            ActiveGanttCSECtl1.Splitter.Type = E_SPLITTERTYPE.SA_STYLE;
            ActiveGanttCSECtl1.Splitter.Width = 6;
            ActiveGanttCSECtl1.Splitter.StyleIndex = "SplitterStyle";

            ActiveGanttCSECtl1.ScrollBarSeparator.StyleIndex = "ScrollBar";

            ActiveGanttCSECtl1.VerticalScrollBar.ScrollBar.StyleIndex = "ScrollBar";
            ActiveGanttCSECtl1.VerticalScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "ArrowButtons";
            ActiveGanttCSECtl1.VerticalScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "ArrowButtons";
            ActiveGanttCSECtl1.VerticalScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "ArrowButtons";
            ActiveGanttCSECtl1.VerticalScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "ThumbButton";
            ActiveGanttCSECtl1.VerticalScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "ThumbButton";
            ActiveGanttCSECtl1.VerticalScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "ThumbButton";

            ActiveGanttCSECtl1.HorizontalScrollBar.ScrollBar.StyleIndex = "ScrollBar";
            ActiveGanttCSECtl1.HorizontalScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "ArrowButtons";
            ActiveGanttCSECtl1.HorizontalScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "ArrowButtons";
            ActiveGanttCSECtl1.HorizontalScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "ArrowButtons";
            ActiveGanttCSECtl1.HorizontalScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "ThumbButton";
            ActiveGanttCSECtl1.HorizontalScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "ThumbButton";
            ActiveGanttCSECtl1.HorizontalScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "ThumbButton";

            oTimeBlock = ActiveGanttCSECtl1.TimeBlocks.Add("");
            oTimeBlock.TimeBlockType = E_TIMEBLOCKTYPE.TBT_RECURRING;
            oTimeBlock.RecurringType = E_RECURRINGTYPE.RCT_WEEK;
            oTimeBlock.BaseWeekDay = E_WEEKDAY.WD_FRIDAY;
            oTimeBlock.BaseDate = new AGCSE.DateTime(2013, 1, 1, 0, 0, 0);
            oTimeBlock.DurationFactor = 48;
            oTimeBlock.DurationInterval = E_INTERVAL.IL_HOUR;
            oTimeBlock.StyleIndex = "Weekend";

            oView = ActiveGanttCSECtl1.Views.Add(E_INTERVAL.IL_MINUTE, 30, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM, "");
            oView.TimeLine.TierArea.UpperTier.Height = 17;
            oView.TimeLine.TierArea.UpperTier.Interval = E_INTERVAL.IL_MONTH;
            oView.TimeLine.TierArea.UpperTier.Factor = 1;
            oView.TimeLine.TierArea.MiddleTier.Height = 17;
            oView.TimeLine.TierArea.MiddleTier.Interval = E_INTERVAL.IL_DAY;
            oView.TimeLine.TierArea.MiddleTier.Factor = 1;
            oView.TimeLine.TierArea.MiddleTier.Visible = true;
            oView.TimeLine.TierArea.LowerTier.Interval = E_INTERVAL.IL_HOUR;
            oView.TimeLine.TierArea.LowerTier.Factor = 12;
            oView.TimeLine.TierArea.LowerTier.Height = 17;
            oView.TimeLine.TickMarkArea.Visible = false;
            oView.TimeLine.TickMarkArea.StyleIndex = "TimeLine";
            oView.TimeLine.Style.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oView.TimeLine.Style.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oView.TimeLine.Style.BackColor = Colors.Black;
            oView.ClientArea.Grid.VerticalLines = true;
            oView.ClientArea.Grid.SnapToGrid = true;
            ActiveGanttCSECtl1.CurrentView = oView.Index.ToString();
            Zoom = 5;

            if (mp_yDataSourceType == E_DATASOURCETYPE.DST_ACCESS)
            {
                //Access_LoadRowsAndTasks();
            }
            else if (mp_yDataSourceType == E_DATASOURCETYPE.DST_XML)
            {
                //XML_LoadRowsAndTasks();
            }
            else if (mp_yDataSourceType == E_DATASOURCETYPE.DST_NONE)
            {
                NoDataSource_LoadRowsAndTasks();
            }
            ActiveGanttCSECtl1.Rows.UpdateTree();

            Mode = HPE_ADDMODE.AM_RESERVATION;

            ActiveGanttCSECtl1.CurrentViewObject.TimeLine.Position(new AGCSE.DateTime(2009, 6, 9));
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
            if (e.Interval == E_INTERVAL.IL_HOUR & e.Factor == 12)
            {
                e.Text = e.StartDate.ToString("tt").ToUpper();
                e.StyleIndex = "TimeLine";
            }
            if (e.Interval == E_INTERVAL.IL_MONTH & e.Factor == 1)
            {
                e.Text = e.StartDate.ToString("MMMM yyyy");
                e.StyleIndex = "TimeLineVA";
            }
            if (e.Interval == E_INTERVAL.IL_DAY & e.Factor == 1)
            {
                e.Text = e.StartDate.ToString("ddd d");
                e.StyleIndex = "TimeLine";
            }
        }

        private void ActiveGanttCSECtl1_ObjectAdded(object sender, AGCSE.ObjectAddedEventArgs e)
        {
            switch (e.EventTarget)
            {
                case E_EVENTTARGET.EVT_TASK:
                    clsTask oTask = null;
                    int lTaskID = 0;
                    oTask = ActiveGanttCSECtl1.Tasks.Item(e.TaskIndex.ToString());
                    oTask.StyleIndex = mp_sAddModeStyleIndex;
                    oTask.Tag = mp_yAddMode.ToString();
                    if (Mode == HPE_ADDMODE.AM_RESERVATION)
                    {
                        mp_fCarRentalReservation.Mode = PRG_DIALOGMODE.DM_ADD;
                        mp_fCarRentalReservation.mp_sTaskID = oTask.Key.Replace("K", "");
                        mp_fCarRentalReservation.Show();
                    }
                    else if (Mode == HPE_ADDMODE.AM_RENTAL)
                    {
                        mp_fCarRentalReservation.Mode = PRG_DIALOGMODE.DM_ADD;
                        mp_fCarRentalReservation.mp_sTaskID = oTask.Key.Replace("K", "");
                        mp_fCarRentalReservation.Show();
                    }
                    else if (Mode == HPE_ADDMODE.AM_MAINTENANCE)
                    {
                        if (mp_yDataSourceType == E_DATASOURCETYPE.DST_ACCESS)
                        {
                        }
                        ////TODO
                        else if (mp_yDataSourceType == E_DATASOURCETYPE.DST_XML)
                        {
                        }
                        ////TODO
                        else if (mp_yDataSourceType == E_DATASOURCETYPE.DST_NONE)
                        {
                            foreach (AG_CR_Rental oRental in mp_o_AG_CR_Rentals)
                            {
                                if (oRental.lTaskID > lTaskID)
                                {
                                    lTaskID = oRental.lTaskID;
                                }
                            }
                            {
                                AG_CR_Rental oRental;
                                lTaskID = lTaskID + 1;
                                oRental = new AG_CR_Rental();
                                oRental.lRowID = System.Convert.ToInt32(oTask.RowKey.Replace("K", ""));
                                oRental.yMode = 2;
                                oRental.dtPickUp = oTask.StartDate.DateTimePart;
                                oRental.dtReturn = oTask.EndDate.DateTimePart;
                                oRental.bGPS = false;
                                oRental.bFSO = false;
                                oRental.bLDW = false;
                                oRental.bPAI = false;
                                oRental.bPEP = false;
                                oRental.bALI = false;
                                oRental.lTaskID = lTaskID;
                                mp_o_AG_CR_Rentals.Add(oRental);
                                oTask.Key = "K" + lTaskID.ToString();
                                oTask.Text = "Scheduled Maintenance";
                                oTask.Tag = System.Convert.ToString(System.Convert.ToInt32(HPE_ADDMODE.AM_MAINTENANCE));
                            }
                        }
                    }

                    break;
            }
        }

        private void ActiveGanttCSECtl1_CompleteObjectMove(object sender, AGCSE.ObjectStateChangedEventArgs e)
        {
            switch (e.EventTarget)
            {
                case E_EVENTTARGET.EVT_TASK:
                    clsTask oTask = null;
                    oTask = ActiveGanttCSECtl1.Tasks.Item(e.Index.ToString());
                    CalculateRate(ref oTask);
                    break;
                case E_EVENTTARGET.EVT_ROW:
                    int i = 0;
                    clsRow oRow = null;
                    for (i = 1; i <= ActiveGanttCSECtl1.Rows.Count; i++)
                    {
                        oRow = ActiveGanttCSECtl1.Rows.Item(i.ToString());
                        if (mp_yDataSourceType == E_DATASOURCETYPE.DST_ACCESS)
                        {
                        }
                        ////TODO
                        else if (mp_yDataSourceType == E_DATASOURCETYPE.DST_XML)
                        {
                        }
                        ////TODO
                        else if (mp_yDataSourceType == E_DATASOURCETYPE.DST_NONE)
                        {
                            foreach (AG_CR_Row oCRRow in mp_o_AG_CR_Rows)
                            {
                                if (oCRRow.lRowID == System.Convert.ToInt32(oRow.Key.Replace("K", "")))
                                {
                                    oCRRow.lOrder = i;
                                    break;
                                }
                            }

                        }
                    }

                    break;
            }
        }

        private void ActiveGanttCSECtl1_CompleteObjectSize(object sender, AGCSE.ObjectStateChangedEventArgs e)
        {
            switch (e.EventTarget)
            {
                case E_EVENTTARGET.EVT_TASK:
                    clsTask oTask = null;
                    oTask = ActiveGanttCSECtl1.Tasks.Item(e.Index.ToString());
                    CalculateRate(ref oTask);
                    break;
            }
        }

        private void ActiveGanttCSECtl1_ControlMouseDown(object sender, AGCSE.MouseEventArgs e)
        {
            long lIndex = 0;
            mp_oTaskPopUp.IsOpen = false;
            mp_oRowPopUp.IsOpen = false;
            switch (e.EventTarget)
            {
                case E_EVENTTARGET.EVT_SELECTEDROW:
                case E_EVENTTARGET.EVT_ROW:
                    lIndex = ActiveGanttCSECtl1.MathLib.GetRowIndexByPosition(e.Y);
                    if (e.Button == E_MOUSEBUTTONS.BTN_LEFT)
                    {
                        clsRow oRow;
                        oRow = ActiveGanttCSECtl1.Rows.Item(ActiveGanttCSECtl1.MathLib.GetRowIndexByPosition(e.Y).ToString());
                        if (e.X > ActiveGanttCSECtl1.Splitter.Position - 20 & e.X < ActiveGanttCSECtl1.Splitter.Position - 5 & e.Y < oRow.Bottom - 5 & e.Y > oRow.Bottom - 20)
                        {
                            oRow.Node.Expanded = !oRow.Node.Expanded;
                            ActiveGanttCSECtl1.Redraw();
                            e.Cancel = true;
                        }
                    }
                    else if (e.Button == E_MOUSEBUTTONS.BTN_RIGHT)
                    {
                        e.Cancel = true;
                        mp_sEditRowKey = ActiveGanttCSECtl1.Rows.Item(lIndex.ToString()).Key;
                        mp_oRowPopUp.SetValue(Canvas.LeftProperty, mp_oCursorPosition.X);
                        mp_oRowPopUp.SetValue(Canvas.TopProperty, mp_oCursorPosition.Y);
                        mp_oRowPopUp.IsOpen = true;
                    }

                    break;
                case E_EVENTTARGET.EVT_SELECTEDTASK:
                case E_EVENTTARGET.EVT_TASK:
                    if (e.Button == E_MOUSEBUTTONS.BTN_RIGHT)
                    {
                        string sTag = null;
                        e.Cancel = true;
                        lIndex = ActiveGanttCSECtl1.MathLib.GetTaskIndexByPosition(e.X, e.Y);
                        mp_sEditTaskKey = ActiveGanttCSECtl1.Tasks.Item(lIndex.ToString()).Key;
                        sTag = ActiveGanttCSECtl1.Tasks.Item(lIndex.ToString()).Tag;
                        if (sTag == "0")
                        {
                            mp_mnuConvertToRental.Visibility = System.Windows.Visibility.Visible;
                        }
                        else
                        {
                            mp_mnuConvertToRental.Visibility = System.Windows.Visibility.Collapsed;
                        }
                        if (sTag == "2")
                        {
                            mp_mnuEditTask.Visibility = System.Windows.Visibility.Collapsed;
                        }
                        else
                        {
                            mp_mnuEditTask.Visibility = System.Windows.Visibility.Visible;
                        }
                        mp_oTaskPopUp.SetValue(Canvas.LeftProperty, mp_oCursorPosition.X);
                        mp_oTaskPopUp.SetValue(Canvas.TopProperty, mp_oCursorPosition.Y);
                        mp_oTaskPopUp.IsOpen = true;
                    }

                    break;
            }
        }

        private void ActiveGanttCSECtl1_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            mp_oCursorPosition.X = e.GetPosition(LayoutRoot).X;
            mp_oCursorPosition.Y = e.GetPosition(LayoutRoot).Y;
        }

        private void ActiveGanttCSECtl1_ControlKeyDown(object sender, AGCSE.KeyEventArgs e)
        {
            if (e.KeyCode == Key.F2)
            {
                Mode = HPE_ADDMODE.AM_RENTAL;
            }
            if (e.KeyCode == Key.F9)
            {
                Mode = HPE_ADDMODE.AM_MAINTENANCE;
            }
        }

        private void ActiveGanttCSECtl1_ControlKeyUp(object sender, AGCSE.KeyEventArgs e)
        {
            Mode = HPE_ADDMODE.AM_RESERVATION;
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

        #endregion

        #region "Page Properties"

        internal E_DATASOURCETYPE DataSource
        {
            get { return mp_yDataSourceType; }
            set { mp_yDataSourceType = value; }
        }

        public HPE_ADDMODE Mode
        {
            get { return mp_yAddMode; }
            set
            {
                mp_yAddMode = value;
                switch (mp_yAddMode)
                {
                    case HPE_ADDMODE.AM_RESERVATION:
                        lblMode.Content = "Add Reservation Mode";
                        lblMode.Background = new SolidColorBrush(Color.FromArgb(255, 153, 170, 194));
                        mp_sAddModeStyleIndex = "Reservation";
                        break;
                    case HPE_ADDMODE.AM_RENTAL:
                        lblMode.Content = "Add Rental Mode";
                        lblMode.Background = new SolidColorBrush(Color.FromArgb(255, 162, 78, 50));
                        mp_sAddModeStyleIndex = "Rental";
                        break;
                    case HPE_ADDMODE.AM_MAINTENANCE:
                        lblMode.Content = "Add Maintenance Mode";
                        lblMode.Background = new SolidColorBrush(Color.FromArgb(255, 255, 77, 1));
                        mp_sAddModeStyleIndex = "Maintenance";
                        break;
                }
            }
        }

        private int Zoom
        {
            get { return mp_lZoom; }
            set
            {
                if (value > 5 | value < 1)
                {
                    return;
                }
                mp_lZoom = value;
                clsView oView = null;
                oView = ActiveGanttCSECtl1.CurrentViewObject;
                switch (mp_lZoom)
                {
                    case 5:
                        oView.Interval = E_INTERVAL.IL_MINUTE;
                        oView.Factor = 30;
                        oView.ClientArea.Grid.Interval = E_INTERVAL.IL_HOUR;
                        oView.ClientArea.Grid.Factor = 12;
                        oView.TimeLine.TickMarkArea.Visible = false;
                        break;
                    case 4:
                        oView.Interval = E_INTERVAL.IL_MINUTE;
                        oView.Factor = 15;
                        oView.ClientArea.Grid.Interval = E_INTERVAL.IL_HOUR;
                        oView.ClientArea.Grid.Factor = 6;
                        oView.TimeLine.TickMarkArea.Visible = false;
                        break;
                    case 3:
                        oView.Interval = E_INTERVAL.IL_MINUTE;
                        oView.Factor = 10;
                        oView.ClientArea.Grid.Interval = E_INTERVAL.IL_HOUR;
                        oView.ClientArea.Grid.Factor = 3;
                        oView.TimeLine.TickMarkArea.Visible = false;
                        break;
                    case 2:
                        oView.Interval = E_INTERVAL.IL_MINUTE;
                        oView.Factor = 5;
                        oView.ClientArea.Grid.Interval = E_INTERVAL.IL_HOUR;
                        oView.ClientArea.Grid.Factor = 2;
                        oView.TimeLine.TickMarkArea.Visible = true;
                        oView.TimeLine.TickMarkArea.Height = 30;
                        oView.TimeLine.TickMarkArea.TickMarks.Clear();
                        oView.TimeLine.TickMarkArea.TickMarks.Add(E_INTERVAL.IL_HOUR, 6, E_TICKMARKTYPES.TLT_BIG, true, "hh:mmtt");
                        oView.TimeLine.TickMarkArea.TickMarks.Add(E_INTERVAL.IL_HOUR, 1, E_TICKMARKTYPES.TLT_SMALL, false, "h");
                        break;
                    case 1:
                        oView.Interval = E_INTERVAL.IL_MINUTE;
                        oView.Factor = 1;
                        oView.ClientArea.Grid.Interval = E_INTERVAL.IL_MINUTE;
                        oView.ClientArea.Grid.Factor = 15;
                        oView.TimeLine.TickMarkArea.Visible = true;
                        oView.TimeLine.TickMarkArea.Height = 30;
                        oView.TimeLine.TickMarkArea.TickMarks.Clear();
                        oView.TimeLine.TickMarkArea.TickMarks.Add(E_INTERVAL.IL_HOUR, 1, E_TICKMARKTYPES.TLT_BIG, true, "hh:mmtt");
                        break;
                }
                ActiveGanttCSECtl1.Redraw();
            }
        }

        #endregion

        #region "Functions"

        internal string GetDescription(int lCarTypeID)
        {
            string sReturn = "";
            if (mp_yDataSourceType == E_DATASOURCETYPE.DST_ACCESS)
            {
            }
            ////TODO
            else if (mp_yDataSourceType == E_DATASOURCETYPE.DST_XML)
            {
            }
            ////TODO
            else if (mp_yDataSourceType == E_DATASOURCETYPE.DST_NONE)
            {
                foreach (AG_CR_Car_Type oCarType in mp_o_AG_CR_Car_Types)
                {
                    if (oCarType.lCarTypeID == lCarTypeID)
                    {
                        sReturn = oCarType.sDescription;
                    }
                }
            }
            return sReturn;
        }

        private void CalculateRate(ref clsTask oTask)
        {
            double dFactor = 0;
            string[] sRowTag = null;
            double lRate = 0;
            double dSubTotal = 0;
            double dOptions = 0;
            double dSurcharge = 0;
            double dTax = 0;
            double dALI = 0;
            double dCRF = 0;
            double dERF = 0;
            double dGPS = 0;
            double dLDW = 0;
            double dPAI = 0;
            double dPEP = 0;
            double dRCFC = 0;
            double dVLF = 0;
            double dWTB = 0;
            bool bGPS = false;
            bool bLDW = false;
            bool bPAI = false;
            bool bPEP = false;
            bool bALI = false;
            string sName = "";
            string sPhone = "";

            string sEstimatedTotal = "";
            double dEstimatedTotal = 0;


            if (mp_yDataSourceType == E_DATASOURCETYPE.DST_ACCESS)
            {
            }
            ////TODO
            else if (mp_yDataSourceType == E_DATASOURCETYPE.DST_XML)
            {
            }
            ////TODO
            else if (mp_yDataSourceType == E_DATASOURCETYPE.DST_NONE)
            {
                foreach (AG_CR_Rental oRental in mp_o_AG_CR_Rentals)
                {
                    if (oRental.lTaskID == System.Convert.ToInt32(oTask.Key.Replace("K", "")))
                    {
                        sName = oRental.sName;
                        sPhone = oRental.sPhone;

                        bGPS = oRental.bGPS;
                        dGPS = oRental.dGPS;
                        bLDW = oRental.bLDW;
                        dLDW = oRental.dLDW;
                        bPAI = oRental.bPAI;
                        dPAI = oRental.dPAI;
                        bPEP = oRental.bPEP;
                        dPEP = oRental.dPEP;
                        bALI = oRental.bALI;
                        dALI = oRental.dALI;

                        dERF = oRental.dERF;
                        dWTB = oRental.dWTB;
                        dRCFC = oRental.dRCFC;
                        dVLF = oRental.dVLF;
                        dCRF = oRental.dCRF;
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
            }

            dFactor = System.Convert.ToDouble(ActiveGanttCSECtl1.MathLib.DateTimeDiff(E_INTERVAL.IL_HOUR, oTask.StartDate, oTask.EndDate) / 24);

            if (bGPS == true)
            {
                dGPS = dGPS * dFactor;
            }
            else
            {
                dGPS = 0;
            }
            if (bLDW == true)
            {
                dLDW = dLDW * dFactor;
            }
            else
            {
                dLDW = 0;
            }
            if (bPAI == true)
            {
                dPAI = dPAI * dFactor;
            }
            else
            {
                dPAI = 0;
            }
            if (bPEP == true)
            {
                dPEP = dPEP * dFactor;
            }
            else
            {
                dPEP = 0;
            }
            if (bALI == true)
            {
                dALI = dALI * dFactor;
            }
            else
            {
                dALI = 0;
            }
            sRowTag = oTask.Row.Tag.Split('|');
            lRate = System.Convert.ToDouble(sRowTag[1]);
            dERF = dERF * dFactor;
            dWTB = dWTB * dFactor;
            dRCFC = dRCFC * dFactor;
            dVLF = dVLF * dFactor;
            dCRF = dCRF * lRate * dFactor;
            dSurcharge = dERF + dWTB + dRCFC + dVLF + dCRF;
            dOptions = (System.Double)dGPS + dLDW + dPAI + dPEP + dALI;
            dSubTotal = (System.Double)dSurcharge + (lRate * dFactor);
            string sState = "";
            dTax = dSubTotal * GetStateTax(ref oTask, ref sState);
            dEstimatedTotal = dSubTotal + dTax + dOptions;
            sEstimatedTotal = dEstimatedTotal.ToString("0.00");
            if (oTask.Tag == "0" | oTask.Tag == "1")
            {
                oTask.Text = sName + "\r\n" + "Phone: " + sPhone + "\r\n" + "Estimated Total: " + sEstimatedTotal + " USD";
            }
            else
            {
                dEstimatedTotal = 0;
                lRate = 0;
            }

            if (mp_yDataSourceType == E_DATASOURCETYPE.DST_ACCESS)
            {
            }
            ////TODO
            else if (mp_yDataSourceType == E_DATASOURCETYPE.DST_XML)
            {
            }
            ////TODO
            else if (mp_yDataSourceType == E_DATASOURCETYPE.DST_NONE)
            {
                foreach (AG_CR_Rental oRental in mp_o_AG_CR_Rentals)
                {
                    if (oRental.lTaskID == System.Convert.ToInt32(oTask.Key.Replace("K", "")))
                    {
                        oRental.dtPickUp = oTask.StartDate.DateTimePart;
                        oRental.dtReturn = oTask.EndDate.DateTimePart;
                        oRental.dRate = lRate;
                        oRental.dEstimatedTotal = dEstimatedTotal;
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
            }
        }

        internal double GetStateTax(ref clsTask oTask, ref string sState)
        {
            clsNode oNode = null;
            double dTax = 0;
            oNode = oTask.Row.Node.Parent();
            if (oNode == null)
            {
                return 0.1;
            }
            else
            {
                if (mp_yDataSourceType == E_DATASOURCETYPE.DST_ACCESS)
                {
                }
                ////TODO
                else if (mp_yDataSourceType == E_DATASOURCETYPE.DST_XML)
                {
                }
                ////TODO
                else if (mp_yDataSourceType == E_DATASOURCETYPE.DST_NONE)
                {
                    foreach (AG_CR_Row oCRRow in mp_o_AG_CR_Rows)
                    {
                        if (oCRRow.lRowID == System.Convert.ToInt32(oNode.Row.Key.Replace("K", "")))
                        {
                            sState = oCRRow.sState;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }
                    foreach (AG_CR_US_State oState in mp_o_AG_CR_US_States)
                    {
                        if (oState.sState == sState)
                        {
                            dTax = System.Convert.ToDouble(oState.dCarRentalTax);
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }
                }
            }
            return dTax;
        }

        internal Image GetImage(string sImage)
        {
            Image oReturnImage = new Image();
            System.Uri oURI = null;
            if (App.Current.Host.Source.ToString().Contains("file:///"))
            {
                String sSource = App.Current.Host.Source.ToString();
                sSource = sSource.Substring(0, sSource.IndexOf("AGCSECON")) + "AGCSECON.Web/" + sImage.Replace("\\", "/");
                oURI = new System.Uri(sSource);
            }
            else
            {
                oURI = new System.Uri(App.Current.Host.Source, "../" + sImage);
            }
            System.Windows.Media.Imaging.BitmapImage oBitmap = new System.Windows.Media.Imaging.BitmapImage();
            oBitmap.ImageOpened += mp_oBitmapOpened;
            oBitmap.UriSource = oURI;
            if (sImage.Contains("/Small/") == true)
            {
                oReturnImage.Width = 95;
                oReturnImage.Height = 40;
            }
            else if (sImage.EndsWith("minus.jpg") | sImage.EndsWith("plus.jpg"))
            {
                oReturnImage.Width = 14;
                oReturnImage.Height = 14;
            }
            oReturnImage.Source = oBitmap;
            return oReturnImage;
        }

        private void mp_oBitmapOpened(Object sender, RoutedEventArgs e)
        {
            ActiveGanttCSECtl1.Redraw();
        }

        #endregion

        #region "Toolbar Buttons"

        #region "cmdSave"

        private void cmdSaveXML_Click(object sender, RoutedEventArgs e)
        {
            mp_fSave = new fSave();
            mp_fSave.Closed += mp_fSave_Closed;
            mp_fSave.sSuggestedFileName = "AGCSE_CR";
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
            Zoom = Zoom - 1;
        }

        private void cmdZoomout_Click(object sender, RoutedEventArgs e)
        {
            Zoom = Zoom + 1;
        }

        private void cmdAddVehicle_Click(object sender, RoutedEventArgs e)
        {
            mp_fCarRentalVehicle.Mode = PRG_DIALOGMODE.DM_ADD;
            mp_fCarRentalVehicle.mp_sRowID = "";
            mp_fCarRentalVehicle.Show();
        }

        private void cmdAddBranch_Click(object sender, RoutedEventArgs e)
        {
            mp_fCarRentalBranch.Mode = PRG_DIALOGMODE.DM_ADD;
            mp_fCarRentalBranch.mp_sRowID = "";
            mp_fCarRentalBranch.Show();
        }

        private void cmdHelp_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Browser.HtmlPage.Window.Navigate(new Uri("http://www.sourcecodestore.com/Article.aspx?ID=16"), "_blank");
        }

        private void cmdBack2_Click(object sender, RoutedEventArgs e)
        {
            ActiveGanttCSECtl1.CurrentViewObject.TimeLine.Position(ActiveGanttCSECtl1.MathLib.DateTimeAdd(ActiveGanttCSECtl1.CurrentViewObject.ClientArea.Grid.Interval, -10 * ActiveGanttCSECtl1.CurrentViewObject.ClientArea.Grid.Factor, ActiveGanttCSECtl1.CurrentViewObject.TimeLine.StartDate));
            ActiveGanttCSECtl1.Redraw();
        }

        private void cmdBack1_Click(object sender, RoutedEventArgs e)
        {
            ActiveGanttCSECtl1.CurrentViewObject.TimeLine.Position(ActiveGanttCSECtl1.MathLib.DateTimeAdd(ActiveGanttCSECtl1.CurrentViewObject.ClientArea.Grid.Interval, -5 * ActiveGanttCSECtl1.CurrentViewObject.ClientArea.Grid.Factor, ActiveGanttCSECtl1.CurrentViewObject.TimeLine.StartDate));
            ActiveGanttCSECtl1.Redraw();
        }

        private void cmdBack0_Click(object sender, RoutedEventArgs e)
        {
            ActiveGanttCSECtl1.CurrentViewObject.TimeLine.Position(ActiveGanttCSECtl1.MathLib.DateTimeAdd(ActiveGanttCSECtl1.CurrentViewObject.ClientArea.Grid.Interval, -1 * ActiveGanttCSECtl1.CurrentViewObject.ClientArea.Grid.Factor, ActiveGanttCSECtl1.CurrentViewObject.TimeLine.StartDate));
            ActiveGanttCSECtl1.Redraw();
        }

        private void cmdFwd0_Click(object sender, RoutedEventArgs e)
        {
            ActiveGanttCSECtl1.CurrentViewObject.TimeLine.Position(ActiveGanttCSECtl1.MathLib.DateTimeAdd(ActiveGanttCSECtl1.CurrentViewObject.ClientArea.Grid.Interval, 1 * ActiveGanttCSECtl1.CurrentViewObject.ClientArea.Grid.Factor, ActiveGanttCSECtl1.CurrentViewObject.TimeLine.StartDate));
            ActiveGanttCSECtl1.Redraw();
        }

        private void cmdFwd1_Click(object sender, RoutedEventArgs e)
        {
            ActiveGanttCSECtl1.CurrentViewObject.TimeLine.Position(ActiveGanttCSECtl1.MathLib.DateTimeAdd(ActiveGanttCSECtl1.CurrentViewObject.ClientArea.Grid.Interval, 5 * ActiveGanttCSECtl1.CurrentViewObject.ClientArea.Grid.Factor, ActiveGanttCSECtl1.CurrentViewObject.TimeLine.StartDate));
            ActiveGanttCSECtl1.Redraw();
        }

        private void cmdFwd2_Click(object sender, RoutedEventArgs e)
        {
            ActiveGanttCSECtl1.CurrentViewObject.TimeLine.Position(ActiveGanttCSECtl1.MathLib.DateTimeAdd(ActiveGanttCSECtl1.CurrentViewObject.ClientArea.Grid.Interval, 10 * ActiveGanttCSECtl1.CurrentViewObject.ClientArea.Grid.Factor, ActiveGanttCSECtl1.CurrentViewObject.TimeLine.StartDate));
            ActiveGanttCSECtl1.Redraw();
        }

        #endregion

        #region "Context Menus"

        private void InitTaskContextMenu()
        {
            mp_oTaskPopUp = new Popup();
            mp_oTaskStackPanel = new StackPanel();
            mp_oTaskStackPanel.Background = new SolidColorBrush(Color.FromArgb(255, 200, 200, 200));
            mp_mnuEditTask = new TextBlock();
            mp_mnuEditTask.Text = "Edit Task";
            mp_mnuEditTask.Padding = new Thickness(5, 5, 5, 5);
            mp_oTaskStackPanel.Children.Add(mp_mnuEditTask);
            mp_mnuConvertToRental = new TextBlock();
            mp_mnuConvertToRental.Text = "Convert to rental";
            mp_mnuConvertToRental.Padding = new Thickness(5, 5, 5, 5);
            mp_oTaskStackPanel.Children.Add(mp_mnuConvertToRental);
            mp_mnuDeleteTask = new TextBlock();
            mp_mnuDeleteTask.Text = "Delete Task";
            mp_mnuDeleteTask.Padding = new Thickness(5, 5, 5, 5);
            mp_oTaskStackPanel.Children.Add(mp_mnuDeleteTask);
            mp_oTaskPopUp.Child = mp_oTaskStackPanel;
            LayoutRoot.Children.Add(mp_oTaskPopUp);
            mp_mnuEditTask.MouseLeftButtonUp += mnuEditTask_Click;
            mp_mnuConvertToRental.MouseLeftButtonUp += mnuConvertToRental_Click;
            mp_mnuDeleteTask.MouseLeftButtonUp += mnuDeleteTask_Click;
        }

        private void InitRowContextMenu()
        {
            mp_oRowPopUp = new Popup();
            mp_oRowStackPanel = new StackPanel();
            mp_oRowStackPanel.Background = new SolidColorBrush(Color.FromArgb(255, 200, 200, 200));
            mp_mnuEditRow = new TextBlock();
            mp_mnuEditRow.Text = "Edit Row";
            mp_mnuEditRow.Padding = new Thickness(5, 5, 5, 5);
            mp_oRowStackPanel.Children.Add(mp_mnuEditRow);
            mp_mnuDeleteRow = new TextBlock();
            mp_mnuDeleteRow.Text = "Delete Row";
            mp_mnuDeleteRow.Padding = new Thickness(5, 5, 5, 5);
            mp_oRowStackPanel.Children.Add(mp_mnuDeleteRow);
            mp_oRowPopUp.Child = mp_oRowStackPanel;
            LayoutRoot.Children.Add(mp_oRowPopUp);
            mp_mnuEditRow.MouseLeftButtonUp += mnuEditRow_Click;
            mp_mnuDeleteRow.MouseLeftButtonUp += mnuDeleteRow_Click;
        }

        private void mnuEditTask_Click(Object sender, MouseButtonEventArgs e)
        {
            mp_oTaskPopUp.IsOpen = false;
            mp_fCarRentalReservation.Mode = PRG_DIALOGMODE.DM_EDIT;
            mp_fCarRentalReservation.mp_sTaskID = mp_sEditTaskKey.Replace("K", "");
            mp_fCarRentalReservation.Show();
        }

        private void mnuConvertToRental_Click(Object sender, MouseButtonEventArgs e)
        {
            clsTask oTask;
            oTask = ActiveGanttCSECtl1.Tasks.Item(mp_sEditTaskKey);
            mp_oTaskPopUp.IsOpen = false;
            if (mp_yDataSourceType == E_DATASOURCETYPE.DST_ACCESS)
            {
            }
            ////TODO
            else if (mp_yDataSourceType == E_DATASOURCETYPE.DST_XML)
            {
            }
            ////TODO
            else if (mp_yDataSourceType == E_DATASOURCETYPE.DST_NONE)
            {
                foreach (AG_CR_Rental oRental in mp_o_AG_CR_Rentals)
                {
                    if (oRental.lTaskID == System.Convert.ToInt32(mp_sEditTaskKey.Replace("K", "")))
                    {
                        oRental.yMode = 1;
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
            }
            oTask.Tag = "1";
            oTask.StyleIndex = "Rental";
            ActiveGanttCSECtl1.Redraw();
        }

        private void mnuDeleteTask_Click(Object sender, MouseButtonEventArgs e)
        {
            mp_oTaskPopUp.IsOpen = false;
            mp_fYesNoMsgBox.Prompt = "Are you sure you want to delete this item?";
            mp_fYesNoMsgBox.Type = "DeleteTask";
            mp_fYesNoMsgBox.Show();
        }

        private void mnuEditRow_Click(Object sender, MouseButtonEventArgs e)
        {
            clsRow oRow;
            oRow = ActiveGanttCSECtl1.Rows.Item(mp_sEditRowKey);
            mp_oRowPopUp.IsOpen = false;
            if (oRow.Node.Depth == 1)
            {
                mp_fCarRentalVehicle.Mode = PRG_DIALOGMODE.DM_EDIT;
                mp_fCarRentalVehicle.mp_sRowID = mp_sEditRowKey.Replace("K", "");
                mp_fCarRentalVehicle.Show();
            }
            else if (oRow.Node.Depth == 0)
            {
                mp_fCarRentalBranch.Mode = PRG_DIALOGMODE.DM_EDIT;
                mp_fCarRentalBranch.mp_sRowID = mp_sEditRowKey.Replace("K", "");
                mp_fCarRentalBranch.Show();
            }
        }

        private void mnuDeleteRow_Click(Object sender, MouseButtonEventArgs e)
        {
            mp_oRowPopUp.IsOpen = false;
            mp_fYesNoMsgBox.Prompt = "Are you sure you want to delete this item?";
            mp_fYesNoMsgBox.Type = "DeleteRow";
            mp_fYesNoMsgBox.Show();
        }

        private void YesNoMsgBox_Closed(Object sender, EventArgs e)
        {
            if (mp_fYesNoMsgBox.Type == "DeleteRow")
            {
                if (mp_fYesNoMsgBox.DialogResult == true)
                {
                    if (mp_yDataSourceType == E_DATASOURCETYPE.DST_ACCESS)
                    {
                    }
                    ////TODO
                    else if (mp_yDataSourceType == E_DATASOURCETYPE.DST_XML)
                    {
                    }
                    ////TODO
                    else if (mp_yDataSourceType == E_DATASOURCETYPE.DST_NONE)
                    {
                        int i = 0;
                        List<AG_CR_Rental> oRentalRemoveList = new List<AG_CR_Rental>();
                        foreach (AG_CR_Row oCRRow in mp_o_AG_CR_Rows)
                        {
                            if (oCRRow.lRowID == System.Convert.ToInt32(mp_sEditRowKey.Replace("K", "")))
                            {
                                mp_o_AG_CR_Rows.Remove(oCRRow);
                                break; // TODO: might not be correct. Was : Exit For
                            }
                        }
                        foreach (AG_CR_Rental oRental in mp_o_AG_CR_Rentals)
                        {
                            if (oRental.lRowID == System.Convert.ToInt32(mp_sEditRowKey.Replace("K", "")))
                            {
                                oRentalRemoveList.Add(oRental);
                            }
                        }
                        for (i = 0; i <= oRentalRemoveList.Count - 1; i++)
                        {
                            AG_CR_Rental oRental;
                            oRental = oRentalRemoveList[i];
                            mp_o_AG_CR_Rentals.Remove(oRental);
                        }
                    }
                    ActiveGanttCSECtl1.Rows.Remove(mp_sEditRowKey);
                    ActiveGanttCSECtl1.Rows.UpdateTree();
                    ActiveGanttCSECtl1.Redraw();
                }
            }
            else if (mp_fYesNoMsgBox.Type == "DeleteTask")
            {
                if (mp_fYesNoMsgBox.DialogResult == true)
                {
                    if (mp_yDataSourceType == E_DATASOURCETYPE.DST_ACCESS)
                    {
                    }
                    ////TODO
                    else if (mp_yDataSourceType == E_DATASOURCETYPE.DST_XML)
                    {
                    }
                    ////TODO
                    else if (mp_yDataSourceType == E_DATASOURCETYPE.DST_NONE)
                    {
                        foreach (AG_CR_Rental oRental in mp_o_AG_CR_Rentals)
                        {
                            if (oRental.lTaskID == System.Convert.ToInt32(mp_sEditTaskKey.Replace("K", "")))
                            {
                                mp_o_AG_CR_Rentals.Remove(oRental);
                                break; // TODO: might not be correct. Was : Exit For
                            }
                        }
                    }
                    ActiveGanttCSECtl1.Tasks.Remove(mp_sEditTaskKey);
                    ActiveGanttCSECtl1.Redraw();
                }
            }
        }

        #endregion

        #region "Load Data"
        
        private void NoDataSource_LoadRowsAndTasks()
        {
            string sRowID = "";
            clsRow oRow = null;
            clsTask oTask = null;

            NoDataSorce_Load_Rows();

            //AG_CR_Row oCRRow;
            foreach (AG_CR_Row oCRRow in mp_o_AG_CR_Rows)
            {
                sRowID = "K" + oCRRow.lRowID.ToString();
                oRow = ActiveGanttCSECtl1.Rows.Add(sRowID);
                oRow.AllowTextEdit = true;
                if (oCRRow.lDepth == 0)
                {
                    oRow.Text = oCRRow.sBranchName + ", " + oCRRow.sState + "\r\n" + "Phone: " + oCRRow.sPhone;
                    oRow.MergeCells = true;
                    oRow.Container = false;
                    oRow.StyleIndex = "Branch";
                    oRow.ClientAreaStyleIndex = "BranchCA";
                    oRow.Node.Depth = 0;
                    oRow.UseNodeImages = true;
                    oRow.Node.ExpandedImage = GetImage("CarRental\\minus.jpg");
                    oRow.Node.Image = GetImage("CarRental\\plus.jpg");
                    oRow.AllowMove = false;
                    oRow.AllowSize = false;
                }
                else if (oCRRow.lDepth == 1)
                {
                    string sDescription = "";
                    sDescription = GetDescription(oCRRow.lCarTypeID);
                    oRow.Cells.Item("1").Text = oCRRow.sLicensePlates;
                    oRow.Cells.Item("1").AllowTextEdit = true;
                    oRow.Cells.Item("2").Image = GetImage("CarRental/Small/" + sDescription + ".jpg");
                    oRow.Cells.Item("3").Text = sDescription + "\r\n" + oCRRow.sACRISSCode + " - " + oCRRow.dRate.ToString() + " USD";
                    oRow.Cells.Item("3").AllowTextEdit = true;
                    oRow.Node.Depth = 1;
                    oRow.Tag = oCRRow.sACRISSCode + "|" + oCRRow.dRate.ToString() + "|" + oCRRow.lCarTypeID.ToString();
                }
            }


            NoDataSorce_Load_Rentals();


            foreach (AG_CR_Rental oRental in mp_o_AG_CR_Rentals)
            {
                oTask = ActiveGanttCSECtl1.Tasks.Add("", "K" + oRental.lRowID.ToString(), Globals.FromDate(oRental.dtPickUp), Globals.FromDate(oRental.dtReturn), "K" + oRental.lTaskID.ToString(), "", "");
                oTask.AllowTextEdit = true;
                if (oRental.yMode == 2)
                {
                    oTask.Text = "Scheduled Maintenance";
                    oTask.StyleIndex = "Maintenance";
                }
                else
                {
                    oTask.Text = oRental.sName + "\r\n" + "Phone: " + oRental.sPhone + "\r\n" + "Estimated Total: " + oRental.dEstimatedTotal.ToString("00.00") + " USD";
                    if (oRental.yMode == 0)
                    {
                        oTask.StyleIndex = "Reservation";
                    }
                    else if (oRental.yMode == 1)
                    {
                        oTask.StyleIndex = "Rental";
                    }
                }
                oTask.Tag = oRental.yMode.ToString();
            }

        }

        private void NoDataSorce_Load_Rows()
        {
            NoDataSorce_Load_Row(28, 0, 1, "", 0, "", 0.0, "", "Hillsboro Beach", "Hillsboro Beach", "FL", "(175) 157-9697", "Nancy Mcatee", "(175) 554-7615", "113 Bueno Drive", "22454");
            NoDataSorce_Load_Row(29, 1, 2, "CKT-2542", 39, "", 245.0, "FFBV", "", "", "", "", "", "", "", "");
            NoDataSorce_Load_Row(30, 1, 3, "XXW-9757", 14, "", 37.0, "EDAZ", "", "", "", "", "", "", "", "");
            NoDataSorce_Load_Row(31, 1, 4, "HGO-6751", 16, "", 37.0, "EDAZ", "", "", "", "", "", "", "", "");
            NoDataSorce_Load_Row(32, 1, 5, "QIZ-1491", 17, "", 37.0, "ECAZ", "", "", "", "", "", "", "", "");
            NoDataSorce_Load_Row(33, 1, 6, "WGN-3159", 46, "", 77.0, "LCAR", "", "", "", "", "", "", "", "");
            NoDataSorce_Load_Row(34, 1, 8, "TJS-5515", 37, "", 245.0, "FFBV", "", "", "", "", "", "", "", "");
            NoDataSorce_Load_Row(35, 1, 9, "FPN-9487", 31, "", 37.0, "CDMV", "", "", "", "", "", "", "", "");
            NoDataSorce_Load_Row(36, 1, 10, "ENU-2926", 26, "", 45.0, "FWAV", "", "", "", "", "", "", "", "");
            NoDataSorce_Load_Row(37, 1, 11, "MND-5686", 11, "", 39.0, "IDAV", "", "", "", "", "", "", "", "");
            NoDataSorce_Load_Row(38, 1, 12, "ZZY-1567", 18, "", 37.0, "ECAZ", "", "", "", "", "", "", "", "");
            NoDataSorce_Load_Row(39, 0, 13, "", 0, "", 0.0, "", "Woodville", "Woodville", "OK", "(145) 548-2974", "Matthew Risner", "(145) 679-8583", "8 Navarro Junction", "61614");
            NoDataSorce_Load_Row(40, 1, 14, "SGL-3748", 24, "", 37.0, "CDAV", "", "", "", "", "", "", "", "");
            NoDataSorce_Load_Row(41, 1, 15, "VYW-1478", 43, "", 51.0, "FVAV", "", "", "", "", "", "", "", "");
            NoDataSorce_Load_Row(42, 1, 16, "LXV-4412", 27, "", 45.0, "FWAV", "", "", "", "", "", "", "", "");
            NoDataSorce_Load_Row(44, 1, 7, "IMU-3364", 23, "", 37.0, "CDAV", "", "", "", "", "", "", "", "");
            NoDataSorce_Load_Row(45, 1, 17, "FRG-8842", 30, "", 37.0, "CDMV", "", "", "", "", "", "", "", "");
            NoDataSorce_Load_Row(46, 1, 18, "OJQ-8553", 14, "", 37.0, "EDAZ", "", "", "", "", "", "", "", "");
            NoDataSorce_Load_Row(47, 1, 19, "INT-3737", 5, "", 223.0, "PWDV", "", "", "", "", "", "", "", "");
            NoDataSorce_Load_Row(48, 1, 20, "USM-8758", 47, "", 77.0, "LCAR", "", "", "", "", "", "", "", "");
            NoDataSorce_Load_Row(49, 1, 21, "RRL-2724", 32, "", 37.0, "CDMV", "", "", "", "", "", "", "", "");
            NoDataSorce_Load_Row(50, 1, 22, "EMF-3865", 20, "", 37.0, "CDAV", "", "", "", "", "", "", "", "");
            NoDataSorce_Load_Row(51, 1, 23, "SRC-5911", 32, "", 37.0, "CDMV", "", "", "", "", "", "", "", "");
            NoDataSorce_Load_Row(52, 1, 24, "VTN-9768", 3, "", 71.0, "IFBV", "", "", "", "", "", "", "", "");
        }

        private void NoDataSorce_Load_Row(int lRowID, int lDepth, int lOrder, string sLicensePlates, int lCarTypeID, string sNotes, double dRate, string sACRISSCode, string sCity, string sBranchName,
        string sState, string sPhone, string sManagerName, string sManagerMobile, string sAddress, string sZIP)
        {
            AG_CR_Row oRow = new AG_CR_Row();
            oRow.lRowID = lRowID;
            oRow.lDepth = lDepth;
            oRow.lOrder = lOrder;
            oRow.sLicensePlates = sLicensePlates;
            oRow.lCarTypeID = lCarTypeID;
            oRow.sNotes = sNotes;
            oRow.dRate = dRate;
            oRow.sACRISSCode = sACRISSCode;
            oRow.sCity = sCity;
            oRow.sBranchName = sBranchName;
            oRow.sState = sState;
            oRow.sPhone = sPhone;
            oRow.sManagerName = sManagerName;
            oRow.sManagerMobile = sManagerMobile;
            oRow.sAddress = sAddress;
            oRow.sZIP = sZIP;
            mp_o_AG_CR_Rows.Add(oRow);
        }

        private void NoDataSorce_Load_Rentals()
        {
            NoDataSorce_Load_Rental(21, 30, 0, "Jeromy Lapham", "33 Mckinley Plaza", "Munds Park", "AZ", "37167", "(532) 463-3173", "(532) 793-8291", new AGCSE.DateTime(2009, 6, 13, 0, 0, 0), new AGCSE.DateTime(2009, 6, 20, 0, 0, 0), 37.0, 14.43, 0.09, 0.67, 11.95, 26.99, 4.0, 2.95, 4.0, 0.6, 2.03, 0.07, 359.22, false, false, false, false, false, false);
            NoDataSorce_Load_Rental(22, 34, 0, "Colleen Nagle", "21 Graziano Street", "George", "SC", "99234", "(266) 819-5725", "(266) 876-2444", new AGCSE.DateTime(2009, 6, 12, 0, 0, 0), new AGCSE.DateTime(2009, 6, 18, 12, 0, 0), 245.0, 14.43, 0.09, 0.67, 11.95, 26.99, 4.0, 2.95, 4.0, 0.6, 2.03, 0.07, 1923.27, false, false, false, false, false, false);
            NoDataSorce_Load_Rental(23, 36, 0, "Luisa Farrior", "86 Wiegand Courts", "Dayton", "VA", "79821", "(417) 727-8137", "(417) 974-9449", new AGCSE.DateTime(2009, 6, 10, 12, 0, 0), new AGCSE.DateTime(2009, 6, 26, 0, 0, 0), 45.0, 14.43, 0.09, 0.67, 11.95, 26.99, 4.0, 2.95, 4.0, 0.6, 2.03, 0.07, 941.21, false, false, false, false, false, false);
            NoDataSorce_Load_Rental(25, 32, 0, "Nancy Sandusky", "4 Babcock Street", "Arlington Heights village", "IL", "37895", "(446) 926-4519", "(446) 552-5686", new AGCSE.DateTime(2009, 6, 9, 12, 0, 0), new AGCSE.DateTime(2009, 6, 18, 12, 0, 0), 37.0, 14.43, 0.09, 0.67, 11.95, 26.99, 4.0, 2.95, 4.0, 0.6, 2.03, 0.07, 461.85, false, false, false, false, false, false);
            NoDataSorce_Load_Rental(26, 29, 0, "Shawn Kidder", "7 Hynes Street", "Vernon Center", "MN", "71625", "(675) 132-8559", "(675) 568-8572", new AGCSE.DateTime(2009, 6, 19, 0, 0, 0), new AGCSE.DateTime(2009, 6, 25, 0, 0, 0), 245.0, 14.43, 0.09, 0.67, 11.95, 26.99, 4.0, 2.95, 4.0, 0.6, 2.03, 0.07, 1847.03, true, false, false, false, false, false);
            NoDataSorce_Load_Rental(27, 33, 1, "Josephina Kuo", "7 Gruber Stravenue", "North Adams", "MA", "29555", "(585) 968-9925", "(585) 789-1551", new AGCSE.DateTime(2009, 6, 11, 12, 0, 0), new AGCSE.DateTime(2009, 6, 22, 12, 0, 0), 77.0, 14.43, 0.09, 0.67, 11.95, 26.99, 4.0, 2.95, 4.0, 0.6, 2.03, 0.07, 1081.84, false, false, false, false, false, false);
            NoDataSorce_Load_Rental(28, 35, 1, "Sherie Gebhard", "241 Booth Lock", "Bauxite", "AR", "73573", "(893) 882-9983", "(893) 854-1831", new AGCSE.DateTime(2009, 6, 11, 0, 0, 0), new AGCSE.DateTime(2009, 6, 21, 0, 0, 0), 37.0, 14.43, 0.09, 0.67, 11.95, 26.99, 4.0, 2.95, 4.0, 0.6, 2.03, 0.07, 513.16, false, false, false, false, false, false);
            NoDataSorce_Load_Rental(29, 29, 0, "Linda Roscoe", "17 Rosenberry Underpass", "Siler", "NC", "23686", "(929) 872-1524", "(929) 546-9944", new AGCSE.DateTime(2009, 6, 11, 0, 0, 0), new AGCSE.DateTime(2009, 6, 17, 0, 0, 0), 245.0, 14.43, 0.09, 0.67, 11.95, 26.99, 4.0, 2.95, 4.0, 0.6, 2.03, 0.07, 1775.33, false, false, false, false, false, false);
            NoDataSorce_Load_Rental(30, 37, 0, "Matthew Alfred", "298 Burcham Street", "Kivalina", "AK", "88648", "(896) 563-7588", "(896) 973-8419", new AGCSE.DateTime(2009, 6, 11, 12, 0, 0), new AGCSE.DateTime(2009, 6, 20, 12, 0, 0), 39.0, 14.43, 0.09, 0.67, 11.95, 26.99, 4.0, 2.95, 4.0, 0.6, 2.03, 0.07, 483.01, false, false, false, false, false, false);
            NoDataSorce_Load_Rental(31, 31, 1, "Betty Ballew", "6 Gillespie Drive", "Souris", "ND", "99572", "(718) 942-2143", "(718) 726-7799", new AGCSE.DateTime(2009, 6, 13, 0, 0, 0), new AGCSE.DateTime(2009, 6, 23, 12, 0, 0), 37.0, 14.43, 0.09, 0.67, 11.95, 26.99, 4.0, 2.95, 4.0, 0.6, 2.03, 0.07, 538.82, false, false, false, false, false, false);
            NoDataSorce_Load_Rental(32, 40, 0, "Jame Josephson", "52 Danford Circle", "Arkport village", "NY", "16792", "(289) 991-7674", "(289) 669-9184", new AGCSE.DateTime(2009, 6, 10, 12, 0, 0), new AGCSE.DateTime(2009, 6, 21, 0, 0, 0), 37.0, 14.43, 0.09, 0.67, 11.95, 26.99, 4.0, 2.95, 4.0, 0.6, 2.03, 0.07, 538.82, false, false, false, false, false, false);
            NoDataSorce_Load_Rental(33, 42, 0, "Penny Holsinger", "1 Mariano Fields", "Seneca Knolls", "NY", "58312", "(372) 274-7459", "(372) 576-9947", new AGCSE.DateTime(2009, 6, 9, 12, 0, 0), new AGCSE.DateTime(2009, 6, 17, 0, 0, 0), 45.0, 14.43, 0.09, 0.67, 11.95, 26.99, 4.0, 2.95, 4.0, 0.6, 2.03, 0.07, 455.42, false, false, false, false, false, false);
            NoDataSorce_Load_Rental(34, 44, 0, "Linda Gabaldon", "4 Lewellen Boulevard", "Cypress Lake", "FL", "71862", "(626) 786-3444", "(626) 591-2811", new AGCSE.DateTime(2009, 6, 10, 0, 0, 0), new AGCSE.DateTime(2009, 6, 25, 12, 0, 0), 37.0, 14.43, 0.09, 0.67, 11.95, 26.99, 4.0, 2.95, 4.0, 0.6, 2.03, 0.07, 795.41, false, false, false, false, false, false);
            NoDataSorce_Load_Rental(35, 46, 0, "Gale Cottingham", "717 Seaton Way", "Worthington borough", "PA", "91136", "(799) 683-3813", "(799) 827-3616", new AGCSE.DateTime(2009, 6, 11, 0, 0, 0), new AGCSE.DateTime(2009, 6, 23, 12, 0, 0), 37.0, 14.43, 0.09, 0.67, 11.95, 26.99, 4.0, 2.95, 4.0, 0.6, 2.03, 0.07, 641.46, false, false, false, false, false, false);
            NoDataSorce_Load_Rental(36, 42, 0, "Brian Grayson", "4 Eckert Drive", "Dunlap village", "IL", "29184", "(598) 441-2575", "(598) 191-9179", new AGCSE.DateTime(2009, 6, 19, 0, 0, 0), new AGCSE.DateTime(2009, 6, 25, 12, 0, 0), 45.0, 14.43, 0.09, 0.67, 11.95, 26.99, 4.0, 2.95, 4.0, 0.6, 2.03, 0.07, 394.7, false, false, false, false, false, false);
            NoDataSorce_Load_Rental(38, 45, 1, "Dessie Hoffer", "6 Clay Way", "Monett", "MO", "54761", "(648) 657-9664", "(648) 481-3828", new AGCSE.DateTime(2009, 6, 10, 0, 0, 0), new AGCSE.DateTime(2009, 6, 22, 0, 0, 0), 37.0, 14.43, 0.09, 0.67, 11.95, 26.99, 4.0, 2.95, 4.0, 0.6, 2.03, 0.07, 615.8, false, false, false, false, false, false);
            NoDataSorce_Load_Rental(39, 41, 1, "Vickie Cartier", "43 Jordan Way", "Williamston", "MI", "92739", "(682) 266-8395", "(682) 745-8184", new AGCSE.DateTime(2009, 6, 9, 12, 0, 0), new AGCSE.DateTime(2009, 6, 19, 12, 0, 0), 51.0, 14.43, 0.09, 0.67, 11.95, 26.99, 4.0, 2.95, 4.0, 0.6, 2.03, 0.07, 677.78, false, false, false, false, false, false);
            NoDataSorce_Load_Rental(41, 47, 0, "Brian Lenoir", "1 Betts Ridges", "Morrisville", "NC", "11594", "(319) 241-1851", "(319) 571-6978", new AGCSE.DateTime(2009, 6, 11, 12, 0, 0), new AGCSE.DateTime(2009, 6, 19, 12, 0, 0), 223.0, 14.43, 0.09, 0.67, 11.95, 26.99, 4.0, 2.95, 4.0, 0.6, 2.03, 0.07, 2160.16, false, false, false, false, false, false);
            NoDataSorce_Load_Rental(43, 38, 2, "", "", "", "", "", "", "", new AGCSE.DateTime(2009, 6, 11, 0, 0, 0), new AGCSE.DateTime(2009, 6, 24, 12, 0, 0), 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, false, false, false, false, false, false);
            NoDataSorce_Load_Rental(44, 49, 0, "Allison Peck", "169 Massa Street", "Waldorf", "MD", "91846", "(679) 847-1487", "(679) 513-3341", new AGCSE.DateTime(2009, 6, 10, 0, 0, 0), new AGCSE.DateTime(2009, 6, 17, 12, 0, 0), 77.0, 14.43, 0.09, 0.67, 11.95, 26.99, 4.0, 2.95, 4.0, 0.6, 2.03, 0.07, 940.05, false, true, true, false, false, false);
            NoDataSorce_Load_Rental(45, 48, 0, "Tiffany Arce", "6 Spires Street", "Hartford village", "IL", "36615", "(362) 357-2429", "(362) 488-4141", new AGCSE.DateTime(2009, 6, 19, 0, 0, 0), new AGCSE.DateTime(2009, 6, 24, 0, 0, 0), 77.0, 14.43, 0.09, 0.67, 11.95, 26.99, 4.0, 2.95, 4.0, 0.6, 2.03, 0.07, 491.75, false, false, false, false, false, false);
            NoDataSorce_Load_Rental(46, 51, 0, "Felipe Vantassel", "56 Ormsby Street", "Cheswold", "DE", "49225", "(714) 757-2167", "(714) 378-9745", new AGCSE.DateTime(2009, 6, 14, 0, 0, 0), new AGCSE.DateTime(2009, 6, 24, 12, 0, 0), 37.0, 14.43, 0.09, 0.67, 11.95, 26.99, 4.0, 2.95, 4.0, 0.6, 2.03, 0.07, 538.82, false, false, false, false, false, false);
            NoDataSorce_Load_Rental(47, 50, 0, "Patricia Cook", "22 Goulet Drive", "Wesleyville borough", "PA", "15945", "(421) 352-2962", "(421) 682-7189", new AGCSE.DateTime(2009, 6, 19, 0, 0, 0), new AGCSE.DateTime(2009, 6, 25, 12, 0, 0), 37.0, 14.43, 0.09, 0.67, 11.95, 26.99, 4.0, 2.95, 4.0, 0.6, 2.03, 0.07, 333.56, false, false, false, false, false, false);
        }

        private void NoDataSorce_Load_Rental(int lTaskID, int lRowID, int yMode, string sName, string sAddress, string sCity, string sState, string sZIP, string sPhone, string sMobile, AGCSE.DateTime dtPickUp, AGCSE.DateTime dtReturn, double dRate, double dALI, double dCRF, double dERF, double dGPS, double dLDW, double dPAI, double dPEP, double dRCFC, double dVLF, double dWTB, double dTax, double dEstimatedTotal, bool bGPS, bool bFSO, bool bLDW, bool bPAI, bool bPEP, bool bALI)
        {
            AG_CR_Rental oRental = new AG_CR_Rental();
            oRental.lTaskID = lTaskID;
            oRental.lRowID = lRowID;
            oRental.yMode = yMode;
            oRental.sName = sName;
            oRental.sAddress = sAddress;
            oRental.sCity = sCity;
            oRental.sState = sState;
            oRental.sZIP = sZIP;
            oRental.sPhone = sPhone;
            oRental.sMobile = sMobile;
            oRental.dtPickUp = dtPickUp.DateTimePart;
            oRental.dtReturn = dtReturn.DateTimePart;
            oRental.dRate = dRate;
            oRental.dALI = dALI;
            oRental.dCRF = dCRF;
            oRental.dERF = dERF;
            oRental.dGPS = dGPS;
            oRental.dLDW = dLDW;
            oRental.dPAI = dPAI;
            oRental.dPEP = dPEP;
            oRental.dRCFC = dRCFC;
            oRental.dVLF = dVLF;
            oRental.dWTB = dWTB;
            oRental.dTax = dTax;
            oRental.dEstimatedTotal = dEstimatedTotal;
            oRental.bGPS = bGPS;
            oRental.bFSO = bFSO;
            oRental.bLDW = bLDW;
            oRental.bPAI = bPAI;
            oRental.bPEP = bPEP;
            oRental.bALI = bALI;
            mp_o_AG_CR_Rentals.Add(oRental);
        }

        private void NoDataSource_Load_Car_Types()
        {
            NoDataSource_Add_Car_Type(1, "Escape Panther Black", "IFBV", 71.0);
            NoDataSource_Add_Car_Type(2, "Escape Hot Red", "IFBV", 71.0);
            NoDataSource_Add_Car_Type(3, "Escape Atlantis Blue", "IFBV", 71.0);
            NoDataSource_Add_Car_Type(4, "Escape Metalic Sand", "IFBV", 71.0);
            NoDataSource_Add_Car_Type(5, "Territory TX RWD Ego", "PWDV", 223.0);
            NoDataSource_Add_Car_Type(6, "Territory TX RWD Kashmir", "PWDV", 223.0);
            NoDataSource_Add_Car_Type(7, "Territory TX RWD Steel", "PWDV", 223.0);
            NoDataSource_Add_Car_Type(8, "Territory TX RWD Silhouette", "PWDV", 223.0);
            NoDataSource_Add_Car_Type(9, "Territory TX RWD Winter White", "PWDV", 223.0);
            NoDataSource_Add_Car_Type(10, "Mondeo LX Sea Grey", "IDAV", 39.0);
            NoDataSource_Add_Car_Type(11, "Mondeo LX Ink Blue", "IDAV", 39.0);
            NoDataSource_Add_Car_Type(12, "Mondeo LX Colorado Red", "IDAV", 39.0);
            NoDataSource_Add_Car_Type(13, "Fiesta CL 5 Door Squeeze", "EDAZ", 37.0);
            NoDataSource_Add_Car_Type(14, "Fiesta CL 5 Door Hydro", "EDAZ", 37.0);
            NoDataSource_Add_Car_Type(15, "Fiesta CL 5 Door Panther Black", "EDAZ", 37.0);
            NoDataSource_Add_Car_Type(16, "Fiesta CL 5 Door Frozen White", "EDAZ", 37.0);
            NoDataSource_Add_Car_Type(17, "Fiesta CL 3 Door Ocean", "ECAZ", 37.0);
            NoDataSource_Add_Car_Type(18, "Fiesta CL 3 Door Hydro", "ECAZ", 37.0);
            NoDataSource_Add_Car_Type(19, "Fiesta CL 3 Door Panther Black", "ECAZ", 37.0);
            NoDataSource_Add_Car_Type(20, "Focus CL Sedan Satin White", "CDAV", 37.0);
            NoDataSource_Add_Car_Type(21, "Focus CL Sedan Titanium Grey", "CDAV", 37.0);
            NoDataSource_Add_Car_Type(22, "Focus CL Sedan Black Sapphire", "CDAV", 37.0);
            NoDataSource_Add_Car_Type(23, "Focus CL Sedan Tango", "CDAV", 37.0);
            NoDataSource_Add_Car_Type(24, "Focus CL Sedan Ocean", "CDAV", 37.0);
            NoDataSource_Add_Car_Type(25, "Falcon XT Wagon Lightning Strike", "FWAV", 45.0);
            NoDataSource_Add_Car_Type(26, "Falcon XT Wagon Silhoutte", "FWAV", 45.0);
            NoDataSource_Add_Car_Type(27, "Falcon XT Wagon Sensation", "FWAV", 45.0);
            NoDataSource_Add_Car_Type(28, "Falcon XT Wagon Vixen", "FWAV", 45.0);
            NoDataSource_Add_Car_Type(29, "Falcon XT Wagon Steel", "FWAV", 45.0);
            NoDataSource_Add_Car_Type(30, "Focus CL Hatch Ocean", "CDMV", 37.0);
            NoDataSource_Add_Car_Type(31, "Focus CL Hatch Black Sapphire", "CDMV", 37.0);
            NoDataSource_Add_Car_Type(32, "Focus CL Hatch Tonic", "CDMV", 37.0);
            NoDataSource_Add_Car_Type(33, "Focus CL Hatch Colorado Red", "CDMV", 37.0);
            NoDataSource_Add_Car_Type(34, "Range Rover HSE Alaska White", "FFBV", 245.0);
            NoDataSource_Add_Car_Type(35, "Range Rover HSE Rimini", "FFBV", 245.0);
            NoDataSource_Add_Car_Type(36, "Range Rover HSE Galway Green", "FFBV", 245.0);
            NoDataSource_Add_Car_Type(37, "Range Rover HSE Buckingham Blue", "FFBV", 245.0);
            NoDataSource_Add_Car_Type(38, "Range Rover HSE Santorini Black", "FFBV", 245.0);
            NoDataSource_Add_Car_Type(39, "Range Rover HSE Zermatt Silver", "FFBV", 245.0);
            NoDataSource_Add_Car_Type(40, "LR3 Rimini Red", "FFBV", 232.0);
            NoDataSource_Add_Car_Type(41, "LR3 Santorini Black", "FFBV", 232.0);
            NoDataSource_Add_Car_Type(42, "LR3 Alaska White", "FFBV", 232.0);
            NoDataSource_Add_Car_Type(43, "Town and Country Modern Blue", "FVAV", 51.0);
            NoDataSource_Add_Car_Type(44, "Town and Country Melbourne Green", "FVAV", 51.0);
            NoDataSource_Add_Car_Type(45, "Town and Country Inferno Red", "FVAV", 51.0);
            NoDataSource_Add_Car_Type(46, "Chrysler 300 Clearwater Blue", "LCAR", 77.0);
            NoDataSource_Add_Car_Type(47, "Chrysler 300 Brilliant Black", "LCAR", 77.0);
            NoDataSource_Add_Car_Type(48, "Chrysler 300 Bright Silver", "LCAR", 77.0);
        }

        private void NoDataSource_Add_Car_Type(int lCarTypeID, string sDescription, string sACRISSCode, double dStdRate)
        {
            AG_CR_Car_Type oCarType = new AG_CR_Car_Type();
            oCarType.lCarTypeID = lCarTypeID;
            oCarType.sDescription = sDescription;
            oCarType.sACRISSCode = sACRISSCode;
            oCarType.dStdRate = dStdRate;
            mp_o_AG_CR_Car_Types.Add(oCarType);
        }

        private void NoDataSource_Load_US_States()
        {
            NoDataSource_Add_US_State("AK", "Alaska", 0.0);
            NoDataSource_Add_US_State("AL", "Alabama", 0.01);
            NoDataSource_Add_US_State("AR", "Arkansas", 0.01);
            NoDataSource_Add_US_State("AZ", "Arizona", 0.05);
            NoDataSource_Add_US_State("CA", "California", 0.06);
            NoDataSource_Add_US_State("CO", "Colorado", 0.03);
            NoDataSource_Add_US_State("CT", "Connecticut", 0.06);
            NoDataSource_Add_US_State("DE", "Delaware", 0.02);
            NoDataSource_Add_US_State("FL", "Florida", 0.07);
            NoDataSource_Add_US_State("GA", "Georgia", 0.04);
            NoDataSource_Add_US_State("HI", "Hawaii", 0.05);
            NoDataSource_Add_US_State("IA", "Iowa", 0.04);
            NoDataSource_Add_US_State("ID", "Idaho", 0.03);
            NoDataSource_Add_US_State("IL", "Illinois", 0.02);
            NoDataSource_Add_US_State("IN", "Indiana", 0.08);
            NoDataSource_Add_US_State("KS", "Kansas", 0.06);
            NoDataSource_Add_US_State("KY", "Kentucky", 0.05);
            NoDataSource_Add_US_State("LA", "Louisiana", 0.03);
            NoDataSource_Add_US_State("MA", "Massachusetts", 0.06);
            NoDataSource_Add_US_State("MD", "Maryland", 0.02);
            NoDataSource_Add_US_State("ME", "Maine", 0.03);
            NoDataSource_Add_US_State("MI", "Michigan", 0.04);
            NoDataSource_Add_US_State("MN", "Minnesota", 0.04);
            NoDataSource_Add_US_State("MO", "Missouri", 0.02);
            NoDataSource_Add_US_State("MS", "Mississippi", 0.01);
            NoDataSource_Add_US_State("MT", "Montana", 0.03);
            NoDataSource_Add_US_State("NC", "North Carolina", 0.04);
            NoDataSource_Add_US_State("ND", "North Dakota", 0.08);
            NoDataSource_Add_US_State("NE", "Nebraska", 0.06);
            NoDataSource_Add_US_State("NH", "New Hampshire", 0.07);
            NoDataSource_Add_US_State("NJ", "New Jersey", 0.06);
            NoDataSource_Add_US_State("NM", "New Mexico", 0.03);
            NoDataSource_Add_US_State("NV", "Nevada", 0.02);
            NoDataSource_Add_US_State("NY", "New York", 0.03);
            NoDataSource_Add_US_State("OH", "Ohio", 0.02);
            NoDataSource_Add_US_State("OK", "Oklahoma", 0.03);
            NoDataSource_Add_US_State("OR", "Oregon", 0.04);
            NoDataSource_Add_US_State("PA", "Pennsylvania", 0.05);
            NoDataSource_Add_US_State("RI", "Rhode Island", 0.06);
            NoDataSource_Add_US_State("SC", "South Carolina", 0.05);
            NoDataSource_Add_US_State("SD", "South Dakota", 0.04);
            NoDataSource_Add_US_State("TN", "Tennessee", 0.03);
            NoDataSource_Add_US_State("TX", "Texas", 0.02);
            NoDataSource_Add_US_State("UT", "Utah", 0.05);
            NoDataSource_Add_US_State("VA", "Virginia", 0.06);
            NoDataSource_Add_US_State("VT", "Vermont", 0.05);
            NoDataSource_Add_US_State("WA", "Washington", 0.04);
            NoDataSource_Add_US_State("WI", "Wisconsin", 0.06);
            NoDataSource_Add_US_State("WV", "West Virginia", 0.07);
            NoDataSource_Add_US_State("WY", "Wyoming", 0.08);
        }

        private void NoDataSource_Add_US_State(string sState, string sName, double dCarRentalTax)
        {
            AG_CR_US_State oState = new AG_CR_US_State();
            oState.sState = sState;
            oState.sName = sName;
            oState.dCarRentalTax = dCarRentalTax.ToString();
            mp_o_AG_CR_US_States.Add(oState);
        }

        internal void NoDataSource_Load_ACRISS_Codes(List<AG_CR_ACRISS_Code> o_AG_CR_ACRISS_Codes, int lPosition)
        {
            if (lPosition == 0 | lPosition == 1)
            {
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 1, "M", "Mini", 1);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 2, "N", "Mini Elite", 1);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 3, "E", "Economy", 1);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 4, "H", "Economy Elite", 1);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 5, "C", "Compact", 1);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 6, "D", "Compact Elite", 1);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 7, "I", "Intermediate", 1);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 8, "J", "Intermediate Elite", 1);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 9, "S", "Standard", 1);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 10, "R", "Standard Elite", 1);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 11, "F", "Fullsize", 1);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 12, "G", "Fullsize Elite", 1);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 13, "P", "Premium", 1);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 14, "U", "Premium Elite", 1);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 15, "L", "Luxury", 1);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 16, "W", "Luxury Elite", 1);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 17, "O", "Oversize", 1);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 18, "X", "Special", 1);
            }
            if (lPosition == 0 | lPosition == 2)
            {
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 19, "B", "2-3 Door", 2);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 20, "C", "2/4 Door", 2);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 21, "D", "4-5 Door", 2);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 22, "W", "Wagon/Estate", 2);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 23, "V", "Passenger Van", 2);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 24, "L", "Limousine", 2);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 25, "S", "Sport", 2);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 26, "T", "Convertible", 2);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 27, "F", "SUV", 2);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 28, "J", "Open Air All Terrain", 2);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 29, "X", "Special", 2);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 30, "P", "Pick up Regular Cab", 2);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 31, "Q", "Pick up Extended Cab", 2);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 32, "Z", "Special Offer Car", 2);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 33, "E", "Coupe", 2);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 34, "M", "Monospace", 2);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 35, "R", "Recreational Vehicle", 2);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 36, "H", "Motor Home", 2);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 37, "Y", "2 Wheel Vehicle", 2);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 38, "N", "Roadster", 2);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 39, "G", "Crossover", 2);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 40, "K", "Commercial Van/Truck", 2);
            }
            if (lPosition == 0 | lPosition == 3)
            {
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 41, "M", "Manual Unspecified Drive", 3);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 42, "N", "Manual 4WD", 3);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 43, "C", "Manual AWD", 3);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 44, "A", "Auto Unspecified Drive", 3);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 45, "B", "Auto 4WD", 3);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 46, "D", "Auto AWD", 3);
            }
            if (lPosition == 0 | lPosition == 4)
            {
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 47, "R", "Unspecified Fuel/Power With Air", 4);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 48, "N", "Unspecified Fuel/Power Without Air", 4);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 49, "D", "Diesel Air", 4);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 50, "Q", "Diesel No Air", 4);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 51, "H", "Hybrid Air", 4);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 52, "I", "Hybrid No Air", 4);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 53, "E", "Electric Air", 4);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 54, "C", "Electric No Air", 4);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 55, "L", "LPG/Compressed Gas Air", 4);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 56, "S", "LPG/Compressed Gas No Air", 4);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 57, "A", "Hydrogen Air", 4);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 58, "B", "Hydrogen No Air", 4);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 59, "M", "Multi Fuel/Power Air", 4);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 60, "F", "Multi Fuel/Power No Air", 4);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 61, "V", "Petrol Air", 4);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 62, "Z", "Petrol No Air", 4);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 63, "U", "Ethanol Air", 4);
                NoDataSource_Add_ACRISS_Code(o_AG_CR_ACRISS_Codes, 64, "X", "Ethanol No Air", 4);
            }
        }

        private void NoDataSource_Add_ACRISS_Code(List<AG_CR_ACRISS_Code> o_AG_CR_ACRISS_Codes, int lID, string sLetter, string sDescription, int lPosition)
        {
            AG_CR_ACRISS_Code oACRISSCode = new AG_CR_ACRISS_Code();
            oACRISSCode.lID = lID;
            oACRISSCode.sLetter = sLetter;
            oACRISSCode.sDescription = sDescription;
            oACRISSCode.lPosition = lPosition;
            o_AG_CR_ACRISS_Codes.Add(oACRISSCode);
        }

        private void NoDataSource_Load_Taxes_Surcharges_Options()
        {
            NoDataSource_Add_Taxes_Surcharges_Options("ALI", "Additional Liability Insurance", 14.43);
            NoDataSource_Add_Taxes_Surcharges_Options("CRF", "Concession Recovery Fee", 0.1);
            NoDataSource_Add_Taxes_Surcharges_Options("ERF", "Energy Recovery Fee", 0.67);
            NoDataSource_Add_Taxes_Surcharges_Options("GPS", "GPS", 11.95);
            NoDataSource_Add_Taxes_Surcharges_Options("LDW", "Loss Damage Waiver", 26.99);
            NoDataSource_Add_Taxes_Surcharges_Options("PAI", "Personal Accident Insurance", 4.0);
            NoDataSource_Add_Taxes_Surcharges_Options("PEP", "Personal Effects Protection", 2.95);
            NoDataSource_Add_Taxes_Surcharges_Options("RCFC", "Rental Car Facility Charge", 4.0);
            NoDataSource_Add_Taxes_Surcharges_Options("VLF", "Vehicle License Fee", 0.6);
            NoDataSource_Add_Taxes_Surcharges_Options("WTB", "Waste Tire/Battery", 2.03);
        }

        private void NoDataSource_Add_Taxes_Surcharges_Options(string sID, string sDescription, double dRate)
        {
            AG_CR_Tax_Surcharge_Option oTSO = new AG_CR_Tax_Surcharge_Option();
            oTSO.sID = sID;
            oTSO.sDescription = sDescription;
            oTSO.dRate = dRate;
            mp_o_AG_CR_Taxes_Surcharges_Options.Add(oTSO);
        }

        #endregion






















    }
}
