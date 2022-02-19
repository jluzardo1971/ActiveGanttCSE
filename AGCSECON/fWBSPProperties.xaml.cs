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

namespace AGCSECON
{
    public partial class fWBSPProperties : ChildWindow
    {

        fWBSProject mp_oParent;

        public fWBSPProperties(fWBSProject oParent)
        {
            InitializeComponent();
            mp_oParent = oParent;
        }

        private void ChildWindow_Loaded(object sender, RoutedEventArgs e)
        {
            chkCheckBoxes.IsChecked = mp_oParent.ActiveGanttCSECtl1.Treeview.CheckBoxes;
            chkImages.IsChecked = mp_oParent.ActiveGanttCSECtl1.Treeview.Images;
            chkPlusMinusSigns.IsChecked = mp_oParent.ActiveGanttCSECtl1.Treeview.PlusMinusSigns;
            chkFullColumnSelect.IsChecked = mp_oParent.ActiveGanttCSECtl1.Treeview.FullColumnSelect;
            chkTreeLines.IsChecked = mp_oParent.ActiveGanttCSECtl1.Treeview.TreeLines;
            chkEnforcePredecessors.IsChecked = mp_oParent.ActiveGanttCSECtl1.EnforcePredecessors;
            cboPredecessorMode.SelectedValue = System.Convert.ToInt32(mp_oParent.ActiveGanttCSECtl1.PredecessorMode).ToString();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            mp_oParent.ActiveGanttCSECtl1.Treeview.CheckBoxes = (bool)chkCheckBoxes.IsChecked;
            mp_oParent.ActiveGanttCSECtl1.Treeview.Images = (bool)chkImages.IsChecked;
            mp_oParent.ActiveGanttCSECtl1.Treeview.PlusMinusSigns = (bool)chkPlusMinusSigns.IsChecked;
            mp_oParent.ActiveGanttCSECtl1.Treeview.FullColumnSelect = (bool)chkFullColumnSelect.IsChecked;
            mp_oParent.ActiveGanttCSECtl1.Treeview.TreeLines = (bool)chkTreeLines.IsChecked;
            mp_oParent.ActiveGanttCSECtl1.EnforcePredecessors = (bool)chkEnforcePredecessors.IsChecked;
            mp_oParent.ActiveGanttCSECtl1.PredecessorMode = (AGCSE.E_PREDECESSORMODE)System.Convert.ToInt32(cboPredecessorMode.SelectedValue);
            this.DialogResult = true;
        }


    }
}

