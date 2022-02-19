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
using System.ServiceModel.DomainServices.Client;
using AGCSECON.Web;
using AGCSE;

namespace AGCSECON
{
    public partial class fLoadXML : Page
    {

        ActiveGanttXMLContext oServiceContext = new ActiveGanttXMLContext();

        private InvokeOperation<string> invkGetXML;
        private InvokeOperation<string> invkGetFileList;
        private InvokeOperation invkSetXML;

        private List<CON_File> mp_oFileList;
        private fLoad mp_fLoad;
        private fSave mp_fSave;

        public fLoadXML()
        {
            InitializeComponent();
        }

        #region "Page_Loaded"

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            invkGetFileList = oServiceContext.GetFileList();
            invkGetFileList.Completed += invkGetFileList_Completed;
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

        #region "cmdBack"

        private void cmdBack_Click(object sender, RoutedEventArgs e)
        {
            fMain oForm = new fMain();
            this.Content = oForm;
        }

        #endregion

        #region "cmdLoadXML"

        private void cmdLoadXML_Click(object sender, RoutedEventArgs e)
        {
            mp_fLoad = new fLoad();
            mp_fLoad.Closed += mp_fLoad_Closed;
            mp_fLoad.Title = "Load XML File";
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
            ActiveGanttCSECtl1.SetXML(sXML);
            ActiveGanttCSECtl1.Redraw();
        }

        #endregion

        #region "cmdSaveXML"

        private void cmdSaveXML_Click(object sender, RoutedEventArgs e)
        {
            mp_fSave = new fSave();
            mp_fSave.Closed += mp_fSave_Closed;
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
                    CON_File oFile = new CON_File();
                    oFile.sDescription = mp_fSave.sFileName;
                    oFile.sFileName = mp_fSave.sFileName;
                    mp_oFileList.Add(oFile);
                    invkSetXML = oServiceContext.SetXML(sXML, mp_fSave.sFileName);
                    cmdSaveXML.IsEnabled = false;
                    invkSetXML.Completed += invkSetXML_Completed;
                }
            }
        }

        private void invkSetXML_Completed(object sender, System.EventArgs e)
        {
            cmdSaveXML.IsEnabled = true;
        }

        #endregion

        #region "ActiveGantt"

        private void ActiveGanttCSECtl1_CustomTierDraw(object sender, AGCSE.CustomTierDrawEventArgs e)
        {
            if (ActiveGanttCSECtl1.ControlTag == "WBSProject")
            {
                if (e.TierPosition == E_TIERPOSITION.SP_LOWER)
                {
                    e.StyleIndex = "TimeLineTiers";
                    e.Text = e.StartDate.ToString("MMM");
                }
                else if (e.TierPosition == E_TIERPOSITION.SP_UPPER)
                {
                    e.StyleIndex = "TimeLineTiers";
                    e.Text = e.StartDate.Year().ToString() + " Q" + e.StartDate.Quarter().ToString();
                }
            }
            else if (ActiveGanttCSECtl1.ControlTag == "CarRental")
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
        }

        #endregion

    }
}
