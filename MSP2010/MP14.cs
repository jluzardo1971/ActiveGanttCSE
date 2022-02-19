using System;

namespace MSP2010
{
	public class MP14
	{

		private int mp_lSaveVersion;
		private string mp_sUID;
		private string mp_sName;
		private string mp_sTitle;
		private string mp_sSubject;
		private string mp_sCategory;
		private string mp_sCompany;
		private string mp_sManager;
		private string mp_sAuthor;
		private System.DateTime mp_dtCreationDate;
		private int mp_lRevision;
		private System.DateTime mp_dtLastSaved;
		private bool mp_bScheduleFromStart;
		private System.DateTime mp_dtStartDate;
		private System.DateTime mp_dtFinishDate;
		private E_FYSTARTDATE mp_yFYStartDate;
		private int mp_lCriticalSlackLimit;
		private int mp_lCurrencyDigits;
		private string mp_sCurrencySymbol;
		private string mp_sCurrencyCode;
		private E_CURRENCYSYMBOLPOSITION mp_yCurrencySymbolPosition;
		private int mp_lCalendarUID;
		private Time mp_oDefaultStartTime;
		private Time mp_oDefaultFinishTime;
		private int mp_lMinutesPerDay;
		private int mp_lMinutesPerWeek;
		private int mp_lDaysPerMonth;
		private E_DEFAULTTASKTYPE mp_yDefaultTaskType;
		private E_DEFAULTFIXEDCOSTACCRUAL mp_yDefaultFixedCostAccrual;
		private float mp_fDefaultStandardRate;
		private float mp_fDefaultOvertimeRate;
		private E_DURATIONFORMAT mp_yDurationFormat;
		private E_WORKFORMAT mp_yWorkFormat;
		private bool mp_bEditableActualCosts;
		private bool mp_bHonorConstraints;
		private E_EARNEDVALUEMETHOD mp_yEarnedValueMethod;
		private bool mp_bInsertedProjectsLikeSummary;
		private bool mp_bMultipleCriticalPaths;
		private bool mp_bNewTasksEffortDriven;
		private bool mp_bNewTasksEstimated;
		private bool mp_bSplitsInProgressTasks;
		private bool mp_bSpreadActualCost;
		private bool mp_bSpreadPercentComplete;
		private bool mp_bTaskUpdatesResource;
		private bool mp_bFiscalYearStart;
		private E_WEEKSTARTDAY mp_yWeekStartDay;
		private bool mp_bMoveCompletedEndsBack;
		private bool mp_bMoveRemainingStartsBack;
		private bool mp_bMoveRemainingStartsForward;
		private bool mp_bMoveCompletedEndsForward;
		private E_BASELINEFOREARNEDVALUE mp_yBaselineForEarnedValue;
		private bool mp_bAutoAddNewResourcesAndTasks;
		private System.DateTime mp_dtStatusDate;
		private System.DateTime mp_dtCurrentDate;
		private bool mp_bMicrosoftProjectServerURL;
		private bool mp_bAutolink;
		private E_NEWTASKSTARTDATE mp_yNewTaskStartDate;
		private E_DEFAULTTASKEVMETHOD mp_yDefaultTaskEVMethod;
		private bool mp_bProjectExternallyEdited;
		private System.DateTime mp_dtExtendedCreationDate;
		private bool mp_bActualsInSync;
		private bool mp_bRemoveFileProperties;
		private bool mp_bAdminProject;
		private string mp_sBaslineCalendar;
		private bool mp_bNewTasksAreManual;
		private bool mp_bUpdateManuallyScheduledTasksWhenEditingLinks;
		private bool mp_bKeepTaskOnNearestWorkingTimeWhenMadeAutoScheduled;
		private OutlineCodes mp_oOutlineCodes;
		private WBSMasks mp_oWBSMasks;
		private ExtendedAttributes mp_oExtendedAttributes;
		private Calendars mp_oCalendars;
		private Tasks mp_oTasks;
		private Resources mp_oResources;
		private Assignments mp_oAssignments;

		public MP14()
		{
			mp_lSaveVersion = 0;
			mp_sUID = "";
			mp_sName = "";
			mp_sTitle = "";
			mp_sSubject = "";
			mp_sCategory = "";
			mp_sCompany = "";
			mp_sManager = "";
			mp_sAuthor = "";
			mp_dtCreationDate = new System.DateTime(0);
			mp_lRevision = 0;
			mp_dtLastSaved = new System.DateTime(0);
			mp_bScheduleFromStart = true;
			mp_dtStartDate = new System.DateTime(0);
			mp_dtFinishDate = new System.DateTime(0);
			mp_yFYStartDate = E_FYSTARTDATE.FYSD_JANUARY;
			mp_lCriticalSlackLimit = 0;
			mp_lCurrencyDigits = 0;
			mp_sCurrencySymbol = "";
			mp_sCurrencyCode = "";
			mp_yCurrencySymbolPosition = E_CURRENCYSYMBOLPOSITION.CSP_BEFORE;
			mp_lCalendarUID = 0;
			mp_oDefaultStartTime = new Time();
			mp_oDefaultFinishTime = new Time();
			mp_lMinutesPerDay = 0;
			mp_lMinutesPerWeek = 0;
			mp_lDaysPerMonth = 0;
			mp_yDefaultTaskType = E_DEFAULTTASKTYPE.DTT_FIXED_DURATION;
			mp_yDefaultFixedCostAccrual = E_DEFAULTFIXEDCOSTACCRUAL.DFCA_START;
			mp_fDefaultStandardRate = 0;
			mp_fDefaultOvertimeRate = 0;
			mp_yDurationFormat = E_DURATIONFORMAT.DF_M;
			mp_yWorkFormat = E_WORKFORMAT.WF_M;
			mp_bEditableActualCosts = false;
			mp_bHonorConstraints = true;
			mp_yEarnedValueMethod = E_EARNEDVALUEMETHOD.EVM_PERCENT_COMPLETE;
			mp_bInsertedProjectsLikeSummary = true;
			mp_bMultipleCriticalPaths = false;
			mp_bNewTasksEffortDriven = true;
			mp_bNewTasksEstimated = true;
			mp_bSplitsInProgressTasks = true;
			mp_bSpreadActualCost = true;
			mp_bSpreadPercentComplete = false;
			mp_bTaskUpdatesResource = false;
			mp_bFiscalYearStart = false;
			mp_yWeekStartDay = E_WEEKSTARTDAY.WSD_SUNDAY;
			mp_bMoveCompletedEndsBack = false;
			mp_bMoveRemainingStartsBack = false;
			mp_bMoveRemainingStartsForward = false;
			mp_bMoveCompletedEndsForward = false;
			mp_yBaselineForEarnedValue = E_BASELINEFOREARNEDVALUE.BFEV_BASELINE;
			mp_bAutoAddNewResourcesAndTasks = true;
			mp_dtStatusDate = new System.DateTime(0);
			mp_dtCurrentDate = new System.DateTime(0);
			mp_bMicrosoftProjectServerURL = false;
			mp_bAutolink = false;
			mp_yNewTaskStartDate = E_NEWTASKSTARTDATE.NTSD_PROJECT_START_DATE;
			mp_yDefaultTaskEVMethod = E_DEFAULTTASKEVMETHOD.DTEVM_PERCENT_COMPLETE;
			mp_bProjectExternallyEdited = false;
			mp_dtExtendedCreationDate = new System.DateTime(0);
			mp_bActualsInSync = false;
			mp_bRemoveFileProperties = false;
			mp_bAdminProject = false;
			mp_sBaslineCalendar = "";
			mp_bNewTasksAreManual = false;
			mp_bUpdateManuallyScheduledTasksWhenEditingLinks = false;
			mp_bKeepTaskOnNearestWorkingTimeWhenMadeAutoScheduled = false;
			mp_oOutlineCodes = new OutlineCodes();
			mp_oWBSMasks = new WBSMasks();
			mp_oExtendedAttributes = new ExtendedAttributes();
			mp_oCalendars = new Calendars();
			mp_oTasks = new Tasks();
			mp_oResources = new Resources();
			mp_oAssignments = new Assignments();
		}

		public int lSaveVersion
		{
			get
			{
				return mp_lSaveVersion;
			}
			set
			{
				mp_lSaveVersion = value;
			}
		}

		public string sUID
		{
			get
			{
				return mp_sUID;
			}
			set
			{
				if (value.Length > 16)
				{
					value = value.Substring(0, 16);
				}
				mp_sUID = value;
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
				if (value.Length > 255)
				{
					value = value.Substring(0, 255);
				}
				mp_sName = value;
			}
		}

		public string sTitle
		{
			get
			{
				return mp_sTitle;
			}
			set
			{
				if (value.Length > 512)
				{
					value = value.Substring(0, 512);
				}
				mp_sTitle = value;
			}
		}

		public string sSubject
		{
			get
			{
				return mp_sSubject;
			}
			set
			{
				if (value.Length > 512)
				{
					value = value.Substring(0, 512);
				}
				mp_sSubject = value;
			}
		}

		public string sCategory
		{
			get
			{
				return mp_sCategory;
			}
			set
			{
				if (value.Length > 512)
				{
					value = value.Substring(0, 512);
				}
				mp_sCategory = value;
			}
		}

		public string sCompany
		{
			get
			{
				return mp_sCompany;
			}
			set
			{
				if (value.Length > 512)
				{
					value = value.Substring(0, 512);
				}
				mp_sCompany = value;
			}
		}

		public string sManager
		{
			get
			{
				return mp_sManager;
			}
			set
			{
				if (value.Length > 512)
				{
					value = value.Substring(0, 512);
				}
				mp_sManager = value;
			}
		}

		public string sAuthor
		{
			get
			{
				return mp_sAuthor;
			}
			set
			{
				if (value.Length > 512)
				{
					value = value.Substring(0, 512);
				}
				mp_sAuthor = value;
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

		public int lRevision
		{
			get
			{
				return mp_lRevision;
			}
			set
			{
				mp_lRevision = value;
			}
		}

		public System.DateTime dtLastSaved
		{
			get
			{
				return mp_dtLastSaved;
			}
			set
			{
				mp_dtLastSaved = value;
			}
		}

		public bool bScheduleFromStart
		{
			get
			{
				return mp_bScheduleFromStart;
			}
			set
			{
				mp_bScheduleFromStart = value;
			}
		}

		public System.DateTime dtStartDate
		{
			get
			{
				return mp_dtStartDate;
			}
			set
			{
				mp_dtStartDate = value;
			}
		}

		public System.DateTime dtFinishDate
		{
			get
			{
				return mp_dtFinishDate;
			}
			set
			{
				mp_dtFinishDate = value;
			}
		}

		public E_FYSTARTDATE yFYStartDate
		{
			get
			{
				return mp_yFYStartDate;
			}
			set
			{
				mp_yFYStartDate = value;
			}
		}

		public int lCriticalSlackLimit
		{
			get
			{
				return mp_lCriticalSlackLimit;
			}
			set
			{
				mp_lCriticalSlackLimit = value;
			}
		}

		public int lCurrencyDigits
		{
			get
			{
				return mp_lCurrencyDigits;
			}
			set
			{
				mp_lCurrencyDigits = value;
			}
		}

		public string sCurrencySymbol
		{
			get
			{
				return mp_sCurrencySymbol;
			}
			set
			{
				if (value.Length > 20)
				{
					value = value.Substring(0, 20);
				}
				mp_sCurrencySymbol = value;
			}
		}

		public string sCurrencyCode
		{
			get
			{
				return mp_sCurrencyCode;
			}
			set
			{
				if (value.Length > 3)
				{
					value = value.Substring(0, 3);
				}
				mp_sCurrencyCode = value;
			}
		}

		public E_CURRENCYSYMBOLPOSITION yCurrencySymbolPosition
		{
			get
			{
				return mp_yCurrencySymbolPosition;
			}
			set
			{
				mp_yCurrencySymbolPosition = value;
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

		public Time oDefaultStartTime
		{
			get
			{
				return mp_oDefaultStartTime;
			}
		}

		public Time oDefaultFinishTime
		{
			get
			{
				return mp_oDefaultFinishTime;
			}
		}

		public int lMinutesPerDay
		{
			get
			{
				return mp_lMinutesPerDay;
			}
			set
			{
				mp_lMinutesPerDay = value;
			}
		}

		public int lMinutesPerWeek
		{
			get
			{
				return mp_lMinutesPerWeek;
			}
			set
			{
				mp_lMinutesPerWeek = value;
			}
		}

		public int lDaysPerMonth
		{
			get
			{
				return mp_lDaysPerMonth;
			}
			set
			{
				mp_lDaysPerMonth = value;
			}
		}

		public E_DEFAULTTASKTYPE yDefaultTaskType
		{
			get
			{
				return mp_yDefaultTaskType;
			}
			set
			{
				mp_yDefaultTaskType = value;
			}
		}

		public E_DEFAULTFIXEDCOSTACCRUAL yDefaultFixedCostAccrual
		{
			get
			{
				return mp_yDefaultFixedCostAccrual;
			}
			set
			{
				mp_yDefaultFixedCostAccrual = value;
			}
		}

		public float fDefaultStandardRate
		{
			get
			{
				return mp_fDefaultStandardRate;
			}
			set
			{
				mp_fDefaultStandardRate = value;
			}
		}

		public float fDefaultOvertimeRate
		{
			get
			{
				return mp_fDefaultOvertimeRate;
			}
			set
			{
				mp_fDefaultOvertimeRate = value;
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

		public E_WORKFORMAT yWorkFormat
		{
			get
			{
				return mp_yWorkFormat;
			}
			set
			{
				mp_yWorkFormat = value;
			}
		}

		public bool bEditableActualCosts
		{
			get
			{
				return mp_bEditableActualCosts;
			}
			set
			{
				mp_bEditableActualCosts = value;
			}
		}

		public bool bHonorConstraints
		{
			get
			{
				return mp_bHonorConstraints;
			}
			set
			{
				mp_bHonorConstraints = value;
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

		public bool bInsertedProjectsLikeSummary
		{
			get
			{
				return mp_bInsertedProjectsLikeSummary;
			}
			set
			{
				mp_bInsertedProjectsLikeSummary = value;
			}
		}

		public bool bMultipleCriticalPaths
		{
			get
			{
				return mp_bMultipleCriticalPaths;
			}
			set
			{
				mp_bMultipleCriticalPaths = value;
			}
		}

		public bool bNewTasksEffortDriven
		{
			get
			{
				return mp_bNewTasksEffortDriven;
			}
			set
			{
				mp_bNewTasksEffortDriven = value;
			}
		}

		public bool bNewTasksEstimated
		{
			get
			{
				return mp_bNewTasksEstimated;
			}
			set
			{
				mp_bNewTasksEstimated = value;
			}
		}

		public bool bSplitsInProgressTasks
		{
			get
			{
				return mp_bSplitsInProgressTasks;
			}
			set
			{
				mp_bSplitsInProgressTasks = value;
			}
		}

		public bool bSpreadActualCost
		{
			get
			{
				return mp_bSpreadActualCost;
			}
			set
			{
				mp_bSpreadActualCost = value;
			}
		}

		public bool bSpreadPercentComplete
		{
			get
			{
				return mp_bSpreadPercentComplete;
			}
			set
			{
				mp_bSpreadPercentComplete = value;
			}
		}

		public bool bTaskUpdatesResource
		{
			get
			{
				return mp_bTaskUpdatesResource;
			}
			set
			{
				mp_bTaskUpdatesResource = value;
			}
		}

		public bool bFiscalYearStart
		{
			get
			{
				return mp_bFiscalYearStart;
			}
			set
			{
				mp_bFiscalYearStart = value;
			}
		}

		public E_WEEKSTARTDAY yWeekStartDay
		{
			get
			{
				return mp_yWeekStartDay;
			}
			set
			{
				mp_yWeekStartDay = value;
			}
		}

		public bool bMoveCompletedEndsBack
		{
			get
			{
				return mp_bMoveCompletedEndsBack;
			}
			set
			{
				mp_bMoveCompletedEndsBack = value;
			}
		}

		public bool bMoveRemainingStartsBack
		{
			get
			{
				return mp_bMoveRemainingStartsBack;
			}
			set
			{
				mp_bMoveRemainingStartsBack = value;
			}
		}

		public bool bMoveRemainingStartsForward
		{
			get
			{
				return mp_bMoveRemainingStartsForward;
			}
			set
			{
				mp_bMoveRemainingStartsForward = value;
			}
		}

		public bool bMoveCompletedEndsForward
		{
			get
			{
				return mp_bMoveCompletedEndsForward;
			}
			set
			{
				mp_bMoveCompletedEndsForward = value;
			}
		}

		public E_BASELINEFOREARNEDVALUE yBaselineForEarnedValue
		{
			get
			{
				return mp_yBaselineForEarnedValue;
			}
			set
			{
				mp_yBaselineForEarnedValue = value;
			}
		}

		public bool bAutoAddNewResourcesAndTasks
		{
			get
			{
				return mp_bAutoAddNewResourcesAndTasks;
			}
			set
			{
				mp_bAutoAddNewResourcesAndTasks = value;
			}
		}

		public System.DateTime dtStatusDate
		{
			get
			{
				return mp_dtStatusDate;
			}
			set
			{
				mp_dtStatusDate = value;
			}
		}

		public System.DateTime dtCurrentDate
		{
			get
			{
				return mp_dtCurrentDate;
			}
			set
			{
				mp_dtCurrentDate = value;
			}
		}

		public bool bMicrosoftProjectServerURL
		{
			get
			{
				return mp_bMicrosoftProjectServerURL;
			}
			set
			{
				mp_bMicrosoftProjectServerURL = value;
			}
		}

		public bool bAutolink
		{
			get
			{
				return mp_bAutolink;
			}
			set
			{
				mp_bAutolink = value;
			}
		}

		public E_NEWTASKSTARTDATE yNewTaskStartDate
		{
			get
			{
				return mp_yNewTaskStartDate;
			}
			set
			{
				mp_yNewTaskStartDate = value;
			}
		}

		public E_DEFAULTTASKEVMETHOD yDefaultTaskEVMethod
		{
			get
			{
				return mp_yDefaultTaskEVMethod;
			}
			set
			{
				mp_yDefaultTaskEVMethod = value;
			}
		}

		public bool bProjectExternallyEdited
		{
			get
			{
				return mp_bProjectExternallyEdited;
			}
			set
			{
				mp_bProjectExternallyEdited = value;
			}
		}

		public System.DateTime dtExtendedCreationDate
		{
			get
			{
				return mp_dtExtendedCreationDate;
			}
			set
			{
				mp_dtExtendedCreationDate = value;
			}
		}

		public bool bActualsInSync
		{
			get
			{
				return mp_bActualsInSync;
			}
			set
			{
				mp_bActualsInSync = value;
			}
		}

		public bool bRemoveFileProperties
		{
			get
			{
				return mp_bRemoveFileProperties;
			}
			set
			{
				mp_bRemoveFileProperties = value;
			}
		}

		public bool bAdminProject
		{
			get
			{
				return mp_bAdminProject;
			}
			set
			{
				mp_bAdminProject = value;
			}
		}

		public string sBaslineCalendar
		{
			get
			{
				return mp_sBaslineCalendar;
			}
			set
			{
				mp_sBaslineCalendar = value;
			}
		}

		public bool bNewTasksAreManual
		{
			get
			{
				return mp_bNewTasksAreManual;
			}
			set
			{
				mp_bNewTasksAreManual = value;
			}
		}

		public bool bUpdateManuallyScheduledTasksWhenEditingLinks
		{
			get
			{
				return mp_bUpdateManuallyScheduledTasksWhenEditingLinks;
			}
			set
			{
				mp_bUpdateManuallyScheduledTasksWhenEditingLinks = value;
			}
		}

		public bool bKeepTaskOnNearestWorkingTimeWhenMadeAutoScheduled
		{
			get
			{
				return mp_bKeepTaskOnNearestWorkingTimeWhenMadeAutoScheduled;
			}
			set
			{
				mp_bKeepTaskOnNearestWorkingTimeWhenMadeAutoScheduled = value;
			}
		}

		public OutlineCodes oOutlineCodes
		{
			get
			{
				return mp_oOutlineCodes;
			}
		}

		public WBSMasks oWBSMasks
		{
			get
			{
				return mp_oWBSMasks;
			}
		}

		public ExtendedAttributes oExtendedAttributes
		{
			get
			{
				return mp_oExtendedAttributes;
			}
		}

		public Calendars oCalendars
		{
			get
			{
				return mp_oCalendars;
			}
		}

		public Tasks oTasks
		{
			get
			{
				return mp_oTasks;
			}
		}

		public Resources oResources
		{
			get
			{
				return mp_oResources;
			}
		}

		public Assignments oAssignments
		{
			get
			{
				return mp_oAssignments;
			}
		}

		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML("Project");
			oXML.SetXML(sXML);
			mp_ReadXML(ref oXML);
		}

		public string GetXML()
		{
			clsXML oXML = new clsXML("Project");
			mp_WriteXML(ref oXML);
			return oXML.GetXML();
		}

		public bool IsNull()
		{
			bool bReturn = true;
			if (mp_lSaveVersion != 0)
			{
				bReturn = false;
			}
			if (mp_sUID != "")
			{
				bReturn = false;
			}
			if (mp_sName != "")
			{
				bReturn = false;
			}
			if (mp_sTitle != "")
			{
				bReturn = false;
			}
			if (mp_sSubject != "")
			{
				bReturn = false;
			}
			if (mp_sCategory != "")
			{
				bReturn = false;
			}
			if (mp_sCompany != "")
			{
				bReturn = false;
			}
			if (mp_sManager != "")
			{
				bReturn = false;
			}
			if (mp_sAuthor != "")
			{
				bReturn = false;
			}
			if (mp_dtCreationDate.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_lRevision != 0)
			{
				bReturn = false;
			}
			if (mp_dtLastSaved.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_bScheduleFromStart != true)
			{
				bReturn = false;
			}
			if (mp_dtStartDate.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_dtFinishDate.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_yFYStartDate != E_FYSTARTDATE.FYSD_JANUARY)
			{
				bReturn = false;
			}
			if (mp_lCriticalSlackLimit != 0)
			{
				bReturn = false;
			}
			if (mp_lCurrencyDigits != 0)
			{
				bReturn = false;
			}
			if (mp_sCurrencySymbol != "")
			{
				bReturn = false;
			}
			if (mp_sCurrencyCode != "")
			{
				bReturn = false;
			}
			if (mp_yCurrencySymbolPosition != E_CURRENCYSYMBOLPOSITION.CSP_BEFORE)
			{
				bReturn = false;
			}
			if (mp_lCalendarUID != 0)
			{
				bReturn = false;
			}
			if (mp_oDefaultStartTime.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_oDefaultFinishTime.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_lMinutesPerDay != 0)
			{
				bReturn = false;
			}
			if (mp_lMinutesPerWeek != 0)
			{
				bReturn = false;
			}
			if (mp_lDaysPerMonth != 0)
			{
				bReturn = false;
			}
			if (mp_yDefaultTaskType != E_DEFAULTTASKTYPE.DTT_FIXED_DURATION)
			{
				bReturn = false;
			}
			if (mp_yDefaultFixedCostAccrual != E_DEFAULTFIXEDCOSTACCRUAL.DFCA_START)
			{
				bReturn = false;
			}
			if (mp_fDefaultStandardRate != 0)
			{
				bReturn = false;
			}
			if (mp_fDefaultOvertimeRate != 0)
			{
				bReturn = false;
			}
			if (mp_yDurationFormat != E_DURATIONFORMAT.DF_M)
			{
				bReturn = false;
			}
			if (mp_yWorkFormat != E_WORKFORMAT.WF_M)
			{
				bReturn = false;
			}
			if (mp_bEditableActualCosts != false)
			{
				bReturn = false;
			}
			if (mp_bHonorConstraints != true)
			{
				bReturn = false;
			}
			if (mp_yEarnedValueMethod != E_EARNEDVALUEMETHOD.EVM_PERCENT_COMPLETE)
			{
				bReturn = false;
			}
			if (mp_bInsertedProjectsLikeSummary != true)
			{
				bReturn = false;
			}
			if (mp_bMultipleCriticalPaths != false)
			{
				bReturn = false;
			}
			if (mp_bNewTasksEffortDriven != true)
			{
				bReturn = false;
			}
			if (mp_bNewTasksEstimated != true)
			{
				bReturn = false;
			}
			if (mp_bSplitsInProgressTasks != true)
			{
				bReturn = false;
			}
			if (mp_bSpreadActualCost != true)
			{
				bReturn = false;
			}
			if (mp_bSpreadPercentComplete != false)
			{
				bReturn = false;
			}
			if (mp_bTaskUpdatesResource != false)
			{
				bReturn = false;
			}
			if (mp_bFiscalYearStart != false)
			{
				bReturn = false;
			}
			if (mp_yWeekStartDay != E_WEEKSTARTDAY.WSD_SUNDAY)
			{
				bReturn = false;
			}
			if (mp_bMoveCompletedEndsBack != false)
			{
				bReturn = false;
			}
			if (mp_bMoveRemainingStartsBack != false)
			{
				bReturn = false;
			}
			if (mp_bMoveRemainingStartsForward != false)
			{
				bReturn = false;
			}
			if (mp_bMoveCompletedEndsForward != false)
			{
				bReturn = false;
			}
			if (mp_yBaselineForEarnedValue != E_BASELINEFOREARNEDVALUE.BFEV_BASELINE)
			{
				bReturn = false;
			}
			if (mp_bAutoAddNewResourcesAndTasks != true)
			{
				bReturn = false;
			}
			if (mp_dtStatusDate.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_dtCurrentDate.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_bMicrosoftProjectServerURL != false)
			{
				bReturn = false;
			}
			if (mp_bAutolink != false)
			{
				bReturn = false;
			}
			if (mp_yNewTaskStartDate != E_NEWTASKSTARTDATE.NTSD_PROJECT_START_DATE)
			{
				bReturn = false;
			}
			if (mp_yDefaultTaskEVMethod != E_DEFAULTTASKEVMETHOD.DTEVM_PERCENT_COMPLETE)
			{
				bReturn = false;
			}
			if (mp_bProjectExternallyEdited != false)
			{
				bReturn = false;
			}
			if (mp_dtExtendedCreationDate.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_bActualsInSync != false)
			{
				bReturn = false;
			}
			if (mp_bRemoveFileProperties != false)
			{
				bReturn = false;
			}
			if (mp_bAdminProject != false)
			{
				bReturn = false;
			}
			if (mp_sBaslineCalendar != "")
			{
				bReturn = false;
			}
			if (mp_bNewTasksAreManual != false)
			{
				bReturn = false;
			}
			if (mp_bUpdateManuallyScheduledTasksWhenEditingLinks != false)
			{
				bReturn = false;
			}
			if (mp_bKeepTaskOnNearestWorkingTimeWhenMadeAutoScheduled != false)
			{
				bReturn = false;
			}
			if (mp_oOutlineCodes.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_oWBSMasks.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_oExtendedAttributes.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_oCalendars.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_oTasks.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_oResources.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_oAssignments.IsNull() == false)
			{
				bReturn = false;
			}
			return bReturn;
		}

		private void mp_WriteXML(ref clsXML oXML)
		{
			oXML.InitializeWriter();
			oXML.AddAttribute("xmlns", "http://schemas.microsoft.com/project");
			oXML.SupportOptional = true;
			oXML.BoolsAreNumeric = true;
			oXML.WriteProperty("SaveVersion", mp_lSaveVersion);
			if (mp_sUID != "")
			{
				oXML.WriteProperty("UID", mp_sUID);
			}
			if (mp_sName != "")
			{
				oXML.WriteProperty("Name", mp_sName);
			}
			if (mp_sTitle != "")
			{
				oXML.WriteProperty("Title", mp_sTitle);
			}
			if (mp_sSubject != "")
			{
				oXML.WriteProperty("Subject", mp_sSubject);
			}
			if (mp_sCategory != "")
			{
				oXML.WriteProperty("Category", mp_sCategory);
			}
			if (mp_sCompany != "")
			{
				oXML.WriteProperty("Company", mp_sCompany);
			}
			if (mp_sManager != "")
			{
				oXML.WriteProperty("Manager", mp_sManager);
			}
			if (mp_sAuthor != "")
			{
				oXML.WriteProperty("Author", mp_sAuthor);
			}
			if (mp_dtCreationDate.Ticks != 0)
			{
				oXML.WriteProperty("CreationDate", mp_dtCreationDate);
			}
			oXML.WriteProperty("Revision", mp_lRevision);
			if (mp_dtLastSaved.Ticks != 0)
			{
				oXML.WriteProperty("LastSaved", mp_dtLastSaved);
			}
			oXML.WriteProperty("ScheduleFromStart", mp_bScheduleFromStart);
			if (mp_dtStartDate.Ticks != 0)
			{
				oXML.WriteProperty("StartDate", mp_dtStartDate);
			}
			if (mp_dtFinishDate.Ticks != 0)
			{
				oXML.WriteProperty("FinishDate", mp_dtFinishDate);
			}
			oXML.WriteProperty("FYStartDate", mp_yFYStartDate);
			oXML.WriteProperty("CriticalSlackLimit", mp_lCriticalSlackLimit);
			oXML.WriteProperty("CurrencyDigits", mp_lCurrencyDigits);
			if (mp_sCurrencySymbol != "")
			{
				oXML.WriteProperty("CurrencySymbol", mp_sCurrencySymbol);
			}
			oXML.WriteProperty("CurrencyCode", mp_sCurrencyCode);
			oXML.WriteProperty("CurrencySymbolPosition", mp_yCurrencySymbolPosition);
			oXML.WriteProperty("CalendarUID", mp_lCalendarUID);
			if (mp_oDefaultStartTime.IsNull() == false)
			{
				oXML.WriteProperty("DefaultStartTime", mp_oDefaultStartTime);
			}
			if (mp_oDefaultFinishTime.IsNull() == false)
			{
				oXML.WriteProperty("DefaultFinishTime", mp_oDefaultFinishTime);
			}
			oXML.WriteProperty("MinutesPerDay", mp_lMinutesPerDay);
			oXML.WriteProperty("MinutesPerWeek", mp_lMinutesPerWeek);
			oXML.WriteProperty("DaysPerMonth", mp_lDaysPerMonth);
			oXML.WriteProperty("DefaultTaskType", mp_yDefaultTaskType);
			oXML.WriteProperty("DefaultFixedCostAccrual", mp_yDefaultFixedCostAccrual);
			oXML.WriteProperty("DefaultStandardRate", mp_fDefaultStandardRate);
			oXML.WriteProperty("DefaultOvertimeRate", mp_fDefaultOvertimeRate);
			oXML.WriteProperty("DurationFormat", mp_yDurationFormat);
			oXML.WriteProperty("WorkFormat", mp_yWorkFormat);
			oXML.WriteProperty("EditableActualCosts", mp_bEditableActualCosts);
			oXML.WriteProperty("HonorConstraints", mp_bHonorConstraints);
			oXML.WriteProperty("EarnedValueMethod", mp_yEarnedValueMethod);
			oXML.WriteProperty("InsertedProjectsLikeSummary", mp_bInsertedProjectsLikeSummary);
			oXML.WriteProperty("MultipleCriticalPaths", mp_bMultipleCriticalPaths);
			oXML.WriteProperty("NewTasksEffortDriven", mp_bNewTasksEffortDriven);
			oXML.WriteProperty("NewTasksEstimated", mp_bNewTasksEstimated);
			oXML.WriteProperty("SplitsInProgressTasks", mp_bSplitsInProgressTasks);
			oXML.WriteProperty("SpreadActualCost", mp_bSpreadActualCost);
			oXML.WriteProperty("SpreadPercentComplete", mp_bSpreadPercentComplete);
			oXML.WriteProperty("TaskUpdatesResource", mp_bTaskUpdatesResource);
			oXML.WriteProperty("FiscalYearStart", mp_bFiscalYearStart);
			oXML.WriteProperty("WeekStartDay", mp_yWeekStartDay);
			oXML.WriteProperty("MoveCompletedEndsBack", mp_bMoveCompletedEndsBack);
			oXML.WriteProperty("MoveRemainingStartsBack", mp_bMoveRemainingStartsBack);
			oXML.WriteProperty("MoveRemainingStartsForward", mp_bMoveRemainingStartsForward);
			oXML.WriteProperty("MoveCompletedEndsForward", mp_bMoveCompletedEndsForward);
			oXML.WriteProperty("BaselineForEarnedValue", mp_yBaselineForEarnedValue);
			oXML.WriteProperty("AutoAddNewResourcesAndTasks", mp_bAutoAddNewResourcesAndTasks);
			if (mp_dtStatusDate.Ticks != 0)
			{
				oXML.WriteProperty("StatusDate", mp_dtStatusDate);
			}
			if (mp_dtCurrentDate.Ticks != 0)
			{
				oXML.WriteProperty("CurrentDate", mp_dtCurrentDate);
			}
			oXML.WriteProperty("MicrosoftProjectServerURL", mp_bMicrosoftProjectServerURL);
			oXML.WriteProperty("Autolink", mp_bAutolink);
			oXML.WriteProperty("NewTaskStartDate", mp_yNewTaskStartDate);
			oXML.WriteProperty("DefaultTaskEVMethod", mp_yDefaultTaskEVMethod);
			oXML.WriteProperty("ProjectExternallyEdited", mp_bProjectExternallyEdited);
			if (mp_dtExtendedCreationDate.Ticks != 0)
			{
				oXML.WriteProperty("ExtendedCreationDate", mp_dtExtendedCreationDate);
			}
			oXML.WriteProperty("ActualsInSync", mp_bActualsInSync);
			oXML.WriteProperty("RemoveFileProperties", mp_bRemoveFileProperties);
			oXML.WriteProperty("AdminProject", mp_bAdminProject);
			if (mp_sBaslineCalendar != "")
			{
				oXML.WriteProperty("BaslineCalendar", mp_sBaslineCalendar);
			}
			oXML.WriteProperty("NewTasksAreManual", mp_bNewTasksAreManual);
			oXML.WriteProperty("UpdateManuallyScheduledTasksWhenEditingLinks", mp_bUpdateManuallyScheduledTasksWhenEditingLinks);
			oXML.WriteProperty("KeepTaskOnNearestWorkingTimeWhenMadeAutoScheduled", mp_bKeepTaskOnNearestWorkingTimeWhenMadeAutoScheduled);
			oXML.WriteObject(mp_oOutlineCodes.GetXML());
			oXML.WriteObject(mp_oWBSMasks.GetXML());
			oXML.WriteObject(mp_oExtendedAttributes.GetXML());
			oXML.WriteObject(mp_oCalendars.GetXML());
			oXML.WriteObject(mp_oTasks.GetXML());
			oXML.WriteObject(mp_oResources.GetXML());
			oXML.WriteObject(mp_oAssignments.GetXML());
		}

		private void mp_ReadXML(ref clsXML oXML)
		{
			oXML.SupportOptional = true;
			oXML.InitializeReader();
			oXML.ReadProperty("SaveVersion", ref mp_lSaveVersion);
			oXML.ReadProperty("UID", ref mp_sUID);
			if (mp_sUID.Length > 16)
			{
				mp_sUID = mp_sUID.Substring(0, 16);
			}
			oXML.ReadProperty("Name", ref mp_sName);
			if (mp_sName.Length > 255)
			{
				mp_sName = mp_sName.Substring(0, 255);
			}
			oXML.ReadProperty("Title", ref mp_sTitle);
			if (mp_sTitle.Length > 512)
			{
				mp_sTitle = mp_sTitle.Substring(0, 512);
			}
			oXML.ReadProperty("Subject", ref mp_sSubject);
			if (mp_sSubject.Length > 512)
			{
				mp_sSubject = mp_sSubject.Substring(0, 512);
			}
			oXML.ReadProperty("Category", ref mp_sCategory);
			if (mp_sCategory.Length > 512)
			{
				mp_sCategory = mp_sCategory.Substring(0, 512);
			}
			oXML.ReadProperty("Company", ref mp_sCompany);
			if (mp_sCompany.Length > 512)
			{
				mp_sCompany = mp_sCompany.Substring(0, 512);
			}
			oXML.ReadProperty("Manager", ref mp_sManager);
			if (mp_sManager.Length > 512)
			{
				mp_sManager = mp_sManager.Substring(0, 512);
			}
			oXML.ReadProperty("Author", ref mp_sAuthor);
			if (mp_sAuthor.Length > 512)
			{
				mp_sAuthor = mp_sAuthor.Substring(0, 512);
			}
			oXML.ReadProperty("CreationDate", ref mp_dtCreationDate);
			oXML.ReadProperty("Revision", ref mp_lRevision);
			oXML.ReadProperty("LastSaved", ref mp_dtLastSaved);
			oXML.ReadProperty("ScheduleFromStart", ref mp_bScheduleFromStart);
			oXML.ReadProperty("StartDate", ref mp_dtStartDate);
			oXML.ReadProperty("FinishDate", ref mp_dtFinishDate);
			oXML.ReadProperty("FYStartDate", ref mp_yFYStartDate);
			oXML.ReadProperty("CriticalSlackLimit", ref mp_lCriticalSlackLimit);
			oXML.ReadProperty("CurrencyDigits", ref mp_lCurrencyDigits);
			oXML.ReadProperty("CurrencySymbol", ref mp_sCurrencySymbol);
			if (mp_sCurrencySymbol.Length > 20)
			{
				mp_sCurrencySymbol = mp_sCurrencySymbol.Substring(0, 20);
			}
			oXML.ReadProperty("CurrencyCode", ref mp_sCurrencyCode);
			if (mp_sCurrencyCode.Length > 3)
			{
				mp_sCurrencyCode = mp_sCurrencyCode.Substring(0, 3);
			}
			oXML.ReadProperty("CurrencySymbolPosition", ref mp_yCurrencySymbolPosition);
			oXML.ReadProperty("CalendarUID", ref mp_lCalendarUID);
			oXML.ReadProperty("DefaultStartTime", ref mp_oDefaultStartTime);
			oXML.ReadProperty("DefaultFinishTime", ref mp_oDefaultFinishTime);
			oXML.ReadProperty("MinutesPerDay", ref mp_lMinutesPerDay);
			oXML.ReadProperty("MinutesPerWeek", ref mp_lMinutesPerWeek);
			oXML.ReadProperty("DaysPerMonth", ref mp_lDaysPerMonth);
			oXML.ReadProperty("DefaultTaskType", ref mp_yDefaultTaskType);
			oXML.ReadProperty("DefaultFixedCostAccrual", ref mp_yDefaultFixedCostAccrual);
			oXML.ReadProperty("DefaultStandardRate", ref mp_fDefaultStandardRate);
			oXML.ReadProperty("DefaultOvertimeRate", ref mp_fDefaultOvertimeRate);
			oXML.ReadProperty("DurationFormat", ref mp_yDurationFormat);
			oXML.ReadProperty("WorkFormat", ref mp_yWorkFormat);
			oXML.ReadProperty("EditableActualCosts", ref mp_bEditableActualCosts);
			oXML.ReadProperty("HonorConstraints", ref mp_bHonorConstraints);
			oXML.ReadProperty("EarnedValueMethod", ref mp_yEarnedValueMethod);
			oXML.ReadProperty("InsertedProjectsLikeSummary", ref mp_bInsertedProjectsLikeSummary);
			oXML.ReadProperty("MultipleCriticalPaths", ref mp_bMultipleCriticalPaths);
			oXML.ReadProperty("NewTasksEffortDriven", ref mp_bNewTasksEffortDriven);
			oXML.ReadProperty("NewTasksEstimated", ref mp_bNewTasksEstimated);
			oXML.ReadProperty("SplitsInProgressTasks", ref mp_bSplitsInProgressTasks);
			oXML.ReadProperty("SpreadActualCost", ref mp_bSpreadActualCost);
			oXML.ReadProperty("SpreadPercentComplete", ref mp_bSpreadPercentComplete);
			oXML.ReadProperty("TaskUpdatesResource", ref mp_bTaskUpdatesResource);
			oXML.ReadProperty("FiscalYearStart", ref mp_bFiscalYearStart);
			oXML.ReadProperty("WeekStartDay", ref mp_yWeekStartDay);
			oXML.ReadProperty("MoveCompletedEndsBack", ref mp_bMoveCompletedEndsBack);
			oXML.ReadProperty("MoveRemainingStartsBack", ref mp_bMoveRemainingStartsBack);
			oXML.ReadProperty("MoveRemainingStartsForward", ref mp_bMoveRemainingStartsForward);
			oXML.ReadProperty("MoveCompletedEndsForward", ref mp_bMoveCompletedEndsForward);
			oXML.ReadProperty("BaselineForEarnedValue", ref mp_yBaselineForEarnedValue);
			oXML.ReadProperty("AutoAddNewResourcesAndTasks", ref mp_bAutoAddNewResourcesAndTasks);
			oXML.ReadProperty("StatusDate", ref mp_dtStatusDate);
			oXML.ReadProperty("CurrentDate", ref mp_dtCurrentDate);
			oXML.ReadProperty("MicrosoftProjectServerURL", ref mp_bMicrosoftProjectServerURL);
			oXML.ReadProperty("Autolink", ref mp_bAutolink);
			oXML.ReadProperty("NewTaskStartDate", ref mp_yNewTaskStartDate);
			oXML.ReadProperty("DefaultTaskEVMethod", ref mp_yDefaultTaskEVMethod);
			oXML.ReadProperty("ProjectExternallyEdited", ref mp_bProjectExternallyEdited);
			oXML.ReadProperty("ExtendedCreationDate", ref mp_dtExtendedCreationDate);
			oXML.ReadProperty("ActualsInSync", ref mp_bActualsInSync);
			oXML.ReadProperty("RemoveFileProperties", ref mp_bRemoveFileProperties);
			oXML.ReadProperty("AdminProject", ref mp_bAdminProject);
			oXML.ReadProperty("BaslineCalendar", ref mp_sBaslineCalendar);
			oXML.ReadProperty("NewTasksAreManual", ref mp_bNewTasksAreManual);
			oXML.ReadProperty("UpdateManuallyScheduledTasksWhenEditingLinks", ref mp_bUpdateManuallyScheduledTasksWhenEditingLinks);
			oXML.ReadProperty("KeepTaskOnNearestWorkingTimeWhenMadeAutoScheduled", ref mp_bKeepTaskOnNearestWorkingTimeWhenMadeAutoScheduled);
			mp_oOutlineCodes.SetXML(oXML.ReadObject("OutlineCodes"));
			mp_oWBSMasks.SetXML(oXML.ReadObject("WBSMasks"));
			mp_oExtendedAttributes.SetXML(oXML.ReadObject("ExtendedAttributes"));
			mp_oCalendars.SetXML(oXML.ReadObject("Calendars"));
			mp_oTasks.SetXML(oXML.ReadObject("Tasks"));
			mp_oResources.SetXML(oXML.ReadObject("Resources"));
			mp_oAssignments.SetXML(oXML.ReadObject("Assignments"));
		}

	}
}
