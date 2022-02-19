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
using System.Windows.Media.Imaging;

namespace AGCSECON
{
    public partial class fMain : Page
    {

        TreeViewItem mp_oParentNode;

        public fMain()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AddTitleNode("AGEX", "ActiveGantt Examples:", 4, 5);
            AddNode("AGEX", "GanttCharts", "Gantt Charts:", 4, 5);

            AddNode("GanttCharts", "WBS", "Work Breakdown Structure (WBS) Project Management Examples:", 4, 5);
            AddNode("WBS", "WBSProject", "No data source (32bit and 64bit compatible)", 2, 2);
            //AddNode("WBS", "WBSProjectXML", "XML data source (32bit and 64bit compatible)", 2, 2)
            //AddNode("WBS", "WBSProjectAccess", "Microsoft Access data source (32bit compatible only)", 2, 2)

            AddNode("GanttCharts", "MSPI", "Microsoft Project Integration Examples (32bit and 64bit compatible):", 4, 5);
            AddNode("MSPI", "Project2003", "Demonstrates how ActiveGantt integrates with MS Project 2003 (using XML Files and the MSP2003 Integration Library)", 2, 2);
            AddNode("MSPI", "Project2007", "Demonstrates how ActiveGantt integrates with MS Project 2007 (using XML Files and the MSP2007 Integration Library)", 2, 2);
            AddNode("MSPI", "Project2010", "Demonstrates how ActiveGantt integrates with MS Project 2010 (using XML Files and the MSP2010 Integration Library)", 2, 2);

            AddNode("AGEX", "Schedules", "Schedules and Rosters:", 4, 5);

            AddNode("Schedules", "VRFC", "Vehicle Rental/Fleet Control Roster Examples:", 4, 5);
            AddNode("VRFC", "CarRental", "No data source (32bit and 64bit compatible)", 2, 2);
            //AddNode("VRFC", "CarRentalXML", "XML data source (32bit and 64bit compatible)", 2, 2)
            //AddNode("VRFC", "CarRentalAccess", "Microsoft Access data source (32bit compatible only)", 2, 2)

            AddNode("AGEX", "OTHER", "Other examples:", 4, 5);
            AddNode("OTHER", "FastLoad", "Fast Loading of Row and Task objects", 2, 2);
            AddNode("OTHER", "CustomDrawing", "Custom Drawing", 2, 2);
            AddNode("OTHER", "SortRows", "Sort Rows", 2, 2);
            AddNode("OTHER", "MillisecondInterval", "5 Millisecond Interval View", 2, 2);

            AddNode("OTHER", "TimeBlocks", "TimeBlocks and Duration Tasks:", 4, 5);
            AddNode("TimeBlocks", "RCT_DAY", "Daily Recurrent TimeBlocks", 2, 2);
            AddNode("TimeBlocks", "RCT_WEEK", "Weekly Recurrent TimeBlocks", 2, 2);
            AddNode("TimeBlocks", "RCT_MONTH", "Monthly Recurrent TimeBlocks", 2, 2);
            AddNode("TimeBlocks", "RCT_YEAR", "Yearly Recurrent TimeBlocks", 2, 2);
            AddNode("TimeBlocks", "DurationTasks", "Duration Tasks (can skip over non-working TimeBlock intervals)", 2, 2);

            AddTitleNode("HLP", "Help", 7, 7);
            AddNode("HLP", "GS-CSE", "How to create a simple Silverlight 4 application using the ActiveGanttCSE component", 3, 3);
            AddNode("HLP", "OnlineDocumentation", "ActiveGanttCSE Online Documentation", 6, 6);
            AddNode("HLP", "BugReport", "Submit a Bug Report", 3, 3);
            AddNode("HLP", "Request", "Request Further Explanations, Code Samples and Submit Technical Queries", 6, 6);

            AddTitleNode("SCS", "The Source Code Store LLC - Website (http://www.sourcecodestore.com/)", 3, 3);
            AddNode("SCS", "OnlineStore", "Online Store - Purchase ActiveGantt Online", 3, 3);
            AddNode("SCS", "ContactUs", "Contact Us (use this form for non technical queries only)", 3, 3);

            TreeViewItem oNode; 
            oNode = FindNode("OTHER");
            oNode.IsExpanded = false;
        }

        private void AddTitleNode(string sKey, string sText, int ImageIndex, int SelectedImageIndex)
        {
            TreeViewItem oNode = new TreeViewItem();
            oNode.Name = sKey;
            oNode.Header = GetStackPanel(sText, ImageIndex);
            oNode.Tag = sKey;
            oNode.IsExpanded = true;
            TreeView1.Items.Add(oNode);
            mp_oParentNode = oNode;
        }

        private void AddNode(string sParentKey, string sKey, string sText, int ImageIndex, int SelectedImageIndex)
        {
            TreeViewItem oNode = new TreeViewItem();
            TreeViewItem oParentNode;
            oNode.Name = sKey;
            oNode.Header = GetStackPanel(sText, ImageIndex);
            oNode.Tag = sKey;
            oNode.IsExpanded = true;
            oParentNode = FindNode(sParentKey);
            oParentNode.Items.Add(oNode);
        }

        private TreeViewItem FindNode(string sName)
        {
            int i = 0;
            TreeViewItem oReturnTreeViewItem = null;
            for (i = 0; i <= TreeView1.Items.Count - 1; i++)
            {
                TreeViewItem oTreeViewItem = (TreeViewItem)TreeView1.Items[i];
                oReturnTreeViewItem = FindNode_Intermediate(ref oTreeViewItem, sName);
                if ((oReturnTreeViewItem != null))
                {
                    return oReturnTreeViewItem;
                }
                oReturnTreeViewItem = FindNode_Final(ref oTreeViewItem, sName);
                if ((oReturnTreeViewItem != null))
                {
                    return oReturnTreeViewItem;
                }
            }
            return oReturnTreeViewItem;
        }

        private TreeViewItem FindNode_Intermediate(ref TreeViewItem oTreeViewItem, string sName)
        {
            int i = 0;
            TreeViewItem oReturnTreeViewItem = null;
            for (i = 0; i <= oTreeViewItem.Items.Count - 1; i++)
            {
                TreeViewItem oChildTreeViewItem = (TreeViewItem)oTreeViewItem.Items[i];
                oReturnTreeViewItem = FindNode_Intermediate(ref oChildTreeViewItem, sName);
                if ((oReturnTreeViewItem != null))
                {
                    return oReturnTreeViewItem;
                }
            }
            oReturnTreeViewItem = FindNode_Final(ref oTreeViewItem, sName);
            return oReturnTreeViewItem;
        }

        private TreeViewItem FindNode_Final(ref TreeViewItem oTreeViewItem, string sName)
        {
            if (oTreeViewItem.Name == sName)
            {
                return oTreeViewItem;
            }
            return null;
        }

        private StackPanel GetStackPanel(string sText, int ImageIndex)
        {
            StackPanel oStackPanel = new StackPanel();
            Image oImage = new Image();
            TextBlock oTextBlock = new TextBlock();
            oImage.Source = GetImage(ImageIndex);
            oTextBlock.Text = " " + sText;
            oStackPanel.Orientation = Orientation.Horizontal;
            oStackPanel.Children.Add(oImage);
            oStackPanel.Children.Add(oTextBlock);
            return oStackPanel;
        }

        private BitmapImage GetImage(int lImageIndex)
        {
            string sImage = "";
            switch (lImageIndex)
            {
                case 4:
                    sImage = "folderopen.png";
                    break;
                case 2:
                    sImage = "ActiveGantt.png";
                    break;
                case 3:
                    sImage = "internet.png";
                    break;
                case 6:
                    sImage = "onlinedocumentation.png";
                    break;
                case 7:
                    sImage = "localCHMdocumentation.png";
                    break;
            }
            System.Uri oURI = new System.Uri("AGCSECON;component/Images/" + sImage, UriKind.Relative);
            System.Windows.Media.Imaging.BitmapImage oBitmap = new System.Windows.Media.Imaging.BitmapImage();
            System.Windows.Resources.StreamResourceInfo oSRI = Application.GetResourceStream(oURI);
            oBitmap.SetSource(oSRI.Stream);
            return oBitmap;
        }

        private void TreeView1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem oSelectedItem;
            oSelectedItem = (TreeViewItem)TreeView1.SelectedItem;
            string sSelectedTag = oSelectedItem.Tag.ToString();
            App oApp = (App)Application.Current;
            switch (sSelectedTag)
            {
                case "WBSProject":
                    {
                        fWBSProject oForm = new fWBSProject();
                        //oForm.DataSource = E_DATASOURCETYPE.DST_NONE;
                        this.Content = oForm;
                    }
                    break;
                case "WBSProjectXML":
                    {
                        fWBSProject oForm = new fWBSProject();
                        //oForm.DataSource = E_DATASOURCETYPE.DST_XML;
                        this.Content = oForm;
                    }
                    break;
                case "WBSProjectAccess":
                    {
                        fWBSProject oForm = new fWBSProject();
                        //oForm.DataSource = E_DATASOURCETYPE.DST_ACCESS;
                        this.Content = oForm;
                    }
                    break;
                case "Project2003":
                    {
                        fMSProject11 oForm = new fMSProject11();
                        this.Content = oForm;
                    }
                    break;
                case "Project2007":
                    {
                        fMSProject12 oForm = new fMSProject12();
                        this.Content = oForm;
                    }
                    break;
                case "Project2010":
                    {
                        fMSProject14 oForm = new fMSProject14();
                        this.Content = oForm;
                    }
                    break;
                case "CarRental":
                    {
                        fCarRental oForm = new fCarRental();
                        //oForm.DataSource = E_DATASOURCETYPE.DST_NONE;
                        this.Content = oForm;
                    }
                    break;
                case "CarRentalXML":
                    {
                        fCarRental oForm = new fCarRental();
                        //oForm.DataSource = E_DATASOURCETYPE.DST_XML;
                        this.Content = oForm;
                    }
                    break;
                case "CarRentalAccess":
                    {
                        fCarRental oForm = new fCarRental();
                        //oForm.DataSource = E_DATASOURCETYPE.DST_ACCESS;
                        this.Content = oForm;
                    }
                    break;
                case "FastLoad":
                    {
                        fFastLoading oForm = new fFastLoading();
                        this.Content = oForm;
                    }
                    break;
                case "CustomDrawing":
                    {
                        fCustomDrawing oForm = new fCustomDrawing();
                        this.Content = oForm;
                    }
                    break;
                case "SortRows":
                    {
                        fSortRows oForm = new fSortRows();
                        this.Content = oForm;
                    }
                    break;
                case "MillisecondInterval":
                    {
                        fMillisecondInterval oForm = new fMillisecondInterval();
                        this.Content = oForm;
                    }
                    break;
                case "DurationTasks":
                    {
                        fDurationTasks oForm = new fDurationTasks();
                        this.Content = oForm;
                    }
                    break;
                case "RCT_DAY":
                    {
                        fRCT_DAY oForm = new fRCT_DAY();
                        this.Content = oForm;
                    }
                    break;
                case "RCT_WEEK":
                    {
                        fRCT_WEEK oForm = new fRCT_WEEK();
                        this.Content = oForm;
                    }
                    break;
                case "RCT_MONTH":
                    {
                        fRCT_MONTH oForm = new fRCT_MONTH();
                        this.Content = oForm;
                    }
                    break;
                case "RCT_YEAR":
                    {
                        fRCT_YEAR oForm = new fRCT_YEAR();
                        this.Content = oForm;
                    }
                    break;
                case "SCS":
                    System.Windows.Browser.HtmlPage.Window.Navigate(new Uri("http://www.sourcecodestore.com/"), "_blank");
                    break;
                case "GS-CSE":
                    System.Windows.Browser.HtmlPage.Window.Navigate(new Uri("http://www.sourcecodestore.com/Article.aspx?ID=19#Create"), "_blank");
                    break;
                case "OnlineStore":
                    System.Windows.Browser.HtmlPage.Window.Navigate(new Uri("http://www.sourcecodestore.com/OnlineStore/"), "_blank");
                    break;
                case "OnlineDocumentation":
                    System.Windows.Browser.HtmlPage.Window.Navigate(new Uri("http://www.sourcecodestore.com/Documentation/DOCFrameset.aspx?PN=AG&PL=CSE"), "_blank");
                    break;
                case "BugReport":
                    System.Windows.Browser.HtmlPage.Window.Navigate(new Uri("http://www.sourcecodestore.com/Support/Report.aspx?T=1"), "_blank");
                    break;
                case "Request":
                    System.Windows.Browser.HtmlPage.Window.Navigate(new Uri("http://www.sourcecodestore.com/Support/Report.aspx?T=2"), "_blank");
                    break;
                case "ContactUs":
                    System.Windows.Browser.HtmlPage.Window.Navigate(new Uri("http://www.sourcecodestore.com/contactus.aspx"), "_blank");
                    break;
            }
        }

    }
}
