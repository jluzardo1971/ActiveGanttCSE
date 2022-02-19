using System;

namespace MSP2007
{
	public class Resource : clsItemBase
	{

		internal clsCollectionBase mp_oCollection;
		private int mp_lUID;
		private int mp_lID;
		private string mp_sName;
		private E_TYPE_6 mp_yType;
		private bool mp_bIsNull;
		private string mp_sInitials;
		private string mp_sPhonetics;
		private string mp_sNTAccount;
		private string mp_sMaterialLabel;
		private string mp_sCode;
		private string mp_sGroup;
		private E_WORKGROUP mp_yWorkGroup;
		private string mp_sEmailAddress;
		private string mp_sHyperlink;
		private string mp_sHyperlinkAddress;
		private string mp_sHyperlinkSubAddress;
		private float mp_fMaxUnits;
		private float mp_fPeakUnits;
		private bool mp_bOverAllocated;
		private System.DateTime mp_dtAvailableFrom;
		private System.DateTime mp_dtAvailableTo;
		private System.DateTime mp_dtStart;
		private System.DateTime mp_dtFinish;
		private bool mp_bCanLevel;
		private E_ACCRUEAT mp_yAccrueAt;
		private Duration mp_oWork;
		private Duration mp_oRegularWork;
		private Duration mp_oOvertimeWork;
		private Duration mp_oActualWork;
		private Duration mp_oRemainingWork;
		private Duration mp_oActualOvertimeWork;
		private Duration mp_oRemainingOvertimeWork;
		private int mp_lPercentWorkComplete;
		private Decimal mp_cStandardRate;
		private E_STANDARDRATEFORMAT mp_yStandardRateFormat;
		private Decimal mp_cCost;
		private Decimal mp_cOvertimeRate;
		private E_OVERTIMERATEFORMAT mp_yOvertimeRateFormat;
		private Decimal mp_cOvertimeCost;
		private Decimal mp_cCostPerUse;
		private Decimal mp_cActualCost;
		private Decimal mp_cActualOvertimeCost;
		private Decimal mp_cRemainingCost;
		private Decimal mp_cRemainingOvertimeCost;
		private float mp_fWorkVariance;
		private float mp_fCostVariance;
		private float mp_fSV;
		private float mp_fCV;
		private float mp_fACWP;
		private int mp_lCalendarUID;
		private string mp_sNotes;
		private float mp_fBCWS;
		private float mp_fBCWP;
		private bool mp_bIsGeneric;
		private bool mp_bIsInactive;
		private bool mp_bIsEnterprise;
		private E_BOOKINGTYPE mp_yBookingType;
		private Duration mp_oActualWorkProtected;
		private Duration mp_oActualOvertimeWorkProtected;
		private string mp_sActiveDirectoryGUID;
		private System.DateTime mp_dtCreationDate;
		private ResourceExtendedAttribute_C mp_oExtendedAttribute_C;
		private ResourceBaseline_C mp_oBaseline_C;
		private ResourceOutlineCode_C mp_oOutlineCode_C;
		private bool mp_bIsCostResource;
		private string mp_sAssnOwner;
		private string mp_sAssnOwnerGuid;
		private bool mp_bIsBudget;
		private ResourceAvailabilityPeriods mp_oAvailabilityPeriods;
		private ResourceRates mp_oRates;
		private TimephasedData_C mp_oTimephasedData_C;

		public Resource()
		{
			mp_lUID = 0;
			mp_lID = 0;
			mp_sName = "";
			mp_yType = E_TYPE_6.T_6_MATERIAL;
			mp_bIsNull = false;
			mp_sInitials = "";
			mp_sPhonetics = "";
			mp_sNTAccount = "";
			mp_sMaterialLabel = "";
			mp_sCode = "";
			mp_sGroup = "";
			mp_yWorkGroup = E_WORKGROUP.WG_DEFAULT;
			mp_sEmailAddress = "";
			mp_sHyperlink = "";
			mp_sHyperlinkAddress = "";
			mp_sHyperlinkSubAddress = "";
			mp_fMaxUnits = System.Convert.ToSingle("1.0");
			mp_fPeakUnits = 0;
			mp_bOverAllocated = false;
			mp_dtAvailableFrom = new System.DateTime(0);
			mp_dtAvailableTo = new System.DateTime(0);
			mp_dtStart = new System.DateTime(0);
			mp_dtFinish = new System.DateTime(0);
			mp_bCanLevel = false;
			mp_yAccrueAt = E_ACCRUEAT.AA_START;
			mp_oWork = new Duration();
			mp_oRegularWork = new Duration();
			mp_oOvertimeWork = new Duration();
			mp_oActualWork = new Duration();
			mp_oRemainingWork = new Duration();
			mp_oActualOvertimeWork = new Duration();
			mp_oRemainingOvertimeWork = new Duration();
			mp_lPercentWorkComplete = 0;
			mp_cStandardRate = 0;
			mp_yStandardRateFormat = E_STANDARDRATEFORMAT.SRF_M;
			mp_cCost = 0;
			mp_cOvertimeRate = 0;
			mp_yOvertimeRateFormat = E_OVERTIMERATEFORMAT.ORF_M;
			mp_cOvertimeCost = 0;
			mp_cCostPerUse = 0;
			mp_cActualCost = 0;
			mp_cActualOvertimeCost = 0;
			mp_cRemainingCost = 0;
			mp_cRemainingOvertimeCost = 0;
			mp_fWorkVariance = 0;
			mp_fCostVariance = 0;
			mp_fSV = 0;
			mp_fCV = 0;
			mp_fACWP = 0;
			mp_lCalendarUID = 0;
			mp_sNotes = "";
			mp_fBCWS = 0;
			mp_fBCWP = 0;
			mp_bIsGeneric = false;
			mp_bIsInactive = false;
			mp_bIsEnterprise = false;
			mp_yBookingType = E_BOOKINGTYPE.BT_COMMITED;
			mp_oActualWorkProtected = new Duration();
			mp_oActualOvertimeWorkProtected = new Duration();
			mp_sActiveDirectoryGUID = "";
			mp_dtCreationDate = new System.DateTime(0);
			mp_oExtendedAttribute_C = new ResourceExtendedAttribute_C();
			mp_oBaseline_C = new ResourceBaseline_C();
			mp_oOutlineCode_C = new ResourceOutlineCode_C();
			mp_bIsCostResource = false;
			mp_sAssnOwner = "";
			mp_sAssnOwnerGuid = "";
			mp_bIsBudget = false;
			mp_oAvailabilityPeriods = new ResourceAvailabilityPeriods();
			mp_oRates = new ResourceRates();
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

		public E_TYPE_6 yType
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

		public string sInitials
		{
			get
			{
				return mp_sInitials;
			}
			set
			{
				if (value.Length > 512)
				{
					value = value.Substring(0, 512);
				}
				mp_sInitials = value;
			}
		}

		public string sPhonetics
		{
			get
			{
				return mp_sPhonetics;
			}
			set
			{
				if (value.Length > 512)
				{
					value = value.Substring(0, 512);
				}
				mp_sPhonetics = value;
			}
		}

		public string sNTAccount
		{
			get
			{
				return mp_sNTAccount;
			}
			set
			{
				if (value.Length > 512)
				{
					value = value.Substring(0, 512);
				}
				mp_sNTAccount = value;
			}
		}

		public string sMaterialLabel
		{
			get
			{
				return mp_sMaterialLabel;
			}
			set
			{
				if (value.Length > 512)
				{
					value = value.Substring(0, 512);
				}
				mp_sMaterialLabel = value;
			}
		}

		public string sCode
		{
			get
			{
				return mp_sCode;
			}
			set
			{
				if (value.Length > 512)
				{
					value = value.Substring(0, 512);
				}
				mp_sCode = value;
			}
		}

		public string sGroup
		{
			get
			{
				return mp_sGroup;
			}
			set
			{
				if (value.Length > 512)
				{
					value = value.Substring(0, 512);
				}
				mp_sGroup = value;
			}
		}

		public E_WORKGROUP yWorkGroup
		{
			get
			{
				return mp_yWorkGroup;
			}
			set
			{
				mp_yWorkGroup = value;
			}
		}

		public string sEmailAddress
		{
			get
			{
				return mp_sEmailAddress;
			}
			set
			{
				if (value.Length > 512)
				{
					value = value.Substring(0, 512);
				}
				mp_sEmailAddress = value;
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

		public float fMaxUnits
		{
			get
			{
				return mp_fMaxUnits;
			}
			set
			{
				mp_fMaxUnits = value;
			}
		}

		public float fPeakUnits
		{
			get
			{
				return mp_fPeakUnits;
			}
			set
			{
				mp_fPeakUnits = value;
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

		public System.DateTime dtAvailableFrom
		{
			get
			{
				return mp_dtAvailableFrom;
			}
			set
			{
				mp_dtAvailableFrom = value;
			}
		}

		public System.DateTime dtAvailableTo
		{
			get
			{
				return mp_dtAvailableTo;
			}
			set
			{
				mp_dtAvailableTo = value;
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

		public bool bCanLevel
		{
			get
			{
				return mp_bCanLevel;
			}
			set
			{
				mp_bCanLevel = value;
			}
		}

		public E_ACCRUEAT yAccrueAt
		{
			get
			{
				return mp_yAccrueAt;
			}
			set
			{
				mp_yAccrueAt = value;
			}
		}

		public Duration oWork
		{
			get
			{
				return mp_oWork;
			}
		}

		public Duration oRegularWork
		{
			get
			{
				return mp_oRegularWork;
			}
		}

		public Duration oOvertimeWork
		{
			get
			{
				return mp_oOvertimeWork;
			}
		}

		public Duration oActualWork
		{
			get
			{
				return mp_oActualWork;
			}
		}

		public Duration oRemainingWork
		{
			get
			{
				return mp_oRemainingWork;
			}
		}

		public Duration oActualOvertimeWork
		{
			get
			{
				return mp_oActualOvertimeWork;
			}
		}

		public Duration oRemainingOvertimeWork
		{
			get
			{
				return mp_oRemainingOvertimeWork;
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

		public Decimal cStandardRate
		{
			get
			{
				return mp_cStandardRate;
			}
			set
			{
				mp_cStandardRate = value;
			}
		}

		public E_STANDARDRATEFORMAT yStandardRateFormat
		{
			get
			{
				return mp_yStandardRateFormat;
			}
			set
			{
				mp_yStandardRateFormat = value;
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

		public Decimal cOvertimeRate
		{
			get
			{
				return mp_cOvertimeRate;
			}
			set
			{
				mp_cOvertimeRate = value;
			}
		}

		public E_OVERTIMERATEFORMAT yOvertimeRateFormat
		{
			get
			{
				return mp_yOvertimeRateFormat;
			}
			set
			{
				mp_yOvertimeRateFormat = value;
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

		public Decimal cCostPerUse
		{
			get
			{
				return mp_cCostPerUse;
			}
			set
			{
				mp_cCostPerUse = value;
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

		public float fSV
		{
			get
			{
				return mp_fSV;
			}
			set
			{
				mp_fSV = value;
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

		public bool bIsGeneric
		{
			get
			{
				return mp_bIsGeneric;
			}
			set
			{
				mp_bIsGeneric = value;
			}
		}

		public bool bIsInactive
		{
			get
			{
				return mp_bIsInactive;
			}
			set
			{
				mp_bIsInactive = value;
			}
		}

		public bool bIsEnterprise
		{
			get
			{
				return mp_bIsEnterprise;
			}
			set
			{
				mp_bIsEnterprise = value;
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

		public string sActiveDirectoryGUID
		{
			get
			{
				return mp_sActiveDirectoryGUID;
			}
			set
			{
				if (value.Length > 16)
				{
					value = value.Substring(0, 16);
				}
				mp_sActiveDirectoryGUID = value;
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

		public ResourceExtendedAttribute_C oExtendedAttribute_C
		{
			get
			{
				return mp_oExtendedAttribute_C;
			}
		}

		public ResourceBaseline_C oBaseline_C
		{
			get
			{
				return mp_oBaseline_C;
			}
		}

		public ResourceOutlineCode_C oOutlineCode_C
		{
			get
			{
				return mp_oOutlineCode_C;
			}
		}

		public bool bIsCostResource
		{
			get
			{
				return mp_bIsCostResource;
			}
			set
			{
				mp_bIsCostResource = value;
			}
		}

		public string sAssnOwner
		{
			get
			{
				return mp_sAssnOwner;
			}
			set
			{
				mp_sAssnOwner = value;
			}
		}

		public string sAssnOwnerGuid
		{
			get
			{
				return mp_sAssnOwnerGuid;
			}
			set
			{
				mp_sAssnOwnerGuid = value;
			}
		}

		public bool bIsBudget
		{
			get
			{
				return mp_bIsBudget;
			}
			set
			{
				mp_bIsBudget = value;
			}
		}

		public ResourceAvailabilityPeriods oAvailabilityPeriods
		{
			get
			{
				return mp_oAvailabilityPeriods;
			}
		}

		public ResourceRates oRates
		{
			get
			{
				return mp_oRates;
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
			if (mp_yType != E_TYPE_6.T_6_MATERIAL)
			{
				bReturn = false;
			}
			if (mp_bIsNull != false)
			{
				bReturn = false;
			}
			if (mp_sInitials != "")
			{
				bReturn = false;
			}
			if (mp_sPhonetics != "")
			{
				bReturn = false;
			}
			if (mp_sNTAccount != "")
			{
				bReturn = false;
			}
			if (mp_sMaterialLabel != "")
			{
				bReturn = false;
			}
			if (mp_sCode != "")
			{
				bReturn = false;
			}
			if (mp_sGroup != "")
			{
				bReturn = false;
			}
			if (mp_yWorkGroup != E_WORKGROUP.WG_DEFAULT)
			{
				bReturn = false;
			}
			if (mp_sEmailAddress != "")
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
			if (mp_fMaxUnits != 1.0)
			{
				bReturn = false;
			}
			if (mp_fPeakUnits != 0)
			{
				bReturn = false;
			}
			if (mp_bOverAllocated != false)
			{
				bReturn = false;
			}
			if (mp_dtAvailableFrom.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_dtAvailableTo.Ticks != 0)
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
			if (mp_bCanLevel != false)
			{
				bReturn = false;
			}
			if (mp_yAccrueAt != E_ACCRUEAT.AA_START)
			{
				bReturn = false;
			}
			if (mp_oWork.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_oRegularWork.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_oOvertimeWork.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_oActualWork.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_oRemainingWork.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_oActualOvertimeWork.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_oRemainingOvertimeWork.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_lPercentWorkComplete != 0)
			{
				bReturn = false;
			}
			if (mp_cStandardRate != 0)
			{
				bReturn = false;
			}
			if (mp_yStandardRateFormat != E_STANDARDRATEFORMAT.SRF_M)
			{
				bReturn = false;
			}
			if (mp_cCost != 0)
			{
				bReturn = false;
			}
			if (mp_cOvertimeRate != 0)
			{
				bReturn = false;
			}
			if (mp_yOvertimeRateFormat != E_OVERTIMERATEFORMAT.ORF_M)
			{
				bReturn = false;
			}
			if (mp_cOvertimeCost != 0)
			{
				bReturn = false;
			}
			if (mp_cCostPerUse != 0)
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
			if (mp_cRemainingCost != 0)
			{
				bReturn = false;
			}
			if (mp_cRemainingOvertimeCost != 0)
			{
				bReturn = false;
			}
			if (mp_fWorkVariance != 0)
			{
				bReturn = false;
			}
			if (mp_fCostVariance != 0)
			{
				bReturn = false;
			}
			if (mp_fSV != 0)
			{
				bReturn = false;
			}
			if (mp_fCV != 0)
			{
				bReturn = false;
			}
			if (mp_fACWP != 0)
			{
				bReturn = false;
			}
			if (mp_lCalendarUID != 0)
			{
				bReturn = false;
			}
			if (mp_sNotes != "")
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
			if (mp_bIsGeneric != false)
			{
				bReturn = false;
			}
			if (mp_bIsInactive != false)
			{
				bReturn = false;
			}
			if (mp_bIsEnterprise != false)
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
			if (mp_sActiveDirectoryGUID != "")
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
			if (mp_oOutlineCode_C.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_bIsCostResource != false)
			{
				bReturn = false;
			}
			if (mp_sAssnOwner != "")
			{
				bReturn = false;
			}
			if (mp_sAssnOwnerGuid != "")
			{
				bReturn = false;
			}
			if (mp_bIsBudget != false)
			{
				bReturn = false;
			}
			if (mp_oAvailabilityPeriods.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_oRates.IsNull() == false)
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
				return "<Resource/>";
			}
			clsXML oXML = new clsXML("Resource");
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
			if (mp_sInitials != "")
			{
				oXML.WriteProperty("Initials", mp_sInitials);
			}
			if (mp_sPhonetics != "")
			{
				oXML.WriteProperty("Phonetics", mp_sPhonetics);
			}
			if (mp_sNTAccount != "")
			{
				oXML.WriteProperty("NTAccount", mp_sNTAccount);
			}
			if (mp_sMaterialLabel != "")
			{
				oXML.WriteProperty("MaterialLabel", mp_sMaterialLabel);
			}
			if (mp_sCode != "")
			{
				oXML.WriteProperty("Code", mp_sCode);
			}
			if (mp_sGroup != "")
			{
				oXML.WriteProperty("Group", mp_sGroup);
			}
			oXML.WriteProperty("WorkGroup", mp_yWorkGroup);
			if (mp_sEmailAddress != "")
			{
				oXML.WriteProperty("EmailAddress", mp_sEmailAddress);
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
			oXML.WriteProperty("MaxUnits", mp_fMaxUnits);
			oXML.WriteProperty("PeakUnits", mp_fPeakUnits);
			oXML.WriteProperty("OverAllocated", mp_bOverAllocated);
			if (mp_dtAvailableFrom.Ticks != 0)
			{
				oXML.WriteProperty("AvailableFrom", mp_dtAvailableFrom);
			}
			if (mp_dtAvailableTo.Ticks != 0)
			{
				oXML.WriteProperty("AvailableTo", mp_dtAvailableTo);
			}
			if (mp_dtStart.Ticks != 0)
			{
				oXML.WriteProperty("Start", mp_dtStart);
			}
			if (mp_dtFinish.Ticks != 0)
			{
				oXML.WriteProperty("Finish", mp_dtFinish);
			}
			oXML.WriteProperty("CanLevel", mp_bCanLevel);
			oXML.WriteProperty("AccrueAt", mp_yAccrueAt);
			oXML.WriteProperty("Work", mp_oWork);
			oXML.WriteProperty("RegularWork", mp_oRegularWork);
			oXML.WriteProperty("OvertimeWork", mp_oOvertimeWork);
			oXML.WriteProperty("ActualWork", mp_oActualWork);
			oXML.WriteProperty("RemainingWork", mp_oRemainingWork);
			oXML.WriteProperty("ActualOvertimeWork", mp_oActualOvertimeWork);
			oXML.WriteProperty("RemainingOvertimeWork", mp_oRemainingOvertimeWork);
			oXML.WriteProperty("PercentWorkComplete", mp_lPercentWorkComplete);
			oXML.WriteProperty("StandardRate", mp_cStandardRate);
			oXML.WriteProperty("StandardRateFormat", mp_yStandardRateFormat);
			oXML.WriteProperty("Cost", mp_cCost);
			oXML.WriteProperty("OvertimeRate", mp_cOvertimeRate);
			oXML.WriteProperty("OvertimeRateFormat", mp_yOvertimeRateFormat);
			oXML.WriteProperty("OvertimeCost", mp_cOvertimeCost);
			oXML.WriteProperty("CostPerUse", mp_cCostPerUse);
			oXML.WriteProperty("ActualCost", mp_cActualCost);
			oXML.WriteProperty("ActualOvertimeCost", mp_cActualOvertimeCost);
			oXML.WriteProperty("RemainingCost", mp_cRemainingCost);
			oXML.WriteProperty("RemainingOvertimeCost", mp_cRemainingOvertimeCost);
			oXML.WriteProperty("WorkVariance", mp_fWorkVariance);
			oXML.WriteProperty("CostVariance", mp_fCostVariance);
			oXML.WriteProperty("SV", mp_fSV);
			oXML.WriteProperty("CV", mp_fCV);
			oXML.WriteProperty("ACWP", mp_fACWP);
			oXML.WriteProperty("CalendarUID", mp_lCalendarUID);
			if (mp_sNotes != "")
			{
				oXML.WriteProperty("Notes", mp_sNotes);
			}
			oXML.WriteProperty("BCWS", mp_fBCWS);
			oXML.WriteProperty("BCWP", mp_fBCWP);
			oXML.WriteProperty("IsGeneric", mp_bIsGeneric);
			oXML.WriteProperty("IsInactive", mp_bIsInactive);
			oXML.WriteProperty("IsEnterprise", mp_bIsEnterprise);
			oXML.WriteProperty("BookingType", mp_yBookingType);
			if (mp_oActualWorkProtected.IsNull() == false)
			{
				oXML.WriteProperty("ActualWorkProtected", mp_oActualWorkProtected);
			}
			if (mp_oActualOvertimeWorkProtected.IsNull() == false)
			{
				oXML.WriteProperty("ActualOvertimeWorkProtected", mp_oActualOvertimeWorkProtected);
			}
			if (mp_sActiveDirectoryGUID != "")
			{
				oXML.WriteProperty("ActiveDirectoryGUID", mp_sActiveDirectoryGUID);
			}
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
			if (mp_oOutlineCode_C.IsNull() == false)
			{
				mp_oOutlineCode_C.WriteObjectProtected(ref oXML);
			}
			oXML.WriteProperty("IsCostResource", mp_bIsCostResource);
			if (mp_sAssnOwner != "")
			{
				oXML.WriteProperty("AssnOwner", mp_sAssnOwner);
			}
			if (mp_sAssnOwnerGuid != "")
			{
				oXML.WriteProperty("AssnOwnerGuid", mp_sAssnOwnerGuid);
			}
			oXML.WriteProperty("IsBudget", mp_bIsBudget);
			if (mp_oAvailabilityPeriods.IsNull() == false)
			{
				oXML.WriteObject(mp_oAvailabilityPeriods.GetXML());
			}
			if (mp_oRates.IsNull() == false)
			{
				oXML.WriteObject(mp_oRates.GetXML());
			}
			if (mp_oTimephasedData_C.IsNull() == false)
			{
				mp_oTimephasedData_C.WriteObjectProtected(ref oXML);
			}
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML("Resource");
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
			oXML.ReadProperty("Initials", ref mp_sInitials);
			if (mp_sInitials.Length > 512)
			{
				mp_sInitials = mp_sInitials.Substring(0, 512);
			}
			oXML.ReadProperty("Phonetics", ref mp_sPhonetics);
			if (mp_sPhonetics.Length > 512)
			{
				mp_sPhonetics = mp_sPhonetics.Substring(0, 512);
			}
			oXML.ReadProperty("NTAccount", ref mp_sNTAccount);
			if (mp_sNTAccount.Length > 512)
			{
				mp_sNTAccount = mp_sNTAccount.Substring(0, 512);
			}
			oXML.ReadProperty("MaterialLabel", ref mp_sMaterialLabel);
			if (mp_sMaterialLabel.Length > 512)
			{
				mp_sMaterialLabel = mp_sMaterialLabel.Substring(0, 512);
			}
			oXML.ReadProperty("Code", ref mp_sCode);
			if (mp_sCode.Length > 512)
			{
				mp_sCode = mp_sCode.Substring(0, 512);
			}
			oXML.ReadProperty("Group", ref mp_sGroup);
			if (mp_sGroup.Length > 512)
			{
				mp_sGroup = mp_sGroup.Substring(0, 512);
			}
			oXML.ReadProperty("WorkGroup", ref mp_yWorkGroup);
			oXML.ReadProperty("EmailAddress", ref mp_sEmailAddress);
			if (mp_sEmailAddress.Length > 512)
			{
				mp_sEmailAddress = mp_sEmailAddress.Substring(0, 512);
			}
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
			oXML.ReadProperty("MaxUnits", ref mp_fMaxUnits);
			oXML.ReadProperty("PeakUnits", ref mp_fPeakUnits);
			oXML.ReadProperty("OverAllocated", ref mp_bOverAllocated);
			oXML.ReadProperty("AvailableFrom", ref mp_dtAvailableFrom);
			oXML.ReadProperty("AvailableTo", ref mp_dtAvailableTo);
			oXML.ReadProperty("Start", ref mp_dtStart);
			oXML.ReadProperty("Finish", ref mp_dtFinish);
			oXML.ReadProperty("CanLevel", ref mp_bCanLevel);
			oXML.ReadProperty("AccrueAt", ref mp_yAccrueAt);
			oXML.ReadProperty("Work", ref mp_oWork);
			oXML.ReadProperty("RegularWork", ref mp_oRegularWork);
			oXML.ReadProperty("OvertimeWork", ref mp_oOvertimeWork);
			oXML.ReadProperty("ActualWork", ref mp_oActualWork);
			oXML.ReadProperty("RemainingWork", ref mp_oRemainingWork);
			oXML.ReadProperty("ActualOvertimeWork", ref mp_oActualOvertimeWork);
			oXML.ReadProperty("RemainingOvertimeWork", ref mp_oRemainingOvertimeWork);
			oXML.ReadProperty("PercentWorkComplete", ref mp_lPercentWorkComplete);
			oXML.ReadProperty("StandardRate", ref mp_cStandardRate);
			oXML.ReadProperty("StandardRateFormat", ref mp_yStandardRateFormat);
			oXML.ReadProperty("Cost", ref mp_cCost);
			oXML.ReadProperty("OvertimeRate", ref mp_cOvertimeRate);
			oXML.ReadProperty("OvertimeRateFormat", ref mp_yOvertimeRateFormat);
			oXML.ReadProperty("OvertimeCost", ref mp_cOvertimeCost);
			oXML.ReadProperty("CostPerUse", ref mp_cCostPerUse);
			oXML.ReadProperty("ActualCost", ref mp_cActualCost);
			oXML.ReadProperty("ActualOvertimeCost", ref mp_cActualOvertimeCost);
			oXML.ReadProperty("RemainingCost", ref mp_cRemainingCost);
			oXML.ReadProperty("RemainingOvertimeCost", ref mp_cRemainingOvertimeCost);
			oXML.ReadProperty("WorkVariance", ref mp_fWorkVariance);
			oXML.ReadProperty("CostVariance", ref mp_fCostVariance);
			oXML.ReadProperty("SV", ref mp_fSV);
			oXML.ReadProperty("CV", ref mp_fCV);
			oXML.ReadProperty("ACWP", ref mp_fACWP);
			oXML.ReadProperty("CalendarUID", ref mp_lCalendarUID);
			oXML.ReadProperty("Notes", ref mp_sNotes);
			oXML.ReadProperty("BCWS", ref mp_fBCWS);
			oXML.ReadProperty("BCWP", ref mp_fBCWP);
			oXML.ReadProperty("IsGeneric", ref mp_bIsGeneric);
			oXML.ReadProperty("IsInactive", ref mp_bIsInactive);
			oXML.ReadProperty("IsEnterprise", ref mp_bIsEnterprise);
			oXML.ReadProperty("BookingType", ref mp_yBookingType);
			oXML.ReadProperty("ActualWorkProtected", ref mp_oActualWorkProtected);
			oXML.ReadProperty("ActualOvertimeWorkProtected", ref mp_oActualOvertimeWorkProtected);
			oXML.ReadProperty("ActiveDirectoryGUID", ref mp_sActiveDirectoryGUID);
			if (mp_sActiveDirectoryGUID.Length > 16)
			{
				mp_sActiveDirectoryGUID = mp_sActiveDirectoryGUID.Substring(0, 16);
			}
			oXML.ReadProperty("CreationDate", ref mp_dtCreationDate);
			mp_oExtendedAttribute_C.ReadObjectProtected(ref oXML);
			mp_oBaseline_C.ReadObjectProtected(ref oXML);
			mp_oOutlineCode_C.ReadObjectProtected(ref oXML);
			oXML.ReadProperty("IsCostResource", ref mp_bIsCostResource);
			oXML.ReadProperty("AssnOwner", ref mp_sAssnOwner);
			oXML.ReadProperty("AssnOwnerGuid", ref mp_sAssnOwnerGuid);
			oXML.ReadProperty("IsBudget", ref mp_bIsBudget);
			mp_oAvailabilityPeriods.SetXML(oXML.ReadObject("AvailabilityPeriods"));
			mp_oRates.SetXML(oXML.ReadObject("Rates"));
			mp_oTimephasedData_C.ReadObjectProtected(ref oXML);
		}

	}
}
