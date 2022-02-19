using System;

namespace MSP2010
{
	public class TaskBaseline : clsItemBase
	{

		internal clsCollectionBase mp_oCollection;
		private TimephasedData_C mp_oTimephasedData_C;
		private int mp_lNumber;
		private bool mp_bInterim;
		private System.DateTime mp_dtStart;
		private System.DateTime mp_dtFinish;
		private Duration mp_oDuration;
		private E_DURATIONFORMAT mp_yDurationFormat;
		private bool mp_bEstimatedDuration;
		private Duration mp_oWork;
		private Decimal mp_cCost;
		private float mp_fBCWS;
		private float mp_fBCWP;
		private float mp_fFixedCost;

		public TaskBaseline()
		{
			mp_oTimephasedData_C = new TimephasedData_C();
			mp_lNumber = 0;
			mp_bInterim = false;
			mp_dtStart = new System.DateTime(0);
			mp_dtFinish = new System.DateTime(0);
			mp_oDuration = new Duration();
			mp_yDurationFormat = E_DURATIONFORMAT.DF_M;
			mp_bEstimatedDuration = false;
			mp_oWork = new Duration();
			mp_cCost = 0;
			mp_fBCWS = 0;
			mp_fBCWP = 0;
			mp_fFixedCost = 0;
		}

		public TimephasedData_C oTimephasedData_C
		{
			get
			{
				return mp_oTimephasedData_C;
			}
		}

		public int lNumber
		{
			get
			{
				return mp_lNumber;
			}
			set
			{
				mp_lNumber = value;
			}
		}

		public bool bInterim
		{
			get
			{
				return mp_bInterim;
			}
			set
			{
				mp_bInterim = value;
			}
		}

		public System.DateTime dtStart
		{
			get
			{
				return mp_dtStart;
			}
			set
			{
				mp_dtStart = value;
			}
		}

		public System.DateTime dtFinish
		{
			get
			{
				return mp_dtFinish;
			}
			set
			{
				mp_dtFinish = value;
			}
		}

		public Duration oDuration
		{
			get
			{
				return mp_oDuration;
			}
		}

		public E_DURATIONFORMAT yDurationFormat
		{
			get
			{
				return mp_yDurationFormat;
			}
			set
			{
				mp_yDurationFormat = value;
			}
		}

		public bool bEstimatedDuration
		{
			get
			{
				return mp_bEstimatedDuration;
			}
			set
			{
				mp_bEstimatedDuration = value;
			}
		}

		public Duration oWork
		{
			get
			{
				return mp_oWork;
			}
		}

		public Decimal cCost
		{
			get
			{
				return mp_cCost;
			}
			set
			{
				mp_cCost = value;
			}
		}

		public float fBCWS
		{
			get
			{
				return mp_fBCWS;
			}
			set
			{
				mp_fBCWS = value;
			}
		}

		public float fBCWP
		{
			get
			{
				return mp_fBCWP;
			}
			set
			{
				mp_fBCWP = value;
			}
		}

		public float fFixedCost
		{
			get
			{
				return mp_fFixedCost;
			}
			set
			{
				mp_fFixedCost = value;
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
			if (mp_oTimephasedData_C.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_lNumber != 0)
			{
				bReturn = false;
			}
			if (mp_bInterim != false)
			{
				bReturn = false;
			}
			if (mp_dtStart.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_dtFinish.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_oDuration.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_yDurationFormat != E_DURATIONFORMAT.DF_M)
			{
				bReturn = false;
			}
			if (mp_bEstimatedDuration != false)
			{
				bReturn = false;
			}
			if (mp_oWork.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_cCost != 0)
			{
				bReturn = false;
			}
			if (mp_fBCWS != 0)
			{
				bReturn = false;
			}
			if (mp_fBCWP != 0)
			{
				bReturn = false;
			}
			if (mp_fFixedCost != 0)
			{
				bReturn = false;
			}
			return bReturn;
		}

		public string GetXML()
		{
			if (IsNull() == true)
			{
				return "<Baseline/>";
			}
			clsXML oXML = new clsXML("Baseline");
			oXML.InitializeWriter();
			oXML.SupportOptional = true;
			oXML.BoolsAreNumeric = true;
			if (mp_oTimephasedData_C.IsNull() == false)
			{
				mp_oTimephasedData_C.WriteObjectProtected(ref oXML);
			}
			oXML.WriteProperty("Number", mp_lNumber);
			oXML.WriteProperty("Interim", mp_bInterim);
			if (mp_dtStart.Ticks != 0)
			{
				oXML.WriteProperty("Start", mp_dtStart);
			}
			if (mp_dtFinish.Ticks != 0)
			{
				oXML.WriteProperty("Finish", mp_dtFinish);
			}
			oXML.WriteProperty("Duration", mp_oDuration);
			oXML.WriteProperty("DurationFormat", mp_yDurationFormat);
			oXML.WriteProperty("EstimatedDuration", mp_bEstimatedDuration);
			oXML.WriteProperty("Work", mp_oWork);
			oXML.WriteProperty("Cost", mp_cCost);
			oXML.WriteProperty("BCWS", mp_fBCWS);
			oXML.WriteProperty("BCWP", mp_fBCWP);
			oXML.WriteProperty("FixedCost", mp_fFixedCost);
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML("Baseline");
			oXML.SupportOptional = true;
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			mp_oTimephasedData_C.ReadObjectProtected(ref oXML);
			oXML.ReadProperty("Number", ref mp_lNumber);
			oXML.ReadProperty("Interim", ref mp_bInterim);
			oXML.ReadProperty("Start", ref mp_dtStart);
			oXML.ReadProperty("Finish", ref mp_dtFinish);
			oXML.ReadProperty("Duration", ref mp_oDuration);
			oXML.ReadProperty("DurationFormat", ref mp_yDurationFormat);
			oXML.ReadProperty("EstimatedDuration", ref mp_bEstimatedDuration);
			oXML.ReadProperty("Work", ref mp_oWork);
			oXML.ReadProperty("Cost", ref mp_cCost);
			oXML.ReadProperty("BCWS", ref mp_fBCWS);
			oXML.ReadProperty("BCWP", ref mp_fBCWP);
			oXML.ReadProperty("FixedCost", ref mp_fFixedCost);
		}

	}
}
