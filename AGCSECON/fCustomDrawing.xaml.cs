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
using AGCSE;

namespace AGCSECON
{
    public partial class fCustomDrawing : Page
    {
        public fCustomDrawing()
        {
            InitializeComponent();
        }

        private void cmdBack_Click(object sender, RoutedEventArgs e)
        {
            fMain oForm = new fMain();
            this.Content = oForm;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            int i = 0;
            ActiveGanttCSECtl1.Columns.Add("Column 1", "", 125, "");
            ActiveGanttCSECtl1.Columns.Add("Column 2", "", 100, "");
            for (i = 1; i <= 10; i++)
            {
                ActiveGanttCSECtl1.Rows.Add("K" + i.ToString(), "Row " + i.ToString() + " (Key: " + "K" + i.ToString() + ")", true, true, "");
            }

            ActiveGanttCSECtl1.CurrentViewObject.TimeLine.Position(new AGCSE.DateTime(2011, 11, 21, 0, 0, 0));
            ActiveGanttCSECtl1.Tasks.Add("Task 1", "K1", new AGCSE.DateTime(2011, 11, 21, 0, 0, 0), new AGCSE.DateTime(2011, 11, 21, 3, 0, 0), "", "", "");
            ActiveGanttCSECtl1.Tasks.Add("Task 2", "K2", new AGCSE.DateTime(2011, 11, 21, 1, 0, 0), new AGCSE.DateTime(2011, 11, 21, 4, 0, 0), "", "", "");
            ActiveGanttCSECtl1.Tasks.Add("Task 3", "K3", new AGCSE.DateTime(2011, 11, 21, 2, 0, 0), new AGCSE.DateTime(2011, 11, 21, 5, 0, 0), "", "", "");

            ActiveGanttCSECtl1.Redraw();
        }

        private void ActiveGanttCSECtl1_Draw(object sender, DrawEventArgs e)
        {
            if (e.EventTarget == E_EVENTTARGET.EVT_TASK)
            {
                if (ActiveGanttCSECtl1.SelectedTaskIndex == e.ObjectIndex)
                {
                    e.CustomDraw = true;
                    clsTask oTask;
                    oTask = ActiveGanttCSECtl1.Tasks.Item(e.ObjectIndex.ToString());
                    Font oFont = new Font("Arial", 10, E_FONTSIZEUNITS.FSU_POINTS, FontWeights.Normal);
                    clsTextFlags oTextFlags = new clsTextFlags(ActiveGanttCSECtl1);
                    oTextFlags.HorizontalAlignment = GRE_HORIZONTALALIGNMENT.HAL_CENTER;
                    oTextFlags.VerticalAlignment = GRE_VERTICALALIGNMENT.VAL_CENTER;
                    Image oImage = new Image();
                    System.Uri oURI = new System.Uri("AGCSECON;component/Images/sampleimage.jpg", UriKind.Relative);
                    System.Windows.Media.Imaging.BitmapImage oBitmap = new System.Windows.Media.Imaging.BitmapImage();
                    System.Windows.Resources.StreamResourceInfo oSRI = Application.GetResourceStream(oURI);
                    oBitmap.SetSource(oSRI.Stream);
                    oImage.Width = 24;
                    oImage.Height = 24;
                    oImage.Source = oBitmap;
                    ActiveGanttCSECtl1.Drawing.PaintImage(oImage, oTask.Left + 40, oTask.Top + 10, oTask.Left + 64, oTask.Top + 34);
                    ActiveGanttCSECtl1.Drawing.DrawLine(oTask.Left, ((oTask.Bottom - oTask.Top) / 2) + oTask.Top, oTask.Right, ((oTask.Bottom - oTask.Top) / 2) + oTask.Top, Colors.Green, GRE_LINEDRAWSTYLE.LDS_SOLID, 1);
                    ActiveGanttCSECtl1.Drawing.DrawRectangle(oTask.Left, oTask.Top, oTask.Left + 10, oTask.Top + 10, Colors.Red, GRE_LINEDRAWSTYLE.LDS_SOLID, 1);
                    ActiveGanttCSECtl1.Drawing.DrawBorder(oTask.Left, oTask.Top, oTask.Right, oTask.Bottom, Colors.Blue, GRE_LINEDRAWSTYLE.LDS_SOLID, 2);
                    ActiveGanttCSECtl1.Drawing.DrawAlignedText(oTask.Left, oTask.Top, oTask.Right, oTask.Bottom, oTask.Text + " Is Selected", GRE_HORIZONTALALIGNMENT.HAL_RIGHT, GRE_VERTICALALIGNMENT.VAL_BOTTOM, Colors.Blue, oFont);
                    ActiveGanttCSECtl1.Drawing.DrawText(oTask.Left, oTask.Top, oTask.Right, oTask.Bottom, "Draw Text", oTextFlags, Colors.Red, oFont);
                }
            }
        }

    }
}
