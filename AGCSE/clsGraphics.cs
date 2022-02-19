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
using System.Windows.Media.Imaging;

namespace AGCSE
{

    internal class clsGraphics
    {

        private struct T_PRECT
        {
            public int lLeft;
            public int lTop;
            public int lRight;
            public int lBottom;
        }


        private T_PRECT mp_udtPreviousClipRegion;

        private const int SizeOfARGB = 4;
        private ActiveGanttCSECtl mp_oControl;
        private bool mp_bNeedsRendering;
        private int mp_lFocusLeft;
        private int mp_lFocusTop;
        private int mp_lFocusRight;

        private int mp_lFocusBottom;
        private int[] mp_aPixels;
        internal int mp_lClipX1;
        internal int mp_lClipX2;
        internal int mp_lClipY1;
        internal int mp_lClipY2;

        private Line mp_oSelectionLine;
        private Rectangle mp_oSelectionRectangle;

        private int mp_lSelectionRectangleIndex = -1;
        private int mp_lSelectionLineIndex = -1;

        private bool mp_bCheckClip;

        internal Rect mp_oTextFinalLayout;

        internal clsGraphics(ActiveGanttCSECtl Value)
        {
            mp_oControl = Value;
            mp_bNeedsRendering = true;
            mp_oSelectionLine = new Line();
            mp_oSelectionRectangle = new Rectangle();
        }

        private WriteableBitmap GetBitmap
        {
            get { return mp_oControl.mp_oBitmap; }
        }

        private void SetPixel(int lIndex, int lColor)
        {
            if (mp_bCheckClip == true)
            {
                int lY = 0;
                int lX = 0;
                lY = (int)System.Math.Floor(lIndex / Width);
                if ((lY) < mp_lClipY1)
                {
                    return;
                }
                if ((lY) > mp_lClipY2)
                {
                    return;
                }
                lX = lIndex - (lY * Width);
                if ((lX + 1) <= mp_lClipX1 | lX >= mp_lClipX2)
                {
                    return;
                }
            }
            if (lIndex > (mp_aPixels.Length - 1))
            {
                return;
            }
            mp_aPixels[lIndex] = lColor;
        }

        public int Width
        {
            get
            {
                if (GetBitmap == null)
                {
                    return 0;
                }
                else
                {
                    return GetBitmap.PixelWidth;
                }
            }
        }

        public int Height
        {
            get
            {
                if (GetBitmap == null)
                {
                    return 0;
                }
                else
                {
                    return GetBitmap.PixelHeight;
                }
            }
        }

        internal int f_FocusLeft
        {
            get { return mp_lFocusLeft; }
            set { mp_lFocusLeft = value; }
        }

        internal int f_FocusTop
        {
            get { return mp_lFocusTop; }
            set { mp_lFocusTop = value; }
        }

        internal int f_FocusRight
        {
            get { return mp_lFocusRight; }
            set { mp_lFocusRight = value; }
        }

        internal int f_FocusBottom
        {
            get { return mp_lFocusBottom; }
            set { mp_lFocusBottom = value; }
        }

        public void StartDrawing()
        {
            if (mp_oControl.mp_oBitmap == null)
            {
                mp_oControl.mp_oBitmap = new WriteableBitmap((int)mp_oControl.oCanvas.ActualWidth, (int)mp_oControl.oCanvas.ActualHeight);
                mp_oControl.oImage.Source = mp_oControl.mp_oBitmap;
            }
            if ((mp_oControl.mp_oBitmap.PixelWidth != mp_oControl.oCanvas.ActualWidth) | (mp_oControl.mp_oBitmap.PixelHeight != mp_oControl.oCanvas.ActualHeight))
            {
                mp_oControl.mp_oBitmap = new WriteableBitmap((int)mp_oControl.oCanvas.ActualWidth, (int)mp_oControl.oCanvas.ActualHeight);
                mp_oControl.oImage.Source = mp_oControl.mp_oBitmap;
            }
            mp_lClipX1 = 0;
            mp_lClipY1 = 0;
            mp_lClipX2 = (int)mp_oControl.oCanvas.ActualWidth;
            mp_lClipY2 = (int)mp_oControl.oCanvas.ActualHeight;


        }

        public void TerminateDrawing()
        {
            mp_bNeedsRendering = false;
            GetBitmap.Invalidate();
        }

        public bool NeedsRendering
        {
            get { return mp_bNeedsRendering; }
            set { mp_bNeedsRendering = value; }
        }

        public void Clear(Color oColor)
        {
            int iColor = SWM_Color_To_Int32(oColor);
            mp_aPixels = GetBitmap.Pixels;
            int iPixelCount = mp_aPixels.Length;
            for (int i = 0; i <= iPixelCount - 1; i++)
            {
                SetPixel(i, iColor);
            }
        }

        private int SWM_Color_To_Int32(Color oColor)
        {
            int iReturn = 0;
            int iA = oColor.A;
            int iR = oColor.R;
            int iG = oColor.G;
            int iB = oColor.B;
            iReturn = (iA << 24) | (iR << 16) | (iG << 8) | iB;
            return iReturn;
        }

        private void mp_DrawLineDDA(int x1, int y1, int x2, int y2, Color oColor)
        {
            int lColor = SWM_Color_To_Int32(oColor);
            int w = GetBitmap.PixelWidth;
            mp_aPixels = GetBitmap.Pixels;
            int dx = x2 - x1;
            int dy = y2 - y1;
            int len = dy >= 0 ? dy : -dy;
            int lenx = dx >= 0 ? dx : -dx;
            if (lenx > len)
            {
                len = lenx;
            }
            if (len != 0)
            {
                float incx = dx / (float)len;
                float incy = dy / (float)len;
                float x = x1;
                float y = y1;
                for (int i = 0; i <= len - 1; i++)
                {
                    SetPixel((int)y * w + (int)x, lColor);
                    x += incx;
                    y += incy;
                }
            }
        }

        private void mp_FillRectangle(int x1, int y1, int x2, int y2, Color oColor)
        {
            int lColor = SWM_Color_To_Int32(oColor);
            int w = GetBitmap.PixelWidth;
            int h = GetBitmap.PixelHeight;
            mp_aPixels = GetBitmap.Pixels;

            x2 = x2 + 1;
            y2 = y2 + 1;

            // Check boundaries
            if (x1 < 0)
            {
                x1 = 0;
            }
            if (y1 < 0)
            {
                y1 = 0;
            }
            if (x2 < 0)
            {
                x2 = 0;
            }
            if (y2 < 0)
            {
                y2 = 0;
            }
            if (x1 >= w)
            {
                x1 = w - 1;
            }
            if (y1 >= h)
            {
                y1 = h - 1;
            }
            if (x2 >= w)
            {
                x2 = w - 1;
            }
            if (y2 >= h)
            {
                y2 = h - 1;
            }


            // Fill first line
            int startY = y1 * w;
            int startYPlusX1 = startY + x1;
            int endOffset = startY + x2;
            for (int x = startYPlusX1; x <= endOffset - 1; x++)
            {
                SetPixel(x, lColor);
            }

            // Copy first line
            int len = (x2 - x1) * SizeOfARGB;
            int srcOffsetBytes = startYPlusX1 * SizeOfARGB;
            int offset2 = y2 * w + x1;
            int y = startYPlusX1 + w;
            while (y < offset2)
            {
                Buffer.BlockCopy(mp_aPixels, srcOffsetBytes, mp_aPixels, y * SizeOfARGB, len);
                y += w;
            }
        }

        private void mp_DrawRectangle(int x1, int y1, int x2, int y2, Color oColor)
        {
            int lColor = SWM_Color_To_Int32(oColor);
            int w = GetBitmap.PixelWidth;
            mp_aPixels = GetBitmap.Pixels;
            int startY = y1 * w;
            int endY = y2 * w;
            int offset2 = endY + x1;
            int endOffset = startY + x2;
            int startYPlusX1 = startY + x1;
            for (int x = startYPlusX1; x <= endOffset; x++)
            {
                SetPixel(x, lColor);
                SetPixel(offset2, lColor);
                offset2 += 1;
            }
            endOffset = startYPlusX1 + w;
            offset2 -= w;
            int y = startY + x2 + w;
            while (y < offset2)
            {
                SetPixel(y, lColor);
                SetPixel(endOffset, lColor);
                endOffset += w;
                y += w;
            }
        }

        private void mp_DrawPolyline(Point[] points, Color oColor)
        {
            int x1 = System.Convert.ToInt32(points[0].X);
            int y1 = System.Convert.ToInt32(points[0].Y);
            int x2 = 0;
            int y2 = 0;
            for (int i = 1; i <= points.Length - 1; i++)
            {
                x2 = System.Convert.ToInt32(points[i].X);
                y2 = System.Convert.ToInt32(points[i].Y);
                mp_DrawLine(x1, y1, x2, y2, oColor);
                x1 = x2;
                y1 = y2;
            }
        }

        private void mp_DrawEllipseCentered(int xc, int yc, int xr, int yr, Color oColor)
        {
            int lColor = SWM_Color_To_Int32(oColor);
            int w = GetBitmap.PixelWidth;
            mp_aPixels = GetBitmap.Pixels;

            // Init vars
            int uh = 0;
            int lh = 0;
            int x = xr;
            int y = 0;
            int xrSqTwo = (xr * xr) << 1;
            int yrSqTwo = (yr * yr) << 1;
            int xChg = yr * yr * (1 - (xr << 1));
            int yChg = xr * xr;
            int err = 0;
            int xStopping = yrSqTwo * xr;
            int yStopping = 0;

            // Draw first set of points counter clockwise where tangent line slope > -1.
            while (xStopping >= yStopping)
            {
                // Draw 4 quadrant points at once
                uh = (yc + y) * w;
                // Upper half
                lh = (yc - y) * w;
                // Lower half
                SetPixel(xc + x + uh, lColor);
                // Quadrant I
                SetPixel(xc - x + uh, lColor);
                // Quadrant II
                SetPixel(xc - x + lh, lColor);
                // Quadrant III
                SetPixel(xc + x + lh, lColor);
                // Quadrant IV
                y += 1;
                yStopping += xrSqTwo;
                err += yChg;
                yChg += xrSqTwo;
                if ((xChg + (err << 1)) > 0)
                {
                    x -= 1;
                    xStopping -= yrSqTwo;
                    err += xChg;
                    xChg += yrSqTwo;
                }
            }

            // ReInit vars
            x = 0;
            y = yr;
            uh = (yc + y) * w;
            // Upper half
            lh = (yc - y) * w;
            // Lower half
            xChg = yr * yr;
            yChg = xr * xr * (1 - (yr << 1));
            err = 0;
            xStopping = 0;
            yStopping = xrSqTwo * yr;

            // Draw second set of points clockwise where tangent line slope < -1.
            while (xStopping <= yStopping)
            {
                // Draw 4 quadrant points at once
                SetPixel(xc + x + uh, lColor);
                // Quadrant I
                SetPixel(xc - x + uh, lColor);
                // Quadrant II
                SetPixel(xc - x + lh, lColor);
                // Quadrant III
                SetPixel(xc + x + lh, lColor);
                // Quadrant IV
                x += 1;
                xStopping += yrSqTwo;
                err += xChg;
                xChg += yrSqTwo;
                if ((yChg + (err << 1)) > 0)
                {
                    y -= 1;
                    uh = (yc + y) * w;
                    // Upper half
                    lh = (yc - y) * w;
                    // Lower half
                    yStopping -= xrSqTwo;
                    err += yChg;
                    yChg += xrSqTwo;
                }
            }
        }

        private void mp_FillEllipseCentered(int xc, int yc, int xw, int yw, Color oColor)
        {
            int lColor = SWM_Color_To_Int32(oColor);
            mp_aPixels = GetBitmap.Pixels;
            int w = GetBitmap.PixelWidth;
            int h = GetBitmap.PixelHeight;
            int xr = xw / 2;
            int yr = yw / 2;

            // Init vars
            int uh = 0;
            int lh = 0;
            int uy = 0;
            int ly = 0;
            int lx = 0;
            int rx = 0;
            int x = xr;
            int y = 0;
            int xrSqTwo = (xr * xr) << 1;
            int yrSqTwo = (yr * yr) << 1;
            int xChg = yr * yr * (1 - (xr << 1));
            int yChg = xr * xr;
            int err = 0;
            int xStopping = yrSqTwo * xr;
            int yStopping = 0;

            // Draw first set of points counter clockwise where tangent line slope > -1.
            while (xStopping >= yStopping)
            {
                // Draw 4 quadrant points at once
                uy = yc + y;
                // Upper half
                ly = yc - y;
                // Lower half
                if (uy < 0)
                {
                    uy = 0;
                }
                // Clip
                if (uy >= h)
                {
                    uy = h - 1;
                }
                // ...
                if (ly < 0)
                {
                    ly = 0;
                }
                if (ly >= h)
                {
                    ly = h - 1;
                }
                uh = uy * w;
                // Upper half
                lh = ly * w;
                // Lower half
                rx = xc + x;
                lx = xc - x;
                if (rx < 0)
                {
                    rx = 0;
                }
                // Clip
                if (rx >= w)
                {
                    rx = w - 1;
                }
                // ...
                if (lx < 0)
                {
                    lx = 0;
                }
                if (lx >= w)
                {
                    lx = w - 1;
                }

                // Draw line
                for (int i = lx; i <= rx; i++)
                {
                    SetPixel(i + uh, lColor);
                    // Quadrant II to I (Actually two octants)
                    // Quadrant III to IV
                    SetPixel(i + lh, lColor);
                }

                y += 1;
                yStopping += xrSqTwo;
                err += yChg;
                yChg += xrSqTwo;
                if ((xChg + (err << 1)) > 0)
                {
                    x -= 1;
                    xStopping -= yrSqTwo;
                    err += xChg;
                    xChg += yrSqTwo;
                }
            }

            // ReInit vars
            x = 0;
            y = yr;
            uy = yc + y;
            // Upper half
            ly = yc - y;
            // Lower half
            if (uy < 0)
            {
                uy = 0;
            }
            // Clip
            if (uy >= h)
            {
                uy = h - 1;
            }
            // ...
            if (ly < 0)
            {
                ly = 0;
            }
            if (ly >= h)
            {
                ly = h - 1;
            }
            uh = uy * w;
            // Upper half
            lh = ly * w;
            // Lower half
            xChg = yr * yr;
            yChg = xr * xr * (1 - (yr << 1));
            err = 0;
            xStopping = 0;
            yStopping = xrSqTwo * yr;

            // Draw second set of points clockwise where tangent line slope < -1.
            while (xStopping <= yStopping)
            {
                // Draw 4 quadrant points at once
                rx = xc + x;
                lx = xc - x;
                if (rx < 0)
                {
                    rx = 0;
                }
                // Clip
                if (rx >= w)
                {
                    rx = w - 1;
                }
                // ...
                if (lx < 0)
                {
                    lx = 0;
                }
                if (lx >= w)
                {
                    lx = w - 1;
                }

                // Draw line
                for (int i = lx; i <= rx; i++)
                {
                    SetPixel(i + uh, lColor);
                    // Quadrant II to I (Actually two octants)
                    // Quadrant III to IV
                    SetPixel(i + lh, lColor);
                }

                x += 1;
                xStopping += yrSqTwo;
                err += xChg;
                xChg += yrSqTwo;
                if ((yChg + (err << 1)) > 0)
                {
                    y -= 1;
                    uy = yc + y;
                    // Upper half
                    ly = yc - y;
                    // Lower half
                    if (uy < 0)
                    {
                        uy = 0;
                    }
                    // Clip
                    if (uy >= h)
                    {
                        uy = h - 1;
                    }
                    // ...
                    if (ly < 0)
                    {
                        ly = 0;
                    }
                    if (ly >= h)
                    {
                        ly = h - 1;
                    }
                    uh = uy * w;
                    // Upper half
                    lh = ly * w;
                    // Lower half
                    yStopping -= xrSqTwo;
                    err += yChg;
                    yChg += xrSqTwo;
                }
            }
        }

        private void mp_FillPolygon(Point[] points, Color oColor)
        {
            int lColor = SWM_Color_To_Int32(oColor);
            int w = GetBitmap.PixelWidth;
            int h = GetBitmap.PixelHeight;
            mp_aPixels = GetBitmap.Pixels;
            int pn = points.Length;
            int pnh = points.Length >> 1;
            int[] intersectionsX = new int[pnh + 1];
            int yMin = h;
            int yMax = 0;
            for (int i = 0; i <= pn - 1; i++)
            {
                int py = System.Convert.ToInt32(points[i].Y);
                if (py < yMin)
                {
                    yMin = py;
                }
                if (py > yMax)
                {
                    yMax = py;
                }
            }
            if (yMin < 0)
            {
                yMin = 0;
            }
            if (yMax >= h)
            {
                yMax = h - 1;
            }
            for (int y = yMin; y <= yMax; y++)
            {
                float vxi = System.Convert.ToSingle(points[0].X);
                float vyi = System.Convert.ToSingle(points[0].Y);
                // Based on http://alienryderflex.com/polygon_fill/
                int intersectionCount = 0;
                for (int i = 1; i <= pn - 1; i++)
                {
                    // Next point x, y
                    float vxj = System.Convert.ToSingle(points[i].X);
                    float vyj = System.Convert.ToSingle(points[i].Y);

                    // Is the scanline between the two points
                    if (vyi < y && vyj >= y || vyj < y && vyi >= y)
                    {
                        intersectionsX[intersectionCount] = (int)(vxi + (y - vyi) / (vyj - vyi) * (vxj - vxi));
                        intersectionCount = intersectionCount + 1;
                    }
                    vxi = vxj;
                    vyi = vyj;
                }

                // Sort the intersections from left to right using Insertion sort 
                // It's faster than Array.Sort for this small data set
                int t = 0;
                int j = 0;
                for (int i = 1; i <= intersectionCount - 1; i++)
                {
                    t = intersectionsX[i];
                    j = i;
                    while (j > 0 && intersectionsX[j - 1] > t)
                    {
                        intersectionsX[j] = intersectionsX[j - 1];
                        j = j - 1;
                    }
                    intersectionsX[j] = t;
                }

                // Fill the pixels between the intersections
                for (int i = 0; i <= intersectionCount - 1; i++)
                {
                    int x0 = intersectionsX[i];
                    int x1 = intersectionsX[i + 1];

                    // Check boundary
                    if (x1 > 0 && x0 < w)
                    {
                        if (x0 < 0)
                        {
                            x0 = 0;
                        }
                        if (x1 >= w)
                        {
                            x1 = w - 1;
                        }

                        // Fill the pixels
                        for (int x = x0; x <= x1; x++)
                        {
                            SetPixel(y * w + x, lColor);
                        }
                    }
                }
            }
        }

        private void mp_DrawLine(int x1, int y1, int x2, int y2, Color oColor)
        {
            int lColor = SWM_Color_To_Int32(oColor);
            int w = GetBitmap.PixelWidth;
            mp_aPixels = GetBitmap.Pixels;
            int dx = x2 - x1;
            int dy = y2 - y1;
            const int PRECISION_SHIFT = 8;
            const int PRECISION_VALUE = 1 << PRECISION_SHIFT;
            int lenX = 0;
            int lenY = 0;
            int incy1 = 0;
            if (dy >= 0)
            {
                incy1 = PRECISION_VALUE;
                lenY = dy;
            }
            else
            {
                incy1 = -PRECISION_VALUE;
                lenY = -dy;
            }
            int incx1 = 0;
            if (dx >= 0)
            {
                incx1 = 1;
                lenX = dx;
            }
            else
            {
                incx1 = -1;
                lenX = -dx;
            }
            if (lenX > lenY)
            {
                int incy = (dy << PRECISION_SHIFT) / lenX;
                int y = y1 << PRECISION_SHIFT;
                for (int i = 0; i <= lenX - 1; i++)
                {
                    SetPixel((y >> PRECISION_SHIFT) * w + x1, lColor);
                    x1 += incx1;
                    y += incy;
                }
            }
            else
            {
                if (lenY == 0)
                {
                    return;
                }
                int incx = (dx << PRECISION_SHIFT) / lenY;
                int lIndex = (x1 + y1 * w) << PRECISION_SHIFT;
                int inc = incy1 * w + incx;
                int lArrayPosIndex = 0;
                int lArrayLength = mp_aPixels.Length;
                for (int i = 0; i <= lenY - 1; i++)
                {
                    lArrayPosIndex = (lIndex >> PRECISION_SHIFT);
                    if (lArrayPosIndex < lArrayLength & lArrayPosIndex >= 0)
                    {
                        SetPixel(lArrayPosIndex, lColor);
                    }
                    //// Their Code
                    //pixels(index >> PRECISION_SHIFT) = lColor
                    lIndex += inc;
                }
            }
        }

        //// Public Functions

        public bool PolygonInsideCanvas(Point[] oPoints)
        {
            object lLength = oPoints.Length;
            int i = 0;
            bool bReturn = false;
            int lPointsOutside = 0;
            for (i = 0; i <= (int)lLength - 1; i++)
            {
                if (oPoints[i].X > mp_lClipX1 & oPoints[i].X < mp_lClipX2)
                {
                    if (oPoints[i].Y > mp_lClipY1 & oPoints[i].Y < mp_lClipY2)
                    {
                        bReturn = true;
                    }
                    else
                    {
                        lPointsOutside = lPointsOutside + 1;
                    }
                }
                else
                {
                    lPointsOutside = lPointsOutside + 1;
                }
            }
            if (lPointsOutside > 0)
            {
                mp_bCheckClip = true;
            }
            else
            {
                mp_bCheckClip = false;
            }
            return bReturn;
        }

        public void DrawPolygon(Color oColor, Point[] oPoints)
        {
            mp_DrawPolyline(oPoints, oColor);
            GetBitmap.Invalidate();
        }

        public void DrawEdge(int v_X1, int v_Y1, int v_X2, int v_Y2, Color clrBackColor, GRE_BUTTONSTYLE v_yButtonStyle, GRE_EDGETYPE v_lEdgeType, bool v_bFilled, clsStyle oStyle)
        {
            Color lExteriorLeftTopColor = Colors.White;
            Color lInteriorLeftTopColor = Colors.White;
            Color lExteriorRightBottomColor = Colors.White;
            Color lInteriorRightBottomColor = Colors.White;
            if (v_yButtonStyle == GRE_BUTTONSTYLE.BT_NORMALWINDOWS)
            {
                switch (v_lEdgeType)
                {
                    case GRE_EDGETYPE.ET_RAISED:
                        if (oStyle == null)
                        {
                            lExteriorLeftTopColor = Color.FromArgb(255, 240, 240, 240);
                            lInteriorLeftTopColor = Color.FromArgb(255, 192, 192, 192);
                            lInteriorRightBottomColor = Colors.Gray;
                            lExteriorRightBottomColor = Color.FromArgb(255, 64, 64, 64);
                        }
                        else
                        {
                            lExteriorLeftTopColor = oStyle.ButtonBorderStyle.RaisedExteriorLeftTopColor;
                            lInteriorLeftTopColor = oStyle.ButtonBorderStyle.RaisedInteriorLeftTopColor;
                            lInteriorRightBottomColor = oStyle.ButtonBorderStyle.RaisedInteriorRightBottomColor;
                            lExteriorRightBottomColor = oStyle.ButtonBorderStyle.RaisedExteriorRightBottomColor;
                        }
                        break;
                    case GRE_EDGETYPE.ET_SUNKEN:
                        if (oStyle == null)
                        {
                            lExteriorLeftTopColor = Colors.Gray;
                            lInteriorLeftTopColor = Color.FromArgb(255, 64, 64, 64);
                            lInteriorRightBottomColor = Color.FromArgb(255, 192, 192, 192);
                            lExteriorRightBottomColor = Color.FromArgb(255, 240, 240, 240);
                        }
                        else
                        {
                            lExteriorLeftTopColor = oStyle.ButtonBorderStyle.SunkenExteriorLeftTopColor;
                            lInteriorLeftTopColor = oStyle.ButtonBorderStyle.SunkenInteriorLeftTopColor;
                            lInteriorRightBottomColor = oStyle.ButtonBorderStyle.SunkenInteriorRightBottomColor;
                            lExteriorRightBottomColor = oStyle.ButtonBorderStyle.SunkenExteriorRightBottomColor;
                        }
                        break;
                }
                // Exterior Left
                DrawLine(v_X1, v_Y1, v_X1, v_Y2, GRE_LINETYPE.LT_NORMAL, lExteriorLeftTopColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                // Exterior Top
                DrawLine(v_X1, v_Y1, v_X2, v_Y1, GRE_LINETYPE.LT_NORMAL, lExteriorLeftTopColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                // Exterior Right
                DrawLine(v_X2, v_Y2, v_X2, v_Y1, GRE_LINETYPE.LT_NORMAL, lExteriorRightBottomColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                // Exterior Bottom
                DrawLine(v_X1, v_Y2, v_X2, v_Y2, GRE_LINETYPE.LT_NORMAL, lExteriorRightBottomColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                // Interior Left
                DrawLine(v_X1 + 1, v_Y1 + 1, v_X1 + 1, v_Y2 - 1, GRE_LINETYPE.LT_NORMAL, lInteriorLeftTopColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                // Interior Top
                DrawLine(v_X1 + 1, v_Y1 + 1, v_X2 - 1, v_Y1 + 1, GRE_LINETYPE.LT_NORMAL, lInteriorLeftTopColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                // Interior Right
                DrawLine(v_X2 - 1, v_Y2 - 1, v_X2 - 1, v_Y1 + 1, GRE_LINETYPE.LT_NORMAL, lInteriorRightBottomColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                // Interior Bottom
                DrawLine(v_X1 + 1, v_Y2 - 1, v_X2 - 1, v_Y2 - 1, GRE_LINETYPE.LT_NORMAL, lInteriorRightBottomColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                if (v_bFilled == true)
                {
                    DrawLine(v_X1 + 2, v_Y1 + 2, v_X2 - 2, v_Y2 - 2, GRE_LINETYPE.LT_FILLED, clrBackColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                }
            }
            else
            {
                switch (v_lEdgeType)
                {
                    case GRE_EDGETYPE.ET_RAISED:
                        if (oStyle == null)
                        {
                            lExteriorLeftTopColor = Colors.White;
                            lExteriorRightBottomColor = Color.FromArgb(255, 64, 64, 64);
                        }
                        else
                        {
                            lExteriorLeftTopColor = oStyle.ButtonBorderStyle.RaisedExteriorLeftTopColor;
                            lExteriorRightBottomColor = oStyle.ButtonBorderStyle.RaisedExteriorRightBottomColor;
                        }
                        break;
                    case GRE_EDGETYPE.ET_SUNKEN:
                        if (oStyle == null)
                        {
                            lExteriorLeftTopColor = Colors.Gray;
                            lExteriorRightBottomColor = Color.FromArgb(255, 255, 255, 255);
                        }
                        else
                        {
                            lExteriorLeftTopColor = oStyle.ButtonBorderStyle.SunkenExteriorLeftTopColor;
                            lExteriorRightBottomColor = oStyle.ButtonBorderStyle.SunkenExteriorRightBottomColor;
                        }
                        break;
                }
                DrawLine(v_X1, v_Y1, v_X2, v_Y1, GRE_LINETYPE.LT_NORMAL, lExteriorLeftTopColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                DrawLine(v_X1, v_Y1, v_X1, v_Y2, GRE_LINETYPE.LT_NORMAL, lExteriorLeftTopColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                DrawLine(v_X1, v_Y2, v_X2, v_Y2, GRE_LINETYPE.LT_NORMAL, lExteriorRightBottomColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                DrawLine(v_X2, v_Y2, v_X2, v_Y1 - 1, GRE_LINETYPE.LT_NORMAL, lExteriorRightBottomColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                if (v_bFilled == true)
                {
                    DrawLine(v_X1 + 1, v_Y1 + 1, v_X2 - 1, v_Y2 - 1, GRE_LINETYPE.LT_FILLED, clrBackColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                }
            }
        }

        public void DrawLine(int v_X1, int v_Y1, int v_X2, int v_Y2, GRE_LINETYPE v_yStyle, Color oColor, GRE_LINEDRAWSTYLE v_lDrawStyle)
        {
            DrawLine(v_X1, v_Y1, v_X2, v_Y2, v_yStyle, oColor, v_lDrawStyle, 1, true);
        }

        public void DrawLine(int v_X1, int v_Y1, int v_X2, int v_Y2, GRE_LINETYPE v_yStyle, Color oColor, GRE_LINEDRAWSTYLE v_lDrawStyle, int v_lWidth)
        {
            DrawLine(v_X1, v_Y1, v_X2, v_Y2, v_yStyle, oColor, v_lDrawStyle, v_lWidth, true);
        }

        public void DrawLine(int v_X1, int v_Y1, int v_X2, int v_Y2, GRE_LINETYPE v_yStyle, Color oColor, GRE_LINEDRAWSTYLE v_lDrawStyle, int v_lWidth, bool v_bCreatePens)
        {
            if ((v_X1 < mp_lClipX1 & v_X2 < mp_lClipX1) | (v_X1 > mp_lClipX2 & v_X2 > mp_lClipX2))
            {
                return;
            }
            if ((v_Y1 < mp_lClipY1 & v_Y2 < mp_lClipY1) | (v_Y1 > mp_lClipY2 & v_Y2 > mp_lClipY2))
            {
                return;
            }
            CorrectRectCoords(ref v_X1, ref v_Y1, ref v_X2, ref v_Y2);

            //Select Case v_lDrawStyle
            //    Case GRE_LINEDRAWSTYLE.LDS_SOLID
            //        mp_ucPen.DashStyle = Drawing.Drawing2D.DashStyle.Solid
            //    Case GRE_LINEDRAWSTYLE.LDS_DOT
            //        mp_ucPen.DashStyle = Drawing.Drawing2D.DashStyle.Dot
            //End Select
            switch (v_yStyle)
            {
                case GRE_LINETYPE.LT_NORMAL:
                    if (v_Y1 == v_Y2)
                    {
                        v_X2 = v_X2 + 1;
                    }
                    else if (v_X1 == v_X2)
                    {
                        v_Y2 = v_Y2 + 1;
                    }

                    mp_DrawLineDDA(v_X1, v_Y1, v_X2, v_Y2, oColor);
                    break;
                case GRE_LINETYPE.LT_BORDER:
                    DrawLine(v_X1, v_Y1, v_X2, v_Y1, GRE_LINETYPE.LT_NORMAL, oColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                    DrawLine(v_X1, v_Y2, v_X2, v_Y2, GRE_LINETYPE.LT_NORMAL, oColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                    DrawLine(v_X1, v_Y1, v_X1, v_Y2, GRE_LINETYPE.LT_NORMAL, oColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                    DrawLine(v_X2, v_Y1, v_X2, v_Y2, GRE_LINETYPE.LT_NORMAL, oColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                    break;
                case GRE_LINETYPE.LT_FILLED:
                    mp_FillRectangle(v_X1, v_Y1, v_X2, v_Y2, oColor);
                    break;
            }
            GetBitmap.Invalidate();
        }

        private void mp_InsideClipRegion(int X, int Y)
        {
            if (X > mp_lClipX1 & X < mp_lClipX2 & Y > mp_lClipY1 & Y < mp_lClipY2)
            {
                mp_bCheckClip = false;
            }
            else
            {
                mp_bCheckClip = true;
            }
        }

        public void DrawFigure(int X, int Y, int dx, int dy, GRE_FIGURETYPE yFigureType, Color oBorderColor, Color oFillColor, GRE_LINEDRAWSTYLE yBorderStyle)
        {
            mp_InsideClipRegion(X, Y);
            if (dx % 2 != 0)
            {
                dx = dx + 1;
                dy = dy + 1;
            }
            switch (yFigureType)
            {
                case GRE_FIGURETYPE.FT_PROJECTUP:
                    {
                        Point[] Points = new Point[6];
                        Points[0].X = X;
                        Points[0].Y = Y;
                        Points[1].X = X + dx / 2;
                        Points[1].Y = Y + dy / 2;
                        Points[2].X = X + dx / 2;
                        Points[2].Y = Y + dy;
                        Points[3].X = X - dx / 2;
                        Points[3].Y = Y + dy;
                        Points[4].X = X - dx / 2;
                        Points[4].Y = Y + dy / 2;
                        Points[5].X = Points[0].X;
                        Points[5].Y = Points[0].Y;
                        mp_DrawFigureAux(oFillColor, oBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_PROJECTDOWN:
                    {
                        Point[] Points = new Point[6];
                        Points[0].X = X + dx / 2;
                        Points[0].Y = Y;
                        Points[1].X = X + dx / 2;
                        Points[1].Y = Y + dy / 2;
                        Points[2].X = X;
                        Points[2].Y = Y + dy;
                        Points[3].X = X - dx / 2;
                        Points[3].Y = Y + dy / 2;
                        Points[4].X = X - dx / 2;
                        Points[4].Y = Y;
                        Points[5].X = Points[0].X;
                        Points[5].Y = Points[0].Y;
                        mp_DrawFigureAux(oFillColor, oBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_DIAMOND:
                    {
                        Point[] Points = new Point[5];
                        Points[0].X = X;
                        Points[0].Y = Y;
                        Points[1].X = X + dx / 2;
                        Points[1].Y = Y + dy / 2;
                        Points[2].X = X;
                        Points[2].Y = Y + dy;
                        Points[3].X = X - dx / 2;
                        Points[3].Y = Y + dy / 2;
                        Points[4].X = Points[0].X;
                        Points[4].Y = Points[0].Y;
                        mp_DrawFigureAux(oFillColor, oBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_CIRCLEDIAMOND:
                    {
                        Point[] Points = new Point[5];
                        Points[0].X = X;
                        Points[0].Y = Y + dy / 4;
                        Points[1].X = X + dx / 4;
                        Points[1].Y = Y + dy / 2;
                        Points[2].X = X;
                        Points[2].Y = Y + (3 * dy) / 4;
                        Points[3].X = X - dx / 4;
                        Points[3].Y = Y + dy / 2;
                        Points[4].X = Points[0].X;
                        Points[4].Y = Points[0].Y;
                        mp_DrawEllipseCentered(X, Y + dy / 2, dx / 2, dy / 2, oFillColor);
                        mp_DrawFigureAux(oFillColor, oBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_TRIANGLEUP:
                    {
                        Point[] Points = new Point[4];
                        Points[0].X = X;
                        Points[0].Y = Y;
                        Points[1].X = X + dx / 2;
                        Points[1].Y = Y + dy;
                        Points[2].X = X - dx / 2;
                        Points[2].Y = Y + dy;
                        Points[3].X = Points[0].X;
                        Points[3].Y = Points[0].Y;
                        mp_DrawFigureAux(oFillColor, oBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_TRIANGLEDOWN:
                    {
                        Point[] Points = new Point[4];
                        Points[0].X = X + dx / 2;
                        Points[0].Y = Y;
                        Points[1].X = X - dx / 2;
                        Points[1].Y = Y;
                        Points[2].X = X;
                        Points[2].Y = Y + dy;
                        Points[3].X = Points[0].X;
                        Points[3].Y = Points[0].Y;
                        mp_DrawFigureAux(oFillColor, oBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_TRIANGLERIGHT:
                    {
                        Point[] Points = new Point[4];
                        Points[0].X = X;
                        Points[0].Y = Y;
                        Points[1].X = X;
                        Points[1].Y = Y + dy;
                        Points[2].X = X + dx;
                        Points[2].Y = Y + dy / 2;
                        Points[3].X = Points[0].X;
                        Points[3].Y = Points[0].Y;
                        mp_DrawFigureAux(oFillColor, oBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_TRIANGLELEFT:
                    {
                        Point[] Points = new Point[4];
                        Points[0].X = X;
                        Points[0].Y = Y;
                        Points[1].X = X;
                        Points[1].Y = Y + dy;
                        Points[2].X = X - dx;
                        Points[2].Y = Y + dy / 2;
                        Points[3].X = Points[0].X;
                        Points[3].Y = Points[0].Y;
                        mp_DrawFigureAux(oFillColor, oBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_CIRCLETRIANGLEUP:
                    {
                        Point[] Points = new Point[4];
                        Points[0].X = X;
                        Points[0].Y = Y + dy / 4;
                        Points[1].X = X + dx / 4;
                        Points[1].Y = Y + (3 * dy) / 4;
                        Points[2].X = X - dx / 4;
                        Points[2].Y = Y + (3 * dy) / 4;
                        Points[3].X = Points[0].X;
                        Points[3].Y = Points[0].Y;
                        mp_DrawEllipseCentered(X, Y + dy / 2, dx / 2, dy / 2, oFillColor);
                        mp_DrawFigureAux(oFillColor, oBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_CIRCLETRIANGLEDOWN:
                    {
                        Point[] Points = new Point[4];
                        Points[0].X = X - dx / 4;
                        Points[0].Y = Y + dy / 4;
                        Points[1].X = X + dx / 4;
                        Points[1].Y = Y + dy / 4;
                        Points[2].X = X;
                        Points[2].Y = Y + (3 * dy) / 4;
                        Points[3].X = Points[0].X;
                        Points[3].Y = Points[0].Y;
                        mp_DrawEllipseCentered(X, Y + dy / 2, dx / 2, dy / 2, oFillColor);
                        mp_DrawFigureAux(oFillColor, oBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_ARROWUP:
                    {
                        Point[] Points = new Point[8];
                        Points[0].X = X;
                        Points[0].Y = Y;
                        Points[1].X = X + dx / 2;
                        Points[1].Y = Y + dy / 2;
                        Points[2].X = X + dx / 4;
                        Points[2].Y = Y + dy / 2;
                        Points[3].X = X + dx / 4;
                        Points[3].Y = Y + dy;
                        Points[4].X = X - dx / 4;
                        Points[4].Y = Y + dy;
                        Points[5].X = X - dx / 4;
                        Points[5].Y = Y + dy / 2;
                        Points[6].X = X - dx / 2;
                        Points[6].Y = Y + dy / 2;
                        Points[7].X = Points[0].X;
                        Points[7].Y = Points[0].Y;
                        mp_DrawFigureAux(oFillColor, oBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_ARROWDOWN:
                    {
                        Point[] Points = new Point[8];
                        Points[0].X = X - dx / 4;
                        Points[0].Y = Y;
                        Points[1].X = X + dx / 4;
                        Points[1].Y = Y;
                        Points[2].X = X + dx / 4;
                        Points[2].Y = Y + dy / 2;
                        Points[3].X = X + dx / 2;
                        Points[3].Y = Y + dy / 2;
                        Points[4].X = X;
                        Points[4].Y = Y + dy;
                        Points[5].X = X - dx / 2;
                        Points[5].Y = Y + dy / 2;
                        Points[6].X = X - dx / 4;
                        Points[6].Y = Y + dy / 2;
                        Points[7].X = Points[0].X;
                        Points[7].Y = Points[0].Y;
                        mp_DrawFigureAux(oFillColor, oBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_CIRCLEARROWUP:
                    {
                        Point[] Points = new Point[8];
                        Points[0].X = X;
                        Points[0].Y = Y + dy / 4;
                        Points[1].X = X + dx / 4;
                        Points[1].Y = Y + dy / 2;
                        Points[2].X = X + dx / 8;
                        Points[2].Y = Y + dy / 2;
                        Points[3].X = X + dx / 8;
                        Points[3].Y = Y + (3 * dy) / 4;
                        Points[4].X = X - dx / 8;
                        Points[4].Y = Y + (3 * dy) / 4;
                        Points[5].X = X - dx / 8;
                        Points[5].Y = Y + dy / 2;
                        Points[6].X = X - dx / 4;
                        Points[6].Y = Y + dy / 2;
                        Points[7].X = Points[0].X;
                        Points[7].Y = Points[0].Y;
                        mp_DrawEllipseCentered(X, Y + dy / 2, dx / 2, dy / 2, oFillColor);
                        mp_DrawFigureAux(oFillColor, oBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_CIRCLEARROWDOWN:
                    {
                        Point[] Points = new Point[8];
                        Points[0].X = X - dx / 8;
                        Points[0].Y = Y + dy / 4;
                        Points[1].X = X + dx / 8;
                        Points[1].Y = Y + dy / 4;
                        Points[2].X = X + dx / 8;
                        Points[2].Y = Y + dy / 2;
                        Points[3].X = X + dx / 4;
                        Points[3].Y = Y + dy / 2;
                        Points[4].X = X;
                        Points[4].Y = Y + (3 * dy) / 4;
                        Points[5].X = X - dx / 4;
                        Points[5].Y = Y + dy / 2;
                        Points[6].X = X - dx / 8;
                        Points[6].Y = Y + dy / 2;
                        Points[7].X = Points[0].X;
                        Points[7].Y = Points[0].Y;
                        mp_DrawEllipseCentered(X, Y + dy / 2, dx / 2, dy / 2, oFillColor);
                        mp_DrawFigureAux(oFillColor, oBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_SMALLPROJECTUP:
                    {
                        Point[] Points = new Point[6];
                        Points[0].X = X;
                        Points[0].Y = Y + dy / 2;
                        Points[1].X = X + dx / 4;
                        Points[1].Y = Y + (3 * dy) / 4;
                        Points[2].X = X + dx / 4;
                        Points[2].Y = Y + dy;
                        Points[3].X = X - dx / 4;
                        Points[3].Y = Y + dy;
                        Points[4].X = X - dx / 4;
                        Points[4].Y = Y + (3 * dy) / 4;
                        Points[5].X = Points[0].X;
                        Points[5].Y = Points[0].Y;
                        mp_DrawFigureAux(oFillColor, oBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_SMALLPROJECTDOWN:
                    {
                        Point[] Points = new Point[6];
                        Points[0].X = X + dx / 4;
                        Points[0].Y = Y;
                        Points[1].X = X + dx / 4;
                        Points[1].Y = Y + dy / 4;
                        Points[2].X = X;
                        Points[2].Y = Y + dy / 2;
                        Points[3].X = X - dx / 4;
                        Points[3].Y = Y + dy / 4;
                        Points[4].X = X - dx / 4;
                        Points[4].Y = Y;
                        Points[5].X = Points[0].X;
                        Points[5].Y = Points[0].Y;
                        mp_DrawFigureAux(oFillColor, oBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_RECTANGLE:
                    {
                        Point[] Points = new Point[5];
                        Points[0].X = X - dx / 8;
                        Points[0].Y = Y;
                        Points[1].X = X + dx / 8;
                        Points[1].Y = Y;
                        Points[2].X = X + dx / 8;
                        Points[2].Y = Y + dy;
                        Points[3].X = X - dx / 8;
                        Points[3].Y = Y + dy;
                        Points[4].X = Points[0].X;
                        Points[4].Y = Points[0].Y;
                        mp_DrawFigureAux(oFillColor, oBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_SQUARE:
                    {
                        Point[] Points = new Point[5];
                        Points[0].X = X - dx / 4;
                        Points[0].Y = Y + dx / 4;
                        Points[1].X = X + dx / 4;
                        Points[1].Y = Y + dx / 4;
                        Points[2].X = X + dx / 4;
                        Points[2].Y = Y + (3 * dy) / 4;
                        Points[3].X = X - dx / 4;
                        Points[3].Y = Y + (3 * dy) / 4;
                        Points[4].X = Points[0].X;
                        Points[4].Y = Points[0].Y;
                        mp_DrawFigureAux(oFillColor, oBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_CIRCLE:
                    mp_FillEllipseCentered(X, Y + dy / 2, dx - 1, dy - 1, oFillColor);
                    break;
                default:
                    return;
            }

        }

        private void mp_DrawFigureAux(Color oFillColor, Color oBorderColor, Point[] oPoints)
        {
            if (PolygonInsideCanvas(oPoints) == true)
            {
                mp_FillPolygon(oPoints, oFillColor);
                mp_DrawPolyline(oPoints, oBorderColor);
            }
        }

        public void DrawPattern(int v_X1, int v_Y1, int v_X2, int v_Y2, Color oColor, GRE_PATTERN v_lDrawStyle, int v_iPatternFactor)
        {
            int tmp = 0;
            int c = 0;
            int c1 = 0;
            int c2 = 0;
            int i1 = 0;
            int j1 = 0;
            int i2 = 0;
            int j2 = 0;
            if (v_X1 > v_X2)
            {
                tmp = v_X1;
                v_X1 = v_X2;
                v_X2 = tmp;
            }
            if (v_Y1 > v_Y2)
            {
                tmp = v_Y1;
                v_Y1 = v_Y2;
                v_Y2 = tmp;
            }
            if (v_lDrawStyle == GRE_PATTERN.FP_HORIZONTALLINE | v_lDrawStyle == GRE_PATTERN.FP_CROSS)
            {
                for (j1 = (v_Y1 + v_iPatternFactor); j1 <= v_Y2; j1 += v_iPatternFactor)
                {
                    DrawLine(v_X1, j1, v_X2, j1, GRE_LINETYPE.LT_NORMAL, oColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                }
            }
            if (v_lDrawStyle == GRE_PATTERN.FP_VERTICALLINE | v_lDrawStyle == GRE_PATTERN.FP_CROSS)
            {
                for (j1 = (v_X1 + v_iPatternFactor); j1 <= v_X2; j1 += v_iPatternFactor)
                {
                    DrawLine(j1, v_Y1, j1, v_Y2, GRE_LINETYPE.LT_NORMAL, oColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                }
            }
            if (v_lDrawStyle == GRE_PATTERN.FP_UPWARDDIAGONAL | v_lDrawStyle == GRE_PATTERN.FP_DIAGONALCROSS)
            {
                c1 = System.Convert.ToInt32((v_Y1 + v_X1) / v_iPatternFactor + 1);
                c2 = System.Convert.ToInt32((v_Y2 + v_X2) / v_iPatternFactor);
                for (c = c1; c <= c2; c++)
                {
                    i1 = v_X1;
                    i2 = v_X2;
                    j1 = c * v_iPatternFactor - i1;
                    j2 = c * v_iPatternFactor - i2;
                    if (j2 < v_Y1)
                    {
                        i2 = c * v_iPatternFactor - v_Y1;
                        j2 = c * v_iPatternFactor - i2;
                    }
                    if (j1 > v_Y2)
                    {
                        i1 = c * v_iPatternFactor - v_Y2;
                        j1 = c * v_iPatternFactor - i1;
                    }
                    DrawLine(i1, j1, i2, j2, GRE_LINETYPE.LT_NORMAL, oColor, GRE_LINEDRAWSTYLE.LDS_SOLID, 1, false);
                }
            }
            if (v_lDrawStyle == GRE_PATTERN.FP_DOWNWARDDIAGONAL | v_lDrawStyle == GRE_PATTERN.FP_DIAGONALCROSS)
            {
                c1 = System.Convert.ToInt32((v_Y1 - v_X2) / v_iPatternFactor + 1);
                c2 = System.Convert.ToInt32((v_Y2 - v_X1) / v_iPatternFactor);
                for (c = c1; c <= c2; c++)
                {
                    i1 = v_X1;
                    i2 = v_X2;
                    j1 = i1 + c * v_iPatternFactor;
                    j2 = i2 + c * v_iPatternFactor;
                    if (j1 < v_Y1)
                    {
                        i1 = v_Y1 - c * v_iPatternFactor;
                        j1 = i1 + c * v_iPatternFactor;
                    }
                    if (j2 > v_Y2)
                    {
                        i2 = v_Y2 - c * v_iPatternFactor;
                        j2 = i2 + c * v_iPatternFactor;
                    }
                    DrawLine(i1, j1, i2, j2, GRE_LINETYPE.LT_NORMAL, oColor, GRE_LINEDRAWSTYLE.LDS_SOLID, 1, false);
                }
            }
            if (v_lDrawStyle == GRE_PATTERN.FP_LIGHT)
            {
                for (j1 = (v_Y1 + 1); j1 <= (v_Y2 - 1); j1++)
                {
                    if (j1 % 2 == 0)
                    {
                        for (j2 = (v_X1 + 1); j2 <= (v_X2 - 1); j2 += 4)
                        {
                            DrawLine(j2, j1, j2 + 1, j1, GRE_LINETYPE.LT_NORMAL, oColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                        }
                    }
                    else
                    {
                        for (j2 = (v_X1 + 3); j2 <= (v_X2 - 1); j2 += 4)
                        {
                            DrawLine(j2, j1, j2 + 1, j1, GRE_LINETYPE.LT_NORMAL, oColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                        }
                    }
                }
            }
            if (v_lDrawStyle == GRE_PATTERN.FP_MEDIUM)
            {
                for (j1 = (v_Y1 + 1); j1 <= (v_Y2 - 1); j1++)
                {
                    if (j1 % 2 == 0)
                    {
                        for (j2 = (v_X1 + 1); j2 <= (v_X2 - 1); j2 += 2)
                        {
                            DrawLine(j2, j1, j2 + 1, j1, GRE_LINETYPE.LT_NORMAL, oColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                        }
                    }
                    else
                    {
                        for (j2 = (v_X1 + 2); j2 <= (v_X2 - 1); j2 += 2)
                        {
                            DrawLine(j2, j1, j2 + 1, j1, GRE_LINETYPE.LT_NORMAL, oColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                        }
                    }
                }
            }
            if (v_lDrawStyle == GRE_PATTERN.FP_DARK)
            {
                for (j1 = (v_Y1 + 1); j1 <= (v_Y2 - 1); j1++)
                {
                    if (j1 % 2 == 0)
                    {
                        for (j2 = (v_X1 + 1); j2 <= (v_X2 - 1); j2 += 4)
                        {
                            if (j2 + 3 < v_X2)
                            {
                                DrawLine(j2, j1, j2 + 3, j1, GRE_LINETYPE.LT_NORMAL, oColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                            }
                            else
                            {
                                DrawLine(j2, j1, v_X2, j1, GRE_LINETYPE.LT_NORMAL, oColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                            }
                        }
                    }
                    else
                    {
                        DrawLine(v_X1, j1, v_X1 + 2, j1, GRE_LINETYPE.LT_NORMAL, oColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                        for (j2 = (v_X1 + 3); j2 <= (v_X2 - 1); j2 += 4)
                        {
                            if (j2 + 3 < v_X2)
                            {
                                DrawLine(j2, j1, j2 + 3, j1, GRE_LINETYPE.LT_NORMAL, oColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                            }
                            else
                            {
                                DrawLine(j2, j1, v_X2, j1, GRE_LINETYPE.LT_NORMAL, oColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                            }
                        }
                    }
                }
            }
        }


        public void DrawPolyLine(Color oColor, int v_lWidth, GRE_LINEDRAWSTYLE v_lDrawStyle, Point[] r_oPoints, int v_Len)
        {
        }

        public void DrawTextEx(int v_X1, int v_Y1, int v_X2, int v_Y2, string v_sParam, clsTextFlags v_lFlags, Color oColor, Font v_oFont, bool v_bClip)
        {
            if ((v_X1 < mp_lClipX1 & v_X2 < mp_lClipX1) | (v_X1 > mp_lClipX2 & v_X2 > mp_lClipX2))
            {
                return;
            }
            if ((v_Y1 < mp_lClipY1 & v_Y2 < mp_lClipY1) | (v_Y1 > mp_lClipY2 & v_Y2 > mp_lClipY2))
            {
                return;
            }
            TextBlock oTextBlock = new TextBlock();
            oTextBlock.FontFamily = new FontFamily(v_oFont.FamilyName);
            oTextBlock.Text = v_sParam;
            oTextBlock.FontSize = v_oFont.Size;
            oTextBlock.Foreground = new SolidColorBrush(oColor);
            oTextBlock.FontWeight = v_oFont.FontWeight;
            oTextBlock.Measure(new Size(v_X2 - v_X1, v_Y2 - v_Y1));
            int X = 0;
            int Y = 0;
            switch (v_lFlags.HorizontalAlignment)
            {
                case GRE_HORIZONTALALIGNMENT.HAL_LEFT:
                    X = (int)System.Convert.ToDouble(v_X1);
                    break;
                case GRE_HORIZONTALALIGNMENT.HAL_CENTER:
                    X = (int)System.Convert.ToDouble(((v_X2 - v_X1) - oTextBlock.ActualWidth) / 2) + v_X1;
                    break;
                case GRE_HORIZONTALALIGNMENT.HAL_RIGHT:
                    X = (int)System.Convert.ToDouble(v_X2 - oTextBlock.ActualWidth);
                    break;
            }
            switch (v_lFlags.VerticalAlignment)
            {
                case GRE_VERTICALALIGNMENT.VAL_TOP:
                    Y = (int)System.Convert.ToDouble(v_Y1);
                    break;
                case GRE_VERTICALALIGNMENT.VAL_CENTER:
                    Y = (int)System.Convert.ToDouble(((v_Y2 - v_Y1) - oTextBlock.ActualHeight) / 2) + v_Y1;
                    break;
                case GRE_VERTICALALIGNMENT.VAL_BOTTOM:
                    Y = (int)System.Convert.ToDouble(v_Y2 - oTextBlock.ActualHeight);
                    break;
            }

            TranslateTransform oTransform = new TranslateTransform();
            oTransform.X = X;
            oTransform.Y = Y;

            GetBitmap.Render(oTextBlock, oTransform);
            if (v_sParam.Length > 0)
            {
                mp_oTextFinalLayout.X = X;
                mp_oTextFinalLayout.Y = Y;
                mp_oTextFinalLayout.Width = oTextBlock.ActualWidth;
                mp_oTextFinalLayout.Height = oTextBlock.ActualHeight;
            }
            GetBitmap.Invalidate();

        }

        public void DrawAlignedText(int v_lLeft, int v_lTop, int v_lRight, int v_lBottom, string v_sParam, GRE_HORIZONTALALIGNMENT v_yHPos, GRE_VERTICALALIGNMENT v_yVPos, Color oColor, Font v_oFont)
        {
            DrawAlignedText(v_lLeft, v_lTop, v_lRight, v_lBottom, v_sParam, v_yHPos, v_yVPos, oColor, v_oFont, true
            );
        }

        public void DrawAlignedText(int v_lLeft, int v_lTop, int v_lRight, int v_lBottom, string v_sParam, GRE_HORIZONTALALIGNMENT v_yHPos, GRE_VERTICALALIGNMENT v_yVPos, Color oColor, Font v_oFont, bool v_bClip
        )
        {
            if ((v_lLeft < mp_lClipX1 & v_lRight < mp_lClipX1) | (v_lLeft > mp_lClipX2 & v_lRight > mp_lClipX2))
            {
                return;
            }
            if ((v_lTop < mp_lClipY1 & v_lBottom < mp_lClipY1) | (v_lTop > mp_lClipY2 & v_lBottom > mp_lClipY2))
            {
                return;
            }
            TextBlock oTextBlock = new TextBlock();
            oTextBlock.FontFamily = new FontFamily(v_oFont.FamilyName);
            oTextBlock.Text = v_sParam;
            oTextBlock.FontSize = v_oFont.Size;
            oTextBlock.Foreground = new SolidColorBrush(oColor);
            oTextBlock.FontWeight = v_oFont.FontWeight;
            if (v_lRight - v_lLeft <= 0)
            {
                return;
            }
            if (v_lBottom - v_lTop <= 0)
            {
                return;
            }
            oTextBlock.Measure(new Size(v_lRight - v_lLeft, v_lBottom - v_lTop));

            int X = 0;
            int Y = 0;
            switch (v_yHPos)
            {
                case GRE_HORIZONTALALIGNMENT.HAL_LEFT:
                    X = (int)System.Convert.ToDouble(v_lLeft);
                    break;
                case GRE_HORIZONTALALIGNMENT.HAL_CENTER:
                    X = (int)System.Convert.ToDouble(((v_lRight - v_lLeft) - oTextBlock.ActualWidth) / 2) + v_lLeft;
                    break;
                case GRE_HORIZONTALALIGNMENT.HAL_RIGHT:
                    X = (int)System.Convert.ToDouble(v_lRight - oTextBlock.ActualWidth);
                    break;
            }
            switch (v_yVPos)
            {
                case GRE_VERTICALALIGNMENT.VAL_TOP:
                    Y = (int)System.Convert.ToDouble(v_lTop);
                    break;
                case GRE_VERTICALALIGNMENT.VAL_CENTER:
                    Y = (int)System.Convert.ToDouble(((v_lBottom - v_lTop) - oTextBlock.ActualHeight) / 2) + v_lTop;
                    break;
                case GRE_VERTICALALIGNMENT.VAL_BOTTOM:
                    Y = (int)System.Convert.ToDouble(v_lBottom - oTextBlock.ActualHeight);
                    break;
            }

            int lClipX1 = 0;
            int lClipX2 = 0;
            int lClipY1 = 0;
            int lClipY2 = 0;
            if ((X - mp_lClipX1) > 0)
            {
                lClipX1 = 0;
            }
            else
            {
                lClipX1 = mp_lClipX1 - X;
            }
            if (((X + oTextBlock.ActualWidth) - mp_lClipX2) > 0)
            {
                lClipX2 = ((X + (int)oTextBlock.ActualWidth) - mp_lClipX2);
            }
            else
            {
                lClipX2 = 0;
            }

            if ((Y - mp_lClipY1) > 0)
            {
                lClipY1 = 0;
            }
            else
            {
                lClipY1 = mp_lClipY1 - Y;
            }
            if (((Y + oTextBlock.ActualHeight) - mp_lClipY2) > 0)
            {
                lClipY2 = ((Y + (int)oTextBlock.ActualHeight) - mp_lClipY2);
            }
            else
            {
                lClipY2 = 0;
            }
            if ((X + oTextBlock.ActualWidth) < mp_lClipX1 | X > mp_lClipX2)
            {
                return;
            }
            if ((Y + oTextBlock.ActualHeight) < mp_lClipY1 | Y > mp_lClipY2)
            {
                return;
            }


            RectangleGeometry oClipRectangle = new RectangleGeometry();
            if (oTextBlock.ActualWidth - lClipX2 <= 0)
            {
                return;
            }
            if (oTextBlock.ActualHeight - lClipY2 <= 0)
            {
                return;
            }
            oClipRectangle.Rect = new System.Windows.Rect(lClipX1, lClipY1, oTextBlock.ActualWidth - lClipX2, oTextBlock.ActualHeight - lClipY2);
            oTextBlock.Clip = oClipRectangle;

            TranslateTransform oTransform = new TranslateTransform();
            oTransform.X = X;
            oTransform.Y = Y;

            GetBitmap.Render(oTextBlock, oTransform);
            if (v_sParam.Length > 0)
            {
                mp_oTextFinalLayout.X = X;
                mp_oTextFinalLayout.Y = Y;
                mp_oTextFinalLayout.Width = oTextBlock.ActualWidth;
                mp_oTextFinalLayout.Height = oTextBlock.ActualHeight;
            }
            GetBitmap.Invalidate();
        }

        public void CorrectRectCoords(ref int X1, ref int Y1, ref int X2, ref int Y2)
        {
            int iBuff = 0;
            if ((X2 - X1) < 0)
            {
                iBuff = X1;
                X1 = X2;
                X2 = iBuff;
            }
            if ((Y2 - Y1) < 0)
            {
                iBuff = Y1;
                Y1 = Y2;
                Y2 = iBuff;
            }
            bool bStraightLine_H = false;
            bool bStraightLine_V = false;
            bool bFill = false;
            bool bCheckClip = false;

            if ((Y1 == Y2))
            {
                bStraightLine_H = true;
            }
            else if ((X1 == X2))
            {
                bStraightLine_V = true;
            }
            else
            {
                bFill = true;
            }
            if (bStraightLine_H == true | bFill == true)
            {
                if (X1 < mp_lClipX1)
                {
                    if (System.Math.Abs(mp_lClipX1 - X1) > 10)
                    {
                        X1 = mp_lClipX1 - 1;
                    }
                    bCheckClip = true;
                }
                if (X2 > mp_lClipX2)
                {
                    if (System.Math.Abs(X2 - mp_lClipX2) > 10)
                    {
                        X2 = mp_lClipX2 + 1;
                    }
                    bCheckClip = true;
                }
            }
            if (bStraightLine_V == true | bFill == true)
            {
                if (Y1 < mp_lClipY1)
                {
                    if (System.Math.Abs(mp_lClipY1 - Y1) > 10)
                    {
                        Y1 = mp_lClipY1 - 1;
                    }
                    bCheckClip = true;
                }
                if (Y2 > mp_lClipY2)
                {
                    if (System.Math.Abs(Y2 - mp_lClipY2) > 10)
                    {
                        Y2 = mp_lClipY2 + 1;
                    }
                    bCheckClip = true;
                }
            }
            mp_bCheckClip = bCheckClip;
        }

        public void ClipRegion(int v_X1, int v_Y1, int v_X2, int v_Y2, bool v_bStore)
        {
            //Dim iBuff As Integer = 0
            //If (v_X2 - v_X1) < 0 Then
            //    iBuff = v_X1
            //    v_X1 = v_X2
            //    v_X2 = iBuff
            //End If
            //If (v_Y2 - v_Y1) < 0 Then
            //    iBuff = v_Y1
            //    v_Y1 = v_Y2
            //    v_Y2 = iBuff
            //End If
            //If Not v_X1 < v_X2 Then
            //    ClearClipRegion()
            //    Return
            //End If
            //If Not v_Y1 < v_Y2 Then
            //    ClearClipRegion()
            //    Return
            //End If
            mp_lClipX1 = v_X1;
            mp_lClipY1 = v_Y1;
            mp_lClipX2 = v_X2;
            mp_lClipY2 = v_Y2;
            if (v_bStore == true)
            {
                mp_udtPreviousClipRegion.lLeft = v_X1;
                mp_udtPreviousClipRegion.lRight = v_X2;
                mp_udtPreviousClipRegion.lTop = v_Y1;
                mp_udtPreviousClipRegion.lBottom = v_Y2;
            }
        }

        public void RestorePreviousClipRegion()
        {
            ClipRegion(mp_udtPreviousClipRegion.lLeft, mp_udtPreviousClipRegion.lTop, mp_udtPreviousClipRegion.lRight, mp_udtPreviousClipRegion.lBottom, false);
        }

        public void ClearClipRegion()
        {
            mp_lClipX1 = 0;
            mp_lClipY1 = 0;
            mp_lClipX2 = Width;
            mp_lClipY2 = Height;
        }

        public void TileImageHorizontal(Image ImageHandle, int v_X1, int v_Y1, int v_X2, int v_Y2, bool v_bTransparent)
        {
            int X = 0;
            int lImageWidth = 0;
            int lImageHeight = 0;
            lImageHeight = (int)ImageHandle.Height;
            lImageWidth = (int)ImageHandle.Width;
            while (X < (v_X2 - v_X1))
            {
                if ((X + lImageWidth) > (v_X2 - v_X1))
                {
                    PaintImage(ImageHandle, v_X2 - lImageWidth, v_Y1, v_X2, v_Y1 + lImageHeight, 0, 0, v_bTransparent);
                }
                else
                {
                    PaintImage(ImageHandle, v_X1 + X, v_Y1, v_X1 + X + lImageWidth, v_Y1 + lImageHeight, 0, 0, v_bTransparent);
                }
                X = X + lImageWidth;
            }
        }


        public void PaintImage(Image oImage, int X1, int Y1, int X2, int Y2, int xOrigin, int yOrigin, bool bUseMask)
        {
            int lClipX1 = 0;
            int lClipX2 = 0;
            int lClipY1 = 0;
            int lClipY2 = 0;

            if ((mp_lClipX1 - X1) > 0)
            {
                lClipX1 = mp_lClipX1 - X1;
            }
            else
            {
                lClipX1 = 0;
            }
            if ((mp_lClipX2 - X2) > 0)
            {
                lClipX2 = 0;
            }
            else
            {
                lClipX2 = X2 - mp_lClipX2;
            }

            if ((mp_lClipY1 - Y1) > 0)
            {
                lClipY1 = mp_lClipY1 - Y1;
            }
            else
            {
                lClipY1 = 0;
            }
            if ((mp_lClipY2 - Y2) > 0)
            {
                lClipY2 = 0;
            }
            else
            {
                lClipY2 = Y2 - mp_lClipY2;
            }



            RectangleGeometry oClipRectangle = new RectangleGeometry();
            if (oImage.Width - lClipX2 <= 0)
            {
                return;
            }
            if (oImage.Height - lClipY2 <= 0)
            {
                return;
            }
            oClipRectangle.Rect = new System.Windows.Rect(lClipX1, lClipY1, oImage.Width - lClipX2, oImage.Height - lClipY2);
            oImage.Clip = oClipRectangle;

            TranslateTransform oTransform = new TranslateTransform();
            oTransform.X = X1;
            oTransform.Y = Y1;
            //oImage.Measure(New Size(X2 - X1, Y2 - Y1))
            //oImage.Arrange(New Rect(0, 0, X2 - X1, Y2 - Y1))
            GetBitmap.Render(oImage, oTransform);
            GetBitmap.Invalidate();
        }

        public void DrawImage(Image v_oImage, GRE_HORIZONTALALIGNMENT v_yHorizontalAlignment, GRE_VERTICALALIGNMENT v_yVerticalAlignment, int v_lImageXMargin, int v_lImageYMargin, int v_lLeft, int v_lRight, int v_lTop, int v_lBottom, bool v_bTransparent
        )
        {
            bool bDrawImage = false;
            bool bHorizontalSmall = false;
            bool bVerticalSmall = false;
            int XOrigin = 0;
            int YOrigin = 0;
            int xDest = 0;
            int yDest = 0;
            int lxWidth = 0;
            int lyHeight = 0;
            int lImageHeight = 0;
            int lImageWidth = 0;
            if ((v_oImage == null))
            {
                return;
            }
            lImageHeight = (int)v_oImage.Height;
            lImageWidth = (int)v_oImage.Width;
            if (v_yHorizontalAlignment == GRE_HORIZONTALALIGNMENT.HAL_CENTER)
            {
                v_lImageXMargin = 0;
            }
            if (v_yVerticalAlignment == GRE_VERTICALALIGNMENT.VAL_CENTER)
            {
                v_lImageYMargin = 0;
            }
            bDrawImage = true;
            if ((v_lRight - v_lLeft) < (lImageWidth + v_lImageXMargin))
            {
                lxWidth = v_lRight - v_lLeft - v_lImageXMargin;
                if (lxWidth <= 0) bDrawImage = false;
                bHorizontalSmall = true;
            }
            else
            {
                lxWidth = lImageWidth;
                bHorizontalSmall = false;
            }
            if ((v_lBottom - v_lTop) < (lImageHeight + v_lImageYMargin))
            {
                lyHeight = v_lBottom - v_lTop - v_lImageYMargin;
                if (lyHeight <= 0) bDrawImage = false;
                bVerticalSmall = true;
            }
            else
            {
                lyHeight = lImageHeight;
                bVerticalSmall = false;
            }
            if (bHorizontalSmall == false)
            {
                switch (v_yHorizontalAlignment)
                {
                    case GRE_HORIZONTALALIGNMENT.HAL_LEFT:
                        xDest = v_lLeft + v_lImageXMargin;
                        break;
                    case GRE_HORIZONTALALIGNMENT.HAL_CENTER:
                        xDest = ((v_lRight - v_lLeft) - lImageWidth) / 2 + v_lLeft;
                        break;
                    case GRE_HORIZONTALALIGNMENT.HAL_RIGHT:
                        xDest = v_lRight - lImageWidth - v_lImageXMargin;
                        break;
                }
                XOrigin = 0;
            }
            else
            {
                switch (v_yHorizontalAlignment)
                {
                    case GRE_HORIZONTALALIGNMENT.HAL_LEFT:
                        XOrigin = 0;
                        xDest = v_lLeft + v_lImageXMargin;
                        break;
                    case GRE_HORIZONTALALIGNMENT.HAL_CENTER:
                        XOrigin = (lImageWidth - lxWidth) / 2;
                        xDest = v_lLeft;
                        break;
                    case GRE_HORIZONTALALIGNMENT.HAL_RIGHT:
                        XOrigin = lImageWidth - lxWidth;
                        xDest = v_lRight - lxWidth - v_lImageXMargin;
                        break;
                }
            }
            if (bVerticalSmall == false)
            {
                switch (v_yVerticalAlignment)
                {
                    case GRE_VERTICALALIGNMENT.VAL_TOP:
                        yDest = v_lTop + v_lImageYMargin;
                        break;
                    case GRE_VERTICALALIGNMENT.VAL_CENTER:
                        yDest = ((v_lBottom - v_lTop) - lImageHeight) / 2 + v_lTop;
                        break;
                    case GRE_VERTICALALIGNMENT.VAL_BOTTOM:
                        yDest = v_lBottom - lImageHeight - v_lImageYMargin;
                        break;
                }
                YOrigin = 0;
            }
            else
            {
                switch (v_yVerticalAlignment)
                {
                    case GRE_VERTICALALIGNMENT.VAL_TOP:
                        YOrigin = 0;
                        yDest = v_lTop + v_lImageYMargin;
                        break;
                    case GRE_VERTICALALIGNMENT.VAL_CENTER:
                        YOrigin = (lImageHeight - lyHeight) / 2;
                        yDest = v_lTop;
                        break;
                    case GRE_VERTICALALIGNMENT.VAL_BOTTOM:
                        YOrigin = lImageHeight - lyHeight;
                        yDest = v_lBottom - lyHeight - v_lImageYMargin;
                        break;
                }
            }
            if (bDrawImage == true)
            {
                PaintImage(v_oImage, xDest, yDest, xDest + lxWidth, yDest + lyHeight, XOrigin, YOrigin, v_bTransparent);
            }
        }

        public void DrawFocusRectangle(int v_X1, int v_Y1, int v_X2, int v_Y2)
        {
            DrawLine(v_X1, v_Y1, v_X2, v_Y2, GRE_LINETYPE.LT_BORDER, mp_oControl.SelectionColor, GRE_LINEDRAWSTYLE.LDS_DOT);
        }

        public void GradientFill(int v_X1, int v_Y1, int v_X2, int v_Y2, Color clrStartColor, Color clrEndColor, GRE_GRADIENTFILLMODE iGradientType)
        {
            if ((v_X2 - v_X1) <= 0)
            {
                return;
            }
            if ((v_Y2 - v_Y1) <= 0)
            {
                return;
            }
            if ((v_X1 < mp_lClipX1 & v_X2 < mp_lClipX1) | (v_X1 > mp_lClipX2 & v_X2 > mp_lClipX2))
            {
                return;
            }
            if ((v_Y1 < mp_lClipY1 & v_Y2 < mp_lClipY1) | (v_Y1 > mp_lClipY2 & v_Y2 > mp_lClipY2))
            {
                return;
            }

            LinearGradientBrush oBrush = null;
            GradientStopCollection oGradientStopCollection = new GradientStopCollection();
            GradientStop oGradientStopStart = new GradientStop();
            GradientStop oGradientStopEnd = new GradientStop();
            Rectangle oRectangle = new Rectangle();
            oGradientStopStart.Color = clrStartColor;
            oGradientStopStart.Offset = 0;
            oGradientStopEnd.Color = clrEndColor;
            oGradientStopEnd.Offset = 1;
            oGradientStopCollection.Add(oGradientStopEnd);
            oGradientStopCollection.Add(oGradientStopStart);

            if ((iGradientType == GRE_GRADIENTFILLMODE.GDT_VERTICAL))
            {
                oBrush = new LinearGradientBrush(oGradientStopCollection, 90.0);
            }
            else if ((iGradientType == GRE_GRADIENTFILLMODE.GDT_HORIZONTAL))
            {
                oBrush = new LinearGradientBrush(oGradientStopCollection, 0.0);
            }

            oRectangle.Width = v_X2 - v_X1 + 1;
            oRectangle.Height = v_Y2 - v_Y1 + 1;
            oRectangle.Fill = oBrush;

            int lClipX1 = 0;
            int lClipX2 = 0;
            int lClipY1 = 0;
            int lClipY2 = 0;

            if ((mp_lClipX1 - v_X1) > 0)
            {
                lClipX1 = mp_lClipX1 - v_X1;
            }
            else
            {
                lClipX1 = 0;
            }
            if ((mp_lClipX2 - v_X2) > 0)
            {
                lClipX2 = 0;
            }
            else
            {
                lClipX2 = v_X2 - mp_lClipX2;
            }

            if ((mp_lClipY1 - v_Y1) > 0)
            {
                lClipY1 = mp_lClipY1 - v_Y1;
            }
            else
            {
                lClipY1 = 0;
            }
            if ((mp_lClipY2 - v_Y2) > 0)
            {
                lClipY2 = 0;
            }
            else
            {
                lClipY2 = v_Y2 - mp_lClipY2;
            }

            RectangleGeometry oClipRectangle = new RectangleGeometry();
            if (oRectangle.Width - lClipX2 <= 0)
            {
                return;
            }
            if (oRectangle.Height - lClipY2 <= 0)
            {
                return;
            }
            oClipRectangle.Rect = new System.Windows.Rect(lClipX1, lClipY1, oRectangle.Width - lClipX2, oRectangle.Height - lClipY2);
            oRectangle.Clip = oClipRectangle;

            TranslateTransform oTransform = new TranslateTransform();
            oTransform.X = v_X1;
            oTransform.Y = v_Y1;

            GetBitmap.Render(oRectangle, oTransform);
            GetBitmap.Invalidate();
        }

        public void HatchFill(int v_X1, int v_Y1, int v_X2, int v_Y2, Color oForeColor, Color oBackColor, GRE_HATCHSTYLE yHatchStyle)
        {
            CorrectRectCoords(ref v_X1, ref v_Y1, ref v_X2, ref v_Y2);
            int lBackColor = SWM_Color_To_Int32(oBackColor);
            int lForeColor = SWM_Color_To_Int32(oForeColor);
            mp_aPixels = GetBitmap.Pixels;
            int iPixelCount = mp_aPixels.Length;
            int lWidth = GetBitmap.PixelWidth;
            int lHeight = GetBitmap.PixelHeight;
            int y = 0;
            int x = 0;
            int iy = 0;
            int ix = 0;
            int xOffset = 0;
            int xDistance = 0;
            int yDistance = 0;
            int xStart = 0;
            int xEnd = 0;
            int yEnd = 0;
            int[,] aRect = null;

            if (v_X1 > lWidth)
            {
                return;
            }
            if (v_Y1 > lHeight)
            {
                return;
            }
            if (v_X1 < 0)
            {
                v_X1 = 0;
            }
            if (v_X2 > lWidth)
            {
                v_X2 = lWidth;
            }

            if (v_Y1 < 0)
            {
                v_Y1 = 0;
            }
            if (v_Y2 > lHeight)
            {
                v_Y2 = lHeight;
            }
            if (yHatchStyle == GRE_HATCHSTYLE.HS_PERCENT60 | yHatchStyle == GRE_HATCHSTYLE.HS_PERCENT70 | yHatchStyle == GRE_HATCHSTYLE.HS_PERCENT75 | yHatchStyle == GRE_HATCHSTYLE.HS_PERCENT80 | yHatchStyle == GRE_HATCHSTYLE.HS_PERCENT90)
            {
                for (y = v_Y1; y <= v_Y2; y++)
                {
                    for (x = v_X1; x <= v_X2; x++)
                    {
                        SetPixel((y * lWidth) + x, lForeColor);
                    }
                }
            }
            else
            {
                for (y = v_Y1; y <= v_Y2; y++)
                {
                    for (x = v_X1; x <= v_X2; x++)
                    {
                        SetPixel((y * lWidth) + x, lBackColor);
                    }
                }
            }



            switch (yHatchStyle)
            {
                case GRE_HATCHSTYLE.HS_HORIZONTAL:
                    yDistance = 8;
                    for (y = v_Y1; y <= v_Y2; y += yDistance)
                    {
                        for (x = v_X1; x <= v_X2; x++)
                        {
                            SetPixel((y * lWidth) + x, lForeColor);
                        }
                    }

                    break;
                case GRE_HATCHSTYLE.HS_VERTICAL:
                    xDistance = 8;
                    for (y = v_Y1; y <= v_Y2; y++)
                    {
                        for (x = v_X1; x <= v_X2; x += xDistance)
                        {
                            SetPixel((y * lWidth) + x, lForeColor);
                        }
                    }

                    break;
                case GRE_HATCHSTYLE.HS_FORWARDDIAGONAL:
                    xDistance = 8;
                    for (y = v_Y1; y <= v_Y2; y++)
                    {
                        xStart = (y * lWidth) + v_X1;
                        xEnd = (y * lWidth) + v_X2;
                        for (x = (xStart - xDistance); x <= (xEnd + xDistance); x += xDistance)
                        {
                            if ((x + xOffset) >= xStart & (x + xOffset) <= xEnd)
                            {
                                SetPixel(x + xOffset, lForeColor);
                            }
                        }
                        xOffset = xOffset + 1;
                        if (xOffset > (xDistance - 1))
                        {
                            xOffset = 0;
                        }
                    }

                    break;
                case GRE_HATCHSTYLE.HS_BACKWARDDIAGONAL:
                    xDistance = 8;
                    for (y = v_Y1; y <= v_Y2; y++)
                    {
                        xStart = (y * lWidth) + v_X1;
                        xEnd = (y * lWidth) + v_X2;
                        for (x = (xStart - xDistance); x <= (xEnd + xDistance); x += xDistance)
                        {
                            if ((x - xOffset) >= xStart & (x - xOffset) <= xEnd)
                            {
                                SetPixel(x - xOffset, lForeColor);
                            }
                        }
                        xOffset = xOffset + 1;
                        if (xOffset > (xDistance - 1))
                        {
                            xOffset = 0;
                        }
                    }

                    break;
                case GRE_HATCHSTYLE.HS_LARGEGRID:
                    xDistance = 8;
                    yDistance = 8;
                    for (y = (v_Y1); y <= v_Y2; y += yDistance)
                    {
                        for (x = v_X1; x <= v_X2; x++)
                        {
                            SetPixel((y * lWidth) + x, lForeColor);
                        }
                    }

                    for (y = v_Y1; y <= v_Y2; y++)
                    {
                        for (x = (v_X1); x <= v_X2; x += xDistance)
                        {
                            SetPixel((y * lWidth) + x, lForeColor);
                        }
                    }

                    break;
                case GRE_HATCHSTYLE.HS_DIAGONALCROSS:
                    xDistance = 8;
                    for (y = v_Y1; y <= v_Y2; y++)
                    {
                        xStart = (y * lWidth) + v_X1;
                        xEnd = (y * lWidth) + v_X2;
                        for (x = (xStart - xDistance); x <= (xEnd + xDistance); x += xDistance)
                        {
                            if ((x + xOffset) >= xStart & (x + xOffset) <= xEnd)
                            {
                                SetPixel(x + xOffset, lForeColor);
                            }
                        }
                        xOffset = xOffset + 1;
                        if (xOffset > (xDistance - 1))
                        {
                            xOffset = 0;
                        }
                    }

                    for (y = v_Y1; y <= v_Y2; y++)
                    {
                        xStart = (y * lWidth) + v_X1;
                        xEnd = (y * lWidth) + v_X2;
                        for (x = (xStart - xDistance); x <= (xEnd + xDistance); x += xDistance)
                        {
                            if ((x - xOffset) >= xStart & (x - xOffset) <= xEnd)
                            {
                                SetPixel(x - xOffset, lForeColor);
                            }
                        }
                        xOffset = xOffset + 1;
                        if (xOffset > (xDistance - 1))
                        {
                            xOffset = 0;
                        }
                    }

                    break;
                case GRE_HATCHSTYLE.HS_PERCENT05:
                    aRect = new int[, ] {
                    { 0, 0, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 1, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0 } 
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lForeColor);

                    break;
                case GRE_HATCHSTYLE.HS_PERCENT10:
                    aRect = new int[, ] 
                    { 
                    { 0, 0, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 1, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 1, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0 }
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lForeColor);

                    break;
                case GRE_HATCHSTYLE.HS_PERCENT20:
                    aRect = new int[, ] {
                    { 1, 0, 0, 0, 1, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 1, 0, 0, 0, 1, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 1, 0, 0, 0, 1, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 1, 0, 0, 0, 1, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 } 
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lForeColor);

                    break;
                case GRE_HATCHSTYLE.HS_PERCENT25:
                    aRect = new int[, ] { 
                    { 1, 0, 0, 0, 1, 0, 0, 0 }, 
                    { 0, 0, 1, 0, 0, 0, 1, 0 }, 
                    { 1, 0, 0, 0, 1, 0, 0, 0 }, 
                    { 0, 0, 1, 0, 0, 0, 1, 0 }, 
                    { 1, 0, 0, 0, 1, 0, 0, 0 }, 
                    { 0, 0, 1, 0, 0, 0, 1, 0 }, 
                    { 1, 0, 0, 0, 1, 0, 0, 0 }, 
                    { 0, 0, 1, 0, 0, 0, 1, 0 } 
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lForeColor);

                    break;
                case GRE_HATCHSTYLE.HS_PERCENT30:
                    aRect = new int[, ] { 
                    { 1, 0, 1, 0, 1, 0, 1, 0 }, 
                    { 0, 1, 0, 0, 0, 1, 0, 0 }, 
                    { 1, 0, 1, 0, 1, 0, 1, 0 }, 
                    { 0, 0, 0, 1, 0, 0, 0, 1 }, 
                    { 1, 0, 1, 0, 1, 0, 1, 0 }, 
                    { 0, 1, 0, 0, 0, 1, 0, 0 }, 
                    { 1, 0, 1, 0, 1, 0, 1, 0 }, 
                    { 0, 0, 0, 1, 0, 0, 0, 1 }
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lForeColor);

                    break;
                case GRE_HATCHSTYLE.HS_PERCENT40:
                    aRect = new int[, ] { 
                    { 1, 0, 1, 0, 1, 0, 1, 0 }, 
                    { 0, 0, 0, 1, 0, 1, 0, 1 }, 
                    { 1, 0, 1, 0, 1, 0, 1, 0 }, 
                    { 0, 1, 0, 1, 0, 1, 0, 1 }, 
                    { 1, 0, 1, 0, 1, 0, 1, 0 }, 
                    { 0, 1, 0, 1, 0, 0, 0, 1 }, 
                    { 1, 0, 1, 0, 1, 0, 1, 0 }, 
                    { 0, 1, 0, 1, 0, 1, 0, 1 } 
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lForeColor);

                    break;
                case GRE_HATCHSTYLE.HS_PERCENT50:
                    aRect = new int[, ] { 
                    { 1, 0, 1, 0, 1, 0, 1, 0 }, 
                    { 0, 1, 0, 1, 0, 1, 0, 1 }, 
                    { 1, 0, 1, 0, 1, 0, 1, 0 }, 
                    { 0, 1, 0, 1, 0, 1, 0, 1 }, 
                    { 1, 0, 1, 0, 1, 0, 1, 0 }, 
                    { 0, 1, 0, 1, 0, 1, 0, 1 }, 
                    { 1, 0, 1, 0, 1, 0, 1, 0 }, 
                    { 0, 1, 0, 1, 0, 1, 0, 1 } 
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lForeColor);

                    break;
                case GRE_HATCHSTYLE.HS_PERCENT60:
                    aRect = new int[, ] { 
                    { 0, 1, 0, 0, 0, 1, 0, 0 }, 
                    { 1, 0, 1, 0, 1, 0, 1, 0 }, 
                    { 0, 0, 0, 1, 0, 0, 0, 1 }, 
                    { 1, 0, 1, 0, 1, 0, 1, 0 }, 
                    { 0, 1, 0, 0, 0, 1, 0, 0 }, 
                    { 1, 0, 1, 0, 1, 0, 1, 0 }, 
                    { 0, 0, 0, 1, 0, 0, 0, 1 }, 
                    { 1, 0, 1, 0, 1, 0, 1, 0 } 
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lBackColor);

                    break;
                case GRE_HATCHSTYLE.HS_PERCENT70:
                    aRect = new int[, ] { 
                    { 1, 0, 0, 0, 1, 0, 0, 0 }, 
                    { 0, 0, 1, 0, 0, 0, 1, 0 }, 
                    { 1, 0, 0, 0, 1, 0, 0, 0 }, 
                    { 0, 0, 1, 0, 0, 0, 1, 0 }, 
                    { 1, 0, 0, 0, 1, 0, 0, 0 }, 
                    { 0, 0, 1, 0, 0, 0, 1, 0 }, 
                    { 1, 0, 0, 0, 1, 0, 0, 0 }, 
                    { 0, 0, 1, 0, 0, 0, 1, 0 } 
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lBackColor);

                    break;
                case GRE_HATCHSTYLE.HS_PERCENT75:
                    aRect = new int[, ] { 
                    { 0, 0, 1, 0, 0, 0, 1, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 1, 0, 0, 0, 1, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 1, 0, 0, 0, 1, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 1, 0, 0, 0, 1, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 } 
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lBackColor);

                    break;
                case GRE_HATCHSTYLE.HS_PERCENT80:
                    aRect = new int[, ] { 
                    { 0, 0, 0, 1, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 1 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 1, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 1 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 } 
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lBackColor);

                    break;
                case GRE_HATCHSTYLE.HS_PERCENT90:
                    aRect = new int[, ] { 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 1, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 1, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 } 
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lBackColor);

                    break;
                case GRE_HATCHSTYLE.HS_LIGHTDOWNWARDDIAGONAL:
                    xDistance = 4;
                    for (y = v_Y1; y <= v_Y2; y++)
                    {
                        xStart = (y * lWidth) + v_X1;
                        xEnd = (y * lWidth) + v_X2;
                        for (x = (xStart - xDistance); x <= (xEnd + xDistance); x += xDistance)
                        {
                            if ((x + xOffset) >= xStart & (x + xOffset) <= xEnd)
                            {
                                SetPixel(x + xOffset, lForeColor);
                            }
                        }
                        xOffset = xOffset + 1;
                        if (xOffset > (xDistance - 1))
                        {
                            xOffset = 0;
                        }
                    }

                    break;
                case GRE_HATCHSTYLE.HS_LIGHTUPWARDDIAGONAL:
                    xDistance = 4;
                    for (y = v_Y1; y <= v_Y2; y++)
                    {
                        xStart = (y * lWidth) + v_X1;
                        xEnd = (y * lWidth) + v_X2;
                        for (x = (xStart - xDistance); x <= (xEnd + xDistance); x += xDistance)
                        {
                            if ((x - xOffset) >= xStart & (x - xOffset) <= xEnd)
                            {
                                SetPixel(x - xOffset, lForeColor);
                            }
                        }
                        xOffset = xOffset + 1;
                        if (xOffset > (xDistance - 1))
                        {
                            xOffset = 0;
                        }
                    }

                    break;
                case GRE_HATCHSTYLE.HS_DARKDOWNWARDDIAGONAL:
                    xDistance = 4;
                    for (y = v_Y1; y <= v_Y2; y++)
                    {
                        xStart = (y * lWidth) + v_X1;
                        xEnd = (y * lWidth) + v_X2;
                        for (x = (xStart - xDistance); x <= (xEnd + xDistance); x += xDistance)
                        {
                            if ((x + xOffset) >= xStart & (x + xOffset) <= xEnd)
                            {
                                SetPixel(x + xOffset, lForeColor);
                            }
                            if ((x + xOffset + 1) >= xStart & (x + xOffset + 1) <= xEnd)
                            {
                                SetPixel(x + xOffset + 1, lForeColor);
                            }
                        }
                        xOffset = xOffset + 1;
                        if (xOffset > (xDistance - 1))
                        {
                            xOffset = 0;
                        }
                    }


                    break;



                case GRE_HATCHSTYLE.HS_DARKUPWARDDIAGONAL:
                    xDistance = 4;
                    for (y = v_Y1; y <= v_Y2; y++)
                    {
                        xStart = (y * lWidth) + v_X1;
                        xEnd = (y * lWidth) + v_X2;
                        for (x = (xStart - xDistance); x <= (xEnd + xDistance); x += xDistance)
                        {
                            if ((x - xOffset) >= xStart & (x - xOffset) <= xEnd)
                            {
                                SetPixel(x - xOffset, lForeColor);
                            }
                            if ((x - xOffset + 1) >= xStart & (x - xOffset + 1) <= xEnd)
                            {
                                SetPixel(x - xOffset + 1, lForeColor);
                            }
                        }
                        xOffset = xOffset + 1;
                        if (xOffset > (xDistance - 1))
                        {
                            xOffset = 0;
                        }
                    }

                    break;
                case GRE_HATCHSTYLE.HS_WIDEDOWNWARDDIAGONAL:
                    xDistance = 8;
                    for (y = v_Y1; y <= v_Y2; y++)
                    {
                        xStart = (y * lWidth) + v_X1;
                        xEnd = (y * lWidth) + v_X2;
                        for (x = (xStart - xDistance); x <= (xEnd + xDistance); x += xDistance)
                        {
                            if ((x + xOffset) >= xStart & (x + xOffset) <= xEnd)
                            {
                                SetPixel(x + xOffset, lForeColor);
                            }
                            if ((x + xOffset + 1) >= xStart & (x + xOffset + 1) <= xEnd)
                            {
                                SetPixel(x + xOffset + 1, lForeColor);
                            }
                            if ((x + xOffset + 2) >= xStart & (x + xOffset + 2) <= xEnd)
                            {
                                SetPixel(x + xOffset + 2, lForeColor);
                            }
                        }
                        xOffset = xOffset + 1;
                        if (xOffset > (xDistance - 1))
                        {
                            xOffset = 0;
                        }
                    }

                    break;
                case GRE_HATCHSTYLE.HS_WIDEUPWARDDIAGONAL:
                    xDistance = 8;
                    for (y = v_Y1; y <= v_Y2; y++)
                    {
                        xStart = (y * lWidth) + v_X1;
                        xEnd = (y * lWidth) + v_X2;
                        for (x = (xStart - xDistance); x <= (xEnd + xDistance); x += xDistance)
                        {
                            if ((x - xOffset) >= xStart & (x - xOffset) <= xEnd)
                            {
                                SetPixel(x - xOffset, lForeColor);
                            }
                            if ((x - xOffset + 1) >= xStart & (x - xOffset + 1) <= xEnd)
                            {
                                SetPixel(x - xOffset + 1, lForeColor);
                            }
                            if ((x - xOffset + 2) >= xStart & (x - xOffset + 2) <= xEnd)
                            {
                                SetPixel(x - xOffset + 2, lForeColor);
                            }
                        }
                        xOffset = xOffset + 1;
                        if (xOffset > (xDistance - 1))
                        {
                            xOffset = 0;
                        }
                    }

                    break;
                case GRE_HATCHSTYLE.HS_LIGHTVERTICAL:
                    xDistance = 4;
                    for (y = v_Y1; y <= v_Y2; y++)
                    {
                        for (x = v_X1; x <= v_X2; x += xDistance)
                        {
                            SetPixel((y * lWidth) + x, lForeColor);
                        }
                    }

                    break;
                case GRE_HATCHSTYLE.HS_LIGHTHORIZONTAL:
                    yDistance = 4;
                    for (y = v_Y1; y <= v_Y2; y += yDistance)
                    {
                        for (x = v_X1; x <= v_X2; x++)
                        {
                            SetPixel((y * lWidth) + x, lForeColor);
                        }
                    }

                    break;
                case GRE_HATCHSTYLE.HS_NARROWVERTICAL:
                    xDistance = 2;
                    for (y = v_Y1; y <= v_Y2; y++)
                    {
                        for (x = v_X1; x <= v_X2; x += xDistance)
                        {
                            SetPixel((y * lWidth) + x, lForeColor);
                        }
                    }

                    break;
                case GRE_HATCHSTYLE.HS_NARROWHORIZONTAL:
                    yDistance = 2;
                    for (y = v_Y1; y <= v_Y2; y += yDistance)
                    {
                        for (x = v_X1; x <= v_X2; x++)
                        {
                            SetPixel((y * lWidth) + x, lForeColor);
                        }
                    }

                    break;
                case GRE_HATCHSTYLE.HS_DARKVERTICAL:
                    xDistance = 4;
                    for (y = v_Y1; y <= v_Y2; y++)
                    {
                        xEnd = (y * lWidth) + v_X2;
                        for (x = v_X1; x <= v_X2; x += xDistance)
                        {
                            SetPixel((y * lWidth) + x, lForeColor);
                            if (((y * lWidth) + x + 1) <= xEnd)
                            {
                                SetPixel((y * lWidth) + x + 1, lForeColor);
                            }
                        }
                    }

                    break;
                case GRE_HATCHSTYLE.HS_DARKHORIZONTAL:
                    yDistance = 4;
                    yEnd = (v_Y2 * lWidth) + v_X2;
                    for (y = v_Y1; y <= v_Y2; y += yDistance)
                    {
                        for (x = v_X1; x <= v_X2; x++)
                        {
                            SetPixel((y * lWidth) + x, lForeColor);
                            if ((((y + 1) * lWidth) + x) <= yEnd)
                            {
                                SetPixel(((y + 1) * lWidth) + x, lForeColor);
                            }
                        }
                    }

                    break;
                case GRE_HATCHSTYLE.HS_DASHEDDOWNWARDDIAGONAL:
                    aRect = new int[, ] { 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 1, 0, 0, 0, 1, 0, 0, 0 }, 
                    { 0, 1, 0, 0, 0, 1, 0, 0 }, 
                    { 0, 0, 1, 0, 0, 0, 1, 0 }, 
                    { 0, 0, 0, 1, 0, 0, 0, 1 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 } 
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lForeColor);

                    break;
                case GRE_HATCHSTYLE.HS_DASHEDUPWARDDIAGONAL:
                    aRect = new int[, ] { 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 1, 0, 0, 0, 1 }, 
                    { 0, 0, 1, 0, 0, 0, 1, 0 }, 
                    { 0, 1, 0, 0, 0, 1, 0, 0 }, 
                    { 1, 0, 0, 0, 1, 0, 0, 0 } 
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lForeColor);

                    break;
                case GRE_HATCHSTYLE.HS_DASHEDHORIZONTAL:
                    aRect = new int[, ] { 
                    { 0, 0, 0, 0, 1, 1, 1, 1 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 1, 1, 1, 1, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 } 
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lForeColor);

                    break;
                case GRE_HATCHSTYLE.HS_DASHEDVERTICAL:
                    aRect = new int[, ] { 
                    { 1, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 1, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 1, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 1, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 1, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 1, 0, 0, 0 }, 
                    { 1, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 1, 0, 0, 0, 0, 0, 0, 0 } 
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lForeColor);

                    break;
                case GRE_HATCHSTYLE.HS_SMALLCONFETTI:
                    aRect = new int[, ] { 
                    { 1, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 1, 0, 0, 0 }, 
                    { 0, 1, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 1, 0 }, 
                    { 0, 0, 0, 1, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 1 }, 
                    { 0, 0, 1, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 1, 0, 0 } 
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lForeColor);

                    break;
                case GRE_HATCHSTYLE.HS_LARGECONFETTI:
                    aRect = new int[, ] { 
                    { 0, 0, 0, 0, 1, 1, 0, 0 }, 
                    { 1, 0, 0, 0, 1, 1, 0, 1 }, 
                    { 1, 0, 1, 1, 0, 0, 0, 1 }, 
                    { 0, 0, 1, 1, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 1, 1 }, 
                    { 0, 0, 0, 1, 1, 0, 1, 1 }, 
                    { 1, 1, 0, 1, 1, 0, 0, 0 }, 
                    { 1, 1, 0, 0, 0, 0, 0, 0 } 
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lForeColor);

                    break;
                case GRE_HATCHSTYLE.HS_ZIGZAG:
                    aRect = new int[, ] { 
                    { 1, 0, 0, 0, 0, 0, 0, 1 }, 
                    { 0, 1, 0, 0, 0, 0, 1, 0 }, 
                    { 0, 0, 1, 0, 0, 1, 0, 0 }, 
                    { 0, 0, 0, 1, 1, 0, 0, 0 }, 
                    { 1, 0, 0, 0, 0, 0, 0, 1 }, 
                    { 0, 1, 0, 0, 0, 0, 1, 0 }, 
                    { 0, 0, 1, 0, 0, 1, 0, 0 }, 
                    { 0, 0, 0, 1, 1, 0, 0, 0 } 
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lForeColor);

                    break;
                case GRE_HATCHSTYLE.HS_WAVE:
                    aRect = new int[, ] { 
                    { 0, 0, 1, 0, 0, 1, 0, 1 }, 
                    { 1, 1, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 1, 1, 0, 0, 0 }, 
                    { 0, 0, 1, 0, 0, 1, 0, 1 }, 
                    { 1, 1, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 1, 1, 0, 0, 0 } 
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lForeColor);

                    break;
                case GRE_HATCHSTYLE.HS_DIAGONALBRICK:
                    aRect = new int[, ] { 
                    { 0, 0, 0, 0, 0, 0, 0, 1 }, 
                    { 0, 0, 0, 0, 0, 0, 1, 0 }, 
                    { 0, 0, 0, 0, 0, 1, 0, 0 }, 
                    { 0, 0, 0, 0, 1, 0, 0, 0 }, 
                    { 0, 0, 0, 1, 1, 0, 0, 0 }, 
                    { 0, 0, 1, 0, 0, 1, 0, 0 }, 
                    { 0, 1, 0, 0, 0, 0, 1, 0 }, 
                    { 1, 0, 0, 0, 0, 0, 0, 1 } 
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lForeColor);

                    break;
                case GRE_HATCHSTYLE.HS_HORIZONTALBRICK:
                    aRect = new int[, ] { 
                    { 0, 0, 0, 0, 1, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 1, 0, 0, 0 }, 
                    { 1, 1, 1, 1, 1, 1, 1, 1 }, 
                    { 1, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 1, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 1, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 1, 1, 1, 1, 1, 1, 1, 1 }, 
                    { 0, 0, 0, 0, 1, 0, 0, 0 } 
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lForeColor);

                    break;
                case GRE_HATCHSTYLE.HS_WEAVE:
                    aRect = new int[, ] { 
                    { 1, 0, 0, 0, 1, 0, 0, 0 }, 
                    { 0, 1, 0, 1, 0, 1, 0, 0 }, 
                    { 0, 0, 1, 0, 0, 0, 1, 0 }, 
                    { 0, 1, 0, 0, 0, 1, 0, 1 }, 
                    { 1, 0, 0, 0, 1, 0, 0, 0 }, 
                    { 0, 0, 0, 1, 0, 1, 0, 0 }, 
                    { 0, 0, 1, 0, 0, 0, 1, 0 }, 
                    { 0, 1, 0, 1, 0, 0, 0, 1 } 
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lForeColor);

                    break;
                case GRE_HATCHSTYLE.HS_PLAID:
                    aRect = new int[, ] { 
                    { 1, 1, 1, 1, 0, 0, 0, 0 }, 
                    { 1, 1, 1, 1, 0, 0, 0, 0 }, 
                    { 1, 0, 1, 0, 1, 0, 1, 0 }, 
                    { 0, 1, 0, 1, 0, 1, 0, 1 }, 
                    { 1, 0, 1, 0, 1, 0, 1, 0 }, 
                    { 0, 1, 0, 1, 0, 1, 0, 1 }, 
                    { 1, 1, 1, 1, 0, 0, 0, 0 }, 
                    { 1, 1, 1, 1, 0, 0, 0, 0 } 
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lForeColor);

                    break;
                case GRE_HATCHSTYLE.HS_DIVOT:
                    aRect = new int[, ] { 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 1, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 1 }, 
                    { 1, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 1, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 1, 0, 0, 0 }, 
                    { 0, 0, 0, 1, 0, 0, 0, 0 } 
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lForeColor);

                    break;
                case GRE_HATCHSTYLE.HS_DOTTEDGRID:
                    aRect = new int[, ] { 
                    { 1, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 1, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 1, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 1, 0, 1, 0, 1, 0, 1, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 } 
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lForeColor);

                    break;


                case GRE_HATCHSTYLE.HS_DOTTEDDIAMOND:
                    aRect = new int[, ] { 
                    { 1, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 1, 0, 0, 0, 1, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 1, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 1, 0, 0, 0, 1, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lForeColor);

                    break;
                case GRE_HATCHSTYLE.HS_SHINGLE:
                    aRect = new int[, ] { 
                    { 0, 0, 0, 0, 0, 0, 0, 1 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 1 }, 
                    { 0, 0, 0, 0, 0, 0, 1, 1 }, 
                    { 1, 0, 0, 0, 0, 1, 0, 0 }, 
                    { 0, 1, 0, 0, 1, 0, 0, 0 }, 
                    { 0, 0, 1, 1, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 1, 1, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 1, 0 } 
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lForeColor);

                    break;

                case GRE_HATCHSTYLE.HS_TRELLIS:
                    aRect = new int[, ] { 
                    { 1, 1, 1, 1, 1, 1, 1, 1 }, 
                    { 0, 1, 1, 0, 0, 1, 1, 0 }, 
                    { 1, 1, 1, 1, 1, 1, 1, 1 }, 
                    { 1, 0, 0, 1, 1, 0, 0, 1 }, 
                    { 1, 1, 1, 1, 1, 1, 1, 1 }, 
                    { 0, 1, 1, 0, 0, 1, 1, 0 }, 
                    { 1, 1, 1, 1, 1, 1, 1, 1 }, 
                    { 1, 0, 0, 1, 1, 0, 0, 1 } 
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lForeColor);

                    break;
                case GRE_HATCHSTYLE.HS_SPHERE:
                    aRect = new int[, ] { 
                    { 1, 0, 0, 0, 1, 1, 1, 1 }, 
                    { 1, 0, 0, 0, 1, 1, 1, 1 }, 
                    { 0, 1, 1, 1, 0, 1, 1, 1 }, 
                    { 1, 0, 0, 1, 1, 0, 0, 0 }, 
                    { 1, 1, 1, 1, 1, 0, 0, 0 }, 
                    { 1, 1, 1, 1, 1, 0, 0, 0 }, 
                    { 0, 1, 1, 1, 0, 1, 1, 1 }, 
                    { 1, 0, 0, 0, 1, 0, 0, 1 } 
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lForeColor);

                    break;
                case GRE_HATCHSTYLE.HS_SMALLGRID:
                    xDistance = 4;
                    yDistance = 4;
                    for (y = (v_Y1); y <= v_Y2; y += yDistance)
                    {
                        for (x = v_X1; x <= v_X2; x++)
                        {
                            SetPixel((y * lWidth) + x, lForeColor);
                        }
                    }

                    for (y = v_Y1; y <= v_Y2; y++)
                    {
                        for (x = (v_X1); x <= v_X2; x += xDistance)
                        {
                            SetPixel((y * lWidth) + x, lForeColor);
                        }
                    }

                    break;
                case GRE_HATCHSTYLE.HS_SMALLCHECKERBOARD:
                    xDistance = 4;
                    for (y = v_Y1; y <= v_Y2; y++)
                    {
                        xStart = (y * lWidth) + v_X1;
                        xEnd = (y * lWidth) + v_X2;
                        for (x = (xStart - xDistance); x <= (xEnd + xDistance); x += xDistance)
                        {
                            if ((x + xOffset) >= xStart & (x + xOffset) <= xEnd)
                            {
                                SetPixel(x + xOffset, lForeColor);
                            }
                        }
                        xOffset = xOffset + 1;
                        if (xOffset > (xDistance - 1))
                        {
                            xOffset = 0;
                        }
                    }

                    for (y = v_Y1; y <= v_Y2; y++)
                    {
                        xStart = (y * lWidth) + v_X1;
                        xEnd = (y * lWidth) + v_X2;
                        for (x = (xStart - xDistance); x <= (xEnd + xDistance); x += xDistance)
                        {
                            if ((x - xOffset) >= xStart & (x - xOffset) <= xEnd)
                            {
                                SetPixel(x - xOffset, lForeColor);
                            }
                        }
                        xOffset = xOffset + 1;
                        if (xOffset > (xDistance - 1))
                        {
                            xOffset = 0;
                        }
                    }

                    break;
                case GRE_HATCHSTYLE.HS_LARGECHECKERBOARD:
                    xDistance = 8;
                    yDistance = 8;
                    yEnd = (v_Y2 * lWidth) + v_X2;
                    for (y = v_Y1; y <= v_Y2; y += yDistance)
                    {
                        xStart = (y * lWidth) + v_X1;
                        xEnd = (y * lWidth) + v_X2;
                        for (x = v_X1; x <= v_X2; x += xDistance)
                        {
                            for (iy = 0; iy <= 3; iy++)
                            {
                                if ((y + iy) <= v_Y2)
                                {
                                    for (ix = 0; ix <= 3; ix++)
                                    {
                                        if (((y * lWidth) + x + ix) >= xStart & ((y * lWidth) + x + ix) <= xEnd)
                                        {
                                            SetPixel(((y + iy) * lWidth) + x + ix, lForeColor);
                                        }
                                    }
                                }
                            }
                            for (iy = 4; iy <= 7; iy++)
                            {
                                if ((y + iy) <= v_Y2)
                                {
                                    for (ix = 4; ix <= 7; ix++)
                                    {
                                        if (((y * lWidth) + x + ix) >= xStart & ((y * lWidth) + x + ix) <= xEnd)
                                        {
                                            SetPixel(((y + iy) * lWidth) + x + ix, lForeColor);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    break;
                case GRE_HATCHSTYLE.HS_OUTLINEDDIAMOND:
                    xDistance = 7;
                    for (y = v_Y1; y <= v_Y2; y++)
                    {
                        xStart = (y * lWidth) + v_X1;
                        xEnd = (y * lWidth) + v_X2;
                        for (x = (xStart - xDistance); x <= (xEnd + xDistance); x += xDistance)
                        {
                            if ((x + xOffset) >= xStart & (x + xOffset) <= xEnd)
                            {
                                SetPixel(x + xOffset, lForeColor);
                            }
                        }
                        xOffset = xOffset + 1;
                        if (xOffset > (xDistance - 1))
                        {
                            xOffset = 0;
                        }
                    }

                    for (y = v_Y1; y <= v_Y2; y++)
                    {
                        xStart = (y * lWidth) + v_X1;
                        xEnd = (y * lWidth) + v_X2;
                        for (x = (xStart - xDistance); x <= (xEnd + xDistance); x += xDistance)
                        {
                            if ((x - xOffset) >= xStart & (x - xOffset) <= xEnd)
                            {
                                SetPixel(x - xOffset, lForeColor);
                            }
                        }
                        xOffset = xOffset + 1;
                        if (xOffset > (xDistance - 1))
                        {
                            xOffset = 0;
                        }
                    }


                    break;
                case GRE_HATCHSTYLE.HS_SOLIDDIAMOND:
                    aRect = new int[, ] { 
                    { 0, 1, 1, 1, 1, 1, 0, 0 }, 
                    { 0, 0, 1, 1, 1, 0, 0, 0 }, 
                    { 0, 0, 0, 1, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 1, 0, 0, 0, 0 }, 
                    { 0, 0, 1, 1, 1, 0, 0, 0 }, 
                    { 0, 1, 1, 1, 1, 1, 0, 0 }, 
                    { 1, 1, 1, 1, 1, 1, 1, 0 } 
                    };
                    mp_DrawRaster(v_X1, v_Y1, v_X2, v_Y2, lWidth, aRect, lForeColor);
                    break;
            }
            GetBitmap.Invalidate();
        }

        private void mp_DrawRaster(int v_X1, int v_Y1, int v_x2, int v_Y2, int lWidth, int[,] aRect, int lForeColor)
        {
            int xDistance = 0;
            int yDistance = 0;
            int yEnd = 0;
            int xStart = 0;
            int xEnd = 0;
            int lVisible = 0;
            int ix = 0;
            int iy = 0;
            int y;
            int x;
            xDistance = aRect.GetUpperBound(0) + 1;
            yDistance = aRect.GetUpperBound(1) + 1;
            yEnd = (v_Y2 * lWidth) + v_x2;
            for (y = v_Y1; y <= v_Y2; y += yDistance)
            {
                xStart = (y * lWidth) + v_X1;
                xEnd = (y * lWidth) + v_x2;
                for (x = v_X1; x <= v_x2; x += xDistance)
                {
                    for (ix = 0; ix <= xDistance - 1; ix++)
                    {
                        for (iy = 0; iy <= yDistance - 1; iy++)
                        {
                            lVisible = aRect[iy, ix];
                            if (lVisible == 1)
                            {
                                if ((y + iy) <= v_Y2)
                                {
                                    if (((y * lWidth) + x + ix) >= xStart & ((y * lWidth) + x + ix) <= xEnd)
                                    {
                                        SetPixel(((y + iy) * lWidth) + x + ix, lForeColor);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        public void ResetFocusRectangle()
        {
        }

        public void DrawReversibleFrameEx()
        {
            DrawReversibleFrame(mp_lFocusLeft, mp_lFocusTop, mp_lFocusRight, mp_lFocusBottom);
        }

        public void DrawReversibleLine(int v_X1, int v_Y1, int v_X2, int v_Y2)
        {
            if (mp_lSelectionLineIndex == -1)
            {
                mp_oSelectionLine.X1 = v_X1;
                mp_oSelectionLine.X2 = v_X2;
                mp_oSelectionLine.Y1 = v_Y1;
                mp_oSelectionLine.Y2 = v_Y2;
                mp_oSelectionLine.Stroke = new SolidColorBrush(mp_oControl.SelectionColor);
                mp_oSelectionLine.StrokeThickness = 1;
                mp_oSelectionLine.IsHitTestVisible = false;
                mp_oControl.oCanvas.Children.Add(mp_oSelectionLine);
                mp_lSelectionLineIndex = mp_oControl.oCanvas.Children.Count - 1;
            }
            else
            {
                mp_oSelectionLine.X1 = v_X1;
                mp_oSelectionLine.X2 = v_X2;
                mp_oSelectionLine.Y1 = v_Y1;
                mp_oSelectionLine.Y2 = v_Y2;
            }
        }

        public void EraseReversibleLines()
        {
            if (mp_lSelectionLineIndex > -1)
            {
                mp_oControl.oCanvas.Children.Remove(mp_oSelectionLine);
                mp_lSelectionLineIndex = -1;
            }
        }

        public void DrawReversibleFrame(int v_X1, int v_Y1, int v_X2, int v_Y2)
        {
            if ((v_X2 - v_X1 + 1) <= 1)
            {
                return;
            }
            if ((v_Y2 - v_Y1 + 1) <= 1)
            {
                return;
            }
            if (mp_lSelectionRectangleIndex == -1)
            {

                mp_oSelectionRectangle.Width = v_X2 - v_X1 + 1;
                mp_oSelectionRectangle.Height = v_Y2 - v_Y1 + 1;
                mp_oSelectionRectangle.SetValue(Canvas.LeftProperty, (double)v_X1);
                mp_oSelectionRectangle.SetValue(Canvas.TopProperty, (double)v_Y1);
                mp_oSelectionRectangle.Stroke = new SolidColorBrush(mp_oControl.SelectionColor);
                mp_oSelectionRectangle.StrokeThickness = 1;
                mp_oSelectionRectangle.Name = "SelectionRectangle";
                mp_oSelectionRectangle.IsHitTestVisible = false;
                mp_oControl.oCanvas.Children.Add(mp_oSelectionRectangle);
                mp_lSelectionRectangleIndex = mp_oControl.oCanvas.Children.Count - 1;
            }
            else
            {
                mp_oSelectionRectangle.Width = v_X2 - v_X1 + 1;
                mp_oSelectionRectangle.Height = v_Y2 - v_Y1 + 1;
                mp_oSelectionRectangle.SetValue(Canvas.LeftProperty, (double)v_X1);
                mp_oSelectionRectangle.SetValue(Canvas.TopProperty, (double)v_Y1);
            }
        }

        public void EraseReversibleFrames()
        {
            if (mp_lSelectionRectangleIndex > -1)
            {
                mp_oControl.oCanvas.Children.Remove(mp_oSelectionRectangle);
                mp_lSelectionRectangleIndex = -1;
            } 
        }

        internal void mp_DrawItemI( clsTask oTask, string sStyleIndex, bool Selected,  clsStyle v_oStyle)
        {
            clsStyle oStyle;
            clsMilestoneStyle oMilestoneStyle;
            if ((v_oStyle == null))
            {
                if (mp_oControl.StrLib.StrIsNumeric(sStyleIndex))
                {
                    if (mp_oControl.StrLib.StrCLng(sStyleIndex) < 0 | mp_oControl.StrLib.StrCLng(sStyleIndex) > mp_oControl.Styles.Count)
                    {
                        mp_oControl.mp_ErrorReport(SYS_ERRORS.STYLE_INVALID_INDEX, "Style object element not found when preparing to draw, invalid index", "mp_DrawItemI");
                        return;
                    }
                }
                else
                {
                    if (mp_oControl.Styles.oCollection.m_bDoesKeyExist(sStyleIndex) == false)
                    {
                        mp_oControl.mp_ErrorReport(SYS_ERRORS.STYLE_INVALID_KEY, "Style object element not found when preparing to draw, invalid key (\"" + sStyleIndex + "\")", "mp_DrawItemI");
                        return;
                    }
                }
                oStyle = mp_oControl.Styles.FItem(sStyleIndex);
            }
            else
            {
                oStyle = v_oStyle;
            }
            switch (oStyle.Appearance)
            {
                case E_STYLEAPPEARANCE.SA_FLAT:
                    oMilestoneStyle = oStyle.MilestoneStyle;
                    DrawFigure(mp_oControl.MathLib.GetXCoordinateFromDate(oTask.StartDate), oTask.Top, oTask.Bottom - oTask.Top, oTask.Bottom - oTask.Top, oMilestoneStyle.ShapeIndex, oMilestoneStyle.BorderColor, oMilestoneStyle.FillColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                    break;
                case E_STYLEAPPEARANCE.SA_GRAPHICAL:
                    if (oStyle.MilestoneStyle.Image == null)
                    {
                    }
                    else
                    {
                        DrawImage(oStyle.MilestoneStyle.Image, oStyle.ImageAlignmentHorizontal, oStyle.ImageAlignmentVertical, oStyle.ImageXMargin, oStyle.ImageYMargin, oTask.Left, oTask.Right, oTask.Top, oTask.Bottom, oStyle.UseMask);
                    }
                    break;
                default:
                    oMilestoneStyle = oStyle.MilestoneStyle;
                    DrawFigure(mp_oControl.MathLib.GetXCoordinateFromDate(oTask.StartDate), oTask.Top, oTask.Bottom - oTask.Top, oTask.Bottom - oTask.Top, oMilestoneStyle.ShapeIndex, oMilestoneStyle.BorderColor, oMilestoneStyle.FillColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                    break;
            }
            mp_DrawItemText(oTask.Left, oTask.Top, oTask.Right, oTask.Bottom, oTask.LeftTrim, oTask.RightTrim,  oStyle, oTask.Text);
            if (oStyle.SelectionRectangleStyle.Visible == true & Selected)
            {
                if (oStyle.SelectionRectangleStyle.Mode == E_SELECTIONRECTANGLEMODE.SRM_DOTTED)
                {
                    DrawFocusRectangle(oTask.Left, oTask.Top, oTask.Right, oTask.Bottom);
                }
                else if (oStyle.SelectionRectangleStyle.Mode == E_SELECTIONRECTANGLEMODE.SRM_COLOR)
                {
                    DrawLine(oTask.Left, oTask.Top, oTask.Right, oTask.Bottom, GRE_LINETYPE.LT_BORDER, oStyle.SelectionRectangleStyle.Color, GRE_LINEDRAWSTYLE.LDS_SOLID, oStyle.SelectionRectangleStyle.BorderWidth);
                }
            }
        }

        internal void mp_DrawItemEx(int v_lLeft, int v_lTop, int v_lRight, int v_lBottom, string sText, bool v_bIsSelected, Image v_oImage, int v_lLeftTrim, int v_lRightTrim, clsStyle v_oStyle, Color clrBackColor, Color clrForeColor, Color clrStartGradientColor, Color clrEndGradientColor, Color clrHatchBackColor, Color clrHatchForeColor)
        {
            clsStyle oStyle;
            clsTaskStyle oTaskStyle;
            if ((v_oStyle == null))
            {
                mp_oControl.mp_ErrorReport(SYS_ERRORS.STYLE_NULL, "Style object is null when preparing to draw.", "mp_DrawItemEx");
                return;
            }
            else
            {
                oStyle = v_oStyle;
            }
            oTaskStyle = oStyle.TaskStyle;
            switch (oStyle.Appearance)
            {
                case E_STYLEAPPEARANCE.SA_RAISED:
                    DrawEdge(v_lLeft, v_lTop, v_lRight, v_lBottom, clrBackColor, oStyle.ButtonStyle, GRE_EDGETYPE.ET_RAISED, true, v_oStyle);
                    break;
                case E_STYLEAPPEARANCE.SA_SUNKEN:
                    DrawEdge(v_lLeft, v_lTop, v_lRight, v_lBottom, clrBackColor, oStyle.ButtonStyle, GRE_EDGETYPE.ET_SUNKEN, true, v_oStyle);
                    break;
                case E_STYLEAPPEARANCE.SA_FLAT:
                    int lTop = 0;
                    int lBottom = 0;
                    lTop = v_lTop;
                    lBottom = v_lBottom;
                    switch (oStyle.FillMode)
                    {
                        case GRE_FILLMODE.FM_COMPLETELYFILLED:
                            break;
                        case GRE_FILLMODE.FM_UPPERHALFFILLED:
                            lBottom = v_lTop + ((v_lBottom - v_lTop) / 2);
                            break;
                        case GRE_FILLMODE.FM_LOWERHALFFILLED:
                            lTop = v_lBottom - ((v_lBottom - v_lTop) / 2);
                            break;
                    }
                    if ((oStyle.BackgroundMode == GRE_BACKGROUNDMODE.FP_SOLID))
                    {
                        DrawLine(v_lLeft, lTop, v_lRight, lBottom, GRE_LINETYPE.LT_FILLED, clrBackColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                    }
                    else if ((oStyle.BackgroundMode == GRE_BACKGROUNDMODE.FP_GRADIENT))
                    {
                        GradientFill(v_lLeft, lTop, v_lRight, lBottom, clrStartGradientColor, clrEndGradientColor, oStyle.GradientFillMode);
                    }
                    else if ((oStyle.BackgroundMode == GRE_BACKGROUNDMODE.FP_PATTERN))
                    {
                        DrawPattern(v_lLeft, lTop, v_lRight, lBottom, clrBackColor, oStyle.Pattern, oStyle.PatternFactor);
                    }
                    else if ((oStyle.BackgroundMode == GRE_BACKGROUNDMODE.FP_HATCH))
                    {
                        HatchFill(v_lLeft, lTop, v_lRight, lBottom, clrHatchForeColor, clrHatchBackColor, oStyle.HatchStyle);
                    }
                    if (oStyle.BorderStyle == GRE_BORDERSTYLE.SBR_SINGLE)
                    {
                        DrawLine(v_lLeft, lTop, v_lRight, lBottom, GRE_LINETYPE.LT_BORDER, oStyle.BorderColor, GRE_LINEDRAWSTYLE.LDS_SOLID, oStyle.BorderWidth);
                    }
                    else if (oStyle.BorderStyle == GRE_BORDERSTYLE.SBR_CUSTOM)
                    {
                        if (oStyle.CustomBorderStyle.Left == true)
                        {
                            DrawLine(v_lLeft, lTop, v_lLeft, lBottom, GRE_LINETYPE.LT_NORMAL, oStyle.BorderColor, GRE_LINEDRAWSTYLE.LDS_SOLID, oStyle.BorderWidth);
                        }
                        if (oStyle.CustomBorderStyle.Top == true)
                        {
                            DrawLine(v_lLeft, lTop, v_lRight, lTop, GRE_LINETYPE.LT_NORMAL, oStyle.BorderColor, GRE_LINEDRAWSTYLE.LDS_SOLID, oStyle.BorderWidth);
                        }
                        if (oStyle.CustomBorderStyle.Right == true)
                        {
                            DrawLine(v_lRight, lTop, v_lRight, lBottom, GRE_LINETYPE.LT_NORMAL, oStyle.BorderColor, GRE_LINEDRAWSTYLE.LDS_SOLID, oStyle.BorderWidth);
                        }
                        if (oStyle.CustomBorderStyle.Bottom == true)
                        {
                            DrawLine(v_lLeft, lBottom, v_lRight, lBottom, GRE_LINETYPE.LT_NORMAL, oStyle.BorderColor, GRE_LINEDRAWSTYLE.LDS_SOLID, oStyle.BorderWidth);
                        }
                    }
                    DrawFigure(v_lRight, v_lTop, v_lBottom - v_lTop, v_lBottom - v_lTop, oTaskStyle.EndShapeIndex, oTaskStyle.EndBorderColor, oTaskStyle.EndFillColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                    DrawFigure(v_lLeft, v_lTop, v_lBottom - v_lTop, v_lBottom - v_lTop, oTaskStyle.StartShapeIndex, oTaskStyle.StartBorderColor, oTaskStyle.StartFillColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                    break;
                case E_STYLEAPPEARANCE.SA_CELL:
                    DrawLine(v_lLeft, v_lTop, v_lRight, v_lBottom, GRE_LINETYPE.LT_FILLED, clrBackColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                    DrawLine(v_lLeft, v_lBottom, v_lRight, v_lBottom, GRE_LINETYPE.LT_NORMAL, oStyle.BorderColor, GRE_LINEDRAWSTYLE.LDS_SOLID, oStyle.BorderWidth);
                    break;
                case E_STYLEAPPEARANCE.SA_GRAPHICAL:

                    if (oTaskStyle.MiddleImage == null | oTaskStyle.StartImage == null | oTaskStyle.EndImage == null)
                    {
                    }
                    else
                    {
                        int lImageHeight = 0;
                        int lImageWidth = 0;
                        lImageHeight = (int)oTaskStyle.MiddleImage.Height;
                        lImageWidth = (int)oTaskStyle.MiddleImage.Width;
                        TileImageHorizontal(oTaskStyle.MiddleImage, v_lLeft, v_lTop, v_lRight, v_lBottom, oStyle.UseMask);
                        //// Exit if the start and end sections don't fit
                        if ((v_lRight - v_lLeft) > (lImageWidth * 2))
                        {
                            //// Left Section
                            PaintImage(oTaskStyle.StartImage, v_lLeft, v_lTop, v_lLeft + lImageWidth, v_lTop + lImageHeight, 0, 0, oStyle.UseMask);
                            //// Right Section
                            PaintImage(oTaskStyle.EndImage, v_lRight - lImageWidth, v_lTop, v_lRight, v_lTop + lImageHeight, 0, 0, oStyle.UseMask);
                        }
                    }
                    break;
            }
            if ((v_oImage != null))
            {
                DrawImage(v_oImage, oStyle.ImageAlignmentHorizontal, oStyle.ImageAlignmentVertical, oStyle.ImageXMargin, oStyle.ImageYMargin, v_lLeft, v_lRight, v_lTop, v_lBottom, oStyle.UseMask);
            }
            mp_DrawItemText(v_lLeft, v_lTop, v_lRight, v_lBottom, v_lLeftTrim, v_lRightTrim, oStyle, sText);
            if (oStyle.SelectionRectangleStyle.Visible == true & v_bIsSelected)
            {
                mp_DrawSelectionRectangle(v_lLeft, v_lTop, v_lRight, v_lBottom, oStyle);
            }
        }

        internal void mp_DrawSelectionRectangle(int v_lLeft, int v_lTop, int v_lRight, int v_lBottom, clsStyle oStyle)
        {
            if (oStyle.SelectionRectangleStyle.Mode == E_SELECTIONRECTANGLEMODE.SRM_DOTTED)
            {
                DrawFocusRectangle(v_lLeft + oStyle.SelectionRectangleStyle.OffsetLeft, v_lTop + oStyle.SelectionRectangleStyle.OffsetTop, v_lRight - oStyle.SelectionRectangleStyle.OffsetRight, v_lBottom - oStyle.SelectionRectangleStyle.OffsetBottom);
            }
            else if (oStyle.SelectionRectangleStyle.Mode == E_SELECTIONRECTANGLEMODE.SRM_COLOR)
            {
                DrawLine(v_lLeft + oStyle.SelectionRectangleStyle.OffsetLeft, v_lTop + oStyle.SelectionRectangleStyle.OffsetTop, v_lRight - oStyle.SelectionRectangleStyle.OffsetRight, v_lBottom - oStyle.SelectionRectangleStyle.OffsetBottom, GRE_LINETYPE.LT_BORDER, oStyle.SelectionRectangleStyle.Color, GRE_LINEDRAWSTYLE.LDS_SOLID, oStyle.SelectionRectangleStyle.BorderWidth);
            }
        }

        internal void mp_DrawItem(int v_lLeft, int v_lTop, int v_lRight, int v_lBottom, string sStyleIndex, string sText, bool v_bIsSelected, Image v_oImage, int v_lLeftTrim, int v_lRightTrim, clsStyle v_oStyle)
        {
            clsStyle oStyle;
            if ((v_oStyle == null))
            {
                if (mp_oControl.StrLib.StrIsNumeric(sStyleIndex))
                {
                    if (mp_oControl.StrLib.StrCLng(sStyleIndex) < 0 | mp_oControl.StrLib.StrCLng(sStyleIndex) > mp_oControl.Styles.Count)
                    {
                        mp_oControl.mp_ErrorReport(SYS_ERRORS.STYLE_INVALID_INDEX, "Style object element not found when preparing to draw, invalid index", "mp_DrawItem");
                        return;
                    }
                }
                else
                {
                    if (mp_oControl.Styles.oCollection.m_bDoesKeyExist(sStyleIndex) == false)
                    {
                        mp_oControl.mp_ErrorReport(SYS_ERRORS.STYLE_INVALID_KEY, "Style object element not found when preparing to draw, invalid key (\"" + sStyleIndex + "\")", "mp_DrawItem");
                        return;
                    }
                }
                oStyle = mp_oControl.Styles.FItem(sStyleIndex);
            }
            else
            {
                oStyle = v_oStyle;
            }
            mp_DrawItemEx(v_lLeft, v_lTop, v_lRight, v_lBottom, sText, v_bIsSelected, v_oImage, v_lLeftTrim, v_lRightTrim, oStyle, oStyle.BackColor, oStyle.ForeColor, oStyle.StartGradientColor, oStyle.EndGradientColor, oStyle.HatchBackColor, oStyle.HatchForeColor);
        }

        private void mp_DrawItemText(int v_lLeft, int v_lTop, int v_lRight, int v_lBottom, int v_lLeftTrim, int v_lRightTrim, clsStyle oStyle, string sText)
        {
            int lTextLeft = 0;
            int lTextRight = 0;
            int lTextTop = 0;
            int lTextBottom = 0;
            if (oStyle.TextVisible == false)
            {
                return;
            }
            if (string.IsNullOrEmpty(sText))
            {
                return;
            }
            switch (oStyle.TextPlacement)
            {
                case E_TEXTPLACEMENT.SCP_OBJECTEXTENTSPLACEMENT:
                    if ((oStyle.DrawTextInVisibleArea == false))
                    {
                        lTextLeft = v_lLeft;
                        lTextRight = v_lRight;
                    }
                    else
                    {
                        lTextLeft = v_lLeftTrim;
                        lTextRight = v_lRightTrim;
                    }

                    lTextTop = v_lTop;
                    lTextBottom = v_lBottom;
                    if (oStyle.TextAlignmentHorizontal == GRE_HORIZONTALALIGNMENT.HAL_LEFT)
                    {
                        lTextLeft = v_lLeft + oStyle.TextXMargin;
                    }

                    if (oStyle.TextAlignmentHorizontal == GRE_HORIZONTALALIGNMENT.HAL_RIGHT)
                    {
                        lTextRight = v_lRight - oStyle.TextXMargin;
                    }

                    if (oStyle.TextAlignmentVertical == GRE_VERTICALALIGNMENT.VAL_TOP)
                    {
                        lTextTop = v_lTop + oStyle.TextYMargin;
                    }

                    if (oStyle.TextAlignmentVertical == GRE_VERTICALALIGNMENT.VAL_BOTTOM)
                    {
                        lTextBottom = v_lBottom - oStyle.TextYMargin;
                    }

                    DrawAlignedText(lTextLeft, lTextTop, lTextRight, lTextBottom, sText, oStyle.TextAlignmentHorizontal, oStyle.TextAlignmentVertical, oStyle.ForeColor, oStyle.Font, oStyle.ClipText
                    );
                    break;
                case E_TEXTPLACEMENT.SCP_OFFSETPLACEMENT:
                    DrawTextEx(v_lLeft + oStyle.TextFlags.OffsetLeft, v_lTop + oStyle.TextFlags.OffsetTop, v_lRight - oStyle.TextFlags.OffsetRight, v_lBottom - oStyle.TextFlags.OffsetBottom, sText, oStyle.TextFlags, oStyle.ForeColor, oStyle.Font, oStyle.ClipText);
                    break;
                case E_TEXTPLACEMENT.SCP_EXTERIORPLACEMENT:
                    if (oStyle.TextAlignmentHorizontal == GRE_HORIZONTALALIGNMENT.HAL_LEFT)
                    {
                        lTextLeft = v_lLeft - mp_oControl.mp_lStrWidth(sText, oStyle.Font) - oStyle.TextXMargin;
                        lTextRight = v_lLeft - oStyle.TextXMargin + 1;
                    }

                    if (oStyle.TextAlignmentHorizontal == GRE_HORIZONTALALIGNMENT.HAL_RIGHT)
                    {
                        lTextLeft = v_lRight + oStyle.TextXMargin;
                        lTextRight = v_lRight + mp_oControl.mp_lStrWidth(sText, oStyle.Font) + oStyle.TextXMargin + 1;
                    }

                    if (oStyle.TextAlignmentHorizontal == GRE_HORIZONTALALIGNMENT.HAL_CENTER)
                    {
                        lTextLeft = v_lLeft;
                        lTextRight = v_lRight + 1;
                    }

                    if (oStyle.TextAlignmentVertical == GRE_VERTICALALIGNMENT.VAL_TOP)
                    {
                        lTextTop = v_lTop - mp_oControl.mp_lStrHeight(sText, oStyle.Font) - oStyle.TextYMargin;
                        lTextBottom = v_lTop - oStyle.TextYMargin + 1;
                    }

                    if (oStyle.TextAlignmentVertical == GRE_VERTICALALIGNMENT.VAL_BOTTOM)
                    {
                        lTextTop = v_lBottom + oStyle.TextYMargin;
                        lTextBottom = v_lBottom + mp_oControl.mp_lStrHeight(sText, oStyle.Font) + oStyle.TextYMargin + 1;
                    }

                    if (oStyle.TextAlignmentVertical == GRE_VERTICALALIGNMENT.VAL_CENTER)
                    {
                        lTextTop = v_lTop;
                        lTextBottom = v_lBottom + 1;
                    }
                    DrawAlignedText(lTextLeft, lTextTop, lTextRight, lTextBottom, sText, GRE_HORIZONTALALIGNMENT.HAL_LEFT, GRE_VERTICALALIGNMENT.VAL_TOP, oStyle.ForeColor, oStyle.Font, oStyle.ClipText);
                    break;
            }
        }

        public void DrawButton(Rect oRect, E_SCROLLBUTTONSTATE state)
        {
            Color clrLightGray = Color.FromArgb(255, 192, 192, 192);
            Color clrMediumGray = Color.FromArgb(255, 128, 128, 128);
            Color clrDarkGray = Color.FromArgb(255, 64, 64, 64);
            DrawLine((int)oRect.X + 1, (int)oRect.Y + 1, (int)oRect.X + (int)oRect.Width - 3, (int)oRect.Y + (int)oRect.Height - 3, GRE_LINETYPE.LT_FILLED, clrLightGray, GRE_LINEDRAWSTYLE.LDS_SOLID);

            DrawLine((int)oRect.X, (int)oRect.Y, (int)oRect.X + (int)oRect.Width - 2, (int)oRect.Y, GRE_LINETYPE.LT_NORMAL, Colors.White, GRE_LINEDRAWSTYLE.LDS_SOLID);
            DrawLine((int)oRect.X, (int)oRect.Y, (int)oRect.X, (int)oRect.Y + (int)oRect.Height - 2, GRE_LINETYPE.LT_NORMAL, Colors.White, GRE_LINEDRAWSTYLE.LDS_SOLID);
            DrawLine((int)oRect.X, (int)oRect.Y + (int)oRect.Height - 1, (int)oRect.X + (int)oRect.Width - 1, (int)oRect.Y + (int)oRect.Height - 1, GRE_LINETYPE.LT_NORMAL, clrDarkGray, GRE_LINEDRAWSTYLE.LDS_SOLID);
            DrawLine((int)oRect.X + (int)oRect.Width - 1, (int)oRect.Y, (int)oRect.X + (int)oRect.Width - 1, (int)oRect.Y + (int)oRect.Height - 1, GRE_LINETYPE.LT_NORMAL, clrDarkGray, GRE_LINEDRAWSTYLE.LDS_SOLID);

            DrawLine((int)oRect.X + 1, (int)oRect.Y + (int)oRect.Height - 2, (int)oRect.X + (int)oRect.Width - 2, (int)oRect.Y + (int)oRect.Height - 2, GRE_LINETYPE.LT_NORMAL, clrMediumGray, GRE_LINEDRAWSTYLE.LDS_SOLID);
            DrawLine((int)oRect.X + (int)oRect.Width - 2, (int)oRect.Y + 1, (int)oRect.X + (int)oRect.Width - 2, (int)oRect.Y + (int)oRect.Height - 2, GRE_LINETYPE.LT_NORMAL, clrMediumGray, GRE_LINEDRAWSTYLE.LDS_SOLID);
        }

        internal void DrawScrollButton(int X1, int Y1, int width, int height, E_SCROLLBUTTON button, E_SCROLLBUTTONSTATE state)
        {
            int[,] aRect = null;
            int lWidth = GetBitmap.PixelWidth;
            mp_aPixels = GetBitmap.Pixels;


            switch (button)
            {
                case E_SCROLLBUTTON.SB_RIGHT:
                    switch (state)
                    {
                        case E_SCROLLBUTTONSTATE.BS_NORMAL:
                            aRect = new int[, ] { 
                            { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 2 },
                            { 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 2 },
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 2, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 2, 2, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 2, 2, 2, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 2, 2, 2, 2, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 2, 2, 2, 4, 4, 4, 4, 4, 3, 2 }, 
						    { 4, 1, 4, 4, 4, 4, 4, 2, 2, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 2, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 2 }, 
                            { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 } 
                            };
                            mp_DrawRasterButton(X1, Y1, X1 + width, Y1 + height, lWidth, aRect);
                            break;
                        case E_SCROLLBUTTONSTATE.BS_PUSHED:
                            aRect = new int[, ] { 
                            { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 1 }, 
                            { 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 2, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 2, 2, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 2, 2, 2, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 2, 2, 2, 2, 4, 4, 4, 4, 1 }, 
						    { 3, 2, 4, 4, 4, 4, 4, 4, 2, 2, 2, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 2, 2, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 2, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 } 
                            };
                            mp_DrawRasterButton(X1, Y1, X1 + width, Y1 + height, lWidth, aRect);
                            break;
                        case E_SCROLLBUTTONSTATE.BS_INACTIVE:
                            aRect = new int[, ] { 
                            { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 2 }, 
                            { 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 3, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 3, 3, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 3, 3, 3, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 3, 3, 3, 3, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 3, 3, 3, 1, 1, 4, 4, 4, 3, 2 }, 
						    { 4, 1, 4, 4, 4, 4, 4, 3, 3, 1, 1, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 3, 1, 1, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 1, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 2 }, 
                            { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 } 
                            };
                            mp_DrawRasterButton(X1, Y1, X1 + width, Y1 + height, lWidth, aRect);
                            break;
                    }

                    break;
                case E_SCROLLBUTTON.SB_LEFT:
                    switch (state)
                    {
                        case E_SCROLLBUTTONSTATE.BS_NORMAL:
                            aRect = new int[, ] { 
                            { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 2 }, 
                            { 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 2, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 2, 2, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 2, 2, 2, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 2, 2, 2, 2, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 2, 2, 2, 4, 4, 4, 4, 4, 4, 3, 2 }, 
						    { 4, 1, 4, 4, 4, 4, 4, 2, 2, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 2, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 2 }, 
                            { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 } 
                            };
                            mp_DrawRasterButton(X1, Y1, X1 + width, Y1 + height, lWidth, aRect);
                            break;
                        case E_SCROLLBUTTONSTATE.BS_PUSHED:
                            aRect = new int[, ] { 
                            { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 1 }, 
                            { 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 2, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 2, 2, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 2, 2, 2, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 2, 2, 2, 2, 4, 4, 4, 4, 4, 4, 1 }, 
						    { 3, 2, 4, 4, 4, 4, 4, 2, 2, 2, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 2, 2, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 2, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 } 
                            };
                            mp_DrawRasterButton(X1, Y1, X1 + width, Y1 + height, lWidth, aRect);
                            break;
                        case E_SCROLLBUTTONSTATE.BS_INACTIVE:
                            aRect = new int[, ] { 
                            { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 2 }, 
                            { 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 3, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 3, 3, 1, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 3, 3, 3, 1, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 3, 3, 3, 3, 1, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 3, 3, 3, 1, 4, 4, 4, 4, 4, 3, 2 }, 
						    { 4, 1, 4, 4, 4, 4, 4, 3, 3, 1, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 3, 1, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 1, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 2 }, 
                            { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 } 
                            };
                            mp_DrawRasterButton(X1, Y1, X1 + width, Y1 + height, lWidth, aRect);
                            break;
                    }

                    break;
                case E_SCROLLBUTTON.SB_UP:
                    switch (state)
                    {
                        case E_SCROLLBUTTONSTATE.BS_NORMAL:
                            aRect = new int[, ] { 
                            { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 2 }, 
                            { 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 2, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 2, 2, 2, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 2, 2, 2, 2, 2, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 2, 2, 2, 2, 2, 2, 2, 4, 4, 4, 3, 2 }, 
						    { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 2 }, 
                            { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 } 
                            };
                            mp_DrawRasterButton(X1, Y1, X1 + width, Y1 + height, lWidth, aRect);
                            break;
                        case E_SCROLLBUTTONSTATE.BS_PUSHED:
                            aRect = new int[, ] { 
                            { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 1 }, 
                            { 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 2, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 2, 2, 2, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 2, 2, 2, 2, 2, 4, 4, 4, 4, 1 }, 
						    { 3, 2, 4, 4, 4, 4, 2, 2, 2, 2, 2, 2, 2, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 } 
                            };
                            mp_DrawRasterButton(X1, Y1, X1 + width, Y1 + height, lWidth, aRect);
                            break;
                        case E_SCROLLBUTTONSTATE.BS_INACTIVE:
                            aRect = new int[, ] { 
                            { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 2 }, 
                            { 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 3, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 3, 3, 3, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 3, 3, 3, 3, 3, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 3, 2 }, 
						    { 4, 1, 4, 4, 4, 4, 1, 1, 1, 1, 1, 1, 1, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 2 }, 
                            { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 } 
                            };
                            mp_DrawRasterButton(X1, Y1, X1 + width, Y1 + height, lWidth, aRect);
                            break;
                    }

                    break;
                case E_SCROLLBUTTON.SB_DOWN:
                    switch (state)
                    {
                        case E_SCROLLBUTTONSTATE.BS_NORMAL:
                            aRect = new int[, ] { 
                            { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 2 }, 
                            { 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 2, 2, 2, 2, 2, 2, 2, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 2, 2, 2, 2, 2, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 2, 2, 2, 4, 4, 4, 4, 4, 3, 2 }, 
						    { 4, 1, 4, 4, 4, 4, 4, 4, 2, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 2 }, 
                            { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 } 
                            };
                            mp_DrawRasterButton(X1, Y1, X1 + width, Y1 + height, lWidth, aRect);
                            break;
                        case E_SCROLLBUTTONSTATE.BS_PUSHED:
                            aRect = new int[, ] {
                            { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 1 }, 
                            { 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 2, 2, 2, 2, 2, 2, 2, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 2, 2, 2, 2, 2, 4, 4, 4, 4, 1 }, 
						    { 3, 2, 4, 4, 4, 4, 4, 4, 2, 2, 2, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 2, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 }, 
                            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 } 
                            };
                            mp_DrawRasterButton(X1, Y1, X1 + width, Y1 + height, lWidth, aRect);
                            break;
                        case E_SCROLLBUTTONSTATE.BS_INACTIVE:
                            aRect = new int[, ] {
                            { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 2 },
                            { 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 2 },
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 3, 3, 3, 3, 3, 1, 1, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 3, 3, 3, 1, 1, 4, 4, 4, 3, 2 }, 
						    { 4, 1, 4, 4, 4, 4, 4, 4, 3, 1, 1, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 1, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 },
                            { 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 2 }, 
                            { 4, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 2 }, 
                            { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 }
                            };
                            mp_DrawRasterButton(X1, Y1, X1 + width, Y1 + height, lWidth, aRect);
                            break;
                    }

                    break;
            }


        }

        private void mp_DrawRasterButton(int v_X1, int v_Y1, int v_x2, int v_Y2, int lWidth, int[,] aRect)
        {
            int xDistance = 0;
            int yDistance = 0;
            int yEnd = 0;
            int xStart = 0;
            int xEnd = 0;
            int lColorIndex = 0;
            int ix = 0;
            int iy = 0;
            int lWhite = SWM_Color_To_Int32(Color.FromArgb(255, 255, 255, 255));
            int lBlack = SWM_Color_To_Int32(Color.FromArgb(255, 0, 0, 0));
            int lDarkGray = SWM_Color_To_Int32(Color.FromArgb(255, 128, 128, 128));
            int lLightGray = SWM_Color_To_Int32(Color.FromArgb(255, 192, 192, 192));
            int lColor = 0;
            int y;
            int x;
            xDistance = aRect.GetUpperBound(1) + 1;
            yDistance = aRect.GetUpperBound(0) + 1;
            yEnd = (v_Y2 * lWidth) + v_x2;
            for (y = v_Y1; y <= v_Y2; y += yDistance + 1)
            {
                xStart = (y * lWidth) + v_X1;
                xEnd = (y * lWidth) + v_x2;
                for (x = v_X1; x <= v_x2; x += xDistance + 1)
                {
                    for (ix = 0; ix <= xDistance - 1; ix++)
                    {
                        for (iy = 0; iy <= yDistance - 1; iy++)
                        {
                            lColorIndex = aRect[iy, ix];
                            if ((y + iy) <= v_Y2)
                            {
                                if (((y * lWidth) + x + ix) >= xStart & ((y * lWidth) + x + ix) <= xEnd)
                                {
                                    lColor = 0;
                                    if (lColorIndex == 1)
                                    {
                                        lColor = lWhite;
                                    }
                                    else if (lColorIndex == 2)
                                    {
                                        lColor = lBlack;
                                    }
                                    else if (lColorIndex == 3)
                                    {
                                        lColor = lDarkGray;
                                    }
                                    else if (lColorIndex == 4)
                                    {
                                        lColor = lLightGray;
                                    }
                                    if (lColor != 0)
                                    {
                                        SetPixel(((y + iy) * lWidth) + x + ix, lColor);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        void DrawPoint(int X, int Y, Color clrColor)
        {
            mp_DrawLine(X, Y, X + 1, Y + 1, clrColor);
        }

        internal void mp_DrawArrow(int v_X, int v_Y, GRE_ARROWDIRECTION v_ArrowDirection, int v_ArrowSize, Color v_lColor)
        {
            int i = 0;
            switch (v_ArrowDirection)
            {
                case GRE_ARROWDIRECTION.AWD_LEFT:
                    DrawPoint(v_X, v_Y, v_lColor);
                    for (i = 1; i <= v_ArrowSize; i++)
                    {
                        v_X = v_X + 1;
                        DrawLine(v_X, v_Y - i, v_X, v_Y + i, GRE_LINETYPE.LT_NORMAL, v_lColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                    }

                    break;
                case GRE_ARROWDIRECTION.AWD_RIGHT:
                    DrawPoint(v_X, v_Y, v_lColor);
                    for (i = 1; i <= v_ArrowSize; i++)
                    {
                        v_X = v_X - 1;
                        DrawLine(v_X, v_Y - i, v_X, v_Y + i, GRE_LINETYPE.LT_NORMAL, v_lColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                    }

                    break;
                case GRE_ARROWDIRECTION.AWD_UP:
                    DrawPoint(v_X, v_Y, v_lColor);
                    for (i = 1; i <= v_ArrowSize; i++)
                    {
                        v_Y = v_Y + 1;
                        DrawLine(v_X - i, v_Y, v_X + i, v_Y, GRE_LINETYPE.LT_NORMAL, v_lColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                    }

                    break;
                case GRE_ARROWDIRECTION.AWD_DOWN:
                    DrawPoint(v_X, v_Y, v_lColor);
                    for (i = 1; i <= v_ArrowSize; i++)
                    {
                        v_Y = v_Y - 1;
                        DrawLine(v_X - i, v_Y, v_X + i, v_Y, GRE_LINETYPE.LT_NORMAL, v_lColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                    }

                    break;
            }
        }








    }




}
