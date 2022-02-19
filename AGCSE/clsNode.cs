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

	public class clsNode
	{
    
		private ActiveGanttCSECtl mp_oControl;
		internal bool mp_bExpanded;
		private string mp_sTag;
		private Image mp_oImage;
		private Image mp_oExpandedImage;
		private Image mp_oSelectedImage;
		private bool mp_bChecked;
		private int mp_lDepth;
		private clsRow mp_oRow;
		private bool mp_bCheckBoxVisible;
		private bool mp_bImageVisible;
        internal clsNode mp_oParent;
        private string mp_sExpandedImageTag;
        private string mp_sSelectedImageTag;
        private string mp_sImageTag;
        private string mp_sStyleIndex;
        private clsStyle mp_oStyle;
        internal double mp_lTextLeft;
        internal double mp_lTextTop;
        internal double mp_lTextRight;
        internal double mp_lTextBottom;
        private bool mp_bAllowTextEdit;
    
		internal clsNode(ActiveGanttCSECtl Value, clsRow oRow)
		{
			mp_oControl = Value;
			mp_oRow = oRow;
			mp_lDepth = 0;
			mp_bExpanded = true;
			mp_oImage = null;
			mp_oExpandedImage = null;
			mp_oSelectedImage = null;
			mp_bChecked = false;
			mp_bCheckBoxVisible = false;
			mp_bImageVisible = false;
			mp_sTag = "";
            mp_oParent = null;
            mp_sExpandedImageTag = "";
            mp_sSelectedImageTag = "";
            mp_sImageTag = "";
            mp_sStyleIndex = "DS_NODE";
            mp_oStyle = mp_oControl.Styles.FItem("DS_NODE");
            mp_bAllowTextEdit = false;
		}

        public bool AllowTextEdit
        {
            get { return mp_bAllowTextEdit; }
            set { mp_bAllowTextEdit = value; }
        }
    
		public clsRow Row 
		{
			get { return mp_oRow; }
		}
    
		public bool CheckBoxVisible 
		{
			get 
			{
				if (mp_oControl.Treeview.CheckBoxes == true) 
				{
					return mp_bCheckBoxVisible;
				}
				else 
				{
					return false;
				}
			}
			set { mp_bCheckBoxVisible = value; }
		}
    
		public bool ImageVisible 
		{
			get 
			{
				if (mp_oControl.Treeview.Images == true) 
				{
					if (mp_oImage == null) 
					{
						return false;
					}
					else 
					{
						return mp_bImageVisible;
					}
				}
				else 
				{
					return false;
				}
			}
			set { mp_bImageVisible = value; }
		}
    
		public int Left 
		{
			get 
			{
				if (Hidden == true) 
				{
					return 0;
				}
				else 
				{
                    return mp_oControl.Treeview.Left + mp_oControl.Treeview.Indentation + (Depth * mp_oControl.Treeview.Indentation);
				}
			}
		}
    
		public int Top 
		{
			get { return mp_oRow.Top; }
		}
    
		public int Bottom 
		{
			get { return mp_oRow.Bottom; }
		}
    
		public clsNode NextSibling()
		{
			int lIndex = Index;
			clsNode oNode = null;
			clsRow oRow = null;
			if ((lIndex + 1) <= mp_oControl.Rows.Count) 
			{
				for (lIndex = (Index + 1); lIndex <= mp_oControl.Rows.Count; lIndex++) 
				{
					oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(lIndex);
					oNode = oRow.Node;
					if (oNode.Depth == Depth) 
					{
						return oNode;
					}
					else if (oNode.Depth == Depth - 1) 
					{
						return null;
					}
				}
				return null;
			}
			else 
			{
				//This Node is the Last Node
				return null;
			}
		}
    
		public clsNode PreviousSibling()
		{
			int lIndex = Index;
			clsNode oNode = null;
			clsRow oRow = null;
			if (lIndex > 1) 
			{
				for (lIndex = (Index - 1); lIndex >= 1; lIndex += -1) 
				{
					oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(lIndex);
					oNode = oRow.Node;
					if (oNode.Depth == Depth) 
					{
						return oNode;
					}
					else if (oNode.Depth == Depth - 1) 
					{
						return null;
					}
				}
				return null;
			}
			else 
			{
				//This node is the First Node
				return null;
			}
		}
    
		public bool IsFirstSibling()
		{
			clsNode oNode = null;
			oNode = PreviousSibling();
			if (oNode == null) 
			{
				return true;
			}
			else 
			{
				return false;
			}
		}
    
		public clsNode FirstSibling()
		{
			clsNode oNode = null;
			clsNode oReturnNode = null;
			oReturnNode = this;
			oNode = PreviousSibling();
			while ((oNode != null)) 
			{
				oReturnNode = oNode;
				oNode = oReturnNode.PreviousSibling();
			}
			return oReturnNode;
		}
    
		public bool IsLastSibling()
		{
			clsNode oNode = null;
			oNode = NextSibling();
			if (oNode == null) 
			{
				return true;
			}
			else 
			{
				return false;
			}
		}
    
		public clsNode LastSibling()
		{
			clsNode oNode = null;
			clsNode oReturnNode = null;
			oReturnNode = this;
			oNode = NextSibling();
			while ((oNode != null)) 
			{
				oReturnNode = oNode;
				oNode = oReturnNode.NextSibling();
			}
			return oReturnNode;
		}
    
		public clsNode Child()
		{
			int lIndex = Index + 1;
			clsNode oNode = null;
			clsRow oRow = null;
			if (lIndex <= mp_oControl.Rows.Count) 
			{
				oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(lIndex);
				oNode = oRow.Node;
				if (oNode.Depth == (Depth + 1)) 
				{
					return oNode;
				}
				else 
				{
					return null;
				}
			}
			else 
			{
				return null;
			}
		}
    
		public clsNode Parent()
		{
            return mp_oParent;
		}
    
		public bool IsRoot()
		{
			if (Parent() == null) 
			{
				return true;
			}
			else 
			{
				return false;
			}
		}
    
		public string FullPath()
		{
			clsNode oNode = null;
			string sReturn = "";
			oNode = Parent();
			while ((oNode != null)) 
			{
				sReturn = oNode.Text + mp_oControl.Treeview.PathSeparator + sReturn;
				oNode = oNode.Parent();
			}
			return sReturn + Text;
		}
    
		public int Depth 
		{
			get { return mp_lDepth; }
			set { mp_lDepth = value; }
		}
    
		public int Children()
		{
			int lIndex = 0;
			clsNode oNode = null;
			clsRow oRow = null;
			int lReturn = 0;
			for (lIndex = (mp_oRow.Index + 1); lIndex <= mp_oControl.Rows.Count; lIndex++) 
			{
				oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(lIndex);
				oNode = oRow.Node;
				if (Depth < oNode.Depth) 
				{
					if (Depth + 1 == oNode.Depth) 
					{
						lReturn = lReturn + 1;
					}
				}
				else 
				{
					break; // TODO: might not be correct. Was : Exit For
				}
			}
			return lReturn;
		}
    
		public bool Expanded 
		{
			get 
			{
				if (Children() > 0) 
				{
					return mp_bExpanded;
				}
				else 
				{
					return true;
				}
			}
			set 
			{
				mp_bExpanded = value;
				mp_oControl.VerticalScrollBar.Update();
			}
		}
    
		public bool Selected 
		{
			get { return (Index == mp_oControl.SelectedRowIndex); }
			set 
			{
				if (value == true) 
				{
					mp_oControl.SelectedRowIndex = Index;
				}
				else 
				{
					if (mp_oControl.SelectedRowIndex == Index) 
					{
						mp_oControl.SelectedRowIndex = 0;
					}
				}
			}
		}
    
		public Image ExpandedImage 
		{
			get { return mp_oExpandedImage; }
			set { mp_oExpandedImage = value; }
		}
    
		public Image SelectedImage 
		{
			get { return mp_oSelectedImage; }
			set { mp_oSelectedImage = value; }
		}
    
		public Image Image 
		{
			get { return mp_oImage; }
			set { mp_oImage = value; }
		}
    
		public string Tag 
		{
			get { return mp_sTag; }
			set { mp_sTag = value; }
		}
    
		public string Text 
		{
			get { return mp_oRow.Text; }
			set { mp_oRow.Text = value; }
		}
    
		public bool Checked 
		{
			get { return mp_bChecked; }
			set { mp_bChecked = value; }
		}
    
		public int Height 
		{
			get { return mp_oRow.Height; }
			set { mp_oRow.Height = value; }
		}
    
		internal int YCenter 
		{
			get { return Top + (Height / 2); }
		}
    
		internal int mt_TextLeft 
		{
			get 
			{
				if (CheckBoxVisible == false & ImageVisible == false) 
				{
					return Left + 10;
				}
				else if (CheckBoxVisible == true & ImageVisible == true) 
				{
                    return Left + 28 + (int)mp_oImage.Width + 5;
				}
				else if (CheckBoxVisible == true) 
				{
					return Left + 28;
				}
				else if (ImageVisible == true) 
				{
                    return Left + 10 + (int)mp_oImage.Width + 5;
				}
				return 0;
			}
		}
    
		internal int mt_TextTop 
		{
            get { return YCenter - (mp_oControl.mp_lStrHeight(Text, mp_oStyle.Font)) + 3; }
		}

        internal int mt_TextRight 
		{
            get { return mt_TextLeft + (mp_oControl.mp_lStrWidth(Text, mp_oStyle.Font)) + 10; }
		}

        internal int mt_TextBottom 
		{
            get { return YCenter + (mp_oControl.mp_lStrHeight(Text, mp_oStyle.Font)) - 3; }
		}
    
		internal int CheckBoxLeft 
		{
			get 
			{
				if (CheckBoxVisible == true & mp_oControl.Treeview.CheckBoxes == true) 
				{
					return Left + 14;
				}
				else 
				{
					return 0;
				}
			}
		}
    
		internal int ImageLeft 
		{
			get 
			{
				if (ImageVisible == true & mp_oControl.Treeview.Images == true) 
				{
                    return mt_TextLeft - 3 - (int)mp_oImage.Width;
				}
				else 
				{
					return 0;
				}
			}
		}
    
		internal int ImageTop 
		{
			get 
			{
				if (ImageVisible == true & mp_oControl.Treeview.Images == true) 
				{
                    return YCenter - ((int)mp_oImage.Height / 2);
				}
				else 
				{
					return 0;
				}
			}
		}
    
		internal int ImageRight 
		{
			get 
			{
				if (ImageVisible == true & mp_oControl.Treeview.Images == true) 
				{
                    return ImageLeft + (int)mp_oImage.Width;
				}
				else 
				{
					return 0;
				}
			}
		}
    
		internal int ImageBottom 
		{
			get 
			{
				if (ImageVisible == true & mp_oControl.Treeview.Images == true) 
				{
                    return ImageTop + (int)mp_oImage.Height;
				}
				else 
				{
					return 0;
				}
			}
		}
    
		internal int Index 
		{
			get { return mp_oRow.Index; }
		}
    
		public bool Hidden 
		{
			get 
			{
                if (mp_lDepth == 0)
                {
                    return false;
                }
				bool bHidden = false;
				bHidden = false;
				bHidden = RecurseHidden(this, bHidden);
				return bHidden;
			}
		}
    
		private bool RecurseHidden(clsNode oNode, bool bHidden)
		{
			oNode = oNode.Parent();
			if ((oNode != null)) 
			{
				if (oNode.mp_bExpanded == false) 
				{
					bHidden = true;
				}
				bHidden = RecurseHidden(oNode, bHidden);
			}
			return bHidden;
		}

        public string ExpandedImageTag
        {
            get { return mp_sExpandedImageTag; }
            set { mp_sExpandedImageTag = value; }
        }

        public string SelectedImageTag
        {
            get { return mp_sSelectedImageTag; }
            set { mp_sSelectedImageTag = value; }
        }

        public string ImageTag
        {
            get { return mp_sImageTag; }
            set { mp_sImageTag = value; }
        }

        public string StyleIndex
        {
            get
            {
                if (mp_sStyleIndex == "DS_NODE")
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
                    value = "DS_NODE";
                mp_sStyleIndex = value;
                mp_oStyle = mp_oControl.Styles.FItem(value);
            }
        }

        public clsStyle Style
        {
            get { return mp_oStyle; }
        }

        public string GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "Node");
            oXML.InitializeWriter();
            oXML.WriteProperty("CheckBoxVisible", mp_bCheckBoxVisible);
            oXML.WriteProperty("Checked", mp_bChecked);
            oXML.WriteProperty("Depth", mp_lDepth);
            oXML.WriteProperty("Expanded", mp_bExpanded);
            oXML.WriteProperty("ExpandedImage", mp_oExpandedImage);
            oXML.WriteProperty("Image", mp_oImage);
            oXML.WriteProperty("ImageVisible", mp_bImageVisible);
            oXML.WriteProperty("SelectedImage", mp_oSelectedImage);
            oXML.WriteProperty("Tag", mp_sTag);
            oXML.WriteProperty("ExpandedImageTag", mp_sExpandedImageTag);
            oXML.WriteProperty("SelectedImageTag", mp_sSelectedImageTag);
            oXML.WriteProperty("ImageTag", mp_sImageTag);
            oXML.WriteProperty("StyleIndex", mp_sStyleIndex);
            oXML.WriteProperty("AllowTextEdit", mp_bAllowTextEdit);
            return oXML.GetXML();
        }


        public void SetXML(string sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "Node");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            oXML.ReadProperty("CheckBoxVisible", ref mp_bCheckBoxVisible);
            oXML.ReadProperty("Checked", ref mp_bChecked);
            oXML.ReadProperty("Depth", ref mp_lDepth);
            oXML.ReadProperty("Expanded", ref mp_bExpanded);
            oXML.ReadProperty("ExpandedImage", ref mp_oExpandedImage);
            oXML.ReadProperty("Image", ref mp_oImage);
            oXML.ReadProperty("ImageVisible", ref mp_bImageVisible);
            oXML.ReadProperty("SelectedImage", ref mp_oSelectedImage);
            oXML.ReadProperty("Tag", ref mp_sTag);
            oXML.ReadProperty("ExpandedImageTag", ref mp_sExpandedImageTag);
            oXML.ReadProperty("SelectedImageTag", ref mp_sSelectedImageTag);
            oXML.ReadProperty("ImageTag", ref mp_sImageTag);
            oXML.ReadProperty("StyleIndex", ref mp_sStyleIndex);
            StyleIndex = mp_sStyleIndex;
            oXML.ReadProperty("AllowTextEdit", ref mp_bAllowTextEdit);
        }
    
	}

}
