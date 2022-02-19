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
using AGCSE;

namespace AGCSECON
{
    public partial class fCarRentalVehicle : ChildWindow
    {

        private fCarRental mp_oParent;
        private PRG_DIALOGMODE mp_yDialogMode;

        public string mp_sRowID;
        public PRG_DIALOGMODE Mode
        {
            get { return mp_yDialogMode; }
            set { mp_yDialogMode = value; }
        }


        public fCarRentalVehicle(fCarRental oParent)
        {
            InitializeComponent();
            mp_oParent = oParent;
        }

        private void ChildWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (mp_oParent.mp_yDataSourceType == E_DATASOURCETYPE.DST_ACCESS)
            {
            }
            ////TODO
            else if (mp_oParent.mp_yDataSourceType == E_DATASOURCETYPE.DST_XML)
            {
            }
            ////TODO
            else if (mp_oParent.mp_yDataSourceType == E_DATASOURCETYPE.DST_NONE)
            {
                drpCarTypeID.ItemsSource = mp_oParent.mp_o_AG_CR_Car_Types;
                drpCarTypeID.DisplayMemberPath = "sDescription";
                drpCarTypeID.SelectedValuePath = "lCarTypeID";
                drpACRISS1.ItemsSource = mp_oParent.mp_o_AG_CR_ACRISS_Codes_1;
                drpACRISS1.DisplayMemberPath = "sDescription";
                drpACRISS1.SelectedValuePath = "sLetter";
                drpACRISS2.ItemsSource = mp_oParent.mp_o_AG_CR_ACRISS_Codes_2;
                drpACRISS2.DisplayMemberPath = "sDescription";
                drpACRISS2.SelectedValuePath = "sLetter";
                drpACRISS3.ItemsSource = mp_oParent.mp_o_AG_CR_ACRISS_Codes_3;
                drpACRISS3.DisplayMemberPath = "sDescription";
                drpACRISS3.SelectedValuePath = "sLetter";
                drpACRISS4.ItemsSource = mp_oParent.mp_o_AG_CR_ACRISS_Codes_4;
                drpACRISS4.DisplayMemberPath = "sDescription";
                drpACRISS4.SelectedValuePath = "sLetter";
            }
            if (mp_yDialogMode == PRG_DIALOGMODE.DM_ADD)
            {
                this.Title = "Add New Vehicle";
                txtLicensePlates.Text = Globals.g_GenerateRandomLicense();
                drpCarTypeID.SelectedIndex = Globals.GetRnd(1, 48);
            }
            else
            {
                this.Title = "Edit Vehicle";

                string sACRISSCode = "";

                if (mp_oParent.mp_yDataSourceType == E_DATASOURCETYPE.DST_ACCESS)
                {
                }
                ////TODO
                else if (mp_oParent.mp_yDataSourceType == E_DATASOURCETYPE.DST_XML)
                {
                }
                ////TODO
                else if (mp_oParent.mp_yDataSourceType == E_DATASOURCETYPE.DST_NONE)
                {
                    foreach (AG_CR_Row oCRRow in mp_oParent.mp_o_AG_CR_Rows)
                    {
                        if (oCRRow.lRowID.ToString() == mp_sRowID)
                        {
                            txtLicensePlates.Text = oCRRow.sLicensePlates;
                            drpCarTypeID.SelectedValue = oCRRow.lCarTypeID;
                            txtNotes.Text = oCRRow.sNotes;
                            txtRate.Text = oCRRow.dRate.ToString();
                            sACRISSCode = oCRRow.sACRISSCode;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }

                }
                UpdatePicture();
                UpdateACRISSCode(sACRISSCode);
            }
        }


        private void UpdateACRISSCode(string sACRISSCode)
        {
            drpACRISS1.SelectedValue = sACRISSCode.Substring(0, 1);
            drpACRISS2.SelectedValue = sACRISSCode.Substring(1, 1);
            drpACRISS3.SelectedValue = sACRISSCode.Substring(2, 1);
            drpACRISS4.SelectedValue = sACRISSCode.Substring(3, 1);
            lblACRISS1.Content = sACRISSCode.Substring(0, 1);
            lblACRISS2.Content = sACRISSCode.Substring(1, 1);
            lblACRISS3.Content = sACRISSCode.Substring(2, 1);
            lblACRISS4.Content = sACRISSCode.Substring(3, 1);
        }

        private void cmdOK_Click(object sender, RoutedEventArgs e)
        {
            clsRow oRow = null;
            if (mp_oParent.mp_yDataSourceType == E_DATASOURCETYPE.DST_ACCESS)
            {
            }
            ////TODO
            else if (mp_oParent.mp_yDataSourceType == E_DATASOURCETYPE.DST_XML)
            {
            }
            ////TODO
            else if (mp_oParent.mp_yDataSourceType == E_DATASOURCETYPE.DST_NONE)
            {
                AG_CR_Row oCRRow1;
                if (mp_yDialogMode == PRG_DIALOGMODE.DM_ADD)
                {

                    int lRowID = 0;
                    foreach (AG_CR_Row oCRRow in mp_oParent.mp_o_AG_CR_Rows)
                    {
                        if (oCRRow.lRowID > lRowID)
                        {
                            lRowID = oCRRow.lRowID;
                        }
                    }
                    lRowID = lRowID + 1;
                    oCRRow1 = new AG_CR_Row();
                    oCRRow1.lRowID = lRowID;
                    oRow = mp_oParent.ActiveGanttCSECtl1.Rows.Add("K" + lRowID.ToString());
                    oRow.Node.Depth = 1;
                    mp_oParent.ActiveGanttCSECtl1.Rows.UpdateTree();
                    mp_oParent.mp_o_AG_CR_Rows.Add(oCRRow1);
                    oCRRow1.lDepth = 1;
                    oCRRow1.sLicensePlates = txtLicensePlates.Text;
                    oCRRow1.lCarTypeID = System.Convert.ToInt32(drpCarTypeID.SelectedValue);
                    oCRRow1.sNotes = txtNotes.Text;
                    oCRRow1.dRate = System.Convert.ToDouble(txtRate.Text);
                    oCRRow1.sACRISSCode = lblACRISS1.Content.ToString() + lblACRISS2.Content.ToString() + lblACRISS3.Content.ToString() + lblACRISS4.Content.ToString();
                }
                else
                {
                    foreach (AG_CR_Row oCRRow in mp_oParent.mp_o_AG_CR_Rows)
                    {
                        if (oCRRow.lRowID.ToString() == mp_sRowID)
                        {
                            oCRRow.lDepth = 1;
                            oCRRow.sLicensePlates = txtLicensePlates.Text;
                            oCRRow.lCarTypeID = System.Convert.ToInt32(drpCarTypeID.SelectedValue);
                            oCRRow.sNotes = txtNotes.Text;
                            oCRRow.dRate = System.Convert.ToDouble(txtRate.Text);
                            oCRRow.sACRISSCode = lblACRISS1.Content.ToString() + lblACRISS2.Content.ToString() + lblACRISS3.Content.ToString() + lblACRISS4.Content.ToString();
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }
                    oRow = mp_oParent.ActiveGanttCSECtl1.Rows.Item("K" + mp_sRowID);
                }

            }
            AG_CR_Car_Type oCarType = null;
            oRow.Cells.Item("1").Text = txtLicensePlates.Text;
            oCarType = (AG_CR_Car_Type)drpCarTypeID.SelectedItem;
            oRow.Cells.Item("2").Image = mp_oParent.GetImage("CarRental/Small/" + oCarType.sDescription + ".jpg");
            oRow.Cells.Item("3").Text = oCarType.sDescription + "\r\n" + lblACRISS1.Content + lblACRISS2.Content + lblACRISS3.Content + lblACRISS4.Content + " - " + txtRate.Text + " USD";
            oRow.Tag = lblACRISS1.Content.ToString() + lblACRISS2.Content.ToString() + lblACRISS3.Content.ToString() + lblACRISS4.Content.ToString() + "|" + txtRate.Text + "|" + drpCarTypeID.SelectedValue.ToString();
            if (mp_yDialogMode == PRG_DIALOGMODE.DM_ADD)
            {
                int l;
                l = (int)System.Math.Floor((double)mp_oParent.ActiveGanttCSECtl1.CurrentViewObject.ClientArea.Height / (double)41);
                if ((mp_oParent.ActiveGanttCSECtl1.Rows.Count - l + 2) > 0)
                {
                    mp_oParent.ActiveGanttCSECtl1.VerticalScrollBar.Value = (mp_oParent.ActiveGanttCSECtl1.Rows.Count - l + 2);
                }
            }
            mp_oParent.ActiveGanttCSECtl1.Redraw();
            this.DialogResult = true;
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void drpCarTypeID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string sACRISSCode = "";
            UpdatePicture();
            AG_CR_Car_Type oCarType = null;
            oCarType = (AG_CR_Car_Type)drpCarTypeID.SelectedItem;
            sACRISSCode = oCarType.sACRISSCode;
            UpdateACRISSCode(sACRISSCode);
            txtRate.Text = oCarType.dStdRate.ToString();
        }

        private void UpdatePicture()
        {
            AG_CR_Car_Type oCarType;
            oCarType = (AG_CR_Car_Type)drpCarTypeID.SelectedItem;
            if (string.IsNullOrEmpty(oCarType.sDescription))
            {
                return;
            }
            picMake.Source = GetImage("CarRental/Big/" + oCarType.sDescription + ".jpg").Source;
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
            oReturnImage.Width = 442;
            oReturnImage.Height = 186;
            oReturnImage.Source = oBitmap;
            return oReturnImage;
        }

        private void mp_oBitmapOpened(Object sender, RoutedEventArgs e)
        {
            //ActiveGanttCSECtl1.Redraw()
        }

        private void drpACRISS1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AG_CR_ACRISS_Code oACRISSCode;
            oACRISSCode = (AG_CR_ACRISS_Code)drpACRISS1.SelectedItem;
            lblACRISS1.Content = oACRISSCode.sLetter;
        }

        private void drpACRISS2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AG_CR_ACRISS_Code oACRISSCode;
            oACRISSCode = (AG_CR_ACRISS_Code)drpACRISS2.SelectedItem;
            lblACRISS2.Content = oACRISSCode.sLetter;
        }

        private void drpACRISS3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AG_CR_ACRISS_Code oACRISSCode;
            oACRISSCode = (AG_CR_ACRISS_Code)drpACRISS3.SelectedItem;
            lblACRISS3.Content = oACRISSCode.sLetter;
        }

        private void drpACRISS4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AG_CR_ACRISS_Code oACRISSCode;
            oACRISSCode = (AG_CR_ACRISS_Code)drpACRISS4.SelectedItem;
            lblACRISS4.Content = oACRISSCode.sLetter;
        }

    }
}

