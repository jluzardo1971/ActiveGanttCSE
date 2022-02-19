using System;

namespace MSP2003
{
	public class ResourceRate : clsItemBase
	{

		internal clsCollectionBase mp_oCollection;
		private System.DateTime mp_dtRatesFrom;
		private System.DateTime mp_dtRatesTo;
		private E_RATETABLE mp_yRateTable;
		private Decimal mp_cStandardRate;
		private E_STANDARDRATEFORMAT_1 mp_yStandardRateFormat;
		private Decimal mp_cOvertimeRate;
		private E_OVERTIMERATEFORMAT mp_yOvertimeRateFormat;
		private Decimal mp_cCostPerUse;

		public ResourceRate()
		{
			mp_dtRatesFrom = new System.DateTime(0);
			mp_dtRatesTo = new System.DateTime(0);
			mp_yRateTable = E_RATETABLE.RT_A;
			mp_cStandardRate = 0;
			mp_yStandardRateFormat = E_STANDARDRATEFORMAT_1.SRF_1_M;
			mp_cOvertimeRate = 0;
			mp_yOvertimeRateFormat = E_OVERTIMERATEFORMAT.ORF_M;
			mp_cCostPerUse = 0;
		}

		public System.DateTime dtRatesFrom
		{
			get
			{
				return mp_dtRatesFrom;
			}
			set
			{
				mp_dtRatesFrom = value;
			}
		}

		public System.DateTime dtRatesTo
		{
			get
			{
				return mp_dtRatesTo;
			}
			set
			{
				mp_dtRatesTo = value;
			}
		}

		public E_RATETABLE yRateTable
		{
			get
			{
				return mp_yRateTable;
			}
			set
			{
				mp_yRateTable = value;
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

		public E_STANDARDRATEFORMAT_1 yStandardRateFormat
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
		public string Key
		{
			get { return mp_sKey; }
			set { mp_oCollection.mp_SetKey(ref mp_sKey, value, SYS_ERRORS.MP_SET_KEY); }
		}

		public bool IsNull()
		{
			bool bReturn = true;
			if (mp_dtRatesFrom.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_dtRatesTo.Ticks != 0)
			{
				bReturn = false;
			}
			if (mp_yRateTable != E_RATETABLE.RT_A)
			{
				bReturn = false;
			}
			if (mp_cStandardRate != 0)
			{
				bReturn = false;
			}
			if (mp_yStandardRateFormat != E_STANDARDRATEFORMAT_1.SRF_1_M)
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
			if (mp_cCostPerUse != 0)
			{
				bReturn = false;
			}
			return bReturn;
		}

		public string GetXML()
		{
			if (IsNull() == true)
			{
				return "<Rate/>";
			}
			clsXML oXML = new clsXML("Rate");
			oXML.InitializeWriter();
			oXML.SupportOptional = true;
			oXML.BoolsAreNumeric = true;
			if (mp_dtRatesFrom.Ticks != 0)
			{
				oXML.WriteProperty("RatesFrom", mp_dtRatesFrom);
			}
			if (mp_dtRatesTo.Ticks != 0)
			{
				oXML.WriteProperty("RatesTo", mp_dtRatesTo);
			}
			oXML.WriteProperty("RateTable", mp_yRateTable);
			oXML.WriteProperty("StandardRate", mp_cStandardRate);
			oXML.WriteProperty("StandardRateFormat", mp_yStandardRateFormat);
			oXML.WriteProperty("OvertimeRate", mp_cOvertimeRate);
			oXML.WriteProperty("OvertimeRateFormat", mp_yOvertimeRateFormat);
			oXML.WriteProperty("CostPerUse", mp_cCostPerUse);
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML("Rate");
			oXML.SupportOptional = true;
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("RatesFrom", ref mp_dtRatesFrom);
			oXML.ReadProperty("RatesTo", ref mp_dtRatesTo);
			oXML.ReadProperty("RateTable", ref mp_yRateTable);
			oXML.ReadProperty("StandardRate", ref mp_cStandardRate);
			oXML.ReadProperty("StandardRateFormat", ref mp_yStandardRateFormat);
			oXML.ReadProperty("OvertimeRate", ref mp_cOvertimeRate);
			oXML.ReadProperty("OvertimeRateFormat", ref mp_yOvertimeRateFormat);
			oXML.ReadProperty("CostPerUse", ref mp_cCostPerUse);
		}

	}
}
