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
	public class clsPercentages
	{
		private ActiveGanttCSECtl mp_oControl;
		private clsCollectionBase mp_oCollection;

		public clsPercentages(ActiveGanttCSECtl Value)
		{
			mp_oControl = Value;
			mp_oCollection = new clsCollectionBase(Value, "Percentage");			
		}

		~clsPercentages()
		{
		}

		public int Count 
		{
			get 
			{
				return mp_oCollection.m_lCount();
			}
		}

		public clsPercentage Item(String Index)
		{
			return (clsPercentage) mp_oCollection.m_oItem(Index, SYS_ERRORS.PERCENTAGES_ITEM_1, SYS_ERRORS.PERCENTAGES_ITEM_2, SYS_ERRORS.PERCENTAGES_ITEM_3, SYS_ERRORS.PERCENTAGES_ITEM_4);
		}

		internal clsCollectionBase oCollection 
		{
			get 
			{
				return mp_oCollection;
			}
		}

		public clsPercentage Add(String TaskKey, String StyleIndex, float Percent, String Key)
		{
			mp_oCollection.AddMode = true;
			clsPercentage oPercentage = new clsPercentage(mp_oControl);
            Key = mp_oControl.StrLib.StrTrim(Key);
            TaskKey = mp_oControl.StrLib.StrTrim(TaskKey);
            oPercentage.Key = Key;
			oPercentage.TaskKey = TaskKey;
			oPercentage.Percent = Percent;
			oPercentage.StyleIndex = StyleIndex;
			mp_oCollection.m_Add(oPercentage, Key, SYS_ERRORS.PERCENTAGES_ADD_1, SYS_ERRORS.PERCENTAGES_ADD_2, false, SYS_ERRORS.PERCENTAGES_ADD_3);
			return oPercentage;
		}

		public void Clear()
		{
			mp_oCollection.m_Clear();
		}

		public void Remove(String Index)
		{
			mp_oCollection.m_Remove(Index, SYS_ERRORS.PERCENTAGES_REMOVE_1, SYS_ERRORS.PERCENTAGES_REMOVE_2, SYS_ERRORS.PERCENTAGES_REMOVE_3, SYS_ERRORS.PERCENTAGES_REMOVE_4);
		}

		internal void Draw()
		{
			int lIndex;
			clsPercentage oPercentage;
			clsTask oTask;
			clsRow oRow;
			clsStyle oStyle;
			bool bDraw;
			if (Count == 0)
			{
				return;
			}
			if (Count == 0)
			{
				return;
			}
			for (lIndex = 1;lIndex <= Count;lIndex++) 
			{
				oPercentage = (clsPercentage) mp_oCollection.m_oReturnArrayElement(lIndex);
				if (oPercentage.Visible == true)
				{
					mp_oControl.clsG.ClipRegion(oPercentage.LeftTrim, oPercentage.Top, oPercentage.RightTrim, oPercentage.Bottom, true);
					oTask = (clsTask) mp_oControl.Tasks.oCollection.m_oReturnArrayElementKey(oPercentage.TaskKey);
					oRow = (clsRow) mp_oControl.Rows.oCollection.m_oReturnArrayElementKey(oTask.RowKey);
					oStyle = mp_oControl.Styles.FItem(oPercentage.StyleIndex);
					bDraw = false;
					//*mp_oControl.FireDraw(E_EVENTTARGET.EVT_PERCENTAGE, ref bDraw, lIndex, 0, mp_oControl.clsG.oGraphics);
					if (bDraw == false)
					{
                        mp_oControl.clsG.mp_DrawItem(oPercentage.Left, oPercentage.Top, oPercentage.Right, oPercentage.Bottom, oPercentage.StyleIndex, mp_oControl.StrLib.StrFormat(oPercentage.Percent, oPercentage.Format), false, null, oPercentage.LeftTrim, oPercentage.RightTrim, null);
					}
				}
			}
		}

        public String GetXML()
        {
            int lIndex;
            clsPercentage oPercentage;
            clsXML oXML = new clsXML(mp_oControl, "Percentages");
            oXML.InitializeWriter();
            for (lIndex = 1; lIndex <= Count; lIndex++)
            {
                oPercentage = (clsPercentage)mp_oCollection.m_oReturnArrayElement(lIndex);
                oXML.WriteObject(oPercentage.GetXML());
            }
            return oXML.GetXML();
        }

        public void SetXML(String sXML)
        {
            int lIndex;
            clsXML oXML = new clsXML(mp_oControl, "Percentages");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            mp_oCollection.m_Clear();
            for (lIndex = 1; lIndex <= oXML.ReadCollectionCount(); lIndex++)
            {
                clsPercentage oPercentage = new clsPercentage(mp_oControl);
                oPercentage.SetXML(oXML.ReadCollectionObject(lIndex));
                mp_oCollection.AddMode = true;
                mp_oCollection.m_Add(oPercentage, oPercentage.Key, SYS_ERRORS.PERCENTAGES_ADD_1, SYS_ERRORS.PERCENTAGES_ADD_2, false, SYS_ERRORS.PERCENTAGES_ADD_3);
                oPercentage = null;
            }
        }


	}
}
