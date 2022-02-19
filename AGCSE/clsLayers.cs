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
	public class clsLayers
	{
		private ActiveGanttCSECtl mp_oControl;
		private clsCollectionBase mp_oCollection;
		private clsLayer mp_oDefaultLayer;

		public clsLayers(ActiveGanttCSECtl Value)
		{
			mp_oControl = Value;
			mp_oCollection = new clsCollectionBase(Value, "Layer");
			mp_oDefaultLayer = new clsLayer(mp_oControl);	
		}

		~clsLayers()
		{	
			mp_oDefaultLayer = null;
			mp_oCollection = null;
			mp_oControl = null;
		}

		public int Count 
		{
			get 
			{
				return mp_oCollection.m_lCount();
			}
		}

		public clsLayer Item(String Index)
		{
			return (clsLayer) mp_oCollection.m_oItem(Index, SYS_ERRORS.LAYERS_ITEM_1, SYS_ERRORS.LAYERS_ITEM_2, SYS_ERRORS.LAYERS_ITEM_3, SYS_ERRORS.LAYERS_ITEM_4);
		}

		internal clsLayer FItem(String Index)
		{
			if ( Index == "0" )
			{
				return mp_oDefaultLayer;
			}
			else
			{
				return (clsLayer) mp_oCollection.m_oItem(Index, SYS_ERRORS.LAYERS_ITEM_1, SYS_ERRORS.LAYERS_ITEM_2, SYS_ERRORS.LAYERS_ITEM_3, SYS_ERRORS.LAYERS_ITEM_4);
			}
		}

		internal clsCollectionBase oCollection 
		{
			get 
			{
				return mp_oCollection;
			}
		}

		public clsLayer Add(String Key, bool Visible)
		{
			mp_oCollection.AddMode = true;
			clsLayer oLayer = new clsLayer(mp_oControl);
			oLayer.Key = Key;
			oLayer.Visible = Visible;
			mp_oCollection.m_Add(oLayer, Key, SYS_ERRORS.LAYERS_ADD_1, SYS_ERRORS.LAYERS_ADD_2, false, SYS_ERRORS.LAYERS_ADD_3);
			return oLayer;
		}

		public void Clear()
		{
			mp_oControl.Tasks.oCollection.m_CollectionRemoveWhereNot("LayerIndex", "0");
			mp_oControl.CurrentLayer = "0";
			mp_oCollection.m_Clear();
		}

		public void Remove(String Index)
		{
			String sRIndex = "";
			String sRKey = "";
			mp_oCollection.m_GetKeyAndIndex(Index, ref sRKey, ref sRIndex);
			mp_oControl.Tasks.oCollection.m_CollectionRemoveWhere("LayerIndex", sRKey, sRIndex);
			mp_oControl.CurrentLayer = "0";
			mp_oCollection.m_Remove(Index, SYS_ERRORS.LAYERS_REMOVE_1, SYS_ERRORS.LAYERS_REMOVE_2, SYS_ERRORS.LAYERS_REMOVE_3, SYS_ERRORS.LAYERS_REMOVE_4);
		}

        public String GetXML()
        {
            int lIndex;
            clsLayer oLayer;
            clsXML oXML = new clsXML(mp_oControl, "Layers");
            oXML.InitializeWriter();
            for (lIndex = 1; lIndex <= Count; lIndex++)
            {
                oLayer = (clsLayer)mp_oCollection.m_oReturnArrayElement(lIndex);
                oXML.WriteObject(oLayer.GetXML());
            }
            return oXML.GetXML();
        }

        public void SetXML(String sXML)
        {
            int lIndex;
            clsXML oXML = new clsXML(mp_oControl, "Layers");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            mp_oCollection.m_Clear();
            for (lIndex = 1; lIndex <= oXML.ReadCollectionCount(); lIndex++)
            {
                clsLayer oLayer = new clsLayer(mp_oControl);
                oLayer.SetXML(oXML.ReadCollectionObject(lIndex));
                mp_oCollection.AddMode = true;
                mp_oCollection.m_Add(oLayer, oLayer.Key, SYS_ERRORS.LAYERS_ADD_1, SYS_ERRORS.LAYERS_ADD_2, false, SYS_ERRORS.LAYERS_ADD_3);
                oLayer = null;
            }
        }

	}
}
