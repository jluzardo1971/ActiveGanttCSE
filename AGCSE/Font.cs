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
    public class Font
    {

        private string mp_sFamily;
        public float Size = 10;
        internal bool Italic = false;
        internal bool Underline = false;
        public FontStyle FontStyle;
        public FontWeight FontWeight;
        public GRE_VERTICALALIGNMENT VerticalAlignment = GRE_VERTICALALIGNMENT.VAL_TOP;

        public GRE_HORIZONTALALIGNMENT HorizontalAlignment = GRE_HORIZONTALALIGNMENT.HAL_LEFT;

        public Font(string FamilyName, float lSize, E_FONTSIZEUNITS lSizeUnits)
        {
            mp_sFamily = FamilyName;
            if (lSizeUnits == E_FONTSIZEUNITS.FSU_PIXELS)
            {
                Size = lSize;
            }
            else if (lSizeUnits == E_FONTSIZEUNITS.FSU_POINTS)
            {
                Size = (96 * lSize / 72);
            }
            
        }

        public Font(string FamilyName, float lSize, E_FONTSIZEUNITS lSizeUnits, FontWeight newStyle)
        {
            mp_sFamily = FamilyName;
            if (lSizeUnits == E_FONTSIZEUNITS.FSU_PIXELS)
            {
                Size = lSize;
            }
            else if (lSizeUnits == E_FONTSIZEUNITS.FSU_POINTS)
            {
                Size = (96 * lSize / 72);
            }
            FontWeight = newStyle;
        }

        public float GetSize(E_FONTSIZEUNITS lSizeUnits)
        {
            if (lSizeUnits == E_FONTSIZEUNITS.FSU_PIXELS)
            {
                return Size;
            }
            else if (lSizeUnits == E_FONTSIZEUNITS.FSU_POINTS)
            {
                return  Size / 96 * 72;
            }
            return 0;
        }

        public FontFamily GetFontFamily()
        {
            FontFamily oFontFamily = new FontFamily(mp_sFamily);
            return oFontFamily;
        }


        public Font Clone()
        {
            return (Font)this.MemberwiseClone();
        }

        public string Name
        {
            get { return mp_sFamily; }
        }

        public string FamilyName
        {
            get { return mp_sFamily; }
            set { mp_sFamily = value; }
        }

        internal bool Bold
        {
            get
            {
                if (FontWeight == FontWeights.Bold)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }

}
