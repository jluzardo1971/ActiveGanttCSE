using System;

namespace MSP2010
{
	public class Task : clsItemBase
	{

		internal clsCollectionBase mp_oCollection;
		private int mp_lUID;
		private int mp_lID;
		private string mp_sName;
		private E_TYPE_4 mp_yType;
		private bool mp_bIsNull;
		private System.DateTime mp_dtCreateDate;
		private string mp_sContact;
		private string mp_sWBS;
		private string mp_sWBSLevel;
		private string mp_sOutlineNumber;
		private int mp_lOutlineLevel;
		private int mp_lPriority;
		private System.DateTime mp_dtStart;
		private System.DateTime mp_dtFinish;
		private Duration mp_oDuration;
		private E_DURATIONFORMAT mp_yDurationFormat;
		private Duration mp_oWork;
		private System.DateTime mp_dtStop;
		private System.DateTime mp_dtResume;
		private bool mp_bResumeValid;
		private bool mp_bEffortDriven;
		private bool mp_bRecurring;
		private bool mp_bOverAllocated;
		private bool mp_bEstimated;
		private bool mp_bMilestone;
		private bool mp_bSummary;
		private bool mp_bDisplayAsSummary;
		private bool mp_bCritical;
		private bool mp_bIsSubproject;
		private bool mp_bIsSubprojectReadOnly;
		private string mp_sSubprojectName;
		private bool mp_bExternalTask;
		private string mp_sExternalTaskProject;
		private System.DateTime mp_dtEarlyStart;
		private System.DateTime mp_dtEarlyFinish;
		private System.DateTime mp_dtLateStart;
		private System.DateTime mp_dtLateFinish;
		private int mp_lStartVariance;
		private int mp_lFinishVariance;
		private float mp_fWorkVariance;
		private int mp_lFreeSlack;
		private int mp_lStartSlack;
		private int mp_lFinishSlack;
		private int mp_lTotalSlack;
		private float mp_fFixedCost;
		private E_FIXEDCOSTACCRUAL mp_yFixedCostAccrual;
		private int mp_lPercentComplete;
		private int mp_lPercentWorkComplete;
		private Decimal mp_cCost;
		private Decimal mp_cOvertimeCost;
		private Duration mp_oOvertimeWork;
		private System.DateTime mp_dtActualStart;
		private System.DateTime mp_dtActualFinish;
		private Duration mp_oActualDuration;
		private Decimal mp_cActualCost;
		private Decimal mp_cActualOvertimeCost;
		private Duration mp_oActualWork;
		private Duration mp_oActualOvertimeWork;
		private Duration mp_oRegularWork;
		private Duration mp_oRemainingDuration;
		private Decimal mp_cRemainingCost;
		private Duration mp_oRemainingWork;
		private Decimal mp_cRemainingOvertimeCost;
		private Duration mp_oRemainingOvertimeWork;
		private float mp_fACWP;
		private float mp_fCV;
		private E_CONSTRAINTTYPE mp_yConstraintType;
		private int mp_lCalendarUID;
		private System.DateTime mp_dtConstraintDate;
		private System.DateTime mp_dtDeadline;
		private bool mp_bLevelAssignments;
		private bool mp_bLevelingCanSplit;
		private int mp_lLevelingDelay;
		private E_LEVELINGDELAYFORMAT mp_yLevelingDelayFormat;
		private System.DateTime mp_dtPreLeveledStart;
		private System.DateTime mp_dtPreLeveledFinish;
		private string mp_sHyperlink;
		private string mp_sHyperlinkAddress;
		private string mp_sHyperlinkSubAddress;
		private bool mp_bIgnoreResourceCalendar;
		private string mp_sNotes;
		private bool mp_bHideBar;
		private bool mp_bRollup;
		private float mp_fBCWS;
		private float mp_fBCWP;
		private int mp_lPhysicalPercentComplete;
		private E_EARNEDVALUEMETHOD mp_yEarnedValueMethod;
		private TaskPredecessorLink_C mp_oPredecessorLink_C;
		private Duration mp_oActualWorkProtected;
		private Duration mp_oActualOvertimeWorkProtected;
		private TaskExtendedAttribute_C mp_oExtendedAttribute_C;
		private TaskBaseline_C mp_oBaseline_C;
		private TaskOutlineCode_C mp_oOutlineCode_C;
		private bool mp_bIsPublished;
		private string mp_sStatusManager;
		private System.DateTime mp_dtCommitmentStart;
		private System.DateTime mp_dtCommitmentFinish;
		private E_COMMITMENTTYPE mp_yCommitmentType;
		private bool mp_bActive;
		private bool mp_bPinned;
		private string mp_sPinnedStart;
		private string mp_sPinnedFinish;
		private string mp_sPinnedDuration;
		private TimephasedData_C mp_oTimephasedData_C;

		public Task()
		{
			mp_lUID = 0;
			mp_lID = 0;
			mp_sName = "";
			mp_yType = E_TYPE_4.T_4_FIXED_UNITS;
			mp_bIsNull = false;
			mp_dtCreateDate = new System.DateTime(0);
			mp_sContact = "";
			mp_sWBS = "";
			mp_sWBSLevel = "";
			mp_sOutlineNumber = "";
			mp_lOutlineLevel = 0;
			mp_lPriority = 0;
			mp_dtStart = new System.DateTime(0);
			mp_dtFinish = new System.DateTime(0);
			mp_oDuration = new Duration();
			mp_yDurationFormat = E_DURATIONFORMAT.DF_M;
			mp_oWork = new Duration();
			mp_dtStop = new System.DateTime(0);
			mp_dtResume = new System.DateTime(0);
			mp_bResumeValid = false;
			mp_bEffortDriven = false;
			mp_bRecurring = false;
			mp_bOverAllocated = false;
			mp_bEstimated = false;
			mp_bMilestone = false;
			mp_bSummary = false;
			mp_bDisplayAsSummary = false;
			mp_bCritical = false;
			mp_bIsSubproject = false;
			mp_bIsSubprojectReadOnly = false;
			mp_sSubprojectName = "";
			mp_bExternalTask = false;
			mp_sExternalTaskProject = "";
			mp_dtEarlyStart = new System.DateTime(0);
			mp_dtEarlyFinish = new System.DateTime(0);
			mp_dtLateStart = new System.DateTime(0);
			mp_dtLateFinish = new System.DateTime(0);
			mp_lStartVariance = 0;
			mp_lFinishVariance = 0;
			mp_fWorkVariance = 0;
			mp_lFreeSlack = 0;
			mp_lStartSlack = 0;
			mp_lFinishSlack = 0;
			mp_lTotalSlack = 0;
			mp_fFixedCost = 0;
			mp_yFixedCostAccrual = E_FIXEDCOSTACCRUAL.FCA_START;
			mp_lPercentComplete = 0;
			mp_lPercentWorkComplete = 0;
			mp_cCost = 0;
			mp_cOvertimeCost = 0;
			mp_oOvertimeWork = new Duration();
			mp_dtActualStart = new System.DateTime(0);
			mp_dtActualFinish = new System.DateTime(0);
			mp_oActualDuration = new Duration();
			mp_cActualCost = 0;
			mp_cActualOvertimeCost = 0;
			mp_oActualWork = new Duration();
			mp_oActualOvertimeWork = new Duration();
			mp_oRegularWork = new Duration();
			mp_oRemainingDuration = new Duration();
			mp_cRemainingCost = 0;
			mp_oRemainingWork = new Duration();
			mp_cRemainingOvertimeCost = 0;
			mp_oRemainingOvertimeWork = new Duration();
			mp_fACWP = 0;
			mp_fCV = 0;
			mp_yConstraintType = E_CONSTRAINTTYPE.CT_AS_SOON_AS_POSSIBLE;
			mp_lCalendarUID = 0;
			mp_dtConstraintDate = new System.DateTime(0);
			mp_dtDeadline = new System.DateTime(0);
			mp_bLevelAssignments = false;
			mp_bLevelingCanSplit = false;
			mp_lLevelingDelay = 0;
			mp_yLevelingDelayFormat = E_LEVELINGDELAYFORMAT.LDF_M;
			mp_dtPreLeveledStart = new System.DateTime(0);
			mp_dtPreLeveledFinish = new System.DateTime(0);
			mp_sHyperlink = "";
			mp_sHyperlinkAddress = "";
			mp_sHyperlinkSubAddress = "";
			mp_bIgnoreResourceCalendar = false;
			mp_sNotes = "";
			mp_bHideBar = false;
			mp_bRollup = false;
			mp_fBCWS = 0;
			mp_fBCWP = 0;
			mp_lPhysicalPercentComplete = 0;
			mp_yEarnedValueMethod = E_EARNEDVALUEMETHOD.EVM_PERCENT_COMPLETE;
			mp_oPredecessorLink_C = new TaskPredecessorLink_C();
			mp_oActualWorkProtected = new Duration();
			mp_oActualOvertimeWorkProtected = new Duration();
			mp_oExtendedAttribute_C = new TaskExtendedAttribute_C();
			mp_oBaseline_C = new TaskBaseline_C();
			mp_oOutlineCode_C = new TaskOutlineCode_C();
			mp_bIsPublished = false;
			mp_sStatusManager = "";
			mp_dtCommitmentStart = new System.DateTime(0);
			mp_dtCommitmentFinish = new System.DateTime(0);
			mp_yCommitmentType = E_COMMITMENTTYPE.CT_THE_TASK_HAS_NO_DELIVERABLE_OR_DEPENDENCY_ON_A_DELIVERABLE;
			mp_bActive = false;
			mp_bPinned = false;
			mp_sPinnedStart = "";
			mp_sPinnedFinish = "";
			mp_sPinnedDuration = "";
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

		public int lID
		{
			get
			{
				return mp_lID;
			}
			set
			{
				mp_lID = value;
			}
		}

		public string sName
		{
			get
			{
				return mp_sName;
			}
			set
			{
				if (value.Length > 512)
				{
					value = value.Substring(0, 512);
				}
				mp_sName = value;
			}
		}

		public E_TYPE_4 yType
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

		public bool bIsNull
		{
			get
			{
				return mp_bIsNull;
			}
			set
			{
				mp_bIsNull = value;
			}
		}

		public System.DateTime dtCreateDate
		{
			get
			{
				return mp_dtCreateDate;
			}
			set
			{
				mp_dtCreateDate = value;
			}
		}

		public string sContact
		{
			get
			{
				return mp_sContact;
			}
			set
			{
				if (value.Length > 512)
				{
					value = value.Substring(0, 512);
				}
				mp_sContact = value;
			}
		}

		public string sWBS
		{
			get
			{
				return mp_sWBS;
			}
			set
			{
				mp_sWBS = value;
			}
		}

		public string sWBSLevel
		{
			get
			{
				return mp_sWBSLevel;
			}
			set
			{
				mp_sWBSLevel = value;
			}
		}

		public string sOutlineNumber
		{
			get
			{
				return mp_sOutlineNumber;
			}
			set
			{
				if (value.Length > 512)
				{
					value = value.Substring(0, 512);
				}
				mp_sOutlineNumber = value;
			}
		}

		public int lOutlineLevel
		{
			get
			{
				return mp_lOutlineLevel;
			}
			set
			{
				mp_lOutlineLevel = value;
			}
		}

		public int lPriority
		{
			get
			{
				return mp_lPriority;
			}
			set
			{
				mp_lPriority = value;
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

		public Duration oWork
		{
			get
			{
				return mp_oWork;
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

		public bool bResumeValid
		{
			get
			{
				return mp_bResumeValid;
			}
			set
			{
				mp_bResumeValid = value;
			}
		}

		public bool bEffortDriven
		{
			get
			{
				return mp_bEffortDriven;
			}
			set
			{
				mp_bEffortDriven = value;
			}
		}

		public bool bRecurring
		{
			get
			{
				return mp_bRecurring;
			}
			set
			{
				mp_bRecurring = value;
			}
		}

		public bool bOverAllocated
		{
			get
			{
				return mp_bOverAllocated;
			}
			set
			{
				mp_bOverAllocated = value;
			}
		}

		public bool bEstimated
		{
			get
			{
				return mp_bEstimated;
			}
			set
			{
				mp_bEstimated = value;
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

		public bool bSummary
		{
			get
			{
				return mp_bSummary;
			}
			set
			{
				mp_bSummary = value;
			}
		}

		public bool bDisplayAsSummary
		{
			get
			{
				return mp_bDisplayAsSummary;
			}
			set
			{
				mp_bDisplayAsSummary = value;
			}
		}

		public bool bCritical
		{
			get
			{
				return mp_bCritical;
			}
			set
			{
				mp_bCritical = value;
			}
		}

		public bool bIsSubproject
		{
			get
			{
				return mp_bIsSubproject;
			}
			set
			{
				mp_bIsSubproject = value;
			}
		}

		public bool bIsSubprojectReadOnly
		{
			get
			{
				return mp_bIsSubprojectReadOnly;
			}
			set
			{
				mp_bIsSubprojectReadOnly = value;
			}
		}

		public string sSubprojectName
		{
			get
			{
				return mp_sSubprojectName;
			}
			set
			{
				if (value.Length > 512)
				{
					value = value.Substring(0, 512);
				}
				mp_sSubprojectName = value;
			}
		}

		public bool bExternalTask
		{
			get
			{
				return mp_bExternalTask;
			}
			set
			{
				mp_bExternalTask = value;
			}
		}

		public string sExternalTaskProject
		{
			get
			{
				return mp_sExternalTaskProject;
			}
			set
			{
				if (value.Length > 512)
				{
					value = value.Substring(0, 512);
				}
				mp_sExternalTaskProject = value;
			}
		}

		public System.DateTime dtEarlyStart
		{
			get
			{
				return mp_dtEarlyStart;
			}
			set
			{
				mp_dtEarlyStart = value;
			}
		}

		public System.DateTime dtEarlyFinish
		{
			get
			{
				return mp_dtEarlyFinish;
			}
			set
			{
				mp_dtEarlyFinish = value;
			}
		}

		public System.DateTime dtLateStart
		{
			get
			{
				return mp_dtLateStart;
			}
			set
			{
				mp_dtLateStart = value;
			}
		}

		public System.DateTime dtLateFinish
		{
			get
			{
				return mp_dtLateFinish;
			}
			set
			{
				mp_dtLateFinish = value;
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

		public int lFreeSlack
		{
			get
			{
				return mp_lFreeSlack;
			}
			set
			{
				mp_lFreeSlack = value;
			}
		}

		public int lStartSlack
		{
			get
			{
				return mp_lStartSlack;
			}
			set
			{
				mp_lStartSlack = value;
			}
		}

		public int lFinishSlack
		{
			get
			{
				return mp_lFinishSlack;
			}
			set
			{
				mp_lFinishSlack = value;
			}
		}

		public int lTotalSlack
		{
			get
			{
				return mp_lTotalSlack;
			}
			set
			{
				mp_lTotalSlack = value;
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

		public E_FIXEDCOSTACCRUAL yFixedCostAccrual
		{
			get
			{
				return mp_yFixedCostAccrual;
			}
			set
			{
				mp_yFixedCostAccrual = value;
			}
		}

		public int lPercentComplete
		{
			get
			{
				return mp_lPercentComplete;
			}
			set
			{
				mp_lPercentComplete = value;
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

		public Duration oActualDuration
		{
			get
			{
				return mp_oActualDuration;
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

		public Duration oActualWork
		{
			get
			{
				return mp_oActualWork;
			}
		}

		public Duration oActualOvertimeWork
		{
			get
			{
				return mp_oActualOvertimeWork;
			}
		}

		public Duration oRegularWork
		{
			get
			{
				return mp_oRegularWork;
			}
		}

		public Duration oRemainingDuration
		{
			get
			{
				return mp_oRemainingDuration;
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

		public Duration oRemainingWork
		{
			get
			{
				return mp_oRemainingWork;
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

		public E_CONSTRAINTTYPE yConstraintType
		{
			get
			{
				return mp_yConstraintType;
			}
			set
			{
				mp_yConstraintType = value;
			}
		}

		public int lCalendarUID
		{
			get
			{
				return mp_lCalendarUID;
			}
			set
			{
				mp_lCalendarUID = value;
			}
		}

		public System.DateTime dtConstraintDate
		{
			get
			{
				return mp_dtConstraintDate;
			}
			set
			{
				mp_dtConstraintDate = value;
			}
		}

		public System.DateTime dtDeadline
		{
			get
			{
				return mp_dtDeadline;
			}
			set
			{
				mp_dtDeadline = value;
			}
		}

		public bool bLevelAssignments
		{
			get
			{
				return mp_bLevelAssignments;
			}
			set
			{
				mp_bLevelAssignments = value;
			}
		}

		public bool bLevelingCanSplit
		{
			get
			{
				return mp_bLevelingCanSplit;
			}
			set
			{
				mp_bLevelingCanSplit = value;
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

		public System.DateTime dtPreLeveledStart
		{
			get
			{
				return mp_dtPreLeveledStart;
			}
			set
			{
				mp_dtPreLeveledStart = value;
			}
		}

		public System.DateTime dtPreLeveledFinish
		{
			get
			{
				return mp_dtPreLeveledFinish;
			}
			set
			{
				mp_dtPreLeveledFinish = value;
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

		public bool bIgnoreResourceCalendar
		{
			get
			{
				return mp_bIgnoreResourceCalendar;
			}
			set
			{
				mp_bIgnoreResourceCalendar = value;
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

		public bool bHideBar
		{
			get
			{
				return mp_bHideBar;
			}
			set
			{
				mp_bHideBar = value;
			}
		}

		public bool bRollup
		{
			get
			{
				return mp_bRollup;
			}
			set
			{
				mp_bRollup = value;
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

		public int lPhysicalPercentComplete
		{
			get
			{
				return mp_lPhysicalPercentComplete;
			}
			set
			{
				mp_lPhysicalPercentComplete = value;
			}
		}

		public E_EARNEDVALUEMETHOD yEarnedValueMethod
		{
			get
			{
				return mp_yEarnedValueMethod;
			}
			set
			{
				mp_yEarnedValueMethod = value;
			}
		}

		public TaskPredecessorLink_C oPredecessorLink_C
		{
			get
			{
				return mp_oPredecessorLink_C;
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

		public TaskExtendedAttribute_C oExtendedAttribute_C
		{
			get
			{
				return mp_oExtendedAttribute_C;
			}
		}

		public TaskBaseline_C oBaseline_C
		{
			get
			{
				return mp_oBaseline_C;
			}
		}

		public TaskOutlineCode_C oOutlineCode_C
		{
			get
			{
				return mp_oOutlineCode_C;
			}
		}

		public bool bIsPublished
		{
			get
			{
				return mp_bIsPublished;
			}
			set
			{
				mp_bIsPublished = value;
			}
		}

		public string sStatusManager
		{
			get
			{
				return mp_sStatusManager;
			}
			set
			{
				mp_sStatusManager = value;
			}
		}

		public System.DateTime dtCommitmentStart
		{
			get
			{
				return mp_dtCommitmentStart;
			}
			set
			{
				mp_dtCommitmentStart = value;
			}
		}

		public System.DateTime dtCommitmentFinish
		{
			get
			{
				return mp_dtCommitmentFinish;
			}
			set
			{
				mp_dtCommitmentFinish = value;
			}
		}

		public E_COMMITMENTTYPE yCommitmentType
		{
			get
			{
				return mp_yCommitmentType;
			}
			set
			{
				mp_yCommitmentType = value;
			}
		}

		public bool bActive
		{
			get
			{
				return mp_bActive;
			}
			set
			{
				mp_bActive = value;
			}
		}

		public bool bPinned
		{
			get
			{
				return mp_bPinned;
			}
			set
			{
				mp_bPinned = value;
			}
		}

		public string sPinnedStart
		{
			get
			{
				return mp_sPinnedStart;
			}
			set
			{
				mp_sPinnedStart = value;
			}
		}

		public string sPinnedFinish
		{
			get
			{
				return mp_sPinnedFinish;
			}
			set
			{
				mp_sPinnedFinish = value;
			}
		}

		public string sPinnedDuration
		{
			get
			{
				return mp_sPinnedDuration;
			}
			set
			{
				mp_sPinnedDuration = value;
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
			if (mp_lID != 0)
			{
				bReturn = false;
			}
			if (mp_sName != "")
			{
				bReturn = false;
			}
			if (mp_yType != E_TYPE_4.T_4_FIXED_UNITS)
			{
				bReturn = false;
			}
			if (mp_bIsNull != false)
			{
				bReturn = false;
			}
			if (mp_dtCreateDate.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_sContact != "")
			{
				bReturn = false;
			}
			if (mp_sWBS != "")
			{
				bReturn = false;
			}
			if (mp_sWBSLevel != "")
			{
				bReturn = false;
			}
			if (mp_sOutlineNumber != "")
			{
				bReturn = false;
			}
			if (mp_lOutlineLevel != 0)
			{
				bReturn = false;
			}
			if (mp_lPriority != 0)
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
			if (mp_oWork.IsNull() == false)
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
			if (mp_bResumeValid != false)
			{
				bReturn = false;
			}
			if (mp_bEffortDriven != false)
			{
				bReturn = false;
			}
			if (mp_bRecurring != false)
			{
				bReturn = false;
			}
			if (mp_bOverAllocated != false)
			{
				bReturn = false;
			}
			if (mp_bEstimated != false)
			{
				bReturn = false;
			}
			if (mp_bMilestone != false)
			{
				bReturn = false;
			}
			if (mp_bSummary != false)
			{
				bReturn = false;
			}
			if (mp_bDisplayAsSummary != false)
			{
				bReturn = false;
			}
			if (mp_bCritical != false)
			{
				bReturn = false;
			}
			if (mp_bIsSubproject != false)
			{
				bReturn = false;
			}
			if (mp_bIsSubprojectReadOnly != false)
			{
				bReturn = false;
			}
			if (mp_sSubprojectName != "")
			{
				bReturn = false;
			}
			if (mp_bExternalTask != false)
			{
				bReturn = false;
			}
			if (mp_sExternalTaskProject != "")
			{
				bReturn = false;
			}
			if (mp_dtEarlyStart.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_dtEarlyFinish.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_dtLateStart.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_dtLateFinish.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_lStartVariance != 0)
			{
				bReturn = false;
			}
			if (mp_lFinishVariance != 0)
			{
				bReturn = false;
			}
			if (mp_fWorkVariance != 0)
			{
				bReturn = false;
			}
			if (mp_lFreeSlack != 0)
			{
				bReturn = false;
			}
			if (mp_lStartSlack != 0)
			{
				bReturn = false;
			}
			if (mp_lFinishSlack != 0)
			{
				bReturn = false;
			}
			if (mp_lTotalSlack != 0)
			{
				bReturn = false;
			}
			if (mp_fFixedCost != 0)
			{
				bReturn = false;
			}
			if (mp_yFixedCostAccrual != E_FIXEDCOSTACCRUAL.FCA_START)
			{
				bReturn = false;
			}
			if (mp_lPercentComplete != 0)
			{
				bReturn = false;
			}
			if (mp_lPercentWorkComplete != 0)
			{
				bReturn = false;
			}
			if (mp_cCost != 0)
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
			if (mp_dtActualStart.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_dtActualFinish.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_oActualDuration.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_cActualCost != 0)
			{
				bReturn = false;
			}
			if (mp_cActualOvertimeCost != 0)
			{
				bReturn = false;
			}
			if (mp_oActualWork.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_oActualOvertimeWork.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_oRegularWork.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_oRemainingDuration.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_cRemainingCost != 0)
			{
				bReturn = false;
			}
			if (mp_oRemainingWork.IsNull() == false)
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
			if (mp_fACWP != 0)
			{
				bReturn = false;
			}
			if (mp_fCV != 0)
			{
				bReturn = false;
			}
			if (mp_yConstraintType != E_CONSTRAINTTYPE.CT_AS_SOON_AS_POSSIBLE)
			{
				bReturn = false;
			}
			if (mp_lCalendarUID != 0)
			{
				bReturn = false;
			}
			if (mp_dtConstraintDate.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_dtDeadline.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_bLevelAssignments != false)
			{
				bReturn = false;
			}
			if (mp_bLevelingCanSplit != false)
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
			if (mp_dtPreLeveledStart.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_dtPreLeveledFinish.Ticks != 0)
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
			if (mp_bIgnoreResourceCalendar != false)
			{
				bReturn = false;
			}
			if (mp_sNotes != "")
			{
				bReturn = false;
			}
			if (mp_bHideBar != false)
			{
				bReturn = false;
			}
			if (mp_bRollup != false)
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
			if (mp_lPhysicalPercentComplete != 0)
			{
				bReturn = false;
			}
			if (mp_yEarnedValueMethod != E_EARNEDVALUEMETHOD.EVM_PERCENT_COMPLETE)
			{
				bReturn = false;
			}
			if (mp_oPredecessorLink_C.IsNull() == false)
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
			if (mp_oExtendedAttribute_C.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_oBaseline_C.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_oOutlineCode_C.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_bIsPublished != false)
			{
				bReturn = false;
			}
			if (mp_sStatusManager != "")
			{
				bReturn = false;
			}
			if (mp_dtCommitmentStart.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_dtCommitmentFinish.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_yCommitmentType != E_COMMITMENTTYPE.CT_THE_TASK_HAS_NO_DELIVERABLE_OR_DEPENDENCY_ON_A_DELIVERABLE)
			{
				bReturn = false;
			}
			if (mp_bActive != false)
			{
				bReturn = false;
			}
			if (mp_bPinned != false)
			{
				bReturn = false;
			}
			if (mp_sPinnedStart != "")
			{
				bReturn = false;
			}
			if (mp_sPinnedFinish != "")
			{
				bReturn = false;
			}
			if (mp_sPinnedDuration != "")
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
				return "<Task/>";
			}
			clsXML oXML = new clsXML("Task");
			oXML.InitializeWriter();
			oXML.SupportOptional = true;
			oXML.BoolsAreNumeric = true;
			oXML.WriteProperty("UID", mp_lUID);
			oXML.WriteProperty("ID", mp_lID);
			if (mp_sName != "")
			{
				oXML.WriteProperty("Name", mp_sName);
			}
			oXML.WriteProperty("Type", mp_yType);
			oXML.WriteProperty("IsNull", mp_bIsNull);
			if (mp_dtCreateDate.Ticks != 0)
			{
				oXML.WriteProperty("CreateDate", mp_dtCreateDate);
			}
			if (mp_sContact != "")
			{
				oXML.WriteProperty("Contact", mp_sContact);
			}
			if (mp_sWBS != "")
			{
				oXML.WriteProperty("WBS", mp_sWBS);
			}
			if (mp_sWBSLevel != "")
			{
				oXML.WriteProperty("WBSLevel", mp_sWBSLevel);
			}
			if (mp_sOutlineNumber != "")
			{
				oXML.WriteProperty("OutlineNumber", mp_sOutlineNumber);
			}
			oXML.WriteProperty("OutlineLevel", mp_lOutlineLevel);
			oXML.WriteProperty("Priority", mp_lPriority);
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
			oXML.WriteProperty("Work", mp_oWork);
			if (mp_dtStop.Ticks != 0)
			{
				oXML.WriteProperty("Stop", mp_dtStop);
			}
			if (mp_dtResume.Ticks != 0)
			{
				oXML.WriteProperty("Resume", mp_dtResume);
			}
			oXML.WriteProperty("ResumeValid", mp_bResumeValid);
			oXML.WriteProperty("EffortDriven", mp_bEffortDriven);
			oXML.WriteProperty("Recurring", mp_bRecurring);
			oXML.WriteProperty("OverAllocated", mp_bOverAllocated);
			oXML.WriteProperty("Estimated", mp_bEstimated);
			oXML.WriteProperty("Milestone", mp_bMilestone);
			oXML.WriteProperty("Summary", mp_bSummary);
			oXML.WriteProperty("DisplayAsSummary", mp_bDisplayAsSummary);
			oXML.WriteProperty("Critical", mp_bCritical);
			oXML.WriteProperty("IsSubproject", mp_bIsSubproject);
			oXML.WriteProperty("IsSubprojectReadOnly", mp_bIsSubprojectReadOnly);
			if (mp_sSubprojectName != "")
			{
				oXML.WriteProperty("SubprojectName", mp_sSubprojectName);
			}
			oXML.WriteProperty("ExternalTask", mp_bExternalTask);
			if (mp_sExternalTaskProject != "")
			{
				oXML.WriteProperty("ExternalTaskProject", mp_sExternalTaskProject);
			}
			if (mp_dtEarlyStart.Ticks != 0)
			{
				oXML.WriteProperty("EarlyStart", mp_dtEarlyStart);
			}
			if (mp_dtEarlyFinish.Ticks != 0)
			{
				oXML.WriteProperty("EarlyFinish", mp_dtEarlyFinish);
			}
			if (mp_dtLateStart.Ticks != 0)
			{
				oXML.WriteProperty("LateStart", mp_dtLateStart);
			}
			if (mp_dtLateFinish.Ticks != 0)
			{
				oXML.WriteProperty("LateFinish", mp_dtLateFinish);
			}
			oXML.WriteProperty("StartVariance", mp_lStartVariance);
			oXML.WriteProperty("FinishVariance", mp_lFinishVariance);
			oXML.WriteProperty("WorkVariance", mp_fWorkVariance);
			oXML.WriteProperty("FreeSlack", mp_lFreeSlack);
			oXML.WriteProperty("StartSlack", mp_lStartSlack);
			oXML.WriteProperty("FinishSlack", mp_lFinishSlack);
			oXML.WriteProperty("TotalSlack", mp_lTotalSlack);
			oXML.WriteProperty("FixedCost", mp_fFixedCost);
			oXML.WriteProperty("FixedCostAccrual", mp_yFixedCostAccrual);
			oXML.WriteProperty("PercentComplete", mp_lPercentComplete);
			oXML.WriteProperty("PercentWorkComplete", mp_lPercentWorkComplete);
			oXML.WriteProperty("Cost", mp_cCost);
			oXML.WriteProperty("OvertimeCost", mp_cOvertimeCost);
			oXML.WriteProperty("OvertimeWork", mp_oOvertimeWork);
			if (mp_dtActualStart.Ticks != 0)
			{
				oXML.WriteProperty("ActualStart", mp_dtActualStart);
			}
			if (mp_dtActualFinish.Ticks != 0)
			{
				oXML.WriteProperty("ActualFinish", mp_dtActualFinish);
			}
			oXML.WriteProperty("ActualDuration", mp_oActualDuration);
			oXML.WriteProperty("ActualCost", mp_cActualCost);
			oXML.WriteProperty("ActualOvertimeCost", mp_cActualOvertimeCost);
			oXML.WriteProperty("ActualWork", mp_oActualWork);
			oXML.WriteProperty("ActualOvertimeWork", mp_oActualOvertimeWork);
			oXML.WriteProperty("RegularWork", mp_oRegularWork);
			oXML.WriteProperty("RemainingDuration", mp_oRemainingDuration);
			oXML.WriteProperty("RemainingCost", mp_cRemainingCost);
			oXML.WriteProperty("RemainingWork", mp_oRemainingWork);
			oXML.WriteProperty("RemainingOvertimeCost", mp_cRemainingOvertimeCost);
			oXML.WriteProperty("RemainingOvertimeWork", mp_oRemainingOvertimeWork);
			oXML.WriteProperty("ACWP", mp_fACWP);
			oXML.WriteProperty("CV", mp_fCV);
			oXML.WriteProperty("ConstraintType", mp_yConstraintType);
			oXML.WriteProperty("CalendarUID", mp_lCalendarUID);
			if (mp_dtConstraintDate.Ticks != 0)
			{
				oXML.WriteProperty("ConstraintDate", mp_dtConstraintDate);
			}
			if (mp_dtDeadline.Ticks != 0)
			{
				oXML.WriteProperty("Deadline", mp_dtDeadline);
			}
			oXML.WriteProperty("LevelAssignments", mp_bLevelAssignments);
			oXML.WriteProperty("LevelingCanSplit", mp_bLevelingCanSplit);
			oXML.WriteProperty("LevelingDelay", mp_lLevelingDelay);
			oXML.WriteProperty("LevelingDelayFormat", mp_yLevelingDelayFormat);
			if (mp_dtPreLeveledStart.Ticks != 0)
			{
				oXML.WriteProperty("PreLeveledStart", mp_dtPreLeveledStart);
			}
			if (mp_dtPreLeveledFinish.Ticks != 0)
			{
				oXML.WriteProperty("PreLeveledFinish", mp_dtPreLeveledFinish);
			}
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
			oXML.WriteProperty("IgnoreResourceCalendar", mp_bIgnoreResourceCalendar);
			if (mp_sNotes != "")
			{
				oXML.WriteProperty("Notes", mp_sNotes);
			}
			oXML.WriteProperty("HideBar", mp_bHideBar);
			oXML.WriteProperty("Rollup", mp_bRollup);
			oXML.WriteProperty("BCWS", mp_fBCWS);
			oXML.WriteProperty("BCWP", mp_fBCWP);
			oXML.WriteProperty("PhysicalPercentComplete", mp_lPhysicalPercentComplete);
			oXML.WriteProperty("EarnedValueMethod", mp_yEarnedValueMethod);
			if (mp_oPredecessorLink_C.IsNull() == false)
			{
				mp_oPredecessorLink_C.WriteObjectProtected(ref oXML);
			}
			oXML.WriteProperty("ActualWorkProtected", mp_oActualWorkProtected);
			oXML.WriteProperty("ActualOvertimeWorkProtected", mp_oActualOvertimeWorkProtected);
			if (mp_oExtendedAttribute_C.IsNull() == false)
			{
				mp_oExtendedAttribute_C.WriteObjectProtected(ref oXML);
			}
			if (mp_oBaseline_C.IsNull() == false)
			{
				mp_oBaseline_C.WriteObjectProtected(ref oXML);
			}
			if (mp_oOutlineCode_C.IsNull() == false)
			{
				mp_oOutlineCode_C.WriteObjectProtected(ref oXML);
			}
			oXML.WriteProperty("IsPublished", mp_bIsPublished);
			if (mp_sStatusManager != "")
			{
				oXML.WriteProperty("StatusManager", mp_sStatusManager);
			}
			if (mp_dtCommitmentStart.Ticks != 0)
			{
				oXML.WriteProperty("CommitmentStart", mp_dtCommitmentStart);
			}
			if (mp_dtCommitmentFinish.Ticks != 0)
			{
				oXML.WriteProperty("CommitmentFinish", mp_dtCommitmentFinish);
			}
			oXML.WriteProperty("CommitmentType", mp_yCommitmentType);
			oXML.WriteProperty("Active", mp_bActive);
			oXML.WriteProperty("Pinned", mp_bPinned);
			if (mp_sPinnedStart != "")
			{
				oXML.WriteProperty("PinnedStart", mp_sPinnedStart);
			}
			if (mp_sPinnedFinish != "")
			{
				oXML.WriteProperty("PinnedFinish", mp_sPinnedFinish);
			}
			if (mp_sPinnedDuration != "")
			{
				oXML.WriteProperty("PinnedDuration", mp_sPinnedDuration);
			}
			if (mp_oTimephasedData_C.IsNull() == false)
			{
				mp_oTimephasedData_C.WriteObjectProtected(ref oXML);
			}
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML("Task");
			oXML.SupportOptional = true;
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("UID", ref mp_lUID);
			oXML.ReadProperty("ID", ref mp_lID);
			oXML.ReadProperty("Name", ref mp_sName);
			if (mp_sName.Length > 512)
			{
				mp_sName = mp_sName.Substring(0, 512);
			}
			oXML.ReadProperty("Type", ref mp_yType);
			oXML.ReadProperty("IsNull", ref mp_bIsNull);
			oXML.ReadProperty("CreateDate", ref mp_dtCreateDate);
			oXML.ReadProperty("Contact", ref mp_sContact);
			if (mp_sContact.Length > 512)
			{
				mp_sContact = mp_sContact.Substring(0, 512);
			}
			oXML.ReadProperty("WBS", ref mp_sWBS);
			oXML.ReadProperty("WBSLevel", ref mp_sWBSLevel);
			oXML.ReadProperty("OutlineNumber", ref mp_sOutlineNumber);
			if (mp_sOutlineNumber.Length > 512)
			{
				mp_sOutlineNumber = mp_sOutlineNumber.Substring(0, 512);
			}
			oXML.ReadProperty("OutlineLevel", ref mp_lOutlineLevel);
			oXML.ReadProperty("Priority", ref mp_lPriority);
			oXML.ReadProperty("Start", ref mp_dtStart);
			oXML.ReadProperty("Finish", ref mp_dtFinish);
			oXML.ReadProperty("Duration", ref mp_oDuration);
			oXML.ReadProperty("DurationFormat", ref mp_yDurationFormat);
			oXML.ReadProperty("Work", ref mp_oWork);
			oXML.ReadProperty("Stop", ref mp_dtStop);
			oXML.ReadProperty("Resume", ref mp_dtResume);
			oXML.ReadProperty("ResumeValid", ref mp_bResumeValid);
			oXML.ReadProperty("EffortDriven", ref mp_bEffortDriven);
			oXML.ReadProperty("Recurring", ref mp_bRecurring);
			oXML.ReadProperty("OverAllocated", ref mp_bOverAllocated);
			oXML.ReadProperty("Estimated", ref mp_bEstimated);
			oXML.ReadProperty("Milestone", ref mp_bMilestone);
			oXML.ReadProperty("Summary", ref mp_bSummary);
			oXML.ReadProperty("DisplayAsSummary", ref mp_bDisplayAsSummary);
			oXML.ReadProperty("Critical", ref mp_bCritical);
			oXML.ReadProperty("IsSubproject", ref mp_bIsSubproject);
			oXML.ReadProperty("IsSubprojectReadOnly", ref mp_bIsSubprojectReadOnly);
			oXML.ReadProperty("SubprojectName", ref mp_sSubprojectName);
			if (mp_sSubprojectName.Length > 512)
			{
				mp_sSubprojectName = mp_sSubprojectName.Substring(0, 512);
			}
			oXML.ReadProperty("ExternalTask", ref mp_bExternalTask);
			oXML.ReadProperty("ExternalTaskProject", ref mp_sExternalTaskProject);
			if (mp_sExternalTaskProject.Length > 512)
			{
				mp_sExternalTaskProject = mp_sExternalTaskProject.Substring(0, 512);
			}
			oXML.ReadProperty("EarlyStart", ref mp_dtEarlyStart);
			oXML.ReadProperty("EarlyFinish", ref mp_dtEarlyFinish);
			oXML.ReadProperty("LateStart", ref mp_dtLateStart);
			oXML.ReadProperty("LateFinish", ref mp_dtLateFinish);
			oXML.ReadProperty("StartVariance", ref mp_lStartVariance);
			oXML.ReadProperty("FinishVariance", ref mp_lFinishVariance);
			oXML.ReadProperty("WorkVariance", ref mp_fWorkVariance);
			oXML.ReadProperty("FreeSlack", ref mp_lFreeSlack);
			oXML.ReadProperty("StartSlack", ref mp_lStartSlack);
			oXML.ReadProperty("FinishSlack", ref mp_lFinishSlack);
			oXML.ReadProperty("TotalSlack", ref mp_lTotalSlack);
			oXML.ReadProperty("FixedCost", ref mp_fFixedCost);
			oXML.ReadProperty("FixedCostAccrual", ref mp_yFixedCostAccrual);
			oXML.ReadProperty("PercentComplete", ref mp_lPercentComplete);
			oXML.ReadProperty("PercentWorkComplete", ref mp_lPercentWorkComplete);
			oXML.ReadProperty("Cost", ref mp_cCost);
			oXML.ReadProperty("OvertimeCost", ref mp_cOvertimeCost);
			oXML.ReadProperty("OvertimeWork", ref mp_oOvertimeWork);
			oXML.ReadProperty("ActualStart", ref mp_dtActualStart);
			oXML.ReadProperty("ActualFinish", ref mp_dtActualFinish);
			oXML.ReadProperty("ActualDuration", ref mp_oActualDuration);
			oXML.ReadProperty("ActualCost", ref mp_cActualCost);
			oXML.ReadProperty("ActualOvertimeCost", ref mp_cActualOvertimeCost);
			oXML.ReadProperty("ActualWork", ref mp_oActualWork);
			oXML.ReadProperty("ActualOvertimeWork", ref mp_oActualOvertimeWork);
			oXML.ReadProperty("RegularWork", ref mp_oRegularWork);
			oXML.ReadProperty("RemainingDuration", ref mp_oRemainingDuration);
			oXML.ReadProperty("RemainingCost", ref mp_cRemainingCost);
			oXML.ReadProperty("RemainingWork", ref mp_oRemainingWork);
			oXML.ReadProperty("RemainingOvertimeCost", ref mp_cRemainingOvertimeCost);
			oXML.ReadProperty("RemainingOvertimeWork", ref mp_oRemainingOvertimeWork);
			oXML.ReadProperty("ACWP", ref mp_fACWP);
			oXML.ReadProperty("CV", ref mp_fCV);
			oXML.ReadProperty("ConstraintType", ref mp_yConstraintType);
			oXML.ReadProperty("CalendarUID", ref mp_lCalendarUID);
			oXML.ReadProperty("ConstraintDate", ref mp_dtConstraintDate);
			oXML.ReadProperty("Deadline", ref mp_dtDeadline);
			oXML.ReadProperty("LevelAssignments", ref mp_bLevelAssignments);
			oXML.ReadProperty("LevelingCanSplit", ref mp_bLevelingCanSplit);
			oXML.ReadProperty("LevelingDelay", ref mp_lLevelingDelay);
			oXML.ReadProperty("LevelingDelayFormat", ref mp_yLevelingDelayFormat);
			oXML.ReadProperty("PreLeveledStart", ref mp_dtPreLeveledStart);
			oXML.ReadProperty("PreLeveledFinish", ref mp_dtPreLeveledFinish);
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
			oXML.ReadProperty("IgnoreResourceCalendar", ref mp_bIgnoreResourceCalendar);
			oXML.ReadProperty("Notes", ref mp_sNotes);
			oXML.ReadProperty("HideBar", ref mp_bHideBar);
			oXML.ReadProperty("Rollup", ref mp_bRollup);
			oXML.ReadProperty("BCWS", ref mp_fBCWS);
			oXML.ReadProperty("BCWP", ref mp_fBCWP);
			oXML.ReadProperty("PhysicalPercentComplete", ref mp_lPhysicalPercentComplete);
			oXML.ReadProperty("EarnedValueMethod", ref mp_yEarnedValueMethod);
			mp_oPredecessorLink_C.ReadObjectProtected(ref oXML);
			oXML.ReadProperty("ActualWorkProtected", ref mp_oActualWorkProtected);
			oXML.ReadProperty("ActualOvertimeWorkProtected", ref mp_oActualOvertimeWorkProtected);
			mp_oExtendedAttribute_C.ReadObjectProtected(ref oXML);
			mp_oBaseline_C.ReadObjectProtected(ref oXML);
			mp_oOutlineCode_C.ReadObjectProtected(ref oXML);
			oXML.ReadProperty("IsPublished", ref mp_bIsPublished);
			oXML.ReadProperty("StatusManager", ref mp_sStatusManager);
			oXML.ReadProperty("CommitmentStart", ref mp_dtCommitmentStart);
			oXML.ReadProperty("CommitmentFinish", ref mp_dtCommitmentFinish);
			oXML.ReadProperty("CommitmentType", ref mp_yCommitmentType);
			oXML.ReadProperty("Active", ref mp_bActive);
			oXML.ReadProperty("Pinned", ref mp_bPinned);
			oXML.ReadProperty("PinnedStart", ref mp_sPinnedStart);
			oXML.ReadProperty("PinnedFinish", ref mp_sPinnedFinish);
			oXML.ReadProperty("PinnedDuration", ref mp_sPinnedDuration);
			mp_oTimephasedData_C.ReadObjectProtected(ref oXML);
		}

	}
}
