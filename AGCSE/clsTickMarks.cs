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
	public class clsTickMarks
	{
		private ActiveGanttCSECtl mp_oControl;
		private clsCollectionBase mp_oCollection;

		public clsTickMarks(ActiveGanttCSECtl Value)
		{
			mp_oControl = Value;
			mp_oCollection = new clsCollectionBase(Value, "TickMark");
		}

		~clsTickMarks()
		{	
		}

		public int Count 
		{
			get 
			{
				return mp_oCollection.m_lCount();
			}
		}

		public clsTickMark Item(String Index)
		{
			return (clsTickMark) mp_oCollection.m_oItem(Index, SYS_ERRORS.TICKMARKS_ITEM_1, SYS_ERRORS.TICKMARKS_ITEM_2, SYS_ERRORS.TICKMARKS_ITEM_3, SYS_ERRORS.TICKMARKS_ITEM_4);
		}

		internal clsCollectionBase oCollection 
		{
			get 
			{
				return mp_oCollection;
			}
		}

        public clsTickMark Add(E_INTERVAL Interval, int Factor, E_TICKMARKTYPES TickMarkType)
        {
            return Add(Interval, Factor, TickMarkType, false, "", "");
        }

        public clsTickMark Add(E_INTERVAL Interval, int Factor, E_TICKMARKTYPES TickMarkType, bool DisplayText, string TextFormat)
        {
            return Add(Interval, Factor, TickMarkType, DisplayText, TextFormat, "");
        }

        public clsTickMark Add(E_INTERVAL Interval, int Factor, E_TICKMARKTYPES TickMarkType, bool DisplayText, String TextFormat, String Key)
        {
            mp_oCollection.AddMode = true;
            clsTickMark oTickMark = new clsTickMark(mp_oControl, this);
            oTickMark.Interval = Interval;
            oTickMark.Factor = Factor;
            oTickMark.TickMarkType = TickMarkType;
            oTickMark.DisplayText = DisplayText;
            oTickMark.TextFormat = TextFormat;
            oTickMark.Key = Key;
            mp_oCollection.m_Add(oTickMark, Key, SYS_ERRORS.TICKMARKS_ADD_1, SYS_ERRORS.TICKMARKS_ADD_2, false, SYS_ERRORS.TICKMARKS_ADD_3);
            return oTickMark;
        }

		public void Clear()
		{
			mp_oCollection.m_Clear();
		}

		public void Remove(String Index)
		{
			mp_oCollection.m_Remove(Index, SYS_ERRORS.TICKMARKS_REMOVE_1, SYS_ERRORS.TICKMARKS_REMOVE_2, SYS_ERRORS.TICKMARKS_REMOVE_3, SYS_ERRORS.TICKMARKS_REMOVE_4);
		}

        public String GetXML()
        {
            int lIndex;
            clsTickMark oTickMark;
            clsXML oXML = new clsXML(mp_oControl, "TickMarks");
            oXML.InitializeWriter();
            for (lIndex = 1; lIndex <= Count; lIndex++)
            {
                oTickMark = (clsTickMark)mp_oCollection.m_oReturnArrayElement(lIndex);
                oXML.WriteObject(oTickMark.GetXML());
            }
            return oXML.GetXML();
        }

        public void SetXML(String sXML)
        {
            int lIndex;
            clsXML oXML = new clsXML(mp_oControl, "TickMarks");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            mp_oCollection.m_Clear();
            for (lIndex = 1; lIndex <= oXML.ReadCollectionCount(); lIndex++)
            {
                clsTickMark oTickMark = new clsTickMark(mp_oControl, this);
                oTickMark.SetXML(oXML.ReadCollectionObject(lIndex));
                mp_oCollection.AddMode = true;
                mp_oCollection.m_Add(oTickMark, oTickMark.Key, SYS_ERRORS.TICKMARKS_ADD_1, SYS_ERRORS.TICKMARKS_ADD_2, false, SYS_ERRORS.TICKMARKS_ADD_3);
                oTickMark = null;
            }
        }


	}
}
