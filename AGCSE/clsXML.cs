using System;
using System.Windows;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Linq;

namespace AGCSE
{



    internal partial class clsXML
    {

        private ActiveGanttCSECtl mp_oControl;
        private XDocument xDoc;
        private XElement oControlElement;
        private XElement oFontElement;
        private XElement oDateTimeElement;
        private string mp_sObject;
        private PE_LEVEL mp_yLevel;
        private bool mp_bSupportOptional = false;

        private bool mp_bBoolsAreNumeric = false;
        private enum PE_LEVEL
        {
            LVL_CONTROL = 0,
            LVL_FONT = 5,
            LVL_DATETIME = 6
        }

        internal bool SupportOptional
        {
            get { return mp_bSupportOptional; }
            set { mp_bSupportOptional = value; }
        }

        internal bool BoolsAreNumeric
        {
            get { return mp_bBoolsAreNumeric; }
            set { mp_bBoolsAreNumeric = value; }
        }

        internal clsXML(ActiveGanttCSECtl Value, string sObject)
        {
            mp_oControl = Value;
            xDoc = new XDocument();
            mp_sObject = sObject;
        }

        internal void InitializeWriter()
        {
            xDoc = XDocument.Parse("<" + mp_sObject + "></" + mp_sObject + ">");
            oControlElement = GetDocumentElement(mp_sObject, 0);
            mp_yLevel = PE_LEVEL.LVL_CONTROL;
        }

        internal void InitializeReader()
        {
            oControlElement = GetDocumentElement(mp_sObject, 0);
            mp_yLevel = PE_LEVEL.LVL_CONTROL;
        }

        private XElement ParentElement()
        {
            switch (mp_yLevel)
            {
                case PE_LEVEL.LVL_CONTROL:
                    return oControlElement;
                case PE_LEVEL.LVL_FONT:
                    return oFontElement;
                case PE_LEVEL.LVL_DATETIME:
                    return oDateTimeElement;
            }
            return null;
        }

        private XElement mp_oCreateEmptyDOMElement(string sElementName)
        {
            XElement oNodeBuff = null;
            oNodeBuff = new XElement(sElementName);
            ParentElement().Add(oNodeBuff);
            return oNodeBuff;
        }

        private XElement GetDocumentElement(string TagName, int lIndex)
        {
            return xDoc.Elements(TagName).ElementAtOrDefault(lIndex);
        }

        internal string GetXML()
        {
            return xDoc.ToString();
        }

        internal void SetXML(string sXML)
        {
            if (mp_bSupportOptional == false)
            {
                xDoc = XDocument.Parse(sXML);
            }
            else
            {
                if (sXML.Length > 0)
                {
                    xDoc = XDocument.Parse(sXML);
                }
            }
        }

        #region "Collections"

        internal string ReadCollectionObject(int lIndex)
        {
            if (mp_bSupportOptional == false)
            {
                return ParentElement().Elements().ElementAtOrDefault(lIndex - 1).ToString();
            }
            else
            {
                if (ParentElement() == null | lIndex == 0)
                {
                    return "";
                }
                if (ParentElement().Elements().Count() > 0)
                {
                    return ParentElement().Elements().ElementAtOrDefault(lIndex - 1).ToString();
                }
                else
                {
                    return "";
                }
            }
        }

        internal string GetCollectionObjectName(int lIndex)
        {
            string sReturn = "";
            if (ParentElement().Elements().ElementAtOrDefault(lIndex - 1).NodeType == XmlNodeType.Element)
            {
                XElement oElement = (XElement)ParentElement().Elements().ElementAtOrDefault(lIndex - 1);
                sReturn = oElement.Name.LocalName;
            }
            else
            {
                sReturn = "";
            }
            return sReturn;
        }

        internal int ReadCollectionCount()
        {
            if (mp_bSupportOptional == false)
            {
                return ParentElement().Elements().Count();
            }
            else
            {
                if (ParentElement() == null)
                {
                    return 0;
                }
                else
                {
                    return ParentElement().Elements().Count();
                }
            }
        }

        #endregion

        #region "XML Objects"

        internal string ReadObject(string sObjectName)
        {
            if (mp_bSupportOptional == false)
            {
                return ParentElement().Elements(sObjectName).ElementAtOrDefault(0).ToString();
            }
            else
            {
                if (ParentElement() == null)
                {
                    return "";
                }
                if (ParentElement().Elements(sObjectName).Count() > 0)
                {
                    return ParentElement().Elements(sObjectName).ElementAtOrDefault(0).ToString();
                }
                else
                {
                    return "";
                }
            }
        }

        internal void WriteObject(string sObjectText)
        {
            XDocument xDoc1 = null;
            XElement oNodeBuff = null;
            xDoc1 = new XDocument();
            xDoc1 = XDocument.Parse(sObjectText);
            oNodeBuff = new XElement(xDoc1.Elements().ElementAtOrDefault(0));
            ParentElement().Add(oNodeBuff);
        }

        #endregion

        #region "Enumerations"

        internal void ReadProperty(string sElementName, ref E_BORDERSTYLE sElementValue)
        {
            sElementValue = (E_BORDERSTYLE)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref E_TEXTPLACEMENT sElementValue)
        {
            sElementValue = (E_TEXTPLACEMENT)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref E_PLACEMENT sElementValue)
        {
            sElementValue = (E_PLACEMENT)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref E_REPORTERRORS sElementValue)
        {
            sElementValue = (E_REPORTERRORS)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref E_SCROLLBEHAVIOUR sElementValue)
        {
            sElementValue = (E_SCROLLBEHAVIOUR)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref E_STYLEAPPEARANCE sElementValue)
        {
            sElementValue = (E_STYLEAPPEARANCE)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref GRE_BORDERSTYLE sElementValue)
        {
            sElementValue = (GRE_BORDERSTYLE)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref GRE_PATTERN sElementValue)
        {
            sElementValue = (GRE_PATTERN)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref GRE_BUTTONSTYLE sElementValue)
        {
            sElementValue = (GRE_BUTTONSTYLE)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref GRE_FIGURETYPE sElementValue)
        {
            sElementValue = (GRE_FIGURETYPE)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref GRE_GRADIENTFILLMODE sElementValue)
        {
            sElementValue = (GRE_GRADIENTFILLMODE)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref GRE_HORIZONTALALIGNMENT sElementValue)
        {
            sElementValue = (GRE_HORIZONTALALIGNMENT)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref GRE_LINEDRAWSTYLE sElementValue)
        {
            sElementValue = (GRE_LINEDRAWSTYLE)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref GRE_VERTICALALIGNMENT sElementValue)
        {
            sElementValue = (GRE_VERTICALALIGNMENT)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref E_ADDMODE sElementValue)
        {
            sElementValue = (E_ADDMODE)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref E_LAYEROBJECTENABLE sElementValue)
        {
            sElementValue = (E_LAYEROBJECTENABLE)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref E_TIMEBLOCKBEHAVIOUR sElementValue)
        {
            sElementValue = (E_TIMEBLOCKBEHAVIOUR)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref E_MOVEMENTTYPE sElementValue)
        {
            sElementValue = (E_MOVEMENTTYPE)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref E_CONSTRAINTTYPE sElementValue)
        {
            sElementValue = (E_CONSTRAINTTYPE)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref E_PROGRESSLINELENGTH sElementValue)
        {
            sElementValue = (E_PROGRESSLINELENGTH)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref E_PROGRESSLINETYPE sElementValue)
        {
            sElementValue = (E_PROGRESSLINETYPE)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref E_TICKMARKTYPES sElementValue)
        {
            sElementValue = (E_TICKMARKTYPES)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref E_TIERPOSITION sElementValue)
        {
            sElementValue = (E_TIERPOSITION)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref E_TIERTYPE sElementValue)
        {
            sElementValue = (E_TIERTYPE)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref E_CONTROLMODE sElementValue)
        {
            sElementValue = (E_CONTROLMODE)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref GRE_BACKGROUNDMODE sElementValue)
        {
            sElementValue = (GRE_BACKGROUNDMODE)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref GRE_HATCHSTYLE sElementValue)
        {
            sElementValue = (GRE_HATCHSTYLE)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref GRE_FILLMODE sElementValue)
        {
            sElementValue = (GRE_FILLMODE)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref E_WEEKDAY sElementValue)
        {
            sElementValue = (E_WEEKDAY)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref E_TIMEBLOCKTYPE sElementValue)
        {
            sElementValue = (E_TIMEBLOCKTYPE)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref E_RECURRINGTYPE sElementValue)
        {
            sElementValue = (E_RECURRINGTYPE)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref E_INTERVAL sElementValue)
        {
            sElementValue = (E_INTERVAL)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref E_SPLITTERTYPE sElementValue)
        {
            sElementValue = (E_SPLITTERTYPE)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref E_TIERBACKGROUNDMODE sElementValue)
        {
            sElementValue = (E_TIERBACKGROUNDMODE)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref E_TIERAPPEARANCESCOPE sElementValue)
        {
            sElementValue = (E_TIERAPPEARANCESCOPE)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref E_TIERFORMATSCOPE sElementValue)
        {
            sElementValue = (E_TIERFORMATSCOPE)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref E_SELECTIONRECTANGLEMODE sElementValue)
        {
            sElementValue = (E_SELECTIONRECTANGLEMODE)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref E_PREDECESSORMODE sElementValue)
        {
            sElementValue = (E_PREDECESSORMODE)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref E_TASKTYPE sElementValue)
        {
            sElementValue = (E_TASKTYPE)yReadProperty(sElementName, (int)sElementValue);
        }

        internal void ReadProperty(string sElementName, ref E_TBINTERVALTYPE sElementValue)
        {
            sElementValue = (E_TBINTERVALTYPE)yReadProperty(sElementName, (int)sElementValue);
        }

        public void WriteProperty(string sElementName, object sElementValue)
        {
            XElement oNodeBuff = null;
            oNodeBuff = new XElement(sElementName);
            oNodeBuff.Value = System.Convert.ToString(System.Convert.ToInt32(sElementValue));
            ParentElement().Add(oNodeBuff);
        }

        #endregion

        #region "Boolean"
        internal void ReadProperty(string sElementName, ref bool bElementValue)
        {
            if (mp_bSupportOptional == false)
            {
                if (ParentElement().Elements(sElementName).ElementAtOrDefault(0).Value == "false" | ParentElement().Elements(sElementName).ElementAtOrDefault(0).Value == "0")
                {
                    bElementValue = false;
                }
                else
                {
                    bElementValue = true;
                }
            }
            else
            {
                if (ParentElement() == null)
                {
                    return;
                }
                if (ParentElement().Elements(sElementName).Count() > 0)
                {
                    if (ParentElement().Elements(sElementName).ElementAtOrDefault(0).Parent.Name == ParentElement().Name)
                    {
                        if (ParentElement().Elements(sElementName).ElementAtOrDefault(0).Value == "false" | ParentElement().Elements(sElementName).ElementAtOrDefault(0).Value == "0")
                        {
                            bElementValue = false;
                        }
                        else
                        {
                            bElementValue = true;
                        }
                    }
                }
            }
        }

        internal void WriteProperty(string sElementName, bool bElementValue)
        {
            XElement oNodeBuff = null;
            oNodeBuff = new XElement(sElementName);
            if (bElementValue == true)
            {
                if (mp_bBoolsAreNumeric == false)
                {
                    oNodeBuff.Value = "true";
                }
                else
                {
                    oNodeBuff.Value = "1";
                }
            }
            else
            {
                if (mp_bBoolsAreNumeric == false)
                {
                    oNodeBuff.Value = "false";
                }
                else
                {
                    oNodeBuff.Value = "0";
                }
            }
            ParentElement().Add(oNodeBuff);
        }
        #endregion

        #region "Byte"

        internal void ReadProperty(string sElementName, ref byte sElementValue)
        {
            sElementValue = System.Convert.ToByte(yReadProperty(sElementName, sElementValue));
        }

        public void WriteProperty(string sElementName, byte sElementValue)
        {
            XElement oNodeBuff = null;
            oNodeBuff = new XElement(sElementName);
            oNodeBuff.Value = System.Convert.ToString(sElementValue);
            ParentElement().Add(oNodeBuff);
        }

        #endregion

        #region "Int32"

        internal void ReadProperty(string sElementName, ref int sElementValue)
        {
            sElementValue = yReadProperty(sElementName, sElementValue);
        }

        private int yReadProperty(string v_sNodeName, int sElementValue)
        {
            if (mp_bSupportOptional == false)
            {
                return System.Convert.ToInt32(ParentElement().Elements(v_sNodeName).ElementAtOrDefault(0).Value);
            }
            else
            {
                if (ParentElement() == null)
                {
                    return sElementValue;
                }
                if (ParentElement().Elements(v_sNodeName).Count() > 0)
                {
                    return System.Convert.ToInt32(ParentElement().Elements(v_sNodeName).ElementAtOrDefault(0).Value);
                }
                else
                {
                    return sElementValue;
                }
            }
        }

        public void WriteProperty(string sElementName, int sElementValue)
        {
            XElement oNodeBuff = null;
            oNodeBuff = new XElement(sElementName);
            oNodeBuff.Value = System.Convert.ToString(sElementValue);
            ParentElement().Add(oNodeBuff);
        }

        #endregion

        #region "Int16"

        internal void ReadProperty(string sElementName, ref short iElementValue)
        {
            if (mp_bSupportOptional == false)
            {
                iElementValue = System.Convert.ToInt16(ParentElement().Elements(sElementName).ElementAtOrDefault(0).Value);
            }
            else
            {
                if (ParentElement() == null)
                {
                    return;
                }
                if (ParentElement().Elements(sElementName).Count() > 0)
                {
                    iElementValue = System.Convert.ToInt16(ParentElement().Elements(sElementName).ElementAtOrDefault(0).Value);
                }
            }
        }

        public void WriteProperty(string sElementName, short sElementValue)
        {
            XElement oNodeBuff = null;
            oNodeBuff = new XElement(sElementName);
            oNodeBuff.Value = System.Convert.ToString(sElementValue);
            ParentElement().Add(oNodeBuff);
        }

        #endregion

        #region "Single"

        internal void ReadProperty(string sElementName, ref float fElementValue)
        {
            if (mp_bSupportOptional == false)
            {
                fElementValue = System.Convert.ToSingle(ParentElement().Elements(sElementName).ElementAtOrDefault(0).Value);
            }
            else
            {
                if (ParentElement() == null)
                {
                    return;
                }
                if (ParentElement().Elements(sElementName).Count() > 0)
                {
                    fElementValue = System.Convert.ToSingle(ParentElement().Elements(sElementName).ElementAtOrDefault(0).Value);
                }
            }
        }

        public void WriteProperty(string sElementName, float sElementValue)
        {
            XElement oNodeBuff = null;
            oNodeBuff = new XElement(sElementName);
            oNodeBuff.Value = System.Convert.ToString(sElementValue);
            ParentElement().Add(oNodeBuff);
        }

        #endregion

        #region "String"

        internal void ReadProperty(string sElementName, ref string sElementValue)
        {
            if (mp_bSupportOptional == false)
            {
                sElementValue = ParentElement().Elements(sElementName).ElementAtOrDefault(0).Value;
            }
            else
            {
                if (ParentElement() == null)
                {
                    return;
                }
                if (ParentElement().Elements(sElementName).Count() > 0)
                {
                    if (ParentElement().Elements(sElementName).ElementAtOrDefault(0).Parent.Name == ParentElement().Name)
                    {
                        sElementValue = ParentElement().Elements(sElementName).ElementAtOrDefault(0).Value;
                    }
                }
            }
        }

        public void WriteProperty(string sElementName, string sElementValue)
        {
            XElement oNodeBuff = null;
            oNodeBuff = new XElement(sElementName);
            oNodeBuff.Value = sElementValue;
            ParentElement().Add(oNodeBuff);
        }

        #endregion

        #region "System.Windows.Media.Color"

        public void ReadProperty(string sElementName, ref System.Windows.Media.Color sElementValue)
        {
            long lResult = 0;
            if (mp_bSupportOptional == false)
            {
                lResult = Convert.ToInt32(ParentElement().Elements(sElementName).ElementAtOrDefault(0).Value);
            }
            else
            {
                if (ParentElement() == null)
                {
                    return;
                }
                if (ParentElement().Elements(sElementName).Count() > 0)
                {
                    lResult = Convert.ToInt32(ParentElement().Elements(sElementName).ElementAtOrDefault(0).Value);
                }
            }
            byte lR = 0;
            byte lG = 0;
            byte lB = 0;
            lB = System.Convert.ToByte(System.Math.Floor(lResult / 65536));
            lResult = lResult - (lB * 65536);
            lG = System.Convert.ToByte(System.Math.Floor(lResult / 256));
            lResult = lResult - (lG * 256);
            lR = System.Convert.ToByte(lResult);
            sElementValue = System.Windows.Media.Color.FromArgb(255, lR, lG, lB);
        }

        public void WriteProperty(string sElementName, System.Windows.Media.Color sElementValue)
        {
            XElement oNodeBuff = null;
            oNodeBuff = new XElement(sElementName);
            long lResult = (sElementValue.B * 65536) + (sElementValue.G * 256) + sElementValue.R;
            oNodeBuff.Value = lResult.ToString();
            ParentElement().Add(oNodeBuff);
        }

        #endregion

        #region "Font"

        public void ReadProperty(string sElementName, ref AGCSE.Font v_oFont)
        {
            PE_LEVEL mp_yBackupLevel = default(PE_LEVEL);
            string sName = "";
            float fSize = 0;
            bool bDummy = false;
            oFontElement = ParentElement().Elements(sElementName).ElementAtOrDefault(0);
            mp_yBackupLevel = mp_yLevel;
            mp_yLevel = PE_LEVEL.LVL_FONT;
            ReadProperty("Name", ref sName);
            ReadProperty("Size", ref fSize);
            if (sName == "MS Sans Serif")
            {
                sName = "Microsoft Sans Serif";
            }
            AGCSE.Font oFont = new Font(sName, fSize, E_FONTSIZEUNITS.FSU_POINTS);
            ReadProperty("Bold", ref bDummy);
            if (bDummy == true)
            {
                oFont.FontWeight = FontWeights.Bold;
            }
            ReadProperty("Italic", ref bDummy);
            if (bDummy == true)
            {
                oFont.FontStyle = FontStyles.Italic;
            }
            ReadProperty("Underline", ref bDummy);
            oFont.Underline = bDummy;
            mp_yLevel = mp_yBackupLevel;
            v_oFont = oFont;
        }

        public void WriteProperty(string sElementName, AGCSE.Font oFont)
        {
            PE_LEVEL mp_yBackupLevel = default(PE_LEVEL);
            oFontElement = mp_oCreateEmptyDOMElement(sElementName);
            mp_yBackupLevel = mp_yLevel;
            mp_yLevel = PE_LEVEL.LVL_FONT;
            WriteProperty("Name", oFont.Name);
            WriteProperty("Size", oFont.GetSize(E_FONTSIZEUNITS.FSU_POINTS));
            WriteProperty("Bold", oFont.Bold);
            WriteProperty("Italic", oFont.Italic);
            WriteProperty("Underline", oFont.Underline);
            mp_yLevel = mp_yBackupLevel;
        }

        #endregion

        #region "Image"

        public void ReadProperty(string sElementName, ref Image oImage)
        {
            if (!string.IsNullOrEmpty(ParentElement().Elements(sElementName).ElementAtOrDefault(0).Value))
            {
                string data = ParentElement().Elements(sElementName).ElementAtOrDefault(0).Value;
                byte[] aImageBytes = System.Convert.FromBase64String(data);
                MemoryStream oMemoryStream = new MemoryStream(aImageBytes, 0, aImageBytes.Length);
                BitmapImage oBitmapImage = new BitmapImage();
                oBitmapImage.SetSource(oMemoryStream);
                if ((oBitmapImage != null))
                {
                    oImage = new Image();
                    oImage.Width = oBitmapImage.PixelWidth;
                    oImage.Height = oBitmapImage.PixelHeight;
                    oImage.Source = oBitmapImage;
                    if (oImage.ActualWidth == 0 & oImage.ActualHeight == 0)
                    {
                        oImage = null;
                    }
                    oMemoryStream.Close();
                }
                else
                {
                    oImage = null;
                }
            }
        }

        public void WriteProperty(string sElementName, Image oImage)
        {
            XElement oNodeBuff = null;
            if ((oImage != null))
            {
                System.Windows.Media.Imaging.WriteableBitmap oWBitmap = new System.Windows.Media.Imaging.WriteableBitmap(oImage, null);
                PngEncoder oEncoder1 = new PngEncoder(oWBitmap.Pixels, System.Convert.ToInt32(oImage.ActualWidth), System.Convert.ToInt32(oImage.ActualHeight), true, 0, 0);
                byte[] aEncodedArray = oEncoder1.Encode(true);
                
                if (aEncodedArray != null)
                {
                    string sObjectText = null;
                    string sEncodedData = null;
                    XDocument xDoc1 = null;
                    System.IO.MemoryStream oMemoryStream;
                    xDoc1 = new XDocument();
                    sObjectText = "<" + sElementName + " xmlns:dt=\"urn:schemas-microsoft-com:datatypes\" dt:dt=\"bin.base64\"></" + sElementName + ">";
                    xDoc1 = XDocument.Parse(sObjectText);
                    oNodeBuff = new XElement(xDoc1.Elements().ElementAtOrDefault(0));
                    oMemoryStream = new System.IO.MemoryStream(aEncodedArray);
                    sEncodedData = Convert.ToBase64String(oMemoryStream.ToArray());
                    oNodeBuff.Value = sEncodedData;
                }
                else
                {
                    oNodeBuff = new XElement(sElementName);
                }
                
            }
            else
            {
                oNodeBuff = new XElement(sElementName);
            }
            ParentElement().Add(oNodeBuff);
        }

        #endregion

        #region "System.DateTime"

        private void ReadProperty(string sElementName, ref System.DateTime dtElementValue)
        {
            if (mp_bSupportOptional == false)
            {
                dtElementValue = mp_dtGetDateFromXML(ParentElement().Elements(sElementName).ElementAtOrDefault(0).Value);
            }
            else
            {
                if (ParentElement() == null)
                {
                    return;
                }
                if (ParentElement().Elements(sElementName).Count() > 0)
                {
                    dtElementValue = mp_dtGetDateFromXML(ParentElement().Elements(sElementName).ElementAtOrDefault(0).Value);
                }
            }
        }

        private System.DateTime mp_dtGetDateFromXML(string sParam)
        {
            System.DateTime dtReturn = default(System.DateTime);
            int lYear = System.Convert.ToInt32(sParam.Substring(0, 4));
            int lMonth = System.Convert.ToInt32(sParam.Substring(5, 2));
            int lDay = System.Convert.ToInt32(sParam.Substring(8, 2));
            int lHours = System.Convert.ToInt32(sParam.Substring(11, 2));
            int lMinutes = System.Convert.ToInt32(sParam.Substring(14, 2));
            int lSeconds = System.Convert.ToInt32(sParam.Substring(17, 2));
            dtReturn = new System.DateTime(lYear, lMonth, lDay, lHours, lMinutes, lSeconds);
            return dtReturn;
        }

        private void WriteProperty(string sElementName, System.DateTime dtElementValue)
        {
            XElement oNodeBuff = null;
            oNodeBuff = new XElement(sElementName);
            oNodeBuff.Value = mp_sGetXMLDateString(dtElementValue);
            ParentElement().Add(oNodeBuff);
        }

        private string mp_sGetXMLDateString(System.DateTime dtParam)
        {
            return dtParam.Year.ToString("0000") + "-" + dtParam.Month.ToString("00") + "-" + dtParam.Day.ToString("00") + "T" + dtParam.Hour.ToString("00") + ":" + dtParam.Minute.ToString("00") + ":" + dtParam.Second.ToString("00");
        }

        #endregion

        #region "AGCSE.DateTime"

        internal void ReadProperty(string sElementName, ref AGCSE.DateTime oDate)
        {
            PE_LEVEL mp_yBackupLevel = default(PE_LEVEL);
            oDateTimeElement = ParentElement().Elements(sElementName).ElementAtOrDefault(0);
            mp_yBackupLevel = mp_yLevel;
            mp_yLevel = PE_LEVEL.LVL_DATETIME;
            System.DateTime dtDateTime = new System.DateTime(0);
            int lSecondFraction = 0;
            ReadProperty("DateTime", ref dtDateTime);
            ReadProperty("SecondFraction", ref lSecondFraction);
            oDate.DateTimePart = dtDateTime;
            oDate.SecondFractionPart = lSecondFraction;
            mp_yLevel = mp_yBackupLevel;
        }

        internal void WriteProperty(string sElementName, AGCSE.DateTime oDate)
        {
            PE_LEVEL mp_yBackupLevel = default(PE_LEVEL);
            mp_yBackupLevel = mp_yLevel;
            oDateTimeElement = mp_oCreateEmptyDOMElement(sElementName);
            mp_yLevel = PE_LEVEL.LVL_DATETIME;
            WriteProperty("DateTime", oDate.DateTimePart);
            WriteProperty("SecondFraction", oDate.SecondFractionPart);
            mp_yLevel = mp_yBackupLevel;
        }


        #endregion

    }




}
