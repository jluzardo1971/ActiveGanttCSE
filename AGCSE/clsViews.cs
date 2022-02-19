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
	public class clsViews
	{
		private ActiveGanttCSECtl mp_oControl;
		private clsCollectionBase mp_oCollection;
		private clsView mp_oDefaultView;
        
		public clsViews(ActiveGanttCSECtl Value)
		{
            mp_oControl = Value;
            mp_oCollection = new clsCollectionBase(Value, "View");
            mp_oDefaultView = new clsView(mp_oControl);
            mp_oDefaultView.Interval = E_INTERVAL.IL_MINUTE;
            mp_oDefaultView.Factor = 1;
            mp_oDefaultView.TimeLine.TierArea.UpperTier.TierType = E_TIERTYPE.ST_MONTH;
            mp_oDefaultView.TimeLine.TierArea.MiddleTier.Visible = false;
            mp_oDefaultView.TimeLine.TierArea.LowerTier.TierType = E_TIERTYPE.ST_DAYOFWEEK;
            mp_oDefaultView.ClientArea.ToolTipFormat = "hh:mmtt";
            mp_oDefaultView.TimeLine.TickMarkArea.TickMarks.Add(E_INTERVAL.IL_HOUR, 1, E_TICKMARKTYPES.TLT_BIG, true, "hh:mmtt");
            mp_oDefaultView.TimeLine.TickMarkArea.TickMarks.Add(E_INTERVAL.IL_MINUTE, 30, E_TICKMARKTYPES.TLT_BIG);
            mp_oDefaultView.TimeLine.TickMarkArea.TickMarks.Add(E_INTERVAL.IL_MINUTE, 15, E_TICKMARKTYPES.TLT_MEDIUM);
            mp_oDefaultView.TimeLine.TickMarkArea.TickMarks.Add(E_INTERVAL.IL_MINUTE, 5, E_TICKMARKTYPES.TLT_SMALL);
            mp_oDefaultView.TimeLine.TickMarkArea.Height = 30;
		}

		~clsViews()
		{	
		}

		public int Count 
		{
			get 
			{
				return mp_oCollection.m_lCount();
			}
		}

		public clsView Item(String Index) 
		{
			return (clsView) mp_oCollection.m_oItem(Index, SYS_ERRORS.VIEWS_ITEM_1, SYS_ERRORS.VIEWS_ITEM_2, SYS_ERRORS.VIEWS_ITEM_3, SYS_ERRORS.VIEWS_ITEM_4);
		}

		internal clsView FItem(String Index)
		{
			if (Index == "0")
			{
				return mp_oDefaultView;
			}
			else
			{
				return (clsView) mp_oCollection.m_oItem(Index, SYS_ERRORS.VIEWS_ITEM_1, SYS_ERRORS.VIEWS_ITEM_2, SYS_ERRORS.VIEWS_ITEM_3, SYS_ERRORS.VIEWS_ITEM_4);
			}
		}

		internal clsCollectionBase oCollection 
		{
			get 
			{
				return mp_oCollection;
			}
		}

        public clsView Add(E_INTERVAL Interval, int Factor, E_TIERTYPE UpperTierType, E_TIERTYPE MiddleTierType, E_TIERTYPE LowerTierType, String Key)
        {
            mp_oCollection.AddMode = true;
            clsView oView = new clsView(mp_oControl);
            oView.Interval = Interval;
            oView.Factor = Factor;
            oView.TimeLine.TierArea.UpperTier.TierType = UpperTierType;
            oView.TimeLine.TierArea.MiddleTier.TierType = MiddleTierType;
            oView.TimeLine.TierArea.LowerTier.TierType = LowerTierType;
            oView.Key = Key;
            mp_oCollection.m_Add(oView, Key, SYS_ERRORS.VIEWS_ADD_1, SYS_ERRORS.VIEWS_ADD_2, false, SYS_ERRORS.VIEWS_ADD_3);
            return oView;
        }

		public void Clear()
		{
			mp_oCollection.m_Clear();
			mp_oControl.CurrentView = "";
		}

		public void Remove(String Index)
		{
			mp_oCollection.m_Remove(Index, SYS_ERRORS.VIEWS_REMOVE_1, SYS_ERRORS.VIEWS_REMOVE_2, SYS_ERRORS.VIEWS_REMOVE_3, SYS_ERRORS.VIEWS_REMOVE_4);
			mp_oControl.CurrentView = "";
		}

        public String GetXML()
        {
            int lIndex;
            clsView oView;
            clsXML oXML = new clsXML(mp_oControl, "Views");
            oXML.InitializeWriter();
            for (lIndex = 1; lIndex <= Count; lIndex++)
            {
                oView = (clsView)mp_oCollection.m_oReturnArrayElement(lIndex);
                oXML.WriteObject(oView.GetXML());
            }
            return oXML.GetXML();
        }

        public void SetXML(String sXML)
        {
            int lIndex;
            clsXML oXML = new clsXML(mp_oControl, "Views");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            mp_oCollection.m_Clear();
            for (lIndex = 1; lIndex <= oXML.ReadCollectionCount(); lIndex++)
            {
                clsView oView = new clsView(mp_oControl);
                oView.SetXML(oXML.ReadCollectionObject(lIndex));
                mp_oCollection.AddMode = true;
                mp_oCollection.m_Add(oView, oView.Key, SYS_ERRORS.VIEWS_ADD_1, SYS_ERRORS.VIEWS_ADD_2, false, SYS_ERRORS.VIEWS_ADD_3);
                oView = null;
            }
        }

	}
}
