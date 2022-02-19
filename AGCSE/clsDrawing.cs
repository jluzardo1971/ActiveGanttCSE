using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace AGCSE
{

    public class clsDrawing
    {


        private ActiveGanttCSECtl mp_oControl;

        internal clsDrawing(ActiveGanttCSECtl Value)
        {
            mp_oControl = Value;
        }


        //Public Function GraphicsInfo() As Graphics
        //    Return mp_oControl.clsG.oGraphics()
        //End Function


        public void DrawLine(int X1, int Y1, int X2, int Y2, Color LineColor, GRE_LINEDRAWSTYLE LineStyle, int LineWidth)
        {
            mp_oControl.clsG.DrawLine(X1, Y1, X2, Y2, GRE_LINETYPE.LT_NORMAL, LineColor, LineStyle, LineWidth, true);
        }


        public void DrawBorder(int X1, int Y1, int X2, int Y2, Color LineColor, GRE_LINEDRAWSTYLE LineStyle, int LineWidth)
        {
            mp_oControl.clsG.DrawLine(X1, Y1, X2, Y2, GRE_LINETYPE.LT_BORDER, LineColor, LineStyle, LineWidth, true);
        }


        public void DrawRectangle(int X1, int Y1, int X2, int Y2, Color LineColor, GRE_LINEDRAWSTYLE LineStyle, int LineWidth)
        {
            mp_oControl.clsG.DrawLine(X1, Y1, X2, Y2, GRE_LINETYPE.LT_FILLED, LineColor, LineStyle, LineWidth, true);
        }


        public void DrawText(int X1, int Y1, int X2, int Y2, string Text, clsTextFlags TextFlags, Color TextColor, Font TextFont)
        {
            mp_oControl.clsG.DrawTextEx(X1, Y1, X2, Y2, Text, TextFlags, TextColor, TextFont, true);
        }


        public void DrawAlignedText(int X1, int Y1, int X2, int Y2, string Text, GRE_HORIZONTALALIGNMENT HorizontalAlignment, GRE_VERTICALALIGNMENT VerticalAlignment, Color TextColor, Font TextFont)
        {
            mp_oControl.clsG.DrawAlignedText(X1, Y1, X2, Y2, Text, HorizontalAlignment, VerticalAlignment, TextColor, TextFont);
        }


        public void PaintImage(Image Image, int X1, int Y1, int X2, int Y2)
        {
            mp_oControl.clsG.PaintImage(Image, X1, Y1, X2, Y2, 0, 0, true);
        }

        //Public Sub ClearClipRegion()
        //    mp_oControl.clsG.ClearClipRegion()
        //End Sub

    }
    

}
