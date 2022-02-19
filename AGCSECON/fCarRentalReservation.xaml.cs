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
    public partial class fCarRentalReservation : ChildWindow
    {

        private fCarRental mp_oParent;
        private PRG_DIALOGMODE mp_yDialogMode;
        public string mp_sTaskID;

        private clsTask mp_oTask;
        public PRG_DIALOGMODE Mode
        {
            get { return mp_yDialogMode; }
            set { mp_yDialogMode = value; }
        }



        public fCarRentalReservation(fCarRental oParent)
        {
            InitializeComponent();
            mp_oParent = oParent;
        }

        private void ChildWindow_Loaded(object sender, RoutedEventArgs e)
        {
		string[] sRowTag = null;
		if (mp_yDialogMode == PRG_DIALOGMODE.DM_ADD) 
        {
			string sCityName = "";
			string sStateName = "";
			int lID = 0;
			if (mp_oParent.Mode == fCarRental.HPE_ADDMODE.AM_RESERVATION) 
            {
				this.Title = "Add Reservation";
				lblMode.Content = "Add Reservation";
				lblMode.Background = new SolidColorBrush(Color.FromArgb(255, 153, 170, 194));
			}
			else 
            {
				this.Title = "Add Rental";
				lblMode.Content = "Add Rental";
				lblMode.Background = new SolidColorBrush(Color.FromArgb(255, 162, 78, 50));
			}
            Globals.g_GenerateRandomCity(ref sCityName, ref sStateName, ref lID, mp_oParent.mp_yDataSourceType);
			mp_oTask = mp_oParent.ActiveGanttCSECtl1.Tasks.Item(mp_oParent.ActiveGanttCSECtl1.Tasks.Count.ToString());
			txtCity.Text = sCityName;
            txtName.Text = Globals.g_GenerateRandomName(false, mp_oParent.mp_yDataSourceType);
			txtState.Text = sStateName;
            txtPhone.Text = Globals.g_GenerateRandomPhone("");
            txtMobile.Text = Globals.g_GenerateRandomPhone(txtPhone.Text.Substring(0, 5));
            txtAddress.Text = Globals.g_GenerateRandomAddress(mp_oParent.mp_yDataSourceType);
            txtZIP.Text = Globals.g_GenerateRandomZIP();
			SetStartDate(mp_oTask.StartDate.DateTimePart);
			SetEndDate(mp_oTask.EndDate.DateTimePart);
			GetStateTax();

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
				foreach (AG_CR_Tax_Surcharge_Option oTSO in mp_oParent.mp_o_AG_CR_Taxes_Surcharges_Options) 
                {
					if (oTSO.sID == "GPS") 
                    {
						chkGPS.Content = oTSO.sDescription;
						chkGPS.Tag = oTSO.dRate;
					}
					if (oTSO.sID == "LDW") 
                    {
						chkLDW.Content = oTSO.sDescription;
						chkLDW.Tag = oTSO.dRate;
					}
					if (oTSO.sID == "PAI") 
                    {
						chkPAI.Content = oTSO.sDescription;
						chkPAI.Tag = oTSO.dRate;
					}
					if (oTSO.sID == "PEP") 
                    {
						chkPEP.Content = oTSO.sDescription;
						chkPEP.Tag = oTSO.dRate;
					}
					if (oTSO.sID == "ALI") 
                    {
						chkALI.Content = oTSO.sDescription;
						chkALI.Tag = oTSO.dRate;
					}
					if (oTSO.sID == "ERF") 
                    {
						txtERF.Tag = oTSO.dRate;
					}
					if (oTSO.sID == "CRF") 
                    {
						txtCRF.Tag = oTSO.dRate;
					}
					if (oTSO.sID == "RCFC") 
                    {
						txtRCFC.Tag = oTSO.dRate;
					}
					if (oTSO.sID == "WTB") 
                    {
						txtWTB.Tag = oTSO.dRate;
					}
					if (oTSO.sID == "VLF") 
                    {
						txtVLF.Tag = oTSO.dRate;
					}
				}
			}

		}
		else 
        {
			mp_oTask = mp_oParent.ActiveGanttCSECtl1.Tasks.Item("K" + mp_sTaskID);
			if (System.Convert.ToInt32(mp_oTask.Tag) == 0) 
            {
				this.Title = "Edit Reservation";
				lblMode.Content = "Edit Reservation";
				lblMode.Background = new SolidColorBrush(Color.FromArgb(255, 153, 170, 194));
			}
			else 
            {
				this.Title = "Edit Rental";
				lblMode.Content = "Edit Rental";
				lblMode.Background = new SolidColorBrush(Color.FromArgb(255, 162, 78, 50));
			}

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

                 foreach (AG_CR_Rental oRental in mp_oParent.mp_o_AG_CR_Rentals)
                 {
					if (oRental.lTaskID.ToString() == mp_sTaskID) 
                    {
                        txtCity.Text = oRental.sCity;
                        txtName.Text = oRental.sName;
                        txtState.Text = oRental.sState;
                        txtPhone.Text = oRental.sPhone;
                        txtMobile.Text = oRental.sMobile;
                        txtAddress.Text = oRental.sAddress;
                        txtZIP.Text = oRental.sZIP;
                        SetStartDate(oRental.dtPickUp);
                        SetEndDate(oRental.dtReturn);
                        txtRate.Text = oRental.dRate.ToString();
                        chkGPS.Tag = oRental.dGPS;
                        chkLDW.Tag = oRental.dLDW;
                        chkPAI.Tag = oRental.dPAI;
                        chkPEP.Tag = oRental.dPEP;
                        chkALI.Tag = oRental.dALI;
                        txtERF.Tag = oRental.dERF;
                        txtCRF.Tag = oRental.dCRF;
                        txtRCFC.Tag = oRental.dRCFC;
                        txtWTB.Tag = oRental.dWTB;
                        txtVLF.Tag = oRental.dVLF;
                        lblTax.Tag = oRental.dTax;
                        txtEstimatedTotal.Tag = oRental.dEstimatedTotal;
                        chkGPS.IsChecked = oRental.bGPS;
                        chkFSO.IsChecked = oRental.bFSO;
                        chkLDW.IsChecked = oRental.bLDW;
                        chkPAI.IsChecked = oRental.bPAI;
                        chkPEP.IsChecked = oRental.bPEP;
                        chkALI.IsChecked = oRental.bALI;
						break; // TODO: might not be correct. Was : Exit For
					}
				}

			}
		}
		GetStateTax();
		sRowTag = mp_oTask.Row.Tag.Split('|');
		txtDescription.Text = mp_oParent.GetDescription(System.Convert.ToInt32(sRowTag[2]));
		picCarType.Source = mp_oParent.GetImage("CarRental/Small/" + txtDescription.Text + ".jpg").Source;
		txtRate.Text = Globals.g_Format(System.Convert.ToDouble(sRowTag[1]), "0.00");
		txtACRISS1.Text = GetACRISSDescription(1, sRowTag[0].Substring(0, 1));
		txtACRISS2.Text = GetACRISSDescription(2, sRowTag[0].Substring(1, 1));
		txtACRISS3.Text = GetACRISSDescription(3, sRowTag[0].Substring(2, 1));
		txtACRISS4.Text = GetACRISSDescription(4, sRowTag[0].Substring(3, 1));
		CalculateRate();
        }



        public string GetACRISSDescription(int sPosition, string sLetter)
	{
		string sReturn = "GetACRISSDescription Error";
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
             foreach (AG_CR_ACRISS_Code oACRISSCode in mp_oParent.mp_o_AG_CR_ACRISS_Codes)
             {
				if (sLetter == oACRISSCode.sLetter) 
                {
                    return oACRISSCode.sDescription;
				}
			}
			
		}
		return sReturn;
	}

        private void GetStateTax()
        {
            string sState = "";
            double dTax = 0;
            dTax = mp_oParent.GetStateTax(ref mp_oTask, ref sState);
            lblTax.Content = sState + " State Tax (" + Globals.g_Format(dTax * 100, "0") + "%):";
            lblTax.Tag = dTax;
        }

        private void CalculateRate()
        {
            double dFactor = 0;
            string[] sRowTag = null;
            double dRate = 0;
            double dSubTotal = 0;
            double dOptions = 0;
            dFactor = (System.Double)mp_oParent.ActiveGanttCSECtl1.MathLib.DateTimeDiff(E_INTERVAL.IL_HOUR, Globals.FromDate(GetStartDate()), Globals.FromDate(GetEndDate())) / 24;
            if (chkGPS.IsChecked == true)
            {
                txtGPS.Text = Globals.g_Format((System.Double)chkGPS.Tag * dFactor, "0.00");
                txtGPS.Tag = Globals.g_Format((System.Double)chkGPS.Tag * dFactor, "0.00");
            }
            else
            {
                txtGPS.Text = "";
                txtGPS.Tag = 0;
            }
            if (chkLDW.IsChecked == true)
            {
                txtLDW.Text = Globals.g_Format((System.Double)chkLDW.Tag * dFactor, "0.00");
                txtLDW.Tag = Globals.g_Format((System.Double)chkLDW.Tag * dFactor, "0.00");
            }
            else
            {
                txtLDW.Text = "";
                txtLDW.Tag = 0;
            }
            if (chkPAI.IsChecked == true)
            {
                txtPAI.Text = Globals.g_Format((System.Double)chkPAI.Tag * dFactor, "0.00");
                txtPAI.Tag = Globals.g_Format((System.Double)chkPAI.Tag * dFactor, "0.00");
            }
            else
            {
                txtPAI.Text = "";
                txtPAI.Tag = 0;
            }
            if (chkPEP.IsChecked == true)
            {
                txtPEP.Text = Globals.g_Format((System.Double)chkPEP.Tag * dFactor, "0.00");
                txtPEP.Tag = Globals.g_Format((System.Double)chkPEP.Tag * dFactor, "0.00");
            }
            else
            {
                txtPEP.Text = "";
                txtPEP.Tag = 0;
            }
            if (chkALI.IsChecked == true)
            {
                txtALI.Text = Globals.g_Format((System.Double)chkALI.Tag * dFactor, "0.00");
                txtALI.Tag = Globals.g_Format((System.Double)chkALI.Tag * dFactor, "0.00");
            }
            else
            {
                txtALI.Text = "";
                txtALI.Tag = 0;
            }
            sRowTag = mp_oTask.Row.Tag.Split('|');
            dRate = System.Convert.ToDouble(sRowTag[1]);
            txtERF.Text = Globals.g_Format((System.Double)txtERF.Tag * dFactor, "0.00");
            txtWTB.Text = Globals.g_Format((System.Double)txtWTB.Tag * dFactor, "0.00");
            txtRCFC.Text = Globals.g_Format((System.Double)txtRCFC.Tag * dFactor, "0.00");
            txtVLF.Text = Globals.g_Format((System.Double)txtVLF.Tag * dFactor, "0.00");
            txtCRF.Text = Globals.g_Format((System.Double)txtCRF.Tag * dRate * dFactor, "0.00");
            txtSurcharge.Tag = ((System.Double)txtERF.Tag * dFactor) + ((System.Double)txtWTB.Tag * dFactor) + ((System.Double)txtRCFC.Tag * dFactor) + ((System.Double)txtVLF.Tag * dFactor) + ((System.Double)txtCRF.Tag * dRate * dFactor);
            txtSurcharge.Text = Globals.g_Format((System.Double)txtSurcharge.Tag, "0.00");

            dOptions = System.Convert.ToDouble(txtGPS.Tag) + System.Convert.ToDouble(txtLDW.Tag) + System.Convert.ToDouble(txtPAI.Tag) + System.Convert.ToDouble(txtPEP.Tag) + System.Convert.ToDouble(txtALI.Tag);
            dSubTotal = (System.Double)txtSurcharge.Tag + (dRate * dFactor);

            txtTax.Tag = dSubTotal * (System.Double)lblTax.Tag;
            txtTax.Text = Globals.g_Format((System.Double)txtTax.Tag, "0.00");

            txtEstimatedTotal.Tag = dSubTotal + (System.Double)txtTax.Tag + dOptions;
            txtEstimatedTotal.Text = Globals.g_Format((System.Double)txtEstimatedTotal.Tag, "0.00");
        }

        private void cmdOK_Click(object sender, RoutedEventArgs e)
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
			AG_CR_Rental oRental1;
			if (mp_yDialogMode == PRG_DIALOGMODE.DM_ADD) 
            {
				int lTaskID = 0;
				foreach (AG_CR_Rental oRental in mp_oParent.mp_o_AG_CR_Rentals) 
                {
					if (oRental.lTaskID > lTaskID) 
                    {
						lTaskID = oRental.lTaskID;
					}
				}
				lTaskID = lTaskID + 1;
				oRental1 = new AG_CR_Rental();
				oRental1.lTaskID = lTaskID;
				mp_oTask.Key = "K" + lTaskID.ToString();
			}
			else 
            {
                foreach (AG_CR_Rental oRental in mp_oParent.mp_o_AG_CR_Rentals) 
                {
					if (oRental.lTaskID == System.Convert.ToInt32(mp_oTask.Key.Replace("K", ""))) 
                    {
                        oRental.lRowID = System.Convert.ToInt32(mp_oTask.RowKey.Replace("K", ""));
                        oRental.yMode = System.Convert.ToInt32(mp_oParent.Mode);
                        oRental.sCity = txtCity.Text;
                        oRental.sName = txtName.Text;
                        oRental.sState = txtState.Text;
                        oRental.sPhone = txtPhone.Text;
                        oRental.sMobile = txtMobile.Text;
                        oRental.sAddress = txtAddress.Text;
                        oRental.sZIP = txtZIP.Text;
                        oRental.dtPickUp = GetStartDate();
                        oRental.dtReturn = GetEndDate();
                        oRental.dRate = System.Convert.ToDouble(txtRate.Text);
                        oRental.dGPS = System.Convert.ToDouble(chkGPS.Tag);
                        oRental.dLDW = System.Convert.ToDouble(chkLDW.Tag);
                        oRental.dPAI = System.Convert.ToDouble(chkPAI.Tag);
                        oRental.dPEP = System.Convert.ToDouble(chkPEP.Tag);
                        oRental.dALI = System.Convert.ToDouble(chkALI.Tag);
                        oRental.dERF = System.Convert.ToDouble(txtERF.Tag);
                        oRental.dCRF = System.Convert.ToDouble(txtCRF.Tag);
                        oRental.dRCFC = System.Convert.ToDouble(txtRCFC.Tag);
                        oRental.dWTB = System.Convert.ToDouble(txtWTB.Tag);
                        oRental.dVLF = System.Convert.ToDouble(txtVLF.Tag);
                        oRental.dTax = System.Convert.ToDouble(lblTax.Tag);
                        oRental.dEstimatedTotal = System.Convert.ToDouble(txtEstimatedTotal.Tag);
                        oRental.bGPS = (bool)chkGPS.IsChecked;
                        oRental.bFSO = (bool)chkFSO.IsChecked;
                        oRental.bLDW = (bool)chkLDW.IsChecked;
                        oRental.bPAI = (bool)chkPAI.IsChecked;
                        oRental.bPEP = (bool)chkPEP.IsChecked;
                        oRental.bALI = (bool)chkALI.IsChecked;
                        if (mp_yDialogMode == PRG_DIALOGMODE.DM_ADD)
                        {
                            mp_oParent.mp_o_AG_CR_Rentals.Add(oRental);
                        }
						break; // TODO: might not be correct. Was : Exit For
					}
				}
			}

		}

		mp_oTask.Text = txtName.Text + "\r\n" + "Phone: " + txtPhone.Text + "\r\n" + "Estimated Total: " + txtEstimatedTotal.Text + " USD";
		mp_oTask.Tag = System.Convert.ToInt32(mp_oParent.Mode).ToString();
		mp_oParent.ActiveGanttCSECtl1.Redraw();
		this.DialogResult = true;
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            if (mp_yDialogMode == PRG_DIALOGMODE.DM_ADD)
            {
                mp_oParent.ActiveGanttCSECtl1.Tasks.Remove(mp_oParent.ActiveGanttCSECtl1.Tasks.Count.ToString());
                mp_oParent.ActiveGanttCSECtl1.Redraw();
            }
            this.DialogResult = false;
        }

        private void SetStartDate(System.DateTime dtDate)
        {
            txtSDYear.Text = dtDate.Year.ToString();
            txtSDMonth.Text = dtDate.Month.ToString();
            txtSDDay.Text = dtDate.Day.ToString();
            txtSDHours.Text = dtDate.Hour.ToString();
            txtSDMinutes.Text = dtDate.Minute.ToString();
            txtSDSeconds.Text = dtDate.Second.ToString();
        }

        private void SetEndDate(System.DateTime dtDate)
        {
            txtEDYear.Text = dtDate.Year.ToString();
            txtEDMonth.Text = dtDate.Month.ToString();
            txtEDDay.Text = dtDate.Day.ToString();
            txtEDHours.Text = dtDate.Hour.ToString();
            txtEDMinutes.Text = dtDate.Minute.ToString();
            txtEDSeconds.Text = dtDate.Second.ToString();
        }

        private System.DateTime GetStartDate()
        {
            System.DateTime dtDate = new System.DateTime(System.Convert.ToInt32(txtSDYear.Text), System.Convert.ToInt32(txtSDMonth.Text), System.Convert.ToInt32(txtSDDay.Text), System.Convert.ToInt32(txtSDHours.Text), System.Convert.ToInt32(txtSDMinutes.Text), System.Convert.ToInt32(txtSDSeconds.Text));
            return dtDate;
        }

        private System.DateTime GetEndDate()
        {
            System.DateTime dtDate = new System.DateTime(System.Convert.ToInt32(txtEDYear.Text), System.Convert.ToInt32(txtEDMonth.Text), System.Convert.ToInt32(txtEDDay.Text), System.Convert.ToInt32(txtEDHours.Text), System.Convert.ToInt32(txtEDMinutes.Text), System.Convert.ToInt32(txtEDSeconds.Text));
            return dtDate;
        }

        private void chkGPS_Checked(object sender, RoutedEventArgs e)
        {
            CalculateRate();
        }

        private void chkGPS_Unchecked(object sender, RoutedEventArgs e)
        {
            CalculateRate();
        }

        private void chkLDW_Checked(object sender, RoutedEventArgs e)
        {
            CalculateRate();
        }

        private void chkLDW_Unchecked(object sender, RoutedEventArgs e)
        {
            CalculateRate();
        }

        private void chkPAI_Checked(object sender, RoutedEventArgs e)
        {
            CalculateRate();
        }

        private void chkPAI_Unchecked(object sender, RoutedEventArgs e)
        {
            CalculateRate();
        }

        private void chkPEP_Checked(object sender, RoutedEventArgs e)
        {
            CalculateRate();
        }

        private void chkPEP_Unchecked(object sender, RoutedEventArgs e)
        {
            CalculateRate();
        }

        private void chkALI_Checked(object sender, RoutedEventArgs e)
        {
            CalculateRate();
        }

        private void chkALI_Unchecked(object sender, RoutedEventArgs e)
        {
            CalculateRate();
        }





    }
}

