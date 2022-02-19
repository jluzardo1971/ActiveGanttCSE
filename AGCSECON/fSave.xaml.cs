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
    public partial class fSave : ChildWindow
    {

        internal List<CON_File> mp_oFileList;
        internal string sFileName = "";
        internal string sSuggestedFileName = "";

        public fSave()
        {
            InitializeComponent();
        }

        private void ChildWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (sSuggestedFileName.Length > 0)
            {
                int j = 0;
                while (true)
                {
                    int i = 0;
                    for (i = 0; i <= mp_oFileList.Count - 1; i++)
                    {
                        if (j == 0)
                        {
                            if ((sSuggestedFileName.ToLower() + ".xml") == mp_oFileList[i].sFileName.ToLower())
                            {
                                j = j + 1;
                                break;
                            }
                        }
                        else
                        {
                            if ((sSuggestedFileName.ToLower() + j.ToString() + ".xml") == mp_oFileList[i].sFileName.ToLower())
                            {
                                j = j + 1;
                                break;
                            }
                        }

                    }
                    break;
                }
                if (j == 0)
                {
                    txtFileName.Text = sSuggestedFileName + ".xml";
                }
                else
                {
                    txtFileName.Text = sSuggestedFileName + j.ToString() + ".xml";
                }
            }
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void cmdOK_Click(object sender, RoutedEventArgs e)
        {
            int i;
            if (txtFileName.Text.Length == 0)
            {
                return;
            }
            if (txtFileName.Text.ToLower().EndsWith(".xml") == false)
            {
                txtFileName.Text = txtFileName.Text + ".xml";
            }
            for (i = 0; i <= mp_oFileList.Count - 1; i++)
            {
                if (txtFileName.Text.ToLower() == mp_oFileList[i].sFileName.ToLower())
                {
                    return;
                }
            }
            sFileName = txtFileName.Text;
            this.DialogResult = true;
        }


    }
}

