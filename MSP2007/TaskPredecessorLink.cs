using System;

namespace MSP2007
{
	public class TaskPredecessorLink : clsItemBase
	{

		internal clsCollectionBase mp_oCollection;
		private int mp_lPredecessorUID;
		private E_TYPE_5 mp_yType;
		private bool mp_bCrossProject;
		private string mp_sCrossProjectName;
		private int mp_lLinkLag;
		private E_LAGFORMAT mp_yLagFormat;

		public TaskPredecessorLink()
		{
			mp_lPredecessorUID = 0;
			mp_yType = E_TYPE_5.T_5_FF;
			mp_bCrossProject = false;
			mp_sCrossProjectName = "";
			mp_lLinkLag = 0;
			mp_yLagFormat = E_LAGFORMAT.LF_M;
		}

		public int lPredecessorUID
		{
			get
			{
				return mp_lPredecessorUID;
			}
			set
			{
				mp_lPredecessorUID = value;
			}
		}

		public E_TYPE_5 yType
		{
			get
			{
				return mp_yType;
			}
			set
			{
				mp_yType = value;
			}
		}

		public bool bCrossProject
		{
			get
			{
				return mp_bCrossProject;
			}
			set
			{
				mp_bCrossProject = value;
			}
		}

		public string sCrossProjectName
		{
			get
			{
				return mp_sCrossProjectName;
			}
			set
			{
				mp_sCrossProjectName = value;
			}
		}

		public int lLinkLag
		{
			get
			{
				return mp_lLinkLag;
			}
			set
			{
				mp_lLinkLag = value;
			}
		}

		public E_LAGFORMAT yLagFormat
		{
			get
			{
				return mp_yLagFormat;
			}
			set
			{
				mp_yLagFormat = value;
			}
		}
		public string Key
		{
			get { return mp_sKey; }
			set { mp_oCollection.mp_SetKey(ref mp_sKey, value, SYS_ERRORS.MP_SET_KEY); }
		}

		public bool IsNull()
		{
			bool bReturn = true;
			if (mp_lPredecessorUID != 0)
			{
				bReturn = false;
			}
			if (mp_yType != E_TYPE_5.T_5_FF)
			{
				bReturn = false;
			}
			if (mp_bCrossProject != false)
			{
				bReturn = false;
			}
			if (mp_sCrossProjectName != "")
			{
				bReturn = false;
			}
			if (mp_lLinkLag != 0)
			{
				bReturn = false;
			}
			if (mp_yLagFormat != E_LAGFORMAT.LF_M)
			{
				bReturn = false;
			}
			return bReturn;
		}

		public string GetXML()
		{
			if (IsNull() == true)
			{
				return "<PredecessorLink/>";
			}
			clsXML oXML = new clsXML("PredecessorLink");
			oXML.InitializeWriter();
			oXML.SupportOptional = true;
			oXML.BoolsAreNumeric = true;
			oXML.WriteProperty("PredecessorUID", mp_lPredecessorUID);
			oXML.WriteProperty("Type", mp_yType);
			oXML.WriteProperty("CrossProject", mp_bCrossProject);
			if (mp_sCrossProjectName != "")
			{
				oXML.WriteProperty("CrossProjectName", mp_sCrossProjectName);
			}
			oXML.WriteProperty("LinkLag", mp_lLinkLag);
			oXML.WriteProperty("LagFormat", mp_yLagFormat);
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML("PredecessorLink");
			oXML.SupportOptional = true;
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("PredecessorUID", ref mp_lPredecessorUID);
			oXML.ReadProperty("Type", ref mp_yType);
			oXML.ReadProperty("CrossProject", ref mp_bCrossProject);
			oXML.ReadProperty("CrossProjectName", ref mp_sCrossProjectName);
			oXML.ReadProperty("LinkLag", ref mp_lLinkLag);
			oXML.ReadProperty("LagFormat", ref mp_yLagFormat);
		}

	}
}
