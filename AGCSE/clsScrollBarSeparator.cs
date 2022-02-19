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
    public class clsScrollBarSeparator
    {

        private ActiveGanttCSECtl mp_oControl;
        private string mp_sStyleIndex;
        private clsStyle mp_oStyle;

        internal clsScrollBarSeparator(ActiveGanttCSECtl Value)
        {
            mp_oControl = Value;
            mp_sStyleIndex = "DS_SB_SEPARATOR";
            mp_oStyle = mp_oControl.Styles.FItem("DS_SB_SEPARATOR");
        }

        public string StyleIndex
        {
            get
            {
                if (mp_sStyleIndex == "DS_SB_SEPARATOR")
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
                    value = "DS_SB_SEPARATOR";
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
            clsXML oXML = new clsXML(mp_oControl, "ScrollBarSeparator");
            oXML.InitializeWriter();
            oXML.WriteProperty("StyleIndex", mp_sStyleIndex);
            return oXML.GetXML();
        }

        public void SetXML(string sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "ScrollBarSeparator");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            oXML.ReadProperty("StyleIndex", ref mp_sStyleIndex);
            StyleIndex = mp_sStyleIndex;
        }

    }
}
