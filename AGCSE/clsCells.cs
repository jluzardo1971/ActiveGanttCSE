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
	public class clsCells
	{
		private ActiveGanttCSECtl mp_oControl;
		private clsCollectionBase mp_oCollection;
		private clsRow mp_oRow;

		public clsCells(ActiveGanttCSECtl Value, clsRow oRow)
		{
			mp_oControl = Value;
			mp_oCollection = new clsCollectionBase(Value, "Cell");
			mp_oRow = oRow;
		}

		~clsCells()
		{

		}

		public int Count 
		{
			get 
			{
				return mp_oCollection.m_lCount();
			}
		}

		public clsCell Item(String Index)
		{
			return (clsCell) mp_oCollection.m_oItem(Index, SYS_ERRORS.CELLS_ITEM_1, SYS_ERRORS.CELLS_ITEM_2, SYS_ERRORS.CELLS_ITEM_3, SYS_ERRORS.CELLS_ITEM_4);
		}

		internal clsCollectionBase oCollection 
		{
			get 
			{
				return mp_oCollection;
			}
		}

		internal void Add()
		{
			mp_oCollection.AddMode = true;
			clsCell oCell = new clsCell(mp_oControl, this);
			mp_oCollection.m_Add(oCell, "", SYS_ERRORS.CELLS_ADD_1, SYS_ERRORS.CELLS_ADD_2, false, SYS_ERRORS.CELLS_ADD_3);
			oCell = null;
		}

		internal void Clear()
		{
			mp_oCollection.m_Clear();
		}

		internal void Remove(String Index)
		{
			mp_oCollection.m_Remove(Index, SYS_ERRORS.CELLS_REMOVE_1, SYS_ERRORS.CELLS_REMOVE_2, SYS_ERRORS.CELLS_REMOVE_3, SYS_ERRORS.CELLS_REMOVE_4);
		}

		internal clsRow Row()
		{
			return mp_oRow;
		}

        public String GetXML()
        {
            int lIndex;
            clsCell oCell;
            clsXML oXML = new clsXML(mp_oControl, "Cells");
            oXML.InitializeWriter();
            for (lIndex = 1; lIndex <= Count; lIndex++)
            {
                oCell = (clsCell)mp_oCollection.m_oReturnArrayElement(lIndex);
                oXML.WriteObject(oCell.GetXML());
            }
            return oXML.GetXML();
        }

        public void SetXML(String sXML)
        {
            int lIndex;
            clsXML oXML = new clsXML(mp_oControl, "Cells");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            mp_oCollection.m_Clear();
            for (lIndex = 1; lIndex <= oXML.ReadCollectionCount(); lIndex++)
            {
                clsCell oCell = new clsCell(mp_oControl, this);
                oCell.SetXML(oXML.ReadCollectionObject(lIndex));
                mp_oCollection.AddMode = true;
                mp_oCollection.m_Add(oCell, "", SYS_ERRORS.CELLS_ADD_1, SYS_ERRORS.CELLS_ADD_2, false, SYS_ERRORS.CELLS_ADD_3);
                oCell = null;
            }
        }




	}
}
