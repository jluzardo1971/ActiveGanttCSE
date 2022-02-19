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

namespace MSP2007
{

    internal partial class clsXML
    {

        private XDocument xDoc;
        private XElement oControlElement;
        private string mp_sObject;
        private PE_LEVEL mp_yLevel;
        private bool mp_bSupportOptional = false;
        private bool mp_bBoolsAreNumeric = false;

        private enum PE_LEVEL
        {
            LVL_CONTROL = 0
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

        internal clsXML(string sObject)
        {
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

        internal int yReadProperty(string v_sNodeName, int sElementValue)
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

        internal void WriteProperty(string sElementName, string sElementValue)
        {
            XElement oNodeBuff = null;
            oNodeBuff = new XElement(sElementName);
            oNodeBuff.Value = sElementValue;
            ParentElement().Add(oNodeBuff);
        }

        #endregion

        #region "System.DateTime"

        internal void ReadProperty(string sElementName, ref System.DateTime dtElementValue)
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

        internal void WriteProperty(string sElementName, System.DateTime dtElementValue)
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


        //// Microsoft Project Integration

        #region "Attributes"

        internal void AddAttribute(string sName, string sValue)
        {
            XAttribute oAttribute = new XAttribute(sName, sValue);
            GetDocumentElement("Project", 0).Add(oAttribute);
        }

        #endregion

        #region "Time"

        internal void ReadProperty(string sElementName, ref Time sElementValue)
        {
            if (mp_bSupportOptional == false)
            {
                sElementValue.FromString(ParentElement().Elements(sElementName).ElementAtOrDefault(0).Value);
            }
            else
            {
                if (ParentElement() == null)
                {
                    return;
                }
                if (ParentElement().Elements(sElementName).Count() > 0)
                {
                    sElementValue.FromString(ParentElement().Elements(sElementName).ElementAtOrDefault(0).Value);
                }
            }
        }

        internal void WriteProperty(string sElementName, Time sElementValue)
        {
            XElement oNodeBuff = null;
            oNodeBuff = new XElement(sElementName);
            oNodeBuff.Value = sElementValue.ToString();
            ParentElement().Add(oNodeBuff);
        }

        #endregion

        #region "Duration"

        internal void ReadProperty(string sElementName, ref Duration sElementValue)
        {
            if (mp_bSupportOptional == false)
            {
                sElementValue.FromString(ParentElement().Elements(sElementName).ElementAtOrDefault(0).Value);
            }
            else
            {
                if (ParentElement() == null)
                {
                    return;
                }
                if (ParentElement().Elements(sElementName).Count() > 0)
                {
                    sElementValue.FromString(ParentElement().Elements(sElementName).ElementAtOrDefault(0).Value);
                }
            }
        }

        internal void WriteProperty(string sElementName, Duration sElementValue)
        {
            XElement oNodeBuff = null;
            oNodeBuff = new XElement(sElementName);
            oNodeBuff.Value = sElementValue.ToString();
            ParentElement().Add(oNodeBuff);
        }

        #endregion

        #region "Decimal"

        internal void ReadProperty(string sElementName, ref decimal sElementValue)
        {
            if (mp_bSupportOptional == false)
            {
                sElementValue = System.Convert.ToDecimal(ParentElement().Elements(sElementName).ElementAtOrDefault(0).Value);
            }
            else
            {
                if (ParentElement() == null)
                {
                    return;
                }
                if (ParentElement().Elements(sElementName).Count() > 0)
                {
                    sElementValue = System.Convert.ToDecimal(ParentElement().Elements(sElementName).ElementAtOrDefault(0).Value);
                }
            }
        }

        internal void WriteProperty(string sElementName, decimal sElementValue)
        {
            XElement oNodeBuff = null;
            oNodeBuff = new XElement(sElementName);
            oNodeBuff.Value = sElementValue.ToString();
            ParentElement().Add(oNodeBuff);
        }

        #endregion

    }

}