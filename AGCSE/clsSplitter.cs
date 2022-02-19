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
using System.Collections;

namespace AGCSE
{
	public class clsSplitter
	{
		private ActiveGanttCSECtl mp_oControl;
		private int mp_lPosition;
		private E_BORDERSTYLE mp_yAppearance;
        private int mp_lWidth;
        private E_SPLITTERTYPE mp_yType;
        private ArrayList mp_aColors;
        private String mp_sStyleIndex;
        private clsStyle mp_oStyle;
        private int mp_lOffset;

		public clsSplitter(ActiveGanttCSECtl Value)
		{
			mp_oControl = Value;
			mp_lPosition = 125;
            mp_aColors = new ArrayList();
			mp_yAppearance = E_BORDERSTYLE.TLB_3D;
            mp_yType = E_SPLITTERTYPE.SA_APPEARANCE;
            this.Width = 6;
            mp_sStyleIndex = "DS_SPLITTER";
            mp_oStyle = mp_oControl.Styles.FItem("DS_SPLITTER");
            mp_lOffset = -1;
		}
		
		~clsSplitter()
		{
		}

        public void SetColor(int Index, Color oColor)
        {
            Index = Index - 1;
            if (mp_yType != E_SPLITTERTYPE.SA_USERDEFINED)
            {
                mp_oControl.mp_ErrorReport(SYS_ERRORS.SPLITTER_INVALIDOP, "Invalid Operation", "ActiveGanttCSECtl.clsSplitter.SetColor");
                return;
            }
            if (Index < 0)
            {
                mp_oControl.mp_ErrorReport(SYS_ERRORS.SPLITTER_INVALID_INDEX, "Invalid Index", "ActiveGanttCSECtl.clsSplitter.SetColor");
                return;
            }
            if (Index > mp_aColors.Count - 1)
            {
                mp_oControl.mp_ErrorReport(SYS_ERRORS.SPLITTER_INVALID_INDEX, "Invalid Index", "ActiveGanttCSECtl.clsSplitter.SetColor");
                return;
            }
            mp_aColors[Index] = oColor;
        }

        public Nullable<Color> GetColor(int Index)
        {
            Index = Index - 1;
            if (mp_yType != E_SPLITTERTYPE.SA_USERDEFINED)
            {
                mp_oControl.mp_ErrorReport(SYS_ERRORS.SPLITTER_INVALIDOP, "Invalid Operation", "ActiveGanttCSECtl.clsSplitter.GetColor");
                return null;
            }
            if (Index < 0)
            {
                mp_oControl.mp_ErrorReport(SYS_ERRORS.SPLITTER_INVALID_INDEX, "Invalid Index", "ActiveGanttCSECtl.clsSplitter.GetColor");
                return null;
            }
            if (Index > mp_aColors.Count - 1)
            {
                mp_oControl.mp_ErrorReport(SYS_ERRORS.SPLITTER_INVALID_INDEX, "Invalid Index", "ActiveGanttCSECtl.clsSplitter.GetColor");
                return null;
            }
            return (Color)mp_aColors[Index];
        }

        public E_SPLITTERTYPE Type
        {
            get { return mp_yType; }
            set { mp_yType = value; }
        }

		public E_BORDERSTYLE Appearance 
		{
			get 
			{
				return mp_yAppearance;
			}
			set 
			{
				mp_yAppearance = value;
			}
		}

        public int Width
        {
            get
            {
                if (mp_yType == E_SPLITTERTYPE.SA_APPEARANCE)
                {
                    return 6;
                }
                else
                {
                    return mp_lWidth;
                }
            }
            set
            {
                if (mp_yType == E_SPLITTERTYPE.SA_APPEARANCE)
                {
                    mp_lWidth = 6;
                }
                else
                {
                    if (value < 0)
                    {
                        mp_oControl.mp_ErrorReport(SYS_ERRORS.SPLITTER_INVALID_WIDTH, "Invalid Width Value", "ActiveGanttCSECtl.clsSplitter.Width");
                        return;
                    }
                    mp_lWidth = value;
                }
                int i = 0;
                mp_aColors.Clear();
                for (i = 0; i <= mp_lWidth - 1; i++)
                {
                    mp_aColors.Add(Colors.White);
                }
            }
        }

		public int Position 
		{
			get 
			{
				return mp_lPosition;
			}
			set 
			{
				if ((value <= 0))
				{
					return;
				}
				mp_lPosition = value;
                if (mp_lPosition > (mp_oControl.Columns.Width + mp_lOffset))
                {
                    mp_lPosition = mp_oControl.Columns.Width + mp_lOffset;
                    mp_oControl.HorizontalScrollBar.Value = 0;
                }
			}
		}

		internal int Left 
		{
			get 
			{
				if (mp_oControl.Columns.Count != 0)
				{
					return Position + mp_oControl.mt_BorderThickness - 1;
				}
				else
				{
					if ((mp_oControl.f_UserMode == true))
					{
						return 0;
					}
					else
					{
						return 125 + mp_oControl.mt_BorderThickness - 1;
					}
				}
			}
		}

		internal int Right 
		{
			get 
			{
				if (mp_oControl.Columns.Count != 0)
				{
                    return Position + mp_oControl.mt_BorderThickness + this.Width;
				}
				else
				{
					if ((mp_oControl.f_UserMode == true))
					{
						return mp_oControl.mt_BorderThickness;
					}
					else
					{
                        return 125 + mp_oControl.mt_BorderThickness + this.Width;
					}
				}
			}
		}

        public string StyleIndex
        {
            get
            {
                if (mp_sStyleIndex == "DS_SPLITTER")
                {
                    return "";
                }
                else
                {
                    return mp_sStyleIndex;
                }
            }
            set
            {
                value = value.Trim();
                if (value.Length == 0)
                    value = "DS_SPLITTER";
                mp_sStyleIndex = value;
                mp_oStyle = mp_oControl.Styles.FItem(value);
            }
        }

        public clsStyle Style
        {
            get { return mp_oStyle; }
        }

        internal void Draw()
        {
            if (mp_oControl.Columns.Count == 0 & mp_oControl.f_UserMode == true)
            {
                return;
            }
            mp_oControl.clsG.ClipRegion(this.Left + 1, 0, this.Left + this.Width + 1, mp_oControl.mt_BottomMargin, true);
            if (mp_yType == E_SPLITTERTYPE.SA_STYLE)
            {
                mp_oControl.clsG.mp_DrawItem(this.Left + 1, 0, this.Left + this.Width + 1, mp_oControl.clsG.Height, "", "", false, null, 0, 0,
                this.Style);
            }
            else
            {
                int i = 0;
                if (mp_yType == E_SPLITTERTYPE.SA_APPEARANCE)
                {
                    mp_aColors.Clear();
                    for (i = 0; i <= 5; i++)
                    {
                        mp_aColors.Add(Colors.White);
                    }
                    switch (mp_yAppearance)
                    {
                        case E_BORDERSTYLE.TLB_3D:
                            mp_aColors[0] = Color.FromArgb(255, 192, 192, 192);
                            mp_aColors[1] = Colors.White;
                            mp_aColors[2] = Color.FromArgb(255, 192, 192, 192);
                            mp_aColors[3] = Color.FromArgb(255, 192, 192, 192);
                            mp_aColors[4] = Color.FromArgb(255, 64, 64, 64);
                            mp_aColors[5] = Color.FromArgb(255, 66, 66, 66);
                            break;
                        case E_BORDERSTYLE.TLB_NONE:
                            mp_aColors[0] = Color.FromArgb(255, 192, 192, 192);
                            mp_aColors[1] = Color.FromArgb(255, 192, 192, 192);
                            mp_aColors[2] = Color.FromArgb(255, 192, 192, 192);
                            mp_aColors[3] = Color.FromArgb(255, 192, 192, 192);
                            mp_aColors[4] = Color.FromArgb(255, 192, 192, 192);
                            mp_aColors[5] = Color.FromArgb(255, 192, 192, 192);
                            break;
                        case E_BORDERSTYLE.TLB_SINGLE:
                            mp_aColors[0] = Colors.Black;
                            mp_aColors[1] = Color.FromArgb(255, 192, 192, 192);
                            mp_aColors[2] = Color.FromArgb(255, 192, 192, 192);
                            mp_aColors[3] = Color.FromArgb(255, 192, 192, 192);
                            mp_aColors[4] = Color.FromArgb(255, 192, 192, 192);
                            mp_aColors[5] = Colors.Black;
                            break;
                    }
                }
                for (i = 0; i <= mp_aColors.Count - 1; i++)
                {
                    mp_oControl.clsG.DrawLine(this.Left + i + 1, 0, this.Left + i + 1, mp_oControl.clsG.Height, GRE_LINETYPE.LT_NORMAL, (Color)mp_aColors[i], GRE_LINEDRAWSTYLE.LDS_SOLID);
                }
            }
        }

		internal void f_AdjustPosition()
		{
			int lWidth;
            lWidth = mp_oControl.Columns.Width + mp_lOffset;
			if (lWidth < (mp_oControl.clsG.Width - 25))
			{
				if (mp_lPosition < lWidth)
				{
					mp_lPosition = lWidth;
				}
			}
			if (mp_lPosition > lWidth)
			{
				mp_lPosition = lWidth;
				mp_oControl.HorizontalScrollBar.Value = 0;
			}
		}

        public int Offset
        {
            get { return mp_lOffset; }
            set { mp_lOffset = value; }
        }

        public String GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "Splitter");
            oXML.InitializeWriter();
            oXML.WriteProperty("Appearance", mp_yAppearance);
            oXML.WriteProperty("Offset", mp_lOffset);
            oXML.WriteProperty("Position", mp_lPosition);
            oXML.WriteProperty("Type", mp_yType);
            oXML.WriteProperty("StyleIndex", mp_sStyleIndex);
            oXML.WriteProperty("Width", mp_lWidth);
            if (mp_yType == E_SPLITTERTYPE.SA_USERDEFINED)
            {
                oXML.WriteProperty("ColorCount", mp_aColors.Count);
                int i = 0;
                for (i = 0; i <= mp_aColors.Count - 1; i++)
                {
                    oXML.WriteProperty("Color" + i.ToString(), (Color)mp_aColors[i]);
                }
            }
            else
            {
                oXML.WriteProperty("ColorCount", 0);
            }
            return oXML.GetXML();
        }

        public void SetXML(String sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "Splitter");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            oXML.ReadProperty("Appearance", ref mp_yAppearance);
            oXML.ReadProperty("Offset", ref mp_lOffset);
            oXML.ReadProperty("Position", ref mp_lPosition);
            Position = mp_lPosition;
            oXML.ReadProperty("Type", ref mp_yType);
            oXML.ReadProperty("StyleIndex", ref mp_sStyleIndex);
            StyleIndex = mp_sStyleIndex;
            oXML.ReadProperty("Width", ref mp_lWidth);
            mp_aColors.Clear();
            int lColorCount = 0;
            oXML.ReadProperty("ColorCount", ref lColorCount);
            if (lColorCount > 0)
            {
                int i = 0;
                for (i = 0; i <= lColorCount - 1; i++)
                {
                    Color oColor = Colors.White;
                    oXML.ReadProperty("Color" + i.ToString(), ref oColor);
                    mp_aColors.Add(oColor);
                }
            }
            StyleIndex = mp_sStyleIndex;
        }

	}
}
