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
	public class clsStyle : clsItemBase
	{
    
		private ActiveGanttCSECtl mp_oControl;
		public clsTaskStyle TaskStyle;
		public clsMilestoneStyle MilestoneStyle;
		public clsPredecessorStyle PredecessorStyle;
		public clsTextFlags TextFlags;
		public clsCustomBorderStyle CustomBorderStyle;
        public clsScrollBarStyle ScrollBarStyle;
        public clsSelectionRectangleStyle SelectionRectangleStyle;
        public clsButtonBorderStyle ButtonBorderStyle;
		private bool mp_bTextVisible;
		private GRE_BACKGROUNDMODE mp_yBackgroundMode;
		private bool mp_bClipText;
		private bool mp_bDrawTextInVisibleArea;
		private bool mp_bUseMask;
		private Color mp_clrBackColor;
		private Color mp_clrForeColor;
		private Color mp_clrBorderColor;
		private Color mp_clrEndGradientColor;
		private Color mp_clrStartGradientColor;
		private Font mp_oFont;
		private int mp_lPatternFactor;
		private int mp_lTextXMargin;
		private int mp_lTextYMargin;
		private int mp_lOffsetBottom;
		private int mp_lOffsetTop;
		private int mp_lImageXMargin;
		private int mp_lImageYMargin;
		private string mp_sTag;
        private int mp_lBorderWidth;
		private E_STYLEAPPEARANCE mp_yAppearance;
		private GRE_PATTERN mp_yPattern;
		private GRE_BORDERSTYLE mp_yBorderStyle;
		private GRE_BUTTONSTYLE mp_yButtonStyle;
		private GRE_HORIZONTALALIGNMENT mp_yTextAlignmentHorizontal;
		private GRE_VERTICALALIGNMENT mp_yTextAlignmentVertical;
		private E_TEXTPLACEMENT mp_yTextPlacement;
		private GRE_GRADIENTFILLMODE mp_yGradientFillMode;
		private GRE_HORIZONTALALIGNMENT mp_yImageAlignmentHorizontal;
		private GRE_VERTICALALIGNMENT mp_yImageAlignmentVertical;
		private E_PLACEMENT mp_yPlacement;
		private GRE_FILLMODE mp_yFillMode;
		private GRE_HATCHSTYLE mp_yHatchStyle;
		private Color mp_clrHatchBackColor;
		private Color mp_clrHatchForeColor;
        private Color mp_clrTextEditBackColor;
        private Color mp_clrTextEditForeColor;
    
		internal clsStyle(ActiveGanttCSECtl Value)
		{
			mp_oControl = Value;
			TaskStyle = new clsTaskStyle(mp_oControl);
			MilestoneStyle = new clsMilestoneStyle(mp_oControl);
			PredecessorStyle = new clsPredecessorStyle(mp_oControl);
			TextFlags = new clsTextFlags(mp_oControl);
			CustomBorderStyle = new clsCustomBorderStyle(mp_oControl);
            ScrollBarStyle = new clsScrollBarStyle(mp_oControl);
            SelectionRectangleStyle = new clsSelectionRectangleStyle(mp_oControl);
            ButtonBorderStyle = new clsButtonBorderStyle(mp_oControl);
			mp_bTextVisible = true;
			mp_bClipText = true;
			mp_bDrawTextInVisibleArea = false;
			mp_bUseMask = true;
			mp_clrBackColor = Color.FromArgb(255, 192, 192, 192);
			mp_clrBorderColor = Colors.Black;
			mp_clrEndGradientColor = Colors.Black;
			mp_clrForeColor = Colors.Black;
			mp_clrStartGradientColor = Colors.Black;
            mp_oFont = new Font("Tahoma",  8, E_FONTSIZEUNITS.FSU_POINTS);
			mp_lPatternFactor = 5;
			mp_lTextXMargin = 0;
			mp_lTextYMargin = 0;
			mp_lOffsetBottom = 10;
			mp_lOffsetTop = 10;
			mp_lImageXMargin = 3;
			mp_lImageYMargin = 3;
			mp_sTag = "";
            mp_lBorderWidth = 1;
			mp_yAppearance = E_STYLEAPPEARANCE.SA_RAISED;
			mp_yPattern = GRE_PATTERN.FP_DOWNWARDDIAGONAL;
			mp_yBorderStyle = GRE_BORDERSTYLE.SBR_NONE;
			mp_yButtonStyle = GRE_BUTTONSTYLE.BT_NORMALWINDOWS;
			mp_yTextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_CENTER;
			mp_yTextAlignmentVertical = GRE_VERTICALALIGNMENT.VAL_CENTER;
			mp_yTextPlacement = E_TEXTPLACEMENT.SCP_OBJECTEXTENTSPLACEMENT;
			mp_yGradientFillMode = GRE_GRADIENTFILLMODE.GDT_HORIZONTAL;
			mp_yImageAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_CENTER;
			mp_yImageAlignmentVertical = GRE_VERTICALALIGNMENT.VAL_CENTER;
			mp_yPlacement = E_PLACEMENT.PLC_ROWEXTENTSPLACEMENT;
			mp_yFillMode = GRE_FILLMODE.FM_COMPLETELYFILLED;
			mp_yBackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
			mp_yHatchStyle = GRE_HATCHSTYLE.HS_HORIZONTAL;
			mp_clrHatchBackColor = Colors.White;
			mp_clrHatchForeColor = Colors.Black;
            mp_clrTextEditBackColor = Colors.White;
            mp_clrTextEditForeColor = Colors.Black;
		}

        public Color TextEditBackColor
        {
            get { return mp_clrTextEditBackColor; }
            set { mp_clrTextEditBackColor = value; }
        }

        public Color TextEditForeColor
        {
            get { return mp_clrTextEditForeColor; }
            set { mp_clrTextEditForeColor = value; }
        }
    
		public Color HatchBackColor 
		{
			get { return mp_clrHatchBackColor; }
			set { mp_clrHatchBackColor = value; }
		}
    
		public Color HatchForeColor 
		{
			get { return mp_clrHatchForeColor; }
			set { mp_clrHatchForeColor = value; }
		}
    
		public string Key 
		{
			get { return mp_sKey; }
			set { mp_oControl.Styles.oCollection.mp_SetKey(ref mp_sKey, value, SYS_ERRORS.STYLES_SET_KEY); }
		}
    
		public E_STYLEAPPEARANCE Appearance 
		{
			get { return mp_yAppearance; }
			set { mp_yAppearance = value; }
		}
    
		public Color BackColor 
		{
			get { return mp_clrBackColor; }
			set { mp_clrBackColor = value; }
		}
    
		public GRE_PATTERN Pattern 
		{
			get { return mp_yPattern; }
			set { mp_yPattern = value; }
		}
    
		public Color BorderColor 
		{
			get { return mp_clrBorderColor; }
			set { mp_clrBorderColor = value; }
		}
    
		public GRE_BORDERSTYLE BorderStyle 
		{
			get { return mp_yBorderStyle; }
			set { mp_yBorderStyle = value; }
		}
    
		public GRE_BUTTONSTYLE ButtonStyle 
		{
			get { return mp_yButtonStyle; }
			set { mp_yButtonStyle = value; }
		}
    
		public GRE_HORIZONTALALIGNMENT TextAlignmentHorizontal 
		{
			get { return mp_yTextAlignmentHorizontal; }
			set { mp_yTextAlignmentHorizontal = value; }
		}
    
		public GRE_VERTICALALIGNMENT TextAlignmentVertical 
		{
			get { return mp_yTextAlignmentVertical; }
			set { mp_yTextAlignmentVertical = value; }
		}
    
		public bool TextVisible 
		{
			get { return mp_bTextVisible; }
			set { mp_bTextVisible = value; }
		}
    
		public int TextXMargin 
		{
			get { return mp_lTextXMargin; }
			set { mp_lTextXMargin = value; }
		}
    
		public int TextYMargin 
		{
			get { return mp_lTextYMargin; }
			set { mp_lTextYMargin = value; }
		}
    
		public bool ClipText 
		{
			get { return mp_bClipText; }
			set { mp_bClipText = value; }
		}
    
		public Font Font 
		{
			get { return mp_oFont; }
			set { mp_oFont = value; }
		}
    
		public Color ForeColor 
		{
			get { return mp_clrForeColor; }
			set { mp_clrForeColor = value; }
		}
    
		public int OffsetBottom 
		{
			get { return mp_lOffsetBottom; }
			set { mp_lOffsetBottom = value; }
		}
    
		public int OffsetTop 
		{
			get { return mp_lOffsetTop; }
			set { mp_lOffsetTop = value; }
		}
    
		public GRE_HORIZONTALALIGNMENT ImageAlignmentHorizontal 
		{
			get { return mp_yImageAlignmentHorizontal; }
			set { mp_yImageAlignmentHorizontal = value; }
		}
    
		public GRE_VERTICALALIGNMENT ImageAlignmentVertical 
		{
			get { return mp_yImageAlignmentVertical; }
			set { mp_yImageAlignmentVertical = value; }
		}
    
		public int ImageXMargin 
		{
			get { return mp_lImageXMargin; }
			set { mp_lImageXMargin = value; }
		}
    
		public int ImageYMargin 
		{
			get { return mp_lImageYMargin; }
			set { mp_lImageYMargin = value; }
		}
    
		public E_PLACEMENT Placement 
		{
			get { return mp_yPlacement; }
			set { mp_yPlacement = value; }
		}
    
		public bool UseMask 
		{
			get { return mp_bUseMask; }
			set { mp_bUseMask = value; }
		}
    
		public E_TEXTPLACEMENT TextPlacement 
		{
			get { return mp_yTextPlacement; }
			set { mp_yTextPlacement = value; }
		}
    
		public int PatternFactor 
		{
			get { return mp_lPatternFactor; }
			set { mp_lPatternFactor = value; }
		}
    
		public GRE_HATCHSTYLE HatchStyle 
		{
			get { return mp_yHatchStyle; }
			set { mp_yHatchStyle = value; }
		}
    
		public Color StartGradientColor 
		{
			get { return mp_clrStartGradientColor; }
			set { mp_clrStartGradientColor = value; }
		}
    
		public Color EndGradientColor 
		{
			get { return mp_clrEndGradientColor; }
			set { mp_clrEndGradientColor = value; }
		}
    
		public GRE_GRADIENTFILLMODE GradientFillMode 
		{
			get { return mp_yGradientFillMode; }
			set { mp_yGradientFillMode = value; }
		}
    
		public GRE_FILLMODE FillMode 
		{
			get { return mp_yFillMode; }
			set { mp_yFillMode = value; }
		}
    
		public GRE_BACKGROUNDMODE BackgroundMode 
		{
			get { return mp_yBackgroundMode; }
			set { mp_yBackgroundMode = value; }
		}
    
		public bool DrawTextInVisibleArea 
		{
			get { return mp_bDrawTextInVisibleArea; }
			set { mp_bDrawTextInVisibleArea = value; }
		}
    
		public string Tag 
		{
			get { return mp_sTag; }
			set { mp_sTag = value; }
		}

        public int BorderWidth
        {
            get { return mp_lBorderWidth; }
            set { mp_lBorderWidth = value; }
        }

        public string GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "Style");
            oXML.InitializeWriter();
            oXML.WriteProperty("Appearance", mp_yAppearance);
            oXML.WriteProperty("BackColor", mp_clrBackColor);
            oXML.WriteProperty("BackgroundMode", mp_yBackgroundMode);
            oXML.WriteProperty("BorderColor", mp_clrBorderColor);
            oXML.WriteProperty("BorderStyle", mp_yBorderStyle);
            oXML.WriteProperty("ButtonStyle", mp_yButtonStyle);
            oXML.WriteProperty("ClipText", mp_bClipText);
            oXML.WriteProperty("DrawTextInVisibleArea", mp_bDrawTextInVisibleArea);
            oXML.WriteProperty("EndGradientColor", mp_clrEndGradientColor);
            oXML.WriteProperty("FillMode", mp_yFillMode);
            oXML.WriteProperty("Font", mp_oFont);
            oXML.WriteProperty("ForeColor", mp_clrForeColor);
            oXML.WriteProperty("GradientFillMode", mp_yGradientFillMode);
            oXML.WriteProperty("HatchBackColor", mp_clrHatchBackColor);
            oXML.WriteProperty("HatchForeColor", mp_clrHatchForeColor);
            oXML.WriteProperty("HatchStyle", mp_yHatchStyle);
            oXML.WriteProperty("ImageAlignmentHorizontal", mp_yImageAlignmentHorizontal);
            oXML.WriteProperty("ImageAlignmentVertical", mp_yImageAlignmentVertical);
            oXML.WriteProperty("ImageXMargin", mp_lImageXMargin);
            oXML.WriteProperty("ImageYMargin", mp_lImageYMargin);
            oXML.WriteProperty("Key", mp_sKey);
            oXML.WriteProperty("OffsetBottom", mp_lOffsetBottom);
            oXML.WriteProperty("OffsetTop", mp_lOffsetTop);
            oXML.WriteProperty("Pattern", mp_yPattern);
            oXML.WriteProperty("PatternFactor", mp_lPatternFactor);
            oXML.WriteProperty("Placement", mp_yPlacement);
            oXML.WriteProperty("StartGradientColor", mp_clrStartGradientColor);
            oXML.WriteProperty("Tag", mp_sTag);
            oXML.WriteProperty("BorderWidth", mp_lBorderWidth);
            oXML.WriteProperty("TextAlignmentHorizontal", mp_yTextAlignmentHorizontal);
            oXML.WriteProperty("TextAlignmentVertical", mp_yTextAlignmentVertical);
            oXML.WriteProperty("TextPlacement", mp_yTextPlacement);
            oXML.WriteProperty("TextVisible", mp_bTextVisible);
            oXML.WriteProperty("TextXMargin", mp_lTextXMargin);
            oXML.WriteProperty("TextYMargin", mp_lTextYMargin);
            oXML.WriteProperty("UseMask", mp_bUseMask);
            oXML.WriteProperty("TextEditBackColor", mp_clrTextEditBackColor);
            oXML.WriteProperty("TextEditForeColor", mp_clrTextEditForeColor);
            oXML.WriteObject(CustomBorderStyle.GetXML());
            oXML.WriteObject(MilestoneStyle.GetXML());
            oXML.WriteObject(PredecessorStyle.GetXML());
            oXML.WriteObject(TaskStyle.GetXML());
            oXML.WriteObject(TextFlags.GetXML());
            oXML.WriteObject(ScrollBarStyle.GetXML());
            oXML.WriteObject(SelectionRectangleStyle.GetXML());
            oXML.WriteObject(ButtonBorderStyle.GetXML());
            return oXML.GetXML();
        }


        public void SetXML(string sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "Style");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            oXML.ReadProperty("Appearance", ref mp_yAppearance);
            oXML.ReadProperty("BackColor", ref mp_clrBackColor);
            oXML.ReadProperty("BackgroundMode", ref mp_yBackgroundMode);
            oXML.ReadProperty("BorderColor", ref mp_clrBorderColor);
            oXML.ReadProperty("BorderStyle", ref mp_yBorderStyle);
            oXML.ReadProperty("ButtonStyle", ref mp_yButtonStyle);
            oXML.ReadProperty("ClipText", ref mp_bClipText);
            oXML.ReadProperty("DrawTextInVisibleArea", ref mp_bDrawTextInVisibleArea);
            oXML.ReadProperty("EndGradientColor", ref mp_clrEndGradientColor);
            oXML.ReadProperty("FillMode", ref mp_yFillMode);
            oXML.ReadProperty("Font", ref mp_oFont);
            oXML.ReadProperty("ForeColor", ref mp_clrForeColor);
            oXML.ReadProperty("GradientFillMode", ref mp_yGradientFillMode);
            oXML.ReadProperty("HatchBackColor", ref mp_clrHatchBackColor);
            oXML.ReadProperty("HatchForeColor", ref mp_clrHatchForeColor);
            oXML.ReadProperty("HatchStyle", ref mp_yHatchStyle);
            oXML.ReadProperty("ImageAlignmentHorizontal", ref mp_yImageAlignmentHorizontal);
            oXML.ReadProperty("ImageAlignmentVertical", ref mp_yImageAlignmentVertical);
            oXML.ReadProperty("ImageXMargin", ref mp_lImageXMargin);
            oXML.ReadProperty("ImageYMargin", ref mp_lImageYMargin);
            oXML.ReadProperty("Key", ref mp_sKey);
            oXML.ReadProperty("OffsetBottom", ref mp_lOffsetBottom);
            oXML.ReadProperty("OffsetTop", ref mp_lOffsetTop);
            oXML.ReadProperty("Pattern", ref mp_yPattern);
            oXML.ReadProperty("PatternFactor", ref mp_lPatternFactor);
            oXML.ReadProperty("Placement", ref mp_yPlacement);
            oXML.ReadProperty("StartGradientColor", ref mp_clrStartGradientColor);
            oXML.ReadProperty("Tag", ref mp_sTag);
            oXML.ReadProperty("BorderWidth", ref mp_lBorderWidth);
            oXML.ReadProperty("TextAlignmentHorizontal", ref mp_yTextAlignmentHorizontal);
            oXML.ReadProperty("TextAlignmentVertical", ref mp_yTextAlignmentVertical);
            oXML.ReadProperty("TextPlacement", ref mp_yTextPlacement);
            oXML.ReadProperty("TextVisible", ref mp_bTextVisible);
            oXML.ReadProperty("TextXMargin", ref mp_lTextXMargin);
            oXML.ReadProperty("TextYMargin", ref mp_lTextYMargin);
            oXML.ReadProperty("UseMask", ref mp_bUseMask);
            oXML.ReadProperty("TextEditBackColor", ref mp_clrTextEditBackColor);
            oXML.ReadProperty("TextEditForeColor", ref mp_clrTextEditForeColor);
            CustomBorderStyle.SetXML(oXML.ReadObject("CustomBorderStyle"));
            MilestoneStyle.SetXML(oXML.ReadObject("MilestoneStyle"));
            PredecessorStyle.SetXML(oXML.ReadObject("PredecessorStyle"));
            TaskStyle.SetXML(oXML.ReadObject("TaskStyle"));
            TextFlags.SetXML(oXML.ReadObject("TextFlags"));
            ScrollBarStyle.SetXML(oXML.ReadObject("ScrollBarStyle"));
            SelectionRectangleStyle.SetXML(oXML.ReadObject("SelectionRectangleStyle"));
            ButtonBorderStyle.SetXML(oXML.ReadObject("ButtonBorderStyle"));
        }
	}
}
