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
    public partial class fYesNoMsgBox : ChildWindow
    {

        private string mp_sType;
        public string Prompt
        {
            get { return txtPrompt.Text; }
            set { txtPrompt.Text = value; }
        }

        public string Type
        {
            get { return mp_sType; }
            set { mp_sType = value; }
        }


        public fYesNoMsgBox()
        {
            InitializeComponent();
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }


    }
}

