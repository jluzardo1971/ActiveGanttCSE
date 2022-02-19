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
    public partial class fMSProject11 : Page
    {
        private MSP2003Context oServiceContext = new MSP2003Context();
        private InvokeOperation<string> invkGetXML;
        private InvokeOperation<string> invkGetFileList;
        private List<CON_File> mp_oFileList;

        private fLoad mp_fLoad;
        private const string mp_sFontName = "Tahoma";

        private MSP2003.MP11 oMP11;

        #region "Constructors"

        public fMSProject11()
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

            this.Title = "The Source Code Store - ActiveGantt Scheduler Control Version " + ActiveGanttCSECtl1.Version + " - Microsoft Project 2003 integration using XML Files and the MSP2003 Integration Library";
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

            oStyle = ActiveGanttCSECtl1.Styles.Add("TimeLineTiers");
            oStyle.Font = new Font(mp_sFontName, 7, E_FONTSIZEUNITS.FSU_POINTS);
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_RAISED;
            oStyle.BorderColor = Colors.DarkGray;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;

            oStyle = ActiveGanttCSECtl1.Styles.Add("TaskStyle");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT;
            oStyle.BackColor = Colors.Blue;
            oStyle.BorderColor = Colors.Blue;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.SelectionRectangleStyle.OffsetTop = 0;
            oStyle.SelectionRectangleStyle.OffsetLeft = 0;
            oStyle.SelectionRectangleStyle.OffsetRight = 0;
            oStyle.SelectionRectangleStyle.OffsetBottom = 0;
            oStyle.TextPlacement = E_TEXTPLACEMENT.SCP_EXTERIORPLACEMENT;
            oStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_RIGHT;
            oStyle.TextXMargin = 10;
            oStyle.OffsetTop = 5;
            oStyle.OffsetBottom = 10;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_HATCH;
            oStyle.HatchBackColor = Colors.White;
            oStyle.HatchForeColor = Colors.Blue;
            oStyle.HatchStyle = GRE_HATCHSTYLE.HS_PERCENT50;
            oStyle.PredecessorStyle.LineColor = Colors.Black;
            oStyle.MilestoneStyle.ShapeIndex = GRE_FIGURETYPE.FT_DIAMOND;
            oStyle.MilestoneStyle.FillColor = Colors.Blue;
            oStyle.MilestoneStyle.BorderColor = Colors.Blue;
            oStyle.PredecessorStyle.XOffset = 4;
            oStyle.PredecessorStyle.YOffset = 4;

            oStyle = ActiveGanttCSECtl1.Styles.Add("SummaryStyle");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT;
            oStyle.BackColor = Colors.Green;
            oStyle.BorderColor = Colors.Green;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.SelectionRectangleStyle.Visible = false;
            oStyle.TextPlacement = E_TEXTPLACEMENT.SCP_EXTERIORPLACEMENT;
            oStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_RIGHT;
            oStyle.TextXMargin = 10;
            oStyle.TaskStyle.StartShapeIndex = GRE_FIGURETYPE.FT_PROJECTDOWN;
            oStyle.TaskStyle.EndShapeIndex = GRE_FIGURETYPE.FT_PROJECTDOWN;
            oStyle.TaskStyle.EndFillColor = Colors.Green;
            oStyle.TaskStyle.EndBorderColor = Colors.Green;
            oStyle.TaskStyle.StartFillColor = Colors.Green;
            oStyle.TaskStyle.StartBorderColor = Colors.Green;
            oStyle.FillMode = GRE_FILLMODE.FM_UPPERHALFFILLED;

            oStyle = ActiveGanttCSECtl1.Styles.Add("CellStyleKeyColumn");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackColor = Colors.White;
            oStyle.BorderColor = Color.FromArgb(255, 128, 128, 128);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Left = false;
            oStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_RIGHT;
            oStyle.TextXMargin = 4;

            ActiveGanttCSECtl1.AllowRowMove = true;
            ActiveGanttCSECtl1.AllowRowSize = true;
            ActiveGanttCSECtl1.AddMode = E_ADDMODE.AT_BOTH;
            ActiveGanttCSECtl1.Splitter.Position = 255;
            ActiveGanttCSECtl1.Treeview.Images = true;
            ActiveGanttCSECtl1.Treeview.CheckBoxes = true;
            ActiveGanttCSECtl1.Treeview.FullColumnSelect = true;
            ActiveGanttCSECtl1.Treeview.TreeLines = false;
            ActiveGanttCSECtl1.VerticalScrollBar.ScrollBar.TimerInterval = 50;

            clsColumn oColumn;

            oColumn = ActiveGanttCSECtl1.Columns.Add("ID", "", 30, "");
            oColumn.AllowTextEdit = true;

            oColumn = ActiveGanttCSECtl1.Columns.Add("Task Name", "", 255, "");
            oColumn.AllowTextEdit = true;

            ActiveGanttCSECtl1.TreeviewColumnIndex = 2;
            ActiveGanttCSECtl1.Splitter.Position = 285;

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
            oView.TimeLine.TimeLineScrollBar.StartDate = AGCSE.DateTime.Now;
            oView.TimeLine.TimeLineScrollBar.Interval = E_INTERVAL.IL_HOUR;
            oView.TimeLine.TimeLineScrollBar.Factor = 1;
            oView.TimeLine.TimeLineScrollBar.SmallChange = 6;
            oView.TimeLine.TimeLineScrollBar.LargeChange = 480;
            oView.TimeLine.TimeLineScrollBar.Max = 4000;
            oView.TimeLine.TimeLineScrollBar.Value = 0;
            oView.TimeLine.TimeLineScrollBar.Enabled = true;
            oView.TimeLine.TimeLineScrollBar.Visible = true;
            oView.ClientArea.DetectConflicts = false;

            oView = ActiveGanttCSECtl1.Views.Add(E_INTERVAL.IL_HOUR, 3, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM, "");
            oView.TimeLine.TierArea.UpperTier.Interval = E_INTERVAL.IL_QUARTER;
            oView.TimeLine.TierArea.UpperTier.Factor = 1;
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
            oView.ClientArea.DetectConflicts = false;

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
            oView.ClientArea.DetectConflicts = false;

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

        private void MP11_To_AG()
        {
            clsTask oAGTask;
            clsRow oAGRow;
            MSP2003.Task oMPTask;
            AGCSE.DateTime dtStartDate = AGCSE.DateTime.Now;
            int i = 0;
            int j = 0;
            //// Load Project Tasks
            for (i = 1; i <= oMP11.oTasks.Count; i++)
            {
                oMPTask = oMP11.oTasks.Item(i.ToString());
                oAGRow = ActiveGanttCSECtl1.Rows.Add("K" + oMPTask.lUID.ToString());
                oAGRow.Cells.Item("1").Text = oMPTask.lUID.ToString();
                oAGRow.Cells.Item("1").StyleIndex = "CellStyleKeyColumn";
                oAGRow.Height = 20;
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
                if (oMPTask.sNotes.Length > 0)
                {
                    oAGRow.Node.Image = GetImage("Note.png");
                    oAGRow.Node.ImageVisible = true;
                }
            }
            ActiveGanttCSECtl1.Rows.UpdateTree();
            //// Indent & set Predecessors
            for (i = 1; i <= oMP11.oTasks.Count; i++)
            {
                oMPTask = oMP11.oTasks.Item(i.ToString());
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
                    MSP2003.TaskPredecessorLink oMPPredecessor;
                    oMPPredecessor = oMPTask.oPredecessorLink_C.Item(j.ToString());
                    ActiveGanttCSECtl1.Predecessors.Add("K" + oMPTask.lUID.ToString(), "K" + oMPPredecessor.lPredecessorUID.ToString(), GetAGPredecessorType(oMPPredecessor.yType), "", "TaskStyle");
                }
            }
            //Assignments
            for (i = 1; i <= oMP11.oAssignments.Count; i++)
            {
                MSP2003.Assignment oAssignment;
                oAssignment = oMP11.oAssignments.Item(i.ToString());
                oAGTask = ActiveGanttCSECtl1.Tasks.Item("K" + oAssignment.lTaskUID);
                if (oAGTask.StartDate != oAGTask.EndDate)
                {
                    if (oAssignment.lResourceUID > 0)
                    {
                        if (oAGTask.Text.Length == 0)
                        {
                            oAGTask.Text = oMP11.oResources.Item("K" + oAssignment.lResourceUID).sName;
                        }
                        else
                        {
                            oAGTask.Text = oAGTask.Text + ", " + oMP11.oResources.Item("K" + oAssignment.lResourceUID).sName;
                        }
                    }
                }
            }
            dtStartDate = ActiveGanttCSECtl1.MathLib.DateTimeAdd(E_INTERVAL.IL_DAY, -3, dtStartDate);
            AGSetStartDate(dtStartDate);
        }

        private AGCSE.E_CONSTRAINTTYPE GetAGPredecessorType(MSP2003.X_Globals.E_TYPE_3 MPPredecessorType)
        {
            switch (MPPredecessorType)
            {
                case MSP2003.X_Globals.E_TYPE_3.T_3_FF:
                    return AGCSE.E_CONSTRAINTTYPE.PCT_END_TO_END;
                case MSP2003.X_Globals.E_TYPE_3.T_3_FS:
                    return AGCSE.E_CONSTRAINTTYPE.PCT_END_TO_START;
                case MSP2003.X_Globals.E_TYPE_3.T_3_SF:
                    return AGCSE.E_CONSTRAINTTYPE.PCT_START_TO_END;
                case MSP2003.X_Globals.E_TYPE_3.T_3_SS:
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
            mp_fLoad.Title = "Load MS-Project 2003 XML file";
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
            oMP11 = new MSP2003.MP11();
            oMP11.SetXML(sXML);
            this.Cursor = Cursors.Wait;
            InitializeAG();
            MP11_To_AG();
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
