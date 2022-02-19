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
    public partial class fCarRentalBranch : ChildWindow
    {


        private fCarRental mp_oParent;
        private PRG_DIALOGMODE mp_yDialogMode;

        public string mp_sRowID;
        public PRG_DIALOGMODE Mode
        {
            get { return mp_yDialogMode; }
            set { mp_yDialogMode = value; }
        }


        public fCarRentalBranch(fCarRental oParent)
        {
            InitializeComponent();
            mp_oParent = oParent;
        }

        private void ChildWindow_Loaded(object sender, RoutedEventArgs e)
        {
		if (mp_yDialogMode == PRG_DIALOGMODE.DM_ADD) 
        {
			this.Title = "Add New Branch";
			string sCityName = "";
			string sStateName = "";
			int lID = 0;
			Globals.g_GenerateRandomCity(ref sCityName, ref sStateName, ref lID, mp_oParent.mp_yDataSourceType);
			txtCity.Text = sCityName;
			txtBranchName.Text = sCityName;
			txtState.Text = sStateName;
            txtPhone.Text = Globals.g_GenerateRandomPhone("");
            txtManagerName.Text = Globals.g_GenerateRandomName(false, mp_oParent.mp_yDataSourceType);
            txtManagerMobile.Text = Globals.g_GenerateRandomPhone(txtPhone.Text.Substring(0, 5));
            txtAddress.Text = Globals.g_GenerateRandomAddress(mp_oParent.mp_yDataSourceType);
            txtZIP.Text = Globals.g_GenerateRandomZIP();
		}
		else 
        {
			this.Title = "Edit Branch";
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
                        txtCity.Text = oCRRow.sCity;
                        txtBranchName.Text = oCRRow.sBranchName;
                        txtState.Text = oCRRow.sState;
                        txtPhone.Text = oCRRow.sPhone;
                        txtManagerName.Text = oCRRow.sManagerName;
                        txtManagerMobile.Text = oCRRow.sManagerMobile;
                        txtAddress.Text = oCRRow.sAddress;
                        txtZIP.Text = oCRRow.sZIP;
						break; // TODO: might not be correct. Was : Exit For
					}
				}
			}
		}
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
                {
                    AG_CR_Row oCRRow;
                    lRowID = lRowID + 1;
                    oCRRow = new AG_CR_Row();
                    oCRRow.lRowID = lRowID;
                    oCRRow.lOrder = mp_oParent.ActiveGanttCSECtl1.Rows.Count + 1;
                    oRow = mp_oParent.ActiveGanttCSECtl1.Rows.Add("K" + lRowID);
                    oRow.Node.Depth = 0;
                    mp_oParent.ActiveGanttCSECtl1.Rows.UpdateTree();
                    mp_oParent.mp_o_AG_CR_Rows.Add(oCRRow);
                    oCRRow.lDepth = 0;
                    oCRRow.sCity = txtCity.Text;
                    oCRRow.sBranchName = txtBranchName.Text;
                    oCRRow.sState = txtState.Text;
                    oCRRow.sPhone = txtPhone.Text;
                    oCRRow.sManagerName = txtManagerName.Text;
                    oCRRow.sManagerMobile = txtManagerMobile.Text;
                    oCRRow.sAddress = txtAddress.Text;
                    oCRRow.sZIP = txtZIP.Text;
                }
            }
			else 
            {
                foreach (AG_CR_Row oCRRow in mp_oParent.mp_o_AG_CR_Rows)
                {
                    if (oCRRow.lRowID.ToString() == mp_sRowID) 
                    {
                        oCRRow.lDepth = 0;
                        oCRRow.sCity = txtCity.Text;
                        oCRRow.sBranchName = txtBranchName.Text;
                        oCRRow.sState = txtState.Text;
                        oCRRow.sPhone = txtPhone.Text;
                        oCRRow.sManagerName = txtManagerName.Text;
                        oCRRow.sManagerMobile = txtManagerMobile.Text;
                        oCRRow.sAddress = txtAddress.Text;
                        oCRRow.sZIP = txtZIP.Text;
						break; // TODO: might not be correct. Was : Exit For
					}
				}
				oRow = mp_oParent.ActiveGanttCSECtl1.Rows.Item("K" + mp_sRowID);
			}
            

		}
		oRow.Text = txtBranchName.Text + ", " + txtState.Text + "\r\n" + "Phone: " + txtPhone.Text;
		oRow.MergeCells = true;
		oRow.Container = false;
		oRow.StyleIndex = "Branch";
		oRow.ClientAreaStyleIndex = "BranchCA";
		oRow.UseNodeImages = true;
		oRow.Node.ExpandedImage = mp_oParent.GetImage("CarRental/minus.jpg");
		oRow.Node.Image = mp_oParent.GetImage("CarRental/plus.jpg");
		oRow.AllowMove = false;
		oRow.AllowSize = false;
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





    }
}

