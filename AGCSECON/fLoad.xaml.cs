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
    public partial class fLoad : ChildWindow
    {

        internal List<CON_File> mp_oFileList;
        internal string sFileName = "";

        public fLoad()
        {
            InitializeComponent();
        }

        private void ChildWindow_Loaded(object sender, RoutedEventArgs e)
        {
            drpFile.ItemsSource = mp_oFileList;
            drpFile.DisplayMemberPath = "sDescription";
            drpFile.SelectedValuePath = "sFileName";
        }

        private void cmdOK_Click(object sender, RoutedEventArgs e)
        {
            sFileName = System.Convert.ToString(drpFile.SelectedValue);
            if (sFileName.Length == 0)
            {
                return;
            }
            this.DialogResult = true;
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

    }
}

