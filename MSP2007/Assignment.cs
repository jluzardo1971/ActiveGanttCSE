using System;

namespace MSP2007
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
		private float mp_fPeakUnits;
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
		private bool mp_bSummary;
		private float mp_fSV;
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
		private string mp_sAssnOwner;
		private string mp_sAssnOwnerGuid;
		private Decimal mp_cBudgetCost;
		private Duration mp_oBudgetWork;
		private AssignmentExtendedAttribute_C mp_oExtendedAttribute_C;
		private AssignmentBaseline_C mp_oBaseline_C;
		private string mp_sf404000;
		private string mp_sf404001;
		private string mp_sf404002;
		private string mp_sf404003;
		private string mp_sf404004;
		private string mp_sf404005;
		private string mp_sf404006;
		private string mp_sf404007;
		private string mp_sf404008;
		private string mp_sf404009;
		private string mp_sf40400a;
		private string mp_sf40400b;
		private string mp_sf40400c;
		private string mp_sf40400d;
		private string mp_sf40400e;
		private string mp_sf40400f;
		private string mp_sf404010;
		private string mp_sf404011;
		private string mp_sf404012;
		private string mp_sf404013;
		private string mp_sf404014;
		private string mp_sf404015;
		private string mp_sf404016;
		private string mp_sf404017;
		private string mp_sf404018;
		private string mp_sf404019;
		private string mp_sf40401a;
		private string mp_sf40401b;
		private string mp_sf40401c;
		private string mp_sf40401d;
		private string mp_sf40401e;
		private string mp_sf40401f;
		private string mp_sf404020;
		private string mp_sf404021;
		private string mp_sf404022;
		private string mp_sf404023;
		private string mp_sf404024;
		private string mp_sf404025;
		private string mp_sf404026;
		private string mp_sf404027;
		private string mp_sf404028;
		private string mp_sf404029;
		private string mp_sf40402a;
		private string mp_sf40402b;
		private string mp_sf40402c;
		private string mp_sf40402d;
		private string mp_sf40402e;
		private string mp_sf40402f;
		private string mp_sf404030;
		private string mp_sf404031;
		private string mp_sf404032;
		private string mp_sf404033;
		private string mp_sf404034;
		private string mp_sf404035;
		private string mp_sf404036;
		private string mp_sf404037;
		private string mp_sf404038;
		private string mp_sf404039;
		private string mp_sf40403a;
		private string mp_sf40403b;
		private string mp_sf40403c;
		private string mp_sf40403d;
		private string mp_sf40403e;
		private string mp_sf40403f;
		private string mp_sf404040;
		private string mp_sf404041;
		private string mp_sf404042;
		private string mp_sf404043;
		private string mp_sf404044;
		private string mp_sf404045;
		private string mp_sf404046;
		private string mp_sf404047;
		private string mp_sf404048;
		private string mp_sf404049;
		private string mp_sf40404a;
		private string mp_sf40404b;
		private string mp_sf40404c;
		private string mp_sf40404d;
		private string mp_sf40404e;
		private string mp_sf40404f;
		private string mp_sf404050;
		private string mp_sf404051;
		private string mp_sf404052;
		private string mp_sf404053;
		private string mp_sf404054;
		private string mp_sf404055;
		private string mp_sf404056;
		private string mp_sf404057;
		private string mp_sf404058;
		private string mp_sf404059;
		private string mp_sf40405a;
		private string mp_sf40405b;
		private string mp_sf40405c;
		private string mp_sf40405d;
		private string mp_sf40405e;
		private string mp_sf40405f;
		private string mp_sf404060;
		private string mp_sf404061;
		private string mp_sf404062;
		private string mp_sf404063;
		private string mp_sf404064;
		private string mp_sf404065;
		private string mp_sf404066;
		private string mp_sf404067;
		private string mp_sf404068;
		private string mp_sf404069;
		private string mp_sf40406a;
		private string mp_sf40406b;
		private string mp_sf40406c;
		private string mp_sf40406d;
		private string mp_sf40406e;
		private string mp_sf40406f;
		private string mp_sf404070;
		private string mp_sf404071;
		private string mp_sf404072;
		private string mp_sf404073;
		private string mp_sf404074;
		private string mp_sf404075;
		private string mp_sf404076;
		private string mp_sf404077;
		private string mp_sf404078;
		private string mp_sf404079;
		private string mp_sf40407a;
		private string mp_sf40407b;
		private string mp_sf40407c;
		private string mp_sf40407d;
		private string mp_sf40407e;
		private string mp_sf40407f;
		private string mp_sf404080;
		private string mp_sf404081;
		private string mp_sf404082;
		private string mp_sf404083;
		private string mp_sf404084;
		private string mp_sf404085;
		private string mp_sf404086;
		private string mp_sf404087;
		private string mp_sf404088;
		private string mp_sf404089;
		private string mp_sf40408a;
		private string mp_sf40408b;
		private string mp_sf40408c;
		private string mp_sf40408d;
		private string mp_sf40408e;
		private string mp_sf40408f;
		private string mp_sf404090;
		private string mp_sf404091;
		private string mp_sf404092;
		private string mp_sf404093;
		private string mp_sf404094;
		private string mp_sf404095;
		private string mp_sf404096;
		private string mp_sf404097;
		private string mp_sf404098;
		private string mp_sf404099;
		private string mp_sf40409a;
		private string mp_sf40409b;
		private string mp_sf40409c;
		private string mp_sf40409d;
		private string mp_sf40409e;
		private string mp_sf40409f;
		private string mp_sf4040a0;
		private string mp_sf4040a1;
		private string mp_sf4040a2;
		private string mp_sf4040a3;
		private string mp_sf4040a4;
		private string mp_sf4040a5;
		private string mp_sf4040a6;
		private string mp_sf4040a7;
		private string mp_sf4040a8;
		private string mp_sf4040a9;
		private string mp_sf4040aa;
		private string mp_sf4040ab;
		private string mp_sf4040ac;
		private string mp_sf4040ad;
		private string mp_sf4040ae;
		private string mp_sf4040af;
		private string mp_sf4040b0;
		private string mp_sf4040b1;
		private string mp_sf4040b2;
		private string mp_sf4040b3;
		private string mp_sf4040b4;
		private string mp_sf4040b5;
		private string mp_sf4040b6;
		private string mp_sf4040b7;
		private string mp_sf4040b8;
		private string mp_sf4040b9;
		private string mp_sf4040ba;
		private string mp_sf4040bb;
		private string mp_sf4040bc;
		private string mp_sf4040bd;
		private string mp_sf4040be;
		private string mp_sf4040bf;
		private string mp_sf4040c0;
		private string mp_sf4040c1;
		private string mp_sf4040c2;
		private string mp_sf4040c3;
		private string mp_sf4040c4;
		private string mp_sf4040c5;
		private string mp_sf4040c6;
		private string mp_sf4040c7;
		private string mp_sf4040c8;
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
			mp_fPeakUnits = 0;
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
			mp_bSummary = false;
			mp_fSV = 0;
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
			mp_sAssnOwner = "";
			mp_sAssnOwnerGuid = "";
			mp_cBudgetCost = 0;
			mp_oBudgetWork = new Duration();
			mp_oExtendedAttribute_C = new AssignmentExtendedAttribute_C();
			mp_oBaseline_C = new AssignmentBaseline_C();
			mp_sf404000 = "";
			mp_sf404001 = "";
			mp_sf404002 = "";
			mp_sf404003 = "";
			mp_sf404004 = "";
			mp_sf404005 = "";
			mp_sf404006 = "";
			mp_sf404007 = "";
			mp_sf404008 = "";
			mp_sf404009 = "";
			mp_sf40400a = "";
			mp_sf40400b = "";
			mp_sf40400c = "";
			mp_sf40400d = "";
			mp_sf40400e = "";
			mp_sf40400f = "";
			mp_sf404010 = "";
			mp_sf404011 = "";
			mp_sf404012 = "";
			mp_sf404013 = "";
			mp_sf404014 = "";
			mp_sf404015 = "";
			mp_sf404016 = "";
			mp_sf404017 = "";
			mp_sf404018 = "";
			mp_sf404019 = "";
			mp_sf40401a = "";
			mp_sf40401b = "";
			mp_sf40401c = "";
			mp_sf40401d = "";
			mp_sf40401e = "";
			mp_sf40401f = "";
			mp_sf404020 = "";
			mp_sf404021 = "";
			mp_sf404022 = "";
			mp_sf404023 = "";
			mp_sf404024 = "";
			mp_sf404025 = "";
			mp_sf404026 = "";
			mp_sf404027 = "";
			mp_sf404028 = "";
			mp_sf404029 = "";
			mp_sf40402a = "";
			mp_sf40402b = "";
			mp_sf40402c = "";
			mp_sf40402d = "";
			mp_sf40402e = "";
			mp_sf40402f = "";
			mp_sf404030 = "";
			mp_sf404031 = "";
			mp_sf404032 = "";
			mp_sf404033 = "";
			mp_sf404034 = "";
			mp_sf404035 = "";
			mp_sf404036 = "";
			mp_sf404037 = "";
			mp_sf404038 = "";
			mp_sf404039 = "";
			mp_sf40403a = "";
			mp_sf40403b = "";
			mp_sf40403c = "";
			mp_sf40403d = "";
			mp_sf40403e = "";
			mp_sf40403f = "";
			mp_sf404040 = "";
			mp_sf404041 = "";
			mp_sf404042 = "";
			mp_sf404043 = "";
			mp_sf404044 = "";
			mp_sf404045 = "";
			mp_sf404046 = "";
			mp_sf404047 = "";
			mp_sf404048 = "";
			mp_sf404049 = "";
			mp_sf40404a = "";
			mp_sf40404b = "";
			mp_sf40404c = "";
			mp_sf40404d = "";
			mp_sf40404e = "";
			mp_sf40404f = "";
			mp_sf404050 = "";
			mp_sf404051 = "";
			mp_sf404052 = "";
			mp_sf404053 = "";
			mp_sf404054 = "";
			mp_sf404055 = "";
			mp_sf404056 = "";
			mp_sf404057 = "";
			mp_sf404058 = "";
			mp_sf404059 = "";
			mp_sf40405a = "";
			mp_sf40405b = "";
			mp_sf40405c = "";
			mp_sf40405d = "";
			mp_sf40405e = "";
			mp_sf40405f = "";
			mp_sf404060 = "";
			mp_sf404061 = "";
			mp_sf404062 = "";
			mp_sf404063 = "";
			mp_sf404064 = "";
			mp_sf404065 = "";
			mp_sf404066 = "";
			mp_sf404067 = "";
			mp_sf404068 = "";
			mp_sf404069 = "";
			mp_sf40406a = "";
			mp_sf40406b = "";
			mp_sf40406c = "";
			mp_sf40406d = "";
			mp_sf40406e = "";
			mp_sf40406f = "";
			mp_sf404070 = "";
			mp_sf404071 = "";
			mp_sf404072 = "";
			mp_sf404073 = "";
			mp_sf404074 = "";
			mp_sf404075 = "";
			mp_sf404076 = "";
			mp_sf404077 = "";
			mp_sf404078 = "";
			mp_sf404079 = "";
			mp_sf40407a = "";
			mp_sf40407b = "";
			mp_sf40407c = "";
			mp_sf40407d = "";
			mp_sf40407e = "";
			mp_sf40407f = "";
			mp_sf404080 = "";
			mp_sf404081 = "";
			mp_sf404082 = "";
			mp_sf404083 = "";
			mp_sf404084 = "";
			mp_sf404085 = "";
			mp_sf404086 = "";
			mp_sf404087 = "";
			mp_sf404088 = "";
			mp_sf404089 = "";
			mp_sf40408a = "";
			mp_sf40408b = "";
			mp_sf40408c = "";
			mp_sf40408d = "";
			mp_sf40408e = "";
			mp_sf40408f = "";
			mp_sf404090 = "";
			mp_sf404091 = "";
			mp_sf404092 = "";
			mp_sf404093 = "";
			mp_sf404094 = "";
			mp_sf404095 = "";
			mp_sf404096 = "";
			mp_sf404097 = "";
			mp_sf404098 = "";
			mp_sf404099 = "";
			mp_sf40409a = "";
			mp_sf40409b = "";
			mp_sf40409c = "";
			mp_sf40409d = "";
			mp_sf40409e = "";
			mp_sf40409f = "";
			mp_sf4040a0 = "";
			mp_sf4040a1 = "";
			mp_sf4040a2 = "";
			mp_sf4040a3 = "";
			mp_sf4040a4 = "";
			mp_sf4040a5 = "";
			mp_sf4040a6 = "";
			mp_sf4040a7 = "";
			mp_sf4040a8 = "";
			mp_sf4040a9 = "";
			mp_sf4040aa = "";
			mp_sf4040ab = "";
			mp_sf4040ac = "";
			mp_sf4040ad = "";
			mp_sf4040ae = "";
			mp_sf4040af = "";
			mp_sf4040b0 = "";
			mp_sf4040b1 = "";
			mp_sf4040b2 = "";
			mp_sf4040b3 = "";
			mp_sf4040b4 = "";
			mp_sf4040b5 = "";
			mp_sf4040b6 = "";
			mp_sf4040b7 = "";
			mp_sf4040b8 = "";
			mp_sf4040b9 = "";
			mp_sf4040ba = "";
			mp_sf4040bb = "";
			mp_sf4040bc = "";
			mp_sf4040bd = "";
			mp_sf4040be = "";
			mp_sf4040bf = "";
			mp_sf4040c0 = "";
			mp_sf4040c1 = "";
			mp_sf4040c2 = "";
			mp_sf4040c3 = "";
			mp_sf4040c4 = "";
			mp_sf4040c5 = "";
			mp_sf4040c6 = "";
			mp_sf4040c7 = "";
			mp_sf4040c8 = "";
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

		public Decimal cBudgetCost
		{
			get
			{
				return mp_cBudgetCost;
			}
			set
			{
				mp_cBudgetCost = value;
			}
		}

		public Duration oBudgetWork
		{
			get
			{
				return mp_oBudgetWork;
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

		public string sf404000
		{
			get
			{
				return mp_sf404000;
			}
			set
			{
				mp_sf404000 = value;
			}
		}

		public string sf404001
		{
			get
			{
				return mp_sf404001;
			}
			set
			{
				mp_sf404001 = value;
			}
		}

		public string sf404002
		{
			get
			{
				return mp_sf404002;
			}
			set
			{
				mp_sf404002 = value;
			}
		}

		public string sf404003
		{
			get
			{
				return mp_sf404003;
			}
			set
			{
				mp_sf404003 = value;
			}
		}

		public string sf404004
		{
			get
			{
				return mp_sf404004;
			}
			set
			{
				mp_sf404004 = value;
			}
		}

		public string sf404005
		{
			get
			{
				return mp_sf404005;
			}
			set
			{
				mp_sf404005 = value;
			}
		}

		public string sf404006
		{
			get
			{
				return mp_sf404006;
			}
			set
			{
				mp_sf404006 = value;
			}
		}

		public string sf404007
		{
			get
			{
				return mp_sf404007;
			}
			set
			{
				mp_sf404007 = value;
			}
		}

		public string sf404008
		{
			get
			{
				return mp_sf404008;
			}
			set
			{
				mp_sf404008 = value;
			}
		}

		public string sf404009
		{
			get
			{
				return mp_sf404009;
			}
			set
			{
				mp_sf404009 = value;
			}
		}

		public string sf40400a
		{
			get
			{
				return mp_sf40400a;
			}
			set
			{
				mp_sf40400a = value;
			}
		}

		public string sf40400b
		{
			get
			{
				return mp_sf40400b;
			}
			set
			{
				mp_sf40400b = value;
			}
		}

		public string sf40400c
		{
			get
			{
				return mp_sf40400c;
			}
			set
			{
				mp_sf40400c = value;
			}
		}

		public string sf40400d
		{
			get
			{
				return mp_sf40400d;
			}
			set
			{
				mp_sf40400d = value;
			}
		}

		public string sf40400e
		{
			get
			{
				return mp_sf40400e;
			}
			set
			{
				mp_sf40400e = value;
			}
		}

		public string sf40400f
		{
			get
			{
				return mp_sf40400f;
			}
			set
			{
				mp_sf40400f = value;
			}
		}

		public string sf404010
		{
			get
			{
				return mp_sf404010;
			}
			set
			{
				mp_sf404010 = value;
			}
		}

		public string sf404011
		{
			get
			{
				return mp_sf404011;
			}
			set
			{
				mp_sf404011 = value;
			}
		}

		public string sf404012
		{
			get
			{
				return mp_sf404012;
			}
			set
			{
				mp_sf404012 = value;
			}
		}

		public string sf404013
		{
			get
			{
				return mp_sf404013;
			}
			set
			{
				mp_sf404013 = value;
			}
		}

		public string sf404014
		{
			get
			{
				return mp_sf404014;
			}
			set
			{
				mp_sf404014 = value;
			}
		}

		public string sf404015
		{
			get
			{
				return mp_sf404015;
			}
			set
			{
				mp_sf404015 = value;
			}
		}

		public string sf404016
		{
			get
			{
				return mp_sf404016;
			}
			set
			{
				mp_sf404016 = value;
			}
		}

		public string sf404017
		{
			get
			{
				return mp_sf404017;
			}
			set
			{
				mp_sf404017 = value;
			}
		}

		public string sf404018
		{
			get
			{
				return mp_sf404018;
			}
			set
			{
				mp_sf404018 = value;
			}
		}

		public string sf404019
		{
			get
			{
				return mp_sf404019;
			}
			set
			{
				mp_sf404019 = value;
			}
		}

		public string sf40401a
		{
			get
			{
				return mp_sf40401a;
			}
			set
			{
				mp_sf40401a = value;
			}
		}

		public string sf40401b
		{
			get
			{
				return mp_sf40401b;
			}
			set
			{
				mp_sf40401b = value;
			}
		}

		public string sf40401c
		{
			get
			{
				return mp_sf40401c;
			}
			set
			{
				mp_sf40401c = value;
			}
		}

		public string sf40401d
		{
			get
			{
				return mp_sf40401d;
			}
			set
			{
				mp_sf40401d = value;
			}
		}

		public string sf40401e
		{
			get
			{
				return mp_sf40401e;
			}
			set
			{
				mp_sf40401e = value;
			}
		}

		public string sf40401f
		{
			get
			{
				return mp_sf40401f;
			}
			set
			{
				mp_sf40401f = value;
			}
		}

		public string sf404020
		{
			get
			{
				return mp_sf404020;
			}
			set
			{
				mp_sf404020 = value;
			}
		}

		public string sf404021
		{
			get
			{
				return mp_sf404021;
			}
			set
			{
				mp_sf404021 = value;
			}
		}

		public string sf404022
		{
			get
			{
				return mp_sf404022;
			}
			set
			{
				mp_sf404022 = value;
			}
		}

		public string sf404023
		{
			get
			{
				return mp_sf404023;
			}
			set
			{
				mp_sf404023 = value;
			}
		}

		public string sf404024
		{
			get
			{
				return mp_sf404024;
			}
			set
			{
				mp_sf404024 = value;
			}
		}

		public string sf404025
		{
			get
			{
				return mp_sf404025;
			}
			set
			{
				mp_sf404025 = value;
			}
		}

		public string sf404026
		{
			get
			{
				return mp_sf404026;
			}
			set
			{
				mp_sf404026 = value;
			}
		}

		public string sf404027
		{
			get
			{
				return mp_sf404027;
			}
			set
			{
				mp_sf404027 = value;
			}
		}

		public string sf404028
		{
			get
			{
				return mp_sf404028;
			}
			set
			{
				mp_sf404028 = value;
			}
		}

		public string sf404029
		{
			get
			{
				return mp_sf404029;
			}
			set
			{
				mp_sf404029 = value;
			}
		}

		public string sf40402a
		{
			get
			{
				return mp_sf40402a;
			}
			set
			{
				mp_sf40402a = value;
			}
		}

		public string sf40402b
		{
			get
			{
				return mp_sf40402b;
			}
			set
			{
				mp_sf40402b = value;
			}
		}

		public string sf40402c
		{
			get
			{
				return mp_sf40402c;
			}
			set
			{
				mp_sf40402c = value;
			}
		}

		public string sf40402d
		{
			get
			{
				return mp_sf40402d;
			}
			set
			{
				mp_sf40402d = value;
			}
		}

		public string sf40402e
		{
			get
			{
				return mp_sf40402e;
			}
			set
			{
				mp_sf40402e = value;
			}
		}

		public string sf40402f
		{
			get
			{
				return mp_sf40402f;
			}
			set
			{
				mp_sf40402f = value;
			}
		}

		public string sf404030
		{
			get
			{
				return mp_sf404030;
			}
			set
			{
				mp_sf404030 = value;
			}
		}

		public string sf404031
		{
			get
			{
				return mp_sf404031;
			}
			set
			{
				mp_sf404031 = value;
			}
		}

		public string sf404032
		{
			get
			{
				return mp_sf404032;
			}
			set
			{
				mp_sf404032 = value;
			}
		}

		public string sf404033
		{
			get
			{
				return mp_sf404033;
			}
			set
			{
				mp_sf404033 = value;
			}
		}

		public string sf404034
		{
			get
			{
				return mp_sf404034;
			}
			set
			{
				mp_sf404034 = value;
			}
		}

		public string sf404035
		{
			get
			{
				return mp_sf404035;
			}
			set
			{
				mp_sf404035 = value;
			}
		}

		public string sf404036
		{
			get
			{
				return mp_sf404036;
			}
			set
			{
				mp_sf404036 = value;
			}
		}

		public string sf404037
		{
			get
			{
				return mp_sf404037;
			}
			set
			{
				mp_sf404037 = value;
			}
		}

		public string sf404038
		{
			get
			{
				return mp_sf404038;
			}
			set
			{
				mp_sf404038 = value;
			}
		}

		public string sf404039
		{
			get
			{
				return mp_sf404039;
			}
			set
			{
				mp_sf404039 = value;
			}
		}

		public string sf40403a
		{
			get
			{
				return mp_sf40403a;
			}
			set
			{
				mp_sf40403a = value;
			}
		}

		public string sf40403b
		{
			get
			{
				return mp_sf40403b;
			}
			set
			{
				mp_sf40403b = value;
			}
		}

		public string sf40403c
		{
			get
			{
				return mp_sf40403c;
			}
			set
			{
				mp_sf40403c = value;
			}
		}

		public string sf40403d
		{
			get
			{
				return mp_sf40403d;
			}
			set
			{
				mp_sf40403d = value;
			}
		}

		public string sf40403e
		{
			get
			{
				return mp_sf40403e;
			}
			set
			{
				mp_sf40403e = value;
			}
		}

		public string sf40403f
		{
			get
			{
				return mp_sf40403f;
			}
			set
			{
				mp_sf40403f = value;
			}
		}

		public string sf404040
		{
			get
			{
				return mp_sf404040;
			}
			set
			{
				mp_sf404040 = value;
			}
		}

		public string sf404041
		{
			get
			{
				return mp_sf404041;
			}
			set
			{
				mp_sf404041 = value;
			}
		}

		public string sf404042
		{
			get
			{
				return mp_sf404042;
			}
			set
			{
				mp_sf404042 = value;
			}
		}

		public string sf404043
		{
			get
			{
				return mp_sf404043;
			}
			set
			{
				mp_sf404043 = value;
			}
		}

		public string sf404044
		{
			get
			{
				return mp_sf404044;
			}
			set
			{
				mp_sf404044 = value;
			}
		}

		public string sf404045
		{
			get
			{
				return mp_sf404045;
			}
			set
			{
				mp_sf404045 = value;
			}
		}

		public string sf404046
		{
			get
			{
				return mp_sf404046;
			}
			set
			{
				mp_sf404046 = value;
			}
		}

		public string sf404047
		{
			get
			{
				return mp_sf404047;
			}
			set
			{
				mp_sf404047 = value;
			}
		}

		public string sf404048
		{
			get
			{
				return mp_sf404048;
			}
			set
			{
				mp_sf404048 = value;
			}
		}

		public string sf404049
		{
			get
			{
				return mp_sf404049;
			}
			set
			{
				mp_sf404049 = value;
			}
		}

		public string sf40404a
		{
			get
			{
				return mp_sf40404a;
			}
			set
			{
				mp_sf40404a = value;
			}
		}

		public string sf40404b
		{
			get
			{
				return mp_sf40404b;
			}
			set
			{
				mp_sf40404b = value;
			}
		}

		public string sf40404c
		{
			get
			{
				return mp_sf40404c;
			}
			set
			{
				mp_sf40404c = value;
			}
		}

		public string sf40404d
		{
			get
			{
				return mp_sf40404d;
			}
			set
			{
				mp_sf40404d = value;
			}
		}

		public string sf40404e
		{
			get
			{
				return mp_sf40404e;
			}
			set
			{
				mp_sf40404e = value;
			}
		}

		public string sf40404f
		{
			get
			{
				return mp_sf40404f;
			}
			set
			{
				mp_sf40404f = value;
			}
		}

		public string sf404050
		{
			get
			{
				return mp_sf404050;
			}
			set
			{
				mp_sf404050 = value;
			}
		}

		public string sf404051
		{
			get
			{
				return mp_sf404051;
			}
			set
			{
				mp_sf404051 = value;
			}
		}

		public string sf404052
		{
			get
			{
				return mp_sf404052;
			}
			set
			{
				mp_sf404052 = value;
			}
		}

		public string sf404053
		{
			get
			{
				return mp_sf404053;
			}
			set
			{
				mp_sf404053 = value;
			}
		}

		public string sf404054
		{
			get
			{
				return mp_sf404054;
			}
			set
			{
				mp_sf404054 = value;
			}
		}

		public string sf404055
		{
			get
			{
				return mp_sf404055;
			}
			set
			{
				mp_sf404055 = value;
			}
		}

		public string sf404056
		{
			get
			{
				return mp_sf404056;
			}
			set
			{
				mp_sf404056 = value;
			}
		}

		public string sf404057
		{
			get
			{
				return mp_sf404057;
			}
			set
			{
				mp_sf404057 = value;
			}
		}

		public string sf404058
		{
			get
			{
				return mp_sf404058;
			}
			set
			{
				mp_sf404058 = value;
			}
		}

		public string sf404059
		{
			get
			{
				return mp_sf404059;
			}
			set
			{
				mp_sf404059 = value;
			}
		}

		public string sf40405a
		{
			get
			{
				return mp_sf40405a;
			}
			set
			{
				mp_sf40405a = value;
			}
		}

		public string sf40405b
		{
			get
			{
				return mp_sf40405b;
			}
			set
			{
				mp_sf40405b = value;
			}
		}

		public string sf40405c
		{
			get
			{
				return mp_sf40405c;
			}
			set
			{
				mp_sf40405c = value;
			}
		}

		public string sf40405d
		{
			get
			{
				return mp_sf40405d;
			}
			set
			{
				mp_sf40405d = value;
			}
		}

		public string sf40405e
		{
			get
			{
				return mp_sf40405e;
			}
			set
			{
				mp_sf40405e = value;
			}
		}

		public string sf40405f
		{
			get
			{
				return mp_sf40405f;
			}
			set
			{
				mp_sf40405f = value;
			}
		}

		public string sf404060
		{
			get
			{
				return mp_sf404060;
			}
			set
			{
				mp_sf404060 = value;
			}
		}

		public string sf404061
		{
			get
			{
				return mp_sf404061;
			}
			set
			{
				mp_sf404061 = value;
			}
		}

		public string sf404062
		{
			get
			{
				return mp_sf404062;
			}
			set
			{
				mp_sf404062 = value;
			}
		}

		public string sf404063
		{
			get
			{
				return mp_sf404063;
			}
			set
			{
				mp_sf404063 = value;
			}
		}

		public string sf404064
		{
			get
			{
				return mp_sf404064;
			}
			set
			{
				mp_sf404064 = value;
			}
		}

		public string sf404065
		{
			get
			{
				return mp_sf404065;
			}
			set
			{
				mp_sf404065 = value;
			}
		}

		public string sf404066
		{
			get
			{
				return mp_sf404066;
			}
			set
			{
				mp_sf404066 = value;
			}
		}

		public string sf404067
		{
			get
			{
				return mp_sf404067;
			}
			set
			{
				mp_sf404067 = value;
			}
		}

		public string sf404068
		{
			get
			{
				return mp_sf404068;
			}
			set
			{
				mp_sf404068 = value;
			}
		}

		public string sf404069
		{
			get
			{
				return mp_sf404069;
			}
			set
			{
				mp_sf404069 = value;
			}
		}

		public string sf40406a
		{
			get
			{
				return mp_sf40406a;
			}
			set
			{
				mp_sf40406a = value;
			}
		}

		public string sf40406b
		{
			get
			{
				return mp_sf40406b;
			}
			set
			{
				mp_sf40406b = value;
			}
		}

		public string sf40406c
		{
			get
			{
				return mp_sf40406c;
			}
			set
			{
				mp_sf40406c = value;
			}
		}

		public string sf40406d
		{
			get
			{
				return mp_sf40406d;
			}
			set
			{
				mp_sf40406d = value;
			}
		}

		public string sf40406e
		{
			get
			{
				return mp_sf40406e;
			}
			set
			{
				mp_sf40406e = value;
			}
		}

		public string sf40406f
		{
			get
			{
				return mp_sf40406f;
			}
			set
			{
				mp_sf40406f = value;
			}
		}

		public string sf404070
		{
			get
			{
				return mp_sf404070;
			}
			set
			{
				mp_sf404070 = value;
			}
		}

		public string sf404071
		{
			get
			{
				return mp_sf404071;
			}
			set
			{
				mp_sf404071 = value;
			}
		}

		public string sf404072
		{
			get
			{
				return mp_sf404072;
			}
			set
			{
				mp_sf404072 = value;
			}
		}

		public string sf404073
		{
			get
			{
				return mp_sf404073;
			}
			set
			{
				mp_sf404073 = value;
			}
		}

		public string sf404074
		{
			get
			{
				return mp_sf404074;
			}
			set
			{
				mp_sf404074 = value;
			}
		}

		public string sf404075
		{
			get
			{
				return mp_sf404075;
			}
			set
			{
				mp_sf404075 = value;
			}
		}

		public string sf404076
		{
			get
			{
				return mp_sf404076;
			}
			set
			{
				mp_sf404076 = value;
			}
		}

		public string sf404077
		{
			get
			{
				return mp_sf404077;
			}
			set
			{
				mp_sf404077 = value;
			}
		}

		public string sf404078
		{
			get
			{
				return mp_sf404078;
			}
			set
			{
				mp_sf404078 = value;
			}
		}

		public string sf404079
		{
			get
			{
				return mp_sf404079;
			}
			set
			{
				mp_sf404079 = value;
			}
		}

		public string sf40407a
		{
			get
			{
				return mp_sf40407a;
			}
			set
			{
				mp_sf40407a = value;
			}
		}

		public string sf40407b
		{
			get
			{
				return mp_sf40407b;
			}
			set
			{
				mp_sf40407b = value;
			}
		}

		public string sf40407c
		{
			get
			{
				return mp_sf40407c;
			}
			set
			{
				mp_sf40407c = value;
			}
		}

		public string sf40407d
		{
			get
			{
				return mp_sf40407d;
			}
			set
			{
				mp_sf40407d = value;
			}
		}

		public string sf40407e
		{
			get
			{
				return mp_sf40407e;
			}
			set
			{
				mp_sf40407e = value;
			}
		}

		public string sf40407f
		{
			get
			{
				return mp_sf40407f;
			}
			set
			{
				mp_sf40407f = value;
			}
		}

		public string sf404080
		{
			get
			{
				return mp_sf404080;
			}
			set
			{
				mp_sf404080 = value;
			}
		}

		public string sf404081
		{
			get
			{
				return mp_sf404081;
			}
			set
			{
				mp_sf404081 = value;
			}
		}

		public string sf404082
		{
			get
			{
				return mp_sf404082;
			}
			set
			{
				mp_sf404082 = value;
			}
		}

		public string sf404083
		{
			get
			{
				return mp_sf404083;
			}
			set
			{
				mp_sf404083 = value;
			}
		}

		public string sf404084
		{
			get
			{
				return mp_sf404084;
			}
			set
			{
				mp_sf404084 = value;
			}
		}

		public string sf404085
		{
			get
			{
				return mp_sf404085;
			}
			set
			{
				mp_sf404085 = value;
			}
		}

		public string sf404086
		{
			get
			{
				return mp_sf404086;
			}
			set
			{
				mp_sf404086 = value;
			}
		}

		public string sf404087
		{
			get
			{
				return mp_sf404087;
			}
			set
			{
				mp_sf404087 = value;
			}
		}

		public string sf404088
		{
			get
			{
				return mp_sf404088;
			}
			set
			{
				mp_sf404088 = value;
			}
		}

		public string sf404089
		{
			get
			{
				return mp_sf404089;
			}
			set
			{
				mp_sf404089 = value;
			}
		}

		public string sf40408a
		{
			get
			{
				return mp_sf40408a;
			}
			set
			{
				mp_sf40408a = value;
			}
		}

		public string sf40408b
		{
			get
			{
				return mp_sf40408b;
			}
			set
			{
				mp_sf40408b = value;
			}
		}

		public string sf40408c
		{
			get
			{
				return mp_sf40408c;
			}
			set
			{
				mp_sf40408c = value;
			}
		}

		public string sf40408d
		{
			get
			{
				return mp_sf40408d;
			}
			set
			{
				mp_sf40408d = value;
			}
		}

		public string sf40408e
		{
			get
			{
				return mp_sf40408e;
			}
			set
			{
				mp_sf40408e = value;
			}
		}

		public string sf40408f
		{
			get
			{
				return mp_sf40408f;
			}
			set
			{
				mp_sf40408f = value;
			}
		}

		public string sf404090
		{
			get
			{
				return mp_sf404090;
			}
			set
			{
				mp_sf404090 = value;
			}
		}

		public string sf404091
		{
			get
			{
				return mp_sf404091;
			}
			set
			{
				mp_sf404091 = value;
			}
		}

		public string sf404092
		{
			get
			{
				return mp_sf404092;
			}
			set
			{
				mp_sf404092 = value;
			}
		}

		public string sf404093
		{
			get
			{
				return mp_sf404093;
			}
			set
			{
				mp_sf404093 = value;
			}
		}

		public string sf404094
		{
			get
			{
				return mp_sf404094;
			}
			set
			{
				mp_sf404094 = value;
			}
		}

		public string sf404095
		{
			get
			{
				return mp_sf404095;
			}
			set
			{
				mp_sf404095 = value;
			}
		}

		public string sf404096
		{
			get
			{
				return mp_sf404096;
			}
			set
			{
				mp_sf404096 = value;
			}
		}

		public string sf404097
		{
			get
			{
				return mp_sf404097;
			}
			set
			{
				mp_sf404097 = value;
			}
		}

		public string sf404098
		{
			get
			{
				return mp_sf404098;
			}
			set
			{
				mp_sf404098 = value;
			}
		}

		public string sf404099
		{
			get
			{
				return mp_sf404099;
			}
			set
			{
				mp_sf404099 = value;
			}
		}

		public string sf40409a
		{
			get
			{
				return mp_sf40409a;
			}
			set
			{
				mp_sf40409a = value;
			}
		}

		public string sf40409b
		{
			get
			{
				return mp_sf40409b;
			}
			set
			{
				mp_sf40409b = value;
			}
		}

		public string sf40409c
		{
			get
			{
				return mp_sf40409c;
			}
			set
			{
				mp_sf40409c = value;
			}
		}

		public string sf40409d
		{
			get
			{
				return mp_sf40409d;
			}
			set
			{
				mp_sf40409d = value;
			}
		}

		public string sf40409e
		{
			get
			{
				return mp_sf40409e;
			}
			set
			{
				mp_sf40409e = value;
			}
		}

		public string sf40409f
		{
			get
			{
				return mp_sf40409f;
			}
			set
			{
				mp_sf40409f = value;
			}
		}

		public string sf4040a0
		{
			get
			{
				return mp_sf4040a0;
			}
			set
			{
				mp_sf4040a0 = value;
			}
		}

		public string sf4040a1
		{
			get
			{
				return mp_sf4040a1;
			}
			set
			{
				mp_sf4040a1 = value;
			}
		}

		public string sf4040a2
		{
			get
			{
				return mp_sf4040a2;
			}
			set
			{
				mp_sf4040a2 = value;
			}
		}

		public string sf4040a3
		{
			get
			{
				return mp_sf4040a3;
			}
			set
			{
				mp_sf4040a3 = value;
			}
		}

		public string sf4040a4
		{
			get
			{
				return mp_sf4040a4;
			}
			set
			{
				mp_sf4040a4 = value;
			}
		}

		public string sf4040a5
		{
			get
			{
				return mp_sf4040a5;
			}
			set
			{
				mp_sf4040a5 = value;
			}
		}

		public string sf4040a6
		{
			get
			{
				return mp_sf4040a6;
			}
			set
			{
				mp_sf4040a6 = value;
			}
		}

		public string sf4040a7
		{
			get
			{
				return mp_sf4040a7;
			}
			set
			{
				mp_sf4040a7 = value;
			}
		}

		public string sf4040a8
		{
			get
			{
				return mp_sf4040a8;
			}
			set
			{
				mp_sf4040a8 = value;
			}
		}

		public string sf4040a9
		{
			get
			{
				return mp_sf4040a9;
			}
			set
			{
				mp_sf4040a9 = value;
			}
		}

		public string sf4040aa
		{
			get
			{
				return mp_sf4040aa;
			}
			set
			{
				mp_sf4040aa = value;
			}
		}

		public string sf4040ab
		{
			get
			{
				return mp_sf4040ab;
			}
			set
			{
				mp_sf4040ab = value;
			}
		}

		public string sf4040ac
		{
			get
			{
				return mp_sf4040ac;
			}
			set
			{
				mp_sf4040ac = value;
			}
		}

		public string sf4040ad
		{
			get
			{
				return mp_sf4040ad;
			}
			set
			{
				mp_sf4040ad = value;
			}
		}

		public string sf4040ae
		{
			get
			{
				return mp_sf4040ae;
			}
			set
			{
				mp_sf4040ae = value;
			}
		}

		public string sf4040af
		{
			get
			{
				return mp_sf4040af;
			}
			set
			{
				mp_sf4040af = value;
			}
		}

		public string sf4040b0
		{
			get
			{
				return mp_sf4040b0;
			}
			set
			{
				mp_sf4040b0 = value;
			}
		}

		public string sf4040b1
		{
			get
			{
				return mp_sf4040b1;
			}
			set
			{
				mp_sf4040b1 = value;
			}
		}

		public string sf4040b2
		{
			get
			{
				return mp_sf4040b2;
			}
			set
			{
				mp_sf4040b2 = value;
			}
		}

		public string sf4040b3
		{
			get
			{
				return mp_sf4040b3;
			}
			set
			{
				mp_sf4040b3 = value;
			}
		}

		public string sf4040b4
		{
			get
			{
				return mp_sf4040b4;
			}
			set
			{
				mp_sf4040b4 = value;
			}
		}

		public string sf4040b5
		{
			get
			{
				return mp_sf4040b5;
			}
			set
			{
				mp_sf4040b5 = value;
			}
		}

		public string sf4040b6
		{
			get
			{
				return mp_sf4040b6;
			}
			set
			{
				mp_sf4040b6 = value;
			}
		}

		public string sf4040b7
		{
			get
			{
				return mp_sf4040b7;
			}
			set
			{
				mp_sf4040b7 = value;
			}
		}

		public string sf4040b8
		{
			get
			{
				return mp_sf4040b8;
			}
			set
			{
				mp_sf4040b8 = value;
			}
		}

		public string sf4040b9
		{
			get
			{
				return mp_sf4040b9;
			}
			set
			{
				mp_sf4040b9 = value;
			}
		}

		public string sf4040ba
		{
			get
			{
				return mp_sf4040ba;
			}
			set
			{
				mp_sf4040ba = value;
			}
		}

		public string sf4040bb
		{
			get
			{
				return mp_sf4040bb;
			}
			set
			{
				mp_sf4040bb = value;
			}
		}

		public string sf4040bc
		{
			get
			{
				return mp_sf4040bc;
			}
			set
			{
				mp_sf4040bc = value;
			}
		}

		public string sf4040bd
		{
			get
			{
				return mp_sf4040bd;
			}
			set
			{
				mp_sf4040bd = value;
			}
		}

		public string sf4040be
		{
			get
			{
				return mp_sf4040be;
			}
			set
			{
				mp_sf4040be = value;
			}
		}

		public string sf4040bf
		{
			get
			{
				return mp_sf4040bf;
			}
			set
			{
				mp_sf4040bf = value;
			}
		}

		public string sf4040c0
		{
			get
			{
				return mp_sf4040c0;
			}
			set
			{
				mp_sf4040c0 = value;
			}
		}

		public string sf4040c1
		{
			get
			{
				return mp_sf4040c1;
			}
			set
			{
				mp_sf4040c1 = value;
			}
		}

		public string sf4040c2
		{
			get
			{
				return mp_sf4040c2;
			}
			set
			{
				mp_sf4040c2 = value;
			}
		}

		public string sf4040c3
		{
			get
			{
				return mp_sf4040c3;
			}
			set
			{
				mp_sf4040c3 = value;
			}
		}

		public string sf4040c4
		{
			get
			{
				return mp_sf4040c4;
			}
			set
			{
				mp_sf4040c4 = value;
			}
		}

		public string sf4040c5
		{
			get
			{
				return mp_sf4040c5;
			}
			set
			{
				mp_sf4040c5 = value;
			}
		}

		public string sf4040c6
		{
			get
			{
				return mp_sf4040c6;
			}
			set
			{
				mp_sf4040c6 = value;
			}
		}

		public string sf4040c7
		{
			get
			{
				return mp_sf4040c7;
			}
			set
			{
				mp_sf4040c7 = value;
			}
		}

		public string sf4040c8
		{
			get
			{
				return mp_sf4040c8;
			}
			set
			{
				mp_sf4040c8 = value;
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
			if (mp_fPeakUnits != 0)
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
			if (mp_bSummary != false)
			{
				bReturn = false;
			}
			if (mp_fSV != 0)
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
			if (mp_sAssnOwner != "")
			{
				bReturn = false;
			}
			if (mp_sAssnOwnerGuid != "")
			{
				bReturn = false;
			}
			if (mp_cBudgetCost != 0)
			{
				bReturn = false;
			}
			if (mp_oBudgetWork.IsNull() == false)
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
			if (mp_sf404000 != "")
			{
				bReturn = false;
			}
			if (mp_sf404001 != "")
			{
				bReturn = false;
			}
			if (mp_sf404002 != "")
			{
				bReturn = false;
			}
			if (mp_sf404003 != "")
			{
				bReturn = false;
			}
			if (mp_sf404004 != "")
			{
				bReturn = false;
			}
			if (mp_sf404005 != "")
			{
				bReturn = false;
			}
			if (mp_sf404006 != "")
			{
				bReturn = false;
			}
			if (mp_sf404007 != "")
			{
				bReturn = false;
			}
			if (mp_sf404008 != "")
			{
				bReturn = false;
			}
			if (mp_sf404009 != "")
			{
				bReturn = false;
			}
			if (mp_sf40400a != "")
			{
				bReturn = false;
			}
			if (mp_sf40400b != "")
			{
				bReturn = false;
			}
			if (mp_sf40400c != "")
			{
				bReturn = false;
			}
			if (mp_sf40400d != "")
			{
				bReturn = false;
			}
			if (mp_sf40400e != "")
			{
				bReturn = false;
			}
			if (mp_sf40400f != "")
			{
				bReturn = false;
			}
			if (mp_sf404010 != "")
			{
				bReturn = false;
			}
			if (mp_sf404011 != "")
			{
				bReturn = false;
			}
			if (mp_sf404012 != "")
			{
				bReturn = false;
			}
			if (mp_sf404013 != "")
			{
				bReturn = false;
			}
			if (mp_sf404014 != "")
			{
				bReturn = false;
			}
			if (mp_sf404015 != "")
			{
				bReturn = false;
			}
			if (mp_sf404016 != "")
			{
				bReturn = false;
			}
			if (mp_sf404017 != "")
			{
				bReturn = false;
			}
			if (mp_sf404018 != "")
			{
				bReturn = false;
			}
			if (mp_sf404019 != "")
			{
				bReturn = false;
			}
			if (mp_sf40401a != "")
			{
				bReturn = false;
			}
			if (mp_sf40401b != "")
			{
				bReturn = false;
			}
			if (mp_sf40401c != "")
			{
				bReturn = false;
			}
			if (mp_sf40401d != "")
			{
				bReturn = false;
			}
			if (mp_sf40401e != "")
			{
				bReturn = false;
			}
			if (mp_sf40401f != "")
			{
				bReturn = false;
			}
			if (mp_sf404020 != "")
			{
				bReturn = false;
			}
			if (mp_sf404021 != "")
			{
				bReturn = false;
			}
			if (mp_sf404022 != "")
			{
				bReturn = false;
			}
			if (mp_sf404023 != "")
			{
				bReturn = false;
			}
			if (mp_sf404024 != "")
			{
				bReturn = false;
			}
			if (mp_sf404025 != "")
			{
				bReturn = false;
			}
			if (mp_sf404026 != "")
			{
				bReturn = false;
			}
			if (mp_sf404027 != "")
			{
				bReturn = false;
			}
			if (mp_sf404028 != "")
			{
				bReturn = false;
			}
			if (mp_sf404029 != "")
			{
				bReturn = false;
			}
			if (mp_sf40402a != "")
			{
				bReturn = false;
			}
			if (mp_sf40402b != "")
			{
				bReturn = false;
			}
			if (mp_sf40402c != "")
			{
				bReturn = false;
			}
			if (mp_sf40402d != "")
			{
				bReturn = false;
			}
			if (mp_sf40402e != "")
			{
				bReturn = false;
			}
			if (mp_sf40402f != "")
			{
				bReturn = false;
			}
			if (mp_sf404030 != "")
			{
				bReturn = false;
			}
			if (mp_sf404031 != "")
			{
				bReturn = false;
			}
			if (mp_sf404032 != "")
			{
				bReturn = false;
			}
			if (mp_sf404033 != "")
			{
				bReturn = false;
			}
			if (mp_sf404034 != "")
			{
				bReturn = false;
			}
			if (mp_sf404035 != "")
			{
				bReturn = false;
			}
			if (mp_sf404036 != "")
			{
				bReturn = false;
			}
			if (mp_sf404037 != "")
			{
				bReturn = false;
			}
			if (mp_sf404038 != "")
			{
				bReturn = false;
			}
			if (mp_sf404039 != "")
			{
				bReturn = false;
			}
			if (mp_sf40403a != "")
			{
				bReturn = false;
			}
			if (mp_sf40403b != "")
			{
				bReturn = false;
			}
			if (mp_sf40403c != "")
			{
				bReturn = false;
			}
			if (mp_sf40403d != "")
			{
				bReturn = false;
			}
			if (mp_sf40403e != "")
			{
				bReturn = false;
			}
			if (mp_sf40403f != "")
			{
				bReturn = false;
			}
			if (mp_sf404040 != "")
			{
				bReturn = false;
			}
			if (mp_sf404041 != "")
			{
				bReturn = false;
			}
			if (mp_sf404042 != "")
			{
				bReturn = false;
			}
			if (mp_sf404043 != "")
			{
				bReturn = false;
			}
			if (mp_sf404044 != "")
			{
				bReturn = false;
			}
			if (mp_sf404045 != "")
			{
				bReturn = false;
			}
			if (mp_sf404046 != "")
			{
				bReturn = false;
			}
			if (mp_sf404047 != "")
			{
				bReturn = false;
			}
			if (mp_sf404048 != "")
			{
				bReturn = false;
			}
			if (mp_sf404049 != "")
			{
				bReturn = false;
			}
			if (mp_sf40404a != "")
			{
				bReturn = false;
			}
			if (mp_sf40404b != "")
			{
				bReturn = false;
			}
			if (mp_sf40404c != "")
			{
				bReturn = false;
			}
			if (mp_sf40404d != "")
			{
				bReturn = false;
			}
			if (mp_sf40404e != "")
			{
				bReturn = false;
			}
			if (mp_sf40404f != "")
			{
				bReturn = false;
			}
			if (mp_sf404050 != "")
			{
				bReturn = false;
			}
			if (mp_sf404051 != "")
			{
				bReturn = false;
			}
			if (mp_sf404052 != "")
			{
				bReturn = false;
			}
			if (mp_sf404053 != "")
			{
				bReturn = false;
			}
			if (mp_sf404054 != "")
			{
				bReturn = false;
			}
			if (mp_sf404055 != "")
			{
				bReturn = false;
			}
			if (mp_sf404056 != "")
			{
				bReturn = false;
			}
			if (mp_sf404057 != "")
			{
				bReturn = false;
			}
			if (mp_sf404058 != "")
			{
				bReturn = false;
			}
			if (mp_sf404059 != "")
			{
				bReturn = false;
			}
			if (mp_sf40405a != "")
			{
				bReturn = false;
			}
			if (mp_sf40405b != "")
			{
				bReturn = false;
			}
			if (mp_sf40405c != "")
			{
				bReturn = false;
			}
			if (mp_sf40405d != "")
			{
				bReturn = false;
			}
			if (mp_sf40405e != "")
			{
				bReturn = false;
			}
			if (mp_sf40405f != "")
			{
				bReturn = false;
			}
			if (mp_sf404060 != "")
			{
				bReturn = false;
			}
			if (mp_sf404061 != "")
			{
				bReturn = false;
			}
			if (mp_sf404062 != "")
			{
				bReturn = false;
			}
			if (mp_sf404063 != "")
			{
				bReturn = false;
			}
			if (mp_sf404064 != "")
			{
				bReturn = false;
			}
			if (mp_sf404065 != "")
			{
				bReturn = false;
			}
			if (mp_sf404066 != "")
			{
				bReturn = false;
			}
			if (mp_sf404067 != "")
			{
				bReturn = false;
			}
			if (mp_sf404068 != "")
			{
				bReturn = false;
			}
			if (mp_sf404069 != "")
			{
				bReturn = false;
			}
			if (mp_sf40406a != "")
			{
				bReturn = false;
			}
			if (mp_sf40406b != "")
			{
				bReturn = false;
			}
			if (mp_sf40406c != "")
			{
				bReturn = false;
			}
			if (mp_sf40406d != "")
			{
				bReturn = false;
			}
			if (mp_sf40406e != "")
			{
				bReturn = false;
			}
			if (mp_sf40406f != "")
			{
				bReturn = false;
			}
			if (mp_sf404070 != "")
			{
				bReturn = false;
			}
			if (mp_sf404071 != "")
			{
				bReturn = false;
			}
			if (mp_sf404072 != "")
			{
				bReturn = false;
			}
			if (mp_sf404073 != "")
			{
				bReturn = false;
			}
			if (mp_sf404074 != "")
			{
				bReturn = false;
			}
			if (mp_sf404075 != "")
			{
				bReturn = false;
			}
			if (mp_sf404076 != "")
			{
				bReturn = false;
			}
			if (mp_sf404077 != "")
			{
				bReturn = false;
			}
			if (mp_sf404078 != "")
			{
				bReturn = false;
			}
			if (mp_sf404079 != "")
			{
				bReturn = false;
			}
			if (mp_sf40407a != "")
			{
				bReturn = false;
			}
			if (mp_sf40407b != "")
			{
				bReturn = false;
			}
			if (mp_sf40407c != "")
			{
				bReturn = false;
			}
			if (mp_sf40407d != "")
			{
				bReturn = false;
			}
			if (mp_sf40407e != "")
			{
				bReturn = false;
			}
			if (mp_sf40407f != "")
			{
				bReturn = false;
			}
			if (mp_sf404080 != "")
			{
				bReturn = false;
			}
			if (mp_sf404081 != "")
			{
				bReturn = false;
			}
			if (mp_sf404082 != "")
			{
				bReturn = false;
			}
			if (mp_sf404083 != "")
			{
				bReturn = false;
			}
			if (mp_sf404084 != "")
			{
				bReturn = false;
			}
			if (mp_sf404085 != "")
			{
				bReturn = false;
			}
			if (mp_sf404086 != "")
			{
				bReturn = false;
			}
			if (mp_sf404087 != "")
			{
				bReturn = false;
			}
			if (mp_sf404088 != "")
			{
				bReturn = false;
			}
			if (mp_sf404089 != "")
			{
				bReturn = false;
			}
			if (mp_sf40408a != "")
			{
				bReturn = false;
			}
			if (mp_sf40408b != "")
			{
				bReturn = false;
			}
			if (mp_sf40408c != "")
			{
				bReturn = false;
			}
			if (mp_sf40408d != "")
			{
				bReturn = false;
			}
			if (mp_sf40408e != "")
			{
				bReturn = false;
			}
			if (mp_sf40408f != "")
			{
				bReturn = false;
			}
			if (mp_sf404090 != "")
			{
				bReturn = false;
			}
			if (mp_sf404091 != "")
			{
				bReturn = false;
			}
			if (mp_sf404092 != "")
			{
				bReturn = false;
			}
			if (mp_sf404093 != "")
			{
				bReturn = false;
			}
			if (mp_sf404094 != "")
			{
				bReturn = false;
			}
			if (mp_sf404095 != "")
			{
				bReturn = false;
			}
			if (mp_sf404096 != "")
			{
				bReturn = false;
			}
			if (mp_sf404097 != "")
			{
				bReturn = false;
			}
			if (mp_sf404098 != "")
			{
				bReturn = false;
			}
			if (mp_sf404099 != "")
			{
				bReturn = false;
			}
			if (mp_sf40409a != "")
			{
				bReturn = false;
			}
			if (mp_sf40409b != "")
			{
				bReturn = false;
			}
			if (mp_sf40409c != "")
			{
				bReturn = false;
			}
			if (mp_sf40409d != "")
			{
				bReturn = false;
			}
			if (mp_sf40409e != "")
			{
				bReturn = false;
			}
			if (mp_sf40409f != "")
			{
				bReturn = false;
			}
			if (mp_sf4040a0 != "")
			{
				bReturn = false;
			}
			if (mp_sf4040a1 != "")
			{
				bReturn = false;
			}
			if (mp_sf4040a2 != "")
			{
				bReturn = false;
			}
			if (mp_sf4040a3 != "")
			{
				bReturn = false;
			}
			if (mp_sf4040a4 != "")
			{
				bReturn = false;
			}
			if (mp_sf4040a5 != "")
			{
				bReturn = false;
			}
			if (mp_sf4040a6 != "")
			{
				bReturn = false;
			}
			if (mp_sf4040a7 != "")
			{
				bReturn = false;
			}
			if (mp_sf4040a8 != "")
			{
				bReturn = false;
			}
			if (mp_sf4040a9 != "")
			{
				bReturn = false;
			}
			if (mp_sf4040aa != "")
			{
				bReturn = false;
			}
			if (mp_sf4040ab != "")
			{
				bReturn = false;
			}
			if (mp_sf4040ac != "")
			{
				bReturn = false;
			}
			if (mp_sf4040ad != "")
			{
				bReturn = false;
			}
			if (mp_sf4040ae != "")
			{
				bReturn = false;
			}
			if (mp_sf4040af != "")
			{
				bReturn = false;
			}
			if (mp_sf4040b0 != "")
			{
				bReturn = false;
			}
			if (mp_sf4040b1 != "")
			{
				bReturn = false;
			}
			if (mp_sf4040b2 != "")
			{
				bReturn = false;
			}
			if (mp_sf4040b3 != "")
			{
				bReturn = false;
			}
			if (mp_sf4040b4 != "")
			{
				bReturn = false;
			}
			if (mp_sf4040b5 != "")
			{
				bReturn = false;
			}
			if (mp_sf4040b6 != "")
			{
				bReturn = false;
			}
			if (mp_sf4040b7 != "")
			{
				bReturn = false;
			}
			if (mp_sf4040b8 != "")
			{
				bReturn = false;
			}
			if (mp_sf4040b9 != "")
			{
				bReturn = false;
			}
			if (mp_sf4040ba != "")
			{
				bReturn = false;
			}
			if (mp_sf4040bb != "")
			{
				bReturn = false;
			}
			if (mp_sf4040bc != "")
			{
				bReturn = false;
			}
			if (mp_sf4040bd != "")
			{
				bReturn = false;
			}
			if (mp_sf4040be != "")
			{
				bReturn = false;
			}
			if (mp_sf4040bf != "")
			{
				bReturn = false;
			}
			if (mp_sf4040c0 != "")
			{
				bReturn = false;
			}
			if (mp_sf4040c1 != "")
			{
				bReturn = false;
			}
			if (mp_sf4040c2 != "")
			{
				bReturn = false;
			}
			if (mp_sf4040c3 != "")
			{
				bReturn = false;
			}
			if (mp_sf4040c4 != "")
			{
				bReturn = false;
			}
			if (mp_sf4040c5 != "")
			{
				bReturn = false;
			}
			if (mp_sf4040c6 != "")
			{
				bReturn = false;
			}
			if (mp_sf4040c7 != "")
			{
				bReturn = false;
			}
			if (mp_sf4040c8 != "")
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
			oXML.WriteProperty("PeakUnits", mp_fPeakUnits);
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
			oXML.WriteProperty("Summary", mp_bSummary);
			oXML.WriteProperty("SV", mp_fSV);
			oXML.WriteProperty("Units", mp_fUnits);
			oXML.WriteProperty("UpdateNeeded", mp_bUpdateNeeded);
			oXML.WriteProperty("VAC", mp_fVAC);
			oXML.WriteProperty("Work", mp_oWork);
			oXML.WriteProperty("WorkContour", mp_yWorkContour);
			oXML.WriteProperty("BCWS", mp_fBCWS);
			oXML.WriteProperty("BCWP", mp_fBCWP);
			oXML.WriteProperty("BookingType", mp_yBookingType);
			if (mp_oActualWorkProtected.IsNull() == false)
			{
				oXML.WriteProperty("ActualWorkProtected", mp_oActualWorkProtected);
			}
			if (mp_oActualOvertimeWorkProtected.IsNull() == false)
			{
				oXML.WriteProperty("ActualOvertimeWorkProtected", mp_oActualOvertimeWorkProtected);
			}
			if (mp_dtCreationDate.Ticks != 0)
			{
				oXML.WriteProperty("CreationDate", mp_dtCreationDate);
			}
			if (mp_sAssnOwner != "")
			{
				oXML.WriteProperty("AssnOwner", mp_sAssnOwner);
			}
			if (mp_sAssnOwnerGuid != "")
			{
				oXML.WriteProperty("AssnOwnerGuid", mp_sAssnOwnerGuid);
			}
			oXML.WriteProperty("BudgetCost", mp_cBudgetCost);
			if (mp_oBudgetWork.IsNull() == false)
			{
				oXML.WriteProperty("BudgetWork", mp_oBudgetWork);
			}
			if (mp_oExtendedAttribute_C.IsNull() == false)
			{
				mp_oExtendedAttribute_C.WriteObjectProtected(ref oXML);
			}
			if (mp_oBaseline_C.IsNull() == false)
			{
				mp_oBaseline_C.WriteObjectProtected(ref oXML);
			}
			if (mp_sf404000 != "")
			{
				oXML.WriteProperty("f404000", mp_sf404000);
			}
			if (mp_sf404001 != "")
			{
				oXML.WriteProperty("f404001", mp_sf404001);
			}
			if (mp_sf404002 != "")
			{
				oXML.WriteProperty("f404002", mp_sf404002);
			}
			if (mp_sf404003 != "")
			{
				oXML.WriteProperty("f404003", mp_sf404003);
			}
			if (mp_sf404004 != "")
			{
				oXML.WriteProperty("f404004", mp_sf404004);
			}
			if (mp_sf404005 != "")
			{
				oXML.WriteProperty("f404005", mp_sf404005);
			}
			if (mp_sf404006 != "")
			{
				oXML.WriteProperty("f404006", mp_sf404006);
			}
			if (mp_sf404007 != "")
			{
				oXML.WriteProperty("f404007", mp_sf404007);
			}
			if (mp_sf404008 != "")
			{
				oXML.WriteProperty("f404008", mp_sf404008);
			}
			if (mp_sf404009 != "")
			{
				oXML.WriteProperty("f404009", mp_sf404009);
			}
			if (mp_sf40400a != "")
			{
				oXML.WriteProperty("f40400a", mp_sf40400a);
			}
			if (mp_sf40400b != "")
			{
				oXML.WriteProperty("f40400b", mp_sf40400b);
			}
			if (mp_sf40400c != "")
			{
				oXML.WriteProperty("f40400c", mp_sf40400c);
			}
			if (mp_sf40400d != "")
			{
				oXML.WriteProperty("f40400d", mp_sf40400d);
			}
			if (mp_sf40400e != "")
			{
				oXML.WriteProperty("f40400e", mp_sf40400e);
			}
			if (mp_sf40400f != "")
			{
				oXML.WriteProperty("f40400f", mp_sf40400f);
			}
			if (mp_sf404010 != "")
			{
				oXML.WriteProperty("f404010", mp_sf404010);
			}
			if (mp_sf404011 != "")
			{
				oXML.WriteProperty("f404011", mp_sf404011);
			}
			if (mp_sf404012 != "")
			{
				oXML.WriteProperty("f404012", mp_sf404012);
			}
			if (mp_sf404013 != "")
			{
				oXML.WriteProperty("f404013", mp_sf404013);
			}
			if (mp_sf404014 != "")
			{
				oXML.WriteProperty("f404014", mp_sf404014);
			}
			if (mp_sf404015 != "")
			{
				oXML.WriteProperty("f404015", mp_sf404015);
			}
			if (mp_sf404016 != "")
			{
				oXML.WriteProperty("f404016", mp_sf404016);
			}
			if (mp_sf404017 != "")
			{
				oXML.WriteProperty("f404017", mp_sf404017);
			}
			if (mp_sf404018 != "")
			{
				oXML.WriteProperty("f404018", mp_sf404018);
			}
			if (mp_sf404019 != "")
			{
				oXML.WriteProperty("f404019", mp_sf404019);
			}
			if (mp_sf40401a != "")
			{
				oXML.WriteProperty("f40401a", mp_sf40401a);
			}
			if (mp_sf40401b != "")
			{
				oXML.WriteProperty("f40401b", mp_sf40401b);
			}
			if (mp_sf40401c != "")
			{
				oXML.WriteProperty("f40401c", mp_sf40401c);
			}
			if (mp_sf40401d != "")
			{
				oXML.WriteProperty("f40401d", mp_sf40401d);
			}
			if (mp_sf40401e != "")
			{
				oXML.WriteProperty("f40401e", mp_sf40401e);
			}
			if (mp_sf40401f != "")
			{
				oXML.WriteProperty("f40401f", mp_sf40401f);
			}
			if (mp_sf404020 != "")
			{
				oXML.WriteProperty("f404020", mp_sf404020);
			}
			if (mp_sf404021 != "")
			{
				oXML.WriteProperty("f404021", mp_sf404021);
			}
			if (mp_sf404022 != "")
			{
				oXML.WriteProperty("f404022", mp_sf404022);
			}
			if (mp_sf404023 != "")
			{
				oXML.WriteProperty("f404023", mp_sf404023);
			}
			if (mp_sf404024 != "")
			{
				oXML.WriteProperty("f404024", mp_sf404024);
			}
			if (mp_sf404025 != "")
			{
				oXML.WriteProperty("f404025", mp_sf404025);
			}
			if (mp_sf404026 != "")
			{
				oXML.WriteProperty("f404026", mp_sf404026);
			}
			if (mp_sf404027 != "")
			{
				oXML.WriteProperty("f404027", mp_sf404027);
			}
			if (mp_sf404028 != "")
			{
				oXML.WriteProperty("f404028", mp_sf404028);
			}
			if (mp_sf404029 != "")
			{
				oXML.WriteProperty("f404029", mp_sf404029);
			}
			if (mp_sf40402a != "")
			{
				oXML.WriteProperty("f40402a", mp_sf40402a);
			}
			if (mp_sf40402b != "")
			{
				oXML.WriteProperty("f40402b", mp_sf40402b);
			}
			if (mp_sf40402c != "")
			{
				oXML.WriteProperty("f40402c", mp_sf40402c);
			}
			if (mp_sf40402d != "")
			{
				oXML.WriteProperty("f40402d", mp_sf40402d);
			}
			if (mp_sf40402e != "")
			{
				oXML.WriteProperty("f40402e", mp_sf40402e);
			}
			if (mp_sf40402f != "")
			{
				oXML.WriteProperty("f40402f", mp_sf40402f);
			}
			if (mp_sf404030 != "")
			{
				oXML.WriteProperty("f404030", mp_sf404030);
			}
			if (mp_sf404031 != "")
			{
				oXML.WriteProperty("f404031", mp_sf404031);
			}
			if (mp_sf404032 != "")
			{
				oXML.WriteProperty("f404032", mp_sf404032);
			}
			if (mp_sf404033 != "")
			{
				oXML.WriteProperty("f404033", mp_sf404033);
			}
			if (mp_sf404034 != "")
			{
				oXML.WriteProperty("f404034", mp_sf404034);
			}
			if (mp_sf404035 != "")
			{
				oXML.WriteProperty("f404035", mp_sf404035);
			}
			if (mp_sf404036 != "")
			{
				oXML.WriteProperty("f404036", mp_sf404036);
			}
			if (mp_sf404037 != "")
			{
				oXML.WriteProperty("f404037", mp_sf404037);
			}
			if (mp_sf404038 != "")
			{
				oXML.WriteProperty("f404038", mp_sf404038);
			}
			if (mp_sf404039 != "")
			{
				oXML.WriteProperty("f404039", mp_sf404039);
			}
			if (mp_sf40403a != "")
			{
				oXML.WriteProperty("f40403a", mp_sf40403a);
			}
			if (mp_sf40403b != "")
			{
				oXML.WriteProperty("f40403b", mp_sf40403b);
			}
			if (mp_sf40403c != "")
			{
				oXML.WriteProperty("f40403c", mp_sf40403c);
			}
			if (mp_sf40403d != "")
			{
				oXML.WriteProperty("f40403d", mp_sf40403d);
			}
			if (mp_sf40403e != "")
			{
				oXML.WriteProperty("f40403e", mp_sf40403e);
			}
			if (mp_sf40403f != "")
			{
				oXML.WriteProperty("f40403f", mp_sf40403f);
			}
			if (mp_sf404040 != "")
			{
				oXML.WriteProperty("f404040", mp_sf404040);
			}
			if (mp_sf404041 != "")
			{
				oXML.WriteProperty("f404041", mp_sf404041);
			}
			if (mp_sf404042 != "")
			{
				oXML.WriteProperty("f404042", mp_sf404042);
			}
			if (mp_sf404043 != "")
			{
				oXML.WriteProperty("f404043", mp_sf404043);
			}
			if (mp_sf404044 != "")
			{
				oXML.WriteProperty("f404044", mp_sf404044);
			}
			if (mp_sf404045 != "")
			{
				oXML.WriteProperty("f404045", mp_sf404045);
			}
			if (mp_sf404046 != "")
			{
				oXML.WriteProperty("f404046", mp_sf404046);
			}
			if (mp_sf404047 != "")
			{
				oXML.WriteProperty("f404047", mp_sf404047);
			}
			if (mp_sf404048 != "")
			{
				oXML.WriteProperty("f404048", mp_sf404048);
			}
			if (mp_sf404049 != "")
			{
				oXML.WriteProperty("f404049", mp_sf404049);
			}
			if (mp_sf40404a != "")
			{
				oXML.WriteProperty("f40404a", mp_sf40404a);
			}
			if (mp_sf40404b != "")
			{
				oXML.WriteProperty("f40404b", mp_sf40404b);
			}
			if (mp_sf40404c != "")
			{
				oXML.WriteProperty("f40404c", mp_sf40404c);
			}
			if (mp_sf40404d != "")
			{
				oXML.WriteProperty("f40404d", mp_sf40404d);
			}
			if (mp_sf40404e != "")
			{
				oXML.WriteProperty("f40404e", mp_sf40404e);
			}
			if (mp_sf40404f != "")
			{
				oXML.WriteProperty("f40404f", mp_sf40404f);
			}
			if (mp_sf404050 != "")
			{
				oXML.WriteProperty("f404050", mp_sf404050);
			}
			if (mp_sf404051 != "")
			{
				oXML.WriteProperty("f404051", mp_sf404051);
			}
			if (mp_sf404052 != "")
			{
				oXML.WriteProperty("f404052", mp_sf404052);
			}
			if (mp_sf404053 != "")
			{
				oXML.WriteProperty("f404053", mp_sf404053);
			}
			if (mp_sf404054 != "")
			{
				oXML.WriteProperty("f404054", mp_sf404054);
			}
			if (mp_sf404055 != "")
			{
				oXML.WriteProperty("f404055", mp_sf404055);
			}
			if (mp_sf404056 != "")
			{
				oXML.WriteProperty("f404056", mp_sf404056);
			}
			if (mp_sf404057 != "")
			{
				oXML.WriteProperty("f404057", mp_sf404057);
			}
			if (mp_sf404058 != "")
			{
				oXML.WriteProperty("f404058", mp_sf404058);
			}
			if (mp_sf404059 != "")
			{
				oXML.WriteProperty("f404059", mp_sf404059);
			}
			if (mp_sf40405a != "")
			{
				oXML.WriteProperty("f40405a", mp_sf40405a);
			}
			if (mp_sf40405b != "")
			{
				oXML.WriteProperty("f40405b", mp_sf40405b);
			}
			if (mp_sf40405c != "")
			{
				oXML.WriteProperty("f40405c", mp_sf40405c);
			}
			if (mp_sf40405d != "")
			{
				oXML.WriteProperty("f40405d", mp_sf40405d);
			}
			if (mp_sf40405e != "")
			{
				oXML.WriteProperty("f40405e", mp_sf40405e);
			}
			if (mp_sf40405f != "")
			{
				oXML.WriteProperty("f40405f", mp_sf40405f);
			}
			if (mp_sf404060 != "")
			{
				oXML.WriteProperty("f404060", mp_sf404060);
			}
			if (mp_sf404061 != "")
			{
				oXML.WriteProperty("f404061", mp_sf404061);
			}
			if (mp_sf404062 != "")
			{
				oXML.WriteProperty("f404062", mp_sf404062);
			}
			if (mp_sf404063 != "")
			{
				oXML.WriteProperty("f404063", mp_sf404063);
			}
			if (mp_sf404064 != "")
			{
				oXML.WriteProperty("f404064", mp_sf404064);
			}
			if (mp_sf404065 != "")
			{
				oXML.WriteProperty("f404065", mp_sf404065);
			}
			if (mp_sf404066 != "")
			{
				oXML.WriteProperty("f404066", mp_sf404066);
			}
			if (mp_sf404067 != "")
			{
				oXML.WriteProperty("f404067", mp_sf404067);
			}
			if (mp_sf404068 != "")
			{
				oXML.WriteProperty("f404068", mp_sf404068);
			}
			if (mp_sf404069 != "")
			{
				oXML.WriteProperty("f404069", mp_sf404069);
			}
			if (mp_sf40406a != "")
			{
				oXML.WriteProperty("f40406a", mp_sf40406a);
			}
			if (mp_sf40406b != "")
			{
				oXML.WriteProperty("f40406b", mp_sf40406b);
			}
			if (mp_sf40406c != "")
			{
				oXML.WriteProperty("f40406c", mp_sf40406c);
			}
			if (mp_sf40406d != "")
			{
				oXML.WriteProperty("f40406d", mp_sf40406d);
			}
			if (mp_sf40406e != "")
			{
				oXML.WriteProperty("f40406e", mp_sf40406e);
			}
			if (mp_sf40406f != "")
			{
				oXML.WriteProperty("f40406f", mp_sf40406f);
			}
			if (mp_sf404070 != "")
			{
				oXML.WriteProperty("f404070", mp_sf404070);
			}
			if (mp_sf404071 != "")
			{
				oXML.WriteProperty("f404071", mp_sf404071);
			}
			if (mp_sf404072 != "")
			{
				oXML.WriteProperty("f404072", mp_sf404072);
			}
			if (mp_sf404073 != "")
			{
				oXML.WriteProperty("f404073", mp_sf404073);
			}
			if (mp_sf404074 != "")
			{
				oXML.WriteProperty("f404074", mp_sf404074);
			}
			if (mp_sf404075 != "")
			{
				oXML.WriteProperty("f404075", mp_sf404075);
			}
			if (mp_sf404076 != "")
			{
				oXML.WriteProperty("f404076", mp_sf404076);
			}
			if (mp_sf404077 != "")
			{
				oXML.WriteProperty("f404077", mp_sf404077);
			}
			if (mp_sf404078 != "")
			{
				oXML.WriteProperty("f404078", mp_sf404078);
			}
			if (mp_sf404079 != "")
			{
				oXML.WriteProperty("f404079", mp_sf404079);
			}
			if (mp_sf40407a != "")
			{
				oXML.WriteProperty("f40407a", mp_sf40407a);
			}
			if (mp_sf40407b != "")
			{
				oXML.WriteProperty("f40407b", mp_sf40407b);
			}
			if (mp_sf40407c != "")
			{
				oXML.WriteProperty("f40407c", mp_sf40407c);
			}
			if (mp_sf40407d != "")
			{
				oXML.WriteProperty("f40407d", mp_sf40407d);
			}
			if (mp_sf40407e != "")
			{
				oXML.WriteProperty("f40407e", mp_sf40407e);
			}
			if (mp_sf40407f != "")
			{
				oXML.WriteProperty("f40407f", mp_sf40407f);
			}
			if (mp_sf404080 != "")
			{
				oXML.WriteProperty("f404080", mp_sf404080);
			}
			if (mp_sf404081 != "")
			{
				oXML.WriteProperty("f404081", mp_sf404081);
			}
			if (mp_sf404082 != "")
			{
				oXML.WriteProperty("f404082", mp_sf404082);
			}
			if (mp_sf404083 != "")
			{
				oXML.WriteProperty("f404083", mp_sf404083);
			}
			if (mp_sf404084 != "")
			{
				oXML.WriteProperty("f404084", mp_sf404084);
			}
			if (mp_sf404085 != "")
			{
				oXML.WriteProperty("f404085", mp_sf404085);
			}
			if (mp_sf404086 != "")
			{
				oXML.WriteProperty("f404086", mp_sf404086);
			}
			if (mp_sf404087 != "")
			{
				oXML.WriteProperty("f404087", mp_sf404087);
			}
			if (mp_sf404088 != "")
			{
				oXML.WriteProperty("f404088", mp_sf404088);
			}
			if (mp_sf404089 != "")
			{
				oXML.WriteProperty("f404089", mp_sf404089);
			}
			if (mp_sf40408a != "")
			{
				oXML.WriteProperty("f40408a", mp_sf40408a);
			}
			if (mp_sf40408b != "")
			{
				oXML.WriteProperty("f40408b", mp_sf40408b);
			}
			if (mp_sf40408c != "")
			{
				oXML.WriteProperty("f40408c", mp_sf40408c);
			}
			if (mp_sf40408d != "")
			{
				oXML.WriteProperty("f40408d", mp_sf40408d);
			}
			if (mp_sf40408e != "")
			{
				oXML.WriteProperty("f40408e", mp_sf40408e);
			}
			if (mp_sf40408f != "")
			{
				oXML.WriteProperty("f40408f", mp_sf40408f);
			}
			if (mp_sf404090 != "")
			{
				oXML.WriteProperty("f404090", mp_sf404090);
			}
			if (mp_sf404091 != "")
			{
				oXML.WriteProperty("f404091", mp_sf404091);
			}
			if (mp_sf404092 != "")
			{
				oXML.WriteProperty("f404092", mp_sf404092);
			}
			if (mp_sf404093 != "")
			{
				oXML.WriteProperty("f404093", mp_sf404093);
			}
			if (mp_sf404094 != "")
			{
				oXML.WriteProperty("f404094", mp_sf404094);
			}
			if (mp_sf404095 != "")
			{
				oXML.WriteProperty("f404095", mp_sf404095);
			}
			if (mp_sf404096 != "")
			{
				oXML.WriteProperty("f404096", mp_sf404096);
			}
			if (mp_sf404097 != "")
			{
				oXML.WriteProperty("f404097", mp_sf404097);
			}
			if (mp_sf404098 != "")
			{
				oXML.WriteProperty("f404098", mp_sf404098);
			}
			if (mp_sf404099 != "")
			{
				oXML.WriteProperty("f404099", mp_sf404099);
			}
			if (mp_sf40409a != "")
			{
				oXML.WriteProperty("f40409a", mp_sf40409a);
			}
			if (mp_sf40409b != "")
			{
				oXML.WriteProperty("f40409b", mp_sf40409b);
			}
			if (mp_sf40409c != "")
			{
				oXML.WriteProperty("f40409c", mp_sf40409c);
			}
			if (mp_sf40409d != "")
			{
				oXML.WriteProperty("f40409d", mp_sf40409d);
			}
			if (mp_sf40409e != "")
			{
				oXML.WriteProperty("f40409e", mp_sf40409e);
			}
			if (mp_sf40409f != "")
			{
				oXML.WriteProperty("f40409f", mp_sf40409f);
			}
			if (mp_sf4040a0 != "")
			{
				oXML.WriteProperty("f4040a0", mp_sf4040a0);
			}
			if (mp_sf4040a1 != "")
			{
				oXML.WriteProperty("f4040a1", mp_sf4040a1);
			}
			if (mp_sf4040a2 != "")
			{
				oXML.WriteProperty("f4040a2", mp_sf4040a2);
			}
			if (mp_sf4040a3 != "")
			{
				oXML.WriteProperty("f4040a3", mp_sf4040a3);
			}
			if (mp_sf4040a4 != "")
			{
				oXML.WriteProperty("f4040a4", mp_sf4040a4);
			}
			if (mp_sf4040a5 != "")
			{
				oXML.WriteProperty("f4040a5", mp_sf4040a5);
			}
			if (mp_sf4040a6 != "")
			{
				oXML.WriteProperty("f4040a6", mp_sf4040a6);
			}
			if (mp_sf4040a7 != "")
			{
				oXML.WriteProperty("f4040a7", mp_sf4040a7);
			}
			if (mp_sf4040a8 != "")
			{
				oXML.WriteProperty("f4040a8", mp_sf4040a8);
			}
			if (mp_sf4040a9 != "")
			{
				oXML.WriteProperty("f4040a9", mp_sf4040a9);
			}
			if (mp_sf4040aa != "")
			{
				oXML.WriteProperty("f4040aa", mp_sf4040aa);
			}
			if (mp_sf4040ab != "")
			{
				oXML.WriteProperty("f4040ab", mp_sf4040ab);
			}
			if (mp_sf4040ac != "")
			{
				oXML.WriteProperty("f4040ac", mp_sf4040ac);
			}
			if (mp_sf4040ad != "")
			{
				oXML.WriteProperty("f4040ad", mp_sf4040ad);
			}
			if (mp_sf4040ae != "")
			{
				oXML.WriteProperty("f4040ae", mp_sf4040ae);
			}
			if (mp_sf4040af != "")
			{
				oXML.WriteProperty("f4040af", mp_sf4040af);
			}
			if (mp_sf4040b0 != "")
			{
				oXML.WriteProperty("f4040b0", mp_sf4040b0);
			}
			if (mp_sf4040b1 != "")
			{
				oXML.WriteProperty("f4040b1", mp_sf4040b1);
			}
			if (mp_sf4040b2 != "")
			{
				oXML.WriteProperty("f4040b2", mp_sf4040b2);
			}
			if (mp_sf4040b3 != "")
			{
				oXML.WriteProperty("f4040b3", mp_sf4040b3);
			}
			if (mp_sf4040b4 != "")
			{
				oXML.WriteProperty("f4040b4", mp_sf4040b4);
			}
			if (mp_sf4040b5 != "")
			{
				oXML.WriteProperty("f4040b5", mp_sf4040b5);
			}
			if (mp_sf4040b6 != "")
			{
				oXML.WriteProperty("f4040b6", mp_sf4040b6);
			}
			if (mp_sf4040b7 != "")
			{
				oXML.WriteProperty("f4040b7", mp_sf4040b7);
			}
			if (mp_sf4040b8 != "")
			{
				oXML.WriteProperty("f4040b8", mp_sf4040b8);
			}
			if (mp_sf4040b9 != "")
			{
				oXML.WriteProperty("f4040b9", mp_sf4040b9);
			}
			if (mp_sf4040ba != "")
			{
				oXML.WriteProperty("f4040ba", mp_sf4040ba);
			}
			if (mp_sf4040bb != "")
			{
				oXML.WriteProperty("f4040bb", mp_sf4040bb);
			}
			if (mp_sf4040bc != "")
			{
				oXML.WriteProperty("f4040bc", mp_sf4040bc);
			}
			if (mp_sf4040bd != "")
			{
				oXML.WriteProperty("f4040bd", mp_sf4040bd);
			}
			if (mp_sf4040be != "")
			{
				oXML.WriteProperty("f4040be", mp_sf4040be);
			}
			if (mp_sf4040bf != "")
			{
				oXML.WriteProperty("f4040bf", mp_sf4040bf);
			}
			if (mp_sf4040c0 != "")
			{
				oXML.WriteProperty("f4040c0", mp_sf4040c0);
			}
			if (mp_sf4040c1 != "")
			{
				oXML.WriteProperty("f4040c1", mp_sf4040c1);
			}
			if (mp_sf4040c2 != "")
			{
				oXML.WriteProperty("f4040c2", mp_sf4040c2);
			}
			if (mp_sf4040c3 != "")
			{
				oXML.WriteProperty("f4040c3", mp_sf4040c3);
			}
			if (mp_sf4040c4 != "")
			{
				oXML.WriteProperty("f4040c4", mp_sf4040c4);
			}
			if (mp_sf4040c5 != "")
			{
				oXML.WriteProperty("f4040c5", mp_sf4040c5);
			}
			if (mp_sf4040c6 != "")
			{
				oXML.WriteProperty("f4040c6", mp_sf4040c6);
			}
			if (mp_sf4040c7 != "")
			{
				oXML.WriteProperty("f4040c7", mp_sf4040c7);
			}
			if (mp_sf4040c8 != "")
			{
				oXML.WriteProperty("f4040c8", mp_sf4040c8);
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
			oXML.ReadProperty("PeakUnits", ref mp_fPeakUnits);
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
			oXML.ReadProperty("Summary", ref mp_bSummary);
			oXML.ReadProperty("SV", ref mp_fSV);
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
			oXML.ReadProperty("AssnOwner", ref mp_sAssnOwner);
			oXML.ReadProperty("AssnOwnerGuid", ref mp_sAssnOwnerGuid);
			oXML.ReadProperty("BudgetCost", ref mp_cBudgetCost);
			oXML.ReadProperty("BudgetWork", ref mp_oBudgetWork);
			mp_oExtendedAttribute_C.ReadObjectProtected(ref oXML);
			mp_oBaseline_C.ReadObjectProtected(ref oXML);
			oXML.ReadProperty("f404000", ref mp_sf404000);
			oXML.ReadProperty("f404001", ref mp_sf404001);
			oXML.ReadProperty("f404002", ref mp_sf404002);
			oXML.ReadProperty("f404003", ref mp_sf404003);
			oXML.ReadProperty("f404004", ref mp_sf404004);
			oXML.ReadProperty("f404005", ref mp_sf404005);
			oXML.ReadProperty("f404006", ref mp_sf404006);
			oXML.ReadProperty("f404007", ref mp_sf404007);
			oXML.ReadProperty("f404008", ref mp_sf404008);
			oXML.ReadProperty("f404009", ref mp_sf404009);
			oXML.ReadProperty("f40400a", ref mp_sf40400a);
			oXML.ReadProperty("f40400b", ref mp_sf40400b);
			oXML.ReadProperty("f40400c", ref mp_sf40400c);
			oXML.ReadProperty("f40400d", ref mp_sf40400d);
			oXML.ReadProperty("f40400e", ref mp_sf40400e);
			oXML.ReadProperty("f40400f", ref mp_sf40400f);
			oXML.ReadProperty("f404010", ref mp_sf404010);
			oXML.ReadProperty("f404011", ref mp_sf404011);
			oXML.ReadProperty("f404012", ref mp_sf404012);
			oXML.ReadProperty("f404013", ref mp_sf404013);
			oXML.ReadProperty("f404014", ref mp_sf404014);
			oXML.ReadProperty("f404015", ref mp_sf404015);
			oXML.ReadProperty("f404016", ref mp_sf404016);
			oXML.ReadProperty("f404017", ref mp_sf404017);
			oXML.ReadProperty("f404018", ref mp_sf404018);
			oXML.ReadProperty("f404019", ref mp_sf404019);
			oXML.ReadProperty("f40401a", ref mp_sf40401a);
			oXML.ReadProperty("f40401b", ref mp_sf40401b);
			oXML.ReadProperty("f40401c", ref mp_sf40401c);
			oXML.ReadProperty("f40401d", ref mp_sf40401d);
			oXML.ReadProperty("f40401e", ref mp_sf40401e);
			oXML.ReadProperty("f40401f", ref mp_sf40401f);
			oXML.ReadProperty("f404020", ref mp_sf404020);
			oXML.ReadProperty("f404021", ref mp_sf404021);
			oXML.ReadProperty("f404022", ref mp_sf404022);
			oXML.ReadProperty("f404023", ref mp_sf404023);
			oXML.ReadProperty("f404024", ref mp_sf404024);
			oXML.ReadProperty("f404025", ref mp_sf404025);
			oXML.ReadProperty("f404026", ref mp_sf404026);
			oXML.ReadProperty("f404027", ref mp_sf404027);
			oXML.ReadProperty("f404028", ref mp_sf404028);
			oXML.ReadProperty("f404029", ref mp_sf404029);
			oXML.ReadProperty("f40402a", ref mp_sf40402a);
			oXML.ReadProperty("f40402b", ref mp_sf40402b);
			oXML.ReadProperty("f40402c", ref mp_sf40402c);
			oXML.ReadProperty("f40402d", ref mp_sf40402d);
			oXML.ReadProperty("f40402e", ref mp_sf40402e);
			oXML.ReadProperty("f40402f", ref mp_sf40402f);
			oXML.ReadProperty("f404030", ref mp_sf404030);
			oXML.ReadProperty("f404031", ref mp_sf404031);
			oXML.ReadProperty("f404032", ref mp_sf404032);
			oXML.ReadProperty("f404033", ref mp_sf404033);
			oXML.ReadProperty("f404034", ref mp_sf404034);
			oXML.ReadProperty("f404035", ref mp_sf404035);
			oXML.ReadProperty("f404036", ref mp_sf404036);
			oXML.ReadProperty("f404037", ref mp_sf404037);
			oXML.ReadProperty("f404038", ref mp_sf404038);
			oXML.ReadProperty("f404039", ref mp_sf404039);
			oXML.ReadProperty("f40403a", ref mp_sf40403a);
			oXML.ReadProperty("f40403b", ref mp_sf40403b);
			oXML.ReadProperty("f40403c", ref mp_sf40403c);
			oXML.ReadProperty("f40403d", ref mp_sf40403d);
			oXML.ReadProperty("f40403e", ref mp_sf40403e);
			oXML.ReadProperty("f40403f", ref mp_sf40403f);
			oXML.ReadProperty("f404040", ref mp_sf404040);
			oXML.ReadProperty("f404041", ref mp_sf404041);
			oXML.ReadProperty("f404042", ref mp_sf404042);
			oXML.ReadProperty("f404043", ref mp_sf404043);
			oXML.ReadProperty("f404044", ref mp_sf404044);
			oXML.ReadProperty("f404045", ref mp_sf404045);
			oXML.ReadProperty("f404046", ref mp_sf404046);
			oXML.ReadProperty("f404047", ref mp_sf404047);
			oXML.ReadProperty("f404048", ref mp_sf404048);
			oXML.ReadProperty("f404049", ref mp_sf404049);
			oXML.ReadProperty("f40404a", ref mp_sf40404a);
			oXML.ReadProperty("f40404b", ref mp_sf40404b);
			oXML.ReadProperty("f40404c", ref mp_sf40404c);
			oXML.ReadProperty("f40404d", ref mp_sf40404d);
			oXML.ReadProperty("f40404e", ref mp_sf40404e);
			oXML.ReadProperty("f40404f", ref mp_sf40404f);
			oXML.ReadProperty("f404050", ref mp_sf404050);
			oXML.ReadProperty("f404051", ref mp_sf404051);
			oXML.ReadProperty("f404052", ref mp_sf404052);
			oXML.ReadProperty("f404053", ref mp_sf404053);
			oXML.ReadProperty("f404054", ref mp_sf404054);
			oXML.ReadProperty("f404055", ref mp_sf404055);
			oXML.ReadProperty("f404056", ref mp_sf404056);
			oXML.ReadProperty("f404057", ref mp_sf404057);
			oXML.ReadProperty("f404058", ref mp_sf404058);
			oXML.ReadProperty("f404059", ref mp_sf404059);
			oXML.ReadProperty("f40405a", ref mp_sf40405a);
			oXML.ReadProperty("f40405b", ref mp_sf40405b);
			oXML.ReadProperty("f40405c", ref mp_sf40405c);
			oXML.ReadProperty("f40405d", ref mp_sf40405d);
			oXML.ReadProperty("f40405e", ref mp_sf40405e);
			oXML.ReadProperty("f40405f", ref mp_sf40405f);
			oXML.ReadProperty("f404060", ref mp_sf404060);
			oXML.ReadProperty("f404061", ref mp_sf404061);
			oXML.ReadProperty("f404062", ref mp_sf404062);
			oXML.ReadProperty("f404063", ref mp_sf404063);
			oXML.ReadProperty("f404064", ref mp_sf404064);
			oXML.ReadProperty("f404065", ref mp_sf404065);
			oXML.ReadProperty("f404066", ref mp_sf404066);
			oXML.ReadProperty("f404067", ref mp_sf404067);
			oXML.ReadProperty("f404068", ref mp_sf404068);
			oXML.ReadProperty("f404069", ref mp_sf404069);
			oXML.ReadProperty("f40406a", ref mp_sf40406a);
			oXML.ReadProperty("f40406b", ref mp_sf40406b);
			oXML.ReadProperty("f40406c", ref mp_sf40406c);
			oXML.ReadProperty("f40406d", ref mp_sf40406d);
			oXML.ReadProperty("f40406e", ref mp_sf40406e);
			oXML.ReadProperty("f40406f", ref mp_sf40406f);
			oXML.ReadProperty("f404070", ref mp_sf404070);
			oXML.ReadProperty("f404071", ref mp_sf404071);
			oXML.ReadProperty("f404072", ref mp_sf404072);
			oXML.ReadProperty("f404073", ref mp_sf404073);
			oXML.ReadProperty("f404074", ref mp_sf404074);
			oXML.ReadProperty("f404075", ref mp_sf404075);
			oXML.ReadProperty("f404076", ref mp_sf404076);
			oXML.ReadProperty("f404077", ref mp_sf404077);
			oXML.ReadProperty("f404078", ref mp_sf404078);
			oXML.ReadProperty("f404079", ref mp_sf404079);
			oXML.ReadProperty("f40407a", ref mp_sf40407a);
			oXML.ReadProperty("f40407b", ref mp_sf40407b);
			oXML.ReadProperty("f40407c", ref mp_sf40407c);
			oXML.ReadProperty("f40407d", ref mp_sf40407d);
			oXML.ReadProperty("f40407e", ref mp_sf40407e);
			oXML.ReadProperty("f40407f", ref mp_sf40407f);
			oXML.ReadProperty("f404080", ref mp_sf404080);
			oXML.ReadProperty("f404081", ref mp_sf404081);
			oXML.ReadProperty("f404082", ref mp_sf404082);
			oXML.ReadProperty("f404083", ref mp_sf404083);
			oXML.ReadProperty("f404084", ref mp_sf404084);
			oXML.ReadProperty("f404085", ref mp_sf404085);
			oXML.ReadProperty("f404086", ref mp_sf404086);
			oXML.ReadProperty("f404087", ref mp_sf404087);
			oXML.ReadProperty("f404088", ref mp_sf404088);
			oXML.ReadProperty("f404089", ref mp_sf404089);
			oXML.ReadProperty("f40408a", ref mp_sf40408a);
			oXML.ReadProperty("f40408b", ref mp_sf40408b);
			oXML.ReadProperty("f40408c", ref mp_sf40408c);
			oXML.ReadProperty("f40408d", ref mp_sf40408d);
			oXML.ReadProperty("f40408e", ref mp_sf40408e);
			oXML.ReadProperty("f40408f", ref mp_sf40408f);
			oXML.ReadProperty("f404090", ref mp_sf404090);
			oXML.ReadProperty("f404091", ref mp_sf404091);
			oXML.ReadProperty("f404092", ref mp_sf404092);
			oXML.ReadProperty("f404093", ref mp_sf404093);
			oXML.ReadProperty("f404094", ref mp_sf404094);
			oXML.ReadProperty("f404095", ref mp_sf404095);
			oXML.ReadProperty("f404096", ref mp_sf404096);
			oXML.ReadProperty("f404097", ref mp_sf404097);
			oXML.ReadProperty("f404098", ref mp_sf404098);
			oXML.ReadProperty("f404099", ref mp_sf404099);
			oXML.ReadProperty("f40409a", ref mp_sf40409a);
			oXML.ReadProperty("f40409b", ref mp_sf40409b);
			oXML.ReadProperty("f40409c", ref mp_sf40409c);
			oXML.ReadProperty("f40409d", ref mp_sf40409d);
			oXML.ReadProperty("f40409e", ref mp_sf40409e);
			oXML.ReadProperty("f40409f", ref mp_sf40409f);
			oXML.ReadProperty("f4040a0", ref mp_sf4040a0);
			oXML.ReadProperty("f4040a1", ref mp_sf4040a1);
			oXML.ReadProperty("f4040a2", ref mp_sf4040a2);
			oXML.ReadProperty("f4040a3", ref mp_sf4040a3);
			oXML.ReadProperty("f4040a4", ref mp_sf4040a4);
			oXML.ReadProperty("f4040a5", ref mp_sf4040a5);
			oXML.ReadProperty("f4040a6", ref mp_sf4040a6);
			oXML.ReadProperty("f4040a7", ref mp_sf4040a7);
			oXML.ReadProperty("f4040a8", ref mp_sf4040a8);
			oXML.ReadProperty("f4040a9", ref mp_sf4040a9);
			oXML.ReadProperty("f4040aa", ref mp_sf4040aa);
			oXML.ReadProperty("f4040ab", ref mp_sf4040ab);
			oXML.ReadProperty("f4040ac", ref mp_sf4040ac);
			oXML.ReadProperty("f4040ad", ref mp_sf4040ad);
			oXML.ReadProperty("f4040ae", ref mp_sf4040ae);
			oXML.ReadProperty("f4040af", ref mp_sf4040af);
			oXML.ReadProperty("f4040b0", ref mp_sf4040b0);
			oXML.ReadProperty("f4040b1", ref mp_sf4040b1);
			oXML.ReadProperty("f4040b2", ref mp_sf4040b2);
			oXML.ReadProperty("f4040b3", ref mp_sf4040b3);
			oXML.ReadProperty("f4040b4", ref mp_sf4040b4);
			oXML.ReadProperty("f4040b5", ref mp_sf4040b5);
			oXML.ReadProperty("f4040b6", ref mp_sf4040b6);
			oXML.ReadProperty("f4040b7", ref mp_sf4040b7);
			oXML.ReadProperty("f4040b8", ref mp_sf4040b8);
			oXML.ReadProperty("f4040b9", ref mp_sf4040b9);
			oXML.ReadProperty("f4040ba", ref mp_sf4040ba);
			oXML.ReadProperty("f4040bb", ref mp_sf4040bb);
			oXML.ReadProperty("f4040bc", ref mp_sf4040bc);
			oXML.ReadProperty("f4040bd", ref mp_sf4040bd);
			oXML.ReadProperty("f4040be", ref mp_sf4040be);
			oXML.ReadProperty("f4040bf", ref mp_sf4040bf);
			oXML.ReadProperty("f4040c0", ref mp_sf4040c0);
			oXML.ReadProperty("f4040c1", ref mp_sf4040c1);
			oXML.ReadProperty("f4040c2", ref mp_sf4040c2);
			oXML.ReadProperty("f4040c3", ref mp_sf4040c3);
			oXML.ReadProperty("f4040c4", ref mp_sf4040c4);
			oXML.ReadProperty("f4040c5", ref mp_sf4040c5);
			oXML.ReadProperty("f4040c6", ref mp_sf4040c6);
			oXML.ReadProperty("f4040c7", ref mp_sf4040c7);
			oXML.ReadProperty("f4040c8", ref mp_sf4040c8);
			mp_oTimephasedData_C.ReadObjectProtected(ref oXML);
		}

	}
}
