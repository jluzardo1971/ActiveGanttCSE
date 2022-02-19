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
	public class clsColumn : clsItemBase
	{
    
		private ActiveGanttCSECtl mp_oControl;
		private bool mp_bAllowMove;
		private bool mp_bAllowSize;
		private int mp_lWidth;
		private string mp_sText;
		private Image mp_oImage;
		private string mp_sStyleIndex;
		private string mp_sTag;
		private int mp_lLeft;
		private int mp_lRight;
		private bool mp_bVisible;
		private clsStyle mp_oStyle;
        private string mp_sImageTag;
        internal double mp_lTextLeft;
        internal double mp_lTextTop;
        internal double mp_lTextRight;
        internal double mp_lTextBottom;
        private bool mp_bAllowTextEdit;
        internal bool mp_bTreeViewColumnIndex;
    
		internal clsColumn(ActiveGanttCSECtl Value)
		{
			mp_oControl = Value;
			mp_bAllowMove = true;
			mp_bAllowSize = true;
			mp_lWidth = 125;
			mp_sText = "";
			mp_oImage = null;
			mp_sStyleIndex = "DS_COLUMN";
			mp_oStyle = mp_oControl.Styles.FItem("DS_COLUMN");
			mp_sTag = "";
			mp_lLeft = 0;
			mp_lRight = 0;
			mp_bVisible = false;
            mp_sImageTag = "";
            mp_bAllowTextEdit = false;
		}

        public bool AllowTextEdit
        {
            get { return mp_bAllowTextEdit; }
            set { mp_bAllowTextEdit = value; }
        }
    
		public bool AllowMove 
		{
			get { return mp_bAllowMove; }
			set { mp_bAllowMove = value; }
		}
    
		public bool AllowSize 
		{
			get { return mp_bAllowSize; }
			set { mp_bAllowSize = value; }
		}
    
		public string Key 
		{
			get { return mp_sKey; }
			set { mp_oControl.Columns.oCollection.mp_SetKey(ref mp_sKey, value, SYS_ERRORS.COLUMNS_SET_KEY); }
		}
    
		public int Width 
		{
			get { return mp_lWidth; }
			set { mp_lWidth = value; }
		}
    
		public string Text 
		{
			get { return mp_sText; }
			set { mp_sText = value; }
		}
    
		public Image Image 
		{
			get { return mp_oImage; }
			set { mp_oImage = value; }
		}
    
		public string StyleIndex 
		{
			get 
			{
				if (mp_sStyleIndex == "DS_COLUMN") 
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
                { 
                    value = "DS_COLUMN"; 
                }
				mp_sStyleIndex = value;
				mp_oStyle = mp_oControl.Styles.FItem(value);
			}
		}
    
		public clsStyle Style 
		{
			get { return mp_oStyle; }
		}
    
		public string Tag 
		{
			get { return mp_sTag; }
			set { mp_sTag = value; }
		}
    
		public int LeftTrim 
		{
			get 
			{
				if (mp_lLeft < mp_oControl.mt_LeftMargin) 
				{
					return mp_oControl.mt_LeftMargin;
				}
				else 
				{
					return mp_lLeft;
				}
			}
		}
    
		public int RightTrim 
		{
			get 
			{
				if (mp_lRight > mp_oControl.Splitter.Left) 
				{
					return mp_oControl.Splitter.Left;
				}
				else 
				{
					return mp_lRight;
				}
			}
		}
    
		public int Left 
		{
			get { return mp_lLeft; }
		}
    
		internal int f_lLeft 
		{
			set { mp_lLeft = value; }
		}
    
		public int Top 
		{
			get { return mp_oControl.mt_TopMargin; }
		}
    
		public int Right 
		{
			get { return mp_lRight; }
		}
    
		internal int f_lRight 
		{
			set { mp_lRight = value; }
		}
    
		public int Bottom 
		{
			get { return mp_oControl.CurrentViewObject.TimeLine.Bottom; }
		}
    
		public bool Visible 
		{
			get { return mp_bVisible; }
		}
    
		internal bool f_bVisible 
		{
			set 
			{
				if (value == false) 
				{
					mp_lLeft = 0;
					mp_lRight = 0;
				}
				mp_bVisible = value;
			}
		}

        public string ImageTag
        {
            get { return mp_sImageTag; }
            set { mp_sImageTag = value; }
        }

        public string GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "Column");
            oXML.InitializeWriter();
            oXML.WriteProperty("AllowMove", mp_bAllowMove);
            oXML.WriteProperty("AllowSize", mp_bAllowSize);
            oXML.WriteProperty("Image", mp_oImage);
            oXML.WriteProperty("Key", mp_sKey);
            oXML.WriteProperty("StyleIndex", mp_sStyleIndex);
            oXML.WriteProperty("Tag", mp_sTag);
            oXML.WriteProperty("Text", mp_sText);
            oXML.WriteProperty("Width", mp_lWidth);
            oXML.WriteProperty("ImageTag", mp_sImageTag);
            oXML.WriteProperty("AllowTextEdit", mp_bAllowTextEdit);
            return oXML.GetXML();
        }


        public void SetXML(string sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "Column");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            oXML.ReadProperty("AllowMove", ref mp_bAllowMove);
            oXML.ReadProperty("AllowSize", ref mp_bAllowSize);
            oXML.ReadProperty("Image", ref mp_oImage);
            oXML.ReadProperty("Key", ref mp_sKey);
            oXML.ReadProperty("StyleIndex", ref mp_sStyleIndex);
            StyleIndex = mp_sStyleIndex;
            oXML.ReadProperty("Tag", ref mp_sTag);
            oXML.ReadProperty("Text", ref mp_sText);
            oXML.ReadProperty("Width", ref mp_lWidth);
            oXML.ReadProperty("ImageTag", ref mp_sImageTag);
            oXML.ReadProperty("AllowTextEdit", ref mp_bAllowTextEdit);
        }
    
	}
}
