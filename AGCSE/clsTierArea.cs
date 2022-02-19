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

	public class clsTierArea
	{
		ActiveGanttCSECtl mp_oControl;
		clsTier mp_oUpperTier;
		clsTier mp_oMiddleTier;
		clsTier mp_oLowerTier;
		clsTierFormat mp_oTierFormat;
		clsTierAppearance mp_oTierAppearance;
		clsTimeLine mp_oTimeLine;

		public clsTierArea(ActiveGanttCSECtl Value, clsTimeLine oTimeLine)
		{
			mp_oControl = Value;
			mp_oTimeLine = oTimeLine;
			mp_oUpperTier = new clsTier(mp_oControl, this, E_TIERPOSITION.SP_UPPER);
			mp_oMiddleTier = new clsTier(mp_oControl, this, E_TIERPOSITION.SP_MIDDLE);
			mp_oLowerTier = new clsTier(mp_oControl, this, E_TIERPOSITION.SP_LOWER);
			mp_oTierFormat = new clsTierFormat(mp_oControl);
			mp_oTierAppearance = new clsTierAppearance(mp_oControl);
		}

		public clsTier UpperTier 
		{
			get 
			{
				return mp_oUpperTier;
			}
		}

		public clsTier MiddleTier 
		{
			get 
			{
				return mp_oMiddleTier;
			}
		}

		public clsTier LowerTier 
		{
			get 
			{
				return mp_oLowerTier;
			}
		}

		public clsTierFormat TierFormat 
		{
			get 
			{
				return mp_oTierFormat;
			}
		}

		public clsTierAppearance TierAppearance 
		{
			get 
			{
				return mp_oTierAppearance;
			}
		}

		internal clsTimeLine TimeLine 
		{
			get 
			{
				return mp_oTimeLine;
			}
		}

        public String GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "TierArea");
            oXML.InitializeWriter();
            oXML.WriteObject(LowerTier.GetXML());
            oXML.WriteObject(MiddleTier.GetXML());
            oXML.WriteObject(TierAppearance.GetXML());
            oXML.WriteObject(TierFormat.GetXML());
            oXML.WriteObject(UpperTier.GetXML());
            return oXML.GetXML();
        }

        public void SetXML(String sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "TierArea");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            LowerTier.SetXML(oXML.ReadObject("LowerTier"));
            MiddleTier.SetXML(oXML.ReadObject("MiddleTier"));
            TierAppearance.SetXML(oXML.ReadObject("TierAppearance"));
            TierFormat.SetXML(oXML.ReadObject("TierFormat"));
            UpperTier.SetXML(oXML.ReadObject("UpperTier"));
        }



	}
}
