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
	public class clsCell : clsItemBase
	{
    
		private ActiveGanttCSECtl mp_oControl;
		private string mp_sText;
		private Image mp_oImage;
		private string mp_sStyleIndex;
		private string mp_sTag;
		private clsCells mp_oCells;
		private clsStyle mp_oStyle;
        private string mp_sImageTag;
        internal double mp_lTextLeft;
        internal double mp_lTextTop;
        internal double mp_lTextRight;
        internal double mp_lTextBottom;
        private bool mp_bAllowTextEdit;
    
		internal clsCell(ActiveGanttCSECtl Value, clsCells oCells)
		{
			mp_oControl = Value;
			mp_sText = "";
			mp_oImage = null;
			mp_sStyleIndex = "DS_CELL";
			mp_oStyle = mp_oControl.Styles.FItem("DS_CELL");
			mp_sTag = "";
			mp_oCells = oCells;
            mp_sImageTag = "";
            mp_bAllowTextEdit = false;
		}

        public bool AllowTextEdit
        {
            get { return mp_bAllowTextEdit; }
            set { mp_bAllowTextEdit = value; }
        }
    
		public clsRow Row 
		{
			get { return mp_oCells.Row(); }
		}
    
		public string Key 
		{
			get { return mp_sKey; }
			set { mp_oCells.oCollection.mp_SetKey(ref mp_sKey, value, SYS_ERRORS.CELLS_SET_KEY); }
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
				if (mp_sStyleIndex == "DS_CELL") 
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
                    value = "DS_CELL"; 
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
    
		public string RowKey 
		{
			get { return mp_oCells.Row().Key; }
		}
    
		public int Left 
		{
			get { return mp_oControl.Columns.Item(mp_lIndex.ToString()).Left; }
		}
    
		public int Top 
		{
			get { return mp_oCells.Row().Top; }
		}
    
		public int Right 
		{
			get { return mp_oControl.Columns.Item(mp_lIndex.ToString()).Right; }
		}
    
		public int Bottom 
		{
			get { return mp_oCells.Row().Bottom; }
		}
    
		public int LeftTrim 
		{
			get { return mp_oControl.Columns.Item(mp_lIndex.ToString()).LeftTrim; }
		}
    
		public int RightTrim 
		{
			get { return mp_oControl.Columns.Item(mp_lIndex.ToString()).RightTrim; }
		}

        public string ImageTag
        {
            get { return mp_sImageTag; }
            set { mp_sImageTag = value; }
        }

        public string GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "Cell");
            oXML.InitializeWriter();
            oXML.WriteProperty("Image", mp_oImage);
            oXML.WriteProperty("Key", mp_sKey);
            oXML.WriteProperty("StyleIndex", mp_sStyleIndex);
            oXML.WriteProperty("Tag", mp_sTag);
            oXML.WriteProperty("Text", mp_sText);
            oXML.WriteProperty("ImageTag", mp_sImageTag);
            oXML.WriteProperty("AllowTextEdit", mp_bAllowTextEdit);
            return oXML.GetXML();
        }

        public void SetXML(string sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "Cell");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            oXML.ReadProperty("Image", ref mp_oImage);
            oXML.ReadProperty("Key", ref mp_sKey);
            oXML.ReadProperty("StyleIndex", ref mp_sStyleIndex);
            StyleIndex = mp_sStyleIndex;
            oXML.ReadProperty("Tag", ref mp_sTag);
            oXML.ReadProperty("Text", ref mp_sText);
            oXML.ReadProperty("ImageTag", ref mp_sImageTag);
            oXML.ReadProperty("AllowTextEdit", ref mp_bAllowTextEdit);
        }
    
	}
}
