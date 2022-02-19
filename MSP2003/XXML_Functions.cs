using System;
using System.IO;
using System.Xml;

namespace MSP2003
{
	internal partial class clsXML
	{
		// ----------------------------------------------------------------------------------------
		// Microsoft Project 2003 XML Functions
		// ----------------------------------------------------------------------------------------

		internal void ReadProperty(string sElementName, ref E_FYSTARTDATE sElementValue)
		{
			sElementValue = (E_FYSTARTDATE) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_CURRENCYSYMBOLPOSITION sElementValue)
		{
			sElementValue = (E_CURRENCYSYMBOLPOSITION) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_DEFAULTTASKTYPE sElementValue)
		{
			sElementValue = (E_DEFAULTTASKTYPE) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_DEFAULTFIXEDCOSTACCRUAL sElementValue)
		{
			sElementValue = (E_DEFAULTFIXEDCOSTACCRUAL) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_DURATIONFORMAT sElementValue)
		{
			sElementValue = (E_DURATIONFORMAT) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_WORKFORMAT sElementValue)
		{
			sElementValue = (E_WORKFORMAT) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_EARNEDVALUEMETHOD sElementValue)
		{
			sElementValue = (E_EARNEDVALUEMETHOD) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_WEEKSTARTDAY sElementValue)
		{
			sElementValue = (E_WEEKSTARTDAY) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_BASELINEFOREARNEDVALUE sElementValue)
		{
			sElementValue = (E_BASELINEFOREARNEDVALUE) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_NEWTASKSTARTDATE sElementValue)
		{
			sElementValue = (E_NEWTASKSTARTDATE) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_DEFAULTTASKEVMETHOD sElementValue)
		{
			sElementValue = (E_DEFAULTTASKEVMETHOD) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_TYPE sElementValue)
		{
			sElementValue = (E_TYPE) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_TYPE_1 sElementValue)
		{
			sElementValue = (E_TYPE_1) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_ROLLUPTYPE sElementValue)
		{
			sElementValue = (E_ROLLUPTYPE) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_CALCULATIONTYPE sElementValue)
		{
			sElementValue = (E_CALCULATIONTYPE) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_VALUELISTSORTORDER sElementValue)
		{
			sElementValue = (E_VALUELISTSORTORDER) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_DAYTYPE sElementValue)
		{
			sElementValue = (E_DAYTYPE) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_TYPE_2 sElementValue)
		{
			sElementValue = (E_TYPE_2) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_FIXEDCOSTACCRUAL sElementValue)
		{
			sElementValue = (E_FIXEDCOSTACCRUAL) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_CONSTRAINTTYPE sElementValue)
		{
			sElementValue = (E_CONSTRAINTTYPE) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_LEVELINGDELAYFORMAT sElementValue)
		{
			sElementValue = (E_LEVELINGDELAYFORMAT) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_TYPE_3 sElementValue)
		{
			sElementValue = (E_TYPE_3) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_LAGFORMAT sElementValue)
		{
			sElementValue = (E_LAGFORMAT) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_TYPE_4 sElementValue)
		{
			sElementValue = (E_TYPE_4) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_WORKGROUP sElementValue)
		{
			sElementValue = (E_WORKGROUP) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_ACCRUEAT sElementValue)
		{
			sElementValue = (E_ACCRUEAT) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_STANDARDRATEFORMAT sElementValue)
		{
			sElementValue = (E_STANDARDRATEFORMAT) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_OVERTIMERATEFORMAT sElementValue)
		{
			sElementValue = (E_OVERTIMERATEFORMAT) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_BOOKINGTYPE sElementValue)
		{
			sElementValue = (E_BOOKINGTYPE) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_RATETABLE sElementValue)
		{
			sElementValue = (E_RATETABLE) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_STANDARDRATEFORMAT_1 sElementValue)
		{
			sElementValue = (E_STANDARDRATEFORMAT_1) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_COSTRATETABLE sElementValue)
		{
			sElementValue = (E_COSTRATETABLE) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_WORKCONTOUR sElementValue)
		{
			sElementValue = (E_WORKCONTOUR) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_TYPE_5 sElementValue)
		{
			sElementValue = (E_TYPE_5) yReadProperty(sElementName, (int) sElementValue);
		}

		internal void ReadProperty(string sElementName, ref E_UNIT sElementValue)
		{
			sElementValue = (E_UNIT) yReadProperty(sElementName, (int) sElementValue);
		}
	}
}
