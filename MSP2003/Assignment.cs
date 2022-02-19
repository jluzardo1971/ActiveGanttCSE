using System;

namespace MSP2003
{
	public class Assignment : clsItemBase
	{

		internal clsCollectionBase mp_oCollection;
		private int mp_lUID;
		private int mp_lTaskUID;
		private int mp_lResourceUID;
		private int mp_lPercentWorkComplete;
		private Decimal mp_cActualCost;
		private System.DateTime mp_dtActualFinish;
		private Decimal mp_cActualOvertimeCost;
		private Duration mp_oActualOvertimeWork;
		private System.DateTime mp_dtActualStart;
		private Duration mp_oActualWork;
		private float mp_fACWP;
		private bool mp_bConfirmed;
		private Decimal mp_cCost;
		private E_COSTRATETABLE mp_yCostRateTable;
		private float mp_fCostVariance;
		private float mp_fCV;
		private int mp_lDelay;
		private System.DateTime mp_dtFinish;
		private int mp_lFinishVariance;
		private string mp_sHyperlink;
		private string mp_sHyperlinkAddress;
		private string mp_sHyperlinkSubAddress;
		private float mp_fWorkVariance;
		private bool mp_bHasFixedRateUnits;
		private bool mp_bFixedMaterial;
		private int mp_lLevelingDelay;
		private E_LEVELINGDELAYFORMAT mp_yLevelingDelayFormat;
		private bool mp_bLinkedFields;
		private bool mp_bMilestone;
		private string mp_sNotes;
		private bool mp_bOverallocated;
		private Decimal mp_cOvertimeCost;
		private Duration mp_oOvertimeWork;
		private Duration mp_oRegularWork;
		private Decimal mp_cRemainingCost;
		private Decimal mp_cRemainingOvertimeCost;
		private Duration mp_oRemainingOvertimeWork;
		private Duration mp_oRemainingWork;
		private bool mp_bResponsePending;
		private System.DateTime mp_dtStart;
		private System.DateTime mp_dtStop;
		private System.DateTime mp_dtResume;
		private int mp_lStartVariance;
		private float mp_fUnits;
		private bool mp_bUpdateNeeded;
		private float mp_fVAC;
		private Duration mp_oWork;
		private E_WORKCONTOUR mp_yWorkContour;
		private float mp_fBCWS;
		private float mp_fBCWP;
		private E_BOOKINGTYPE mp_yBookingType;
		private Duration mp_oActualWorkProtected;
		private Duration mp_oActualOvertimeWorkProtected;
		private System.DateTime mp_dtCreationDate;
		private AssignmentExtendedAttribute_C mp_oExtendedAttribute_C;
		private AssignmentBaseline_C mp_oBaseline_C;
		private TimephasedData_C mp_oTimephasedData_C;

		public Assignment()
		{
			mp_lUID = 0;
			mp_lTaskUID = 0;
			mp_lResourceUID = 0;
			mp_lPercentWorkComplete = 0;
			mp_cActualCost = 0;
			mp_dtActualFinish = new System.DateTime(0);
			mp_cActualOvertimeCost = 0;
			mp_oActualOvertimeWork = new Duration();
			mp_dtActualStart = new System.DateTime(0);
			mp_oActualWork = new Duration();
			mp_fACWP = 0;
			mp_bConfirmed = false;
			mp_cCost = 0;
			mp_yCostRateTable = E_COSTRATETABLE.CRT_COST_RATE_TABLE_0;
			mp_fCostVariance = 0;
			mp_fCV = 0;
			mp_lDelay = 0;
			mp_dtFinish = new System.DateTime(0);
			mp_lFinishVariance = 0;
			mp_sHyperlink = "";
			mp_sHyperlinkAddress = "";
			mp_sHyperlinkSubAddress = "";
			mp_fWorkVariance = 0;
			mp_bHasFixedRateUnits = false;
			mp_bFixedMaterial = false;
			mp_lLevelingDelay = 0;
			mp_yLevelingDelayFormat = E_LEVELINGDELAYFORMAT.LDF_M;
			mp_bLinkedFields = false;
			mp_bMilestone = false;
			mp_sNotes = "";
			mp_bOverallocated = false;
			mp_cOvertimeCost = 0;
			mp_oOvertimeWork = new Duration();
			mp_oRegularWork = new Duration();
			mp_cRemainingCost = 0;
			mp_cRemainingOvertimeCost = 0;
			mp_oRemainingOvertimeWork = new Duration();
			mp_oRemainingWork = new Duration();
			mp_bResponsePending = false;
			mp_dtStart = new System.DateTime(0);
			mp_dtStop = new System.DateTime(0);
			mp_dtResume = new System.DateTime(0);
			mp_lStartVariance = 0;
			mp_fUnits = 0;
			mp_bUpdateNeeded = false;
			mp_fVAC = 0;
			mp_oWork = new Duration();
			mp_yWorkContour = E_WORKCONTOUR.WC_FLAT;
			mp_fBCWS = 0;
			mp_fBCWP = 0;
			mp_yBookingType = E_BOOKINGTYPE.BT_COMMITED;
			mp_oActualWorkProtected = new Duration();
			mp_oActualOvertimeWorkProtected = new Duration();
			mp_dtCreationDate = new System.DateTime(0);
			mp_oExtendedAttribute_C = new AssignmentExtendedAttribute_C();
			mp_oBaseline_C = new AssignmentBaseline_C();
			mp_oTimephasedData_C = new TimephasedData_C();
		}

		public int lUID
		{
			get
			{
				return mp_lUID;
			}
			set
			{
				mp_lUID = value;
			}
		}

		public int lTaskUID
		{
			get
			{
				return mp_lTaskUID;
			}
			set
			{
				mp_lTaskUID = value;
			}
		}

		public int lResourceUID
		{
			get
			{
				return mp_lResourceUID;
			}
			set
			{
				mp_lResourceUID = value;
			}
		}

		public int lPercentWorkComplete
		{
			get
			{
				return mp_lPercentWorkComplete;
			}
			set
			{
				mp_lPercentWorkComplete = value;
			}
		}

		public Decimal cActualCost
		{
			get
			{
				return mp_cActualCost;
			}
			set
			{
				mp_cActualCost = value;
			}
		}

		public System.DateTime dtActualFinish
		{
			get
			{
				return mp_dtActualFinish;
			}
			set
			{
				mp_dtActualFinish = value;
			}
		}

		public Decimal cActualOvertimeCost
		{
			get
			{
				return mp_cActualOvertimeCost;
			}
			set
			{
				mp_cActualOvertimeCost = value;
			}
		}

		public Duration oActualOvertimeWork
		{
			get
			{
				return mp_oActualOvertimeWork;
			}
		}

		public System.DateTime dtActualStart
		{
			get
			{
				return mp_dtActualStart;
			}
			set
			{
				mp_dtActualStart = value;
			}
		}

		public Duration oActualWork
		{
			get
			{
				return mp_oActualWork;
			}
		}

		public float fACWP
		{
			get
			{
				return mp_fACWP;
			}
			set
			{
				mp_fACWP = value;
			}
		}

		public bool bConfirmed
		{
			get
			{
				return mp_bConfirmed;
			}
			set
			{
				mp_bConfirmed = value;
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

		public E_COSTRATETABLE yCostRateTable
		{
			get
			{
				return mp_yCostRateTable;
			}
			set
			{
				mp_yCostRateTable = value;
			}
		}

		public float fCostVariance
		{
			get
			{
				return mp_fCostVariance;
			}
			set
			{
				mp_fCostVariance = value;
			}
		}

		public float fCV
		{
			get
			{
				return mp_fCV;
			}
			set
			{
				mp_fCV = value;
			}
		}

		public int lDelay
		{
			get
			{
				return mp_lDelay;
			}
			set
			{
				mp_lDelay = value;
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

		public int lFinishVariance
		{
			get
			{
				return mp_lFinishVariance;
			}
			set
			{
				mp_lFinishVariance = value;
			}
		}

		public string sHyperlink
		{
			get
			{
				return mp_sHyperlink;
			}
			set
			{
				if (value.Length > 512)
				{
					value = value.Substring(0, 512);
				}
				mp_sHyperlink = value;
			}
		}

		public string sHyperlinkAddress
		{
			get
			{
				return mp_sHyperlinkAddress;
			}
			set
			{
				if (value.Length > 512)
				{
					value = value.Substring(0, 512);
				}
				mp_sHyperlinkAddress = value;
			}
		}

		public string sHyperlinkSubAddress
		{
			get
			{
				return mp_sHyperlinkSubAddress;
			}
			set
			{
				if (value.Length > 512)
				{
					value = value.Substring(0, 512);
				}
				mp_sHyperlinkSubAddress = value;
			}
		}

		public float fWorkVariance
		{
			get
			{
				return mp_fWorkVariance;
			}
			set
			{
				mp_fWorkVariance = value;
			}
		}

		public bool bHasFixedRateUnits
		{
			get
			{
				return mp_bHasFixedRateUnits;
			}
			set
			{
				mp_bHasFixedRateUnits = value;
			}
		}

		public bool bFixedMaterial
		{
			get
			{
				return mp_bFixedMaterial;
			}
			set
			{
				mp_bFixedMaterial = value;
			}
		}

		public int lLevelingDelay
		{
			get
			{
				return mp_lLevelingDelay;
			}
			set
			{
				mp_lLevelingDelay = value;
			}
		}

		public E_LEVELINGDELAYFORMAT yLevelingDelayFormat
		{
			get
			{
				return mp_yLevelingDelayFormat;
			}
			set
			{
				mp_yLevelingDelayFormat = value;
			}
		}

		public bool bLinkedFields
		{
			get
			{
				return mp_bLinkedFields;
			}
			set
			{
				mp_bLinkedFields = value;
			}
		}

		public bool bMilestone
		{
			get
			{
				return mp_bMilestone;
			}
			set
			{
				mp_bMilestone = value;
			}
		}

		public string sNotes
		{
			get
			{
				return mp_sNotes;
			}
			set
			{
				mp_sNotes = value;
			}
		}

		public bool bOverallocated
		{
			get
			{
				return mp_bOverallocated;
			}
			set
			{
				mp_bOverallocated = value;
			}
		}

		public Decimal cOvertimeCost
		{
			get
			{
				return mp_cOvertimeCost;
			}
			set
			{
				mp_cOvertimeCost = value;
			}
		}

		public Duration oOvertimeWork
		{
			get
			{
				return mp_oOvertimeWork;
			}
		}

		public Duration oRegularWork
		{
			get
			{
				return mp_oRegularWork;
			}
		}

		public Decimal cRemainingCost
		{
			get
			{
				return mp_cRemainingCost;
			}
			set
			{
				mp_cRemainingCost = value;
			}
		}

		public Decimal cRemainingOvertimeCost
		{
			get
			{
				return mp_cRemainingOvertimeCost;
			}
			set
			{
				mp_cRemainingOvertimeCost = value;
			}
		}

		public Duration oRemainingOvertimeWork
		{
			get
			{
				return mp_oRemainingOvertimeWork;
			}
		}

		public Duration oRemainingWork
		{
			get
			{
				return mp_oRemainingWork;
			}
		}

		public bool bResponsePending
		{
			get
			{
				return mp_bResponsePending;
			}
			set
			{
				mp_bResponsePending = value;
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

		public System.DateTime dtStop
		{
			get
			{
				return mp_dtStop;
			}
			set
			{
				mp_dtStop = value;
			}
		}

		public System.DateTime dtResume
		{
			get
			{
				return mp_dtResume;
			}
			set
			{
				mp_dtResume = value;
			}
		}

		public int lStartVariance
		{
			get
			{
				return mp_lStartVariance;
			}
			set
			{
				mp_lStartVariance = value;
			}
		}

		public float fUnits
		{
			get
			{
				return mp_fUnits;
			}
			set
			{
				mp_fUnits = value;
			}
		}

		public bool bUpdateNeeded
		{
			get
			{
				return mp_bUpdateNeeded;
			}
			set
			{
				mp_bUpdateNeeded = value;
			}
		}

		public float fVAC
		{
			get
			{
				return mp_fVAC;
			}
			set
			{
				mp_fVAC = value;
			}
		}

		public Duration oWork
		{
			get
			{
				return mp_oWork;
			}
		}

		public E_WORKCONTOUR yWorkContour
		{
			get
			{
				return mp_yWorkContour;
			}
			set
			{
				mp_yWorkContour = value;
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

		public E_BOOKINGTYPE yBookingType
		{
			get
			{
				return mp_yBookingType;
			}
			set
			{
				mp_yBookingType = value;
			}
		}

		public Duration oActualWorkProtected
		{
			get
			{
				return mp_oActualWorkProtected;
			}
		}

		public Duration oActualOvertimeWorkProtected
		{
			get
			{
				return mp_oActualOvertimeWorkProtected;
			}
		}

		public System.DateTime dtCreationDate
		{
			get
			{
				return mp_dtCreationDate;
			}
			set
			{
				mp_dtCreationDate = value;
			}
		}

		public AssignmentExtendedAttribute_C oExtendedAttribute_C
		{
			get
			{
				return mp_oExtendedAttribute_C;
			}
		}

		public AssignmentBaseline_C oBaseline_C
		{
			get
			{
				return mp_oBaseline_C;
			}
		}

		public TimephasedData_C oTimephasedData_C
		{
			get
			{
				return mp_oTimephasedData_C;
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
			if (mp_lUID != 0)
			{
				bReturn = false;
			}
			if (mp_lTaskUID != 0)
			{
				bReturn = false;
			}
			if (mp_lResourceUID != 0)
			{
				bReturn = false;
			}
			if (mp_lPercentWorkComplete != 0)
			{
				bReturn = false;
			}
			if (mp_cActualCost != 0)
			{
				bReturn = false;
			}
			if (mp_dtActualFinish.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_cActualOvertimeCost != 0)
			{
				bReturn = false;
			}
			if (mp_oActualOvertimeWork.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_dtActualStart.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_oActualWork.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_fACWP != 0)
			{
				bReturn = false;
			}
			if (mp_bConfirmed != false)
			{
				bReturn = false;
			}
			if (mp_cCost != 0)
			{
				bReturn = false;
			}
			if (mp_yCostRateTable != E_COSTRATETABLE.CRT_COST_RATE_TABLE_0)
			{
				bReturn = false;
			}
			if (mp_fCostVariance != 0)
			{
				bReturn = false;
			}
			if (mp_fCV != 0)
			{
				bReturn = false;
			}
			if (mp_lDelay != 0)
			{
				bReturn = false;
			}
			if (mp_dtFinish.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_lFinishVariance != 0)
			{
				bReturn = false;
			}
			if (mp_sHyperlink != "")
			{
				bReturn = false;
			}
			if (mp_sHyperlinkAddress != "")
			{
				bReturn = false;
			}
			if (mp_sHyperlinkSubAddress != "")
			{
				bReturn = false;
			}
			if (mp_fWorkVariance != 0)
			{
				bReturn = false;
			}
			if (mp_bHasFixedRateUnits != false)
			{
				bReturn = false;
			}
			if (mp_bFixedMaterial != false)
			{
				bReturn = false;
			}
			if (mp_lLevelingDelay != 0)
			{
				bReturn = false;
			}
			if (mp_yLevelingDelayFormat != E_LEVELINGDELAYFORMAT.LDF_M)
			{
				bReturn = false;
			}
			if (mp_bLinkedFields != false)
			{
				bReturn = false;
			}
			if (mp_bMilestone != false)
			{
				bReturn = false;
			}
			if (mp_sNotes != "")
			{
				bReturn = false;
			}
			if (mp_bOverallocated != false)
			{
				bReturn = false;
			}
			if (mp_cOvertimeCost != 0)
			{
				bReturn = false;
			}
			if (mp_oOvertimeWork.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_oRegularWork.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_cRemainingCost != 0)
			{
				bReturn = false;
			}
			if (mp_cRemainingOvertimeCost != 0)
			{
				bReturn = false;
			}
			if (mp_oRemainingOvertimeWork.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_oRemainingWork.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_bResponsePending != false)
			{
				bReturn = false;
			}
			if (mp_dtStart.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_dtStop.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_dtResume.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_lStartVariance != 0)
			{
				bReturn = false;
			}
			if (mp_fUnits != 0)
			{
				bReturn = false;
			}
			if (mp_bUpdateNeeded != false)
			{
				bReturn = false;
			}
			if (mp_fVAC != 0)
			{
				bReturn = false;
			}
			if (mp_oWork.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_yWorkContour != E_WORKCONTOUR.WC_FLAT)
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
			if (mp_yBookingType != E_BOOKINGTYPE.BT_COMMITED)
			{
				bReturn = false;
			}
			if (mp_oActualWorkProtected.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_oActualOvertimeWorkProtected.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_dtCreationDate.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_oExtendedAttribute_C.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_oBaseline_C.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_oTimephasedData_C.IsNull() == false)
			{
				bReturn = false;
			}
			return bReturn;
		}

		public string GetXML()
		{
			if (IsNull() == true)
			{
				return "<Assignment/>";
			}
			clsXML oXML = new clsXML("Assignment");
			oXML.InitializeWriter();
			oXML.SupportOptional = true;
			oXML.BoolsAreNumeric = true;
			oXML.WriteProperty("UID", mp_lUID);
			oXML.WriteProperty("TaskUID", mp_lTaskUID);
			oXML.WriteProperty("ResourceUID", mp_lResourceUID);
			oXML.WriteProperty("PercentWorkComplete", mp_lPercentWorkComplete);
			oXML.WriteProperty("ActualCost", mp_cActualCost);
			if (mp_dtActualFinish.Ticks != 0)
			{
				oXML.WriteProperty("ActualFinish", mp_dtActualFinish);
			}
			oXML.WriteProperty("ActualOvertimeCost", mp_cActualOvertimeCost);
			oXML.WriteProperty("ActualOvertimeWork", mp_oActualOvertimeWork);
			if (mp_dtActualStart.Ticks != 0)
			{
				oXML.WriteProperty("ActualStart", mp_dtActualStart);
			}
			oXML.WriteProperty("ActualWork", mp_oActualWork);
			oXML.WriteProperty("ACWP", mp_fACWP);
			oXML.WriteProperty("Confirmed", mp_bConfirmed);
			oXML.WriteProperty("Cost", mp_cCost);
			oXML.WriteProperty("CostRateTable", mp_yCostRateTable);
			oXML.WriteProperty("CostVariance", mp_fCostVariance);
			oXML.WriteProperty("CV", mp_fCV);
			oXML.WriteProperty("Delay", mp_lDelay);
			if (mp_dtFinish.Ticks != 0)
			{
				oXML.WriteProperty("Finish", mp_dtFinish);
			}
			oXML.WriteProperty("FinishVariance", mp_lFinishVariance);
			if (mp_sHyperlink != "")
			{
				oXML.WriteProperty("Hyperlink", mp_sHyperlink);
			}
			if (mp_sHyperlinkAddress != "")
			{
				oXML.WriteProperty("HyperlinkAddress", mp_sHyperlinkAddress);
			}
			if (mp_sHyperlinkSubAddress != "")
			{
				oXML.WriteProperty("HyperlinkSubAddress", mp_sHyperlinkSubAddress);
			}
			oXML.WriteProperty("WorkVariance", mp_fWorkVariance);
			oXML.WriteProperty("HasFixedRateUnits", mp_bHasFixedRateUnits);
			oXML.WriteProperty("FixedMaterial", mp_bFixedMaterial);
			oXML.WriteProperty("LevelingDelay", mp_lLevelingDelay);
			oXML.WriteProperty("LevelingDelayFormat", mp_yLevelingDelayFormat);
			oXML.WriteProperty("LinkedFields", mp_bLinkedFields);
			oXML.WriteProperty("Milestone", mp_bMilestone);
			if (mp_sNotes != "")
			{
				oXML.WriteProperty("Notes", mp_sNotes);
			}
			oXML.WriteProperty("Overallocated", mp_bOverallocated);
			oXML.WriteProperty("OvertimeCost", mp_cOvertimeCost);
			oXML.WriteProperty("OvertimeWork", mp_oOvertimeWork);
			oXML.WriteProperty("RegularWork", mp_oRegularWork);
			oXML.WriteProperty("RemainingCost", mp_cRemainingCost);
			oXML.WriteProperty("RemainingOvertimeCost", mp_cRemainingOvertimeCost);
			oXML.WriteProperty("RemainingOvertimeWork", mp_oRemainingOvertimeWork);
			oXML.WriteProperty("RemainingWork", mp_oRemainingWork);
			oXML.WriteProperty("ResponsePending", mp_bResponsePending);
			if (mp_dtStart.Ticks != 0)
			{
				oXML.WriteProperty("Start", mp_dtStart);
			}
			if (mp_dtStop.Ticks != 0)
			{
				oXML.WriteProperty("Stop", mp_dtStop);
			}
			if (mp_dtResume.Ticks != 0)
			{
				oXML.WriteProperty("Resume", mp_dtResume);
			}
			oXML.WriteProperty("StartVariance", mp_lStartVariance);
			oXML.WriteProperty("Units", mp_fUnits);
			oXML.WriteProperty("UpdateNeeded", mp_bUpdateNeeded);
			oXML.WriteProperty("VAC", mp_fVAC);
			oXML.WriteProperty("Work", mp_oWork);
			oXML.WriteProperty("WorkContour", mp_yWorkContour);
			oXML.WriteProperty("BCWS", mp_fBCWS);
			oXML.WriteProperty("BCWP", mp_fBCWP);
			oXML.WriteProperty("BookingType", mp_yBookingType);
			oXML.WriteProperty("ActualWorkProtected", mp_oActualWorkProtected);
			oXML.WriteProperty("ActualOvertimeWorkProtected", mp_oActualOvertimeWorkProtected);
			if (mp_dtCreationDate.Ticks != 0)
			{
				oXML.WriteProperty("CreationDate", mp_dtCreationDate);
			}
			if (mp_oExtendedAttribute_C.IsNull() == false)
			{
				mp_oExtendedAttribute_C.WriteObjectProtected(ref oXML);
			}
			if (mp_oBaseline_C.IsNull() == false)
			{
				mp_oBaseline_C.WriteObjectProtected(ref oXML);
			}
			if (mp_oTimephasedData_C.IsNull() == false)
			{
				mp_oTimephasedData_C.WriteObjectProtected(ref oXML);
			}
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML("Assignment");
			oXML.SupportOptional = true;
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("UID", ref mp_lUID);
			oXML.ReadProperty("TaskUID", ref mp_lTaskUID);
			oXML.ReadProperty("ResourceUID", ref mp_lResourceUID);
			oXML.ReadProperty("PercentWorkComplete", ref mp_lPercentWorkComplete);
			oXML.ReadProperty("ActualCost", ref mp_cActualCost);
			oXML.ReadProperty("ActualFinish", ref mp_dtActualFinish);
			oXML.ReadProperty("ActualOvertimeCost", ref mp_cActualOvertimeCost);
			oXML.ReadProperty("ActualOvertimeWork", ref mp_oActualOvertimeWork);
			oXML.ReadProperty("ActualStart", ref mp_dtActualStart);
			oXML.ReadProperty("ActualWork", ref mp_oActualWork);
			oXML.ReadProperty("ACWP", ref mp_fACWP);
			oXML.ReadProperty("Confirmed", ref mp_bConfirmed);
			oXML.ReadProperty("Cost", ref mp_cCost);
			oXML.ReadProperty("CostRateTable", ref mp_yCostRateTable);
			oXML.ReadProperty("CostVariance", ref mp_fCostVariance);
			oXML.ReadProperty("CV", ref mp_fCV);
			oXML.ReadProperty("Delay", ref mp_lDelay);
			oXML.ReadProperty("Finish", ref mp_dtFinish);
			oXML.ReadProperty("FinishVariance", ref mp_lFinishVariance);
			oXML.ReadProperty("Hyperlink", ref mp_sHyperlink);
			if (mp_sHyperlink.Length > 512)
			{
				mp_sHyperlink = mp_sHyperlink.Substring(0, 512);
			}
			oXML.ReadProperty("HyperlinkAddress", ref mp_sHyperlinkAddress);
			if (mp_sHyperlinkAddress.Length > 512)
			{
				mp_sHyperlinkAddress = mp_sHyperlinkAddress.Substring(0, 512);
			}
			oXML.ReadProperty("HyperlinkSubAddress", ref mp_sHyperlinkSubAddress);
			if (mp_sHyperlinkSubAddress.Length > 512)
			{
				mp_sHyperlinkSubAddress = mp_sHyperlinkSubAddress.Substring(0, 512);
			}
			oXML.ReadProperty("WorkVariance", ref mp_fWorkVariance);
			oXML.ReadProperty("HasFixedRateUnits", ref mp_bHasFixedRateUnits);
			oXML.ReadProperty("FixedMaterial", ref mp_bFixedMaterial);
			oXML.ReadProperty("LevelingDelay", ref mp_lLevelingDelay);
			oXML.ReadProperty("LevelingDelayFormat", ref mp_yLevelingDelayFormat);
			oXML.ReadProperty("LinkedFields", ref mp_bLinkedFields);
			oXML.ReadProperty("Milestone", ref mp_bMilestone);
			oXML.ReadProperty("Notes", ref mp_sNotes);
			oXML.ReadProperty("Overallocated", ref mp_bOverallocated);
			oXML.ReadProperty("OvertimeCost", ref mp_cOvertimeCost);
			oXML.ReadProperty("OvertimeWork", ref mp_oOvertimeWork);
			oXML.ReadProperty("RegularWork", ref mp_oRegularWork);
			oXML.ReadProperty("RemainingCost", ref mp_cRemainingCost);
			oXML.ReadProperty("RemainingOvertimeCost", ref mp_cRemainingOvertimeCost);
			oXML.ReadProperty("RemainingOvertimeWork", ref mp_oRemainingOvertimeWork);
			oXML.ReadProperty("RemainingWork", ref mp_oRemainingWork);
			oXML.ReadProperty("ResponsePending", ref mp_bResponsePending);
			oXML.ReadProperty("Start", ref mp_dtStart);
			oXML.ReadProperty("Stop", ref mp_dtStop);
			oXML.ReadProperty("Resume", ref mp_dtResume);
			oXML.ReadProperty("StartVariance", ref mp_lStartVariance);
			oXML.ReadProperty("Units", ref mp_fUnits);
			oXML.ReadProperty("UpdateNeeded", ref mp_bUpdateNeeded);
			oXML.ReadProperty("VAC", ref mp_fVAC);
			oXML.ReadProperty("Work", ref mp_oWork);
			oXML.ReadProperty("WorkContour", ref mp_yWorkContour);
			oXML.ReadProperty("BCWS", ref mp_fBCWS);
			oXML.ReadProperty("BCWP", ref mp_fBCWP);
			oXML.ReadProperty("BookingType", ref mp_yBookingType);
			oXML.ReadProperty("ActualWorkProtected", ref mp_oActualWorkProtected);
			oXML.ReadProperty("ActualOvertimeWorkProtected", ref mp_oActualOvertimeWorkProtected);
			oXML.ReadProperty("CreationDate", ref mp_dtCreationDate);
			mp_oExtendedAttribute_C.ReadObjectProtected(ref oXML);
			mp_oBaseline_C.ReadObjectProtected(ref oXML);
			mp_oTimephasedData_C.ReadObjectProtected(ref oXML);
		}

	}
}
