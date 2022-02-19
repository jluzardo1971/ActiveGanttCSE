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
	public class clsPercentage : clsItemBase
	{
    
		private ActiveGanttCSECtl mp_oControl;
		private float mp_fPercent;
		private string mp_sTaskKey;
		private string mp_sTag;
		private bool mp_bVisible;
		private bool mp_bAllowSize;
		private clsTask mp_oTask;
        private string mp_sStyleIndex;
        private clsStyle mp_oStyle;
        private string mp_sFormat;

		internal clsPercentage(ActiveGanttCSECtl Value)
		{
			mp_oControl = Value;
			mp_fPercent = 0;
			mp_sTaskKey = "";
			mp_sTag = "";
			mp_bVisible = true;
			mp_bAllowSize = true;
            mp_sStyleIndex = "DS_PERCENTAGE";
            mp_oStyle = mp_oControl.Styles.FItem("DS_PERCENTAGE");
            mp_sFormat = "";
		}
    
		public bool AllowSize 
		{
			get { return mp_bAllowSize; }
			set { mp_bAllowSize = value; }
		}
    
		public string Key 
		{
			get { return mp_sKey; }
			set { mp_oControl.Percentages.oCollection.mp_SetKey(ref mp_sKey, value, SYS_ERRORS.PERCENTAGES_SET_KEY); }
		}
    
		public float Percent 
		{
			get { return mp_fPercent; }
			set { mp_fPercent = value; }
		}
    
		public string TaskKey 
		{
			get { return mp_sTaskKey; }
			set 
			{
				mp_sTaskKey = value;
				mp_oTask = mp_oControl.Tasks.Item(value);
			}
		}
    
		public clsTask Task 
		{
			get { return mp_oTask; }
		}
    
		public clsLayer Layer 
		{
			get { return mp_oTask.Layer; }
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
				if (Left < mp_oControl.Splitter.Right) 
				{
					return mp_oControl.Splitter.Right;
				}
				else 
				{
					return Left;
				}
			}
		}
    
		public int RightTrim 
		{
			get 
			{
				if (Right > mp_oControl.mt_RightMargin) 
				{
					return mp_oControl.mt_RightMargin;
				}
				else 
				{
					return Right;
				}
			}
		}
    
		internal bool f_bLeftVisible 
		{
			get 
			{
				if (LeftTrim == Left) 
				{
					return true;
				}
				else 
				{
					return false;
				}
			}
		}
    
		internal bool f_bRightVisible 
		{
			get 
			{
				if (RightTrim == Right) 
				{
					return true;
				}
				else 
				{
					return false;
				}
			}
		}
    
		public int Left 
		{
			get { return mp_oTask.Left; }
		}
    
		public int Top 
		{
			get 
			{
				if ((mp_oTask.Row.Height <= -1)) 
				{
					return mp_oTask.Row.Top;
				}
				if (mp_oStyle.Placement == E_PLACEMENT.PLC_ROWEXTENTSPLACEMENT | mp_oStyle.Appearance == E_STYLEAPPEARANCE.SA_CELL) 
				{
					return mp_oTask.Row.Top;
				}
				if (mp_oStyle.Placement == E_PLACEMENT.PLC_OFFSETPLACEMENT) 
				{
					return mp_oTask.Row.Top + mp_oStyle.OffsetTop;
				}
				return 0;
			}
		}
    
		public int Bottom 
		{
			get 
			{
				if ((mp_oTask.Row.Height <= -1)) 
				{
					return mp_oTask.Row.Top;
				}
				if (mp_oStyle.Placement == E_PLACEMENT.PLC_ROWEXTENTSPLACEMENT | mp_oStyle.Appearance == E_STYLEAPPEARANCE.SA_CELL) 
				{
					return mp_oTask.Row.Bottom - 1;
				}
				if (mp_oStyle.Placement == E_PLACEMENT.PLC_OFFSETPLACEMENT) 
				{
					return mp_oTask.Row.Top + mp_oStyle.OffsetTop + mp_oStyle.OffsetBottom;
				}
				return 0;
			}
		}
    
		public int Right 
		{
			get { return Left + System.Convert.ToInt32((mp_oTask.Right - mp_oTask.Left) * mp_fPercent); }
		}
    
		internal int RightSel 
		{
			get 
			{
				if (Right == Left) 
				{
					return Left + 15;
				}
				else 
				{
					return Right;
				}
			}
		}
    
		public bool Visible 
		{
			get 
			{
				if (mp_oTask.Row.Visible == false) 
				{
					return false;
				}
				if (mp_oTask.Visible == false | mp_oTask.Type == E_OBJECTTYPE.OT_MILESTONE) 
				{
					return false;
				}
				return mp_bVisible;
			}
			set { mp_bVisible = value; }
		}

        public string StyleIndex
        {
            get
            {
                if (mp_sStyleIndex == "DS_PERCENTAGE")
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
                if (value.Length == 0) { value = "DS_PERCENTAGE"; }
                mp_sStyleIndex = value;
                mp_oStyle = mp_oControl.Styles.FItem(value);
            }
        }

        public clsStyle Style
        {
            get { return mp_oStyle; }
        }

        public string Format
        {
            get { return mp_sFormat; }
            set { mp_sFormat = value; }
        }

        public string GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "Percentage");
            oXML.InitializeWriter();
            oXML.WriteProperty("AllowSize", mp_bAllowSize);
            oXML.WriteProperty("Key", mp_sKey);
            oXML.WriteProperty("Percent", mp_fPercent);
            oXML.WriteProperty("Tag", mp_sTag);
            oXML.WriteProperty("TaskKey", mp_sTaskKey);
            oXML.WriteProperty("Visible", mp_bVisible);
            oXML.WriteProperty("StyleIndex", mp_sStyleIndex);
            oXML.WriteProperty("Format", mp_sFormat);
            return oXML.GetXML();
        }


        public void SetXML(string sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "Percentage");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            oXML.ReadProperty("AllowSize", ref mp_bAllowSize);
            oXML.ReadProperty("Key", ref mp_sKey);
            oXML.ReadProperty("Percent", ref mp_fPercent);
            oXML.ReadProperty("Tag", ref mp_sTag);
            oXML.ReadProperty("TaskKey", ref mp_sTaskKey);
            mp_oTask = mp_oControl.Tasks.Item(mp_sTaskKey);
            oXML.ReadProperty("Visible", ref mp_bVisible);
            oXML.ReadProperty("StyleIndex", ref mp_sStyleIndex);
            StyleIndex = mp_sStyleIndex;
            oXML.ReadProperty("Format", ref mp_sFormat);
        }
    
	}
}
